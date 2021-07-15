using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.feedback;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Cashier
{
    [Authorize(Roles = "Cashier")]
    [Route("SendFeedback")]
    [ApiController]
    public class SendFeedback_APIController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendFeedback([FromBody] JsonElement JsonObj)
        {
            String feedback_content = JsonObj.GetProperty("feedback_content").GetString();
            Debug.WriteLine("Content: " + feedback_content);
            if (feedback_content.Length <= 1000)
            {
                String cashier_username =  HttpContext.Session.GetString("USERNAME");
                FeedbackDAO fDAO = new FeedbackDAO();
                fDAO.createFeedback(DateTime.Now,
                        feedback_content, cashier_username);
            }
            return new JsonResult(null);
        }
    }
}
