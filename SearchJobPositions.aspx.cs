using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchJobPositions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(0);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);
        search();
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        search();
    }

    protected void search()
    {
        SearchModule mySearchModule = new SearchModule();
        JobPositionsGridView.DataSource = mySearchModule.searchJobPositionByTitle(KeywordTextBox.Text);
        JobPositionsGridView.DataBind();

        foreach (GridViewRow row in JobPositionsGridView.Rows)
        {
            HyperLink hp = new HyperLink();
            hp.Text = row.Cells[1].Text;
            hp.NavigateUrl = "~/ShowJobPosition.aspx?pId=" + row.Cells[0].Text;
            row.Cells[1].Controls.Add(hp);
        }
    }

    protected void GridViewRowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }
    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
}