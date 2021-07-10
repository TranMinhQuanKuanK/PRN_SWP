using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.statistic
{
    public class FinancialStatisticObj
    {
        public int countBill { get; set; }
        public int sumRevenue { get; set; }
        public int sumProfit { get; set; }
        public int sumCost { get; set; }
        public int countReceipt { get; set; }
    }
}
