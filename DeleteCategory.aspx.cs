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
    public partial class DeleteCategory : System.Web.UI.Page
    {
        string cnntString = ConfigurationManager.ConnectionStrings["FlowerInventoryDB"].ConnectionString;
        int CategoryID;
        protected void Page_Load(object sender, EventArgs e)
        {
            string CatIdStr = Request.QueryString["CategoryID"];
            int.TryParse(CatIdStr, out CategoryID);
            if (!IsPostBack)
            {
                if (int.TryParse(CatIdStr, out CategoryID))
                {
                    LoadCategoryTitle(CategoryID);

                }
                else
                {
                    Response.Redirect("HomePage.aspx");
                }
            }
        }
        private void LoadCategoryTitle(int CategoryId)
        {
            var service=new CategoryService(cnntString);
            var category=service.GetCategory(CategoryID);
           
                if (category != null) 
                {
                    CatNameTitletxt.Text = "Delete " +category.NameOfCategory ;

                    DelCatNameTxt.Text = category.NameOfCategory;
                    DelCatDescription.Text = category.Description;
                }
                else
                {
                    Response.Redirect("HomePage.aspx");
                }

        }

        protected void DelCategoryBtn(object sender, EventArgs e)
        {
            var service = new CategoryService(cnntString);
            service.DeleteCategory(CategoryID);
            Response.Redirect("HomePage.aspx");

        }
    

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}