using System;
using System.Collections;
using System.Collections.Generic;
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
using System.IO;

public partial class SubAdmin_ExportToExcel : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    TestReports.Report rpt = new TestReports.Report();
    string fileName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        if (gvExportToExcel.Visible)
        {
            Response.AddHeader("content-disposition", "attachment; filename='" + Session["FileName"] + "'Excel.xls");
            Response.ContentType = "application/excel";
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
            gvExportToExcel.RenderControl(hTextWriter);
            Response.Write(sWriter.ToString());
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void btnShowMasterData_Click(object sender, EventArgs e)
    {

        string SqlQuery = "Select Distinct Login.LoginId,Login.Password,Login.UserName,Admin_SubUser.loginname,(Select Distinct Login.UserName From Login Where Login.LoginId='" + Session["LoginId"] + "') AS CenterName,(Select Distinct Login.Address From Login Where Login.LoginId='" + Session["LoginId"] + "') AS Address From Login Inner Join Admin_SubUser ON Login.LoginId=Admin_SubUser.UnderUsername  Where Login.LoginId Like '54321%' ";  //Admin_SubUser.loginname='" + Session["LoginId"] + "'";

        DataSet dataset = cc.ExecuteDataset(SqlQuery);


        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("UserId", typeof(string)));
        dt.Columns.Add(new DataColumn("Password", typeof(string)));
        dt.Columns.Add(new DataColumn("StudentName", typeof(string)));
        dt.Columns.Add(new DataColumn("CenterId", typeof(string)));
        dt.Columns.Add(new DataColumn("HostelName", typeof(string)));
        dt.Columns.Add(new DataColumn("Address", typeof(string)));

        for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
        {
            dt.Rows.Add(dataset.Tables[0].Rows[i]["LoginId"].ToString(), cc.DESDecrypt(dataset.Tables[0].Rows[i]["Password"].ToString()), dataset.Tables[0].Rows[i]["UserName"].ToString(), dataset.Tables[0].Rows[i]["loginname"].ToString(), dataset.Tables[0].Rows[i]["CenterName"].ToString(), dataset.Tables[0].Rows[i]["Address"].ToString());
        }


        dataset.Tables.RemoveAt(0);
        dataset.Tables.Add(dt);

        gvExportToExcel.DataSource = dataset.Tables[0];
        gvExportToExcel.DataBind();
    }


    protected void btnShowDataStudentsofPerClassAdmin_Click(object sender, EventArgs e)
    {
        string login = Convert.ToString(Session["LoginId"]);
        Session["FileName"] = login + " Passwords " + System.DateTime.Now.Date.ToString("dd-MM-yyyy");

        if (login == Convert.ToString(9822696599))
        {

            string SqlQuery = "Select Distinct Login.LoginId,Login.Password,Login.UserName,Login.Address From Login Inner Join Admin_SubUser ON Login.LoginId=Admin_SubUser.UnderUsername  Where Admin_SubUser.loginname='" + Session["LoginId"] + "'";

            DataSet dataset = cc.ExecuteDataset(SqlQuery);


            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("CenterId", typeof(string)));
            dt.Columns.Add(new DataColumn("Password", typeof(string)));
            dt.Columns.Add(new DataColumn("HostelName", typeof(string)));
            dt.Columns.Add(new DataColumn("Address", typeof(string)));

            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                dt.Rows.Add(dataset.Tables[0].Rows[i]["LoginId"].ToString(), cc.DESDecrypt(dataset.Tables[0].Rows[i]["Password"].ToString()), dataset.Tables[0].Rows[i]["UserName"].ToString(), dataset.Tables[0].Rows[i]["Address"].ToString());
            }


            dataset.Tables.RemoveAt(0);
            dataset.Tables.Add(dt);

            gvExportToExcel.DataSource = dataset.Tables[0];
            gvExportToExcel.DataBind();
        }

        else
        {
            string SqlQuery = "Select Distinct Login.LoginId,Login.Password,Login.UserName,Admin_SubUser.loginname,(Select Distinct Login.UserName From Login Where Login.LoginId='" + Session["LoginId"] + "') AS CenterName,(Select Distinct Login.Address From Login Where Login.LoginId='" + Session["LoginId"] + "') AS Address From Login Inner Join Admin_SubUser ON Login.LoginId=Admin_SubUser.UnderUsername  Where Admin_SubUser.loginname='" + Session["LoginId"] + "'";

            DataSet dataset = cc.ExecuteDataset(SqlQuery);


            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("UserId", typeof(string)));
            dt.Columns.Add(new DataColumn("Password", typeof(string)));
            dt.Columns.Add(new DataColumn("StudentName", typeof(string)));
            dt.Columns.Add(new DataColumn("CenterId", typeof(string)));
            dt.Columns.Add(new DataColumn("HostelName", typeof(string)));
            dt.Columns.Add(new DataColumn("Address", typeof(string)));

            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                dt.Rows.Add(dataset.Tables[0].Rows[i]["LoginId"].ToString(), cc.DESDecrypt(dataset.Tables[0].Rows[i]["Password"].ToString()), dataset.Tables[0].Rows[i]["UserName"].ToString(), dataset.Tables[0].Rows[i]["loginname"].ToString(), dataset.Tables[0].Rows[i]["CenterName"].ToString(), dataset.Tables[0].Rows[i]["Address"].ToString());
            }


            dataset.Tables.RemoveAt(0);
            dataset.Tables.Add(dt);

            gvExportToExcel.DataSource = dataset.Tables[0];
            gvExportToExcel.DataBind();
        }
    }
    protected void btnShowStudentScoreDetails_Click(object sender, EventArgs e)
    {
        try
        {
            Session["FileName"] = ddlCenterNo.SelectedItem.Text + " Result " + txtDate.Text;

            string SqlQuery = "Select Login.UserName,tblAppScoreReport.UserMobileNo,tblAppScoreReport.TeacherMobNo,tblAppScoreReport.TestId, " +

                              " tblAppScoreReport.TestDate,tblAppScoreReport.IMEI, tblAppScoreReport.[CorrectAnswered_count],tblAppScoreReport.[InCorrectanswered_count],tblAppScoreReport.[NotAnsweredQuestions_count],(((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int)))) As Total," +

                              " tblAppScoreReport.Status,(Select Distinct Login.UserName From Login Where Login.LoginId='" + ddlCenterNo.SelectedItem.Text + "') AS CenterName, " +

                              " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] as INT)))*100.00)/NULLIF(((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))),0)) as Percentage" +

                              " From Login Inner Join tblAppScoreReport ON Login.LoginId=tblAppScoreReport.UserMobileNo Where tblAppScoreReport.TeacherMobNo='" + ddlCenterNo.SelectedItem.Text + "' and tblAppScoreReport.TestDate='" + txtDate.Text + "'  Order by UserMobileNo ASC ";

            DataSet dataset = cc.ExecuteDataset(SqlQuery);


            gvExportToExcel.DataSource = dataset.Tables[0];
            gvExportToExcel.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnGetTeacMoNo_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtDate.Text != "")
            {
                txtDate.BorderColor = System.Drawing.Color.GreenYellow;

                string SqlQueryGetCenNo = "Select  Distinct [TeacherMobNo] From [tblAppScoreReport] Where [TeacherMobNo] LIKE '8474645%'  and [TestDate]='" + txtDate.Text + "'";
                DataSet dataset = cc.ExecuteDataset(SqlQueryGetCenNo);

                DataTable dataTable = new DataTable();
                DataColumn dataColumn = dataTable.Columns.Add("ID", typeof(int));
                dataColumn.AutoIncrement = true;
                dataColumn.AutoIncrementSeed = 0;
                dataColumn.AutoIncrementStep = 1;
                dataTable.Columns.Add(new DataColumn("TeacherMobNo", typeof(string)));

                for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
                {
                    dataTable.Rows.Add(null, dataset.Tables[0].Rows[i]["TeacherMobNo"].ToString());
                }

                dataset.Tables.RemoveAt(0);
                dataset.Tables.Add(dataTable);

                ddlCenterNo.DataSource = dataset.Tables[0];
                ddlCenterNo.DataTextField = "TeacherMobNo";
                ddlCenterNo.DataValueField = "ID";
                ddlCenterNo.DataBind();
            }
            else
            {
                txtDate.BorderColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            Response.Write("ERROR :" + ex);
        }
    }


    public void PrintCertificates()
    {
        try
        {
            string userName = "", userID = "", centerNo = "", dateVal = "", totalMarks = "", grades = "";

            List<TestReports.ReportClass> list = new List<TestReports.ReportClass>();

            string SQLQuery = "Select Distinct Login.UserName,tblAppScoreReport.UserMobileNo,tblAppScoreReport.TeacherMobNo From Login Inner Join tblAppScoreReport ON Login.LoginId=tblAppScoreReport.UserMobileNo Where tblAppScoreReport.TeacherMobNo='" + ddlCenterNo.SelectedItem.Text + "'  Order by UserMobileNo ASC ";
            DataSet dataset = cc.ExecuteDataset(SQLQuery);

            if (dataset != null)
            {
                if (dataset.Tables[0].Rows.Count > 0)
                {
                    for (int j1 = 0; j1 < dataset.Tables[0].Rows.Count; j1++)
                    {
                        string UserIDVal = dataset.Tables[0].Rows[j1][1].ToString();


                        string SQLQUERY = "Select Distinct Login.UserName,tblAppScoreReport.UserMobileNo,tblAppScoreReport.TestDate,tblAppScoreReport.TeacherMobNo,(Select SUM(CONVERT(int,a)) as TOTAL from (select max(CorrectAnswered_count) as a from tblAppScoreReport group by UserMobileNo,TestId having UserMobileNo = '" + UserIDVal + "') as ab) as Total  From Login Inner Join tblAppScoreReport ON Login.LoginId=tblAppScoreReport.UserMobileNo Where tblAppScoreReport.UserMobileNo = '" + UserIDVal + "' Order by UserMobileNo ASC  ";
                        DataSet dataset1 = cc.ExecuteDataset(SQLQUERY);

                        userName = dataset1.Tables[0].Rows[0][0].ToString();
                        userID = dataset1.Tables[0].Rows[0][1].ToString();
                        dateVal = dataset1.Tables[0].Rows[0][2].ToString();
                        centerNo = dataset1.Tables[0].Rows[0][3].ToString();
                        totalMarks = dataset1.Tables[0].Rows[0][4].ToString();

                        if (Convert.ToInt32(totalMarks) >= 35 && Convert.ToInt32(totalMarks) < 44)
                        {
                            grades = "D";
                        }
                        else if (Convert.ToInt32(totalMarks) >= 45 && Convert.ToInt32(totalMarks) < 54)
                        {
                            grades = "C";
                        }
                        else if (Convert.ToInt32(totalMarks) >= 55 && Convert.ToInt32(totalMarks) < 64)
                        {
                            grades = "B";
                        }
                        else if (Convert.ToInt32(totalMarks) < 35)
                        {
                            grades = "E";
                        }
                        else
                        {
                            grades = "A";
                        }

                        list.Add(new TestReports.ReportClass { center = centerNo, date = dateVal, grade = grades, id = userID, name = userName });

                    }
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    rpt.getReport(list, HttpContext.Current.Response);
                    Response.End();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("ERROR : " + ex);
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string CenterCodeNo = txtCenterCode.Text;
        Response.Redirect("~/SubAdmin/ExportToExcelStudentScore.aspx?CenterNo=" + CenterCodeNo);
        //PrintCertificates();
    }
}
