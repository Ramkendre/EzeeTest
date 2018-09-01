using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

/// <summary>
/// Summary description for TrueVoter20616
/// </summary>
/// 

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class TrueVoter20616 : System.Web.Services.WebService
{

    public TrueVoter20616()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //SqlConnection con = new SqlConnection(@"Data Source=AISPL-W1A3-PC;Initial Catalog=TrueVoterDB;Integrated Security=True;");

    SqlConnection con = new SqlConnection("Data Source=103.16.140.243;Initial Catalog=TrueVoterDB;User ID=TrueVoter;Password=TrueVoter@#123;");
    SqlCommand cmd = null;
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();


    [WebMethod(Description = "NEW TRUE VOTER EXTRA DATA INSERT")]// missing ADDED 03.09.2016
    public int InsertExtraRegData(string usrMobileNumber, string designationId, string designationName, string lookingAfterId, string lookingAfterName, string localBodyId, string localBodyName, string emergencyNum1, string emergencyNum2, string emergencyNum3, string emergencyNum4, string emergencyNum5, string refMobileNumber)
    {
        string sqlQuery = string.Empty;
        try
        {
            sqlQuery = " SELECT * FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra] WHERE [usrMobileNumber] = '" + usrMobileNumber + "'";
            cmd = new SqlCommand(sqlQuery, con);
            da.SelectCommand = cmd;
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                sqlQuery = " UPDATE [TrueVoterDB].[dbo].[tblNewDataRegExtra] SET [DesignationId]='" + designationId + "',[DesignationName]='" + designationName + "',[LokingAfterId]='" + lookingAfterId + "',[LokingAfterName]='" + lookingAfterName + "',[LocalBodyId]='" + localBodyId + "',[LocalBodyName]='" + localBodyName + "',[EmergencyNum1]='" + emergencyNum1 + "',[EmergencyNum2]='" + emergencyNum2 + "',[EmergencyNum3]='" + emergencyNum3 + "',[EmergencyNum4]='" + emergencyNum4 + "',[EmergencyNum5]='" + emergencyNum5 + "',[refMobileNumber]='" + refMobileNumber + "',[ModifyBy]='" + usrMobileNumber + "',[ModifyDate]='" + System.DateTime.Now + "'" +
                           " WHERE [usrMobileNumber] = '" + usrMobileNumber + "'";
                con.Open();
                cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                sqlQuery = " INSERT INTO [TrueVoterDB].[dbo].[tblNewDataRegExtra] ([usrMobileNumber],[DesignationId],[DesignationName],[LokingAfterId],[LokingAfterName],[LocalBodyId],[LocalBodyName],[EmergencyNum1],[EmergencyNum2],[EmergencyNum3],[EmergencyNum4],[EmergencyNum5],[refMobileNumber],[CreatedBy],[CreatedDate]) " +
                           " VALUES ('" + usrMobileNumber + "','" + designationId + "','" + designationName + "','" + lookingAfterId + "','" + lookingAfterName + "','" + localBodyId + "','" + localBodyName + "','" + emergencyNum1 + "','" + emergencyNum2 + "','" + emergencyNum3 + "','" + emergencyNum4 + "','" + emergencyNum5 + "','" + refMobileNumber + "','" + usrMobileNumber + "','" + System.DateTime.Now + "') ";
                con.Open();
                cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    [WebMethod(Description = "INSERT DATA TO NOMINATION PART ONE")]
    public int InsertNominationPart_1(string firstName, string lastName, string fatherName, string mobileNumber, string emailId, string electionFor, string electionYear, string electionType, string localBody, string startDate, string endDate, string divisionName, string districtName, string talukaName, string electoralDivisionNo, string electoralDivisionName, string electoralCollegeNo, string electoralCollegeName, string wardNo, string wardName, string seatNo, string reservationCategory, string startDate1, string endDate1, string userName, string usrPassword, string txtMobileNo, string AppMobileNumber)
    {
        try
        {
            string sqlQuery = " INSERT INTO [TrueVoterDB].[dbo].[tblNEnrCandidateApp] ([FirstName],[LastName],[FatherName],[MobileNo],[EmailId],[ElectionFor],[ElectionYear],[ElectionType],[LocalBody],[StartDate],[EndDate],[CreatedBy],[CreatedDate]) " +
                              " VALUES ('" + firstName + "','" + lastName + "','" + fatherName + "','" + mobileNumber + "','" + emailId + "','" + electionFor + "','" + electionYear + "','" + electionType + "','" + localBody + "','" + startDate + "','" + endDate + "','" + AppMobileNumber + "','" + System.DateTime.Now + "')";
            con.Open();
            cmd = new SqlCommand(sqlQuery, con);
            cmd.ExecuteNonQuery();
            con.Close();
            InsertNominationPart_2(divisionName, districtName, talukaName, electoralDivisionNo, electoralDivisionName, electoralCollegeNo, electoralCollegeName, wardNo, wardName, seatNo, reservationCategory, startDate1, endDate1, userName, usrPassword, txtMobileNo, AppMobileNumber);
            return 1;

        }
        catch
        {
            return 0;
        }
    }

    //[WebMethod(Description = "INSERT DATA TO NOMINATION PART TWO")]
    public int InsertNominationPart_2(string divisionName, string districtName, string talukaName, string electoralDivisionNo, string electoralDivisionName, string electoralCollegeNo, string electoralCollegeName, string wardNo, string wardName, string seatNo, string reservationCategory, string startDate, string endDate, string userName, string usrPassword, string txtMobileNo, string AppMobileNumber)
    {
        try
        {
            string sqlQuery = " UPDATE [TrueVoterDB].[dbo].[tblNEnrCandidateApp] SET [DivisionName]='" + divisionName + "',[DistrictId]='1',[DistrictName]='" + districtName + "',[TalukaId]='1',[TalukaName]='" + talukaName + "',[ElectoralDivisionNo]='" + electoralDivisionNo + "',[ElectoralDivisionName]='" + electoralDivisionName + "',[ElectoralCollegeNo]='" + electoralCollegeNo + "',[ElectoralCollegeName]='" + electoralCollegeName + "',[WardNo]='" + wardNo + "',[WardName]='" + wardName + "',[SeatNo]='" + seatNo + "',[ReservationCategory]='" + reservationCategory + "',[NstartDate]='" + startDate + "',[NendDate]='" + endDate + "',[UserName]='" + userName + "',[UserPassword]='" + usrPassword + "',[Status]='1',[ModifyBy]='" + AppMobileNumber + "',[ModifyDate]='" + System.DateTime.Now + "'" +
                              " WHERE [MobileNo]='" + txtMobileNo + "'";
            con.Open();
            cmd = new SqlCommand(sqlQuery, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    [WebMethod(Description = "INSERT ELECTION STATUS DETAILS")]
    public int InsertElectionStatus(string electionStatusId, string electionStatusName, string remarks, string date, string loginNumber)
    {
        try
        {
            string sqlQuery = " INSERT INTO [TrueVoterDB].[dbo].[tblElectionStatus] ([ElectionStatusId],[ElectionStatusName],[Remarks],[Status],[Date],[LoginNumber],[CreatedBy],[CreatedDate]) " +
                              " VALUES ('" + electionStatusId + "','" + electionStatusName + "','" + remarks + "','1','" + date + "','" + loginNumber + "','" + loginNumber + "','" + System.DateTime.Now + "')";
            con.Open();
            cmd = new SqlCommand(sqlQuery, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    [WebMethod(Description = "INSERT EMERGENCY SERVICES DETAILS")]
    public int InsertEmergencyServices(string emergSeviceId, string emergeServiceName, string remarks, string date, string loginNumber)
    {
        try
        {
            string sqlQuery = " INSERT INTO [TrueVoterDB].[dbo].[tblEmergencyServices] ([EmergServiceId],[EmergServiceName],[Remark],[Status],[Date],[LoginNumber],[CreatedBy],[CreatedDate]) " +
                              " VALUES ('" + emergSeviceId + "','" + emergeServiceName + "','" + remarks + "','1','" + date + "','" + loginNumber + "','" + loginNumber + "','" + System.DateTime.Now + "')";
            con.Open();
            cmd = new SqlCommand(sqlQuery, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    [WebMethod(Description = "INSERT REGISTRATION DETAILS TO TRUE VOTER TABLE")]
    public int SendRegDataTrueVoter(string firstName, string mobile, string usrName, string usrPassword, string otp, string middleName, string lastName, string latitude, string longitude)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[TrueVoterDB].[dbo].[uspRegisterUser]";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 150).Value = firstName;
            cmd.Parameters.Add("@mobileNo", SqlDbType.NVarChar, 12).Value = mobile;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 10).Value = usrName;
            cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = usrPassword;
            cmd.Parameters.Add("@mName", SqlDbType.NVarChar, 20).Value = middleName;
            cmd.Parameters.Add("@lName", SqlDbType.NVarChar, 20).Value = lastName;
            cmd.Parameters.Add("@otp", SqlDbType.NVarChar, 8).Value = otp;
            cmd.Parameters.Add("@lat", SqlDbType.NVarChar, 8).Value = latitude;
            cmd.Parameters.Add("@lag", SqlDbType.NVarChar, 8).Value = longitude;
            cmd.Parameters.Add("@rid", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            SqlParameter returnValue = cmd.CreateParameter();
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnValue);

            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();

            cmd.ExecuteNonQuery();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    [WebMethod(Description = "GET TOATAL CATEGORIES DETAILS TO APP")]
    public string DownloadCategories()
    {
        try
        {
            string returnString = string.Empty;
            string sqlQuery = "SELECT [CID],[CategoryName],[DefaultorDefine],[SelorType],[Validation] FROM [TrueVoterDB].[dbo].[tblCategories]";
            cmd = new SqlCommand(sqlQuery, con);
            da.SelectCommand = cmd;
            da.Fill(ds);
            int countds = ds.Tables[0].Rows.Count;

            if (countds > 0)
            {
                for (int i = 0; i < countds; i++)
                {
                    string cid = ds.Tables[0].Rows[i][0].ToString(), categoryName = ds.Tables[0].Rows[i][1].ToString(), defordefine = ds.Tables[0].Rows[i][2].ToString(), seloftype = ds.Tables[0].Rows[i][3].ToString(), validation = ds.Tables[0].Rows[i][4].ToString();
                    returnString += "#" + cid + "*" + categoryName + "*" + defordefine + "*" + seloftype + "*" + validation;
                }
                returnString = returnString.Substring(1);
                return returnString;
            }
            else
            {
                return "105";
            }
        }
        catch
        {
            return "105";
        }
    }

    [WebMethod(Description = "DOWNLOAD CATEGORY ITEMS DETAILS")]
    public string DownloadCategoryItems()
    {
        try
        {
            string returnString = string.Empty;
            string sqlQuery = "SELECT [ItemId],[ItemName],[CategoryId],[DefaultorDefine],[RepreMobile],[Area],[Ward],[Part],[IMEI],[Validation] FROM [TrueVoterDB].[dbo].[tblCategoryItems] ORDER BY [ItemId] ASC";
            cmd = new SqlCommand(sqlQuery, con);
            da.SelectCommand = cmd;
            da.Fill(ds);
            int countds = ds.Tables[0].Rows.Count;

            if (countds > 0)
            {
                for (int i = 0; i < countds; i++)
                {
                    string itemId = ds.Tables[0].Rows[i][0].ToString(), itemName = ds.Tables[0].Rows[i][1].ToString(), categoryId = ds.Tables[0].Rows[i][2].ToString(), defordefine = ds.Tables[0].Rows[i][3].ToString(), reprmob = ds.Tables[0].Rows[i][4].ToString();
                    string area = ds.Tables[0].Rows[i][5].ToString(), ward = ds.Tables[0].Rows[i][6].ToString(), part = ds.Tables[0].Rows[i][7].ToString(), imei = ds.Tables[0].Rows[i][8].ToString(), validation = ds.Tables[0].Rows[i][9].ToString();

                    returnString += "#" + itemId + "*" + itemName + "*" + categoryId + "*" + defordefine + "*" + reprmob + "*" + area + "*" + ward + "*" + part + "*" + imei + "*" + validation;
                }
                returnString = returnString.Substring(1);
                return returnString;
            }
            else
            {
                return "105";
            }
        }
        catch
        {
            return "105";
        }
    }

    [WebMethod(Description = "TO DOWNLOAD VOTER LIST")]
    public XmlDocument GetVoterDetails(string Assembly, string FirstName, string LastName, string PageSize, string PageIndex)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        DataSet dataset = new DataSet();
        DataTable dt = new DataTable("Table");
        DataSet dsXml = new DataSet();

        string sqlQuery = "SELECT TOP 20 [SECTION_NO] AS Sr,[Allocated_Ward] AS WardNo,[SerialNo_ForFinalList] AS SerialNo,[IDCARD_NO],[fm_name_v1],[RLN_FM_NM_v1],[RLN_L_NM_v1],[FM_NAMEEN], " +
                          "[LASTNAMEEN],[RLN_FM_NMEN],[SEX],[AGE],[AC_NO],[PART_NO],[SLNOINPART] FROM [TrueVoterDB].[dbo].[TestData] " +
                          "SELECT TOP 20 [BoothNo] AS BoothNumber,[BoothAddress] AS boothname,[BoothAddress] AS BoothAddress FROM [TrueVoterDB].[dbo].[BoothAddresses] ";
        cmd = new SqlCommand(sqlQuery, con);
        da.SelectCommand = cmd;
        da.Fill(dataset);
        int countds = dataset.Tables[0].Rows.Count;

        if (countds > 0)
        {
            dt.Columns.Add(new DataColumn("Sr", typeof(string)));
            dt.Columns.Add(new DataColumn("WardNo", typeof(string)));
            dt.Columns.Add(new DataColumn("SerialNo", typeof(string)));
            dt.Columns.Add(new DataColumn("IDCARD_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("fm_name_v1", typeof(string)));
            dt.Columns.Add(new DataColumn("RLN_FM_NM_v1", typeof(string)));
            dt.Columns.Add(new DataColumn("RLN_L_NM_v1", typeof(string)));
            dt.Columns.Add(new DataColumn("FM_NAMEEN", typeof(string)));
            dt.Columns.Add(new DataColumn("LASTNAMEEN", typeof(string)));
            dt.Columns.Add(new DataColumn("RLN_FM_NMEN", typeof(string)));
            dt.Columns.Add(new DataColumn("SEX", typeof(string)));
            dt.Columns.Add(new DataColumn("AGE", typeof(string)));
            dt.Columns.Add(new DataColumn("AC_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("PART_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("SLNOINPART", typeof(string)));
            dt.Columns.Add(new DataColumn("BoothNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("boothname", typeof(string)));
            dt.Columns.Add(new DataColumn("BoothAddress", typeof(string)));

            for (int i = 0; i < 20; i++)
            {
                dt.Rows.Add(dataset.Tables[0].Rows[i][0].ToString(), dataset.Tables[0].Rows[i][1].ToString(), dataset.Tables[0].Rows[i][2].ToString(), dataset.Tables[0].Rows[i][3].ToString(), dataset.Tables[0].Rows[i][4].ToString(), dataset.Tables[0].Rows[i][5].ToString(), dataset.Tables[0].Rows[i][6].ToString(), dataset.Tables[0].Rows[i][7].ToString(), dataset.Tables[0].Rows[i][8].ToString(), dataset.Tables[0].Rows[i][9].ToString(), dataset.Tables[0].Rows[i][10].ToString(), dataset.Tables[0].Rows[i][11].ToString(), dataset.Tables[0].Rows[i][12].ToString(), dataset.Tables[0].Rows[i][13].ToString(), dataset.Tables[0].Rows[i][14].ToString(), dataset.Tables[1].Rows[i][0].ToString(), dataset.Tables[1].Rows[i][1].ToString(), dataset.Tables[1].Rows[i][2].ToString());
            }
            dsXml.Tables.Add(dt);
            xmldoc = new XmlDataDocument(dsXml);
            XmlElement xmlelement = xmldoc.DocumentElement;
        }
        return xmldoc;
    }
    [WebMethod(Description = "INSERT VOTER DETAILS")]
    public string InsertVoterDetails(string VoterDetails)
    {
        try
        {
            int inserted = 0;
            string[] str = null;
            string ACNO = String.Empty;
            string PARTNO = String.Empty;
            string SRNO = String.Empty;
            string CID = String.Empty;
            string ITEMID = String.Empty;
            string VALUE = String.Empty;
            string IMEI = String.Empty;
            string CreatedDate = String.Empty;
            string CreatedBy = String.Empty;
            string ModifiedDate = string.Empty;
            string ModifiedBy = string.Empty;
            string status = string.Empty;

            str = VoterDetails.Split(new char[] { '#', '*' });

            for (int i = 0; i < str.Length - 1; i += 11)
            {
                ACNO = str[i].ToString();
                PARTNO = str[i + 1];
                SRNO = str[i + 2].ToString();
                CID = str[i + 3].ToString();
                ITEMID = str[i + 4].ToString();
                VALUE = str[i + 5].ToString();
                IMEI = str[i + 6].ToString();
                CreatedDate = str[i + 7].ToString();
                CreatedBy = str[i + 8].ToString();
                ModifiedDate = str[i + 9].ToString();
                ModifiedBy = str[i + 10].ToString();
                ds.Clear();

                string sql = "SELECT ID FROM [TrueVoterDB].[dbo].[tblVoterDetails] WHERE [ACNO]='" + ACNO + "'AND [PARTNO]='" + PARTNO + "'AND [SRNO]='" + SRNO + "'AND [CID]='" + CID + "'AND [ITEMID]='" + ITEMID + "'AND [VALUE]='" + VALUE + "'";
                cmd = new SqlCommand(sql, con);
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                da.SelectCommand = cmd;
                da.Fill(ds);
                cmd.Connection.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string sql1 = "UPDATE [TrueVoterDB].[dbo].[tblVoterDetails] SET [ACNO]='" + ACNO + "',[PARTNO]='" + PARTNO + "',[SRNO]='" + SRNO + "',[CID]='" + CID + "',[ITEMID]='" + ITEMID + "',[VALUE]='" + VALUE + "',[IMEI]='" + IMEI + "',[ModifiedDate]='" + ModifiedDate + "',[ModifiedBy]='" + ModifiedBy + "' WHERE [ID]='" + ds.Tables[0].Rows[0]["ID"] + "'";
                    cmd = new SqlCommand(sql1, con);
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    inserted = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    status += inserted.ToString() + "*";
                }
                else
                {
                    string sql2 = "INSERT INTO [TrueVoterDB].[dbo].[tblVoterDetails]([ACNO],[PARTNO],[SRNO],[CID],[ITEMID],[VALUE],[IMEI],[CreatedDate],[CreatedBy])  VALUES ('" + ACNO + "','" + PARTNO + "','" + SRNO + "','" + CID + "','" + ITEMID + "','" + VALUE + "','" + IMEI + "','" + CreatedDate + "','" + CreatedBy + "')";
                    cmd = new SqlCommand(sql2, con);
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    inserted = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    status += inserted.ToString() + "*";
                }
            }
            if (status.EndsWith("*"))
            {
                status = status.Remove(status.Length - 1);
            }
            return status;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod(Description = "INSERT VOTER TIME DETAILS")]
    public string InsertVoterTimeDetails(string VotetimeDetails)
    {
        try
        {
            int inserted = 0;
            string[] str = null;
            string RECORDTYPE = String.Empty;
            string MALE = String.Empty;
            string FEMALE = String.Empty;
            string OTHER = String.Empty;
            string WARDNO = String.Empty;
            string BOOTHNO = String.Empty;
            string DISTID = String.Empty;
            string TALUKAID = String.Empty;
            string LOCALBODYID = String.Empty;
            string LOCALBODY = String.Empty;
            string IMEI = String.Empty;
            string TIME = String.Empty;

            string CreatedBy = String.Empty;
            string ModifiedDate = string.Empty;
            string ModifiedBy = string.Empty;
            string status = string.Empty;

            str = VotetimeDetails.Split(new char[] { '#', '*' });

            for (int i = 0; i < str.Length - 1; i += 12)
            {
                RECORDTYPE = str[i].ToString().Trim();
                MALE = str[i + 1].ToString().Trim();
                FEMALE = str[i + 2].ToString().Trim();
                OTHER = str[i + 3].ToString().Trim();
                WARDNO = str[i + 4].ToString().Trim();
                BOOTHNO = str[i + 5].ToString().Trim();
                DISTID = str[i + 6].ToString().Trim();
                TALUKAID = str[i + 7].ToString().Trim();
                LOCALBODYID = str[i + 8].ToString().Trim();
                LOCALBODY = str[i + 9].ToString().Trim();
                IMEI = str[i + 10].ToString().Trim();
                TIME = str[i + 11].ToString().Trim();
                ds.Clear();

                string sql = "SELECT ID FROM [TrueVoterDB].[dbo].[tblVoteTimeDetails] WHERE [RECORDTYPE]='" + RECORDTYPE + "' AND [WARDNO]='" + WARDNO + "' AND [BOOTHNO]='" + BOOTHNO + "' AND [DISTID]='" + DISTID + "' AND [TALUKAID]='" + TALUKAID + "' AND [LOCALBODYID]='" + LOCALBODYID + "' AND [LOCALBODY]='" + LOCALBODY + "' AND [TIME]='" + TIME + "'";
                cmd = new SqlCommand(sql, con);
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                da.SelectCommand = cmd;
                da.Fill(ds);
                cmd.Connection.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string sql1 = "UPDATE [TrueVoterDB].[dbo].[tblVoteTimeDetails] SET [RECORDTYPE]='" + RECORDTYPE + "',[MALE]='" + MALE + "',[FEMALE]='" + FEMALE + "',[OTHER]='" + OTHER + "', [WARDNO]='" + WARDNO + "', [BOOTHNO]='" + BOOTHNO + "', [DISTID]='" + DISTID + "' , [TALUKAID]='" + TALUKAID + "' , [LOCALBODYID]='" + LOCALBODYID + "' , [LOCALBODY]='" + LOCALBODY + "' , [IMEI]='" + IMEI + "', [TIME]='" + TIME + "',[Updatedby]='" + IMEI + "',[UpdatedDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt") + "' WHERE [ID]='" + ds.Tables[0].Rows[0]["ID"] + "'";
                    cmd = new SqlCommand(sql1, con);
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    inserted = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    status += inserted.ToString() + "*";
                }
                else
                {
                    string sql2 = "INSERT INTO [TrueVoterDB].[dbo].[tblVoteTimeDetails]([RECORDTYPE],[MALE],[FEMALE],[OTHER],[WARDNO],[BOOTHNO],[DISTID],[TALUKAID],[LOCALBODYID],[LOCALBODY],[IMEI],[TIME],[Createdby],[CreatedDate])  VALUES ('" + RECORDTYPE + "','" + MALE + "','" + FEMALE + "','" + OTHER + "','" + WARDNO + "','" + BOOTHNO + "','" + DISTID + "','" + TALUKAID + "','" + LOCALBODYID + "','" + LOCALBODY + "','" + IMEI + "','" + TIME + "','" + IMEI + "','" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt") + "')";
                    cmd = new SqlCommand(sql2, con);
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    inserted = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    status += inserted.ToString() + "*";
                }
            }
            if (status.EndsWith("*"))
            {
                status = status.Remove(status.Length - 1);
            }
            return status;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
