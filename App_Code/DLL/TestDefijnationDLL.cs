using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;


/// <summary>
/// Summary description for TestDefijnationDLL
/// </summary>
/// 

public class TestDefijnationDLL
{
    public TestDefijnationDLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DataSet ds = new DataSet();
    int status;
    string sql;
    CommonCode cc = new CommonCode();


    public int _insertTestDefi(TestDefinationBLL BllTestd)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            try
            {
                SqlParameter[] par = new SqlParameter[26];
                par[0] = new SqlParameter("@TestName", BllTestd.TestName);
                par[1] = new SqlParameter("@Examid", BllTestd.Examid);
                par[2] = new SqlParameter("@Exandate1", BllTestd.Exandate1);
                par[3] = new SqlParameter("@Duration", BllTestd.Duration);
                par[4] = new SqlParameter("@LoginId1", BllTestd.LoginId1);
                par[5] = new SqlParameter("@D1", BllTestd.D1);
                par[6] = new SqlParameter("@D2", BllTestd.D2);
                par[7] = new SqlParameter("@D3", BllTestd.D3);
                par[8] = new SqlParameter("@TypeofMaterial1", BllTestd.TypeofMaterial1);
                par[9] = new SqlParameter("@Subject_id1", BllTestd.Subject_id1);
                par[10] = new SqlParameter("@SubjectName1", BllTestd.SubjectName1);
                par[11] = new SqlParameter("@Class_id1", BllTestd.Class_id1);
                par[12] = new SqlParameter("@MediumID", BllTestd.MediumID);
                par[13] = new SqlParameter("@TypeOfExam", BllTestd.TypeOfExam);
                par[14] = new SqlParameter("@MarkCorrA", BllTestd.MarkCorrA);
                par[15] = new SqlParameter("@MarkPass", BllTestd.MarkPass);
                par[16] = new SqlParameter("@Retake", BllTestd.Retake);
                par[17] = new SqlParameter("@BreakAllow", BllTestd.BreakAllow);
                par[18] = new SqlParameter("@ReverseNavig", BllTestd.ReverseNavig);
                par[19] = new SqlParameter("@NegativeMark", BllTestd.NegativeMark);
                par[20] = new SqlParameter("@MarkforNegative", BllTestd.MarkforNegative);
                par[21] = new SqlParameter("@GroupOfQuestion1", BllTestd.GroupOfQuestion1);
                par[22] = new SqlParameter("@Testtype", BllTestd.Testtype);
                par[23] = new SqlParameter("@IndexNo", BllTestd.IndexNo1);
                par[24] = new SqlParameter("@groupofExam", BllTestd.GroupofExam);
                par[25] = new SqlParameter("@status", 0);
                par[25].Direction = ParameterDirection.InputOutput;
                status = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "InsertTestDefinition_SP", par);
            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                con.Close();
            }

        return status;

    }

    public DataSet _selecttestdef(TestDefinationBLL BllTestd)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "Select tblTestDefinition.Test_ID as Id ,Exam_name,tblTestDefinition.examid ,tblTestDefinition.Subject_id,TypeofMaterial,Exam_date,Exam_Duration ,DLevel1 ,DLevel2 ,DLevel3,tblTestDefinition.Class_id,tblTestDefinition.MediumID,tblTestDefinition.TypeOfExam,MarkCorrA,MarkPass,Retake,BreakAllow,ReverseNavig,NegativeMark,MarkforNegative,tblTestDefinition.LoginId , tblTestDefinition.GroupOfQuestion,tblTestDefinition.TypeofTest,tblTestDefinition.IndexNo,tblTestDefinition.GroupofExamId from tblTestDefinition  where  Test_ID =" + BllTestd.Test_ID1 + "";
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;

    }


    public int _updatetestdef(TestDefinationBLL BllTestd)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            try
            {
                SqlParameter[] par = new SqlParameter[27];
                par[0] = new SqlParameter("@TestName", BllTestd.TestName);
                par[1] = new SqlParameter("@Examid", BllTestd.Examid);
                par[2] = new SqlParameter("@Exandate1", BllTestd.Exandate1);
                par[3] = new SqlParameter("@Duration", BllTestd.Duration);
                par[4] = new SqlParameter("@LoginId1", BllTestd.LoginId1);
                par[5] = new SqlParameter("@D1", BllTestd.D1);
                par[6] = new SqlParameter("@D2", BllTestd.D2);
                par[7] = new SqlParameter("@D3", BllTestd.D3);
                par[8] = new SqlParameter("@TypeofMaterial1", BllTestd.TypeofMaterial1);
                par[9] = new SqlParameter("@Subject_id1", BllTestd.Subject_id1);
                par[10] = new SqlParameter("@SubjectName1", BllTestd.SubjectName1);
                par[11] = new SqlParameter("@Class_id1", BllTestd.Class_id1);
                par[12] = new SqlParameter("@MediumID", BllTestd.MediumID);
                par[13] = new SqlParameter("@TypeOfExam", BllTestd.TypeOfExam);
                par[14] = new SqlParameter("@MarkCorrA", BllTestd.MarkCorrA);
                par[15] = new SqlParameter("@MarkPass", BllTestd.MarkPass);
                par[16] = new SqlParameter("@Retake", BllTestd.Retake);
                par[17] = new SqlParameter("@BreakAllow", BllTestd.BreakAllow);
                par[18] = new SqlParameter("@ReverseNavig", BllTestd.ReverseNavig);
                par[19] = new SqlParameter("@NegativeMark", BllTestd.NegativeMark);
                par[20] = new SqlParameter("@MarkforNegative", BllTestd.MarkforNegative);
                par[21] = new SqlParameter("@GroupOfQuestion1", BllTestd.GroupOfQuestion1);
                par[22] = new SqlParameter("@Testtype", BllTestd.Testtype);
                par[23] = new SqlParameter("@Test_ID1", BllTestd.Test_ID1);
                par[24] = new SqlParameter("@IndexNo", BllTestd.IndexNo1);
                par[25] = new SqlParameter("@groupofExam", BllTestd.GroupofExam);
                par[26] = new SqlParameter("@status", 0);
                par[26].Direction = ParameterDirection.InputOutput;

                status = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UpdateTestDefinition_SP", par);
            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                con.Close();
            }

        return status;

    }

    public int _deletetestdef(TestDefinationBLL BllTestd)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                sql = "Delete from tblTestDefinition where Test_ID=" + BllTestd.Test_ID1 + "";
                status = SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return status;
    }

    public DataSet GetAllTestDefinesubject(int examid)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                sql = "  Select Test_ID as Id ,tblTestDefinition.examid ,tblSubject.Subject_id  ,tblTopic.Topic_Name,tblExamName.examname,Exam_date,Total_que ,Exam_Duration, Exam_Subject, Exam_Topic ,DLevel1 ,DLevel2 ,DLevel3  from tblTestDefinition ,tblExamName,tblTopic,tblSubject where tblTestDefinition.examid = tblExamName.examid and tblTestDefinition.Topic_id = tblTopic.Topic_id and tblTestDefinition.Subject_id = tblSubject.Subject_id and tblTestDefinition.examid = " + examid + "";
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;
    }

    public DataSet DALGetAllTestDefination()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                sql = "  Select Test_ID as Id ,tblTestDefinition.examid ,tblSubject.Subject_Name,tblTopic.Topic_Name,tblExamName.examname,Exam_date,Total_que ,Exam_Duration ,DLevel1 ,DLevel2 ,DLevel3  from tblTestDefinition ,tblExamName,tblTopic,tblSubject where tblTestDefinition.examid = tblExamName.examid and tblTestDefinition.Topic_id = tblTopic.Topic_id and tblTestDefinition.Subject_id = tblSubject.Subject_id order by Test_ID DESC";
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;

    }
    public DataSet DALGetAllTDename(string ename)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                sql = "Select Test_ID as Id ,tblTestDefinition.examid ,tblSubject.Subject_Name,tblTopic.Topic_Name,tblExamName.examname,Exam_date,Total_que ,Exam_Duration, Subject_Name, Topic_Name ,DLevel1 ,DLevel2 ,DLevel3  from tblTestDefinition ,tblExamName,tblTopic,tblSubject where tblTestDefinition.examid = tblExamName.examid and tblTestDefinition.Topic_id = tblTopic.Topic_id and tblTestDefinition.Subject_id = tblSubject.Subject_id and tblTestDefinition.examid=" + ename + "";
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;

    }
    public DataSet DALGetAllTDsname(string sname)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                sql = "  Select Test_ID as Id ,tblTestDefinition.examid ,tblSubject.Subject_Name,tblTopic.Topic_Name,tblExamName.examname,Exam_date,Total_que ,Exam_Duration, Subject_Name, Topic_Name ,DLevel1 ,DLevel2 ,DLevel3  from tblTestDefinition ,tblExamName,tblTopic,tblSubject where tblTestDefinition.examid = tblExamName.examid and tblTestDefinition.Topic_id = tblTopic.Topic_id and tblTestDefinition.Subject_id = tblSubject.Subject_id and tblTestDefinition.Subject_id = " + sname + "";
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;

    }
    public DataSet DALGetAllTDtid(string tid)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                sql = " Select Test_ID as Id ,tblTestDefinition.examid ,tblSubject.Subject_Name,tblTopic.Topic_Name,tblExamName.examname,Exam_date,Total_que ,Exam_Duration, Subject_Name, Topic_Name ,DLevel1 ,DLevel2 ,DLevel3  from tblTestDefinition ,tblExamName,tblTopic,tblSubject where tblTestDefinition.examid = tblExamName.examid and tblTestDefinition.Topic_id = tblTopic.Topic_id and tblTestDefinition.Subject_id = tblSubject.Subject_id and tblTestDefinition.Topic_id=" + tid + " ";
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;

    }

    public DataSet GetTestByGroupofQues(TestDefinationBLL testbal)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@LoginId1", testbal.LoginId1);
                par[1] = new SqlParameter("@GroupOfQuestion1", testbal.GroupOfQuestion1);
                par[2] = new SqlParameter("@status", 0);

                par[2].Direction = ParameterDirection.Output;
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "SelectTestDefinition_SP", par);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;

    }



    //********************** AddExamchapter ********************************************************************************************

    public DataSet TestbyGroupofQuesLoginId5(TestDefinationBLL testbal) // use for AddExamChapter page
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@LoginId1", testbal.LoginId1);
                par[1] = new SqlParameter("@GroupOfQuestion1", testbal.GroupOfQuestion1);
                par[2] = new SqlParameter("@status", 0);

                par[2].Direction = ParameterDirection.Output;
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "TestbyGroupofQuesLoginId5_SP", par);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;
    }

    public DataSet loadsubject(string TestId)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string SQl = "select Subject_id from tblTestDefinition where Test_ID=" + TestId + "";
                string Id = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.Text, SQl));
                sql = "select Name,ItemValueId from tblItemValue where  ItemValueId in(" + Id + ")";

                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, sql); // sp use but error in keyword convert nvarchar to int 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;
    }


    //********************** Assign QuestionInExam page *********************************************************************************

    public DataSet getAssignTestDetails(TestDefinationBLL testbal)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@LoginId1", testbal.LoginId1);
                par[1] = new SqlParameter("@Test_ID1", testbal.Test_ID1);
                par[2] = new SqlParameter("@status", 0);

                par[2].Direction = ParameterDirection.Output;
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "SelectAssignTestDetails_SP", par);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;
    }


    public DataSet getLevelTestDef(TestDefinationBLL testbal)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@Test_ID1", testbal.Test_ID1);
                par[1] = new SqlParameter("@status", 0);

                par[1].Direction = ParameterDirection.Output;
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "SelectLevelTestDef_SP", par);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;
    }
}
