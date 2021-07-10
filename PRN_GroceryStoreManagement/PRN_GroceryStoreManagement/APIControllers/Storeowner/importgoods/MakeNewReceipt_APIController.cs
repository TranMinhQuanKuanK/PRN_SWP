using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PRN_GroceryStoreManagement.Models.pendingItem;
using PRN_GroceryStoreManagement.Models.product;
using PRN_GroceryStoreManagement.Models.receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.importgoods
{
    [Authorize(Roles = "Admin")]
    [Route("MakeNewReceipt")]
    [ApiController]
    public class MakeNewReceipt_APIController : ControllerBase
    {
        [HttpGet]
        public IActionResult MakeNewReceipt()
        {
           

            ReceiptObj receipt = null;
            String ReceiptJSONString = HttpContext.Session.GetString("RECEIPT");
            receipt = JsonConvert.DeserializeObject<ReceiptObj>(ReceiptJSONString);
            DateTime import_date = DateTime.Now;
            String username = HttpContext.Session.GetString("USERNAME");
            int receiptTotal = receipt.total_cost;
            ReceiptDAO rDAO = new ReceiptDAO();
            int receipt_ID = rDAO.CreateReceipt(import_date, username, receiptTotal);

            PendingItemDAO pdDAO = new PendingItemDAO();
            List<PendingItemDTO> pendingList = pdDAO.GetPendingList();
            ProductDAO pDAO = new ProductDAO();
            List<ReceiptItem> receiptItems = receipt.receipt_detail;
 
            foreach (ReceiptItem detail in receiptItems)
            {

                int product_id = detail.product.product_ID;
                int quantity = detail.quantity;
                int price = detail.product.selling_price;
                int costItem = price * quantity;
                //Them vao ReceiptDetailDB
                ReceiptDetailDAO rdDAO = new ReceiptDetailDAO();
                rdDAO.CreateReceiptDetail(product_id, quantity, receipt_ID, price, costItem);

                //Cap nhat Inventory
                bool is_lower_than_threshold = pDAO.AddQuantityToProduct(product_id, quantity);
                bool isExisted = pdDAO.IsExistedInPendingList(product_id);

                if (is_lower_than_threshold)
                { //Neu so luong thap hon nguong
                    if (!isExisted)
                    { //Chua ton tai trong Pending -> San pham moi tao, nhung import khong du
                        String notiMessage = "Tự động thêm lúc nhập hàng do không đủ số lượng";
                        pdDAO.CreatePendingList(product_id, import_date, notiMessage);
                    }
                }
                else
                { // Neu so luong cao hon nguong
                    if (isExisted)
                    { // Ton tai trong pending -> Cap nhat trang thai is_resolved
                        pdDAO.UpdatePendingList(product_id);
                    }
                }
            }
            receipt = new ReceiptObj();
            HttpContext.Session.SetString("RECEIPT", JsonConvert.SerializeObject(receipt));

            return new JsonResult(value: null);
        }
    }
}
