using PRN_GroceryStoreManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.customer
{
    public class CustomerDAO
    {
        //cái dở là chưa set được connnection string global
       

        public CustomerDTO GetCustomerByPhone(String phone_no)
        {
            CustomerDTO cDTO = null;
            try
            {
                //---------------đoạn code copy-------------------
                string ConnectionString = ConnectionStringUtil.GetConnectionString();
                SqlConnection connection = new SqlConnection(ConnectionString);
                string SQLString = "SELECT name, point"
                        + " FROM customer "
                        + $"WHERE phone_no = {phone_no}";
                SqlCommand command = new SqlCommand(SQLString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                //------------------------------------------------
                
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                            String name = reader.GetString("name");
                            int point = reader.GetInt32("point");
                            cDTO = new CustomerDTO(phone_no, name, point);

                    }
                }
                else return null;
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return cDTO;
        }

        public bool CreateNewCustomer(String phone_no, String name)
        {

            return false;
        //?
        }
    }
}
