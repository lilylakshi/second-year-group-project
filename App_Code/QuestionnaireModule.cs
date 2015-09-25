using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QuestionnaireModule
/// </summary>
public class QuestionnaireModule
{
    private static String connectionString = String.Format("Data Source={0}; Initial Catalog={1}; Persist Security Info=True; User ID={2}; Password={3};", "LILY-PC", "projectdb1", "admin", "123");
	public QuestionnaireModule()
	{

	}

    public String storeQuestionnaireMarks(String userId, String questionnaireName, int marks)
    {
        
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myInsertCommand = new SqlCommand("INSERT INTO questionnaire_marks(u_id, questionnaire_name, marks) VALUES(@u_id, @questionnaireName, @marks)", myConnection);
        myInsertCommand.Parameters.Add("u_id", SqlDbType.Int).Value = userId;
        myInsertCommand.Parameters.Add("questionnaireName", SqlDbType.VarChar).Value = questionnaireName;
        myInsertCommand.Parameters.Add("marks", SqlDbType.Int).Value = marks;
        myInsertCommand.ExecuteNonQuery();
        myConnection.Close();

        return "Marks stored";
    }

    public String deletePrevMarks(String userId, String questionnaireName)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        SqlCommand myDeleteCommand = new SqlCommand("DELETE FROM questionnaire_marks WHERE u_id=@u_id AND questionnaire_name=@questionnaireName",myConnection);
        myDeleteCommand.Parameters.Add("u_id",SqlDbType.Int).Value = userId;
        myDeleteCommand.Parameters.Add("questionnaireName", SqlDbType.VarChar).Value = questionnaireName;
        myDeleteCommand.ExecuteNonQuery();
        myConnection.Close();

        return "Marks Deleted";
    }
}