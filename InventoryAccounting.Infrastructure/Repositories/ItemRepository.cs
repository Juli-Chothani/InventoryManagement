using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using InventoryAccounting.Core.Entities;
using InventoryAccounting.Core.Interfaces;
using InventoryAccounting.Infrastructure.Database;
using System.Data;

namespace InventoryAccounting.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction? _transaction;
        private readonly DbConnectionFactory? _factory;

        public ItemRepository(DbConnectionFactory factory)
        {
            _factory = factory;
        }

        public ItemRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        private IDbConnection Connection => _connection ?? _factory!.CreateConnection();

        public async Task<ItemMaster?> GetItemById(int itemId)
        {
            var conn = _connection ?? _factory!.CreateConnection();

            return await conn.QueryFirstOrDefaultAsync<ItemMaster>(
                "usp_GetItemById",
                new { ItemId = itemId },
                transaction: _transaction,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateItemStock(int itemId, decimal deltaQty)
        {
            var conn = _connection ?? _factory!.CreateConnection();

            return await conn.ExecuteAsync(
                "usp_UpdateItemStock",
                new { ItemId = itemId, DeltaQty = deltaQty },
                transaction: _transaction,
                commandType: CommandType.StoredProcedure
            );
        }
    }

}

