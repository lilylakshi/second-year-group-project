using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QuestionnaireJava : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);
    }

    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int marks = 0;
        String questionnaireType = "java";

        if (RadioButton2.Checked)
            marks++;

        if (RadioButton9.Checked)
            marks++;

        if (RadioButton12.Checked)
            marks++;

        if(RadioButton14.Checked)
            marks++;

        if (RadioButton20.Checked)
            marks++;

        if (RadioButton24.Checked)
            marks++;

        if (RadioButton28.Checked)
            marks++;

        if (RadioButton32.Checked)
            marks++;

        if (RadioButton37.Checked)
            marks++;

        if (RadioButton38.Checked)
            marks++;

        QuestionnaireModule myQuestionnaireModule = new QuestionnaireModule();
        myQuestionnaireModule.deletePrevMarks((String)Session["userID"], questionnaireType);
        myQuestionnaireModule.storeQuestionnaireMarks((String)Session["userID"],questionnaireType,marks);
        Response.Redirect("HomePage.aspx");
    }
}