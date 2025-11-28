using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Core.Interfaces
{
    public interface IReceiptRepository
    {
        Task<int> CreateReceiptAsync(int customerId, DateTime date, decimal amount, string? remarks);
    }
}
