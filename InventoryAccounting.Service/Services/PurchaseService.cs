using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace InventoryAccounting.Service.Services
{
    public class PurchaseService
    {
        private readonly Func<IUnitOfWork> _uowFactory;
        private readonly ILogger<PurchaseService>? _logger;

        private const int InventoryAccountId = 1;
        private const int AccountsPayableAccountId = 2;

        public PurchaseService(Func<IUnitOfWork> uowFactory, ILogger<PurchaseService>? logger = null)
        {
            _uowFactory = uowFactory;
            _logger = logger;
        }

        public async Task<int> CreatePurchaseAsync(PurchaseDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (dto.Items == null || !dto.Items.Any()) throw new ArgumentException("At least one item required");

            // compute total
            var total = dto.Items.Sum(i => i.Quantity * i.UnitPrice);

            using var uow = _uowFactory();

            try
            {
                var purchaseId = await uow.Purchases.CreateHeaderAsync(dto.SupplierId, dto.PurchaseDate, total, dto.Remarks);

                // 2. for each item: create item row, update stock, ledger entries
                foreach (var it in dto.Items)
                {
                    var purchaseItemId = await uow.Purchases.CreateItemAsync(purchaseId,it.ItemId,it.Quantity,it.UnitPrice);

                    // update stock (increase)
                    await uow.Items.UpdateItemStock(it.ItemId, it.Quantity);

                    // ledger: Debit Inventory, Credit Accounts Payable (supplier)
                    var reference = $"Purchase:{purchaseId} Item:{purchaseItemId}";
                    var amount = it.Quantity * it.UnitPrice;

                    await uow.Ledger.InsertEntryAsync(DateTime.UtcNow, InventoryAccountId, reference, amount, 0m);
                    await uow.Ledger.InsertEntryAsync(DateTime.UtcNow, AccountsPayableAccountId, reference, 0m, amount);
                }

                await uow.CommitAsync();

                return purchaseId;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error creating purchase");
                await uow.RollbackAsync();
                throw;
            }
        }
    }
}

