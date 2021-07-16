using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.statistics
{
    [Route("GetProductStatistic")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class GetProductStatistic_APIController : Controller
    {
        [HttpGet]
        public IActionResult GetProductStatistic(string date_from, string date_to)
        {
            try
            {
                StatisticErrorObj errors = new StatisticErrorObj();
                String dateFrom = date_from.Replace('T', ' ');
                String dateTo = date_to.Replace('T', ' ');


                //1. Check error
                if (dateFrom.Length == 0 || dateTo.Length == 0)
                {
                    errors.IsError = true;
                    errors.dateError = "Ngày nhập không tồn tại";
                }
                else if (dateFrom.CompareTo(dateTo) > 0)
                {
                    errors.IsError = true;
                    errors.dateError = "Ngày kết thúc phải lớn hơn ngày bắt đầu";
                }

                if (errors.IsError)
                {
                    //2.1 Caching errors, return error object
                    return new JsonResult(errors);
                }
                else
                {
                    //2.2 Call DAO
                    ProductStatisticDAO dao = new ProductStatisticDAO();
                    dao.searchProductStatisticMap(dateFrom, dateTo);

                    Dictionary<int, ProductStatisticDTO> resultMap = dao.getProductStatisticMap();
                    List<ProductStatisticDTO> resultList = new List<ProductStatisticDTO>();

                    if (resultMap != null)
                    {
                        resultList = new List<ProductStatisticDTO>(resultMap.Values.OrderByDescending(p => p.Quantity));
                    }
                    return new JsonResult(resultList);
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
