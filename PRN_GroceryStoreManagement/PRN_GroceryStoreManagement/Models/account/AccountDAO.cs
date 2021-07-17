using PRN_GroceryStoreManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PRN_GroceryStoreManagement.Models.account
{
    public class AccountDAO
    {
        private List<AccountDTO> accountList = new List<AccountDTO>();

        public List<AccountDTO> getAccountList()
        {
            return accountList;
        }

        public AccountDTO checkLogin(string username, string password)
        {
            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand($"SELECT username, password_acc, name, is_owner " +
                $"FROM account WHERE username = '{username}' AND password_acc = '{password}'", connection);
            AccountDTO aDTO = null;
            //------------------------------------------------
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    if (reader.Read())
                    {
                        //Username = reader.GetString("username"),
                        string _username = reader.GetString("username");
                        string _password_acc = reader.GetString("password_acc");
                        string _name = reader.GetString("name");
                        bool _is_owner = reader.GetBoolean("is_owner");


                        aDTO = new AccountDTO(_username, _password_acc, _name, _is_owner);
                    }
                }
                else return null;
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return aDTO;
        }

        public bool ChangePassword(string username, string password)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "UPDATE account\n"
                                + "SET password_acc = @password\n"
                                + "WHERE username = @username";
            SqlCommand command = new SqlCommand(SQLString, connection);

            try
            {
                connection.Open();

                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
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

        public void fetchAccountList()
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT username, name, is_owner\n"
                                + "FROM account\n"
                                + "WHERE is_active = 'true'";

            SqlCommand command = new SqlCommand(SQLString, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows == true)
                {

                    while (reader.Read())
                    {
                        string username = reader.GetString("username");
                        string name = reader.GetString("name");
                        bool isOwner = reader.GetBoolean("is_owner");

                        AccountDTO aDTO = new AccountDTO(username, name, isOwner);
                        accountList.Add(aDTO);
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

        public bool resetAccount(string username)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "UPDATE account\n"
                                + "SET password_acc = '123456'\n"
                                + "WHERE username = @username";
            SqlCommand command = new SqlCommand(SQLString, connection);

            try
            {
                connection.Open();

                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
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

        public bool deleteAccount(string username)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "UPDATE account\n"
                                + "SET is_active = 'false'\n"
                                + "WHERE username = @username";
            SqlCommand command = new SqlCommand(SQLString, connection);

            try
            {
                connection.Open();

                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
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

        public bool addAccount(string name, string username, string password, bool isOwner)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "INSERT INTO account (username, password_acc, name, is_owner, is_active)\n"
                                + "VALUES (@username, @password, @name, @is_owner, 'true')";
            SqlCommand command = new SqlCommand(SQLString, connection);

            try
            {
                connection.Open();

                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@is_owner", SqlDbType.Bit).Value = isOwner;

                int rowAffected = command.ExecuteNonQuery();
               
                return rowAffected > 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message+"loi o day");
            }
            finally
            {
                if (connection != null) connection.Close();
            }
            return false;

        }

        public bool checkExist(string username)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT username\n"
                                + "FROM account\n"
                                + $"WHERE username = '{username}'";
            SqlCommand command = new SqlCommand(SQLString, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows == true)
                {
                    return true;
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
            return false;
        }

    }
}
