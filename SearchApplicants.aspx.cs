using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SearchApplicants : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(0);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);
        SearchByDropDownList.AutoPostBack = true;
        JobTypeDropDownList.Visible = false; 
        JobTypeLabel.Visible = false;

        if (SearchByDropDownList.SelectedValue.Equals("JobPosition"))
        {
            JobTypeDropDownList.Visible = true;
            JobTypeLabel.Visible = true;
        }

        search();
    }
    protected void SearchButton_Click(object sender, EventArgs e)
    {
        search();
    }
    protected void GridViewRowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void search()
    {
        DataTable myDataTable = new DataTable();

        String keyword = SearchByDropDownList.SelectedValue;
        switch (keyword)
        {
            case "Name":
                myDataTable = new SearchModule().searchApplicantsByName(KeywordBox.Text).Copy();
                break;
            case "ComputerLanguage":
                myDataTable = new SearchModule().searchApplicantsByComputerLanguage(KeywordBox.Text).Copy();
                break;
            case "SoftSkill":
                myDataTable = new SearchModule().searchApplicantsBySoftSkill(KeywordBox.Text).Copy();
                break;
            case "JobPosition":
                if (!JobTypeDropDownList.SelectedValue.Equals("-1"))
                {
                    myDataTable = new SearchModule().searchApplicantsByJob(KeywordBox.Text, JobTypeDropDownList.SelectedValue).Copy();
                }
                else
                {
                    myDataTable = new SearchModule().searchApplicantsByJob(KeywordBox.Text).Copy();
                }
                break;
        }

        myDataTable.Columns.Add("Photo", typeof(String)).SetOrdinal(0);

        ResultsGridView.DataSource = myDataTable;
        ResultsGridView.DataBind();

        if (myDataTable.Rows.Count <= 0)
        {
            MessageLabel.Text = "No results found.";
            return;
        }
        else
        {
            MessageLabel.Text = "";
        }

        ResultsGridView.GridLines = GridLines.Horizontal;

        foreach (GridViewRow row in ResultsGridView.Rows)
        {
            HyperLink hp = new HyperLink();
            hp.Text = row.Cells[2].Text;
            hp.NavigateUrl = "~/SearchCandidates.aspx?userId=" + row.Cells[1].Text;
            row.Cells[2].Controls.Add(hp);

            row.Cells[1].Controls.Clear();
            Image img = new Image();
            img.ImageUrl = "~/ShowPhoto.aspx?userId=" + row.Cells[1].Text;
            img.Height = 60;
            row.Cells[1].Controls.Add(img);
        }
    }
    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
}