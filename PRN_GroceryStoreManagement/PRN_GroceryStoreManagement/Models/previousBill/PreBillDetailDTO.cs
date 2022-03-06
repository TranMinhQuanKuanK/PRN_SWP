using System;

namespace PRN_GroceryStoreManagement.Models.previousBill
{
    public class PreBillDetailDTO
    {
        public int quantity { get; set; }
        public int cost { get; set; }
        public int total { get; set; }
        public String productName { get; set; }
        public PreBillDetailDTO(int quantity, int cost, int total, String productName)
        {
            this.quantity = quantity;
            this.cost = cost;
            this.total = total;
            this.productName = productName;
        }

    }
}