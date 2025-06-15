using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flower_Inventory_Assessment
{
    public partial class AddFlower : System.Web.UI.Page
    {
        string cnntString = "Data Source=DESKTOP-VESJCLA\\SQLEXPRESS;Initial Catalog=FlowerInventoryAssessment;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        string CatIdStr;
        string CategoryName;
        int CategoryID;

        protected void Page_Load(object sender, EventArgs e)
        {
            string CatIdStr = Request.QueryString["CategoryID"];
            int.TryParse(CatIdStr, out CategoryID);

        }


        protected void AddNewFlower(object sender, EventArgs e)
        {
           

            string FlowerName = AddFlowerNameTxt.Text.Trim();
            string Color = AddFlowerColor.Text.Trim();
            string PriceStr = AddFlowerPrice.Text.Trim();


            if (string.IsNullOrEmpty(FlowerName) || string.IsNullOrEmpty(Color) || !decimal.TryParse(PriceStr, out decimal Price))
            {
                // put label
                
                return;
            }

            using (SqlConnection conn = new SqlConnection(cnntString))
            {
                SqlCommand cmd = new SqlCommand("AddFlower", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.Parameters.AddWithValue("@Name", FlowerName);
                cmd.Parameters.AddWithValue("@Color", Color);
                cmd.Parameters.AddWithValue("@Price", Price);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect($"CategoryDetails.aspx?CategoryID={CategoryID}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        protected void Back(object sender, EventArgs e)
        {
           
            Response.Redirect($"CategoryDetails.aspx?CategoryID={CategoryID}");
        }
    }
}