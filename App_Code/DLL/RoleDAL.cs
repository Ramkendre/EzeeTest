using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.IO;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for CityDAL
/// </summary>
public class RoleDAL
{

    public RoleDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    DataSet ds = new DataSet();
    int status;




    public DataSet DALGetAllRole(string roleid)
    {
        string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]+abc))
        {
            try
            {
               string Sql = "Select b.RoleId as Id, b.RoleName as Name,b.Describ as Describtion,a.Reference,a.RoleName as PrentRolename from Role a,Role b where b.parentrole=a.RoleId  Order by Id  ";
                //string Sql = "Select b.RoleId as Id, b.RoleName as Name,b.Describ as Describtion,a.Reference,b.Reference,a.RoleName " +
                //             " as PrentRolename from Role a,Role b where b.parentrole=a.RoleId  and b.reference is not null " +
                //             " and b.reference=" + roleid + " Order by Id  ";
               // SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSelectUserDetails", par);
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text,Sql);
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