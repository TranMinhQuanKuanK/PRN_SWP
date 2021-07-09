using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PRN_GroceryStoreManagement.Models.receipt;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.importgoods
{
    [Authorize(Roles = "Admin")]
    [Route("GetReceipt")]
    [ApiController]
    public class GetReceipt_APIController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetReceipt()
        {

            ReceiptObj receipt = null;
            String ReceiptJSONString = HttpContext.Session.GetString("RECEIPT");
            if (ReceiptJSONString == null)
            {
                receipt = new ReceiptObj();
                HttpContext.Session.SetString("RECEIPT", JsonConvert.SerializeObject(receipt));
            }
            else
            {
                receipt = JsonConvert.DeserializeObject<ReceiptObj>(ReceiptJSONString);
            }

            return new JsonResult(receipt);

        }
    }
}
