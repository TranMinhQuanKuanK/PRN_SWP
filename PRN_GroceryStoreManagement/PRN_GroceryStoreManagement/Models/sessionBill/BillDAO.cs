using PRN_GroceryStoreManagement.Models.category;
using PRN_GroceryStoreManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.product
{
    public class BillDAO
    {

        private List<ProductDTO> listProduct = new List<ProductDTO>();
        public List<ProductDTO> GetProductList(int? category_id,String search_value, bool only_noos_items)
        {
            Debug.WriteLine($"category la: {category_id} va search value la {search_value} va only la {only_noos_items}");
            try
            {
                //---------------đoạn code copy-------------------
                string ConnectionString = ConnectionStringUtil.GetConnectionString();
                SqlConnection connection = new SqlConnection(ConnectionString);
                string SQLString = $"SELECT product_ID, name, quantity"
                        + ",cost_price,selling_price,lower_threshold,"
                        + " category_ID,unit_label,is_selling,location "
                        + " FROM product ";
                SqlCommand command = new SqlCommand(SQLString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                //------------------------------------------------
                ProductDTO pDTO = null;
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        bool isRightRecord = true;
                        if (category_id != null && !(reader.GetInt32("category_ID") == category_id))
                        {
                            isRightRecord = false;
                        }
                        if (search_value != null && !StringNormalizer.normalize(reader.GetString("name")).Contains(StringNormalizer.normalize(search_value)))
                        {
                            isRightRecord = false;
                        }
                        if (only_noos_items && reader.GetInt32("quantity") > reader.GetInt32("lower_threshold"))
                        {
                            isRightRecord = false;
                        }
                        if (isRightRecord)
                        {
                            int product_ID = reader.GetInt32("product_ID");
                            Debug.WriteLine(reader.GetInt32("product_ID"));
                            String name = reader.GetString("name");
                            Debug.WriteLine(reader.GetString("name"));
                            int quantity = reader.GetInt32("quantity");
                            int cost_price = reader.GetInt32("cost_price");
                            int selling_price = reader.GetInt32("selling_price");
                            int lower_threshold = reader.GetInt32("lower_threshold");
                            int category_ID = reader.GetInt32("category_ID");
                            String unit_label = reader.GetString("unit_label");
                            bool is_selling = reader.GetBoolean("is_selling");
                            String location = reader.GetString("location");

                            CategoryDAO cDAO = new CategoryDAO();
                            CategoryDTO cDTO = cDAO.GetCategoryByID(category_ID);

                            pDTO = new ProductDTO(product_ID, name, quantity,
                                   cost_price, selling_price, lower_threshold, cDTO,
                                   unit_label, is_selling, location);
                            listProduct.Add(pDTO);
                            
                        }
                    }
                }
                else return null;
                    connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return listProduct;
        }
        public List<ProductDTO> GetProductListForCashier(int? category_id, String search_value, bool only_noos_items)
        {
            Debug.WriteLine($"category la: {category_id} va search value la {search_value} va only la {only_noos_items}");
            try
            {
                //---------------đoạn code copy-------------------
                string ConnectionString = "Data Source=localhost,1433;Initial Catalog=SWP_GroceryStoreDB;User ID=SWP;Password=SWPPassword";
                SqlConnection connection = new SqlConnection(ConnectionString);
                string SQLString = $"SELECT product_ID, name, quantity"
                        + ",cost_price,selling_price,lower_threshold,"
                        + " category_ID,unit_label,is_selling,location "
                        + " FROM product ";
                SqlCommand command = new SqlCommand(SQLString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                //------------------------------------------------
                ProductDTO pDTO = null;
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        bool isRightRecord = true;
                        if (category_id != null && !(reader.GetInt32("category_ID") == category_id))
                        {
                            isRightRecord = false;
                        }
                        if (search_value != null && !StringNormalizer.normalize(reader.GetString("name")).Contains(StringNormalizer.normalize(search_value)))
                        {
                            isRightRecord = false;
                        }
                        if (only_noos_items && reader.GetInt32("quantity") > reader.GetInt32("lower_threshold"))
                        {
                            isRightRecord = false;
                        }
                        if (isRightRecord && reader.GetBoolean("is_selling"))
                        {
                            int product_ID = reader.GetInt32("product_ID");
                            String name = reader.GetString("name");
                            int quantity = reader.GetInt32("quantity");
                            int cost_price = reader.GetInt32("cost_price");
                            int selling_price = reader.GetInt32("selling_price");
                            int lower_threshold = reader.GetInt32("lower_threshold");
                            int category_ID = reader.GetInt32("category_ID");
                            String unit_label = reader.GetString("unit_label");
                            bool is_selling = reader.GetBoolean("is_selling");
                            String location = reader.GetString("location");

                            CategoryDAO cDAO = new CategoryDAO();
                            CategoryDTO cDTO = cDAO.GetCategoryByID(category_ID);

                            pDTO = new ProductDTO(product_ID, name, quantity,
                                   cost_price, selling_price, lower_threshold, cDTO,
                                   unit_label, is_selling, location);
                            listProduct.Add(pDTO);

                        }
                    }
                }
                else return null;
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return listProduct;
        }
    }
}
