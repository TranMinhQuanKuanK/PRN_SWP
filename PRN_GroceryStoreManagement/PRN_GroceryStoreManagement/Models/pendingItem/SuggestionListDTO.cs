using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.pendingItem
{
    public class SuggestionListDTO
    {
        public int product_ID { get; set; }
        public string product_name { get; set; }
        public int product_quantity { get; set; }

        public SuggestionListDTO(int product_ID, string product_name, int product_quantity)
        {
            this.product_ID = product_ID;
            this.product_name = product_name;
            this.product_quantity = product_quantity;
        }
    }
}
