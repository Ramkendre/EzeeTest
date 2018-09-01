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

public partial class SubAdmin_TakePrintOut : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    public int cRowID = 0;
    string Sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        string Login = Convert.ToString(Session["LoginId"]);

        Sql = "SELECT Test_ID,Exam_Name FROM tblTestDefinition WHERE LoginId='" + Login + "' ORDER BY Test_ID DESC";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvBindTestNamesForPrint.DataSource = ds.Tables[0];
            gvBindTestNamesForPrint.DataBind();
        }
    }
    protected void gvBindTestNamesForPrint_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Id = Convert.ToString(e.CommandArgument);

        if (Convert.ToString(e.CommandName) == "TakePrintOut")
        {
            Sql = "SELECT TypeofTest,GroupOfQuestion FROM tblTestDefinition WHERE Test_ID='" + Id + "'";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(Sql);
            string flag = (ds.Tables[0].Rows[0][0].ToString());
            string groupQues = Convert.ToString(ds.Tables[0].Rows[0][1]);
            if (flag == Convert.ToString(0))
            {
                if (groupQues == Convert.ToString(0))
                {
                    Response.Redirect("~/Admin/frmPrintQuestion.aspx?Id=" + Id);
                }
                else
                {
                    Response.Redirect("~/Admin/frmPrintTheoryQues.aspx?Id=" + Id);
                }
            }
            else
            {
                lblError.Text = "This Test for Premium User!!! for Further Please Conatct Us. ";
            }

            
        }
    }
    protected void gvBindTestNamesForPrint_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //GridViewRow row = e.Row;
        //if (row.RowType == DataControlRowType.DataRow)
        //{
        //    row.Attributes["id"] = cRowID.ToString();
        //    cRowID++;
        //}
    }
    protected void gvBindTestNamesForPrint_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBindTestNamesForPrint.PageIndex = e.NewPageIndex;
        string Login = Convert.ToString(Session["LoginId"]);

        Sql = "SELECT Test_ID,Exam_Name FROM tblTestDefinition WHERE LoginId='" + Login + "' ORDER BY Test_ID DESC";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvBindTestNamesForPrint.DataSource = ds.Tables[0];
            gvBindTestNamesForPrint.DataBind();
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // Response.Redirect("~/CreateTest/createtest.aspx");
    }
}
