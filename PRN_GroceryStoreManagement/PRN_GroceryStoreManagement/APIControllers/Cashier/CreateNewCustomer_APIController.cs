using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.customer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Cashier
{
    [Authorize(Roles = "Cashier")]
    [Route("CreateNewCustomer")]
    [ApiController]
    public class CreateNewCustomer_APIController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateNewCustomer([FromBody] JsonElement JsonObj)
        {
            CustomerErrObj err_obj = new CustomerErrObj();

            try
            {
                string phone_no = JsonObj.GetProperty("phone_no").GetString();
                string name = JsonObj.GetProperty("name").GetString();

                //Debug.WriteLine($"{phone_no} + password: {name}");
                if (Regex.IsMatch(phone_no, "[0-9]+") == false)
                {
                    err_obj.has_Error = true;
                    err_obj.phone_noError = "Số điện thoại không được chứa kí tự đặc biệt";
                }
                else
                {
                    CustomerDAO cDAO = new CustomerDAO();
                    CustomerDTO cDTO = cDAO.GetCustomerByPhone(phone_no);

                    if (cDTO == null)
                    {
                        cDAO.CreateNewCustomer(phone_no, name);
                    }
                    else
                    {
                        err_obj.has_Error = true;
                        err_obj.phone_noError = "Số điện thoại đã tồn tại!";
                    }
                }
                return new JsonResult(err_obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(err_obj);
        }
    }
}
