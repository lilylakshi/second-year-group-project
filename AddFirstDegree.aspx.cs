using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddFirstDegree : System.Web.UI.Page
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
        if (DegreeNameTextBox.Text != "" && UniversityNameTextBox.Text != "" && YearTextBox.Text != "")
        {
            CVModule myCVModule = new CVModule();
            myCVModule.setUserID((String)Session["userID"]);
            FunctionCallerLabel.Text = myCVModule.insertFirstDegree(DegreeNameTextBox.Text, UniversityNameTextBox.Text, YearTextBox.Text);
            DegreeNameTextBox.Text = String.Empty;
            UniversityNameTextBox.Text = String.Empty;
            YearTextBox.Text = String.Empty;
        }
        else
        {
            ConfirmationLabel.Text = "Please fill in all the details.";
        }
    }
    protected void SubmitAndCloseButton_Click(object sender, EventArgs e)
    {
        if (DegreeNameTextBox.Text != "" && UniversityNameTextBox.Text != "" && YearTextBox.Text != "")
        {
            CVModule myCVModule = new CVModule();
            myCVModule.setUserID((String)Session["userID"]);
            FunctionCallerLabel.Text = myCVModule.insertFirstDegree(DegreeNameTextBox.Text, UniversityNameTextBox.Text, YearTextBox.Text);
            FunctionCallerLabel.Text = "<script type='text/javascript'>closeWindow();</script>"; 
        }
        else
        {
            ConfirmationLabel.Text = "Please fill in all the details.";
        }
        //Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "closeWindow();");
        //Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closeWindow", "window.onunload = closeWindow();"); 
    }
    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
}