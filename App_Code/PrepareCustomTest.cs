using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Collections.Generic;
using System.Timers;

/// <summary>
/// Summary description for PrepareCustomTest
/// </summary>
public class PrepareCustomTest
{
    int status, TotalQuetion, AddingQuestion;
    CommonCode cc = new CommonCode();
    public static string Chapter_id = "";
    public static int TypeOFExam = 0;
    public static int Class_id = 0;
    public static int Subject_id = 0;
    public static string Subjectid = "";

    public DataSet dsStatic = null;
    public DataSet dsItemValue = null;
    int j1 = 0, k1;

    string Sql = "", Sqlquery = "", SNOstring = "";
    string lblChapterID = "";
    string testID = "";
    string loginID = "";
    string companyID = "";
    int i1;

	public PrepareCustomTest()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void PrepareCustomTest1(string login, string typeofExam, string subjectId)
    {
        string sqlQuery1 = "Select *from tblTestDefinition Where LoginId IN ('" + login + "') and [TypeOFExam]='" + typeofExam + "' and [Subject_id]='" + subjectId + "' and [Class_id]='16' and [Exam_date]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'";
        DataSet dataset1 = cc.ExecuteDataset(sqlQuery1);
        if (dataset1 != null)
        {
            if (dataset1.Tables[0].Rows.Count > 0)
            {
                for (int a = 0; a < dataset1.Tables[0].Rows.Count; a++)
                {
                    testID = Convert.ToString(dataset1.Tables[0].Rows[a]["Test_ID"]);
                    loginID = Convert.ToString(dataset1.Tables[0].Rows[a]["LoginId"]);

                    //string sqlQurey2 = "Select CompanyId From Login Where LoginId ='" + loginID.ToString() + "'";
                    //companyID = cc.ExecuteScalar(sqlQurey2);

                    PrepareTest();
                }
            }
        }
    }

    public void PrepareTest()
    {
        try
        {
            //string s11 = "tbl" + companyID.ToString();  //Convert.ToString(Session["CompanyId"]);

            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "uspCreateTables";
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            //SqlParameter[] parameter = new SqlParameter[] { 
            //new SqlParameter("@companyID",s11)
            //};
            //cmd.Parameters.AddRange(parameter);
            //cmd.Connection.Open();
            //cmd.ExecuteNonQuery();
            //cmd.Connection.Close();

            DataSet dataset = new DataSet();

            string Login = loginID.ToString();  //Convert.ToString(Session["Loginid"]);

            Sql = "Select SNO from tbl5164 Where TestID='" + testID.ToString() + "'"; //Convert.ToString(Session["CompanyId"])  Convert.ToInt32(Session["TestID"])

            dataset = cc.ExecuteDataset(Sql);

            if (dataset.Tables[0].Rows.Count == 0)
            {
                string SQLQuery = "Select *from tblTestDefinition where Test_ID='" + testID.ToString() + "' and LoginId='" + Login + "'";  //Convert.ToInt32(Session["TestID"])

                dataset = cc.ExecuteDataset(SQLQuery);

                if (dataset.Tables[0].Rows.Count > 0)
                {
                    string sTypeofMaterial = dataset.Tables[0].Rows[0][7].ToString();
                    string sTypeofExam = dataset.Tables[0].Rows[0][8].ToString();
                    string sClassid = dataset.Tables[0].Rows[0][9].ToString();
                    string sSubjectid = dataset.Tables[0].Rows[0][10].ToString();

                    string TotNoQues = dataset.Tables[0].Rows[0][29].ToString();
                    string chawiseques = dataset.Tables[0].Rows[0][30].ToString();
                    string chapterID = dataset.Tables[0].Rows[0][34].ToString();

                    string[] chapwiseques1 = chawiseques.Split('*');


                    var temp = new List<string>();
                    foreach (var s in chapwiseques1)
                    {
                        if (!string.IsNullOrEmpty(s))
                            temp.Add(s);
                    }
                    chapwiseques1 = temp.ToArray();

                    string[] ChapterID1 = chapterID.Split(',');

                    foreach (string label in ChapterID1)
                    {
                        lblChapterID += " ' " + label + " ' " + ",";
                    }

                    if (lblChapterID.ToString() != "")
                    {
                        lblChapterID = lblChapterID.ToString().Substring(0, lblChapterID.ToString().Length - 1);
                    }
                    for (int i = 0; i < ChapterID1.Length; i++)
                    {
                        Sqlquery = @"SELECT [questions] FROM QuestionsUsed where  [userId]='" + Login + "' and [typeofexam]='" + sTypeofExam + "' and [class]='" + sClassid + "' and [subject]='" + sSubjectid + "' and [chapter]='" + ChapterID1[i1] + "'";
                        SNOstring = cc.ExecuteScalar(Sqlquery);

                        if (lblChapterID.ToString() != "")
                        {

                            int noofquestion = 0;
                            if (string.IsNullOrEmpty(SNOstring))
                            {
                                Sql = @" SELECT count(SNO) FROM tblQuestionAccess  where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ")";
                                noofquestion = Convert.ToInt32(cc.ExecuteScalar(Sql));
                                SNOstring = "0";
                            }
                            else
                            {
                                //SNOstring = SNOstring.Substring(1);
                                Sql = @" SELECT count(SNO) FROM tblQuestionAccess  where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ") and SNO NOT IN (" + SNOstring + ")";
                                noofquestion = Convert.ToInt32(cc.ExecuteScalar(Sql));
                            }
                            int qustion = Convert.ToInt32(chapwiseques1[k1]);

                            if (noofquestion > qustion)
                            {
                                //Convert.ToString(Session["CompanyId"])
                                Sql = " insert into " + "tbl5164 " +
                                                               " SELECT Top " + chapwiseques1[k1] + "  SNO,Question_id,Question,QType,Answer1,AType,Answer2,BType,Answer3,CType,Answer4,DType,OptionE,EType,OptionP,PType,OptionQ,QType1,OptionR,RType,OptionS,SType, " +
                                                               " OptionT,TType,Passage,passageType,QuesWithImage,Q1Type,Qhint,hType,Correct_answer,QuestionLevel,MobileNo,SettingId,changeDate,Ischecked,TypeOFExam,TypeofQues,Class_id, " +
                                                               " Subject_id,Chapter_id,Topic_id,QuesVerify,Suggestion,UploaderMoNo,UniqueId,DOUpload,LoginId,checkerLoginId,Test_ID,Image,MediumID,Sellanguage,userClass_id,userSubject_id, " +
                                                               " userChapter_id,userTopic_id,userCompitativeExam,TypeofMaterial,TypeofDB,examQwener,flag,createdate,UploadFileName,Class_AdmVerify,Class_AdmSuggest,Class_AdmLogin,PublicationName, " +
                                                               " '" + testID.ToString() + "','" + Login + "'	FROM tblQuestionAccess " +
                                                               " where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ") and SNO NOT IN (" + SNOstring + ")";
                                //Convert.ToInt32(Session["TestID"])
                                int status1 = cc.ExecuteNonQuery(Sql);

                                Sql = @" SELECT Top " + chapwiseques1[k1] + " SNO FROM tblQuestionAccess  where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ") and SNO NOT IN (" + SNOstring + ")";
                                dataset = cc.ExecuteDataset(Sql);
                                string s = "";
                                for (int ia = 0; ia < dataset.Tables[0].Rows.Count; ia++)
                                    s += "," + dataset.Tables[0].Rows[ia][0].ToString() + "";

                                s = s.Substring(1);

                                if (SNOstring == "0")
                                {
                                    string sql = @"insert into QuestionsUsed ([userId],[typeofexam],[class],[subject],[chapter],[questions]) values('" + Login + "','" + sTypeofExam + "','" + sClassid + "','" + sSubjectid + "','" + ChapterID1[i1] + "','" + s + "')";
                                    status1 = cc.ExecuteNonQuery(sql);
                                }
                                else
                                {
                                    string s1 = SNOstring + "," + s;
                                    string sql = @"update QuestionsUsed set [questions]='" + s1 + "' where [userId]='" + Login + "' and [typeofexam]='" + sTypeofExam + "' and [class]='" + sClassid + "' and [subject]='" + sSubjectid + "' and [chapter]='" + ChapterID1[i1] + "' ";
                                    status1 = cc.ExecuteNonQuery(sql);
                                }
                            }
                            else
                            {
                                string s2 = "";

                                Sql = " insert into " + "tbl5164 " +
                                                               " SELECT Top " + noofquestion + "  SNO,Question_id,Question,QType,Answer1,AType,Answer2,BType,Answer3,CType,Answer4,DType,OptionE,EType,OptionP,PType,OptionQ,QType1,OptionR,RType,OptionS,SType, " +
                                                               " OptionT,TType,Passage,passageType,QuesWithImage,Q1Type,Qhint,hType,Correct_answer,QuestionLevel,MobileNo,SettingId,changeDate,Ischecked,TypeOFExam,TypeofQues,Class_id, " +
                                                               " Subject_id,Chapter_id,Topic_id,QuesVerify,Suggestion,UploaderMoNo,UniqueId,DOUpload,LoginId,checkerLoginId,Test_ID,Image,MediumID,Sellanguage,userClass_id,userSubject_id, " +
                                                               " userChapter_id,userTopic_id,userCompitativeExam,TypeofMaterial,TypeofDB,examQwener,flag,createdate,UploadFileName,Class_AdmVerify,Class_AdmSuggest,Class_AdmLogin,PublicationName, " +
                                                               " '" + testID.ToString() + "','" + Login + "'	FROM tblQuestionAccess " +
                                                               " where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ") and SNO NOT IN (" + SNOstring + ")";
                                int status1 = cc.ExecuteNonQuery(Sql);

                                Sql = @" SELECT Top " + chapwiseques1[k1] + " SNO FROM tblQuestionAccess  where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ") and SNO NOT IN (" + SNOstring + ")";
                                dataset = cc.ExecuteDataset(Sql);
                                string s = "";
                                for (int ia = 0; ia < dataset.Tables[0].Rows.Count; ia++)
                                    s += "," + dataset.Tables[0].Rows[ia][0].ToString() + "";
                                s = s.Substring(1);

                                noofquestion = qustion - noofquestion;
                                if (SNOstring == "'0'")
                                {
                                    s = SNOstring;
                                }

                                Sql = " insert into " + "tbl5164 " +
                                                               " SELECT Top " + noofquestion + "  SNO,Question_id,Question,QType,Answer1,AType,Answer2,BType,Answer3,CType,Answer4,DType,OptionE,EType,OptionP,PType,OptionQ,QType1,OptionR,RType,OptionS,SType, " +
                                                               " OptionT,TType,Passage,passageType,QuesWithImage,Q1Type,Qhint,hType,Correct_answer,QuestionLevel,MobileNo,SettingId,changeDate,Ischecked,TypeOFExam,TypeofQues,Class_id, " +
                                                               " Subject_id,Chapter_id,Topic_id,QuesVerify,Suggestion,UploaderMoNo,UniqueId,DOUpload,LoginId,checkerLoginId,Test_ID,Image,MediumID,Sellanguage,userClass_id,userSubject_id, " +
                                                               " userChapter_id,userTopic_id,userCompitativeExam,TypeofMaterial,TypeofDB,examQwener,flag,createdate,UploadFileName,Class_AdmVerify,Class_AdmSuggest,Class_AdmLogin,PublicationName, " +
                                                               " '" + testID.ToString() + "','" + Login + "'	FROM tblQuestionAccess " +
                                                               " where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ") and SNO NOT IN (" + s + ")";
                                status1 = cc.ExecuteNonQuery(Sql);

                                Sql = @" SELECT Top " + noofquestion + " SNO FROM tblQuestionAccess  where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ") and SNO NOT IN (" + s + ")";
                                dataset = cc.ExecuteDataset(Sql);

                                for (int ia = 0; ia < dataset.Tables[0].Rows.Count; ia++)
                                    s2 += "," + dataset.Tables[0].Rows[ia][0].ToString() + "";


                                if (SNOstring == "0")
                                {
                                    string sql = @"insert into QuestionsUsed ([userId],[typeofexam],[class],[subject],[chapter],[questions]) values('" + Login + "','" + sTypeofExam + "','" + sClassid + "','" + sSubjectid + "','" + ChapterID1[i1] + "','" + s + "')";
                                    status1 = cc.ExecuteNonQuery(sql);
                                }
                                else
                                {
                                    string s1 = s2 + "," + s;
                                    s1 = s1.Substring(1);

                                    string sql = @"update QuestionsUsed set [questions]='" + s1 + "' where [userId]='" + Login + "' and [typeofexam]='" + sTypeofExam + "' and [class]='" + sClassid + "' and [subject]='" + sSubjectid + "' and [chapter]='" + ChapterID1[i1] + "' ";
                                    status1 = cc.ExecuteNonQuery(sql);
                                }
                            }
                            k1++; i1++;
                        }
                    }
                }
            }
        }
        catch
        {

        }
    }

    public void NewPrepareCustomTest1(string login, string typeofExam, string subjectId,string classid)
    {
        string sqlQuery1 = "Select *from tblTestDefinition Where LoginId IN ('" + login + "') and [TypeOFExam]='" + typeofExam + "' and [Subject_id]='" + subjectId + "' and [Class_id]='" + classid + "' and [Exam_date]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'";
        DataSet dataset1 = cc.ExecuteDataset(sqlQuery1);
        if (dataset1 != null)
        {
            if (dataset1.Tables[0].Rows.Count > 0)
            {
                for (int a = 0; a < dataset1.Tables[0].Rows.Count; a++)
                {
                    testID = Convert.ToString(dataset1.Tables[0].Rows[a]["Test_ID"]);
                    loginID = Convert.ToString(dataset1.Tables[0].Rows[a]["LoginId"]);

                    NewPrepareTest();
                }
            }
        }
    }

    public void NewPrepareTest()
    {
        try
        {
            Sql = "insert into [tblEzeeTestQuestion]([Question],[optionA],[optionB],[optionC],[optionD],[optionE],[Answer],[classid],[subjectid],[Testid],[CreatedBy],[CreatedDate],Imei],[LoginId])" +
                   "Values()";
            status = cc.ExecuteNonQuery(Sql);
        }
        catch
        {

        }
    }
}
