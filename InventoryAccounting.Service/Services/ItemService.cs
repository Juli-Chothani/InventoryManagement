using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryAccounting.Core.Interfaces;

namespace InventoryAccounting.Service.Services
{
    public class ItemService
    {
        private readonly IItemRepository _repo;

        public ItemService(IItemRepository repo)
        {
            _repo = repo;
        }

        public async Task IncreaseStock(int itemId, decimal qty)
        {
            await _repo.UpdateItemStock(itemId, qty);
        }

        public async Task<bool> DecreaseStock(int itemId, decimal qty)
        {
            var item = await _repo.GetItemById(itemId);

            if (item == null)
                throw new Exception("Item not found");

            if (item.Stock < qty)
                throw new Exception("Not enough stock");

            await _repo.UpdateItemStock(itemId, -qty);
            return true;
        }
    }
}
