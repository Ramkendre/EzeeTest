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
using System.Xml;
using System.IO;
using System.Security.Permissions;
using System.Security.AccessControl;
using System.Security.Authentication;

public partial class Admin_TestHome : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gettest();

            if (Page.PreviousPage != null)
            {
                StoreResultToServer();
                //ResultSaveInXml();
            }

        }
    }
    string Test_ID = "";
    void gettest()
    {
        string sql = "";
        string Usertype = Convert.ToString(Session["UserType"]);

        if (Usertype == "2")
        {
            sql = " select Test_ID from tblAssignTestToStudent where StudentMobileNo='" + Convert.ToString(Session["Loginid"]) + "' or (StudentMobileNo='' and (UserType='1' or UserType='2'))  ";//where NewQID<=150"; 

        }
        else if (Usertype == "3")
        {
            sql = " select Test_ID from tblAssignTestToStudent where StudentMobileNo='" + Convert.ToString(Session["Loginid"]) + "' or (StudentMobileNo='' and (UserType='1' or UserType='2' or UserType='3'))  ";//where NewQID<=150"; 

        }
        else if (Usertype == "4")
        {
            sql = " select Test_ID from tblAssignTestToStudent where StudentMobileNo='" + Convert.ToString(Session["Loginid"]) + "' or (StudentMobileNo='' and (UserType='1' or UserType='2' or UserType='3' or UserType='4'))  ";//where NewQID<=150"; 

        }
        else
        {
            sql = " select Test_ID from tblAssignTestToStudent where StudentMobileNo='" + Convert.ToString(Session["Loginid"]) + "' or (StudentMobileNo='' and UserType='1') ";

        }

        DataSet ds = cc.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Test_ID = Test_ID + "," + Convert.ToString(ds.Tables[0].Rows[i]["Test_ID"]);

            }

            Test_ID = Test_ID.Substring(1);

            //Below is Patch For Scholarship Exam on 04.03.2015 by Jitendra
            string SqlQuery = "Select CompanyId From Login Where LoginId='" + Convert.ToString(Session["Loginid"]) + "'";
            int companyID =Convert.ToInt32(cc.ExecuteScalar(SqlQuery));

            if (companyID == 5250)
            {
                string Sql = "select Test_ID,Exam_name from tblTestDefinition where Test_ID IN('663','664','665','666','667','668') Order By IndexNo ASC ";
                ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddltest.DataSource = ds.Tables[0];
                    ddltest.DataTextField = "Exam_name";
                    ddltest.DataValueField = "Test_ID";
                    ddltest.DataBind();
                    ddltest.Items.Add("--Select--");
                    ddltest.SelectedIndex = ddltest.Items.Count - 1;

                }

            }
            else if(companyID==5251)
            {
                string Sql = "select Test_ID,Exam_name from tblTestDefinition where Test_ID IN('617','629','571','572','630','618') Order By IndexNo ASC ";
                ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddltest.DataSource = ds.Tables[0];
                    ddltest.DataTextField = "Exam_name";
                    ddltest.DataValueField = "Test_ID";
                    ddltest.DataBind();
                    ddltest.Items.Add("--Select--");
                    ddltest.SelectedIndex = ddltest.Items.Count - 1;

                }
            }
            else if (companyID == 5252)
            {
                string Sql = "select Test_ID,Exam_name from tblTestDefinition where Test_ID IN('486','462','504','696','466','474') Order By IndexNo ASC ";
                ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddltest.DataSource = ds.Tables[0];
                    ddltest.DataTextField = "Exam_name";
                    ddltest.DataValueField = "Test_ID";
                    ddltest.DataBind();
                    ddltest.Items.Add("--Select--");
                    ddltest.SelectedIndex = ddltest.Items.Count - 1;

                }
            }

            else if (companyID == 5253)
            {
                string Sql = "select Test_ID,Exam_name from tblTestDefinition where Test_ID IN('531','528','506','532','708','508') Order By IndexNo ASC ";
                ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddltest.DataSource = ds.Tables[0];
                    ddltest.DataTextField = "Exam_name";
                    ddltest.DataValueField = "Test_ID";
                    ddltest.DataBind();
                    ddltest.Items.Add("--Select--");
                    ddltest.SelectedIndex = ddltest.Items.Count - 1;

                }
            }
            else
            {
                string Sql = "select Test_ID,Exam_name from tblTestDefinition where Test_ID in('657','658','659') Order By IndexNo ASC "; //" + Test_ID + "
                ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddltest.DataSource = ds.Tables[0];
                    ddltest.DataTextField = "Exam_name";
                    ddltest.DataValueField = "Test_ID";
                    ddltest.DataBind();
                    ddltest.Items.Add("--Select--");
                    ddltest.SelectedIndex = ddltest.Items.Count - 1;

                }
            }
        }
    }
    protected void ddltest_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltest.SelectedIndex == ddltest.Items.Count - 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Exam Name')", true);

        }
        else
        {
            Session["TestID"] = ddltest.SelectedValue;
            Session["TestName"] = ddltest.SelectedItem.Text;

            createCookie();
            Response.Redirect("../Admin/exTest.aspx");

        }
    }

    void createCookie()
    {
        /************ Add Session in Cookie ***************/

        HttpCookie cookie = new HttpCookie("Credentials");
        cookie.Values.Add("ezeeUser123", Session["UserName"].ToString());// your x value
        cookie.Values.Add("mobNo", Session["LoginId"].ToString()); // your y value

        cookie.Values.Add("CompanyId", Session["CompanyId"].ToString());
        cookie.Values.Add("TestID", Session["TestID"].ToString());

        cookie.Expires = DateTime.Now.AddDays(365); // --------> cookie.Expires is the property you can set timeout
        HttpContext.Current.Response.AppendCookie(cookie);
    }


    public void StoreResultToServer()
    {
        string IPAdd = string.Empty;
        IPAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(IPAdd))
        {
            IPAdd = Request.ServerVariables["REMOTE_ADDR"];
        }

        string SqlQuery = " Select Admin_SubUser.loginname from Admin_SubUser where UnderUsername= '" + Convert.ToString(Session["Loginid"]) + "'order by id DESC";
        string value = cc.ExecuteScalar(SqlQuery);

        string SqlQuery1 = "select tblTestDefinition.TypeOFExam from tblTestDefinition where Test_ID= '" + Convert.ToString(Session["TestID"]) + "'";
        string val1 = cc.ExecuteScalar(SqlQuery1);

        int corr = Convert.ToInt32(Session["Corrhidden3"]);

        int incorr = Convert.ToInt32(Session["Incorrhidden4"]);
        int notans = Convert.ToInt32(Session["NotAnswered"]);

        double Result = Convert.ToDouble((corr * 100) / (corr + incorr + notans));
        string PassFail = "";

        if (Result < 35.00)
        {
            PassFail = "Fail";
        }
        else
        {
            PassFail = "Pass";
        }


        SqlCommand cmd = new SqlCommand();
        DataSet dataset = new DataSet();
        SqlParameter sqlParam = new SqlParameter();
        cmd.CommandText = "sp_SaveResultToServer";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        sqlParam.Size = 15;
        sqlParam.DbType = DbType.String;
        

        SqlParameter[] parameter = new SqlParameter[]
        {
            new SqlParameter("@userMobileNo",Convert.ToString(Session["Loginid"])),
            new SqlParameter("@teacherMobNo",value),
            new SqlParameter("@examId",val1),
            new SqlParameter("@testId",Convert.ToString(Session["TestID"])),
            new SqlParameter("@imei",0.ToString()),
            new SqlParameter("@testDate",System.DateTime.Now.Date.ToString("yyyy-MM-dd")),
            new SqlParameter("@startTime",System.DateTime.Now.ToShortTimeString()),
            new SqlParameter("@endtime",0.ToString()),
            new SqlParameter("@corrAnsCount",Convert.ToString(Session["Corrhidden3"])),
            new SqlParameter("@inCorrAnsCount",Convert.ToString(Session["Incorrhidden4"])),
            new SqlParameter("@notAnsQuesCount",Convert.ToString(Session["NotAnswered"])),
            new SqlParameter("@status",PassFail),
            new SqlParameter("@ipAddress",IPAdd)
        };
        cmd.Parameters.AddRange(parameter);
        cmd.Connection.Open();
        int res = cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        
        if (res != 0)
        {
            Label lbl = new Label();
            lbl.ForeColor = System.Drawing.Color.Green;
            lbl.Font.Bold = true;
            lbl.Text = "Record Inserted Successfully!!!";
            this.Controls.Add(lbl);
        }
        else
        {
            Label lbl = new Label();
            lbl.ForeColor = System.Drawing.Color.Green;
            lbl.Font.Bold = true;
            lbl.Text = "Record Not Inserted Successfully!!!";
            this.Controls.Add(lbl);
        }
    }




    public void ResultSaveInXml() // Sva Result in XML Done by Jitendra
    {
        
        string IPAdd = string.Empty;
        IPAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(IPAdd))
        {
            IPAdd = Request.ServerVariables["REMOTE_ADDR"];
        }

        string SqlQuery = " Select Admin_SubUser.loginname from Admin_SubUser where UnderUsername= '" + Convert.ToString(Session["Loginid"]) + "'order by id DESC";
        string value = cc.ExecuteScalar(SqlQuery);

        string SqlQuery1 = "select tblTestDefinition.TypeOFExam from tblTestDefinition where Test_ID= '" + Convert.ToString(Session["TestID"]) + "'";
        string val1 = cc.ExecuteScalar(SqlQuery1);

        int corr = Convert.ToInt32(Session["Corrhidden3"]);

        int incorr = Convert.ToInt32(Session["Incorrhidden4"]);
        int notans = Convert.ToInt32(Session["NotAnswered"]);

        double Result = Convert.ToDouble((corr * 100) / (corr + incorr + notans));
        string PassFail = "";

        if (Result < 35.00)
        {
            PassFail = "Fail";
        }
        else
        {
            PassFail = "Pass";
        }

        string paperID = Convert.ToString(Session["TestID"]);
        string login = Convert.ToString(Session["Loginid"]);
        string pathString = "D:\\eZeeTest\\eZee'" + login + paperID + "'.xml";

        string folderName = @"D:\eZeeTest";
        System.IO.Directory.CreateDirectory(folderName);


            XmlTextWriter writer = new XmlTextWriter(pathString, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Table");


            string A1 = Convert.ToString(Session["Loginid"]);
            string A2 = Convert.ToString(Session["TestID"]);
            string A3 = System.DateTime.Now.ToShortDateString();
            string A4 = System.DateTime.Now.ToShortTimeString();
            string A5 = Convert.ToString(Session["Corrhidden3"]);
            string A6 = Convert.ToString(Session["Incorrhidden4"]);
            string A7 = Convert.ToString(Session["NotAnswered"]);


            createNode(A1, value, val1, A2, "0", A3, A4, "0", A5, A6, A7, PassFail, IPAdd, writer);

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
           
    }

    private void createNode(string UserMobileNo, string TeacherMobNo, string ExamId, string TestId, string IMEI, string TestDate, string StartTime, string EndTime, string CorrectAnswered_count, string InCorrectanswered_count, string NotAnsweredQuestions_count, string Status, string ipAddress, XmlTextWriter writer)
    {

        writer.WriteStartElement("tblAppScoreReport");
        writer.WriteStartElement("UserMobileNo");
        writer.WriteString(UserMobileNo);
        writer.WriteEndElement();

        writer.WriteStartElement("TeacherMobNo");
        writer.WriteString(TeacherMobNo);
        writer.WriteEndElement();


        writer.WriteStartElement("ExamId");
        writer.WriteString(ExamId);
        writer.WriteEndElement();

        writer.WriteStartElement("TestId");
        writer.WriteString(TestId);
        writer.WriteEndElement();

        writer.WriteStartElement("IMEI");
        writer.WriteString(IMEI);
        writer.WriteEndElement();

        writer.WriteStartElement("TestDate");
        writer.WriteString(TestDate);
        writer.WriteEndElement();

        writer.WriteStartElement("StartTime");
        writer.WriteString(StartTime);
        writer.WriteEndElement();

        writer.WriteStartElement("EndTime");
        writer.WriteString(EndTime);
        writer.WriteEndElement();

        writer.WriteStartElement("CorrectAnswered_count");
        writer.WriteString(CorrectAnswered_count);
        writer.WriteEndElement();

        writer.WriteStartElement("InCorrectanswered_count");
        writer.WriteString(InCorrectanswered_count);
        writer.WriteEndElement();

        writer.WriteStartElement("NotAnsweredQuestions_count");
        writer.WriteString(NotAnsweredQuestions_count);
        writer.WriteEndElement();

        writer.WriteStartElement("Status");
        writer.WriteString(Status);
        writer.WriteEndElement();

        writer.WriteStartElement("ipAddress");
        writer.WriteString(ipAddress);
        writer.WriteEndElement();


        writer.WriteEndElement();


    }

}