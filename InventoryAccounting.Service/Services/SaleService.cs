using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Service.Services
{
    public class SaleService
    {
        private readonly IUnitOfWork _uow;

        public SaleService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> CreateSaleAsync(CreateSaleDto dto)
        {
            decimal totalAmount = dto.Items.Sum(x => x.Quantity * x.UnitPrice);

            var saleId = await _uow.Sales.CreateSaleHeaderAsync(
                dto.CustomerId,
                dto.SaleDate,
                totalAmount,
                dto.Remarks
            );

            foreach (var item in dto.Items)
            {
                await _uow.Sales.CreateSaleItemAsync(saleId, item.ItemId, item.Quantity, item.UnitPrice);

                // reduce stock
                await _uow.Items.UpdateItemStock(item.ItemId, -item.Quantity);

                // ledger entries
                await _uow.Ledger.InsertEntryAsync(dto.SaleDate, 2, $"Sale:{saleId} Item:{item.ItemId}", 0, item.Quantity * item.UnitPrice);
                await _uow.Ledger.InsertEntryAsync(dto.SaleDate, 1, $"Sale:{saleId} Item:{item.ItemId}", item.Quantity * item.UnitPrice, 0);
            }

            await _uow.CommitAsync();

            return saleId;
        }
    }

}
