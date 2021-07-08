using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.previousReceipt
{
    public class PreviousReceiptDetailDTO
    {
        public int quantity { get; set; }
        public int cost { get; set; }
        public int total { get; set; }
        public string productName { get; set; }

        public PreviousReceiptDetailDTO(int quantity, int cost, int total, string productName)
        {
            this.quantity = quantity;
            this.cost = cost;
            this.total = total;
            this.productName = productName;
        }
    }
}
