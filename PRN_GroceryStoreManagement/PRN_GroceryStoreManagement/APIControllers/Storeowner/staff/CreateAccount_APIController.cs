using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.account;
using System.Text.Json;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.staff
{
    [Authorize(Roles = "Admin")]
    [Route("CreateAccount")]
    [ApiController]
    public class CreateAccount_APIControllers : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateAccount([FromBody] JsonElement JsonObj)
        {
            string name = JsonObj.GetProperty("new_name").GetString();
            string username = JsonObj.GetProperty("new_username").GetString();
            string password = JsonObj.GetProperty("new_password").GetString();
            string confirm = JsonObj.GetProperty("new_confirm").GetString();
            string temp_isOwner = JsonObj.GetProperty("new_is_owner").GetString();
            bool isOwner = false;
            if (temp_isOwner == "false")
            {
                isOwner = false;
            } 
            else
            {
                isOwner = true;
            }
            AccountErrObj err_obj = new AccountErrObj();
            AccountDAO dao = new AccountDAO();

            if (confirm == null)
            {
                confirm = "";
            }

            if (username == null)
            {
                err_obj.hasError = true;
                err_obj.usernameLengthError = "Vui lòng nhập tên đăng nhập";
            }
            else if (username.Trim().Length < 6 || username.Trim().Length > 30)
            {
                err_obj.hasError = true;
                err_obj.usernameLengthError = "Tên đăng nhập phải có độ dài từ 6 đến 30 kí tự";
            }
            else if (username.Contains(" "))
            {
                err_obj.usernameLengthError = "Tên đăng nhập không được chứa khoảng trắng";
            }
          
            if (password == null)
            {
                err_obj.hasError = true;
                err_obj.passwordLengthError = "Vui lòng nhập mật khẩu";
            }
            else if (password.Trim().Length < 6 || password.Trim().Length > 20)
            {
                err_obj.hasError = true;
                err_obj.passwordLengthError = "Mật khẩu phải có độ dài từ 6 đến 20 kí tự";
            }
            else if (!confirm.Trim().Equals(password.Trim()))
            {
                err_obj.hasError = true;
                err_obj.confirmNotMatch = "Mật khẩu xác nhận không trùng khớp";
            }
          
            if (name == null)
            {
                err_obj.hasError = true;
                err_obj.nameLengthError = "Vui lòng nhập họ và tên";
            }
            else if (name.Trim().Length < 2 || name.Trim().Length > 50)
            {
                err_obj.hasError = true;
                err_obj.nameLengthError = "Họ tên phải có độ dài từ 2 đến 50 kí tự";
            }
       
            if (!(err_obj.hasError == true))
            {
                if (dao.checkExist(username))
                {
                    err_obj.hasError = true;
                    err_obj.usernameExist = "Tên đăng nhập " + username + " đã được sử dụng";
                }
                else if (!dao.addAccount(name, username, password, isOwner))
                {
                    err_obj.hasError = true;
                }
            }
       
            return new JsonResult(err_obj);

        }
    }
}