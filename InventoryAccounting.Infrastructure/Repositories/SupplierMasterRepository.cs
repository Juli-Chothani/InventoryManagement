using Dapper;
using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Entities;
using InventoryAccounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace InventoryAccounting.Infrastructure.Repositories
{
    public class SupplierMasterRepository : ISupplierRepository
    {
        private readonly IDbConnection _conn;
        private readonly IDbTransaction _transaction;

        public SupplierMasterRepository(IDbConnection conn, IDbTransaction transaction)
        {
            _conn = conn;
            _transaction = transaction;
        }

        public async Task<int> CreateSupplierAsync(SupplierDto dto)
        {
            var query = @"
            INSERT INTO SupplierMaster (SupplierName, AccountId)
            VALUES (@SupplierName, @AccountId);

            SELECT CAST(SCOPE_IDENTITY() as int);
        ";

            return await _conn.ExecuteScalarAsync<int>(query, dto, transaction: _transaction);
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _conn.QueryAsync<Supplier>("SELECT * FROM SupplierMaster ORDER BY SupplierId DESC", transaction: _transaction);
        }
    }

}
