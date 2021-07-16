using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.feedback;
using System.Collections.Generic;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.feedback
{
    [Authorize(Roles = "Admin")]
    [Route("GetFeedbackList")]
    [ApiController]
    public class GetFeedbackList_APIControllers : ControllerBase
    {
        [HttpGet]
        public IActionResult GetFeedbackList(int? feedback_ID)
        {
            FeedbackDAO fDAO = new FeedbackDAO();
            int temp_feedback_ID;
            if (feedback_ID == null)
            {
                temp_feedback_ID = default(int);
            }
            else
            {
                temp_feedback_ID = feedback_ID.Value;
            }

            if (feedback_ID != null)
            {
                fDAO.changeFeedbackToIsSeen(temp_feedback_ID);
            }

            List<FeedbackDTO> feedbackList = fDAO.getAllFeedbackList();
            return new JsonResult(feedbackList);
        }
    }
}