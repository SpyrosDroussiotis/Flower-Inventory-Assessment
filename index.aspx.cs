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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string cnntString = ConfigurationManager.ConnectionStrings["FlowerInventoryDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginbtn_click(object sender, EventArgs e)
        {
            string Username=UsernameTxt.Text.Trim();
            string Password=PasswordTxt.Text.Trim();
            using (SqlConnection conn = new SqlConnection(cnntString))
            {

                SqlCommand cmd = new SqlCommand("Authentication", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);

                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    ErrorMsg.Text = "Invalid Username or Password";
                }
            }
            
        }

        protected void UsernameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        protected void PasswordTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}