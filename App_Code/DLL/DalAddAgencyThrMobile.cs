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
using Microsoft.ApplicationBlocks.Data;


/// <summary>
/// Summary description for DalAddAgencyThrMobile
/// </summary>
public class DalAddAgencyThrMobile
{
    DataSet ds;
    RegisterToMyct regmyct = new RegisterToMyct();
    CommonCode cc = new CommonCode();
    SendMail semdmail = new SendMail();
    int Status = 0;
    string result = "";
    int count = 0;
    string Regid = "", Ftype = "";

    public DalAddAgencyThrMobile()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int AddAgency(BllAddAgencyThrMobile bllagency)
    {
        int i = 1;
        string Abailable = "";
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            try
            {


                con.Open();
                SqlDataReader dr1;
                SqlDataReader dr2;
                SqlCommand cmd1 = new SqlCommand("select RegId from tblRegistration$ where MobileNo1=@MobileNo1 or NameFirm_Hospital like '%@NameFirm_Hospital%' and  Email_Id=@Email_Id", con);
                cmd1.Parameters.AddWithValue("@MobileNo1", bllagency.MobileNo_1);
                cmd1.Parameters.AddWithValue("@NameFirm_Hospital", bllagency.NameFirm_Hospital1);
                cmd1.Parameters.AddWithValue("@Email_Id", bllagency.Email_Id1);
                dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    dr1.Close();
                    SqlCommand cmd2 = new SqlCommand("select RegId from tblRegistration$ where MobileNo1=@MobileNo1", con);
                    cmd2.Parameters.AddWithValue("@MobileNo1", bllagency.MobileNo_1);
                    dr2 = cmd2.ExecuteReader();
                    if (dr2.HasRows)
                    {
                        while (dr2.Read())
                        {
                            i++;
                            Abailable = Convert.ToString(dr2["RegId"]);
                            dr2.Read();
                        }
                        if (Abailable != "" || Abailable != null)
                        {
                            SqlCommand cmd = new SqlCommand("update tblRegistration$ set NameFirm_Hospital=@NameFirm_Hospital, CP_FirstName=@CP_FirstName, CP_LastName=@CP_LastName,MobileNo1=@MobileNo1,Email_Id=@Email_Id ,LoginID=@LoginID,AutoUpdateDrug=@AutoUpdateDrug,PhoneNo1=@PhoneNo1,FavName=@FavName2, FavMobileno=@FavMobileno2, DocQualification=@DocQualification2, DocSpacialization=@DocSpacialiazation2, City=@City where RegId=" + Abailable + " ", con);
                            cmd.Parameters.AddWithValue("@NameFirm_Hospital", bllagency.NameFirm_Hospital1);
                            cmd.Parameters.AddWithValue("@CP_FirstName", bllagency.CP_FirstName1);
                            cmd.Parameters.AddWithValue("@CP_LastName", bllagency.CP_LastName1);
                            cmd.Parameters.AddWithValue("@MobileNo1", bllagency.MobileNo_1);
                            cmd.Parameters.AddWithValue("@Email_Id", bllagency.Email_Id1);
                            cmd.Parameters.AddWithValue("@LoginID", bllagency.MobileNo_1);
                            cmd.Parameters.AddWithValue("@AutoUpdateDrug", "1");
                            cmd.Parameters.AddWithValue("@PhoneNo1", bllagency.PhoneNo_1);
                            cmd.Parameters.AddWithValue("@FavName2", bllagency.FavName1);
                            cmd.Parameters.AddWithValue("@FavMobileno2", bllagency.FavMobileno1);
                            cmd.Parameters.AddWithValue("@DocQualification2", bllagency.DocQualification1);
                            cmd.Parameters.AddWithValue("@DocSpacialization2", bllagency.DocSpacialization1);
                            cmd.Parameters.AddWithValue("@City", bllagency.City1);

                            cmd.Parameters.AddWithValue("@Status", 0);
                            dr2.Close();
                            Status = cmd.ExecuteNonQuery();

                        }
                    }
                    else
                    {
                        dr2.Close();
                        SqlCommand cmd = new SqlCommand("Insert into tblRegistration$(NameFirm_Hospital, CP_FirstName, CP_LastName,MobileNo1,Email_Id,LoginID,AutoUpdateDrug,RegistrationWay,PhoneNo1,FavName,FavMobileno,DocQualification,DocSpacialization,City)values(@NameFirm_Hospital, @CP_FirstName, @CP_LastName,@MobileNo1,@Email_Id,@LoginID,@AutoUpdateDrug,@RegistrationWay,@PhoneNo1,@FavName2,@FavMobileno2,@DocQualification2,@DocSpacilization2,@City)", con);
                        cmd.Parameters.AddWithValue("@NameFirm_Hospital", bllagency.NameFirm_Hospital1);
                        cmd.Parameters.AddWithValue("@CP_FirstName", bllagency.CP_FirstName1);
                        cmd.Parameters.AddWithValue("@CP_LastName", bllagency.CP_LastName1);
                        cmd.Parameters.AddWithValue("@MobileNo1", bllagency.MobileNo_1);
                        cmd.Parameters.AddWithValue("@Email_Id", bllagency.Email_Id1);
                        cmd.Parameters.AddWithValue("@LoginID", bllagency.MobileNo_1);
                        cmd.Parameters.AddWithValue("@AutoUpdateDrug", "1");
                        cmd.Parameters.AddWithValue("@RegistrationWay", "drugapps");
                        cmd.Parameters.AddWithValue("@PhoneNo1", bllagency.PhoneNo_1);
                        cmd.Parameters.AddWithValue("@FavName2", bllagency.FavName1);
                        cmd.Parameters.AddWithValue("@FavMobileno2", bllagency.FavMobileno1);
                        cmd.Parameters.AddWithValue("@DocQualification2", bllagency.DocQualification1);
                        cmd.Parameters.AddWithValue("@DocSpacialization2", bllagency.DocSpacialization1);
                        cmd.Parameters.AddWithValue("@City", bllagency.City1);
                        cmd.Parameters.AddWithValue("@Status", 0);
                        Status = cmd.ExecuteNonQuery();


                    }

                }
                else
                {
                    dr1.Close();
                    SqlCommand cmd = new SqlCommand("Insert into tblRegistration$(NameFirm_Hospital, CP_FirstName, CP_LastName,MobileNo1,Email_Id,LoginID,AutoUpdateDrug,RegistrationWay,PhoneNo1,FavName,FavMobileno,DocQualification,DocSpacialization,City)values(@NameFirm_Hospital, @CP_FirstName, @CP_LastName,@MobileNo1,@Email_Id,@LoginID,@AutoUpdateDrug,@RegistrationWay,@PhoneNo1,@FavName2,@FavMobileno2,@DocQualification2,@DocSpacialization2,@City)", con);
                    cmd.Parameters.AddWithValue("@NameFirm_Hospital", bllagency.NameFirm_Hospital1);
                    cmd.Parameters.AddWithValue("@CP_FirstName", bllagency.CP_FirstName1);
                    cmd.Parameters.AddWithValue("@CP_LastName", bllagency.CP_LastName1);
                    cmd.Parameters.AddWithValue("@MobileNo1", bllagency.MobileNo_1);
                    cmd.Parameters.AddWithValue("@Email_Id", bllagency.Email_Id1);
                    cmd.Parameters.AddWithValue("@LoginID", bllagency.MobileNo_1);
                    cmd.Parameters.AddWithValue("@AutoUpdateDrug", "1");
                    cmd.Parameters.AddWithValue("@RegistrationWay", "drugapps");
                    cmd.Parameters.AddWithValue("@PhoneNo1", bllagency.PhoneNo_1);
                    cmd.Parameters.AddWithValue("@FavName2", bllagency.FavName1);
                    cmd.Parameters.AddWithValue("@FavMobileno2", bllagency.FavMobileno1);
                    cmd.Parameters.AddWithValue("@DocQualification2", bllagency.DocQualification1);
                    cmd.Parameters.AddWithValue("@DocSpacialization2", bllagency.DocSpacialization1);
                    cmd.Parameters.AddWithValue("@City", bllagency.City1);
                    cmd.Parameters.AddWithValue("@Status", 0);
                    Status = cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        return Status;
    }



    public int AddFirm(BllAddAgencyThrMobile bllagency)
    {
        int i = 1;
        string Abailable = "";
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            try
            {
                DateTime dt = new DateTime();
                string entryDate = string.Empty;

                if (!string.IsNullOrEmpty(bllagency.CreateDate1))
                {
                    dt = Convert.ToDateTime(bllagency.CreateDate1);
                    entryDate = dt.ToString("yyyy-MM-dd");
                }

                con.Open();
                SqlDataReader dr;
                SqlCommand cmd1 = new SqlCommand("select RegId from tblRegistration$ where MobileNo1=@MobileNo1 or MobileNo2=@MobileNo1 or MobileNo3=@MobileNo1", con);
                cmd1.Parameters.AddWithValue("@MobileNo1", bllagency.MobileNo_1);
                dr = cmd1.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        i++;
                        Abailable = Convert.ToString(dr["RegId"]);
                        dr.Read();
                    }
                    if (Abailable != "")
                    {
                        bllagency.RegId1 = Convert.ToInt32(Abailable);
                        SqlCommand cmd = new SqlCommand("update tblRegistration$ set NameFirm_Hospital=@NameFirm_Hospital, CP_FirstName=@CP_FirstName, CP_LastName=@CP_LastName,MobileNo1=@MobileNo1,Email_Id=@Email_Id,FirmType=@FirmType, State=@state,District=@district, Taluka=@taluka, Pincode=@Pincode, LoginID=@LoginID, ModifyDate=@CreateDate,passcode=@passcode ,Longitute=@Longitute,Latitute=@Latitute ,RegistrationWay=@RegistrationWay ,usertype=@usertype,IMEI=@IMEI ,AutoUpdateDrug=@AutoUpdateDrug,Address=@Address1, PhoneNo1=@PhoneNo1,FavMobileno=@FavMobileno2, DocQualification=@DocQualification2, DocSpacialization=@DocSpacialization1, City=@City where RegId=" + Abailable + " ", con);
                        cmd.Parameters.AddWithValue("@NameFirm_Hospital", bllagency.NameFirm_Hospital1);
                        cmd.Parameters.AddWithValue("@CP_FirstName", bllagency.CP_FirstName1);
                        cmd.Parameters.AddWithValue("@CP_LastName", bllagency.CP_LastName1);
                        cmd.Parameters.AddWithValue("@MobileNo1", bllagency.MobileNo_1);
                        cmd.Parameters.AddWithValue("@Email_Id", bllagency.Email_Id1);
                        cmd.Parameters.AddWithValue("@FirmType", bllagency.FirmType1);
                        cmd.Parameters.AddWithValue("@state", bllagency.State1);
                        cmd.Parameters.AddWithValue("@district", bllagency.district1);
                        cmd.Parameters.AddWithValue("@taluka", bllagency.Taluka1);
                        cmd.Parameters.AddWithValue("@Pincode", bllagency.Pincode1);
                        cmd.Parameters.AddWithValue("@LoginID", bllagency.LoginID1);
                        if (!string.IsNullOrEmpty(entryDate))
                            cmd.Parameters.AddWithValue("@CreateDate", Convert.ToDateTime(entryDate));
                        else
                            cmd.Parameters.AddWithValue("@CreateDate",DBNull.Value);
                        cmd.Parameters.AddWithValue("@passcode", bllagency.Passcode);
                        cmd.Parameters.AddWithValue("@Longitute", bllagency.Longitute);
                        cmd.Parameters.AddWithValue("@Latitute", bllagency.Latitute1);
                        cmd.Parameters.AddWithValue("@RegistrationWay", "drugapps");
                        cmd.Parameters.AddWithValue("@usertype", bllagency.Usertype);
                        cmd.Parameters.AddWithValue("@IMEI", bllagency.IMEI1);
                        cmd.Parameters.AddWithValue("@AutoUpdateDrug", "1");
                        cmd.Parameters.AddWithValue("@Address1", bllagency.Address1);
                        cmd.Parameters.AddWithValue("@PhoneNo1", bllagency.PhoneNo_1);
                        cmd.Parameters.AddWithValue("@FavName2", bllagency.FavName1);
                        cmd.Parameters.AddWithValue("@FavMobileno2", bllagency.FavMobileno1);
                        cmd.Parameters.AddWithValue("@DocQualification2", bllagency.DocQualification1);
                        cmd.Parameters.AddWithValue("@DocSpacialization1", bllagency.DocSpacialization1);
                        cmd.Parameters.AddWithValue("@City", bllagency.City1);
                        cmd.Parameters.AddWithValue("@Status", 0);
                        dr.Close();
                        Status = cmd.ExecuteNonQuery();


                    }
                }
                else
                {
                    dr.Close();
                    SqlCommand cmd = new SqlCommand("Insert into tblRegistration$(NameFirm_Hospital, CP_FirstName, CP_LastName,MobileNo1,Email_Id, FirmType, State, District, Taluka, Pincode, LoginID, CreateDate,passcode,Longitute,Latitute,RegistrationWay,usertype,IMEI,AutoUpdateDrug,Address,PhoneNo1,FavName,FavMobileno,DocQualification,DocSpacialization,City)values " +
                                                   "(@NameFirm_Hospital, @CP_FirstName, @CP_LastName,@MobileNo1,@Email_Id, @FirmType, @state,@district, @taluka, @Pincode, @LoginID, @CreateDate,@passcode,@Longitute,@Latitute,@RegistrationWay,@usertype,@IMEI,@AutoUpdateDrug,@Address1,@PhoneNo1,@FavName2,@FavMobileno2,@DocQualification2,@DocSpacialization1,@City)", con);
                    cmd.Parameters.AddWithValue("@NameFirm_Hospital", bllagency.NameFirm_Hospital1);
                    cmd.Parameters.AddWithValue("@CP_FirstName", bllagency.CP_FirstName1);
                    cmd.Parameters.AddWithValue("@CP_LastName", bllagency.CP_LastName1);
                    cmd.Parameters.AddWithValue("@MobileNo1", bllagency.MobileNo_1);
                    cmd.Parameters.AddWithValue("@Email_Id", bllagency.Email_Id1);
                    cmd.Parameters.AddWithValue("@FirmType", bllagency.FirmType1);
                    cmd.Parameters.AddWithValue("@state", bllagency.State1);
                    cmd.Parameters.AddWithValue("@district", bllagency.district1);
                    cmd.Parameters.AddWithValue("@taluka", bllagency.Taluka1);
                    cmd.Parameters.AddWithValue("@Pincode", bllagency.Pincode1);
                    cmd.Parameters.AddWithValue("@LoginID", bllagency.LoginID1);
                    if (!string.IsNullOrEmpty(entryDate))
                        cmd.Parameters.AddWithValue("@CreateDate", Convert.ToDateTime(entryDate));
                    else
                        cmd.Parameters.AddWithValue("@CreateDate", DBNull.Value);

                    cmd.Parameters.AddWithValue("@passcode", bllagency.Passcode);
                    cmd.Parameters.AddWithValue("@Longitute", bllagency.Longitute);
                    cmd.Parameters.AddWithValue("@Latitute", bllagency.Latitute1);
                    cmd.Parameters.AddWithValue("@RegistrationWay", "drugapps");
                    cmd.Parameters.AddWithValue("@usertype", bllagency.Usertype);
                    cmd.Parameters.AddWithValue("@IMEI", bllagency.IMEI1);
                    cmd.Parameters.AddWithValue("@AutoUpdateDrug", "1");
                    cmd.Parameters.AddWithValue("@Address1", bllagency.Address1);
                    cmd.Parameters.AddWithValue("@PhoneNo1", bllagency.PhoneNo_1);
                    cmd.Parameters.AddWithValue("@FavName2", bllagency.FavName1);
                    cmd.Parameters.AddWithValue("@FavMobileno2", bllagency.FavMobileno1);
                    cmd.Parameters.AddWithValue("@DocQualification2", bllagency.DocQualification1);
                    cmd.Parameters.AddWithValue("@DocSpacialization1", bllagency.DocSpacialization1);
                    cmd.Parameters.AddWithValue("@City", bllagency.City1);
                    cmd.Parameters.AddWithValue("@Status", 0);
                    Status = cmd.ExecuteNonQuery();
                    if (Status == 1)
                    {

                        string SQL = "Select RegId from tblRegistration$ where  MobileNo1='" + bllagency.MobileNo_1 + "'";
                        SQL = SQL + "Select RoleName from Role where Roleid='" + bllagency.FirmType1 + "'";
                        DataSet ds = cc.ExecuteDataset(SQL);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Regid = Convert.ToString(ds.Tables[0].Rows[0]["RegId"]);

                            bllagency.RegId1 = Convert.ToInt32(Regid);  // Regid
                            if (ds.Tables[1].Rows.Count != 0)
                                Ftype = Convert.ToString(ds.Tables[1].Rows[0]["RoleName"]);
                            SQL = "insert into Login(UsrUserID,MobileNo,Password,CreateDate,RegId) values" +
                                   "('we','" + bllagency.MobileNo_1 + "','" + bllagency.MyctPwd + "','" + System.DateTime.Now + "'," + Regid + ")";
                            int status = cc.ExecuteNonQuery(SQL);
                            if (status == 1)
                            {

                            }

                        }
                        if (bllagency.FirmType1 == "1")
                        {

                            string passwordMessage = "Dear User " + bllagency.CP_LastName1 + ",u r added for online transaction on ezeedrug & ur pwd is  " + bllagency.MyctPwd + " for www.ezeehealth.in and " + cc.AddSMS(bllagency.MobileNo_1);
                            int smslength = passwordMessage.Length;
                            cc.SendMessageLongCodeSMS("ezeedrug", bllagency.MobileNo_1, passwordMessage, smslength);
                            if (bllagency.Email_Id1 != "")
                            {
                                //semdmail.SendMeail(bllagency.Email_Id1, bllagency.MobileNo_1, bllagency.MyctPwd, bllagency.NameFirm_Hospital1);
                            }
                        }
                        else
                        {
                            string passwordMessage = "Dear " + Ftype + " " + bllagency.CP_LastName1 + ",ur " + bllagency.NameFirm_Hospital1 + "  is added for online transaction on ezeedrug & ur pwd is  " + bllagency.MyctPwd + " for www.ezeehealth.in and " + cc.AddSMS(bllagency.MobileNo_1);
                            int smslength = passwordMessage.Length;
                            cc.SendMessageLongCodeSMS("ezeedrug", bllagency.MobileNo_1, passwordMessage, smslength);
                            try
                            {
                                if (bllagency.Email_Id1 != "")
                                {
                                    //semdmail.SendMeail(bllagency.Email_Id1, bllagency.MobileNo_1, bllagency.MyctPwd, bllagency.NameFirm_Hospital1);
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }




                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        return Status;
    }



    public int AddFirmUpdate(BllAddAgencyThrMobile bllagency)
    {
        int i = 1;
        string Abailable = "";
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update tblRegistration$ set RegistrationWay=@RegistrationWay , Address=@Address, druglicenceno=@druglicenceno,vat_tinno=@vat_tinno,FoodLic=@FoodLic,Homiopathiclic=@Homiopathiclic,ScheXlic=@ScheXlic,PanCard=@PanCard,LBT=@LBT,DocRNo=@DocRNo,HosShopactlic=@HosShopactlic,druglicenceno_rdt=@druglicenceno_rdt,vat_tinno_rdt=@vat_tinno_rdt,FoodLic_rdt=@FoodLic_rdt,Homiopathiclic_rdt=@Homiopathiclic_rdt,ScheXlic_rdt=@ScheXlic_rdt,PanCard_rdt=@PanCard_rdt,LBT_rdt=@LBT_rdt,DocRNo_rdt=@DocRNo_rdt,druglicenceno_21=@druglicenceno_21,druglicenceno_rdt21=@druglicenceno_rdt21,cstno=@cstno,cstno_rdt=@cstno_rdt where MobileNo1=@MobileNo1 or MobileNo2=@MobileNo1 or MobileNo3=@MobileNo1", con);
                cmd.Parameters.AddWithValue("@MobileNo1", bllagency.MobileNo_1);
                cmd.Parameters.AddWithValue("@RegistrationWay", "drugappsMore");
                cmd.Parameters.AddWithValue("@Address", bllagency.Address1);
                cmd.Parameters.AddWithValue("@druglicenceno", bllagency.Druglicenceno);
                cmd.Parameters.AddWithValue("@vat_tinno", bllagency.Vat_tinno);
                cmd.Parameters.AddWithValue("@FoodLic", bllagency.FoodLic1);
                cmd.Parameters.AddWithValue("@Homiopathiclic", bllagency.Homiopathiclic1);
                cmd.Parameters.AddWithValue("@ScheXlic", bllagency.ScheXlic1);
                cmd.Parameters.AddWithValue("@PanCard", bllagency.PanCard1);
                cmd.Parameters.AddWithValue("@LBT", bllagency.LBT1);
                cmd.Parameters.AddWithValue("@DocRNo", bllagency.DocRNo1);
                cmd.Parameters.AddWithValue("@HosShopactlic", bllagency.HosShopactlic1);
                cmd.Parameters.AddWithValue("@druglicenceno_rdt", bllagency.Druglicenceno_rdt);
                cmd.Parameters.AddWithValue("@vat_tinno_rdt", bllagency.Vat_tinno_rdt);
                cmd.Parameters.AddWithValue("@FoodLic_rdt", bllagency.FoodLic_rdt1);
                cmd.Parameters.AddWithValue("@Homiopathiclic_rdt", bllagency.HosShopactlic_rdt1);
                cmd.Parameters.AddWithValue("@ScheXlic_rdt", bllagency.ScheXlic_rdt1);
                cmd.Parameters.AddWithValue("@PanCard_rdt", bllagency.PanCard_rdt1);
                cmd.Parameters.AddWithValue("@LBT_rdt", bllagency.LBT_rdt1);
                cmd.Parameters.AddWithValue("@DocRNo_rdt", bllagency.DocRNo_rdt1);
                cmd.Parameters.AddWithValue("@druglicenceno_21", bllagency.Druglicenceno_21);
                cmd.Parameters.AddWithValue("@druglicenceno_rdt21", bllagency.Druglicenceno_rdt21);
                cmd.Parameters.AddWithValue("@cstno", bllagency.Cstno);
                cmd.Parameters.AddWithValue("@cstno_rdt", bllagency.Cstno_rdt);
                cmd.Parameters.AddWithValue("@Status", 0);
                Status = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        return Status;
    }
}
