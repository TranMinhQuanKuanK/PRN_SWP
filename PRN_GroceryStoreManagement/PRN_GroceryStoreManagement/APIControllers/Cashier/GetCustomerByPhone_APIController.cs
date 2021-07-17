using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PRN_GroceryStoreManagement.Models.category;
using PRN_GroceryStoreManagement.Models.customer;
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
    [Route("GetCustomerByPhone")]
    [ApiController]
    public class GetCustomerByPhone_APIController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetCustomerByPhone(string phone_no)
        {
            try
            {
                CustomerDTO cDTO = new CustomerDAO().GetCustomerByPhone(phone_no);

                //get bill from session
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

                //nếu tìm thấy thì set
                if (cDTO != null)
                {
                    bill.customer_dto = cDTO;
                    bill.phone_no = cDTO.phone_no;
                    HttpContext.Session.SetString("BILL", JsonConvert.SerializeObject(bill));
                }
                return new JsonResult(cDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(null);
        }
    }
}
