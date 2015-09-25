using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ApplicantsJobs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(0);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);

        /*
        JobsModule myJobsModule = new JobsModule();
        myJobsModule.setUserId((String)Session["userId"]);
        JobsGridView.DataSource = myJobsModule.viewMentionedJobs();
        JobsGridView.DataBind();
         */

        this.setTable();
        this.setTable2();
    }

    protected void setTable()
    {
        DataTable myDataTable = new DataTable();
        JobsModule myJobsModule = new JobsModule();
        myJobsModule.setUserId((String)Session["userId"]);

        myDataTable = myJobsModule.viewMentionedJobs().Copy();
        myDataTable.Columns.Add("Delete", typeof(String)).SetOrdinal(0);

        JobsGridView.DataSource = myDataTable;
        JobsGridView.DataBind();

        foreach (GridViewRow row in JobsGridView.Rows)
        {
            LinkButton lb = new LinkButton();
            lb.Text = "Delete";
            lb.Click += new EventHandler(LinkButtonClicked);
            //lb.OnClick = myJobsModule.deleteApplicantsMentionedJob((row.Cells[2].Text).Replace(" ", String.Empty).ToLower());
            row.Cells[0].Controls.Add(lb);

        }
    }

    protected void setTable2()
    {
        DataTable myDataTable = new DataTable();
        JobsModule myJobsModule = new JobsModule();
        myJobsModule.setUserId((String)Session["userId"]);

        myDataTable = myJobsModule.getAppliedJobPositionsOfApplicant();

        AppliedJobsGridView.DataSource = myDataTable;
        AppliedJobsGridView.DataBind();
    }

    void LinkButtonClicked(object sender, EventArgs e)
    {
        LinkButton src = (LinkButton)sender;

        JobsModule myJobsModule = new JobsModule();
        myJobsModule.setUserId((String)Session["userId"]);

        GridViewRow row = (GridViewRow)src.NamingContainer;

        myJobsModule.deleteApplicantsMentionedJob((row.Cells[2].Text).Replace(" ", String.Empty).ToLower());
        Response.Redirect(Request.RawUrl);
    }
    /*protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/Login_Register.aspx");
    }*/

    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }

}