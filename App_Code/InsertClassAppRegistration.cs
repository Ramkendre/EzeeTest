using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for InsertClassAppRegistration
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class InsertClassAppRegistration : System.Web.Services.WebService
{
    CommonCode cc = new CommonCode();

    public InsertClassAppRegistration()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    #region METHOD TO INSERT USER DETAILS OF EZEECLASS APP TO EZEETEST DATABASE

    [WebMethod(Description = "INSERT USER DETAILS OF CLASSAPP IN EZEETEST DATABASE")]

    public void InsertClassAppDetailsToeZeeTest(string firstName, string lastName, string firmName, string mobileNo, string Password, string address, string emailID, string userType, string instituteHeadMoblieNo, string strDevID)
    {
        try
        {

            if (mobileNo != "9422324927" && instituteHeadMoblieNo != "9422324927" && mobileNo != "9999999999" && instituteHeadMoblieNo != "9999999999" && mobileNo != "9292929292" && instituteHeadMoblieNo != "9292929292" && mobileNo != "9393939393" && instituteHeadMoblieNo != "9393939393" && mobileNo != "9191919191" && instituteHeadMoblieNo != "9191919191")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspInsertClassAppRegistration";
                cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlParameter[] parameter = new SqlParameter[] 
        {
            new SqlParameter("@firstName",firstName),
            new SqlParameter("@lastName",lastName),
            new SqlParameter("@firmName",firmName),
            new SqlParameter("@mobileNo",mobileNo),
            new SqlParameter("@usrPassword",Password),
            new SqlParameter("@usraddress",address),
            new SqlParameter("@emailID",emailID),
            new SqlParameter("@userType",userType),
            new SqlParameter("@instituteHeadMoblieNo",instituteHeadMoblieNo),
            new SqlParameter("@strDevID",strDevID)
                      
        };
                cmd.Parameters.AddRange(parameter);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }
        catch
        {

        }
        finally
        {

        }

    }

    #endregion

}

