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

/// <summary>
/// Summary description for CompanyBAL
/// </summary>
public class CompanyBAL
{

    CompanyDAL compdal = new CompanyDAL();
    int status;
    DataSet ds = new DataSet();

	public CompanyBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int CompanyId;

    public int CompanyId1
    {
        get { return CompanyId; }
        set { CompanyId = value; }
    }
    private string CompanyName;

    public string CompanyName1
    {
        get { return CompanyName; }
        set { CompanyName = value; }
    }

    private string DisplayName;

    public string DisplayName1
    {
        get { return DisplayName; }
        set { DisplayName = value; }
    }

    private string address1;

    public string Address1
    {
        get { return address1; }
        set { address1 = value; }
    }

    private string address2;

    public string Address2
    {
        get { return address2; }
        set { address2 = value; }
    }
    private int city;

    public int City
    {
        get { return city; }
        set { city = value; }
    }

   

    private string pincode;

    public string Pincode
    {
        get { return pincode; }
        set { pincode = value; }
    }

    private string mobile1;

    public string Mobile1
    {
        get { return mobile1; }
        set { mobile1 = value; }
    }



    private string mobile2;

    public string Mobile2
    {
        get { return mobile2; }
        set { mobile2 = value; }
    }
    private string phone1;

    public string Phone1
    {
        get { return phone1; }
        set { phone1 = value; }
    }

    private string phone2;

    public string Phone2
    {
        get { return phone2; }
        set { phone2 = value; }
    }

    private string faxno;

    public string Faxno
    {
        get { return faxno; }
        set { faxno = value; }
    }

    private string emailid;

    public string Emailid
    {
        get { return emailid; }
        set { emailid = value; }
    }

    private string date;

    public string Date
    {
        get { return date; }
        set { date = value; }
    }

    private int active;

    public int Active
    {
        get { return active; }
        set { active = value; }
    }

    private int AdmissionQuota;

    public int AdmissionQuota1
    {
        get { return AdmissionQuota; }
        set { AdmissionQuota = value; }
    }

    private string CenterCode;

    public string CenterCode1
    {
        get { return CenterCode; }
        set { CenterCode = value; }
    }


    private int tempCompanyId; // use for center code page upload Admin_SubUser

    public int TempCompanyId
    {
        get { return tempCompanyId; }
        set { tempCompanyId = value; }
    }


    private string IEMI;

    public string IEMI1
    {
        get { return IEMI; }
        set { IEMI = value; }
    }

    private string _cityName;

    public string CityName
    {
        get { return this._cityName; }
        set { this._cityName = value; }
    }

    private int stateId;

    public int StateId
    {
        get { return stateId; }
        set { stateId = value; }
    }
    private int districtId;

    public int DistrictId
    {
        get { return districtId; }
        set { districtId = value; }
    }
    private int talukaId;

    public int TalukaId
    {
        get { return talukaId; }
        set { talukaId = value; }
    }

    public int _insertCompany(CompanyBAL compbal)
    {
        status = compdal._insertCompany(compbal);
        return status;
    }

       public DataSet _selectCompany(CompanyBAL compbal)
       {
           ds = compdal._selectCompany(compbal);
           return ds;
       }

    public int _updateCompany(CompanyBAL compbal)
    {
        status = compdal._updateCompany(compbal);
        return status;
    }
    public int _deleteCompany(CompanyBAL compbal)
    {
        status = compdal._deleteCompany(compbal);
        return status;
    }




}
