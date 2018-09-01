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
/// Summary description for CompanyDAL
/// </summary>
/// 

public class CompanyDAL
{
    int status;
    DataSet ds = new DataSet();
    CommonCode cc = new CommonCode();

    public CompanyDAL()
    {

    }


    public int _insertCompany(CompanyBAL compbal)
    {
        DataSet ds = new DataSet();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = " INSERT INTO CompanyMaster (CompanyName, DisplayName, MobileNo1, " +
                             " PhoneNo1, PhoneNo2, FaxNo, CityId, Address1, " +
                             "  EmailId, PinCode,CreatedDate,Active,AdmissionQuota,CenterCode,IEMI,CityName,StateId,DistrictId,TalukaId) VALUES " +
                             " ('" + compbal.CompanyName1 + "','" + compbal.DisplayName1 + "','" + compbal.Mobile1 + "', " +
                             " '" + compbal.Phone1 + "','" + compbal.Phone2 + "','" + compbal.Faxno + "'," + Convert.ToInt32(compbal.City) + ",'" + compbal.Address1 + "', " +
                             " '" + compbal.Emailid + "','" + compbal.Pincode + "','" + System.DateTime.Today.ToString("yyyy-MM-dd hh:mm:ss tt") + "',1," + compbal.AdmissionQuota1 + ",'" + compbal.CenterCode1 + "' ,'" + compbal.IEMI1 + "','" + compbal.CityName + "','" + compbal.StateId + "','" + compbal.DistrictId + "','" + compbal.TalukaId + "') ";


                status = SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql);
                if (status == 1)
                {
                    sql = " SELECT CompanyId FROM CompanyMaster WHERE MobileNo1='" + compbal.Mobile1 + "' AND DisplayName='" + compbal.DisplayName1 + "' ";
                    status = cc.ExecuteScalar_all(sql);
                    if (status >= 1)
                    {
                    }
                    else
                    {
                        status = 0;
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
        }
        return status;
    }



    public DataSet _selectCompany(CompanyBAL compbal)
    {
        DataSet ds = new DataSet();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {

                string sql = " SELECT CompanyMaster.CompanyId,CompanyMaster.AdmissionQuota,CompanyMaster.CompanyName,CompanyMaster.DisplayName,CompanyMaster.MobileNo1, " +
                             " CompanyMaster.PhoneNo1,CompanyMaster.PhoneNo2,CompanyMaster.FaxNo,CompanyMaster.Address1,CompanyMaster.EmailId,CompanyMaster.PinCode,CompanyMaster.CreatedDate, " +
                             " CompanyMaster.Active,CompanyMaster.CityId,CompanyMaster.[StateId],CompanyMaster.[DistrictId],CompanyMaster.[TalukaId],CompanyMaster.CityName AS CompCityName FROM CompanyMaster WHERE CompanyMaster.CompanyId='" + compbal.CompanyId1 + "' ";

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


    public int _updateCompany(CompanyBAL compbal)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = " Update CompanyMaster SET " +
                             " CompanyName=N'" + compbal.CompanyName1 + "', " +
                             " DisplayName=N'" + compbal.DisplayName1 + "', " +
                             " MobileNo1='" + compbal.Mobile1 + "', " +
                             " PhoneNo1='" + compbal.Phone1 + "', " +
                             " PhoneNo2='" + compbal.Phone2 + "', " +
                             " FaxNo='" + compbal.Faxno + "', " +
                             " CityId=" + compbal.City + ", " +
                             " Address1='" + compbal.Address1 + "', " +
                             " AdmissionQuota=" + compbal.AdmissionQuota1 + ", " +
                             " EmailId='" + compbal.Emailid + "', " +
                             " PinCode='" + compbal.Pincode + "' ," +
                             " IEMI='" + compbal.IEMI1 + "', " +
                             " CityName='" + compbal.CityName + "', " +
                             " StateId='" + compbal.StateId + "'," +
                             " DistrictId='" + compbal.DistrictId + "'," +
                             " TalukaId='" + compbal.TalukaId + "'" +
                             " Where CompanyId=" + compbal.CompanyId1 + " ";

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


    public int _deleteCompany(CompanyBAL compbal)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = " UPDATE CompanyMaster SET Active = 0 WHERE CompanyId=" + compbal.CompanyId1 + "";
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
