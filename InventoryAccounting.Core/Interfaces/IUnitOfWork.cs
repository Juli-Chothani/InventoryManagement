using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPurchaseRepository Purchases { get; }
        IItemRepository Items { get; }
        ILedgerRepository Ledger { get; }
        ISaleRepository Sales { get; }
        IReceiptRepository Receipts { get; }
        IPaymentRepository Payments { get; }
        IItemMasterRepository Item { get; }

        IAccountRepository Accounts { get; }

        ISupplierRepository Suppliers { get; }
        Task CommitAsync();
        Task RollbackAsync();
    }
}
