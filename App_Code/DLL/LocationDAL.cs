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
public class LocationDAL
{
    public LocationDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    DataSet ds = new DataSet();
    int status;

    public DataSet DALGetAllState()
    {

       // string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
        //using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string Sql = "Select StateId as Id, StateName as Name, 'India' as CountryName from StateMaster Order by StateName ";

                //SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSelectUserDetails", par);
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
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
    public DataSet DALGetAllState_default()
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringDB"]))
        {
            try
            {
                string Sql = "Select StateId as Id, StateName as Name, 'India' as CountryName from StateMaster Order by StateName ";

                //SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSelectUserDetails", par);
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
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
    public DataSet DALGetAllDistrict(string StateId)
    {
        //string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);

       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string Sql = "SELECT     DistrictMaster.DistrictId as Id, DistrictMaster.DistrictName as Name, " +
                    " StateMaster.StateName, CountryMaster.CountryName " +
                " FROM         DistrictMaster INNER JOIN " +
                    " StateMaster ON DistrictMaster.StateId = StateMaster.StateId INNER JOIN " +
                    " CountryMaster ON StateMaster.CountryId = CountryMaster.CountryId  " +
                " Where StateMaster.StateId=" + StateId + " order by DistrictMaster.DistrictName ";

                //SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSelectUserDetails", par);
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
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

    public DataSet DALGetAllDistrict_default(string StateName)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringDB"]))
        {
            try
            {
                string Sql = "SELECT     DistrictMaster.DistrictId as Id, DistrictMaster.DistrictName as Name, " +
                    " StateMaster.StateName, CountryMaster.CountryName " +
                " FROM         DistrictMaster INNER JOIN " +
                    " StateMaster ON DistrictMaster.StateId = StateMaster.StateId INNER JOIN " +
                    " CountryMaster ON StateMaster.CountryId = CountryMaster.CountryId " +
                " Where StateMaster.StateName='" + StateName + "' order by DistrictMaster.DistrictName";

                //SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSelectUserDetails", par);
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
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

    public DataSet DALGetAllCity(string DistrictId)
    {

        //string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string Sql = "SELECT     CityMaster.CityId as Id, CityMaster.CityName as Name, DistrictMaster.DistrictName, " +
                    " StateMaster.StateName, CountryMaster.CountryName " +
                " FROM         DistrictMaster INNER JOIN " +
                      " StateMaster ON DistrictMaster.StateId = StateMaster.StateId INNER JOIN " +
                      " CountryMaster ON StateMaster.CountryId = CountryMaster.CountryId INNER JOIN " +
                      " CityMaster ON DistrictMaster.DistrictId = CityMaster.DistrictId" +
                " Where DistrictMaster.DistrictId=" + DistrictId + " order by CityMaster.CityName";

                //SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSelectUserDetails", par);
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
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

    // City means taluka in DB
    public DataSet DALGetAllCity_default(string DistrictName)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringDB"]))
        {
            try
            {
                string Sql = "SELECT     CityMaster.CityId as Id, CityMaster.CityName as Name, DistrictMaster.DistrictName, " +
                    " StateMaster.StateName, CountryMaster.CountryName " +
                " FROM         DistrictMaster INNER JOIN " +
                      " StateMaster ON DistrictMaster.StateId = StateMaster.StateId INNER JOIN " +
                      " CountryMaster ON StateMaster.CountryId = CountryMaster.CountryId INNER JOIN " +
                      " CityMaster ON DistrictMaster.DistrictId = CityMaster.DistrictId" +
                " Where DistrictMaster.DistrictName='" + DistrictName + "' order by CityMaster.CityName";

                //SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSelectUserDetails", par);
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
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
    // City means taluka in DB
    public DataSet DALGetAllCity()
    {

      //  string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string Sql = "SELECT     CityMaster.CityId as Id, CityMaster.CityName as Name, DistrictMaster.DistrictName, " +
                    " StateMaster.StateName, CountryMaster.CountryName " +
                " FROM         DistrictMaster INNER JOIN " +
                      " StateMaster ON DistrictMaster.StateId = StateMaster.StateId INNER JOIN " +
                      " CountryMaster ON StateMaster.CountryId = CountryMaster.CountryId INNER JOIN " +
                      " CityMaster ON DistrictMaster.DistrictId = CityMaster.DistrictId   order by CityMaster.CityName ";


                //SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSelectUserDetails", par);
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
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


    public DataSet _GetCollegeName()
    {       
  //      string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        try
            {
                string sql = "select CompanyId as Id,CompanyName as Name from CompanyMaster";
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
    public DataSet _GetCollegeNamecid(string cid)
    {       
   //     string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
     //   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        try
            {
                string sql = "select CompanyId as Id,CompanyName as Name from CompanyMaster where CompanyId= " + cid + "";
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

    // Taluka means city in DB
    public DataSet DALGetAllTaluka_default(string TalukaName)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringDB"]))
        {
            try
            {
                string Sql = "SELECT     TalukaMaster.TalukaId as Id, TalukaMaster.TalukaName as Name,CityMaster.CityName as Taluka,  DistrictMaster.DistrictName, " +
                    " StateMaster.StateName, CountryMaster.CountryName " +
                " FROM         DistrictMaster INNER JOIN " +
                      " StateMaster ON DistrictMaster.StateId = StateMaster.StateId INNER JOIN " +
                      " CountryMaster ON StateMaster.CountryId = CountryMaster.CountryId INNER JOIN " +
                      " CityMaster ON DistrictMaster.DistrictId = CityMaster.DistrictId INNER JOIN " +
                      " TalukaMaster ON CityMaster.CityID = TalukaMaster.CityID" +
                " Where CityMaster.CityName='" + TalukaName + "' order by Talukamaster.TalukaName";

                //SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSelectUserDetails", par);
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
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
    // Taluka means city in DB
    public DataSet DALGetAllTaluka(string Talukaid)
    {

  //      string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string Sql = "SELECT     TalukaMaster.TalukaId as Id, TalukaMaster.TalukaName as Name,CityMaster.CityName as Taluka,  DistrictMaster.DistrictName, " +
                    " StateMaster.StateName, CountryMaster.CountryName " +
                " FROM         DistrictMaster INNER JOIN " +
                      " StateMaster ON DistrictMaster.StateId = StateMaster.StateId INNER JOIN " +
                      " CountryMaster ON StateMaster.CountryId = CountryMaster.CountryId INNER JOIN " +
                      " CityMaster ON DistrictMaster.DistrictId = CityMaster.DistrictId INNER JOIN " +
                      " TalukaMaster ON CityMaster.CityID = TalukaMaster.CityID" +
                " Where CityMaster.CityID='" + Talukaid + "' order by Talukamaster.TalukaName";

                //SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSelectUserDetails", par);
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
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