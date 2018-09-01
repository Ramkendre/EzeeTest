using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for InsertEzeeTestAppRegistration
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class InsertEzeeTestAppRegistration : System.Web.Services.WebService {

    public InsertEzeeTestAppRegistration () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    #region Method to Insert Registration Data
    [WebMethod(Description="Method For Insert Registration Data to eZeeTest")]
    public void InsertEzeeTestRegistrationData(string LoginId, string Password, string UserName, string Address)
    {

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspInsertEzeeTestRegistration";
            cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlParameter[] parameter = new SqlParameter[] 
        {
            new SqlParameter("@loginNumber",LoginId),
            new SqlParameter("@userPassword",Password),
            new SqlParameter("@userName",UserName),
            new SqlParameter("@userAddress",Address)
           
        };
            cmd.Parameters.AddRange(parameter);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        catch
        {

        }
    }

    #endregion
}

