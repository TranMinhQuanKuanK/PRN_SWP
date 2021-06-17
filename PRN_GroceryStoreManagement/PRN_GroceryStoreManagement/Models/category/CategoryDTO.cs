using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.category
{
    public class CategoryDTO
    {
        //private int category_ID;
        //private String name;
        //private String info;
        public int category_ID { get; set; }
        public string name { get; set; }
        public string info { get; set; }

        public CategoryDTO(int category_ID, string name, string info)
        {
            this.category_ID = category_ID;
            this.name = name;
            this.info = info;
        }
    }
}
