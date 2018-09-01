using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for RegistrationApp
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class RegistrationApp : System.Web.Services.WebService {

    public RegistrationApp () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string RegistrationNew(string AppMobileNo, string RefmobileNo, string strDevId, string strSimSerialNo, string keyword, string firstName,
                              string lastName, string firmName, string address, string SchoolCode, string eMailId, string Role_Id, string pincode,
                              string passcode, string latitude, string longitude, string state, string district, string Taluka, string userType,
                              string DealerMobNo)
    {
        try
        {
            AppRegMyct.AppRegistration myctreg = new AppRegMyct.AppRegistration();
            myctreg.Registration(AppMobileNo, RefmobileNo, strDevId, strSimSerialNo, keyword, firstName, lastName, firmName, address, SchoolCode,
                eMailId, Role_Id, pincode, passcode, latitude, longitude, state, district, Taluka, userType, DealerMobNo);
        }
        catch
        {
            return "0";
        }
        return "1";
    }
    
}
