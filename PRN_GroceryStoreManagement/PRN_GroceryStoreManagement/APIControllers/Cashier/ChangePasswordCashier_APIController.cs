using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Cashier
{
    [Authorize(Roles = "Cashier")]
    [Route("ChangePasswordCashier")]
    [ApiController]
    public class ChangePasswordCashier_APIController : ControllerBase
    {
        [HttpPost]
        public IActionResult ChangePasswordCashier([FromBody] JsonElement JsonObj)
        {
            try
            {

                String currentPassword = JsonObj.GetProperty("currentPassword").GetString();
                String newPassword = JsonObj.GetProperty("newPassword").GetString();
                String username = HttpContext.Session.GetString("USERNAME");
                AccountErrObj accError = new AccountErrObj();
                if (username != null)
                {
                    AccountDAO aDAO = new AccountDAO();
                    AccountDTO aDTO = aDAO.checkLogin(username, currentPassword);
                    if (aDTO == null)
                    {
                        //thông báo mật khẩu không đúng
                        accError.currentPasswordError = "Mật khẩu hiện tại không đúng";
                        accError.hasError = true;

                    }
                    else
                    {
                        //kiểm tra password mới 6 kí tự 
                        if (newPassword.Length < 6)
                        {
                            accError.newPasswordError = "Mật khẩu mới phải từ 6 kí tự trở lên";
                            accError.hasError = true;
                        }
                        else if (newPassword == currentPassword)
                        {
                            accError.newPasswordError = "Mật khẩu mới phải khác mật khẩu cũ";
                            accError.hasError = true;
                        }
                        else
                        {
                            aDAO.ChangePassword(username, newPassword);
                        }
                    }

                }
                return new JsonResult(accError);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(null);
        }
    }
}
