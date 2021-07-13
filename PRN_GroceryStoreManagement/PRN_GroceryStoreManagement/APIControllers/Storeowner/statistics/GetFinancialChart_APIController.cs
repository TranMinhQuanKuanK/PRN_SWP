using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.statistic;
using PRN_GroceryStoreManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.statistics
{
    [Route("GetFinancialChart")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class GetFinancialChart_APIController : Controller
    {
        [HttpGet]
        public IActionResult GetFinancialChart(string date_from, string date_to)
        {
            StatisticErrorObj errors = new StatisticErrorObj();

            //1. Check error
            if (date_from.CompareTo(date_to) > 0)
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

                List<string> events = new List<string>();
                List<int> revenue = new List<int>();
                List<int> profit = new List<int>();

                string dateIterator = date_from;
                while (dateIterator.CompareTo(date_to) <= 0)
                {
                    events.Add(dateIterator);
                    dateIterator = dao.nextMonth(dateIterator);
                }

                foreach (string month in events)
                {
                    revenue.Add(dao.getSumRevenue(month, dao.nextMonth(month)));
                    profit.Add(dao.sumProfit(month, dao.nextMonth(month)));
                }

                FinancialChartDataObj result = new FinancialChartDataObj
                {
                    Event = events,
                    Profit = profit,
                    Revenue = revenue
                };

                return new JsonResult(result);
            }
        }
    }
}
