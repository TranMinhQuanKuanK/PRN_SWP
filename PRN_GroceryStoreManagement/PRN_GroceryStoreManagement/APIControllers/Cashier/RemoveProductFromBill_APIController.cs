using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PRN_GroceryStoreManagement.Models.category;
using PRN_GroceryStoreManagement.Models.product;
using PRN_GroceryStoreManagement.Models.sessionBill;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Common
{
    [Authorize(Roles = "Admin,Cashier")]
    [Route("RemoveProductFromBill")]
    [ApiController]
    public class RemoveProductFromBill_APIController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult RemoveProductFromBill(int product_id)
        {
            //get bill from session
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

            List<BillItemObject> details = bill.Bill_Detail;

            //lấy vị trí
            int result = -1;
            for (int i = 0; i < details.Count; i++)
            {
                if (details[i].product.product_ID == product_id)
                {
                    result = i;
                }
            }
            //xóa
            if (result >= 0)
            {
                BillItemObject selected_for_remove_Product = details[result];
                int price_lost = selected_for_remove_Product.product.selling_price
                        * selected_for_remove_Product.quantity;
                details.RemoveAt(result);
                bill.total_cost =  bill.total_cost - price_lost;
                bill.Bill_Detail = details;
                //set lại lỗi
                bill.err_obj = new BillErrObj();

                HttpContext.Session.SetString("BILL", JsonConvert.SerializeObject(bill));
            }

            return new JsonResult(bill);
        }
    }
}
