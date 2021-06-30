using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Utils
{
    public class TryParseInt
    {
        public static int tryParse(String input)
        {
            try
            {
                return int.Parse(input);
            }
            catch (NumberFormatException ex)
            {
                return null;
            }
        }
    }
}
