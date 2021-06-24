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
    [Route("GetProductList")]
    [ApiController]
    public class GetProductList_APIController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetProductList(int? category_id, String search_value, bool only_noos_items = false)
        { 

            List<ProductDTO> productList = new ProductDAO().GetProductList(category_id, search_value, only_noos_items);
           
            return new JsonResult(productList);
        }
    }
}
