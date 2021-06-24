using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    [Route("GetProductListForCashier")]
    [ApiController]
    public class GetProductListForCashier_APIController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetProductListForCashier(int? category_id, String search_value, bool only_noos_items = false)
        {

            List<ProductDTO> productList = new ProductDAO().GetProductListForCashier(category_id, search_value, only_noos_items);
           
            return new JsonResult(productList);
        }
    }
}
