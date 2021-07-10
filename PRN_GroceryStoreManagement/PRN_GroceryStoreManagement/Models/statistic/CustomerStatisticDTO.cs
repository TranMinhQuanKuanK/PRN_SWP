using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.statistic
{
    public class CustomerStatisticDTO
    {
        public int Quantity { get; set; }
        public int Total { get; set; }
        public String PhoneNum { get; set; }
        public string CustomerName { get; set; }
    }
}
