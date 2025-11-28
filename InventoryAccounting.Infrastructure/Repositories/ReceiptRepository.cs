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
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public ReceiptRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task<int> CreateReceiptAsync(int customerId, DateTime date, decimal amount, string? remarks)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            parameters.Add("@ReceiptDate", date);
            parameters.Add("@Amount", amount);
            parameters.Add("@Remarks", remarks);
            parameters.Add("@ReceiptId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _connection.ExecuteAsync(
                "usp_CreateReceipt",
                parameters,
                _transaction,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("@ReceiptId");
        }
    }
}
