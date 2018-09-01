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
  
    class CommonCode
    {
        public static string connectionString = "server=www.come2mycity.com;User Id=ezeesoftschooluser; Password=ezeeschool!@12;Min Pool Size=20; Max Pool Size=200;";

        private static byte[] keys = { };
        private static byte[] IVs = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static string EncryptionKeys = "!5623a#de";
        const string DESKey = "AQWSEDRF";
        const string DESIV = "HGFEDCBA";

        private SqlConnection sqlConnection = new SqlConnection(connectionString);
        public string ErrorMessage;
        public int errorNumber;
        public string stackTrace, sqlQuery;
        private SqlCommand sqlCommand = new SqlCommand();
        public DataSet UserDataset { get; set; }
        private string CurrenctDate = "", UpperKeword = "";
        private string DateFormat = "";
        





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
        internal string ExecuteScalar(string sql2)
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

        internal DataSet ExecuteDataset(string sql3)
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

        internal int ExecuteNonQuery(string sql)
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
        public bool SendMessageLongCodeSMS(string sendFrom, string sendTo, string fwdMessage, int smslength)
        {
            bool flagMsgSuccess = false;
            try
            {
                fwdMessage = fwdMessage.Replace("&", "and");
                string sendto = Convert.ToString(sendTo);
                fwdMessage = fwdMessage.Replace("sssss", "'");
                fwdMessage = fwdMessage.Replace("aaaaa", "&");
                string senderid = "myctin";
                string userid = "ezeesoft";
                string password = "67893";
                fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
                string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendTo + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
                string url = "http://api.smscountry.com/SMSCwebservice_bulk.aspx?";
                string result = "";
                StreamWriter myWriter = null;
                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
                objRequest.Method = "POST";
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

                fwdMessage = fwdMessage.Replace("'", "sssss");
                fwdMessage = fwdMessage.Replace("&", "aaaaa");
                fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
                string sql = "insert into sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',23,'" + smslength + "','" + System.DateTime.Now + "')";
                int d = ExecuteNonQuery(sql);
                string resultMsg = result;
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
        internal string AddSMS(string usrMoNo)
        {
            string str = "";
            string SqlAdd = "select SP.Id as ID,SP.Msg as sms, SP.Sent as sentsms from [Come2myCityDB].[dbo].[SMSPushingCity] SPC Inner Join [Come2myCityDB].[dbo].[UserMaster] UM on SPC.CityId=UM.usrCityId Inner Join [Come2myCityDB].[dbo].[SMSPushing] SP on SP.Id=SPC.SmsPushingId where usrMobileNo='" + usrMoNo.ToString() + "' and SP.TotalMsg > SP.Sent and CONVERT(DATETIME ,SP.StartDate)<= SYSDATETIME() and not CONVERT(DATETIME ,SP.StartDate)>= GETDATE()+SP.Days";
            DataSet ds = ExecuteDataset(SqlAdd);
            string sms = "";
            int id = 0, sendSms = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                id = Convert.ToInt32(dr["ID"]);
                sms = Convert.ToString(dr["sms"]);
                sendSms = Convert.ToInt32(dr["sentsms"]);
            }
            if (sms == "")
            {
                str = " www.myct.in";
            }
            else
            {
                str = "Ad: " + sms.ToString();
                string SqlUpdate = "Update [Come2myCityDB].[dbo].[SMSPushing] set Sent=" + (sendSms + 1).ToString() + " where Id=" + id.ToString() + "";
                int ff = ExecuteNonQuery(SqlUpdate);
            }


            return str;
        }
    }
}
