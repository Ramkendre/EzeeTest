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

public partial class SubAdmin_ExportToExcelStudentScore : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    TestReports.Report rpt = new TestReports.Report();
    string centercodenum = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        centercodenum = Request.QueryString["CenterNo"];
        if (!Page.IsPostBack)
        {
            rpt.getReport(PrintCertificates(), HttpContext.Current.Response);
        }
    }

    public List<TestReports.ReportClass> PrintCertificates()
    {
        try
        {
            string userName = "", userID = "", centerNo = "", dateVal = "", totalMarks = "", grades = "";

            List<TestReports.ReportClass> list = new List<TestReports.ReportClass>();

            string SQLQuery = "Select Distinct Login.UserName,tblAppScoreReport.UserMobileNo,tblAppScoreReport.TeacherMobNo From Login Inner Join tblAppScoreReport ON Login.LoginId=tblAppScoreReport.UserMobileNo Where tblAppScoreReport.TeacherMobNo='" + centercodenum + "'  Order by UserMobileNo ASC ";
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
                   
                }
            }
            return list;
        }
        catch (Exception ex)
        {
            Response.Write("ERROR : " + ex);
        }
        return null;
    }


    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvExportToExcel.Visible)
            {
                Response.AddHeader("content-disposition", "attachment; filename='" + txtCenterNo.Text + "'Excel.xls");
                Response.ContentType = "application/excel";
                StringWriter sWriter = new StringWriter();
                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                gvExportToExcel.RenderControl(hTextWriter);
                Response.Write(sWriter.ToString());
                Response.End();
            }
        }
        catch(Exception ex)
        {
 
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void btnShowMasterData_Click(object sender, EventArgs e)
    {
        try
        {
            string SqlQuery = "Select Login.UserName,tblAppScoreReport.UserMobileNo,tblAppScoreReport.TeacherMobNo,tblAppScoreReport.TestId, " +

                              " tblAppScoreReport.TestDate,tblAppScoreReport.IMEI, tblAppScoreReport.[CorrectAnswered_count],tblAppScoreReport.[InCorrectanswered_count],tblAppScoreReport.[NotAnsweredQuestions_count],(((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int)))) As Total," +

                              " tblAppScoreReport.Status,(Select Distinct Login.UserName From Login Where Login.LoginId='" + txtCenterNo.Text + "') AS CenterName, " +

                              " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] as INT)))*100.00)/NULLIF(((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))),0)) as Percentage" +

                              " From Login Inner Join tblAppScoreReport ON Login.LoginId=tblAppScoreReport.UserMobileNo Where tblAppScoreReport.TeacherMobNo='" + txtCenterNo.Text + "' Order by UserMobileNo ASC ";

            DataSet dataset = cc.ExecuteDataset(SqlQuery);


            gvExportToExcel.DataSource = dataset.Tables[0];
            gvExportToExcel.DataBind();
        }
        catch(Exception ex)
        {
 
        }
    }


}
