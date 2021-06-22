using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PreviousBillsController : Controller
    {
        public IActionResult Index()
        {
            return View("PreviousBills");
        }
    }
}
