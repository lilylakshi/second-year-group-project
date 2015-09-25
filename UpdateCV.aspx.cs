using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using System.Data;

public partial class UpdateCV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(0);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);

        try
        {
            if (!IsPostBack)
            {
                CVModule myCVModule = new CVModule();
                //LoginModule myLoginModule = new LoginModule();
                String[] stringArray = myCVModule.getDetailsToForm((String)Session["userID"]);
                fName.Text = stringArray[0]; mName.Text = stringArray[1]; lName.Text = stringArray[2];
                //String date = stringArray[3];
                DateTime myDateTime = new DateTime();
                myDateTime = DateTime.Parse(stringArray[3]);
                Datepicker.Text = myDateTime.ToString("MM/dd/yyyy");
                //DateTime dt = Convert.ToDateTime(date);
                //Calendar1.SelectedDate = dt;
                //Calendar1.VisibleDate = dt;
                int genderIndex;
                if (stringArray[5].Equals("True"))
                {
                    genderIndex = 1;
                }
                else
                {
                    genderIndex = 0;
                }
                Gender.SelectedIndex = genderIndex;
                int mStatusIndex;
                if (stringArray[6].Equals("True"))
                {
                    mStatusIndex = 1;
                }
                else
                {
                    mStatusIndex = 0;
                }
                mStatus.SelectedIndex = mStatusIndex;
                number.Text = stringArray[7]; street.Text = stringArray[8]; town.Text = stringArray[9];
                email.Text = stringArray[10]; phone.Text = stringArray[11]; school.Text = stringArray[12];
            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "showAlert", "showAlert();", true);
        }
        
    }
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        try
        {
            //DateTime dt = (Calendar1.SelectedDate);
            //String format = "yyyy-MM-dd";
            // String dob = dt.ToString(format);
            CVModule myCVModule = new CVModule();
            myCVModule.setStrings(fName.Text, mName.Text, lName.Text, phone.Text, email.Text, school.Text, number.Text, street.Text, town.Text);
            //myCVModule.setdob(dob);
            myCVModule.setdob(Datepicker.Text);
            //myCVModule.setUsername(fName.Text);
            myCVModule.setUserID((String)Session["userID"]);
            int x = Gender.SelectedIndex, y = mStatus.SelectedIndex;
            myCVModule.setints(x, y);
            TextBox1.Text = myCVModule.UpdateCV();
            if (TextBox1.Text.Equals("Non-returning query Successfully executed.Non-returning query Successfully executed.Non-returning query Successfully executed."))
            {
                Response.Redirect("HomePage.aspx");
            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "showAlert", "showAlert();", true);
        }
    }

    protected void UploadImageButton_Click(object sender, EventArgs e)
    {
        CVModule myCVModule = new CVModule();
        myCVModule.setUserID((String)Session["userID"]);
        myCVModule.uploadImage(imageUploadControl);
    }

    protected void UploadPDFButton_Click(object sender, EventArgs e)
    {
        CVModule myCVModule = new CVModule();
        myCVModule.setUserID((String)Session["userID"]);
        myCVModule.uploadPdfCv(PDFUploadControl);
    }

    protected void ConnectFBButton_Click(object sender, EventArgs e)
    {
        /*HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:4840");
        client.PostAsJsonAsync("http://localhost:4840/Temp_Code/test4.aspx", "does this work?"); */
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        InfoModule myModule = new InfoModule();
        String token = myModule.facebookCheckAuthorisation();
        var client = new FacebookClient(token);
        client.Post("/me/feed", new { message = "Hello World!" });
    }
    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }

}