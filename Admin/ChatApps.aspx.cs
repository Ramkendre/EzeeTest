using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Linq;


public partial class Admin_ChatApps : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void GetOnline() //add on 6.12.13
    {
        string sql = "select  userid from DemoOnline where userid='" + Session["LoginId"] + "' and status='Active'";
        DataSet ds = ExecuteDataset(sql);
        gvUseronline.DataSource = ds.Tables[0];
        gvUseronline.DataBind();
    }
    protected void AutoRefreshTimer_Tick(object sender, EventArgs e)
    {
        GetOnline();
    }
    public DataSet ExecuteDataset(string Sql)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;
    }
}
