using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ViewEmployersJobPositions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(1);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);

        setTable();
    }

    protected void setTable()
    {
        DataTable myDataTable = new DataTable();
        JobsModule myJobsModule = new JobsModule();
        myJobsModule.setUserId((String)Session["userId"]);

        myDataTable = myJobsModule.getEmployersJobPositions().Copy();

        myDataTable.Columns.Add("Delete", typeof(String)).SetOrdinal(0);
        myDataTable.Columns.Add("List of Applied Applicants", typeof(String)).SetOrdinal(4);

        JobPositionsGridView.DataSource = myDataTable;
        JobPositionsGridView.DataBind();

        foreach (GridViewRow row in JobPositionsGridView.Rows)
        {
            LinkButton lb = new LinkButton();
            lb.Text = "Delete";
            lb.Click += new EventHandler(LinkButtonClicked);
            row.Cells[0].Controls.Add(lb);

            HyperLink hp = new HyperLink();
            hp.Text = row.Cells[2].Text;
            hp.NavigateUrl = "~/ShowJobPositionsManager.aspx?pId=" + row.Cells[1].Text;
            row.Cells[2].Controls.Add(hp);

            HyperLink hp2 = new HyperLink();
            hp2.Text = "Show Applied Applicants";
            hp2.NavigateUrl = "~/ListOfAppliedApplicants.aspx?pId=" + row.Cells[1].Text;
            row.Cells[4].Controls.Add(hp2);
        }
    }

    void LinkButtonClicked(object sender, EventArgs e)
    {
        LinkButton src = (LinkButton)sender;

        JobsModule myJobsModule = new JobsModule();
        myJobsModule.setUserId((String)Session["userId"]);

        GridViewRow row = (GridViewRow)src.NamingContainer;

        myJobsModule.deleteJobPosition(row.Cells[1].Text);
        Response.Redirect(Request.RawUrl);
    }

    protected void GridViewRowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
    }

    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
}