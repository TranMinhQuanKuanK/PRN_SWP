using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Controllers
{
    public class StartupController : Controller
    {
        public IActionResult Index()
        {
            int? status = HttpContext.Session.GetInt32("LOGIN_STATUS");
            if (status==1)
            return View("StoreownerDashboard");
            else if (status == 2) return View("CashierDashboard");
            return View("LoginPage");
        }
    }
}
