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
    [Route("AddToSuggestion")]
    [ApiController]
    public class AddToSuggestion_APIController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddToSuggestion([FromBody] JsonElement JsonObj)
        {
            int productID = int.Parse(JsonObj.GetProperty("product_ID").GetString());
            string notiMessage = JsonObj.GetProperty("noti_mess").GetString();
            if (notiMessage.Equals("owner"))
            {
                notiMessage = "Được thêm bởi store owner";
                DateTime notedate = DateTime.Now;                   
                PendingItemDAO DAO = new PendingItemDAO();
                string? returnMess = null;
                bool isExisted = DAO.IsExistedInPendingList(productID);
                if (!isExisted)
                { // chưa tồn tại trong Pending thì ghi xuống
                    DAO.CreatePendingList(productID, notedate, notiMessage);
                    return new JsonResult("1");
                }
                else
                {
                    return new JsonResult("1");
                }
            }
            else if (notiMessage.Equals("auto"))
            {
                notiMessage = "Được thêm tự động";
                DateTime notedate = DateTime.Now;
                PendingItemDAO DAO = new PendingItemDAO();
                string? returnMess = null;
                bool isExisted = DAO.IsExistedInPendingList(productID);
                if (!isExisted)
                {
                    DAO.CreatePendingList(productID, notedate, notiMessage);
                    return new JsonResult("1");
                }
            }
            return new JsonResult(value: null);
        }

    }
}
