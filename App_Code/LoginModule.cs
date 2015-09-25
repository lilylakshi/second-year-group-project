using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for LoginModule
/// </summary>
public class LoginModule
{
    private static String connectionString = String.Format("Data Source={0}; Initial Catalog={1}; Persist Security Info=True; User ID={2}; Password={3};", "LILY-PC", "projectdb1", "admin", "123");
    
	public LoginModule()
	{
	}

    // function to login to the system
    public String login(String username, String password)
    {
        return "Complete the implementation";
    }

    // function to create a new user account
    public String createAccount(String username, String password, String email, int role)
    {
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        if (this.checkAvailability(username, email) >= 1)
        {
            String query1 = String.Format("INSERT INTO UserAcc(u_name, passd, role) VALUES ('{0}','{1}', {2})", username, password, role);
            String msg1 = myConnection.executeNonReturningQuery(query1);

            return msg1;
        }
        else
        {
            return "Username is already taken.";
        }
    }

    // function to check if the username already exists.
    // return 1 if username is available
    public int checkAvailability(String username, String email)
    {
        List<String> myList1 = new List<string>();
        List<String> myList2 = new List<string>();

        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String query1 = String.Format("SELECT * FROM UserAcc WHERE u_name = '{0}'", username);
        String query2 = String.Format("SELECT email FROM Candidate WHERE email = '{0}'", email);

        myList1 = myConnection.getResultsList(query1, "u_name");
        myList2 = myConnection.getResultsList(query2, "email");

        if ((myList1.Count >= 1) || (myList2.Count >= 1)) { return 0; }
        else { return 1; }
    }

    // functionto check the password for a given username
    public int checkPassword(String username, String password)
    {
        List<String> myList1 = new List<string>();
        List<String> myList2 = new List<string>();
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String query = String.Format("SELECT * FROM UserAcc WHERE u_name='{0}'", username);
        myList1 = myConnection.getResultsList(query, "u_name");
        myList2 = myConnection.getResultsList(query, "passd");
        String[] array1 = myList1.ToArray();
        String[] array2 = myList2.ToArray();
        for (int i = 0; i < array1.Length; i++ )
        {
            if (array1[i]==username && array2[i]==password) { return 1; }
        }
        return 0;
    }

    public String getID(String username)
    {
        String id; List<String> myList = new List<string>();
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String query = String.Format("SELECT * FROM UserAcc WHERE u_name='{0}'", username);
        myList = myConnection.getResultsList(query, "u_id");
        String[] array = myList.ToArray();
        id = array[0];
        return id;
    }

    public void checkLoginStatus()
    {
        if (HttpContext.Current.Session["userID"] == null)
        {
            //HttpContext.Current.Session["prevPage"] = Path.GetFileName(HttpContext.Current.Request.PhysicalPath);
            HttpContext.Current.Session["prevPage"] = HttpContext.Current.Request.Url.AbsoluteUri.ToString();
            HttpContext.Current.Response.Redirect("~/PromptToLogin.aspx");
        }
    }

    public String getFirstName(String userId)
    {
        List<String> myList = new List<string>();
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String query = String.Format("SELECT f_name FROM Candidate WHERE u_id='{0}'", userId);
        myList = myConnection.getResultsList(query, "f_name");
        if (myList.Count == 0)
        {
            return this.getUsername();
        }
        return myList.ElementAt(0);
    }

    public String getUsername()
    {
        String userId = (String)HttpContext.Current.Session["userID"];
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String query = String.Format("SELECT u_name FROM UserAcc WHERE u_id='{0}'", userId);
        return myConnection.getResultsList(query, "u_name").ElementAt(0);
    }

    public int getUserRole()
    {
        String userId = (String)HttpContext.Current.Session["userID"];
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT role FROM UserAcc WHERE u_id = @u_id", myConnection);
        myGetCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userId;
        object role = myGetCommand.ExecuteScalar();

        myConnection.Close();

        return int.Parse(role.ToString());
    }
    public String manageChangePassword(String userId, String oldPsd, String newPassword, String reEntNewPsd)
    {
        if (this.getPassword(userId).Equals(oldPsd))
        {
            if (newPassword.Equals(reEntNewPsd))
            {
                return this.changePassword(userId, newPassword);
            }
            else
            {
                return "New password fields do not match";
            }
        }
        else
        {
            return "Password entered is incorrect";
        }
    }

    public String getPassword(String userId)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT passd FROM UserAcc WHERE u_id = @u_id", myConnection);
        myGetCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userId;
        String password;
        try
        {
            password = myGetCommand.ExecuteScalar().ToString();
        }
        catch (Exception e)
        {
            password = "Error Occured";
        }
        myConnection.Close();
        return password;
    }

    public String changePassword(String userId, String newPassword)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myUpdateCommand = new SqlCommand("UPDATE UserAcc SET passd = @newPassword WHERE u_id = @u_id", myConnection);
        myUpdateCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userId;
        myUpdateCommand.Parameters.Add("newPassword", SqlDbType.VarChar).Value = newPassword;
        try
        {
            myUpdateCommand.ExecuteNonQuery();
        }
        catch (Exception e) { }
        myConnection.Close();
        return "Password changed";

    }
    public String deleteAccount(String userId)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myDeleteCommand = new SqlCommand("DELETE FROM UserAcc WHERE u_id = @u_id", myConnection);
        myDeleteCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userId;

        try
        {
            myDeleteCommand.ExecuteNonQuery();
        }
        catch (Exception e) { }
        myConnection.Close();
        return "Account Deleted";
    }

    public String checkPermission(int x)
    {
        int role = getUserRole();

        if (x != role)
        {
            HttpContext.Current.Response.Redirect("~/WarningNoPermission.aspx");
        }

        return "Permisstion checked";
    }
}