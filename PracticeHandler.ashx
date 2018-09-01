<%@ WebHandler Language="C#" Class="PracticeHandler" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

public class PracticeHandler : IHttpHandler
{   
    CommonCode cc = new CommonCode();      
    public void ProcessRequest(HttpContext context)
    {

        string[] para = context.Request.QueryString["para"].Split(',');        

        try
        {
            string sql = "select " + para[1] + " from tblQuestionAccess  where SNO=" + para[0] + "";
            DataSet ds = cc.ExecuteDataset(sql);

            if (para[1].ToString() == "Qhint")
            {
                string valueHint = ds.Tables[0].Rows[0][0].ToString();
                string[] hintValue = valueHint.Split('₹');

                var temp = new List<string>();
                foreach (var s in hintValue)
                {
                    if (!string.IsNullOrEmpty(s))
                        temp.Add(s);
                }
                hintValue = temp.ToArray();

                if (hintValue.Length > 1)
                {
                    context.Response.BinaryWrite(Convert.FromBase64String(hintValue[0]));
                }
                else
                {
                    context.Response.BinaryWrite(Convert.FromBase64String(ds.Tables[0].Rows[0]["" + para[1] + ""].ToString()));
                }
            }
            else
            {
                context.Response.BinaryWrite(Convert.FromBase64String(ds.Tables[0].Rows[0]["" + para[1] + ""].ToString()));
            }
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
    