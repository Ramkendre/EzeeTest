using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net;


namespace Myct
{
    public class MYCT
    {

        private static byte[] keys = { };
        private static byte[] IVs = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static string EncryptionKeys = "!5623a#de";
        const string DESKey = "AQWSEDRF";
        const string DESIV = "HGFEDCBA";
        private string connectionString = "server=www.Come2myCity.com;User Id=Come2mycity; Password=myct2013;Min Pool Size=20; Max Pool Size=200;";
        //private string connectionString = "server=118.67.249.128;User Id=onlineexam; Password=onlineexam12345;Min Pool Size=20; Max Pool Size=200;";
        private SqlConnection sqlConnection;
        public string ErrorMessage;
        public int errorNumber;
        public string stackTrace, sqlQuery;
        private SqlCommand sqlCommand = new SqlCommand();
        public DataSet UserDataset { get; set; }
        private string CurrenctDate = "", UpperKeword = "";
        private string DateFormat = "";

        private BllAddAgencyThrMobile bllagency = new BllAddAgencyThrMobile();
        private RegisterToMyct regmyct = new RegisterToMyct();



        private int status = 0;
        private string result = "";
        private int count = 0;
        private string Regid = "";
        private DataSet ds;
        private DataTable dt;
        private string strXml = "", Sql1 = "";
        private string OrderNo = "", exError = "";






        public MYCT()
        {
            sqlConnection = new SqlConnection(connectionString);

        }
        public string registerUser(string userFirstName, string userLastName, string userMobileNumber)
        {
            string password = null;
            string sqlQuery = "SELECT usrPassword FROM [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo=@mobileNumber";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            try
            {
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                sqlCommand.Parameters.AddWithValue("@mobileNumber", userMobileNumber);
                password = Convert.ToString(sqlCommand.ExecuteScalar());
                if (String.IsNullOrEmpty(password))
                {
                    Random random = new Random();

                    string userId = System.Guid.NewGuid().ToString();

                    password = DESEncrypt(Convert.ToString(random.Next(10001, 99999)));
                    sqlQuery = "INSERT INTO [Come2myCityDB].[dbo].[UserMaster] (usrUserId,usrPassword,usrFirstName,usrLastName,usrMobileNo) VALUES('" + userId + "','" + password + "','" + userFirstName + "','" + userLastName + "','" + userMobileNumber + "');";
                    sqlCommand.CommandText = sqlQuery;


                    int flag = sqlCommand.ExecuteNonQuery();
                    return password;
                    //if (flag == 1)
                    //    password = DESDecrypt(password);
                    //else
                    //    password = "0";

                }

            }
            catch (SqlException sqlException) { password = "0"; throw sqlException; }
            catch (Exception exception) { password = "0"; throw exception; }
            finally { sqlCommand.Dispose(); sqlCommand.Connection.Close(); }



            return password;

        }
        internal string DESEncrypt_CT(string stringToEncrypt)// Encrypt the content
        {

            byte[] key;
            byte[] IV;

            byte[] inputByteArray;
            try
            {

                key = Convert2ByteArray(DESKey);
                IV = Convert2ByteArray(DESIV);
                inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream(); CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }

            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        internal string DESDecrypt(string stringToDecrypt)//Decrypt the content
        {

            byte[] key;
            byte[] IV;

            byte[] inputByteArray;
            try
            {

                key = Convert2ByteArray(DESKey);
                IV = Convert2ByteArray(DESIV);

                stringToDecrypt = stringToDecrypt.Replace(" ", "+");



                int len = stringToDecrypt.Length;
                inputByteArray = Convert.FromBase64String(stringToDecrypt);

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8; return encoding.GetString(ms.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        internal string DESEncrypt(string stringToEncrypt)// Encrypt the content
        {

            byte[] key;
            byte[] IV;

            byte[] inputByteArray;
            try
            {

                key = Convert2ByteArray(DESKey);
                IV = Convert2ByteArray(DESIV);
                inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream(); CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }

            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        internal byte[] Convert2ByteArray(string strInput)
        {

            int intCounter; char[] arrChar;
            arrChar = strInput.ToCharArray();

            byte[] arrByte = new byte[arrChar.Length];

            for (intCounter = 0; intCounter <= arrByte.Length - 1; intCounter++)
                arrByte[intCounter] = Convert.ToByte(arrChar[intCounter]);

            return arrByte;
        }





        /// <summary>
        /// Query which is executed on myct database
        /// </summary>
        /// <param name="sqlQuery">Query which is going to execute</param>
        /// <param name="tableOfMyct">table array of myct with full qualifing name</param>
        /// <returns>dataset</returns>
        public DataSet QueryToExecute(string sqlQuery, string[] tableOfMyct)
        {
            try
            {
                DataSet ds = new DataSet();
                foreach (string tableName in tableOfMyct)
                {
                    sqlQuery = sqlQuery.Replace(tableName, tableName);
                }
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(ds);
                return ds;
            }
            catch (SqlException sqlException) { ErrorMessage = "Error Occure While Execution"; stackTrace = sqlException.StackTrace; }
            catch (Exception exception) { ErrorMessage = "Error Occure While Execution"; stackTrace = exception.StackTrace; }
            return null;
        }
        /// <summary>
        /// Get User Inforamtion.
        /// </summary>
        /// <param name="searchParameter"> string Value Based On Which Search </param>
        /// <param name="what">1-Based on UserId
        /// 2-Based on Mobile Number
        /// 3-Based on IMEINumber</param>
        /// <returns>DataTable</returns>
        public DataTable SELECT(string searchParameter, int what)
        {
            switch (what)
            {
                case 1: return getUserInformationBasedOnUserId(searchParameter);

                case 2: return getUserInformationBasedOnMobileNumber(searchParameter);

                case 3: return getUserInformationBasedOnIMEINUmber(searchParameter);
            }
            ErrorMessage = "Wrong Input";
            return null;
        }
        private DataTable getUserInformationBasedOnUserId(string searchParameter)
        {
            DataTable dt = new DataTable();
            try
            {

                sqlQuery = " SELECT *FROM [Come2myCityDB].[dbo].[UserMaster] WHERE [usrUserId]='" + searchParameter + "'";
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Connection = sqlConnection;

                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                dt.Load(reader);
                return dt;

            }
            catch (SqlException sqlException) { ErrorMessage = "Error Occure While Execution"; stackTrace = sqlException.StackTrace; }
            catch (Exception exception) { ErrorMessage = "Error Occure While Execution"; stackTrace = exception.StackTrace; }
            finally { sqlCommand.Dispose(); sqlCommand.Connection.Close(); }
            return null;
        }
        private DataTable getUserInformationBasedOnMobileNumber(string mobileNumber)
        {
            DataTable dt = new DataTable();
            try
            {

                sqlQuery = " SELECT *FROM [Come2myCityDB].[dbo].[UserMaster] WHERE [usrMobileNo]='" + mobileNumber + "'";
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Connection = sqlConnection;

                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                dt.Load(reader);
                return dt;

            }
            catch (SqlException sqlException) { ErrorMessage = "Error Occure While Execution"; stackTrace = sqlException.StackTrace; }
            catch (Exception exception) { ErrorMessage = "Error Occure While Execution"; stackTrace = exception.StackTrace; }
            finally { sqlCommand.Dispose(); sqlCommand.Connection.Close(); }
            return null;

        }
        private DataTable getUserInformationBasedOnIMEINUmber(string imeiNumber)
        {
            DataTable dt = new DataTable();
            try
            {

                sqlQuery = " SELECT *FROM [Come2myCityDB].[dbo].[UserMaster] WHERE [strDevId]='" + imeiNumber + "'";
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Connection = sqlConnection;

                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                dt.Load(reader);
                return dt;

            }
            catch (SqlException sqlException) { ErrorMessage = "Error Occure While Execution"; stackTrace = sqlException.StackTrace; }
            catch (Exception exception) { ErrorMessage = "Error Occure While Execution"; stackTrace = exception.StackTrace; }
            finally { sqlCommand.Dispose(); sqlCommand.Connection.Close(); }
            return null;


        }
        /// <summary>
        /// Log In In Myct
        /// </summary>
        /// <param name="userId">Mobile Number</param>
        /// <param name="password">Password</param>
        /// <returns>boolean and if true return data in userDataset else error if in Return message</returns>
        public Boolean getLogInDetails(string userId, string password)
        {
            UserDataset = new DataSet();
            bool login = false;
            string sqlQuery = "execute [Come2myCityDB].[dbo].[Authenticate] @UserId = N'" + userId + "',@Password = N'" + password + "'";
            try
            {
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = sqlCommand;
                adapter.Fill(UserDataset);
                login = true;
            }
            catch (SqlException sqlExcepiton)
            {
                login = false;
                errorNumber = sqlExcepiton.ErrorCode;
                ErrorMessage = "Error in Execution";
                stackTrace = sqlExcepiton.StackTrace;
            }
            catch (Exception ex)
            {
                login = false;
                ErrorMessage = "Error in Execution";
                stackTrace = ex.StackTrace;
            }

            return login;



        }
        public string ALLAppsRegistration(string AppMobileNo, string keyword, string strDevId, string strSimSerialNo, string firstName, string lastName, string firmName,
                                     string RefmobileNo, string address, string Qualification, string Spatialization, string LadlineNo, string Favorite, string eMailId, string typeOfUse_Id, string pincode, string passcode,
                                     string latitude, string longitude, string state, string district, string Taluka, string Village, string userType)
        {
            #region AppsRegistration
            keyword = keyword.ToUpper();
            string Data = "0";
            DataSet ds = new DataSet();
            int i = 0;

            try
            {
                string getuserID = GetRegisterRecord(AppMobileNo, firstName, lastName, address, pincode, strDevId);
                if (String.IsNullOrEmpty(getuserID))
                {
                }
                else
                {
                    string Sqlchk = "Select EzeeDrugAppId from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where  mobileNo='" + AppMobileNo + "'  and keyword='" + keyword + "'";//and strDevId = '" + strDevId + "' 
                    ds = ExecuteDataset(Sqlchk);

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        string Sql = "Insert Into [Come2myCityDB].[dbo].[EzeeDrugsAppDetail](keyword,strDevId,strSimSerialNo,firstName,lastName,firmName,mobileNo,address,eMailId,typeOfUse_Id,pincode,passcode,latitude,longitude,EntryDate,UserId,RefMobileNo ,State,District,usertype,Qualification,LadlineNo,Favorite,Village,Spatialization,Taluka)" +
                                     "Values('" + keyword + "','" + strDevId + "','" + strSimSerialNo + "','" + firstName + "','" + lastName + "','" + firmName + "','" + AppMobileNo + "','" + address + "','" + eMailId + "','" +
                                     typeOfUse_Id + "','" + pincode + "','" + passcode + "','" + latitude + "','" + longitude + "','" + Convert.ToString(CurrenctDate) + "','" + getuserID + "','" + RefmobileNo + "','" + state + "','" + district + "','" + userType + "','" + Qualification + "','" + LadlineNo + "','" + Favorite + "','" + Village + "','" + Spatialization + "','" + Taluka + "')";
                        i = ExecuteNonQuery(Sql);
                        if (i == 1)
                        {

                            if (keyword == "EZEEDRUG")
                            {

                                int status;
                                status = FirmRegistration(strDevId, strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, typeOfUse_Id, pincode, RefmobileNo, CurrenctDate, passcode, longitude, latitude, state, district, Taluka, userType, address, LadlineNo, Favorite, Qualification, Spatialization, Village);
                                Data = Convert.ToString(status);
                            }
                            else if (keyword == "EZEECLASS")
                            {
                                Data = "1";
                                //OnExam.classregistration(strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, address, pincode, RefmobileNo);
                            }
                            else if (keyword == "EZEESCHOOLAPP")
                            {
                                Data = "1";
                                string FullName = firstName + " " + lastName;
                                //scID.SchoolAppRegistrationDetails(strDevId, strSimSerialNo, FullName, firmName, AppMobileNo, getuserID);
                            }
                            else if (keyword == "MHVIDHANAPP")//use for the register the user
                            {
                                Data = "1";
                            }
                            else if (keyword == "EZEEMOBILE")//use for the register the user
                            {
                                Data = "1";
                            }



                        }
                    }
                    else
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            string Sql = "Update [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] set strDevId = '" + strDevId + "', firstName='" + firstName + "',lastName='" + lastName + "',firmName='" + firmName + "',address='" + address + "',eMailId='" + eMailId + "',typeOfUse_Id='" + typeOfUse_Id + "',pincode='" + pincode + "',passcode='" + passcode + "',latitude='" + latitude + "',longitude='" + longitude + "',EntryDate='" + Convert.ToString(CurrenctDate) + "',UserId='" + getuserID + "',RefMobileNo='" + RefmobileNo + "' ,State='" + state + "',District='" + district + "',usertype='" + userType + "',Qualification = '" + Qualification + "',LadlineNo = '" + LadlineNo + "',Favorite = '" + Favorite + "',Village = '" + Village + "',Spatialization = '" + Spatialization + "' where  EzeeDrugAppId=" + row[0] + "";
                            i = ExecuteNonQuery(Sql);
                        }
                        if (i == 1)
                        {
                            if (keyword == "EZEEDRUG")
                            {
                                int status;

                                status = FirmRegistration(strDevId, strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, typeOfUse_Id, pincode, RefmobileNo, CurrenctDate, passcode, longitude, latitude, state, district, Taluka, userType, address, LadlineNo, Favorite, Qualification, Spatialization, Village);
                                Data = Convert.ToString(status);
                            }
                            else if (keyword == "EZEECLASS")
                            {
                                Data = "1";
                                //  OnExam.classregistration(strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, address, pincode, RefmobileNo);
                            }
                            else if (keyword == "EZEESCHOOLAPP")
                            {
                                Data = "1";

                                string FullName = firstName + " " + lastName;
                                // scID.SchoolAppRegistrationDetails(strDevId, strSimSerialNo, FullName, firmName, AppMobileNo, getuserID);

                            }
                            else if (keyword == "MHVIDHANAPP")//use for the register users
                            {
                                Data = "1";
                            }
                            else if (keyword == "EZEEMOBILE")//use for the register the user
                            {
                                Data = "1";
                            }


                        }
                    }
                }
            }
            catch (Exception ex)
            { }
            return Data;
            #endregion AppsRegistration
        }




        //------------------------------------------------------User Registration To MYCT------------------------------------------------------------------


        public string GetRegisterRecord(string MobileNo, string Fname, string Lname, string address, string pincode, string strDevId)
        {
            int i, smslength;
            string id = "";
            DataSet ds = new DataSet();
            try
            {

                UserRegistrationBLL balobj = new UserRegistrationBLL();


                balobj.usrFirstName = Fname;
                balobj.usrLastName = Lname;
                balobj.usrMobileNo = MobileNo;
                balobj.usrAddress = address;
                balobj.usrPIN = pincode;
                balobj.StrDevId = strDevId;
                i = balobj.BLLIsExistUserRegistrationInitial(balobj);//check user is exist or not if i = 0 then already exist 
                if (i > 0)
                {
                    balobj.usrUserId = System.Guid.NewGuid().ToString();
                    Random rnd = new Random();
                    balobj.usrPassword = DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    i = balobj.BLLInsertUserRegistrationInitial(balobj);
                    if (i > 0)
                    {
                        id = balobj.usrUserId;
                        string myMobileNo = balobj.usrMobileNo;
                        string myPassword = DESDecrypt(balobj.usrPassword);
                        string myName = balobj.usrFirstName;
                        Myct.CommonCode cc = new CommonCode();
                        string passwordMessage = "Welcome " + myName + ",for ur First Login Username=" + myMobileNo + " & Password is " + myPassword + "  " + cc.AddSMS(myMobileNo);
                        smslength = passwordMessage.Length;
                        TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);

                        //------------------------------ For Dublicate IMEI number....................

                        string sql3 = "select [usrMobileNo] from [Come2myCityDB].[dbo].[UserMaster] where strDevId = '" + strDevId + "'";//takes all mobile number who have same IMEI number
                        ds = ExecuteDataset(sql3);

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            if (row[0].Equals(MobileNo))
                            {
                            }
                            else
                            {
                                string sql = "update [Come2myCityDB].[dbo].[UserMaster] set StrDevId = '0' where [usrMobileNo] ='" + row[0] + "' ";
                                int j = ExecuteNonQuery(sql);
                            }
                        }

                    }
                }
                else
                {

                   string sqlget = "select usrUserid from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + MobileNo + "'";//geting userid of user
                    id = ExecuteScalar(sqlget);

                    string sql2 = "select strDevId from [Come2myCityDB].[dbo].[UserMaster] where usrUserid='" + id + "' ";
                    string str = ExecuteScalar(sql2);

                    if (str == "" || str == null || str == "0")// If IMEI no is null
                    {
                        string sql = "Update [Come2myCityDB].[dbo].[UserMaster] set StrDevId = '" + strDevId + "' where usrUserid ='" + id + "' ";//to add/update IMEI no's for old entries
                        int j = ExecuteNonQuery(sql);
                    }


                    string sql3 = "select [usrMobileNo] from [Come2myCityDB].[dbo].[UserMaster] where strDevId = '" + str + "'";//takes all mobile number who have same IMEI number
                    ds = ExecuteDataset(sql3);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (row[0].Equals(MobileNo))
                        {
                        }
                        else
                        {
                            string sql = "update [Come2myCityDB].[dbo].[UserMaster] set StrDevId = '0' where [usrMobileNo] ='" + row[0] + "' ";
                            int j = ExecuteNonQuery(sql);
                        }
                    }

                }

            }
            catch (Exception ex)
            { }
            return id;
        }

        private string ExecuteScalar(string sql2)
        {
            string data = string.Empty;
            try
            {
                sqlCommand.CommandText = sql2;
                sqlCommand.Connection = sqlConnection;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                data = Convert.ToString(sqlCommand.ExecuteScalar());
            }
            catch (SqlException sqlException)
            { }
            catch (Exception exepiton)
            { }
            finally { sqlCommand.Dispose(); sqlCommand.Connection.Close(); }
            return data;
        }

        private DataSet ExecuteDataset(string sql3)
        {
            DataSet ds = new DataSet();
            try
            {
                sqlCommand.CommandText = sql3;
                sqlCommand.Connection = sqlConnection;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(ds);
            }
            catch (SqlException sqlException)
            { }
            catch (Exception exepiton)
            { }
            finally { sqlCommand.Dispose(); sqlCommand.Connection.Close(); }
            return ds;
        }

        private int ExecuteNonQuery(string sql)
        {
            int data = 0;
            try
            {
                sqlCommand.CommandText = sql;
                sqlCommand.Connection = sqlConnection;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                data = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlException)
            { }
            catch (Exception exepiton)
            { }
            finally { sqlCommand.Dispose(); sqlCommand.Connection.Close(); }
            return data;
        }


        //------------------------------------------------------All Android Apps Registration--------------------------------------------------------------


        //public string ALLAppsRegistration(string AppMobileNo, string keyword, string strDevId, string strSimSerialNo, string firstName, string lastName, string firmName,
        //                                  string RefmobileNo, string address, string Qualification, string Spatialization, string LadlineNo, string Favorite, string eMailId, string typeOfUse_Id, string pincode, string passcode,
        //                                  string latitude, string longitude, string state, string district, string Village, string userType)
        //{
        //    #region AppsRegistration
        //    keyword = keyword.ToUpper();
        //    string Data = "0";
        //    DataSet ds = new DataSet();
        //    int i = 0;

        //    try
        //    {
        //        string getuserID = GetRegisterRecord(AppMobileNo, firstName, lastName, address, pincode, strDevId);
        //        if (String.IsNullOrEmpty(getuserID))
        //        {
        //        }
        //        else
        //        {




        //            string Sqlchk = "Select EzeeDrugAppId from EzeeDrugsAppDetail where  mobileNo='" + AppMobileNo + "'  and keyword='" + keyword + "'";//and strDevId = '" + strDevId + "' 
        //            ds = cc.ExecuteDataset(Sqlchk);

        //            if (ds.Tables[0].Rows.Count == 0)
        //            {
        //                string Sql = "Insert Into EzeeDrugsAppDetail(keyword,strDevId,strSimSerialNo,firstName,lastName,firmName,mobileNo,address,eMailId,typeOfUse_Id,pincode,passcode,latitude,longitude,EntryDate,UserId,RefMobileNo ,State,District,usertype,Qualification,LadlineNo,Favorite,Village,Spatialization)" +
        //                             "Values('" + keyword + "','" + strDevId + "','" + strSimSerialNo + "','" + firstName + "','" + lastName + "','" + firmName + "','" + AppMobileNo + "','" + address + "','" + eMailId + "','" +
        //                             typeOfUse_Id + "','" + pincode + "','" + passcode + "','" + latitude + "','" + longitude + "','" + Convert.ToString(CurrenctDate) + "','" + getuserID + "','" + RefmobileNo + "','" + state + "','" + district + "','" + userType + "','" + Qualification + "','" + LadlineNo + "','" + Favorite + "','" + Village + "','" + Spatialization + "')";
        //                i = cc.ExecuteNonQuery(Sql);
        //                if (i == 1)
        //                {

        //                    if (keyword == "EZEEDRUG")
        //                    {

        //                        int status;
        //                        status = drug.FirmRegistration(strDevId, strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, typeOfUse_Id, pincode, RefmobileNo, CurrenctDate, passcode, longitude, latitude, state, district, userType, address, LadlineNo, Favorite, Qualification, Spatialization, Village);
        //                        Data = Convert.ToString(status);
        //                              }
        //                    else if (keyword == "EZEECLASS")
        //                    {
        //                        Data = "1";
        //                       // OnExam.classregistration(strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, address, pincode, RefmobileNo);
        //                    }
        //                    else if (keyword == "EZEESCHOOLAPP")
        //                    {
        //                        Data = "1";
        //                        string FullName = firstName + " " + lastName;
        //                       // scID.SchoolAppRegistrationDetails(strDevId, strSimSerialNo, FullName, firmName, AppMobileNo, getuserID);
        //                    }
        //                    else if (keyword == "MHVIDHANAPP")//use for the register the user
        //                    {
        //                        Data = "1";
        //                    }
        //                    else if (keyword == "EZEEMOBILE")//use for the register the user
        //                    {
        //                        Data = "1";
        //                    }

        //                    //Data = "1";

        //                }
        //            }
        //            else
        //            {
        //                foreach (DataRow row in ds.Tables[0].Rows)
        //                {
        //                    string Sql = "Update EzeeDrugsAppDetail set strDevId = '" + strDevId + "', firstName='" + firstName + "',lastName='" + lastName + "',firmName='" + firmName + "',address='" + address + "',eMailId='" + eMailId + "',typeOfUse_Id='" + typeOfUse_Id + "',pincode='" + pincode + "',passcode='" + passcode + "',latitude='" + latitude + "',longitude='" + longitude + "',EntryDate='" + Convert.ToString(CurrenctDate) + "',UserId='" + getuserID + "',RefMobileNo='" + RefmobileNo + "' ,State='" + state + "',District='" + district + "',usertype='" + userType + "',Qualification = '" + Qualification + "',LadlineNo = '" + LadlineNo + "',Favorite = '" + Favorite + "',Village = '" + Village + "',Spatialization = '" + Spatialization + "' where  EzeeDrugAppId=" + row[0] + "";
        //                    i = cc.ExecuteNonQuery(Sql);
        //                }
        //                if (i == 1)
        //                {
        //                    if (keyword == "EZEEDRUG")
        //                    {
        //                        int status;

        //                      //  status = drug.FirmRegistration(strDevId, strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, typeOfUse_Id, pincode, RefmobileNo, CurrenctDate, passcode, longitude, latitude, state, district, userType, address, LadlineNo, Favorite, Qualification, Spatialization, Village);
        //                        Data = Convert.ToString(status);
        //                                                  }
        //                    else if (keyword == "EZEECLASS")
        //                    {
        //                        Data = "1";
        //                      //  OnExam.classregistration(strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, address, pincode, RefmobileNo);
        //                    }
        //                    else if (keyword == "EZEESCHOOLAPP")
        //                    {
        //                        Data = "1";

        //                        string FullName = firstName + " " + lastName;
        //                    //    scID.SchoolAppRegistrationDetails(strDevId, strSimSerialNo, FullName, firmName, AppMobileNo, getuserID);

        //                    }
        //                    else if (keyword == "MHVIDHANAPP")//use for the register users
        //                    {
        //                        Data = "1";
        //                    }
        //                    else if (keyword == "EZEEMOBILE")//use for the register the user
        //                    {
        //                        Data = "1";
        //                    }


        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    { }
        //    return Data;
        //    #endregion AppsRegistration
        //}

        public bool TransactionalSMSCountry(string sendFrom, string sendTo, string fwdMessage, int smslength, int SenderCode)
        {
            bool flagMsgSuccess = false;

            try
            {
                fwdMessage = fwdMessage.Replace("&", "and");
                string sendto = Convert.ToString(sendTo);
                fwdMessage = fwdMessage.Replace("sssss", "'");
                fwdMessage = fwdMessage.Replace("aaaaa", "&");
                //mailSendingSMS(sendFrom, sendto, fwdMessage);
                string senderid = "myctin";
                string userid = "ezeesoft";
                string password = "67893";
                fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
                string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
                string url = "http://www.smscountry.com/SMSCwebservice.aspx?";

                string result = "";
                StreamWriter myWriter = null;
                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strRequest);
                objRequest.Method = "POST";
                objRequest.ContentLength = strRequest.Length;
                objRequest.ContentType = "application/x-www-form-urlencoded";
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(strRequest);
                myWriter.Close();
                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                    sr.Close();
                }
                if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
                {
                    result = "unable to Process SMS between 9 PM to 9 AM.";
                }

                //fwdMessage = fwdMessage.Replace("'", "sssss");
                //fwdMessage = fwdMessage.Replace("&", "aaaaa");
                fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);

                string sql = "insert into [Come2myCityDB].[come2mycity].[sendSMSstatus](SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "'," + SenderCode + ",'" + smslength + "','" + DateFormatStatus() + "')";
                int d = ExecuteNonQuery(sql);
                string resultMsg = result;
                //if (resultMsg.Contains("EZEESOFT"))
                if (resultMsg.Contains("203179963"))
                {

                    flagMsgSuccess = true;
                }
                else
                {
                    flagMsgSuccess = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            flagMsgSuccess = true;
            return flagMsgSuccess;
        }

        private string DateFormatStatus()
        {
            DateTime dt = DateTime.Now; // get current date
            double d = 12; //add hours in time
            double m = 35; //add min in time
            DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
            SystemDate = SystemDate.AddMinutes(m);
            DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss''");
            string ds1 = Convert.ToString(DateFormat);
            return ds1;
        }


        public int FirmRegistration(string IMEI, string RefSimNo, string FirmName, string Fname, string Lname, string MobileNo, string EmailId, string FirmType, string Pincode, string ReferencemobileNo, string CreateDate, string passcode, string Longitute, string Latitute, string state, string district,string Taluka, string usertype, string address, string PhoneNo1, string FavName, string DocQualification, string DocSpacialization, string City)
        {
            try
            {
                string str = "insert into [DBeZeeHealth].[dbo].[tbldemo] (FirstName, LastName, MobNo)values('" + Fname + "','" + Lname + "','" + MobileNo + "')";
                int status2 = ExecuteNonQuery(str);

                string regid = regmyct.Addnew(Fname, Lname, MobileNo);
                //string regid = regmyct.AddnewWithIMEI(Fname, Lname, MobileNo, IMEI);
                if (regid != "" || regid == null)
                {
                    bllagency.IMEI1 = IMEI;
                    bllagency.NameFirm_Hospital1 = FirmName;
                    bllagency.CP_FirstName1 = Fname;
                    bllagency.CP_LastName1 = Lname;
                    bllagency.MobileNo_1 = MobileNo;
                    bllagency.Email_Id1 = EmailId;
                    bllagency.FirmType1 = FirmType;
                    bllagency.State1 = state;
                    bllagency.district1 = district;
                    bllagency.Taluka1 = Taluka;
                    bllagency.Pincode1 = Convert.ToString(Pincode);
                    bllagency.LoginID1 = MobileNo;  // Convert.ToString(ReferencemobileNo);  // ref no previous
                    bllagency.CreateDate1 = CreateDate;  //yyyy-mm-dd
                    bllagency.Passcode = passcode;
                    bllagency.MyctPwd = regid;
                    bllagency.Longitute = Longitute;
                    bllagency.Latitute1 = Latitute;
                    bllagency.Usertype = usertype;
                    bllagency.Address1 = address;
                    bllagency.FavName1 = FavName;
                    bllagency.PhoneNo_1 = PhoneNo1;
                    bllagency.City1 = City;

                    if (FirmType == "1")
                        bllagency.FavMobileno1 = ReferencemobileNo;
                    else
                        bllagency.FavMobileno1 = "";

                    bllagency.DocQualification1 = DocQualification;
                    bllagency.DocSpacialization1 = DocSpacialization;



                    status = bllagency.RegFirm(bllagency);  /// / dal bal 

                    string Regidowner = Convert.ToString(bllagency.RegId1);

                    if (status == 1)
                    {
                        bllagency.IMEI1 = "";

                        string SQL = "";
                        Regid = Convert.ToString(bllagency.RegId1);
                        if (FirmType == "3" || FirmType == "4")
                        {
                            //// "3":  // retailer
                            SQL = "Select RegId from [DBeZeeHealth].[dbo].[tblRegistration$] where  MobileNo1='" + ReferencemobileNo + "'";
                            string Retailer_RegId = ExecuteScalar(SQL);
                            if (Retailer_RegId != "")
                            {
                                if (Regidowner == Retailer_RegId)
                                {
                                }
                                else
                                {
                                    string DR_relation = "select DR_Id from [DBeZeeHealth].[dbo].[tblRelationDealer_Retailer] where Dealer_RegId='" + Retailer_RegId + "' and Retailer_RegId='" + Regidowner + "'";
                                    string DR_Id = ExecuteScalar(DR_relation);
                                    if (DR_Id == "" || DR_Id == null)
                                    {
                                        string AddAgency = "insert into [DBeZeeHealth].[dbo].[tblRelationDealer_Retailer] (Dealer_RegId,Retailer_RegId,LoginId,Entrydate,entryway,Active)values('" + Retailer_RegId + "','" + Regidowner + "','" + ReferencemobileNo + "','" + System.DateTime.Now.ToString() + "','Customer_Apps',1)";
                                        status = ExecuteNonQuery(AddAgency);
                                    }
                                    else
                                    {
                                    }
                                }
                            }
                            else
                            {
                                ////reg regmob No if not reg and add as dealer of owner number 

                                //// regid = regmyct.Addnew(Fname, Lname, MobileNo);
                                regid = regmyct.Addnew("Shree", "Shree", ReferencemobileNo);
                                if (regid != "" || regid == null)
                                {
                                    bllagency.NameFirm_Hospital1 = "Shree";
                                    bllagency.CP_FirstName1 = "shree";
                                    bllagency.CP_LastName1 = "shree";
                                    bllagency.MobileNo_1 = ReferencemobileNo;
                                    bllagency.Email_Id1 = EmailId;
                                    bllagency.FirmType1 = "4";
                                    bllagency.State1 = state;
                                    bllagency.district1 = district;
                                    bllagency.Taluka1 = Taluka;
                                    bllagency.Pincode1 = "111111";
                                    bllagency.LoginID1 = Convert.ToString(ReferencemobileNo);  // ref no previous
                                    bllagency.CreateDate1 = CreateDate;  //yyyy-mm-dd
                                    bllagency.Passcode = "111122";
                                    bllagency.MyctPwd = regid;
                                    bllagency.Longitute = Longitute;
                                    bllagency.Latitute1 = Latitute;
                                    bllagency.Usertype = usertype;
                                    bllagency.Address1 = address;
                                    status = bllagency.RegFirm(bllagency);  /// / dal bal

                                    if (status == 1)
                                    {
                                        SQL = "Select RegId from [DBeZeeHealth].[dbo].[tblRegistration$] where  MobileNo1='" + ReferencemobileNo + "'";
                                        Retailer_RegId = ExecuteScalar(SQL);
                                        if (Retailer_RegId != "")
                                        {

                                            if (Regidowner == Retailer_RegId)
                                            {
                                                //lblerror.Text = "Login User can't add As a Customer";
                                                //lblerror.Visible = true;
                                                //visibilityControl(false);
                                            }
                                            else
                                            {
                                                string DR_relation = "select DR_Id from [DBeZeeHealth].[dbo].[tblRelationDealer_Retailer] where Dealer_RegId='" + Retailer_RegId + "' and Retailer_RegId='" + Regidowner + "'";
                                                string DR_Id = ExecuteScalar(DR_relation);
                                                if (DR_Id == "" || DR_Id == null)
                                                {
                                                    string AddAgency = "insert into [DBeZeeHealth].[dbo].[tblRelationDealer_Retailer] (Dealer_RegId,Retailer_RegId,LoginId,Entrydate,entryway,Active)values('" + Retailer_RegId + "','" + Regidowner + "','" + ReferencemobileNo + "','" + System.DateTime.Now.ToString() + "','Customer_Apps',1)";
                                                    status = ExecuteNonQuery(AddAgency);
                                                }

                                            }

                                        }
                                    }

                                }

                            }
                        }

                        else if (FirmType == "5" || FirmType == "7")  ////case "5": //salesman
                        {
                            SQL = "Select RegId from [DBeZeeHealth].[dbo].[tblRegistration$] where  MobileNo1='" + ReferencemobileNo + "' ";
                            string companyId = ExecuteScalar(SQL);
                            if (companyId != "")
                            {
                                if (Regidowner == companyId)
                                {
                                    //lblerror.Text = "Login User can't add As a Agency";
                                    //lblerror.Visible = true;
                                    //visibilityControl(false);
                                }
                                else
                                {
                                    string DR_relation = "select SalesMR_Id from [DBeZeeHealth].[dbo].[tblRelationUser_SalesMan_MR] where SalesMR_RegId='" + companyId + "' and Active=1 ";
                                    string DR_Id = ExecuteScalar(DR_relation);
                                    if (DR_Id == "" || DR_Id == null)
                                    {
                                        string AddAgency = "insert into [DBeZeeHealth].[dbo].[tblRelationUser_SalesMan_MR] (User_RegId,SalesMR_RegId,LoginId,Entrydate,Active)values('" + companyId + "','" + Regidowner + "','" + ReferencemobileNo + "','" + System.DateTime.Now.ToString() + "',1)";
                                        status = ExecuteNonQuery(AddAgency);
                                    }
                                }

                            }
                            else
                            {
                                #region regRefNumber
                                //// regid = regmyct.Addnew(Fname, Lname, MobileNo);
                                regid = regmyct.Addnew("Shree", "Shree", ReferencemobileNo);
                                if (regid != "" || regid == null)
                                {
                                    bllagency.NameFirm_Hospital1 = "Shree";
                                    bllagency.CP_FirstName1 = "shree";
                                    bllagency.CP_LastName1 = "shree";
                                    bllagency.MobileNo_1 = ReferencemobileNo;
                                    bllagency.Email_Id1 = EmailId;
                                    bllagency.FirmType1 = "4";
                                    bllagency.State1 = state;
                                    bllagency.district1 = district;
                                    bllagency.Taluka1 = Taluka;
                                    bllagency.Pincode1 = "111111";
                                    bllagency.LoginID1 = Convert.ToString(ReferencemobileNo);  // ref no previous
                                    bllagency.CreateDate1 = CreateDate;  //yyyy-mm-dd
                                    bllagency.Passcode = "111122";
                                    bllagency.MyctPwd = regid;
                                    bllagency.Longitute = Longitute;
                                    bllagency.Latitute1 = Latitute;
                                    bllagency.Usertype = usertype;
                                    bllagency.Address1 = address;
                                    status = bllagency.RegFirm(bllagency);  /// / dal bal

                                    if (status == 1)
                                    {
                                        SQL = "Select RegId from [DBeZeeHealth].[dbo].[tblRegistration$] where  MobileNo1='" + ReferencemobileNo + "' ";
                                        companyId = ExecuteScalar(SQL);
                                        if (companyId != "")
                                        {
                                            if (Regidowner == companyId)
                                            {
                                                //lblerror.Text = "Login User can't add As a Agency";
                                                //lblerror.Visible = true;
                                                //visibilityControl(false);
                                            }
                                            else
                                            {
                                                string DR_relation = "select SalesMR_Id from [DBeZeeHealth].[dbo].[tblRelationUser_SalesMan_MR] where SalesMR_RegId='" + companyId + "' and Active=1 ";
                                                string DR_Id = ExecuteScalar(DR_relation);
                                                if (DR_Id == "" || DR_Id == null)
                                                {
                                                    string AddAgency = "insert into [DBeZeeHealth].[dbo].[tblRelationUser_SalesMan_MR] (User_RegId,SalesMR_RegId,LoginId,Entrydate,Active)values('" + companyId + "','" + Regidowner + "','" + ReferencemobileNo + "','" + System.DateTime.Now.ToString() + "',1)";
                                                    status = ExecuteNonQuery(AddAgency);
                                                }
                                            }

                                        }
                                    }

                                }
                                #endregion

                            }

                        }
                        else if (FirmType == "1" || FirmType == "2" || FirmType == "6" || FirmType == "8" || FirmType == "10")
                        {
                            SQL = "Select RegId from [DBeZeeHealth].[dbo].[tblRegistration$] where  MobileNo1='" + ReferencemobileNo + "' ";
                            string companyId = ExecuteScalar(SQL);
                            if (companyId == "")
                            {
                                #region regRefNumber
                                //// regid = regmyct.Addnew(Fname, Lname, MobileNo);
                                regid = regmyct.Addnew("Shree", "Shree", ReferencemobileNo);
                                if (regid != "" || regid == null)
                                {
                                    bllagency.NameFirm_Hospital1 = "Shree";
                                    bllagency.CP_FirstName1 = "shree";
                                    bllagency.CP_LastName1 = "shree";
                                    bllagency.MobileNo_1 = ReferencemobileNo;
                                    bllagency.Email_Id1 = EmailId;

                                    if (FirmType == "1")
                                        bllagency.FirmType1 = "3";
                                    if (FirmType == "2" || FirmType == "8")
                                        bllagency.FirmType1 = "4";
                                    if (FirmType == "6")
                                        bllagency.FirmType1 = "6";
                                    if (FirmType == "10")
                                        bllagency.FirmType1 = "6";
                                    if (FirmType == "0")
                                        bllagency.FirmType1 = "4";

                                    bllagency.State1 = state;
                                    bllagency.district1 = district;
                                    bllagency.Taluka1 = Taluka;
                                    bllagency.Pincode1 = "111111";
                                    bllagency.LoginID1 = Convert.ToString(ReferencemobileNo);  // ref no previous
                                    bllagency.CreateDate1 = CreateDate;  //yyyy-mm-dd
                                    bllagency.Passcode = "111122";
                                    bllagency.MyctPwd = regid;
                                    bllagency.Longitute = Longitute;
                                    bllagency.Latitute1 = Latitute;
                                    bllagency.Usertype = usertype;
                                    bllagency.Address1 = address;
                                    status = bllagency.RegFirm(bllagency);  /// / dal bal
                                }
                                #endregion

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

    }

}
