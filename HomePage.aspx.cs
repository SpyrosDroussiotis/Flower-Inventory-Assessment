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
    public partial class HomePage : System.Web.UI.Page
    {
        string cnntString = "Data Source=DESKTOP-VESJCLA\\SQLEXPRESS;Initial Catalog=FlowerInventoryAssessment;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            
            using (SqlConnection conn = new SqlConnection(cnntString))
            {

                SqlCommand cmd = new SqlCommand("GetAllCategories", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da= new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                CategoriesData.DataSource = dt;
                CategoriesData.DataBind();
            }
        }

        protected void CategoriesData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string CategoryId = DataBinder.Eval(e.Row.DataItem, "CategoryID").ToString();
                int CategoryID;
                if (int.TryParse(CategoryId, out CategoryID))
                {
                    e.Row.Attributes["onclick"] = $"window.location='CategoryDetails.aspx?CategoryID={CategoryID}';";
                    e.Row.Attributes["style"] = "cursor:pointer";
                    //Response.Redirect($"CategoryDetails.aspx?CategoryID={CategoryID}");
                }
                else
                {
                    Response.Redirect("HomePage.aspx");
                }

                
            }
        }
        protected void CategoriesData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditCategory" || e.CommandName == "DeleteCategory")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = CategoriesData.Rows[index];
                int categoryId = Convert.ToInt32(CategoriesData.DataKeys[index].Value);

                if (e.CommandName == "EditCategory")
                {
                      Response.Redirect($"EditCategory.aspx?CategoryID={categoryId}");
                 }
                else if(e.CommandName == "DeleteCategory")
                {
                    Response.Redirect($"DeleteCategory.aspx?CategoryID={categoryId}");
                }


                
            }
        }
        protected void Filters_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = Filters.SelectedValue;

            if (selectedValue == "ASC")
            {
                SortAsc();
            }
            else if (selectedValue == "DESC")
            {
                SortDesc();
            }
            else
            {
                // Optionally reload default list or do nothing
                LoadCategories();
            }
        }

        protected void SortAsc()
        {
            using (SqlConnection conn = new SqlConnection(cnntString))
            {

                SqlCommand cmd = new SqlCommand("SortAscCategories", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                CategoriesData.DataSource = dt;
                CategoriesData.DataBind();
            }
        }

        protected void SortDesc()
        {
            using (SqlConnection conn = new SqlConnection(cnntString))
            {

                SqlCommand cmd = new SqlCommand("SortDescCategories", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                CategoriesData.DataSource = dt;
                CategoriesData.DataBind();
            }
        }

        protected void SearchByName(object sender, EventArgs e)
        {
            string SearchText = SearchTxt.Text.Trim();
            using (SqlConnection conn = new SqlConnection(cnntString))
            {

                SqlCommand cmd = new SqlCommand("SearchCategoryByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", SearchText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                CategoriesData.DataSource = dt;
                CategoriesData.DataBind();
            }
        }

        protected void AddNewCategory(object sender, EventArgs e)
        {
            Response.Redirect("AddCategory.aspx");
        }
    }
}