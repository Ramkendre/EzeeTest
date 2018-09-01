using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

public partial class SubAdmin_RSBTestHome : System.Web.UI.Page
{

    CommonCode cc = new CommonCode();

    string Sql = "", Sqlquery = "", SNOstring = "";
    int status;
    int i1, j1, k1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gettest();
        }

    }


    string Test_ID = "";
    void gettest()
    {
        string sql = "";
        string Usertype = Convert.ToString(Session["UserType"]);

        if (Usertype == "2")
        {
            sql = " select Test_ID from tblTestDefinition where LoginID='" + Convert.ToString(Session["Loginid"]) + "' or (LoginID='' and (UserType='1' or UserType='2'))  ";//where NewQID<=150"; 

        }
        else if (Usertype == "3")
        {
            sql = " select Test_ID from tblTestDefinition where LoginID='" + Convert.ToString(Session["Loginid"]) + "' or (LoginID='' and (UserType='1' or UserType='2' or UserType='3'))  ";//where NewQID<=150"; 

        }
        else if (Usertype == "4")
        {
            sql = " select Test_ID from tblTestDefinition where LoginID='" + Convert.ToString(Session["Loginid"]) + "' or (LoginID='' and (UserType='1' or UserType='2' or UserType='3' or UserType='4'))  ";//where NewQID<=150"; 

        }
        else
        {
            sql = " select Test_ID from tblTestDefinition where LoginID='" + Convert.ToString(Session["Loginid"]) + "' or (LoginID='' and UserType='1') ";


        }


        DataSet ds = cc.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Test_ID = Test_ID + "," + Convert.ToString(ds.Tables[0].Rows[i]["Test_ID"]);

            }

            Test_ID = Test_ID.Substring(1);



            string Sql = "select Test_ID, Exam_Name from tblTestDefinition where Test_ID in(" + Test_ID + ") ";
            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddltest.DataSource = ds.Tables[0];
                ddltest.DataTextField = "Exam_Name";
                ddltest.DataValueField = "Test_ID";
                ddltest.DataBind();
                ddltest.Items.Add("--Select--");
                ddltest.SelectedIndex = ddltest.Items.Count - 1;

            }

        }
    }
    protected void ddltest_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltest.SelectedIndex == ddltest.Items.Count - 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Exam Name')", true);

        }
        else
        {
            Session["TestID"] = ddltest.SelectedValue;
            Session["TestName"] = ddltest.SelectedItem.Text;

            PrepareTest();

            createCookie();
            Response.Redirect("~/SubAdmin/RSBexTest.aspx");

        }
    }

    void createCookie()
    {
        /************ Add Session in Cookie ***************/

        HttpCookie cookie = new HttpCookie("Credentials");
        cookie.Values.Add("ezeeUser123", Session["UserName"].ToString());// your x value
        cookie.Values.Add("mobNo", Session["LoginId"].ToString()); // your y value

        cookie.Values.Add("CompanyId", Session["CompanyId"].ToString());
        cookie.Values.Add("TestID", Session["TestID"].ToString());

        cookie.Expires = DateTime.Now.AddDays(365); // --------> cookie.Expires is the property you can set timeout
        HttpContext.Current.Response.AppendCookie(cookie);
    }





    private void PrepareTest()
    {
        try
        {
            string s11 = "tbl" + Convert.ToString(Session["CompanyId"]);
            try
            {
                Sql = "select * from  " + s11 + " ";
                status = cc.ExecuteNonQuery(Sql);
            }
            catch
            {

            }

            if (status != -1)
            {
                string queryString =
                                    @"
               CREATE TABLE MyTable
                (
                    
	[SNO] [int] NULL,
	[Question_id] [int] NOT NULL,
	[Question] [nvarchar](max) NULL,
	[QType] [int] NULL,
	[Answer1] [nvarchar](max) NULL,
	[AType] [int] NULL,
	[Answer2] [nvarchar](max) NULL,
	[BType] [int] NULL,
	[Answer3] [nvarchar](max) NULL,
	[CType] [int] NULL,
	[Answer4] [nvarchar](max) NULL,
	[DType] [int] NULL,
	[OptionE] [nvarchar](max) NULL,
	[EType] [int] NULL,
	[OptionP] [nvarchar](max) NULL,
	[PType] [int] NULL,
	[OptionQ] [nvarchar](max) NULL,
	[QType1] [int] NULL,
	[OptionR] [nvarchar](max) NULL,
	[RType] [int] NULL,
	[OptionS] [nvarchar](max) NULL,
	[SType] [int] NULL,
	[OptionT] [nvarchar](max) NULL,
	[TType] [int] NULL,
	[Passage] [nvarchar](max) NULL,
	[passageType] [int] NULL,
	[QuesWithImage] [nvarchar](max) NULL,
	[Q1Type] [int] NULL,
	[Qhint] [nvarchar](max) NULL,
	[hType] [int] NULL,
	[Correct_answer] [nvarchar](50) NULL,
	[QuestionLevel] [int] NULL,
	[MobileNo] [nvarchar](15) NULL,
	[SettingId] [int] NULL,
	[changeDate] [nvarchar](50) NULL,
	[Ischecked] [int] NULL,
	[TypeOFExam] [int] NULL,
	[TypeofQues] [int] NULL,
	[Class_id] [int] NULL,
	[Subject_id] [int] NULL,
	[Chapter_id] [int] NULL,
	[Topic_id] [int] NULL,
	[QuesVerify] [nvarchar](4) NULL,
	[Suggestion] [nvarchar](max) NULL,
	[UploaderMoNo] [nvarchar](12) NULL,
	[UniqueId] [int] NULL,
	[DOUpload] [nvarchar](22) NULL,
	[LoginId] [nvarchar](50) NULL,
	[checkerLoginId] [nvarchar](50) NULL,
	[Test_ID] [int] NULL,
	[Image] [nvarchar](max) NULL,
	[MediumID] [nvarchar](50) NULL,
	[Sellanguage] [nvarchar](50) NULL,
	[userClass_id] [nvarchar](40) NULL,
	[userSubject_id] [nvarchar](50) NULL,
	[userChapter_id] [nvarchar](40) NULL,
	[userTopic_id] [nvarchar](40) NULL,
	[userCompitativeExam] [nvarchar](50) NULL,
	[TypeofMaterial] [nvarchar](40) NULL,
	[TypeofDB] [nvarchar](10) NULL,
	[examQwener] [nvarchar](50) NULL,
	[flag] [int] NULL,
	[createdate] [datetime] NULL,
	[UploadFileName] [nvarchar](200) NULL,
	[Class_AdmVerify] [nvarchar](9) NULL,
	[Class_AdmSuggest] [nvarchar](200) NULL,
	[Class_AdmLogin] [nvarchar](50) NULL,
	[PublicationName] [nvarchar](200) NULL,
	[TestID] [nvarchar](10) NULL,
    [TestCreaterID] [nvarchar](50) NULL
	)
                
CREATE NONCLUSTERED INDEX [QAccess5] ON [dbo].[MyTableatul2] 
(
[TestID]  ASC,
	[TypeofMaterial] ASC,
	[TypeOFExam] ASC,
	[Class_id] ASC,
	[Subject_id] ASC,
	[Chapter_id] ASC,
	[TypeofDB] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

                ";

                queryString = queryString.Replace("MyTable", s11);

                status = cc.ExecuteNonQuery(queryString);
            }

            if (status == -1)
            {
                DataSet dataset = new DataSet();

                string Login = Convert.ToString(Session["Loginid"]);

                Sql = "Select SNO from " + "tbl" + Convert.ToString(Session["CompanyId"]) + " Where TestID='" + Convert.ToInt32(Session["TestID"]) + "'";

                dataset = cc.ExecuteDataset(Sql);

                if (dataset.Tables[0].Rows.Count == 0)
                {

                    string SQLQuery = "Select *from tblTestDefinition where Test_ID='" + Convert.ToInt32(Session["TestID"]) + "' and LoginId='" + Login + "'";

                    dataset = cc.ExecuteDataset(SQLQuery);

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
                        lblChapterID.Text += " ' " + label + " ' " + ",";
                    }

                    if (lblChapterID.Text != "")
                    {
                        lblChapterID.Text = lblChapterID.Text.Substring(0, lblChapterID.Text.Length - 1);
                    }





                    for (int i = 0; i < ChapterID1.Length; i++)
                    {
                        Sqlquery = @"SELECT [questions] FROM QuestionsUsed where  [userId]='" + Login + "' and [typeofexam]='" + sTypeofExam + "' and [class]='" + sClassid + "' and [subject]='" + sSubjectid + "' and [chapter]='" + ChapterID1[i1] + "'";
                        SNOstring = cc.ExecuteScalar(Sqlquery);

                        

                        if (lblChapterID.Text != "")
                        {
                            chapwiseques1[k1].Trim();
                            ChapterID1[i1].Trim();

                            int noofquestion = 0;
                            if (string.IsNullOrEmpty(SNOstring))
                            {
                                Sql = @" SELECT count(SNO) FROM tblQuestionAccess  where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ")";
                                noofquestion = Convert.ToInt32(cc.ExecuteScalar(Sql));
                                SNOstring = "0";
                            }
                            else
                            {
                                SNOstring = SNOstring.Substring(1);
                                Sql = @" SELECT count(SNO) FROM tblQuestionAccess  where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ") and SNO NOT IN (" + SNOstring + ")";
                                noofquestion = Convert.ToInt32(cc.ExecuteScalar(Sql));
                            }
                            int qustion = Convert.ToInt32(chapwiseques1[k1]);
                            if (noofquestion > qustion)
                            {
                                Sql = " insert into " + "tbl" + Convert.ToString(Session["CompanyId"]) + " " +
                                                               " SELECT Top " + chapwiseques1[k1] + "  SNO,Question_id,Question,QType,Answer1,AType,Answer2,BType,Answer3,CType,Answer4,DType,OptionE,EType,OptionP,PType,OptionQ,QType1,OptionR,RType,OptionS,SType, " +
                                                               " OptionT,TType,Passage,passageType,QuesWithImage,Q1Type,Qhint,hType,Correct_answer,QuestionLevel,MobileNo,SettingId,changeDate,Ischecked,TypeOFExam,TypeofQues,Class_id, " +
                                                               " Subject_id,Chapter_id,Topic_id,QuesVerify,Suggestion,UploaderMoNo,UniqueId,DOUpload,LoginId,checkerLoginId,Test_ID,Image,MediumID,Sellanguage,userClass_id,userSubject_id, " +
                                                               " userChapter_id,userTopic_id,userCompitativeExam,TypeofMaterial,TypeofDB,examQwener,flag,createdate,UploadFileName,Class_AdmVerify,Class_AdmSuggest,Class_AdmLogin,PublicationName, " +
                                                               " '" + Convert.ToInt32(Session["TestID"]) + "','" + Login + "'	FROM tblQuestionAccess " +
                                                               " where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ") and SNO NOT IN (" + SNOstring + ")";

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

                                Sql = " insert into " + "tbl" + Convert.ToString(Session["CompanyId"]) + " " +
                                                               " SELECT Top " + noofquestion + "  SNO,Question_id,Question,QType,Answer1,AType,Answer2,BType,Answer3,CType,Answer4,DType,OptionE,EType,OptionP,PType,OptionQ,QType1,OptionR,RType,OptionS,SType, " +
                                                               " OptionT,TType,Passage,passageType,QuesWithImage,Q1Type,Qhint,hType,Correct_answer,QuestionLevel,MobileNo,SettingId,changeDate,Ischecked,TypeOFExam,TypeofQues,Class_id, " +
                                                               " Subject_id,Chapter_id,Topic_id,QuesVerify,Suggestion,UploaderMoNo,UniqueId,DOUpload,LoginId,checkerLoginId,Test_ID,Image,MediumID,Sellanguage,userClass_id,userSubject_id, " +
                                                               " userChapter_id,userTopic_id,userCompitativeExam,TypeofMaterial,TypeofDB,examQwener,flag,createdate,UploadFileName,Class_AdmVerify,Class_AdmSuggest,Class_AdmLogin,PublicationName, " +
                                                               " '" + Convert.ToInt32(Session["TestID"]) + "','" + Login + "'	FROM tblQuestionAccess " +
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

                                Sql = " insert into " + "tbl" + Convert.ToString(Session["CompanyId"]) + " " +
                                                               " SELECT Top " + noofquestion + "  SNO,Question_id,Question,QType,Answer1,AType,Answer2,BType,Answer3,CType,Answer4,DType,OptionE,EType,OptionP,PType,OptionQ,QType1,OptionR,RType,OptionS,SType, " +
                                                               " OptionT,TType,Passage,passageType,QuesWithImage,Q1Type,Qhint,hType,Correct_answer,QuestionLevel,MobileNo,SettingId,changeDate,Ischecked,TypeOFExam,TypeofQues,Class_id, " +
                                                               " Subject_id,Chapter_id,Topic_id,QuesVerify,Suggestion,UploaderMoNo,UniqueId,DOUpload,LoginId,checkerLoginId,Test_ID,Image,MediumID,Sellanguage,userClass_id,userSubject_id, " +
                                                               " userChapter_id,userTopic_id,userCompitativeExam,TypeofMaterial,TypeofDB,examQwener,flag,createdate,UploadFileName,Class_AdmVerify,Class_AdmSuggest,Class_AdmLogin,PublicationName, " +
                                                               " '" + Convert.ToInt32(Session["TestID"]) + "','" + Login + "'	FROM tblQuestionAccess " +
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
                        //if (status1 >= 1)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "msg(' " + status1 + " Question Added Successfully')", true);
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Selected Question Already Exist.');", true);

                        //}

                    }

                }

            }

        }
        catch (Exception ex)
        {

        }
    }

}
