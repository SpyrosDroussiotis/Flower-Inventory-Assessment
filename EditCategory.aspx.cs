using Microsoft.Ajax.Utilities;
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
    public partial class EditCategory : System.Web.UI.Page
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
                    CatNameTitletxt.Text = "Edit " + CategoryName;

                    EditCatNameTxt.Text = CategoryName;
                    EditCatDescription.Text = CategoryDescription;
                }
                else
                {
                    Response.Redirect("HomePage.aspx");
                }

            }

        }

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void EditCategoryBtn(object sender, EventArgs e)
        {
            string CatIdStr = Request.QueryString["CategoryID"];
           int CategoryID = int.Parse(CatIdStr);
            using (SqlConnection conn = new SqlConnection(cnntString))
            {
                string CatName = EditCatNameTxt.Text.Trim();
                string CatDescription= EditCatDescription.Text.Trim();

                SqlCommand cmd = new SqlCommand("EditCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NameOfCategory", CatName);
                cmd.Parameters.AddWithValue("@Description",CatDescription);
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
                Response.Redirect("HomePage.aspx");

            }
        }
        }
    }
