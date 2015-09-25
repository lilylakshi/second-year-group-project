using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ForumModule
/// </summary>
public class ForumModule
{
    //private DateTime timeofCreation;
    //private int ForumID;
    //private String creator;

	public ForumModule()
	{
	}

    public String createForum(String userID, String forumTitle)
    {
        DateTime time = new DateTime();
        time = DateTime.Now;
        String timeString = time.ToString("yyyy-MM-dd HH:MM:ss");
        String query = String.Format("INSERT INTO Forum( u_id, f_time, f_title) VALUES ( {0}, '{1}', '{2}')", userID, timeString, forumTitle);
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String msg = myConnection.executeNonReturningQuery(query);
        return msg;
    }
    public String addPostToForum(String userID, String forumID, String post)
    {
       /* DateTime time = new DateTime();
        time = DateTime.Now;
        String timeString = time.ToString("yyyy-MM-dd HH:MM:ss");
        String query = String.Format("INSERT INTO Post (post, p_time, u_id, f_id) VALUES ('{0}', '{1}', {2}, {3})", post, timeString, userID, forumID);
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String msg = myConnection.executeNonReturningQuery(query);
        return msg; */

        DateTime time = new DateTime();
        time = DateTime.Now;

        String connectionString = String.Format("Data Source={0}; Initial Catalog={1}; Persist Security Info=True; User ID={2}; Password={3};", "LILY-PC", "projectdb1", "admin", "123");
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myInsertCommand = new SqlCommand("INSERT INTO Post (post, p_time, u_id, f_id) VALUES (@post, @p_time, @u_id, @f_id)", myConnection);
        myInsertCommand.Parameters.Add("post", SqlDbType.VarChar).Value = post;
        myInsertCommand.Parameters.Add("p_time", SqlDbType.DateTime).Value = time;
        myInsertCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userID;
        myInsertCommand.Parameters.Add("f_id", SqlDbType.Int).Value = forumID;
        myInsertCommand.ExecuteNonQuery();
        myConnection.Close();
        return "Successfully Inserted";
    }

    public DataTable getPostsOFForum(String forumID)
    {
        DataTable myTable = new DataTable(); ;
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String query = String.Format("SELECT p.post FROM Post AS p, Forum AS f WHERE f.f_id = {0} AND f.f_id = p.f_id ORDER BY p.p_time", forumID);
        myTable = myConnection.executeReturningQuery(query);
        return myTable;
    }

    public List<String> getListOfForums()
    {
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String query = "SELECT f_title FROM [projectdb1].[dbo].[Forum]";
        return myConnection.getResultsList(query, "f_title");
    }

    public String getForumID(String forumName)
    {
        List<String> myList = new List<string>();
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String query = String.Format("SELECT f_id FROM [projectdb1].[dbo].[Forum] WHERE f_title = '{0}'", forumName);
        myList = myConnection.getResultsList(query, "f_id");
        return myList.First();
    }
}