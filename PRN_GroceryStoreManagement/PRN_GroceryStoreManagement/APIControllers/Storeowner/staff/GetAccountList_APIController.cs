using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Models.account;
using System;
using System.Collections.Generic;

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
            try
            {
                AccountDAO dao = new AccountDAO();
                dao.fetchAccountList();
                List<AccountDTO> resultList = dao.getAccountList();

                // already implement method Compare in AccountDTO
                resultList.Sort(delegate (AccountDTO x, AccountDTO y)
                {
                    return x.is_owner.CompareTo(y.is_owner);
                });
                resultList.Reverse();

                return new JsonResult(resultList);
            }   
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(null);
}
    }
}