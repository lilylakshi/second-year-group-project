using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Settings_AccountSettings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(0);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);
    }

    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
    protected void confirmButton_Click(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        statusLabel.Text = myLoginModule.manageChangePassword((String)Session["userID"],oldPsd.Text, newPsd.Text, reEntNewPsd.Text);
        //if (statusLabel.Text.Equals("Password changed")) {
         //   Response.Redirect("Homepage.aspx");
        //}
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        EmailModule myEmailModule = new EmailModule();
        myEmailModule.deleteAccountConfirmation((String)Session["userID"]);
        myLoginModule.deleteAccount((String)Session["userID"]);
        Response.Redirect("WhereIsMyJob.aspx");
    }
}