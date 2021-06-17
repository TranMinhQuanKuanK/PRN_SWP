using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PRN_GroceryStoreManagement.Models.category;
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

            //System.out.println("I went to product_to_bill servlet");
            //HttpSession session = request.getSession();
            //Integer product_id = Integer.parseInt(request.getParameter("product_id"));
            //System.out.println("product id toi nhan la: " + product_id);
            //BillObj bill = (BillObj)session.getAttribute("BILL");
            //ProductDAO pDAO = new ProductDAO();
            //ProductDTO pDTO = pDAO.GetProductByID(product_id);

            //if (bill == null)
            //{
            //    session.setAttribute("BILL", new BillObj());
            //}
            //else
            //{
            //    ArrayList<BillItemObject> details = bill.getBill_Detail();

            //    //                for (BillItemObject b : details) {
            //    //                    if (b.getProduct().getProduct_ID() == product_id) {
            //    //                        found = true;
            //    //                        b.setQuantity(b.getQuantity() + 1);
            //    //                    }
            //    //                }
            //    //Tìm trong bill trên session xem sản phẩm đó đã có chưa
            //    boolean found = false;
            //    int found_index = -1;
            //    for (int i = 0; i < details.size(); i++)
            //    {
            //        if (details.get(i).getProduct().getProduct_ID() == product_id)
            //        {
            //            found = true;
            //            found_index = i;
            //            //details.get(i).setQuantity(details.get(i).getQuantity() + 1);
            //        }
            //    }
            //    //Nếu tồn tại trong detail thì xét số lượng, nếu lớn hơn số lượng dưới db thì lỗi
            //    if (found)
            //    {
            //        int currentQuantityOnBill = details.get(found_index).getQuantity();
            //        if ((currentQuantityOnBill + 1) <= pDTO.getQuantity())
            //        {
            //            details.get(found_index).setQuantity(currentQuantityOnBill + 1);
            //            bill.setTotal_cost(bill.getTotal_cost() + pDTO.getSelling_price());
            //            //set lại error lỗi là không có lỗi;
            //            bill.setErr_obj(new BillErrObj());
            //        }
            //        else
            //        {
            //            //Set lỗi
            //            BillErrObj bill_error = new BillErrObj();
            //            bill_error.appendError("\"" + pDTO.getName() + "\" chỉ còn " + pDTO.getQuantity() + " sản phẩm trong kho");
            //            bill.setErr_obj(bill_error);
            //        };
            //    }
            //    else
            //    {
            //        if (pDTO.getQuantity() > 0)
            //        {
            //            BillItemObject billItem = new BillItemObject(pDTO, 1);
            //            bill.getBill_Detail().add(billItem);
            //            bill.setTotal_cost(bill.getTotal_cost() + pDTO.getSelling_price());
            //            //làm trống lỗi
            //            bill.setErr_obj(new BillErrObj());
            //        }
            //        else
            //        {
            //            //Set lỗi
            //            BillErrObj bill_error = new BillErrObj();
            //            bill_error.appendError("\"" + pDTO.getName() + "\" chỉ còn " + pDTO.getQuantity() + " sản phẩm trong kho");
            //            bill.setErr_obj(bill_error);
            //        };
            //    }

            //    session.setAttribute("BILL", bill);
            BillObj bill = null;
            String BillJSONString = HttpContext.Session.GetString("BILL");
           
           // bill.err_obj = new BillErrObj();

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
                        bill_error.appendError("\"" + pDTO.name  + "\" chỉ còn " + pDTO.quantity + " sản phẩm trong kho");
                        bill.err_obj = bill_error; //xem thử có nên xóa hay ko
                    };
                }

                HttpContext.Session.SetString("BILL", JsonConvert.SerializeObject(bill));
            }



            return new JsonResult(bill);
        }
    }
}
