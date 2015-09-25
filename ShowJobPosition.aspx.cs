using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowJobPosition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(0);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);

        PositionId.Visible = false;
       
        showHideApplyButton();

        populatePage();
    }

    protected void populatePage()
    {
        JobsModule myJobsModule = new JobsModule();

        
        Dictionary<String, String> fields = new Dictionary<string, string>();
        fields = myJobsModule.getJobPosition(Context.Request.QueryString["pId"]);

        PositionId.Text = fields["positionId"];
        CreatorsId.Text = fields["creatorsId"];
        TitleLabel.Text = fields["title"];
        JobType.Text = fields["jobType"];
        EmployerLabel.Text = fields["employer"];
        FirstQuality.Text = fields["firstQuality"];
        FirstQualityType.Text = fields["firstQualityType"];
        SecondQuality.Text = fields["secondQuality"];
        SecondQualityType.Text = fields["secondQualityType"];
        ThirdQuality.Text = fields["thirdQuality"];
        ThirdQualityType.Text = fields["thirdQualityType"];
        DescriptionLabel.Text = fields["description"];
        Salary.Text = fields["salary"];
        MinAge.Text = fields["minAge"];
        MaxAge.Text = fields["maxAge"];
        Experience.Text = fields["experience"];

    }

    protected void showHideApplyButton()
    {
        if (new LoginModule().getUserRole() == 0)
        {
            ApplyButton.Visible = true;
        }
        else
        {
            ApplyButton.Visible = false;
        }
    }
    protected void ApplyButton_Click(object sender, EventArgs e)
    {
        // myJobsModule = new JobsModule();
        //if ((myJobsModule.enterApplicantForJobPosition((String)Session["userID"], PositionId.Text)).Equals("Applicant successfully inserted"))
        //{
        //    showAlert();
        //}
        Response.Redirect("~/AddRemark.aspx?pId=" + PositionId.Text);
    }

    protected void showAlert()
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "showAlert", "showAlert();", true);
    }

    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
}