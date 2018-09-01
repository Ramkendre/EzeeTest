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
/// Summary description for stateDAL
/// </summary>
public class stateDAL
{
    int status;
    DataSet ds;
   

    public stateDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public int _insertstate(stateBAL sbal)
    {
       // string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
      //  using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "Insert into StateMaster(StateName, CountryId) Values ('" + sbal.StateName1 + "'," + Convert.ToString(sbal.CountryId1) + ") ";
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

    public int _updatestate(stateBAL sbal)
    {
       // string abc = " ;Initial Catalog= " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "Update StateMaster set StateName='" + sbal.StateName1 + "' where StateId=" + sbal.StateId1 + "  ";
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

    public DataSet _selectstate(stateBAL sbal)
    {
       // string abc = " ;Initial Catalog= " + Convert.ToString(HttpContext.Current.Session["DBName"]);
     //   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "Select StateId, StateName, CountryId from StateMaster where StateId=" + sbal.StateId1 + "";
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
        return ds;
    }

    public int _deletestate(stateBAL sbal)
    {
       // string abc = ";Initial Catalog=" + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "Delete from StateMaster where StateId=" + sbal.StateId1 + " ";
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

 


 }
 