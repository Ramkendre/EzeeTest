<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

public class ImageHandler : IHttpHandler
{
    
    
    CommonCode cc = new CommonCode();      
    public void ProcessRequest(HttpContext context)
    {

        string imageid = context.Request.QueryString["QId"];

       // string imageid = context.Request.QueryString["QId"];

        string[] img = imageid.Split(' ');
        
        try
        {

            if (img[0].ToString() != null && img[0].ToString() != null )
            {
                string db = img[1].ToString() + ' ' + img[2].ToString() + ' ' + img[3].ToString();
                
                string sql = "select Image from tblQuestion where Question_id=" + img[0].ToString() + "";
                DataSet ds = cc.ExecuteDataset(sql,db);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    context.Response.BinaryWrite((Byte[])ds.Tables[0].Rows[0]["Image"]);
                  
                }                
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
    //string strcon = ConfigurationManager.AppSettings["ConnectionString"].ToString();
    //public void ProcessRequest(HttpContext context)
    //{


    //    string imageid = context.Request.QueryString["EmpId"];
    //    if (imageid != null)
    //    {
    //    SqlConnection connection = new SqlConnection(strcon);
    //    connection.Open();
    //    SqlCommand command = new SqlCommand("select ImageD from Employee where EmpId=" + imageid, connection);
    //    SqlDataReader dr = command.ExecuteReader();
    //    dr.Read();
    //    context.Response.BinaryWrite((Byte[])dr[0]);
    //    connection.Close();
    //    context.Response.End();
    //   }
        //string imageid = context.Request.QueryString["AddmissionId"];
        //if (imageid != null)
        //{
        //    SqlConnection connection = new SqlConnection(strcon);
        //    connection.Open();
        //    SqlCommand command = new SqlCommand("select ImageD from Addmissionmaster where AddmissionId=" + imageid, connection);
        //    SqlDataReader dr = command.ExecuteReader();
        //    dr.Read();
        //    context.Response.BinaryWrite((Byte[])dr[0]);
        //    connection.Close();
        //    context.Response.End();
        //}
    //}
 
    //public bool IsReusable {
    //    get {
    //        return false;
    //    }
    //}

