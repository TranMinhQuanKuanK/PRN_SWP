using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.previousReceipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.previousReceipts
{
    [Authorize(Roles = "Admin")]
    [Route("GetReceiptInformation")]
    [ApiController]
    public class GetReceiptInformation_APIController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetReceiptInformation([FromBody] JsonElement JsonObj)
        {
            int receipt_ID = int.Parse(JsonObj.GetProperty("receipt_ID").GetString());
            PreviousReceiptDAO DAO = new PreviousReceiptDAO();
            List<PreviousReceiptDetailDTO> receiptInfo = DAO.GetReceiptDetails(receipt_ID);
            return new JsonResult(receiptInfo);
        }
    }
}
