using InventoryAccounting.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Core.Interfaces
{
    public interface ILedgerRepository
    {
        Task InsertEntryAsync(DateTime entryDate, int accountId, string reference, decimal debit, decimal credit);
        Task<IEnumerable<LedgerEntryDto>> GetLedgerAsync(int accountId);
    }
}
