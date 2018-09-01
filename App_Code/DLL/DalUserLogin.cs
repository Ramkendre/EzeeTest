using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


/// <summary>
/// Summary description for DalUserLogin
/// </summary>
public class DalUserLogin

{
   // SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    // BllUserLogin blllogin = new BllUserLogin();

     public bool login(BllUserLogin blllogin)
     {
         string row = "";
         SqlDataReader dr;
         bool flag = false;
         DataSet ds = new DataSet();
       //  string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       //  using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
         using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
         try
         {
               SqlParameter[] par = new SqlParameter[4];
                 par[0] = new SqlParameter("@Name",blllogin.Name1);
                 par[1] = new SqlParameter("@Password", blllogin.Password1);                
                 par[2] = new SqlParameter("@Status", 11);
                 par[2].Direction = ParameterDirection.Output;
                 using (dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "studentlogin", par))
                 {

                     if (dr.HasRows)
                     {
                         dr.Read();
                         row = "1";
                         blllogin.Student_id1 = Convert.ToInt32(Convert.ToString(dr["Student_id"]));
                     }
                 }
             

         }
         catch (SqlException ex)
         {
             throw ex;
         }
         finally
         {
        con.Close();
         }
         if (row != "")
         {
             flag = true;
         }
         return flag;
     }
        


    public DalUserLogin()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
