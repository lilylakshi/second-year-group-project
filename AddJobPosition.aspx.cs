using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddJobPosition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(1);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);
    }

    protected void SubmitCloseButton_Click(object sender, EventArgs e)
    {
        insert();
        closeWindow();
    }

    protected void SubmitNewButton_Click(object sender, EventArgs e)
    {
        insert();
        clearTextBoxes();
    }

    protected void insert()
    {
        if (isTextBoxesFilled())
        {
            JobsModule myJobsModule = new JobsModule();
            myJobsModule.insertJobPosition((String)Session["userId"], JobTypeDropDownList.SelectedValue, EmployerTextBox.Text, 
                TitleTextBox.Text, DescriptionTextBox.Text, SalaryTextBox.Text, MinAgeTextBox.Text, MaxAgeTextBox.Text, ExperienceTextBox.Text,
                FirstQualityDropDownList.SelectedValue, FirstQualityTextBox.Text, SecondQualityDropDownList.SelectedValue, SecondQualityTextBox.Text, 
                ThirdQualityDropDownList.SelectedValue, ThirdQualityTextBox.Text);
        }
        else
        {
            FeedbackLabel.Text = "Please fill in all required fields";
        }
    }

    protected bool isTextBoxesFilled()
    {
        if (TitleTextBox.Text == "" || EmployerTextBox.Text == "" || DescriptionTextBox.Text == "" ||
            FirstQualityTextBox.Text == "" || SecondQualityTextBox.Text == "" || ThirdQualityTextBox.Text == "")
        {
            return false;
        }
        return true;
    }

    protected void closeWindow()
    {
        if (isTextBoxesFilled())
        {
            Response.Redirect("~/ManagerHomePage.aspx");
        }
        else
        {
            FeedbackLabel.Text = "Please fill in all required fields";
        }
    }

    protected void clearTextBoxes()
    {
        TitleTextBox.Text = String.Empty;
        EmployerTextBox.Text = String.Empty;
        DescriptionTextBox.Text = String.Empty;
        SalaryTextBox.Text = "0";
        MinAgeTextBox.Text = "0";
        MaxAgeTextBox.Text = "0";
        ExperienceTextBox.Text = "0";
        JobTypeDropDownList.SelectedValue = "0";
        FirstQualityTextBox.Text = String.Empty;
        SecondQualityTextBox.Text = String.Empty;
        ThirdQualityTextBox.Text = String.Empty;
    }
    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
}