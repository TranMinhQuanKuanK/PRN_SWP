using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SqlServer;
using System.Data.SqlClient;
using PRN_GroceryStoreManagement.Utils;
using System.Data;

namespace PRN_GroceryStoreManagement.Models.statistic
{
    public class CustomerStatisticDAO
    {
        private Dictionary<String, CustomerStatisticDTO> customerStatisticMap = null;

        public Dictionary<String, CustomerStatisticDTO> getCustomerStatisticMap() => customerStatisticMap;

        public void searchCustomerStatistic (string dateFrom, String dateTo)
        {
            try
            {
                string ConnectionString = ConnectionStringUtil.GetConnectionString();
                SqlConnection connection = new SqlConnection(ConnectionString);
                string SQLString = "SELECT customer.phone_no, total_cost, name "
                            + "FROM customer_bill "
                            + "JOIN customer ON customer.phone_no = customer_bill.phone_no "
                            + "WHERE @date_from <= buy_date AND buy_date <= @date_to";
                SqlCommand command = new SqlCommand(SQLString, connection);

                command.Parameters.Add("@date_from", SqlDbType.NVarChar).Value = dateFrom;
                command.Parameters.Add("@date_to", SqlDbType.NVarChar).Value = dateTo;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
               
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        int total = reader.GetInt32(1);
                        string phoneNum = reader.GetString(0);
                        string customerName = reader.GetString(2);
                        int quantity = 1;

                        if (customerStatisticMap == null)
                        {
                            customerStatisticMap = new Dictionary<String, CustomerStatisticDTO>();
                        }

                        if (customerStatisticMap.ContainsKey(reader.GetString(0)))
                        {
                            this.customerStatisticMap[phoneNum].Quantity += quantity;
                            this.customerStatisticMap[phoneNum].Total += total;
                        }
                        else
                        {
                            this.customerStatisticMap.Add(phoneNum, new CustomerStatisticDTO
                            {
                                CustomerName = customerName,
                                Total = total,
                                PhoneNum = phoneNum,
                                Quantity = quantity
                            });
                        }
                        
                    }
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
