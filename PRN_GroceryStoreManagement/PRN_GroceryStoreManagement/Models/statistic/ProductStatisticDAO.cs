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
        private Dictionary<int, ProductStatisticDTO> productStatisticMap;

        public Dictionary<int, ProductStatisticDTO> getProductStatisticMap() => productStatisticMap;

        public void searchProductStatisticMap(string dateFrom, string dateTo)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT customer_bill_detail.product_ID, customer_bill_detail.quantity, total, product.name "
                        + "FROM customer_bill_detail "
                        + "JOIN customer_bill ON customer_bill_detail.bill_ID = customer_bill.bill_ID "
                        + "JOIN product ON customer_bill_detail.product_ID = product.product_ID "
                        + $"WHERE {dateFrom} <= buy_date AND buy_date <= {dateTo}";

            SqlCommand command = new SqlCommand(SQLString, connection);

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

                    if(this.productStatisticMap == null)
                    {
                        this.productStatisticMap = new Dictionary<int, ProductStatisticDTO>();
                    }

                    if (this.productStatisticMap.ContainsKey(productID))
                    {
                        quantity += this.productStatisticMap[productID].Quantity;
                        total += this.productStatisticMap[productID].Total;
                    }

                    this.productStatisticMap.Add(productID, new ProductStatisticDTO
                    {
                        ProdcutName = productName,
                        Quantity = quantity,
                        Total = total
                    });
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
