using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateManagerInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(1);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);
        if (!IsPostBack)
        {
            try
            {

                Employer myEmployer = new Employer();
                //LoginModule myLoginModule = new LoginModule();
                String[] stringArray = myEmployer.getInfoToForm((String)Session["userID"]);
                fName.Text = stringArray[0]; mName.Text = stringArray[1]; lName.Text = stringArray[2];
                company.Text = stringArray[4];
                personalPhone.Text = stringArray[9];
                personalEmail.Text = stringArray[3];
                companyPhone.Text = stringArray[10];
                companyEmail.Text = stringArray[8];
                number.Text = stringArray[5];
                street.Text = stringArray[6];
                town.Text = stringArray[7];
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "showAlert", "showAlert();", true);
            }
        }

    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        try
        {
            //DateTime dt = (Calendar1.SelectedDate);
            //String format = "yyyy-MM-dd";
            // String dob = dt.ToString(format);
            Employer myEmployer = new Employer(); ;
            myEmployer.setStrings(fName.Text, mName.Text, lName.Text, personalPhone.Text, personalEmail.Text, companyPhone.Text, number.Text, street.Text, town.Text, company.Text, companyEmail.Text);

            //myCVModule.setUsername(fName.Text);
            myEmployer.setUserID((String)Session["userID"]);
            TextBox1.Text = myEmployer.UpdateInfo();
            if (TextBox1.Text.Equals("Non-returning query Successfully executed.Non-returning query Successfully executed.Non-returning query Successfully executed."))
            {
                Response.Redirect("ManagerHomePage.aspx");
            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "showAlert", "showAlert();", true);
        }
    }


    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
}