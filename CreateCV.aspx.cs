using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateCV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(0);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);
    }
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        //DateTime dt = (Calendar1.SelectedDate);
        //String format = "yyyy-MM-dd";
        //String dob = dt.ToString(format);
        CVModule myCVModule = new CVModule();
        myCVModule.setStrings(fName.Text, mName.Text, lName.Text, phone.Text, email.Text, school.Text, number.Text, street.Text, town.Text);
        //myCVModule.setdob(dob);
        myCVModule.setdob(Datepicker.Text);
        //myCVModule.setUsername(fName.Text);
        myCVModule.setUserID((String)Session["userID"]);
        int x = Gender.SelectedIndex, y = mStatus.SelectedIndex;
        myCVModule.setints(x, y);
        TextBox1.Text = myCVModule.createCV();
        Response.Redirect("HomePage.aspx");
    }
    protected void UploadImageButton_Click(object sender, EventArgs e)
    {
        CVModule myCVModule = new CVModule();
        myCVModule.setUserID((String)Session["userID"]);
        myCVModule.uploadImage(imageUploadControl);
    }

    protected void BrowseImageButton_Click(object sender, EventArgs e)
    {
        picone.ImageUrl = "imageUploadControl"; 
    }

    protected void UploadPDFButton_Click(object sender, EventArgs e)
    {
        CVModule myCVModule = new CVModule();
        myCVModule.setUserID((String)Session["userID"]);
        myCVModule.uploadPdfCv(PDFUploadControl);
    }
    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
}