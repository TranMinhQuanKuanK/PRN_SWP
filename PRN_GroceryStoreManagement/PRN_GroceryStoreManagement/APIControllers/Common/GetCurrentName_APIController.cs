using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.category;
using PRN_GroceryStoreManagement.Models.product;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Common
{
    [Authorize(Roles = "Admin,Cashier")]
    [Route("GetCurrentName")]
    [ApiController]
    public class GetCurrentName_APIController : ControllerBase
    {
        
        [HttpGet]
        public string GetCategoryList()
        {
       
            string currentName = HttpContext.Session.GetString("FULLNAME");
                return currentName;
        }
    }
}
