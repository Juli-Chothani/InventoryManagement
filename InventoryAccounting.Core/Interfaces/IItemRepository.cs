using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryAccounting.Core.Entities;

namespace InventoryAccounting.Core.Interfaces
{
    public interface IItemRepository
    {
        Task<ItemMaster?> GetItemById(int itemId);
        Task<int> UpdateItemStock(int itemId, decimal deltaQty);

    }
}
