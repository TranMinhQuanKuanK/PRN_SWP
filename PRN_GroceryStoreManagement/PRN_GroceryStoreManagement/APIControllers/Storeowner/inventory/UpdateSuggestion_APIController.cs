using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.pendingItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.inventory
{
    [Authorize(Roles = "Admin")]
    [Route("UpdateSuggestion")]
    [ApiController]
    public class UpdateSuggestion_APIController : ControllerBase
    {
        [HttpPost]
        public IActionResult UpdateSuggestion([FromBody] JsonElement JsonObj)
        {
            int productID = int.Parse(JsonObj.GetProperty("product_ID").GetString());
            PendingItemDAO DAO = new PendingItemDAO();
            bool isExisted = DAO.IsExistedInPendingList(productID);
            if (isExisted)
            {
                DAO.UpdatePendingList(productID);
            }
            return new JsonResult(value: null);
        }
    }
}
