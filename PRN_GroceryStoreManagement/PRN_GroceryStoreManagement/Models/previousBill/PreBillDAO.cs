using PRN_GroceryStoreManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PRN_GroceryStoreManagement.Models.previousBill
{
    public class PreBillDAO
    {
        private List<PreBillDTO> preBillList = new List<PreBillDTO>();

        public List<PreBillDTO> getPreBillList()
        {
            return preBillList;
        }

        public void searchPreviousBill(String searchValue, String dateFrom, String dateTo)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT bill_ID, name, customer.phone_no, buy_date, total_cost, "
                           + "cashier_username, point_used, cash\n"
                           + "FROM customer_bill\n"
                           + "JOIN customer ON customer.phone_no = customer_bill.phone_no\n"
                           + $"WHERE '{dateFrom}' <= buy_date AND buy_date <= '{dateTo}'";
            SqlCommand command = new SqlCommand(SQLString, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        int billID = reader.GetInt32("bill_ID");
                        string name = reader.GetString("name");
                        string phoneNo = reader.GetString("phone_no");

                        DateTime buy_Date = reader.GetDateTime("buy_date");
                        string buyDate = buy_Date.ToString("dd/MM/yyyy HH:mm:ss");

                        int totalCost = reader.GetInt32("total_cost");
                        List<PreBillDetailDTO> details = getBillDetails(billID);

                        string temp_cashier_username = reader.GetString("cashier_username");
                        string cashier = getCashierName(temp_cashier_username);

                        int pointUsed = reader.GetInt32("point_used");
                        int cash = reader.GetInt32("cash");

                        if (searchValue.Length == 0 || Char.IsDigit(searchValue[0]))
                        {
                            if (!phoneNo.Contains(searchValue))
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (!StringNormalizer.normalize(name).Contains(searchValue))
                            {
                                continue;
                            }
                        }

                        preBillList.Add(new PreBillDTO(billID, totalCost, pointUsed, cash,
                            name, phoneNo, buyDate, cashier, details));
                    }
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null) connection.Close();
            }
        }

        public void searchGuestPreviousBill(String dateFrom, String dateTo)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT bill_ID, buy_date, total_cost, "
                           + "cashier_username, point_used, cash\n"
                           + "FROM customer_bill\n"
                           + "WHERE customer_bill.phone_no IS NULL AND "
                           + $"'{dateFrom}' <= buy_date AND buy_date <= '{dateTo}'";
            SqlCommand command = new SqlCommand(SQLString, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        int billID = reader.GetInt32("bill_ID");
                        string name = "Khách hàng vãng lai";
                        string phoneNo = "Không có";

                        DateTime buy_Date = reader.GetDateTime("buy_date");
                        string buyDate = buy_Date.ToString("dd/MM/yyyy HH:mm:ss");

                        int totalCost = reader.GetInt32("total_cost");
                        List<PreBillDetailDTO> details = getBillDetails(billID);

                        string temp_cashier_username = reader.GetString("cashier_username");
                        string cashier = getCashierName(temp_cashier_username);

                        int pointUsed = reader.GetInt32("point_used");
                        int cash = reader.GetInt32("cash");

                        preBillList.Add(new PreBillDTO(billID, totalCost, pointUsed, cash,
                            name, phoneNo, buyDate, cashier, details));
                    }
                } else
                {
                    Console.WriteLine("NULLLLLLL");
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null) connection.Close();
            }
        }

        public List<PreBillDetailDTO> getBillDetails(int billID)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT product_ID, quantity, cost, total\n"
                            + "FROM customer_bill_detail\n"
                            + $"WHERE bill_ID = {billID}";
            SqlCommand command = new SqlCommand(SQLString, connection);

            List<PreBillDetailDTO> result = new List<PreBillDetailDTO>();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        int quantity = reader.GetInt32("quantity");
                        int cost = reader.GetInt32("cost");
                        int total = reader.GetInt32("total");

                        int temp_product_ID = reader.GetInt32("product_ID");
                        string productName = getProductName(temp_product_ID);

                        result.Add(new PreBillDetailDTO(quantity, cost, total, productName));
                    }
                }

                return result;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null) connection.Close();
            }

            return null;
        }

        public String getCashierName(String cashierUsername)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT name\n"
                           + "FROM account\n"
                           + $"WHERE username = '{cashierUsername}'";
            SqlCommand command = new SqlCommand(SQLString, connection);

            string cashierName = null;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        cashierName = reader.GetString("name");
                    }
                }

                return cashierName;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null) connection.Close();
            }

            return null;
        }

        public String getProductName(int productID)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT name\n"
                           + "FROM product\n"
                           + $"WHERE product_ID = '{productID}'";
            SqlCommand command = new SqlCommand(SQLString, connection);

            string productName = null;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        productName = reader.GetString("name");
                    }
                }

                return productName;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null) connection.Close();
            }

            return null;
        }

    }
}

