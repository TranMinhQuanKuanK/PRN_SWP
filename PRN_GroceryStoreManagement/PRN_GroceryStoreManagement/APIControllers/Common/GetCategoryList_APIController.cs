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
    [Route("GetCategoryList")]
    [ApiController]
    public class GetCategoryList_APIController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetCategoryList()
        {
            try
            {
                List<CategoryDTO> categoryList = new CategoryDAO().GetAllCategory();

                return new JsonResult(categoryList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(null);
        }
    }
}
