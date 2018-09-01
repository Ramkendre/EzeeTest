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
using System.ComponentModel;
using System.Collections.Generic;

public partial class SubAdmin_NewGridView : System.Web.UI.Page
{

    BindQuestionsToGridBAL objBindQuestionsToGridBAL = new BindQuestionsToGridBAL();
    CommanDDLbindclass Cds = new CommanDDLbindclass();
    //int status, TotalQuetion, AddingQuestion;
    CommonCode cc = new CommonCode();
    TestDefinationBLL testDefBAL = new TestDefinationBLL();
    AssignQuestionInExamBAL assignQuestioninexamBal = new AssignQuestionInExamBAL();

    public static string Chapter_id = "";
    public static int TypeOFExam = 0;
    public static int Class_id = 0;
    public static int Subject_id = 0;
    public static string Subjectid = "";
    public static string MediumID = "";

    public DataSet dsStatic = null;
    public DataSet dsItemValue = null;

    string Sql = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MultiView1.ActiveViewIndex = 0;
            loadTestName();
            LoadClass();
            loadSubject();
            LoadTypeofQues();
            LoadTypeofExams();
            loadChapter();
            loadTopic();
            loadPublication();
        }
    }
    public void loadPublication()
    {
        string role = Convert.ToString(Session["Role"]);
        if (role == "8" || role == "19")
        {
            Sql = "SELECT Name,ItemValueId FROM tblItemValue WHERE  ItemId=0 OR ItemId=7 ";
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

    int pageNumber, pageSize, startindex, endindex;
    public void BindGrid()
    {
        //string s11 = Convert.ToString(Session["TestID"]);

        string s11 = ddltextName.SelectedValue;//Convert.ToString(Session["TestID"]);

        string viewtblName = "tbll" + s11 + " ";
        Sql = "SELECT COUNT (*) FROM " + viewtblName + " ";
        string tempcount = cc.ExecuteScalar(Sql);
        if (Convert.ToInt32(tempcount) < 1000)
            lblcount.Text = "Total Number of Question : " + tempcount;
        else
        {
            tempcount = "1000";
            lblcount.Text = "Total Number of Question : " + tempcount;
        }

        if (ViewState["PageNumber"] != null)
            pageNumber = Convert.ToInt32(ViewState["PageNumber"].ToString());
        else
        {
            pageNumber = 1;
            startindex = 1;
            endindex = 10;
        }

        if (pageNumber == 1)
        {
            pageNumber = 1;
            startindex = 1;
            endindex = 10;
        }

        pageSize = 10;

        if (pageNumber > 1)
        {
            startindex = ((pageNumber - 1) * pageSize) + 1;

            endindex = pageNumber * pageSize;
            if (Convert.ToInt32(tempcount) < endindex)
            {
                endindex = Convert.ToInt32(tempcount);
            }
        }

        Sql = " SELECT NewQID," + viewtblName + ".SNO,Question,TypeofDB,Sellanguage,QType,tblItemValue.Name AS TypeofQues FROM " + viewtblName + " INNER JOIN tblItemValue ON " + viewtblName + ".TypeofQues=tblItemValue.ItemValueId  " +
              " WHERE NewQID>=" + startindex + " AND NewQID<=" + endindex + " ";
        DataSet ds = cc.ExecuteDataset(Sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            gvBindQuestions.DataSource = ds.Tables[0];
            gvBindQuestions.DataBind();
            gvBindQuestions.Visible = true;

            populatePager(Convert.ToInt32(tempcount), pageNumber, pageSize);
        }
    }


    //protected void chkAll_CheckedChanged(object sender, EventArgs e)
    //{

    //    CheckBox ChkBoxHeader = (CheckBox)gvBindQuestions.HeaderRow.FindControl("chkAll");
    //    foreach (GridViewRow row in gvBindQuestions.Rows)
    //    {
    //        CheckBox ChkBoxRows = (CheckBox)row.FindControl("chk1");
    //        if (ChkBoxHeader.Checked == true)
    //        {
    //            ChkBoxRows.Checked = true;
    //        }
    //        else
    //        {
    //            ChkBoxRows.Checked = false;
    //        }
    //    }

    //}

    private void populatePager(int total, int currentPage, int pageSize)
    {

        double pageCount = (double)((total) / pageSize);
        int pageNumber = (int)Math.Ceiling(pageCount);
        if ((total % pageSize) != 0)
            pageNumber++;

        List<ListItem> pages = new List<ListItem>();
        if (pageNumber > 0)
        {
            pages.Add(new ListItem("First", "1", currentPage > 1));
            for (int i = 2; i < pageNumber; i++)
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            pages.Add(new ListItem("Last", pageNumber.ToString(), currentPage < pageNumber));
        }
        rptPageNumber.DataSource = pages;
        rptPageNumber.DataBind();
    }

    public void PageChange_OnClick(object sender, EventArgs e)
    {
        LinkButton lnk = sender as LinkButton;
        lnk.ForeColor = System.Drawing.ColorTranslator.FromHtml("#5BB1E6");
        pageNumber = int.Parse((sender as LinkButton).CommandArgument);
        ViewState["PageNumber"] = pageNumber;

        BindGrid();
    }


    protected void gvBindQuestions_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView row1 = e.Row.DataItem as DataRowView;
            string sno = Convert.ToString(row1[1]);
            string Question = Convert.ToString(row1[2]);
            string TypeofDB = Convert.ToString(row1[3]);
            string Sellanguage = Convert.ToString(row1[4]);
            string QType = Convert.ToString(row1[5]);

            Label lbl = (Label)e.Row.FindControl("lblTextQuestion");
            Image img = (Image)e.Row.FindControl("imgQuestion");

            if (TypeofDB == "Access")
            {
                if (QType == "2")
                {
                    img.Visible = true;
                    lbl.Visible = false;

                    img.ImageUrl = "~/SubAdmin/GetGridImageHandler.ashx?SNO1= " + sno + ", Question";
                }
                else if (QType == "1")
                {
                    string s = Convert.ToString(Question);
                    s = s.Replace("@011", "'");
                    lbl.Text = s;
                    lbl.Visible = true;
                    lbl.Font.Name = "Shivaji01";
                    lbl.Font.Size = 14;
                    img.Visible = false;
                }
                else if (QType == "3")
                {
                    string s = Convert.ToString(Question);
                    s = s.Replace("@011", "'");
                    lbl.Text = s;
                    lbl.Visible = true;
                    lbl.Font.Name = "Cambria Math";
                    lbl.Font.Size = 11;
                    img.Visible = false;
                }
                else if (QType == "0")
                {
                    string s = Convert.ToString(Question);
                    s = s.Replace("@011", "'");
                    lbl.Text = s;

                    lbl.Visible = true;
                    lbl.Font.Name = "Times New Roman";
                    lbl.Font.Size = 12;
                    img.Visible = false;
                }
            }
            else
            {
                if (Sellanguage == "Marathi")
                {
                    string s = Convert.ToString(Question);
                    s = s.Replace("@011", "'");
                    lbl.Text = s;
                    lbl.Visible = true;
                    lbl.Font.Name = "Shivaji01";
                    lbl.Font.Size = 14;
                    img.Visible = false;
                }
                else if (Sellanguage == "MarathiMangal")
                {
                    string s = Convert.ToString(Question);
                    s = s.Replace("@011", "'");
                    lbl.Text = s;
                    lbl.Visible = true;
                    lbl.Font.Name = "Cambria Math";
                    lbl.Font.Size = 11;
                    img.Visible = false;
                }
                else if (Sellanguage == "English")
                {
                    string s = Convert.ToString(Question);
                    s = s.Replace("@011", "'");
                    lbl.Text = s;

                    lbl.Visible = true;
                    lbl.Font.Name = "Times New Roman";
                    lbl.Font.Size = 12;
                    img.Visible = false;
                }
            }
        }
    }


    public string QType = "";
    public string TypeDB = "", lang = "";

    protected void btnStart_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddltextName.SelectedIndex == ddltextName.Items.Count - 1)
            {
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Test Name')", true);
                lblError.Text = "PLEASE CHOOSE ALL FIELDS..!!!";
            }
            else
            {
                string chapterID = "";
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
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Please Select Test Name')", true);
                    lblError.Text = "PLEASE CHOOSE ALL FIELDS..!!!";
                }
                else if (cmbSelectsubject.SelectedIndex == cmbSelectsubject.Items.Count - 1)
                {
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Please Select Subject Name')", true);
                    lblError.Text = "PLEASE CHOOSE ALL FIELDS..!!!";
                }

                //NEW BELOW PARAMETERS ADDED.
                //else if (ddlClass.SelectedItem.Text == "--Select--")
                //{
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Please Select Class Name')", true);
                //    lblError.Text = "PLEASE CHOOSE ALL FIELDS..!!!";
                //}
                else if (ddlTypeofExam.SelectedItem.Text == "--Select--")
                {
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Please Select Exam Name')", true);
                    lblError.Text = "PLEASE CHOOSE ALL FIELDS..!!!";
                }
                else if (ddlTypeofMaterial.SelectedItem.Text == "--Select--")
                {
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Please Select Material Name')", true);
                    lblError.Text = "PLEASE CHOOSE ALL FIELDS..!!!";
                }
                else if (ddlTypeofQues.SelectedItem.Text == "--Select--")
                {
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Please Select Question Name')", true);
                    lblError.Text = "PLEASE CHOOSE ALL FIELDS..!!!";
                }
                else if (ddlMedium.SelectedItem.Text == "--Select--")
                {
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Please Select Medium Name')", true);
                    lblError.Text = "PLEASE CHOOSE ALL FIELDS..!!!";
                }
                // END HERE

                else if (chapterID == "")
                {
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Please Select Chapter')", true);
                    lblError.Text = "PLEASE CHOOSE ALL FIELDS..!!!";
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
            DataSet ds = new DataSet();

            //testDefBAL.LoginId1 = Convert.ToString(Session["LoginId"]);  //use sp
            //testDefBAL.Test_ID1 = Convert.ToInt32(ddltextName.SelectedValue);

            // DataSet ds = testDefBAL.getAssignTestDetails(testDefBAL);

            //if (ds.Tables[0].Rows.Count >= 1)
            //{
            //TypeOFExam = Convert.ToString(ds.Tables[0].Rows[0]["TypeOFExam"]);
            //TypeofMaterial = Convert.ToString(ds.Tables[0].Rows[0]["TypeofMaterial"]);
            //Class_id = Convert.ToInt32(ds.Tables[0].Rows[0]["Class_id"]);
            //Subjectid = Convert.ToString(ds.Tables[0].Rows[0]["Subject_id"]);
            //MediumID = Convert.ToString(ds.Tables[0].Rows[0]["MediumID"]);

            TypeOFExam = ddlTypeofExam.SelectedValue;
            TypeofMaterial = ddlTypeofMaterial.SelectedItem.Text;
            Class_id = Convert.ToInt32(ddlClass.SelectedValue);
            Subjectid = cmbSelectsubject.SelectedValue;
            MediumID = ddlMedium.SelectedItem.Text;

            //Sql = "SELECT COUNT (*) FROM dbo.tblAssignExamChapter WHERE LoginId='" + Session["LoginId"] + "' and TestID=" + ddltextName.SelectedValue + " ";
            //ds = cc.ExecuteDataset(Sql);

            //if (ds.Tables[0].Rows.Count > 0)
            //{

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

            //string s11 = Convert.ToString(Session["TestID"]);

            string s11 = ddltextName.SelectedValue;

            try
            {
                Sql = " DROP VIEW tbll" + s11 + "";
                int i = cc.ExecuteNonQuery(Sql);
            }
            catch
            {
            }

            string role = Convert.ToString(Session["Role"]);
            if(role == "8" || role == "19")
            {
            if (Class_id == 1)
            {
                //Question_id
                Sql = " CREATE   VIEW tbll" + s11 + " AS  " +
                      " SELECT ROW_NUMBER() OVER( ORDER BY SNO DESC ) NewQID,  * " +
                      "    FROM " +
                      "   (SELECT * FROM dbo.tblQuestionAccess WHERE TypeOFExam=" + TypeOFExam + " AND (QuesVerify !='0' or QuesVerify is null) AND QuestionLevel=" + rdoLevelList1.SelectedValue + "  AND Subject_id =" + cmbSelectsubject.SelectedValue + " AND MediumID='" + ddlMedium.SelectedItem.Text + "' AND PublicationName ='" + ddlpublication.SelectedItem.Text + "'  )  AS MyResults ";
                if (chapterID != "")
                    Sql = " CREATE   VIEW tbll" + s11 + " AS  " +
                          " SELECT ROW_NUMBER() OVER( ORDER BY SNO DESC) NewQID,  * " +
                          "    FROM " +
                          "   (SELECT * FROM dbo.tblQuestionAccess WHERE  TypeOFExam=" + TypeOFExam + " AND (QuesVerify !='0' or QuesVerify is null) AND QuestionLevel=" + rdoLevelList1.SelectedValue + "  AND Subject_id =" + cmbSelectsubject.SelectedValue + " AND MediumID='" + ddlMedium.SelectedItem.Text + "' AND Topic_id in(" + chapterID + ") AND Chapter_id=" + ddlTopik.SelectedValue + " AND PublicationName ='" + ddlpublication.SelectedItem.Text + "' )  AS MyResults ";
            }
            else
            {
                Sql = " CREATE   VIEW tbll" + s11 + " AS  " +
                     " SELECT ROW_NUMBER() OVER( ORDER BY SNO DESC) NewQID,  * " +
                     "    FROM " +
                     "   (SELECT * FROM dbo.tblQuestionAccess WHERE  TypeOFExam=" + TypeOFExam + " AND (QuesVerify !='0' or QuesVerify is null) AND QuestionLevel=" + rdoLevelList1.SelectedValue + " AND Class_id=" + Class_id + " AND Subject_id =" + cmbSelectsubject.SelectedValue + " AND MediumID='" + ddlMedium.SelectedItem.Text + "' AND PublicationName ='" + ddlpublication.SelectedItem.Text + "'  )  AS MyResults ";
                if (chapterID != "")
                    Sql = " CREATE   VIEW tbll" + s11 + " AS  " +
                          " SELECT ROW_NUMBER() OVER( ORDER BY SNO DESC) NewQID,  * " +
                          "    FROM " +
                          "   (SELECT * FROM dbo.tblQuestionAccess WHERE  TypeOFExam=" + TypeOFExam + " AND (QuesVerify !='0' or QuesVerify is null) AND QuestionLevel=" + rdoLevelList1.SelectedValue + " AND Class_id=" + Class_id + " AND Subject_id =" + cmbSelectsubject.SelectedValue + " AND MediumID='" + ddlMedium.SelectedItem.Text + "' AND Topic_id in(" + chapterID + ") AND Chapter_id=" + ddlTopik.SelectedValue + " AND PublicationName ='" + ddlpublication.SelectedItem.Text + "')  AS MyResults ";
            }
            }
            else
            {
                   if (Class_id == 1)
            {
                //Question_id
                Sql = " CREATE   VIEW tbll" + s11 + " AS  " +
                      " SELECT ROW_NUMBER() OVER( ORDER BY SNO DESC ) NewQID,  * " +
                      "    FROM " +
                      "   (SELECT * FROM dbo.tblQuestionAccess WHERE TypeOFExam=" + TypeOFExam + " AND (QuesVerify !='0' or QuesVerify is null) AND QuestionLevel=" + rdoLevelList1.SelectedValue + "  AND Subject_id =" + cmbSelectsubject.SelectedValue + " AND MediumID='" + ddlMedium.SelectedItem.Text + "'   )  AS MyResults ";
                if (chapterID != "")
                    Sql = " CREATE   VIEW tbll" + s11 + " AS  " +
                          " SELECT ROW_NUMBER() OVER( ORDER BY SNO DESC) NewQID,  * " +
                          "    FROM " +
                          "   (SELECT * FROM dbo.tblQuestionAccess WHERE  TypeOFExam=" + TypeOFExam + " AND (QuesVerify !='0' or QuesVerify is null) AND QuestionLevel=" + rdoLevelList1.SelectedValue + "  AND Subject_id =" + cmbSelectsubject.SelectedValue + " AND MediumID='" + ddlMedium.SelectedItem.Text + "' AND Topic_id in(" + chapterID + ") and Chapter_id=" + ddlTopik.SelectedValue + ")  AS MyResults ";
            }
            else
            {
                Sql = " CREATE   VIEW tbll" + s11 + " AS  " +
                     " SELECT ROW_NUMBER() OVER( ORDER BY SNO DESC) NewQID,  * " +
                     "    FROM " +
                     "   (SELECT * FROM dbo.tblQuestionAccess WHERE  TypeOFExam=" + TypeOFExam + " AND (QuesVerify !='0' or QuesVerify is null) AND QuestionLevel=" + rdoLevelList1.SelectedValue + " AND Class_id=" + Class_id + " AND Subject_id =" + cmbSelectsubject.SelectedValue + " AND MediumID='" + ddlMedium.SelectedItem.Text + "'   )  AS MyResults ";
                if (chapterID != "")
                    Sql = " CREATE   VIEW tbll" + s11 + " AS  " +
                          " SELECT ROW_NUMBER() OVER( ORDER BY SNO DESC) NewQID,  * " +
                          "    FROM " +
                          "   (SELECT * FROM dbo.tblQuestionAccess WHERE  TypeOFExam=" + TypeOFExam + " AND (QuesVerify !='0' or QuesVerify is null) AND QuestionLevel=" + rdoLevelList1.SelectedValue + " AND Class_id=" + Class_id + " AND Subject_id =" + cmbSelectsubject.SelectedValue + " AND MediumID='" + ddlMedium.SelectedItem.Text + "' AND Topic_id in(" + chapterID + ") and Chapter_id="+ ddlTopik.SelectedValue +")  AS MyResults ";
            }
            }
                
               

            int k = cc.ExecuteNonQuery(Sql);

            ViewState["PageNumber"] = null;
            GetTotal();
            BindGrid();

            //}
            //else
            //{
            //    TypeOFExam = "";
            //    Class_id = 0;
            //    Subject_id = 0;
            //    Chapter_id = "";
            //    MultiView1.SetActiveView(View1);
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Assign Chapter or Subject to Test Name')", true);
            //}
            // }

        }
        catch
        {
            // Response.Write("<h4>" + ex.Message);
        }
    }

    protected void btnAddQuestion_Click(object sender, EventArgs e)
    {
        try
        {

            string vv = Convert.ToString(ddltextName.SelectedValue);
            string gvSNO = "";
            for (int i = 0; i < gvBindQuestions.Rows.Count; i++)
            {
                CheckBox chkbox = (CheckBox)gvBindQuestions.Rows[i].Cells[4].FindControl("chk1");

                if (chkbox != null)
                {
                    if (chkbox.Checked == true)
                    {
                        gvSNO += Convert.ToString(gvBindQuestions.DataKeys[i].Value) + ",";

                    }
                }
                chkbox.Checked = false;
            }

            if (gvSNO == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select atleast one Question  !!!')", true);
            }
            else
            {
                if (gvSNO != "")
                {
                    gvSNO = gvSNO.Substring(0, gvSNO.Length - 1);
                }

                int TotalQuetion = Convert.ToInt32(Session["TotalQuetion"]);
                int AddingQuestion = Convert.ToInt32(Session["AddingQuestion"]);

                if (TotalQuetion >= AddingQuestion && TotalQuetion != AddingQuestion)
                {
                    int ExamType = 0;
                    string QuestionIDSet = gvSNO;
                    DataSet ds = new DataSet();

                    //testDefBAL.Test_ID1 = Convert.ToInt32(ddltextName.SelectedValue);
                    //DataSet ds = testDefBAL.getLevelTestDef(testDefBAL);

                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //ExamType = Convert.ToInt32(ds.Tables[0].Rows[0]["TypeOFExam"]);

                    ExamType = Convert.ToInt32(ddlTypeofExam.SelectedValue);

                    string[] splitid = QuestionIDSet.Split(',');
                    if (splitid.Length > 0)
                    {
                        try
                        {
                            Sql = "DROP VIEW [tbl13" + Convert.ToString(Session["CompanyId"]) + "]";
                            cc.ExecuteNonQuery(Sql);
                        }
                        catch
                        {
                        }

                        Sql = "SELECT * FROM dbo.tblNoRepeatQues WHERE LoginId='" + Convert.ToString(Session["LoginId"]) + "'";
                        ds = cc.ExecuteDataset(Sql);

                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            string TestIDVal = "";
                            int n;
                            TestIDVal = " ' " + ds.Tables[0].Rows[0]["Test_ID"].ToString() + "'";

                            for (n = 1; n < ds.Tables[0].Rows.Count; n++)
                            {
                                TestIDVal += "," + "'" + Convert.ToString(ds.Tables[0].Rows[n]["Test_ID"]) + "'";
                            }

                            string[] splitTestIDVal = TestIDVal.Split(',');

                            Sql = " CREATE VIEW tbl13" + Convert.ToString(Session["CompanyId"]) + " AS  " +
                                  " SELECT ROW_NUMBER() OVER( ORDER BY SNO DESC ) NewQID,  * " +
                                  " FROM " +
                                  " (SELECT SNO,TestID FROM tbl5164 WHERE TestID IN (" + TestIDVal + ",'" + Convert.ToInt32(ddltextName.SelectedValue) + "' )) AS myWay "; //Convert.ToInt32(Session["TestID"])

                            cc.ExecuteNonQuery(Sql);
                        }

                        string already = string.Empty;

                        for (int i = 0; i < splitid.Length; i++)
                        {
                            string sno1 = string.Empty;

                            //  string selectSql = "SELECT [TestID] FROM [tbl5164] WHERE SNO="+ splitid[i] +" AND ";

                            try
                            {
                                Sql = "SELECT SNO,TestID FROM tbl13" + Convert.ToString(Session["CompanyId"]) + " WHERE SNO=" + splitid[i] + "";
                                sno1 = Convert.ToString(cc.ExecuteScalar(Sql));
                            }
                            catch
                            {

                            }
                            if (sno1 == "" || sno1 == null)

                            {
                                Sql = " INSERT INTO " + "tbl5164" +
                                      " SELECT  SNO,Question_id,Question,QType,Answer1,AType,Answer2,BType,Answer3,CType,Answer4,DType,OptionE,EType,OptionP,PType,OptionQ,QType1,OptionR,RType,OptionS,SType, " +
                                      " OptionT,TType,Passage,passageType,QuesWithImage,Q1Type,Qhint,hType,Correct_answer,QuestionLevel,MobileNo,SettingId,changeDate,Ischecked,TypeOFExam,TypeofQues,Class_id, " +
                                      " Subject_id,Chapter_id,Topic_id,QuesVerify,Suggestion,UploaderMoNo,UniqueId,DOUpload,LoginId,checkerLoginId,Test_ID,Image,MediumID,Sellanguage,userClass_id,userSubject_id, " +
                                      " userChapter_id,userTopic_id,userCompitativeExam,TypeofMaterial,TypeofDB,examQwener,flag,createdate,UploadFileName,Class_AdmVerify,Class_AdmSuggest,Class_AdmLogin,PublicationName, " +
                                      " '" + Convert.ToInt32(ddltextName.SelectedValue) + "','" + Convert.ToString(Session["Loginid"]) + "'	FROM tblQuestionAccess " +
                                      " WHERE  SNO = " + splitid[i] + " "; //Convert.ToInt32(Session["TestID"])

                                cc.ExecuteNonQuery(Sql);
                            }
                            else
                            {
                                already += ", " + sno1;

                                lblNoReQues.Text = already + " Already Exists !!!";
                            }
                        }

                        GetTotal();
                    }

                    //}

                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Sorry No Question Added !!!')", true);
                    //}
                }
                else
                {
                    GetTotal();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Sorry!!! You Can't Add More Than Total Question Count. !!!')", true);
                }
            }
        }
        catch
        {
        }
    }

    public void GetTotal()  // calculated Number of Question assign for level 1,2,3 and remaining Question
    {
        try
        {
            int DLevel1 = 0, DLevel2 = 0, DLevel3 = 0, Total = 0;// TypeOFExam = 0;
            int ALevel1 = 0, ALevel2 = 0, ALevel3 = 0, ATotal1 = 0;
            int RLevel1 = 0, RLevel2 = 0, RLevel3 = 0, RTotal1 = 0;

            testDefBAL.Test_ID1 = Convert.ToInt32(ddltextName.SelectedValue); //Convert.ToInt32(Session["testid"])
            DataSet ds = testDefBAL.getLevelTestDef(testDefBAL);

            if (ds.Tables[0].Rows.Count >= 1)
            {
                DLevel1 = Convert.ToInt32(ds.Tables[0].Rows[0]["DLevel1"]);
                DLevel2 = Convert.ToInt32(ds.Tables[0].Rows[0]["DLevel2"]);
                DLevel3 = Convert.ToInt32(ds.Tables[0].Rows[0]["DLevel3"]);
                TypeOFExam = Convert.ToInt32(ddlTypeofExam.SelectedValue); //Convert.ToInt32(ds.Tables[0].Rows[0]["TypeOFExam"]);

                //Convert.ToInt32(Session["TestID"])
                string SQl = " SELECT COUNT(QuestionLevel) AS L1  FROM tbl5164 WHERE QuestionLevel = 1 AND TestID='" + Convert.ToInt32(ddltextName.SelectedValue) + "' " +
                             " SELECT COUNT(QuestionLevel) AS L2  FROM tbl5164 WHERE QuestionLevel = 2 AND TestID='" + Convert.ToInt32(ddltextName.SelectedValue) + "' " +
                             " SELECT COUNT(QuestionLevel) AS L3  FROM tbl5164 WHERE QuestionLevel = 3 AND TestID='" + Convert.ToInt32(ddltextName.SelectedValue) + "' ";

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
        catch
        {
        }
    }

    protected void ddltextName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //loadSubject(ddltextName.SelectedValue);
    }

    private void loadSubject(string test)
    {
        if (ddltextName.SelectedItem.Text == "--Select--")
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
        //LoadChapter(cmbSelectsubject.SelectedValue);
    }

    //private void LoadChapter(string chapterid)
    //{
    //    string sql = "SELECT [TypeOFExam],[Class_id] FROM [tblTestDefinition] WHERE [Test_ID]='" + ddltextName.SelectedValue + "'";
    //    DataSet ds = cc.ExecuteDataset(sql);

    //    string TOE_id = Convert.ToString(ds.Tables[0].Rows[0]["TypeOFExam"]);
    //    string Cl_id = Convert.ToString(ds.Tables[0].Rows[0]["Class_id"]);

    //    string sqlQuery = " SELECT [ChapterID],[ChapterName] FROM [tblChapterANDTopicNames] WHERE [TypeofExamId]='" + TOE_id + "' AND [ClassID]='" + Cl_id + "' AND [SubjectID]='" + cmbSelectsubject.SelectedValue + "'";//and [ChapterID] IN(" + Id + ") ";
    //    DataSet dataset = cc.ExecuteDataset(sqlQuery);
    //    if (dataset.Tables[0].Rows.Count > 0)
    //    {
    //        string chaptername = Convert.ToString(dataset.Tables[0].Rows[0]["ChapterName"]);
    //        if (chaptername == "")
    //        {
    //            Sql = "select Name,ItemValueId from dbo.tblItemValue where ItemId=0 or ItemId=3"; //and ItemValueId in(" + Id + ")";
    //            dataset = cc.ExecuteDataset(Sql);

    //            ddlTopik.DataSource = dataset.Tables[0];
    //            ddlTopik.DataTextField = "Name";
    //            ddlTopik.DataValueField = "ItemValueId";
    //            ddlTopik.DataBind();
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
    //        Sql = "select Name,ItemValueId from dbo.tblItemValue where ItemId=0 or ItemId=3"; //and ItemValueId in(" + Id + ")";
    //        dataset = cc.ExecuteDataset(Sql);

    //        ddlTopik.DataSource = dataset.Tables[0];
    //        ddlTopik.DataTextField = "Name";
    //        ddlTopik.DataValueField = "ItemValueId";
    //        ddlTopik.DataBind();
    //        //ChkSelectALL.Checked = false; 
    //        //ChkSelectALL.Visible = true;
    //    }


    //    //if (cmbSelectsubject.SelectedIndex == cmbSelectsubject.Items.Count - 1)
    //    //{
    //    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Suject.')", true);
    //    //    ChkSelectALL.Checked = false;
    //    //    ddlChapter.Items.Clear();
    //    //    ChkSelectALL.Visible = false;
    //    //}
    //    //else
    //    //{
    //    //    string SQl = "SELECT Chapter_id FROM dbo.tblAssignExamChapter WHERE Subject_id=" + SubjectID + " AND TestID=" + ddltextName.SelectedValue + "";
    //    //    string Id = Convert.ToString(cc.ExecuteScalar(SQl));
    //    //    if (Id == "")
    //    //    {
    //    //        ddlChapter.Items.Clear();
    //    //        ChkSelectALL.Visible = false;
    //    //    }
    //    //    else
    //    //    {
    //    //        Sql = "SELECT Name,ItemValueId FROM dbo.tblItemValue WHERE ItemId = 3 AND ItemValueId IN (" + Id + ")";
    //    //        DataSet ds = cc.ExecuteDataset(Sql);
    //    //        if (ds.Tables[0].Rows.Count > 0)
    //    //        {
    //    //            ddlChapter.DataSource = ds.Tables[0];
    //    //            ddlChapter.DataTextField = "Name";
    //    //            ddlChapter.DataValueField = "ItemValueId";
    //    //            ddlChapter.DataBind();
    //    //            ChkSelectALL.Checked = false;
    //    //            ChkSelectALL.Visible = true;
    //    //        }
    //    //    }
    //    //}
    //}

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
        }
    }

    public void loadSubject()
    {
        //Sql = "SELECT Name,ItemValueId FROM dbo.tblItemValue WHERE ItemId = 0 OR ItemId = 2";
        Sql = "SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId = 0 OR ItemId = 204 OR ItemId = 2 ORDER BY ItemValueId ASC";
        DataSet ds = cc.ExecuteDataset(Sql);
        cmbSelectsubject.DataSource = ds.Tables[0];
        cmbSelectsubject.DataTextField = "Name";
        cmbSelectsubject.DataValueField = "ItemValueId";
        cmbSelectsubject.DataBind();
    }
    public void loadChapter()
    {
        Sql = "SELECT Name,ItemValueId FROM dbo.tblItemValue WHERE ItemId = 4";
        DataSet ds = cc.ExecuteDataset(Sql);
        ddlChapter.DataSource = ds.Tables[0];
        ddlChapter.DataTextField = "Name";
        ddlChapter.DataValueField = "ItemValueId";
        ddlChapter.DataBind();
        ChkSelectALL.Checked = false;
        ChkSelectALL.Visible = true;
    }
    public void loadTopic()
    {
        Sql = "SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId = 0 OR ItemId = 3 ";
        DataSet ds = cc.ExecuteDataset(Sql);
        ddlTopik.DataSource = ds.Tables[0];
        ddlTopik.DataTextField = "Name";
        ddlTopik.DataValueField = "ItemValueId";
        ddlTopik.DataBind();
    }

    public void LoadClass()
    {
        Sql = "SELECT Name,ItemValueId FROM dbo.tblItemValue WHERE ItemId = 0 OR ItemId = 1";
        DataSet ds = cc.ExecuteDataset(Sql);
        ddlClass.DataSource = ds.Tables[0];
        ddlClass.DataTextField = "Name";
        ddlClass.DataValueField = "ItemValueId";
        ddlClass.DataBind();
    }

    public void LoadTypeofQues()
    {
        Sql = "SELECT Name,ItemValueId FROM dbo.tblItemValue WHERE ItemId = 0 OR ItemId = 5";
        DataSet ds = cc.ExecuteDataset(Sql);
        ddlTypeofQues.DataSource = ds.Tables[0];
        ddlTypeofQues.DataTextField = "Name";
        ddlTypeofQues.DataValueField = "ItemValueId";
        ddlTypeofQues.DataBind();
    }

    public void LoadTypeofExams()
    {
        Sql = "SELECT Name,ItemValueId FROM dbo.tblItemValue WHERE ItemId = 0 OR ItemId = 6";
        DataSet ds = cc.ExecuteDataset(Sql);
        ddlTypeofExam.DataSource = ds.Tables[0];
        ddlTypeofExam.DataTextField = "Name";
        ddlTypeofExam.DataValueField = "ItemValueId";
        ddlTypeofExam.DataBind();
    }

    protected void gvBindQuestions_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBindQuestions.PageIndex = e.NewPageIndex;
        BindGrid();
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

    protected void btnBack1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
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
    protected void btnNoReapetQues_Click(object sender, EventArgs e)
    {
    }
    //#region To Give topic name
    //public void LoadTopic(string topicid)
    //{
    //    string sql = "SELECT [TypeOFExam],[Class_id] FROM [tblTestDefinition] WHERE [Test_ID]='" + ddltextName.SelectedValue + "'";
    //    DataSet ds = cc.ExecuteDataset(sql);

    //    string TOE_id = Convert.ToString(ds.Tables[0].Rows[0]["TypeOFExam"]);
    //    string Cl_id = Convert.ToString(ds.Tables[0].Rows[0]["Class_id"]);

    //    string Sql = " SELECT [TopicID],[TopicName] FROM [tblChapterANDTopicNames] WHERE [SubjectID]='" + cmbSelectsubject.SelectedValue + "'  AND [ChapterID]='" + ddlTopik.SelectedValue + "' AND [TypeofExamId]='" + TOE_id + "' AND [ClassID]='" + Cl_id + "' "; //AND [Medium]='" + ddlMedium.SelectedItem.Text + "' AND [PublicationName]='" + ddlpublication.SelectedItem.Text + "'
    //    DataSet dataset = cc.ExecuteDataset(Sql);
    //    if (dataset.Tables[0].Rows.Count > 0)
    //    {
    //        string topicname = Convert.ToString(dataset.Tables[0].Rows[0]["TopicName"]);
    //        if (topicname == "")
    //        {
    //            Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE  [ItemId] = 4 ";
    //            dataset = cc.ExecuteDataset(Sql);

    //            ddlChapter.DataSource = dataset.Tables[0];
    //            ddlChapter.DataTextField = "Name";
    //            ddlChapter.DataValueField = "ItemValueId";
    //            ddlChapter.DataBind();

    //            ChkSelectALL.Visible = true;
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
    //        Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE  [ItemId] = 4 ";
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
    }
}