using Flower_Inventory_Assessment.services;
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
    public partial class HomePage : System.Web.UI.Page
    {
        string cnntString = ConfigurationManager.ConnectionStrings["FlowerInventoryDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            var service = new CategoryService(cnntString);
            DataTable dt = service.GetAllCategories();
            CategoriesData.DataSource = dt;
            CategoriesData.DataBind();

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
                else if (e.CommandName == "DeleteCategory")
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
            var service = new SearchAndSortService(cnntString);
            DataTable dt = service.CatAsc();
            CategoriesData.DataSource = dt;
            CategoriesData.DataBind();

        }

        protected void SortDesc()
        {
            var service = new SearchAndSortService(cnntString);
            DataTable dt = service.CatDesc();
            CategoriesData.DataSource = dt;
            CategoriesData.DataBind();

        }

        protected void SearchByName(object sender, EventArgs e)
        {
            string SearchText = SearchTxt.Text.Trim();
            var service = new SearchAndSortService(cnntString);
            DataTable dt = service.SearchCat(SearchText);
            CategoriesData.DataSource = dt;
            CategoriesData.DataBind();
        }
    

        protected void AddNewCategory(object sender, EventArgs e)
        {
            Response.Redirect("AddCategory.aspx");
        }
    }
}