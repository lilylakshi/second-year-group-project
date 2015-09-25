using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchCandidatesManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(1);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);

        HttpContext context = System.Web.HttpContext.Current;
        //Added code
        CVModule myCVModule = new CVModule();
        myCVModule.setUserID(context.Request.QueryString["userId"]);
        picone.ImageUrl = "ShowPhoto.aspx?userId=" + context.Request.QueryString["userId"];
        //String[] stringArray = myCVModule.getDetailsToForm(myLoginModule.getID(TextBox2.Text));
        String[] stringArray = myCVModule.getDetailsToForm(context.Request.QueryString["userId"]);
        name.Text = stringArray[0] + " " + stringArray[1] + " " + stringArray[2];
        String dob = stringArray[3];
        DateTime myDateTime = new DateTime();
        myDateTime = DateTime.Parse(stringArray[3]);
        String stringAge = myDateTime.Subtract(DateTime.Now).ToString("dhms");
        long age = Int64.Parse(stringAge);
        age /= 1000000;
        age /= 365;
        Calendar1.Text = age.ToString();
        if (stringArray[5].Equals("True"))
        {
            Gender.Text = "Female";
        }
        else
        {
            Gender.Text = "Male";
        }
        if (stringArray[6].Equals("True"))
        {
            mStatus.Text = "Married";
        }
        else
        {
            mStatus.Text = "Single";
        }
        number.Text = stringArray[7]; street.Text = stringArray[8]; town.Text = stringArray[9];
        email.Text = stringArray[10];
        //phone.Text = stringArray[11]; 
        school.Text = stringArray[12];

        FirstDegreeGridView.DataSource = myCVModule.getFirstDegree();
        FirstDegreeGridView.DataBind();
        FirstDegreeGridView.GridLines = GridLines.None;
        if (FirstDegreeGridView.Rows.Count == 0)
        {
            FirstDegreesLabel.Visible = false;
        }

        MastersDegreeGridView.DataSource = myCVModule.getMastersDegree();
        MastersDegreeGridView.DataBind();
        MastersDegreeGridView.GridLines = GridLines.None;
        if (MastersDegreeGridView.Rows.Count == 0)
        {
            MastersDegreeLabel.Visible = false;
        }

        PhdGridView.DataSource = myCVModule.getPhd();
        PhdGridView.DataBind();
        PhdGridView.GridLines = GridLines.None;
        if (PhdGridView.Rows.Count == 0)
        {
            PhdLabel.Visible = false;
        }

        SoftSkillGridView.DataSource = myCVModule.getSoftSkill();
        SoftSkillGridView.DataBind();
        SoftSkillGridView.GridLines = GridLines.None;
        if (SoftSkillGridView.Rows.Count == 0)
        {
            SoftSkillLabel.Visible = false;
        }

        PhoneGridView.DataSource = myCVModule.getPhoneNumbers();
        PhoneGridView.DataBind();
        PhoneGridView.GridLines = GridLines.None;
        if (PhoneGridView.Rows.Count == 0)
        {
            PhoneLabel.Visible = false;
        }

        SeekingJobsGridView.DataSource = myCVModule.getSeekingJobs();
        SeekingJobsGridView.DataBind();
        SeekingJobsGridView.GridLines = GridLines.None;
        if (SeekingJobsGridView.Rows.Count == 0)
        {
            SeekingJobsLabel.Visible = false;
        }
    }

    /*protected void SearchButton_Click(object sender, EventArgs e)
    {
        CVModule myCVModule = new CVModule();
        LoginModule myLoginModule = new LoginModule();
        picone.ImageUrl = "ShowPhoto.aspx?userId=" + myLoginModule.getID(TextBox2.Text);
        String[] stringArray = myCVModule.getDetailsToForm(myLoginModule.getID(TextBox2.Text));
        fName.Text = stringArray[0]; mName.Text = stringArray[1]; lName.Text = stringArray[2];
        String dob = stringArray[3];
        DateTime myDateTime = new DateTime();
        myDateTime = DateTime.Parse(stringArray[3]);
        Calendar1.Text = myDateTime.ToString("MM/dd/yyyy");
        if (stringArray[5].Equals("True"))
        {
            Gender.Text = "Female";
        }
        else
        {
            Gender.Text = "Male";
        }
        if (stringArray[6].Equals("True"))
        {
            mStatus.Text = "Married";
        }
        else
        {
            mStatus.Text = "Single";
        }
        number.Text = stringArray[7]; street.Text = stringArray[8]; town.Text = stringArray[9];
        email.Text = stringArray[10]; 
        //phone.Text = stringArray[11]; 
        school.Text = stringArray[12];
    }*/

    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }

    protected void ShowFacebookButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ApplicantFacebbookDataManagerView.aspx?id=" + Request["userId"]);
    }
    protected void DownloadCvButton_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/FileDownloader.aspx?uId=" + Request["userId"]);
        }
        catch {
            Session["Prev"] = HttpContext.Current.Session["prevPage"] = HttpContext.Current.Request.Url.AbsoluteUri.ToString();
            Response.Redirect("WarningNoDownloadableContent.aspx");
        }
    }
}