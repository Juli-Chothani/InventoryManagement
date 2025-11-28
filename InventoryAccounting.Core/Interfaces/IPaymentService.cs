using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Core.Interfaces
{
    public interface IPaymentService
    {
        Task<int> CreatePaymentAsync(int supplierId, decimal amount, string? remarks);
    }

}
