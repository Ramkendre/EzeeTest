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
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

public partial class SubAdmin_MangalDemo : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    string Sql = "";
    string searchVal = string.Empty;
    TestDefinationBLL testDefBAL = new TestDefinationBLL();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            MultiView1.SetActiveView(View1);
          
            this.btnExportExcel.Visible = false;
        }

    }

    public void disComputerCourse()
    {
        if (txtDate.Text == "")
        {
            Sql = "Select tblAppScoreReport.UserMobileNo,tblAppScoreReport.firstName,tblAppScoreReport.lastName,tblAppScoreReport.UDISE_Code,tblAppScoreReport.IMEI, " +
                " tblAppScoreReport.TestDate,(Select Exam_name from tblTestDefinition where Test_ID=tblAppScoreReport.TestId) AS PaperName,(((tblAppScoreReport.[CorrectAnswered_count])*4)-(tblAppScoreReport.[InCorrectanswered_count])) As ObtainMarks, " +
                " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*1) As Total, " +
                " tblAppScoreReport.Status from tblAppScoreReport Where " + searchVal + " Like '" + txtCenterNo.Text + "%'  " +
                " and tblAppScoreReport.ExamId=" + ddlExamName.SelectedValue + "  Order by tblAppScoreReport.firstName ASC ";
        }
        else
        {

            Sql = "Select tblAppScoreReport.UserMobileNo,tblAppScoreReport.firstName,tblAppScoreReport.lastName,tblAppScoreReport.UDISE_Code,tblAppScoreReport.IMEI, " +
                " tblAppScoreReport.TestDate,(Select Exam_name from tblTestDefinition where Test_ID=tblAppScoreReport.TestId) AS PaperName,(((tblAppScoreReport.[CorrectAnswered_count])*4)-(tblAppScoreReport.[InCorrectanswered_count])) As ObtainMarks, " +
                " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*1) As Total, " +
                " tblAppScoreReport.Status from tblAppScoreReport Where " + searchVal + " Like '" + txtCenterNo.Text + "%' and tblAppScoreReport.TestDate='" + txtDate.Text + "' " +
                " and tblAppScoreReport.ExamId =" + ddlExamName.SelectedValue + "  Order by tblAppScoreReport.firstName ASC ";
            //" + searchVal + " Like '" + txtCenterNo.Text + "%' and
        }
        ds = cc.ExecuteDataset(Sql);

        gvStudentData.DataSource = ds.Tables[0];
        gvStudentData.DataBind();
    }
    public void BindGridView()
    {
        //string searchVal = string.Empty;
        if (rdolstSearchBy.SelectedValue == Convert.ToString(0))
        {
            searchVal = "tblAppScoreReport.UserMobileNo";
        }
        else if (rdolstSearchBy.SelectedValue == Convert.ToString(1))
        {
            searchVal = "tblAppScoreReport.UDISE_Code";
        }
        else
        {
            searchVal = "tblAppScoreReport.IMEI";
        }
        if (ddlExamName.SelectedValue == Convert.ToString(96))
        {
            if (txtDate.Text == "")
            {
                Sql = "Select tblAppScoreReport.UserMobileNo,tblAppScoreReport.firstName,tblAppScoreReport.lastName,tblAppScoreReport.UDISE_Code,tblAppScoreReport.IMEI, " +
                    " tblAppScoreReport.TestDate,(Select Exam_name from tblTestDefinition where Test_ID=tblAppScoreReport.TestId) AS PaperName,((tblAppScoreReport.[CorrectAnswered_count])*2) As ObtainMarks, " +
                    " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*2) As Total, " +
                    " tblAppScoreReport.Status from tblAppScoreReport Where " + searchVal + " Like '" + txtCenterNo.Text + "%'  " +
                    " and tblAppScoreReport.ExamId =" + ddlExamName.SelectedValue + "  Order by tblAppScoreReport.firstName ASC ";
            }
            else
            {
                Sql = "Select tblAppScoreReport.UserMobileNo,tblAppScoreReport.firstName,tblAppScoreReport.lastName,tblAppScoreReport.UDISE_Code,tblAppScoreReport.IMEI, " +
                    " tblAppScoreReport.TestDate,(Select Exam_name from tblTestDefinition where Test_ID=tblAppScoreReport.TestId) AS PaperName,((tblAppScoreReport.[CorrectAnswered_count])*2) As ObtainMarks, " +
                    " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*2) As Total, " +
                    " tblAppScoreReport.Status from tblAppScoreReport Where " + searchVal + " Like '" + txtCenterNo.Text + "%' and tblAppScoreReport.TestDate='" + txtDate.Text + "' " +
                    " and tblAppScoreReport.ExamId " + ddlExamName.SelectedValue + "  Order by tblAppScoreReport.firstName ASC ";
            }
            ds = cc.ExecuteDataset(Sql);

            gvStudentData.DataSource = ds.Tables[0];
            gvStudentData.DataBind();
        }

        else if (ddlExamName.SelectedValue == Convert.ToString(98))
        {
            if (txtDate.Text == "")
            {
                Sql = "Select tblAppScoreReport.UserMobileNo,tblAppScoreReport.firstName,tblAppScoreReport.lastName,tblAppScoreReport.UDISE_Code,tblAppScoreReport.IMEI, " +
                    " tblAppScoreReport.TestDate,(Select Exam_name from tblTestDefinition where Test_ID=tblAppScoreReport.TestId) AS PaperName,(((tblAppScoreReport.[CorrectAnswered_count])*4)-(tblAppScoreReport.[InCorrectanswered_count])) As ObtainMarks, " +
                    " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*1) As Total, " +
                    " tblAppScoreReport.Status from tblAppScoreReport Where " + searchVal + " Like '" + txtCenterNo.Text + "%'  " +
                    " and tblAppScoreReport.ExamId=" + ddlExamName.SelectedValue + "  Order by tblAppScoreReport.firstName ASC ";
            }
            else
            {

                Sql = "Select tblAppScoreReport.UserMobileNo,tblAppScoreReport.firstName,tblAppScoreReport.lastName,tblAppScoreReport.UDISE_Code,tblAppScoreReport.IMEI, " +
                    " tblAppScoreReport.TestDate,(Select Exam_name from tblTestDefinition where Test_ID=tblAppScoreReport.TestId) AS PaperName,(((tblAppScoreReport.[CorrectAnswered_count])*4)-(tblAppScoreReport.[InCorrectanswered_count])) As ObtainMarks, " +
                    " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*1) As Total, " +
                    " tblAppScoreReport.Status from tblAppScoreReport Where " + searchVal + " Like '" + txtCenterNo.Text + "%' and tblAppScoreReport.TestDate='" + txtDate.Text + "' " +
                    " and tblAppScoreReport.ExamId =" + ddlExamName.SelectedValue + "  Order by tblAppScoreReport.firstName ASC ";
                //" + searchVal + " Like '" + txtCenterNo.Text + "%' and
            }
            ds = cc.ExecuteDataset(Sql);

            gvStudentData.DataSource = ds.Tables[0];
            gvStudentData.DataBind();

        }

        else if (ddlExamName.SelectedValue == Convert.ToString(110) && ddlSubject.SelectedValue == Convert.ToString(111))
        {
            if (txtDate.Text == "")
            {
                Sql = "Select tblAppScoreReport.UserMobileNo,tblAppScoreReport.firstName,tblAppScoreReport.lastName,tblAppScoreReport.UDISE_Code,tblAppScoreReport.IMEI, " +
                    " tblAppScoreReport.TestDate,(Select Exam_name from tblTestDefinition where Test_ID=tblAppScoreReport.TestId) AS PaperName,(((tblAppScoreReport.[CorrectAnswered_count])*4)-(tblAppScoreReport.[InCorrectanswered_count])) As ObtainMarks, " +
                    " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*1) As Total, " +
                    " tblAppScoreReport.Status from tblAppScoreReport Where " + searchVal + " Like '" + txtCenterNo.Text + "%'  " +
                    " and tblAppScoreReport.ExamId='11000'  Order by tblAppScoreReport.firstName ASC ";
            }
            else
            {

                Sql = "Select tblAppScoreReport.UserMobileNo,tblAppScoreReport.firstName,tblAppScoreReport.lastName,tblAppScoreReport.UDISE_Code,tblAppScoreReport.IMEI, " +
                    " tblAppScoreReport.TestDate,(Select Exam_name from tblTestDefinition where Test_ID=tblAppScoreReport.TestId) AS PaperName,(((tblAppScoreReport.[CorrectAnswered_count])*4)-(tblAppScoreReport.[InCorrectanswered_count])) As ObtainMarks, " +
                    " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*1) As Total, " +
                    " tblAppScoreReport.Status from tblAppScoreReport Where " + searchVal + " Like '" + txtCenterNo.Text + "%' and tblAppScoreReport.TestDate='" + txtDate.Text + "' " +
                    " and tblAppScoreReport.ExamId ='11000'  Order by tblAppScoreReport.firstName ASC ";
                //" + searchVal + " Like '" + txtCenterNo.Text + "%' and
            }
            ds = cc.ExecuteDataset(Sql);

            gvStudentData.DataSource = ds.Tables[0];
            gvStudentData.DataBind();
        }
        else if (ddlExamName.SelectedValue == Convert.ToString(110) && ddlSubject.SelectedValue == Convert.ToString(112))
        {
            if (txtDate.Text == "")
            {
                Sql = "Select tblAppScoreReport.UserMobileNo,tblAppScoreReport.firstName,tblAppScoreReport.lastName,tblAppScoreReport.UDISE_Code,tblAppScoreReport.IMEI, " +
                    " tblAppScoreReport.TestDate,(Select Exam_name from tblTestDefinition where Test_ID=tblAppScoreReport.TestId) AS PaperName,(((tblAppScoreReport.[CorrectAnswered_count])*4)-(tblAppScoreReport.[InCorrectanswered_count])) As ObtainMarks, " +
                    " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*1) As Total, " +
                    " tblAppScoreReport.Status from tblAppScoreReport Where " + searchVal + " Like '" + txtCenterNo.Text + "%'  " +
                    " and tblAppScoreReport.ExamId='110000'  Order by tblAppScoreReport.firstName ASC ";
            }
            else
            {

                Sql = "Select tblAppScoreReport.UserMobileNo,tblAppScoreReport.firstName,tblAppScoreReport.lastName,tblAppScoreReport.UDISE_Code,tblAppScoreReport.IMEI, " +
                    " tblAppScoreReport.TestDate,(Select Exam_name from tblTestDefinition where Test_ID=tblAppScoreReport.TestId) AS PaperName,(((tblAppScoreReport.[CorrectAnswered_count])*4)-(tblAppScoreReport.[InCorrectanswered_count])) As ObtainMarks, " +
                    " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*1) As Total, " +
                    " tblAppScoreReport.Status from tblAppScoreReport Where " + searchVal + " Like '" + txtCenterNo.Text + "%' and tblAppScoreReport.TestDate='" + txtDate.Text + "' " +
                    " and tblAppScoreReport.ExamId ='110000'  Order by tblAppScoreReport.firstName ASC ";
                //" + searchVal + " Like '" + txtCenterNo.Text + "%' and
            }
            ds = cc.ExecuteDataset(Sql);

            gvStudentData.DataSource = ds.Tables[0];
            gvStudentData.DataBind();
        }
        else if(ddlExamName.SelectedValue == Convert.ToString(110) && ddlSubject.SelectedValue == Convert.ToString(134))
        {
            if (txtDate.Text == "")
            {
                Sql = "Select tblAppScoreReport.UserMobileNo,tblAppScoreReport.firstName,tblAppScoreReport.lastName,tblAppScoreReport.UDISE_Code,tblAppScoreReport.IMEI, " +
                    " tblAppScoreReport.TestDate,(Select Exam_name from tblTestDefinition where Test_ID=tblAppScoreReport.TestId) AS PaperName,(((tblAppScoreReport.[CorrectAnswered_count])*4)-(tblAppScoreReport.[InCorrectanswered_count])) As ObtainMarks, " +
                    " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*1) As Total, " +
                    " tblAppScoreReport.Status from tblAppScoreReport Where " + searchVal + " Like '" + txtCenterNo.Text + "%'  " +
                    " and tblAppScoreReport.ExamId='110'  Order by tblAppScoreReport.firstName ASC ";
            }
            else
            {

                Sql = "Select tblAppScoreReport.UserMobileNo,tblAppScoreReport.firstName,tblAppScoreReport.lastName,tblAppScoreReport.UDISE_Code,tblAppScoreReport.IMEI, " +
                    " tblAppScoreReport.TestDate,(Select Exam_name from tblTestDefinition where Test_ID=tblAppScoreReport.TestId) AS PaperName,(((tblAppScoreReport.[CorrectAnswered_count])*4)-(tblAppScoreReport.[InCorrectanswered_count])) As ObtainMarks, " +
                    " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*1) As Total, " +
                    " tblAppScoreReport.Status from tblAppScoreReport Where " + searchVal + " Like '" + txtCenterNo.Text + "%' and tblAppScoreReport.TestDate='" + txtDate.Text + "' " +
                    " and tblAppScoreReport.ExamId ='110'  Order by tblAppScoreReport.firstName ASC ";
                //" + searchVal + " Like '" + txtCenterNo.Text + "%' and
            }
            ds = cc.ExecuteDataset(Sql);

            gvStudentData.DataSource = ds.Tables[0];
            gvStudentData.DataBind();
        }
        else if (ddlExamName.SelectedValue == Convert.ToString(110) && ddlSubject.SelectedValue == Convert.ToString(164))
        {
            if (txtDate.Text == "")
            {
                Sql = "Select tblAppScoreReport.UserMobileNo,tblAppScoreReport.firstName,tblAppScoreReport.lastName,tblAppScoreReport.UDISE_Code,tblAppScoreReport.IMEI, " +
                    " tblAppScoreReport.TestDate,(Select Exam_name from tblTestDefinition where Test_ID=tblAppScoreReport.TestId) AS PaperName,(((tblAppScoreReport.[CorrectAnswered_count])*4)-(tblAppScoreReport.[InCorrectanswered_count])) As ObtainMarks, " +
                    " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*1) As Total, " +
                    " tblAppScoreReport.Status from tblAppScoreReport Where " + searchVal + " Like '" + txtCenterNo.Text + "%'  " +
                    " and tblAppScoreReport.ExamId='1100'  Order by tblAppScoreReport.firstName ASC ";
            }
            else
            {

                Sql = "Select tblAppScoreReport.UserMobileNo,tblAppScoreReport.firstName,tblAppScoreReport.lastName,tblAppScoreReport.UDISE_Code,tblAppScoreReport.IMEI, " +
                    " tblAppScoreReport.TestDate,(Select Exam_name from tblTestDefinition where Test_ID=tblAppScoreReport.TestId) AS PaperName,(((tblAppScoreReport.[CorrectAnswered_count])*4)-(tblAppScoreReport.[InCorrectanswered_count])) As ObtainMarks, " +
                    " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*1) As Total, " +
                    " tblAppScoreReport.Status from tblAppScoreReport Where " + searchVal + " Like '" + txtCenterNo.Text + "%' and tblAppScoreReport.TestDate='" + txtDate.Text + "' " +
                    " and tblAppScoreReport.ExamId ='1100'  Order by tblAppScoreReport.firstName ASC ";
                //" + searchVal + " Like '" + txtCenterNo.Text + "%' and
            }
            ds = cc.ExecuteDataset(Sql);

            gvStudentData.DataSource = ds.Tables[0];
            gvStudentData.DataBind();
        }
        else
        {
            if (txtDate.Text == "")
            {
                Sql = "Select tblAppScoreReport.UserMobileNo,tblAppScoreReport.firstName,tblAppScoreReport.lastName,tblAppScoreReport.UDISE_Code,tblAppScoreReport.IMEI, " +
                    " tblAppScoreReport.TestDate,(Select Exam_name from tblTestDefinition where Test_ID=tblAppScoreReport.TestId) AS PaperName,((tblAppScoreReport.[CorrectAnswered_count])*1) As ObtainMarks, " +
                    " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*1) As Total, " +
                    " tblAppScoreReport.Status from tblAppScoreReport Where " + searchVal + " Like '" + txtCenterNo.Text + "%'  " +
                    " and tblAppScoreReport.ExamId=" + ddlExamName.SelectedValue + "  Order by tblAppScoreReport.firstName ASC ";  //Like '" + ddlExamName.SelectedValue + "%'
            }
            else
            {

                Sql = "Select tblAppScoreReport.UserMobileNo,tblAppScoreReport.firstName,tblAppScoreReport.lastName,tblAppScoreReport.UDISE_Code,tblAppScoreReport.IMEI, " +
                    " tblAppScoreReport.TestDate,(Select Exam_name from tblTestDefinition where Test_ID=tblAppScoreReport.TestId) AS PaperName,((tblAppScoreReport.[CorrectAnswered_count])*1) As ObtainMarks, " +
                    " ((((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int))))*1) As Total, " +
                    " tblAppScoreReport.Status from tblAppScoreReport Where " + searchVal + " Like '" + txtCenterNo.Text + "%' and tblAppScoreReport.TestDate='" + txtDate.Text + "' " +
                    " and tblAppScoreReport.ExamId =" + ddlExamName.SelectedValue + "  Order by tblAppScoreReport.firstName ASC ";
                //" + searchVal + " Like '" + txtCenterNo.Text + "%' and
            }
            ds = cc.ExecuteDataset(Sql);

            gvStudentData.DataSource = ds.Tables[0];
            gvStudentData.DataBind();

        }
        MultiView1.SetActiveView(View1);
        this.btnExportExcel.Visible = true;
    }

    protected void gvStudentData_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvStudentData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Convert.ToString(e.CommandName) == "ViewDetails")
        {
            ShowStudentResult();
        }
        MultiView1.SetActiveView(View2);
    }
    protected void gvStudentData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStudentData.PageIndex = e.NewPageIndex;
        BindGridView();
    }


    private void ShowStudentResult()
    {

        string SqlQuery = "Select Login.UserName,tblAppScoreReport.UserMobileNo,tblAppScoreReport.TeacherMobNo,tblAppScoreReport.TestId,tblAppScoreReport.TestDate,tblAppScoreReport.IMEI,tblAppScoreReport.StartTime,tblAppScoreReport.EndTime,tblAppScoreReport.Status,(Select Distinct Login.UserName From Login Where Login.LoginId='9999999999') AS CenterName,((((CAST(tblAppScoreReport.[CorrectAnswered_count] as INT)))*100.00)/((CAST(tblAppScoreReport.[CorrectAnswered_count] As INT))+(CAST (tblAppScoreReport.[InCorrectanswered_count] As int))+(CAST( tblAppScoreReport.[NotAnsweredQuestions_count] as int)))) as Percentage,(Select tblTestDefinition.Exam_name From tblTestDefinition Inner Join tblAppScoreReport ON tblTestDefinition.Test_ID=tblAppScoreReport.TestId Where tblAppScoreReport.TestId='547') AS TestName From Login Inner Join tblAppScoreReport ON Login.LoginId=tblAppScoreReport.UserMobileNo Where tblAppScoreReport.TeacherMobNo='9999999999'";
        ds = cc.ExecuteDataset(SqlQuery);

        lblUserId.Text = ds.Tables[0].Rows[0][1].ToString();
        lblUserName.Text = ds.Tables[0].Rows[0][0].ToString();
        lblCenterNoView.Text = ds.Tables[0].Rows[0][2].ToString();
        lblPaperID.Text = ds.Tables[0].Rows[0][3].ToString();
        lblPaperDate.Text = ds.Tables[0].Rows[0][4].ToString();
        lblIMEI.Text = ds.Tables[0].Rows[0][5].ToString();
        lblStartTime.Text = ds.Tables[0].Rows[0][6].ToString();
        lblEndTime.Text = ds.Tables[0].Rows[0][7].ToString();
        lblResult.Text = ds.Tables[0].Rows[0][8].ToString();
        lblCenterName.Text = ds.Tables[0].Rows[0][9].ToString();
        lblPercentage.Text = ds.Tables[0].Rows[0][10].ToString();
        lblPaperName.Text = ds.Tables[0].Rows[0][11].ToString();

    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
    }
    protected void ddlGroupofExam_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlGroupofExam.SelectedValue == Convert.ToString(140))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=17196  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(141))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=16998 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(142))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=17099  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(143))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=203";// 167103  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(144))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=205"; //ItemIdNew=205" 167103  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(177))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=1796  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
    }

    protected void ddlExamName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlExamName.SelectedValue == Convert.ToString(110))
        {
            lblSubject.Visible = true;
            ddlSubject.Visible = true;

            //Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=204";
            //DataSet ds = cc.ExecuteDataset(Sql);

            //ddlSubject.DataSource = ds.Tables[0];
            //ddlSubject.DataTextField = "Name";
            //ddlSubject.DataValueField = "ItemValueIdNew";
            //ddlSubject.DataBind();
        }
        else
        {
            lblSubject.Visible = false;
            ddlSubject.Visible = false;
        }
    }

    protected void btnGetData_Click(object sender, EventArgs e)
    {
        BindGridView();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {

        gvStudentData.AllowPaging = false; //This Line is for Export Data to Excel while Paging is Apply on gridView
        this.BindGridView();

        if (gvStudentData.Visible)
        {
            //Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=" + txtCenterNo.Text + ".xls");
            // Response.Charset = "";
            Response.ContentType = "application/excel";
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
            gvStudentData.RenderControl(hTextWriter);
            Response.Write(sWriter.ToString());
            Response.End();
        }
    }



}
