using PRN_GroceryStoreManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.category
{
    public class CategoryDAO
    {
        private List<CategoryDTO> listCategory = new List<CategoryDTO>();
        public List<CategoryDTO> GetAllCategory()
        {

            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT category_ID, name, info "
                        + "FROM category";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------ 
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                CategoryDTO cDTO = null;
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        int category_ID = reader.GetInt32("category_ID");
                        string name = reader.GetString("name");
                        string info = reader.GetString("info");
                        cDTO = new CategoryDTO(category_ID, name, info);
                        listCategory.Add(cDTO);
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
            return listCategory;
        }
        public CategoryDTO GetCategoryByID(int ID)
        {


            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = $"SELECT category_ID, name, info "
                        + $"FROM category WHERE category_ID={ID}";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                CategoryDTO cDTO = null;
                if (reader.HasRows == true)
                {
                    if (reader.Read())
                    {
                        int category_ID = reader.GetInt32("category_ID");
                        string name = reader.GetString("name");
                        string info = reader.GetString("info");
                        cDTO = new CategoryDTO(category_ID, name, info);
                        return cDTO;
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
            return null;
        }
    }
}
