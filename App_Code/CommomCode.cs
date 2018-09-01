using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Linq;

/// <summary>
/// Summary description for CommonCode
/// </summary>
/// 

public class CommonCode
{
    DataTable dtCategory = new DataTable();
    private static byte[] keys = { };
    private static byte[] IVs = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
    private static string EncryptionKeys = "!5623a#de";

    const string DESKey = "AQWSEDRF";
    const string DESIV = "HGFEDCBA";

    public CommonCode()
    {
        // TODO: Add constructor logic here
        // http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?
    }


    public bool CheckImageExtension(string imageName)
    {
        bool imageOk = false;

        string fileExtension = Path.GetExtension(imageName.ToString()).ToLower();
        string[] allowExtensions = { ".png", ".jpeg", ".jpg", ".gif", ".PNG", ".JPEG", ".JPG", ".GIF" };

        for (int i = 0; i < allowExtensions.Length; i++)
        {
            if (fileExtension == allowExtensions[i])
            {
                imageOk = true;
            }
        }

        return imageOk;
    }

    public bool CheckPDFExtension(string imageName)
    {
        bool imageOk = false;

        string fileExtension = Path.GetExtension(imageName.ToString()).ToLower();
        string[] allowExtensions = { ".pdf", ".png", ".jpeg", ".jpg", ".gif", ".PNG", ".JPEG", ".JPG", ".GIF" };

        for (int i = 0; i < allowExtensions.Length; i++)
        {
            if (fileExtension == allowExtensions[i])
            {
                imageOk = true;
            }
        }

        return imageOk;
    }

    public DataSet ExecuteDataset(string Sql)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;
    }


    public DataSet ExecuteDatasetMYCT(string Sql)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["MyctConnectionString"]))
        {

            try
            {

                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;
    }


    public DataSet ExecuteDataseteZeeSchool(string Sql)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SchoolConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;
    }


    public Boolean InsertUpdateData(SqlCommand cmd)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }


    public DataTable GetData(SqlCommand cmd)
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }
    }

    public DataTable GetData(SqlCommand cmd, string s)
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }
    }

    public DataSet ExecuteDataset(string Sql, string dbName)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;
    }

    public string DTGet_Local(string Date1)
    {
        string Date = "";
        try
        {
            string[] tmp = Date1.Split(' ');

            tmp = tmp[0].Split('-');
            tmp = tmp[0].Split('/');

            Date = tmp[2].ToString() + "/" + tmp[1].ToString() + "/" + tmp[0].ToString() + "";
        }
        catch
        { }
        return Date;
    }

    public string DTGet_LocalNew(string Date1)
    {
        string Date = "";
        try
        {
            if (Date1.Length > 20)
            {
                Date1 = Date1.Substring(0, 10);
            }

            Date1 = Date1.Trim();
            string[] tmp = Date1.Split('-');

            if (tmp.Length == 0)
            {
                tmp = Date1.Split('/');
                if (tmp[0].Length == 1)
                {
                    tmp[0] = "0" + tmp[0];
                }

                Date = tmp[1].ToString() + "/" + tmp[0].ToString() + "/" + tmp[2].ToString() + "";
            }
            else
            {
                Date = tmp[2].ToString() + "/" + tmp[1].ToString() + "/" + tmp[0].ToString() + "";
            }
        }
        catch
        { }
        return Date;
    }

    public string DTInsert_Local(string Date1)//06/21/2012
    {
        string Date = "";
        string time = System.DateTime.Now.ToString();
        string[] tm = time.Split(' ');
        try
        {
            string[] tmp = Date1.Split(' ');

            tmp = tmp[0].Split('/');

            Date = tmp[2].ToString() + "-" + tmp[1].ToString() + "-" + tmp[0].ToString();
        }
        catch
        { }
        return Date;

    }


    public string ExecuteScalar(string Sql)
    {
        string Data = "";
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                Data = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.Text, Sql));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return Data;
    }

    public string ExecuteScalarCt1(string Sql)
    {
        string Data = "";
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["MyctConnectionString"]))
        {
            try
            {
                Data = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.Text, Sql));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return Data;
    }

    public string ExecuteScalar1(string Sql, string db)
    {
        string Data = "";
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                Data = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.Text, Sql));

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return Data;
    }

    public int ExecuteScalar_all(string Sql)
    {
        int Data = 0;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                Data = Convert.ToInt32(SqlHelper.ExecuteScalar(con, CommandType.Text, Sql));

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return Data;
    }
    public int ExecuteScalar_all1(string Sql, string db)
    {
        int Data = 0;

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                Data = Convert.ToInt32(SqlHelper.ExecuteScalar(con, CommandType.Text, Sql));

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return Data;
    }

    public string ExecuteScalar(string Sql, string DbName)
    {
        string Data = "";
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                Data = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.Text, Sql));

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return Data;
    }


    public int ExecuteNonQuery(string Sql)
    {
        int flag = 0;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                flag = SqlHelper.ExecuteNonQuery(con, CommandType.Text, Sql);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return flag;
    }

    public int ExecuteNonQuery1(string Sql)
    {
        int flag = 0;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["MyctConnectionString"]))
        {

            try
            {

                flag = SqlHelper.ExecuteNonQuery(con, CommandType.Text, Sql);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return flag;
    }

    public string DESEncrypt_CT(string stringToEncrypt)// Encrypt the content
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
    public string DESDecrypt(string stringToDecrypt)//Decrypt the content
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

    /// <summary>
    /// Encrypt the normal string with the DES to Encrypted string 
    /// </summary>
    /// <param name="stringToEncrypt">Normal String  to Encrypt</param>
    /// <returns></returns>
    /// 

    public string DESEncrypt(string stringToEncrypt)// Encrypt the content
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

    static byte[] Convert2ByteArray(string strInput)
    {

        int intCounter; char[] arrChar;
        arrChar = strInput.ToCharArray();

        byte[] arrByte = new byte[arrChar.Length];

        for (intCounter = 0; intCounter <= arrByte.Length - 1; intCounter++)
            arrByte[intCounter] = Convert.ToByte(arrChar[intCounter]);

        return arrByte;
    }

    public string ChangeDate(string dt)
    {
        string[] tmpdt;

        string dt1 = "0";
        try
        {
            tmpdt = dt.Split('/');
            if (tmpdt[0].Length == 1)
                tmpdt[0] = "0" + tmpdt[0];
            if (tmpdt[1].Length == 1)
                tmpdt[1] = "0" + tmpdt[1];

            dt1 = tmpdt[1] + "/" + tmpdt[0] + "/" + tmpdt[2];

        }
        catch (Exception ex)
        {
            string msg = ex.Message;


        }
        return dt1;
    }


    public string AdvMessage()
    {

        string advMsg = "Ad: Join 'All India Mobile Directory Users Association' on come2mycity.com";
        return advMsg;
    }


    public DataSet getLoginDetails(string LoginId, string Password)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];

                par[0] = new SqlParameter("@LoginId", LoginId);
                par[1] = new SqlParameter("@Password", Password);
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Authenticate", par);

            }
            catch
            {
                ds = null;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;
    }


    public DataSet LoadMonthYear()
    {
        DataTable dt = new DataTable();
        DataColumn dc = new DataColumn("intMonth");
        dt.Columns.Add(dc);
        dc = new DataColumn("strMonth");
        dt.Columns.Add(dc);

        DataRow dr = dt.NewRow();

        dr["intMonth"] = "1";
        dr["strMonth"] = "January";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "2";
        dr["strMonth"] = "February";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "3";
        dr["strMonth"] = "March";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "4";
        dr["strMonth"] = "April";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "5";
        dr["strMonth"] = "May";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "6";
        dr["strMonth"] = "June";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "7";
        dr["strMonth"] = "July";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "8";
        dr["strMonth"] = "August";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "9";
        dr["strMonth"] = "September";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "10";
        dr["strMonth"] = "October";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "11";
        dr["strMonth"] = "November";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "12";
        dr["strMonth"] = "December";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "";
        dr["strMonth"] = "--Select--";
        dt.Rows.Add(dr);

        DataSet ds = new DataSet();
        ds.Tables.Add(dt);

        dt = new DataTable();
        dc = new DataColumn("intYear");
        dt.Columns.Add(dc);
        dc = new DataColumn("strYear");
        dt.Columns.Add(dc);

        int Year = System.DateTime.Now.Year;

        for (int i = Year - 5; i <= Year + 5; i++)
        {
            dr = dt.NewRow();
            dr["intYear"] = i.ToString();
            dr["strYear"] = i.ToString();
            dt.Rows.Add(dr);
        }
        dr = dt.NewRow();
        dr["intYear"] = "";
        dr["strYear"] = "--Select--";
        dt.Rows.Add(dr);
        ds.Tables.Add(dt);
        return ds;
    }

    public void AddControls(ControlCollection page, ArrayList controlList, string language)
    {
    }

    public void AddCon(ControlCollection page, ArrayList controlList, string language)
    {
        if (language != null)
        {
            foreach (Control c in page)
            {
                Type tp = c.GetType();
                if (c.ID != null)
                {

                    if (tp.Name.ToUpper().ToString() == "TEXTBOX")
                    {
                        TextBox TXT = (TextBox)c;
                        if (TXT.Text != null)
                        {
                            TXT.Font.Name = language;
                            // TXT.Font.Size = 12;
                        }

                    }

                    else if ((tp.Name.ToUpper().ToString() == "DROPDOWNLIST"))
                    {
                        DropDownList ddl = (DropDownList)c;
                        if (ddl.Text != null)
                        {
                            ddl.Font.Name = language;
                            // ddl.Font.Size = 12;
                        }


                    }
                    else if ((tp.Name.ToUpper().ToString() == "GRIDVIEW"))
                    {
                        GridView gv = (GridView)c;

                        if (gv.SelectedIndex != null)
                        {
                            gv.Font.Name = language;
                            //gv.Font.Size =12;
                        }


                    }
                }

                if (c.HasControls())
                {
                    AddCon(c.Controls, controlList, language);
                }
            }
        }

    }

    // ******************** Add new Changes Related Hostel************10_Nov_2012
    public void FillDDL(string sql, DropDownList ddl, string table)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                con.Open();

                DataSet dsDesign = new DataSet();
                SqlDataAdapter adDesign = new SqlDataAdapter(sql, con);
                adDesign.Fill(dsDesign, table);
                ddl.DataSource = dsDesign.Tables[0];
                if (dsDesign.Tables[0].Rows.Count > 0)
                {
                    //ddl.DataTextField = "Name";
                    ddl.DataValueField = "Id";

                }
                ddl.DataBind();
                ddl.Items.Add("Add New");
                ddl.Items.Add("--Select--");
                ddl.SelectedIndex = ddl.Items.Count - 1;
                ddl.Items[ddl.Items.Count - 1].Value = "";
                dsDesign.Clear();
                adDesign.Dispose();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }

    public void FillDDL1(string sql, DropDownList ddl, string table)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))

            try
            {
                con.Open();

                DataSet dsDesign = new DataSet();
                SqlDataAdapter adDesign = new SqlDataAdapter(sql, con);
                adDesign.Fill(dsDesign, table);
                ddl.DataSource = dsDesign.Tables[0];
                if (dsDesign.Tables[0].Rows.Count > 0)
                {
                    ddl.DataTextField = "Name";
                    ddl.DataValueField = "Id";

                }
                ddl.DataBind();
                ddl.Items.Add("--Select--");
                ddl.SelectedIndex = ddl.Items.Count - 1;
                ddl.Items[ddl.Items.Count - 1].Value = "";
                dsDesign.Clear();
                adDesign.Dispose();



            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            finally
            {

                con.Close();
            }


    }
    public void FillDDL3(string sql, DropDownList ddl, string table)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))

            try
            {
                con.Open();

                DataSet dsDesign = new DataSet();
                SqlDataAdapter adDesign = new SqlDataAdapter(sql, con);
                adDesign.Fill(dsDesign, table);
                ddl.DataSource = dsDesign.Tables[0];
                if (dsDesign.Tables[0].Rows.Count > 0)
                {
                    ddl.DataTextField = "Name";
                    ddl.DataValueField = "Id";

                }
                ddl.DataBind();
                ddl.Items.Add("ALL");
                ddl.SelectedIndex = ddl.Items.Count - 1;
                ddl.Items[ddl.Items.Count - 1].Value = "ALL";
                ddl.Items.Add("--Select--");
                ddl.SelectedIndex = ddl.Items.Count - 1;
                ddl.Items[ddl.Items.Count - 1].Value = "";
                dsDesign.Clear();
                adDesign.Dispose();



            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            finally
            {

                con.Close();
            }
    }


    public bool TransactionalSMSCountry(string sendFrom, string sendTo, string fwdMessage)
    {
        bool flagMsgSuccess = false;
        string senderid = string.Empty;
        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            string NewSento = sendto.Substring(sendto.Length - 10);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            senderid = "myctin";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            fwdMessage += " www.myct.in";
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + NewSento + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            // string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&mtype=N&DR=Y";
            //string url = "http://www.smscountry.com/SMSCwebservice.aspx?";
            string url = "http://api.smscountry.com/SMSCwebservice_bulk.aspx?";

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
            //string sql = "insert into [Come2myCityDB].[come2mycity].[sendSMSstatus](SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "'," + 107 + ",'" + 10 + "','" + dt + "')";
            //int d = ExecuteNonQuery(sql);
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

    //---Give Max Id ----------

    public int maxIDMain(string table, string field)
    {
        int id = 0;

        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            try
            {
                con.Open();
                SqlDataReader dr;
                SqlCommand cmd;

                cmd = new SqlCommand("select distinct(" + field + ") from " + table + " order by " + field + " desc", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    id = System.Convert.ToInt32(dr[0]);
                }

                else
                {
                    id = 1;
                }

            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            finally
            {
                con.Close();


            }
        return id;

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
            int d = ExecuteNonQuery1(sql);
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

    public static string connectionStringmyct = "server=www.come2mycity.com;User Id=ezeesoftschooluser; Password=ezeeschool!@12;Min Pool Size=20; Max Pool Size=200;";

    internal DataSet ExecuteDataset12(string sql3)
    {

        DataSet ds = new DataSet();
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["MyctConnectionString"]);
        SqlCommand sqlCommand = new SqlCommand();
        try
        {
            sqlCommand.CommandText = sql3;
            sqlCommand.Connection = sqlConnection;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(ds);
        }
        catch
        { }
        finally { sqlCommand.Dispose(); sqlCommand.Connection.Close(); }
        return ds;
    }

    public string AddSMS(string usrMoNo)
    {
        string str = "";
        string SqlAdd = "select SP.Id as ID,SP.Msg as sms, SP.Sent as sentsms from SMSPushingCity SPC Inner Join UserMaster UM on SPC.CityId=UM.usrCityId Inner Join SMSPushing SP on SP.Id=SPC.SmsPushingId where usrMobileNo='" + usrMoNo.ToString() + "' and SP.TotalMsg > SP.Sent and CONVERT(DATETIME ,SP.StartDate)<= SYSDATETIME() and not CONVERT(DATETIME ,SP.StartDate)>= GETDATE()+SP.Days";
        DataSet ds = ExecuteDataset12(SqlAdd);
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
            string SqlUpdate = "Update SMSPushing set Sent=" + (sendSms + 1).ToString() + " where Id=" + id.ToString() + "";
            int ff = ExecuteNonQuery1(SqlUpdate);
        }
        return str;
    }

    private string aid = "639250"; //NEWLY ADDED BY JITENDRA DATED ON 05.11.2016
    private string pin = "M@h123";
    private WebProxy objProxy1 = null;
    public string SMS(string Mobile_Number, string Message)
    {


        Mobile_Number = "91" + Mobile_Number;
        //System.Object stringpost = "aid=" + aid + "&pin=" + pin + "&mnumber=" + Mobile_Number + "&message=" + Message + "&signature=MAHSEC";
        System.Object stringpost = "aid=" + aid + "&pin=" + pin + "&mnumber=" + Mobile_Number + "&message=" + Message + "&signature=MAHSEC";

        HttpWebRequest objWebRequest = null;
        HttpWebResponse objWebResponse = null;
        StreamWriter objStreamWriter = null;
        StreamReader objStreamReader = null;

        try
        {
            string stringResult = null;
            //objWebRequest = (HttpWebRequest)WebRequest.Create(" http://otp.zone:7501/failsafe/HttpLink?aid=639128&pin=M@h123&mnumber=91XXXXXXXXXX&message=test&signature=MAHSEC");
            //objWebRequest = (HttpWebRequest)WebRequest.Create("  http://otp.zone:7501/failsafe/HttpLink?aid=639250&pin=M@h123&mnumber=91XXXXXXXXXX&message=test&signature=MGAGEX");

            objWebRequest = (HttpWebRequest)WebRequest.Create("http://otp.zone:7501/failsafe/HttpLink?");
            objWebRequest.Method = "POST";

            if ((objProxy1 != null))
            {
                objWebRequest.Proxy = objProxy1;
            }

            objWebRequest.ContentType = "application/x-www-form-urlencoded";
            objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
            objStreamWriter.Write(stringpost);
            objStreamWriter.Flush();
            objStreamWriter.Close();
            objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
            objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
            stringResult = objStreamReader.ReadToEnd();
            objStreamReader.Close();
            return (stringResult);
        }
        catch (Exception ex)
        {
            return (ex.Message);
        }
        finally
        {

            if ((objStreamWriter != null))
            {
                objStreamWriter.Close();
            }
            if ((objStreamReader != null))
            {
                objStreamReader.Close();
            }
            objWebRequest = null;
            objWebResponse = null;
            objProxy1 = null;
        }
    }



}

