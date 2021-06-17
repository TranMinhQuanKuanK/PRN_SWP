using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.sessionBill
{
    public class BillErrObj
    {
        //private ArrayList<String> error_list;
        //boolean hasError;
        public List<String> error_list { get; set; }
        public  bool hasError { get; set; }

        public BillErrObj()
        {
            this.error_list = new List<string>();
            hasError = false;
        }
        public void appendError(String error)
        {
            this.error_list.Add(error);
            this.hasError = true;
        }

    }
}
