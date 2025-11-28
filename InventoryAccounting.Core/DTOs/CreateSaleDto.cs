using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Core.DTOs
{
    public class CreateSaleDto
    {
        public int CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public List<SaleItemDto> Items { get; set; }
        public string? Remarks { get; set; }
    }
}
