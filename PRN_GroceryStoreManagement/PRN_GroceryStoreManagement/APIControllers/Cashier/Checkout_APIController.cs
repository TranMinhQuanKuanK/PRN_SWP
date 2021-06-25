using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PRN_GroceryStoreManagement.Models.customer;
using PRN_GroceryStoreManagement.Models.pendingItem;
using PRN_GroceryStoreManagement.Models.product;
using PRN_GroceryStoreManagement.Models.sessionBill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Cashier
{
    [Authorize(Roles = "Cashier")]
    [Route("Checkout")]
    [ApiController]
    public class Checkout_APIController : ControllerBase
    {

        [HttpGet]
        public IActionResult Checkout(int? cash)
        {
            //Lấy billobj từ session, nếu chưa có thì tạo mới
            BillObj bill = null;
            String BillJSONString = HttpContext.Session.GetString("BILL");
            if (BillJSONString == null)
            {
                bill = new BillObj();
            }
            else
            {
                bill = JsonConvert.DeserializeObject<BillObj>(BillJSONString);
                bill.err_obj = new BillErrObj();
            }
            string phone_no = bill.phone_no;

            //???? sao để lấy time hiện tại

            String cashier_username = HttpContext.Session.GetString("USERNAME");

            int total_cost = bill.total_cost;
            int point_used = 0;
            if (bill.use_point == true)
            {
                point_used = Math.Min((int)Math.Ceiling((double)bill.total_cost / 1000),
                        bill.customer_dto.point); //???
            }

            List<BillItemObject> Bill_Detail = bill.Bill_Detail;
            int profit = 0;
            foreach (BillItemObject detail in Bill_Detail)
            {
                //System.out.println("Món :" + detail.getProduct().getName() + " có gia ban: " + detail.getProduct().getSelling_price() + " va gia goc: " + detail.getProduct().getCost_price());
                profit += (detail.product.selling_price - detail.product.cost_price) * detail.quantity;
            }
            profit -= point_used * 1000;

            BillDAO bDAO = new BillDAO();
            //ghi bill xuống database
            int Bill_ID = bDAO.CreateBill(phone_no, DateTime.Now,
                    cashier_username, total_cost, point_used, cash, profit);
            PendingItemDAO ppDAO = new PendingItemDAO();
            List<PendingItemDTO> pendingList = ppDAO.GetPendingList();
            ProductDAO pDAO = new ProductDAO();

            CustomerDAO cDAO = new CustomerDAO();
            cDAO.AddPointCustomer(phone_no,
                    (int)Math.Floor((double)total_cost / 20000) - point_used);

            foreach (BillItemObject detail in Bill_Detail)
            {

                int? product_id = detail.product.product_ID;
                int? quantity = detail.quantity;
                int? cost = detail.product.selling_price;
                int? total = cost * quantity;
                //ghi bill detail xuống db
                bDAO.CreateBillDetail(Bill_ID, product_id, quantity, cost, total);

                //tìm xem đã có trong danh sách pending chưa
                bool is_lower_than_threshold = pDAO.AddQuantityToProduct((int)product_id, (int)((-1) * quantity));
                bool already_in_pending = false;
                if (is_lower_than_threshold)
                {
                    for (int i = 0; i < pendingList.Count; i++)
                    {
                        if (pendingList[i].product_ID == product_id)
                        {
                            already_in_pending = true;
                        }
                    }
                }
                //ghi vào pending
                if (already_in_pending == false)
                {
                    PendingItemDAO pendingDAO = new PendingItemDAO();
                    pendingDAO.CreatePendingList((int)product_id, DateTime.Now, "Hết hàng - được thêm tự động");
                }
            }
            bill = new BillObj();
            HttpContext.Session.SetString("BILL", JsonConvert.SerializeObject(bill));

            return new JsonResult(null);
        }

    }
}
