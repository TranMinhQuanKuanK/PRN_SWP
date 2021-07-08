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
            int? total_cost, int? point_used, int? cash, int? profit)
        {
            if (phone_no == null) Debug.WriteLine("sđt null rồi");
            if (cash == null) Debug.WriteLine("cash null rồi");
           // Debug.WriteLine($"Tôi đã ghi bill {phone_no},buydate {buy_date} với {cashier_username}, cost: {total_cost}, point: {point_used}, cash: {cash}, profit: {profit}");
            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "INSERT INTO customer_bill (phone_no,"
                    + "buy_date, cashier_username, total_cost, "
                    + "point_used , cash, profit) output INSERTED.bill_ID"
                    + " VALUES (@phone_no, @buy_date, @cashier_username, " +
                    "@total_cost, @point_used, @cash, @profit)";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            int bill_ID = 0;
            try
            {
                connection.Open();

                command.Parameters.Add("@phone_no", SqlDbType.NVarChar).Value = (phone_no==null)? DBNull.Value : phone_no;
                command.Parameters.Add("@buy_date", SqlDbType.DateTime).Value = buy_date;
                command.Parameters.Add("@cashier_username", SqlDbType.NVarChar).Value = cashier_username;
                command.Parameters.Add("@total_cost", SqlDbType.Int).Value = total_cost;
                command.Parameters.Add("@point_used", SqlDbType.Int).Value = point_used;
                command.Parameters.Add("@cash", SqlDbType.Int).Value = (cash==null)? 0 : cash;
                command.Parameters.Add("@profit", SqlDbType.Int).Value = profit;

                bill_ID = (int)command.ExecuteScalar();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null) connection.Close();
            }
            return bill_ID;
        }
        public bool CreateBillDetail(int? bill_ID, int? product_ID,
            int? quantity, int? cost, int? total)
        {
           // Debug.WriteLine($"Tôi đã ghi billd detail billID: {bill_ID}, với product {product_ID}, quantity: {quantity}, cost: {cost}, total: {total}");
            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "INSERT INTO customer_bill_detail"
                     + "(bill_ID, product_ID, quantity, cost,total)"
                     + " VALUES (@bill_ID, @product_ID, @quantity, " +
                    "@cost, @total)";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            try
            {
                connection.Open();

                command.Parameters.Add("@bill_ID", SqlDbType.Int).Value = bill_ID;
                command.Parameters.Add("@product_ID", SqlDbType.Int).Value = product_ID;
                command.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;
                command.Parameters.Add("@cost", SqlDbType.Int).Value = cost;
                command.Parameters.Add("@total", SqlDbType.Int).Value = total;

                int rowAffected = command.ExecuteNonQuery();

                return rowAffected > 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null) connection.Close();
            }
            return false;
        }


    }
}
