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
    CommonCode cc = new CommonCode();
    string username,abc;
    protected void Page_Load(object sender, EventArgs e)
    {

        username = Convert.ToString(Session["LoginId"]);
       
    }
    protected void btnScore_Click(object sender, EventArgs e)
    {
          try
           {
              int correct =0, wrong =0, attempted = 0, notattempted =0;
             
              string Sql = "Select count(EQ_id)as EQ_id from tblExamQuestion where Status=" + 1 + " and LoginId='" + username + "'";
              DataSet ds = cc.ExecuteDataset(Sql);
              correct=Convert.ToInt32( ds.Tables[0].Rows[0]["EQ_id"]);
             
 
              string Sql2 = "Select count(EQ_id)as EQ_id  from tblExamQuestion where Status=" + 2 + "and LoginId='" + username + "'";
              DataSet ds2 = cc.ExecuteDataset(Sql2);
              wrong = Convert.ToInt32(ds2.Tables[0].Rows[0]["EQ_id"]);
             

              string Sql3 = "Select count(EQ_id)as EQ_id  from tblExamQuestion where Status=" + 0 + "and LoginId='" + username + "'";
              DataSet ds3 = cc.ExecuteDataset(Sql3);
              notattempted =Convert.ToInt32(ds2.Tables[0].Rows[0]["EQ_id"]);
             

             attempted = correct + wrong ;

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
