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
    [Route("EditQuantityInReceipt")]
    [ApiController]
    public class EditQuantityInReceipt_APIController : ControllerBase
    {
        [HttpPost]
        public IActionResult EditQuantityInReceipt([FromBody] JsonElement JsonObj)
        {
            ReceiptObj receipt = null;
            String ReceiptJSONString = HttpContext.Session.GetString("RECEIPT");
            receipt = JsonConvert.DeserializeObject<ReceiptObj>(ReceiptJSONString);
            int product_id = int.Parse(JsonObj.GetProperty("product_id").GetString());
            int new_quantity = int.Parse(JsonObj.GetProperty("quantity").GetString());
            List<ReceiptItem> receipt_detail = receipt.receipt_detail;
            ProductDTO pDTO = new ProductDAO().GetProductByID(product_id);
            for (int i = 0; i < receipt_detail.Count; i++)
            {
                if (receipt_detail[i].product.product_ID == product_id)
                {
                    if (new_quantity >= 1)
                    {
                        //sửa Giá total cost 
                        int quantity_difference = new_quantity - receipt.receipt_detail[i].quantity;
                        int currentPrice = receipt.receipt_detail[i].product.selling_price;
                        receipt.total_cost = receipt.total_cost + quantity_difference * currentPrice;
                        //sửa quantity trong receipt_items
                        receipt_detail[i].quantity = new_quantity;
                    }
                }
            }
            HttpContext.Session.SetString("RECEIPT", JsonConvert.SerializeObject(receipt));
            return new JsonResult(receipt);
        }
    }
}
