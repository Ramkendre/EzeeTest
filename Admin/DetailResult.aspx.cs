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

public partial class DetailResult : System.Web.UI.Page
{
    string abc;
    protected void Page_Load(object sender, EventArgs e)
    {
        abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
       
        DisplayDetailResult();
      
    }
   
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void DisplayDetailResult()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
        try
        {
            int status = 0,index=0,rowcount=0,pg=0;
            string txtstatus="";
            string str = "select Question,Correct_Answer,Submitted,Status from tblExamQuestion ";
           
            con.Open();
            SqlCommand c = new SqlCommand(str,con);
          
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            
            rowcount =Convert.ToInt32(GridView1.Rows.Count.ToString());
            while (index < rowcount)
            {
                status =Convert.ToInt32(GridView1.Rows[index].Cells[3].Text);
                if (status == 0)
                {
                    txtstatus = "Not attempted";
                    GridView1.Rows[index].Cells[3].Text = txtstatus;

                }
                if (status == 1)
                {
                    txtstatus = "Correct";
                    GridView1.Rows[index].Cells[3].Text = txtstatus;
                }
                if (status == 2)
                {
                    txtstatus = "Wrong";
                    GridView1.Rows[index].Cells[3].Text = txtstatus;
                }
                index++;
            }


            int pageno = GridView1.PageIndex;
            if (pageno == 0)
            {
            }
            else
            {
               pageno *= 5;
            }

            int count = 0;
            SqlDataReader dr = c.ExecuteReader();
            while (dr.Read())
            {
                count++;
                Label1.Text = dr.GetValue(0).ToString();
                if (count > pageno)
                {
                    if (pg <= rowcount)
                    {
                        GridView1.Rows[pg].Cells[0].Text = Label1.Text;
                        pg++;
                    }
                }


            }
            dr.Close();

            
           
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
    }
    protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        DisplayDetailResult();
    }
    protected void btnback_Click(object sender, EventArgs e)
    {

    }
}
