using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for AndroidClassApp_StoreProc
/// </summary>
public class AndroidClassApp_StoreProc
{
	public AndroidClassApp_StoreProc()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public string ExcuteStoreproce(string storeprocName, SqlParameter[] par)
    {
        string Data = "";
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                Data = Convert.ToString(SqlHelper.ExecuteNonQuery(con,CommandType.StoredProcedure, storeprocName, par));
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
        return Data;
    }

}