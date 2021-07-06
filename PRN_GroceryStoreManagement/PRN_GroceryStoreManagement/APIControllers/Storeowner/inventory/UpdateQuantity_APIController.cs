using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.inventory
{ 
    [Authorize(Roles = "Admin")]
    [Route("UpdateQuantity")]
    [ApiController]
    public class UpdateQuantity_APIController : ControllerBase
    {
        [HttpPost] 
        public IActionResult UpdateQuantity([FromBody] JsonElement JsonObj)
        {
            int productID = int.Parse(JsonObj.GetProperty("product_ID").GetString());
            int quantity = int.Parse(JsonObj.GetProperty("new_quantity").GetString());
            if (quantity >= 0)
            {
                ProductDAO DAO = new ProductDAO();
                DAO.changeQuantity(productID, quantity);
            }
            return null;
        }
    }
}
