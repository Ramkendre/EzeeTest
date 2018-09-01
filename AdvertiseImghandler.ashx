<%@ WebHandler Language="C#" Class="AdvertiseImghandler" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class AdvertiseImghandler : IHttpHandler
{

    CommonCode cc = new CommonCode();
    public void ProcessRequest(HttpContext context)
    {
        string imageid = Convert.ToString(context.Request.QueryString["Id"]);

        try
        {
            string sql = "SELECT AdvContent FROM tblAdvertise WHERE Id ='" + imageid + "' ";
            DataSet ds = cc.ExecuteDataset(sql);
            context.Response.BinaryWrite(Convert.FromBase64String(ds.Tables[0].Rows[0]["AdvContent"].ToString()));
        }
        catch { }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}