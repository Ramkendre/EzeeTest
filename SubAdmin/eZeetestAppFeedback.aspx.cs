using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class SubAdmin_eZeetestAppFeedback : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
 
        }
    }

    public void GetFeedBackDetails()
    {
        DataSet ds = new DataSet();
        string sqlQuery = " SELECT [firstName],[lastName],[userMobNo],[imei],[typeOfFeedback],[feedbackContent],[feedbackDate] FROM [tblFeedback] WHERE [typeOfFeedback]='" + ddlSelectFeedback.SelectedItem.Text + "' and [feedbackDate] BETWEEN '" + txtFromDate.Text + "' AND '" + txtToDate.Text + "'";
        ds = cc.ExecuteDataset(sqlQuery);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            gvShowResult.DataSource = ds.Tables[0];
            gvShowResult.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('No Data Found for this Combination.!!!')", true);
        }
    }

    protected void btnGetData_Click(object sender, EventArgs e)
    {
        GetFeedBackDetails();
    }

    protected void btnGetTest_Click(object sender, EventArgs e)
    {

    }

    protected void gvShowResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShowResult.PageIndex = e.NewPageIndex;
        GetFeedBackDetails();
    }
}