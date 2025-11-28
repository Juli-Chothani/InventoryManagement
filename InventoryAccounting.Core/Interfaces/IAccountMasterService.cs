using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Core.Interfaces
{
    public interface IAccountMasterService
    {
        Task<int> CreateAccountAsync(AccountDto dto);
        Task<IEnumerable<Account>> GetAllAsync();

        Task<IEnumerable<LedgerEntryDto>> GetAccountLedgerAsync(int accountId);

    }
}
