using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for AssignQuestionInExamDAL
/// </summary>
public class AssignQuestionInExamDAL
{
    DataSet ds = new DataSet();
    int status;

	public AssignQuestionInExamDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int UpdateQuestionVerifyClassAdmin(AssignQuestionInExamBAL assignQuestioninexamBal)
    {
        using(SqlConnection con =new SqlConnection (ConfigurationManager.AppSettings["ConnectionString"]))
        try
        {
            SqlParameter[] par = new SqlParameter[7];
            par[0] = new SqlParameter("@SNO1", assignQuestioninexamBal.SNO1);
            par[1] = new SqlParameter("@Class_AdmLogin1", assignQuestioninexamBal.Class_AdmLogin1);
            par[2] = new SqlParameter("@Class_AdmVerify1", assignQuestioninexamBal.Class_AdmVerify1);
            par[3] = new SqlParameter("@Class_AdmSuggest1", assignQuestioninexamBal.Class_AdmSuggest1);
           
            par[4] = new SqlParameter("@status", 0);

            par[4].Direction = ParameterDirection.InputOutput;

            status = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UpdateAssignQuestioninexam_SP", par);

        }
        catch
        {
        }
        return status;
     
    }


     public DataSet SelectQuestionAssignVIEW(AssignQuestionInExamBAL assignQuestioninexamBal)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            try
            {
                SqlParameter[] par = new SqlParameter[7];
                par[0] = new SqlParameter("@ViewtblName1", assignQuestioninexamBal.ViewtblName1);
                par[1] = new SqlParameter("@NewQID", assignQuestioninexamBal.NewQID1);
                par[2] = new SqlParameter("@status", 0);
                par[2].Direction = ParameterDirection.InputOutput;
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "SelectQuestionAssignVIEW_SP", par);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        return ds;

    }


     public DataSet SelectInCorrectQuestions(AssignQuestionInExamBAL assignQuestioninexamBal)
     {

         using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
             try
             {
                 string Sql = "with t as(Select Row_Number()Over(Order By SNO Asc) As NewQID, *from tblQuestionAccess where (Class_AdmVerify='1'" + "OR QuesVerify='1'))select * from t where NewQID=" + assignQuestioninexamBal.NewQID1 + " ";

                 ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);

             }
             catch (Exception ex)
             {
                 throw ex;
             }
         return ds;

     }

}