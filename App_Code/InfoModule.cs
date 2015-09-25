using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.IO;
using Facebook;

/// <summary>
/// Summary description for InfoModule
/// </summary>
public class InfoModule
{
    private static String connectionString = String.Format("Data Source={0}; Initial Catalog={1}; Persist Security Info=True; User ID={2}; Password={3};", "LILY-PC", "projectdb1", "admin", "123");

    private static String facebookAppId = "1551757645083277";
    private static String facebookAppSecret = "e428629b8df81e049c7443c4b2c05e41";

    public InfoModule()
	{
	}
    public String storeLinkedInId(String id, String u_id) 
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myInsertCommand = new SqlCommand("INSERT INTO LinkedInId(u_id, linkedInId) VALUES(@u_id, @id)", myConnection);
        myInsertCommand.Parameters.Add("u_id", SqlDbType.Int).Value = u_id;
        myInsertCommand.Parameters.Add("id", SqlDbType.VarChar).Value = id;
        myInsertCommand.ExecuteNonQuery();
        myConnection.Close();

        return "LinkedIn ID successfully stored";
    }

    public String getLinkedInId(String u_id)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT linkedInId FROM LinkedInId WHERE u_id=@u_id)", myConnection);
        myGetCommand.Parameters.Add("u_id", SqlDbType.Int).Value = u_id;
        String id = myGetCommand.ExecuteScalar().ToString();
        myConnection.Close();

        return id;
    }

    public String facebookCheckAuthorisation()
    {
        string accessToken = "";
        //String scope = "public_profile,user_actions.news,user_education_history,user_posts,user_status,user_work_history,publish_stream,manage_pages";
        String scope = "rsvp_event,publish_pages,read_mailbox,rsvp_event,email,publish_actions,read_insights,read_stream,user_about_me,user_actions.music,user_birthday,user_friends,user_hometown,user_managed_groups,user_relationship_details,user_status,user_website,user_actions.books,user_actions.news,user_education_history,user_likes,user_photos,user_relationships,user_tagged_places,user_work_history,user_actions.video,user_events,user_groups,user_location,user_posts,user_religion_politics,user_videos,manage_pages";
        if(HttpContext.Current.Request["code"] == null) 
        {
            HttpContext.Current.Response.Redirect(String.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                facebookAppId, HttpContext.Current.Request.Url.AbsoluteUri, scope));
        } else 
        {
            Dictionary<String, String> tokens = new Dictionary<string,string>();
           
            string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                facebookAppId, HttpContext.Current.Request.Url.AbsoluteUri, scope, HttpContext.Current.Request["code"].ToString(), facebookAppSecret);

            HttpWebRequest myRequest = WebRequest.Create(url) as HttpWebRequest;

            using(HttpWebResponse myResponse = myRequest.GetResponse() as HttpWebResponse) 
            {
                StreamReader myReader = new StreamReader(myResponse.GetResponseStream());

                string valsArray = myReader.ReadToEnd();

                foreach(string token in valsArray.Split('&')) 
                {
                    tokens.Add(token.Substring(0, token.IndexOf("=")), token.Substring(token.IndexOf("=") + 1, (token.Length - token.IndexOf("=") - 1)));
                }
            }
            accessToken = tokens["access_token"];
            this.storeAccessToken(accessToken);
        }
        return accessToken;
    }

    
    public string storeAccessToken(String accessToken) 
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myInsertCommand = new SqlCommand("INSERT INTO FacebookAccessToken(u_id, accessToken) VALUES (@u_id, @accessToken)", myConnection);
        myInsertCommand.Parameters.Add("u_id", SqlDbType.Int).Value = HttpContext.Current.Session["userID"].ToString();
        myInsertCommand.Parameters.Add("accessToken", SqlDbType.VarChar).Value = accessToken;
        myInsertCommand.ExecuteNonQuery();
        myConnection.Close();

        return "Successfully Inserted";
    }

    public String getFacebookAuthorisation()
    {
        if (this.readFacebookAccessToken().Length <= 0)
        {
            return this.facebookCheckAuthorisation();
        }
        else
        {
            return this.readFacebookAccessToken();
        }
    }

    public String readFacebookAccessToken() {
        
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT accessToken FROM FacebookAccessToken WHERE u_id = @u_id ORDER BY rowId DESC;", myConnection);
        myGetCommand.Parameters.Add("u_id", SqlDbType.Int).Value = HttpContext.Current.Session["userID"].ToString();

        String accessToken = "";
        try
        {
            accessToken = myGetCommand.ExecuteScalar().ToString();
        }
        catch(NullReferenceException e)
        {

        }
        myConnection.Close();

        return accessToken;
    }

    public String readFacebookAccessToken(String userID)
    {

        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT accessToken FROM FacebookAccessToken WHERE u_id = @u_id ORDER BY rowId DESC;", myConnection);
        myGetCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userID;

        String accessToken = "";
        try
        {
            accessToken = myGetCommand.ExecuteScalar().ToString();
        }
        catch (NullReferenceException e)
        {

        }
        myConnection.Close();

        return accessToken;
    }
}