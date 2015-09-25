using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SendAnEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreatePostButton_Click(object sender, EventArgs e)
    {
        try
        {
            EmailModule myEmailModule = new EmailModule();
            //myEmailModule.recoverPassword(TextBox1.Text);
            myEmailModule.recoverPassword2(TextBox1.Text);
            Response.Redirect("EmailConfirmation.aspx");
        }
        catch (NullReferenceException en) { }

        
    }
}