using PRN_GroceryStoreManagement.Models.customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.sessionBill
{
    public class BillObj
    {
        //private ArrayList<BillItemObject> Bill_Detail;
        //private String phone_no;
        //private Timestamp buy_date;
        //private String cashier_username;
        //private int total_cost;
        //// private int point_used;
        //private int cash;
        //boolean use_point; //thêm
        //CustomerDTO customer_dto; //thêm
        //BillErrObj err_obj;//thêm 10/6
        public List<BillItemObject> Bill_Detail { get; set; }
        public String phone_no { get; set; }
        public DateTime? buy_date { get; set; }
        public String cashier_username { get; set; }
        public int total_cost { get; set; }
        public int cash { get; set; }
        public bool use_point { get; set; }
        public CustomerDTO customer_dto { get; set; }
        public BillErrObj err_obj { get; set; }

        public BillObj()
        {
            this.Bill_Detail = new List<BillItemObject>(); ;
            this.phone_no = null;
            this.buy_date = null;
            this.cashier_username = null;
            this.total_cost = 0;
            this.cash = 0;
            this.use_point = false;
            this.customer_dto = null;
            this.err_obj = new BillErrObj();
        }
       

    }
}
