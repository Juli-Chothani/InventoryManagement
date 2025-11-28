using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Core.Interfaces
{

    public interface IItemMasterService
    {
        Task<int> CreateAsync(ItemMasterDto dto);
        Task<IEnumerable<ItemMaster>> GetAllAsync();
    }
}
