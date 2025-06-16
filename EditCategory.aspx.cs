using Flower_Inventory_Assessment.services;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Flower_Inventory_Assessment.services.CategoryService;

namespace Flower_Inventory_Assessment
{
    public partial class EditCategory : System.Web.UI.Page
    {
        string cnntString = "Data Source=DESKTOP-VESJCLA\\SQLEXPRESS;Initial Catalog=FlowerInventoryAssessment;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
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

        private void LoadCategoryTitle(int CategoryID)
        {


            var service = new CategoryService(cnntString);
            var category = service.GetCategory(CategoryID);

            if (category != null)
            {
                CatNameTitletxt.Text = "Edit " + category.NameOfCategory;

                EditCatNameTxt.Text = category.NameOfCategory;
                EditCatDescription.Text = category.Description;
            }
            else
            {
                Response.Redirect("HomePage.aspx");
            }

        }

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void EditCategoryBtn(object sender, EventArgs e)
        {
                string CatName = EditCatNameTxt.Text.Trim();
                string CatDescription= EditCatDescription.Text.Trim();
                if (!string.IsNullOrEmpty(CatName) && !string.IsNullOrEmpty(CatDescription))
                {
                var service = new CategoryService(cnntString);
                service.EditCategory(CategoryID, CatName, CatDescription);
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    ErrorMsg.Text = "Please fill all the Boxes";
                    return;
                }

            
        }
     }
}
    
