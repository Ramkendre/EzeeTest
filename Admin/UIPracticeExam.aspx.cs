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

public partial class Admin_UIPracticeExam : System.Web.UI.Page
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

    string Sql = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MultiView1.ActiveViewIndex = 0;
            rdoQuesVerify.SelectedIndex = 0;
            loadTestName();
            //  loadTypeofExam();
            // loadClass();
            // loadSubject();
            //loadChapter();
        }

        //  this.Set_Page_Level_Setting();

    }

    protected void Set_Page_Level_Setting()
    {
        //set page heading
        Label lblMainHeading = (Label)Master.FindControl("lblMainHeading");
        if (lblMainHeading != null)
            lblMainHeading.Text = " Add Question for Exam";
    }

    public void loadTestName()
    {
        Sql = "select Test_ID,Exam_name from tblTestDefinition where LoginId ='" + Convert.ToString(Session["LoginId"]) + "' ";
        DataSet ds = cc.ExecuteDataset(Sql);
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

    public void loadTypeofExam()
    {
        Sql = "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=6  ";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //ddlTypeofExam.DataSource = ds.Tables[0];
            //ddlTypeofExam.DataTextField = "Name";
            //ddlTypeofExam.DataValueField = "ItemValueId";
            //ddlTypeofExam.DataBind();
        }
    }
    public void loadClass()
    {
        Sql = "select Name,ItemValueId from tblItemValue where ItemId=0 or ItemId=1";
        DataSet ds = cc.ExecuteDataset(Sql);
        //ddlAddClass.DataSource = ds.Tables[0];
        //ddlAddClass.DataTextField = "Name";
        //ddlAddClass.DataValueField = "ItemValueId";
        //ddlAddClass.DataBind();
    }
    public void loadSubject()
    {
        Sql = "select Name,ItemValueId from tblItemValue where ItemId =0 or ItemId=2";
        DataSet ds = cc.ExecuteDataset(Sql);
        cmbSelectsubject.DataSource = ds.Tables[0];
        cmbSelectsubject.DataTextField = "Name";
        cmbSelectsubject.DataValueField = "ItemValueId";
        cmbSelectsubject.DataBind();
    }
    public void loadChapter()
    {
        Sql = "select Name,ItemValueId from tblItemValue where ItemId=3";
        DataSet ds = cc.ExecuteDataset(Sql);
        ddlChapter.DataSource = ds.Tables[0];
        ddlChapter.DataTextField = "Name";
        ddlChapter.DataValueField = "ItemValueId";
        ddlChapter.DataBind();

    }

    protected void btnStart_Click1(object sender, EventArgs e)
    {
        try
        {
            string chapterID = "", chapterName = ""; ;
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
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Question Level')", true);

            }
            else
            {
                MultiView1.SetActiveView(View2);
                QuesNo();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //public void ItemValueDS()
    //{
    //    try
    //    {
    //        string Sql = "select Name,ItemValueId from tblItemValue";
    //        dsItemValue = cc.ExecuteDataset(Sql);
    //    }
    //    catch (Exception ex)
    //    { throw ex; }
    //}

    public void QuesNo()
    {
        try
        {
            string TypeOFExam = "", TypeofMaterial = "";
            string SQL = "  select TypeOFExam,TypeofMaterial,Class_id ,Subject_id from [tblTestDefinition] where LoginId='" + Session["LoginId"] + "' and Test_ID=" + ddltextName.SelectedValue + " ";
            DataSet ds = cc.ExecuteDataset(SQL);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                TypeOFExam = Convert.ToString(ds.Tables[0].Rows[0]["TypeOFExam"]);
                TypeofMaterial = Convert.ToString(ds.Tables[0].Rows[0]["TypeofMaterial"]);
                Class_id = Convert.ToInt32(ds.Tables[0].Rows[0]["Class_id"]);
                Subjectid = Convert.ToString(ds.Tables[0].Rows[0]["Subject_id"]);

                Sql = "select * from tblAssignExamChapter where LoginId='" + Session["LoginId"] + "' and TestID=" + ddltextName.SelectedValue + " ";
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




                    //if (Chapter_id == "1")
                    //{
                    //    try
                    //    {
                    //        Sql = " drop view " + Session["LoginId"] + "";
                    //        int i = cc.ExecuteNonQuery(Sql);
                    //    }
                    //    catch
                    //    {
                    //    }
                    //    Sql = " CREATE   view " + Session["LoginId"] + " as  " +
                    //          " Select ROW_NUMBER() OVER( ORDER BY Question_id) NewQID,  * " +
                    //          "    from " +
                    //          "   (select * from tblQuestionAccess where  TypeOFExam=" + TypeOFExam + " and QuestionLevel=" + rdoLevelList1.SelectedValue + " and Class_id=" + Class_id + " and Subject_id in (" + Subjectid + " ) )  as MyResults ";
                    //    int k = cc.ExecuteNonQuery(Sql);
                    //}
                    //else
                    //{
                    try
                    {
                        Sql = " drop view " + Session["LoginId"] + "";
                        int i = cc.ExecuteNonQuery(Sql);
                    }
                    catch
                    {
                    }
                    Sql = " CREATE   view " + Session["LoginId"] + " as  " +
                          " Select ROW_NUMBER() OVER( ORDER BY Question_id) NewQID,  * " +
                          "    from " +
                          "   (select * from tblQuestionAccess where  TypeOFExam=" + TypeOFExam + " and QuestionLevel=" + rdoLevelList1.SelectedValue + " and Class_id=" + Class_id + " and Subject_id in (" + Subjectid + " ) and Chapter_id in(" + chapterID + ") )  as MyResults ";
                    int k = cc.ExecuteNonQuery(Sql);
                    // }



                    string sql = "select * from " + Session["LoginId"] + "";
                    dsStatic = cc.ExecuteDataset(sql);

                    if (dsStatic.Tables[0].Rows.Count == 0)
                    {
                        MultiView1.SetActiveView(View1);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('No Question found for this combination ')", true);

                    }
                    else
                    {
                        fetchCommonData(dsStatic.Tables[0].Rows[0]);
                    }
                    lblcount.Text = "Total Available Question No. : " + Convert.ToInt32(dsStatic.Tables[0].Rows.Count);

                }
                else
                {
                    TypeOFExam = "";
                    Class_id = 0;
                    Subject_id = 0;
                    Chapter_id = "";
                    MultiView1.SetActiveView(View1);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select proper Type of Materials,Subject which is assign you')", true);

                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            collectAnswer();
            if (txtAns.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('please select Answer')", true);
            }
            //else if ((hType == "0" && hintDB!="")||(hType == "1" && hintDB!=""))
            else if ((hType == "0") || (hType == "1"))
            {
                string Sql = "update tblQuestionAccess set QuestionLevel=" + rdoLevelList.SelectedValue + " , Correct_answer='" + txtAns.Text + "',Qhint='" + txtHint.Text + "' ,hType='" + ddlhint.SelectedValue + "',Suggestion='" + txtSuggest.Text + "',QuesVerify='" + rdoQuesVerify.SelectedValue + "',checkerLoginId='" + Session["LoginId"] + "' where  SNo='" + lblSno.Text + "'  ";
                int flag = cc.ExecuteNonQuery(Sql);
                if (flag == 1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Your Question is Updated')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Your Question is Not Updated')", true);
                }
            }
            else
            {
                string Sql = "update tblQuestionAccess set QuestionLevel=" + rdoLevelList.SelectedValue + " , Correct_answer='" + txtAns.Text + "' ,Suggestion='" + txtSuggest.Text + "',QuesVerify='" + rdoQuesVerify.SelectedValue + "',checkerLoginId='" + Session["LoginId"] + "' where   SNo='" + lblSno.Text + "'  ";
                int flag = cc.ExecuteNonQuery(Sql);
                if (flag == 1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Your Question is Updated')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Your Question is Not Updated')", true);
                }
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select answer and Question level')", true);

        }
    }


    public void collectAnswer()
    {

        if (TypeofQues == "80" || TypeofQues == "86" || TypeofQues == "82")
        {
            txtAns.Text = "";
            if (rdoAnswerlist.SelectedValue == "0")
                txtAns.Text = "A";
            if (rdoAnswerlist.SelectedValue == "1")
                txtAns.Text = "B";
            if (rdoAnswerlist.SelectedValue == "2")
                txtAns.Text = "C";
            if (rdoAnswerlist.SelectedValue == "3")
                txtAns.Text = "D";
            if (rdoAnswerlist.SelectedValue == "4")
                txtAns.Text = "E";
        }
        else if (TypeofQues == "93" || TypeofQues == "84")
        {
            txtAns.Text = txtAns.Text;
        }
        else if (TypeofQues == "83") // Multiple correct ans.
        {
            txtAns.Text = "";
            if (chkAnslist.Items[0].Selected == true)
                txtAns.Text = "A,";
            if (chkAnslist.Items[1].Selected == true)
                txtAns.Text += "B,";
            if (chkAnslist.Items[2].Selected == true)
                txtAns.Text += "C,";
            if (chkAnslist.Items[3].Selected == true)
                txtAns.Text += "D,";
            if (chkAnslist.Items[4].Selected == true)
                txtAns.Text += "E,";

            txtAns.Text = txtAns.Text.Substring(0, txtAns.Text.Length - 1);
        }
        else if (TypeofQues == "87") // matrix type Question 
        {
            txtAns.Text = "";
            if (ChkansMatA.Items[0].Selected == true)
                txtAnsMatA.Text = "P,";
            if (ChkansMatA.Items[1].Selected == true)
                txtAnsMatA.Text += "Q,";
            if (ChkansMatA.Items[2].Selected == true)
                txtAnsMatA.Text += "R,";
            if (ChkansMatA.Items[3].Selected == true)
                txtAnsMatA.Text += "S,";
            if (ChkansMatA.Items[4].Selected == true)
                txtAnsMatA.Text += "T,";

            if (ChkansMatB.Items[0].Selected == true)
                txtAnsMatB.Text = "P,";
            if (ChkansMatB.Items[1].Selected == true)
                txtAnsMatB.Text += "Q,";
            if (ChkansMatB.Items[2].Selected == true)
                txtAnsMatB.Text += "R,";
            if (ChkansMatB.Items[3].Selected == true)
                txtAnsMatB.Text += "S,";
            if (ChkansMatB.Items[4].Selected == true)
                txtAnsMatB.Text += "T,";


            if (ChkansMatC.Items[0].Selected == true)
                txtAnsMatC.Text = "P,";
            if (ChkansMatC.Items[1].Selected == true)
                txtAnsMatC.Text += "Q,";
            if (ChkansMatC.Items[2].Selected == true)
                txtAnsMatC.Text += "R,";
            if (ChkansMatC.Items[3].Selected == true)
                txtAnsMatC.Text += "S,";
            if (ChkansMatC.Items[4].Selected == true)
                txtAnsMatC.Text += "T,";

            if (ChkansMatD.Items[0].Selected == true)
                txtAnsMatD.Text = "P,";
            if (ChkansMatD.Items[1].Selected == true)
                txtAnsMatD.Text += "Q,";
            if (ChkansMatD.Items[2].Selected == true)
                txtAnsMatD.Text += "R,";
            if (ChkansMatD.Items[3].Selected == true)
                txtAnsMatD.Text += "S,";
            if (ChkansMatD.Items[4].Selected == true)
                txtAnsMatD.Text += "T,";
            //remove comma in last 
            txtAnsMatA.Text = txtAnsMatA.Text.Substring(0, txtAnsMatA.Text.Length - 1);
            txtAnsMatB.Text = txtAnsMatB.Text.Substring(0, txtAnsMatB.Text.Length - 1);
            txtAnsMatC.Text = txtAnsMatC.Text.Substring(0, txtAnsMatC.Text.Length - 1);
            if (txtAnsMatD.Text != "")
                txtAnsMatD.Text = txtAnsMatD.Text.Substring(0, txtAnsMatD.Text.Length - 1);

            //combine 4 textbox ans.
            txtAns.Text = "A-" + txtAnsMatA.Text + "*" + "B-" + txtAnsMatB.Text + "*" + "C-" + txtAnsMatC.Text + "*" + "D-" + txtAnsMatD.Text;

        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {


        int NewQID = Convert.ToInt32(lblQNo.Text);
        if (NewQID > 1)
        {
            NewQID = NewQID - 1;
            ddlhint.SelectedIndex = 0;
            //string sql = "select * from " + Session["LoginId"] + " where SettingId in(select ID from tblSettings where TypeOFExam=" + TypeOFExam + " and  Class_id=" + Class_id + " and Subject_id=" + Subject_id + " and Chapter_id in(" + Chapter_id + ")) and NewQID<=" + NewQID + " order by NewQID DESC ";
            //DataSet ds1 = cc.ExecuteDataset(sql);
            string sql = "select * from " + Session["LoginId"] + "";
            dsStatic = cc.ExecuteDataset(sql);
            DataRow[] dr = dsStatic.Tables[0].Select("NewQID<=" + NewQID, "NewQID desc");
            if (dr.Length > 0)
            {
                fetchCommonData(dr[0]);

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
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry you can not go Back Question')", true);
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        // chkAddQuestion.Checked = false;

        ddlhint.SelectedIndex = 0;
        int NewQID = Convert.ToInt32(lblQNo.Text);
        NewQID = NewQID + 1;

        // string Sql = "select * from tblQuestionAccess where SettingId in(select ID from tblSettings where TypeOFExam=" + TypeOFExam + " and  Class_id=" + Class_id + " and Subject_id=" + Subject_id + " and Chapter_id in(" + Chapter_id + ")) and Question_id>=" + NewQID + " order by Question_id ";
        //string sql = "select * from " + Session["LoginId"] + " where SettingId in(select ID from tblSettings where TypeOFExam=" + TypeOFExam + " and  Class_id=" + Class_id + " and Subject_id=" + Subject_id + " and Chapter_id in(" + Chapter_id + ")) and NewQID>=" + NewQID + " order by NewQID ";
        //DataSet ds1 = cc.ExecuteDataset(sql);
        string sql = "select * from " + Session["LoginId"] + "";
        dsStatic = cc.ExecuteDataset(sql);
        DataRow[] dr = dsStatic.Tables[0].Select("NewQID>=" + NewQID);
        if (dr.Length > 0)
        {
            fetchCommonData(dr[0]);

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

        clearcontrol();

        if (row.ItemArray.Count() > 0)
        {

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


            string level = Convert.ToString(row["QuestionLevel"]);
            if (level == "1")
                rdoLevelList.SelectedIndex = 0;
            if (level == "2")
                rdoLevelList.SelectedIndex = 1;
            if (level == "3")
                rdoLevelList.SelectedIndex = 2;

            TypeofQues = Convert.ToString(row["TypeofQues"]);

            string Sql = "select Name,ItemValueId from tblItemValue";
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
                lblQuestion.Text = Convert.ToString(row["Question"]);
                lblQuestion.Visible = true;
                lblQuestion.Font.Name = "Times New Roman";
                lblQuestion.Font.Size = 9;
                imgQues.Visible = false;
            }
            else if (QType == "1")
            {
                lblQuestion.Text = Convert.ToString(row["Question"]);
                lblQuestion.Visible = true;
                lblQuestion.Font.Name = "Shivaji01";
                lblQuestion.Font.Size = 12;
                imgQues.Visible = false;
            }
            else
            {
                lblQuestion.Visible = false;
                imgQues.Visible = true;
                imgQues.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Question," + loginId + "";
            }


            if (AType == "0")
            {
                lblOptA.Text = Convert.ToString(row["Answer1"]);
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
                lblOptA.Font.Size = 9;
            }
            else if (AType == "1")
            {
                lblOptA.Text = Convert.ToString(row["Answer1"]);
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
                lblOptA.Font.Size = 12;
            }
            else
            {
                lblOptA.Visible = false;
                imgoptA.Visible = true;
                lblA.Visible = true;
                imgoptA.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Answer1," + loginId + "";


            }

            if (BType == "0")
            {
                lblOptB.Text = Convert.ToString(row["Answer2"]);
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
                lblOptB.Font.Size = 9;
            }
            else if (BType == "1")
            {
                lblOptB.Text = Convert.ToString(row["Answer2"]);
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
                lblOptB.Font.Size = 12;
            }
            else
            {
                imgoptB.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Answer2," + loginId + "";
                lblOptB.Visible = false;
                imgoptB.Visible = true;
                lblB.Visible = true;
            }

            if (CType == "0")
            {
                lblOptC.Text = Convert.ToString(row["Answer3"]);
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
                lblOptC.Font.Size = 9;
            }
            else if (CType == "1")
            {
                lblOptC.Text = Convert.ToString(row["Answer3"]);
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
                lblOptC.Font.Size = 12;
            }
            else
            {
                imgoptC.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Answer3," + loginId + "";
                lblOptC.Visible = false;
                imgoptC.Visible = true;
                lblC.Visible = true;
            }


            if (DType == "0")
            {
                lblOptD.Text = Convert.ToString(row["Answer4"]);

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
                lblOptD.Font.Size = 9;
            }
            else if (DType == "1")
            {
                lblOptD.Text = Convert.ToString(row["Answer4"]);

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
                lblOptD.Font.Size = 12;
            }
            else
            {
                imgoptD.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Answer4," + loginId + "";
                lblOptD.Visible = false;
                imgoptD.Visible = true;
                lblD.Visible = true;
            }

            if (EType == "0")
            {
                lblOptE.Text = Convert.ToString(row["OptionE"]);

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
                lblOptE.Font.Size = 9;
            }
            else if (EType == "1")
            {
                lblOptE.Text = Convert.ToString(row["OptionE"]);

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
                lblOptD.Font.Name = "Shivaji01";
                lblOptD.Font.Size = 12;
            }

            else
            {
                imgoptE.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",OptionE," + loginId + "";
                lblOptE.Visible = false;
                imgoptE.Visible = true;
                lblE.Visible = true;
                lblE.Visible = true;
            }


            if (PType == "0")
            {
                lblOptP.Text = Convert.ToString(row["OptionP"]);

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
                lblOptP.Font.Size = 9;
            }
            else if (PType == "1")
            {
                lblOptP.Text = Convert.ToString(row["OptionP"]);

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
                lblOptP.Font.Size = 12;
            }
            else
            {
                imgoptP.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",OptionP," + loginId + "";
                lblOptP.Visible = false;
                imgoptP.Visible = true;
                lblP.Visible = true;
            }

            if (QType1 == "0")
            {
                lblOptQ.Text = Convert.ToString(row["OptionQ"]);
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
                lblOptQ.Font.Size = 9;
            }
            else if (QType1 == "1")
            {
                lblOptQ.Text = Convert.ToString(row["OptionQ"]);
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
                lblOptQ.Font.Size = 12;
            }
            else
            {
                imgoptQ.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",OptionQ," + loginId + "";
                lblOptQ.Visible = false;
                imgoptQ.Visible = true;
                lblQ.Visible = true;
            }

            if (RType == "0")
            {
                lblOptR.Text = Convert.ToString(row["OptionR"]);
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
                lblOptR.Font.Size = 9;
            }
            else if (RType == "1")
            {
                lblOptR.Text = Convert.ToString(row["OptionR"]);
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
                lblOptR.Font.Size = 12;
            }
            else
            {
                imgoptR.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",OptionR," + loginId + "";
                lblOptR.Visible = false;
                imgoptR.Visible = true;
                lblR.Visible = true;
            }

            if (SType == "0")
            {
                lblOptS.Text = Convert.ToString(row["OptionS"]);
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
                lblOptS.Font.Size = 9;
            }
            else if (SType == "1")
            {
                lblOptS.Text = Convert.ToString(row["OptionS"]);
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
                lblOptS.Font.Size = 12;
            }
            else
            {
                imgoptS.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",OptionS," + loginId + "";
                lblOptS.Visible = false;
                imgoptS.Visible = true;
                lblS.Visible = true;
            }

            if (TType == "0")
            {
                lblOptT.Text = Convert.ToString(row["OptionT"]);
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
                lblOptT.Font.Size = 9;
            }
            else if (TType == "1")
            {
                lblOptT.Text = Convert.ToString(row["OptionT"]);
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
                lblOptT.Font.Size = 12;
            }
            else
            {
                imgoptT.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",OptionT," + loginId + "";
                lblOptT.Visible = false;
                imgoptT.Visible = true;
                lblT.Visible = true;
            }

            if (passageType == "0")
            {
                lblPassage.Text = Convert.ToString(row["Passage"]);
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
                lblPassage.Font.Size = 9;

            }
            else if (passageType == "1")
            {
                lblPassage.Text = Convert.ToString(row["Passage"]);
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
                lblPassage.Font.Size = 12;
            }
            else
            {
                imgPassage.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Passage," + loginId + "";
                lblPassage.Visible = false;
                imgPassage.Visible = true;
                lblpassage1.Visible = true;
            }

            if (Q1Type == "0")
            {
                lblQuestionwithImage.Text = Convert.ToString(row["QuesWithImage"]);
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
                lblQuestionwithImage.Font.Size = 9;
            }
            else if (Q1Type == "1")
            {
                lblQuestionwithImage.Text = Convert.ToString(row["QuesWithImage"]);
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
                lblQuestionwithImage.Font.Size = 12;
            }
            else
            {
                lblQuestionwithImage.Text = Convert.ToString(row["QuesWithImage"]);
                if (lblQuestionwithImage.Text != "")
                {
                    imgQuesImage.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",QuesWithImage," + loginId + "";
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
                txtHint.Text = Convert.ToString(row["Qhint"]);
                hintDB = Convert.ToString(row["Qhint"]);
                ddlhint.SelectedIndex = Convert.ToInt32(hType);
                txtHint.Font.Name = "Times New Roman";
                txtHint.Font.Size = 9;
                imgHint.Visible = false;
                txtHint.Visible = true;
                lblH.Visible = true;
                ddlhint.Visible = true;

            }
            else if (hType == "1")
            {
                txtHint.Text = Convert.ToString(row["Qhint"]);
                hintDB = Convert.ToString(row["Qhint"]);
                ddlhint.SelectedIndex = Convert.ToInt32(hType);
                txtHint.Font.Name = "Shivaji01";
                txtHint.Font.Size = 12;
                imgHint.Visible = false;

                txtHint.Visible = true;
                lblH.Visible = true;
                ddlhint.Visible = true;

            }
            else
            {
                imgHint.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Qhint," + loginId + "";
                txtHint.Visible = false;
                imgHint.Visible = true;
                lblH.Visible = true;
                ddlhint.Visible = false;
            }

            txtSuggest.Text = Convert.ToString(row["Suggestion"]);

        }

    }


    protected void ddlhint_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlhint.SelectedIndex == 0)
        {
            txtHint.Font.Name = "Times New Roman";
            txtHint.Font.Size = 9;
        }
        else
        {
            txtHint.Font.Name = "Shivaji01";
            txtHint.Font.Size = 12;
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }


    string QuestionID;
    protected void chkAddQuestion_CheckedChanged(object sender, EventArgs e)
    {

        Session["QuestionID"] = Session["QuestionID"] + lblSno.Text + ",";

        string s1 = Convert.ToString(Session["QuestionID"]);


    }

    protected void btnSubmit_Click(object sender, EventArgs e)
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
                string SQl = "select  DLevel1 , DLevel2 , DLevel3 ,TypeOFExam from tblTestDefinition where Test_ID=" + ddltextName.SelectedValue + "";
                DataSet ds = cc.ExecuteDataset(SQl);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    ExamType = Convert.ToInt32(ds.Tables[0].Rows[0]["TypeOFExam"]);
                    if (ExamType == 103)
                    {
                        Sql = "insert into tblMahatetExamQuestionSet " +
                       " SELECT  * FROM tblQuestionAccess " +
                       " where  SNO not in ( select SNo from tblMahatetExamQuestionSet) and sno in (" + QuestionIDSet + ")";

                        status = cc.ExecuteNonQuery(Sql);
                        if (status >= 1)
                        {
                            GetTotal();
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert(' " + status + " Question Added Successfully')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert(' selected Question Already Exit.')", true);

                        }
                    }
                    else
                    {
                        string s11 = "tbl" + Convert.ToString(Session["LoginId"]);
                        try
                        {
                            Sql = "select * from  " + s11 + " ";
                            status = cc.ExecuteNonQuery(Sql);
                        }
                        catch (Exception ex)
                        {

                        }
                        if (status != -1)
                        {
                            string queryString =
                                                @"
                CREATE TABLE MyTable
                (
                    [EQID] [int] IDENTITY(1,1) NOT NULL,
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
                 CONSTRAINT [PK_MyTable] PRIMARY KEY CLUSTERED 
                (
	                [EQID] ASC
                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                ) ON [PRIMARY]
                ";

                            queryString = queryString.Replace("MyTable", s11);

                            status = cc.ExecuteNonQuery(queryString);
                            if (status == -1)
                            {
                                Sql = "insert into " + s11 + " " +
                            " SELECT  * FROM tblQuestionAccess " +
                            " where  SNO not in ( select SNo from " + s11 + " ) and sno in (" + QuestionIDSet + ")";

                                status = cc.ExecuteNonQuery(Sql);

                            }
                        }
                        else
                        {
                            Sql = "insert into " + s11 + " " +
                             " SELECT  * FROM tblQuestionAccess " +
                             " where  SNO not in ( select SNo from " + s11 + " ) and sno in (" + QuestionIDSet + ")";

                            status = cc.ExecuteNonQuery(Sql);
                            if (status >= 1)
                            {
                                GetTotal();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert(' selected Question Already Exit.')", true);

                            }
                        }
                    }


                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert(' " + status + " Question Added Successfully')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry No Question Added !!!')", true);
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry You not Select any Question !!!')", true);
            }
        }
        else
        {
            GetTotal();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry You not Add More Than Total Question Count. !!!')", true);

        }
    }
    protected void ddltextName_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadSubject(ddltextName.SelectedValue);
    }
    private void loadSubject(string test)
    {
        if (ddltextName.SelectedIndex == ddltextName.Items.Count - 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Exam Name')", true);

        }
        else
        {
            string SQl = "select Subject_id from tblTestDefinition where Test_ID=" + test + "";
            string Id = Convert.ToString(cc.ExecuteScalar(SQl));
            string Sql = "select Name,ItemValueId from tblItemValue where ItemId=2 and ItemValueId in(" + Id + ")";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbSelectsubject.DataSource = ds.Tables[0];
                cmbSelectsubject.DataTextField = "Name";
                cmbSelectsubject.DataValueField = "ItemValueId";
                cmbSelectsubject.DataBind();
                cmbSelectsubject.Items.Add("--Select--");
                cmbSelectsubject.SelectedIndex = cmbSelectsubject.Items.Count - 1;
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


        }
        else
        {
            string SQl = "select Chapter_id from tblAssignExamChapter where Subject_id=" + SubjectID + " and TestID=" + ddltextName.SelectedValue + "";
            string Id = Convert.ToString(cc.ExecuteScalar(SQl));
            string Sql = "select Name,ItemValueId from tblItemValue where ItemId=3 and ItemValueId in(" + Id + ")";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlChapter.DataSource = ds.Tables[0];
                ddlChapter.DataTextField = "Name";
                ddlChapter.DataValueField = "ItemValueId";
                ddlChapter.DataBind();

            }
        }
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

    public void GetTotal()
    {
        try
        {
            int DLevel1 = 0, DLevel2 = 0, DLevel3 = 0, Total = 0, TypeOFExam = 0;
            int ALevel1 = 0, ALevel2 = 0, ALevel3 = 0, ATotal1 = 0;
            int RLevel1 = 0, RLevel2 = 0, RLevel3 = 0, RTotal1 = 0;

            string SQl = "select  DLevel1 , DLevel2 , DLevel3 ,TypeOFExam from tblTestDefinition where Test_ID=" + Convert.ToString(Session["testid"]) + "";
            DataSet ds = cc.ExecuteDataset(SQl);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                DLevel1 = Convert.ToInt32(ds.Tables[0].Rows[0]["DLevel1"]);
                DLevel2 = Convert.ToInt32(ds.Tables[0].Rows[0]["DLevel2"]);
                DLevel3 = Convert.ToInt32(ds.Tables[0].Rows[0]["DLevel3"]);
                TypeOFExam = Convert.ToInt32(ds.Tables[0].Rows[0]["TypeOFExam"]);
                //lbl3.Text = "Total Level3 Question No." + DLevel3;
                if (TypeOFExam == 103)
                {
                    SQl = "Select count(QuestionLevel) as L1 from tblMahatetExamQuestionSet where QuestionLevel=1 " +
                     " Select count(QuestionLevel) as L2  from tblMahatetExamQuestionSet where QuestionLevel=2 " +
                     " Select count(QuestionLevel) as L3  from tblMahatetExamQuestionSet where QuestionLevel=3 ";

                    DataSet ds1 = cc.ExecuteDataset(SQl);
                    if (ds1.Tables[0].Rows.Count >= 1 || ds1.Tables[1].Rows.Count >= 1 || ds1.Tables[2].Rows.Count >= 1)
                    {
                        ALevel1 = Convert.ToInt32(ds1.Tables[0].Rows[0]["L1"]);
                        ALevel2 = Convert.ToInt32(ds1.Tables[1].Rows[0]["L2"]);
                        ALevel3 = Convert.ToInt32(ds1.Tables[2].Rows[0]["L3"]);
                    }
                }
                Total = DLevel1 + DLevel2 + DLevel3;
                ATotal1 = ALevel1 + ALevel2 + ALevel3;
                RLevel1 = DLevel1 - ALevel1;
                RLevel2 = DLevel2 - ALevel2;
                RLevel3 = DLevel3 - ALevel3;
                RTotal1 = RLevel1 + RLevel2 + RLevel3;
                Session["TotalQuetion"] = Total;
                Session["AddingQuestion"] = ATotal1;
                lblt1.Text = "Total Exam Question= " + Total;
                lblt1.Visible = true;
                lblt2.Text = "Total Exam Adding Question.= " + ATotal1;
                lblt2.Visible = true;
                lblt3.Text = "Total Exam Remaining Question= " + RTotal1;
                lblt3.Visible = true;


                pnl1.Visible = true;
                lblTotalQNo.Text = "Total Exam Question No.= " + Total + " (Level1 + Level2 + Level3 =" + DLevel1 + "+" + DLevel2 + "+" + DLevel3 + ")";
                lblAvailable.Text = "Total Exam Adding Question No. = " + ATotal1 + " (Level1 + Level2 + Level3 =" + ALevel1 + "+" + ALevel2 + "+" + ALevel3 + ")";
                lblRemaininhg.Text = "Total Exam Remaining Question No.= " + RTotal1 + " (Level1 + Level2 + Level3 =" + RLevel1 + "+" + RLevel2 + "+" + RLevel3 + ")";


            }
            else
            {
                pnl1.Visible = false;
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
