using Flower_Inventory_Assessment.services;
using Flower_Inventory_Assessment.Services;
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

                    ShowCatDescription.Text = CategoryDescription;
                }
                else
                {
                }

            }

        }
        private void LoadFlowers(int CategoryId)
        {
            var service = new FlowerService(cnntString);
            DataTable dt= service.GetAllFlowers(CategoryId);
                FlowerData.DataSource = dt;
                FlowerData.DataBind();
            
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
            var service = new SearchAndSortService(cnntString);
            DataTable dt = service.FlowerNameAsc(CategoryId);
                FlowerData.DataSource = dt;
                FlowerData.DataBind();
            
        }
       

        protected void NameDesc()
        {
            var service = new SearchAndSortService(cnntString);
            DataTable dt = service.FlowerNameDesc(CategoryId);
            FlowerData.DataSource = dt;
                FlowerData.DataBind();
            
        }

        protected void PriceAsc()
        {
            var service = new SearchAndSortService(cnntString);
            DataTable dt = service.FlowerPriceAsc(CategoryId);
            FlowerData.DataSource = dt;
                FlowerData.DataBind();
            
        }

        protected void PriceDesc()
        {
            var service = new SearchAndSortService(cnntString);
            DataTable dt = service.FlowerPriceDesc(CategoryId);
            FlowerData.DataSource = dt;
                FlowerData.DataBind();
            
        }

        protected void SearchByName(object sender, EventArgs e)
        {
            string SearchText=SearchTxt.Text.Trim();
            var service = new SearchAndSortService(cnntString);
            DataTable dt = service.FlowerNameSearch(SearchText);
            FlowerData.DataSource = dt;
                FlowerData.DataBind();
            
        }
        
    }
}