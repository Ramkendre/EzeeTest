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
using System.IO;
using System.Drawing;
using System.Web.Services;


public partial class SubAdmin_RSBhutadaNewPractice1 : System.Web.UI.Page
{

    string Sql;
    CommonCode cc = new CommonCode();
    NewPractice1BAL newpractice1bal = new NewPractice1BAL();
    string su, ch, le, cl, mat, exam, medium;
    int j = 0, k = 0;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        string combo = Convert.ToString(Request.QueryString["combo"]);
        string[] comboSplit = combo.Split('*');
        su = Convert.ToString(comboSplit[0]);
        ch = Convert.ToString(comboSplit[1]);
       // le = Convert.ToString(comboSplit[2]);
        mat = Convert.ToString(comboSplit[2]);
        exam = Convert.ToString(comboSplit[3]);
        cl = Convert.ToString(comboSplit[4]);
        medium = Convert.ToString(comboSplit[5]);

        if (!Page.IsPostBack)
        {

            getTotalQuesCount();
            QuesNo("1", "10", 0);

        }
    }

    int j1 = 0;



    public void getTotalQuesCount()
    {
        try
        {
            string TypeOFExam = "", TypeofMaterial = "";

            string Role = Convert.ToString(Session["Role"]);
            newpractice1bal.Chapter = ch;
            newpractice1bal.Class_id1 = cl;
            newpractice1bal.Usertype = Convert.ToString(Session["UserType"]);

            //  sp in(35,37) keyword set @material='''Competitive Exam''' 

            //mat = "'" + mat + "'";  // for in key in sql (37,39)  and  use for display 'Competitive Exam' in sql query set @material='''Competitive Exam''' 

            newpractice1bal.Material = mat;
            newpractice1bal.RoleID1 = Role;

            //newpractice1bal.Queslevel1 = le;
            newpractice1bal.Subjectid = su;
            newpractice1bal.Typeofexam = exam;
            newpractice1bal.Medium = medium;

            ds = newpractice1bal.getQuestionNewpracticeCountRSB(newpractice1bal);




            int count = Convert.ToInt32(ds.Tables[0].Rows.Count);
            lblcount.Text = "Total Available Question No. : " + count;
            // addcontrolrdo(count);  // display count in panel 

            if (ds.Tables[0].Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('No Question found for this combination ')", true);

            }


        }
        catch (Exception ex)
        {
            // Response.Write("<h4>ERROR :" + ex.Message);
        }
    }
    string username1;
    public void QuesNo(string RowFrom, string RowTo, int quesrounduptemp)
    {
        try
        {
            string TypeOFExam = "", TypeofMaterial = "";

            string Role = Convert.ToString(Session["Role"]);
            newpractice1bal.Chapter = ch;
            newpractice1bal.Class_id1 = cl;
            newpractice1bal.Usertype = Convert.ToString(Session["UserType"]);

            //  sp in(35,37) keyword set @material='''Competitive Exam''' 

            // mat = "'" + mat + "'";  // for in key in sql (37,39)  and  use for display 'Competitive Exam' in sql query set @material='''Competitive Exam''' 

            newpractice1bal.Material = mat;
            newpractice1bal.RoleID1 = Role;

          //  newpractice1bal.Queslevel1 = le;
            newpractice1bal.Subjectid = su;
            newpractice1bal.Typeofexam = exam;
            newpractice1bal.RowFrom = RowFrom;
            newpractice1bal.RowTo = RowTo;
            newpractice1bal.Medium = medium;

            ds = newpractice1bal.getQuestionNewpracticeRSB(newpractice1bal);
            int k = 1;

            buttonVisiblefalse();
            lbldsLastrowscount.Text = Convert.ToString(ds.Tables[0].Rows[(ds.Tables[0].Rows.Count - 1)]["ID"]);
            lbldsFirstrowscount.Text = Convert.ToString(ds.Tables[0].Rows[0]["ID"]);
            for (int j = 0; j < (ds.Tables[0].Rows.Count); j++)
            {

                string btn = "Button" + k;

                Button btnid = FindControl(btn) as Button;
                btnid.Text = Convert.ToString(ds.Tables[0].Rows[j]["ID"]);
                btnid.Visible = true;


                k++;

            }

            username1 = Convert.ToString(Session["LoginId"]);
            Cache.Remove(username1);
            if (Cache[username1] == null)
            {

                Cache[username1] = ds;

                Response.Cache.SetExpires(DateTime.Now.AddSeconds(6000));
                Response.Cache.SetCacheability(HttpCacheability.Public);


                // Cache["mytable"] = ds;
                dt = ds.Tables[0];
            }

            ////ViewState.Remove("mytable");
            ////    if (ViewState["mytable"] == null)
            ////    {

            ////        dt = ds.Tables[0];
            ////        ViewState["mytable"] = dt;
            ////    }
            ////    else
            ////    {
            ////        dt = (DataTable)ViewState["mytable"];
            ////    }

            int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

            if (quesrounduptemp == 0)
            {
                fetchCommonData(dt.Rows[0]);
            }
            else
            {
                fetchCommonData(dt.Rows[quesrounduptemp - 1]);
            }


        }
        catch (Exception ex)
        {
            // Response.Write("<h4>Error :" + ex.Message);
        }
    }




    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {

            int m = Convert.ToInt32(lblQNo.Text);
            int getrow = m % 10;
            if (getrow != 1)
            {
                DataSet ds2 = new DataSet();
                username1 = Convert.ToString(Session["LoginId"]);

                ds2 = (DataSet)Cache[username1];
                dt = ds2.Tables[0];
                ////dt = (DataTable)ViewState["mytable"];




                //Session["ckeckedIdset"] += "," + m;

                fetchCommonData(dt.Rows[getrow - 2]);

                // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You can not go to next Question ')", true);

            }
            else
            {
                int startrows = Convert.ToInt32(lbldsFirstrowscount.Text);
                if (startrows != 1)
                {
                    if (startrows > 9)
                    {
                        string rowFrom = Convert.ToString(startrows - 10);
                        string rowTo = Convert.ToString(startrows - 1);
                        QuesNo(rowFrom, rowTo, 0);
                    }
                    else
                    {
                        string rowFrom = Convert.ToString(1);
                        string rowTo = Convert.ToString(startrows - 1);
                        QuesNo(rowFrom, rowTo, 0);
                    }
                }

            }
        }
        catch (Exception ex)
        {
            // Response.Write("<h4>Error :" + ex.Message);
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            int m = Convert.ToInt32(lblQNo.Text);
            int getrow = m % 10;
            if (getrow != 0)
            {
                DataSet ds2 = new DataSet();
                username1 = Convert.ToString(Session["LoginId"]);

                ds2 = (DataSet)Cache[username1];
                dt = ds2.Tables[0];

                //// dt = (DataTable)ViewState["mytable"];




                //Session["ckeckedIdset"] += "," + m;

                fetchCommonData(dt.Rows[getrow]);

                // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You can not go to next Question ')", true);

            }
            else
            {
                int totalcount = Convert.ToInt32((lblcount.Text.Split(':'))[1]);


                int currentcount = Convert.ToInt32(lbldsLastrowscount.Text);
                if ((totalcount - currentcount) > 9)
                {
                    string rowFrom = Convert.ToString(currentcount + 1);
                    string rowTo = Convert.ToString(currentcount + 10);
                    QuesNo(rowFrom, rowTo, 0);
                }
            }
        }
        catch (Exception ex)
        {
            // Response.Write("<h4>Error :" + ex.Message);
        }
    }

    string userAns, userAns1, userAns2, userAns3;
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int i2 = Convert.ToInt32(lblQNo.Text);
            //  RadioButton rdo = new RadioButton();
            TypeofQues = Convert.ToString(Session["TypeofQues1"]);
            string cans = Convert.ToString(Session["Ans1"]);

            #region Basic Type,Passage
            if (TypeofQues == "80" || TypeofQues == "86" || TypeofQues == "82") //basic type
            {
                if (rdoAnswerlist.SelectedIndex != -1)
                {
                    if (rdoAnswerlist.SelectedItem.Text.CompareTo(cans) == 0)
                    {
                        lblCans.Text = "Your answer is Correct!!";
                        lblCans.Visible = true;
                        lblCans.ForeColor = Color.Green;
                        rdoAnswerlist.SelectedItem.Attributes.Add("Style", "background-color:lightgreen");

                    }
                    else
                    {
                        lblCans.Text = "Your answer is wrong!!";
                        lblCans.Visible = true;
                        lblCans.ForeColor = Color.Red;
                        rdoAnswerlist.SelectedItem.Attributes.Add("style", "background-color:Indianred");
                        for (int i = 0; i < rdoAnswerlist.Items.Count; i++)
                        {
                            if (rdoAnswerlist.Items[i].Text == cans)
                            {
                                rdoAnswerlist.Items[i].Attributes.Add("Style", "background-color:lightgreen");
                                break;
                            }
                        }
                    }
                }
                else
                {
                    lblCans.Text = "Please Select Answer !!";
                    lblCans.Visible = true;
                    lblCans.ForeColor = Color.Red;
                }
            }
            #endregion

            #region Multiple correct Choce
            if (TypeofQues == "83") //Multiple corre          
            {

                if (chkAnslist.SelectedIndex != -1)
                {
                    for (int i = 0; i < chkAnslist.Items.Count; i++)
                    {
                        if (chkAnslist.Items[i].Selected == true)
                            userAns += chkAnslist.Items[i].Text + ",";
                    }
                    if (userAns != "")
                        userAns = userAns.Substring(0, userAns.Length - 1);


                    if (userAns == cans)
                    {
                        lblCans.Text = "Your answer is Correct!!";
                        lblCans.Visible = true;
                        lblCans.ForeColor = Color.Green;
                        for (int i = 0; i < chkAnslist.Items.Count; i++)
                        {
                            if (chkAnslist.Items[i].Selected == true)
                                chkAnslist.Items[i].Attributes.Add("Style", "background-color:lightgreen");
                        }
                    }
                    else
                    {
                        lblCans.Text = "Your answer is wrong!!";
                        lblCans.Visible = true;
                        lblCans.ForeColor = Color.Red;

                        for (int i = 0; i < chkAnslist.Items.Count; i++)
                        {
                            if (chkAnslist.Items[i].Selected == true)
                                chkAnslist.Items[i].Attributes.Add("Style", "background-color:Indianred");
                        }
                        //  chkAnslist.SelectedItem.Attributes.Add("style", "background-color:Indianred");

                        string[] cansSplit = cans.Split(',');
                        for (int j = 0; j < cansSplit.Length; j++)
                        {
                            for (int i = 0; i < chkAnslist.Items.Count; i++)
                            {
                                if (chkAnslist.Items[i].Text == cansSplit[j])
                                {
                                    chkAnslist.Items[i].Attributes.Add("Style", "background-color:lightgreen");
                                    // break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    lblCans.Text = "Please Select Answer !!";
                    lblCans.Visible = true;
                    lblCans.ForeColor = Color.Red;
                }
            }

            #endregion

            #region Integer type
            if (TypeofQues == "93" || TypeofQues == "84")
            {
                if (txtAns.Text != "")
                {
                    if (txtAns.Text == cans)
                    {
                        lblCans.Text = "Your answer is Correct!!";
                        lblCans.Visible = true;
                        lblCans.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblCans.Text = "Your answer is wrong !! Your Correct answer is : " + cans;
                        lblCans.Visible = true;
                        lblCans.ForeColor = Color.Red;
                    }
                }

                else
                {
                    lblCans.Text = "Please Select Answer !!";
                    lblCans.Visible = true;
                    lblCans.ForeColor = Color.Red;
                }
            }
            #endregion

            #region Matrix type
            //**************************** Start  matrix type*****************************************************************************
            if (TypeofQues == "87") //Matrix type          
            {
                string[] cansSplit1 = cans.Split('*');

                //*********************************************************  A

                string[] cansSplitA = cansSplit1[0].Split('-');

                if (ChkansMatA.SelectedIndex != -1)
                {
                    for (int i = 0; i < ChkansMatA.Items.Count; i++)
                    {
                        if (ChkansMatA.Items[i].Selected == true)
                            userAns += ChkansMatA.Items[i].Text + ",";
                    }
                    if (userAns != "")
                        userAns = userAns.Substring(0, userAns.Length - 1);


                    if (userAns == Convert.ToString(cansSplitA[1]))
                    {

                        for (int i = 0; i < ChkansMatA.Items.Count; i++)
                        {
                            if (ChkansMatA.Items[i].Selected == true)
                                ChkansMatA.Items[i].Attributes.Add("Style", "background-color:lightgreen");
                        }
                    }
                    else
                    {

                        for (int i = 0; i < ChkansMatA.Items.Count; i++)
                        {
                            if (ChkansMatA.Items[i].Selected == true)
                                ChkansMatA.Items[i].Attributes.Add("Style", "background-color:Indianred");
                        }
                        //  chkAnslist.SelectedItem.Attributes.Add("style", "background-color:Indianred");

                        string[] cansSplit = cansSplitA[1].Split(',');
                        for (int j = 0; j < cansSplit.Length; j++)
                        {
                            for (int i = 0; i < ChkansMatA.Items.Count; i++)
                            {
                                if (ChkansMatA.Items[i].Text == cansSplit[j])
                                {
                                    ChkansMatA.Items[i].Attributes.Add("Style", "background-color:lightgreen");
                                    // break;
                                }
                            }
                        }
                    }
                }


                //*********************************************************  B

                string[] cansSplitB = cansSplit1[1].Split('-');
                if (ChkansMatB.SelectedIndex != -1)
                {
                    for (int i = 0; i < ChkansMatB.Items.Count; i++)
                    {
                        if (ChkansMatB.Items[i].Selected == true)
                            userAns1 += ChkansMatB.Items[i].Text + ",";
                    }
                    if (userAns1 != "")
                        userAns1 = userAns1.Substring(0, userAns1.Length - 1);


                    if (userAns1 == Convert.ToString(cansSplitB[1]))
                    {

                        for (int i = 0; i < ChkansMatB.Items.Count; i++)
                        {
                            if (ChkansMatB.Items[i].Selected == true)
                                ChkansMatB.Items[i].Attributes.Add("Style", "background-color:lightgreen");
                        }
                    }
                    else
                    {


                        for (int i = 0; i < ChkansMatA.Items.Count; i++)
                        {
                            if (ChkansMatB.Items[i].Selected == true)
                                ChkansMatB.Items[i].Attributes.Add("Style", "background-color:Indianred");
                        }
                        //  chkAnslist.SelectedItem.Attributes.Add("style", "background-color:Indianred");

                        string[] cansSplit = cansSplitB[1].Split(',');
                        for (int j = 0; j < cansSplit.Length; j++)
                        {
                            for (int i = 0; i < ChkansMatB.Items.Count; i++)
                            {
                                if (ChkansMatB.Items[i].Text == cansSplit[j])
                                {
                                    ChkansMatB.Items[i].Attributes.Add("Style", "background-color:lightgreen");
                                    // break;
                                }
                            }
                        }
                    }
                }


                //*********************************************************  C

                string[] cansSplitC = cansSplit1[2].Split('-');

                if (ChkansMatC.SelectedIndex != -1)
                {
                    for (int i = 0; i < ChkansMatC.Items.Count; i++)
                    {
                        if (ChkansMatC.Items[i].Selected == true)
                            userAns2 += ChkansMatC.Items[i].Text + ",";
                    }
                    if (userAns2 != "")
                        userAns2 = userAns2.Substring(0, userAns2.Length - 1);


                    if (userAns2 == Convert.ToString(cansSplitC[1]))
                    {

                        for (int i = 0; i < ChkansMatC.Items.Count; i++)
                        {
                            if (ChkansMatC.Items[i].Selected == true)
                                ChkansMatC.Items[i].Attributes.Add("Style", "background-color:lightgreen");
                        }
                    }
                    else
                    {

                        for (int i = 0; i < ChkansMatC.Items.Count; i++)
                        {
                            if (ChkansMatC.Items[i].Selected == true)
                                ChkansMatC.Items[i].Attributes.Add("Style", "background-color:Indianred");
                        }
                        //  chkAnslist.SelectedItem.Attributes.Add("style", "background-color:Indianred");

                        string[] cansSplit = cansSplitC[1].Split(',');
                        for (int j = 0; j < cansSplit.Length; j++)
                        {
                            for (int i = 0; i < ChkansMatC.Items.Count; i++)
                            {
                                if (ChkansMatC.Items[i].Text == cansSplit[j])
                                {
                                    ChkansMatC.Items[i].Attributes.Add("Style", "background-color:lightgreen");
                                    // break;
                                }
                            }
                        }
                    }
                }


                //*********************************************************  D

                string[] cansSplitD = cansSplit1[3].Split('-');

                if (ChkansMatD.SelectedIndex != -1)
                {
                    for (int i = 0; i < ChkansMatD.Items.Count; i++)
                    {
                        if (ChkansMatD.Items[i].Selected == true)
                            userAns3 += ChkansMatD.Items[i].Text + ",";
                    }
                    if (userAns3 != "")
                        userAns3 = userAns3.Substring(0, userAns3.Length - 1);


                    if (userAns3 == Convert.ToString(cansSplitD[1]))
                    {

                        for (int i = 0; i < ChkansMatD.Items.Count; i++)
                        {
                            if (ChkansMatD.Items[i].Selected == true)
                                ChkansMatD.Items[i].Attributes.Add("Style", "background-color:lightgreen");
                        }
                    }
                    else
                    {


                        for (int i = 0; i < ChkansMatD.Items.Count; i++)
                        {
                            if (ChkansMatD.Items[i].Selected == true)
                                ChkansMatD.Items[i].Attributes.Add("Style", "background-color:Indianred");
                        }
                        //  chkAnslist.SelectedItem.Attributes.Add("style", "background-color:Indianred");

                        string[] cansSplit = cansSplitD[1].Split(',');
                        for (int j = 0; j < cansSplit.Length; j++)
                        {
                            for (int i = 0; i < ChkansMatD.Items.Count; i++)
                            {
                                if (ChkansMatD.Items[i].Text == cansSplit[j])
                                {
                                    ChkansMatD.Items[i].Attributes.Add("Style", "background-color:lightgreen");
                                    // break;
                                }
                            }
                        }
                    }
                }


                //******************************** end D

                string collectuserAns = "A-" + userAns + "*B-" + userAns1 + "*C-" + userAns2 + "*D-" + userAns3;
                if (collectuserAns == cans)
                {
                    lblCans.Text = "Your answer is Correct!!";
                    lblCans.Visible = true;
                    lblCans.ForeColor = Color.Green;
                }
                else
                {
                    lblCans.Text = "Your answer is wrong!!";
                    lblCans.Visible = true;
                    lblCans.ForeColor = Color.Red;
                }

            }
            //**************************** end matrix type****************************************************************************

            #endregion

            // ScriptManager.RegisterStartupScript(this, typeof(Page), "checkRadio", "checkRadio('" + i2 + "');", true);
        }
        catch (Exception ex)
        {
            //  Response.Write("<h4>Error :" + ex.Message);
        }

    }

    public string TypeofQues = "";
    public string QType = "", Q1Type = "", AType = "", BType = "", CType = "", DType = "", EType = "", PType = "", RType = "", QType1 = "",
        SType = "", TType = "", passageType = "", hType = "";
    public string TypeDB = "", lang = "";
    public static string hintDB = "";
    public int settingid1 = 0;
    string ans;

    void fetchCommonData(DataRow row)
    {
        try
        {
            lblCans.Text = "";
            lblCans.Visible = false;
            rdoAnswerlist.ClearSelection();
            chkAnslist.ClearSelection();
            ChkansMatA.ClearSelection();
            ChkansMatB.ClearSelection();
            ChkansMatC.ClearSelection();
            ChkansMatD.ClearSelection();


            string loginId = Convert.ToString(Session["LoginId"]);
            string s11 = Convert.ToString(Session["CompanyId"]) + "" + Convert.ToString(Session["TestID"]);

            if (row.ItemArray.Count() > 0)
            {

                lblQNo.Text = Convert.ToString(row["ID"]);
                lblSno.Text = Convert.ToString(row["SNO"]);
                lblMasterID.Text = "Master ID : " + lblSno.Text;

                int NewQID = Convert.ToInt32(lblSno.Text);

                #region Type Of DB

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

                    // settingid1 = Convert.ToInt32(row["SettingId"]);

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

                if (TypeofQues == "80")
                    lbltypeQues.Text = "Type of Question : Basic Type";
                if (TypeofQues == "82")
                    lbltypeQues.Text = "Type of Question : Question On Passage";
                if (TypeofQues == "83")
                    lbltypeQues.Text = "Type of Question :Multiple Correct Choice";
                if (TypeofQues == "84")
                    lbltypeQues.Text = "Type of Question : Integer Answer Type";
                if (TypeofQues == "86")
                    lbltypeQues.Text = "Type of Question : Reasoning Type";
                if (TypeofQues == "87")
                    lbltypeQues.Text = "Type of Question : Matrix Match Type";
                if (TypeofQues == "93")
                    lbltypeQues.Text = "Type of Question : Theory Question Type";


                #endregion

                ans = Convert.ToString(row["Correct_answer"]);

                Session["TypeofQues1"] = TypeofQues;
                Session["Ans1"] = ans;

                if (TypeofQues == "80" || TypeofQues == "86" || TypeofQues == "82") //basic type
                {

                    txtAns.Visible = false;
                    chkAnslist.Visible = false;
                    pnlAnsMat.Visible = false;
                    rdoAnswerlist.Visible = true;
                }
                else if (TypeofQues == "93" || TypeofQues == "84")
                {
                    txtAns.Visible = true;
                    rdoAnswerlist.Visible = false;
                    chkAnslist.Visible = false;
                    pnlAnsMat.Visible = false;
                }

                else if (TypeofQues == "83")
                {
                    txtAns.Visible = false;
                    rdoAnswerlist.Visible = false;
                    chkAnslist.Visible = true;
                    pnlAnsMat.Visible = false;

                }
                else if (TypeofQues == "87")
                {
                    txtAns.Visible = false;
                    rdoAnswerlist.Visible = false;
                    chkAnslist.Visible = false;
                    pnlAnsMat.Visible = true;
                }

                #region All options A to T



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
                    lblQuestion.Font.Name = "Mangal";
                    lblQuestion.Font.Size = 14;
                    imgQues.Visible = false;
                }
                else
                {
                    lblQuestion.Visible = false;
                    imgQues.Visible = true;
                    imgQues.ImageUrl = "~/PracticeHandler.ashx?para=" + NewQID + ",Question";
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
                    lblOptA.Font.Name = "Mangal";
                    lblOptA.Font.Size = 14;
                }
                else
                {
                    lblOptA.Visible = false;
                    imgoptA.Visible = true;
                    lblA.Visible = true;
                    imgoptA.ImageUrl = "~/PracticeHandler.ashx?para=" + NewQID + ",Answer1";


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
                    lblOptB.Font.Name = "Mangal";
                    lblOptB.Font.Size = 14;
                }
                else
                {
                    imgoptB.ImageUrl = "~/PracticeHandler.ashx?para=" + NewQID + ",Answer2";
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
                    lblOptC.Font.Name = "Mangal";
                    lblOptC.Font.Size = 14;
                }
                else
                {
                    imgoptC.ImageUrl = "~/PracticeHandler.ashx?para=" + NewQID + ",Answer3";
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
                    lblOptD.Font.Name = "Mangal";
                    lblOptD.Font.Size = 14;
                }
                else
                {
                    imgoptD.ImageUrl = "~/PracticeHandler.ashx?para=" + NewQID + ",Answer4 ";
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
                        imgoptE.Visible = false;
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
                        imgoptE.Visible = false;
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
                    lblOptD.Font.Size = 14;
                }
                else if (EType == "3")
                {
                    string s = Convert.ToString(row["OptionE"]);
                    s = s.Replace("@011", "'");
                    lblOptE.Text = s;

                    imgoptE.Visible = false;
                    if (lblOptE.Text == " " || lblOptE.Text == "")
                    {
                        imgoptE.Visible = false;
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
                    lblOptD.Font.Name = "Mangal";
                    lblOptD.Font.Size = 14;
                }

                else
                {
                    string s = Convert.ToString(row["OptionE"]);

                    if (s == " " || s == "")
                    {
                        lblOptE.Visible = false;
                        lblE.Visible = false;
                        lblE.Visible = false;
                        imgoptE.Visible = false;
                    }
                    else
                    {
                        imgoptE.ImageUrl = "~/PracticeHandler.ashx?para=" + NewQID + ",OptionE";
                        lblOptE.Visible = false;
                        imgoptE.Visible = true;
                        lblE.Visible = true;
                        lblE.Visible = true;
                    }
                }


                if (PType == "0")
                {
                    string s = Convert.ToString(row["OptionP"]);
                    s = s.Replace("@011", "'");
                    lblOptP.Text = s;


                    //   lblOptP.Text = Convert.ToString(row["OptionP"]);

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
                    //  lblOptP.Text = Convert.ToString(row["OptionP"]);

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
                    //  lblOptP.Text = Convert.ToString(row["OptionP"]);

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
                    imgoptP.ImageUrl = "~/PracticeHandler.ashx?para=" + NewQID + ",OptionP";
                    lblOptP.Visible = false;
                    imgoptP.Visible = true;
                    lblP.Visible = true;
                }

                if (QType1 == "0")
                {
                    string s = Convert.ToString(row["OptionQ"]);
                    s = s.Replace("@011", "'");
                    lblOptQ.Text = s;

                    //   lblOptQ.Text = Convert.ToString(row["OptionQ"]);
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

                    // lblOptQ.Text = Convert.ToString(row["OptionQ"]);
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

                    // lblOptQ.Text = Convert.ToString(row["OptionQ"]);
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
                    imgoptQ.ImageUrl = "~/PracticeHandler.ashx?para=" + NewQID + ",OptionQ ";
                    lblOptQ.Visible = false;
                    imgoptQ.Visible = true;
                    lblQ.Visible = true;
                }

                if (RType == "0")
                {
                    string s = Convert.ToString(row["OptionR"]);
                    s = s.Replace("@011", "'");
                    lblOptR.Text = s;

                    // lblOptR.Text = Convert.ToString(row["OptionR"]);
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

                    // lblOptR.Text = Convert.ToString(row["OptionR"]);
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

                    // lblOptR.Text = Convert.ToString(row["OptionR"]);
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
                    imgoptR.ImageUrl = "~/PracticeHandler.ashx?para=" + NewQID + ",OptionR";
                    lblOptR.Visible = false;
                    imgoptR.Visible = true;
                    lblR.Visible = true;
                }

                if (SType == "0")
                {
                    string s = Convert.ToString(row["OptionS"]);
                    s = s.Replace("@011", "'");
                    lblOptS.Text = s;

                    //lblOptS.Text = Convert.ToString(row["OptionS"]);
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

                    // lblOptS.Text = Convert.ToString(row["OptionS"]);
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

                    // lblOptS.Text = Convert.ToString(row["OptionS"]);
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
                    imgoptS.ImageUrl = "~/PracticeHandler.ashx?para=" + NewQID + ",OptionS";
                    lblOptS.Visible = false;
                    imgoptS.Visible = true;
                    lblS.Visible = true;
                }

                if (TType == "0")
                {
                    string s = Convert.ToString(row["OptionT"]);
                    s = s.Replace("@011", "'");
                    lblOptT.Text = s;

                    //   lblOptT.Text = Convert.ToString(row["OptionT"]);
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

                    //  lblOptT.Text = Convert.ToString(row["OptionT"]);
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

                    //  lblOptT.Text = Convert.ToString(row["OptionT"]);
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
                    imgoptT.ImageUrl = "~/PracticeHandler.ashx?para=" + NewQID + ",OptionT";
                    lblOptT.Visible = false;
                    imgoptT.Visible = true;
                    lblT.Visible = true;
                }

                if (passageType == "0")
                {
                    string s = Convert.ToString(row["Passage"]);
                    s = s.Replace("@011", "'");
                    lblPassage.Text = s;

                    //  lblPassage.Text = Convert.ToString(row["Passage"]);
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

                    // lblPassage.Text = Convert.ToString(row["Passage"]);
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

                    // lblPassage.Text = Convert.ToString(row["Passage"]);
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
                    imgPassage.ImageUrl = "~/PracticeHandler.ashx?para=" + NewQID + ",Passage";
                    lblPassage.Visible = false;
                    imgPassage.Visible = true;
                    lblpassage1.Visible = true;
                }

                if (Q1Type == "0")
                {
                    string s = Convert.ToString(row["QuesWithImage"]);
                    s = s.Replace("@011", "'");
                    lblQuestionwithImage.Text = s;

                    // lblQuestionwithImage.Text = Convert.ToString(row["QuesWithImage"]);
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


                    //   lblQuestionwithImage.Text = Convert.ToString(row["QuesWithImage"]);
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


                    //   lblQuestionwithImage.Text = Convert.ToString(row["QuesWithImage"]);
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
                        imgQuesImage.ImageUrl = "~/PracticeHandler.ashx?para=" + NewQID + ",QuesWithImage";
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
                    if (txtHint.Text != "")
                    {
                        //txtHint.Text = Convert.ToString(row["Qhint"]);
                        hintDB = s;
                        ddlhint.SelectedIndex = Convert.ToInt32(hType);
                        txtHint.Font.Name = "Times New Roman";
                        txtHint.Font.Size = 11;
                        imgHint.Visible = false;
                        txtHint.Visible = true;
                        lblH.Visible = true;
                        // ddlhint.Visible = true;
                    }
                    else
                    {
                        lblH.Visible = false;
                        imgHint.Visible = false;
                    }

                }
                else if (hType == "1")
                {
                    string s = Convert.ToString(row["Qhint"]);
                    s = s.Replace("@011", "'");
                    txtHint.Text = s;
                    if (txtHint.Text != "")
                    {
                        hintDB = s;
                        ddlhint.SelectedIndex = Convert.ToInt32(hType);
                        txtHint.Font.Name = "Shivaji01";
                        txtHint.Font.Size = 14;
                        imgHint.Visible = false;

                        txtHint.Visible = true;
                        lblH.Visible = true;
                        // ddlhint.Visible = true;
                    }
                    else
                    {

                        lblH.Visible = false;
                        imgHint.Visible = false;
                    }


                }
                else if (hType == "3")
                {
                    string s = Convert.ToString(row["Qhint"]);
                    s = s.Replace("@011", "'");
                    txtHint.Text = s;
                    if (txtHint.Text != "")
                    {
                        hintDB = s;
                        ddlhint.SelectedIndex = Convert.ToInt32(hType);
                        txtHint.Font.Name = "Mangal";
                        txtHint.Font.Size = 14;
                        imgHint.Visible = false;

                        txtHint.Visible = true;
                        lblH.Visible = true;
                        // ddlhint.Visible = true;
                    }
                    else
                    {

                        lblH.Visible = false;
                        imgHint.Visible = false;
                    }
                }
                else
                {
                    if (txtHint.Text != "")
                    {
                        imgHint.ImageUrl = "~/PracticeHandler.ashx?para=" + NewQID + ",Qhint";
                        txtHint.Visible = false;
                        txtHint.Text = "";
                        imgHint.Visible = true;
                        lblH.Visible = true;
                        ddlhint.Visible = false;
                    }
                    else
                    {
                        lblH.Visible = false;
                        imgHint.Visible = false;
                    }
                }

                #endregion

            }


        }

        catch (Exception ex)
        {
            // Response.Write("<h4>Error :" + ex.Message);
        }

    }


    protected void btnGoto_Click(object sender, EventArgs e)
    {
        if (txtgoto.Text != "")
        {
            string[] countQues = lblcount.Text.Split(':');
            int userques = Convert.ToInt32(txtgoto.Text);
            int totCount = Convert.ToInt32(countQues[1]);
            if (userques <= totCount)
            {
                int temp = userques % 10;
                if ((userques + 9) <= totCount)
                {


                    if (temp > 0)  // round up 75 to 70
                    {
                        int quesroundup = userques - temp;

                        string rowFrom = Convert.ToString(quesroundup + 1);
                        string rowTo = Convert.ToString(quesroundup + 10);
                        QuesNo(rowFrom, rowTo, temp); // 1 for dosplay current ques enter in gotoques.
                    }
                    else
                    {
                        string rowFrom = Convert.ToString(userques);
                        string rowTo = Convert.ToString(userques + 9);
                        QuesNo(rowFrom, rowTo, 0);
                    }
                }
                else // for last question 
                {
                    if (temp > 0)
                    {
                        int quesroundup = userques - temp;

                        string rowFrom = Convert.ToString(quesroundup + 1);
                        string rowTo = Convert.ToString(totCount);
                        QuesNo(rowFrom, rowTo, temp);
                    }
                    else
                    {
                        string rowFrom = Convert.ToString(userques);
                        string rowTo = Convert.ToString(totCount);
                        QuesNo(rowFrom, rowTo, 0);
                    }
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Question should not be more than total available Question!!!!! ')", true);

            }
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        int m = Convert.ToInt32(((Button)sender).Text);
        int getrow = m % 10;

        username1 = Convert.ToString(Session["LoginId"]);

        DataSet ds2 = (DataSet)Cache[username1];
        dt = ds2.Tables[0];
        ////  dt = (DataTable)ViewState["mytable"];

        if (getrow > 0)
        {
            fetchCommonData(dt.Rows[getrow - 1]);
        }
        else
        {
            fetchCommonData(dt.Rows[9]);
        }

    }
    protected void btnNextRowset_Click(object sender, EventArgs e)
    {
        int totalcount = Convert.ToInt32((lblcount.Text.Split(':'))[1]);


        int currentcount = Convert.ToInt32(lbldsLastrowscount.Text);
        if ((totalcount - currentcount) > 9)
        {
            string rowFrom = Convert.ToString(currentcount + 1);
            string rowTo = Convert.ToString(currentcount + 10);
            QuesNo(rowFrom, rowTo, 0);
        }

    }
    protected void btnbackRowset_Click(object sender, EventArgs e)
    {
        int startrows = Convert.ToInt32(lbldsFirstrowscount.Text);
        if (startrows != 1)
        {
            if (startrows > 9)
            {
                string rowFrom = Convert.ToString(startrows - 10);
                string rowTo = Convert.ToString(startrows - 1);
                QuesNo(rowFrom, rowTo, 0);
            }
            else
            {
                string rowFrom = Convert.ToString(1);
                string rowTo = Convert.ToString(startrows - 1);
                QuesNo(rowFrom, rowTo, 0);
            }
        }
    }

    public void buttonVisiblefalse()
    {
        Button1.Visible = false;
        Button2.Visible = false;
        Button3.Visible = false;
        Button4.Visible = false;
        Button5.Visible = false;
        Button6.Visible = false;
        Button7.Visible = false;
        Button8.Visible = false;
        Button9.Visible = false;
        Button10.Visible = false;

    }








}
