using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ListOfAppliedApplicants : System.Web.UI.Page
{

    private int selectRow = 5;

    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(1);

        JobsModule myJobsModule = new JobsModule();
        if (!myJobsModule.doesJobBelongToUser((String)Session["userID"], Request["pId"]))
        {
            myLoginModule.checkPermission(3);
        }

        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);

        setTable();
    }

    protected void setTable()
    {
        SearchModule mySearchModule = new SearchModule();
        DataTable myDataTable = new DataTable();

        myDataTable = mySearchModule.ratedListOfApplicantsForJobPosition3(Request["pId"]).Copy();
        myDataTable.Columns.Add("Select for Interview", typeof(String));
        myDataTable.Columns.Add("Photo", typeof(String)).SetOrdinal(1);

        ApplicantsListGridView.DataSource = myDataTable;
        ApplicantsListGridView.DataBind();

        foreach (GridViewRow row in ApplicantsListGridView.Rows)
        {
            HyperLink hp = new HyperLink();
            hp.Text = row.Cells[2].Text;
            hp.NavigateUrl = "~/SearchCandidates.aspx?userId=" + row.Cells[0].Text;
            row.Cells[2].Controls.Add(hp);

            CheckBox cb = new CheckBox();
            row.Cells[selectRow].Controls.Add(cb);

            row.Cells[1].Controls.Clear();
            Image img = new Image();
            img.ImageUrl = "~/ShowPhoto.aspx?userId=" + row.Cells[0].Text;
            img.Height = 60;
            row.Cells[1].Controls.Add(img);
        }
    }

    protected void GridViewRowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }
    protected void RefreshRatingsButton_Click(object sender, EventArgs e)
    {
        RatingModule myRatingModule = new RatingModule(Request["pId"]);
        setTable();
    }
    protected void SendForInterviewButton_Click(object sender, EventArgs e)
    {
        List<String> idList = new List<String>();

        CheckBox cb = new CheckBox();

        foreach (GridViewRow row in ApplicantsListGridView.Rows)
        {
            cb = (CheckBox)row.Cells[selectRow].Controls[0];
            if (cb.Checked)
            {
                idList.Add(((GridViewRow)cb.NamingContainer).Cells[0].Text);
            }
        }

        EmailModule myEmailModule = new EmailModule();
        Employer emailSender = new Employer();
        emailSender.sheduleAndCallForInterviews(idList, Request["pid"], StartingTimeTextBox.Text, DateTextBox.Text, VenueTextBox.Text);
        /*
        foreach (String applicantId in idList)
        {
            myEmailModule.sendEmailForInterview(applicantId, Request["pid"], "10.30AM", "06/06/2015", "Company Conference Hall");
        }
        */
    }
    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
}