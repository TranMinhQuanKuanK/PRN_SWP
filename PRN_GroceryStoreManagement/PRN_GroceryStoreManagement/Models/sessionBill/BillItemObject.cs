using PRN_GroceryStoreManagement.Models.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.sessionBill
{
    public class BillItemObject
    {
        //private ProductDTO product;
        //private int quantity;
        public ProductDTO product { get; set; }
        public int quantity { get; set; }

        public BillItemObject(ProductDTO product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }
    }
}
