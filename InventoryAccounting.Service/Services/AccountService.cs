using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _uow;

        public AccountService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Task<IEnumerable<LedgerEntryDto>> GetLedgerAsync(int accountId)
        {
            return _uow.Ledger.GetLedgerAsync(accountId);
        }
    }
}
