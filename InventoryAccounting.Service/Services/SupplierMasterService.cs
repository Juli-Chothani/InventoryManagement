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
    public class SupplierMasterService : ISupplierMasterServices
    {
        private readonly IUnitOfWork _uow;

        public SupplierMasterService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> CreateSupplierAsync(SupplierDto dto)
        {
            var id = await _uow.Suppliers.CreateSupplierAsync(dto);
            await _uow.CommitAsync();
            return id;
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _uow.Suppliers.GetAllAsync();
        }
    }

}
