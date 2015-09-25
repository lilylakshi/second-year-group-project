using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        myLoginModule.checkPermission(1);
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);
    }
    protected void AdditionalInfoButton_Click(object sender, EventArgs e)
    {
        Employer myEmployer = new Employer();
        myEmployer.setUserID((String)Session["userID"]);
        myEmployer.setStrings(fName.Text, mName.Text, lName.Text, personalPhone.Text, personalEmail.Text, company.Text, number.Text, street.Text, town.Text, companyPhone.Text, companyEmail.Text);
        TextBox1.Text = myEmployer.addInfo();
        Response.Redirect("ManagerHomePage.aspx");
    }
    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
    
}