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
    public class ProductDAO
    {

        private List<ProductDTO> listProduct = new List<ProductDTO>();
        public List<ProductDTO> GetProductList(int? category_id, String search_value, bool only_noos_items)
        {

            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = $"SELECT product_ID, name, quantity"
                    + ",cost_price,selling_price,lower_threshold,"
                    + " category_ID,unit_label,is_selling,location "
                    + " FROM product ";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

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
            finally
            {
                if (connection != null) connection.Dispose();
            }
            return listProduct;
        }
        public List<ProductDTO> GetProductListForCashier(int? category_id, String search_value, bool only_noos_items)
        {
            Debug.WriteLine($"category la: {category_id} va search value la {search_value} va only la {only_noos_items}");
            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = $"SELECT product_ID, name, quantity"
                    + ",cost_price,selling_price,lower_threshold,"
                    + " category_ID,unit_label,is_selling,location "
                    + " FROM product ";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

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
            finally
            {
                if (connection != null) connection.Dispose();
            }
            return listProduct;
        }
        public ProductDTO GetProductByID(int? id)
        {
            ProductDTO pDTO = null;

            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = $"SELECT product_ID, name, quantity"
                    + ",cost_price,selling_price,lower_threshold,"
                    + " category_ID,unit_label,is_selling,location "
                    + $" FROM product WHERE product_ID = {id}";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);


                if (reader.HasRows == true)
                {
                    while (reader.Read())
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
                    }
                }
                else return null;
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
            return pDTO;
        }
        public bool AddQuantityToProduct(int ProductID, int quantity)
        {
            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT quantity, lower_threshold "
                        + " FROM product WHERE product_ID = @product_ID";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            int? currentQuantity = 0;
            int? lower_threshold = 0;
            try
            {
                connection.Open();

                command.Parameters.Add("@product_ID", SqlDbType.Int).Value = ProductID;

                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    if (reader.Read())
                    {
                        currentQuantity = reader.GetInt32("quantity");
                        lower_threshold = reader.GetInt32("lower_threshold");
                    }
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null) connection.Dispose();
            }
            //-------------------------------------------------
            SQLString = "UPDATE product "
                        + "SET quantity = @quantity"
                        + " WHERE product_ID = @product_ID ";
            command = new SqlCommand(SQLString, connection);
            //------------------------------------------------

            try
            {
                connection.Open();

                command.Parameters.Add("@quantity", SqlDbType.Int).Value = currentQuantity + quantity;
                command.Parameters.Add("@product_ID", SqlDbType.Int).Value = ProductID;

                int rowAffected = command.ExecuteNonQuery();
                connection.Close();
                if (currentQuantity + quantity <= lower_threshold)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null) connection.Dispose();
            }
            return false;
        }
        // kiểm tra hàng hóa đã có tên tương tự trong hệ thống chưa
        // nếu trùng ID thì coi như false
        public bool ConfirmMatchedProduct(string productName, int productID)
        {
            //---------------đoạn code copy-------------------
            string ConnectionString = "Data Source=localhost,1433;Initial Catalog=SWP_GroceryStoreDB;User ID=SWP;Password=SWPPassword";
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "SELECT product_ID, name "
                        + " FROM product";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                productName = StringNormalizer.normalize(productName);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        bool check = StringNormalizer.normalize(reader.GetString("name")).Equals(productName);
                        if (check)
                        {
                            if (productID == 0) return check;
                            else
                            {
                                return reader.GetInt32("product_ID") != productID;
                            }
                        }
                    }
                    return false;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
            return false;
        }
        public bool AddNewProduct(string productName, int categoryID, int threshold, int costPrice, int sellingPrice, string unitLabel, string location, bool isSelling)
        {

            //---------------đoạn code copy-------------------
            string ConnectionString = "Data Source=localhost,1433;Initial Catalog=SWP_GroceryStoreDB;User ID=SWP;Password=SWPPassword";
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "INSERT INTO product(name, quantity, cost_price, selling_price, lower_threshold, category_ID, unit_label, location, is_selling) "
                            + "VALUES(@name, 0, @cost_price, @selling_price, @lower_threshold, @categoryID, @unit_label, @location, @is_selling)";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            try
            {
                connection.Open();

                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = productName;
                command.Parameters.Add("@cost_price", SqlDbType.Int).Value = costPrice;
                command.Parameters.Add("@selling_price", SqlDbType.Int).Value = sellingPrice;
                command.Parameters.Add("@lower_threshold", SqlDbType.Int).Value = threshold;
                command.Parameters.Add("@categoryID", SqlDbType.Int).Value = categoryID;
                command.Parameters.Add("@unit_label", SqlDbType.NVarChar).Value = unitLabel;
                command.Parameters.Add("@location", SqlDbType.NVarChar).Value = location;
                command.Parameters.Add("@is_selling", SqlDbType.Bit).Value = isSelling;

                int rowAffected = command.ExecuteNonQuery();
                connection.Close();
                return rowAffected > 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
            return false;
        }
        public bool changeQuantity(int productID, int quantity)
        {
            //---------------đoạn code copy-------------------
            string ConnectionString = ConnectionStringUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "UPDATE product "
                        + "SET quantity = @new_quantity "
                        + "WHERE product_ID = @proID";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            try
            {
                connection.Open();

                command.Parameters.Add("@proID", SqlDbType.Int).Value = productID;
                command.Parameters.Add("@new_quantity", SqlDbType.Int).Value = quantity;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    return true;
                }

                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null) connection.Dispose();
            }
            return false;
        }
        public bool UpdateProductInfo(int ProductID, string productName, int categoryID, int threshold, int costPrice, int sellingPrice, String unitLabel, String location, bool isSelling)
        {
            //---------------đoạn code copy-------------------
            string ConnectionString = "Data Source=localhost,1433;Initial Catalog=SWP_GroceryStoreDB;User ID=SWP;Password=SWPPassword";
            SqlConnection connection = new SqlConnection(ConnectionString);
            string SQLString = "UPDATE product "
                        + "SET name = @name,"
                        + "cost_price = @cost_price,"
                        + "selling_price = @selling_price,"
                        + "lower_threshold = @lower_threshold,"
                        + "category_ID = @category_ID,"
                        + "unit_label = @unit_label,"
                        + "location = @location,"
                        + "is_selling = @is_selling"
                        + " WHERE product_ID = @product_ID";
            SqlCommand command = new SqlCommand(SQLString, connection);
            //------------------------------------------------
            try
            {
                connection.Open();
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = productName;
                command.Parameters.Add("@cost_price", SqlDbType.Int).Value = costPrice;
                command.Parameters.Add("@selling_price", SqlDbType.Int).Value = sellingPrice;
                command.Parameters.Add("@lower_threshold", SqlDbType.Int).Value = threshold;
                command.Parameters.Add("@category_ID", SqlDbType.Int).Value = categoryID;
                command.Parameters.Add("@unit_label", SqlDbType.NVarChar).Value = unitLabel;
                command.Parameters.Add("@location", SqlDbType.NVarChar).Value = location;
                command.Parameters.Add("@is_selling", SqlDbType.Bit).Value = isSelling;
                command.Parameters.Add("@product_ID", SqlDbType.Int).Value = ProductID;

                int rowAffected = command.ExecuteNonQuery();
                connection.Close();
                return rowAffected > 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
            return false;
        }
    }
}
