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
    [Route("AddToReceiptFromPending")]
    [ApiController]
    public class AddToReceiptFromPending_APIController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddToReceiptFromPending([FromBody] JsonElement JsonObj)
        {
            ReceiptObj receipt = null;
            String ReceiptJSONString = HttpContext.Session.GetString("RECEIPT");
            int productID = int.Parse(JsonObj.GetProperty("product_ID").GetString());
            ProductDTO pDTO = new ProductDAO().GetProductByID(productID);
            if (ReceiptJSONString == null)
            {
                receipt = new ReceiptObj();
                HttpContext.Session.SetString("RECEIPT", JsonConvert.SerializeObject(receipt));
            }
            else
            {
                receipt = JsonConvert.DeserializeObject<ReceiptObj>(ReceiptJSONString);
                List<ReceiptItem> receipt_detail = receipt.receipt_detail;
                //ktra san pham da ton tai tren session chua
                bool found = false;
                for (int i = 0; i < receipt_detail.Count; i++)
                {
                    if (receipt_detail[i].product.product_ID == productID)
                    {
                        found = true;
                        break;
                    }
                }
                //Neu chua ton tai thi them vao session
                if (!found)
                {
                    ReceiptItem receiptItem = new ReceiptItem(pDTO, 1);
                    receipt.receipt_detail.Add(receiptItem);
                    receipt.total_cost = receipt.total_cost + pDTO.selling_price;
                }
                HttpContext.Session.SetString("RECEIPT", JsonConvert.SerializeObject(receipt));
            }
            return new JsonResult(receipt);
        }
    }
}
           
        
