using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.customer
{
    public class CustomerDTO
    {
        //private String phone_no;
        //private String name;
        //private int point;
        public String phone_no { get; set; }
        public String name { get; set; }
        public int point { get; set; }

        public CustomerDTO(string phone_no, string name, int point)
        {
            this.phone_no = phone_no;
            this.name = name;
            this.point = point;
        }
    }

}
