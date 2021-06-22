using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index()
        {
            return View("ProductList");
        }
    }
}
