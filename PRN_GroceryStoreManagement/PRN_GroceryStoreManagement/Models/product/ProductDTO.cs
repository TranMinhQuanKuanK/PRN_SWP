using PRN_GroceryStoreManagement.Models.category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.product
{
    public class ProductDTO
    {
        public int product_ID { get; set; }
        public String name { get; set; }
        public int quantity { get; set; }
        public int cost_price { get; set; }
        public int selling_price { get; set; }
        public int lower_threshold { get; set; }
        public CategoryDTO category { get; set; }
        public String unit_label { get; set; }
        public bool is_selling { get; set; }
        public String location { get; set; }

        public ProductDTO(int product_ID, string name, 
            int quantity, int cost_price, int selling_price, 
            int lower_threshold, CategoryDTO category, 
            string unit_label, bool is_selling, string location)
        {
            this.product_ID = product_ID;
            this.name = name;
            this.quantity = quantity;
            this.cost_price = cost_price;
            this.selling_price = selling_price;
            this.lower_threshold = lower_threshold;
            this.category = category;
            this.unit_label = unit_label;
            this.is_selling = is_selling;
            this.location = location;
        }
    }
}
