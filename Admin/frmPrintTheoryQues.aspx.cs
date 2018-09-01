using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;



public partial class frmPrintTheoryQues : System.Web.UI.Page
{
    string Sql;
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        string TestID = Convert.ToString(Request.QueryString["Id"]);

        if (!IsPostBack)
        {
            data();
            loadTest(TestID);
            loadCollegeName();
        }
    }

    public void loadCollegeName()
    {
        int companyId = Convert.ToInt32(Session["CompanyId"]);
        Sql = "SELECT DisplayName FROM CompanyMaster WHERE CompanyId=" + companyId + " ";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCollegeName.Text = Convert.ToString(ds.Tables[0].Rows[0]["DisplayName"]);
        }
    }

    public void loadTest(string TestID)
    {
        try
        {
            Sql = "SELECT * FROM tblTestDefinition WHERE Test_ID='" + TestID + "' ";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTestName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Exam_name"]);
                string duration = Convert.ToString(ds.Tables[0].Rows[0]["Exam_Duration"]);
                lblExamDurration.Text = duration + " Min";

                lblTotalQue.Text = Convert.ToString(ds.Tables[0].Rows[0]["MarkCorrA"]);
            }
        }
        catch
        {
        }
    }

    Button btnMove = null;

    void data()
    {
        try
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            //string s11 = "tblT" + Convert.ToString(Session["CompanyId"]);

            string s11 = "tblT5167";

            Session["QuestionID1"] = null;
            Session["TheoryId1"] = null;
            Session["InstruID"] = null;
            Session["ID2"] = null;
            int g = 0, h = 0, m = 0;

            //*****************instru***************
            string sql6 = "SELECT * FROM tblInstructionTheory WHERE  defaultFlag='1' AND LoginId='" + Convert.ToString(Session["LoginId"]) + "' AND TestId=" + Convert.ToString(Session["TestID"]) + " ";
            DataSet ds6 = cc.ExecuteDataset(sql6);
            if (ds6.Tables[0].Rows.Count > 0)
            {
                //if user add defualt instruction 
                string sql7 = "SELECT * FROM tblInstructionTheory WHERE  defaultFlag='1' AND LoginId='1' AND TestId='1' ";
                DataSet ds7 = cc.ExecuteDataset(sql7);
                if (ds7.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds7.Tables[0].Rows.Count; i++)
                    {
                        string InstruID1 = Convert.ToString(ds7.Tables[0].Rows[i]["ID"]);
                        Session["InstruID"] = Session["InstruID"] + InstruID1 + ",";
                        Control ctl1 = LoadControl("../userControl/userinstruction.ascx");
                        Session["ID2"] = -1;
                        ctl1.ID = "UmC" + m;
                        m = m + 1;
                        td1.Controls.Add(ctl1); //td1 is div 
                    }
                }
            }
            else
            {

                string sql8 = "SELECT ID,InstrucIDSet  FROM tblInstructionTheory WHERE  LoginId='" + Convert.ToString(Session["LoginId"]) + "' AND TestId=" + Convert.ToString(Session["TestID"]) + " ";
                DataSet ds8 = cc.ExecuteDataset(sql8);

                string ac = "";
                for (int j = 0; j < ds8.Tables[0].Rows.Count; j++)
                {
                    foreach (string s in ac.Split(','))
                    {
                        if (Convert.ToString(ds8.Tables[0].Rows[j]["ID"]) != s && Convert.ToString(ds8.Tables[0].Rows[j]["InstrucIDSet"]) == "")
                        {
                            ac += Convert.ToString(ds8.Tables[0].Rows[j]["ID"]) + ",";
                            break;
                        }
                    }

                    string[] IdSet = (Convert.ToString(ds8.Tables[0].Rows[j]["InstrucIDSet"])).Split(',');
                    for (int i = 0; i < IdSet.Count(); i++)
                    {
                        foreach (string s in ac.Split(','))
                        {
                            if (Convert.ToString(IdSet[i]) != s && IdSet[i] != "")
                            {
                                ac += Convert.ToString(IdSet[i]) + ",";
                                break;
                            }
                        }
                    }
                }
                ac = ac.Substring(0, ac.Length - 1);

                if (ds8.Tables[0].Rows.Count > 0)
                {
                    string[] acsplit = ac.Split(',');

                    for (int i = 0; i < acsplit.Length; i++)
                    {
                        string InstruID1 = Convert.ToString(acsplit[i]);
                        Session["InstruID"] = Session["InstruID"] + InstruID1 + ",";
                        Control ctl1 = LoadControl("../userControl/userinstruction.ascx");

                        Session["ID2"] = -1;
                        ctl1.ID = "UmC" + m;
                        m = m + 1;
                        td1.Controls.Add(ctl1);
                    }
                }
            }


            //********************************** ADD HEADING AND THEN ADD QUESTION IN  HEADING

            Session["lengthQues"] = null;
            string sql1 = "SELECT * FROM TheoryQuesTestDetails WHERE LoginId='" + Convert.ToString(Session["LoginId"]) + "' AND TestId=" + Convert.ToString(Session["TestID"]) + " ";
            DataSet ds1 = cc.ExecuteDataset(sql1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++) //count theory Question row by Heading
                {
                    string QuestionID = Convert.ToString(ds1.Tables[0].Rows[i]["QuestionID"]);

                    string[] QuesArr = QuestionID.Split(',');

                    string TheoryId11 = Convert.ToString(ds1.Tables[0].Rows[i]["ID"]);
                    Session["TheoryId1"] = Session["TheoryId1"] + TheoryId11 + ",";
                    string po12 = Convert.ToString(Session["TheoryId1"]);

                    Session["ID1"] = -1;

                    //add code to load heading control
                    Control ctl1 = LoadControl("../userControl/Heading.ascx");

                    ctl1.ID = "UHC" + h;  //h==o; add control =number of Question All Ques.
                    h = h + 1;
                    td1.Controls.Add(ctl1);

                    for (int k = 0; k < QuesArr.Length; k++) //loop for number of Question split by ,  (ADD  QUESTION)
                    {
                        string QuestionID1 = QuesArr[k];

                        Session["SNO"] = -1;

                        Session["QuestionID1"] = Session["QuestionID1"] + QuestionID1 + ",";
                        string po11 = Convert.ToString(Session["QuestionID1"]);

                        Control ctl = LoadControl("../userControl/ShowTheoryQuestion.ascx");  

                        ctl.ID = "UC" + g;  
                        g = g + 1;

                        td1.Controls.Add(ctl);
                    }
                }
            }
        }
        catch 
        { }
    }

    protected void btnMove_Click(object s, EventArgs e)
    {
        string id = btnMove.ID;
    }
}