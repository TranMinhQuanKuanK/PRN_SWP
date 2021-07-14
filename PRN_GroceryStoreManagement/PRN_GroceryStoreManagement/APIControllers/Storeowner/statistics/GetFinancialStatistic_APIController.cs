using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.statistics
{
    [Route("GetFinancialStatistic")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class GetFinancialStatistic_APIController : Controller
    {
        [HttpGet]
        public IActionResult GetFinancialStatistic(string date_from, string date_to)
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
                    FinancialStatisticDAO dao = new FinancialStatisticDAO();
                    FinancialStatisticObj result = new FinancialStatisticObj();

                    if (dateFrom.Length == 7)
                    {
                        dateFrom += "-01 00:00:00";
                    }

                    if (dateTo.Length == 7)
                    {
                        dateTo = dao.nextMonth(dateTo);
                        dateTo += "-01 00:00:00";
                    }

                    result.countBill = dao.getBillCount(dateFrom, dateTo);
                    result.countReceipt = dao.getReceiptCount(dateFrom, dateTo);
                    result.sumRevenue = dao.getSumRevenue(dateFrom, dateTo);
                    result.sumProfit = dao.sumProfit(dateFrom, dateTo);
                    result.sumCost = dao.getSumCost(dateFrom, dateTo);

                return new JsonResult(result);
                }
        }
    }
}
