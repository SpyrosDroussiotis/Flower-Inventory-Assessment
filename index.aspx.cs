using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flower_Inventory_Assessment
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginbtn_click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void UsernameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        protected void PasswordTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}