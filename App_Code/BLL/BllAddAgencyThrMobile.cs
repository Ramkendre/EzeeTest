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
using System.Data;

/// <summary>
/// Summary description for BllAddAgencyThrMobile
/// </summary>
public class BllAddAgencyThrMobile
{
    DalAddAgencyThrMobile dalagency = new DalAddAgencyThrMobile();
    int status;
    DataSet ds;
	public BllAddAgencyThrMobile()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int RegId;

    public int RegId1
    {
        get { return RegId; }
        set { RegId = value; }
    }
    private string NameFirm_Hospital;
    public string NameFirm_Hospital1
    {
        get { return NameFirm_Hospital; }
        set { NameFirm_Hospital = value; }

    }
    private string FirmType;
    public string FirmType1
    {
        get { return FirmType; }
        set { FirmType = value; }
    }
    private string CP_FirstName;
    public string CP_FirstName1
    {
        get { return CP_FirstName; }
        set { CP_FirstName = value; }
    }
    private string CP_LastName;
    public string CP_LastName1
    {
        get { return CP_LastName; }
        set { CP_LastName = value; }
    }
    private string Address;

    public string Address1
    {
        get { return Address; }
        set { Address = value; }
    }
    private string State;
    public string State1
    {
        get { return State; }
        set { State = value; }
    }

    private string District;
    public string district1
    {
        get { return District; }
        set { District = value; }
    }
    private string Taluka;
    public string Taluka1
    {
        get { return Taluka; }
        set { Taluka = value; }
    }
    private string City;
    public string City1
    {
        get { return City; }
        set { City = value; }
    }
    private string Pincode;
    public string Pincode1
    {
        get { return Pincode; }
        set { Pincode = value; }

    }
    private string PhoneNo1;
    public string PhoneNo_1
    {
        get { return PhoneNo1; }
        set { PhoneNo1 = value; }

    }

    private string PhoneNo11;
    public string PhoneNo_11
    {
        get { return PhoneNo_11; }
        set { PhoneNo_11 = value; }

    }
    private string Fax;
    public string Fax1
    {
        get { return Fax; }
        set { Fax = value; }

    }
    private string MobileNo1;
    public string MobileNo_1
    {
        get { return MobileNo1; }
        set { MobileNo1 = value; }

    }
    private string MobileNo2;
    public string MobileNo_2
    {
        get { return MobileNo2; }
        set { MobileNo2= value; }

    }
    private string MobileNo3;
    public string MobileNo_3
    {
        get { return MobileNo3; }
        set { MobileNo3 = value; }

    }
    private string Email_Id;
    public string Email_Id1
    {
        get { return Email_Id; }
        set { Email_Id = value; }

    }
    private string Website;
    public string Website1
    {
        get { return Website; }
        set { Website = value; }

    }
    private float Sr_No;
    public float Sr_No1
    {
        get { return Sr_No; }
        set { Sr_No = value; }

    }
    private string LoginID;
    public string LoginID1
    {
        get { return LoginID; }
        set { LoginID = value; }

    }

    private string passcode;

    public string Passcode
    {
        get { return passcode; }
        set { passcode = value; }
    }
    private string CreateDate;
    public string CreateDate1
    {
        get { return CreateDate; }
        set { CreateDate = value; }

    }

    private string longitute;

    public string Longitute
    {
        get { return longitute; }
        set { longitute = value; }
    }
    private string Latitute;

    public string Latitute1
    {
        get { return Latitute; }
        set { Latitute = value; }
    }


    private string myctPwd;

    public string MyctPwd
    {
        get { return myctPwd; }
        set { myctPwd = value; }
    }
    private string CaptchaCode;
    public string CaptchaCode1
    {
        get { return CaptchaCode; }
        set { CaptchaCode = value; }
    }
    private string druglicenceno;

    public string Druglicenceno
    {
        get { return druglicenceno; }
        set { druglicenceno = value; }
    }
    private string vat_tinno;

    public string Vat_tinno
    {
        get { return vat_tinno; }
        set { vat_tinno = value; }
    }
    private string FoodLic;

    public string FoodLic1
    {
        get { return FoodLic; }
        set { FoodLic = value; }
    }
    private string Homiopathiclic;

    public string Homiopathiclic1
    {
        get { return Homiopathiclic; }
        set { Homiopathiclic = value; }
    }
    private string ScheXlic;

    public string ScheXlic1
    {
        get { return ScheXlic; }
        set { ScheXlic = value; }
    }
    private string PanCard;

    public string PanCard1
    {
        get { return PanCard; }
        set { PanCard = value; }
    }
    private string LBT;

    public string LBT1
    {
        get { return LBT; }
        set { LBT = value; }
    }
    private string DocRNo;

    public string DocRNo1
    {
        get { return DocRNo; }
        set { DocRNo = value; }
    }
    private string HosShopactlic;

    public string HosShopactlic1
    {
        get { return HosShopactlic; }
        set { HosShopactlic = value; }
    }
    private string druglicenceno_rdt;

    public string Druglicenceno_rdt
    {
        get { return druglicenceno_rdt; }
        set { druglicenceno_rdt = value; }
    }
    private string vat_tinno_rdt;

    public string Vat_tinno_rdt
    {
        get { return vat_tinno_rdt; }
        set { vat_tinno_rdt = value; }
    }
    private string FoodLic_rdt;

    public string FoodLic_rdt1
    {
        get { return FoodLic_rdt; }
        set { FoodLic_rdt = value; }
    }
    private string Homiopathiclic_rdt;

    public string Homiopathiclic_rdt1
    {
        get { return Homiopathiclic_rdt; }
        set { Homiopathiclic_rdt = value; }
    }
    private string ScheXlic_rdt;

    public string ScheXlic_rdt1
    {
        get { return ScheXlic_rdt; }
        set { ScheXlic_rdt = value; }
    }
    private string PanCard_rdt;

    public string PanCard_rdt1
    {
        get { return PanCard_rdt; }
        set { PanCard_rdt = value; }
    }
    private string LBT_rdt;

    public string LBT_rdt1
    {
        get { return LBT_rdt; }
        set { LBT_rdt = value; }
    }
    private string DocRNo_rdt;

    public string DocRNo_rdt1
    {
        get { return DocRNo_rdt; }
        set { DocRNo_rdt = value; }
    }
    private string HosShopactlic_rdt;

    public string HosShopactlic_rdt1
    {
        get { return HosShopactlic_rdt; }
        set { HosShopactlic_rdt = value; }
    }
    private string druglicenceno_21;

    public string Druglicenceno_21
    {
        get { return druglicenceno_21; }
        set { druglicenceno_21 = value; }
    }
    private string druglicenceno_rdt21;

    public string Druglicenceno_rdt21
    {
        get { return druglicenceno_rdt21; }
        set { druglicenceno_rdt21 = value; }
    }
    private string usertype;

    public string Usertype
    {
        get { return usertype; }
        set { usertype = value; }
    }
    private string cstno;

    public string Cstno
    {
        get { return cstno; }
        set { cstno = value; }
    }
    private string cstno_rdt;

    public string Cstno_rdt
    {
        get { return cstno_rdt; }
        set { cstno_rdt = value; }
    }
    private string IMEI;

    public string IMEI1
    {
        get { return IMEI; }
        set { IMEI = value; }
    }

    private string FavName;

    public string FavName1
    {
        get { return FavName; }
        set { FavName = value; }
    }
    private string FavMobileno;

    public string FavMobileno1
    {
        get { return FavMobileno; }
        set { FavMobileno = value; }
    }
    private string DocQualification;

    public string DocQualification1
    {
        get { return DocQualification; }
        set { DocQualification = value; }
    }
    private string DocSpacialization;

    public string DocSpacialization1
    {
        get { return DocSpacialization; }
        set { DocSpacialization = value; }
    }
    
    public int RegAgency(BllAddAgencyThrMobile  bllagency)
    {
        status = dalagency.AddAgency(bllagency);
        return status;
    }
    public int RegFirm(BllAddAgencyThrMobile bllagency)
    {
        status = dalagency.AddFirm(bllagency);
        return status;
    }
    public int RegFirmUpdate(BllAddAgencyThrMobile bllagency)
    {
        status = dalagency.AddFirmUpdate(bllagency);
        return status;

    }
}

