using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

/// <summary>
/// Summary description for NewPractice1DAL
/// </summary>
public class NewPractice1DAL
{
    DataSet ds = new DataSet();
	public NewPractice1DAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet getQuestionNewpractice(NewPractice1BAL newpractice1bal)
    {
        ds = null;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        try
        {
            SqlParameter[] par = new SqlParameter[13];
            par[0] = new SqlParameter("@subjectid", newpractice1bal.Subjectid);                      
            par[1] = new SqlParameter("@Queslevel", newpractice1bal.Queslevel1);
            par[2] = new SqlParameter("@typeofexam", newpractice1bal.Typeofexam);
            par[3] = new SqlParameter("@Class_id", newpractice1bal.Class_id1);
            par[4] = new SqlParameter("@material", newpractice1bal.Material);
            par[5] = new SqlParameter("@RoleID", newpractice1bal.RoleID1);
            par[6] = new SqlParameter("@chapter", newpractice1bal.Chapter);
            par[7] = new SqlParameter("@UserType", newpractice1bal.Usertype);
            par[8] = new SqlParameter("@rowFrom", newpractice1bal.RowFrom);
            par[9] = new SqlParameter("@rowTo", newpractice1bal.RowTo);
            par[10] = new SqlParameter("@MediumID", newpractice1bal.Medium);
            par[11] = new SqlParameter("@TopicId", newpractice1bal.Topicid);

            par[12] = new SqlParameter("@status",0);
            par[12].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "getQuestionNewpractice", par);
        }
        catch(Exception ex)
        {
        }
        return ds;
    }

    public DataSet  getQuestionNewpracticeCount(NewPractice1BAL newpractice1bal)
    {
      
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            try
            {
                SqlParameter[] par = new SqlParameter[12];
                par[0] = new SqlParameter("@subjectid", newpractice1bal.Subjectid);
                par[1] = new SqlParameter("@Queslevel", newpractice1bal.Queslevel1);
                par[2] = new SqlParameter("@typeofexam", newpractice1bal.Typeofexam);
                par[3] = new SqlParameter("@Class_id", newpractice1bal.Class_id1);
                par[4] = new SqlParameter("@material", newpractice1bal.Material);
                par[5] = new SqlParameter("@RoleID", newpractice1bal.RoleID1);
                par[6] = new SqlParameter("@chapter", newpractice1bal.Chapter);
                par[7] = new SqlParameter("@UserType", newpractice1bal.Usertype);
                par[8] = new SqlParameter("@MediumID", newpractice1bal.Medium);
                par[9] = new SqlParameter("@TopicId", newpractice1bal.Topicid);
                par[10] = new SqlParameter("@status", 0);
                par[10].Direction = ParameterDirection.Output;

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "getQuestionNewpracticeCountSp", par);
            }
            catch (Exception ex)
            {
            }
        return ds;
    }


    public DataSet getQuestionNewpracticeRSB(NewPractice1BAL newpractice1bal)
    {
        ds = null;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            try
            {
                SqlParameter[] par = new SqlParameter[12];
                par[0] = new SqlParameter("@subjectid", newpractice1bal.Subjectid);
                //par[1] = new SqlParameter("@Queslevel", newpractice1bal.Queslevel1);
                par[1] = new SqlParameter("@typeofexam", newpractice1bal.Typeofexam);
                par[2] = new SqlParameter("@Class_id", newpractice1bal.Class_id1);
                par[3] = new SqlParameter("@material", newpractice1bal.Material);
                par[4] = new SqlParameter("@RoleID", newpractice1bal.RoleID1);
                par[5] = new SqlParameter("@chapter", newpractice1bal.Chapter);
                par[6] = new SqlParameter("@UserType", newpractice1bal.Usertype);
                par[7] = new SqlParameter("@rowFrom", newpractice1bal.RowFrom);
                par[8] = new SqlParameter("@rowTo", newpractice1bal.RowTo);
                par[9] = new SqlParameter("@MediumID", newpractice1bal.Medium);
                par[10] = new SqlParameter("@TopicId", newpractice1bal.Topicid);
                par[11] = new SqlParameter("@status", 0);
                par[11].Direction = ParameterDirection.Output;

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "getQuestionNewpracticeRSB", par);
            }
            catch (Exception ex)
            {
            }
        return ds;
    }

    public DataSet getQuestionNewpracticeCountRSB(NewPractice1BAL newpractice1bal)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            try
            {
                SqlParameter[] par = new SqlParameter[12];
                par[0] = new SqlParameter("@subjectid", newpractice1bal.Subjectid);
               // par[1] = new SqlParameter("@Queslevel", newpractice1bal.Queslevel1);
                par[1] = new SqlParameter("@typeofexam", newpractice1bal.Typeofexam);
                par[2] = new SqlParameter("@Class_id", newpractice1bal.Class_id1);
                par[3] = new SqlParameter("@material", newpractice1bal.Material);
                par[4] = new SqlParameter("@RoleID", newpractice1bal.RoleID1);
                par[5] = new SqlParameter("@chapter", newpractice1bal.Chapter);
                par[6] = new SqlParameter("@UserType", newpractice1bal.Usertype);
                par[7] = new SqlParameter("@MediumID", newpractice1bal.Medium);
                par[8] = new SqlParameter("@TopicId", newpractice1bal.Topicid);
                par[9] = new SqlParameter("@status", 0);
                par[9].Direction = ParameterDirection.Output;

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "getQuestionNewpracticeCountSpRSB", par);
            }
            catch (Exception ex)
            {
            }
        return ds;
    }
}