using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Web.Security;

public partial class Register : System.Web.UI.Page
{
    static readonly string scriptErrorUserId =
        "<script language=\"javascript\">\n" +
        "alert (\"Error - UserID you entered is taken up, please key in another UserID\");\n" +
    "</script>";

    static readonly string scriptSuccessNewAccount =
    "<script language=\"javascript\">\n" +
        "alert (\"Your account has been successfully created - Thank you!\");\n" +
    "</script>";

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        OleDbConnection mDB = new OleDbConnection();
        mDB.ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/App_Data/webBase.accdb");
        mDB.Open();
        Type csType = this.GetType();
        OleDbCommand cmd;
        OleDbDataReader rdr;
        string strSQLSelect = "SELECT CUsername FROM myCustomer ORDER BY CUsername";
        cmd = new OleDbCommand(strSQLSelect, mDB);
        rdr = cmd.ExecuteReader();

        while (rdr.Read() == true)
        {
            if (TextBoxUserName.Text == (string)rdr["cUsername"])
            {
                ClientScript.RegisterStartupScript(csType, "Error", scriptErrorUserId);
                mDB.Close();
                return;
            }
        }

        // Insert new records keyed by the user
        string strSQLInsert = "INSERT INTO "
            + "myCustomer (CFirstName, CLastName, CAddressLine1, CAddressLine2, CCountry, CState, CPostalCode, CContactNumber, CEmail, CConfirmEmail, CUserName, CPassword, CConfirmPassword)"
            + "VALUES (@eFirstName, @eLastName, @eAddressLine1, @eAddressLine2, @eCountry, @eState, @ePostalCode, @eContactNumber, @eEmail, @eConfirmEmail, @eUserName, @ePassword, @eConfirmPassword)";

        cmd = new OleDbCommand(strSQLInsert, mDB);
        cmd.Parameters.AddWithValue("@eFirstName", TextBoxFirstName.Text);
        cmd.Parameters.AddWithValue("@eLastName", TextBoxLastName.Text);
        cmd.Parameters.AddWithValue("@eAddressLine1", TextBoxAddressLine1.Text);
        cmd.Parameters.AddWithValue("@eAddressLine2", TextBoxAddressLine2.Text);
        cmd.Parameters.AddWithValue("@eCountry", TextBoxCountry.Text);
        cmd.Parameters.AddWithValue("@eState", TextBoxState.Text);
        cmd.Parameters.AddWithValue("@ePostalCode", TextBoxPostalCode.Text);
        cmd.Parameters.AddWithValue("@eContactNumber", TextBoxContactNumber.Text);
        cmd.Parameters.AddWithValue("@eEmail", TextBoxEmail.Text);
        cmd.Parameters.AddWithValue("@eConfirmEmail", TextBoxConfirmEmail.Text);
        cmd.Parameters.AddWithValue("@eUserName", TextBoxUserName.Text);
        cmd.Parameters.AddWithValue("@ePassword", TextBoxPassword.Text);
        cmd.Parameters.AddWithValue("@eConfirmPassword", TextBoxConfirmPassword.Text);

        cmd.ExecuteNonQuery();
        mDB.Close();
        ClientScript.RegisterStartupScript(csType, "Success", scriptSuccessNewAccount);

        //Re putting by KingJK , ensure prepare Session before Redirect
        // prepare Session Variables for newly registered customer
        Session["sFlag"] = "T";
        Session["sFirstName"] = (string)TextBoxFirstName.Text;
        Session["sLastName"] = (string)TextBoxLastName.Text;
        Session["sAddressLine1"] = (string)TextBoxAddressLine1.Text;
        Session["sAddressLine2"] = (string)TextBoxAddressLine2.Text;
        Session["sCountry"] = (string)TextBoxCountry.Text;
        Session["sState"] = (string)TextBoxState.Text;
        Session["sPostalCode"] = (string)TextBoxPostalCode.Text;
        Session["sContactNumber"] = (string)TextBoxContactNumber.Text;
        Session["sEmail"] = (string)TextBoxEmail.Text;
        Session["sConfirmEmail"] = (string)TextBoxConfirmEmail.Text;
        Session["sUserName"] = (string)TextBoxUserName.Text;
        Session["sePassword"] = (string)TextBoxPassword.Text;
        Session["sConfirmPassword"] = (string)TextBoxConfirmPassword.Text;

        //IF you want to Use Page.User.Identity.Name , You need Register User be a  Authencaite 
        //And you can use Page.User.Identity.Name .
        //Btw if you use  FormsAuthentication.RedirectFromLoginPage. it will  Redirect your website Default Page  Like  Home.aspx or Default.aspx 
        FormsAuthentication.RedirectFromLoginPage(Session["sUserName"].ToString(), false);

        //Will not be Exec
        Response.Redirect("Account.aspx");

      
    }
}