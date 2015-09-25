using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContactUS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        LoginModule myLogin = new LoginModule();
        int x = myLogin.checkPassword(UserNameLogin.Text, PasswordLogin.Text);
        if (x == 1)
        {
            //ConfirmationLabel.Text = "Password is correct.";

            // creating the session variable to store the ID of the user
            Session["userID"] = myLogin.getID(UserNameLogin.Text);
            if (Session["prevPage"] == null)
            {
                if (myLogin.getUserRole() == 0)
                {
                    Response.Redirect("HomePage.aspx");
                }
                else if (myLogin.getUserRole() == 1)
                {
                    Response.Redirect("ManagerHomePage.aspx");
                }
            }
            else
            {
                Response.Redirect((String)Session["prevPage"]);
            }
        }
        else
        {// ConfirmationLabel.Text = "Password is incorrect."; }

        }
    }
}