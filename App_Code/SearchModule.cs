using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SearchModule
/// </summary>
public class SearchModule
{
    private static String connectionString = String.Format("Data Source={0}; Initial Catalog={1}; Persist Security Info=True; User ID={2}; Password={3};", "LILY-PC", "projectdb1", "admin", "123");
	public SearchModule()
	{
	}

    public DataTable searchApplicantsByName(String keyword)
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT a.u_id, f_name + ' ' + m_name + ' '+ l_name AS Name, gender AS Gender, maritual_status AS 'Marital Status' FROM UserAcc AS a, Candidate WHERE Candidate.u_id = a.u_id AND f_name + ' ' + m_name + ' '+ l_name LIKE @keyword;", myConnection);
        myGetCommand.Parameters.Add("keyword", SqlDbType.VarChar).Value = "%" + keyword + "%";
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myConnection.Close();

        return this.getTableFormatted(myDataTable);
    }

    public DataTable searchApplicantsByComputerLanguage(String keyword)
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT a.u_id, f_name + ' ' + m_name + ' '+ l_name AS Name, c.language AS Language,  c.proficiency AS Proficiency, gender AS Gender, maritual_status AS 'Marital Status' FROM UserAcc AS a, Candidate, ComputerLanguage AS c WHERE Candidate.u_id = a.u_id AND a.u_id = c.u_id AND c.languageLowerCase LIKE @keyword;", myConnection);
        myGetCommand.Parameters.Add("keyword", SqlDbType.VarChar).Value = "%" + keyword + "%";
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myConnection.Close();

        return this.getTableFormatted(myDataTable);
    }

    public DataTable searchApplicantsBySoftSkill(String keyword)
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT a.u_id, f_name + ' ' + m_name + ' '+ l_name AS Name, s.softSkill AS 'Soft Skill', gender AS Gender, maritual_status AS 'Marital Status' FROM UserAcc AS a, Candidate, SoftSkill AS s WHERE Candidate.u_id = a.u_id AND a.u_id = s.u_id AND s.softSkillLowerCase LIKE @keyword;", myConnection);
        myGetCommand.Parameters.Add("keyword", SqlDbType.VarChar).Value = "%" + keyword + "%";
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myConnection.Close();

        return this.getTableFormatted(myDataTable);
    }
    public DataTable searchApplicantsByJob(String keyword, String jobType)
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT a.u_id, f_name + ' ' + m_name + ' '+ l_name AS Name, s.job AS 'Seeking Job', gender AS Gender FROM UserAcc AS a, Candidate, SeekingJob AS s WHERE Candidate.u_id = a.u_id AND a.u_id = s.u_id AND s.jobLowerCase LIKE @keyword AND jobType = @jobType;", myConnection);
        myGetCommand.Parameters.Add("keyword", SqlDbType.VarChar).Value = "%" + keyword + "%";
        myGetCommand.Parameters.Add("jobType", SqlDbType.VarChar).Value = jobType;
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myConnection.Close();

        return this.getTableFormatted(myDataTable);
    }
    public DataTable searchApplicantsByJob(String keyword)
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT a.u_id, f_name + ' ' + m_name + ' '+ l_name AS Name, s.job AS 'Seeking Job', gender AS Gender FROM UserAcc AS a, Candidate, SeekingJob AS s WHERE Candidate.u_id = a.u_id AND a.u_id = s.u_id AND s.jobLowerCase LIKE @keyword;", myConnection);
        myGetCommand.Parameters.Add("keyword", SqlDbType.VarChar).Value = "%" + keyword + "%";
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myConnection.Close();

        return this.getTableFormatted(myDataTable);
    }

    public DataTable getTableFormatted(DataTable originalTable)
    {
        DataTable clonedTable = originalTable.Clone();

        if (originalTable.Columns.Contains("Gender"))
        {
            clonedTable.Columns["Gender"].DataType = typeof(String);
        }
        if (originalTable.Columns.Contains("Marital Status"))
        {
            clonedTable.Columns["Marital Status"].DataType = typeof(String);
        }
        if (originalTable.Columns.Contains("Proficiency"))
        {
            clonedTable.Columns["Proficiency"].DataType = typeof(String);
        }

        foreach (DataRow row in originalTable.Rows)
        {
            clonedTable.ImportRow(row);
        }
        if (originalTable.Columns.Contains("Gender"))
        {
            foreach (DataRow row in clonedTable.Rows)
            {
                if (row["Gender"].ToString().Equals("False"))
                {
                    row["Gender"] = "Male";
                }
                else
                {
                    row["Gender"] = "Female";
                }
            }
        }
        if (originalTable.Columns.Contains("Marital Status"))
        {
            foreach (DataRow row in clonedTable.Rows)
            {
                if (row["Marital Status"].ToString().Equals("False"))
                {
                    row["Marital Status"] = "Single";
                }
                else
                {
                    row["Marital Status"] = "Married";
                }
            }
        }
        if (originalTable.Columns.Contains("Proficiency"))
        {
            foreach (DataRow row in clonedTable.Rows)
            {
                if (row["Proficiency"].ToString().Equals("0"))
                {
                    row["Proficiency"] = "Beginner";
                }
                else if(row["Proficiency"].ToString().Equals("1"))
                {
                    row["Proficiency"] = "Intermediate";
                } 
                else 
                {
                    row["Proficiency"] = "Expert";
                }
            }
        }
        return clonedTable;
    }

    public DataTable searchJobPositionByTitle(String keyword)
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT positionId, title AS Title, jobType AS 'Job Type' FROM JobPosition WHERE title LIKE @keyword;", myConnection);
        myGetCommand.Parameters.Add("keyword", SqlDbType.VarChar).Value = "%" + keyword + "%";
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myConnection.Close();

        return new JobsModule().formatSeekingJobTable(myDataTable);
    }

    public DataTable listOfApplicantsForJobPosition(String positionId)
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT a.u_id, b.f_name + ' ' + b.m_name + ' '+ b.l_name AS Name FROM UsersAppliedForJobPosition AS a, Candidate AS b WHERE a.positionId = @positionId AND a.u_id = b.u_id;", myConnection);
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myConnection.Close();

        return myDataTable;
    }

    public DataTable ratedListOfApplicantsForJobPosition(String positionId)
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT a.u_id, b.f_name + ' ' + b.m_name + ' '+ b.l_name AS Name, c.rating AS Rating FROM UsersAppliedForJobPosition AS a, Candidate AS b, ApplicantsRatings AS c WHERE a.positionId = @positionId AND a.positionId = c.positionId AND a.u_id = b.u_id AND a.u_id = c.u_id;", myConnection);
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myConnection.Close();

        return myDataTable;
    }

    public DataTable ratedListOfApplicantsForJobPosition2(String positionId)
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT a.u_id, b.f_name + ' ' + b.m_name + ' '+ b.l_name AS Name, c.rating AS Rating, d.remark FROM UsersAppliedForJobPosition AS a, Candidate AS b, ApplicantsRatings AS c, JobPositionRemarks AS d WHERE a.positionId = @positionId AND a.positionId = c.positionId AND a.u_id = b.u_id AND a.u_id = c.u_id AND d.positionId = a.positionId AND a.u_id = d.u_id ORDER BY c.rating DESC;", myConnection);
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myConnection.Close();

        return myDataTable;
    }

    public DataTable ratedListOfApplicantsForJobPosition3(String positionId)
    {
        DataTable myDataTable = new DataTable();

        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT a.u_id, b.f_name + ' ' + b.m_name + ' '+ b.l_name AS Name, c.rating AS Rating, d.remark FROM UsersAppliedForJobPosition AS a, Candidate AS b, ApplicantsRatings AS c, JobPositionRemarks AS d WHERE a.positionId = @positionId AND a.positionId = c.positionId AND a.u_id = b.u_id AND a.u_id = c.u_id AND d.positionId = a.positionId AND a.u_id = d.u_id ORDER BY c.rating DESC;", myConnection);
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myConnection.Close();

        return myDataTable;
    }
}