using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Core.Interfaces
{
    public interface IReceiptService
    {
        Task<int> CreateReceiptAsync(int customerId, decimal amount, string? remarks);
    }

}
