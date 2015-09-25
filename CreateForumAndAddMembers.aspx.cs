using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateForumAndAddMembers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(1);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);
        if (!IsPostBack)
        {
            ForumModule myForumModule = new ForumModule();
            List<String> myList = new List<string>();
            myList = myForumModule.getListOfForums();
        }
    }
    protected void GetForumButton_Click(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        ForumModule myForumMoudule = new ForumModule();
        //ConfirmationLabel.Text = myForumMoudule.createForum(myLoginModule.getID(Username.Text), ForumName.Text);
        ConfirmationLabel.Text = myForumMoudule.createForum((String)Session["userID"], ForumName.Text);
    }
    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
}