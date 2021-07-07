using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.pendingItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.importgoods
{
    [Authorize(Roles = "Admin")]
    [Route("GetPendingItemList")]
    [ApiController]
    public class GetPendingItemList_APIController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetPendingItemList()
        {
            List<PendingItemDTO> pendingList = new PendingItemDAO().GetPendingList();

            return new JsonResult(pendingList);
        }
    }
}
