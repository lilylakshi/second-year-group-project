using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// RatingModule rates applicants of a job position created by an employer.
/// </summary>
public class RatingModule
{
    private static String connectionString = String.Format("Data Source={0}; Initial Catalog={1}; Persist Security Info=True; User ID={2}; Password={3};", "LILY-PC", "projectdb1", "admin", "123");

    private int positionId;
    private int jobType;
    private int mostComputerLanguages;
    private int mostSoftSkills;
    private int mostFirstDegrees;
    private int mostMastersDegrees;
    private int mostPhdDegrees;

    private int[] applicantsArray;

    public int doThings(int userId)
    {
        return 0;
    }

    public RatingModule(String positionId)
    {
        this.positionId = int.Parse(positionId);

        mostComputerLanguages = 0;
        mostSoftSkills = 0;
        mostFirstDegrees = 0;
        mostMastersDegrees = 0;
        mostPhdDegrees = 0;

        this.setApplicantsArray();

        this.getMostSoftSkills();
        this.getMostComputerLanguages();
        this.getMostFirstDegrees();
        this.getMostMastersDegrees();
        this.getMostPhdDegrees();

        this.deletePrevRatings();
        this.initiateRating();

    }

    private String getFirstQuality()
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT firstQualityLower FROM JobPosition WHERE positionId = @positionId;", myConnection);
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;

        String quality;
        quality = myGetCommand.ExecuteScalar().ToString();
        myConnection.Close();

        return quality;
    }
    private String getSecondQuality()
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT secondQualityLower FROM JobPosition WHERE positionId = @positionId;", myConnection);
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;

        String quality;
        quality = myGetCommand.ExecuteScalar().ToString();
        myConnection.Close();

        return quality;
    }
    private String getThirdQuality()
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT thirdQualityLower FROM JobPosition WHERE positionId = @positionId;", myConnection);
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;

        String quality;
        quality = myGetCommand.ExecuteScalar().ToString();
        myConnection.Close();

        return quality;
    }

    private void setApplicantsArray()
    {
        List<int> myList = new List<int>();

        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT u_id FROM UsersAppliedForJobPosition WHERE positionId = @positionId;", myConnection);
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;
        myReader = myGetCommand.ExecuteReader();

        while (myReader.Read())
        {
            myList.Add(myReader.GetInt32(0));
        }
        myReader.Close();
        myConnection.Close();

        applicantsArray = myList.ToArray();
    }


    private int getMostSoftSkills()
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT COUNT(a.u_id) as c, a.u_id FROM SoftSkill AS a, UsersAppliedForJobPosition AS b WHERE a.u_id = b.u_id AND b.positionId = @positionId GROUP BY a.u_id ORDER BY c DESC;", myConnection);
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;
        try
        {
            mostSoftSkills = int.Parse(myGetCommand.ExecuteScalar().ToString());
        }
        catch (Exception ex)
        {
            mostSoftSkills = 1;
        }

        myConnection.Close();

        return mostSoftSkills;
    }

    private int getMostComputerLanguages()
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT COUNT(a.u_id) as c, a.u_id FROM ComputerLanguage AS a, UsersAppliedForJobPosition AS b WHERE a.u_id = b.u_id AND b.positionId = @positionId GROUP BY a.u_id ORDER BY c DESC;", myConnection);
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;
        try
        {
            mostComputerLanguages = int.Parse(myGetCommand.ExecuteScalar().ToString());
        }
        catch (Exception ex)
        {
            mostComputerLanguages = 1;
        }

        myConnection.Close();

        return mostComputerLanguages;
    }

    private int getMostFirstDegrees()
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT COUNT(a.u_id) as c, a.u_id FROM FirstDegree AS a, UsersAppliedForJobPosition AS b WHERE a.u_id = b.u_id AND b.positionId = @positionId GROUP BY a.u_id ORDER BY c DESC;", myConnection);
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;
        try
        {
            mostFirstDegrees = int.Parse(myGetCommand.ExecuteScalar().ToString());
        }
        catch (Exception ex)
        {
            mostFirstDegrees = 1;
        }

        myConnection.Close();

        return mostFirstDegrees;
    }

    private int getMostMastersDegrees()
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT COUNT(a.u_id) as c, a.u_id FROM MastersDegree AS a, UsersAppliedForJobPosition AS b WHERE a.u_id = b.u_id AND b.positionId = @positionId GROUP BY a.u_id ORDER BY c DESC;", myConnection);
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;
        try
        {
            mostMastersDegrees = int.Parse(myGetCommand.ExecuteScalar().ToString());
        }
        catch (Exception ex)
        {
            mostMastersDegrees = 1;
        }

        myConnection.Close();

        return mostMastersDegrees;
    }

    private int getMostPhdDegrees()
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT COUNT(a.u_id) as c, a.u_id FROM phdDegree AS a, UsersAppliedForJobPosition AS b WHERE a.u_id = b.u_id AND b.positionId = @positionId GROUP BY a.u_id ORDER BY c DESC;", myConnection);
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;
        try
        {
            mostPhdDegrees = int.Parse(myGetCommand.ExecuteScalar().ToString());
        }
        catch (Exception ex)
        {
            mostPhdDegrees = 1;
        }

        myConnection.Close();

        return mostPhdDegrees;
    }

    //implemet a functions to get soft skills, first degress, etc.. of each applicant.

    private float getSoftSkillsOfApplicant(int userId)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT COUNT(a.u_id) as c, a.u_id FROM SoftSkill AS a, UsersAppliedForJobPosition AS b WHERE a.u_id = b.u_id AND a.u_id = @userId AND b.positionId = @positionId GROUP BY a.u_id;", myConnection);
        myGetCommand.Parameters.Add("userId", SqlDbType.Int).Value = userId;
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;
        float softSkillsOfApplicant;
        try
        {
            softSkillsOfApplicant = int.Parse(myGetCommand.ExecuteScalar().ToString());
        }
        catch (Exception ex)
        {
            softSkillsOfApplicant = 0;
        }

        myConnection.Close();

        return softSkillsOfApplicant;
    }

    private float getComputerLanguagesOfApplicant(int userId)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT COUNT(a.u_id) as c, a.u_id FROM ComputerLanguage AS a, UsersAppliedForJobPosition AS b WHERE a.u_id = b.u_id AND a.u_id = @userId AND b.positionId = @positionId GROUP BY a.u_id;", myConnection);
        myGetCommand.Parameters.Add("userId", SqlDbType.Int).Value = userId;
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;

        float computerLanguagesOfApplicant;
        try
        {
            computerLanguagesOfApplicant = int.Parse(myGetCommand.ExecuteScalar().ToString());
        }
        catch (Exception ex)
        {
            computerLanguagesOfApplicant = 0;
        }

        myConnection.Close();

        return computerLanguagesOfApplicant;
    }

    private float getFirstDegreesOfApplicant(int userId)
    {

        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT COUNT(a.u_id) as c, a.u_id FROM FirstDegree AS a, UsersAppliedForJobPosition AS b WHERE a.u_id = b.u_id AND a.u_id = @userId AND b.positionId = @positionId GROUP BY a.u_id;", myConnection);
        myGetCommand.Parameters.Add("userId", SqlDbType.Int).Value = userId;
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;

        float firstDegreesOfApplicant;
        try
        {
            firstDegreesOfApplicant = int.Parse(myGetCommand.ExecuteScalar().ToString());
        }
        catch (Exception ex)
        {
            firstDegreesOfApplicant = 0;
        }

        myConnection.Close();

        return firstDegreesOfApplicant;
    }

    private float getMastersDegreesOfApplicant(int userId)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT COUNT(a.u_id) as c, a.u_id FROM MastersDegree AS a, UsersAppliedForJobPosition AS b WHERE a.u_id = b.u_id AND a.u_id = @userId AND b.positionId = @positionId GROUP BY a.u_id;", myConnection);
        myGetCommand.Parameters.Add("userId", SqlDbType.Int).Value = userId;
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;

        float mastersDegreesOfApplicant;
        try
        {
            mastersDegreesOfApplicant = int.Parse(myGetCommand.ExecuteScalar().ToString());
        }
        catch (Exception ex)
        {
            mastersDegreesOfApplicant = 0;
        }

        myConnection.Close();

        return mastersDegreesOfApplicant;
    }

    private float getPhdDegreesOfApplicant(int userId)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT COUNT(a.u_id) as c, a.u_id FROM phdDegree AS a, UsersAppliedForJobPosition AS b WHERE a.u_id = b.u_id AND a.u_id = @userId AND b.positionId = @positionId GROUP BY a.u_id;", myConnection);
        myGetCommand.Parameters.Add("userId", SqlDbType.Int).Value = userId;
        myGetCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;

        float phdDegreesOfApplicant;
        try
        {
            phdDegreesOfApplicant = int.Parse(myGetCommand.ExecuteScalar().ToString());
        }
        catch (Exception ex)
        {
            phdDegreesOfApplicant = 0;
        }

        myConnection.Close();

        return phdDegreesOfApplicant;
    }

    private Boolean applicantHasQuality(int applicantId, int qualityType, String qualityLower)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myGetCommand;

        switch (qualityType)
        {
            case 0:
                myGetCommand = new SqlCommand("SELECT COUNT(languageLowerCase) FROM ComputerLanguage WHERE u_id = @applicantId AND languageLowerCase = @qualityLower;", myConnection);
                break;

            case 1:
                myGetCommand = new SqlCommand("SELECT COUNT(softSkillLowerCase) FROM SoftSkill WHERE u_id = @applicantId AND softSkillLowerCase = @qualityLower;", myConnection);
                break;

            case 2:
                myGetCommand = new SqlCommand("SELECT COUNT(degreeLowerCase) FROM FirstDegree WHERE u_id = @applicantId AND degreeLowerCase = @qualityLower;", myConnection);
                break;

            default:
                myGetCommand = new SqlCommand("SELECT COUNT(softSkillLowerCase) FROM SoftSkill WHERE u_id = @applicantId AND softSkillLowerCase = @qualityLower;", myConnection);
                break;
        }

        myGetCommand.Parameters.Add("applicantId", SqlDbType.Int).Value = applicantId;
        myGetCommand.Parameters.Add("qualityLower", SqlDbType.VarChar).Value = qualityLower;

        int availability = int.Parse(myGetCommand.ExecuteScalar().ToString());
        myConnection.Close();

        return availability == 1;
    }

    private String storeRatingsOfApplicant(int userId, int rating)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myInsertCommand = new SqlCommand("INSERT INTO ApplicantsRatings(positionId, u_id, rating) VALUES (@positionId, @userId, @rating);", myConnection);
        myInsertCommand.Parameters.Add("userId", SqlDbType.Int).Value = userId;
        myInsertCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;
        myInsertCommand.Parameters.Add("rating", SqlDbType.Int).Value = rating;
        myInsertCommand.ExecuteNonQuery();

        myConnection.Close();

        return "Record successfully inserted";
    }

    public String deletePrevRatings()
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myDeleteCommand = new SqlCommand("DELETE FROM ApplicantsRatings WHERE positionId = @positionId ", myConnection);
        myDeleteCommand.Parameters.Add("positionId", SqlDbType.Int).Value = positionId;
        myDeleteCommand.ExecuteNonQuery();

        myConnection.Close();

        return "Record successfully deleted";
    }


    private int rateApplicant(int userId)
    {
        float rating = 0;

        rating += (this.getSoftSkillsOfApplicant(userId) / this.mostSoftSkills) * 100;
        rating += (this.getComputerLanguagesOfApplicant(userId) / this.mostComputerLanguages) * 100;
        rating += (this.getFirstDegreesOfApplicant(userId) / this.mostFirstDegrees) * 100;
        rating += (this.getMastersDegreesOfApplicant(userId) / this.mostMastersDegrees) * 100;
        rating += (this.getPhdDegreesOfApplicant(userId) / this.mostPhdDegrees) * 100;

        for (int i = 0; i < 3; i++)
        {
            if (this.applicantHasQuality(userId, i, this.getFirstQuality()))
            {
                rating += 700;
            }
            if (this.applicantHasQuality(userId, i, this.getSecondQuality()))
            {
                rating += 600;
            }
            if (this.applicantHasQuality(userId, i, this.getThirdQuality()))
            {
                rating += 500;
            }
        }

        return (int)((rating / 2300) * 100);
    }

    public void initiateRating()
    {
        for (int i = 0; i < applicantsArray.Length; i++)
        {
            int rating = this.rateApplicant(applicantsArray[i]);
            this.storeRatingsOfApplicant(applicantsArray[i], rating);
        }
    }
}