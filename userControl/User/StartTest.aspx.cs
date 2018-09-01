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

public partial class User_StartTest : System.Web.UI.Page
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

           
        companyid = Session["companyid"].ToString();
        if (Page.IsPostBack == false)
        {
            select_Subject();
            //clean();
        }
    }
    protected void btnStart_Click1(object sender, EventArgs e)
    {
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

                    //lblQue.Visible = false;
                    //lblQuestion.Visible = false;
                    //rdoAnswerlist.Visible = false;
                    //lblAnswer.Visible = false;
                    //btnSubmit.Visible = false;
                    //txtQhint.Visible = false;
                    //lblAnswer.Visible = false;
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
                    //clean();
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
    protected void cmbSelectlang_SelectedIndexChanged(object sender, EventArgs e)
    {
        String lan = cmbSelectlang.Text;
        //if (lan.CompareTo("Marathi") == 0 || lan.CompareTo("Hindi") == 0)
        //{
        //    lblQuestion.Font.Name = "Shivaji01";
        //    lblQue.Font.Name = "Shivaji01";
        //    rdoAnswerlist.Font.Name = "Shivaji01";
        //    txtGoto.Font.Name = "Shivaji01";
        //    TxtCount.Font.Name = "Shivaji01";

        //    lblQuestion.Font.Size = 16;
        //    lblQue.Font.Size = 14;
        //    rdoAnswerlist.Font.Size = 12;
        //    txtGoto.Font.Size = 14;
        //    TxtCount.Font.Size = 14;
        //}
        //if (lan.CompareTo("English") == 0)
        //{
        //    lblQuestion.Font.Name = "Arial";
        //    lblQue.Font.Size = 14;
        //    rdoAnswerlist.Font.Name = "Arial";
        //    txtQhint.Font.Name = "Arial";
        //    txtGoto.Font.Name = "Arial";
        //    TxtCount.Font.Name = "Arial";
        //    AnswerHint.Font.Name = "Arial";

        //    rdoAnswerlist.Font.Size = 10;
        //    lblQuestion.Font.Size = 10;
        //    lblQue.Font.Size = 10;
        //    TxtCount.Font.Size = 10;
        //    AnswerHint.Font.Size = 10;
        //}
       // questionCount();
       // TxtCount.Visible = false;
    }

}
