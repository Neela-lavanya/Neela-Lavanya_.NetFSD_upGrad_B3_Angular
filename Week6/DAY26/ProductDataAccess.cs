using ConsoleApp12;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ConsoleApp41
{
    public class ProductDataAccess
    {
        private readonly string connStr;

        public ProductDataAccess()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            connStr = config.GetConnectionString("DefaultConnection");
        }

        // INSERT
        public void Insert(Product p)
        {
            try
            {
                using SqlConnection conn = new SqlConnection(connStr);
                using SqlCommand cmd = new SqlCommand("sp_InsertProduct", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Price", p.Price);

                conn.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("Inserted Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // GET ALL
        public void GetAll()
        {
            try
            {
                using SqlConnection conn = new SqlConnection(connStr);
                using SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n--- Product List ---");

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductId"]} | {reader["ProductName"]} | {reader["Category"]} | {reader["Price"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // UPDATE
        public void Update(Product p)
        {
            try
            {
                using SqlConnection conn = new SqlConnection(connStr);
                using SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", p.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Price", p.Price);

                conn.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("Updated Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // DELETE
        public void Delete(int id)
        {
            try
            {
                using SqlConnection conn = new SqlConnection(connStr);
                using SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", id);

                conn.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("Deleted Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // GET BY ID ⭐
        public void GetById(int id)
        {
            try
            {
                using SqlConnection conn = new SqlConnection(connStr);
                using SqlCommand cmd = new SqlCommand("sp_GetProductById", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine("\n--- Product Details ---");
                    Console.WriteLine($"{reader["ProductId"]} | {reader["ProductName"]} | {reader["Category"]} | {reader["Price"]}");
                }
                else
                {
                    Console.WriteLine("Product Not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}