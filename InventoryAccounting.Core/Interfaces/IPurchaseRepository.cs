using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryAccounting.Core.DTOs;

namespace InventoryAccounting.Core.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<int> CreateHeaderAsync(int supplierId, DateTime purchaseDate, decimal totalAmount, string? remarks);
        Task<int> CreateItemAsync(int purchaseId, int itemId, decimal quantity, decimal unitPrice);
    }
}
