using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PRN_GroceryStoreManagement.Utils;

namespace PRN_GroceryStoreManagement.Models.statistic
{
    public class FinancialStatisticDAO
    {
        public int getBillCount(string dateFrom, string dateTo)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT COUNT(*) count_bill FROM customer_bill "
                        + $"WHERE @date_from <= buy_date AND buy_date <= @date_to";


            int countBill = 0;
            try
            {
                SqlCommand command = new SqlCommand(SQLString, connection);
                command.Parameters.Add("@date_from", SqlDbType.NVarChar).Value = dateFrom;
                command.Parameters.Add("@date_to", SqlDbType.NVarChar).Value = dateTo;

                connection.Open();
                SqlDataReader Reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                while (Reader.Read())
                {
                    countBill = Reader.GetInt32(0);
                }

                connection.Close();
                return countBill;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int getReceiptCount(string dateFrom, string dateTo)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT COUNT(*) count_receipt FROM receipt "
                        + $"WHERE @date_from <= import_date AND import_date <= @date_to";

            SqlCommand command = new SqlCommand(SQLString, connection);
            command.Parameters.Add("@date_from", SqlDbType.NVarChar).Value = dateFrom;
            command.Parameters.Add("@date_to", SqlDbType.NVarChar).Value = dateTo;
            int countReceipt = 0;

            try
            {
                connection.Open();
                countReceipt = (int)command.ExecuteScalar();

                connection.Close();
                return countReceipt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int getSumRevenue(string dateFrom, string dateTo)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);

            if (dateFrom.Length == 7)
            {
                dateFrom += "-01";
            }

            if (dateTo.Length == 7)
            {
                dateTo += "-01";
            }

            string SQLString = "SELECT SUM(total_cost) sum_revenue FROM customer_bill "
                        + $"WHERE @date_from <= buy_date AND buy_date < @date_to";

            SqlCommand command = new SqlCommand(SQLString, connection);
            int sumRevenue = 0;
            command.Parameters.Add("@date_from", SqlDbType.NVarChar).Value = dateFrom;
            command.Parameters.Add("@date_to", SqlDbType.NVarChar).Value = dateTo;
            try
            {
                connection.Open();
                if (command.ExecuteScalar() == DBNull.Value)
                    sumRevenue = 0;
                else sumRevenue = (int)command.ExecuteScalar();

                connection.Close();
                return sumRevenue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int sumProfit(string dateFrom, string dateTo)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);

            if (dateFrom.Length == 7)
            {
                dateFrom += "-01";
            }

            if (dateTo.Length == 7)
            {
                dateTo += "-01";
            }

            string SQLString = "SELECT SUM(profit) sum_profit FROM customer_bill "
                        + $"WHERE @date_from <= buy_date AND buy_date <= @date_to";

            SqlCommand command = new SqlCommand(SQLString, connection);
            int sumProfit = 0;
            command.Parameters.Add("@date_from", SqlDbType.NVarChar).Value = dateFrom;
            command.Parameters.Add("@date_to", SqlDbType.NVarChar).Value = dateTo;
            try
            {
                connection.Open();
                if (command.ExecuteScalar() == DBNull.Value)
                    sumProfit = 0;
                else sumProfit = (int)command.ExecuteScalar();

                connection.Close();
                return sumProfit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int getSumCost(string dateFrom, string dateTo)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT SUM(total) sum_cost FROM receipt "
                        + $"WHERE @date_from <= import_date AND import_date <= @date_to";

            SqlCommand command = new SqlCommand(SQLString, connection);
            int sumCost = 0;
            command.Parameters.Add("@date_from", SqlDbType.NVarChar).Value = dateFrom;
            command.Parameters.Add("@date_to", SqlDbType.NVarChar).Value = dateTo;
            try
            {
                connection.Open();
                if (command.ExecuteScalar() == DBNull.Value)
                    sumCost = 0;
                else sumCost = (int)command.ExecuteScalar();

                connection.Close();
                return sumCost;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string nextMonth(string original)
        {
            string year = original.Substring(0, 4);
            string month = original.Substring(5);

            string[] next = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "01" };

            month = next[Int32.Parse(month)];

            if (month.Equals("01"))
            {
                int nextYear = Int32.Parse(year) + 1;
                year = nextYear.ToString();
            }

            return year + "-" + month;
        }
    }
}
