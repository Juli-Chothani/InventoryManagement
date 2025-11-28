using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAccounting.Core.DTOs
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        public string AccountCode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
