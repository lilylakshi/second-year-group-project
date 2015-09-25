using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FileDownloader : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    public override void ProcessRequest(HttpContext context)
    {
        try
        {
            String connectionString = String.Format("Data Source={0}; Initial Catalog={1}; Persist Security Info=True; User ID={2}; Password={3};", "LILY-PC", "projectdb1", "admin", "123");
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            SqlCommand getCommand = new SqlCommand("SELECT cvData FROM PDFCV WHERE u_id = @u_id", myConnection);
            getCommand.Parameters.Add("u_id", SqlDbType.Int).Value = context.Request.QueryString["uId"];

            byte[] file = (byte[])getCommand.ExecuteScalar();

            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition",
                               "attachment; filename=" + "CV_PDF.pdf" + ";");
            response.BinaryWrite(file);
            response.Flush();
            response.End();
        }
        catch (Exception ex)
        {
            context.Response.Redirect("~/WhereIsMyJob.aspx");
        }
    }
    
}