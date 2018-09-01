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
using System.Collections.Generic;

public partial class Admin_DisplayQues : System.Web.UI.Page
{


    CommonCode cc = new CommonCode();
    CommanDDLbindclass Cds = new CommanDDLbindclass();

    AssignQuestionInExamBAL assignQuestioninexamBal = new AssignQuestionInExamBAL();

    public static string Chapter_id = "";
    public static int TypeOFExam = 0;
    public static int Class_id = 0;
    public static int Subject_id = 0;


    DataSet dsStatic = null;
    DataSet dsItemValue = null;

    string Sql = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MultiView1.ActiveViewIndex = 0;
            //ItemValueDS();
            //QuesNo();
            rdoQuesVerify.SelectedIndex = 0;

            //   loadTypeofExam();
            Cds.loadGroupofExam(ddlGroupofExam);
            //Sql = "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=8 ";
            //DataSet ds = cc.ExecuteDataset(Sql);

            //ddlGroupofExam.DataSource = ds.Tables[0];
            //ddlGroupofExam.DataTextField = "Name";
            //ddlGroupofExam.DataValueField = "ItemValueId";
            //ddlGroupofExam.DataBind();
        }

    }

    public void loadTypeofExam()
    {
        Sql = "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=6  ";
        Sql = Sql + "select Name,ItemValueId from tblItemValue where ItemId=0 or ItemId=1";
        Sql = Sql + "select Name,ItemValueId from tblItemValue where ItemId =0 or ItemId=2";


        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueId";
            ddlTypeofExam.DataBind();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            ddlAddClass.DataSource = ds.Tables[1];
            ddlAddClass.DataTextField = "Name";
            ddlAddClass.DataValueField = "ItemValueId";
            ddlAddClass.DataBind();
        }

        if (ds.Tables[2].Rows.Count > 0)
        {
            cmbSelectsubject.DataSource = ds.Tables[2];
            cmbSelectsubject.DataTextField = "Name";
            cmbSelectsubject.DataValueField = "ItemValueId";
            cmbSelectsubject.DataBind();
        }
    }

    protected void btnStart_Click1(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
        QuesNo();
    }


    public void QuesNo()
    {
        try
        {
            string chapterID = "";
            for (int c = 0; c < ddlChapter.Items.Count; c++)
            {
                if (ddlChapter.Items[c].Selected == true)
                {
                    chapterID = chapterID + ddlChapter.Items[c].Value + ",";

                }
            }
            if (chapterID != "")
                chapterID = chapterID.Substring(0, chapterID.Length - 1);

            if (chapterID != "")
            {

                if (rdoTypeofMaterial.SelectedItem.Text == "Competitive Exam")
                {
                    Sql = "select * from dbo.tblAssignChapter where AssignUserName='" + Session["LoginId"] + "' and TypeofMaterial='" + rdoTypeofMaterial.SelectedItem.Text + "' and TypeOFExam=" + ddlTypeofExam.SelectedValue + " and Subject_id=" + cmbSelectsubject.SelectedValue + " ";
                }
                else
                {
                    Sql = "select * from dbo.tblAssignChapter where AssignUserName='" + Session["LoginId"] + "' and TypeofMaterial='" + rdoTypeofMaterial.SelectedItem.Text + "' and Class_id=" + ddlAddClass.SelectedValue + " and Subject_id=" + cmbSelectsubject.SelectedValue + " ";
                }
                DataSet ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    TypeOFExam = Convert.ToInt32(ds.Tables[0].Rows[0]["TypeOFExam"]);
                    Class_id = Convert.ToInt32(ds.Tables[0].Rows[0]["Class_id"]);
                    Subject_id = Convert.ToInt32(ds.Tables[0].Rows[0]["Subject_id"]);
                    Chapter_id = Convert.ToString(ds.Tables[0].Rows[0]["Chapter_id"]); // for assign chapter only but not in used

                    try
                    {
                        Sql = " drop view tbl" + Session["LoginId"] + "";
                        int i = cc.ExecuteNonQuery(Sql);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<h4>" + ex.Message);
                    }

                    // all chapter //Question_id
                    Sql = " CREATE   view tbl" + Session["LoginId"] + " as  " +
                         " Select ROW_NUMBER() OVER( ORDER BY SNO DESC ) NewQID,  * " +
                         "    from " +
                         "   (select * from dbo.tblQuestionAccess where  TypeOFExam=" + TypeOFExam + " and (QuesVerify !='0' or QuesVerify is null) and  Class_id=" + Class_id + " and MediumID='" + (ddlMedium.SelectedItem.Text) + "'  and Subject_id=" + Subject_id + " )  as MyResults ";


                    if (chapterID != "")
                        Sql = " CREATE   view tbl" + Session["LoginId"] + " as  " +
                          " Select ROW_NUMBER() OVER( ORDER BY SNO DESC) NewQID,  * " +
                          "    from " +
                          "   (select * from dbo.tblQuestionAccess where  TypeOFExam=" + TypeOFExam + " and (QuesVerify !='0' or QuesVerify is null) and  Class_id=" + Class_id + " and Subject_id=" + Subject_id + " and MediumID='" + (ddlMedium.SelectedItem.Text) + "' and Chapter_id='" + ddlTopik.SelectedValue + "' and  [Topic_id]  in (" + chapterID + ") )  as MyResults "; // by ram Topic & Chapter Name Wise display Question (Topic_id = Chapter_id vice versa)
                    int k = cc.ExecuteNonQuery(Sql);


                    Sql = "select count(*) from tbl" + Session["LoginId"] + " ";
                    string tempcount = cc.ExecuteScalar(Sql);

                    lblcount.Text = "Total Number of Question : " + tempcount;

                    if (tempcount == "0")
                    {
                        Sql = " drop view tbl" + Session["LoginId"] + "";
                        int i = cc.ExecuteNonQuery(Sql);

                        Sql = " CREATE   view tbl" + Session["LoginId"] + " as  " +
                         " Select ROW_NUMBER() OVER( ORDER BY SNO DESC) NewQID,  * " +
                         "    from " +
                         "   (select * from dbo.tblQuestionAccess where  TypeOFExam=" + TypeOFExam + " and (QuesVerify !='0' or QuesVerify is null) and  Class_id=" + Class_id + " and Subject_id=" + Subject_id + " and MediumID='" + (ddlMedium.SelectedItem.Text) + "' and Chapter_id='" + ddlTopik.SelectedValue + "' and  [Topic_id]  in ('1','2','3','4','5') )  as MyResults "; // by ram Topic & Chapter Name Wise display Question (Topic_id = Chapter_id vice versa)
                        int k1 = cc.ExecuteNonQuery(Sql);


                        Sql = "select count(*) from tbl" + Session["LoginId"] + " ";
                        string tempcount1 = cc.ExecuteScalar(Sql);

                        lblcount.Text = "Total Number of Question : " + tempcount1;

                        string s11 = Convert.ToString(Session["LoginId"]);
                        string viewtblName = "tbl" + s11 + " ";
                        assignQuestioninexamBal.ViewtblName1 = viewtblName;

                        assignQuestioninexamBal.NewQID1 = 1;

                        dsStatic = assignQuestioninexamBal.SelectQuestionAssignVIEW(assignQuestioninexamBal);
                    }
                    else
                    {
                        string s11 = Convert.ToString(Session["LoginId"]);
                        string viewtblName = "tbl" + s11 + " ";
                        assignQuestioninexamBal.ViewtblName1 = viewtblName;

                        assignQuestioninexamBal.NewQID1 = 1;

                        dsStatic = assignQuestioninexamBal.SelectQuestionAssignVIEW(assignQuestioninexamBal);
                    }




                    if (dsStatic.Tables[0].Rows.Count == 0)
                    {
                        MultiView1.SetActiveView(View1);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('No Question found for this combination  Please select next Chapter ')", true);
                    }
                    else
                    {
                        fetchCommonData(dsStatic.Tables[0].Rows[0]);
                    }
                }
                else
                {
                    TypeOFExam = 0;
                    Class_id = 0;
                    Subject_id = 0;
                    Chapter_id = "";
                    MultiView1.SetActiveView(View1);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select proper Type of Materials,Subject which is assign you')", true);

                }
            }
            else
            {
                MultiView1.SetActiveView(View1);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select chapter !!!')", true);

            }
        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
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

            else if ((hType == "0") || (hType == "1"))
            {
                string Sql = "update dbo.tblQuestionAccess set QuestionLevel=" + rdoLevelList.SelectedValue + " , Correct_answer='" + txtAns.Text + "',Qhint='" + txtHint.Text + "' ,hType='" + ddlhint.SelectedValue + "',Suggestion='" + txtSuggest.Text + "',QuesVerify='" + rdoQuesVerify.SelectedValue + "',checkerLoginId='" + Session["LoginId"] + "' where  SNo='" + lblSno.Text + "'  ";
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
                string Sql = "update dbo.tblQuestionAccess set QuestionLevel=" + rdoLevelList.SelectedValue + " , Correct_answer='" + txtAns.Text + "' ,Suggestion='" + txtSuggest.Text + "',QuesVerify='" + rdoQuesVerify.SelectedValue + "',checkerLoginId='" + Session["LoginId"] + "' where   SNo='" + lblSno.Text + "'  ";
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
            Response.Write("<h4>" + ex.Message);
        }
    }


    public void collectAnswer()
    {
        TypeofQues = lblTypeofQuesID.Text;
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

            string s11 = Convert.ToString(Session["LoginId"]);
            string viewtblName = "tbl" + s11 + " ";

            assignQuestioninexamBal.ViewtblName1 = viewtblName;
            assignQuestioninexamBal.NewQID1 = NewQID;
            dsStatic = assignQuestioninexamBal.SelectQuestionAssignVIEW(assignQuestioninexamBal);
            fetchCommonData(dsStatic.Tables[0].Rows[0]);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry! You Can Not Go Back')", true);
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        int NewQID = Convert.ToInt32(lblQNo.Text);
        int asdhjgahjsghj = Convert.ToInt32((lblcount.Text.Split(':')[1]));
        if (NewQID < Convert.ToInt32((lblcount.Text.Split(':')[1])))
        {

            ddlhint.SelectedIndex = 0;
            NewQID = Convert.ToInt32(lblQNo.Text);
            NewQID = NewQID + 1;

            string s11 = Convert.ToString(Session["LoginId"]);
            string viewtblName = "tbl" + s11 + " ";
            assignQuestioninexamBal.ViewtblName1 = viewtblName;
            assignQuestioninexamBal.NewQID1 = NewQID;
            dsStatic = assignQuestioninexamBal.SelectQuestionAssignVIEW(assignQuestioninexamBal);
            fetchCommonData(dsStatic.Tables[0].Rows[0]);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry! You Can Not Go Next')", true);
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


            txtSuggest.Text = Convert.ToString(row["Suggestion"]);
            string QuesVerify = Convert.ToString(row["QuesVerify"]);

            rdoQuesVerify.SelectedIndex = 0;
            if (QuesVerify == "1")
                rdoQuesVerify.SelectedIndex = 1;



            int QId = Convert.ToInt32(row["Question_id"]);

            int NewQID = Convert.ToInt32(row["NewQID"]);
            lblQNo.Text = Convert.ToString(NewQID);

            lblQuestion_id.Text = Convert.ToString(QId);
            lblSno.Text = Convert.ToString(row["SNO"]);
            lblMasterID.Text = "Master ID : " + lblSno.Text;

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
            if (level == "1")
                rdoLevelList.SelectedIndex = 0;
            if (level == "2")
                rdoLevelList.SelectedIndex = 1;
            if (level == "3")
                rdoLevelList.SelectedIndex = 2;

            TypeofQues = Convert.ToString(row["TypeofQues"]);
            lblTypeofQuesID.Text = TypeofQues;
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
                //lblQuestion.Font.Name = "Mangal";
                lblQuestion.Font.Size = 11;


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
                imgoptA.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Answer1," + loginId + "";


            }

            if (BType == "0")
            {
                string s = Convert.ToString(row["Answer2"]);
                s = s.Replace("@011", "'");
                lblOptB.Text = s;


                //lblOptB.Text = Convert.ToString(row["Answer2"]);
                //lblOptB.Text.Replace("@011", "'");
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

                //lblOptB.Text = Convert.ToString(row["Answer2"]);
                //lblOptB.Text.Replace("@011", "'");
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

                //lblOptB.Text = Convert.ToString(row["Answer2"]);
                //lblOptB.Text.Replace("@011", "'");
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
                imgoptB.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Answer2," + loginId + "";
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
                imgoptC.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Answer3," + loginId + "";
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
                imgoptD.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Answer4," + loginId + "";
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
                imgoptE.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",OptionE," + loginId + "";
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
                lblOptP.Font.Name = "Cambria Math";
                lblOptP.Font.Size = 11;
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
                lblOptQ.Font.Name = "Cambria Math";
                lblOptQ.Font.Size = 11;
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
                lblOptR.Font.Size = 11;
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
                lblOptS.Font.Size = 11;
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
                lblOptT.Font.Size = 11;
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
                lblPassage.Font.Size = 11;
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
                lblQuestionwithImage.Font.Size = 11;
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
                // ddlhint.SelectedIndex = Convert.ToInt32(hType);
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
                    imgHint.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Qhint," + loginId + "";
                    imgHint2.ImageUrl = "~/LongHintImageHandler.ashx?para=" + NewQID + ",Qhint," + loginId + "";

                    imgHint2.Visible = true;
                    txtHint.Visible = false;
                    imgHint.Visible = true;
                    lblH.Visible = true;
                    ddlhint.Visible = false;
                }
                else
                {
                    imgHint.ImageUrl = "~/LongHintImageHandler.ashx?para=" + NewQID + ",Qhint," + loginId + "";
                    imgHint2.Visible = false;
                    txtHint.Visible = false;
                    imgHint.Visible = true;
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
            txtHint.Font.Size = 11;
        }
        else if (ddlhint.SelectedIndex == 1)
        {
            txtHint.Font.Name = "Shivaji01";
            txtHint.Font.Size = 14;
        }
        else if (ddlhint.SelectedIndex == 3)
        {
            txtHint.Font.Name = "Cambria Math";
            txtHint.Font.Size = 12;
        }
    }

    protected void btnUpdateHint_Click(object sender, EventArgs e)
    {
        Sql = "update tblQuestionAccess set hType='2' where Qhint Like '/9j%'";

        int flag = cc.ExecuteNonQuery(Sql);

        if (flag == 0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Hint Updation Failed!!!')", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Hint Updated Successfully!!!')", true);
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

    protected void rdoTypeofMaterial_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoTypeofMaterial.SelectedIndex == 0)
        {
            Label11.Visible = true;
            Label10.Visible = false;
            RequiredFieldValidator8.Enabled = true;
            RequiredFieldValidator11.Enabled = false;
        }
        else
        {
            Label11.Visible = false;
            Label10.Visible = true;
            RequiredFieldValidator8.Enabled = false;
            RequiredFieldValidator11.Enabled = true;
        }
    }

    protected void chkAnslist_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlAddClass.SelectedIndex = 0;
        ddlMedium.SelectedIndex = 0;
        ddlTypeofExam.SelectedIndex = 0;
        cmbSelectsubject.SelectedIndex = 0;
        rdoTypeofMaterial.ClearSelection();
        ChkSelectALL.Checked = false;

        foreach (ListItem li in ddlChapter.Items)
        {
            li.Selected = false;
        }
    }
    //#region To display chapter namewise
    //public void LoadChapter()
    //{
    //        string sqlQuery = " SELECT [ChapterID],[ChapterName] FROM [tblChapterANDTopicNames] WHERE [TypeofExamId]='" + ddlTypeofExam.SelectedValue + "' AND [ClassID]='" + ddlAddClass.SelectedValue + "' AND [SubjectID]='" + cmbSelectsubject.SelectedValue + "'"; //and [ChapterID] IN(" + Id + ") ";
    //        DataSet dataset = cc.ExecuteDataset(sqlQuery);
    //        if (dataset.Tables[0].Rows.Count > 0)
    //        {
    //            ddlTopik.DataSource = dataset.Tables[0];  //ddlChapter
    //            ddlTopik.DataTextField = "ChapterName";
    //            ddlTopik.DataValueField = "ChapterID";
    //            ddlTopik.DataBind();
    //            ddlTopik.Items.Add("--Select--");
    //            ddlTopik.SelectedIndex = ddlTopik.Items.Count - 1;
    //           // ChkSelectALL.Visible = true;
    //        }
    //        else
    //        {
    //            Sql = "select Name,ItemValueId from dbo.tblItemValue where ItemId=0 or ItemId=3"; //and ItemValueId in(" + Id + ")";
    //            dataset = cc.ExecuteDataset(Sql);

    //            ddlTopik.DataSource = dataset.Tables[0];
    //            ddlTopik.DataTextField = "Name";
    //            ddlTopik.DataValueField = "ItemValueId";
    //            ddlTopik.DataBind();
    //           // ChkSelectALL.Checked = false; 
    //            //ChkSelectALL.Visible = true;
    //        }
    //}
    //#endregion
    protected void cmbSelectsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        // LoadChapter();
        Cds.GetChapterNames(ddlTopik, ddlTypeofExam, ddlAddClass, cmbSelectsubject);

        //if (rdoTypeofMaterial.SelectedItem.Text == "Competitive Exam")
        //{
        //    Sql = "select Chapter_id from dbo.tblAssignChapter where AssignUserName='" + Session["LoginId"] + "' and TypeofMaterial='" + rdoTypeofMaterial.SelectedItem.Text + "' and TypeOFExam=" + ddlTypeofExam.SelectedValue + " and Subject_id=" + cmbSelectsubject.SelectedValue + " ";

        //    //Sql = "select Chapter_id from dbo.tblAssignChapter where TypeofMaterial='" + rdoTypeofMaterial.SelectedItem.Text + "' and TypeOFExam=" + ddlTypeofExam.SelectedValue + " and Subject_id=" + cmbSelectsubject.SelectedValue + " and Class_id=" + ddlAddClass.SelectedValue + " ";
        //}
        //else
        //{
        //    Sql = "select Chapter_id from dbo.tblAssignChapter where AssignUserName='" + Session["LoginId"] + "' and TypeofMaterial='" + rdoTypeofMaterial.SelectedItem.Text + "' and Class_id=" + ddlAddClass.SelectedValue + " and Subject_id=" + cmbSelectsubject.SelectedValue + " ";
        //}
        //DataSet ds = cc.ExecuteDataset(Sql);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    Chapter_id = Convert.ToString(ds.Tables[0].Rows[0]["Chapter_id"]); // for assign chapter only display bind ,

        //    Sql = "select Name,ItemValueId from tblItemValue where ItemId=3 and ItemValueId in('" + Chapter_id + "')"; //loadChapter
        //    ds = cc.ExecuteDataset(Sql);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        ddlChapter.Items.Clear();
        //        ddlChapter.DataSource = ds.Tables[0];
        //        ddlChapter.DataTextField = "Name";
        //        ddlChapter.DataValueField = "ItemValueId";
        //        ddlChapter.DataBind();

        //        ChkSelectALL.Checked = false;
        //        ChkSelectALL.Visible = true;
        //    }
        //    else
        //    {

        //    }
        //}
        //else
        //{
        //    ChkSelectALL.Visible = false;
        //    ddlChapter.Items.Clear();
        //    cmbSelectsubject.SelectedIndex = 0;
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select proper Type of Materials,Subject which is assign you')", true);
        //}
    }

    protected void btnGotoQues_Click(object sender, EventArgs e)
    {
        try
        {
            int NewQID = Convert.ToInt32(txtGotoQues.Text);

            if (NewQID < Convert.ToInt32((lblcount.Text.Split(':')[1])))
            {
                string s11 = Convert.ToString(Session["LoginId"]);
                string viewtblName = "tbl" + s11 + " ";
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
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
    }

    #region ddlGroupofExam

    //protected void binddropdown212()
    //{
    //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=212 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlTypeofExam.DataSource = ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //protected void BindDropDown213()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 213 ";
    //    DataSet DS = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = DS.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //protected void BindDropDown214()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 214 ";
    //    DataSet DS = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = DS.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown273()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 273 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown274()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 274 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown275()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 275 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown276()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 276 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown277()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 277 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown278()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 278 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown279()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 445 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    protected void ddlGroupofExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        string groupExamid = ddlGroupofExam.SelectedValue;
        Cds.BindTypeofExamOnGroup(ddlTypeofExam, groupExamid);
        //if (ddlGroupofExam.SelectedValue == Convert.ToString(135))
        //{
        //    binddropdown212();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(136))
        //{
        //    BindDropDown213();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(137))
        //{
        //    BindDropDown214();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(140))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=210  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(141))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=207  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(142))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=206  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(143))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=203  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(144))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=205  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(177))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=1796  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(178))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=1806  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(231))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=2310  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(232))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=2310  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(233))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=2310  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(257))
        //{
        //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 257";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(273))
        //{
        //    binddropdown273();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(274))
        //{
        //    binddropdown274();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(275))
        //{
        //    binddropdown275();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(276))
        //{
        //    binddropdown276();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(277))
        //{
        //    binddropdown277();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(278))
        //{
        //    binddropdown278();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(445))
        //{
        //    binddropdown279();
        //}
    }
    #endregion

    #region ddlTypeofExam

    //protected void binddropdwn211()
    //{
    //    ddlAddClass.Enabled = true;
    //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=211 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlAddClass.DataSource = ds.Tables[0];
    //    ddlAddClass.DataTextField = "Name";
    //    ddlAddClass.DataValueField = "ItemValueIdNew";
    //    ddlAddClass.DataBind();
    //}

    //protected void bindropdown2()
    //{
    //    Sql = Sql + "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=2 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    cmbSelectsubject.DataSource = ds.Tables[0];
    //    cmbSelectsubject.DataTextField = "Name";
    //    cmbSelectsubject.DataValueField = "ItemValueId";
    //    cmbSelectsubject.DataBind();
    //    ddlAddClass.SelectedValue = "1";
    //    ddlAddClass.Enabled = false;
    //}

    //protected void binddropdown202()
    //{
    //    ddlAddClass.Enabled = true;
    //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=202 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlAddClass.DataSource = ds.Tables[0];
    //    ddlAddClass.DataTextField = "Name";
    //    ddlAddClass.DataValueField = "ItemValueIdNew";
    //    ddlAddClass.DataBind();
    //}
    //protected void binddropdown201()
    //{
    //    ddlAddClass.Enabled = true;
    //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=201 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlAddClass.DataSource = ds.Tables[0];
    //    ddlAddClass.DataTextField = "Name";
    //    ddlAddClass.DataValueField = "ItemValueIdNew";
    //    ddlAddClass.DataBind();
    //}

    protected void ddlTypeofExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        string classORSubject = ddlTypeofExam.SelectedValue;
        Cds.BindClassOrSubject(ddlAddClass, classORSubject, cmbSelectsubject);
        //if (ddlTypeofExam.SelectedValue == Convert.ToString(88))
        //{
        //    binddropdown201();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(271))
        //{
        //    binddropdown201();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(272))
        //{
        //    binddropdown201();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(98))
        //{
        //    binddropdown202();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(99))
        //{
        //    binddropdown202();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(100))
        //{
        //    binddropdown202();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(96))
        //{
        //    binddropdwn211();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(101))
        //{
        //    binddropdwn211();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(102))
        //{
        //    binddropdwn211();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(89))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(94))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(95))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(130))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(110))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=204 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    cmbSelectsubject.DataSource = ds.Tables[0];
        //    cmbSelectsubject.DataTextField = "Name";
        //    cmbSelectsubject.DataValueField = "ItemValueIdNew";
        //    cmbSelectsubject.DataBind();
        //}

        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(103))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(165))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(179))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(180))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(176))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(184))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(185))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(191))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(193))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(200) || ddlTypeofExam.SelectedValue == Convert.ToString(201) || ddlTypeofExam.SelectedValue == Convert.ToString(202) || ddlTypeofExam.SelectedValue == Convert.ToString(203) || ddlTypeofExam.SelectedValue == Convert.ToString(204) || ddlTypeofExam.SelectedValue == Convert.ToString(205) || ddlTypeofExam.SelectedValue == Convert.ToString(206) || ddlTypeofExam.SelectedValue == Convert.ToString(207))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(217))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(224))
        //{
        //    ddlAddClass.Enabled = true;
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=201 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlAddClass.DataSource = ds.Tables[0];
        //    ddlAddClass.DataTextField = "Name";
        //    ddlAddClass.DataValueField = "ItemValueIdNew";
        //    ddlAddClass.DataBind();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(227))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(228))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(229))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(230))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(234))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(235))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(236))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(237))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(248))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(254))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(258) || ddlTypeofExam.SelectedValue == Convert.ToString(259) || ddlTypeofExam.SelectedValue == Convert.ToString(260) || ddlTypeofExam.SelectedValue == Convert.ToString(261) || ddlTypeofExam.SelectedValue == Convert.ToString(262) || ddlTypeofExam.SelectedValue == Convert.ToString(263) || ddlTypeofExam.SelectedValue == Convert.ToString(264) || ddlTypeofExam.SelectedValue == Convert.ToString(265))
        //{
        //    binddropdown201();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(266) || ddlTypeofExam.SelectedValue == Convert.ToString(267) || ddlTypeofExam.SelectedValue == Convert.ToString(268) || ddlTypeofExam.SelectedValue == Convert.ToString(269) || ddlTypeofExam.SelectedValue == Convert.ToString(270))
        //{
        //    binddropdown201();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(446) || ddlTypeofExam.SelectedValue == Convert.ToString(447) || ddlTypeofExam.SelectedValue == Convert.ToString(448) || ddlTypeofExam.SelectedValue == Convert.ToString(449))
        //{
        //    bindropdown2();
        //}
    }

    #endregion

    #region ddlAddClass

    protected void ddlAddClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        string addClassIDNew = ddlAddClass.SelectedValue;
        Cds.BindAddSubjectOnClassId(cmbSelectsubject, addClassIDNew, ddlTypeofExam);
        //for (int count = 0; count < 15; count++)
        //{
        //    if (ddlAddClass.SelectedValue == Convert.ToString(count))
        //    {
        //        Sql = Sql + "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=2 ";
        //        DataSet ds = cc.ExecuteDataset(Sql);

        //        cmbSelectsubject.DataSource = ds.Tables[0];
        //        cmbSelectsubject.DataTextField = "Name";
        //        cmbSelectsubject.DataValueField = "ItemValueId";
        //        cmbSelectsubject.DataBind();

        //    }
        //}

        //if ((ddlAddClass.SelectedValue == Convert.ToString(15) || ddlAddClass.SelectedValue == Convert.ToString(16)) && ddlTypeofExam.SelectedValue == Convert.ToString(99))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where ItemIdNew=0 or ItemIdNew=209 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    cmbSelectsubject.DataSource = ds.Tables[0];
        //    cmbSelectsubject.DataTextField = "Name";
        //    cmbSelectsubject.DataValueField = "ItemValueIdNew";
        //    cmbSelectsubject.DataBind();
        //}

        //else if ((ddlAddClass.SelectedValue == Convert.ToString(15) || ddlAddClass.SelectedValue == Convert.ToString(16)) && (ddlTypeofExam.SelectedValue == Convert.ToString(98) || ddlTypeofExam.SelectedValue == Convert.ToString(100)))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where ItemIdNew=0 or  ItemIdNew=208 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    cmbSelectsubject.DataSource = ds.Tables[0];
        //    cmbSelectsubject.DataTextField = "Name";
        //    cmbSelectsubject.DataValueField = "ItemValueIdNew";
        //    cmbSelectsubject.DataBind();
        //}
        //else if (ddlAddClass.SelectedValue == Convert.ToString(188) || ddlAddClass.SelectedValue == Convert.ToString(189))
        //{
        //    Sql = Sql + "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=2 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    cmbSelectsubject.DataSource = ds.Tables[0];
        //    cmbSelectsubject.DataTextField = "Name";
        //    cmbSelectsubject.DataValueField = "ItemValueId";
        //    cmbSelectsubject.DataBind();

        //}
    }
    #endregion

    protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    //#region To display Topic namewise
    //public void LoadTopic()
    //{
    //    string Sql = " SELECT [TopicID],[TopicName] FROM [tblChapterANDTopicNames] WHERE [TypeofExamId]='" + ddlTypeofExam.SelectedValue + "' AND [ClassID]='" + ddlAddClass.SelectedValue + "' AND [SubjectID]='" + cmbSelectsubject.SelectedValue + "'  AND [ChapterID]='" + ddlTopik.SelectedValue + "' "; 
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

    //            ChkSelectALL.Checked = false;
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
    //        Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 4 ";
    //        dataset = cc.ExecuteDataset(Sql);

    //        ddlChapter.DataSource = dataset.Tables[0];
    //        ddlChapter.DataTextField = "Name";
    //        ddlChapter.DataValueField = "ItemValueId";
    //        ddlChapter.DataBind();

    //        ChkSelectALL.Checked = false;
    //        ChkSelectALL.Visible = true;
    //    }



    //}
    //#endregion
    protected void ddlTopik_SelectedIndexChanged(object sender, EventArgs e)
    {
        //LoadTopic();
        Cds.GetToipcName(ddlChapter, ChkSelectALL, ddlTypeofExam, ddlAddClass, cmbSelectsubject, ddlTopik);
    }
}