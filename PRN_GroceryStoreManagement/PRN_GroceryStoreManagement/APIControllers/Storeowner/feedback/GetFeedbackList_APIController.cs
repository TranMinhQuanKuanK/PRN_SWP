using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.feedback;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.feedback {
    [Authorize(Roles = "Admin")]
    [Route("GetFeedbackList")]
    [ApiController]
    public class GetFeedbackList_APIControllers : ControllerBase {
        [HttpGet]
        public IActionResult GetFeedbackList(int? feedback_ID) {
            FeedbackDAO fDAO = new FeedbackDAO();
            int temp_feedback_ID;
            if (feedback_ID == null){
                temp_feedback_ID = default(int); 
            } else {
                temp_feedback_ID = feedback_ID.Value;
            }

            if (feedback_ID != null) {
                fDAO.changeFeedbackToIsSeen(temp_feedback_ID);
            }

            List<FeedbackDTO> feedbackList = fDAO.getAllFeedbackList();
            return new JsonResult(feedbackList);
        }
    }
}