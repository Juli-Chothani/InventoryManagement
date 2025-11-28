using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Entities;
using InventoryAccounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Service.Services
{
    public class ItemMasterService : IItemMasterService
    {
        private readonly IUnitOfWork _uow;

        public ItemMasterService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> CreateAsync(ItemMasterDto dto)
        {
            var id = await _uow.Item.CreateItemAsync(dto);
            await _uow.CommitAsync();
            return id;
        }

        public async Task<IEnumerable<ItemMaster>> GetAllAsync()
        {
            return await _uow.Item.GetAllAsync();
        }
    }
}
