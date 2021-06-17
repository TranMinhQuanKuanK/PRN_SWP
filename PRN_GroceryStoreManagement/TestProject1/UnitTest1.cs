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
        public void Test2()
        {
            //ProductDAO
        }
    }
}
