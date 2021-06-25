using PRN_GroceryStoreManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.pendingItem
{
    public class PendingItemDAO
    {
        private List<PendingItemDTO> listPendingNoti = new List<PendingItemDTO>();

        public List<PendingItemDTO> GetPendingList()
        {
            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT pending_ID, product_ID, pending_date"
                        + ",is_resolved,note "
                        + " FROM pending_product_noti WHERE is_resolved = @is_resolved";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            try
            {
                connection.Open();

                command.Parameters.Add("@is_resolved", SqlDbType.Bit).Value = false;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        int pending_ID = reader.GetInt32("pending_ID");
                        int product_ID = reader.GetInt32("product_ID");
                        DateTime pending_date = reader.GetDateTime("pending_date");
                        String note = reader.GetString("note");

                        PendingItemDTO pDTO = new PendingItemDTO(pending_ID,
                            product_ID, pending_date, false, note);
                        listPendingNoti.Add(pDTO);
                    }
                }
                else return null;
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return listPendingNoti;
        }
        public bool CreatePendingList(int productID, DateTime pending_date, String note)
        {
            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "INSERT INTO pending_product_noti "
                        + " (product_ID, pending_date, is_resolved,note)"
                        + " VALUES (@product_ID,@pending_date,@is_resolved,@note)";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            try
            {
                connection.Open();

                command.Parameters.Add("@product_ID", SqlDbType.Int).Value = productID;
                command.Parameters.Add("@pending_date", SqlDbType.DateTime).Value = pending_date;
                command.Parameters.Add("@is_resolved", SqlDbType.Bit).Value = false;
                command.Parameters.Add("@note", SqlDbType.NVarChar).Value = note;

                int rowAffected = command.ExecuteNonQuery();

                connection.Close();
                return rowAffected > 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

    }
}
