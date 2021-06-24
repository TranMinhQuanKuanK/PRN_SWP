using PRN_GroceryStoreManagement.Models.category;
using PRN_GroceryStoreManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.product
{
    public class BillDAO
    {
        public int CreateBill(String phone_no, DateTime buy_date, String cashier_username,
            int? total_cost, int? point_used, int? cash, int? profit) {

            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "INSERT INTO customer_bill(phone_no,"
                    + "buy_date, cashier_username, total_cost, "
                    + "point_used , cash, profit) output INSERTED.bill_ID"
                    + " VALUES (@phone_no, @buy_date, @cashier_username, " +
                    "@total_cost, @point_used, @cash, @profit)";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            try
            {
                connection.Open();

                command.Parameters.Add("@phone_no", SqlDbType.NVarChar).Value = phone_no;
                command.Parameters.Add("@buy_date", SqlDbType.DateTime).Value = buy_date;
                command.Parameters.Add("@cashier_username", SqlDbType.NVarChar).Value = cashier_username;
                command.Parameters.Add("@total_cost", SqlDbType.Int).Value = total_cost;
                command.Parameters.Add("@point_used", SqlDbType.Int).Value = point_used;
                command.Parameters.Add("@cash", SqlDbType.Int).Value = cash;
                command.Parameters.Add("@profit", SqlDbType.Int).Value = profit;

                int bill_ID = (int)command.ExecuteScalar();
                
                connection.Close();
                return bill_ID;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return -9999;
        }


    }
}
