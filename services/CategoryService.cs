using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Flower_Inventory_Assessment.services
{
    public class CategoryService
    {
        private readonly string _connectionString;

        public CategoryService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public class Category
        {
            public int CategoryID { get; set; }
            public string NameOfCategory { get; set; }
            public string Description { get; set; }
        }
        public void AddCategory(string NameOfCategory, string Descrption)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NameOfCategory", NameOfCategory);
                cmd.Parameters.AddWithValue("@Description", Descrption);

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

        public void EditCategory(int CategoryID, string NameOfCategory, string Description)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("EditCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NameOfCategory", NameOfCategory);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);

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
        public void DeleteCategory(int CategoryID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
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
        public Category GetCategory(int CategoryID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("GetCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        return new Category
                        {
                            CategoryID = CategoryID,
                            NameOfCategory = reader["NameOfCategory"].ToString(),
                            Description = reader["Description"].ToString()
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
        public DataTable GetAllCategories()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("GetAllCategories", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
         }
    }
}