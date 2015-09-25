using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PromptToLogin : System.Web.UI.Page
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
            ConfirmationLabel.Text = "Password is correct.";

            // creating the session variable to store the ID of the user
            Session["userID"] = myLogin.getID(UserNameLogin.Text);

            if (Session["prevPage"] == null)
            {
                Response.Redirect("~/Login_Register.aspx");

            }

            /*if (Session["prevPage"] == null)
            {
                if (RadioButton2.Checked)
                {
                    Response.Redirect("HomePage.aspx");
                }
                else if (RadioButton1.Checked)
                {
                    Response.Redirect("ManagerHomePage.aspx");
                }
                else
                {
                    ConfirmationLabel.Text = "Please select Candidate or Employer";
                }

            }
            else
            {
                Response.Redirect((String)Session["prevPage"]);
            }*/
            Response.Redirect((String)Session["prevPage"]);
        }
        else { ConfirmationLabel.Text = "Password is incorrect."; }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login_Register.aspx");
    }
}