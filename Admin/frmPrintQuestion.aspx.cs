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

public partial class Admin_frmPrintQuestion : System.Web.UI.Page
{
    string Sql;
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        string TestID = Convert.ToString(Request.QueryString["Id"]);

        if (!IsPostBack)
        {
            data(TestID);
            loadTest(TestID);
            loadCollegeName();
        }
    }


    public void loadCollegeName()
    {
        int companyId = Convert.ToInt32(Session["CompanyId"]);

        Sql = "SELECT DisplayName FROM CompanyMaster WHERE CompanyId = " + companyId + " ";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCollegeName.Text = Convert.ToString(ds.Tables[0].Rows[0]["DisplayName"]);
        }
    }

    public void loadTest(string TestID)
    {
        try
        {
            Sql = "SELECT * FROM tblTestDefinition WHERE Test_ID='" + TestID + "' ";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTestName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Exam_name"]);
                string duration = Convert.ToString(ds.Tables[0].Rows[0]["Exam_Duration"]);
                lblExamDurration.Text = duration + " Min";
            }
        }
        catch
        {
        }
    }

    Button btnMove = null;

    void data(string TestID)
    {
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            string s11 = "tbl5164";
            string sql = "SELECT SNO FROM  " + s11 + " WHERE  TestID='" + TestID + "' ";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Session["SNO"] = 1;
            Session["TestID"] = TestID; //new line added by me

            lblTotalQue.Text = Convert.ToString(ds.Tables[0].Rows.Count);

            for (int i = 1; i <= ds.Tables[0].Rows.Count;)
            {
                Control ctl = LoadControl("../userControl/showQuestion.ascx");
                ctl.ID = "UC" + i;
                i = i + 1;

                td1.Controls.Add(ctl);
            }
        }
        catch
        {

        }
    }

    protected void btnMove_Click(object s, EventArgs e)
    {
        string id = btnMove.ID;
    }
}