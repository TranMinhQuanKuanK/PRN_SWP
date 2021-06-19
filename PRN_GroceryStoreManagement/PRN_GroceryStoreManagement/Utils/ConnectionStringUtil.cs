using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Utils
{
    public static class ConnectionStringUtil
    {
        public static string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).Build();
            return config["ConnectionString"];
        }
    }
}
