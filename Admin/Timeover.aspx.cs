using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Drawing;



public partial class Timeover : System.Web.UI.Page
{    
    string abc;
    protected void Page_Load(object sender, EventArgs e)
    {
          abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
         
    }
    protected void btnScore_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
        try
        {
           
            
            
            int correct = 0, wrong = 0, attempted = 0, notattempted = 0;
            con.Open();
            string st = "Select count(EQ_id) from tblExamQuestion where Status=" + 1 + "";
            SqlCommand cm = new SqlCommand(st, con);
            SqlDataReader d = cm.ExecuteReader();
            d.Read();
            correct = Convert.ToInt32(d.GetValue(0).ToString());
            d.Close();

            string st1 = "Select count(EQ_id) from tblExamQuestion where Status=" + 2 + "";
            SqlCommand cm1 = new SqlCommand(st1, con);
            SqlDataReader d1 = cm1.ExecuteReader();
            d1.Read();
            wrong = Convert.ToInt32(d1.GetValue(0).ToString());
            d1.Close();

            string st2 = "Select count(EQ_id) from tblExamQuestion where Status=" + 0 + "";
            SqlCommand cm2 = new SqlCommand(st2, con);
            SqlDataReader d2 = cm2.ExecuteReader();
            d2.Read();
            notattempted = Convert.ToInt32(d2.GetValue(0).ToString());
            d2.Close();


            attempted = correct + wrong;

           // tbl.Attributes.Add("Style", "visibility: Visible");
            
            lbltattempt.Text = attempted.ToString();
            lbltcorrect.Text = correct.ToString();
            lbltwrong.Text = wrong.ToString();

            

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {
            con.Close();
        }
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
    protected void linkbtnDetail_Click(object sender, EventArgs e)
    {
        Response.Redirect("DetailResult.aspx");
    }
}
