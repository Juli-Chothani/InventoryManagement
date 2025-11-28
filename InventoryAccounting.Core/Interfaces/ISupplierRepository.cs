using InventoryAccounting.Core.DTOs;
using InventoryAccounting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Core.Interfaces
{
    public interface ISupplierRepository
    {
        Task<int> CreateSupplierAsync(SupplierDto dto);
        Task<IEnumerable<Supplier>> GetAllAsync();
    }
}
