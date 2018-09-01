using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

/// <summary>
/// Summary description for TestApp
/// </summary>
/// 

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class TestApp : System.Web.Services.WebService
{
    string sql = "";
    CommonCode cc = new CommonCode();
    public static string connectionString { get { return "server=103.16.140.243;Initial Catalog=OKCLDB;User id=TrueVoter;Password=TrueVoter@#123;"; } }

    public TestApp()
    {

    }

    #region Function GetQuestionFromexam(Return Questions from tblCompanyId by using TestID)

    /// <summary>
    /// Get Question by testid
    /// </summary>
    /// <param name="UserMobileNo"></param>
    /// <param name="TeacherMobileNo"></param>
    /// <param name="TblName"></param>
    /// <param name="Testid"></param>
    /// <returns></returns>
    /// 

    [WebMethod(Description = "Get Question by testid")]
    public XmlDocument GetQuestionFromexam(string UserMobileNo, string TeacherMobileNo, string TblName, string Testid, string examid)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        try
        {
            DataSet ds = new DataSet();

            sql = " SELECT Test_ID,Exam_name,Exam_Duration,MarkCorrA,MarkPass,NegativeMark,MarkforNegative,TypeofTest FROM tblTestDefinition(nolock) WHERE TypeOFExam='" + examid + "' AND  LoginId='" + TeacherMobileNo + "' AND Test_ID='" + Testid + "' ";
            sql = sql + " SELECT TOP 100 PERCENT * FROM " + TblName + "(nolock)  WHERE TestID='" + Testid + "' ORDER BY SNO ASC   ";
            ds = cc.ExecuteDataset(sql);
            xmldoc = new XmlDataDocument(ds);
            XmlElement xmlelement = xmldoc.DocumentElement;
        }
        catch
        {

        }
        return xmldoc;
    }
    #endregion

    #region  Score Report of an Users given Test in eZeeTest App

    [WebMethod(Description = "METHOD TO INSERT RESULT OF SOLVED TEST TO SERVER TABLE")]

    public int TestAppUserScoreReport(string UserMobileNo, string TeacherORDefaultMobNo, string examGroupId, string examId, string TestId, string IMEI, string TestDate, string startTime, string endTime, string correctAnswered_count, string inCorrectAnswered_count, string notAnsweredQuestions_count, string CorrectAnswer_InDetail, string InCorrectAnswer_InDetail, string NotAnsweredQuestions_InDetail, string Status, string firstName, string lastName, string UDISE_Code, string elapsedTime, string txtMobileNumber)
    {
        int flag = 1;
        try
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "uspInserteZeeTestAppResult";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlParameter[] parameter = new SqlParameter[] 
        {
            new SqlParameter("@userMobileNo", UserMobileNo),
            new SqlParameter("@teacherMobileNo", TeacherORDefaultMobNo),
            new SqlParameter("@examGroupId", examGroupId),
            new SqlParameter("@examId", examId),
            new SqlParameter("@TestId", TestId),
            new SqlParameter("@IMEI", IMEI),
            new SqlParameter("@TestDate", TestDate),
            new SqlParameter("@startTime", startTime),
            new SqlParameter("@endTime", endTime),
            new SqlParameter("@correctAnswered_count", correctAnswered_count),
            new SqlParameter("@inCorrectAnswered_count", inCorrectAnswered_count),
            new SqlParameter("@notAnsweredQuestions_count", notAnsweredQuestions_count),
            new SqlParameter("@CorrectAnswer_InDetail", CorrectAnswer_InDetail),
            new SqlParameter("@InCorrectAnswer_InDetail", InCorrectAnswer_InDetail),
            new SqlParameter("@NotAnsweredQuestions_InDetail", NotAnsweredQuestions_InDetail),
            new SqlParameter("@Status", Status),
            new SqlParameter("@firstName", firstName),
            new SqlParameter("@lastName", lastName),
            new SqlParameter("@udiseCode", UDISE_Code),
            new SqlParameter("@elapsedTime", elapsedTime),
            new SqlParameter("@txtMobNumber", txtMobileNumber)
        };
            sqlCommand.Parameters.AddRange(parameter);
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
        }
        catch
        {
            flag = 0;
        }
        return flag;
    }

    #endregion

    #region Method For Validate Scratch Code

    [WebMethod(Description = "Method for Validate Scratch Code")]
    public string validateScratchCode(string strDevId, string passcode, string groupofExam, string examNameID)
    {
        string resValid = "";
        if (string.IsNullOrEmpty(passcode) || passcode == " " || passcode == "")
        {
            resValid = "2";
        }
        else
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            SqlCommand cmd = new SqlCommand("spCheckKeyCode", con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dataset = new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@imeino", SqlDbType.VarChar).Value = strDevId;
            cmd.Parameters.Add("@scratchcode", SqlDbType.VarChar).Value = passcode;
            cmd.Parameters.Add("@groupofexam", SqlDbType.VarChar).Value = groupofExam;
            cmd.Parameters.Add("@examnameid", SqlDbType.VarChar).Value = examNameID;
            con.Open();
            da.SelectCommand = cmd;
            da.Fill(dataset);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                if (dataset.Tables[0].Rows[0][4].ToString() == "1")
                {
                    resValid = "1"; //Valid Key_Code/Passcode/Scratch_Code
                }
                else
                {
                    resValid = "2";//InValid Key_Code/Passcode/Scratch_Code
                }
            }
            else
            {
                resValid = "3"; //No Data Found
            }
            con.Close();
        }
        return resValid;

    }


    #endregion

    #region METHOD RETURN TEST NAME CREATE BY CLASS TEACHER

    [WebMethod(Description = "RETURN TEST NAME CREATE BY CLASS TEACHER")]
    public string getExamNamefromTestDefine(string UserMobileNo, string TeacherMobileNo, string classId, string examid, string Usertype, string GroupofThryQues)
    {
        string returnstring = "", returnTableName = "", returntestid = "", returntestName = "", returnTypeofTest = "", returnSeqNo = "";
        string returnClassId = "", returnBatch = "", returnStudents = "", returnClassAdmin = "", returnOwnNumber = "", returnGroupofQues = "";

        DataSet ds = new DataSet();
        SqlCommand sqlCommand = new SqlCommand();


        if (examid == "209" || examid == "210" || examid == "211" || examid == "212")
        {
            if (examid == "209")
            {
                returnstring = NewExamAddedTestList(UserMobileNo, TeacherMobileNo, classId, "27", "99", Usertype, GroupofThryQues);
            }
            if (examid == "210")
            {
                returnstring = NewExamAddedTestList(UserMobileNo, TeacherMobileNo, classId, "28", "99", Usertype, GroupofThryQues);
            }
            if (examid == "211")
            {
                returnstring = NewExamAddedTestList(UserMobileNo, TeacherMobileNo, classId, "26", "98", Usertype, GroupofThryQues);
            }
            if (examid == "212")
            {
                returnstring = NewExamAddedTestList(UserMobileNo, TeacherMobileNo, classId, "29", "99", Usertype, GroupofThryQues);
            }
        }
        else
        {
            sqlCommand.CommandText = "uspGetTestList";
            sqlCommand.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.DbType = DbType.String;
            sqlParameter.Size = 50;

            SqlParameter[] parameter = new SqlParameter[] 
        {
            new SqlParameter("@userMobileNo", UserMobileNo),
            new SqlParameter("@teacherMobile", TeacherMobileNo),
            new SqlParameter("@classId", classId),
            new SqlParameter("@examId", examid),
            new SqlParameter("@userType", Usertype) ,
            new SqlParameter("@GroupofThryQues",GroupofThryQues)
        };

            sqlCommand.Parameters.AddRange(parameter);
            SqlDataAdapter adaper = new SqlDataAdapter();
            adaper.SelectCommand = sqlCommand;
            adaper.Fill(ds);

            returnTableName = "tbl5164";

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    returntestid = returntestid + "," + ds.Tables[0].Rows[i]["Test_ID"];
                    returntestName = returntestName + "," + ds.Tables[0].Rows[i]["Exam_name"];
                    returnTypeofTest = returnTypeofTest + "," + ds.Tables[0].Rows[i]["TypeofTest"];
                    returnSeqNo = returnSeqNo + "," + ds.Tables[0].Rows[i]["IndexNo"];

                    returnClassId = returnClassId + "," + ds.Tables[0].Rows[i]["Class_id"];
                    returnBatch = returnBatch + "," + ds.Tables[0].Rows[i]["Batch"];
                    returnStudents = returnStudents + "," + ds.Tables[0].Rows[i]["Students"];
                    returnClassAdmin = returnClassAdmin + "," + ds.Tables[0].Rows[i]["LoginId"];
                    returnOwnNumber = returnOwnNumber + "," + ds.Tables[0].Rows[i]["OwnNumber"];
                    returnGroupofQues = returnGroupofQues + "," + ds.Tables[0].Rows[i]["GroupOfQuestion"];
                }

                return returnstring = returnTableName + "*" + returntestid + "*" + returntestName + "*" + returnTypeofTest + "*" + returnSeqNo + "*" + returnClassId + "*" + returnBatch + "*" + returnStudents + "*" + returnClassAdmin + "*" + returnOwnNumber + "*" + returnGroupofQues;
            }
            else
            {
                return returnstring = "105";
            }
        }

        return returnstring;
    }

    public string NewExamAddedTestList(string UserMobileNo, string TeacherMobileNo, string classId, string subjectId, string examid, string Usertype, string GroupofThryQues)
    {
        string returnstring = "", returnTableName = "", returntestid = "", returntestName = "", returnTypeofTest = "", returnSeqNo = "";
        string returnClassId = "", returnBatch = "", returnStudents = "", returnClassAdmin = "", returnOwnNumber = "", returnGroupofQues = "";

        DataSet ds = new DataSet();
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.CommandText = "uspTestListNewExamId";
        sqlCommand.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        SqlParameter sqlParameter = new SqlParameter();

        sqlParameter.DbType = DbType.String;
        sqlParameter.Size = 50;

        SqlParameter[] parameter = new SqlParameter[] 
        {
            new SqlParameter("@userMobileNo", UserMobileNo),
            new SqlParameter("@teacherMobile", TeacherMobileNo),
            new SqlParameter("@classId", classId),
            new SqlParameter("@subjectId", subjectId),
            new SqlParameter("@examId", examid),
            new SqlParameter("@userType", Usertype), 
            new SqlParameter("@GroupofThryQues", GroupofThryQues),
        };

        sqlCommand.Parameters.AddRange(parameter);
        SqlDataAdapter adaper = new SqlDataAdapter();
        adaper.SelectCommand = sqlCommand;
        adaper.Fill(ds);

        returnTableName = "tbl5164";

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                returntestid = returntestid + "," + ds.Tables[0].Rows[i]["Test_ID"];
                returntestName = returntestName + "," + ds.Tables[0].Rows[i]["Exam_name"];
                returnTypeofTest = returnTypeofTest + "," + ds.Tables[0].Rows[i]["TypeofTest"];
                returnSeqNo = returnSeqNo + "," + ds.Tables[0].Rows[i]["IndexNo"];

                returnClassId = returnClassId + "," + ds.Tables[0].Rows[i]["Class_id"];
                returnBatch = returnBatch + "," + ds.Tables[0].Rows[i]["Batch"];
                returnStudents = returnStudents + "," + ds.Tables[0].Rows[i]["Students"];
                returnClassAdmin = returnClassAdmin + "," + ds.Tables[0].Rows[i]["LoginId"];
                returnOwnNumber = returnOwnNumber + "," + ds.Tables[0].Rows[i]["OwnNumber"];
                returnGroupofQues = returnGroupofQues + "," + ds.Tables[0].Rows[i]["GroupOfQuestion"];
            }

            return returnstring = returnTableName + "*" + returntestid + "*" + returntestName + "*" + returnTypeofTest + "*" + returnSeqNo + "*" + returnClassId + "*" + returnBatch + "*" + returnStudents + "*" + returnClassAdmin + "*" + returnOwnNumber + "*" + returnGroupofQues;
        }
        else
        {
            return returnstring = "105";
        }
    }

    #endregion

    #region Method For Daily Questions and GKDQ WebService

    [WebMethod(Description = "Daily Questions WebService")]
    public string dailyQuestions(string UserMobileNo, string TeacherMobileNo, string classId, string examid, string Usertype, DateTime Examdate)
    {

        string returnstring = "", returnTableName = "", returntestid = "", returntestName = "", returnTypeofTest = "", returnSeqNo = ""; //returnGroupofQues = "";
        DataSet ds = new DataSet();
        try
        {
            if (examid == "209" || examid == "210" || examid == "211" || examid == "212")
            {
                if (examid == "209")
                {
                    returnstring = NewdailyQuestions(UserMobileNo, TeacherMobileNo, classId, "27", "99", Usertype, Examdate);
                }
                else if (examid == "210")
                {
                    returnstring = NewdailyQuestions(UserMobileNo, TeacherMobileNo, classId, "28", "99", Usertype, Examdate);
                }
                else if (examid == "211")
                {
                    returnstring = NewdailyQuestions(UserMobileNo, TeacherMobileNo, classId, "26", "98", Usertype, Examdate);
                }
                else if (examid == "212")
                {
                    returnstring = NewdailyQuestions(UserMobileNo, TeacherMobileNo, classId, "29", "99", Usertype, Examdate);
                }
            }
            else
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "spDailyQuestion";
                sqlCommand.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();

                sqlParameter.Direction = ParameterDirection.Output;
                sqlParameter.DbType = DbType.String;
                sqlParameter.Size = 50;

                SqlParameter[] parameter = new SqlParameter[] 
            { 
                new SqlParameter("@teacherMobNo", TeacherMobileNo),
                new SqlParameter("@classID", classId), 
                new SqlParameter("@examID", examid), 
                new SqlParameter("@examDate", Examdate),
                //new SqlParameter("@Groupofques", Groupofques)
            };

                sqlCommand.Parameters.AddRange(parameter);
                SqlDataAdapter adaper = new SqlDataAdapter();
                adaper.SelectCommand = sqlCommand;

                adaper.Fill(ds);

                if (TeacherMobileNo == "9292929292")
                {
                    returnTableName = "tbl5254";
                }
                else
                {
                    returnTableName = "tbl5164";
                }

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        returntestid = returntestid + "," + ds.Tables[0].Rows[i]["Test_ID"];
                        returntestName = returntestName + "," + ds.Tables[0].Rows[i]["Exam_name"];
                        returnTypeofTest = returnTypeofTest + "," + ds.Tables[0].Rows[i]["TypeofTest"];
                        returnSeqNo = returnSeqNo + "," + ds.Tables[0].Rows[i]["IndexNo"];
                        //returnGroupofQues = returnGroupofQues + "," + ds.Tables[0].Rows[i]["GroupOfQuestion"];
                    }

                    return returnstring = returnTableName + "*" + returntestid + "*" + returntestName + "*" + returnTypeofTest + "*" + returnSeqNo; //+ "*" + returnGroupofQues;
                }
                else
                {
                    returnstring = "105";
                }
            }
        }
        catch
        {
            returnstring = "105";
        }
        return returnstring;
    }


    public string NewdailyQuestions(string UserMobileNo, string TeacherMobileNo, string classId, string subjectId, string examid, string Usertype, DateTime Examdate)
    {

        string returnstring = "", returnTableName = "", returntestid = "", returntestName = "", returnTypeofTest = "", returnSeqNo = "";  //, returnGroupofQues = "";
        DataSet ds = new DataSet();
        try
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "spNewDailyQuestion";
            sqlCommand.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter();

            sqlParameter.Direction = ParameterDirection.Output;
            sqlParameter.DbType = DbType.String;
            sqlParameter.Size = 50;

            SqlParameter[] parameter = new SqlParameter[] 
            { 
                new SqlParameter("@teacherMobNo", TeacherMobileNo),
                new SqlParameter("@classID", classId), 
                new SqlParameter("@examID", examid), 
                new SqlParameter("@examDate", Examdate), 
                new SqlParameter("@subjectID",subjectId)
            };

            sqlCommand.Parameters.AddRange(parameter);
            SqlDataAdapter adaper = new SqlDataAdapter();
            adaper.SelectCommand = sqlCommand;

            adaper.Fill(ds);

            //returnTableName = "tbl5254";

            if (TeacherMobileNo == "9292929292")
            {
                returnTableName = "tbl5254";
            }
            else
            {
                returnTableName = "tbl5164";
            }

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    returntestid = returntestid + "," + ds.Tables[0].Rows[i]["Test_ID"];
                    returntestName = returntestName + "," + ds.Tables[0].Rows[i]["Exam_name"];
                    returnTypeofTest = returnTypeofTest + "," + ds.Tables[0].Rows[i]["TypeofTest"];
                    returnSeqNo = returnSeqNo + "," + ds.Tables[0].Rows[i]["IndexNo"];
                    //returnGroupofQues = returnGroupofQues + "," + ds.Tables[0].Rows[i]["GroupOfQuestion"];
                }

                return returnstring = returnTableName + "*" + returntestid + "*" + returntestName + "*" + returnTypeofTest + "*" + returnSeqNo; //+"*" + returnGroupofQues;
            }
            else
            {
                returnstring = "105";
            }
        }
        catch
        {
            returnstring = "105";
        }
        return returnstring;
    }


    #endregion

    #region Get Exam_duration and other Test Define Details

    [WebMethod(Description = "Get Exam_duration and other Test Define Details")]
    public string examDefineDetails(string UserMobileNo, string TeacherMobileNo, string classId, string examid, string Usertype)
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adaper = new SqlDataAdapter();
        string returnString = "", returnTest_ID = "", returnExam_date = "", returnExam_Duration = "", returnMarkCorrA = "", returnMarkPass = "", returnNegativeMark = "", returnMarkForNegative = "", returnTestofType = "";
        try
        {
            if (examid == "209" || examid == "210" || examid == "211" || examid == "212")
            {
                if (examid == "209")
                {
                    returnString = GetNewexamDefineDetails(UserMobileNo, TeacherMobileNo, classId, "27", "99", Usertype);
                }
                if (examid == "210")
                {
                    returnString = GetNewexamDefineDetails(UserMobileNo, TeacherMobileNo, classId, "28", "99", Usertype);
                }
                if (examid == "211")
                {
                    returnString = GetNewexamDefineDetails(UserMobileNo, TeacherMobileNo, classId, "26", "98", Usertype);
                }
                if (examid == "212")
                {
                    returnString = GetNewexamDefineDetails(UserMobileNo, TeacherMobileNo, classId, "29", "99", Usertype);
                }
            }
            else
            {
                cmd.CommandText = "spGetExamDefineDetails";
                cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userMobileNo", SqlDbType.VarChar).Value = UserMobileNo;
                cmd.Parameters.Add("@teacherMobileNo", SqlDbType.VarChar).Value = TeacherMobileNo;
                cmd.Parameters.Add("@classID", SqlDbType.VarChar).Value = classId;
                cmd.Parameters.Add("@examID", SqlDbType.VarChar).Value = examid;
                cmd.Parameters.Add("@userType", SqlDbType.VarChar).Value = Usertype;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = 0;

                cmd.Connection.Open();

                adaper.SelectCommand = cmd;
                adaper.Fill(ds);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        returnTest_ID += "," + Convert.ToString(ds.Tables[0].Rows[i]["Test_ID"]);
                        returnExam_Duration += "," + Convert.ToString(ds.Tables[0].Rows[i]["Exam_Duration"]);
                        returnMarkCorrA += "," + Convert.ToString(ds.Tables[0].Rows[i]["MarkCorrA"]);
                        returnMarkPass += "," + Convert.ToString(ds.Tables[0].Rows[i]["MarkPass"]);
                        returnNegativeMark += "," + Convert.ToString(ds.Tables[0].Rows[i]["NegativeMark"]);
                        returnMarkForNegative += "," + Convert.ToString(ds.Tables[0].Rows[i]["MarkforNegative"]);
                        returnTestofType += "," + Convert.ToString(ds.Tables[0].Rows[i]["TypeofTest"]);
                        returnExam_date += "," + Convert.ToString(ds.Tables[0].Rows[i]["Exam_date"]).Remove(Convert.ToString(ds.Tables[0].Rows[i]["Exam_date"]).Length - 12);
                    }

                    if (returnTest_ID.Length > 0)
                    {
                        returnTest_ID = returnTest_ID.Substring(1);
                        returnExam_Duration = returnExam_Duration.Substring(1);
                        returnMarkCorrA = returnMarkCorrA.Substring(1);
                        returnMarkPass = returnMarkPass.Substring(1);
                        returnNegativeMark = returnNegativeMark.Substring(1);
                        returnMarkForNegative = returnMarkForNegative.Substring(1);
                        returnTestofType = returnTestofType.Substring(1);
                        returnExam_date = returnExam_date.Substring(1);
                    }
                    returnString = returnTest_ID + "*" + returnExam_Duration + "*" + returnMarkCorrA + "*" + returnMarkPass + "*" + returnNegativeMark + "*" + returnMarkForNegative + "*" + returnTestofType + "*" + returnExam_date;
                }
                else
                {
                    returnString = "105";
                }
            }
        }
        catch
        {

        }
        return returnString;
    }

    public string GetNewexamDefineDetails(string UserMobileNo, string TeacherMobileNo, string classId, string subjectId, string examid, string Usertype)
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adaper = new SqlDataAdapter();
        string returnString = "", returnTest_ID = "", returnExam_date = "", returnExam_Duration = "", returnMarkCorrA = "", returnMarkPass = "", returnNegativeMark = "", returnMarkForNegative = "", returnTestofType = "";

        cmd.CommandText = "spGetNewExamDefineDetails";
        cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@userMobileNo", SqlDbType.VarChar).Value = UserMobileNo;
        cmd.Parameters.Add("@teacherMobileNo", SqlDbType.VarChar).Value = TeacherMobileNo;
        cmd.Parameters.Add("@classID", SqlDbType.VarChar).Value = classId;
        cmd.Parameters.Add("@subjectID", SqlDbType.VarChar).Value = subjectId;
        cmd.Parameters.Add("@examID", SqlDbType.VarChar).Value = examid;
        cmd.Parameters.Add("@userType", SqlDbType.VarChar).Value = Usertype;
        cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = 0;

        cmd.Connection.Open();

        adaper.SelectCommand = cmd;
        adaper.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                returnTest_ID += "," + Convert.ToString(ds.Tables[0].Rows[i]["Test_ID"]);
                returnExam_Duration += "," + Convert.ToString(ds.Tables[0].Rows[i]["Exam_Duration"]);
                returnMarkCorrA += "," + Convert.ToString(ds.Tables[0].Rows[i]["MarkCorrA"]);
                returnMarkPass += "," + Convert.ToString(ds.Tables[0].Rows[i]["MarkPass"]);
                returnNegativeMark += "," + Convert.ToString(ds.Tables[0].Rows[i]["NegativeMark"]);
                returnMarkForNegative += "," + Convert.ToString(ds.Tables[0].Rows[i]["MarkforNegative"]);
                returnTestofType += "," + Convert.ToString(ds.Tables[0].Rows[i]["TypeofTest"]);
                returnExam_date += "," + Convert.ToString(ds.Tables[0].Rows[i]["Exam_date"]).Remove(Convert.ToString(ds.Tables[0].Rows[i]["Exam_date"]).Length - 12);
            }


            if (returnTest_ID.Length > 0)
            {
                returnTest_ID = returnTest_ID.Substring(1);
                returnExam_Duration = returnExam_Duration.Substring(1);
                returnMarkCorrA = returnMarkCorrA.Substring(1);
                returnMarkPass = returnMarkPass.Substring(1);
                returnNegativeMark = returnNegativeMark.Substring(1);
                returnMarkForNegative = returnMarkForNegative.Substring(1);
                returnTestofType = returnTestofType.Substring(1);
                returnExam_date = returnExam_date.Substring(1);
            }
            returnString = returnTest_ID + "*" + returnExam_Duration + "*" + returnMarkCorrA + "*" + returnMarkPass + "*" + returnNegativeMark + "*" + returnMarkForNegative + "*" + returnTestofType + "*" + returnExam_date;
        }
        else
        {
            returnString = "105";
        }
        return returnString;
    }

    #endregion

    #region Method to get userName and Password for SocialWelfare

    [WebMethod(Description = "Method to get userName and Password for SocialWelfare")]
    public XmlDocument getUserInfo(string center_No)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        DataSet dataset = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adaper = new SqlDataAdapter();

        try
        {

            cmd.CommandText = "spGetUserInfo";
            cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@centerNo", SqlDbType.VarChar).Value = center_No;
            cmd.Connection.Open();

            adaper.SelectCommand = cmd;
            adaper.Fill(dataset);

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Login", typeof(string)));
            dt.Columns.Add(new DataColumn("Password", typeof(string)));
            dt.Columns.Add(new DataColumn("UserName", typeof(string)));

            int dsCount = dataset.Tables[0].Rows.Count;

            for (int i = 0; i < dsCount; i++)
            {
                dt.Rows.Add(dataset.Tables[0].Rows[i][0].ToString(), cc.DESDecrypt(dataset.Tables[0].Rows[i][1].ToString()), dataset.Tables[0].Rows[i][2].ToString());
            }

            dataset.Tables.RemoveAt(0);
            dataset.Tables.Add(dt);

            xmldoc = new XmlDataDocument(dataset);
            XmlElement xmlelement = xmldoc.DocumentElement;

        }
        catch
        {

        }
        return xmldoc;
    }

    #endregion

    #region Method for AV_TUTOR

    [WebMethod(Description = "Method for AVTutor")]

    public XmlDocument AudioList(string audio)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        DataSet dataset = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adaper = new SqlDataAdapter();
        try
        {

            cmd.CommandText = "spAudioVideoList";
            cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AV_VALUE", SqlDbType.VarChar).Value = audio;
            cmd.Connection.Open();

            adaper.SelectCommand = cmd;
            adaper.Fill(dataset);

            xmldoc = new XmlDataDocument(dataset);
            XmlElement xmlelement = xmldoc.DocumentElement;

        }
        catch
        {

        }
        return xmldoc;
    }
    #endregion

    #region Method for Get Feedback Details

    [WebMethod(Description = "Method to Get Feedback of Users")]
    public int getFeedbackDetails(string firstName, string lastName, string userMobNo, string imei, string typeOfFeedback, string feedbackContent, DateTime date)
    {

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "spGetFeedbackDetails";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        SqlParameter[] parameter = new SqlParameter[]
        {
            new SqlParameter("@firstName",firstName),
            new SqlParameter("@lastName",lastName),
            new SqlParameter("@userMobNo",userMobNo),
            new SqlParameter("@imei",imei),
            new SqlParameter("@typeOfFeedback",typeOfFeedback),
            new SqlParameter("@feedbackContent",feedbackContent),
            new SqlParameter("@feedbackDate",date) 
        };
        cmd.Parameters.AddRange(parameter);
        cmd.Connection.Open();
        int status = cmd.ExecuteNonQuery();
        cmd.Connection.Close();

        return status;

    }
    #endregion

    #region Method to give ItemMaster to App

    [WebMethod(Description = "METHOD TO GIVE ITEM_MASTER FOR EZEETEST APP")]
    public XmlDocument GetItemMaster()
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        DataSet dataset = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adaper = new SqlDataAdapter();

        try
        {

            cmd.CommandText = "spAppItemMaster";
            cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Connection.Open();

            adaper.SelectCommand = cmd;
            adaper.Fill(dataset);

            xmldoc = new XmlDataDocument(dataset);
            XmlElement xmlelement = xmldoc.DocumentElement;

        }
        catch
        {
        }
        return xmldoc;
    }

    #endregion

    #region Method for customTestList Insert

    [WebMethod(Description = "Method for Insert Custom Test List")]
    public int SaveCustomTestList(string testName, float examDuration, string typeofExam, string subjectId, string loginId, string subjectName, string userType, string totalNoofQues, int quesSetRepeat, string chapWiseQues, string examName, string chapterName, string chapterId)
    {
        try
        {
            if (loginId != "9999999999" && loginId != "9292929292" && loginId != "9393939393")
            {
                int testNameCount = 1;
                int j = 0;

                if (typeofExam == "209")
                {
                    typeofExam = "99";
                }
                else if (typeofExam == "210")
                {
                    typeofExam = "99";
                }
                else if (typeofExam == "211")
                {
                    typeofExam = "98";
                }
                else
                {
                    typeofExam = "99";
                }

                DeleteCustomTestDefinition(typeofExam, subjectId, loginId); //Delete Custom test From Mobile App

                for (int count = 0; count < quesSetRepeat; count++)
                {
                    string testNameNew = testName + " Set " + testNameCount;

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "spSaveCustomTestList";
                    sqlCommand.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                    SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@testName",testNameNew),
                new SqlParameter("@examDate",System.DateTime.Now.Date.AddDays(j).ToString("yyyy-MM-dd")),
                new SqlParameter("@examDuration",examDuration),
                new SqlParameter("@level1",1),
                new SqlParameter("@level2",1),
                new SqlParameter("@level3",1),
                new SqlParameter("@typeofMaterial","Competitive Exam"),
                new SqlParameter("@typeofExam",typeofExam),
                new SqlParameter("@classId",16),
                new SqlParameter("@subjectId",subjectId),
                new SqlParameter("@loginId",loginId),
                new SqlParameter("@mediumId","English"),
                new SqlParameter("@markCorrA",1),
                new SqlParameter("@markPass",20),
                new SqlParameter("@retake","No"),
                new SqlParameter("@breakAllow","No"),
                new SqlParameter("@reverseNavi","No"),
                new SqlParameter("@negativeMark","No"),
                new SqlParameter("@markForNegative","0"),
                new SqlParameter("@subjectName",subjectName),
                new SqlParameter("@groupofQues","0"),
                new SqlParameter("@typeofTest","0"),
                new SqlParameter("@indexNo",'0'),
                new SqlParameter("@parentID","2"),
                new SqlParameter("@userType",userType),
                new SqlParameter("@testCreateDate",System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt")),
                new SqlParameter("@totalNoofQues",totalNoofQues),
                new SqlParameter("@chapterWiseQues",chapWiseQues),
                new SqlParameter("@examName",examName),
                new SqlParameter("@className","12th Standard"),
                new SqlParameter("@chapterName",chapterName),
                new SqlParameter("@chapterId",chapterId),
                new SqlParameter("@ownNumber",loginId) 
            };
                    sqlCommand.Parameters.AddRange(parameter);
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();
                    testNameCount++;
                    j++;

                    if (count == 0)
                    {
                        PrepareCustomTest objPCT = new PrepareCustomTest();
                        objPCT.PrepareCustomTest1(loginId, typeofExam, subjectId);
                    }
                }
            }
        }

        catch (SqlException)
        {
            return 0;
        }

        return 1;
    }

    #endregion

    #region Method for Delete CustomTestList as per user

    public void DeleteCustomTestDefinition(string typeofExam, string subjectId, string loginId)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspDeleteCustomTestDef";
            cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlParameter[] parameter = new SqlParameter[] 
        {
            new SqlParameter("@typeofExam",typeofExam),
            new SqlParameter("@classId",16),
            new SqlParameter("@subjectId",subjectId),
            new SqlParameter("@loginId",loginId)
           
        };
            cmd.Parameters.AddRange(parameter);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        catch
        {

        }
    }
    #endregion

    #region Method to Insert or Update CustomTest as per Class,Batch and StudentWise

    [WebMethod(Description = "Method to Insert or Update CustomTest as per Class,Batch and StudentWise")]
    public int InsertCustomTestSetting(string testId, string classId, string batch, string students, string classAdmin, string ownNumber)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspInsertCustomTestSetting";
            cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlParameter[] parameter = new SqlParameter[] 
        {
            new SqlParameter("@testId",testId.Trim()),
            new SqlParameter("@classId",classId.Trim()),
            new SqlParameter("@batch",batch.Trim()),
            new SqlParameter("@students",students.Trim()),
            new SqlParameter("@classAdmin",classAdmin.Trim()),
            new SqlParameter("@ownNumber",ownNumber.Trim())
        };
            cmd.Parameters.AddRange(parameter);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        catch
        {
            return 105;
        }

        return 106;
    }

    #endregion

    #region Method to Send TestList To ClassApp For Result
    [WebMethod(Description = "METHOD TO GET TEST_NAME")]
    public string GetTestListClassApp(int testId)
    {
        string testName = string.Empty;
        string sqlQuery = "SELECT [Exam_name] FROM [tblTestDefinition] WHERE [Test_ID]='" + testId + "'";
        DataSet ds = cc.ExecuteDataset(sqlQuery);
        if (ds.Tables[0].Rows.Count > 0)
        {
            testName = ds.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            testName = "105";
        }
        return testName;
    }

    #endregion

    #region Method to Give eZeeTest App Result To display in eZeeClass App
    [WebMethod(Description = "METHOD TO GET RESULT FROM EZEETEST APP FOR INSTITUTE HEAD/TEACHER")]
    public XmlDocument GetResultFromeZeeTest(int testId, string instituteHeadNumber)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        DataSet dataset = new DataSet();
        DataTable dt = new DataTable();

        try
        {
            string sqlQuery1 = "SELECT DISTINCT [TxtMobNumber] FROM [tblAppScoreReport] WHERE [TestId]='" + testId + "' AND [TeacherMobNo]='" + instituteHeadNumber + "'";
            DataSet dsUserMobNo = cc.ExecuteDataset(sqlQuery1);
            int dscount = dsUserMobNo.Tables[0].Rows.Count;

            if (dscount > 0)
            {
                dt.Columns.Add(new DataColumn("firstName", typeof(string)));
                dt.Columns.Add(new DataColumn("lastName", typeof(string)));
                dt.Columns.Add(new DataColumn("UserMobileNo", typeof(string)));
                dt.Columns.Add(new DataColumn("TxtMobNumber", typeof(string)));
                dt.Columns.Add(new DataColumn("TeacherMobNo", typeof(string)));
                dt.Columns.Add(new DataColumn("IMEI", typeof(string)));
                dt.Columns.Add(new DataColumn("TestId", typeof(string)));
                dt.Columns.Add(new DataColumn("TestDate", typeof(string)));
                dt.Columns.Add(new DataColumn("StartTime", typeof(string)));
                dt.Columns.Add(new DataColumn("EndTime", typeof(string)));
                dt.Columns.Add(new DataColumn("ObtainMarks", typeof(string)));
                dt.Columns.Add(new DataColumn("InCorrectanswered_count", typeof(string)));
                dt.Columns.Add(new DataColumn("NotAnsweredQuestions_count", typeof(string)));
                dt.Columns.Add(new DataColumn("Total", typeof(string)));
                dt.Columns.Add(new DataColumn("Status", typeof(string)));
                dt.Columns.Add(new DataColumn("CorrectAnswered_InDetail", typeof(string)));
                dt.Columns.Add(new DataColumn("InCorrectAnswered_InDetail", typeof(string)));
                dt.Columns.Add(new DataColumn("NotAnsweredQuestions_InDetail", typeof(string)));
                dt.Columns.Add(new DataColumn("ElapsedTime", typeof(string)));
                dt.Columns.Add(new DataColumn("UDISE_Code", typeof(string)));

                DataSet dsUserMarks = new DataSet();

                for (int i = 0; i < dscount; i++)
                {
                    string sqlQuery2 = " SELECT TOP 1 [firstName],[lastName],[UserMobileNo],[TxtMobNumber],[TeacherMobNo],[IMEI],[TestId],[TestDate],[StartTime],[EndTime],([CorrectAnswered_count]) AS ObtainMarks,[InCorrectanswered_count],[NotAnsweredQuestions_count], " +
                                       " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*1) As Total,[Status], " +
                                       " [CorrectAnswered_InDetail],[InCorrectAnswered_InDetail],[NotAnsweredQuestions_InDetail],[ElapsedTime],[UDISE_Code] " +
                                       " FROM [tblAppScoreReport] WHERE [TxtMobNumber]='" + dsUserMobNo.Tables[0].Rows[i][0] + "' AND [TestId]='" + testId + "' AND [TeacherMobNo]='" + instituteHeadNumber + "' ORDER BY [TestDate],[StartTime] ASC ";
                    dsUserMarks = cc.ExecuteDataset(sqlQuery2);

                    dt.Rows.Add(dsUserMarks.Tables[0].Rows[0][0].ToString(), dsUserMarks.Tables[0].Rows[0][1].ToString(), dsUserMarks.Tables[0].Rows[0][2].ToString(), dsUserMarks.Tables[0].Rows[0][3].ToString(), dsUserMarks.Tables[0].Rows[0][4].ToString(), dsUserMarks.Tables[0].Rows[0][5].ToString(), dsUserMarks.Tables[0].Rows[0][6].ToString(), dsUserMarks.Tables[0].Rows[0][7].ToString(), dsUserMarks.Tables[0].Rows[0][8].ToString(), dsUserMarks.Tables[0].Rows[0][9].ToString(), dsUserMarks.Tables[0].Rows[0][10].ToString(), dsUserMarks.Tables[0].Rows[0][11].ToString(), dsUserMarks.Tables[0].Rows[0][12].ToString(), dsUserMarks.Tables[0].Rows[0][13].ToString(), dsUserMarks.Tables[0].Rows[0][14].ToString(), dsUserMarks.Tables[0].Rows[0][15].ToString(), dsUserMarks.Tables[0].Rows[0][16].ToString(), dsUserMarks.Tables[0].Rows[0][17].ToString(), dsUserMarks.Tables[0].Rows[0][18].ToString(), dsUserMarks.Tables[0].Rows[0][19].ToString());
                }
            }

            dataset.Tables.Add(dt);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NoRecord"] = "106";
                dt.Rows.Add(dr);
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            dataset.Tables.Add(dt);
            xmldoc = new XmlDataDocument(dataset);
            XmlElement xmlelement = xmldoc.DocumentElement;
        }

        return xmldoc;
    }

    #endregion

    #region Method to Get eZeeTest App Result All Attempts of Single Test
    [WebMethod(Description = "METHOD TO GET EZEETEST RESULT FOR PARENT/STUDENT ROLE")]
    public XmlDocument ParentGetResultFromeZeeTest(int testId, string parentNumber)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        DataSet dataset = new DataSet();
        DataTable dt = new DataTable();

        try
        {
            string sqlQuery = " SELECT [firstName],[lastName],[UserMobileNo],[TxtMobNumber],[TeacherMobNo],[IMEI],[TestId],[TestDate],[StartTime],[EndTime],([CorrectAnswered_count]) AS ObtainMarks,[InCorrectanswered_count],[NotAnsweredQuestions_count], " +
                              " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*1) As Total, " +
                              " [CorrectAnswered_InDetail],[InCorrectAnswered_InDetail],[NotAnsweredQuestions_InDetail],[ElapsedTime],[UDISE_Code],[ipAddress],[Status] " +
                              " FROM [tblAppScoreReport] WHERE [TestId]='" + testId + "' AND [TxtMobNumber]='" + parentNumber + "' ORDER BY [TestDate],[StartTime] ASC ";

            dataset = cc.ExecuteDataset(sqlQuery);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NoRecord"] = "106";
                dt.Rows.Add(dr);
                dataset.Tables.Add(dt);
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            dataset.Tables.Add(dt);
            xmldoc = new XmlDataDocument(dataset);
            XmlElement xmlelement = xmldoc.DocumentElement;
        }
        return xmldoc;
    }
    #endregion

    #region Method to Give Chapter and Topic Names
    [WebMethod(Description = "METHOD TO GIVE CHAPTER AND TOPICS NAME TO EZEETEST APP CUSTOM TEST")]
    public XmlDocument GiveChapterANDTopicNames(int typeofExamID, int classID, int subjectID)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        DataSet dataset = new DataSet();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adaper = new SqlDataAdapter();

        try
        {
            if (typeofExamID == 209 || typeofExamID == 210 || typeofExamID == 212)
            {
                typeofExamID = 99;
            }
            if (typeofExamID == 211)
            {
                typeofExamID = 98;
            }

            cmd.CommandText = "uspGiveChapterANDTopicName";
            cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@typeofExamID", SqlDbType.Int).Value = typeofExamID;
            cmd.Parameters.Add("@classID", SqlDbType.Int).Value = classID;
            cmd.Parameters.Add("@subjectID", SqlDbType.Int).Value = subjectID;

            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();

            adaper.SelectCommand = cmd;
            adaper.Fill(dataset);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NoRecord"] = "106";
                dt.Rows.Add(dr);
                dataset.Tables.Add(dt);
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
            if (cmd.Connection.State == ConnectionState.Open)
                cmd.Connection.Close();
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            dataset.Tables.Add(dt);
            xmldoc = new XmlDataDocument(dataset);
            XmlElement xmlelement = xmldoc.DocumentElement;
        }

        return xmldoc;
    }

    #endregion

    #region Method To Give Group Of Exam Name.
    [WebMethod(Description = "Method To Give Group Of Exam Name")]
    public string GiveGroupExamName(string MobNo)
    {

        string returnString = string.Empty;
        string result = string.Empty;

        string sql = "select [GroupOfExamId],[GroupOfExamName],[InsertBy] from  [tblDynamicGroupExam] where  [InsertBy]=" + MobNo + " ";
        DataSet ds = cc.ExecuteDataset(sql);


        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
            {

                for (int cols = 0; cols < 3; cols++)
                {
                    if (cols != 3)
                    {
                        returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                    }
                    else
                    {
                        returnString += ds.Tables[0].Rows[rows][cols].ToString();
                    }
                }
                returnString += "#";
            }
            return returnString;
        }
        else
        {
            result = "0";
            return result;
        }
    }
    #endregion

    #region Method To Give Type Of Exam Name.
    [WebMethod(Description = "Method To Give Type Of Exam Name")]
    public string GiveTypeExamName(string MobNo)
    {

        string returnString = string.Empty;
        string result = string.Empty;

        string Sql = "select [TypeOfExamId],[TypeOfExamName],[GroupOfExamId],[InsertBy] from [tblDynamicTypeExam] where [InsertBy]=" + MobNo + " ";//and [TypeOfExamId] IN(244,245,246,247,248,249,250,251,252,253,254,255,256,257,258,259)";
        DataSet ds = cc.ExecuteDataset(Sql);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
            {

                for (int cols = 0; cols < 4; cols++)
                {
                    if (cols != 4)
                    {
                        returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                    }
                    else
                    {
                        returnString += ds.Tables[0].Rows[rows][cols].ToString();
                    }
                }
                returnString += "#";
            }
            return returnString;
        }
        else
        {
            result = "0";
            return result;
        }
    }
    #endregion

    #region Method to download theoryTest Table1
    [WebMethod(Description = "Method to download theory Test table1")]
    public string TheoryTestThryQuesTestDetails(string testid)
    {
        string returnString = string.Empty;
        string result = string.Empty;

        string Sql = "select LoginId,TestID,TestName,MainQuestion,SubQuestion,HeadingText,NoOfQuestion,MarkAllQuestion,ORMainQuestion,QuestionID,Queslanguage,ID from TheoryQuesTestDetails where TestId=" + testid + " ";
        DataSet ds = cc.ExecuteDataset(Sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
            {

                for (int cols = 0; cols < 12; cols++)
                {
                    if (cols != 12)
                    {
                        returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                    }
                    else
                    {
                        returnString += ds.Tables[0].Rows[rows][cols].ToString();
                    }
                }
                returnString += "#";
            }
            return returnString;
        }

        else
        {
            result = "0";
            return result;
        }
    }
    #endregion

    #region Method to download theoryTest table2
    [WebMethod(Description = "Method to download theory Test table2")]
    public string TheoryTesttblT5167(string testid)
    {
        string returnString = string.Empty;
        string result = string.Empty;

        string Sql = "SELECT SNO,Question_id,Question,QType,QuesWithImage,Q1Type,Qhint,hType,Correct_answer,QuestionLevel,TypeofQues,TypeofDB,Sellanguage,TestID FROM tblT5167 where TestID=" + testid + " ";
        DataSet ds = cc.ExecuteDataset(Sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
            {
                for (int cols = 0; cols < 14; cols++)
                {
                    if (cols != 14)
                    {
                        returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                    }
                    else
                    {
                        returnString += ds.Tables[0].Rows[rows][cols].ToString();
                    }
                }
                returnString += "#";
            }
            return returnString;
        }

        else
        {
            result = "0";
            return result;
        }
    }
    #endregion

    #region Method to Give TheoryTestInstruction Details
    [WebMethod(Description = "Method to Give TheoryTestInstruction Deails")]
    public string TheoryTestInstruction(string testid)
    {
        string returnString = string.Empty;
        string result = string.Empty;

        string sql = "SELECT ID,Instruction,TestId,LoginId,Default1,defaultFlag,Testname,Instrulanguage,InstrucIDSet FROM tblInstructionTheory where TestId IN(" + testid + ",1) ";
        DataSet ds = cc.ExecuteDataset(sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
            {
                for (int cols = 0; cols < 9; cols++)
                {
                    if (cols != 9)
                    {
                        returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                    }
                    else
                    {
                        returnString += ds.Tables[0].Rows[rows][cols].ToString();
                    }
                }
                returnString += "#";
            }
            return returnString;
        }
        else
        {
            result = "0";
            return result;
        }
    }
    #endregion

    #region Method to Give Advertisement Details
    [WebMethod(Description = "Method to Give Advertisement Deails")]
    public string GiveAdvertisement(int stateid,int districtid)
    {
        string returnString = string.Empty;
        string result = string.Empty;

        string sql = "SELECT  [Id],[AddType],[StateId],[DistrictId],[AdvContent],[Status],[Count] FROM [tblAdvertise] where [StateId]='" + stateid + "' and [DistrictId]='" + districtid + "'";
        DataSet ds = cc.ExecuteDataset(sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
            {
                for (int cols = 0; cols < 7; cols++)
                {
                    if (cols != 7)
                    {
                        returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                    }
                    else
                    {
                        returnString += ds.Tables[0].Rows[rows][cols].ToString();
                    }
                }
                returnString += "#";
            }
            return returnString;
        }
        else
        {
            result = "105";
            return result;
        }
    }
    #endregion

    //////////Create custom_test and upload question for exam....by Ram kendre

    #region METHOD TO CREATE CUSTOM TEST AND UPLOAD QUESTION 
    [WebMethod(Description = "Custom Test and Upload questions for Exam")]
    public string CustomTestAndUploadQuestion(string testName, float examDuration, string typeofExam, string subjectId, string loginId, string subjectName, string userType, string examName,string NoOfQuestion,string classid,string className)  //, string chapterName, string chapterId)  string totalNoofQues, int quesSetRepeat, string chapWiseQues
    {
        try
        {
            if (loginId != "9999999999" && loginId != "9292929292" && loginId != "9393939393")
            {
                int testNameCount = 1;
                int j = 0;
              
                DeleteCustomTestDefinition(typeofExam, subjectId, loginId); //Delete Custom test From Mobile App

                for (int count = 0; count < NoOfQuestion.Count(); count++)
                {
                    string testNameNew = testName + " Set " + testNameCount;

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "spSaveCustomTestList";
                    sqlCommand.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                    SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@testName",testNameNew),
                new SqlParameter("@examDate",System.DateTime.Now.Date.AddDays(j).ToString("yyyy-MM-dd")),
                new SqlParameter("@examDuration",examDuration),
                new SqlParameter("@level1",1),
                new SqlParameter("@level2",1),
                new SqlParameter("@level3",1),
                new SqlParameter("@typeofMaterial","Competitive Exam"),
                new SqlParameter("@typeofExam",typeofExam),
                new SqlParameter("@classId",classid),
                new SqlParameter("@subjectId",subjectId),
                new SqlParameter("@loginId",loginId),
                new SqlParameter("@mediumId","English"),
                new SqlParameter("@markCorrA",1),
                new SqlParameter("@markPass",20),
                new SqlParameter("@retake","No"),
                new SqlParameter("@breakAllow","No"),
                new SqlParameter("@reverseNavi","No"),
                new SqlParameter("@negativeMark","No"),
                new SqlParameter("@markForNegative","0"),
                new SqlParameter("@subjectName",subjectName),
                new SqlParameter("@groupofQues","0"),
                new SqlParameter("@typeofTest","0"),
                new SqlParameter("@indexNo",'0'),
                new SqlParameter("@parentID","2"),
                new SqlParameter("@userType",userType),
                new SqlParameter("@testCreateDate",System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt")),
              //  new SqlParameter("@totalNoofQues",totalNoofQues),
               // new SqlParameter("@chapterWiseQues",chapWiseQues),
                new SqlParameter("@examName",examName),
                new SqlParameter("@className",className),
               // new SqlParameter("@chapterName",chapterName),
               // new SqlParameter("@chapterId",chapterId),
                new SqlParameter("@ownNumber",loginId) 
            };
                    sqlCommand.Parameters.AddRange(parameter);
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();
                    testNameCount++;
                    j++;

                    if (count == 0)
                    {
                        PrepareCustomTest objPCT = new PrepareCustomTest();
                        objPCT.NewPrepareCustomTest1(loginId, typeofExam, subjectId,classid);
                    }
                }
            }
        }

        catch
        {
            return "0";
        }
        return "1";
    }
    #endregion
}