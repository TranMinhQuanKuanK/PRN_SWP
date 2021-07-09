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
    public class ReceiptDAO
    {
        public int CreateReceipt(DateTime import_date, string username, int total)
        {
            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "INSERT INTO receipt(import_date, store_owner_username, total) output INSERTED.receipt_ID "
                             + " VALUES (@import_date, @store_owner_username ,@total)";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            int receiptID = 0;
            try
            {
                connection.Open();

                command.Parameters.Add("@import_date", SqlDbType.DateTime).Value = import_date;
                command.Parameters.Add("@store_owner_username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@total", SqlDbType.Int).Value = total;

                receiptID = (int)command.ExecuteScalar();
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
            return receiptID;
        }
    }
}
