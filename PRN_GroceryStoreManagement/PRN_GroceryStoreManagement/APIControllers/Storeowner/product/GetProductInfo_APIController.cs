using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.product
{
    [Authorize(Roles = "Admin")]
    [Route("GetProductInfo")]
    [ApiController]
    public class GetProductInfo_APIController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProductInfo(string clickedProductID)
        {
            try
            {
                int productID = int.Parse(clickedProductID);

                ProductDAO dao = new ProductDAO();
                ProductDTO dto = dao.GetProductByID(productID);
                return new JsonResult(dto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(null);
        }
    }
}
