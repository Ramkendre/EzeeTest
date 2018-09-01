using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
public partial class Exam : System.Web.UI.Page
{


    int flag = 0;
    String topic, sub, canswer, studid, username, companyname, Qhint, testassign, abc;
    int cnt = 0, cnt1 = 0, cnt2 = 0, i, tid = 0, sid = 0, attcnt = 0, TQueNo, TComNo;
    int id = 0, no = 0, qno = 0, cno, n = 0, correct;
    int[] next;
    int[] jp;
    int[] js;
    int addition;

    int Status = 0;

    string A1, A2, A3, A4, Qname;


    CommonCode cc = new CommonCode();

    protected void Page_Load(object sender, EventArgs e)
    {
       
      
        try
        {
            username = Convert.ToString(Session["LoginId"]);
            companyname = Convert.ToString(Session["companyid"]);

            if (Page.IsPostBack == false)
            {
                select_Examname();

            }
           
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }

    private void select_Examname()
    {
        try
        {
            AnswerHint.Visible = false;
            txtQhint.Visible = false;
            getmenu();
            string Sql = " select distinct Total_que as testname,tblTestDefinition.Test_ID as Id from tblTestDefinition ,Login1 where  tblTestDefinition.Test_ID in(" + testassign + ")and companyId = " + companyname + "";
            DataSet ds = cc.ExecuteDataset(Sql);
            dddlExamname.DataSource = ds.Tables[0];
            dddlExamname.DataValueField = "Id";
            dddlExamname.DataTextField = "testname";
            dddlExamname.DataBind();
            dddlExamname.Items.Add("--Select--");
            dddlExamname.SelectedIndex = dddlExamname.Items.Count - 1;
            clear_subject();
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {
        }
    }
    public void getmenu()
    {
        try
        {
            string sql = "select MenuId from Login1 where LoginId='" + username + "'";
            DataSet ds = cc.ExecuteDataset(sql);
            testassign = Convert.ToString(ds.Tables[0].Rows[0]["MenuId"]);
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {
        }
    }
    public void clear_subject()
    {
        lblQno.Visible = false;
        lblQuestion.Visible = false;
        lblAns.Visible = false;
        rdoSelectAnswer.Visible = false;
        btnSubmit.Visible = false;
        btnPrev.Visible = false;
        btnNext.Visible = false;
        txtcurrentNo.Visible = false;
        lblOf.Visible = false;
        lblTotalQue.Visible = false;
        btnExit.Visible = false;
        lblatcnt.Visible = false;
        lblattemp.Visible = false;
        Label1.Visible = false;
        Label3.Visible = false;
        Label5.Visible = false;
        Label4.Visible = false;
        lblCans.Visible = false;
        txtQhint.Visible = false;
    }

    protected void btnStart_Click(object sender, EventArgs e)
    {
        txtQhint.Visible = false;
        Label5.Visible = true;
        int j = 0, l1 = 0, l2 = 0, l3 = 0;

        try
        {
            string strc1 = "UPDATE tblQuestion SET Ischecked = 0";
            DataSet ds1 = cc.ExecuteDataset(strc1);
            // FIND EXAM DURATION
            string str = " select Exam_Duration from tbltestDefinition where tblTestDefinition.Test_ID='" + dddlExamname.SelectedValue + "'";
            DataSet ds = cc.ExecuteDataset(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label1.Text = Convert.ToString(ds.Tables[0].Rows[0]["Exam_Duration"]);
            }
            //timer start
            Label1.Visible = true;
            Label4.Visible = true;
            Label3.Visible = true;
            // Label1.Text = time;
            int s = Convert.ToInt32(Label1.Text);
            s--;
            Label1.Text = s.ToString();
            Label4.Text = "0";

            lblatcnt.Text = "0";
            lblattemp.Visible = true;
            lblatcnt.Visible = true;
            string sid = " 0";
            string temp_topic = "0";

            string strdel = "delete from tblExamQuestion where LoginId='" + username + " '";
            ds = cc.ExecuteDataset(strdel);

            String s1 = "Select temp_topic from tblMaxQuestions,tblTopic where tblTopic.Topic_id=tblMaxQuestions.Topic_id and tblMaxQuestions.Topic_Id='" + Session["tid"] + "'";
            ds = cc.ExecuteDataset(s1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                temp_topic = Convert.ToString(ds.Tables[0].Rows[0]["temp_topic"]);
                if (sid.CompareTo(temp_topic) == 0)
                {
                    flag = 1;
                    count1();
                    count2();
                    count3();
                    string str0 = "update tblMaxQuestions set Level1=" + cnt + ",Level2=" + cnt1 + ",Level3=" + cnt2 + " where Subject_id=" + ds + "  ";
                    ds = cc.ExecuteDataset(str0);

                    string ll = "select * from tblExamQuestion order by Question_id";
                    ds = cc.ExecuteDataset(ll);
                }
            }

            if (flag == 0)
            {
                count1();
                count2();
                count3();
                string str5 = " insert into tblMaxQuestions(Subject_id,Level1,Level2,Level3,temp_sub,Topic_id,temp_topic) values(" + Session["sid"] + "," + cnt + "," + cnt1 + "," + cnt2 + "," + Session["sid"] + "," + Session["tid"] + "," + Session["tid"] + ")";
                ds = cc.ExecuteDataset(str5);

                string ll = "select * from tblExamQuestion order by Question_id";
                ds = cc.ExecuteDataset(ll);

            }

            String correctans;
            string str4 = "select Level1,Level2,Level3 from tblMaxQuestions where Subject_id=" + Session["sid"] + "and Topic_id=" + Session["tid"] + "  ";
            ds = cc.ExecuteDataset(str4);
            if (ds.Tables[0].Rows.Count > 0)
            {
                l1 = Convert.ToInt32(ds.Tables[0].Rows[0]["Level1"]);
                l2 = Convert.ToInt32(ds.Tables[0].Rows[0]["Level2"]);
                l3 = Convert.ToInt32(ds.Tables[0].Rows[0]["Level3"]);
            }

            // count number of ques 
            string sq = "select count(Question_id)as Question_id  from tblQuestion where  Topic_id=" + Session["tid"] + " and Subject_id=" + Session["sid"] + " ";

            ds = cc.ExecuteDataset(sq);
            if (ds.Tables[0].Rows.Count > 0)
            {
                TQueNo = Convert.ToInt32(ds.Tables[0].Rows[0]["Question_id"]);
                lblTotalQue.Text = TQueNo.ToString();
            }
            while (j < TQueNo)
            {
                lblcnt.Text = "1";
                int jumpcnt = Convert.ToInt32(lblcnt.Text);

                while (jumpcnt <= 2 && j < TQueNo)
                {
                    if (j < TQueNo)
                    {
                        String st = "Level1";

                        //change- string str2 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id from tblQuestion,tblSubject where tblQuestion.Subject_id=tblSubject.Subject_id and Subject_Name='" + sub + "' and QuestionLevel='" + st + "' and Ischecked=0";
                        string str2 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id,Qhint from tblQuestion,tblTopic where tblQuestion.Topic_id=tblTopic.Topic_id and tblQuestion.Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " and QuestionLevel='" + st + "' and Ischecked=0";
                        // string str2 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id from tblExamQuestion,tblTopic where tblQuestion.Topic_id=tblTopic.Topic_id and tblQuestion.Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " and QuestionLevel='" + st + "' and Ischecked=0";


                        ds = cc.ExecuteDataset(str2);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            correctans = Convert.ToString(ds.Tables[0].Rows[0]["Correct_answer"]);
                            Session["a"] = correctans;
                            id = Convert.ToInt32(ds.Tables[0].Rows[0]["Question_id"]);
                            Session["b"] = id;
                            A1 = Convert.ToString(ds.Tables[0].Rows[0]["Answer1"]);
                            A2 = Convert.ToString(ds.Tables[0].Rows[0]["Answer2"]);
                            A3 = Convert.ToString(ds.Tables[0].Rows[0]["Answer3"]);
                            A4 = Convert.ToString(ds.Tables[0].Rows[0]["Answer4"]);
                            Qname = Convert.ToString(ds.Tables[0].Rows[0]["Question"]);
                            Qhint = Convert.ToString(ds.Tables[0].Rows[0]["Qhint"]);
                            // crete change tblExamQuestion Status null //insert status =0 default
                            string sr = "insert into tblExamQuestion(Question_id,Question,Answer1,Answer2,Answer3,Answer4,Correct_Answer,LoginId,CompanyId,Status,Qhint ) values(" + id + ",'" + Qname + "','" + A1 + "','" + A2 + "','" + A3 + "','" + A4 + "','" + correctans + "','" + username + "'," + companyname + ", '" + Status + "','" + Qhint + "')";

                            ds = cc.ExecuteDataset(sr);
                            string ll = "select * from tblExamQuestion order by Question_id";
                            ds = cc.ExecuteDataset(ll);

                            jumpcnt++;
                            j++;
                        }
                        else
                        {
                            jumpcnt++;
                        }


                        string sr4 = "UPDATE tblQuestion SET Ischecked = 1 WHERE Question_id=" + id + "";
                        ds = cc.ExecuteDataset(sr4);
                        count1();
                        if (cnt == 0)
                        {
                            string strc = "UPDATE tblQuestion SET Ischecked = 0 WHERE QuestionLevel='" + st + "'";
                            ds = cc.ExecuteDataset(strc);

                        }

                    }
                    else
                    {
                        jumpcnt = 3;
                    }
                }

                while (jumpcnt > 2 && jumpcnt <= 4 && j < TQueNo)
                {
                    if (j < TQueNo)
                    {
                        String st = "Level2";
                        string str2 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id,Qhint from tblQuestion,tblTopic where tblQuestion.Topic_id=tblTopic.Topic_id and tblQuestion.Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " and QuestionLevel='" + st + "' and Ischecked=0";
                        ds = cc.ExecuteDataset(str2);
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            correctans = Convert.ToString(ds.Tables[0].Rows[0]["Correct_answer"]);
                            Session["a"] = correctans;
                            id = Convert.ToInt32(ds.Tables[0].Rows[0]["Question_id"]);
                            Session["b"] = id;
                            A1 = Convert.ToString(ds.Tables[0].Rows[0]["Answer1"]);
                            A2 = Convert.ToString(ds.Tables[0].Rows[0]["Answer2"]);
                            A3 = Convert.ToString(ds.Tables[0].Rows[0]["Answer3"]);
                            A4 = Convert.ToString(ds.Tables[0].Rows[0]["Answer4"]);
                            Qname = Convert.ToString(ds.Tables[0].Rows[0]["Question"]);
                            Qhint = Convert.ToString(ds.Tables[0].Rows[0]["Qhint"]);
                            //insert status =0 default
                            string sr = "insert into tblExamQuestion(Question_id,Question,Answer1,Answer2,Answer3,Answer4,Correct_Answer,LoginId,CompanyId,Status,Qhint) values(" + id + ",'" + Qname + "','" + A1 + "','" + A2 + "','" + A3 + "','" + A4 + "','" + correctans + "','" + username + "'," + companyname + ", '" + Status + "','" + Qhint + "')";

                            ds = cc.ExecuteDataset(sr);
                            string ll = "select * from tblExamQuestion order by Question_id";
                            ds = cc.ExecuteDataset(ll);

                            jumpcnt++;
                            j++;
                        }
                        else
                        {
                            jumpcnt++;
                        }

                        string st4 = "UPDATE tblQuestion SET Ischecked =1 WHERE Question_id=" + id + "";
                        ds = cc.ExecuteDataset(st4);

                        //count2();
                        //if (cnt1 == 0)
                        //{
                        //    string strc = "UPDATE tblQuestion SET Ischecked = 0 WHERE QuestionLevel='" + st + "'";
                        //    ds = cc.ExecuteDataset(strc);
                        //    break;
                        //}
                    }


                    else
                    {
                        jumpcnt = 5;
                    }
                }

                while (jumpcnt > 4 && jumpcnt <= 6 && j < TQueNo)
                {
                    if (j < TQueNo)
                    {
                        String st = "Level3";
                        string str2 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id,Qhint from tblQuestion,tblTopic where tblQuestion.Topic_id=tblTopic.Topic_id and tblQuestion.Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " and QuestionLevel='" + st + "' and Ischecked=0";

                        ds = cc.ExecuteDataset(str2);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            correctans = Convert.ToString(ds.Tables[0].Rows[0]["Correct_answer"]);
                            Session["a"] = correctans;
                            id = Convert.ToInt32(ds.Tables[0].Rows[0]["Question_id"]);
                            Session["b"] = id;
                            A1 = Convert.ToString(ds.Tables[0].Rows[0]["Answer1"]);
                            A2 = Convert.ToString(ds.Tables[0].Rows[0]["Answer2"]);
                            A3 = Convert.ToString(ds.Tables[0].Rows[0]["Answer3"]);
                            A4 = Convert.ToString(ds.Tables[0].Rows[0]["Answer4"]);
                            Qname = Convert.ToString(ds.Tables[0].Rows[0]["Question"]);
                            Qhint = Convert.ToString(ds.Tables[0].Rows[0]["Qhint"]);
                            string sr = "insert into tblExamQuestion(Question_id,Question,Answer1,Answer2,Answer3,Answer4,Correct_Answer,LoginId,CompanyId,Status,Qhint) values(" + id + ",'" + Qname + "','" + A1 + "','" + A2 + "','" + A3 + "','" + A4 + "','" + correctans + "','" + username + "'," + companyname + ", '" + Status + "','" + Qhint + "' )";

                            ds = cc.ExecuteDataset(sr);
                            string ll = "select * from tblExamQuestion order by Question_id";
                            ds = cc.ExecuteDataset(ll);

                            jumpcnt++;
                            j++;
                        }

                        else
                        {
                            jumpcnt++;
                        }
                        string str6 = "UPDATE tblQuestion SET Ischecked =1 WHERE Question_id=" + id + "";
                        ds = cc.ExecuteDataset(str6);

                        //count3();
                        //if (cnt2 == 0)
                        //{
                        //    string strt = "UPDATE tblQuestion SET Ischecked = 0 WHERE QuestionLevel='" + st + "'";
                        //    ds = cc.ExecuteDataset(strt);
                        //}


                    }
                    else
                    {
                        jumpcnt = 7;
                    }
                }
            }

            // string Sql1 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id from tblQuestion where Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " ";
            string Sql1 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id,Qhint from tblExamQuestion where LoginId='" + username + "' ";

            ds = cc.ExecuteDataset(Sql1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblQuestion.Text = Convert.ToString(ds.Tables[0].Rows[0]["Question"]);
                rdoSelectAnswer.Items[0].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer1"]);
                rdoSelectAnswer.Items[1].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer2"]);
                rdoSelectAnswer.Items[2].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer3"]);
                rdoSelectAnswer.Items[3].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer4"]);
                canswer = Convert.ToString(ds.Tables[0].Rows[0]["Correct_answer"]);
                tid = Convert.ToInt32(ds.Tables[0].Rows[0]["Question_id"]);

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

                Session["id"] = tid.ToString();
                Session["b"] = canswer.ToString();
                lblQno.Text = "1";
                questionCount();
                txtcurrentNo.Text = "1";
            }

            lblQno.Visible = true;
            lblQuestion.Visible = true;
            lblAns.Visible = true;
            rdoSelectAnswer.Visible = true;
            btnSubmit.Visible = true;
            btnPrev.Visible = true;
            btnNext.Visible = true;
            txtcurrentNo.Visible = true;
            lblOf.Visible = true;
            lblTotalQue.Visible = true;
            btnStart.Visible = false;

            lblCans.Visible = false;
            btnExit.Visible = true;
        }

        catch (Exception ex)
        {
            string msg = ex.Message;
        }

        finally
        {
        }
    }

    # region count question by level
    public void count1()
    {
        try
        {
            String st = "Level1";
            string sql = " select count(Question_id)as Question_id from tblQuestion,tblTopic where tblQuestion.Topic_id=tblTopic.Topic_id and tblQuestion.Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + "  and QuestionLevel='" + st + "'and Ischecked=0";

            DataSet ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cnt = Convert.ToInt32(ds.Tables[0].Rows[0]["Question_id"]);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }
    public void count2()
    {

        try
        {
            String st = "Level2";
            string sql = " select count(Question_id)as Question_id from tblQuestion,tblTopic where tblQuestion.Topic_id=tblTopic.Topic_id and tblQuestion.Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + "  and QuestionLevel='" + st + "'and Ischecked=0";
            DataSet ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cnt1 = Convert.ToInt32(ds.Tables[0].Rows[0]["Question_id"]);

            }

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }

    }
    public void count3()
    {

        try
        {
            String st = "Level3";
            string sql = " select count(Question_id)as Question_id from tblQuestion,tblTopic where tblQuestion.Topic_id=tblTopic.Topic_id and tblQuestion.Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + "  and QuestionLevel='" + st + "'and Ischecked=0";
            DataSet ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cnt2 = Convert.ToInt32(ds.Tables[0].Rows[0]["Question_id"]);

            }

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }
    # endregion
    public void questionCount()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
            try
            {
                txtQhint.Visible = false;
                string str8 = "update tblQuestion set [Ischecked]=false";
                DataSet ds = cc.ExecuteDataset(str8);


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

    protected void btnNext_Click(object sender, EventArgs e)
    {

        try
        {
            txtQhint.Visible = false;

            int status = 0;
            no = Convert.ToInt32(txtcurrentNo.Text);
            qno = Convert.ToInt32(lblQno.Text);
            no++;
            qno++;
            int gocount = Convert.ToInt32(lblTotalQue.Text);

            if (no > gocount)
            {
                flag = 1;
                lblCans.Visible = true;
                lblCans.Text = " No Question Found";
                lblCans.ForeColor = Color.Red;
            }
            if (flag == 0)
            {
                rdoSelectAnswer.Enabled = true;
                rdoSelectAnswer.ClearSelection();
                txtcurrentNo.Text = no.ToString();
                lblQno.Text = qno.ToString();


                int gotoid = 0;
                next = new int[gocount];
                cno = Convert.ToInt32(txtcurrentNo.Text);

                // cno--;


                // string str9 = "select Question_id from tblQuestion where  Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " ";
                string str9 = "select Question_id from tblExamQuestion where LoginId='" + username + "' ";


                DataSet ds = cc.ExecuteDataset(str9);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
                    {
                        next[n] = Convert.ToInt32(ds.Tables[0].Rows[p]["Question_id"]);
                        n++;
                    }
                }


                for (n = 0; n < gocount; n++)
                {
                    if (n == cno)
                    {
                        gotoid = next[n];
                    }
                }


                // string Sql1 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id from tblQuestion where Question_id='" + gotoid + "' and  Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " ";
                string Sql1 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id,Qhint from tblExamQuestion where Question_id='" + gotoid + "' and LoginId='" + username + "'  ";

                ds = cc.ExecuteDataset(Sql1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblQuestion.Text = Convert.ToString(ds.Tables[0].Rows[0]["Question"]);
                    rdoSelectAnswer.Items[0].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer1"]);
                    rdoSelectAnswer.Items[1].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer2"]);
                    rdoSelectAnswer.Items[2].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer3"]);
                    rdoSelectAnswer.Items[3].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer4"]);
                    canswer = Convert.ToString(ds.Tables[0].Rows[0]["Correct_answer"]);
                    tid = Convert.ToInt32(ds.Tables[0].Rows[0]["Question_id"]);

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

                    Session["id"] = tid.ToString();
                    Session["b"] = canswer.ToString();
                }
                /*******************************************************************************************************/

                // IN DATABASE NUUL ALLOW  

                rdoSelectAnswer.Enabled = false;
                string ste = "select Status from tblExamQuestion where Question_id=" + gotoid + " and LoginId='" + username + "'";
                ds = cc.ExecuteDataset(ste);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                }
                if (status == 0)
                {
                    rdoSelectAnswer.Enabled = true;
                }
                /**********************************************************************************************************/
                lblQno.Visible = true;
                lblQuestion.Visible = true;
                rdoSelectAnswer.Visible = true;
                lblAns.Visible = true;
                btnSubmit.Visible = true;
                lblCans.Text = "";
                txtcurrentNo.Visible = true;
                lblOf.Visible = true;
                lblTotalQue.Visible = true;


                //rdoSelectAnswer.Enabled = true;
            }

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {

        }

    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {

        try
        {
            txtQhint.Visible = false;
            rdoSelectAnswer.ClearSelection();
            no = Convert.ToInt32(txtcurrentNo.Text);
            int status = 0;
            qno = Convert.ToInt32(lblQno.Text);

            if (no == 1)
            {
                flag = 1;
                lblCans.Visible = true;
                lblCans.Text = "you cannot go back";
                lblCans.ForeColor = Color.Red;

            }
            int gocount = Convert.ToInt32(lblTotalQue.Text);
            if (flag == 0)
            {
                no--;
                qno--;
                txtcurrentNo.Text = no.ToString();
                lblQno.Text = qno.ToString();
                // string s = "select Question_id from tblExamQuestion";

                string s = "select Question_id from tblExamQuestion where LoginId='" + username + "' ";


                DataSet ds = cc.ExecuteDataset(s);
                int gotoid = 0;
                js = new int[gocount];
                int goct = Convert.ToInt32(txtcurrentNo.Text);
                goct--;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
                    {
                        js[i] = Convert.ToInt32(ds.Tables[0].Rows[p]["Question_id"]);
                        i++;
                    }

                }

                for (i = 0; i < gocount; i++)
                {
                    if (i == goct)
                    {
                        gotoid = js[i];
                    }
                }


                //string Sql1 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id from tblQuestion where Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " ";
                string Sql1 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id,Qhint from tblExamQuestion where Question_id='" + gotoid + "' and LoginId='" + username + "'  ";


                ds = cc.ExecuteDataset(Sql1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblQuestion.Text = Convert.ToString(ds.Tables[0].Rows[0]["Question"]);
                    rdoSelectAnswer.Items[0].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer1"]);
                    rdoSelectAnswer.Items[1].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer2"]);
                    rdoSelectAnswer.Items[2].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer3"]);
                    rdoSelectAnswer.Items[3].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer4"]);
                    canswer = Convert.ToString(ds.Tables[0].Rows[0]["Correct_answer"]);
                    tid = Convert.ToInt32(ds.Tables[0].Rows[0]["Question_id"]);
                    string qhint = Convert.ToString(ds.Tables[0].Rows[0]["Qhint"]);

                    if (qhint == "")
                    {
                        AnswerHint.Visible = false;
                    }
                    else
                    {
                        AnswerHint.Visible = true;
                        txtQhint.Text = Convert.ToString(ds.Tables[0].Rows[0]["Qhint"]);
                    } Session["id"] = tid.ToString();
                    Session["b"] = canswer.ToString();
                }
                /*******************************************************************************************************/
                rdoSelectAnswer.Enabled = false;
                string ste = "select Status from tblExamQuestion where Question_id=" + gotoid + "";

                ds = cc.ExecuteDataset(ste);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                }
                if (status == 0)
                {
                    rdoSelectAnswer.Enabled = true;
                }
                /**********************************************************************************************************/


                lblQno.Visible = true;
                lblQuestion.Visible = true;
                rdoSelectAnswer.Visible = true;
                lblAns.Visible = true;
                btnSubmit.Visible = true;
                lblCans.Text = "";
                txtcurrentNo.Visible = true;
                lblOf.Visible = true;
                lblTotalQue.Visible = true;


                // rdoSelectAnswer.Enabled = true;

            }
        }
        catch (Exception ex)
        {
            String msg = ex.Message;
        }
        finally
        {

        }

    }

    public int add(int l1, int l2, int l3)
    {

        try
        {
            addition = l1 + l2 + l3;
        }
        catch (Exception ex)
        {
        }
        return addition;


    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
            try
            {
                con.Open();
                // string stid = "Select LoginId from Login1 where UserName='" + username + "'";
                string stid = "Select LoginId from Login1 where LoginId='" + username + "'";

                DataSet ds = cc.ExecuteDataset(stid);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    studid = Convert.ToString(ds.Tables[0].Rows[0]["LoginId"]);
                }
                string st = " Select count(EQ_id) as EQ_id from tblExamQuestion where Status= 1 and LoginId='" + studid + "' and CompanyId='" + Session["companyid"].ToString() + "'";

                ds = cc.ExecuteDataset(st);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    correct = Convert.ToInt32(ds.Tables[0].Rows[0]["EQ_id"]);
                }

                string s = "insert into tblStudentStatus(LoginId,StudName,subject,Marks,Topic,Test_Name) values('" + studid + "','" + username + "','" + Session["tid"].ToString() + "'," + correct + ",'" + Session["tid"].ToString() + "','" + dddlExamname.SelectedValue + "')";
                ds = cc.ExecuteDataset(s);

                string str4 = "UPDATE tblStudentStatus set  Status=" + 1 + " WHERE LoginId='" + username + "'";
                ds = cc.ExecuteDataset(str4);



                Response.Redirect("Timeover.aspx");
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


    protected void txtcurrentNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int gotoid = 0, status = 0;
            int goct = Convert.ToInt32(txtcurrentNo.Text);
            int gocount = Convert.ToInt32(lblTotalQue.Text);
            if (goct > gocount || goct == 0)
            {
                flag = 1;
                lblQno.Visible = false;
                lblQuestion.Visible = false;
                rdoSelectAnswer.Visible = false;
                lblAns.Visible = false;
                btnSubmit.Visible = false;
                rdoSelectAnswer.ClearSelection();
                btnExit.Visible = true;
                btnExit.Enabled = true;
                lblCans.Text = "No Question found";
                lblCans.Visible = true;
                lblCans.ForeColor = Color.Red;
            }

            if (flag == 0)
            {
                lblQno.Text = txtcurrentNo.Text;
                string str9 = "select Question_id  from tblExamQuestion";
                DataSet ds = cc.ExecuteDataset(str9);

                jp = new int[gocount];
                goct--;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    jp[i] = Convert.ToInt32(ds.Tables[0].Rows[0][" Question_id"]);
                    i++;
                }

                for (i = 0; i < gocount; i++)
                {
                    if (i == goct)
                    {
                        gotoid = jp[i];
                    }
                }
                string Sql1 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id,Qhint from tblQuestion where Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " ";
                ds = cc.ExecuteDataset(Sql1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblQuestion.Text = Convert.ToString(ds.Tables[0].Rows[0]["Question"]);
                    rdoSelectAnswer.Items[0].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer1"]);
                    rdoSelectAnswer.Items[1].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer2"]);
                    rdoSelectAnswer.Items[2].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer3"]);
                    rdoSelectAnswer.Items[3].Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer4"]);
                    canswer = Convert.ToString(ds.Tables[0].Rows[0]["Correct_answer"]);
                    tid = Convert.ToInt32(ds.Tables[0].Rows[0]["Question_id"]);
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
                    Session["id"] = tid.ToString();
                    Session["b"] = canswer.ToString();
                }
                /*******************************************************************************************************/
                rdoSelectAnswer.Enabled = false;
                string ste = "select Status from tblExamQuestion where Question_id=" + gotoid + "";

                ds = cc.ExecuteDataset(ste);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                }
                if (status == 0)
                {
                    rdoSelectAnswer.Enabled = true;
                }
                /**********************************************************************************************************/
                lblQno.Visible = true;
                lblQuestion.Visible = true;
                rdoSelectAnswer.Visible = true;
                lblAns.Visible = true;
                btnSubmit.Visible = true;
                lblCans.Text = "";
                txtcurrentNo.Visible = true;
                lblOf.Visible = true;
                lblTotalQue.Visible = true;

            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {

        }
    }

    protected void Exit_Click(object sender, EventArgs e)
    {
        Session["username"] = "";
        Session.Abandon();
        Response.Redirect("Index.aspx");
    }
    protected void linkbtnDetail_Click(object sender, EventArgs e)
    {
        Response.Redirect("DetailResult.aspx");
    }

    protected void UpdateTimer_Tick(object sender, EventArgs e)
    {
        try
        {
            int minute = Convert.ToInt32(Label1.Text);
            int sec = Convert.ToInt32(Label4.Text);

            if (minute > 0)
            {
                if (minute < TQueNo)
                {
                    Label1.Text = "0" + minute;
                }
                if (sec > 0)
                {
                    sec--;
                    Label4.Text = sec.ToString();
                    if (sec < TQueNo)
                    {
                        Label4.Text = "0" + sec;
                    }
                }
                if (sec == 0)
                {
                    Label4.Text = "60";
                    minute--;
                    Label1.Text = minute.ToString();
                    if (minute < TQueNo)
                    {
                        Label1.Text = "0" + minute;
                    }
                }

            }
            else
                if (minute == 0 && sec > 0)
                {
                    sec--;
                    Label4.Text = sec.ToString();
                    if (sec < TQueNo)
                    {
                        Label4.Text = "0" + sec;
                    }

                }
                else
                {

                    Label3.Visible = false;
                    Label4.Visible = false;
                    Label1.Text = "Time over";


                    string stid = "Select LoginId from Login1 where UserName='" + username + "'";

                    DataSet ds = cc.ExecuteDataset(stid);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        studid = Convert.ToString(ds.Tables[0].Rows[0]["LoginId"]);
                    }
                    string st = " Select count(EQ_id) as EQ_id from tblExamQuestion where Status= 1 and LoginId='" + studid + "' and CompanyId='" + Session["companyid"].ToString() + "'";

                    ds = cc.ExecuteDataset(stid);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        correct = Convert.ToInt32(ds.Tables[0].Rows[0]["EQ_id"]);
                    }

                    string s = "insert into tblStudentStatus(LoginId,StudName,subject,Marks,Topic,Test_Name) values('" + studid + "','" + username + "','" + Session["tid"].ToString() + "'," + correct + ",'" + Session["tid"].ToString() + "','" + dddlExamname.SelectedValue + "')";
                    ds = cc.ExecuteDataset(s);

                    string str4 = "UPDATE tblStudentStatus set  Status=" + 1 + " WHERE LoginId='" + username + "'";
                    ds = cc.ExecuteDataset(str4);



                    Response.Redirect("Timeover.aspx");
                }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }

    }

   
    protected void lstboxSeltopic_SelectedIndexChanged(object sender, EventArgs e)
    {
        questionCount();
        clear_subject();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataSet ds;
        try
        {

            canswer = Session["b"].ToString();
            tid = Convert.ToInt32(Session["id"].ToString());
            if (rdoSelectAnswer.SelectedIndex != -1)
            {
                attcnt = Convert.ToInt32(lblatcnt.Text.ToString());
                attcnt++;
                lblatcnt.Text = Convert.ToString(attcnt);
                lblCans.Visible = false;
                string s = rdoSelectAnswer.SelectedItem.Text;
                if (s == canswer)
                {
                    string str4 = "UPDATE tblExamQuestion set Submitted='" + canswer + "', Status=" + 1 + " WHERE Question_id=" + tid + "";
                    ds = cc.ExecuteDataset(str4);

                    rdoSelectAnswer.Enabled = false;
                }
                else
                {
                    string str4 = "UPDATE tblExamQuestion set Submitted='" + rdoSelectAnswer.SelectedItem.Text + "', Status=" + 2 + " WHERE Question_id=" + tid + "";
                    ds = cc.ExecuteDataset(str4);
                    rdoSelectAnswer.Enabled = false;
                }
            }
            else
            {
                if (rdoSelectAnswer.Enabled == true)
                {
                    lblCans.Text = "Answer not Selected";
                    lblCans.Visible = true;
                    rdoSelectAnswer.Enabled = true;
                    lblCans.ForeColor = Color.Red;
                }
            }
        }
        catch (Exception ex)
        {
            String msg = ex.Message;
        }
        finally
        {

        }
    }
    protected void rdoLevelList_SelectedIndexChanged(object sender, EventArgs e)
    {
        questionCount();
        btnStart.Visible = true;

    }
    protected void dddlExamname_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))

            try
            {
                btnStart.Visible = true;

                string str9 = " select Subject_id from tblTestDefinition where  Test_ID=" + dddlExamname.SelectedValue + "";
                con.Open();
                DataSet ds = cc.ExecuteDataset(str9);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sub = Convert.ToString(ds.Tables[0].Rows[0]["Subject_id"]);
                    Session["sid"] = sub.ToString();
                }
                string str8 = " select Topic_id from tblTestDefinition where   Test_ID=" + dddlExamname.SelectedValue + "";

                SqlCommand cmd8 = new SqlCommand(str8, con);
                ds = cc.ExecuteDataset(str8);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    topic = Convert.ToString(ds.Tables[0].Rows[0]["Topic_id"]);
                    Session["tid"] = topic.ToString();
                }

                questionCount();
                clear_subject();
            }
            catch (Exception ex)
            { }
    }
    protected void AnswerHint_Click(object sender, EventArgs e)
    {
        txtQhint.Visible = true;
    }
}
