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
            try
            {
                //---------------đoạn code copy-------------------
                string ConnectionString = ConnectionStringUtil.GetConnectionString();
                SqlConnection connection = new SqlConnection(ConnectionString);
                string SQLString = $"SELECT category_ID, name, info "
                            + "FROM category";
                SqlCommand command = new SqlCommand(SQLString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                //------------------------------------------------
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
                connection.Close();
            } catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            } 
            return listCategory;
        }
        public CategoryDTO GetCategoryByID (int ID)
        {
           
            try
            {
                //---------------đoạn code copy-------------------
                string ConnectionString = "Data Source=localhost,1433;Initial Catalog=SWP_GroceryStoreDB;User ID=SWP;Password=SWPPassword";
                SqlConnection connection = new SqlConnection(ConnectionString);
                string SQLString = $"SELECT category_ID, name, info "
                            + $"FROM category WHERE category_ID={ID}";
                SqlCommand command = new SqlCommand(SQLString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                //------------------------------------------------
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
                else return null;
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
