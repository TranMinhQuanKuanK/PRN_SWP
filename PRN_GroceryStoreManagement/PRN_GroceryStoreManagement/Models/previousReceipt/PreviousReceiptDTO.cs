using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.previousReceipt
{
    public class PreviousReceiptDTO
    {
        public int receipt_ID { get; set; }
        public string import_date { get; set; }
        public string owner_name { get; set; }
        public int total { get; set; }

        public PreviousReceiptDTO(int receipt_ID, string import_date, string owner_name, int total)
        {
            this.receipt_ID = receipt_ID;
            this.import_date = import_date;
            this.owner_name = owner_name;
            this.total = total;
        }
    }

}
