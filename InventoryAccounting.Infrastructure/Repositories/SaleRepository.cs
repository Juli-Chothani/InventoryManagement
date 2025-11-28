using Dapper;
using InventoryAccounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Infrastructure.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public SaleRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task<int> CreateSaleHeaderAsync(int customerId, DateTime saleDate, decimal totalAmount, string? remarks)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            parameters.Add("@SaleDate", saleDate);
            parameters.Add("@TotalAmount", totalAmount);
            parameters.Add("@Remarks", remarks);
            parameters.Add("@SaleId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _connection.ExecuteAsync("usp_CreateSaleHeader", parameters, _transaction, commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@SaleId");
        }

        public async Task<int> CreateSaleItemAsync(int saleId, int itemId, decimal quantity, decimal unitPrice)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SaleId", saleId);
            parameters.Add("@ItemId", itemId);
            parameters.Add("@Quantity", quantity);
            parameters.Add("@UnitPrice", unitPrice);
            parameters.Add("@SaleItemId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _connection.ExecuteAsync("usp_CreateSaleItem", parameters, _transaction, commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@SaleItemId");
        }
    }

}
