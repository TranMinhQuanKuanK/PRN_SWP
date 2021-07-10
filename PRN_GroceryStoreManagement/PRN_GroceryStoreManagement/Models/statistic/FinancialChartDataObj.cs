using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.statistic
{
    public class FinancialChartDataObj
    {
        public List<string> Event { get; set; }

        public List<Int32> Revenue { get; set; }
        public List<Int32> Profit { get; set; }
    }
}
