using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SubAdmin_OMRShowResult : System.Web.UI.Page
{

    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }


    public void GetOMRMarksDetails()
    {
        DataSet ds = new DataSet();
        string sql = string.Empty;

        if (txtRollNo.Text == "" || txtRollNo.Text == null)
        {
            sql = "SELECT [ID],[RollNo],[TeacherORDefaultMobNo],[TestId],[InsertDate],[CorrectAnswersCount],[InCorrectAnswersCount],[NotAnsweredQuetionsCount],[TotalMarks] FROM [tblOMRScoreReport] WHERE [TeacherORDefaultMobNo]='" + txtIHMobile.Text.Trim() + "' and [TestId]='" + ddlSelectTest.SelectedValue + "'";
        }
        else
        {
            sql = "SELECT [ID],[RollNo],[TeacherORDefaultMobNo],[TestId],[InsertDate],[CorrectAnswersCount],[InCorrectAnswersCount],[NotAnsweredQuetionsCount],[TotalMarks] FROM [tblOMRScoreReport] WHERE [TeacherORDefaultMobNo]='" + txtIHMobile.Text.Trim() + "' and [TestId]='" + ddlSelectTest.SelectedValue + "' and [RollNo]='" + txtRollNo.Text.Trim() + "'";
        }

        ds = cc.ExecuteDataset(sql);
        gvShowResult.DataSource = ds.Tables[0];
        gvShowResult.DataBind();
    }

    public void bindDropDown()
    {
        DataSet ds = new DataSet();
        string sql = "SELECT [Test_ID],[Exam_name] FROM [tblTestDefinition] WHERE [LoginId]='" + txtIHMobile.Text.Trim() + "'";
        ds = cc.ExecuteDataset(sql);

        ddlSelectTest.DataSource = ds.Tables[0];
        ddlSelectTest.DataTextField = "Exam_name";
        ddlSelectTest.DataValueField = "Test_ID";
        ddlSelectTest.DataBind();
    }


    protected void btnGetData_Click(object sender, EventArgs e)
    {
        GetOMRMarksDetails();
    }
    protected void btnGetTest_Click(object sender, EventArgs e)
    {
        bindDropDown();
    }
    protected void gvShowResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShowResult.PageIndex = e.NewPageIndex;
        GetOMRMarksDetails();
    }
}