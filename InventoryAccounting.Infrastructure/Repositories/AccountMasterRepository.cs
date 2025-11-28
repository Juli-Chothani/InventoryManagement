using Dapper;
using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Entities;
using InventoryAccounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace InventoryAccounting.Infrastructure.Repositories
{
    public class AccountMasterRepository : IAccountRepository
    {
        private readonly IDbConnection _conn;
        private readonly IDbTransaction _transaction;

        public AccountMasterRepository(IDbConnection conn, IDbTransaction transaction)
        {
            _conn = conn;
            _transaction = transaction;
        }

        public async Task<int> CreateAccountAsync(AccountDto dto)
        {
            var query = @"
            INSERT INTO AccountMaster (AccountCode, Name, Type)
            VALUES (@AccountCode, @Name, @Type);

            SELECT CAST(SCOPE_IDENTITY() as int);
        ";

            return await _conn.ExecuteScalarAsync<int>(query, dto, transaction: _transaction);
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _conn.QueryAsync<Account>("SELECT * FROM AccountMaster ORDER BY AccountId DESC",transaction: _transaction);
        }

        public async Task<IEnumerable<LedgerEntryDto>> GetAccountLedgerAsync(int accountId)
        {
            return await _conn.QueryAsync<LedgerEntryDto>("usp_GetAccountLedger",new { AccountId = accountId },commandType: CommandType.StoredProcedure,transaction: _transaction);
        }

    }

}
