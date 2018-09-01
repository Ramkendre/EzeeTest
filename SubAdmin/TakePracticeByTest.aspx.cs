using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.UI.HtmlControls;


public partial class SubAdmin_Default : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string Sql;
    public int cRowID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        // MultiView1.SetActiveView(View2);
    }


    protected void gvBindTestName_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //GridViewRow row = e.Row;
        //if (row.RowType == DataControlRowType.DataRow)
        //{
        //    row.Attributes["id"] = cRowID.ToString();
        //    cRowID++;
        //}   
    }

    protected void gvBindTestName_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Id = Convert.ToString(e.CommandArgument);

        if (Convert.ToString(e.CommandName) == "Give Test")
        {
            Sql = "SELECT TypeofTest FROM tblTestDefinition WHERE Test_ID='" + Id + "'";
            DataSet ds = cc.ExecuteDataset(Sql);

            string val = ds.Tables[0].Rows[0]["TypeofTest"].ToString();

            if (val == (0).ToString())
            {
                Response.Redirect("~/SubAdmin/TakePracticeByTest1.aspx?Id=" + Id);
            }
            else
            {
                lblalert.Text = "This Test For Paid User !!! Please Contact Us for further Test";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Test For Premium User !!!')", true);
                MultiView1.SetActiveView(View2);
            }
        }
    }

    #region BinddropdownExamName

    protected void ddlGroupofExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGroupofExam.SelectedValue == Convert.ToString(135))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=212  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else  if (ddlGroupofExam.SelectedValue == Convert.ToString(136))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=213  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else  if (ddlGroupofExam.SelectedValue == Convert.ToString(137))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=214  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(257))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=257  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(140))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=210  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(141))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=207 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(142))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=206  ";
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
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=205";// 167103  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(177))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=1796";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(231))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=2310";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if(ddlGroupofExam.SelectedValue == Convert.ToString(273))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 273";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(274))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 274";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(275))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 275";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(276))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 276";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(277))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 277";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(278))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 278";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(445))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 445";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(455))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 455";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
    }
    #endregion

    public string GetLoginNumber()
    {
        string loginNumber = string.Empty;
        string sqlQuery = "SELECT [loginname],[UnderUsername],[roleid] FROM [Admin_SubUser] WHERE [UnderUsername]='" + Convert.ToString(Session["LoginId"]) + "' ";
        DataSet ds = cc.ExecuteDataset(sqlQuery);

        if (ds.Tables[0].Rows[0][2].ToString() == "10")
        {
            loginNumber = ds.Tables[0].Rows[0][0].ToString() + "," + ds.Tables[0].Rows[0][1].ToString();
        }
        else if (ds.Tables[0].Rows[0][2].ToString() == "3")
        {
            loginNumber = ds.Tables[0].Rows[0][1].ToString();
        }
        else if (ds.Tables[0].Rows[0][2].ToString() == "21")
        {
            loginNumber = ds.Tables[0].Rows[0][0].ToString() + "," + ds.Tables[0].Rows[0][1].ToString();
        }
        else
        {
            loginNumber = Convert.ToString(Session["LoginId"]);
        }

        return loginNumber;
    }

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        string Login = GetLoginNumber();

        string sql = "SELECT Test_ID,Exam_Name FROM tblTestDefinition WHERE LoginId='" + Login + "' AND TypeOFExam='" + Convert.ToInt32(ddlExamName.SelectedValue) + "' ORDER BY Test_ID DESC";

        DataSet ds = cc.ExecuteDataset(sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            gvBindTestName.DataSource = ds.Tables[0];
            gvBindTestName.DataBind();
        }

        MultiView1.SetActiveView(View2);
    }
    protected void gvBindTestName_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBindTestName.PageIndex = e.NewPageIndex;

        string Login = GetLoginNumber();

        string sql = "SELECT Test_ID,Exam_Name FROM tblTestDefinition WHERE LoginId='" + Login + "' AND TypeOFExam='" + Convert.ToInt32(ddlExamName.SelectedValue) + "' ORDER BY Test_ID DESC";

        DataSet ds = cc.ExecuteDataset(sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            gvBindTestName.DataSource = ds.Tables[0];
            gvBindTestName.DataBind();
        }

        MultiView1.SetActiveView(View2);
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
}
