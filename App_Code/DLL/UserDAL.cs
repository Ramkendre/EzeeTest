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
public class UserDAL
{
    
    public UserDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    DataSet ds = new DataSet();
    int status;
    CommonCode cc = new CommonCode();
   

    public int _insertUser(UserBLL userbal)
    {
       
        //string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
        //using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "Insert into Login1(LoginId, UserName, Password, ContactNo,  Address, DOJ, Role, examid,CompanyId,Active ) Values ('" +userbal .LoginId   + "','" +userbal .UserName + "','" +cc.DESEncrypt( userbal .Password)  + "','" +userbal.ContactNo  + "', '" +userbal .Address  + "','" + userbal.DOJ + "','" +userbal.Role + "','" +userbal.Company   + "','" +userbal.CompanyId+ "' ,1) ";
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


    public int _updateUser(UserBLL userbal)
    {
        
        //string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
        //using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "Update Login1 set UserName='" + userbal.UserName + "', " +
                " Password='" + cc.DESEncrypt(userbal .Password ) + "', " +
               " ContactNo='" + userbal.ContactNo + "', " +
               " Address='" + userbal.Address + "' , " +
               " DOJ='" + userbal.DOJ + "', " +
               " Role=" + userbal.Role + ", " +
               " examid=" +userbal.Company + ", " +
                " CompanyId=" + userbal.CompanyId + " " +
               " Where LoginId='" + userbal.LoginId   + "'"; 
                
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

    public int _deleteUser(UserBLL userbal)
    {

        //string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
        //using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "Update Login1 set Active=0 where LoginId='" + userbal.LoginId + "'";
    

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


   

    public DataSet DALShowUserDetails(UserBLL user)
    {

        
        //string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
        //using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@LoginId", user.LoginId);

                //SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSelectUserDetails", par);
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spUserDetailsSelect", par);
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

    public int UpdateOwnDetails(UserBLL user)
    {

      
        
       // string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            
            try
            {
                SqlParameter[] par = new SqlParameter[6];
                par[0] = new SqlParameter("@LoginId", user.LoginId);
                par[1] = new SqlParameter("@UserName", user.UserName);
                par[2] = new SqlParameter("@Password", user.Password);
                par[3] = new SqlParameter("@ContactNo", user.ContactNo);
                par[4] = new SqlParameter("@Address", user.Address);
                par[5] = new SqlParameter("@Status", 11);
               
                par[5].Direction = ParameterDirection.Output;

             status =  SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spUserUpdateOWN", par);
                //status = (int)par[5].Value;
               
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


    public DataSet returnMenu(string LoginID)
    {

        
        //string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
        //using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string Sql = "select MenuId from Login1 where LoginId='" + LoginID + "'";
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