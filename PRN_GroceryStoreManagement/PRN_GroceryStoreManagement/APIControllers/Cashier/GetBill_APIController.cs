using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    [Route("GetBill")]
    [ApiController]
    public class GetBill_APIController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetBill()
        {
            BillObj bill = null;
            String BillJSONString = HttpContext.Session.GetString("BILL");
            try
            {
                if (BillJSONString == null)
                {
                    bill = new BillObj();
                    HttpContext.Session.SetString("BILL", JsonConvert.SerializeObject(bill));
                }
                else
                {
                    bill = JsonConvert.DeserializeObject<BillObj>(BillJSONString);
                    bill.err_obj = new BillErrObj();
                }

                return new JsonResult(bill);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(bill);
        }
    }
}
