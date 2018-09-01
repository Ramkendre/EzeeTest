<%@ WebHandler Language="C#" Class="GetGridImageHandler" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class GetGridImageHandler : IHttpHandler {

    CommonCode cc = new CommonCode();
    public void ProcessRequest(HttpContext context)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        //string strcon = ConfigurationManager.AppSettings["ConnectionString"].ToString();

        string[] imageid = context.Request.QueryString["SNO1"].Split(',');
        con.Open();
        string sql = "Select Question from tblQuestionAccess Where SNO= " + imageid[0] + " ";
        DataSet ds = cc.ExecuteDataset(sql);
        context.Response.BinaryWrite(Convert.FromBase64String(ds.Tables[0].Rows[0]["Question"].ToString()));
        //context.Response.BinaryWrite((Byte[])dr[0]);
        //con.Close();
        //context.Response.End();
                
        
        
        
        
        
      
        //try
        //{

        //    string[] SNO1 = context.Request.QueryString["SNO"].Split(',');
        //    string sql = "Select Question from tblQuestionAccess where SNO = '7950'";

        //    DataSet ds = cc.ExecuteDataset(sql);
        //    context.Response.BinaryWrite(Convert.FromBase64String(ds.Tables[0].Rows[0][""+SNO1[1]+""].ToString()));
            

        //}
        //catch
        //{ 
        //}
    } 

       
        
   
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}