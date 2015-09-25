using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for DBConnection
/// </summary>
public class DBConnection
{
    String connectionString;
    SqlConnection myConnection;
    SqlCommand myCommand;
    SqlDataReader myReader;
	public DBConnection()
	{
	}

    // establishing a connection 
    public String connect(String dataSource, String database, String username, String password)
    {
        try
        {
            connectionString = String.Format("Data Source={0}; Initial Catalog={1}; Persist Security Info=True; User ID={2}; Password={3};", dataSource, database, username, password);
            myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            myConnection.Close();
            return "Successfully connected.";
        } 
        catch(SqlException e)
        {
            return e.Message;
        }
    }

    // execute a non-returning query
    public String executeNonReturningQuery(String query)
    {
        try
        {
            myConnection.Open();
            myCommand = new SqlCommand(query, myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            return "Non-returning query Successfully executed.";
        }
        catch(SqlException e)
        {
            myConnection.Close();
            return e.Message;
        }
    }

    // exexute a returning query
    public DataTable executeReturningQuery(String query)
    {
        try
        {
            myConnection.Open();
            myCommand = new SqlCommand(query, myConnection);
            myReader = myCommand.ExecuteReader();
            DataTable myTable = new DataTable();
            myTable.Load(myReader);
            myConnection.Close();
            return myTable;
        }
        catch(SqlException e)
        {
            myConnection.Close();
            DataTable myTable = new DataTable();
            return myTable;
        }
    }

    //return a List for comparing purposes
    public List<String> getResultsList(String query, String colName)
    {
        List<String> myList = new List<string>();
        try
        {
            myConnection.Open();
            myCommand = new SqlCommand(query, myConnection);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                myList.Add(myReader[colName].ToString());
            }

            // close the connection
            myReader.Close();
            myConnection.Close();
            return myList;
        }
        catch (SqlException e)
        {
            myReader.Close();
            myConnection.Close();
            myList.Add(e.ToString());
            return myList;
        }
    }
}