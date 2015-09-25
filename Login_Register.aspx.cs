using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int role = 0;

        if (!RadioButton2.Checked && RadioButton1.Checked) { role = 1; }

        if (TextBox2.Text.Equals("") || TextBox3.Text.Equals("") || ReEnterPassword.Text.Equals("") || 
            (!RadioButton1.Checked && !RadioButton2.Checked) )
        {
            WarningLabel.Text = "Your Response is incomplete";
        }
        else
        {
            LoginModule myLogin = new LoginModule();
            if (TextBox3.Text == ReEnterPassword.Text)
            {
                WarningLabel.Text = myLogin.createAccount(TextBox2.Text, TextBox3.Text, EmailTextBox.Text, role);
            }
            else
            {
                WarningLabel.Text = "Passwords don't match!";
            }

        }
    }
    protected void VerifyButton_Click(object sender, EventArgs e)
    {
        LoginModule myLogin = new LoginModule();
        if (myLogin.checkAvailability(TextBox2.Text, EmailTextBox.Text) >= 1) {
            ShowAvailabilityLabel.Text = "Username is available"; 
        }
        else { ShowAvailabilityLabel.Text = "Username or/and email already exists!"; }
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        LoginModule myLogin = new LoginModule();
        int x = myLogin.checkPassword(UserNameLogin.Text, PasswordLogin.Text);
        if (x == 1) { 
            ConfirmationLabel.Text = "Password is correct.";

            // creating the session variable to store the ID of the user
            Session["userID"] = myLogin.getID(UserNameLogin.Text);
            /*
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
                else if (myLogin.getUserRole() == 2)
                {
                    Response.Redirect("AdminHomePage.aspx");
                }
            }
            else
            {
                Response.Redirect((String)Session["prevPage"]);
            } */
            if (myLogin.getUserRole() == 0)
            {
                Response.Redirect("HomePage.aspx");
            }
            else if (myLogin.getUserRole() == 1)
            {
                Response.Redirect("ManagerHomePage.aspx");
            }
            else if (myLogin.getUserRole() == 2)
            {
                Response.Redirect("WarnBanUsers.aspx");
            }
        }
        else { ConfirmationLabel.Text = "Password is incorrect."; }

    }
}