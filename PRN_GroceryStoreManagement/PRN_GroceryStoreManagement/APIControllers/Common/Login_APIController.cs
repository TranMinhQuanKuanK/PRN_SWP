using Microsoft.AspNetCore.Authentication;//thêm
using Microsoft.AspNetCore.Authentication.Cookies;//thêm
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PRN_GroceryStoreManagement.Models.account;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;//thêm 
using System.Text.Json;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Common
{
    [Route("Login")]
    [ApiController]
    public class Login_APIController : ControllerBase
    {
        [HttpPost]
        public IActionResult checkLogin([FromBody] JsonElement DataObj)
        {
          string txtUsername = DataObj.GetString("txtUsername");
            string txtPassword = DataObj.GetString("txtPassword");
            Debug.WriteLine($"Username la: {txtUsername} va password la: {txtUsername}");
            ClaimsIdentity identity = null;
            bool isAuthenticated = false; //xử lí sau
            string name = "",role ="";
            LoginErrObj errobj = null;
           AccountDTO aDTO = new AccountDAO().checkLogin(txtUsername, txtPassword);
            if (aDTO==null) {
                errobj = new LoginErrObj("Username or password is incorrect! Please try again");
            } else
            {
                isAuthenticated = true;
                name = aDTO.username;
                role = (aDTO.is_owner == true) ? "Admin" : "Cashier";
            } 
            if (isAuthenticated)
            {
                identity = new ClaimsIdentity
                (
                new[] {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Role, role)
                       }, CookieAuthenticationDefaults.AuthenticationScheme
                );
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme
                    , principal);
                errobj = new LoginErrObj(false, (aDTO.is_owner == true) ? 1 : 2);
                HttpContext.Session.SetInt32("LOGIN_STATUS", (aDTO.is_owner == true)?1:2);
                HttpContext.Session.SetString("USERNAME", aDTO.username);
                HttpContext.Session.SetString("FULLNAME", aDTO.name);
            }
            

            return new JsonResult(errobj);
        }
    }
}
