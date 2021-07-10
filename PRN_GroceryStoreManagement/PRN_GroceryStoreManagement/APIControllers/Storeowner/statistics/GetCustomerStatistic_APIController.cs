using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRN_GroceryStoreManagement.Models.statistic;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.statistics
{
    [Route("GetCustomerStatistic")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class GetCustomerStatistic_APIController : Controller
    {
        public IActionResult GetCustomerStatistic(string date_from, string date_to)
        {
            StatisticErrorObj errors = new StatisticErrorObj();

            String dateFrom = date_from.Replace("T", " ");
            String dateTo = date_to.Replace("T", " ");


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
                CustomerStatisticDAO dao = new CustomerStatisticDAO();
                dao.searchCustomerStatistic(dateFrom, dateTo);

                Dictionary<String, CustomerStatisticDTO> resultMap = dao.getCustomerStatisticMap();
                List<CustomerStatisticDTO> resultList = new List<CustomerStatisticDTO>();

                if (resultMap != null)
                {
                    resultList = new List<CustomerStatisticDTO>(resultMap.Values);
                }
                return new JsonResult(resultList);
            }
        }
    }
}
