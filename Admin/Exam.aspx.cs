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
    String topic, sub, canswer, studid, username, companyname,abc;
    int cnt = 0, cnt1 = 0, cnt2 = 0, i, tid = 0, sid = 0, attcnt = 0, TQueNo;
    int id = 0,no=0,qno=0,cno,n=0;
    int[] next;
    int[] jp;
    int[] js;
   
    SqlDataReader d;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       
        try
        {


            username = Convert.ToString(Session["username"]);
            companyname = Convert.ToString(Session["companyid"]);
            
                if (Page.IsPostBack == false)
                {
                    select_subject();
                    //Label1.Text = "TQueNo";
                    //Label4.Text = "60";

                
                    
                }
                Set_Page_Level_Setting();
           
            //else
            //{
            //    Response.Redirect("Login.aspx");
            //}
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }
    protected void Set_Page_Level_Setting()
    {
        //set page heading
     
        Menu menulist = (Menu)Master.FindControl("MenuList");
        menulist.Visible = false;

        Label examname = (Label)Master.FindControl("Lable2");
 
    }


    private void select_subject()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
        try
        {
            string str1 = "select Subject_Name from tblSubject order by Subject_Name ";
            SqlCommand cmd = new SqlCommand(str1, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            lstSelectsub.Items.Clear();
            while (dr.Read())
            {
                lstSelectsub.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
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

   
    
    protected void btnStart_Click(object sender, EventArgs e)
    {
        Label5.Visible = true;
        sub = lstSelectsub.SelectedItem.Text;
        topic = lstboxSeltopic.SelectedItem.Text;
        int j = 0, l1 = 0, l2 = 0, l3 = 0;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
        try
        {  
            string str = " select Exam_Duration from tbltestDefinition where Exam_Subject='" + sub + "' and Exam_Topic='"+topic+"' ";
            SqlCommand cmd = new SqlCommand(str, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Label1.Text = (dr.GetValue(0).ToString());
            }
            dr.Close();
            con.Close();
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
            string ds = "0";
            string topicid = "0";
            string str1 = "select Subject_id from tblSubject where Subject_Name='" + sub + "' ";
            //string str1 = " Select temp_sub from tblMaxQuestions,tblTopic where tblTopic.Topic_id=tblMaxQuestions.Topic_id and Topic_Name=" + Convert.ToInt32(Session["tid"]).ToString() + "";
            SqlCommand cmd1 = new SqlCommand(str1, con);
            con.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                sid = (dr1.GetValue(0).ToString());
            }
            dr.Close();
            dr1.Close();

            string Sql = "select Topic_id from tblTopic where Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " ";
           SqlCommand Cm = new SqlCommand(Sql, con);
           SqlDataReader DR = Cm.ExecuteReader();
            while (DR.Read())
            {
                topicid = (DR.GetValue(0).ToString());
            }
           DR.Close();

           
           string strdel = "delete from tblExamQuestion where LoginId='" +username + " '";
           SqlCommand cmddel = new SqlCommand(strdel, con);
           cmddel.ExecuteNonQuery();
           dr1.Close();
           //change- String s1 = "Select temp_sub from tblMaxQuestions,tblSubject where tblSubject.Subject_id=tblMaxQuestions.Subject_id and Subject_Name='" + sub + "'";
           String s1 = "Select temp_topic from tblMaxQuestions,tblTopic where tblTopic.Topic_id=tblMaxQuestions.Topic_id and Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + "";
           
            SqlCommand c = new SqlCommand(s1, con);
            d = c.ExecuteReader();
            if (d.Read())
            {
                ds = (d.GetValue(0).ToString());
                if (sid.CompareTo(ds) == 0)
                {
                    flag = 1;
                    d.Close();
                    count1();
                    count2();
                    count3();
                    string str0 = "update tblMaxQuestions set Level1=" + cnt + ",Level2=" + cnt1 + ",Level3=" + cnt2 + " where Subject_id=" + ds + "  ";
                    SqlCommand cmd0 = new SqlCommand(str0, con);
                    cmd0.ExecuteNonQuery();
                    string ll = "select * from tblExamQuestion order by Question_id";
                    SqlCommand cll = new SqlCommand(ll, con);
                    cll.ExecuteNonQuery();
                }
            }
            d.Close();

            if (flag == 0)
            {
                count1();
                count2();
                count3();
                string str5 = " insert into tblMaxQuestions(Subject_id,Level1,Level2,Level3,temp_sub,Topic_id,temp_topic) values(" + sid + "," + cnt + "," + cnt1 + "," + cnt2 + "," + sid + "," + topicid + "," + topicid + ")";
                SqlCommand cmd5 = new SqlCommand(str5, con);
                cmd5.ExecuteNonQuery();
                string ll = "select * from tblExamQuestion order by Question_id";
                SqlCommand cll = new SqlCommand(ll, con);
                cll.ExecuteNonQuery();
            }
            con.Close();
            sub = lstSelectsub.SelectedItem.Text;

            String correctans;
            
            con.Open();

            
            string str9 = "select Level1,Level2,Level3 from tblMaxQuestions where Subject_id=" + sid + "and Topic_id=" +topicid+"  ";
            SqlCommand cmd9 = new SqlCommand(str9, con);
            SqlDataReader dr9 = cmd9.ExecuteReader();
            while (dr9.Read())
            {
                l1 = Convert.ToInt32(dr9.GetValue(0).ToString());
                l2 = Convert.ToInt32(dr9.GetValue(1).ToString());
                l3 = Convert.ToInt32(dr9.GetValue(2).ToString());
            }


            dr9.Close();

            string sq = "select count(Question_id) from tblQuestion where  Topic_id=" + topicid + " and Subject_id=" + sid + " ";
            SqlCommand cm = new SqlCommand(sq, con);
            SqlDataReader d3 = cm.ExecuteReader();
            while (d3.Read())
            {
              TQueNo = Convert.ToInt32(d3.GetValue(0).ToString());
            }
            d3.Close();

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
                        string str2 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id from tblQuestion,tblTopic where tblQuestion.Topic_id=tblTopic.Topic_id and Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " and QuestionLevel='" + st + "' and Ischecked=0";
                       
                        
                        SqlCommand cmd2 = new SqlCommand(str2, con);
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                        {
                            correctans = dr2.GetValue(5).ToString();
                            id = Convert.ToInt32(dr2.GetValue(6).ToString());
                            Session["a"] = correctans;
                            Session["b"] = id;
                            string sr = "insert into tblExamQuestion(Question_id,Question,Answer1,Answer2,Answer3,Answer4,Correct_Answer,LoginId,CompanyId) values(" + id + ",'" + dr2.GetValue(0).ToString() + "','" + dr2.GetValue(1).ToString() + "','" + dr2.GetValue(2).ToString() + "','" + dr2.GetValue(3).ToString() + "','" + dr2.GetValue(4).ToString() + "','" + correctans + "','" + username + "',"+companyname+" )";
                            dr2.Close();
                            SqlCommand cr = new SqlCommand(sr, con);
                            cr.ExecuteNonQuery();
                            string ll = "select * from tblExamQuestion order by Question_id";
                            SqlCommand cll = new SqlCommand(ll, con);
                            cll.ExecuteNonQuery();
                            jumpcnt++;
                            j++;
                        }
                        else
                        {
                            jumpcnt++;
                        }
                        dr2.Close();

                        string str4 = "UPDATE tblQuestion SET Ischecked = 1 WHERE Question_id=" + id + "";
                        SqlCommand cmd4 = new SqlCommand(str4, con);

                        cmd4.ExecuteNonQuery();
                        count1();
                        if (cnt == 0)
                        {
                            string strc = "UPDATE tblQuestion SET Ischecked = 0 WHERE QuestionLevel='" + st + "'";
                            SqlCommand cmdc = new SqlCommand(strc, con);
                            cmdc.ExecuteNonQuery();
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
                       // string str2 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id from tblQuestion,tblSubject where tblQuestion.Subject_id=tblSubject.Subject_id and Subject_Name='" + sub + "' and QuestionLevel='" + st + "' and Ischecked=0";
                        string str2 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id from tblQuestion,tblTopic where tblQuestion.Topic_id=tblTopic.Topic_id and Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " and QuestionLevel='" + st + "' and Ischecked=0";
                       
                        SqlCommand cmd2 = new SqlCommand(str2, con);
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                        {
                            
                            correctans = dr2.GetValue(5).ToString();
                            id = Convert.ToInt32(dr2.GetValue(6).ToString());
                            Session["a"] = correctans;
                            Session["b"] = id;
                            string sr = "insert into tblExamQuestion(Question_id,Question,Answer1,Answer2,Answer3,Answer4,Correct_Answer,LoginId,CompanyId) values(" + id + ",'" + dr2.GetValue(0).ToString() + "','" + dr2.GetValue(1).ToString() + "','" + dr2.GetValue(2).ToString() + "','" + dr2.GetValue(3).ToString() + "','" + dr2.GetValue(4).ToString() + "','" + correctans + "','" + username + "'," + companyname + ")";
                            dr2.Close();
                            SqlCommand cr = new SqlCommand(sr, con);
                            cr.ExecuteNonQuery();
                            string ll = "select * from tblExamQuestion order by Question_id";
                            SqlCommand cll = new SqlCommand(ll, con);
                            cll.ExecuteNonQuery();
                            jumpcnt++;
                            j++;
                        }
                        else
                        {
                            jumpcnt++;
                        }
                        dr2.Close();
                        string str4 = "UPDATE tblQuestion SET Ischecked =1 WHERE Question_id=" + id + "";
                        SqlCommand cmd4 = new SqlCommand(str4, con);

                        cmd4.ExecuteNonQuery();


                        count2();
                        if (cnt1 == 0)
                        {
                            string strs = "UPDATE tblQuestion SET Ischecked = 0 WHERE QuestionLevel='" + st + "'";
                            SqlCommand cmds = new SqlCommand(strs, con);

                            cmds.ExecuteNonQuery();
                        }

                       
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
                       // string str2 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id from tblQuestion,tblSubject where tblQuestion.Subject_id=tblSubject.Subject_id and Subject_Name='" + sub + "' and QuestionLevel='" + st + "' and Ischecked=0";
                        string str2 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id from tblQuestion,tblTopic where tblQuestion.Topic_id=tblTopic.Topic_id and Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " and QuestionLevel='" + st + "' and Ischecked=0";
                       
                        
                        SqlCommand cmd2 = new SqlCommand(str2, con);
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                        {
                            correctans = dr2.GetValue(5).ToString();
                            id = Convert.ToInt32(dr2.GetValue(6).ToString());
                            Session["a"] = correctans;
                            Session["b"] = id;
                            string sr = "insert into tblExamQuestion(Question_id,Question,Answer1,Answer2,Answer3,Answer4,Correct_Answer,LoginId,CompanyId) values(" + id + ",'" + dr2.GetValue(0).ToString() + "','" + dr2.GetValue(1).ToString() + "','" + dr2.GetValue(2).ToString() + "','" + dr2.GetValue(3).ToString() + "','" + dr2.GetValue(4).ToString() + "','" + correctans + "','" + username + "'," + companyname + ")";
                            dr2.Close();
                            SqlCommand cr = new SqlCommand(sr, con);
                            cr.ExecuteNonQuery();
                            string ll = "select * from tblExamQuestion order by Question_id";
                            SqlCommand cll = new SqlCommand(ll, con);
                            cll.ExecuteNonQuery();
                            jumpcnt++;
                            j++;
                        }
                           
                        else
                        {
                            jumpcnt++;
                        }
                        dr2.Close();
                        string str4 = "UPDATE tblQuestion SET Ischecked =1 WHERE Question_id=" + id + "";
                        SqlCommand cmd4 = new SqlCommand(str4, con);

                        cmd4.ExecuteNonQuery();

                        count3();
                        if (cnt2 == 0)
                        {
                            string strt = "UPDATE tblQuestion SET Ischecked = 0 WHERE QuestionLevel='" + st + "'";
                            SqlCommand cmdt = new SqlCommand(strt, con);

                            cmdt.ExecuteNonQuery();
                        }

                       
                    }
                    else
                    {
                        jumpcnt = 7;
                    }
                }



               
            }
            /************To Display a question******************/

          //  string str3 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_Answer,Question_id from tblExamQuestion ";
           string Sql1 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id from tblQuestion where Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " ";

           // string Sql1 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_answer,Question_id from tblQuestion where Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " ";

            SqlCommand cmd3 = new SqlCommand(Sql1, con);
            SqlDataReader dr4 = cmd3.ExecuteReader();


          

            if (dr4.Read())
            {
                lblQuestion.Text = dr4.GetValue(0).ToString();
                rdoSelectAnswer.Items[0].Text = dr4.GetValue(1).ToString();
                rdoSelectAnswer.Items[1].Text = dr4.GetValue(2).ToString();
                rdoSelectAnswer.Items[2].Text = dr4.GetValue(3).ToString();
                rdoSelectAnswer.Items[3].Text = dr4.GetValue(4).ToString();
                canswer = dr4.GetValue(5).ToString();
                tid = Convert.ToInt32(dr4.GetValue(6).ToString());
                Session["id"] = tid.ToString();
                Session["b"] = canswer.ToString();
                //}
                //i++;
                lblQno.Text = "1";
                dr4.Close();
                questionCount();
                txtcurrentNo.Text = "1";
               // lblTotalQue.Text = quecnt.ToString();

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
            con.Close();
        }
  }

    public void count1()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
        try
        {

            sub = lstSelectsub.SelectedItem.Text;
            topic = lstboxSeltopic.SelectedItem.Text;
            String st = "Level1";
           // string str2 = "select count(Question_id) from tblQuestion,tblSubject where tblQuestion.Subject_id=tblSubject.Subject_id and Subject_Name='" + sub + "' and QuestionLevel='" + st + "' and Ischecked=0";
           // string sql = "select count((Question_id) from tblQuestion,tblSubject,tblTopic where tblQuestion.Subject_id=tblSubject.Subject_id and Subject_Name='" + sub + "' and  tblQuestion.Topic_id=tblTopic.Topic_id and Topic_Name=" + Convert.ToInt32(Session["tid"]).ToString() + " and QuestionLevel='" + st + "' and Ischecked=0";
            string sql = " select count(Question_id) from tblQuestion,tblTopic where tblQuestion.Topic_id=tblTopic.Topic_id and Topic_id='" + topic + "' and QuestionLevel='" + st + "'and Ischecked=0";

            SqlCommand cmd2 = new SqlCommand(sql, con);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                cnt = Convert.ToInt32(dr2.GetValue(0).ToString());
            }
            dr2.Close();
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }

    public void count2()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
        try
        {
            sub = lstSelectsub.SelectedItem.Text;
            sub = lstboxSeltopic.SelectedItem.Text;
            String st1 = "Level2";
           // string str3 = "select count(Question_id) from tblQuestion,tblSubject where tblQuestion.Subject_id=tblSubject.Subject_id and Subject_Name='" + sub + "' and QuestionLevel='" + st1 + "' and Ischecked=0";
           // string sql = "select count((Question_id) from tblQuestion,tblSubject,tblTopic where tblQuestion.Subject_id=tblSubject.Subject_id and Subject_Name='" + sub + "' and  tblQuestion.Topic_id=tblTopic.Topic_id and Topic_Name=" + Convert.ToInt32(Session["tid"]).ToString() + " and QuestionLevel='" + st1 + "' and Ischecked=0";
            string sql = " select count(Question_id) from tblQuestion,tblTopic where tblQuestion.Topic_id=tblTopic.Topic_id and Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " and QuestionLevel='" + st1 + "'and Ischecked=0";

            SqlCommand cmd3 = new SqlCommand(sql, con);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                cnt1 = Convert.ToInt32(dr3.GetValue(0).ToString());
            }
            dr3.Close();
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }

    }

    public void count3()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
        try
        {
            sub = lstSelectsub.SelectedItem.Text;
            topic = lstboxSeltopic.SelectedItem.Text;
            String st2 = "Level3";
           // string str4 = "select count(Question_id) from tblQuestion,tblSubject where tblQuestion.Subject_id=tblSubject.Subject_id and Subject_Name='" + sub + "' and QuestionLevel='" + st2 + "' and Ischecked=0";
           // string sql = "select count((Question_id) from tblQuestion,tblSubject,tblTopic where tblQuestion.Subject_id=tblSubject.Subject_id and Subject_Name='" + sub + "' and  tblQuestion.Topic_id=tblTopic.Topic_id and Topic_Name=" + Convert.ToInt32(Session["tid"]).ToString() + " and QuestionLevel='" + st2 + "' and Ischecked=0";
            string sql = " select count(Question_id) from tblQuestion,tblTopic where tblQuestion.Topic_id=tblTopic.Topic_id and Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " and QuestionLevel='" + st2 + "'and Ischecked=0";


            SqlCommand cmd4 = new SqlCommand(sql, con);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                cnt2 = Convert.ToInt32(dr4.GetValue(0).ToString());
            }
            dr4.Close();
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
        try
        {

            int status = 0;
            no = Convert.ToInt32(txtcurrentNo.Text);
            qno = Convert.ToInt32(lblQno.Text);
            no++;
            qno++;
            con.Open();
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
               // string str9 = "select Question_id from tblExamQuestion";

                string str9 = "select Question_id from tblQuestion where  Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " ";
               

                SqlCommand cmd9 = new SqlCommand(str9, con);

                SqlDataReader dr9 = cmd9.ExecuteReader();
                int gotoid = 0;
                next = new int[gocount];
                cno = Convert.ToInt32(txtcurrentNo.Text);
                cno--;
                while (dr9.Read())
                {
                    next[n] = Convert.ToInt32(dr9.GetValue(0).ToString());
                    
                    n++;
                }
                dr9.Close();
                for (n = 0; n < gocount; n++)
                {
                    if (n == cno)
                    {
                        gotoid = next[n];
                    }
                }
                string str8 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_Answer,Question_id from tblExamQuestion where Question_id=" + gotoid + "";
                SqlCommand cmd8 = new SqlCommand(str8, con);
                SqlDataReader dr8 = cmd8.ExecuteReader();
                while (dr8.Read())
                {
                    lblQuestion.Text = dr8.GetValue(0).ToString();
                    rdoSelectAnswer.Items[0].Text = dr8.GetValue(1).ToString();
                    rdoSelectAnswer.Items[1].Text = dr8.GetValue(2).ToString();
                    rdoSelectAnswer.Items[2].Text = dr8.GetValue(3).ToString();
                    rdoSelectAnswer.Items[3].Text = dr8.GetValue(4).ToString();
                    canswer = dr8.GetValue(5).ToString();
                    tid = Convert.ToInt32(dr8.GetValue(6).ToString());
                    Session["id"] = tid.ToString();
                    Session["b"] = canswer.ToString();
                }
                dr8.Close();
                /*******************************************************************************************************/
                rdoSelectAnswer.Enabled = false;
                string ste = "select Status from tblExamQuestion where Question_id=" + gotoid + "";
                SqlCommand cme = new SqlCommand(ste, con);
                SqlDataReader de = cme.ExecuteReader();
                while (de.Read())
                {
                    status = Convert.ToInt32(de.GetValue(0).ToString());
                }
                de.Close();
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
            con.Close();
        }

   }

  

    public void questionCount()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
        try
        {

           // string level = rdoLevelList.SelectedItem.Text;
            //  lang = cmbSelectlang.Text;
            int selIndex = lstboxSeltopic.SelectedIndex;
            string topic = lstboxSeltopic.SelectedItem.Text;
            string subject = lstSelectsub.SelectedItem.Text;
            string str1 = "select Subject_id from tblSubject where Subject_Name='" + subject + "' ";
            //string str1 = " Select temp_sub from tblMaxQuestions,tblTopic where tblTopic.Topic_id=tblMaxQuestions.Topic_id and Topic_Name=" + Convert.ToInt32(Session["tid"]).ToString() + "";
            SqlCommand cmd = new SqlCommand(str1, con);
            con.Open();
            SqlDataReader drs = cmd.ExecuteReader();
            while (drs.Read())
            {
                sid = Convert.ToInt32(drs.GetValue(0).ToString());
            }
            drs.Close();




            string str3 = "select Topic_id from tblTopic where Topic_id=" + Convert.ToInt32(Session["tid"]).ToString() + " ";
            SqlCommand cmd1 = new SqlCommand(str3, con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                id = Convert.ToInt32(dr1.GetValue(0).ToString());
                Session["tid"] = id.ToString();
            }
            dr1.Close();




            string str2 = "select count(Question_id) from tblQuestion where Subject_id=" + sid + " and Topic_id=" + id + " ";
            SqlCommand cmd2 = new SqlCommand(str2, con);
            
            SqlDataReader dr3 = cmd2.ExecuteReader();
            while (dr3.Read())
            {
                cnt = Convert.ToInt32(dr3.GetValue(0).ToString());
            }
            dr3.Close();
            lblTotalQue.Text = cnt.ToString();
            txtcurrentNo.Text = "";
            rdoSelectAnswer.Visible = false;
            lblQuestion.Visible = false;
            lblQuestion.Visible = false;
            lblAns.Visible = false;
            btnSubmit.Visible = false;
            btnStart.Visible = true;
            btnExit.Visible = false;
            lblCans.Visible = false;
            lblQno.Visible = false;
            lblTotalQue.Visible = true;
            
            string str8 = "update tblQuestion set [Ischecked]=false";
            con.Open();
            SqlCommand cmd8 = new SqlCommand(str8, con);
            cmd8.ExecuteNonQuery();


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

    protected void btnExit_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
        try
        {
            con.Open();
            string st = "Select count(EQ_id) from tblExamQuestion where Status=" + 1 + "";
            SqlCommand cm = new SqlCommand(st, con);
            SqlDataReader d = cm.ExecuteReader();
            d.Read();
            int correct = Convert.ToInt32(d.GetValue(0).ToString());
            d.Close();
            sub = lstSelectsub.SelectedItem.Text;
            topic = lstboxSeltopic.SelectedItem.Text;


            string stid = "Select LoginId from Login1 where UserName='" + username + "'";

            SqlCommand cmid = new SqlCommand(stid, con);
            SqlDataReader did = cmid.ExecuteReader();
            while (did.Read())
            {
                studid = Convert.ToString(did.GetValue(0).ToString());
            }
            did.Close();
            string s = "insert into tblStudentStatus(StudentLoginId,StudName,subject,Marks,Topic) values('" + studid + "','" + username + "','" + sub + "'," + correct + "," + Convert.ToInt32(Session["tid"]).ToString() + ")";
            SqlCommand c = new SqlCommand(s, con);
            c.ExecuteNonQuery();



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
    protected void lstSelectsub_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
        try
        {
            string subselected = lstSelectsub.Text;
            string str1 = "select Topic_Name from tblTopic,tblSubject where tblSubject.Subject_id=tblTopic.Subject_id and Subject_Name='" + subselected + "'Order  by Topic_Name ";
            SqlCommand cmd = new SqlCommand(str1, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            lstboxSeltopic.Items.Clear();
            while (dr.Read())
            {
                lstboxSeltopic.Items.Add(dr.GetValue(0).ToString());
            }
            lstboxSeltopic.Focus();
            dr.Close();
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {
            con.Close();
        }

        btnStart.Visible = true;
   
    }
    protected void txtcurrentNo_TextChanged(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
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
                con.Open();
                string str9 = "select Question_id from tblExamQuestion";
                SqlCommand cmd9 = new SqlCommand(str9, con);
                SqlDataReader dr9 = cmd9.ExecuteReader();

                //********************************************************
                jp = new int[gocount];
                goct--;
                while (dr9.Read())
                {
                    jp[i] = Convert.ToInt32(dr9.GetValue(0).ToString());
                    i++;
                }
                dr9.Close();
                for (i = 0; i < gocount; i++)
                {
                    if (i == goct)
                    {
                        gotoid = jp[i];
                    }
                }
                string str8 = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_Answer,Question_id from tblExamQuestion where Question_id=" + gotoid + "";
                SqlCommand cmd8 = new SqlCommand(str8, con);
                SqlDataReader dr8 = cmd8.ExecuteReader();
                while (dr8.Read())
                {
                    lblQuestion.Text = dr8.GetValue(0).ToString();
                    rdoSelectAnswer.Items[0].Text = dr8.GetValue(1).ToString();
                    rdoSelectAnswer.Items[1].Text = dr8.GetValue(2).ToString();
                    rdoSelectAnswer.Items[2].Text = dr8.GetValue(3).ToString();
                    rdoSelectAnswer.Items[3].Text = dr8.GetValue(4).ToString();
                    canswer = dr8.GetValue(5).ToString();
                    tid = Convert.ToInt32(dr8.GetValue(6).ToString());
                    Session["id"] = tid.ToString();
                    Session["b"] = canswer.ToString();
                }
                dr8.Close();
                /*******************************************************************************************************/
                rdoSelectAnswer.Enabled = false;
                string ste = "select Status from tblExamQuestion where Question_id=" + gotoid + "";
                SqlCommand cme = new SqlCommand(ste, con);
                SqlDataReader de = cme.ExecuteReader();
                while (de.Read())
                {
                    status = Convert.ToInt32(de.GetValue(0).ToString());
                }
                if (status == 0)
                {
                    rdoSelectAnswer.Enabled = true;
                }
                de.Close();
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
            con.Close();
        }
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
        try
        {
            rdoSelectAnswer.ClearSelection();
            no = Convert.ToInt32(txtcurrentNo.Text);
            int status = 0;
            qno = Convert.ToInt32(lblQno.Text);

            if (no == 1)
            {
                flag = 1;
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
                string s = "select Question_id from tblExamQuestion";
                SqlCommand c = new SqlCommand(s, con);
                con.Open();
                SqlDataReader drs = c.ExecuteReader();
                int gotoid = 0;
                js = new int[gocount];
                int goct = Convert.ToInt32(txtcurrentNo.Text);
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
                string st = "select Question,Answer1,Answer2,Answer3,Answer4,Correct_Answer,Question_id from tblExamQuestion where Question_id=" + gotoid + "";
                SqlCommand cm = new SqlCommand(st, con);

                SqlDataReader d = cm.ExecuteReader();

                while (d.Read())
                {
                    lblQuestion.Text = d.GetValue(0).ToString();
                    rdoSelectAnswer.Items[0].Text = d.GetValue(1).ToString();
                    rdoSelectAnswer.Items[1].Text = d.GetValue(2).ToString();
                    rdoSelectAnswer.Items[2].Text = d.GetValue(3).ToString();
                    rdoSelectAnswer.Items[3].Text = d.GetValue(4).ToString();
                    canswer = d.GetValue(5).ToString();
                    tid = Convert.ToInt32(d.GetValue(6).ToString());
                    Session["id"] = tid.ToString();
                    Session["b"] = canswer.ToString();



                }
                d.Close();
                /*******************************************************************************************************/

                rdoSelectAnswer.Enabled = false;
                string ste = "select Status from tblExamQuestion where Question_id=" + gotoid + "";
                SqlCommand cme = new SqlCommand(ste, con);

                SqlDataReader de = cme.ExecuteReader();
                while (de.Read())
                {
                    status = Convert.ToInt32(de.GetValue(0).ToString());
                }
                de.Close();
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
            String msg = ex.Message;
        }
        finally
        {
            con.Close();
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
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
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

                    sub = lstSelectsub.SelectedItem.Text;
                    sub = lstboxSeltopic.SelectedItem.Text;
                    con.Open();
                    string st = "Select count(EQ_id) from tblExamQuestion where Status=" + 1 + "";
                    SqlCommand cm = new SqlCommand(st, con);
                    SqlDataReader d = cm.ExecuteReader();
                    d.Read();
                    int correct = Convert.ToInt32(d.GetValue(0).ToString());
                    d.Close();

                    string stid = "Select LoginId from Login1 where UserName='" + username + "'";

                    SqlCommand cmid = new SqlCommand(stid, con);
                    SqlDataReader did = cmid.ExecuteReader();
                    while (did.Read())
                    {
                        studid = Convert.ToString(did.GetValue(0).ToString());
                    }
                    did.Close();
                    string s = "insert into tblStudentStatus(StudentLoginId,StudName,subject,Marks,Topic) values('" + studid + "','" + username + "','" + sub + "'," + correct + "," + Convert.ToInt32(Session["tid"]).ToString() + ")";
                    SqlCommand c = new SqlCommand(s, con);
                    c.ExecuteNonQuery();

                    Response.Redirect("Timeover.aspx");
                }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    
    }

    protected void rdoSelectAnswer_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstSelectsub.SelectedIndex == 0)
        {
        
        }
    }
    protected void lstboxSeltopic_SelectedIndexChanged(object sender, EventArgs e)
    {
        questionCount();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
        try
        {

            canswer = Session["b"].ToString();
            tid = Convert.ToInt32(Session["id"].ToString());
            con.Open();
            if (rdoSelectAnswer.SelectedIndex != -1)
            {
                attcnt = Convert.ToInt32(lblatcnt.Text.ToString());
                attcnt++;
                lblatcnt.Text = Convert.ToString(attcnt);
                lblCans.Visible = false;
                string s = rdoSelectAnswer.SelectedItem.Text;
                if (s == canswer)
                //if (rdoSelectAnswer.SelectedItem.Text.CompareTo(canswer) == 1)
                {
                    string str4 = "UPDATE tblExamQuestion set Submitted='" + canswer + "', Status=" + 1 + " WHERE Question_id=" + tid + "";
                    SqlCommand cmd4 = new SqlCommand(str4, con);
                    cmd4.ExecuteNonQuery();
                    rdoSelectAnswer.Enabled = false;
                }
                else
                {
                    string str4 = "UPDATE tblExamQuestion set Submitted='" + rdoSelectAnswer.SelectedItem.Text + "', Status=" + 2 + " WHERE Question_id=" + tid + "";
                    SqlCommand cmd4 = new SqlCommand(str4, con);
                    cmd4.ExecuteNonQuery();
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
            con.Close();
        }
    }
    protected void rdoLevelList_SelectedIndexChanged(object sender, EventArgs e)
    {
        questionCount();
        btnStart.Visible=true;
   
    }
}
