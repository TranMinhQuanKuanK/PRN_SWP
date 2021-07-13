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
    [Route("ResetAccount")]
    [ApiController]
    public class ResetAccount_APIControllers : ControllerBase
    {
        [HttpPost]
        public IActionResult ResetAccount([FromBody] JsonElement JsonObj)
        {
            string username = JsonObj.GetProperty("username").GetString();
            AccountErrObj accountErr = new AccountErrObj();
            AccountDAO dao = new AccountDAO();

            if (!dao.resetAccount(username))
            {
                accountErr.hasError = true;
                accountErr.resetPasswordError ="Không thể đặt lại mật khẩu. Vui lòng tải lại trang!";
            }

            return new JsonResult(accountErr);
        }

    }
}