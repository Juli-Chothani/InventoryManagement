using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Core.DTOs
{
    public class LedgerEntryDto
    {
        public int LedgerId { get; set; }
        public DateTime EntryDate { get; set; }
        public string Reference { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal RunningBalance { get; set; }
    }

}
