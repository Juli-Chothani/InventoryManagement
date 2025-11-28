using Dapper;
using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace InventoryAccounting.Infrastructure.Repositories
{
    public class LedgerRepository : ILedgerRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;
        private const string InsertSp = "usp_InsertLedgerEntry";
        private const string GetLedgerSp = "usp_GetAccountLedger";

        public LedgerRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
        }

        public async Task InsertEntryAsync(DateTime entryDate, int accountId, string reference, decimal debit, decimal credit)
        {
            await _connection.ExecuteAsync(
                InsertSp,
                new { EntryDate = entryDate, AccountId = accountId, Reference = reference, Debit = debit, Credit = credit },
                transaction: _transaction,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<LedgerEntryDto>> GetLedgerAsync(int accountId)
        {
            return await _connection.QueryAsync<LedgerEntryDto>(
                GetLedgerSp,
                new { AccountId = accountId },
                transaction: _transaction,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
