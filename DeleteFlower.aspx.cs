using Flower_Inventory_Assessment.Services;
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
    public partial class DeleteFlower : System.Web.UI.Page
    {
        int FlowerID, CategoryID;
        string cnntString = ConfigurationManager.ConnectionStrings["FlowerInventoryDB"].ConnectionString;
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
            var service = new FlowerService(cnntString);
            var flower = service.GetFlower(FlowerID);

            if (flower != null)
            {
                FlowerNameTitletxt.Text = flower.Name;
                DeleteFlowerNameTxt.Text = flower.Name;
                PriceText.Text = flower.price;
                ColorTxt.Text = flower.Color;
            }
        }

        
        protected void DeleteCategoryBtn(object sender, EventArgs e)
        {
           var service= new FlowerService(cnntString);
            service.DeleteFlower(FlowerID);
           Response.Redirect($"CategoryDetails.aspx?CategoryID={CategoryID}");

           
        }
        protected void Back(object sender, EventArgs e)
        {
            string CatIdStr = Request.QueryString["CategoryID"];
            int.TryParse(CatIdStr, out int CategoryID);
            Response.Redirect($"CategoryDetails.aspx?CategoryID={CategoryID}");
        }
    }
}