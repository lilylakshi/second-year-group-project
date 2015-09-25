using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PostInForum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(0);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);
        if (!IsPostBack)
        {
            ForumModule myForumModule = new ForumModule();
            List<String> myList = new List<string>();
            myList = myForumModule.getListOfForums();
            ListOfForumsDropDownList.DataSource = myList;
            ListOfForumsDropDownList.DataBind();
        }
        else
        {
            ForumModule myForumModule = new ForumModule();
            String forumID = myForumModule.getForumID(ListOfForumsDropDownList.SelectedValue);
            GridView1.DataSource = myForumModule.getPostsOFForum(forumID);
            GridView1.DataBind();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "animateGridView", "animateGridView();", true);
        }

    }
    protected void CreatePostButton_Click(object sender, EventArgs e)
    {
        ForumModule myForumModule = new ForumModule();
        String forumID = myForumModule.getForumID(ListOfForumsDropDownList.SelectedValue);;
        myForumModule.addPostToForum((String)Session["userID"], forumID, TextBox2.Text);
        GridView1.DataSource = myForumModule.getPostsOFForum(forumID);
        GridView1.DataBind();
    }
    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
}