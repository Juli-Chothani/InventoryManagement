using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Core.Interfaces
{
    public interface IPaymentRepository
    {
        Task<int> CreatePaymentAsync(int supplierId, DateTime date, decimal amount, string? remarks);
    }

}
