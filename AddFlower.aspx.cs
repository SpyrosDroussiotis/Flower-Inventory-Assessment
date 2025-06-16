using Flower_Inventory_Assessment.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        string cnntString = ConfigurationManager.ConnectionStrings["FlowerInventoryDB"].ConnectionString;
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
                ErrorMsg.Text = "Please fill all the Boxes";
                return;
            }

            var service = new FlowerService(cnntString);
            service.AddFlower(CategoryID, FlowerName, Color, Price);
            Response.Redirect($"CategoryDetails.aspx?CategoryID={CategoryID}");
        }


        
        protected void Back(object sender, EventArgs e)
        {
           
            Response.Redirect($"CategoryDetails.aspx?CategoryID={CategoryID}");
        }
    }
}