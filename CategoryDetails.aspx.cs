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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CatIdStr = Request.QueryString["CategoryID"];
                if (int.TryParse(CatIdStr, out int CategoryId))
                {
                    LoadCategoryTitle(CategoryId);
                    LoadFlowers(CategoryId);

                }
                else
                {
                    Response.Redirect("HomePage.aspx");
                }
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

                    string CategoryName = reader["NameOfCategory"].ToString();
                    string CategoryDescription = reader["Description"].ToString();
                    CatNameTitletxt.Text = CategoryName;

                    //EditCatNameTxt.Text = CategoryName;
                    ShowCatDescription.Text = CategoryDescription;
                }
                else
                {
                    Response.Redirect("HomePage.aspx");
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
            Response.Redirect("HomePage.aspx");
        }
    }
}