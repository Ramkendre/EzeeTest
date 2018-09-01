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
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for DistricDAL
/// </summary>
public class DistricDAL
{
    DataSet ds;
    int status;
	public DistricDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int _insertDistric(DistricBAL dbal)
    {  

        //string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
      //  using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "Insert into DistrictMaster(DistrictName, StateId) Values ('" +dbal .DistrictName1  + "'," + Convert .ToString (dbal .StateId1 ) + ") ";
                 status = SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql);
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
        return status;
    }

 public int _updateDidtric(DistricBAL dbal)
 {     
   //  string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
   //  using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
     using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
     {
         try
         {
             string sql = "Update DistrictMaster set DistrictName='" +dbal .DistrictName1  + "', " +
                        " StateId=" + Convert .ToString (dbal .StateId1 ) + " where DistrictId=" + dbal .DistrictId1  + "  ";
             status = SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql);
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
     return status;
 }

public DataSet _selectDistric(DistricBAL dbal)
{
  //  string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
  //  using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    {
        try
        {
            string sql = "Select DistrictId, DistrictName, StateId from DistrictMaster where DistrictId=" +dbal .DistrictId1+ "";
            ds = SqlHelper.ExecuteDataset(con, CommandType.Text, sql);
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
    return ds ;
}

public int _deleteDistric(DistricBAL dbal)
{
   // string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
   // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    {
        try
        {
            string sql = "Delete from DistrictMaster where DistrictId=" + dbal.DistrictId1 + " ";
            status = SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
        return status;
    }

}



}
