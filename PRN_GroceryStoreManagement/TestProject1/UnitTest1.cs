using PRN_GroceryStoreManagement.Models.product;
using PRN_GroceryStoreManagement.Utils;
using System;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            StringNormalizer sn = new StringNormalizer();
            Assert.Equal("uNIT TEST SUONG GHE NHE", 
                StringNormalizer.normalize("Unit test   sướng    ghê  nhề"));
        }
        [Fact]
        public void TestBillDAO()
        {
            BillDAO bDAO = new BillDAO();
            int result = bDAO.CreateBill("0978610119", DateTime.Now, "cashier", 1000, 0, 20000, 0);
            Assert.Equal(1, result);
            //ProductDAO
        }
    }
}
