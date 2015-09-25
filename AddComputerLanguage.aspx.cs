using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddComputerLanguage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(0);
        FunctionCallerLabel.Text = String.Empty;
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);
    }
    protected void SubmitAndNewButton_Click(object sender, EventArgs e)
    {
        if (Language.Text != "")
        {
            CVModule myCVModule = new CVModule();
            myCVModule.setUserID((String)Session["userID"]);
            ConfirmationLabel.Text = myCVModule.insertComputerLanguage(Language.Text, ProficiencyDropDownList.SelectedValue);
            Language.Text = String.Empty;
        }
        else
        {
            ConfirmationLabel.Text = "Please enter a language.";
        }
    }
    protected void SubmitAndCloseButton_Click(object sender, EventArgs e)
    {
        if (Language.Text != "")
        {
            CVModule myCVModule = new CVModule();
            myCVModule.setUserID((String)Session["userID"]);
            ConfirmationLabel.Text = myCVModule.insertComputerLanguage(Language.Text, ProficiencyDropDownList.SelectedValue);
            FunctionCallerLabel.Text = "<script type='text/javascript'>closeWindow();</script>";
        }
        else
        {
            ConfirmationLabel.Text = "Please enter a language.";
        }
        //Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closeWindow", "window.onunload = closeWindow();");  
        //Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "closeWindow();");
    }
    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
}