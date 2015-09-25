using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CVModule
/// </summary>
public class CVModule
{

    private static String connectionString = String.Format("Data Source={0}; Initial Catalog={1}; Persist Security Info=True; User ID={2}; Password={3};", "LILY-PC", "projectdb1", "admin", "123");
    
    private String fName, mName, lName, phone, email, school, number, street, town;
    private int gender, mStatus;
    private String dob;
    private String username;
    private String userID;
	public CVModule()
	{
	}

    public String createCV()
    {
        String query1 = String.Format("INSERT INTO [Candidate] ([u_id],[f_name],[m_name],[l_name],[dob],[gender],[maritual_status],[add_no],[add_street],[add_town],[email])" +
                        "VALUES({0}, '{1}', '{2}', '{3}', '{4}', {5}, {6}, '{7}', '{8}', '{9}', '{10}')", 
                        userID, fName, mName, lName, dob, gender, mStatus, number, street, town, email);

        String query2 = String.Format("INSERT INTO [PrsPhone]([u_id],[phone]) VALUES ({0}, '{1}')", userID, phone);
        String query3 = String.Format("INSERT INTO [CanSchool]([u_id],[school]) VALUES ({0}, '{1}')", userID, school);
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String msg = myConnection.executeNonReturningQuery(query1);
        String msg2 = myConnection.executeNonReturningQuery(query2);
        String msg3 = myConnection.executeNonReturningQuery(query3);
        return msg + msg2 + msg3;
    }
    public void setStrings(String fName, String mName, String lName, String phone, String email, String school, String number, String street, String town)
    {
        this.fName = fName; this.mName = mName; this.lName = lName; this.phone = phone;
        this.email = email; this.school = school; 
        this.number = number; this.street = street; this.town = town;
    }
    public void setints(int gender, int mStatus)
    {
        this.gender = gender; this.mStatus = mStatus;
    }
    public void setdob(String dob)
    {
        this.dob = dob;
    }
    public void setUsername(String username)
    {
        this.username = username;
    }

    public void setUserID(String userID)
    {
        this.userID = userID;
    }

    public DataTable getCV(String id)
    {
        DataTable myTable = new DataTable();
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String query = String.Format("SELECT c.f_name AS 'First Name' ,c.m_name AS 'Middle Name', c.l_name AS 'Last Name', c.dob AS 'Date of Birth', c.age AS 'Age', c.gender AS 'Gender', c.maritual_status AS 'Marital Status', c.add_no AS 'Number',c.add_street AS 'Street', c.add_town AS 'Town',c.email AS 'Email', p.phone AS 'Phone', s.school AS 'School'  FROM [Candidate] AS c, PrsPhone AS p, CanSchool AS s WHERE c.u_id=p.u_id AND c.u_id=s.u_id AND c.u_id={0}", id);
        myTable = myConnection.executeReturningQuery(query);
        return myTable;
    }

    
    // returns a List<String> which has a row of CV information of the user who has the given ID
    public String[] getDetailsToForm(String id)
    {
        DataTable myTable = new DataTable();
        myTable = this.getCV(id);
        DataRow[] rowArray = myTable.AsEnumerable().Take(1).ToArray();
        object[] objectArray = rowArray[0].ItemArray;
        String[] stringArray = Array.ConvertAll(objectArray, (p => Convert.ToString(p)));
        return stringArray;
    }
    
    public String UpdateCV()
    {
        String query1 = String.Format( "UPDATE [Candidate] SET [f_name] = '{0}', [m_name] = '{1}', [l_name] = '{2}', [dob] = '{3}', [gender] = {4}, [maritual_status] = {5}, [add_no] = '{6}', [add_street] = '{7}', [add_town] = '{8}', [email] = '{9}' WHERE u_id = {10}", 
                                                                fName, mName, lName, dob, gender, mStatus, number, street, town, email, userID);
        String query2 = String.Format("UPDATE [CanSchool] SET [school] = '{0}' WHERE u_id = {1}", school, userID);
        String query3 = String.Format("UPDATE [PrsPhone] SET [phone] = '{0}' WHERE u_id = {1}", phone, userID);
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String msg1 = myConnection.executeNonReturningQuery(query1);
        String msg2 = myConnection.executeNonReturningQuery(query2);
        String msg3 = myConnection.executeNonReturningQuery(query3);
        return msg1 + msg2 + msg3;
    }

    
    public void uploadImage(System.Web.UI.WebControls.FileUpload imageUploadControl)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        System.Drawing.Image myImage = System.Drawing.Image.FromStream(imageUploadControl.PostedFile.InputStream);
        myConnection.Open();
        
        SqlCommand myInsertCommand = new SqlCommand("INSERT INTO UserProfilePhoto(userId, photoData) VALUES(@userId, @photoData)", myConnection);
        myInsertCommand.Parameters.Add("photoData", SqlDbType.Image, 0).Value = new ImageModule().convertImageToByteArray(myImage, System.Drawing.Imaging.ImageFormat.Jpeg);
        myInsertCommand.Parameters.Add("userId", SqlDbType.Int).Value = userID;
        myInsertCommand.ExecuteNonQuery();
        myConnection.Close();
    }
    public String insertComputerLanguage(String language, String proficiency)
    {
        String languageLowerCase = (language.Replace(" ", String.Empty)).ToLower();
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String query = String.Format("INSERT INTO ComputerLanguage(u_id, languageLowerCase, language, proficiency) VALUES({0}, '{1}', '{2}', {3})", userID, languageLowerCase, language, proficiency);
        return myConnection.executeNonReturningQuery(query);
    }
    public String insertFirstDegree(String degree, String university, String year)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myInsertCommand = new SqlCommand("INSERT INTO FirstDegree(u_id, degreeLowerCase, degree, university, universityLowerCase, year) VALUES(@u_Id, @degreeLowerCase, @degree, @university, @universityLowerCase, @year)", myConnection);
        myInsertCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userID;
        myInsertCommand.Parameters.Add("degreeLowerCase", SqlDbType.VarChar).Value = (degree.Replace(" ", String.Empty)).ToLower();
        myInsertCommand.Parameters.Add("degree", SqlDbType.VarChar).Value = degree;
        myInsertCommand.Parameters.Add("university", SqlDbType.VarChar).Value = university;
        myInsertCommand.Parameters.Add("universityLowerCase", SqlDbType.VarChar).Value = (university.Replace(" ", String.Empty)).ToLower();
        myInsertCommand.Parameters.Add("year", SqlDbType.Int).Value = year;
        myInsertCommand.ExecuteNonQuery();
        myConnection.Close();
        return "Successfully inserted";
    }
    public String insertMastersDegree(String mastersDegree, String university, String year)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myInsertCommand = new SqlCommand("INSERT INTO MastersDegree(u_id, MastersDegreeLowerCase, MastersDegree, university, universityLowerCase, year) VALUES(@u_Id, @MastersDegreeLowerCase, @MastersDegree, @university, @universityLowerCase, @year)", myConnection);
        myInsertCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userID;
        myInsertCommand.Parameters.Add("MastersDegreeLowerCase", SqlDbType.VarChar).Value = (mastersDegree.Replace(" ", String.Empty)).ToLower();
        myInsertCommand.Parameters.Add("MastersDegree", SqlDbType.VarChar).Value = mastersDegree;
        myInsertCommand.Parameters.Add("university", SqlDbType.VarChar).Value = university;
        myInsertCommand.Parameters.Add("universityLowerCase", SqlDbType.VarChar).Value = (university.Replace(" ", String.Empty)).ToLower();
        myInsertCommand.Parameters.Add("year", SqlDbType.Int).Value = year;
        myInsertCommand.ExecuteNonQuery();
        myConnection.Close();
        return "Successfully inserted";
    }
    public String insertPersonalPhoneNumber(String phone)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myInsertCommand = new SqlCommand("INSERT INTO PrsPhone(u_id, phone) VALUES(@u_id, @phone)", myConnection);
        myInsertCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userID;
        myInsertCommand.Parameters.Add("phone", SqlDbType.VarChar).Value = phone;
        myInsertCommand.ExecuteNonQuery();
        myConnection.Close();
        return "Successfully inserted";
    }
    public String insertPhd(String subject, String university, String year)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myInsertCommand = new SqlCommand("INSERT INTO phdDegree(u_id, subjectLowerCase, subject, university, universityLowerCase, year) VALUES(@u_Id, @subjectLowerCase, @subject, @university, @universityLowerCase, @year)", myConnection);
        myInsertCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userID;
        myInsertCommand.Parameters.Add("subjectLowerCase", SqlDbType.VarChar).Value = (subject.Replace(" ", String.Empty)).ToLower();
        myInsertCommand.Parameters.Add("subject", SqlDbType.VarChar).Value = subject;
        myInsertCommand.Parameters.Add("university", SqlDbType.VarChar).Value = university;
        myInsertCommand.Parameters.Add("universityLowerCase", SqlDbType.VarChar).Value = (university.Replace(" ", String.Empty)).ToLower();
        myInsertCommand.Parameters.Add("year", SqlDbType.Int).Value = year;
        myInsertCommand.ExecuteNonQuery();
        myConnection.Close();
        return "Successfully inserted";
    }
    public String insertSoftSkill(String softSkill)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myInsertCommand = new SqlCommand("INSERT INTO SoftSkill(u_id, softSkillLowerCase, softSkill) VALUES(@u_Id, @softSkillLowerCase, @softSkill)", myConnection);
        myInsertCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userID;
        myInsertCommand.Parameters.Add("softSkillLowerCase", SqlDbType.VarChar).Value = (softSkill.Replace(" ", String.Empty)).ToLower();
        myInsertCommand.Parameters.Add("softSkill", SqlDbType.VarChar).Value = softSkill;
        myInsertCommand.ExecuteNonQuery();
        myConnection.Close();
        return "Successfully inserted";
    }
    public String uploadPdfCv(System.Web.UI.WebControls.FileUpload pdfUploadControl)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        byte[] myByteArray = new byte[pdfUploadControl.PostedFile.ContentLength];
        myByteArray = pdfUploadControl.FileBytes;

        SqlCommand myInsertCommand = new SqlCommand("INSERT INTO PDFCV(u_id, cvData) VALUES(@u_Id, @cvData)", myConnection);
        myInsertCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userID;
        myInsertCommand.Parameters.Add("cvData", SqlDbType.Image).Value = myByteArray;
        myInsertCommand.ExecuteNonQuery();
        myConnection.Close();

        return "PDF successfully uploaded";
    }
    public DataTable getFirstDegree()
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand mySelectCommand = new SqlCommand("SELECT degree, year FROM FirstDegree WHERE u_id = @u_id ORDER BY year", myConnection);
        mySelectCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userID;

        myDataTable.Load(mySelectCommand.ExecuteReader());
        
        return myDataTable;
    }
    public DataTable getMastersDegree()
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand mySelectCommand = new SqlCommand("SELECT mastersDegree, year FROM MastersDegree WHERE u_id = @u_id ORDER BY year", myConnection);
        mySelectCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userID;

        myDataTable.Load(mySelectCommand.ExecuteReader());

        return myDataTable;
    }
    public DataTable getPhd()
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand mySelectCommand = new SqlCommand("SELECT subject, year FROM phdDegree WHERE u_id = @u_id ORDER BY year", myConnection);
        mySelectCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userID;

        myDataTable.Load(mySelectCommand.ExecuteReader());

        return myDataTable;
    }
    public DataTable getSoftSkill()
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand mySelectCommand = new SqlCommand("SELECT softSkill FROM SoftSkill WHERE u_id = @u_id", myConnection);
        mySelectCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userID;

        myDataTable.Load(mySelectCommand.ExecuteReader());

        return myDataTable;
    }
    public DataTable getPhoneNumbers()
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand mySelectCommand = new SqlCommand("SELECT phone FROM PrsPhone WHERE u_id = @u_id", myConnection);
        mySelectCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userID;

        myDataTable.Load(mySelectCommand.ExecuteReader());

        return myDataTable;
    }
    public String insertSeekingJob(String job, String jobType)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myInsertCommand = new SqlCommand("INSERT INTO SeekingJob(u_id, jobLowerCase, job, jobType) VALUES (@u_id, @jobLowerCase, @job, @jobType)", myConnection);
        myInsertCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userID;
        myInsertCommand.Parameters.Add("jobLowerCase", SqlDbType.VarChar).Value = (job.Replace(" ", String.Empty)).ToLower();
        myInsertCommand.Parameters.Add("job", SqlDbType.VarChar).Value = job;
        myInsertCommand.Parameters.Add("jobType", SqlDbType.VarChar).Value = jobType;

        myInsertCommand.ExecuteNonQuery();
        myConnection.Close();

        return "Seeking job successfully inserted";
    }
    public DataTable getSeekingJobs()
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand mySelectCommand = new SqlCommand("SELECT job FROM SeekingJob WHERE u_id = @u_id", myConnection);
        mySelectCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userID;

        myDataTable.Load(mySelectCommand.ExecuteReader());

        return myDataTable;
    }
}