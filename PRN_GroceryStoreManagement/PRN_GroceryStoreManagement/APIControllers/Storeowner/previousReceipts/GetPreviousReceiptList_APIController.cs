using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.previousReceipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.previousReceipts
{
    [Authorize(Roles = "Admin")]
    [Route("GetPreviousReceiptList")]
    [ApiController]
    public class GetPreviousReceiptList_APIController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetPreviousReceiptList(string? date_from, string? date_to)
        {
            try
            {
                string? dateFrom = date_from;
                string? dateTo = date_to;
                if (dateFrom.Length == 10)
                {
                    dateFrom += " 00:00:00";
                }
                if (dateTo.Length == 10)
                {
                    dateTo += " 23:59:59";
                }
                PreviousReceiptDAO DAO = new PreviousReceiptDAO();
                List<PreviousReceiptDTO> receiptList = DAO.GetPreviousReceipt(dateFrom, dateTo);
                return new JsonResult(receiptList);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(null);
}
        
    }
}
