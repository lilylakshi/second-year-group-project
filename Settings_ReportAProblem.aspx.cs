using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Settings_ReportAProblem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(0);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);
    }
    protected void SendEmailButton_Click(object sender, EventArgs e)
    {
         try
        {
            EmailModule myEmailModule = new EmailModule();
            myEmailModule.sendEmailToReportAProblem((String)Session["userID"], problem.Text, description.Text);
            Response.Redirect("HomePage.aspx");
        }
        catch (NullReferenceException en) { }

        
    }

    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
}