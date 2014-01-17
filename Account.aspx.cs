using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class Account : System.Web.UI.Page
{
    public string UFlag = "F"; public string strUserName;
    static readonly string ScriptSuccessUpdate = "<script language=\"javscript\"\n" + "alert (\"Update successful - Please surf to other pages to shop\");\n </script>";

    protected void Page_Load(object sender, EventArgs e)
    {
        LabelUserName.Text = (string)Session["sUserName"];
        LabelFirstName.Text = (string)Session["sFirstName"];
        LabelLastName.Text = (string)Session["sLastName"];
        LabelAddressLine1.Text = (string)Session["sAddressLine1"];
        LabelAddressLine2.Text = (string)Session["sAddressLine2"];
        LabelCountry.Text = (string)Session["sCountry"];
        LabelState.Text = (string)Session["sState"];
        LabelPostalCode.Text = (string)Session["sPostalCode"];
        LabelContactNumber.Text = Convert.ToInt32(Session["sContactNumber"]).ToString();
        LabelEmail.Text = (string)Session["sEmail"];
        LabelPassword.Text = (string)Session["sPassword"];

    }
    protected void ImageButtonUpdate_Click(object sender, ImageClickEventArgs e)
    {
        strUserName = (string)Session["sUserName"];
        if (TextBoxFirstName.Text != "")
        {
            string StrFName = "CFirstName"; string strFValue = TextBoxFirstName.Text;
            UpdatemyCustomer(StrFName, strFValue);
            Session["sFirstName"] = TextBoxFirstName.Text;
        }
        if (TextBoxLastName.Text != "")
        {
            string strFName = "CLastName"; string strFValue = TextBoxLastName.Text;
            UpdatemyCustomer(strFName, strFValue);
            Session["sLastName"] = TextBoxLastName.Text;
        }
        if (TextBoxAddressLine1.Text != "")
        {
            string strFName = "CAddressLine1"; string strFValue = TextBoxAddressLine1.Text;
            UpdatemyCustomer(strFName, strFValue);
            Session["sAddressLine1"] = TextBoxAddressLine1.Text;
        }
        if (TextBoxAddressLine2.Text != "")
        {
            string strFName = "CAddressLine2"; string strFValue = TextBoxAddressLine2.Text;
            UpdatemyCustomer(strFName, strFValue);
            Session["sAddressLine2"] = TextBoxAddressLine2.Text;
        }
        if (TextBoxCountry.Text != "")
        {
            string strFName = "CCountry"; string strFValue = TextBoxCountry.Text;
            UpdatemyCustomer(strFName, strFValue);
            Session["sCountry"] = TextBoxCountry.Text;
        }
        if (TextBoxState.Text != "")
        {
            string strFName = "CState"; string strFValue = TextBoxState.Text;
            UpdatemyCustomer(strFName, strFValue);
            Session["sState"] = TextBoxState.Text;
        }
        if (TextBoxPostalCode.Text != "")
        {
            string strFName = "CPostalCode"; string strFValue = TextBoxPostalCode.Text;
            UpdatemyCustomer(strFName, strFValue);
            Session["sPostalCode"] = TextBoxPostalCode.Text;
        }
        if (TextBoxContactNumber.Text != "")
        {
            string strFName = "CContactNumber"; string strFValue = TextBoxContactNumber.Text;
            UpdatemyCustomer(strFName, strFValue);
            Session["sContactNumber"] = TextBoxContactNumber.Text;
        }
        if (TextBoxEmail.Text != "")
        {
            string strFName = "CEmail"; string strFValue = TextBoxEmail.Text;
            UpdatemyCustomer(strFName, strFValue);
            Session["sEmail"] = TextBoxEmail.Text;
        }
        if (TextBoxPassword.Text != "")
        {
            string strFName = "CPassword"; string strFValue = TextBoxPassword.Text;
            UpdatemyCustomer(strFName, strFValue);
            Session["sPassword"] = TextBoxPassword.Text;
        }
        if (UFlag == "T")
        {
            Type strType = this.GetType();
            ClientScript.RegisterStartupScript(strType, "Success", ScriptSuccessUpdate);
        }
    }
    public void UpdatemyCustomer(string strFName, string strFValue)
    {
        OleDbConnection mDB = new OleDbConnection();
        mDB.ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data source=" + Server.MapPath("~/App_Data/webBase.accdb");
        mDB.Open();
        OleDbCommand cmd;
        String strSQL = "UPDATE myCustomer SET " + strFName + "=@newValue WHERE cUserName = @eUserName";
        cmd = new OleDbCommand(strSQL, mDB);
        cmd.Parameters.Add("@newValue", OleDbType.Char).Value = strFValue;
        cmd.Parameters.Add("@eUserName", OleDbType.Char).Value = strUserName;
        cmd.ExecuteNonQuery();
        UFlag = "T";
        mDB.Close();
    }
}