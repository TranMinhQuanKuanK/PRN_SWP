using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRN_GroceryStoreManagement.Utils;
using System.Data.SqlClient;
using System.Data;

namespace PRN_GroceryStoreManagement.Models.statistic
{
    public class ProductStatisticDAO
    {
        private Dictionary<int, ProductStatisticDTO> productStatisticMap = null;

        public Dictionary<int, ProductStatisticDTO> getProductStatisticMap() => productStatisticMap;

        public void searchProductStatisticMap(string dateFrom, string dateTo)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT customer_bill_detail.product_ID, customer_bill_detail.quantity, total, product.name "
                        + "FROM customer_bill_detail "
                        + "JOIN customer_bill ON customer_bill_detail.bill_ID = customer_bill.bill_ID "
                        + "JOIN product ON customer_bill_detail.product_ID = product.product_ID "
                        + "WHERE @date_from <= buy_date AND buy_date <= @date_to";

            SqlCommand command = new SqlCommand(SQLString, connection);
            command.Parameters.Add("@date_from", SqlDbType.NVarChar, 50).Value = dateFrom;
            command.Parameters.Add("@date_to", SqlDbType.NVarChar, 50).Value = dateTo;

            foreach (SqlParameter t in command.Parameters)
            {
                Console.WriteLine(t.Value.ToString());
            }
            try
            {

                connection.Open();
                SqlDataReader Reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                while (Reader.Read())
                {
                    int productID = Reader.GetInt32(0);
                    int quantity = Reader.GetInt32(1);
                    int total = Reader.GetInt32(2);
                    string productName = Reader.GetString(3);

                    if (productStatisticMap == null)
                    {
                        productStatisticMap = new Dictionary<int, ProductStatisticDTO>();
                    }

                    if (productStatisticMap.ContainsKey(productID))
                    {
                        productStatisticMap[productID].Quantity += quantity;
                        productStatisticMap[productID].Total += total;
                    }
                    else
                    {
                        productStatisticMap.Add(productID, new ProductStatisticDTO
                        {
                            ProductName = productName,
                            Quantity = quantity,
                            Total = total
                        });
                    }    
                }
                productStatisticMap.OrderByDescending(p => p.Value.Quantity);
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }
    }
}
