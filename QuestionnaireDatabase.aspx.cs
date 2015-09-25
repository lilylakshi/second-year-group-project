using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QuestionnaireDatabase : System.Web.UI.Page
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

        if (RadioButton1.Checked)
            marks++;

        if (RadioButton8.Checked)
            marks++;

        if (RadioButton10.Checked)
            marks++;

        if (RadioButton17.Checked)
            marks++;

        if (RadioButton21.Checked)
            marks++;

        if (RadioButton24.Checked)
            marks++;

        if (RadioButton29.Checked)
            marks++;

        if (RadioButton31.Checked)
            marks++;

        if (RadioButton36.Checked)
            marks++;

        if (RadioButton41.Checked)
            marks++;

        QuestionnaireModule myQuestionnaireModule = new QuestionnaireModule();
        myQuestionnaireModule.deletePrevMarks((String)Session["userID"], questionnaireType);
        myQuestionnaireModule.storeQuestionnaireMarks((String)Session["userID"], questionnaireType, marks);
        Response.Redirect("HomePage.aspx");
    }
}