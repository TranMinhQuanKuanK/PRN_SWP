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
    [Route("AddProductToBill")]
    [ApiController]
    public class AddProductToBill_APIController : ControllerBase
    {

        [HttpGet]
        public IActionResult AddProductToBill(int product_id)
        {
            //add comment 
            try
            {
                BillObj bill = null;
                String BillJSONString = HttpContext.Session.GetString("BILL");

                ProductDTO pDTO = new ProductDAO().GetProductByID(product_id);
                if (BillJSONString == null)
                {
                    bill = new BillObj();
                    HttpContext.Session.SetString("BILL", JsonConvert.SerializeObject(bill));
                }
                else
                {
                    bill = JsonConvert.DeserializeObject<BillObj>(BillJSONString);
                    // bill.err_obj = new BillErrObj();

                    //java code
                    List<BillItemObject> details = bill.Bill_Detail;

                    //Tìm trong bill trên session xem sản phẩm đó đã có chưa
                    bool found = false;
                    int found_index = -1;
                    for (int i = 0; i < details.Count; i++)
                    {
                        if (details[i].product.product_ID == product_id)
                        {
                            found = true;
                            found_index = i;
                            //details.get(i).setQuantity(details.get(i).getQuantity() + 1);
                        }
                    }
                    //Nếu tồn tại trong detail thì xét số lượng, nếu lớn hơn số lượng dưới db thì lỗi
                    if (found)
                    {
                        int currentQuantityOnBill = details[found_index].quantity;
                        if ((currentQuantityOnBill + 1) <= pDTO.quantity)
                        {
                            details[found_index].quantity = currentQuantityOnBill + 1;
                            bill.total_cost = bill.total_cost + pDTO.selling_price;
                            //set lại error lỗi là không có lỗi;
                            bill.err_obj = new BillErrObj(); //xem thử có nên xóa hay ko
                        }
                        else
                        {
                            //Set lỗi
                            BillErrObj bill_error = new BillErrObj();
                            bill_error.appendError("\"" + pDTO.name + "\" chỉ còn " + pDTO.quantity + " sản phẩm trong kho");
                            bill.err_obj = bill_error;
                        };
                    }
                    else
                    {
                        if (pDTO.quantity > 0)
                        {
                            BillItemObject billItem = new BillItemObject(pDTO, 1);
                            bill.Bill_Detail.Add(billItem);
                            bill.total_cost = bill.total_cost + pDTO.selling_price;
                            //làm trống lỗi
                            bill.err_obj = new BillErrObj(); //xem thử có nên xóa hay ko
                        }
                        else
                        {
                            //Set lỗi
                            BillErrObj bill_error = new BillErrObj();
                            bill_error.appendError("\"" + pDTO.name + "\" chỉ còn " + pDTO.quantity + " sản phẩm trong kho");
                            bill.err_obj = bill_error; //xem thử có nên xóa hay ko
                        };
                    }

                    HttpContext.Session.SetString("BILL", JsonConvert.SerializeObject(bill));

                }
                return new JsonResult(bill);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
