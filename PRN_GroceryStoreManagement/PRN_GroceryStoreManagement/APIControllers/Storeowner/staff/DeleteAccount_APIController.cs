using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.account;
using System;
using System.Text.Json;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.staff
{
    [Authorize(Roles = "Admin")]
    [Route("DeleteAccount")]
    [ApiController]
    public class DeleteAccount_APIControllers : ControllerBase
    {
        [HttpPost]
        public IActionResult DeleteAccount([FromBody] JsonElement JsonObj)
        {
            try
            {
                string username = JsonObj.GetProperty("username").GetString();
                AccountErrObj accountErr = new AccountErrObj();
                AccountDAO dao = new AccountDAO();

                if (!dao.deleteAccount(username))
                {
                    accountErr.hasError = true;
                    accountErr.deleteAccountError = "Không thể xóa tài khoản. Vui lòng tải lại trang!";
                }

                return new JsonResult(accountErr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(null);
        }

    }
}