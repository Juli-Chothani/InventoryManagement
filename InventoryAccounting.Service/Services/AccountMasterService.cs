using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Entities;
using InventoryAccounting.Core.Interfaces;
using InventoryAccounting.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Service.Services
{
    public class AccountMasterService : IAccountMasterService
    {
        private readonly IUnitOfWork _uow;

        public AccountMasterService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> CreateAccountAsync(AccountDto dto)
        {
            var id = await _uow.Accounts.CreateAccountAsync(dto);
            await _uow.CommitAsync();
            return id;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _uow.Accounts.GetAllAsync();
        }

        public async Task<IEnumerable<LedgerEntryDto>> GetAccountLedgerAsync(int accountId)
        {
            return await _uow.Accounts.GetAccountLedgerAsync(accountId);
        }
    }
}

