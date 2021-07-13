using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.account;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.APIControllers.Storeowner.staff
{
    [Authorize(Roles = "Admin")]
    [Route("GetAccountList")]
    [ApiController]
    public class GetAccountList_APIControllers : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAccountList()
        {
            AccountDAO dao = new AccountDAO();
            dao.fetchAccountList();
            List<AccountDTO> resultList = dao.getAccountList();

            // already implement method Compare in AccountDTO
            resultList.Sort(delegate(AccountDTO x, AccountDTO y)
            {
                return x.is_owner.CompareTo(y.is_owner);
            });
            resultList.Reverse();

            return new JsonResult(resultList);
        }
    }
}