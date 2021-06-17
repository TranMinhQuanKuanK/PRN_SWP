using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PRN_GroceryStoreManagement.Models.category;
using PRN_GroceryStoreManagement.Models.product;
using PRN_GroceryStoreManagement.Models.sessionBill;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Common
{
    [Authorize(Roles = "Cashier")]
    [Route("GetBill")]
    [ApiController]
    public class GetBill_APIController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetBill()
        {
         
            BillObj bill = null;
            String BillJSONString = HttpContext.Session.GetString("BILL");
            if (BillJSONString == null)
            {
                bill = new BillObj();
               // bill.Bill_Detail.Add(new BillItemObject(new ProductDTO(23, "Sản phẩm test ASP.NET số 1", 2, 23000, 24000, 10, new CategoryDTO(3,"Sữa","blabla"), "Chai", true, "Trên kệ"), 3));
               // bill.Bill_Detail.Add(new BillItemObject(new ProductDTO(23, "Sản phẩm test ASP.NET số 2", 3, 23000, 24500, 10, new CategoryDTO(5, "Muối", "blabla"), "Chai", true, "Trên kệ"), 6));
               // bill.Bill_Detail.Add(new BillItemObject(new ProductDTO(23, "Sản phẩm test ASP.NET số 2", 3, 23000, 24500, 10, new CategoryDTO(5, "Muối", "blabla"), "Chai", true, "Trên kệ"), 4));
                HttpContext.Session.SetString("BILL", JsonConvert.SerializeObject(bill));
                Debug.WriteLine("WTF: " + JsonConvert.SerializeObject(bill));
            } else
            {
                bill = JsonConvert.DeserializeObject<BillObj>(BillJSONString);
                bill.err_obj = new BillErrObj();
            }
           
            return new JsonResult(bill);
        }
    }
}
