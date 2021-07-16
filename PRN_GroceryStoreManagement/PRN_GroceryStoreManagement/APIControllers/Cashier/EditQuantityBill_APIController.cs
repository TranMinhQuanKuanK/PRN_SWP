using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    [Route("EditQuantityBill")]
    [ApiController]
    public class EditQuantityBill_APIController : ControllerBase
    {

        [HttpGet]
        public IActionResult EditQuantityBill(int product_id, int quantity)
        {
            BillObj bill = null;
            String BillJSONString = HttpContext.Session.GetString("BILL");
            try
            {
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
                ProductDTO pDTO = new ProductDAO().GetProductByID(product_id);

                for (int i = 0; i < details.Count; i++)
                {
                    if (details[i].product.product_ID == product_id)
                    {
                        if (quantity >= 1)
                        {
                            if (quantity <= pDTO.quantity)
                            {
                                //sửa Giá total cost 
                                int quantity_difference = quantity - bill.Bill_Detail[i].quantity;
                                int currentPrice = bill.Bill_Detail[i].product.selling_price;
                                bill.total_cost = bill.total_cost + quantity_difference * currentPrice;
                                //sửa quantity trong details
                                details[i].quantity = quantity;
                                //set lại lỗi
                                bill.err_obj = new BillErrObj();
                            }
                            else
                            {
                                //Set lỗi
                                BillErrObj bill_error = new BillErrObj();
                                bill_error.appendError("\"" + pDTO.name + "\" chỉ còn " + pDTO.quantity + " sản phẩm trong kho");
                                bill_error.hasError = true;
                                bill.err_obj = bill_error;
                                //set lại số lượng = quantity
                                int new_quantity = pDTO.quantity;
                                //sửa giá total cost
                                int quantity_difference = new_quantity - bill.Bill_Detail[i].quantity;
                                int currentPrice = bill.Bill_Detail[i].product.selling_price;
                                bill.total_cost = bill.total_cost + quantity_difference * currentPrice;
                                //sửa quantity trong details
                                details[i].quantity = new_quantity;
                            }
                        }
                    }
                }
                HttpContext.Session.SetString("BILL", JsonConvert.SerializeObject(bill));

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
