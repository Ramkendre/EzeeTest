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

/// <summary>
/// Summary description for cityDAL
/// </summary>
public class cityDAL
{
    int status;
    DataSet ds;
	public cityDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int _insertcity(cityBAL cbal)
    {       
       // string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
        //using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "Insert into CityMaster(CityName, DistrictId) Values ('" +cbal .CityName1  + "'," + Convert .ToString ( cbal .DistrictId1)  + ") ";
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

    public int _updatecity(cityBAL cbal)
    {       
      //  string abc=";Initial Catalog="+Convert .ToString (HttpContext .Current .Session ["DBName"]);
       // using (SqlConnection con=new SqlConnection (ConfigurationManager .AppSettings ["ConnectionString"]+abc ))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
          try 
            {
               string sql="Update CityMaster set CityName='" +cbal .CityName1 + "' , "+
                        " DistrictId="+Convert .ToString (cbal .DistrictId1 )+" where CityId=" + cbal .CityId1  + "  ";
                status =SqlHelper .ExecuteNonQuery (con,CommandType .Text ,sql );
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

     public int _deletecity(cityBAL cbal)
     {        
       //  string abc = ";Initial Catalog=" + Convert.ToString(HttpContext.Current.Session["DBName"]);
         //using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
         using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
         {
             try
             {
                 string sql = "Delete from CityMaster where CityId=" + cbal .CityId1  + "";
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
    
    public DataSet _selectcity(cityBAL cbal)
    {
       // string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
        //using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))  
        try
            {
                string sql = "Select CityId, CityName, DistrictId from CityMaster where CityId=" + cbal.CityId1 + "";
 
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
        return ds;
    }


    public DataSet citywise(string DistrictId)
    {
       // string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
        //using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))  
        try
            {
               // string sql = "Select CityId, CityName, DistrictId from CityMaster where CityId=" + DistrictId+ "";
                string sql = "SELECT  CityMaster.CityId as Id, CityMaster.CityName as Name, DistrictMaster.DistrictName,  StateMaster.StateName, CountryMaster.CountryName   FROM         DistrictMaster INNER JOIN  StateMaster ON DistrictMaster.StateId = StateMaster.StateId INNER JOIN   CountryMaster ON StateMaster.CountryId = CountryMaster.CountryId INNER JOIN   CityMaster ON DistrictMaster.DistrictId = CityMaster.DistrictId Where DistrictMaster.DistrictId=" + DistrictId + "";
            
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
        return ds;
    }

}
