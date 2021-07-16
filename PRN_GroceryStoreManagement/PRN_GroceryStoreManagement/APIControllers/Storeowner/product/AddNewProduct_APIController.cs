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

            try
            {
                bool foundErr = false;
                ProductError err = new ProductError();
                ProductDAO dao = new ProductDAO();

                string productName;
                int productCategoryID, productLowerThreshold = 0, productCostPrice = 0, productSellingPrice = 0;
                string productUnitLabel, productLocation;
                bool productIsSelling;

                if (!int.TryParse(JsonObj.GetProperty("productLowerThreshold").GetString(), out productLowerThreshold))
                {
                    foundErr = true;
                    err.LowerThresholdErr = "Mức dưới ngưỡng quá lớn";
                }
                if (!int.TryParse(JsonObj.GetProperty("productCostPrice").GetString(), out productCostPrice))
                {
                    foundErr = true;
                    err.CostPriceErr = "Tiền mua quá lớn";
                }
                if (!int.TryParse(JsonObj.GetProperty("productSellingPrice").GetString(), out productSellingPrice))
                {
                    foundErr = true;
                    err.SellingPriceErr = "Tiền bán quá lớn";
                }

                if (!foundErr)
                {
                    if (productLowerThreshold < 0)
                    {
                        foundErr = true;
                        err.LowerThresholdErr = "Mức dưới ngưỡng phải lớn hơn 0";
                    }
                    if (productCostPrice < 0)
                    {
                        foundErr = true;
                        err.CostPriceErr = "Tiền mua phải lớn hơn 0";
                    }
                    if (productSellingPrice < 0)
                    {
                        foundErr = true;
                        err.SellingPriceErr = "Tiền bán phải lớn hơn 0";
                    }
                }

                productName = JsonObj.GetProperty("productName").GetString();
                productCategoryID = int.Parse(JsonObj.GetProperty("productCategoryID").GetString());
                //productLowerThreshold = int.Parse(JsonObj.GetProperty("productLowerThreshold").GetString());
                //productCostPrice = int.Parse(JsonObj.GetProperty("productCostPrice").GetString());
                //productSellingPrice = int.Parse(JsonObj.GetProperty("productSellingPrice").GetString());
                productUnitLabel = JsonObj.GetProperty("productUnitLabel").GetString();
                productLocation = JsonObj.GetProperty("productLocation").GetString();
                productIsSelling = JsonObj.GetProperty("productIsSelling").GetBoolean();

                if (productName.Equals("") || productName.Length > 100)
                {
                    foundErr = true;
                    err.NameErr = "Tên món hàng phải từ 1 tới 100 chữ";
                }

                if (dao.ConfirmMatchedProduct(productName, 0))
                {
                    foundErr = true;
                    err.NameErr = "Tên món hàng đã tồn tại";
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(null);
        }
    }
}
