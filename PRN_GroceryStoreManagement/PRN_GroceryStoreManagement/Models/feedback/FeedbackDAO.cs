using Microsoft.AspNetCore.Mvc;
using PRN_GroceryStoreManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PRN_GroceryStoreManagement.Models.feedback;
using PRN_GroceryStoreManagement.Models.account;

namespace PRN_GroceryStoreManagement.Models.feedback
{
    public class FeedbackDAO
    {
        public bool createFeedback(DateTime feedback_date, string feedback_content, string cashier_username)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "INSERT INTO cashier_feedback(feedback_date, feedback_content,"
                                + "is_seen, cashier_username)\n"
                                + "VALUES (@feedback_date,@feedback_content,@is_seen,@cashiser_username)";
            SqlCommand command = new SqlCommand(SQLString, connection);

            try
            {
                connection.Open();

                command.Parameters.Add("@feedback_date", SqlDbType.DateTime).Value = feedback_date;
                command.Parameters.Add("@feedback_content", SqlDbType.NVarChar).Value = feedback_content;
                command.Parameters.Add("@is_seen", SqlDbType.Bit).Value = false;
                command.Parameters.Add("@cashiser_username", SqlDbType.NVarChar).Value = cashier_username;

                int? rowAffected = (int?)command.ExecuteScalar();

                connection.Close();
                return rowAffected > 0;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        private List<FeedbackDTO> listFeedback = new List<FeedbackDTO>();

        public List<FeedbackDTO> getAllFeedbackList()
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT feedback_ID, feedback_date, feedback_content, is_seen, username, password_acc, name, is_owner\n"
                            + "FROM cashier_feedback\n"
                            + "JOIN account\n"
                            + "ON account.username = cashier_feedback.cashier_username\n"
                            + "ORDER BY feedback_date DESC";
            SqlCommand command = new SqlCommand(SQLString, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        int feedback_ID = reader.GetInt32("feedback_ID");
                        DateTime feedback_date = reader.GetDateTime("feedback_date");
                        string feedback_content = reader.GetString("feedback_content");
                        bool is_seen = reader.GetBoolean("is_seen");
                        // Get AccountDTO
                        string username = reader.GetString("username");
                        string password = reader.GetString("password_acc");
                        string name = reader.GetString("name");
                        bool is_owner = reader.GetBoolean("is_owner");
                        AccountDTO aDTO = new AccountDTO(username, password, name, is_owner);

                        FeedbackDTO tempFeedbackDTO = new FeedbackDTO(feedback_ID, feedback_date, feedback_content, is_seen, aDTO);
                        listFeedback.Add(tempFeedbackDTO);
                    }
                }
                else
                {
                    connection.Close();
                    return null;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return listFeedback;
        }

        public List<FeedbackDTO> getUnSeenFeedbackList()
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT feedback_ID, feedback_date, feedback_content, is_seen, username, password_acc, name, is_owner\n"
                            + "FROM cashier_feedback\n"
                            + "JOIN account\n"
                            + "ON account.username = cashier_feedback.cashier_username\n"
                            + "WHERE is_seen = 0\n"
                            + "ORDER BY feedback_date DESC";
            SqlCommand command = new SqlCommand(SQLString, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        int feedback_ID = reader.GetInt32("feedback_ID");
                        DateTime feedback_date = reader.GetDateTime("feedback_date");
                        string feedback_content = reader.GetString("feedback_content");
                        bool is_seen = reader.GetBoolean("is_seen");
                        // Get AccountDTO
                        string username = reader.GetString("username");
                        string password = reader.GetString("password_acc");
                        string name = reader.GetString("name");
                        bool is_owner = reader.GetBoolean("is_owner");
                        AccountDTO aDTO = new AccountDTO(username, password, name, is_owner);

                        FeedbackDTO tempFeedbackDTO = new FeedbackDTO(feedback_ID, feedback_date, feedback_content, is_seen, aDTO);
                        listFeedback.Add(tempFeedbackDTO);
                    }
                }
                else
                {
                    connection.Close();
                    return null;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return listFeedback;
        }

        public bool changeFeedbackToIsSeen(int feedback_ID)
        {
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "UPDATE cashier_feedback\n"
                                + "SET is_seen = 1\n"
                                + "WHERE feedback_ID = @feedback_ID";

            SqlCommand command = new SqlCommand(SQLString, connection);

            try
            {
                connection.Open();

                command.Parameters.Add("@feedback_ID", SqlDbType.Int).Value = feedback_ID;
                int? rowAffected = (int?)command.ExecuteScalar();
                connection.Close();
                return rowAffected > 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return false;
        }
        
    }
}