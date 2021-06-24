using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PRN_GroceryStoreManagement.Models.sessionBill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Cashier
{
    [Authorize(Roles = "Cashier")]
    [Route("Checkout")]
    [ApiController]
    public class Checkout_APIController : ControllerBase
    {

        [HttpGet]
        public IActionResult Checkout(int cash)
        {
            //Lấy billobj từ session, nếu chưa có thì tạo mới
            BillObj bill = null;
            String BillJSONString = HttpContext.Session.GetString("BILL");
            if (BillJSONString == null)
            {
                bill = new BillObj();
            }
            else
            {
                bill = JsonConvert.DeserializeObject<BillObj>(BillJSONString);
                bill.err_obj = new BillErrObj();
            }
            string phone_no = bill.phone_no;

            //???? sao để lấy time hiện tại

            String cashier_username = HttpContext.Session.GetString("USERNAME");
            
            int total_cost = bill.total_cost;
            int point_used = 0;
            if (bill.use_point ==true ) 
            {
                point_used = Math.Min( (int) Math.Ceiling((double)bill.total_cost/1000),
                        bill.customer_dto.point); //???
            }

            List<BillItemObject> Bill_Detail = bill.Bill_Detail;
            int profit = 0;
            foreach (BillItemObject detail in Bill_Detail)
            {
                //System.out.println("Món :" + detail.getProduct().getName() + " có gia ban: " + detail.getProduct().getSelling_price() + " va gia goc: " + detail.getProduct().getCost_price());
                profit += (detail.product.selling_price - detail.product.cost_price) * detail.quantity;
            }
            profit -= point_used * 1000;
        }

    }
}
