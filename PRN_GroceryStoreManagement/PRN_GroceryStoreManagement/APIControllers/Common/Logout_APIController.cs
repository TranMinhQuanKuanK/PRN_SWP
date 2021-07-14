using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Common
{
    [Route("Logout")]
    [ApiController]
    public class Logout_APIController : ControllerBase
    {
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.SetInt32("LOGIN_STATUS",0);
            HttpContext.Session.SetString("USERNAME","");
            HttpContext.Session.SetString("FULLNAME","");
            return Redirect("/");
        }
    }
}
