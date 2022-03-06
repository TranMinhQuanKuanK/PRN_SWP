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

            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT name, point"
                    + " FROM customer "
                    + $"WHERE phone_no = @phone_no";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@phone_no", phone_no);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);


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
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null) connection.Close();
            }
            return cDTO;
        }

        public bool CreateNewCustomer(String phone_no, String name)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "INSERT INTO customer "
                        + " (phone_no, name, point)"
                        + " VALUES (@phone_no,@name,@point)";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            try
            {
                //nullable primitive type
                connection.Open();

                command.Parameters.Add("@phone_no", SqlDbType.NVarChar).Value = phone_no;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                command.Parameters.Add("@point", SqlDbType.Int).Value = 0;

               int? rowAffected = (int?) command.ExecuteScalar();

                connection.Close();
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
            //?
        }
        public bool AddPointCustomer(String phone_no, int point)
        {

            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT point"
                        + " FROM customer "
                        + "WHERE phone_no = @phone_no";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            int current_point = 0;
            try
            {
                connection.Open();
                command.Parameters.Add("@phone_no", SqlDbType.NVarChar).Value = phone_no;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                
                if (reader.HasRows == true)
                {
                    if (reader.Read())
                    {
                        current_point = reader.GetInt32("point");
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
            //---------------------------------------------
            SQLString = "UPDATE customer "
                        + "SET point = @point"
                        + " WHERE phone_no = @phone_no ";
            command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            try
            {
                connection.Open();
                command.Parameters.Add("@point", SqlDbType.Int).Value = current_point + point;
                command.Parameters.Add("@phone_no", SqlDbType.NVarChar).Value = phone_no;
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
