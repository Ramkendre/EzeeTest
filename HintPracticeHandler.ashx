<%@ WebHandler Language="C#" Class="HintPracticeHandler" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class HintPracticeHandler : IHttpHandler
{

    CommonCode cc = new CommonCode();

    public void ProcessRequest(HttpContext context)
    {
        string[] para = context.Request.QueryString["para"].Split(',');

        try
        {
            string sql = "select " + para[1] + " from tblQuestionAccess  where SNO=" + para[0] + "";
            DataSet ds = cc.ExecuteDataset(sql);

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
                context.Response.BinaryWrite(Convert.FromBase64String(hintValue[1]));
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

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}