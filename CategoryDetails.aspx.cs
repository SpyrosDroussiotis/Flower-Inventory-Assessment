using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flower_Inventory_Assessment
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string cnntString = "Data Source=DESKTOP-VESJCLA\\SQLEXPRESS;Initial Catalog=FlowerInventoryAssessment;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        string CatIdStr;
        string CategoryName;
        int CategoryId;

        protected void Page_Load(object sender, EventArgs e)
        {
            CatIdStr = Request.QueryString["CategoryID"];
            int.TryParse(CatIdStr, out CategoryId);
            

            if (!IsPostBack)
            {
                LoadFlowers(CategoryId);
                LoadCategoryTitle(CategoryId);
                
            }
        }

        private void LoadCategoryTitle(int CategoryId)
        {

            using (SqlConnection conn = new SqlConnection(cnntString))
            {

                SqlCommand cmd = new SqlCommand("GetCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CategoryID", CategoryId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    CategoryName = reader["NameOfCategory"].ToString();
                    string CategoryDescription = reader["Description"].ToString();
                    CatNameTitletxt.Text = CategoryName;

                    //EditCatNameTxt.Text = CategoryName;
                    ShowCatDescription.Text = CategoryDescription;
                }
                else
                {
                }

            }

        }
        private void LoadFlowers(int CategoryId)
        {
            using (SqlConnection conn = new SqlConnection(cnntString))
            {
                SqlCommand cmd = new SqlCommand("GetAllFlowersOfCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", CategoryId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                FlowerData.DataSource = dt;
                FlowerData.DataBind();
            }
        }

        protected void AddNewFlower(object sender, EventArgs e)
        {
            CatIdStr = Request.QueryString["CategoryID"];
            int.TryParse(CatIdStr, out int CategoryId);
            Response.Redirect($"AddFlower.aspx?CategoryID={CategoryId}");
        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
        protected void FlowerData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditFlower" || e.CommandName == "DeleteFlower")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = FlowerData.Rows[index];
                int FlowerID = Convert.ToInt32(FlowerData.DataKeys[index].Value);

                if (e.CommandName == "EditFlower")
                {
                    Response.Redirect($"EditFlower.aspx?FlowerID={FlowerID}&CategoryID={CategoryId}");
                }
                else if (e.CommandName == "DeleteFlower")
                {
                    Response.Redirect($"DeleteFlower.aspx?FlowerID={FlowerID}&CategoryID={CategoryId}");
                }



            }
        }

        protected void Filters_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = Filters.SelectedValue;

            if (selectedValue == "ASC")
            {
                NameAsc();
            }
            else if (selectedValue == "DESC")
            {
                NameDesc();
            }
            else if (selectedValue == "ASCPrice")
            {
                PriceAsc();
            }
            else if (selectedValue == "DESCPrice")
            {
                PriceDesc();
            }
            else
            {
                // Optionally reload default list or do nothing
                LoadFlowers(CategoryId);
                LoadCategoryTitle(CategoryId);

            }
        }

        protected void NameAsc()
        {
            using (SqlConnection conn = new SqlConnection(cnntString))
            {

                SqlCommand cmd = new SqlCommand("SortAscNameFlowers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                FlowerData.DataSource = dt;
                FlowerData.DataBind();
            }
        }
       

        protected void NameDesc()
        {
            using (SqlConnection conn = new SqlConnection(cnntString))
            {

                SqlCommand cmd = new SqlCommand("SortDescNameFlowers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                FlowerData.DataSource = dt;
                FlowerData.DataBind();
            }
        }
        protected void PriceAsc()
        {
            using (SqlConnection conn = new SqlConnection(cnntString))
            {

                SqlCommand cmd = new SqlCommand("SortAscPriceFlowers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                FlowerData.DataSource = dt;
                FlowerData.DataBind();
            }
        }

        protected void PriceDesc()
        {
            using (SqlConnection conn = new SqlConnection(cnntString))
            {

                SqlCommand cmd = new SqlCommand("SortDescPriceFlowers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                FlowerData.DataSource = dt;
                FlowerData.DataBind();
            }
        }

        protected void SearchByName(object sender, EventArgs e)
        {
            string SearchText=SearchTxt.Text.Trim();
            using (SqlConnection conn = new SqlConnection(cnntString))
            {

                SqlCommand cmd = new SqlCommand("SearchFlowerByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", SearchText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                FlowerData.DataSource = dt;
                FlowerData.DataBind();
            }
        }
        
    }
}