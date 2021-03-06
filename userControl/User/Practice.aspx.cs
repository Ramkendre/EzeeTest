using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;


public partial class Practice : System.Web.UI.Page
{
    String level, lang, topic = "", cans, companyid, abc;

    int selIndex, id = 0, cnt = 0;
    int tid = 0, no = 0, sid, flag = 0, qno = 0, i, Question_id;

    int[] jump;
    int[] jp;
    int[] js;
    DataSet ds;
    CommonCode cc = new CommonCode();
    [DllImport("User32.dll")]
    public static extern int MBox(int h, string m, string c, int type);


    protected void Page_Load(object sender, EventArgs e)
    {      

        abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))          
            // AnswerHint.Visible = false;
            Label2.Visible = false;
        companyid = Session["companyid"].ToString();
        if (Page.IsPostBack == false)
        {
            ImgSfeed.Visible = false;
            MultiView1.ActiveViewIndex = 0;
           // MultiView1.SetActiveView(View1);
            select_Subject();
            clean();
        }
    }

    protected void btnStart_Click(object sender, EventArgs e)
    {        
        cmbSelectlang.Enabled = false;
        rdoLevelList.Enabled = false;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        cans = Session["b"].ToString();
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
            lblCans.Text = "Please Select Answer";
            lblCans.Visible = true;
            lblCans.ForeColor = Color.Red;
        }
    }

    public void select_Subject()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))

            try
            {
                string str1 = "select Subject_id as Id,Subject_Name as Subject from tblSubject where CompanyId=" + companyid + "  order by Subject_Name";
                ds = cc.ExecuteDataset(str1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbSelectSub.DataSource = ds.Tables[0];
                    cmbSelectSub.DataValueField = "Id";
                    cmbSelectSub.DataTextField = "Subject";
                    cmbSelectSub.DataBind();
                    cmbSelectSub.Items.Add("--Select--");
                    cmbSelectSub.SelectedIndex = cmbSelectSub.Items.Count - 1;

                    lblQue.Visible = false;
                    lblQuestion.Visible = false;
                    rdoAnswerlist.Visible = false;
                    lblAnswer.Visible = false;
                    btnSubmit.Visible = false;
                    txtQhint.Visible = false;
                    lblAnswer.Visible = false;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                con.Close();
            }
    }

    protected void lstboxSeltopic_SelectedIndexChanged(object sender, EventArgs e)
    {
        questionCount();
    }
    protected void rdoLevelList_SelectedIndexChanged(object sender, EventArgs e)
    {
        questionCount();
        TxtCount.Visible = false;
    }
    protected void cmbSelectlang_SelectedIndexChanged(object sender, EventArgs e)
    {
        String lan = cmbSelectlang.Text;
        if (lan.CompareTo("Marathi") == 0 || lan.CompareTo("Hindi") == 0)
        {
            lblQuestion.Font.Name = "Shivaji01";
            lblQue.Font.Name = "Shivaji01";
            rdoAnswerlist.Font.Name = "Shivaji01";
            txtGoto.Font.Name = "Shivaji01";
            TxtCount.Font.Name = "Shivaji01";

            lblQuestion.Font.Size = 16;
            lblQue.Font.Size = 14;
            rdoAnswerlist.Font.Size = 12;
            txtGoto.Font.Size = 14;
            TxtCount.Font.Size = 14;
        }
        if (lan.CompareTo("English") == 0)
        {
            lblQuestion.Font.Name = "Arial";
            lblQue.Font.Size = 14;
            rdoAnswerlist.Font.Name = "Arial";
            txtQhint.Font.Name = "Arial";
            txtGoto.Font.Name = "Arial";
            TxtCount.Font.Name = "Arial";
            AnswerHint.Font.Name = "Arial";

            rdoAnswerlist.Font.Size = 10;
            lblQuestion.Font.Size = 10;
            lblQue.Font.Size = 10;
            TxtCount.Font.Size = 10;
            AnswerHint.Font.Size = 10;
        }
        questionCount();
        TxtCount.Visible = false;
    }

    public void questionCount()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))

            try
            {
                txtQhint.Visible = false;
                level = rdoLevelList.SelectedItem.Text;
                lang = cmbSelectlang.Text;
                string str2 = "select count(Question_id) as Question from tblQuestion where QuestionLevel='" + level + "' and Sellanguage='" + lang + "' and Topic_id=" + lstboxSeltopic.SelectedValue + " and Subject_id=" + cmbSelectSub.SelectedValue + " ";
                ds = cc.ExecuteDataset(str2);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cnt = Convert.ToInt32(ds.Tables[0].Rows[0]["Question"]);
                }
                // count total number of ques
                TxtCount.Text = cnt.ToString();
                Label2.Text = "Total Number of Question= " + cnt.ToString();
                Label2.Visible = true;
               
                clean();
                btnStart.Visible = true;
                string str8 = "update tblQuestion set [Ischecked]=false";
                ds = cc.ExecuteDataset(str8);
            }
            catch (Exception ex)
            {
                String msg = ex.Message;
            }
            finally
            {
                con.Close();
            }
    }
    public void clean()
    {
        txtGoto.Text = "";
        rdoAnswerlist.Visible = false;
        lblQuestion.Visible = false;
        lblQue.Visible = false;
        lblAnswer.Visible = false;
        btnSubmit.Visible = false;
        btnStart.Visible = false;
        btnExit.Visible = false;
        lblCans.Visible = false;
        txtQhint.Visible = false;
        lblAnswer.Visible = false;
        AnswerHint.Visible = false;
        btnNext.Visible = false;
        btnPrevious.Visible = false;
    }
    protected void btnStart_Click1(object sender, EventArgs e)
    {
        AnswerHint.Visible = false;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
         try
            {
                if (cmbSelectlang.SelectedIndex == cmbSelectlang.Items.Count - 1)
                {
                    lblError.Visible = true;
                    lblError.Text = "Select Language Name";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select Language Name')", true);
                }
                else
                {
                    txtQhint.Visible = false;
                    int gocnt = Convert.ToInt32(TxtCount.Text);
                    if (gocnt == 0)
                    {
                        lblCans.Text = "No Questions found";

                        lblCans.Visible = true;
                        lblCans.ForeColor = Color.Red;

                        lblQue.Visible = false;
                        lblQuestion.Visible = false;
                        rdoAnswerlist.Visible = false;
                        lblAnswer.Visible = false;
                        btnSubmit.Visible = false;
                        rdoAnswerlist.ClearSelection();
                        btnExit.Visible = true;
                        btnExit.Enabled = true;
                        AnswerHint.Visible = false;

                        flag = 1;

                    }
                    if (flag == 0)
                    {
                        int tid = 0;
                        txtGoto.Text = "1";
                        lblQuestion.Text = "1";
                        level = rdoLevelList.SelectedItem.Text;
                        lang = cmbSelectlang.Text;
                        con.Open();

                        string str3 = "select Question_id, Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Qhint,Image from tblQuestion where  QuestionLevel='" + level + "' and Sellanguage='" + lang + "' and Topic_id=" + lstboxSeltopic.SelectedValue + " ";
                        ds = cc.ExecuteDataset(str3);

                      
                        if (cmbSelectlang.SelectedItem.Text.CompareTo("Marathi") == 0 || cmbSelectlang.SelectedItem.Text.CompareTo("Hindi") == 0)
                        {
                            rdoAnswerlist.Font.Name = "Shivaji01";
                            lblQue.Font.Name = "Shivaji01";
                            if (TxtCount.Text != "")
                            {
                                btnNext.Font.Name = "Shivaji01";
                                btnPrevious.Font.Name = "Shivaji01";
                                btnSubmit.Font.Name = "Shivaji01";
                                btnExit.Font.Name = "Shivaji01";
                                lblAnswer.Font.Name = "Shivaji01";
                                rdoAnswerlist.Font.Name = "Shivaji01";

                                btnPrevious.Font.Size = 14;
                                btnNext.Font.Size = 14;
                                btnSubmit.Font.Size = 14;
                                btnExit.Font.Size = 14;
                                lblAnswer.Font.Size = 12;
                                rdoAnswerlist.Font.Size = 12;

                                btnExit.Text = "baa*or";
                                btnSubmit.Text = "jamaa";
                                btnNext.Text = "puZo";
                                btnPrevious.Text = "maagao";
                                lblAnswer.Text = "उत्तर";
                            }
                        }
                        else
                        {
                            rdoAnswerlist.Font.Name = "Arial";
                            lblQue.Font.Name = "Arial";
                            if (TxtCount.Text != "")
                            {
                                btnNext.Font.Name = "Arial";
                                btnPrevious.Font.Name = "Arial";
                                btnSubmit.Font.Name = "Arial";
                                btnExit.Font.Name = "Arial";
                                lblAnswer.Font.Name = "Arial";
                                rdoAnswerlist.Font.Name = "Arial";

                                btnPrevious.Font.Size = 10;
                                btnNext.Font.Size = 10;
                                btnSubmit.Font.Size = 10;
                                btnExit.Font.Size = 10;
                                lblAnswer.Font.Size = 10;
                                rdoAnswerlist.Font.Size = 10;

                                btnExit.Text = "Exit";
                                btnSubmit.Text = "Submit";
                                btnNext.Text = ">";
                                btnPrevious.Text = "<";
                                lblAnswer.Text = "Answer";
                            }
                        }

                        jump = new int[gocnt];

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lblQue.Text = Convert.ToString(ds.Tables[0].Rows[0]["Question"]);
                            rdoAnswerlist.Items[0].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer1"]);
                            rdoAnswerlist.Items[1].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer2"]);
                            rdoAnswerlist.Items[2].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer3"]);
                            rdoAnswerlist.Items[3].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer4"]);
                            cans = Convert.ToString(ds.Tables[0].Rows[0]["Correct_answer"]);
                            tid = Convert.ToInt32(ds.Tables[0].Rows[0]["Question_id"]);
                            string Qhint = Convert.ToString(ds.Tables[0].Rows[0]["Qhint"]);

                            ImgSfeed.ImageUrl = "~/User/ImageHandler.ashx?QId=" + tid + " " + Session["DBName"].ToString() + " ";

                            //******** COUNT length of Image *****
                            String aa = "SELECT  DATALENGTH(Image)  FROM tblQuestion WHERE Question_id = " + tid + "";
                            int imgLength = Convert.ToInt32(cc.ExecuteScalar(aa));
                            if (imgLength == 0 || imgLength < 70)
                            {
                                ImgSfeed.Visible = false;
                            }
                            else
                            {
                                ImgSfeed.Visible = true;
                            }

                            if (Qhint == "")
                            {
                                AnswerHint.Visible = false;
                            }
                            else
                            {
                                AnswerHint.Visible = true;
                                txtQhint.Text = Convert.ToString(ds.Tables[0].Rows[0]["Qhint"]);
                            }

                            Session["id"] = tid.ToString();
                            Session["b"] = cans.ToString();
                        }
                        i++;

                        lblAnswer.Visible = true;
                        lblQue.Visible = true;
                        lblQuestion.Visible = true;
                        rdoAnswerlist.Visible = true;
                        lblAnswer.Visible = true;
                        btnSubmit.Visible = true;
                        rdoAnswerlist.ClearSelection();
                        lblCans.Text = "";
                        //AnswerHint.Visible = true;
                        btnPrevious.Visible = true;
                        btnNext.Visible = true;
                        TxtCount.Visible = true;
                        btnStart.Visible = false;
                        lblCans0.Visible = true;
                    }
                }
            }

            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                con.Close();
            }
        //MultiView1.ActiveViewIndex = 1;
        MultiView1.SetActiveView(View2);
       
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))

            try
            {
                txtQhint.Visible = false;
                rdoAnswerlist.Enabled = true;
                rdoAnswerlist.ClearSelection();
                no = Convert.ToInt32(txtGoto.Text);
                qno = Convert.ToInt32(lblQuestion.Text);
                no++;
                qno++;

                level = rdoLevelList.SelectedItem.Text;
                lang = cmbSelectlang.Text;
                int gocount = Convert.ToInt32(TxtCount.Text);
                if (no > gocount)
                {
                    flag = 1;
                    lblCans.Text = "You have finished with the exam. Thank you!!";
                    lblCans.ForeColor = Color.Green;
                    lblCans.Visible = true;
                    lblQue.Visible = false;
                    lblQuestion.Visible = false;
                    rdoAnswerlist.Visible = false;
                    lblAnswer.Visible = false;
                    btnSubmit.Visible = false;
                    rdoAnswerlist.ClearSelection();
                    btnExit.Visible = true;
                    btnExit.Enabled = true;
                    AnswerHint.Visible = false;
                    ImgSfeed.Visible = false;
                    lblCans0.Visible = false;

                }
                if (flag == 0)
                {
                    string s1 = "select Question_id from tblQuestion where QuestionLevel='" + level + "' and Sellanguage='" + lang + "' and Topic_id=" + lstboxSeltopic.SelectedValue + " ";
                    SqlCommand c = new SqlCommand(s1, con);
                    con.Open();
                    SqlDataReader drs = c.ExecuteReader();

                    int gotoid = 0;
                    //int quesid = 0;
                    js = new int[gocount];
                    int goct = Convert.ToInt32(txtGoto.Text);

                    while (drs.Read())
                    {
                        js[i] = Convert.ToInt32(drs.GetValue(0).ToString());
                        i++;
                    }
                    drs.Close();
                    for (i = 0; i < gocount; i++)
                    {
                        if (i == goct)
                        {
                            gotoid = js[i];
                        }
                    }

                    txtGoto.Text = no.ToString();

                    lblQuestion.Text = no.ToString();

                    string str8 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id,Qhint,Image from tblQuestion where Question_id='" + gotoid + "' and QuestionLevel='" + level + "' and Sellanguage='" + lang + "' and Topic_id=" + lstboxSeltopic.SelectedValue + " ";
                    ds = cc.ExecuteDataset(str8);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblQue.Text = Convert.ToString(ds.Tables[0].Rows[0]["Question"]);
                        rdoAnswerlist.Items[0].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer1"]);
                        rdoAnswerlist.Items[1].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer2"]);
                        rdoAnswerlist.Items[2].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer3"]);
                        rdoAnswerlist.Items[3].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer4"]);
                        cans = Convert.ToString(ds.Tables[0].Rows[0]["Correct_answer"]);

                        ImgSfeed.ImageUrl = "~/User/ImageHandler.ashx?QId=" + gotoid + " " + Session["DBName"].ToString() + " ";


                        String aa = "SELECT  DATALENGTH(Image)  FROM tblQuestion WHERE Question_id = " + gotoid + "";
                        int imgLength = Convert.ToInt32(cc.ExecuteScalar(aa));
                        if (imgLength == 0 || imgLength < 70)
                        {
                            ImgSfeed.Visible = false;
                        }
                        else
                        {
                            ImgSfeed.Visible = true;
                        }

                        string Qhint = Convert.ToString(ds.Tables[0].Rows[0]["Qhint"]);
                        if (Qhint == "")
                        {
                            AnswerHint.Visible = false;
                        }
                        else
                        {
                            AnswerHint.Visible = true;
                            txtQhint.Text = Convert.ToString(ds.Tables[0].Rows[0]["Qhint"]);
                        }
                        Session["b"] = cans.ToString();
                    }

                    lblQue.Visible = true;
                    lblQuestion.Visible = true;
                    rdoAnswerlist.Visible = true;
                    lblAnswer.Visible = true;
                    btnSubmit.Visible = true;
                    rdoAnswerlist.ClearSelection();
                    lblCans.Text = "";
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                con.Close();
            }
    }
    protected void btnExit_Click(object sender, EventArgs e)
    { }
    protected void txtGoto_TextChanged(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))

            try
            {
                int gotoid = 0;
                int goct = Convert.ToInt32(txtGoto.Text);
                int gocount = Convert.ToInt32(TxtCount.Text);
                if (goct > gocount || goct == 0)
                {
                    flag = 1;
                    lblQue.Visible = false;
                    lblQuestion.Visible = false;
                    rdoAnswerlist.Visible = false;
                    lblAnswer.Visible = false;
                    btnSubmit.Visible = false;
                    rdoAnswerlist.ClearSelection();
                    btnExit.Visible = true;
                    btnExit.Enabled = true;
                    lblCans.Text = "No Question found";
                    lblCans.Visible = true;
                    lblCans.ForeColor = Color.Red;
                }

                if (flag == 0)
                {
                    lblQuestion.Text = txtGoto.Text;
                    level = rdoLevelList.SelectedItem.Text;
                    lang = cmbSelectlang.Text;
                    con.Open();

                    string str9 = "select Question_id from tblQuestion where QuestionLevel='" + level + "' and Sellanguage='" + lang + "' and Topic_id=" + Convert.ToInt32(Session["a"]).ToString() + " ";
                    ds = cc.ExecuteDataset(str9);
                    jp = new int[gocount];
                    goct--;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        jp[i] = Convert.ToInt32(ds.Tables[0].Rows[0]["Question_id"]);
                        i++;
                    }
                    for (i = 0; i < gocount; i++)
                    {
                        if (i == goct)
                        {
                            gotoid = jp[i];
                            Session["gotoid"] = Convert.ToString(gotoid);
                        }
                    }
                    string str8 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id,Qhint from tblQuestion where QuestionLevel='" + level + "' and Sellanguage='" + lang + "' and Topic_id=" + lstboxSeltopic.SelectedValue + " ";
                    ds = cc.ExecuteDataset(str8);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblQue.Text = Convert.ToString(ds.Tables[0].Rows[0]["Question"]);
                        rdoAnswerlist.Items[0].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer1"]);
                        rdoAnswerlist.Items[1].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer2"]);
                        rdoAnswerlist.Items[2].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer3"]);
                        rdoAnswerlist.Items[3].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer4"]);
                        cans = Convert.ToString(ds.Tables[0].Rows[0]["Correct_answer"]);

                        string Qhint = Convert.ToString(ds.Tables[0].Rows[0]["Qhint"]);
                        if (Qhint == null)
                        {
                            AnswerHint.Visible = false;
                        }
                        else
                        {
                            AnswerHint.Visible = true;
                            txtQhint.Text = Convert.ToString(ds.Tables[0].Rows[0]["Qhint"]);
                        }
                        Session["b"] = cans.ToString();
                    }
                    lblQue.Visible = true;
                    lblQuestion.Visible = true;
                    rdoAnswerlist.Visible = true;
                    lblAnswer.Visible = true;
                    btnSubmit.Visible = true;
                    rdoAnswerlist.ClearSelection();
                    lblCans.Text = "";
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                con.Close();
            }
    }

    protected void cmbSelectsub_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
            try
            {
                if (cmbSelectSub.SelectedIndex == cmbSelectSub.Items.Count - 1)
                {
                    lstboxSeltopic.Items.Clear();
                    btnStart.Visible = false;
                }
                else
                {
                    string subselected = cmbSelectSub.Text;
                    string str1 = "select Topic_id as Id,Topic_Name as topic from tblTopic,tblSubject where tblSubject.Subject_id=tblTopic.Subject_id and tblTopic.Subject_id='" + cmbSelectSub.SelectedValue + "'Order  by Topic_Name ";
                    ds = cc.ExecuteDataset(str1);
                    lstboxSeltopic.Items.Clear();
                    lstboxSeltopic.DataSource = ds.Tables[0];
                    lstboxSeltopic.DataValueField = "Id";
                    lstboxSeltopic.DataTextField = "topic";
                    lstboxSeltopic.DataBind();
                    clean();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                con.Close();
            }
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))

            try
            {
                txtQhint.Visible = false;
                rdoAnswerlist.Enabled = true;
                rdoAnswerlist.ClearSelection();
                no = Convert.ToInt32(txtGoto.Text);

                qno = Convert.ToInt32(lblQuestion.Text);
                int gocount = Convert.ToInt32(TxtCount.Text);
                if (no == 1)
                {
                    flag = 1;
                    lblCans.Text = "you cannot go back";
                    lblCans.Visible = true;
                    lblCans.ForeColor = Color.Red;
                }
                // if (no + 1 > gocount)
                if (no > gocount)
                {
                    flag = 1;
                    lblCans.Text = "No Question found";
                    lblCans.Visible = true;
                    lblCans.ForeColor = Color.Red;
                    no--;
                    //qno--;
                    txtGoto.Text = no.ToString();
                    ImgSfeed.Visible = false;
                }

                level = rdoLevelList.SelectedItem.Text;
                lang = cmbSelectlang.Text;
                selIndex = lstboxSeltopic.SelectedIndex;
                topic = lstboxSeltopic.SelectedItem.Text;

                if (flag == 0)
                {
                    no--;
                    qno--;
                    txtGoto.Text = no.ToString();
                    lblQuestion.Text = no.ToString();
                    string s = "select Question_id from tblQuestion where QuestionLevel='" + level + "' and Sellanguage='" + lang + "' and Topic_id=" + lstboxSeltopic.SelectedValue + " ";
                    SqlCommand c = new SqlCommand(s, con);
                    con.Open();
                    SqlDataReader drs = c.ExecuteReader();

                    int gotoid = 0;

                    //int quesid = 0;
                    js = new int[gocount];
                    int goct = Convert.ToInt32(txtGoto.Text);
                    goct--;
                    while (drs.Read())
                    {
                        js[i] = Convert.ToInt32(drs.GetValue(0).ToString());
                        i++;
                    }
                    drs.Close();
                    for (i = 0; i < gocount; i++)
                    {
                        if (i == goct)
                        {
                            gotoid = js[i];
                        }
                    }
                    string st = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Qhint from tblQuestion where Question_id=" + gotoid + "";
                    ds = cc.ExecuteDataset(st);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblQue.Text = Convert.ToString(ds.Tables[0].Rows[0]["Question"]);
                        rdoAnswerlist.Items[0].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer1"]);
                        rdoAnswerlist.Items[1].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer2"]);
                        rdoAnswerlist.Items[2].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer3"]);
                        rdoAnswerlist.Items[3].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer4"]);
                        cans = Convert.ToString(ds.Tables[0].Rows[0]["Correct_answer"]);

                        ImgSfeed.ImageUrl = "~/User/ImageHandler.ashx?QId=" + gotoid + " " + Session["DBName"].ToString() + " ";
                        String aa = "SELECT  DATALENGTH(Image)  FROM tblQuestion WHERE Question_id = " + gotoid + "";
                        int imgLength = Convert.ToInt32(cc.ExecuteScalar(aa));

                        if (imgLength == 0 || imgLength < 70)
                        {
                            ImgSfeed.Visible = false;
                        }
                        else
                        {
                            ImgSfeed.Visible = true;
                        }


                        string qhint = Convert.ToString(ds.Tables[0].Rows[0]["Qhint"]);
                        if (qhint == "")
                        {
                            AnswerHint.Visible = false;
                        }
                        else
                        {
                            AnswerHint.Visible = true;
                            txtQhint.Text = Convert.ToString(ds.Tables[0].Rows[0]["Qhint"]);
                        }
                        Session["b"] = cans.ToString();
                    }

                    lblQue.Visible = true;
                    lblQuestion.Visible = true;
                    rdoAnswerlist.Visible = true;
                    lblAnswer.Visible = true;
                    btnSubmit.Visible = true;
                    rdoAnswerlist.ClearSelection();
                    lblCans.Text = "";
                    lblAnswer.Visible = true;
                }
            }
            catch (Exception ex)
            {
                String msg = ex.Message;
            }
            finally
            {
                con.Close();
            }
    }
    protected void rdoAnswerlist_SelectedIndexChanged(object sender, EventArgs e)
    { }
    protected void TxtCount_TextChanged(object sender, EventArgs e)
    { }
    protected void AnswerHint_Click(object sender, EventArgs e)
    {
        txtQhint.Visible = true;
    }
}



