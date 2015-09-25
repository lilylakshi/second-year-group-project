using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for EmailModule
/// </summary>
public class EmailModule
{

    private static String connectionString = String.Format("Data Source={0}; Initial Catalog={1}; Persist Security Info=True; User ID={2}; Password={3};", "LILY-PC", "projectdb1", "admin", "123");
	public EmailModule()
	{
	}

    public String recoverPassword(String SendtoAddress)
    {
        String fromAddress = "lilylakshi@gmail.com";
        String toAddress = SendtoAddress;
        const String password = "diligentia";
        const String subject = "Retrieving Password";
        String query = String.Format("SELECT u.u_name, u.passd FROM UserAcc AS u, Candidate AS c WHERE c.email= '{0}' AND u.u_id=c.u_id", SendtoAddress);
        DataTable myTable = new DataTable();
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        myTable = myConnection.executeReturningQuery(query);
        DataRow[] rowArray = myTable.AsEnumerable().Take(1).ToArray();
        object[] objectArray = rowArray[0].ItemArray;
        String[] stringArray = Array.ConvertAll(objectArray, (p => Convert.ToString(p)));
        String body = stringArray[0] + stringArray[1];

        try
        {
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress, password),
                Timeout = 3000
            };
            MailMessage message = new MailMessage(fromAddress, toAddress, subject, body);
            smtp.Send(message);
        }
        catch (Exception ex)
        {
        }
        return stringArray[0];
    }
    public String recoverPassword2(String SendtoAddress)
    {
        String query = String.Format("SELECT u.u_name, u.passd FROM UserAcc AS u, Candidate AS c WHERE c.email= '{0}' AND u.u_id=c.u_id", SendtoAddress);
        DataTable myTable = new DataTable();
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        myTable = myConnection.executeReturningQuery(query);
        DataRow[] rowArray = myTable.AsEnumerable().Take(1).ToArray();
        object[] objectArray = rowArray[0].ItemArray;
        String[] stringArray = Array.ConvertAll(objectArray, (p => Convert.ToString(p)));
        String body = String.Format("Your login credentials for the project by DILIGENTIA are as follows, <br /><br /><b>Username:</b> {0}<br /><b>Password:</b> {1}", stringArray[0], stringArray[1]);
        //String body = stringArray[0] + stringArray[1];

        MailMessage msg = new MailMessage();
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
        try
        {
            msg.Subject = "Recover Password";
            msg.Body = body;
            msg.From = new MailAddress("lilylakshi@gmail.com");
            msg.To.Add(SendtoAddress);
            msg.IsBodyHtml = true;
            client.Host = "smtp.gmail.com";
            System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("lilylakshi@gmail.com", "diligentia");
            client.Port = int.Parse("587");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicauthenticationinfo;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(msg);
            return "Sucessful Completion";
        }
        catch (Exception ex)
        {
            return (ex.Message);
        }
    }

    public String sendEmailForInterview(String applicantId, String positionId, String time, String date, String venue)
    {
        String applicantName;
        String jobPosition;
        String employer;
        String today;
        String sendToAddress;

        today = (DateTime.Now).ToString("yyyy-MM-dd");


        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand getFirstName = new SqlCommand("SELECT f_name FROM Candidate WHERE u_id = @applicantId", myConnection);
        getFirstName.Parameters.Add("applicantId", SqlDbType.Int).Value = applicantId;

        SqlCommand getEmail = new SqlCommand("SELECT email FROM Candidate WHERE u_id = @applicantId", myConnection);
        getEmail.Parameters.Add("applicantId", SqlDbType.Int).Value = applicantId;

        SqlCommand getJobDetails = new SqlCommand("SELECT title, employer FROM JobPosition WHERE positionId = @positionId", myConnection);
        getJobDetails.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;

        applicantName = getFirstName.ExecuteScalar().ToString();
        sendToAddress = getEmail.ExecuteScalar().ToString();

        myReader = getJobDetails.ExecuteReader();
        myReader.Read();
        Object[] tempArray = new Object[myReader.FieldCount];
        myReader.GetValues(tempArray);
        jobPosition = tempArray[0].ToString();
        employer = tempArray[1].ToString();

        String body = String.Format("Dear {0},<br />We are excited to inform you that you have been selected to be interviewd for the job position {1} by {2}." +
                                    "<br />You are requested to be present at {3} on {4} at {5}.<br /><br />Your faithfully,<br />{6}, {7}",
                                    applicantName, jobPosition, employer, time, date, venue, employer, today);

        myConnection.Close();

        MailMessage msg = new MailMessage();
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
        try
        {
            msg.Subject = String.Format("Request to Be Preset for Interview for Position, {0} by {1}", jobPosition, employer);
            msg.Body = body;
            msg.From = new MailAddress("lilylakshi@gmail.com");
            msg.To.Add(sendToAddress);
            msg.IsBodyHtml = true;
            client.Host = "smtp.gmail.com";
            System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("lilylakshi@gmail.com", "diligentia");
            client.Port = int.Parse("587");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicauthenticationinfo;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(msg);
            return "Sucessful Completion";
        }
        catch (Exception ex)
        {
            return (ex.Message);
        }
    }

    public String sendEmailToReportAProblem(String userID, String problem, String description) {

        String applicantName;
        String applicantEmail;
        String applicantProblem;
        String applicantDescription;
        String today;

        applicantProblem = problem;
        applicantDescription = description;

        today = (DateTime.Now).ToString("yyyy-MM-dd");

        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand getFirstName = new SqlCommand("SELECT f_name FROM Candidate WHERE u_id = @userID", myConnection);
        getFirstName.Parameters.Add("userID", SqlDbType.Int).Value = userID;

        SqlCommand getEmail = new SqlCommand("SELECT email FROM Candidate WHERE u_id = @userID", myConnection);
        getEmail.Parameters.Add("userID", SqlDbType.Int).Value = userID;

        applicantName = getFirstName.ExecuteScalar().ToString();
        applicantEmail = getEmail.ExecuteScalar().ToString();

        String body = String.Format("User - {0}<br />User E-mail - {1}<br />Problem - {2}<br />Details - {3}<br />Date - {4}<br />", applicantName, applicantEmail, applicantProblem, applicantDescription, today);

        myConnection.Close();

        MailMessage msg = new MailMessage();
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
        try
        {
            msg.Subject = String.Format("To report a problem by {0}", applicantName);
            msg.Body = body;
            msg.From = new MailAddress("lilylakshi@gmail.com");
            msg.To.Add("lileelakshi@gmail.com");
            msg.IsBodyHtml = true;
            client.Host = "smtp.gmail.com";
            System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("lilylakshi@gmail.com", "diligentia");
            client.Port = int.Parse("587");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicauthenticationinfo;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(msg);
            return "Sucessful Completion";
        }
        catch (Exception ex)
        {
            return (ex.Message);
        }
    }

    public String sendEmailToReportAProblem2(String userID, String problem, String description)
    {

        String applicantName;
        String applicantEmail;
        String applicantProblem;
        String applicantDescription;
        String today;

        applicantProblem = problem;
        applicantDescription = description;

        today = (DateTime.Now).ToString("yyyy-MM-dd");

        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand getFirstName = new SqlCommand("SELECT f_name FROM Manager WHERE u_id = @userID", myConnection);
        getFirstName.Parameters.Add("userID", SqlDbType.Int).Value = userID;

        SqlCommand getEmail = new SqlCommand("SELECT prs_email FROM Manager WHERE u_id = @userID", myConnection);
        getEmail.Parameters.Add("userID", SqlDbType.Int).Value = userID;

        applicantName = getFirstName.ExecuteScalar().ToString();
        applicantEmail = getEmail.ExecuteScalar().ToString();

        String body = String.Format("User - {0}<br />User E-mail - {1}<br />Problem - {2}<br />Details - {3}<br />Date - {4}<br />", applicantName, applicantEmail, applicantProblem, applicantDescription, today);

        myConnection.Close();

        MailMessage msg = new MailMessage();
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
        try
        {
            msg.Subject = String.Format("To report a problem by {0}", applicantName);
            msg.Body = body;
            msg.From = new MailAddress("lilylakshi@gmail.com");
            msg.To.Add("lileelakshi@gmail.com");
            msg.IsBodyHtml = true;
            client.Host = "smtp.gmail.com";
            System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("lilylakshi@gmail.com", "diligentia");
            client.Port = int.Parse("587");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicauthenticationinfo;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(msg);
            return "Sucessful Completion";
        }
        catch (Exception ex)
        {
            return (ex.Message);
        }
    }

    public String sendPasswordChangeConfirmation(String userID)
    {
        String userType;
        String today;
        String userName;
        String userEmail;


        today = (DateTime.Now).ToString("yyyy-MM-dd");

        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand getUserType = new SqlCommand("SELECT role FROM UserAcc  WHERE u_id = @userID", myConnection);
        getUserType.Parameters.Add("userID", SqlDbType.Int).Value = userID;

        userType = getUserType.ExecuteScalar().ToString();

        if (userType.Equals("1"))
        {
            SqlCommand getFirstName = new SqlCommand("SELECT f_name FROM Manager WHERE u_id = @userID", myConnection);
            getFirstName.Parameters.Add("userID", SqlDbType.Int).Value = userID;

            SqlCommand getEmail = new SqlCommand("SELECT prs_email FROM Manager WHERE u_id = @userID", myConnection);
            getEmail.Parameters.Add("userID", SqlDbType.Int).Value = userID;

            userName = getFirstName.ExecuteScalar().ToString();
            userEmail = getEmail.ExecuteScalar().ToString();
        }
        else
        {
            SqlCommand getFirstName = new SqlCommand("SELECT f_name FROM Candidate WHERE u_id = @userID", myConnection);
            getFirstName.Parameters.Add("userID", SqlDbType.Int).Value = userID;

            SqlCommand getEmail = new SqlCommand("SELECT email FROM Candidate WHERE u_id = @userID", myConnection);
            getEmail.Parameters.Add("userID", SqlDbType.Int).Value = userID;

            userName = getFirstName.ExecuteScalar().ToString();
            userEmail = getEmail.ExecuteScalar().ToString();


        }

        String body = String.Format("Hi {0},<br />Your account password was changed on {1}.<br />If you did this, you can safely disregard this email.<br />If you didn't do this, please secure your account.", userName, today);

        myConnection.Close();

        MailMessage msg = new MailMessage();
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
        try
        {
            msg.Subject = String.Format("To confirm password change by {0}", userName);
            msg.Body = body;
            msg.From = new MailAddress("lilylakshi@gmail.com");
            msg.To.Add(userEmail);
            msg.IsBodyHtml = true;
            client.Host = "smtp.gmail.com";
            System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("lilylakshi@gmail.com", "diligentia");
            client.Port = int.Parse("587");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicauthenticationinfo;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(msg);
            return "Sucessful Completion";
        }
        catch (Exception ex)
        {
            return (ex.Message);
        }
    }

    public String warnUserByEmail(String userId)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlCommand getEmail;
        String sentToAddress = "";
        myConnection.Open();

        SqlCommand getUserType = new SqlCommand("SELECT role FROM UserAcc  WHERE u_id = @userID", myConnection);
        getUserType.Parameters.Add("userID", SqlDbType.Int).Value = userId;

        String userRole = getUserType.ExecuteScalar().ToString();
        if (userRole.Equals("0"))
        {
            getEmail = new SqlCommand("SELECT email FROM Candidate WHERE u_id = @userId", myConnection);
            getEmail.Parameters.Add("userId", SqlDbType.Int).Value = userId;
            sentToAddress = getEmail.ExecuteScalar().ToString();
            myConnection.Close();
        }
        else if (userRole.Equals("1"))
        {
            getEmail = new SqlCommand("SELECT prs_email FROM Manager WHERE u_id = @userId", myConnection);
            getEmail.Parameters.Add("userId", SqlDbType.Int).Value = userId;
            sentToAddress = getEmail.ExecuteScalar().ToString();
            myConnection.Close();
        }

        MailMessage msg = new MailMessage();
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
        try
        {
            msg.Subject = "Warning of Improper Behaviour";
            msg.Body = "Dear user,<br />The admin of the site DILIGENTIA has received complaints about your behavior in the site. Please not that if you continue to receive complaints, you will be banned from the site without any further notice.<br /><br />Admin,<br />DILIGENTIA.";
            msg.From = new MailAddress("lilylakshi@gmail.com");
            msg.To.Add(sentToAddress);
            msg.IsBodyHtml = true;
            client.Host = "smtp.gmail.com";
            System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("lilylakshi@gmail.com", "diligentia");
            client.Port = int.Parse("587");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicauthenticationinfo;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(msg);
            return "Sucessful Completion";
        }
        catch (Exception ex)
        {
            return (ex.Message);
        }
    }


    public String deleteAccountConfirmation(String userID)
    {
        String userType;
        String today;
        String userName;
        String userEmail;


        today = (DateTime.Now).ToString("yyyy-MM-dd");

        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand getUserType = new SqlCommand("SELECT role FROM UserAcc  WHERE u_id = @userID", myConnection);
        getUserType.Parameters.Add("userID", SqlDbType.Int).Value = userID;

        userType = getUserType.ExecuteScalar().ToString();

        if (userType.Equals("1"))
        {
            SqlCommand getFirstName = new SqlCommand("SELECT f_name FROM Manager WHERE u_id = @userID", myConnection);
            getFirstName.Parameters.Add("userID", SqlDbType.Int).Value = userID;

            SqlCommand getEmail = new SqlCommand("SELECT prs_email FROM Manager WHERE u_id = @userID", myConnection);
            getEmail.Parameters.Add("userID", SqlDbType.Int).Value = userID;

            userName = getFirstName.ExecuteScalar().ToString();
            userEmail = getEmail.ExecuteScalar().ToString();
        }
        else
        {
            SqlCommand getFirstName = new SqlCommand("SELECT f_name FROM Candidate WHERE u_id = @userID", myConnection);
            getFirstName.Parameters.Add("userID", SqlDbType.Int).Value = userID;

            SqlCommand getEmail = new SqlCommand("SELECT email FROM Candidate WHERE u_id = @userID", myConnection);
            getEmail.Parameters.Add("userID", SqlDbType.Int).Value = userID;

            userName = getFirstName.ExecuteScalar().ToString();
            userEmail = getEmail.ExecuteScalar().ToString();


        }

        String body = String.Format("Hi {0},<br />Your account has been removed from over application on {1}.", userName, today);

        myConnection.Close();

        MailMessage msg = new MailMessage();
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
        try
        {
            msg.Subject = String.Format("To inform about removing of your account from our application");
            msg.Body = body;
            msg.From = new MailAddress("lilylakshi@gmail.com");
            msg.To.Add(userEmail);
            msg.IsBodyHtml = true;
            client.Host = "smtp.gmail.com";
            System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("lilylakshi@gmail.com", "diligentia");
            client.Port = int.Parse("587");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicauthenticationinfo;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(msg);
            return "Sucessful Completion";
        }
        catch (Exception ex)
        {
            return (ex.Message);
        }
    }

}