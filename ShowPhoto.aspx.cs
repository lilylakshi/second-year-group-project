using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Temp_Code_ShowPhoto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public override void ProcessRequest(HttpContext context)
    {
        System.Data.SqlClient.SqlDataReader myDataReader = null;
        System.Data.SqlClient.SqlConnection myConnection = null;
        System.Data.SqlClient.SqlCommand mySqlCommand = null;
        try
        {
            String connectionString = String.Format("Data Source={0}; Initial Catalog={1}; Persist Security Info=True; User ID={2}; Password={3};", "LILY-PC", "projectdb1", "admin", "123");
            myConnection = new System.Data.SqlClient.SqlConnection(connectionString);
            mySqlCommand = new System.Data.SqlClient.SqlCommand("SELECT photoData FROM UserProfilePhoto WHERE userId =" + context.Request.QueryString["userId"] + "ORDER BY photoId DESC", myConnection); 
            myConnection.Open();
            myDataReader = mySqlCommand.ExecuteReader();
            if(!(myDataReader.HasRows)) {
                myDataReader.Close();
                mySqlCommand = new System.Data.SqlClient.SqlCommand("SELECT photoData FROM UserProfilePhoto WHERE userId = 0", myConnection);
                myDataReader = mySqlCommand.ExecuteReader();
            }
            while (myDataReader.Read())
            {
                context.Response.ContentType = "image/jpg";
                context.Response.BinaryWrite((byte[])myDataReader["photoData"]);
            }
            if (myDataReader != null)
                myDataReader.Close();
        }
        finally
        {
            if (myConnection != null)
                myConnection.Close();
        }
    }
}