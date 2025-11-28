using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace InventoryAccounting.Core.DTOs
{
    public class PurchaseDto
    {
        public int SupplierId { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
        public List<PurchaseItemDto> Items { get; set; } = new();
        public string? Remarks { get; set; }
    }
}
