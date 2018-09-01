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

public partial class SubAdmin_NoRepeatQues : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string Sql;
    public int cRowID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;

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

        if (Convert.ToString(e.CommandName) == "Select Test")
        {
            Sql = "Select TypeofTest from tblTestDefinition where Test_ID='" + Id + "'";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(Sql);
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
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(140))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew=0 OR ItemIdNew=210";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(141))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=207 "; //16998
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(142))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=206  "; //17099
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(143))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=203";// 167103  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(144))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=205";// 167103  ";
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
    }
    #endregion

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        //string Login = "9999999999";
        string Login = Convert.ToString(Session["LoginId"]);
        string sql = "Select Test_ID,Exam_Name from tblTestDefinition where LoginId='" + Login + "' and TypeOFExam='" + Convert.ToInt32(ddlExamName.SelectedValue) + "' order by Test_ID Desc";

        DataSet ds = new DataSet();

        ds = cc.ExecuteDataset(sql);
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

        //string Login = "9999999999";
        string Login = Convert.ToString(Session["LoginId"]);
        string sql = "Select Test_ID,Exam_Name from tblTestDefinition where LoginId='" + Login + "' and TypeOFExam='" + Convert.ToInt32(ddlExamName.SelectedValue) + "' order by Test_ID Desc";

        DataSet ds = new DataSet();

        ds = cc.ExecuteDataset(sql);
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

    protected void ddlExamName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlClassName.Enabled = true;
        //Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=211 ";
        //DataSet ds = cc.ExecuteDataset(Sql);

        //ddlClassName.DataSource = ds.Tables[0];
        //ddlClassName.DataTextField = "Name";
        //ddlClassName.DataValueField = "ItemValueIdNew";
        //ddlClassName.DataBind();
    }



    protected void btnAddTest_Click(object sender, EventArgs e)
    {
        string gvSNO = "";
        for (int i = 0; i < gvBindTestName.Rows.Count; i++)
        {
            CheckBox chkbox = (CheckBox)gvBindTestName.Rows[i].Cells[3].FindControl("chk1");

            if (chkbox != null)
            {
                if (chkbox.Checked == true)
                {
                    gvSNO += Convert.ToString(gvBindTestName.DataKeys[i].Value) + ",";

                }
            }
            chkbox.Checked = false;
        }

        if (gvSNO == "")
        {
            lblalert.Text = "Please select atleast one Test  !!!";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select atleast one Test  !!!')", true);
        }

        else if (gvSNO != "")
        {
            gvSNO = gvSNO.Substring(0, gvSNO.Length - 1);
        }



        string TestIDSet = gvSNO;

        if (TestIDSet != "")
        {
            string[] splitid = TestIDSet.Split(',');



            if (splitid.Length > 0)
            {
                for (int i = 0; i < splitid.Length; i++)
                {

                    Sql = "Select Test_ID from tblNoRepeatQues where Test_ID=" + splitid[i] + "";
                    string TestIDVal = Convert.ToString(cc.ExecuteScalar(Sql));

                    if (TestIDVal == "")
                    {
                        Sql = "insert into tblNoRepeatQues select Test_ID,Exam_Name,TypeOFExam,Class_Id,LoginId from tblTestDefinition where Test_ID=" + splitid[i] + "";

                        int status1 = cc.ExecuteNonQuery(Sql);

                        if (status1 >= 1)
                        {
                            lblalert.ForeColor = System.Drawing.Color.Green;
                            lblalert.Text = "Test Added Successfully !!!";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "msg(' " + status1 + " Test Added Successfully')", true);
                            MultiView1.SetActiveView(View2);
                        }
                        else
                        {
                            lblalert.ForeColor = System.Drawing.Color.Red;
                            lblalert.Text = "Test <>Not<> Added Successfully !!!";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Selected Test Already Exist.');", true);
                            MultiView1.SetActiveView(View2);
                        }
                    }
                    else
                    {

                        lblalert.ForeColor = System.Drawing.Color.Red;
                        lblalert.Text = "Test Already Exist !!!";
                        MultiView1.SetActiveView(View2);
                    }
                }
            }
        }
        else
        {
            lblalert.Text = "Please select atleast one Test  !!!";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select atleast one Test  !!!')", true);
        }
    }
}
