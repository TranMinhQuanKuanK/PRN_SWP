using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.customer
{
    public class CustomerErrObj
    {
        //private boolean has_Error;
        //private String phone_noError;
        public bool has_Error { get; set; }
        public String phone_noError { get; set; }
        public CustomerErrObj()
        {
            this.phone_noError = "";
            this.has_Error = false;
        }
    }
}
