using Dapper;
using InventoryAccounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InventoryAccounting.Infrastructure.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly IDbConnection? _connection;
        private readonly IDbTransaction? _transaction;

        private readonly string _spCreateHeader = "usp_CreatePurchaseHeader";
        private readonly string _spCreateItem = "usp_CreatePurchaseItem";

        public PurchaseRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task<int> CreateHeaderAsync(int supplierId, DateTime purchaseDate, decimal totalAmount, string? remarks)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SupplierId", supplierId);
            parameters.Add("@PurchaseDate", purchaseDate);
            parameters.Add("@TotalAmount", totalAmount);
            parameters.Add("@Remarks", remarks);
            parameters.Add("@PurchaseId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _connection.ExecuteAsync(
                "usp_CreatePurchaseHeader",
                parameters,
                _transaction,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@PurchaseId");
        }

        public async Task<int> CreateItemAsync(int purchaseId, int itemId, decimal quantity, decimal unitPrice)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PurchaseId", purchaseId);
            parameters.Add("@ItemId", itemId);
            parameters.Add("@Quantity", quantity);
            parameters.Add("@UnitPrice", unitPrice);
            parameters.Add("@PurchaseItemId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _connection.ExecuteAsync(
                "usp_CreatePurchaseItem",
                parameters,
                _transaction,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("@PurchaseItemId");
        }
    }
}

