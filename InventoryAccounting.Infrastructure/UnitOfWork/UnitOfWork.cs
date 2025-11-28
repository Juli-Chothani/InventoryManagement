using InventoryAccounting.Core.Interfaces;
using InventoryAccounting.Infrastructure.Repositories;
using InventoryAccounting.Infrastructure.Database;
using System;
using System.Data;

namespace InventoryAccounting.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public IPurchaseRepository Purchases { get; }
        public IItemRepository Items { get; }
        public ILedgerRepository Ledger { get; }
        public ISaleRepository Sales { get; }
        public IReceiptRepository Receipts { get; }
        public IPaymentRepository Payments { get; }
        public IAccountRepository Accounts { get; }
        public IItemMasterRepository Item { get; }

        public ISupplierRepository Suppliers { get; }

        public UnitOfWork(DbConnectionFactory factory)
        {
            // Create a single connection for this UnitOfWork instance
            _connection = factory.CreateConnection();
            _connection.Open();

            // Start a transaction shared by repositories created below
            _transaction = _connection.BeginTransaction();

            // Instantiate repository instances with the same connection + transaction
            Purchases = new PurchaseRepository(_connection, _transaction);
            Items = new ItemRepository(_connection, _transaction);
            Ledger = new LedgerRepository(_connection, _transaction);
            Sales = new SaleRepository(_connection, _transaction);
            Receipts = new ReceiptRepository(_connection, _transaction);
            Payments = new PaymentRepository(_connection, _transaction);
            Accounts = new AccountMasterRepository(_connection, _transaction);
            Item = new ItemMasterRepository(_connection, _transaction);
            Suppliers = new SupplierMasterRepository(_connection, _transaction);
        }

        public Task CommitAsync()
        {
            _transaction.Commit();
            return Task.CompletedTask;
        }

        public Task RollbackAsync()
        {
            _transaction.Rollback();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            try { _transaction?.Dispose(); } catch { }
            try { _connection?.Close(); _connection?.Dispose(); } catch { }
        }
    }
}
