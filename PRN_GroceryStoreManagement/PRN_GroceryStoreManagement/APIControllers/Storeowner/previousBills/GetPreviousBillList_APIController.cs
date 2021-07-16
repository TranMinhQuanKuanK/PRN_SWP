using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.previousBill;
using PRN_GroceryStoreManagement.Utils;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.previousBill
{
    [Authorize(Roles = "Admin")]
    [Route("GetPreviousBillList")]
    [ApiController]
    public class GetPreviousBillList_APIControllers : ControllerBase
    {
        [HttpPost]
        public IActionResult GetPreviousBillList([FromBody] JsonElement JsonObj)
        {
            string searchValue = JsonObj.GetProperty("search_Value").GetString();
            string date_from = JsonObj.GetProperty("date_from").GetString();
            string date_to = JsonObj.GetProperty("date_to").GetString();
            
            string dateFrom = date_from.Replace('T', ' ');
            string dateTo = date_to.Replace('T', ' ');
            PreBillErrorObj errors = new PreBillErrorObj();

            if (dateFrom.Length == 10)
            {
                dateFrom += " 00:00:00";
            }

            if (dateTo.Length == 10)
            {
                dateTo += " 23:59:59";
            }

            if (searchValue == null)
            {
                searchValue = "";
            }
            else
            {
                searchValue = StringNormalizer.normalize(searchValue);
            }

            if (dateFrom.Length == 0 || dateTo.Length == 0)
            {
                errors.isError = true;
                errors.dateError = "Ngày nhập không tồn tại";
            }
            else if (dateFrom.CompareTo(dateTo) > 0)
            {
                errors.isError = true;
                errors.dateError = "Ngày kết thúc phải lớn hơn ngày bắt đầu";
            }

            if (errors.isError == true)
            {
                return new JsonResult(errors);
            }
            else
            {
                //2.2 Call DAO
                PreBillDAO dao = new PreBillDAO();
                String guestName = StringNormalizer.normalize("Khách hàng vãng lai");
                dao.searchPreviousBill(searchValue, dateFrom, dateTo);
                if (searchValue.Length == 0 || guestName.Contains(searchValue))
                {
                    dao.searchGuestPreviousBill(dateFrom, dateTo);
                }

                List<PreBillDTO> resultList = dao.getPreBillList();

                if (resultList == null)
                {
                    resultList = new List<PreBillDTO>();
                }
                else
                {
                    resultList.Sort(delegate(PreBillDTO x, PreBillDTO y)
                    {
                        return DateTime.Parse(x.buyDate).CompareTo(DateTime.Parse(y.buyDate));
                    });
                    resultList.Reverse();
                }

                return new JsonResult(resultList);
            }
        }
    }
}
