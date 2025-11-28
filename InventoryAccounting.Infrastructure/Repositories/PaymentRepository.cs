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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction? _transaction;

        public PaymentRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task<int> CreatePaymentAsync(int supplierId, DateTime date, decimal amount, string? remarks)
        {
            var p = new DynamicParameters();
            p.Add("@SupplierId", supplierId);
            p.Add("@PaymentDate", date);
            p.Add("@Amount", amount);
            p.Add("@Remarks", remarks);
            p.Add("@PaymentId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _connection.ExecuteAsync("usp_CreatePayment", p,
                transaction: _transaction,
                commandType: CommandType.StoredProcedure);

            return p.Get<int>("@PaymentId");
        }
    }
}
