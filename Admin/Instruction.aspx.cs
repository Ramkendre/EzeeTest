using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.SqlClient;
using System.IO;

public partial class Admin_Instruction : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string Sql;

    protected void Page_Load(object sender, EventArgs e)
    {
        string TestID = Convert.ToString(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            if (TestID != "" && TestID != null)
            {
                loadTest(TestID);
            }
        }

    }

    public void loadTest(string TestID)
    {
        try
        {
            Sql = "select* from tblTestDefinition where Test_ID='" + TestID + "' ";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label1.Text = Convert.ToString(ds.Tables[0].Rows[0]["Exam_name"]);
                string duration = Convert.ToString(ds.Tables[0].Rows[0]["Exam_Duration"]);
                Label3.Text = duration + " Min";

                Label5.Text = Convert.ToString(ds.Tables[0].Rows[0]["MarkPass"]);

                int L1 = Convert.ToInt32(ds.Tables[0].Rows[0]["DLevel1"]);
                int L2 = Convert.ToInt32(ds.Tables[0].Rows[0]["DLevel2"]);
                int L3 = Convert.ToInt32(ds.Tables[0].Rows[0]["DLevel3"]);

                Label7.Text = Convert.ToString(L1 + L2 + L3);

                Label11.Text = cc.DTGet_Local(Convert.ToString(ds.Tables[0].Rows[0]["Exam_date"]));
                Label15.Text = Convert.ToString(ds.Tables[0].Rows[0]["MarkCorrA"]);
                Label9.Text = Convert.ToString(ds.Tables[0].Rows[0]["NegativeMark"]);
                if (Label9.Text == "Yes")
                {
                   string b = Convert.ToString(ds.Tables[0].Rows[0]["MarkforNegative"]);
                   Label13.Text = "- " + b;
                    Label12.Visible = true;
                    Label13.Visible = true;
                }
                else
                {
                    Label12.Visible = false;
                    Label13.Visible = false;
                }
            

            }

        }
        catch
        {
        }
    }



}
