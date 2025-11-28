using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Core.Interfaces
{
    public interface ISaleRepository
    {
        Task<int> CreateSaleHeaderAsync(int customerId, DateTime saleDate, decimal totalAmount, string? remarks);
        Task<int> CreateSaleItemAsync(int saleId, int itemId, decimal quantity, decimal unitPrice);
    }
}
