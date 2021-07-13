using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.account;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.staff
{
    [Authorize(Roles = "Admin")]
    [Route("ChangePasswordStoreowner")]
    [ApiController]
    public class ChangePasswordStoreowner_APIControllers : ControllerBase
    {
        [HttpPost]
        public IActionResult ChangePasswordStoreowner([FromBody] JsonElement JsonObj)
        {
            AccountErrObj accountErr = new AccountErrObj();
            AccountDAO dao = new AccountDAO();
            string username = HttpContext.Session.GetString("FULLNAME");
            string currentPassword = JsonObj.GetProperty("currentPassword").GetString();
            string newPassword = JsonObj.GetProperty("newPassword").GetString();

            if (username != null)
            {
                AccountDTO aDTO = dao.checkLogin(username, currentPassword);

                if (aDTO == null)
                {
                    accountErr.currentPasswordError = "Mật khẩu hiện tại không đúng";
                    accountErr.hasError = true;
                }
                else
                {
                    if (newPassword.Length < 6 || newPassword.Length > 20)
                    {
                        accountErr.newPasswordError = "Mật khẩu mới phải có độ dài từ 6 đến 20 kí tự";
                        accountErr.hasError = true;
                    }
                    else if (newPassword.Equals(currentPassword))
                    {
                        accountErr.newPasswordError = "Mật khẩu mới phải khác mật khẩu cũ";
                        accountErr.hasError = true;
                    }
                    else
                    {
                        dao.ChangePassword(username, newPassword);
                    }
                }

            }

            return new JsonResult(accountErr);
        }

    }
}