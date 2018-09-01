using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for RegistrationDal
/// </summary>
public class RegistrationDal
{
    //SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    //RegistrationBll rbll=new RegistrationBll ();

    public  int inseret(RegistrationBll regbll)
    {
    
        int row;
        DataSet ds = new DataSet();
       // string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        try
            { 
            
                SqlParameter[] par=new SqlParameter[4];
                par[0] =new SqlParameter("@Name",regbll.Name1);
                par[1]=new SqlParameter("@Password",regbll.Password);
                par[2]=new SqlParameter("@Confirmpass",regbll.Cpwd);
                par[3] = new SqlParameter("@Status", 11);
                par[3].Direction = ParameterDirection.Output;

                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "insert_student", par);
           
            return row;
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
    public bool isExist(RegistrationBll regbll)
    {
      
        string row = "";
        bool flag = false;
        DataSet ds = new DataSet();
       // string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"])) 
        try
        {  
            SqlParameter[] par = new SqlParameter[4];

                par[0] = new SqlParameter("@Name",regbll.Name1);
                par[1] = new SqlParameter("@Password", regbll.Password);
                par[2] = new SqlParameter("@Confirmpass", regbll.Cpwd);
                par[3] = new SqlParameter("@Status", 11);
                par[3].Direction = ParameterDirection.Output;
                row = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "checkUserRec", par));
           

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

    public bool isExistName(RegistrationBll regbll)
    {
     
        bool flag = false;
        string row = "";
        DataSet ds = new DataSet();
       // string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
      //  using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        try
        {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@Name", regbll.Name1);
                par[1] = new SqlParameter("@Status", 11);
                par[1].Direction = ParameterDirection.Output;
                row = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "checkUserName", par));
            

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

   public List<RegistrationBll>Load()
    {
        SqlDataReader dr;
        
        List<RegistrationBll> studList = new List<RegistrationBll>();
        DataSet ds = new DataSet();
       // string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        try
        {
          
                using (dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "loadStudent"))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            RegistrationBll regbll=new RegistrationBll();
                            regbll.Student_id=Convert.ToInt32(Convert.ToString(dr["Student_id"]));
                            regbll.Name1=Convert.ToString(dr["Name"]);
                            regbll.Cpwd=Convert.ToString(dr["Confirmpass"]);
                            studList.Add(regbll);
                                
                        }
                    }
               
            }
            return studList;
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
         public int update(RegistrationBll regbll)
    {

        int row;
        DataSet ds = new DataSet();
      //  string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        try
        {
          
           
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@Student_id",regbll.Student_id);
                par[1] = new SqlParameter("@Name", regbll.Name1);
                par[2] = new SqlParameter("@Password",regbll.Password);
                par[3] = new SqlParameter("@Confirmpass",regbll.Cpwd);               
                par[4] = new SqlParameter("@Status", 11);
                par[4].Direction = ParameterDirection.Output;
                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "updateCreateStudent", par);
           
            return row;
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
        
        
            
    
    
    
    
    


	public RegistrationDal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
