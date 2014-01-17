using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class UpdateProductsAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //If in  Register.aspx   FormsAuthentication.RedirectFromLoginPage is execute correct
        //you can use Page.User.Identity.Name getting  Authencaited UserName
        if (Page.User.Identity.Name == "admin")
        {
            //DetailsView1.Visible = true;
        }
        else
        {
            Response.Redirect("Page404.aspx");
        }

    }
}