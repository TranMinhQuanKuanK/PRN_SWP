using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PRN_GroceryStoreManagement.Models.product;
using PRN_GroceryStoreManagement.Models.receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.importgoods
{
    [Authorize(Roles = "Admin")]
    [Route("RemoveFromReceipt")]
    [ApiController]
    public class RemoveFromReceipt_APIController : ControllerBase
    {
        [HttpPost]
        public IActionResult RemoveFromReceipt([FromBody] JsonElement JsonObj)
        {
            try
            {
                ReceiptObj receipt = null;
                String ReceiptJSONString = HttpContext.Session.GetString("RECEIPT");
                int productID = int.Parse(JsonObj.GetProperty("product_ID").GetString());
                receipt = JsonConvert.DeserializeObject<ReceiptObj>(ReceiptJSONString);
                List<ReceiptItem> details = receipt.receipt_detail;
                int result = -1;
                for (int i = 0; i < details.Count; i++)
                {
                    if (details[i].product.product_ID == productID)
                    {
                        result = i;
                    }
                }
                if (result >= 0)
                {
                    ReceiptItem selected_for_remove_Product = details[result];
                    int price_lost = selected_for_remove_Product.product.selling_price
                            * selected_for_remove_Product.quantity;
                    details.RemoveAt(result);
                    receipt.total_cost = receipt.total_cost - price_lost;
                    receipt.receipt_detail = details;
                    HttpContext.Session.SetString("RECEIPT", JsonConvert.SerializeObject(receipt));
                }
                return new JsonResult(receipt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(null);
        }
    }
}
