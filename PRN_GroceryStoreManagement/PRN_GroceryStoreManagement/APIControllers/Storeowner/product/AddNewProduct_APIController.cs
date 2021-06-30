using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.product
{
    [Authorize(Roles = "Admin")]
    [Route("AddNewProduct")]
    [ApiController]
    public class AddNewProduct_APIController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddNewProduct([FromBody] JsonElement JsonObj)
        {
            bool foundErr = false;
            ProductError err = new ProductError();
            ProductDAO dao = new ProductDAO();

            String productName = JsonObj.GetProperty("productName").GetString();
            int productCategoryID = JsonObj.GetProperty("productCategoryID").GetInt32();
            int productLowerThreshold = JsonObj.GetProperty("productLowerThreshold").GetInt32();
            int productCostPrice = JsonObj.GetProperty("productCostPrice").GetInt32();
            int productSellingPrice = JsonObj.GetProperty("productSellingPrice").GetInt32();
            String productUnitLabel = JsonObj.GetProperty("productUnitLabel").GetString();
            String productLocation = JsonObj.GetProperty("productLocation").GetString();
            bool productIsSelling = JsonObj.GetProperty("productIsSelling").GetBoolean();

            if (productName.Equals("") || productName.Length > 100)
            {
                foundErr = true;
                err.setNameErr("Tên món hàng phải từ 1 tới 100 chữ");
            }

            if (dao.ConfirmMatchedProduct(productName, 0))
            {
                foundErr = true;
                err.setNameErr("Tên món hàng đã tồn tại");
            }
            if (productLowerThreshold < 0)
            {
                foundErr = true;
                err.setLowerThresholdErr("Mức dưới ngưỡng phải lớn hơn 0");
            }
            if (productCostPrice < 0)
            {
                foundErr = true;
                err.setCostPriceErr("Tiền mua phải lớn hơn 0");
            }
            if (productSellingPrice < 0)
            {
                foundErr = true;
                err.setSellingPriceErr("Tiền bán phải lớn hơn 0");
            }

            if (foundErr)
            {
                return new JsonResult(err);
            }
            else
            {
                bool result = dao.AddNewProduct(productName, productCategoryID, productLowerThreshold, productCostPrice, productSellingPrice, productUnitLabel, productLocation, productIsSelling);
                if (result)
                {
                    return new JsonResult(null);
                }
                else
                {
                    return new JsonResult("Something wrong");
                }
            }
        }
}
