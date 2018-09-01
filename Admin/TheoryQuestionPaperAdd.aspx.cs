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
using System.Data.SqlClient;

public partial class Admin_TheoryQuestionPaperAdd : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    TestDefinationBLL testDefBAL = new TestDefinationBLL();
    AssignQuestionInExamBAL assignQuestioninexamBal = new AssignQuestionInExamBAL();

    string Sql;
    int status;
    DataSet ds = null;
    public DataSet dsStatic = null;
    public DataSet dsItemValue = null;

    public static string Chapter_id = "";
    public static int TypeOFExam = 0;
    public static int Class_id = 0;
    public static int Subject_id = 0;
    public static string Subjectid = "";

    public static string initialQHE = "Q.";
    public static string initialQHM = "प्र.";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            loadTestName();
            string a1 = "0";
            loadMainHeading(a1);
            MultiView1.ActiveViewIndex = 0;
            rdoQueslanguage.SelectedValue = "0";
            lblInitialQues.Text = initialQHE;
            rdoInstruLang.SelectedValue = "0";
            rdolstIsSubQues.SelectedValue = "1";

            instruBind();
        }
    }

    public void loadTestName()
    {
        testDefBAL.LoginId1 = Convert.ToString(Session["LoginId"]);  //use sp
        testDefBAL.GroupOfQuestion1 = "1";

        DataSet ds = testDefBAL.TestbyGroupofQuesLoginId5(testDefBAL);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddltestName.DataSource = ds.Tables[0];
            ddltestName.DataTextField = "Exam_name";
            ddltestName.DataValueField = "Test_ID";
            ddltestName.DataBind();
            ddltestName.Items.Add("--Select--");
            ddltestName.SelectedIndex = ddltestName.Items.Count - 1;
            cmbSelectsubject.Items.Add("--Select--");
            cmbSelectsubject.SelectedIndex = cmbSelectsubject.Items.Count - 1;
        }
    }

    protected void btnStart_Click1(object sender, EventArgs e)
    {
        try
        {
            if (ddltestName.SelectedIndex == ddltestName.Items.Count - 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Exam Name')", true);
            }
            else if ((ddlMainHead.SelectedItem.Text == "--Select--") && (txtMainHead.Text == ""))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select or Enter Heading for Questions')", true);
            }
            else
            {
                //Chapter_id = Convert.ToString(rdoLevelList1.SelectedValue);
                string chapterID = "";
                Session["QuestionID"] = "";
                for (int c = 0; c < rdoLevelList1.Items.Count; c++)      //rdoLevelList1
                {
                    if (rdoLevelList1.Items[c].Selected == true)
                    {
                        chapterID = chapterID + "," + rdoLevelList1.Items[c].Value;
                    }
                }

                if (ddltestName.SelectedIndex == ddltestName.Items.Count - 1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Exam Name')", true);
                }
                else if (cmbSelectsubject.SelectedIndex == cmbSelectsubject.Items.Count - 1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Subject Name')", true);
                }
                else if (chapterID == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Chapter')", true);
                }
                else
                {
                    MultiView1.SetActiveView(View2);
                    QuesNo();
                }
            }
        }
        catch
        {

        }
    }

    public void QuesNo()
    {
        try
        {
            string TypeOFExam = "", TypeofMaterial = "";

            testDefBAL.LoginId1 = Convert.ToString(Session["LoginId"]);  //use sp
            testDefBAL.Test_ID1 = Convert.ToInt32(ddltestName.SelectedValue);
            DataSet ds = testDefBAL.getAssignTestDetails(testDefBAL);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                TypeOFExam = Convert.ToString(ds.Tables[0].Rows[0]["TypeOFExam"]);
                TypeofMaterial = Convert.ToString(ds.Tables[0].Rows[0]["TypeofMaterial"]);
                Class_id = Convert.ToInt32(ds.Tables[0].Rows[0]["Class_id"]);
                Subjectid = Convert.ToString(ds.Tables[0].Rows[0]["Subject_id"]);

                Sql = "SELECT * FROM tblAssignExamChapter WHERE LoginId='" + Session["LoginId"] + "' AND TestID=" + ddltestName.SelectedValue + " ";
                ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Chapter_id = Convert.ToString(ddlChapter.SelectedValue);
                    string chapterID = "";
                    for (int c = 0; c < ddlChapter.Items.Count; c++)
                    {
                        if (ddlChapter.Items[c].Selected == true)
                        {
                            chapterID = chapterID + "," + ddlChapter.Items[c].Value;
                        }
                    }

                    if (chapterID.Length > 1)
                    {
                        chapterID = chapterID.Substring(1);
                    }

                    string s11 = Convert.ToString(Session["CompanyId"]) + "" + Convert.ToString(Session["TestID"]);

                    try
                    {
                        Sql = " DROP VIEW tbll" + s11 + "";
                        int i = cc.ExecuteNonQuery(Sql);
                    }
                    catch
                    {
                    }

                    if (Class_id == 1)
                    {
                        Sql = " CREATE VIEW tbll" + s11 + " AS  " +
                              " SELECT ROW_NUMBER() OVER( ORDER BY Question_id) NewQID,  * " +
                              "    FROM " +
                              "   (SELECT SNO,Question_id  ,Question,QType  ,QuesWithImage ,Q1Type,TypeofQues,Correct_answer,QuestionLevel,Qhint,hType,[TypeofDB],Sellanguage FROM tblQuestionAccess WHERE  TypeOFExam=" + TypeOFExam + " AND QuestionLevel=" + rdoLevelList1.SelectedValue + "  AND Subject_id =" + cmbSelectsubject.SelectedValue + " AND TypeofQues='93' )  AS MyResults "; //TypeofQues='93'
                        if (chapterID != "")
                            Sql = " CREATE   VIEW tbll" + s11 + " AS  " +
                                  " SELECT ROW_NUMBER() OVER( ORDER BY Question_id) NewQID,  * " +
                                  "    FROM " +
                                  "   (SELECT SNO,Question_id  ,Question,QType  ,QuesWithImage ,Q1Type,TypeofQues,Correct_answer,QuestionLevel,Qhint,hType,[TypeofDB],Sellanguage from tblQuestionAccess WHERE  TypeOFExam=" + TypeOFExam + " AND QuestionLevel=" + rdoLevelList1.SelectedValue + "  AND Subject_id =" + cmbSelectsubject.SelectedValue + " AND Chapter_id in(" + chapterID + ") AND TypeofQues='93')  AS MyResults "; //TypeofQues='93'
                    }
                    else
                    {
                        Sql = " CREATE   VIEW tbll" + s11 + " AS  " +
                             " SELECT ROW_NUMBER() OVER( ORDER BY Question_id) NewQID,  * " +
                             "    FROM " +
                             "   (SELECT SNO,Question_id  ,Question,QType  ,QuesWithImage ,Q1Type,TypeofQues,Correct_answer,QuestionLevel,Qhint,hType,TypeofDB,Sellanguage from tblQuestionAccess WHERE  TypeOFExam=" + TypeOFExam + " AND QuestionLevel=" + rdoLevelList1.SelectedValue + " AND Class_id=" + Class_id + " AND Subject_id =" + cmbSelectsubject.SelectedValue + " AND TypeofQues='93' )  AS MyResults "; //TypeofQues='93'
                        if (chapterID != "")
                            Sql = " CREATE   VIEW tbll" + s11 + " AS  " +
                                  " SELECT ROW_NUMBER() OVER( ORDER BY Question_id) NewQID,  * " +
                                  "    FROM " +
                                  "   (SELECT SNO,Question_id  ,Question,QType  ,QuesWithImage ,Q1Type,TypeofQues,Correct_answer,QuestionLevel,Qhint,hType,TypeofDB,Sellanguage from tblQuestionAccess WHERE  TypeOFExam=" + TypeOFExam + " AND QuestionLevel=" + rdoLevelList1.SelectedValue + " AND Class_id=" + Class_id + " AND Subject_id =" + cmbSelectsubject.SelectedValue + " AND Chapter_id in(" + chapterID + ") AND TypeofQues='93' )  AS MyResults "; //
                    }

                    int k = cc.ExecuteNonQuery(Sql);

                    string viewtblName = "tbll" + s11 + " ";

                    Sql = "SELECT COUNT(*) FROM " + viewtblName + " ";
                    string tempcount = cc.ExecuteScalar(Sql);
                    lblcount.Text = "TOTAL NUMBER OF QUESTIONS : " + tempcount;

                    assignQuestioninexamBal.ViewtblName1 = viewtblName;
                    assignQuestioninexamBal.NewQID1 = 1;

                    assignQuestioninexamBal.ViewtblName1 = viewtblName;
                    dsStatic = assignQuestioninexamBal.SelectQuestionAssignVIEW(assignQuestioninexamBal);

                    if (dsStatic.Tables[0].Rows.Count == 0)
                    {
                        MultiView1.SetActiveView(View1);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('No Question found for this combination ')", true);
                    }
                    else
                    {
                        fetchCommonData(dsStatic.Tables[0].Rows[0]);
                    }
                }
                else
                {
                    TypeOFExam = "";
                    Class_id = 0;
                    Subject_id = 0;
                    Chapter_id = "";
                    MultiView1.SetActiveView(View1);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Assign Chapter or Subject to Test Name')", true);
                }
            }
        }
        catch
        {
        }
    }

    public string TypeofQues = "";
    //public string QType = "", Q1Type = "", hType = "";
    //public string TypeDB = "";
    //public string TypeofQues = "";
    public string QType = "", Q1Type = "", AType = "", BType = "", CType = "", DType = "", EType = "", PType = "", RType = "", QType1 = "",
        SType = "", TType = "", passageType = "", hType = "";
    public string TypeDB = "", lang = "";
    public static string hintDB = "";
    public int settingid1 = 0;


    void fetchCommonData(DataRow row)
    {
        string loginId = Convert.ToString(Session["LoginId"]);
        string s11 = Convert.ToString(Session["CompanyId"]) + "" + Convert.ToString(Session["TestID"]);

        clearcontrol();

        if (row.ItemArray.Count() > 0)
        {

            int QId = Convert.ToInt32(row["Question_id"]);
            int NewQID = Convert.ToInt32(row["NewQID"]);
            lblQNo.Text = Convert.ToString(NewQID);

            lblQuestion_id.Text = Convert.ToString(QId);
            lblSno.Text = Convert.ToString(row["SNO"]);

            QType = Convert.ToString(row["QType"]);
            Q1Type = Convert.ToString(row["Q1Type"]);
            hType = Convert.ToString(row["hType"]);
            TypeDB = Convert.ToString(row["TypeofDB"]);
            lang = Convert.ToString(row["Sellanguage"]);

            string level = Convert.ToString(row["QuestionLevel"]);
            if (level == "1")
                rdoLevelList.SelectedIndex = 0;
            if (level == "2")
                rdoLevelList.SelectedIndex = 1;
            if (level == "3")
                rdoLevelList.SelectedIndex = 2;

            TypeofQues = Convert.ToString(row["TypeofQues"]);

            string Sql = "SELECT Name,ItemValueId FROM tblItemValue";
            dsItemValue = cc.ExecuteDataset(Sql);

            DataRow[] dr = dsItemValue.Tables[0].Select("ItemValueId=" + TypeofQues);

            string ans = Convert.ToString(row["Correct_answer"]);

            if (TypeDB == "Access")
            {
                QType = Convert.ToString(row["QType"]);
                Q1Type = Convert.ToString(row["Q1Type"]);
                hType = Convert.ToString(row["hType"]);

                //settingid1 = Convert.ToInt32(row["SettingId"]);
            }
            else if (TypeDB == "Excel" && lang == "Marathi")
            {
                QType = "1";
                Q1Type = "1";
                hType = "1";
            }
            else if (TypeDB == "Excel" && lang == "English")
            {
                QType = "0";
                Q1Type = "0";
                hType = "0";
            }
            else if (TypeDB == "Excel" && lang == "MarathiMangal")
            {
                QType = "3";
                Q1Type = "3";
                hType = "3";
            }


            if (TypeofQues == "93")
            {
                txtAns.Text = ans;
                txtAns.Visible = true;
            }

            if (QType == "0")
            {
                string s = Convert.ToString(row["Question"]);
                s = s.Replace("@011", "'");
                lblQuestion.Text = s;

                lblQuestion.Visible = true;
                lblQuestion.Font.Name = "Times New Roman";
                lblQuestion.Font.Size = 12;
                imgQues.Visible = false;
            }
            else if (QType == "1")
            {
                string s = Convert.ToString(row["Question"]);
                s = s.Replace("@011", "'");
                lblQuestion.Text = s;
                lblQuestion.Visible = true;
                lblQuestion.Font.Name = "Mangal";
                lblQuestion.Font.Size = 14;
                imgQues.Visible = false;
            }
            else if (QType == "3")
            {
                string s = Convert.ToString(row["Question"]);
                s = s.Replace("@011", "'");
                lblQuestion.Text = s;
                lblQuestion.Visible = true;
                lblQuestion.Font.Name = "Cambria Math";
                lblQuestion.Font.Size = 11;
                imgQues.Visible = false;
            }

            else
            {
                lblQuestion.Visible = false;
                imgQues.Visible = true;
                imgQues.ImageUrl = "~/ImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",Question," + s11 + "";
            }

            if (Q1Type == "0")
            {
                string s = Convert.ToString(row["QuesWithImage"]);
                s = s.Replace("@011", "'");
                lblQuestionwithImage.Text = s;
                imgQuesImage.Visible = false;
                if (lblQuestionwithImage.Text == "")
                {
                    lblQuestionwithImage.Visible = false;
                    QuestionImage.Visible = false;
                }
                else
                {
                    lblQuestionwithImage.Visible = true;
                    QuestionImage.Visible = true;
                }
                lblQuestionwithImage.Font.Name = "Times New Roman";
                lblQuestionwithImage.Font.Size = 11;
            }

            else if (Q1Type == "1")
            {
                string s = Convert.ToString(row["QuesWithImage"]);
                s = s.Replace("@011", "'");
                lblQuestionwithImage.Text = s;
                imgQuesImage.Visible = false;
                if (lblQuestionwithImage.Text == "")
                {
                    lblQuestionwithImage.Visible = false;
                    QuestionImage.Visible = false;
                }
                else
                {
                    lblQuestionwithImage.Visible = true;
                    QuestionImage.Visible = true;
                }
                lblQuestionwithImage.Font.Name = "Mangal";
                lblQuestionwithImage.Font.Size = 14;
            }
            else if (Q1Type == "3")
            {
                string s = Convert.ToString(row["QuesWithImage"]);
                s = s.Replace("@011", "'");
                lblQuestionwithImage.Text = s;                      //lblQuestion.Text = s;
                lblQuestionwithImage.Visible = true;                //lblQuestion.Visible=true;
                lblQuestionwithImage.Font.Name = "Cambria Math";    //lblQuestion.Font.Name="Cambria Math";
                lblQuestionwithImage.Font.Size = 11;                //lblQuestion.Font.Size=11;
                imgQues.Visible = false;
            }
            else
            {
                lblQuestionwithImage.Text = Convert.ToString(row["QuesWithImage"]);
                if (lblQuestionwithImage.Text != "")
                {
                    imgQuesImage.ImageUrl = "~/ImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",QuesWithImage," + s11 + "";
                    lblQuestionwithImage.Visible = false;
                    imgQuesImage.Visible = true;
                    QuestionImage.Visible = true;
                }
                else
                {
                    QuestionImage.Visible = false;
                    imgQuesImage.Visible = false;
                    lblQuestionwithImage.Visible = false;
                }
            }

            if (hType == "0")
            {
                string s = Convert.ToString(row["Qhint"]);
                s = s.Replace("@011", "'");
                txtHint.Text = s;
                ddlhint.SelectedIndex = Convert.ToInt32(hType);
                txtHint.Font.Name = "Times New Roman";
                txtHint.Font.Size = 11;
                imgHint.Visible = false;
                txtHint.Visible = true;
                lblH.Visible = true;
                ddlhint.Visible = true;
            }
            else if (hType == "1")
            {
                string s = Convert.ToString(row["Qhint"]);
                s = s.Replace("@011", "'");
                txtHint.Text = s;
                ddlhint.SelectedIndex = Convert.ToInt32(hType);
                txtHint.Font.Name = "Mangal";
                txtHint.Font.Size = 14;
                imgHint.Visible = false;

                txtHint.Visible = true;
                lblH.Visible = true;
                ddlhint.Visible = true;
            }
            else if (hType == "3")
            {
                string s = Convert.ToString(row["Qhint"]);
                s = s.Replace("@011", "'");
                lblQuestion.Text = s;
                lblQuestion.Visible = true;
                lblQuestion.Font.Name = "Cambria Math";
                lblQuestion.Font.Size = 11;
                imgQues.Visible = false;
            }
            else
            {
                imgHint.ImageUrl = "~/ImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",Qhint," + s11 + "";
                txtHint.Visible = false;
                imgHint.Visible = true;
                lblH.Visible = true;
                ddlhint.Visible = false;
            }
        }
    }

    public void clearcontrol()
    {
        lblQuestion.Text = "";
        lblQuestionwithImage.Text = "";
        txtHint.Text = "";
        imgQues.ImageUrl = "";
        imgQuesImage.ImageUrl = "";
        imgHint.ImageUrl = "";
    }

    public void loadMainHeading(string QuesLang1)
    {
        Sql = "SELECT DISTINCT HeadingText FROM TheoryQuesTestDetails WHERE Queslanguage='" + QuesLang1 + "' ";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlMainHead.DataSource = ds.Tables[0];
            ddlMainHead.DataTextField = "HeadingText";
            ddlMainHead.DataBind();
            ddlMainHead.Items.Add("--Select--");
            ddlMainHead.SelectedIndex = ddlMainHead.Items.Count - 1;
        }
        else
        {
            ddlMainHead.Items.Add("--Select--");
            ddlMainHead.SelectedIndex = ddlMainHead.Items.Count - 1;
        }
    }

    protected void ddltestName_SelectedIndexChanged1(object sender, EventArgs e)
    {
        loadSubject(ddltestName.SelectedValue);
        string TestID = Convert.ToString(ddltestName.SelectedValue);

        if (ddltestName.Text == "--Select--")
        {
            btnPrint.Visible = false;
        }
        else
        {
            btnPrint.Visible = true;
            hplInstruction.Enabled = true;

            bindgrid(TestID);
        }
    }

    private void loadSubject(string test)
    {
        if (ddltestName.SelectedIndex == ddltestName.Items.Count - 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Test Name')", true);
        }
        else
        {
            DataSet ds = testDefBAL.loadsubject(test); // load all test under test definition

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbSelectsubject.DataSource = ds.Tables[0];
                cmbSelectsubject.DataTextField = "Name";
                cmbSelectsubject.DataValueField = "ItemValueId";
                cmbSelectsubject.DataBind();
                cmbSelectsubject.Items.Add("--Select--");
                cmbSelectsubject.SelectedIndex = cmbSelectsubject.Items.Count - 1;
                Session["TestID"] = test;
            }
            else
            {
                Session["TestID"] = "dummy";
            }
        }
    }

    protected void cmbSelectsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadChapter(cmbSelectsubject.SelectedValue);
    }

    private void LoadChapter(string SubjectID)
    {
        if (cmbSelectsubject.SelectedIndex == cmbSelectsubject.Items.Count - 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Sujject.')", true);
            ChkSelectALL.Checked = false;
            ddlChapter.Items.Clear();
            ChkSelectALL.Visible = false;
        }
        else
        {
            string SQl = "SELECT Chapter_id FROM tblAssignExamChapter WHERE Subject_id=" + SubjectID + " AND TestID=" + ddltestName.SelectedValue + "";
            string Id = Convert.ToString(cc.ExecuteScalar(SQl));
            if (Id == "")
            {
                ddlChapter.Items.Clear();
                ChkSelectALL.Visible = false;
            }
            else
            {
                Sql = "SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId=3 AND ItemValueId IN (" + Id + ")";
                DataSet ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlChapter.DataSource = ds.Tables[0];
                    ddlChapter.DataTextField = "Name";
                    ddlChapter.DataValueField = "ItemValueId";
                    ddlChapter.DataBind();
                    ChkSelectALL.Checked = false;
                    ChkSelectALL.Visible = true;
                }
            }
        }
    }

    protected void rdoLevelList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltestName.SelectedIndex == ddltestName.Items.Count - 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Exam Name')", true);
        }
        else
        {
            int text = Convert.ToInt32(ddltestName.SelectedValue);
            Session["testid"] = text;
            GetTotal();
        }
    }

    public void GetTotal()  // calculated Number of Question assign for lavel 1,2,3 and remaining Question
    {
        try
        {
            int DLevel1 = 0, DLevel2 = 0, DLevel3 = 0, Total = 0, TypeOFExam = 0;
            int ALevel1 = 0, ALevel2 = 0, ALevel3 = 0, ATotal1 = 0;
            int RLevel1 = 0, RLevel2 = 0, RLevel3 = 0, RTotal1 = 0;

            testDefBAL.Test_ID1 = Convert.ToInt32(Session["testid"]);
            DataSet ds = testDefBAL.getLevelTestDef(testDefBAL);

            if (ds.Tables[0].Rows.Count >= 1)
            {
                DLevel1 = Convert.ToInt32(ds.Tables[0].Rows[0]["DLevel1"]);
                DLevel2 = Convert.ToInt32(ds.Tables[0].Rows[0]["DLevel2"]);
                DLevel3 = Convert.ToInt32(ds.Tables[0].Rows[0]["DLevel3"]);
                TypeOFExam = Convert.ToInt32(ds.Tables[0].Rows[0]["TypeOFExam"]);

                string SQl = " SELECT COUNT(QuestionLevel) as L1  FROM tblT5167 WHERE QuestionLevel=1 " +
                             " SELECT COUNT(QuestionLevel) as L2  FROM tblT5167 WHERE QuestionLevel=2 " +
                             " SELECT COUNT(QuestionLevel) as L3  FROM tblT5167 WHERE QuestionLevel=3 ";

                DataSet ds1 = cc.ExecuteDataset(SQl);

                if (ds1.Tables[0].Rows.Count >= 1 || ds1.Tables[1].Rows.Count >= 1 || ds1.Tables[2].Rows.Count >= 1)
                {
                    ALevel1 = Convert.ToInt32(ds1.Tables[0].Rows[0]["L1"]);
                    ALevel2 = Convert.ToInt32(ds1.Tables[1].Rows[0]["L2"]);
                    ALevel3 = Convert.ToInt32(ds1.Tables[2].Rows[0]["L3"]);
                }

                Total = DLevel1 + DLevel2 + DLevel3;
                ATotal1 = ALevel1 + ALevel2 + ALevel3;
                RLevel1 = DLevel1 - ALevel1;
                RLevel2 = DLevel2 - ALevel2;
                RLevel3 = DLevel3 - ALevel3;
                RTotal1 = RLevel1 + RLevel2 + RLevel3;
                Session["TotalQuetion"] = Total;
                Session["AddingQuestion"] = ATotal1;
                lblt1.Text = "TOTAL QUESTIONS IN EXAM = " + Total;
                lblt1.Visible = true;
                lblt2.Text = "TOTAL QUESTIONS ADDED IN EXAM = " + ATotal1;
                lblt2.Visible = true;
                lblt3.Text = "QUESTIONS REMAINING TO BE ADDED = " + RTotal1;
                lblt3.Visible = true;

                pnl1.Visible = true;
                lblTotalQNo.Text = "TOTAL QUESTIONS IN EXAM = " + Total + " (Level1 + Level2 + Level3 = " + DLevel1 + "+" + DLevel2 + "+" + DLevel3 + ")";
                lblAvailable.Text = "TOTAL QUESTIONS ADDED IN EXAM = " + ATotal1 + " (Level1 + Level2 + Level3 = " + ALevel1 + "+" + ALevel2 + "+" + ALevel3 + ")";
                lblRemaininhg.Text = "QUESTIONS REMAINING TO BE ADDED = " + RTotal1 + " (Level1 + Level2 + Level3 = " + RLevel1 + "+" + RLevel2 + "+" + RLevel3 + ")";
            }
            else
            {
                pnl1.Visible = false;
            }
        }
        catch (Exception ex)
        {
            string error = ex.Message;
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        int NewQID = Convert.ToInt32(lblQNo.Text);
        if (NewQID > 1)
        {
            NewQID = NewQID - 1;
            ddlhint.SelectedIndex = 0;

            string s11 = Convert.ToString(Session["CompanyId"]) + "" + Convert.ToString(Session["TestID"]);

            string viewtblName = "tbll" + s11 + " ";
            assignQuestioninexamBal.ViewtblName1 = viewtblName;
            assignQuestioninexamBal.NewQID1 = NewQID;
            dsStatic = assignQuestioninexamBal.SelectQuestionAssignVIEW(assignQuestioninexamBal);
            fetchCommonData(dsStatic.Tables[0].Rows[0]);

            bool s;
            string q = Convert.ToString(Session["QuestionID"]);
            s = q.Contains(lblSno.Text);
            if (s == true)
            {
                chkAddQuestion.Checked = true;
            }
            else
            {
                chkAddQuestion.Checked = false;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry you can not go Back Question')", true);
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        ddlhint.SelectedIndex = 0;
        int NewQID = Convert.ToInt32(lblQNo.Text);
        if (NewQID < Convert.ToInt32((lblcount.Text.Split(':')[1])))
        {
            NewQID = NewQID + 1;

            string s11 = Convert.ToString(Session["CompanyId"]) + "" + Convert.ToString(Session["TestID"]);

            string viewtblName = "tbll" + s11 + " ";
            assignQuestioninexamBal.ViewtblName1 = viewtblName;
            assignQuestioninexamBal.NewQID1 = NewQID;
            dsStatic = assignQuestioninexamBal.SelectQuestionAssignVIEW(assignQuestioninexamBal);
            fetchCommonData(dsStatic.Tables[0].Rows[0]);

            bool s;
            string q = Convert.ToString(Session["QuestionID"]);
            s = q.Contains(lblSno.Text);
            if (s == true)
            {
                chkAddQuestion.Checked = true;
            }
            else
            {
                chkAddQuestion.Checked = false;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry you can not go next Question')", true);
        }
    }

    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
        int TotalQuetion = Convert.ToInt32(Session["TotalQuetion"]);
        int AddingQuestion = Convert.ToInt32(Session["AddingQuestion"]);

        if (TotalQuetion >= AddingQuestion || TotalQuetion != AddingQuestion)
        {
            int ExamType = 0;
            string QuestionIDSet = Convert.ToString(Session["QuestionID"]);
            string[] QuestionIDSet1 = QuestionIDSet.Split(',');

            int noofQues = Convert.ToInt32(txtNoOfQues.Text);
            if (noofQues >= QuestionIDSet1.Length - 1)
            {
                if (QuestionIDSet != "")
                {
                    QuestionIDSet = QuestionIDSet.Substring(0, QuestionIDSet.Length - 1);

                    testDefBAL.Test_ID1 = Convert.ToInt32(ddltestName.SelectedValue);
                    DataSet ds = testDefBAL.getLevelTestDef(testDefBAL);

                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        ExamType = Convert.ToInt32(ds.Tables[0].Rows[0]["TypeOFExam"]);

                        string s11 = "tblT5167";

                        Sql = " INSERT INTO " + s11 + " " +
                               " SELECT SNO,Question_id,Question,QType,QuesWithImage,Q1Type,Qhint,hType,Correct_answer,QuestionLevel,TypeofQues,TypeofDB,Sellanguage,'" + Convert.ToString(Session["TestID"]) + "' FROM tblQuestionAccess " +
                               " WHERE  SNO NOT IN (SELECT SNO FROM " + s11 + " ) AND SNO IN (" + QuestionIDSet + ")";

                        int status1 = cc.ExecuteNonQuery(Sql);

                        if (status1 >= 1)
                        {
                            string mainHead;
                            if (ddlMainHead.Text == "--Select--")
                            {
                                mainHead = txtMainHead.Text;
                            }
                            else
                            {
                                mainHead = ddlMainHead.Text;
                            }

                            string Orvalue;
                            if (chkOR.Checked == true)
                                Orvalue = "1";
                            else
                                Orvalue = "0";

                            string strQNO = string.Empty;
                            string strSubQNO = string.Empty;

                            if (rdoQueslanguage.SelectedValue == "0")
                            {
                                strQNO = lblInitialQues.Text + "" + ddlQNOE.SelectedItem.Text;
                                if (rdolstIsSubQues.SelectedValue == "0")
                                {
                                    strSubQNO = ddlIsSubQuesE.SelectedItem.Text;
                                }
                                else
                                {
                                    strSubQNO = string.Empty;
                                }
                            }
                            else
                            {
                                strQNO = lblInitialQues.Text + "" + ddlQNOM.SelectedItem.Text;
                                if (rdolstIsSubQues.SelectedValue == "0")
                                {
                                    strSubQNO = ddlIsSubQuesM.SelectedItem.Text;
                                }
                                else
                                {
                                    strSubQNO = string.Empty;
                                }
                            }

                            string sqlQuery = " SELECT * FROM [TheoryQuesTestDetails] WHERE  [LoginId]='" + Convert.ToString(Session["LoginId"]) + "' AND [TestId]='" + ddltestName.SelectedValue + "' AND [MainQuestion]=N'" + strQNO + "' AND [SubQuestion]=N'" + strSubQNO + "' ";
                            DataSet datasetTheory = cc.ExecuteDataset(sqlQuery);

                            if (datasetTheory.Tables[0].Rows.Count > 0)
                            {
                                string sqlQuery1 = "UPDATE [TheoryQuesTestDetails] SET QuestionID=N'" + QuestionIDSet + "' WHERE [LoginId]='" + Convert.ToString(Session["LoginId"]) + "' AND [TestId]='" + ddltestName.SelectedValue + "' AND [MainQuestion]=N'" + strQNO + "' AND [SubQuestion]=N'" + strSubQNO + "' ";
                                cc.ExecuteNonQuery(sqlQuery1);
                            }
                            else
                            {
                                string sql2 = " INSERT INTO TheoryQuesTestDetails (LoginId,TestId,TestName,MainQuestion,SubQuestion, " +
                                              " HeadingText,NoOfQuestion ,MarkAllQuestion  ,ORMainQuestion ,QuestionID,Queslanguage) VALUES " +
                                              " ('" + Convert.ToString(Session["LoginId"]) + "'," + ddltestName.SelectedValue + ",N'" + ddltestName.SelectedItem.Text + "',N'" + strQNO + "', N'" + strSubQNO + "', " +
                                              " N'" + mainHead + "' , N'" + txtNoOfQues.Text + "' ,N'" + txtMarkforAllQues.Text + "',N'" + Orvalue + "',N'" + QuestionIDSet + "' , '" + rdoQueslanguage.SelectedValue + "')";

                                int status2 = cc.ExecuteNonQuery(sql2);
                            }

                            GetTotal();
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert(' " + status1 + " Question Added Successfully')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert(' Selected Question Already Exist.')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry No Question Added !!!')", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You have selected more Question than you assign so Please select Number of Question you aasign ')", true);
            }
        }
        else
        {
            GetTotal();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You can not add more Questions ')", true);
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string Id = ddltestName.SelectedValue;
        Response.Redirect("~/Admin/frmPrintTheoryQues.aspx?Id=" + Id);
    }

    protected void btnInsturc_Click(object sender, EventArgs e)
    {

    }

    protected void ChkSelectALL_CheckedChanged(object sender, EventArgs e)
    {

        if (ChkSelectALL.Checked == true)
        {

            foreach (ListItem li in ddlChapter.Items)
            {
                li.Selected = true;
            }
        }
        else
        {
            foreach (ListItem li in ddlChapter.Items)
            {
                li.Selected = false;
            }
        }
    }

    string s1;
    protected void chkAddQuestion_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAddQuestion.Checked == true)
        {
            Session["QuestionID"] = Session["QuestionID"] + lblSno.Text + ",";
            s1 = Convert.ToString(Session["QuestionID"]);
        }
        else
        {
            string[] arr = Convert.ToString(Session["QuestionID"]).Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == lblSno.Text)
                {
                    arr[i] = "";
                }
            }

            foreach (string s in arr)
            {
                if (s != "")
                {
                    s1 += s + ",";
                }
            }
        }

        Session["QuestionID"] = s1;
    }

    protected void gvTheory_RowCommand(object sender, GridViewCommandEventArgs e)  //RETRIVED DATA TO MODIFY 
    {
        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;

        if (Convert.ToString(e.CommandName) == "Modify")
        {
            btnUpdate.Visible = true;
            btnStart.Visible = false;

            Sql = " SELECT [LoginId],[TestId],[TestName],[MainQuestion],[SubQuestion],[HeadingText],[NoOfQuestion],[MarkAllQuestion],[ORMainQuestion],[QuestionID],[Queslanguage] FROM TheoryQuesTestDetails WHERE ID='" + lblId.Text + "' ";
            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string lang = Convert.ToString(ds.Tables[0].Rows[0]["Queslanguage"]);

                if (lang == "1")
                {
                    rdoQueslanguage.SelectedValue = "1";

                    ddlMainHead.Font.Name = "Cambria Math";
                    ddlMainHead.Font.Size = 10;
                    txtMainHead.Font.Name = "Cambria Math";
                    txtMainHead.Font.Size = 10;
                }
                else
                {
                    rdoQueslanguage.SelectedValue = "0";
                    ddlMainHead.Font.Name = "Times New Roman";
                    ddlMainHead.Font.Size = 10;
                    txtMainHead.Font.Name = "Times New Roman";
                    txtMainHead.Font.Size = 10;
                }

                ddltestName.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TestId"]);
                ddlMainHead.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["HeadingText"]);
                txtMarkforAllQues.Text = Convert.ToString(ds.Tables[0].Rows[0]["MarkAllQuestion"]);
                txtNoOfQues.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfQuestion"]);

                string MainQNOHead = Convert.ToString(ds.Tables[0].Rows[0]["MainQuestion"]);
                MainQNOHead = MainQNOHead.Trim();
                string[] mainQnoHead = MainQNOHead.Split('.');
                lblInitialQues.Text = mainQnoHead[0].ToString() + "" + ".";
                txtQNOHeading.Text = mainQnoHead[0].ToString();

                string or = Convert.ToString(ds.Tables[0].Rows[0]["ORMainQuestion"]);

                if (or == "0")
                {
                    chkOR.Checked = false;
                }
                else
                {
                    chkOR.Checked = true;
                }

                cmbSelectsubject.Enabled = false;
                pnl1.Enabled = false;
                rdoLevelList1.Enabled = false;
                ddltestName.Enabled = false;
                txtNoOfQues.Enabled = false;
                RequiredFieldValidator3.Enabled = false;
            }
        }
        if (Convert.ToString(e.CommandName) == "Delete")
        {
            try
            {
                Sql = "DELETE FROM TheoryQuesTestDetails WHERE ID='" + lblId.Text + "' AND LoginId='" + Convert.ToString(Session["LoginId"]) + "'  ";
                status = cc.ExecuteNonQuery(Sql);
                if (status == 1)
                {
                    bindgrid(ddltestName.SelectedValue);
                    cleartheoryControl();

                    lblerror.Text = "Theory Question Details Deleted successfully";
                    lblerror.Visible = true;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Theory Question Details Deleted successfully')", true);
                }
                else
                {
                    lblerror.Text = "Theory Question Details Not Deleted ! ";
                    lblerror.Visible = true;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Theory Question Details Not Deleted ! ')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public void bindgrid(string TestID)
    {
        Sql = "SELECT * FROM TheoryQuesTestDetails WHERE TestId='" + TestID + "' AND LoginId='" + Convert.ToString(Session["LoginId"]) + "' ORDER BY ID DESC ";
        DataSet ds2 = cc.ExecuteDataset(Sql);
        if (ds2.Tables[0].Rows.Count > 0)
        {
            gvTheory.DataSource = ds2.Tables[0];
            gvTheory.DataBind();
        }
        else
        {
            gvTheory.DataSource = null;
            gvTheory.DataBind();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        cleartheoryControl();
    }

    public void cleartheoryControl()
    {
        btnStart.Visible = true;
        btnUpdate.Visible = false;
        lblId.Text = "";
        cmbSelectsubject.Enabled = true;
        pnl1.Enabled = true;
        rdoLevelList1.Enabled = true;
        ddltestName.Enabled = true;
        txtNoOfQues.Enabled = true;
        lblerror.Visible = false;

        txtQNOHeading.Text = "";
        txtNoOfQues.Text = "";
        txtMarkforAllQues.Text = "";
        txtMainHead.Text = "";
        chkOR.Checked = false;

        rdoQueslanguage.SelectedValue = "0";

        RequiredFieldValidator3.Enabled = false;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(lblId.Text) != "")
        {
            try
            {
                if (txtQNOHeading.Text == "")
                {
                    lblerror.Text = "Please Enter Questions Number ";
                    lblerror.Visible = true;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Questions Number ')", true);
                }
                else if (txtMarkforAllQues.Text == "")
                {
                    lblerror.Text = "Please Enter Total Marks For Questions";
                    lblerror.Visible = true;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Total Marks For Questions')", true);
                }
                else
                {
                    string HeadingText = txtMainHead.Text;
                    if (txtMainHead.Text == "")
                        HeadingText = Convert.ToString(ddlMainHead.SelectedItem.Text);

                    string Orvalue;
                    if (chkOR.Checked == true)
                        Orvalue = "1";
                    else
                        Orvalue = "0";

                    Sql = " UPDATE TheoryQuesTestDetails SET Queslanguage='" + rdoQueslanguage.SelectedValue + "',  MainQuestion=N'" + txtQNOHeading.Text + "' , " +
                          " HeadingText=N'" + HeadingText + "',MarkAllQuestion=N'" + txtMarkforAllQues.Text + "'  ,ORMainQuestion=N'" + Orvalue + "' WHERE ID='" + lblId.Text + "' ";

                    int status = cc.ExecuteNonQuery(Sql);
                    if (status == 1)
                    {
                        bindgrid(Convert.ToString(ddltestName.SelectedValue));
                        cleartheoryControl();

                        lblerror.Text = "Theory Question Details Updated successfully";
                        lblerror.Visible = true;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Theory Question Details Updated successfully')", true);
                    }
                    else
                    {
                        lblerror.Text = "Theory Question Details Not Updated ! ";
                        lblerror.Visible = true;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Theory Question Details Not Updated ! ')", true);
                    }
                }
            }
            catch
            {
            }
        }
    }

    protected void gvTheory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTheory.PageIndex = e.NewPageIndex;
    }

    protected void btnGotoQues_Click(object sender, EventArgs e)
    {
        try
        {
            int NewQID = Convert.ToInt32(txtGotoQues.Text);
            if (NewQID < Convert.ToInt32((lblcount.Text.Split(':')[1])))
            {
                string s11 = Convert.ToString(Session["CompanyId"]) + "" + Convert.ToString(Session["TestID"]);

                string viewtblName = "tbll" + s11 + " ";
                assignQuestioninexamBal.ViewtblName1 = viewtblName;
                assignQuestioninexamBal.NewQID1 = NewQID;
                dsStatic = assignQuestioninexamBal.SelectQuestionAssignVIEW(assignQuestioninexamBal);
                fetchCommonData(dsStatic.Tables[0].Rows[0]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry you can not go to Question')", true);
            }
        }
        catch
        {
        }
    }

    protected void gvTheory_DataBound(object sender, EventArgs e)
    {

    }

    protected void gvTheory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void rdoQueslanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //string QuesLang1 = Convert.ToString(rdoQueslanguage.SelectedValue); // THIS METHOD FOR LOAD THE AVAILABLE INSRTUCTIONS AS PER LANGUAGE
            //loadMainHeading(QuesLang1);

            if (rdoQueslanguage.SelectedValue == "1")
            {
                lblInitialQues.Text = initialQHM;
                ddlQNOE.Visible = false;
                ddlQNOM.Visible = true;

                loadMainHeading("1");

                if (rdolstIsSubQues.SelectedValue == "0")
                {
                    ddlIsSubQuesE.Visible = false;
                    ddlIsSubQuesM.Visible = true;
                }
                else
                {
                    ddlIsSubQuesE.Visible = false;
                    ddlIsSubQuesM.Visible = false;
                }
            }
            else
            {
                lblInitialQues.Text = initialQHE;
                ddlQNOE.Visible = true;
                ddlQNOM.Visible = false;

                loadMainHeading("0");

                if (rdolstIsSubQues.SelectedValue == "0")
                {
                    ddlIsSubQuesE.Visible = true;
                    ddlIsSubQuesM.Visible = false;
                }
                else
                {
                    ddlIsSubQuesE.Visible = false;
                    ddlIsSubQuesM.Visible = false;
                }
            }
        }
        catch
        {

        }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.EditIndex = e.NewPageIndex;
        instruBind();
        ModalPopupExtender1.DropShadow = true;
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ID = Convert.ToString(e.CommandArgument);
        lblid2.Text = ID;
        try
        {
            if (Convert.ToString(e.CommandName) == "Modify")
            {
                rdodefualt.Checked = false;
                rdodefualt.Enabled = false;

                btnInstru.Text = "Update";
                Sql = "SELECT * FROM tblInstructionTheory WHERE ID=" + ID + "  AND Default1='No' AND defaultFlag='0' ";
                ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds = cc.ExecuteDataset(Sql);

                    Session["TestId"] = Convert.ToInt32(ds.Tables[0].Rows[0]["TestId"]);
                    Session["Testname"] = Convert.ToString(ds.Tables[0].Rows[0]["Testname"]);

                    txtInstructionName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Instruction"]);

                    TextBox1.Text = Convert.ToString(ds.Tables[0].Rows[0]["InstrucIDSet"]);

                    string[] top = TextBox1.Text.Split(',');

                    int j;

                    foreach (GridViewRow r in GridView2.Rows)
                    {
                        CheckBox chk = (CheckBox)r.FindControl("chkAddInstruc");
                        string ItemValueId = r.Cells[0].Text.ToString();

                        for (j = 0; j < top.Length; j++)
                        {
                            string k = Convert.ToString(top[j]);

                            if (ItemValueId == k)
                            {
                                chk.Checked = true;
                            }
                            else
                            {
                            }
                        }
                    }

                    string lang = Convert.ToString(ds.Tables[0].Rows[0]["Instrulanguage"]);
                    if (lang == "Marathi")
                    {
                        rdoInstruLang.SelectedValue = "1";
                        txtInstructionName.Font.Name = "Mangal";
                        txtInstructionName.Font.Size = 14;
                    }
                    else
                    {
                        rdoInstruLang.SelectedValue = "0";
                        txtInstructionName.Font.Name = "Times New Roman";
                        txtInstructionName.Font.Size = 11;
                    }
                }
                else
                {
                    clearInstru();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You can not modify this instruction')", true);
                }
            }
            if (Convert.ToString(e.CommandName) == "Delete")
            {
                try
                {
                    Sql = "DELETE FROM tblInstructionTheory WHERE ID=" + ID + " AND Default1='No' ";
                    status = cc.ExecuteNonQuery(Sql);
                    if (status == 1)
                    {
                        clearInstru();
                        instruBind();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Instruction is deleted successfully')", true);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You can not deleted this instruction')", true);

                    lblid2.Text = "";
                }
                catch
                {
                }
            }
            ModalPopupExtender1.Show();
        }
        catch
        {
        }

    }

    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void btnInstru_Click(object sender, EventArgs e)
    {
        string id = lblid2.Text;
        if (id == "")
        {
            if (rdodefualt.Checked == true)
                addDefault();
            else
                addinstruc();
        }
        else
        {
            updateinstruc(id);
        }
        lblid2.Text = "";
        instruBind();
    }

    public void addDefault()
    {
        try
        {
            Sql = " SELECT ID FROM tblInstructionTheory WHERE LoginId='" + Convert.ToString(Session["LoginId"]) + "' AND TestId='" + ddltestName.SelectedValue + "' AND defaultFlag='1' ";
            string Id = cc.ExecuteScalar(Sql);
            if (Id == "")
            {
                Sql = " INSERT INTO tblInstructionTheory ([Instruction],[TestId],[Testname],[LoginId],[Default1],[defaultFlag],[Instrulanguage],[InstrucIDSet]) VALUES ('0'," + ddltestName.SelectedValue + ",N'" + ddltestName.SelectedItem.Text + "','" + Convert.ToString(Session["LoginId"]) + "','No','1','" + rdoInstruLang.SelectedItem.Text + "','0')";
                status = cc.ExecuteNonQuery(Sql);
                if (status == 1)
                {
                    clearInstru();
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Defualt Instruction is submitted successfully')", true);
                    lblStatus.Text = "Default Instruction Added Successfully.!!!";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You can not submitted defualt instruction')", true);
                    lblStatus.Text = "You Can't Add Default Instructions.";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Defualt instruction is already exist')", true);
                lblStatus.Text = "Default Instructions Already Exist.!!!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            ModalPopupExtender1.Show();
        }
        catch
        {
        }
    }

    public void addinstruc()
    {
        try
        {
            TextBox1.Text = "";

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                CheckBox chkbox1 = (CheckBox)GridView2.Rows[i].Cells[0].FindControl("chkAddInstruc");
                if (chkbox1 != null)
                {
                    if (chkbox1.Checked)
                    {
                        TextBox1.Text += Convert.ToString(GridView2.Rows[i].Cells[0].Text) + ",";
                        string Name = Convert.ToString(GridView2.Rows[i].Cells[1].Text);
                    }
                }
                chkbox1.Checked = false;
            }
            if (TextBox1.Text != "")
                TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.Length - 1);

            if (TextBox1.Text != "" || txtInstructionName.Text != "")
            {
                Sql = " SELECT ID FROM tblInstructionTheory WHERE Instruction=N'" + txtInstructionName.Text + "' AND Default1='No' AND InstrucIDSet =N'" + TextBox1.Text + "' ";
                string Id = cc.ExecuteScalar(Sql);
                if (Id == "")
                {
                    Sql = " INSERT INTO tblInstructionTheory (Instruction,TestId,Testname,LoginId,Default1,defaultFlag,Instrulanguage,InstrucIDSet) VALUES  " +
                        " (N'" + txtInstructionName.Text + "'," + ddltestName.SelectedValue + ",N'" + ddltestName.SelectedItem.Text + "','" + Convert.ToString(Session["LoginId"]) + "','No','0' , N'" + rdoInstruLang.SelectedItem.Text + "' , N'" + TextBox1.Text + "')";
                    status = cc.ExecuteNonQuery(Sql);
                    if (status == 1)
                    {
                        clearInstru();
                        //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Instruction is submitted successfully')", true);
                        lblStatus.Text = "Instruction Added Successfully.!!!";
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You can not submitted this instruction')", true);
                        lblStatus.Text = "You Can't Add Instruction.!!!";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This instruction is already exist')", true);
                    lblStatus.Text = "This Instruction Already Exist.!!!";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
                ModalPopupExtender1.Show();
            }
            else
            {
                // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select instruction from gridview or Enter new instruction')", true);
                lblStatus.Text = "Please Select OR Insert New Instruction.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                ModalPopupExtender1.Show();
            }
        }
        catch
        {
        }
    }

    public void updateinstruc(string id)
    {
        try
        {
            TextBox1.Text = "";

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                CheckBox chkbox1 = (CheckBox)GridView2.Rows[i].Cells[0].FindControl("chkAddInstruc");
                if (chkbox1 != null)
                {
                    if (chkbox1.Checked)
                    {
                        TextBox1.Text += Convert.ToString(GridView2.Rows[i].Cells[0].Text) + ",";
                        string Name = Convert.ToString(GridView2.Rows[i].Cells[1].Text);
                    }
                }
                chkbox1.Checked = false;
            }
            if (TextBox1.Text != "")
                TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.Length - 1);

            if (TextBox1.Text != "" || txtInstructionName.Text != "")
            {
                Sql = " UPDATE tblInstructionTheory SET Instruction=N'" + txtInstructionName.Text + "',TestId=" + Convert.ToInt32(Session["TestId"]) + ",Testname=N'" + Convert.ToString(Session["Testname"]) + "',Instrulanguage='" + rdoInstruLang.SelectedItem.Text + "' , InstrucIDSet='" + TextBox1.Text + "' WHERE ID=" + id + " ";
                status = cc.ExecuteNonQuery(Sql);
                if (status == 1)
                {
                    clearInstru();
                    // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Instruction is updated successfully')", true);
                    lblStatus.Text = "Instruction Updated Successfully..!!!";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You can not updated this instruction')", true);
                    lblStatus.Text = "You Can't Update this Instruction.";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }

                ModalPopupExtender1.Show();
            }
            else
            {
                // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select instruction from gridview or Enter new instruction')", true);
                lblStatus.Text = "Please Select OR Insert New Instruction.";
                lblStatus.ForeColor = System.Drawing.Color.Red;

                ModalPopupExtender1.Show();
            }
        }
        catch
        {
        }
    }

    public void clearInstru()
    {
        txtInstructionName.Text = "";
        lblid2.Text = "";

        btnInstru.Text = "Submit";
        rdodefualt.Checked = false;
    }

    public void instruBind()
    {
        Sql = "SELECT * FROM tblInstructionTheory WHERE LoginId='1' OR LoginId='" + Convert.ToString(Session["LoginId"]) + "' ";
        ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();
        }
    }

    protected void btnclose0_Click(object sender, EventArgs e)
    {
        rdodefualt.Enabled = true;
        rdodefualt.Checked = false;
        txtInstructionName.Text = "";
        btnInstru.Text = "Submit";
        lblid2.Text = "";
        ModalPopupExtender1.Show();
    }

    protected void rdoInstruLang_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(rdoInstruLang.SelectedItem.Text) == "Marathi")
        {
            txtInstructionName.Font.Name = "Mangal";
            txtInstructionName.Font.Size = 10;
        }
        else
        {
            txtInstructionName.Font.Name = "Times New Roman";
            txtInstructionName.Font.Size = 10;
        }
        ModalPopupExtender1.Show();
    }

    protected void ddlMainHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMainHead.SelectedItem.Text == "--Select--")
        {
            txtMainHead.Enabled = true;
        }
        else
        {
            txtMainHead.Enabled = false;
        }
    }
    protected void rdolstIsSubQues_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoQueslanguage.SelectedValue == "0")
        {
            if (rdolstIsSubQues.SelectedValue == "0")
            {
                ddlIsSubQuesE.Visible = true;
                ddlIsSubQuesM.Visible = false;
            }
            else
            {
                ddlIsSubQuesE.Visible = false;
                ddlIsSubQuesM.Visible = false;
            }
        }
        else
        {
            if (rdolstIsSubQues.SelectedValue == "0")
            {
                ddlIsSubQuesM.Visible = true;
                ddlIsSubQuesE.Visible = false;
            }
            else
            {
                ddlIsSubQuesE.Visible = false;
                ddlIsSubQuesM.Visible = false;
            }
        }
    }
}
