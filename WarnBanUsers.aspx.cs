using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WarnBanUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(2);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);

        search();

    }

    protected void search()
    {
        DataTable myDataTable = new DataTable(); 
        AdminModule myAdminModule = new AdminModule();
        //myDataTable = myAdminModule.getAllUsers();

        if (KeywordBox.Text.Equals(""))
        {
            myDataTable = myAdminModule.getAllUsers2().Copy();
        }
        else
        {
            myDataTable = myAdminModule.searchUsers2(KeywordBox.Text).Copy();
        }

        myDataTable.Columns.Add("Warn", typeof(String));
        myDataTable.Columns.Add("Ban", typeof(String));

        UsersGridView.DataSource = myDataTable;
        UsersGridView.DataBind();

        formatGridView();

    }
    protected void GetAllButton_Click(object sender, EventArgs e)
    {
        getAllUsers();
    }

    protected void getAllUsers()
    {
        DataTable myDataTable = new DataTable();

        AdminModule myAdminModule = new AdminModule();
        myDataTable = myAdminModule.getAllUsers2().Copy();
        myDataTable.Columns.Add("Warn", typeof(String));
        myDataTable.Columns.Add("Ban", typeof(String));

        UsersGridView.DataSource = myDataTable;
        UsersGridView.DataBind();

        formatGridView();

    }

    protected void formatGridView()
    {
        foreach(GridViewRow row in UsersGridView.Rows) 
        {
            LinkButton warnButton = new LinkButton();
            warnButton.Text = "Warn";
            warnButton.Click += new EventHandler(LinkButtonClicked);
            row.Cells[4].Controls.Add(warnButton);

            LinkButton banButton = new LinkButton();
            banButton.Text = "Ban";
            banButton.Click += new EventHandler(BanButtonClicked);
            row.Cells[5].Controls.Add(banButton);
        }
    }

    void LinkButtonClicked(object sender, EventArgs e)
    {
        LinkButton src = (LinkButton)sender;
        GridViewRow row = (GridViewRow)src.NamingContainer;

        new EmailModule().warnUserByEmail(row.Cells[0].Text);

       // Response.Redirect(Request.RawUrl);
    }

    void BanButtonClicked(object sender, EventArgs e)
    {
        LinkButton src = (LinkButton)sender;
        GridViewRow row = (GridViewRow)src.NamingContainer;

        new LoginModule().deleteAccount(row.Cells[0].Text);

        Response.Redirect(Request.RawUrl);
    }

    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
}