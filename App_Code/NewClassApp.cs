using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.Xml.Linq;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Web.Script.Services;
using Newtonsoft.Json;
using System.Text;

/// <summary>
/// Summary description for NewClassApp
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class NewClassApp : System.Web.Services.WebService
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    SqlCommand cmd = new SqlCommand();
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    string[] RegiPayKeyword = new string[] { "Registration", "Analysis&Provision", "VisionMission", "PastWorkDone" };
    string sql = string.Empty;
    StringBuilder sb = new StringBuilder();

    public NewClassApp()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(Description = "Share to data on parent mobile no like that DaySpecial,Long_Form,Phases_Idioms,Good_Thoughts")]
    public int ShareComman(string studMobNo, string keyword, string uniqueid, string batch, string classid, string createdby) //string ownerMobNo,string RefMobNo
    {
        int res = 0; int count = 0;
        string sql = string.Empty;
        try
        {
            string[] studNumber = studMobNo.Split('|');

            var temp = new List<string>();
            foreach (var s in studNumber)
            {
                if (!string.IsNullOrEmpty(s))
                    temp.Add(s);
            }
            studNumber = temp.ToArray();

            for (int i = 0; i < studNumber.Length; i++)
            {
                string SqlQury = "Select [ShareWId] from [tblShareWords] where [StudentMobNo]='" + studNumber[i] + "' and [UniqueId]='" + uniqueid + "' and [KeyWord]='" + keyword + "' ";
                DataSet dtset = cc.ExecuteDataset(SqlQury);
                if (dtset.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    if (keyword == "DaySpecial")
                    {
                        sql = "insert into [tblShareWords]([StudentMobNo],[UniqueId],[ClassId],[Batch],[CreatedBy],[CreatedDate],[KeyWord])" +
                              "Values('" + studNumber[i] + "','" + uniqueid + "','" + classid + "','" + batch + "','" + createdby + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + keyword + "')";
                        res = cc.ExecuteNonQuery(sql);
                    }
                    else if (keyword == "LongForm")
                    {
                        sql = "insert into [tblShareWords]([StudentMobNo],[UniqueId],[ClassId],[Batch],[CreatedBy],[CreatedDate],[KeyWord])" +
                             "Values('" + studNumber[i] + "','" + uniqueid + "','" + classid + "','" + batch + "','" + createdby + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + keyword + "')";
                        res = cc.ExecuteNonQuery(sql);
                    }
                    else if (keyword == "phasesIdioms")
                    {
                        sql = "insert into [tblShareWords]([StudentMobNo],[UniqueId],[ClassId],[Batch],[CreatedBy],[CreatedDate],[KeyWord])" +
                              "Values('" + studNumber[i] + "','" + uniqueid + "','" + classid + "','" + batch + "','" + createdby + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + keyword + "')";
                        res = cc.ExecuteNonQuery(sql);
                    }
                    else if (keyword == "GoodThoughts")
                    {
                        sql = "insert into [tblShareWords]([StudentMobNo],[UniqueId],[ClassId],[Batch],[CreatedBy],[CreatedDate],[KeyWord])" +
                              "Values('" + studNumber[i] + "','" + uniqueid + "','" + classid + "','" + batch + "','" + createdby + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + keyword + "')";
                        res = cc.ExecuteNonQuery(sql);
                    }
                    else if (keyword == "Video")
                    {
                        sql = sql = "insert into [tblShareWords]([StudentMobNo],[UniqueId],[ClassId],[Batch],[CreatedBy],[CreatedDate],[KeyWord])" +
                              "Values('" + studNumber[i] + "','" + uniqueid + "','" + classid + "','" + batch + "','" + createdby + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + keyword + "')";
                        res = cc.ExecuteNonQuery(sql);
                    }
                    count++;
                }
            }

        }
        catch
        {
            return 0;
        }
        return count;
    }

    #region METHOD TO DOWNLOAD DATA TO PARENT MOBILE NO FOR DAY_SPECIAL,LONG_FORM,PHASES_IDIOMS,GOOD_THOUGHTS

    [WebMethod(Description = "Download To Parent Mobile No for DaySpecial ")]
    public string DownloadTo_DaySpecialParentData(string parentNumber, string Keyword)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        string returnstring = string.Empty;
        DataSet dataset = new DataSet();
        DataTable dt = new DataTable();
        string uniqueId = string.Empty;

        try
        {
            string sqlQuery = "SELECT DISTINCT [UniqueId] FROM [tblShareWords] WHERE [StudentMobNo]='" + parentNumber + "' and [KeyWord]='" + Keyword + "'";
            dataset = cc.ExecuteDataset(sqlQuery);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
                {
                    uniqueId = uniqueId + "," + dataset.Tables[0].Rows[i][0].ToString();
                }
                uniqueId = uniqueId.Substring(1);

                string sqlQuery1 = "Select [date],[CategoryName],[DaySpecial],[Language],[ClassId],[SubjectId],[ChapterId],[TopicId],[CreatedBy] from [tblDaySpecial] where [UniqueId] IN ('" + uniqueId + "')";
                DataSet ds = cc.ExecuteDataset(sqlQuery1);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //xmldoc = new XmlDataDocument(ds);
                    //XmlElement xmlelement = xmldoc.DocumentElement;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        returnstring += ds.Tables[0].Rows[i][0].ToString() + "*" + ds.Tables[0].Rows[i][1].ToString() + "*" + ds.Tables[0].Rows[i][2].ToString() + "*" + ds.Tables[0].Rows[i][3].ToString() + "*" + ds.Tables[0].Rows[i][4].ToString()
                                         + "*" + ds.Tables[0].Rows[i][5].ToString() + "*" + ds.Tables[0].Rows[i][6].ToString() + "*" + ds.Tables[0].Rows[i][7].ToString() + "*" + ds.Tables[0].Rows[i][8].ToString();
                    }
                }
                else
                {
                    //dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                    //DataRow dr = dt.NewRow();
                    //dr["NoRecord"] = "106";
                    //dt.Rows.Add(dr);
                    //ds.Tables.Add(dt);
                    //xmldoc = new XmlDataDocument(ds);
                    //XmlElement xmlelement = xmldoc.DocumentElement;
                    returnstring = "106";
                }
            }
        }
        catch
        {
            //dt.Columns.Add(new DataColumn("Error", typeof(int)));
            //DataRow dr = dt.NewRow();
            //dr["Error"] = "105";
            //dt.Rows.Add(dr);
            //ds.Tables.Add(dt);
            //xmldoc = new XmlDataDocument(ds);
            //XmlElement xmlelement = xmldoc.DocumentElement;
            returnstring = "105";
        }
        return returnstring;
    }

    [WebMethod(Description = "Download To Parent Mobile No for Long_Form ")]
    public string DownloadTo_LongFormParentData(string parentNumber, string Keyword)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        string returnstring = string.Empty;
        DataSet dataset = new DataSet();
        DataTable dt = new DataTable();
        string uniqueId = string.Empty;

        try
        {
            string sqlQuery = "SELECT DISTINCT [UniqueId] FROM [tblShareWords] WHERE [StudentMobNo]='" + parentNumber + "' and [KeyWord]='" + Keyword + "'";
            dataset = cc.ExecuteDataset(sqlQuery);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
                {
                    uniqueId = uniqueId + "," + dataset.Tables[0].Rows[i][0].ToString();
                }
                uniqueId = uniqueId.Substring(1);

                string sqlQuery1 = "SELECT [Word],[CategoryName],[LomgForm],[ClassId],[SubjectId],[ChapterId],[TopicId],[CreatedBy] FROM [tblLongForm] WHERE [UniqueId] IN ('" + uniqueId + "')";
                DataSet ds = cc.ExecuteDataset(sqlQuery1);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //xmldoc = new XmlDataDocument(ds);
                    //XmlElement xmlelement = xmldoc.DocumentElement;

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        returnstring += ds.Tables[0].Rows[i][0].ToString() + "*" + ds.Tables[0].Rows[i][1].ToString() + "*" + ds.Tables[0].Rows[i][2].ToString() + "*" + ds.Tables[0].Rows[i][3].ToString() + "*" + ds.Tables[0].Rows[i][4].ToString()
                                         + "*" + ds.Tables[0].Rows[i][5].ToString() + "*" + ds.Tables[0].Rows[i][6].ToString() + "*" + ds.Tables[0].Rows[i][7].ToString();
                    }
                }
                else
                {
                    //dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                    //DataRow dr = dt.NewRow();
                    //dr["NoRecord"] = "106";
                    //dt.Rows.Add(dr);
                    //ds.Tables.Add(dt);
                    //xmldoc = new XmlDataDocument(ds);
                    //XmlElement xmlelement = xmldoc.DocumentElement;
                    returnstring = "106";
                }
            }
        }
        catch
        {
            //dt.Columns.Add(new DataColumn("Error", typeof(int)));
            //DataRow dr = dt.NewRow();
            //dr["Error"] = "105";
            //dt.Rows.Add(dr);
            //ds.Tables.Add(dt);
            //xmldoc = new XmlDataDocument(ds);
            //XmlElement xmlelement = xmldoc.DocumentElement;
            returnstring = "106";
        }
        return returnstring;
    }

    [WebMethod(Description = "Download To Parent Mobile No for Phases_Idioms")]
    public string DownloadTo_PhasesIdiomsParentData(string parentNumber, string Keyword)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        string returnstring = string.Empty;
        DataSet dataset = new DataSet();
        DataTable dt = new DataTable();
        string uniqueId = string.Empty;

        try
        {
            string sqlQuery = "SELECT DISTINCT [UniqueId] FROM [tblShareWords] WHERE [StudentMobNo]='" + parentNumber + "' and [KeyWord]='" + Keyword + "'";
            dataset = cc.ExecuteDataset(sqlQuery);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
                {
                    uniqueId = uniqueId + "," + dataset.Tables[0].Rows[i][0].ToString();
                }
                uniqueId = uniqueId.Substring(1);

                string sqlQuery1 = "Select [ClassId],[SubjectId],[ChapterId],[TopicId],[CreatedBy] from [tblPhases_Idioms] where [UniqueId] IN ('" + uniqueId + "')";
                DataSet ds = cc.ExecuteDataset(sqlQuery1);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //xmldoc = new XmlDataDocument(ds);
                    //XmlElement xmlelement = xmldoc.DocumentElement;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        returnstring += ds.Tables[0].Rows[i][0].ToString() + "*" + ds.Tables[0].Rows[i][1].ToString() + "*" + ds.Tables[0].Rows[i][2].ToString() + "*" + ds.Tables[0].Rows[i][3].ToString() + "*" + ds.Tables[0].Rows[i][4].ToString();

                    }
                }
                else
                {
                    //dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                    //DataRow dr = dt.NewRow();
                    //dr["NoRecord"] = "106";
                    //dt.Rows.Add(dr);
                    //ds.Tables.Add(dt);
                    //xmldoc = new XmlDataDocument(ds);
                    //XmlElement xmlelement = xmldoc.DocumentElement;

                    returnstring = "106";
                }
            }
        }
        catch
        {
            //dt.Columns.Add(new DataColumn("Error", typeof(int)));
            //DataRow dr = dt.NewRow();
            //dr["Error"] = "105";
            //dt.Rows.Add(dr);
            //ds.Tables.Add(dt);
            //xmldoc = new XmlDataDocument(ds);
            //XmlElement xmlelement = xmldoc.DocumentElement;
            returnstring = "105";
        }
        return returnstring;
    }

    [WebMethod(Description = "Download To Parent Mobile No for Good_Thoughts ")]
    public string DownloadTo_GoodThoughtsParentData(string parentNumber, string Keyword)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        string returnstring = string.Empty;
        DataSet dataset = new DataSet();
        DataTable dt = new DataTable();
        string uniqueId = string.Empty;

        try
        {
            string sqlQuery = "SELECT DISTINCT [UniqueId] FROM [tblShareWords] WHERE [StudentMobNo]='" + parentNumber + "' and [KeyWord]='" + Keyword + "'";
            dataset = cc.ExecuteDataset(sqlQuery);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
                {
                    uniqueId = uniqueId + "," + dataset.Tables[0].Rows[i][0].ToString();
                }
                uniqueId = uniqueId.Substring(1);

                string sqlQuery1 = "Select [ClassId],[SubjectId],[ChapterId],[TopicId],[CreatedBy] from [tblGoodThoughts] where [UniqueId] IN ('" + uniqueId + "')";
                DataSet ds = cc.ExecuteDataset(sqlQuery1);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //xmldoc = new XmlDataDocument(ds);
                    //XmlElement xmlelement = xmldoc.DocumentElement;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        returnstring += ds.Tables[0].Rows[i][0].ToString() + "*" + ds.Tables[0].Rows[i][1].ToString() + "*" + ds.Tables[0].Rows[i][2].ToString() + "*" + ds.Tables[0].Rows[i][3].ToString() + "*" + ds.Tables[0].Rows[i][4].ToString();

                    }
                }
                else
                {
                    //dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                    //DataRow dr = dt.NewRow();
                    //dr["NoRecord"] = "106";
                    //dt.Rows.Add(dr);
                    //ds.Tables.Add(dt);
                    //xmldoc = new XmlDataDocument(ds);
                    //XmlElement xmlelement = xmldoc.DocumentElement;

                    returnstring = "106";
                }
            }
        }
        catch
        {
            //dt.Columns.Add(new DataColumn("Error", typeof(int)));
            //DataRow dr = dt.NewRow();
            //dr["Error"] = "105";
            //dt.Rows.Add(dr);
            //ds.Tables.Add(dt);
            //xmldoc = new XmlDataDocument(ds);
            //XmlElement xmlelement = xmldoc.DocumentElement;

            returnstring = "105";
        }
        return returnstring;
    }

    #endregion

    #region METHOD TO UPLOAD VIDEO LINK
    [WebMethod(Description = "Upload video data")]
    public string UploadVideos(string ClassId, string SubjectId, string ChapterId, string TopicId, string VideoTitle, string VideoLink, string CreatedBy, string ReferenceMoNo, string Imei)
    {
        string SqlQry = string.Empty; string ServerId = string.Empty;
        int res = 0;
        int Uid = 0;
        try
        {
            string sqlqry = "select [UniqueId] from [tblClassVideo] where [ClassId]='" + ClassId + "' and [SubjectId]='" + SubjectId + "' and [ChapterId]='" + ChapterId + "' and [TopicId]='" + TopicId + "'";
            string id = Convert.ToString(cc.ExecuteScalar(sqlqry));
            if (id == "NULL" || id == "")
            {
                SqlQry = "select max(UniqueId)+1 from [tblClassVideo]";
                Uid = Convert.ToInt32(cc.ExecuteScalar(SqlQry));
            }
            else
            {
                Uid = Convert.ToInt32(id);
            }

            SqlQry = "Insert into tblClassVideo([ClassId],[SubjectId],[ChapterId],[TopicId],[VideoTitle],[VideoLink],[ReferenceMoNo],[CreatedBy],[CreatedDate],[Imei],[UniqueId]) values(" +
                      ClassId + "," + SubjectId + "," + ChapterId + "," + TopicId + ",'" + VideoTitle + "',N'" + VideoLink + "','" + ReferenceMoNo + "','" +
                       CreatedBy + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + Imei + "'," + Uid + ")";
            res = cc.ExecuteNonQuery(SqlQry);
            string sql = "Select Max(Id) From tblClassVideo";
            ServerId = cc.ExecuteScalar(sql);
            return ServerId;
        }
        catch
        {
            return "0";
        }

    }

    [WebMethod(Description = "Download To Parent Mobile No for Video")]
    public XmlDataDocument DownloadVideo(string ClassId, string SubjectId, string ChapterId, string TopicId)
    {
        XmlDataDocument ObjXmlData = new XmlDataDocument();
        string SqlQuery = string.Empty;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        //string SqlQry = string.Empty; string ServerId = string.Empty;
        //int res = 0;
        //int Uid = 0;
        try
        {
            SqlQuery = "Select [Id],[ClassId],[SubjectId],[ChapterId],[TopicId],[VideoTitle],[VideoLink],[ReferenceMoNo],[CreatedBy],[UniqueId] From [tblClassVideo] where ClassId=" +
                ClassId + "And SubjectId=" + SubjectId + "And ChapterId=" + ChapterId + "And TopicId=" + TopicId + "";
            ds = cc.ExecuteDataset(SqlQuery);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ObjXmlData = new XmlDataDocument(ds);
                XmlElement ObjXmlElement = ObjXmlData.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("No Records", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["No Record"] = "106";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                ObjXmlData = new XmlDataDocument(ds);
                XmlElement ObjXmlElements = ObjXmlData.DocumentElement;
            }
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
            ObjXmlData = new XmlDataDocument(ds);
            XmlElement ObjXmlElementt = ObjXmlData.DocumentElement;
        }
        return ObjXmlData;
    }
    #endregion

    [WebMethod]
    public string InsertRegRecord()
    {
        CommonCode cc = new CommonCode();
        SqlConnection seccon = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionStringLocal"].ConnectionString);
        SqlCommand cmd = new SqlCommand(); string Sql = string.Empty;
        string jsonDataStrngReturn = string.Empty;
        DataSet ds1 = new DataSet();
        try
        {
            //Sql = "select [LBID],[Id],[FirstName],[MiddleName],[LastName],[MobNo],[EDivisionID],[EDivisionName],[ECollegeID],[ECollegeName],[UserName] FROM  [RegistrationDtls] " +
            //       "WHERE Id = '" + MaxId + "'";
            //da = new SqlDataAdapter(Sql, seccon);
            //da.Fill(ds);

            //Sql = "select [FirstName],[MiddleName],[LastName],[MobNo] FROM  [TrueVoterDB].[dbo].[tblregsDtls]"; //where Id > '94915'";
            Sql = "select [UsrMobNo] FROM  [Test].[dbo].[tblMsgSend] where ID > 16000";
            //Sql = "select [FirstName],[MiddleName],[LastName],[CandidateMob] FROM [TrueVoterDB].[dbo].[tblNominationMpAndZp]  ";// where Id > '114394'";
            SqlDataAdapter da = new SqlDataAdapter(Sql, seccon);
            da.Fill(ds);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string sql = string.Empty;
                #region Comment
                //Sql = "Select [LBDistrictID] from [LB_District] where [LBID]='" + ds.Tables[0].Rows[i]["LBID"].ToString() + "'";
                //cmd = new SqlCommand(Sql, seccon);
                //seccon.Open();
                //string districtId = cmd.ExecuteScalar().ToString();

                //cmd = new SqlCommand("Select [Districtname] from [mstDistrict] where [Districtcode]='" + districtId + "'", seccon);
                //seccon.Open();
                //string Districtname = cmd.ExecuteScalar().ToString();

                //cmd = new SqlCommand("Select [LBName] from [LB_LocalBody] where [LBID]='" + ds.Tables[0].Rows[i]["LBID"].ToString() + "'", seccon);
                //seccon.Open();
                //string Localbodyname = cmd.ExecuteScalar().ToString();

                //Sql = "Select [SubDistrictcode],[SubDistrictname] from [SEC].[dbo].[mstTaluka] where [DistrictCode]='" + districtId + "'";
                //da = new SqlDataAdapter(Sql, seccon);
                //da.Fill(ds1);

                //sql = "Insert into [tblRegistrationSEC]([RegIDSEC],[FirstName],[MiddleName],[LastName],[RegMobileNo],[DistrictId],[DistrictName],[TalukaId],[TalukaName],[ElectrolId] " +
                //     ",[ElectrolName],[ElectrolClgId],[ElectrolClgName],[PartyName],[SymbolName],[ElectionName],[LocalBodyName]) values('" + ds.Tables[0].Rows[i]["Id"].ToString() + "','" + ds.Tables[0].Rows[i]["FirstName"].ToString() + "' " +
                //     ",'" + ds.Tables[0].Rows[i]["MiddleName"].ToString() + "','" + ds.Tables[0].Rows[i]["LastName"].ToString() + "','" + ds.Tables[0].Rows[i]["MobNo"].ToString() + "'," +
                //     ",'" + districtId + "','" + Districtname + "','" + ds1.Tables[0].Rows[i]["SubDistrictcode"].ToString() + "','" + ds1.Tables[0].Rows[i]["SubDistrictname"].ToString() + "' " +
                //    ",'" + ds.Tables[0].Rows[i]["EDivisionID"].ToString() + "','" + ds.Tables[0].Rows[i]["EDivisionName"].ToString() + "','" + ds.Tables[0].Rows[i]["ECollegeID"].ToString() + "','" + ds.Tables[0].Rows[i]["ECollegeName"].ToString() + "' " +
                //  ",'" + ds.Tables[0].Rows[i]["UserName"].ToString() + "','" + Localbodyname + "')";
                //cmd = new SqlCommand(sql, con);
                //con.Open();
                //cmd.ExecuteNonQuery();
                //con.Close();

                //string Msg = "SEC Welcomes " + Convert.ToString(ds.Tables[0].Rows[i]["FirstName"]) + " "+"" + Convert.ToString(ds.Tables[0].Rows[i]["MiddleName"]) + " "+"" + Convert.ToString(ds.Tables[0].Rows[i]["LastName"]) + ".  Congratulations for filing online nomination form successfully! In this election daily election expenses are to be filled online through True Voter Mobile Application. Download True Voter app on your android mobile from the link or Play Store and register it using Mobile Number used in Nomination form. goo.gl/YN7qn1";

                //  string Msg = "Dear Candidate use True Voter app with ur Registered mob no for filling Daily Expenses & Getting voter list of ur Ward/ZP/PS area in ur mobile with voter Analysis facility";
                #endregion
                //string Msg = "Dear Voter, TRUE VOTER app gives facility to Know Your Candidate (Profile of Candidate called KYC). To dwnload app Click on and also share link goo.gl/YN7qn1";

                //  cc.SMS(Convert.ToString(ds.Tables[0].Rows[i]["CandidateMob"]), Msg);
                //string Msg = "Sir use TRUE VOTER app either in ZO/PRO/PO1/PO2 role to upload polling count at 9.30, 11.30, 1.30, 3.30,  5.30 on election day. Update Ur app and u can do live practice Today. Then clear data before actual election day activity. Watch video on youtube link https://youtu.be/l4gdIICJ7Pw"; 
                string Msg = "Dear candidate use TRUE VOTER app for creating voter slip automatic with your  design for sharing. your representatives can also install app freely to share voter slips and for voter analysis. This activity will help to increase voter awareness. For support call 7447455869/70. https://goo.gl/wdFt9b";
                //  string Msg = "Dear candidate use TRUE VOTER app for creating voter slip automatic with your  design for sharing. your representatives can also install app freely to share voter slips and for voter analysis. This activity will help to increase voter awareness. For support call 7447455864/65/66. https://goo.gl/wdFt9b";
                cc.SMS(Convert.ToString(ds.Tables[0].Rows[i]["UsrMobNo"]), Msg);
                // cc.SMS("8421371345", Msg);
            }
            return jsonDataStrngReturn = "1";
        }
        catch (Exception ex)
        {
            return jsonDataStrngReturn = "0";
        }
        finally
        {
            ds.Clear();
        }

    }

    #region INSERT PAYMENT DETAILS (JSON_PARSING)
    [WebMethod(Description = "WEB METHOD INSERT PAYMENT DETAILS ")]
    public string InsertpayUDetails(string transData)
    {
        JObject o = JObject.Parse(transData);
        cmd.CommandText = "uspInsertPaymentDetails";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.Parameters.Clear();
        string returnString = string.Empty;

        string Id = string.Empty;
        try { Id = (string)o["id"].ToString(); }
        catch { Id = "0"; }

        string mode = string.Empty;
        try { mode = (string)o["mode"].ToString(); }
        catch { mode = "0"; }

        string status = string.Empty;
        try { status = (string)o["status"].ToString(); }
        catch { status = "0"; }

        string unmappedstatus = string.Empty;
        try { unmappedstatus = (string)o["unmappedstatus"].ToString(); }
        catch { unmappedstatus = "0"; }

        string key = string.Empty;
        try { key = (string)o["key"].ToString(); }
        catch { key = "0"; }

        string txnid = string.Empty;
        try { txnid = (string)o["txnid"].ToString(); }
        catch { txnid = "0"; }

        string transaction_fee = string.Empty;
        try { transaction_fee = (string)o["transaction_fee"].ToString(); }
        catch { transaction_fee = "0"; }

        string amount = string.Empty;
        try { amount = (string)o["amount"].ToString(); }
        catch { amount = "0"; }

        string cardCategory = string.Empty;
        try { cardCategory = (string)o["cardCategory"].ToString(); }
        catch { cardCategory = "0"; }

        string discount = string.Empty;
        try { discount = (string)o["discount"].ToString(); }
        catch { discount = "0"; }

        string additional_charges = string.Empty;
        try { additional_charges = (string)o["additional_charges"].ToString(); }
        catch { additional_charges = "0"; }

        string addedon = string.Empty;
        try { addedon = (string)o["addedon"].ToString(); }
        catch { addedon = "0"; }

        string productinfo = string.Empty;
        try { productinfo = (string)o["productinfo"].ToString(); }
        catch { productinfo = "0"; }

        string firstname = string.Empty;
        try { firstname = (string)o["firstname"].ToString(); }
        catch { firstname = "0"; }

        string email = string.Empty;
        try { email = (string)o["email"].ToString(); }
        catch { email = "0"; }

        string udf1 = string.Empty;
        try
        {
            udf1 = (string)o["udf1"].ToString();
            // udf1 = EncryptDecrypt.DecodeAndDecrypt(udf1);

        }
        catch
        {
            udf1 = "0";
        }

        string udf2 = string.Empty;
        try { udf2 = (string)o["udf2"].ToString(); }
        catch { udf2 = "0"; }

        string udf3 = string.Empty;
        try
        {
            udf3 = (string)o["udf3"].ToString();
            // udf3 = EncryptDecrypt.DecodeAndDecrypt(udf3);
        }
        catch
        {
            udf3 = "0";
        }

        string udf4 = string.Empty;
        try { udf4 = (string)o["udf4"].ToString(); }
        catch { udf4 = "0"; }

        string udf5 = string.Empty;
        try { udf5 = (string)o["udf5"].ToString(); }
        catch { udf5 = "0"; }

        string hash = string.Empty;
        try { hash = (string)o["hash"].ToString(); }
        catch { hash = "0"; }

        string field1 = string.Empty;
        try { field1 = (string)o["field1"].ToString(); }
        catch { field1 = "0"; }

        string field2 = string.Empty;
        try { field2 = (string)o["field2"].ToString(); }
        catch { field2 = "0"; }

        string field3 = string.Empty;
        try { field3 = (string)o["field3"].ToString(); }
        catch { field3 = "0"; }

        string field4 = string.Empty;
        try { field4 = (string)o["field4"].ToString(); }
        catch { field4 = "0"; }

        string field5 = string.Empty;
        try { field5 = (string)o["field5"].ToString(); }
        catch { field5 = "0"; }

        string field6 = string.Empty;
        try { field6 = (string)o["field6"].ToString(); }
        catch { field6 = "0"; }

        string field7 = string.Empty;
        try { field7 = (string)o["field7"].ToString(); }
        catch { field7 = "0"; }

        string field8 = string.Empty;
        try { field8 = (string)o["field8"].ToString(); }
        catch { field8 = "0"; }

        string field9 = string.Empty;
        try { field9 = (string)o["field9"].ToString(); }
        catch { field9 = "0"; }

        string payment_source = string.Empty;
        try { payment_source = (string)o["payment_source"].ToString(); }
        catch { payment_source = "0"; }

        string PG_TYPE = string.Empty;
        try { PG_TYPE = (string)o["PG_TYPE"].ToString(); }
        catch { PG_TYPE = "0"; }

        string bank_ref_no = string.Empty;
        try { bank_ref_no = (string)o["bank_ref_no"].ToString(); }
        catch { bank_ref_no = "0"; }

        string ibibo_code = string.Empty;
        try { ibibo_code = (string)o["ibibo_code"].ToString(); }
        catch { ibibo_code = "0"; }

        string error_code = string.Empty;
        try { error_code = (string)o["error_code"].ToString(); }
        catch { error_code = "0"; }

        string Error_Message = string.Empty;
        try { Error_Message = (string)o["Error_Message"].ToString(); }
        catch { Error_Message = "0"; }

        string name_on_card = string.Empty;
        try { name_on_card = (string)o["name_on_card"].ToString(); }
        catch { name_on_card = "0"; }

        string card_no = string.Empty;
        try { card_no = (string)o["card_no"].ToString(); }
        catch { card_no = "0"; }

        string is_seamless = string.Empty;
        try { is_seamless = (string)o["is_seamless"].ToString(); }
        catch { is_seamless = "0"; }

        string surl = string.Empty;
        try { surl = (string)o["surl"].ToString(); }
        catch { surl = "0"; }

        string furl = string.Empty;
        try { furl = (string)o["furl"].ToString(); }
        catch { furl = "0"; }

        cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = Id;
        cmd.Parameters.Add("@mode", SqlDbType.NVarChar, 30).Value = mode;
        cmd.Parameters.Add("@status", SqlDbType.NVarChar, 30).Value = status;
        cmd.Parameters.Add("@unmappedstatus", SqlDbType.NVarChar, 30).Value = unmappedstatus;
        cmd.Parameters.Add("@key", SqlDbType.NVarChar, 30).Value = key;
        cmd.Parameters.Add("@txnid", SqlDbType.NVarChar, 50).Value = txnid;
        cmd.Parameters.Add("@transaction_fee", SqlDbType.NVarChar, 30).Value = transaction_fee;
        cmd.Parameters.Add("@amount", SqlDbType.NVarChar, 30).Value = amount;
        cmd.Parameters.Add("@cardCategory", SqlDbType.NVarChar, 30).Value = cardCategory;
        cmd.Parameters.Add("@discount", SqlDbType.NVarChar, 30).Value = discount;
        cmd.Parameters.Add("@additional_charges", SqlDbType.NVarChar, 30).Value = additional_charges;
        cmd.Parameters.Add("@addedon", SqlDbType.NVarChar, 30).Value = addedon;
        cmd.Parameters.Add("@productinfo", SqlDbType.NVarChar, 100).Value = productinfo;
        cmd.Parameters.Add("@firstname", SqlDbType.NVarChar, 100).Value = firstname;
        cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;
        cmd.Parameters.Add("@udf1", SqlDbType.NVarChar, 50).Value = udf1;
        cmd.Parameters.Add("@udf2", SqlDbType.NVarChar, 50).Value = udf2;
        cmd.Parameters.Add("@udf3", SqlDbType.NVarChar, 50).Value = udf3;
        cmd.Parameters.Add("@udf4", SqlDbType.NVarChar, 50).Value = udf4;
        cmd.Parameters.Add("@udf5", SqlDbType.NVarChar, 50).Value = udf5;
        cmd.Parameters.Add("@hash", SqlDbType.NVarChar).Value = hash;
        cmd.Parameters.Add("@field1", SqlDbType.NVarChar, 50).Value = field1;
        cmd.Parameters.Add("@field2", SqlDbType.NVarChar, 50).Value = field2;
        cmd.Parameters.Add("@field3", SqlDbType.NVarChar, 50).Value = field3;
        cmd.Parameters.Add("@field4", SqlDbType.NVarChar, 50).Value = field4;
        cmd.Parameters.Add("@field5", SqlDbType.NVarChar, 50).Value = field5;
        cmd.Parameters.Add("@field6", SqlDbType.NVarChar, 50).Value = field6;
        cmd.Parameters.Add("@field7", SqlDbType.NVarChar, 50).Value = field7;
        cmd.Parameters.Add("@field8", SqlDbType.NVarChar, 50).Value = field8;
        cmd.Parameters.Add("@field9", SqlDbType.NVarChar).Value = field9;
        cmd.Parameters.Add("@payment_source", SqlDbType.NVarChar, 100).Value = payment_source;
        cmd.Parameters.Add("@PG_TYPE", SqlDbType.NVarChar, 100).Value = PG_TYPE;
        cmd.Parameters.Add("@bank_ref_no", SqlDbType.NVarChar, 100).Value = bank_ref_no;
        cmd.Parameters.Add("@ibibo_code", SqlDbType.NVarChar, 100).Value = ibibo_code;
        cmd.Parameters.Add("@error_code", SqlDbType.NVarChar, 100).Value = error_code;
        cmd.Parameters.Add("@Error_Messages", SqlDbType.NVarChar, 100).Value = Error_Message;
        cmd.Parameters.Add("@name_on_card", SqlDbType.NVarChar, 100).Value = name_on_card;
        cmd.Parameters.Add("@card_no", SqlDbType.NVarChar, 100).Value = card_no;
        cmd.Parameters.Add("@is_seamless", SqlDbType.NVarChar, 100).Value = is_seamless;
        cmd.Parameters.Add("@surl", SqlDbType.NVarChar, 100).Value = surl;
        cmd.Parameters.Add("@furl", SqlDbType.NVarChar, 100).Value = furl;

        cmd.Parameters.Add("@maxID", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;

        if (cmd.Connection.State == ConnectionState.Closed)
            cmd.Connection.Open();
        cmd.ExecuteNonQuery();

        string MaxId = cmd.Parameters["@maxID"].Value.ToString();
        returnString += Id + "*" + MaxId + "#";

        //GetTxnStatus(txnid);
        return returnString;
    }
    #endregion

    #region CHECK PAYMENT DETAILS
    [WebMethod(Description = "CHECK PAYMENT DETAILS OF REPRESENTATIVE")]
    public XmlDocument CheckPaymentRegistration(string mobileNo, string imeiNo, string regiPayID)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        DataSet dataset = new DataSet();
        DataTable dt1 = new DataTable();
        DataSet ds1 = new DataSet();
        DataTable dt = new DataTable("Table");
        DataSet dsXml = new DataSet();
        string sqlQuery = string.Empty;
        try
        {
            string KeyRegiId = regiPayID;
            switch (KeyRegiId)
            {
                case "1":
                    sqlQuery = "SELECT TOP 1 [ID],[Udf],[Udf2],[Status],[Udf3],[Transaction_fee] FROM [tblPaymentInfo](NOLOCK) WHERE Udf='" + mobileNo.Trim() + "' AND Udf2='" + imeiNo.Trim() + "' AND Udf3='" + regiPayID.Trim() + "' AND [Status]='success' ORDER BY ID DESC";
                    break;

                case "2":
                    sqlQuery = "SELECT [ID],[Udf],[Udf2],[Status],[Udf3],[Transaction_fee] FROM [tblPaymentInfo](NOLOCK) WHERE Udf='" + mobileNo.Trim() + "' AND Udf2='" + imeiNo.Trim() + "' AND Udf3 IN ('2','23','24','234') AND [Status]='success' ORDER BY ID DESC";
                    break;

                case "3":
                    sqlQuery = "SELECT [ID],[Udf],[Udf2],[Status],[Udf3],[Transaction_fee] FROM [tblPaymentInfo](NOLOCK) WHERE Udf='" + mobileNo.Trim() + "' AND Udf2='" + imeiNo.Trim() + "' AND Udf3 IN ('3','23','34','234') AND [Status]='success' ORDER BY ID DESC";
                    break;

                case "4":
                    sqlQuery = "SELECT [ID],[Udf],[Udf2],[Status],[Udf3],[Transaction_fee] FROM [tblPaymentInfo](NOLOCK) WHERE Udf='" + mobileNo.Trim() + "' AND Udf2='" + imeiNo.Trim() + "' AND Udf3 IN ('4','24','34','234') AND [Status]='success' ORDER BY ID DESC";
                    break;

                case "6":
                    sqlQuery = "SELECT [ID],[Udf],[Udf2],[Status],[Udf3],[Transaction_fee] FROM [tblPaymentInfo](NOLOCK) WHERE Udf='" + mobileNo.Trim() + "' AND Udf2='" + imeiNo.Trim() + "' AND Udf3 IN ('6') AND [Status]='success' ORDER BY ID DESC";
                    break;
            }
            //sqlQuery = "SELECT TOP 1 [ID],[Udf],[Udf2],[Status],[Udf3],[Transaction_fee] FROM [tblPaymentInfo](NOLOCK) WHERE Udf='" + mobileNo.Trim() + "' AND Udf2='" + imeiNo.Trim() + "' AND Udf3='" + regiPayID.Trim() + "' AND [Status]='success' ORDER BY ID DESC";
            dataset = cc.ExecuteDataset(sqlQuery);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                dt.Columns.Add(new DataColumn("ID", typeof(string)));
                dt.Columns.Add(new DataColumn("MobileNo", typeof(string)));
                dt.Columns.Add(new DataColumn("IMEINo", typeof(string)));
                dt.Columns.Add(new DataColumn("Status", typeof(string)));
                dt.Columns.Add(new DataColumn("KeywordID", typeof(string)));
                dt.Columns.Add(new DataColumn("Amount", typeof(string)));
                for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
                {
                    dt.Rows.Add(dataset.Tables[0].Rows[i][0].ToString(), dataset.Tables[0].Rows[i][1].ToString(), dataset.Tables[0].Rows[i][2].ToString(), dataset.Tables[0].Rows[i][3].ToString(), dataset.Tables[0].Rows[i][4].ToString(), dataset.Tables[0].Rows[i][5].ToString());
                }
                dsXml.Tables.Add(dt);
                xmldoc = new XmlDataDocument(dsXml);
                return xmldoc;
            }
            else
            {
                dt1.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt1.NewRow();
                dr["NoRecord"] = "106";
                dt1.Rows.Add(dr);
                ds1.Tables.Add(dt1);
                ds1.Tables[0].TableName = "Table";
                xmldoc = new XmlDataDocument(ds1);
                return xmldoc;
            }
        }
        catch
        {
            dt1.Columns.Add(new DataColumn("Error", typeof(string)));
            DataRow dr = dt1.NewRow();
            dr["Error"] = "105";
            dt1.Rows.Add(dr);
            ds1.Tables.Add(dt1);
            ds1.Tables[0].TableName = "Table";
            xmldoc = new XmlDataDocument(ds1);
            return xmldoc;
        }
    }
    #endregion

    [WebMethod]
    public string InsertEnquiryDetails(string enquiryNo, string enquiryDate, string classid, string className, string batch, string studentLName, string studentFName, string studentMName, string studentMobNo, string enquiryBy, string parentMobNo, string address, string wardNo, string cityName, string pinCode, string createdBy, string dob)
    {
        try
        {
            //   List<EnquiryInfo> enqrylst = new JavaScriptSerializer().Deserialize<List<EnquiryInfo>>(enquiryString);
            //foreach (EnquiryInfo enqry in enqrylst)
            //{
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "uspInsertEnquiryDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ENQUIRYNO", enquiryNo.ToString());
            cmd.Parameters.AddWithValue("@ENQUIRYDATE", enquiryDate.ToString());
            cmd.Parameters.AddWithValue("@CLASSID", classid.ToString());
            cmd.Parameters.AddWithValue("@CLASSNAME", className.ToString());
            cmd.Parameters.AddWithValue("@BATCH", batch.ToString());
            cmd.Parameters.AddWithValue("@STUDENTLNAME", studentLName.ToString());
            cmd.Parameters.AddWithValue("@STUDENTFNAME", studentFName.ToString());
            cmd.Parameters.AddWithValue("@STUDENTMNAME", studentMName.ToString());
            cmd.Parameters.AddWithValue("@STUDENTMOBNO", studentMobNo.ToString());
            cmd.Parameters.AddWithValue("@ENQUIRYBY", enquiryBy.ToString());
            cmd.Parameters.AddWithValue("@PARENTMOBNO", parentMobNo.ToString());
            cmd.Parameters.AddWithValue("@ADDRESS", address.ToString());
            cmd.Parameters.AddWithValue("@WARDNO", wardNo.ToString());
            cmd.Parameters.AddWithValue("@CITYNAME", cityName.ToString());
            cmd.Parameters.AddWithValue("@PINCODE", pinCode.ToString());
            cmd.Parameters.AddWithValue("@CREATEDBY", createdBy.ToString());
            cmd.Parameters.AddWithValue("@CREATEDDATE", System.DateTime.Now.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@dob", dob.ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //}
        }
        catch
        {
            return "0";
        }
        return "1";
    }

    #region Rest Full Service for Add Item And Download Item
    //[WebMethod(Description = "METHOD TO INSERT AddItem")]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public List<Item> InsertAddItem(string DevString)
    //{
    //    string data = string.Empty;

    //    List<Item> listworkreport = new List<Item>();
    //    try
    //    {
    //        using (StreamReader reader = new StreamReader(DevString))
    //        {
    //            data = reader.ReadToEnd();
    //        }
    //        data = data.Replace("\"", "'");

    //        var objListWorkReport = JsonConvert.DeserializeObject<List<Item>>(data);

    //        using (var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    //        {
    //            foreach (var item in objListWorkReport)
    //            {
    //                using (var cmd = new SqlCommand())
    //                {
    //                    cmd.CommandText = "uspInsertAddItem";
    //                    cmd.Connection = connection;
    //                    cmd.CommandType = CommandType.StoredProcedure;
    //                    cmd.Parameters.AddWithValue("@itemType", item.itemType);
    //                    cmd.Parameters.AddWithValue("@itemName", item.itemName);
    //                    cmd.Parameters.AddWithValue("@itemTypeId", item.itemTypeId);
    //                    cmd.Parameters.AddWithValue("@status", item.status);
    //                    cmd.Parameters.AddWithValue("@CreatedByMob", item.CreatedByMob);

    //                    cmd.Parameters.Add("@returnid", SqlDbType.VarChar, 250);
    //                    cmd.Parameters["@returnid"].Direction = ParameterDirection.Output;
    //                    connection.Open();
    //                    cmd.CommandType = CommandType.StoredProcedure;
    //                    cmd.ExecuteNonQuery();
    //                    connection.Close();

    //                    listworkreport.Add(new Item()
    //                    {
    //                        //NoData = "107",
    //                        ServerId = Convert.ToString(cmd.Parameters["@returnid"].Value)
    //                    });
    //                }
    //            }
    //        }
    //    }
    //    catch
    //    {
    //        listworkreport.Add(new Item()
    //        {
    //            Error = "0",
    //            ServerId = Convert.ToString("106")
    //        });
    //    }
    //    return listworkreport.ToList();
    //}

    string status = string.Empty;

    [WebMethod(Description = "METHOD TO INSERT AddItem")]
    public string InsertAddItem(string DevString)
    {
        try
        {
            string[] ArryString = DevString.Split(new char[] { '*', '#' });
            var temp = new List<string>();
            foreach (var s in ArryString)
            {
                if (!string.IsNullOrEmpty(s))
                    temp.Add(s);
            }
            ArryString = temp.ToArray();

            using (var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                for (int i = 0; i < ArryString.Length; i += 6)
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = "uspInsertAddItem";
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemType", ArryString[i + 1].ToString());
                        cmd.Parameters.AddWithValue("@itemName", ArryString[i + 2].ToString());
                        cmd.Parameters.AddWithValue("@itemTypeId", ArryString[i + 3].ToString());
                        cmd.Parameters.AddWithValue("@CreatedByMob", ArryString[i + 4].ToString());
                        cmd.Parameters.AddWithValue("@status", ArryString[i + 5].ToString());

                        cmd.Parameters.Add("@returnid", SqlDbType.VarChar, 250);
                        cmd.Parameters["@returnid"].Direction = ParameterDirection.Output;
                        connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        status = "1";
                    }
                }
            }
        }
        catch
        {
            status = "0";
        }
        return status.ToString();
    }

    [WebMethod(Description = "METHOD TO Download AdItem")]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string DownloadAddItem(string CreatedByMob)
    {
        //List<Item> listworkreport = new List<Item>();
        try
        {
            using (var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                sql = "SELECT [Id],[ItemType],[ItemTypeId],[ItemName],[CreatedByMob],[Status] FROM [DBeZeeOnlineExam].[dbo].[Additem] WHERE [CreatedByMob] = '99999999999' OR [CreatedByMob] = '" + CreatedByMob + "'";
                ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        sb.Append(Convert.ToString(ds.Tables[0].Rows[i]["ItemType"]) + "*");
                        sb.Append(Convert.ToString(ds.Tables[0].Rows[i]["ItemTypeId"]) + "*");
                        sb.Append(Convert.ToString(ds.Tables[0].Rows[i]["ItemName"]) + "*");
                        sb.Append(Convert.ToString(ds.Tables[0].Rows[i]["CreatedByMob"]) + "*");
                        sb.Append(Convert.ToString(ds.Tables[0].Rows[i]["Status"]) + "*");
                        sb.Append(Convert.ToString(ds.Tables[0].Rows[i]["Id"]) + "#");
                    }
                }
                else
                {
                    sb.Append("107");
                }
            }
        }
        catch
        {
            sb.Append("105");
        }
        return sb.ToString();
    }

    [WebMethod(Description = "")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string AddItemData()
    {
        try
        {
            sql = "SELECT * FROM [Come2myCityDB].[dbo].[EzeeMarketingAddItem] WHERE [ItemId]=2845";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "GetAddItemData";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(new DataSet());
        }
        catch (Exception ex)
        {

        }
        return "101";
    }


    [WebMethod(Description = "METHOD TO INSERT Add material Issued")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string InsertMaterialIssued(string DevString)
    {
        string returnStr = string.Empty;
        List<MaterialIssued> listmaterialIssued = new List<MaterialIssued>();
        try
        {
            DevString = DevString.Replace("\"", "'");

            var objListWorkReport = JsonConvert.DeserializeObject<List<MaterialIssued>>(DevString);

            using (var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                foreach (var item in objListWorkReport)
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = "uspInsertMaterialIssued";
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@usermobile", item.issuedBy);
                        cmd.Parameters.AddWithValue("@classid", item.className);
                        cmd.Parameters.AddWithValue("@addmissionid", item.studentName);
                        cmd.Parameters.AddWithValue("@dateofissue", item.dateOfIssue);
                        cmd.Parameters.AddWithValue("@itemname", item.itemName);
                        cmd.Parameters.AddWithValue("@quantity", item.quantity);
                        cmd.Parameters.AddWithValue("@section", item.section);
                        cmd.Parameters.AddWithValue("@status", item.status);
                        cmd.Parameters.AddWithValue("@refmobile", item.referenceMobNo);
                        cmd.Parameters.AddWithValue("@createdby", item.issuedBy);
                        cmd.Parameters.Add("@returnid", SqlDbType.VarChar, 250);
                        cmd.Parameters["@returnid"].Direction = ParameterDirection.Output;
                        connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        returnStr = Convert.ToString(cmd.Parameters["@returnid"].Value);
                    }
                }
            }
        }
        catch
        {
            returnStr = "0";
        }
        return returnStr;
    }

    public class MaterialIssued
    {
        public string className { get; set; }
        public string dateOfIssue { get; set; }
        public string issuedBy { get; set; }
        public string itemName { get; set; }
        public string quantity { get; set; }
        public string referenceMobNo { get; set; }
        public string section { get; set; }
        public string serverId { get; set; }
        public string status { get; set; }
        public string studentName { get; set; }
        public string Error { get; set; }
        public string NoData { get; set; }
    }


    public class Item
    {
        public string ServerId { get; set; }
        public string itemType { get; set; }
        public string itemTypeId { get; set; }
        public string itemName { get; set; }
        public string CreatedByMob { get; set; }
        public string status { get; set; }
        public string Error { get; set; }
        public string NoData { get; set; }
    }
    #endregion
}
