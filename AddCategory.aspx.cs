using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flower_Inventory_Assessment
{
    public partial class WebForm2 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void AddNewCategory(object sender, EventArgs e)
        {
            string CatName, CatDescription;
            CatName = AddCatNameTxt.Text.Trim();
            CatDescription = AddCatDescription.Text.Trim();

            if (!string.IsNullOrEmpty(CatName) && !string.IsNullOrEmpty(CatDescription))
            {

                string cnntString = ConfigurationManager.ConnectionStrings["FlowerInventoryDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(cnntString))
            {
                SqlCommand cmd = new SqlCommand("AddCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NameOfCategory", CatName);
                cmd.Parameters.AddWithValue("@Description", CatDescription);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex){
                    Console.WriteLine(ex.Message);
                }
                
                    Response.Redirect("HomePage.aspx");
                }
            }
            else
            {
                ErrorMsg.Text = "Please fill all the Boxes";
                return;
            }

        }

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}