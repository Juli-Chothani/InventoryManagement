using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Core.DTOs
{
    public class ReceiptRequestDto
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
    }
}
