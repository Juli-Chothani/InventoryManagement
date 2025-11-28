using InventoryAccounting.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Core.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<LedgerEntryDto>> GetLedgerAsync(int accountId);

    }
}
