using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;//tự thêm
using System.Data.SqlClient;//cài thêm
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.account
{
    public class AccountDAO
    {
        
        public AccountDTO checkLogin( string username, string password)
        {
            string ConnectionString = "Data Source=localhost,1433;Initial Catalog=SWP_GroceryStoreDB;User ID=SWP;Password=SWPPassword";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand($"SELECT username, password_acc, name, is_owner " +
                $"FROM account WHERE username = '{username}' AND password_acc = '{password}'", connection);
            Debug.WriteLine("Username recevied: "+username);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            AccountDTO aDTO = null;
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
            return aDTO;
        }
    }
}
