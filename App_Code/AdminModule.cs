using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminModule
/// </summary>
public class AdminModule
{
    private static String connectionString = String.Format("Data Source={0}; Initial Catalog={1}; Persist Security Info=True; User ID={2}; Password={3};", "LILY-PC", "projectdb1", "admin", "123");
	public AdminModule()
	{
	}

    public DataTable getAllUsers()
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        DataTable myDataTable = new DataTable();
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT a.u_id, a.u_name, f_name + ' ' + m_name + ' '+ l_name AS Name, a.role FROM UserAcc AS a FULL OUTER JOIN Candidate AS b ON a.u_id = b.u_id;", myConnection);
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myConnection.Close();

        return myDataTable;
    }
    public DataTable getAllUsers2()
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        DataTable myDataTable = new DataTable();
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT a.u_id, a.u_name, b.f_name + ' ' + b.m_name + ' '+ b.l_name AS Name, a.role FROM UserAcc AS a, Candidate AS b WHERE a.u_id = b.u_id UNION SELECT a.u_id, a.u_name, b.f_name + ' ' + b.m_name + ' '+ b.l_name AS Name, a.role FROM UserAcc AS a, Manager AS b WHERE a.u_id = b.u_id;", myConnection);
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myConnection.Close();

        return myDataTable;
    }
    public DataTable searchUsers(String keyword)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        DataTable myDataTable = new DataTable();
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT a.u_id, a.u_name, f_name + ' ' + m_name + ' '+ l_name AS Name, a.role FROM UserAcc AS a FULL OUTER JOIN Candidate AS b ON a.u_id = b.u_id WHERE f_name + ' ' + m_name + ' '+ l_name LIKE @keyword;", myConnection);
        myGetCommand.Parameters.Add("keyword", SqlDbType.VarChar).Value = "%" + keyword + "%";
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myConnection.Close();

        return myDataTable;
    }
    public DataTable searchUsers2(String keyword)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlDataReader myReader;
        DataTable myDataTable = new DataTable();
        myConnection.Open();

        SqlCommand myGetCommand = new SqlCommand("SELECT a.u_id, a.u_name, b.f_name + ' ' + b.m_name + ' '+ b.l_name AS Name, a.role FROM UserAcc AS a, Candidate AS b WHERE a.u_id = b.u_id AND f_name + ' ' + m_name + ' '+ l_name LIKE @keyword UNION SELECT a.u_id, a.u_name, b.f_name + ' ' + b.m_name + ' '+ b.l_name AS Name, a.role FROM UserAcc AS a, Manager AS b WHERE a.u_id = b.u_id AND f_name + ' ' + m_name + ' '+ l_name LIKE @keyword;", myConnection);
        myGetCommand.Parameters.Add("keyword", SqlDbType.VarChar).Value = "%" + keyword + "%";
        myReader = myGetCommand.ExecuteReader();
        myDataTable.Load(myReader);
        myConnection.Close();

        return myDataTable;
    }
}