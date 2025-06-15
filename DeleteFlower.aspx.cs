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
    public partial class DeleteFlower : System.Web.UI.Page
    {
        int FlowerID, CategoryID;
        string cnntString = "Data Source=DESKTOP-VESJCLA\\SQLEXPRESS;Initial Catalog=FlowerInventoryAssessment;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            string FlowerIdStr = Request.QueryString["FlowerID"];
            int.TryParse(FlowerIdStr, out FlowerID);

            string CatIdStr = Request.QueryString["CategoryID"];
            int.TryParse(CatIdStr, out CategoryID);
            if (!IsPostBack)
            {
                LoadFlowerDetails(FlowerID);
            }
        }
        private void LoadFlowerDetails(int FlowerID)
        {

            using (SqlConnection conn = new SqlConnection(cnntString))
            {

                SqlCommand cmd = new SqlCommand("GetFlower", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FlowerID", FlowerID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    string FlowerName = reader["Name"].ToString();
                    string Price = reader["Price"].ToString();
                    string Color = reader["Color"].ToString();
                    FlowerNameTitletxt.Text = FlowerName;

                    DeleteFlowerNameTxt.Text = FlowerName;
                    ColorTxt.Text = Color;
                    PriceText.Text = Price;
                }


            }

        }
        protected void DeleteCategoryBtn(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(cnntString))
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
                Response.Redirect($"CategoryDetails.aspx?CategoryID={CategoryID}");

            }
        }
        protected void Back(object sender, EventArgs e)
        {
            string CatIdStr = Request.QueryString["CategoryID"];
            int.TryParse(CatIdStr, out int CategoryID);
            Response.Redirect($"CategoryDetails.aspx?CategoryID={CategoryID}");
        }
    }
}