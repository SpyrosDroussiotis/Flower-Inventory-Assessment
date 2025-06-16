using System;
using System.Data;
using System.Data.SqlClient;
using static Flower_Inventory_Assessment.Services.FlowerService;

namespace Flower_Inventory_Assessment.Services
{
    public class FlowerService
    {
        private readonly string _connectionString;

        public FlowerService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public class Flower
        {
            public int CategoryID { get; set; }
            public int FlowerID { get; set; }
            public string Name { get; set; }
            public string Color { get; set; }
            public string price { get; set; }
            public decimal Price { get; set; }
        }
        public void AddFlower(int CategoryID, string name, string color, decimal price)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddFlower", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Color", color);
                cmd.Parameters.AddWithValue("@Price", price);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void DeleteFlower(int FlowerID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteFlower", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FlowerID", FlowerID);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public DataTable GetAllFlowers(int CategoryID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllFlowersOfCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void EditFlower(int flowerId, int categoryId, string name, string color, decimal price)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("EditFlower", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FlowerID", flowerId);
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Color", color);
                cmd.Parameters.AddWithValue("@Price", price);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public Flower GetFlower(int FlowerID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetFlower", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FlowerID", FlowerID);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Flower {
                            Name = reader["Name"].ToString(),
                            price = reader["Price"].ToString(),
                        Color = reader["Color"].ToString(),
                        };
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return null;

            }
        }

    }
}
