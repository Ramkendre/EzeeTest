using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

/// <summary>
/// Summary description for ChangePassword
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ChangePassword : System.Web.Services.WebService {
    CommonCode cc = new CommonCode();
    int status = 0;
    public ChangePassword () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public int UpdatePwd(string MobileNo,string Pwd)
    {
        try
        {
            string SQl = "Update Login set Password='" + Pwd + "' where LoginId='" + MobileNo + "'";
            int i = cc.ExecuteNonQuery(SQl);
            if (i == 1)
            {
                status = i;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return status;
    }
    
}

