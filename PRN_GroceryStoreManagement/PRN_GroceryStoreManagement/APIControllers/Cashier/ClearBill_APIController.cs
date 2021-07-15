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
    [Route("ClearBill")]
    [ApiController]
    public class ClearBill_APIController : ControllerBase
    {
        [HttpGet]
        public IActionResult Checkout()
        {
            HttpContext.Session.SetString("BILL", JsonConvert.SerializeObject(new BillObj()));
            return new JsonResult(null);
        }
    }
}
