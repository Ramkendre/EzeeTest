using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for AddExamChapterDAL
/// </summary>
public class AddExamChapterDAL
{
    int status;
    DataSet ds = new DataSet();
	public AddExamChapterDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int InsertUpdateExamChapter(AddExamChapterBAL addexamchapterbal)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"])) 
        try
        {
           

            SqlParameter[] par = new SqlParameter[11];
            par[0]=new SqlParameter ("@TestID1",addexamchapterbal.TestID1);
            par[1] = new SqlParameter("@ChapterName1", addexamchapterbal.ChapterName1);
            par[2] = new SqlParameter("@Chapter_id1", addexamchapterbal.Chapter_id1);
            par[3] = new SqlParameter("@Subject_id1", addexamchapterbal.Subject_id1);
            par[4] = new SqlParameter("@EntryDate1", addexamchapterbal.EntryDate1);
            par[5] = new SqlParameter("@LoginId1", addexamchapterbal.LoginId1);
            par[6]=new SqlParameter ("@AecID1",addexamchapterbal.AecID1);  // insert update
            par[7] = new SqlParameter("@status", 0);

            par[7].Direction = ParameterDirection.InputOutput;

            status = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "InsertUpdateAddExamChapter", par);

        }
        catch
        {

        }
        return status;
    }

    public DataSet GetRecordModify(AddExamChapterBAL addexamchapterbal)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"])) 

        try
        {
            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@AecID1", addexamchapterbal.AecID1);
            par[1] = new SqlParameter("@status",0);
         
            par[1].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "SelectAddExamChapter_SP", par);

          
        }
        catch
        {
        }
        return ds;
    }

}