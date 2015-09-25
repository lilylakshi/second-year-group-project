using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// This class views a list of jobs  the applicant has mentioned. 
/// Views a list of positions the applicant has applied for.
/// </summary>
public class JobsModule
{
    private static String connectionString = String.Format("Data Source={0}; Initial Catalog={1}; Persist Security Info=True; User ID={2}; Password={3};", "LILY-PC", "projectdb1", "admin", "123");
    private String userId;

    private static String[] jobType = { "Test",
                                        "3D Animation or Graphic Design",
                                        "Customer Service",
                                        "Data Entry",
                                        "Database",
                                        "Electronics Technician or Engineer",
                                        "Engineer",
                                        "Tester",
                                        "Hardware",
                                        "Networking or System Administrator",
                                        "Programmer or Software Developer",
                                        "Quality Assurance (QA)",
                                        "System Analyst",
                                        "Repair and Fix",
                                        "Sales",
                                        "Technical Support (Technician or Help Desk)",
                                        "Technical Writing",
                                        "Security Expert",
                                        "Webmaster or Web Designer"};

    public static String[] qualityType = {"Computer Language", "SoftSkill", "Degree"};

	public JobsModule()
	{
	}

    public void setUserId(String userId)
    {
        this.userId = userId;
    }

    public DataTable viewMentionedJobs()
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT jobType AS 'Job Type', job AS Job FROM SeekingJob WHERE u_id = @u_id", myConnection);
        myGetCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userId;
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myConnection.Close();

        return this.formatSeekingJobTable(myDataTable);
    }

    public String deleteApplicantsMentionedJob(String job)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myDeleteCommand = new SqlCommand("DELETE FROM SeekingJob WHERE u_id = @u_id AND jobLowerCase = @job", myConnection);
        myDeleteCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userId;
        myDeleteCommand.Parameters.Add("job", SqlDbType.VarChar).Value = job;
        myDeleteCommand.ExecuteNonQuery();
        myConnection.Close();

        return "Job deleted";
    }

    public DataTable formatSeekingJobTable(DataTable originalTable)
    {
        DataTable clonedTable = originalTable.Clone();

        if (originalTable.Columns.Contains("job Type"))
        {
            clonedTable.Columns["job Type"].DataType = typeof(String);
        }

        foreach (DataRow row in originalTable.Rows)
        {
            clonedTable.ImportRow(row);
        }

        if (clonedTable.Columns.Contains("job Type"))
        {
            foreach (DataRow row in clonedTable.Rows)
            {
                row["job Type"] = jobType[int.Parse((String)row["job Type"])];
            }
        }


        return clonedTable;
    }

    public String insertJobPosition(String creatorsId, String jobType, String employer, String title, String description, String salary, String minAge, String maxAge, String experience,
        String firstQualityType, String firstQuality, String secondQualityType, String secondQuality, String thirdQualityType, String thirdQuality)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myInsertCommand = new SqlCommand("INSERT INTO JobPosition(creatorsId, jobType, employer, title, description, salary, minAge, maxAge, experience, " + 
            "firstQualityType, firstQuality, firstQualityLower, secondQualityType, secondQuality, secondQualityLower, thirdQualityType, thirdQuality, thirdQualityLower)" + 
            " VALUES (@creatorsId, @jobType, @employer, @title, @description, @salary, @minAge, @maxAge, @experience, @firstQualityType, @firstQuality, @firstQualityLower, @secondQualityType, @secondQuality, @secondQualityLower, @thirdQualityType, @thirdQuality, @thirdQualityLower)", myConnection);
        myInsertCommand.Parameters.Add("creatorsId", SqlDbType.Int).Value = creatorsId;
        myInsertCommand.Parameters.Add("jobType", SqlDbType.Int).Value = jobType;
        myInsertCommand.Parameters.Add("employer", SqlDbType.VarChar).Value = employer;
        myInsertCommand.Parameters.Add("title", SqlDbType.VarChar).Value = title;
        myInsertCommand.Parameters.Add("description", SqlDbType.VarChar).Value = description;
        myInsertCommand.Parameters.Add("salary", SqlDbType.Int).Value = salary;
        myInsertCommand.Parameters.Add("minAge", SqlDbType.Int).Value = minAge;
        myInsertCommand.Parameters.Add("maxAge", SqlDbType.Int).Value = maxAge;
        myInsertCommand.Parameters.Add("experience", SqlDbType.Int).Value = experience;
        myInsertCommand.Parameters.Add("firstQualityType", SqlDbType.Int).Value = firstQualityType;
        myInsertCommand.Parameters.Add("firstQuality", SqlDbType.VarChar).Value = firstQuality;
        myInsertCommand.Parameters.Add("firstQualityLower", SqlDbType.VarChar).Value = (firstQuality.Replace(" ", String.Empty)).ToLower();
        myInsertCommand.Parameters.Add("secondQualityType", SqlDbType.Int).Value = secondQualityType;
        myInsertCommand.Parameters.Add("secondQuality", SqlDbType.VarChar).Value = secondQuality;
        myInsertCommand.Parameters.Add("secondQualityLower", SqlDbType.VarChar).Value = (secondQuality.Replace(" ", String.Empty)).ToLower(); ;
        myInsertCommand.Parameters.Add("thirdQualityType", SqlDbType.Int).Value = thirdQualityType;
        myInsertCommand.Parameters.Add("thirdQuality", SqlDbType.VarChar).Value = thirdQuality;
        myInsertCommand.Parameters.Add("thirdQualityLower", SqlDbType.VarChar).Value = (thirdQuality.Replace(" ", String.Empty)).ToLower(); ;

        myInsertCommand.ExecuteNonQuery();

        myConnection.Close();

        return "Job position inserted";
    }

    public DataTable getEmployersJobPositions()
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT positionId, title AS Title, jobType AS 'Job Type' FROM JobPosition WHERE creatorsId = @creatorsId", myConnection);
        myGetCommand.Parameters.Add("creatorsId", SqlDbType.Int).Value = userId;
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myConnection.Close();

        return this.formatSeekingJobTable(myDataTable);
    }

    public String deleteJobPosition(String positionId)
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myDeleteCommand = new SqlCommand("DELETE FROM JobPosition WHERE positionId = @positionId", myConnection);
        myDeleteCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;
        myDeleteCommand.ExecuteNonQuery();
        myConnection.Close();

        return "Job position deleted";
    }

    public Dictionary<String, String> getJobPosition(String positionId)
    {
        Dictionary<String, String> jobPosition = new Dictionary<string,string>();

        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT positionId, creatorsId, jobType, employer, title, description, firstQualityType, firstQuality, secondQualityType, secondQuality," + 
            "thirdQualityType, thirdQuality, salary, minAge, maxAge, experience FROM JobPosition WHERE positionId = @positionId", myConnection);
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;
        myReader = myGetCommand.ExecuteReader();

        Object[] array = new Object[myReader.FieldCount];

        myReader.Read();

        myReader.GetValues(array);

        jobPosition["positionId"] = array[0].ToString();
        jobPosition["creatorsId"] = array[1].ToString();
        jobPosition["jobType"] = jobType[int.Parse(array[2].ToString())];
        jobPosition["employer"] = array[3].ToString();
        jobPosition["title"] = array[4].ToString();
        jobPosition["description"] = array[5].ToString();
        jobPosition["firstQualityType"] = qualityType[int.Parse(array[6].ToString())];
        jobPosition["firstQuality"] = array[7].ToString();
        jobPosition["secondQualityType"] = qualityType[int.Parse(array[8].ToString())];
        jobPosition["secondQuality"] = array[9].ToString();
        jobPosition["thirdQualityType"] = qualityType[int.Parse(array[10].ToString())];
        jobPosition["thirdQuality"] = array[11].ToString();
        jobPosition["salary"] = array[12].ToString();
        jobPosition["minAge"] = array[13].ToString();
        jobPosition["maxAge"] = array[14].ToString();
        jobPosition["experience"] = array[15].ToString();


        myConnection.Close();

        return jobPosition;
    }

    public String enterApplicantForJobPosition(String applicantId, String positionId)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myInsertCommand = new SqlCommand("INSERT INTO UsersAppliedForJobPosition(positionId, u_id) VALUES(@positionId, @u_id)", myConnection);
        myInsertCommand.Parameters.Add("u_id", SqlDbType.Int).Value = applicantId;
        myInsertCommand.Parameters.Add("positionId", SqlDbType.VarChar).Value = positionId;
        myInsertCommand.ExecuteNonQuery();
        myConnection.Close();

        return "Applicant successfully inserted";
    }

    public DataTable getAppliedJobPositionsOfApplicant()
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT a.jobType AS 'job Type', a.title AS Title, a.employer AS Employer FROM JobPosition AS a, UsersAppliedForJobPosition AS b WHERE b.u_id = @applicantId AND a.positionId = b.positionId", myConnection);
        myGetCommand.Parameters.Add("applicantId", SqlDbType.Int).Value = userId;
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myReader.Close();
        myConnection.Close();

        return this.formatSeekingJobTable(myDataTable);
    }

    public String addRemark(String positionId, String u_id, String remark)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myInsertCommand = new SqlCommand("INSERT INTO JobPositionRemarks(positionId, u_id, remark) VALUES (@positionId, @u_id, @remark);", myConnection);
        myInsertCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;
        myInsertCommand.Parameters.Add("u_id", SqlDbType.Int).Value = u_id;
        myInsertCommand.Parameters.Add("remark", SqlDbType.VarChar).Value = remark;

        myInsertCommand.ExecuteNonQuery();
        myConnection.Close();

        return "Remark Inserted";
    }

    public bool doesJobBelongToUser(String currentUser, String positionId)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT creatorsId FROM JobPosition WHERE positionId = @positionId;", myConnection);
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;

        String creator = myGetCommand.ExecuteScalar().ToString();

        if (currentUser.Equals(creator))
        {
            return true;
        }
        return false;
    }
}