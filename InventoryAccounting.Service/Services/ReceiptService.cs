using InventoryAccounting.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace InventoryAccounting.Service.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IUnitOfWork _uow;

        public ReceiptService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> CreateReceiptAsync(int customerId, decimal amount, string remarks)
        {
            try
            {
                var receiptId = await _uow.Receipts.CreateReceiptAsync(customerId, DateTime.UtcNow, amount, remarks);

                await _uow.Ledger.InsertEntryAsync(DateTime.UtcNow, /*cashAccountId*/ 1, $"Receipt #{receiptId} from Customer {customerId}", amount, 0m);
                await _uow.Ledger.InsertEntryAsync(DateTime.UtcNow, /*customerAccountId*/ customerId, $"Receipt #{receiptId} by Customer {customerId}", 0m, amount);

                await _uow.CommitAsync();
                return receiptId;
            }
            catch
            {
                await _uow.RollbackAsync();
                throw;
            }
        }
    }
}
