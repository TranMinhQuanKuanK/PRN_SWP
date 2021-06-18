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
    [Authorize(Roles = "Cashier")]
    [Route("ToggleDiscount")]
    [ApiController]
    public class ToggleDiscount_APIController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult ToggleDiscount(bool use_point)
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

            bill.use_point = use_point;
            bill.err_obj = new BillErrObj();

            HttpContext.Session.SetString("BILL", JsonConvert.SerializeObject(bill));

            return new JsonResult(bill);
        }
    }
}
