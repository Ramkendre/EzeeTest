<%@ WebHandler Language="C#" Class="imageHandler" %>

using System;
using System.Web;
using System.Data;

public class imageHandler : IHttpHandler {

    CommonCode cc = new CommonCode();
    
    public void ProcessRequest (HttpContext context) {
        try
        {
            string[] para = context.Request.QueryString["para"].Split(',');        
            
            
           // string sql = "select " + para[1] + " from  " + para[2] + " where EQID=" + para[0] + "";
            string sql = " with t as   (  select ROW_NUMBER()over(order by " + para[2] + ".SNO)as EQID," + para[1] + " ,tblItemValue.ItemValueId, tblItemValue.ItemId, tblItemValue.Name from " + para[2] + "   inner join tblItemValue on tblItemValue.ItemValueId= " + para[2] + ".TypeofQues    " +
          " where TestID='" + para[3] + "'  )select * from t where EQID=" + para[0] + " ";
            //DataSet ds = cc.ExecuteDataset(sql,db);
            DataSet ds = cc.ExecuteDataset(sql);            //, "online exam atul");

            context.Response.BinaryWrite(Convert.FromBase64String(ds.Tables[0].Rows[0]["" + para[1] + ""].ToString()));
        }
        catch (Exception ex)
        {
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}