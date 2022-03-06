using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.receipt
{
    public class ReceiptObj
    {
        public List<ReceiptItem> receipt_detail { get; set; }
        public DateTime? import_date { get; set; }
        public int total_cost { get; set; }

        public ReceiptObj()
        {
            this.receipt_detail = new List<ReceiptItem>();
            this.import_date = null;
            this.total_cost = 0;
        }
    }
}
