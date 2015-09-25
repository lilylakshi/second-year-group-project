using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Employer
/// </summary>
public class Employer
{
    private String fName, mName, lName, personalPhone, personalEmail, company, number, street, town, companyPhone, companyEmail;
    private String userID;
	public Employer()
	{
	}

    public String addInfo()
    {
        String query1 = String.Format("INSERT INTO Manager (f_name, m_name, l_name, prs_email, company, cmp_add_no, cmp_add_street, cmp_add_town, cmp_email, u_id) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9})",
                                                            fName, mName, lName, personalEmail, company, number, street, town, companyEmail, userID);
        String query2 = String.Format("INSERT INTO BusPhone (u_id, phone) VALUES ({0}, '{1}')", userID, companyPhone);
        String query3 = String.Format("INSERT INTO PrsPhone (u_id, phone) VALUES ({0}, '{1}')", userID, personalPhone);
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String msg = myConnection.executeNonReturningQuery(query1);
        String msg2 = myConnection.executeNonReturningQuery(query2);
        String msg3 = myConnection.executeNonReturningQuery(query3);
        return msg + msg2 + msg3;
    }

    public void setStrings(String fName, String mName, String lName, String personalPhone, String personalEmail, String company, String number, String street, String town, String companyPhone, String companyEmail)
    {
        this.fName = fName; this.mName = mName; this.lName = lName; this.personalPhone = personalPhone; this.personalEmail = personalEmail; this.company = company; 
        this.number = number; this.street = street; this.town = town; this.companyPhone = companyPhone; this.companyEmail = companyEmail;
    }

    public void setUserID(String userID)
    {
        this.userID = userID;
    }

    public DataTable getInfo(String id)
    {
        DataTable myTable = new DataTable();
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String query = String.Format("SELECT c.f_name AS 'First Name' ,c.m_name AS 'Middle Name', c.l_name AS 'Last Name', c.prs_email AS 'Personal Email', c.company AS 'Company',c.cmp_add_no AS 'C.A.No',c.cmp_add_street AS 'C.A.St',c.cmp_add_town AS 'C.A.tw',c.cmp_email AS 'Cm.Email',p.phone AS 'Pers Phone',b.phone AS 'Bus Phone'  FROM Manager AS c, PrsPhone AS p, BusPhone AS b WHERE c.u_id=p.u_id AND c.u_id=b.u_id AND c.u_id={0}", id);
        myTable = myConnection.executeReturningQuery(query);
        return myTable;
    }

    public String[] getInfoToForm(String id)
    {
        DataTable myTable = new DataTable();
        myTable = this.getInfo(id);
        DataRow[] rowArray = myTable.AsEnumerable().Take(1).ToArray();
        object[] objectArray = rowArray[0].ItemArray;
        String[] stringArray = Array.ConvertAll(objectArray, (p => Convert.ToString(p)));
        return stringArray;
    }

    public String UpdateInfo()
    {
        String query1 = String.Format("UPDATE [Manager] SET [f_name] = '{0}', [m_name] = '{1}', [l_name] = '{2}', [prs_email] = '{3}', [company] = '{4}', [cmp_add_no] = '{5}', [cmp_add_street] = '{6}', [cmp_add_town] = '{7}', [cmp_email] = '{8}' WHERE u_id = {9}",
                                                                fName, mName, lName, personalEmail, company, number, street, town, companyEmail, userID);
        String query2 = String.Format("UPDATE [PrsPhone] SET [phone] = '{0}' WHERE u_id = {1}", personalPhone, userID);
        String query3 = String.Format("UPDATE [BusPhone] SET [phone] = '{0}' WHERE u_id = {1}", companyPhone, userID);
        DBConnection myConnection = new DBConnection();
        myConnection.connect("LILY-PC", "projectdb1", "admin", "123");
        String msg1 = myConnection.executeNonReturningQuery(query1);
        String msg2 = myConnection.executeNonReturningQuery(query2);
        String msg3 = myConnection.executeNonReturningQuery(query3);
        return msg1 + msg2 + msg3;
    }

    public String sheduleAndCallForInterviews(List<String> applicantsList, String positionId, String startingTime, String date, String venue)
    {
        EmailModule emailSender = new EmailModule();
        foreach (String applicantId in applicantsList)
        {
            emailSender.sendEmailForInterview(applicantId, positionId, startingTime, date, venue);
        }

        return "Emails Sent";
    }
}