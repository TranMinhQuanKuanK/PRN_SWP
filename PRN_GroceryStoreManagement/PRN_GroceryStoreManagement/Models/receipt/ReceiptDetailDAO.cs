using PRN_GroceryStoreManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.receipt
{
    public class ReceiptDetailDAO
    {
        public bool CreateReceiptDetail(int product_ID, int quantity, int receipt_ID, int cost_price, int total)
        {
            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "INSERT INTO receipt_detail "
                            + "(product_ID, quantity, receipt_ID, cost_price, total) "
                            + " VALUES (@product_ID, @quantity, @receipt_ID, @cost_price, @total)";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            try
            {
                connection.Open();

                command.Parameters.Add("@product_ID", SqlDbType.Int).Value = product_ID;
                command.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;
                command.Parameters.Add("@receipt_ID", SqlDbType.Int).Value = receipt_ID;
                command.Parameters.Add("@cost_price", SqlDbType.Int).Value = cost_price;
                command.Parameters.Add("@total", SqlDbType.Int).Value = total;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    return true;
                }
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null) connection.Dispose();
            }
            return false;
        }
    }
}
