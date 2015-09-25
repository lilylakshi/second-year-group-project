using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddRemark : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(0);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);
    }
    protected void ApplyButton_Click(object sender, EventArgs e)
    {
        JobsModule myJobsModule = new JobsModule();
        myJobsModule.enterApplicantForJobPosition((String)Session["userID"], Request["pId"]);
        myJobsModule.addRemark(Request["pId"], (String)Session["userID"], RemarkTextBox.Text);
        Response.Redirect("~/ApplicantsJobs.aspx");
    }

    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
}