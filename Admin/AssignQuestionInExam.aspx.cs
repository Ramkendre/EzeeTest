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

public partial class Admin_AssignQuestionInExam : System.Web.UI.Page
{

    int status, TotalQuetion, AddingQuestion;
    string role = "";
    CommonCode cc = new CommonCode();
    TestDefinationBLL testDefBAL = new TestDefinationBLL();
    CommanDDLbindclass Cds = new CommanDDLbindclass();
    AssignQuestionInExamBAL assignQuestioninexamBal = new AssignQuestionInExamBAL();

    public static string Chapter_id = "";
    public static int TypeOFExam = 0;
    public static int Class_id = 0;
    public static int Subject_id = 0;
    public static string Subjectid = "";

    public DataSet dsStatic = null;
    public DataSet dsItemValue = null;

    string Sql = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MultiView1.ActiveViewIndex = 0;
            rdoQuesVerify.SelectedIndex = 0;
            loadTestName();
            loadPublication();
        }
    }
    public void loadTestName()
    {
        testDefBAL.LoginId1 = Convert.ToString(Session["LoginId"]);  //use sp
        testDefBAL.GroupOfQuestion1 = "0";

        DataSet ds = testDefBAL.TestbyGroupofQuesLoginId5(testDefBAL);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddltextName.DataSource = ds.Tables[0];
            ddltextName.DataTextField = "Exam_name";
            ddltextName.DataValueField = "Test_ID";
            ddltextName.DataBind();
            ddltextName.Items.Add("--Select--");
            ddltextName.SelectedIndex = ddltextName.Items.Count - 1;
            cmbSelectsubject.Items.Add("--Select--");
            cmbSelectsubject.SelectedIndex = cmbSelectsubject.Items.Count - 1;
            ddlTopik.Items.Add("--Select--");
            ddlTopik.SelectedIndex = ddlTopik.Items.Count - 1;
        }
    }


    public void loadSubject()
    {
        Sql = "select Name,ItemValueId from dbo.tblItemValue where ItemId =0 or ItemId=2";
        DataSet ds = cc.ExecuteDataset(Sql);
        cmbSelectsubject.DataSource = ds.Tables[0];
        cmbSelectsubject.DataTextField = "Name";
        cmbSelectsubject.DataValueField = "ItemValueId";
        cmbSelectsubject.DataBind();
    }
    public void loadChapter()
    {
        Sql = "select Name,ItemValueId from dbo.tblItemValue  where ItemId=0 or ItemId=3";
        DataSet ds = cc.ExecuteDataset(Sql);
        ddlChapter.DataSource = ds.Tables[0];
        ddlChapter.DataTextField = "Name";
        ddlChapter.DataValueField = "ItemValueId";
        ddlChapter.DataBind();

    }
    public void loadPublication()
    {
        string role = Convert.ToString(Session["Role"]);
        if (role == "8" || role == "19")
        {
            Sql = "select Name,ItemValueId from dbo.tblItemValue where ItemId=0 or ItemId=7";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlpublication.DataSource = ds.Tables[0];
            ddlpublication.DataTextField = "Name";
            ddlpublication.DataValueField = "ItemValueId";
            ddlpublication.DataBind();
        }
        else
        {
            lblpublication.Visible = false;
            ddlpublication.Visible = false;
        }
    }

    protected void btnStart_Click1(object sender, EventArgs e)
    {
        try
        {
            if (ddltextName.SelectedIndex == ddltextName.Items.Count - 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Exam Name')", true);
            }
            else
            {
                string chapterID = "", chapterName = "";
                Session["QuestionID"] = "";
                for (int c = 0; c < rdoLevelList1.Items.Count; c++)
                {
                    if (rdoLevelList1.Items[c].Selected == true)
                    {
                        chapterID = chapterID + "," + rdoLevelList1.Items[c].Value;
                    }
                }

                if (ddltextName.SelectedIndex == ddltextName.Items.Count - 1)
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
                //else if (ddlpublication.SelectedIndex == ddlpublication.Items.Count - 1)
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Publication')", true);
                //}
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
            testDefBAL.Test_ID1 = Convert.ToInt32(ddltextName.SelectedValue);

            DataSet ds = testDefBAL.getAssignTestDetails(testDefBAL);

            if (ds.Tables[0].Rows.Count >= 1)
            {
                TypeOFExam = Convert.ToString(ds.Tables[0].Rows[0]["TypeOFExam"]);
                TypeofMaterial = Convert.ToString(ds.Tables[0].Rows[0]["TypeofMaterial"]);
                Class_id = Convert.ToInt32(ds.Tables[0].Rows[0]["Class_id"]);
                Subjectid = Convert.ToString(ds.Tables[0].Rows[0]["Subject_id"]);

                Sql = "select count(*) from dbo.tblAssignExamChapter where LoginId='" + Session["LoginId"] + "' and TestID=" + ddltextName.SelectedValue + " ";
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

                    string s11 = Convert.ToString(Session["TestID"]);
                    try
                    {
                        Sql = " drop view tbll" + s11 + "";
                        int i = cc.ExecuteNonQuery(Sql);
                    }
                    catch
                    {
                    }
                    string role = Convert.ToString(Session["Role"]);
                    if (role == "8" || role == "19")
                    {
                        if (Class_id == 1)
                        {
                            Sql = " CREATE   view tbll" + s11 + " as  " +
                                  " Select ROW_NUMBER() OVER( ORDER BY Question_id) NewQID,  * " +
                                  "    from " +
                                  "   (select * from dbo.tblQuestionAccess where  TypeOFExam=" + TypeOFExam + " and (QuesVerify !='0' or QuesVerify is null) and QuestionLevel=" + rdoLevelList1.SelectedValue + "  and Subject_id =" + cmbSelectsubject.SelectedValue + " and PublicationName ='" + ddlpublication.SelectedItem.Text + "')  as MyResults ";
                            if (chapterID != "")
                                Sql = " CREATE   view tbll" + s11 + " as  " +
                                      " Select ROW_NUMBER() OVER( ORDER BY Question_id) NewQID,  * " +
                                      "    from " +
                                      "   (select * from dbo.tblQuestionAccess where  TypeOFExam=" + TypeOFExam + " and (QuesVerify !='0' or QuesVerify is null) and QuestionLevel=" + rdoLevelList1.SelectedValue + "  and Subject_id =" + cmbSelectsubject.SelectedValue + " and Topic_id in(" + chapterID + ") and Chapter_id=" + ddlTopik.SelectedValue + "  and PublicationName ='" + ddlpublication.SelectedItem.Text + "')  as MyResults ";
                        }
                        else
                        {
                            Sql = " CREATE   view tbll" + s11 + " as  " +
                                 " Select ROW_NUMBER() OVER( ORDER BY Question_id) NewQID,  * " +
                                 "    from " +
                                 "   (select * from dbo.tblQuestionAccess where  TypeOFExam=" + TypeOFExam + " and (QuesVerify !='0' or QuesVerify is null) and QuestionLevel=" + rdoLevelList1.SelectedValue + " and Class_id=" + Class_id + " and Subject_id =" + cmbSelectsubject.SelectedValue + " and PublicationName ='" + ddlpublication.SelectedItem.Text + "') as MyResults ";
                            if (chapterID != "")
                                Sql = " CREATE   view tbll" + s11 + " as  " +
                                      " Select ROW_NUMBER() OVER( ORDER BY Question_id) NewQID,  * " +
                                      "    from " +
                                      "   (select * from dbo.tblQuestionAccess where  TypeOFExam=" + TypeOFExam + " and (QuesVerify !='0' or QuesVerify is null) and QuestionLevel=" + rdoLevelList1.SelectedValue + " and Class_id=" + Class_id + " and Subject_id =" + cmbSelectsubject.SelectedValue + " and Topic_id in(" + chapterID + ") and Chapter_id=" + ddlTopik.SelectedValue + "  and PublicationName ='" + ddlpublication.SelectedItem.Text + "')  as MyResults ";

                        }
                    }
                    else
                    {
                        if (Class_id == 1)
                        {
                            Sql = " CREATE   view tbll" + s11 + " as  " +
                                  " Select ROW_NUMBER() OVER( ORDER BY Question_id) NewQID,  * " +
                                  "    from " +
                                  "   (select * from dbo.tblQuestionAccess where  TypeOFExam=" + TypeOFExam + " and (QuesVerify !='0' or QuesVerify is null) and QuestionLevel=" + rdoLevelList1.SelectedValue + "  and Subject_id =" + cmbSelectsubject.SelectedValue + "   )  as MyResults ";
                            if (chapterID != "")
                                Sql = " CREATE   view tbll" + s11 + " as  " +
                                      " Select ROW_NUMBER() OVER( ORDER BY Question_id) NewQID,  * " +
                                      "    from " +
                                      "   (select * from dbo.tblQuestionAccess where  TypeOFExam=" + TypeOFExam + " and (QuesVerify !='0' or QuesVerify is null) and QuestionLevel=" + rdoLevelList1.SelectedValue + "  and Subject_id =" + cmbSelectsubject.SelectedValue + " and Topic_id in(" + chapterID + ") and Chapter_id=" + ddlTopik.SelectedValue + ")  as MyResults ";   //chapter_id=Topic_id
                        }
                        else
                        {
                            Sql = " CREATE   view tbll" + s11 + " as  " +
                                 " Select ROW_NUMBER() OVER( ORDER BY Question_id) NewQID,  * " +
                                 "    from " +
                                 "   (select * from dbo.tblQuestionAccess where  TypeOFExam=" + TypeOFExam + " and (QuesVerify !='0' or QuesVerify is null) and QuestionLevel=" + rdoLevelList1.SelectedValue + " and Class_id=" + Class_id + " and Subject_id =" + cmbSelectsubject.SelectedValue + "   )  as MyResults ";
                            if (chapterID != "")
                                Sql = " CREATE   view tbll" + s11 + " as  " +
                                      " Select ROW_NUMBER() OVER( ORDER BY Question_id) NewQID,  * " +
                                      "    from " +
                                      "   (select * from dbo.tblQuestionAccess where  TypeOFExam=" + TypeOFExam + " and (QuesVerify !='0' or QuesVerify is null) and QuestionLevel=" + rdoLevelList1.SelectedValue + " and Class_id=" + Class_id + " and Subject_id =" + cmbSelectsubject.SelectedValue + " and Topic_id in(" + chapterID + ") and Chapter_id=" + ddlTopik.SelectedValue + ")  as MyResults ";

                        }
                    }

                    int k = cc.ExecuteNonQuery(Sql);

                    string viewtblName = "tbll" + s11 + " ";
                    Sql = "select count(*) from " + viewtblName + " ";
                    string tempcount = cc.ExecuteScalar(Sql);
                    lblcount.Text = "Total Number of Question : " + tempcount;

                    assignQuestioninexamBal.ViewtblName1 = viewtblName;
                    assignQuestioninexamBal.NewQID1 = 1;
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            // if Question is coreect then save 0 else save 1 for incorrect

            assignQuestioninexamBal.Class_AdmSuggest1 = txtSuggest.Text;
            assignQuestioninexamBal.Class_AdmLogin1 = Convert.ToString(Session["LoginId"]);
            assignQuestioninexamBal.Class_AdmVerify1 = rdoQuesVerify.SelectedValue;
            assignQuestioninexamBal.SNO1 = Convert.ToInt32(lblSno.Text);

            status = assignQuestioninexamBal.UpdateQuestionVerifyClassAdmin(assignQuestioninexamBal);
            if (status == 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Your Question is Updated')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Your Question is Not Updated')", true);
            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select answer and Question level')", true);
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        int NewQID = Convert.ToInt32(lblQNo.Text);
        if (NewQID > 1)
        {
            NewQID = NewQID - 1;
            ddlhint.SelectedIndex = 0;
            string s11 = Convert.ToString(Session["TestID"]);

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
        string[] sdfds = lblcount.Text.Split(':');
        if (NewQID < Convert.ToInt32((lblcount.Text.Split(':')[1])))
        {
            NewQID = NewQID + 1;

            string s11 = Convert.ToString(Session["TestID"]);
            string viewtblName = "tbll" + s11 + " ";
            assignQuestioninexamBal.ViewtblName1 = viewtblName;
            assignQuestioninexamBal.NewQID1 = NewQID;
            dsStatic = assignQuestioninexamBal.SelectQuestionAssignVIEW(assignQuestioninexamBal);
            fetchCommonData(dsStatic.Tables[0].Rows[0]);


            // coding for Question is check or not
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

    public string TypeofQues = "";
    public string QType = "", Q1Type = "", AType = "", BType = "", CType = "", DType = "", EType = "", PType = "", RType = "", QType1 = "",
        SType = "", TType = "", passageType = "", hType = "";
    public string TypeDB = "", lang = "";
    public static string hintDB = "";
    public int settingid1 = 0;

    void fetchCommonData(DataRow row)
    {
        string loginId = Convert.ToString(Session["LoginId"]);
        string s11 = Convert.ToString(Session["TestID"]);

        clearcontrol();
        if (row.ItemArray.Count() > 0)
        {
            txtSuggest.Text = Convert.ToString(row["Class_AdmSuggest"]);
            string QuesVerify = Convert.ToString(row["Class_AdmVerify"]);

            rdoQuesVerify.SelectedIndex = 0;
            if (QuesVerify == "1")
                rdoQuesVerify.SelectedIndex = 1;


            int QId = Convert.ToInt32(row["Question_id"]);

            int NewQID = Convert.ToInt32(row["NewQID"]);
            lblQNo.Text = Convert.ToString(NewQID);

            lblQuestion_id.Text = Convert.ToString(QId);
            lblSno.Text = Convert.ToString(row["SNO"]);

            TypeDB = Convert.ToString(row["TypeofDB"]);
            lang = Convert.ToString(row["Sellanguage"]);

            if (TypeDB == "Access")
            {
                QType = Convert.ToString(row["QType"]);
                Q1Type = Convert.ToString(row["Q1Type"]);
                AType = Convert.ToString(row["AType"]);
                BType = Convert.ToString(row["BType"]);
                CType = Convert.ToString(row["CType"]);
                DType = Convert.ToString(row["DType"]);
                EType = Convert.ToString(row["EType"]);
                PType = Convert.ToString(row["pType"]);
                QType1 = Convert.ToString(row["QType1"]);
                RType = Convert.ToString(row["RType"]);
                SType = Convert.ToString(row["SType"]);
                TType = Convert.ToString(row["TType"]);
                passageType = Convert.ToString(row["passageType"]);
                hType = Convert.ToString(row["hType"]);

                settingid1 = Convert.ToInt32(row["SettingId"]);

            }
            else if (TypeDB == "Excel" && lang == "Marathi")
            {
                QType = "1";
                Q1Type = "1";
                AType = "1";
                BType = "1";
                CType = "1";
                DType = "1";
                EType = "1";
                PType = "1";
                QType1 = "1";
                RType = "1";
                SType = "1";
                TType = "1";
                passageType = "1";
                hType = "1";
            }
            else if (TypeDB == "Excel" && lang == "English")
            {
                QType = "0";
                Q1Type = "0";
                AType = "0";
                BType = "0";
                CType = "0";
                DType = "0";
                EType = "0";
                PType = "0";
                QType1 = "0";
                RType = "0";
                SType = "0";
                TType = "0";
                passageType = "0";
                hType = "0";
            }
            else if (TypeDB == "Excel" && lang == "MarathiMangal")
            {
                QType = "3";
                Q1Type = "3";
                AType = "3";
                BType = "3";
                CType = "3";
                DType = "3";
                EType = "3";
                PType = "3";
                QType1 = "3";
                RType = "3";
                SType = "3";
                TType = "3";
                passageType = "3";
                hType = "3";
            }

            string level = Convert.ToString(row["QuestionLevel"]);
            rdoLevelList.SelectedIndex = 0;
            if (level == "2")
                rdoLevelList.SelectedIndex = 1;
            if (level == "3")
                rdoLevelList.SelectedIndex = 2;

            TypeofQues = Convert.ToString(row["TypeofQues"]);

            string Sql = "select Name,ItemValueId from dbo.tblItemValue";
            dsItemValue = cc.ExecuteDataset(Sql);

            DataRow[] dr = dsItemValue.Tables[0].Select("ItemValueId=" + TypeofQues);
            lbltypeQues.Text = "Type of Question : " + dr[0]["Name"].ToString();
            string ans = Convert.ToString(row["Correct_answer"]);

            if (TypeofQues == "80" || TypeofQues == "86" || TypeofQues == "82")
            {
                if (ans == "A")
                    rdoAnswerlist.SelectedIndex = 0;
                if (ans == "B")
                    rdoAnswerlist.SelectedIndex = 1;
                if (ans == "C")
                    rdoAnswerlist.SelectedIndex = 2;
                if (ans == "D")
                    rdoAnswerlist.SelectedIndex = 3;
                if (ans == "E")
                    rdoAnswerlist.SelectedIndex = 4;
                txtAns.Visible = false;
                chkAnslist.Visible = false;
                pnlAnsMat.Visible = false;

                rdoAnswerlist.Visible = true;
            }
            else if (TypeofQues == "93" || TypeofQues == "84")
            {
                txtAns.Text = ans;
                txtAns.Visible = true;
                rdoAnswerlist.Visible = false;
                chkAnslist.Visible = false;
                pnlAnsMat.Visible = false;
            }

            else if (TypeofQues == "83")
            {
                string[] chk = ans.Split(',');

                foreach (string s in chk)
                {
                    if (s == "A")
                        chkAnslist.Items[0].Selected = true;
                    if (s == "B")
                        chkAnslist.Items[1].Selected = true;
                    if (s == "C")
                        chkAnslist.Items[2].Selected = true;
                    if (s == "D")
                        chkAnslist.Items[3].Selected = true;
                    if (s == "E")
                        chkAnslist.Items[4].Selected = true;
                }
                txtAns.Visible = false;
                rdoAnswerlist.Visible = false;
                chkAnslist.Visible = true;
                pnlAnsMat.Visible = false;

            }
            else if (TypeofQues == "87")
            {
                string[] splitstar = ans.Split('*');

                string[] splitcomma = splitstar[0].Split('-')[1].Split(',');
                foreach (string s in splitcomma)
                {
                    if (s == "P")
                        ChkansMatA.Items[0].Selected = true;
                    if (s == "Q")
                        ChkansMatA.Items[1].Selected = true;
                    if (s == "R")
                        ChkansMatA.Items[2].Selected = true;
                    if (s == "S")
                        ChkansMatA.Items[3].Selected = true;
                    if (s == "T")
                        ChkansMatA.Items[4].Selected = true;
                }

                splitcomma = splitstar[1].Split('-')[1].Split(',');
                foreach (string s in splitcomma)
                {
                    if (s == "P")
                        ChkansMatB.Items[0].Selected = true;
                    if (s == "Q")
                        ChkansMatB.Items[1].Selected = true;
                    if (s == "R")
                        ChkansMatB.Items[2].Selected = true;
                    if (s == "S")
                        ChkansMatB.Items[3].Selected = true;
                    if (s == "T")
                        ChkansMatB.Items[4].Selected = true;
                }

                splitcomma = splitstar[2].Split('-')[1].Split(',');
                foreach (string s in splitcomma)
                {
                    if (s == "P")
                        ChkansMatC.Items[0].Selected = true;
                    if (s == "Q")
                        ChkansMatC.Items[1].Selected = true;
                    if (s == "R")
                        ChkansMatC.Items[2].Selected = true;
                    if (s == "S")
                        ChkansMatC.Items[3].Selected = true;
                    if (s == "T")
                        ChkansMatC.Items[4].Selected = true;
                }

                splitcomma = splitstar[3].Split('-')[1].Split(',');
                foreach (string s in splitcomma)
                {
                    if (s == "P")
                        ChkansMatD.Items[0].Selected = true;
                    if (s == "Q")
                        ChkansMatD.Items[1].Selected = true;
                    if (s == "R")
                        ChkansMatD.Items[2].Selected = true;
                    if (s == "S")
                        ChkansMatD.Items[3].Selected = true;
                    if (s == "T")
                        ChkansMatD.Items[4].Selected = true;
                }
                txtAns.Visible = false;
                rdoAnswerlist.Visible = false;
                chkAnslist.Visible = false;
                pnlAnsMat.Visible = true;
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
                lblQuestion.Font.Name = "Shivaji01";
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


            if (AType == "0")
            {
                string s = Convert.ToString(row["Answer1"]);
                s = s.Replace("@011", "'");
                lblOptA.Text = s;

                imgoptA.Visible = false;
                if (lblOptA.Text == "")
                {
                    lblOptA.Visible = false;
                    lblA.Visible = false;
                }
                else
                {
                    lblA.Visible = true;
                    lblOptA.Visible = true;
                }
                lblOptA.Font.Name = "Times New Roman";
                lblOptA.Font.Size = 12;
            }
            else if (AType == "1")
            {
                string s = Convert.ToString(row["Answer1"]);
                s = s.Replace("@011", "'");
                lblOptA.Text = s;

                imgoptA.Visible = false;
                if (lblOptA.Text == "")
                {
                    lblOptA.Visible = false;
                    lblA.Visible = false;
                }
                else
                {
                    lblA.Visible = true;
                    lblOptA.Visible = true;
                }
                lblOptA.Font.Name = "Shivaji01";
                lblOptA.Font.Size = 14;
            }
            else if (AType == "3")
            {
                string s = Convert.ToString(row["Answer1"]);
                s = s.Replace("@011", "'");
                lblOptA.Text = s;

                imgoptA.Visible = false;
                if (lblOptA.Text == "")
                {
                    lblOptA.Visible = false;
                    lblA.Visible = false;
                }
                else
                {
                    lblA.Visible = true;
                    lblOptA.Visible = true;
                }
                lblOptA.Font.Name = "Cambria Math";
                lblOptA.Font.Size = 11;
            }
            else
            {
                lblOptA.Visible = false;
                imgoptA.Visible = true;
                lblA.Visible = true;
                imgoptA.ImageUrl = "~/ImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",Answer1," + s11 + "";
            }

            if (BType == "0")
            {
                string s = Convert.ToString(row["Answer2"]);
                s = s.Replace("@011", "'");
                lblOptB.Text = s;

                imgoptB.Visible = false;
                if (lblOptB.Text == "")
                {
                    lblOptB.Visible = false;
                    lblB.Visible = false;
                }
                else
                {
                    lblB.Visible = true;
                    lblOptB.Visible = true;
                }
                lblOptB.Font.Name = "Times New Roman";
                lblOptB.Font.Size = 12;
            }
            else if (BType == "1")
            {
                string s = Convert.ToString(row["Answer2"]);
                s = s.Replace("@011", "'");
                lblOptB.Text = s;
                imgoptB.Visible = false;
                if (lblOptB.Text == "")
                {
                    lblOptB.Visible = false;
                    lblB.Visible = false;
                }
                else
                {
                    lblB.Visible = true;
                    lblOptB.Visible = true;
                }
                lblOptB.Font.Name = "Shivaji01";
                lblOptB.Font.Size = 14;
            }
            else if (BType == "3")
            {
                string s = Convert.ToString(row["Answer2"]);
                s = s.Replace("@011", "'");
                lblOptB.Text = s;
                imgoptB.Visible = false;
                if (lblOptB.Text == "")
                {
                    lblOptB.Visible = false;
                    lblB.Visible = false;
                }
                else
                {
                    lblB.Visible = true;
                    lblOptB.Visible = true;
                }
                lblOptB.Font.Name = "Cambria Math";
                lblOptB.Font.Size = 11;
            }
            else
            {
                imgoptB.ImageUrl = "~/ImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",Answer2," + s11 + "";
                lblOptB.Visible = false;
                imgoptB.Visible = true;
                lblB.Visible = true;
            }

            if (CType == "0")
            {
                string s = Convert.ToString(row["Answer3"]);
                s = s.Replace("@011", "'");
                lblOptC.Text = s;

                imgoptC.Visible = false;
                if (lblOptC.Text == "")
                {
                    lblOptC.Visible = false;
                    lblC.Visible = false;
                }
                else
                {
                    lblC.Visible = true;
                    lblOptC.Visible = true;
                }
                lblOptC.Font.Name = "Times New Roman";
                lblOptC.Font.Size = 12;
            }
            else if (CType == "1")
            {
                string s = Convert.ToString(row["Answer3"]);
                s = s.Replace("@011", "'");
                lblOptC.Text = s;

                imgoptC.Visible = false;
                if (lblOptC.Text == "")
                {
                    lblOptC.Visible = false;
                    lblC.Visible = false;
                }
                else
                {
                    lblC.Visible = true;
                    lblOptC.Visible = true;
                }
                lblOptC.Font.Name = "Shivaji01";
                lblOptC.Font.Size = 14;
            }
            else if (CType == "3")
            {
                string s = Convert.ToString(row["Answer3"]);
                s = s.Replace("@011", "'");
                lblOptC.Text = s;

                imgoptC.Visible = false;
                if (lblOptC.Text == "")
                {
                    lblOptC.Visible = false;
                    lblC.Visible = false;
                }
                else
                {
                    lblC.Visible = true;
                    lblOptC.Visible = true;
                }
                lblOptC.Font.Name = "Cambria Math";
                lblOptC.Font.Size = 11;
            }
            else
            {
                imgoptC.ImageUrl = "~/ImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",Answer3," + s11 + "";
                lblOptC.Visible = false;
                imgoptC.Visible = true;
                lblC.Visible = true;
            }


            if (DType == "0")
            {
                string s = Convert.ToString(row["Answer4"]);
                s = s.Replace("@011", "'");
                lblOptD.Text = s;

                imgoptD.Visible = false;
                if (lblOptD.Text == "")
                {
                    lblOptD.Visible = false;
                    lblD.Visible = false;
                }
                else
                {
                    lblD.Visible = true;
                    lblOptD.Visible = true;
                }
                lblOptD.Font.Name = "Times New Roman";
                lblOptD.Font.Size = 12;
            }
            else if (DType == "1")
            {
                string s = Convert.ToString(row["Answer4"]);
                s = s.Replace("@011", "'");
                lblOptD.Text = s;

                imgoptD.Visible = false;
                if (lblOptD.Text == "")
                {
                    lblOptD.Visible = false;
                    lblD.Visible = false;
                }
                else
                {
                    lblD.Visible = true;
                    lblOptD.Visible = true;
                }
                lblOptD.Font.Name = "Shivaji01";
                lblOptD.Font.Size = 14;
            }
            else if (DType == "3")
            {
                string s = Convert.ToString(row["Answer4"]);
                s = s.Replace("@011", "'");
                lblOptD.Text = s;

                imgoptD.Visible = false;
                if (lblOptD.Text == "")
                {
                    lblOptD.Visible = false;
                    lblD.Visible = false;
                }
                else
                {
                    lblD.Visible = true;
                    lblOptD.Visible = true;
                }
                lblOptD.Font.Name = "Cambria Math";
                lblOptD.Font.Size = 11;
            }
            else
            {
                imgoptD.ImageUrl = "~/ImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",Answer4," + s11 + "";
                lblOptD.Visible = false;
                imgoptD.Visible = true;
                lblD.Visible = true;
            }

            if (EType == "0")
            {
                string s = Convert.ToString(row["OptionE"]);
                s = s.Replace("@011", "'");
                lblOptE.Text = s;

                imgoptE.Visible = false;
                if (lblOptE.Text == " " || lblOptE.Text == "")
                {
                    lblOptE.Visible = false;
                    lblE.Visible = false;
                    lblE.Visible = false;
                }
                else
                {
                    lblE.Visible = true;
                    lblOptE.Visible = true;
                    lblE.Visible = true;
                }
                lblOptE.Font.Name = "Times New Roman";
                lblOptE.Font.Size = 12;
            }
            else if (EType == "1")
            {
                string s = Convert.ToString(row["OptionE"]);
                s = s.Replace("@011", "'");
                lblOptE.Text = s;

                imgoptE.Visible = false;
                if (lblOptE.Text == " " || lblOptE.Text == "")
                {
                    lblOptE.Visible = false;
                    lblE.Visible = false;
                    lblE.Visible = false;
                }
                else
                {
                    lblE.Visible = true;
                    lblOptE.Visible = true;
                    lblE.Visible = true;
                }
                lblOptE.Font.Name = "Shivaji01";
                lblOptE.Font.Size = 14;
            }
            else if (EType == "3")
            {
                string s = Convert.ToString(row["OptionE"]);
                s = s.Replace("@011", "'");
                lblOptE.Text = s;

                imgoptE.Visible = false;
                if (lblOptE.Text == " " || lblOptE.Text == "")
                {
                    lblOptE.Visible = false;
                    lblE.Visible = false;
                    lblE.Visible = false;
                }
                else
                {
                    lblE.Visible = true;
                    lblOptE.Visible = true;
                    lblE.Visible = true;
                }
                lblOptE.Font.Name = "Cambria Math";
                lblOptE.Font.Size = 11;
            }
            else
            {
                imgoptE.ImageUrl = "~/ImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",OptionE," + s11 + "";
                lblOptE.Visible = false;
                imgoptE.Visible = true;
                lblE.Visible = true;
                lblE.Visible = true;
            }


            if (PType == "0")
            {
                string s = Convert.ToString(row["OptionP"]);
                s = s.Replace("@011", "'");
                lblOptP.Text = s;
                imgoptP.Visible = false;
                if (lblOptP.Text == "")
                {
                    lblOptP.Visible = false;
                    lblP.Visible = false;
                }
                else
                {
                    lblP.Visible = true;
                    lblOptP.Visible = true;
                }
                lblOptP.Font.Name = "Times New Roman";
                lblOptP.Font.Size = 12;
            }
            else if (PType == "1")
            {
                string s = Convert.ToString(row["OptionP"]);
                s = s.Replace("@011", "'");
                lblOptP.Text = s;
                imgoptP.Visible = false;
                if (lblOptP.Text == "")
                {
                    lblOptP.Visible = false;
                    lblP.Visible = false;
                }
                else
                {
                    lblP.Visible = true;
                    lblOptP.Visible = true;
                }
                lblOptP.Font.Name = "Shivaji01";
                lblOptP.Font.Size = 14;
            }
            else if (PType == "3")
            {
                string s = Convert.ToString(row["OptionP"]);
                s = s.Replace("@011", "'");
                lblOptP.Text = s;
                imgoptP.Visible = false;
                if (lblOptP.Text == "")
                {
                    lblOptP.Visible = false;
                    lblP.Visible = false;
                }
                else
                {
                    lblP.Visible = true;
                    lblOptP.Visible = true;
                }
                lblOptP.Font.Name = "Mangal";
                lblOptP.Font.Size = 14;
            }
            else
            {
                imgoptP.ImageUrl = "~/ImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",OptionP," + s11 + "";
                lblOptP.Visible = false;
                imgoptP.Visible = true;
                lblP.Visible = true;
            }

            if (QType1 == "0")
            {
                string s = Convert.ToString(row["OptionQ"]);
                s = s.Replace("@011", "'");
                lblOptQ.Text = s;
                imgoptQ.Visible = false;
                if (lblOptQ.Text == "")
                {
                    lblOptQ.Visible = false;
                    lblQ.Visible = false;
                }
                else
                {
                    lblQ.Visible = true;
                    lblOptQ.Visible = true;
                }
                lblOptQ.Font.Name = "Times New Roman";
                lblOptQ.Font.Size = 12;
            }
            else if (QType1 == "1")
            {
                string s = Convert.ToString(row["OptionQ"]);
                s = s.Replace("@011", "'");
                lblOptQ.Text = s;
                imgoptQ.Visible = false;
                if (lblOptQ.Text == "")
                {
                    lblOptQ.Visible = false;
                    lblQ.Visible = false;
                }
                else
                {
                    lblQ.Visible = true;
                    lblOptQ.Visible = true;
                }
                lblOptQ.Font.Name = "Shivaji01";
                lblOptQ.Font.Size = 14;
            }
            else if (QType1 == "3")
            {
                string s = Convert.ToString(row["OptionQ"]);
                s = s.Replace("@011", "'");
                lblOptQ.Text = s;
                imgoptQ.Visible = false;
                if (lblOptQ.Text == "")
                {
                    lblOptQ.Visible = false;
                    lblQ.Visible = false;
                }
                else
                {
                    lblQ.Visible = true;
                    lblOptQ.Visible = true;
                }
                lblOptQ.Font.Name = "Mangal";
                lblOptQ.Font.Size = 14;
            }
            else
            {
                imgoptQ.ImageUrl = "~/ImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",OptionQ," + s11 + "";
                lblOptQ.Visible = false;
                imgoptQ.Visible = true;
                lblQ.Visible = true;
            }

            if (RType == "0")
            {
                string s = Convert.ToString(row["OptionR"]);
                s = s.Replace("@011", "'");
                lblOptR.Text = s;
                imgoptR.Visible = false;
                if (lblOptR.Text == "")
                {
                    lblOptR.Visible = false;
                    lblR.Visible = false;
                }
                else
                {
                    lblR.Visible = true;
                    lblOptR.Visible = true;
                }
                lblOptR.Font.Name = "Times New Roman";
                lblOptR.Font.Size = 12;
            }
            else if (RType == "1")
            {
                string s = Convert.ToString(row["OptionR"]);
                s = s.Replace("@011", "'");
                lblOptR.Text = s;
                imgoptR.Visible = false;
                if (lblOptR.Text == "")
                {
                    lblOptR.Visible = false;
                    lblR.Visible = false;
                }
                else
                {
                    lblR.Visible = true;
                    lblOptR.Visible = true;
                }
                lblOptR.Font.Name = "Shivaji01";
                lblOptR.Font.Size = 14;
            }
            else if (RType == "3")
            {
                string s = Convert.ToString(row["OptionR"]);
                s = s.Replace("@011", "'");
                lblOptR.Text = s;
                imgoptR.Visible = false;
                if (lblOptR.Text == "")
                {
                    lblOptR.Visible = false;
                    lblR.Visible = false;
                }
                else
                {
                    lblR.Visible = true;
                    lblOptR.Visible = true;
                }
                lblOptR.Font.Name = "Mangal";
                lblOptR.Font.Size = 14;
            }
            else
            {
                imgoptR.ImageUrl = "~/ImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",OptionR," + s11 + "";
                lblOptR.Visible = false;
                imgoptR.Visible = true;
                lblR.Visible = true;
            }

            if (SType == "0")
            {
                string s = Convert.ToString(row["OptionS"]);
                s = s.Replace("@011", "'");
                lblOptS.Text = s;
                imgoptS.Visible = false;
                if (lblOptS.Text == "")
                {
                    lblOptS.Visible = false;
                    lblS.Visible = false;
                }
                else
                {
                    lblS.Visible = true;
                    lblOptS.Visible = true;
                }
                lblOptS.Font.Name = "Times New Roman";
                lblOptS.Font.Size = 12;
            }
            else if (SType == "1")
            {
                string s = Convert.ToString(row["OptionS"]);
                s = s.Replace("@011", "'");
                lblOptS.Text = s;
                imgoptS.Visible = false;
                if (lblOptS.Text == "")
                {
                    lblOptS.Visible = false;
                    lblS.Visible = false;
                }
                else
                {
                    lblS.Visible = true;
                    lblOptS.Visible = true;
                }
                lblOptS.Font.Name = "Shivaji01";
                lblOptS.Font.Size = 14;
            }
            else if (SType == "3")
            {
                string s = Convert.ToString(row["OptionS"]);
                s = s.Replace("@011", "'");
                lblOptS.Text = s;
                imgoptS.Visible = false;
                if (lblOptS.Text == "")
                {
                    lblOptS.Visible = false;
                    lblS.Visible = false;
                }
                else
                {
                    lblS.Visible = true;
                    lblOptS.Visible = true;
                }
                lblOptS.Font.Name = "Mangal";
                lblOptS.Font.Size = 14;
            }
            else
            {
                imgoptS.ImageUrl = "~/ImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",OptionS," + s11 + "";
                lblOptS.Visible = false;
                imgoptS.Visible = true;
                lblS.Visible = true;
            }

            if (TType == "0")
            {
                string s = Convert.ToString(row["OptionT"]);
                s = s.Replace("@011", "'");
                lblOptT.Text = s;
                imgoptT.Visible = false;
                if (lblOptT.Text == "" || lblOptT.Text == " ")
                {
                    lblOptT.Visible = false;
                    lblT.Visible = false;
                    lblT.Visible = false;
                }
                else
                {
                    lblT.Visible = true;
                    lblOptT.Visible = true;
                    lblT.Visible = true;
                }
                lblOptT.Font.Name = "Times New Roman";
                lblOptT.Font.Size = 12;
            }
            else if (TType == "1")
            {
                string s = Convert.ToString(row["OptionT"]);
                s = s.Replace("@011", "'");
                lblOptT.Text = s;
                imgoptT.Visible = false;
                if (lblOptT.Text == "" || lblOptT.Text == " ")
                {
                    lblOptT.Visible = false;
                    lblT.Visible = false;
                    lblT.Visible = false;
                }
                else
                {
                    lblT.Visible = true;
                    lblOptT.Visible = true;
                    lblT.Visible = true;
                }
                lblOptT.Font.Name = "Shivaji01";
                lblOptT.Font.Size = 14;
            }
            else if (TType == "3")
            {
                string s = Convert.ToString(row["OptionT"]);
                s = s.Replace("@011", "'");
                lblOptT.Text = s;
                imgoptT.Visible = false;
                if (lblOptT.Text == "" || lblOptT.Text == " ")
                {
                    lblOptT.Visible = false;
                    lblT.Visible = false;
                    lblT.Visible = false;
                }
                else
                {
                    lblT.Visible = true;
                    lblOptT.Visible = true;
                    lblT.Visible = true;
                }
                lblOptT.Font.Name = "Mangal";
                lblOptT.Font.Size = 14;
            }
            else
            {
                imgoptT.ImageUrl = "~/ImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",OptionT," + s11 + "";
                lblOptT.Visible = false;
                imgoptT.Visible = true;
                lblT.Visible = true;
            }

            if (passageType == "0")
            {
                string s = Convert.ToString(row["Passage"]);
                s = s.Replace("@011", "'");
                lblPassage.Text = s;
                imgPassage.Visible = false;
                if (lblPassage.Text == "")
                {
                    lblPassage.Visible = false;
                    lblpassage1.Visible = false;
                }
                else
                {
                    lblpassage1.Visible = true;
                    lblPassage.Visible = true;
                }
                lblPassage.Font.Name = "Times New Roman";
                lblPassage.Font.Size = 12;

            }
            else if (passageType == "1")
            {
                string s = Convert.ToString(row["Passage"]);
                s = s.Replace("@011", "'");
                lblPassage.Text = s;
                imgPassage.Visible = false;
                if (lblPassage.Text == "")
                {
                    lblPassage.Visible = false;
                    lblpassage1.Visible = false;
                }
                else
                {
                    lblpassage1.Visible = true;
                    lblPassage.Visible = true;
                }
                lblPassage.Font.Name = "Shivaji01";
                lblPassage.Font.Size = 14;
            }
            else if (passageType == "3")
            {
                string s = Convert.ToString(row["Passage"]);
                s = s.Replace("@011", "'");
                lblPassage.Text = s;
                imgPassage.Visible = false;
                if (lblPassage.Text == "")
                {
                    lblPassage.Visible = false;
                    lblpassage1.Visible = false;
                }
                else
                {
                    lblpassage1.Visible = true;
                    lblPassage.Visible = true;
                }
                lblPassage.Font.Name = "Mangal";
                lblPassage.Font.Size = 14;
            }
            else
            {
                imgPassage.ImageUrl = "~/ImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",Passage," + s11 + "";
                lblPassage.Visible = false;
                imgPassage.Visible = true;
                lblpassage1.Visible = true;
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
                lblQuestionwithImage.Font.Name = "Shivaji01";
                lblQuestionwithImage.Font.Size = 14;
            }
            else if (Q1Type == "3")
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

                hintDB = s;
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

                hintDB = s;
                ddlhint.SelectedIndex = Convert.ToInt32(hType);
                txtHint.Font.Name = "Shivaji01";
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
                txtHint.Text = s;

                hintDB = s;

                txtHint.Font.Name = "Cambria Math";
                txtHint.Font.Size = 11;
                imgHint.Visible = false;

                txtHint.Visible = true;
                lblH.Visible = true;
                ddlhint.Visible = true;

            }
            else
            {
                string s = Convert.ToString(row["Qhint"]);
                string[] val = s.Split('₹');
                if (val.Length == 3)
                {
                    imgHint.ImageUrl = "~/ImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",Qhint," + s11 + "";
                    imgHint2.ImageUrl = "~/HintImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",Qhint," + s11 + "";

                    txtHint.Visible = false;
                    imgHint.Visible = true;
                    imgHint2.Visible = true;
                    lblH.Visible = true;
                    ddlhint.Visible = false;
                }
                else
                {
                    imgHint.ImageUrl = "~/ImageHandlerAddQuesInExam.ashx?para=" + NewQID + ",Qhint," + s11 + "";
                    txtHint.Visible = false;
                    imgHint.Visible = true;
                    imgHint2.Visible = false;
                    lblH.Visible = true;
                    ddlhint.Visible = false;
                }
            }
        }
    }

    protected void ddlhint_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlhint.SelectedIndex == 0)
        {
            txtHint.Font.Name = "Times New Roman";
            txtHint.Font.Size = 9;
        }
        else if (ddlhint.SelectedIndex == 1)
        {
            txtHint.Font.Name = "Shivaji01";
            txtHint.Font.Size = 14;
        }
        else if (ddlhint.SelectedIndex == 3)
        {
            txtHint.Font.Name = "Cambria Math";
            txtHint.Font.Size = 11;
        }
    }
    public void clearcontrol()
    {
        lblQuestion.Text = "";
        lblQuestionwithImage.Text = "";
        lblPassage.Text = "";
        lblOptA.Text = "";
        lblOptB.Text = "";
        lblOptC.Text = "";
        lblOptD.Text = "";
        lblOptE.Text = "";
        lblOptP.Text = "";
        lblOptQ.Text = "";
        lblOptR.Text = "";
        lblOptS.Text = "";
        lblOptT.Text = "";
        txtHint.Text = "";
        txtSuggest.Text = "";

        imgQues.ImageUrl = "";
        imgPassage.ImageUrl = "";
        imgoptA.ImageUrl = "";
        imgoptB.ImageUrl = "";
        imgoptC.ImageUrl = "";
        imgoptD.ImageUrl = "";
        imgoptE.ImageUrl = "";
        imgoptP.ImageUrl = "";
        imgoptQ.ImageUrl = "";
        imgoptR.ImageUrl = "";
        imgoptS.ImageUrl = "";
        imgoptT.ImageUrl = "";
        imgQuesImage.ImageUrl = "";
        imgHint.ImageUrl = "";


    }

    public void clearFields()
    {
        ddltextName.SelectedIndex = ddltextName.Items.Count - 1;
        ddlMedium.SelectedIndex = 0;
        cmbSelectsubject.SelectedIndex = cmbSelectsubject.Items.Count - 1;
        ChkSelectALL.Checked = false;
        rdoLevelList1.ClearSelection();
        foreach (ListItem li in ddlChapter.Items)
        {
            li.Selected = false;

        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

        clearFields();

    }

    string QuestionID, s1;
    protected void chkAddQuestion_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAddQuestion.Checked == true)
        {
            Session["QuestionID"] = Session["QuestionID"] + lblSno.Text + ",";
            s1 = Convert.ToString(Session["QuestionID"]);
        }
        else
        {
            // coding for chk   uncheck then remove  id 
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int TotalQuetion = Convert.ToInt32(Session["TotalQuetion"]);
            int AddingQuestion = Convert.ToInt32(Session["AddingQuestion"]);

            if (TotalQuetion >= AddingQuestion && TotalQuetion != AddingQuestion)
            {
                int ExamType = 0;
                string QuestionIDSet = Convert.ToString(Session["QuestionID"]);
                if (QuestionIDSet != "")
                {
                    QuestionIDSet = QuestionIDSet.Substring(0, QuestionIDSet.Length - 1);

                    testDefBAL.Test_ID1 = Convert.ToInt32(ddltextName.SelectedValue);
                    DataSet ds = testDefBAL.getLevelTestDef(testDefBAL);

                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        ExamType = Convert.ToInt32(ds.Tables[0].Rows[0]["TypeOFExam"]);

                        string[] splitid = QuestionIDSet.Split(',');

                        if (splitid.Length > 0)
                        {
                            for (int i = 0; i < splitid.Length; i++)
                            {
                                Sql = "select SNO from tbl5164 where SNO=" + splitid[i] + " and TestID='" + Convert.ToInt32(Session["TestID"]) + "' ";
                                string sno = Convert.ToString(cc.ExecuteScalar(Sql));

                                if (sno == "")
                                {
                                    Sql = " Insert Into tbl5164 " +
                                       " SELECT  SNO,Question_id,Question,QType,Answer1,AType,Answer2,BType,Answer3,CType,Answer4,DType,OptionE,EType,OptionP,PType,OptionQ,QType1,OptionR,RType,OptionS,SType, " +
                                       " OptionT,TType,Passage,passageType,QuesWithImage,Q1Type,Qhint,hType,Correct_answer,QuestionLevel,MobileNo,SettingId,changeDate,Ischecked,TypeOFExam,TypeofQues,Class_id, " +
                                       " Subject_id,Chapter_id,Topic_id,QuesVerify,Suggestion,UploaderMoNo,UniqueId,DOUpload,LoginId,checkerLoginId,Test_ID,Image,MediumID,Sellanguage,userClass_id,userSubject_id, " +
                                       " userChapter_id,userTopic_id,userCompitativeExam,TypeofMaterial,TypeofDB,examQwener,flag,createdate,UploadFileName,Class_AdmVerify,Class_AdmSuggest,Class_AdmLogin,PublicationName, " +
                                       " '" + Convert.ToInt32(Session["TestID"]) + "','" + Convert.ToString(Session["Loginid"]) + "'	FROM tblQuestionAccess " +
                                       " where  SNO = " + splitid[i] + " ";

                                    int status1 = cc.ExecuteNonQuery(Sql);
                                    if (status1 >= 1)
                                    {
                                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert(' " + status1 + " Question Added Successfully')", true);
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert(' Selected Question Already Exist.')", true);
                                    }
                                }
                            }
                            GetTotal();
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
                GetTotal();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry You not Add More Than Total Question Count. !!!')", true);
            }
        }
        catch
        {

        }
    }

    protected void ddltextName_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadSubject(ddltextName.SelectedValue);
    }

    //protected void ddlpublication_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    loadPublication();
    //}

    private void loadSubject(string test)
    {
        if (ddltextName.SelectedIndex == ddltextName.Items.Count - 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Exam Name')", true);
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
        Cds.GetChapterNames(ddlTopik, ddltextName, cmbSelectsubject);
        //LoadChapter();
        // LoadChapter(ddlTopik.SelectedValue);
    }

    //private void LoadChapter()
    //{
    //    string sql = "SELECT [TypeOFExam],[Class_id] FROM [tblTestDefinition] WHERE [Test_ID]='" + ddltextName.SelectedValue + "'";
    //    DataSet ds = cc.ExecuteDataset(sql);

    //    string TOE_id = Convert.ToString(ds.Tables[0].Rows[0]["TypeOFExam"]);
    //    string Cl_id = Convert.ToString(ds.Tables[0].Rows[0]["Class_id"]);

    //    string sqlQuery = " SELECT [ChapterID],[ChapterName] FROM [tblChapterANDTopicNames] WHERE [TypeofExamId]='" + TOE_id + "' AND [ClassID]='" + Cl_id + "' AND [SubjectID]='" + cmbSelectsubject.SelectedValue + "' "; //and [ChapterID] IN(" + Id +") ";
    //    DataSet dataset = cc.ExecuteDataset(sqlQuery);

    //    if (dataset.Tables[0].Rows.Count > 0)
    //    {
    //        string chaptername = Convert.ToString(dataset.Tables[0].Rows[0]["ChapterName"]);
    //        if (chaptername == "")
    //        {
    //            Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 0 OR [ItemId] = 3"; //and ItemValueId in(" + Id + ")";
    //            dataset = cc.ExecuteDataset(Sql);

    //            ddlTopik.DataSource = dataset.Tables[0];
    //            ddlTopik.DataTextField = "Name";
    //            ddlTopik.DataValueField = "ItemValueId";
    //            ddlTopik.DataBind();
    //            //ddlTopik.Items.Add("--Select--");
    //            //ddlTopik.SelectedIndex = ddlTopik.Items.Count - 1;
    //            //ChkSelectALL.Visible = true;
    //        }
    //        else
    //        {
    //            ddlTopik.DataSource = dataset.Tables[0];  //ddlChapter
    //            ddlTopik.DataTextField = "ChapterName";
    //            ddlTopik.DataValueField = "ChapterID";
    //            ddlTopik.DataBind();
    //            ddlTopik.Items.Add("--Select--");
    //            ddlTopik.SelectedIndex = ddlTopik.Items.Count - 1;
    //            //ChkSelectALL.Visible = true;
    //        }
    //    }
    //    else
    //    {
    //        string Sql = "SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 0 OR [ItemId] = 3"; //and ItemValueId in(" + Id + ")";
    //        dataset = cc.ExecuteDataset(Sql);

    //        ddlTopik.DataSource = dataset.Tables[0];
    //        ddlTopik.DataTextField = "Name";
    //        ddlTopik.DataValueField = "ItemValueId";
    //        ddlTopik.DataBind();
    //        //ddlTopik.Items.Add("--Select--");
    //        //ddlTopik.SelectedIndex = ddlTopik.Items.Count - 1;
    //        //ChkSelectALL.Visible = true;
    //    }

    //    //string SQl = "select Chapter_id from dbo.tblAssignExamChapter where Subject_id=" + SubjectID + " and TestID=" + ddltextName.SelectedValue + "";
    //    //string Id = Convert.ToString(cc.ExecuteScalar(SQl));



    //    //if (Id == "")
    //    //{
    //    //    // ddlChapter.Items.Clear();
    //    //    // ChkSelectALL.Visible = false;

    //    //}
    //    //else
    //    //{
    //    //    Sql = "select Name,ItemValueId from dbo.tblItemValue where ItemId=3 and ItemValueId in(" + Id + ")";
    //    //    DataSet ds = cc.ExecuteDataset(Sql);
    //    //    if (ds.Tables[0].Rows.Count > 0)
    //    //    {
    //    //        ddlTopik.DataSource = ds.Tables[0];
    //    //        ddlTopik.DataTextField = "Name";
    //    //        ddlTopik.DataValueField = "ItemValueId";
    //    //        ddlTopik.DataBind();
    //    //        ddlTopik.Items.Add("--Select--");
    //    //        ddlTopik.SelectedIndex = ddlTopik.Items.Count - 1;
    //    //        //ChkSelectALL.Checked = false; 
    //    //        //ChkSelectALL.Visible = true;

    //    //    }
    //    //}

    //}
    //private void LoadChapter(string SubjectID)
    //{
    //    if (cmbSelectsubject.SelectedIndex == cmbSelectsubject.Items.Count - 1)
    //    {
    //        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Sujject.')", true);
    //        ChkSelectALL.Checked = false;
    //        ddlChapter.Items.Clear();
    //        ChkSelectALL.Visible = false;

    //    }
    //    else
    //    {
    //        string SQl = "select Chapter_id from dbo.tblAssignExamChapter where Subject_id=" + SubjectID + " and TestID=" + ddltextName.SelectedValue + "";
    //        string Id = Convert.ToString(cc.ExecuteScalar(SQl));
    //        if (Id == "")
    //        {
    //            ddlChapter.Items.Clear();
    //            ChkSelectALL.Visible = false;

    //        }
    //        else
    //        {
    //            Sql = "select Name,ItemValueId from dbo.tblItemValue where ItemId=3 and ItemValueId in(" + Id + ")";
    //            DataSet ds = cc.ExecuteDataset(Sql);
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                ddlChapter.DataSource = ds.Tables[0];
    //                ddlChapter.DataTextField = "Name";
    //                ddlChapter.DataValueField = "ItemValueId";
    //                ddlChapter.DataBind();
    //                ChkSelectALL.Checked = false;
    //                ChkSelectALL.Visible = true;

    //            }
    //        }
    //    }
    //}
    public void LoadTopic(string chptrid)
    {

        if (ddlTopik.SelectedIndex == cmbSelectsubject.Items.Count - 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Chapter.')", true);
            // ChkSelectALL.Checked = false;
            ddlChapter.Items.Clear();
            // ChkSelectALL.Visible = false;

        }
        else
        {
            //string SQl = "select Chapter_id from dbo.tblAssignExamChapter where Subject_id=" + chptrid + " and TestID=" + ddltextName.SelectedValue + "";
            // string Id = Convert.ToString(cc.ExecuteScalar(SQl));
            //  if (Id == "")
            //  {
            //     ddlChapter.Items.Clear();
            //      ChkSelectALL.Visible = false;

            //}
            //  else
            // {
            Sql = "select Name,ItemValueId from dbo.tblItemValue where ItemId=4"; //and ItemValueId in(" + Id + ")";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlChapter.DataSource = ds.Tables[0];
                ddlChapter.DataTextField = "Name";
                ddlChapter.DataValueField = "ItemValueId";
                ddlChapter.DataBind();
                // ChkSelectALL.Checked = false;
                // ChkSelectALL.Visible = true;

            }
            // }
        }
    }

    //#region ToGet TopicName
    //public void GetNameTopic()
    //{
    //    string sql = "SELECT [TypeOFExam],[Class_id] FROM [tblTestDefinition] WHERE [Test_ID]='" + ddltextName.SelectedValue + "'";
    //    DataSet ds = cc.ExecuteDataset(sql);

    //    string TOE_id = Convert.ToString(ds.Tables[0].Rows[0]["TypeOFExam"]);
    //    string Cl_id = Convert.ToString(ds.Tables[0].Rows[0]["Class_id"]);

    //    string Sql = " SELECT [TopicID],[TopicName] FROM [tblChapterANDTopicNames] WHERE  [SubjectID]='" + cmbSelectsubject.SelectedValue + "' AND [ChapterID]='" + ddlTopik.SelectedValue + "' AND TypeofExamId='" + TOE_id + "' AND ClassID='" + Cl_id + "' ";
    //    DataSet dataset = cc.ExecuteDataset(Sql);

    //    if (dataset.Tables[0].Rows.Count > 0)
    //    {
    //        string topicname = Convert.ToString(dataset.Tables[0].Rows[0]["TopicName"]);
    //        if (topicname == "")
    //        {
    //            Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 4 ";
    //            dataset = cc.ExecuteDataset(Sql);

    //            ddlChapter.DataSource = dataset.Tables[0];
    //            ddlChapter.DataTextField = "Name";
    //            ddlChapter.DataValueField = "ItemValueId";
    //            ddlChapter.DataBind();

    //            ChkSelectALL.Visible = true;

    //            //ddlChapter.DataSource = dataset.Tables[0];
    //            //ddlChapter.DataTextField = "TopicName";
    //            //ddlChapter.DataValueField = "TopicID";
    //            //ddlChapter.DataBind();

    //            //ChkSelectALL.Visible = true;
    //        }
    //        else
    //        {
    //            ddlChapter.DataSource = dataset.Tables[0];
    //            ddlChapter.DataTextField = "TopicName";
    //            ddlChapter.DataValueField = "TopicID";
    //            ddlChapter.DataBind();

    //            ChkSelectALL.Visible = true;
    //        }
    //    }
    //    else
    //    {

    //        Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 4 ";
    //        dataset = cc.ExecuteDataset(Sql);

    //        ddlChapter.DataSource = dataset.Tables[0];
    //        ddlChapter.DataTextField = "Name";
    //        ddlChapter.DataValueField = "ItemValueId";
    //        ddlChapter.DataBind();

    //        ChkSelectALL.Visible = true;
    //    }
    //}
    //#endregion

    protected void ddlTopik_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cds.GetToipcName(ddltextName, cmbSelectsubject, ddlTopik, ddlChapter, ChkSelectALL);
        //LoadTopic(ddlTopik.SelectedValue);
        //GetNameTopic();
    }

    protected void rdoLevelList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltextName.SelectedIndex == ddltextName.Items.Count - 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Exam Name')", true);

        }
        else
        {
            int text = Convert.ToInt32(ddltextName.SelectedValue);
            Session["testid"] = text;
            GetTotal();
        }
    }

    public void GetTotal()  // Calculated Number of Question assign for lavel 1,2,3 and remaining Question
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

                string SQl = " Select count(QuestionLevel) as L1  from tbl5164 where QuestionLevel=1 and   TestID='" + Convert.ToInt32(Session["TestID"]) + "' " +
                             " Select count(QuestionLevel) as L2  from tbl5164 where QuestionLevel=2 and   TestID='" + Convert.ToInt32(Session["TestID"]) + "' " +
                             " Select count(QuestionLevel) as L3  from tbl5164 where QuestionLevel=3 and   TestID='" + Convert.ToInt32(Session["TestID"]) + "' ";

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
                lblt1.Text = "Total Questions In Exam= " + Total;
                lblt1.Visible = true;
                lblt2.Text = "Total Questions added in Exam=" + ATotal1;
                lblt2.Visible = true;
                lblt3.Text = "Questions Remaining to be added= " + RTotal1;
                lblt3.Visible = true;


                pnl1.Visible = true;
                lblTotalQNo.Text = "Total Questions In Exam= " + Total + " (Level1 + Level2 + Level3 =" + DLevel1 + "+" + DLevel2 + "+" + DLevel3 + ")";
                lblAvailable.Text = "Total Questions added in Exam= " + ATotal1 + " (Level1 + Level2 + Level3 =" + ALevel1 + "+" + ALevel2 + "+" + ALevel3 + ")";
                lblRemaininhg.Text = "Questions Remaining to be added= " + RTotal1 + " (Level1 + Level2 + Level3 =" + RLevel1 + "+" + RLevel2 + "+" + RLevel3 + ")";


            }
            else
            {
                pnl1.Visible = false;
            }


        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
    }

    protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
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

    protected void btnarchive_Click(object sender, EventArgs e)
    {
        if (ddltextName.SelectedIndex == ddltextName.Items.Count - 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Exam Name')", true);

        }
        else
        {
            string s11 = "tblArchive" + Convert.ToString(Session["CompanyId"]) + "" + Convert.ToString(Session["TestID"]);
            string s12 = "tbl" + Convert.ToString(Session["CompanyId"]) + "" + Convert.ToString(Session["TestID"]);

            try
            {
                Sql = "select * from  " + s11 + " ";
                status = cc.ExecuteNonQuery(Sql);
            }
            catch (Exception ex)
            {
                Response.Write("<h4>" + ex.Message);
            }
            if (status != -1)
            {
                string queryString =
                                    @"
                CREATE TABLE MyTableatul2
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

                queryString = queryString.Replace("MyTableatul2", s11);

                status = cc.ExecuteNonQuery(queryString);
                if (status == -1)
                {
                    Sql = "insert into " + s11 + " ([SNO] , [Question_id],[Question],[QType],[Answer1] ,[AType],[Answer2],[BType],[Answer3] ,[CType],[Answer4],[DType] ) " +

                 @"SELECT  [SNO] ,
                [Question_id],
                [Question],
                [QType],
                [Answer1] ,
                [AType],
                [Answer2],
                [BType],
                [Answer3] ,
                [CType],
                [Answer4],
                [DType] 
                 FROM " + s12 + " ";


                    int status1 = cc.ExecuteNonQuery(Sql);
                    if (status1 >= 1)
                    {
                        Sql = "truncate table  " + s12 + "";
                        status1 = cc.ExecuteNonQuery(Sql);
                        if (status1 >= 1)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('BackUp Succesfully restored.')", true);

                        }

                    }
                }
            }
            else
            {
                Sql = "insert into " + s11 + " " +
                              " SELECT  * FROM " + s12 + " ";


                int status1 = cc.ExecuteNonQuery(Sql);
                if (status1 >= 1)
                {

                    Sql = "truncate table  " + s12 + "";
                    status1 = cc.ExecuteNonQuery(Sql);
                    if (status1 >= 1)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('BackUp Succesfully restored.')", true);

                    }

                }
            }
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string Id = ddltextName.SelectedValue;
        Response.Redirect("~/Admin/frmPrintQuestion.aspx?Id=" + Id);

    }

    protected void btnInsturc_Click(object sender, EventArgs e)
    {
        string Id = ddltextName.SelectedValue;

        Response.Redirect("~/Admin/Instruction.aspx?Id=" + Id);
    }

    protected void btnBack1_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
    }

    protected void btnGotoQues_Click(object sender, EventArgs e)
    {
        try
        {
            int NewQID = Convert.ToInt32(txtGotoQues.Text);
            if (NewQID < Convert.ToInt32((lblcount.Text.Split(':')[1])))
            {
                //string s11 = Convert.ToString(Session["CompanyId"]) + "" + Convert.ToString(Session["TestID"]);
                string s11 = Convert.ToString(Session["TestID"]);

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

}
