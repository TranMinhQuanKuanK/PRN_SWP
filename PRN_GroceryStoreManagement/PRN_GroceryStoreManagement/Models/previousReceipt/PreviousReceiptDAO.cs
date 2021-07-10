using PRN_GroceryStoreManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.previousReceipt
{
    public class PreviousReceiptDAO
    {
        private List<PreviousReceiptDTO> listReceipt = new List<PreviousReceiptDTO>();

        public List<PreviousReceiptDTO> GetPreviousReceipt(string dateFrom, string dateTo)
        {
            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT receipt_ID, import_date, store_owner_username, total "
                                + "FROM receipt "
                                + "WHERE @dateFrom <= import_date AND import_date <=@dateTo";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            try
            {
                connection.Open();
                command.Parameters.Add("@dateFrom", SqlDbType.NChar).Value = dateFrom;
                command.Parameters.Add("@dateTo", SqlDbType.NChar).Value = dateTo;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        int receipt_ID = reader.GetInt32("receipt_ID");
                        DateTime import_date_Date = reader.GetDateTime("import_date");
                        string import_date = import_date_Date.ToString("yyyy-MM-dd hh:mm:ss");
                        import_date = StringNormalizer.dateNormalize(import_date);
                        string storeowner_name = reader.GetString("store_owner_username");
                        string owner_name = getStoreOwnerName(storeowner_name);
                        int total = reader.GetInt32("total");
                        PreviousReceiptDTO DTO = new PreviousReceiptDTO(receipt_ID, import_date, owner_name, total);
                        listReceipt.Add(DTO);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null) connection.Dispose();
            }
            return listReceipt;
        }

        public string getStoreOwnerName(string store_owner_username)
        {
            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT name "
                            + "FROM account "
                            + "WHERE username = @store_owner_username";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            string owner_name = null;
            try
            {
                connection.Open();
                command.Parameters.Add("@store_owner_username", SqlDbType.NChar).Value = store_owner_username;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    owner_name = reader.GetString("name");
                    return owner_name;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return owner_name;
        }

        public List<PreviousReceiptDetailDTO> GetReceiptDetails(int receiptID)
        {
            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT R.product_ID, R.quantity, R.cost_price, R.total, P.name "
                                + "FROM receipt_detail R JOIN product P ON R.product_ID = P.product_ID "
                                + "WHERE R.receipt_ID = @receiptID";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            List<PreviousReceiptDetailDTO> result = null;
            try
            {
                connection.Open();
                command.Parameters.Add("@receiptID", SqlDbType.Int).Value = receiptID;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        int quantity = reader.GetInt32("quantity");
                        int cost = reader.GetInt32("cost_price");
                        int total = reader.GetInt32("total");
                        string productName = reader.GetString("name");
                        if (result == null)
                        {
                            result = new List<PreviousReceiptDetailDTO>();
                        }
                        result.Add(new PreviousReceiptDetailDTO(quantity, cost, total, productName));
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null) connection.Dispose();
            }
            return result;
        }
    }
}
