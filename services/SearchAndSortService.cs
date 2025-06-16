using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Flower_Inventory_Assessment.services
{
    public class SearchAndSortService
    {
        private readonly string _connectionString;

        public SearchAndSortService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable CatAsc()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("SortAscCategories", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            return null;
        }
        public DataTable CatDesc()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("SortDescCategories", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            return null;
        }
        public DataTable SearchCat(string CatName)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("SearchCategoryByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", CatName);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            return null;
        }
        public DataTable FlowerNameAsc(int CategoryID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("SortAscNameFlowers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            return null;
        }
        public DataTable FlowerNameDesc(int CategoryID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("SortDescNameFlowers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            return null;
        }
        public DataTable FlowerPriceAsc(int CategoryID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("SortAscPriceFlowers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            return null;
        }
        public DataTable FlowerPriceDesc(int CategoryID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("SortDescPriceFlowers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            return null;
        }
        public DataTable FlowerNameSearch(string FlowerNameSearch)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("SearchFlowerByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", FlowerNameSearch);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            return null;

        }
    }

}