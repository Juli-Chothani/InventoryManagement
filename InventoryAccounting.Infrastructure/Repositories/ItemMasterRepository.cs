using Dapper;
using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Entities;
using InventoryAccounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace InventoryAccounting.Infrastructure.Repositories
{
    public class ItemMasterRepository : IItemMasterRepository
    {
        private readonly IDbConnection _conn;
        private readonly IDbTransaction _transaction;
        public ItemMasterRepository(IDbConnection conn, IDbTransaction transaction)
        {
            _conn = conn;
            _transaction = transaction;
        }

        public async Task<int> CreateItemAsync(ItemMasterDto dto)
        {
            var query = @"
            INSERT INTO ItemMaster (ItemName,Stock, UnitPrice)
            VALUES (@ItemName, @Stock, @UnitPrice);

            SELECT CAST(SCOPE_IDENTITY() as int);
        ";

            return await _conn.ExecuteScalarAsync<int>(query, dto, transaction: _transaction);
        }

        public async Task<IEnumerable<ItemMaster>> GetAllAsync()
        {
            return await _conn.QueryAsync<ItemMaster>("SELECT * FROM ItemMaster ORDER BY ItemId DESC", transaction: _transaction);
        }

        public async Task<ItemMaster?> GetByIdAsync(int id)
        {
            return await _conn.QueryFirstOrDefaultAsync<ItemMaster>(
                "SELECT * FROM ItemMaster WHERE ItemId = @Id", new { Id = id }, commandType: CommandType.StoredProcedure, transaction: _transaction);
        }
    }

}
