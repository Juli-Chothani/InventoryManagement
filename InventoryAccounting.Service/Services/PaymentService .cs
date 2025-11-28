using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryAccounting.Core.Interfaces;

namespace InventoryAccounting.Service.Services
{

    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _uow;

        public PaymentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> CreatePaymentAsync(int supplierId, decimal amount, string? remarks)
        {
            try
            {
                // 1. Insert Payment Header
                int paymentId = await _uow.Payments.CreatePaymentAsync(
                    supplierId,
                    DateTime.UtcNow,
                    amount,
                    remarks
                );

                // 2. Ledger Posting

                // Supplier A/c (Debit)
                await _uow.Ledger.InsertEntryAsync(
                    entryDate: DateTime.UtcNow,
                    accountId: supplierId,       // Supplier account
                    reference: $"Payment #{paymentId} to Supplier {supplierId}",
                    debit: amount,
                    credit: 0
                );

                // Cash/Bank A/c (Credit)
                await _uow.Ledger.InsertEntryAsync(
                    entryDate: DateTime.UtcNow,
                    accountId: 1,                // Cash Account
                    reference: $"Payment #{paymentId} to Supplier {supplierId}",
                    debit: 0,
                    credit: amount
                );

                await _uow.CommitAsync();
                return paymentId;
            }
            catch
            {
                await _uow.RollbackAsync();
                throw;
            }
        }
    }

}
