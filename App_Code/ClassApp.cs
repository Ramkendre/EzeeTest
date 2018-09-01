using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Xml;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Summary description for ClassApp
/// </summary>
/// 

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class ClassApp : System.Web.Services.WebService
{
    AndroidClassApp_StoreProc androidClassapp = new AndroidClassApp_StoreProc();
    Location location = new Location();
    CompanyBAL compbal = new CompanyBAL();
    RegisterToMyct reg = new RegisterToMyct();
    CommonCode cc = new CommonCode();
    int status, cid;
    DataSet ds = new DataSet();
    CommonData objComData = new CommonData();
    StringBuilder sb = new StringBuilder();

    string language;
    string UserName1 = "", mno = "", newMobNO = "", returnstatus = "0", UserID = "", usenm = "", R1 = "", R2 = "", R3 = "", R4 = "", R5 = "", R6 = "", initial = "", Login_Uid = "", usrRole = "", RoleId = "", userid, CompanyId, LoginId_PK, parentrole, insertID, Sub_UID;
    string FN = "", LN = "", FatherName = "";

    public ClassApp()
    {
    }


    #region Insert class Setting
    [WebMethod(Description = "Insert Your Class Setting Here...")]
    public string ClassSetting(string classSettingString)
    {
        string result = string.Empty;
        string str1 = string.Empty;
        if (classSettingString.ToString() != null)
        {
            string[] stringArray = classSettingString.Split(new char[] { '#', '*' });
            if ((stringArray.Length % 13) == 0)
            {
                AllClassAppMethods objClassApp = new AllClassAppMethods();
                for (int i = 0; i < stringArray.Length; i += 13)
                {
                    result += objClassApp.ClassSettingfunction(stringArray[i], stringArray[i + 1], stringArray[i + 2], stringArray[i + 3], stringArray[i + 4], stringArray[i + 5], stringArray[i + 6], stringArray[i + 7], stringArray[i + 8], stringArray[i + 9], stringArray[i + 10], stringArray[i + 11], stringArray[i + 12]) + "*";

                }
                //return result.Substring(0, result.Length - 1);
            }
            else
            {
                return "WrongString";
            }
        }
        return result;
    }
    #endregion

    #region Insert Student Registration
    [WebMethod(Description = "Insert Your Student Registration Details...")]
    public string StudentRegistration(string studentRegistrationString)
    {
        string result = string.Empty;

        if (studentRegistrationString.ToString() != null)
        {
            string[] stringArray = studentRegistrationString.Split(new char[] { '#', '*' });
            if ((stringArray.Length % 22) == 0)
            {
                AllClassAppMethods objClassApp = new AllClassAppMethods();
                for (int i = 0; i < stringArray.Length; i += 22)
                {
                    result += objClassApp.StudentRegistrationFunction(stringArray[i], stringArray[i + 1], stringArray[i + 2], stringArray[i + 3], stringArray[i + 4], stringArray[i + 5], stringArray[i + 6], stringArray[i + 7], stringArray[i + 8], stringArray[i + 9], stringArray[i + 10], stringArray[i + 11], stringArray[i + 12], stringArray[i + 13], stringArray[i + 14], stringArray[i + 15], stringArray[i + 16], stringArray[i + 17], stringArray[i + 18], stringArray[i + 19], stringArray[i + 20], stringArray[i + 21]) + "*";
                }
                //return result.Substring(0, result.Length - 1);
            }
            else
            {
                return "WrongString";
            }
        }
        return result;
    }

    #endregion

    #region Insert Family Details
    [WebMethod(Description = "Insert Your Family Details Here...")]
    public string FamilyDetails(string familyDetailsString)
    {
        string result = string.Empty;

        if (familyDetailsString.ToString() != null)
        {
            string[] stringArray = familyDetailsString.Split(new char[] { '#', '*' });
            if ((stringArray.Length % 13) == 0)
            {
                AllClassAppMethods objClassApp = new AllClassAppMethods();
                for (int i = 0; i < stringArray.Length; i += 13)
                {
                    result += objClassApp.FamilyDetailsFunction(stringArray[i], stringArray[i + 1], stringArray[i + 2], stringArray[i + 3], stringArray[i + 4], stringArray[i + 5], stringArray[i + 6], stringArray[i + 7], stringArray[i + 8], stringArray[i + 9], stringArray[i + 10], stringArray[i + 11], stringArray[i + 12]) + "*";
                }
                return result.Substring(0, result.Length - 1);
            }
            else
            {
                return "WrongString";
            }
        }
        return result;
    }

    #endregion

    #region Insert Studetn Attendance Details
    [WebMethod(Description = "Insert Student Attendance Details Here...")]
    public string attendance(string attendanceString)
    {
        string result = string.Empty;

        if (attendanceString.ToString() != null)
        {
            string[] stringArray = attendanceString.Split(new char[] { '#', '*' });
            if ((stringArray.Length % 12) == 0)
            {
                AllClassAppMethods objClassApp = new AllClassAppMethods();
                for (int i = 0; i < stringArray.Length; i += 12)
                {
                    result += objClassApp.ClassAppAttendanceFunction(stringArray[i], stringArray[i + 1], stringArray[i + 2], stringArray[i + 3], stringArray[i + 4], stringArray[i + 5], stringArray[i + 6], stringArray[i + 7], stringArray[i + 8], stringArray[i + 9], stringArray[i + 10], stringArray[i + 11]) + "*";
                }
                return result.Substring(0, result.Length - 1);
            }
            else
            {
                return "WrongString";
            }
        }
        return result;
    }

    #endregion

    #region Insert Test Detail Function
    [WebMethod(Description = "Insert Test Details Here...")]
    public string AndriodtestDetails(string testDetailsString)
    {
        string result = string.Empty;

        if (testDetailsString.ToString() != null)
        {
            string[] stringArray = testDetailsString.Split(new char[] { '#', '*' });
            if ((stringArray.Length % 16) == 0)
            {
                AllClassAppMethods objClassApp = new AllClassAppMethods();
                for (int i = 0; i < stringArray.Length; i += 16)
                {
                    result += objClassApp.TestDetailsFunction(stringArray[i], stringArray[i + 1], stringArray[i + 2], stringArray[i + 3], stringArray[i + 4], stringArray[i + 5], stringArray[i + 6], stringArray[i + 7], stringArray[i + 8], stringArray[i + 9], stringArray[i + 10], stringArray[i + 11], stringArray[i + 12], stringArray[i + 13], stringArray[i + 14], stringArray[i + 15]) + "*";
                }
                return result.Substring(0, result.Length - 1);
            }
            else
            {
                return "WrongString";
            }
        }
        return result;
    }

    #endregion

    #region Insert FeesDetails
    [WebMethod(Description = "Insert Fees Details of Student Here...")]
    public string FEESDetails(string feesDetailsString)
    {
        string result = string.Empty;

        if (feesDetailsString.ToString() != null)
        {
            string[] stringArray = feesDetailsString.Split(new char[] { '#', '*' });
            if ((stringArray.Length % 16) == 0)
            {
                AllClassAppMethods objClassApp = new AllClassAppMethods();
                for (int i = 0; i < stringArray.Length; i += 16)
                {
                    result += objClassApp.ClassAppFeesDetailsFunction(stringArray[i], stringArray[i + 1], stringArray[i + 2], stringArray[i + 3], stringArray[i + 4], stringArray[i + 5], stringArray[i + 6], stringArray[i + 7], stringArray[i + 8], stringArray[i + 9], stringArray[i + 10], stringArray[i + 11], stringArray[i + 12], stringArray[i + 13], stringArray[i + 14], stringArray[i + 15]) + "*";
                }
                return result.Substring(0, result.Length - 1);
            }
            else
            {
                return "WrongString";
            }
        }
        return result;
    }

    #endregion

    #region Insert Student Marks Details
    [WebMethod(Description = "StudentMarksDetails")]
    public int StudentMarksDetails(string admissionno, string ClassID, string batch, string strSem, string strSession, string date, string Marathi, string Hindi, string English, string Science, string History, string Practical)
    {
        int flag = 0;
        try
        {
            string Sql = "select *from tblStudentRegister where Adm_No = " + admissionno;
            DataSet ds = cc.ExecuteDataset(Sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Sql = "select *from tblStudentMarksDetails where Adm_No=" + admissionno + " and Class_Id='" + ClassID + "' and Batch='" + batch + "' and Session='" + strSession + "' and Semester= '" + strSem + "'";
                ds = cc.ExecuteDataset(Sql);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Sql = "update tblStudentMarksDetails set Adm_No='" + admissionno + "' , Class_Id='" + ClassID + "' , Batch='" + batch + "' , Session='" + strSession + "' , Semester= '" + strSem + "'" +
                          " , Date='" + date + "' , Marathi='" + Marathi + "' , Hindi='" + Hindi + "' , English='" + English + "' , Science='" + Science + "' , History='" + History + "' , Practical= '" + Practical + "'" +
                          " where Adm_No=" + admissionno + " and Class_Id='" + ClassID + "' and Batch='" + batch + "' and Session='" + strSession + "' and Semester= '" + strSem + "'";
                    flag = cc.ExecuteNonQuery(Sql);
                }
                else
                {
                    Sql = "insert into tblStudentMarksDetails(Adm_No,Class_Id,Batch,Session,Semester,Date,Marathi,Hindi,English,Science,History,Practical) " +
                        " Values('" + admissionno + "','" + ClassID + "','" + batch + "','" + strSession + "','" + strSem + "','" + date + "','" + Marathi + "','" + Hindi + "','" + English + "','" + Science + "','" + History + "','" + Practical + "')";

                    flag = cc.ExecuteNonQuery(Sql);
                }
            }
        }
        catch
        {
        }
        return flag;
    }
    #endregion

    #region Get Student Attendance Details
    [WebMethod(Description = "Methods to Get Student Attendance Details...")]
    public string GetStudentAttendanceDetails(string referenceMoblie, string parentOwnerMobile)
    {
        string result = string.Empty;
        try
        {
            string SqlQuery1 = "Select [SNO],[First_Name],[Father_Name],[Last_Name] From [DBeZeeOnlineExam].[dbo].[tblStudentRegister] Where [Parent_MobNo]='" + parentOwnerMobile + "' and [LoginId]='" + referenceMoblie + "'";
            DataSet dataSet = cc.ExecuteDataset(SqlQuery1);

            if (dataSet.Tables[0].Rows.Count == 0)
            {
                string sqlQuery3 = "Select [mobileNo] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] Where [RefMobileNo]='" + referenceMoblie + "'";
                DataSet dataset3 = cc.ExecuteDatasetMYCT(sqlQuery3);

                if (dataset3.Tables[0].Rows.Count > 0)
                {
                    for (int s = 0; s < dataset3.Tables[0].Rows.Count; s++)
                    {
                        string mobileColumn = dataset3.Tables[0].Rows[s][0].ToString();

                        string SqlQuery4 = "Select [SNO],[First_Name],[Father_Name],[Last_Name] From [DBeZeeOnlineExam].[dbo].[tblStudentRegister] Where [Parent_MobNo]='" + parentOwnerMobile + "' and [LoginId]='" + mobileColumn + "'";
                        DataSet dataSet4 = cc.ExecuteDataset(SqlQuery4);

                        if (dataSet4.Tables[0].Rows.Count > 0)
                        {
                            for (int a = 0; a < dataSet4.Tables[0].Rows.Count; a++)
                            {
                                string sno = dataSet4.Tables[0].Rows[a][0].ToString();
                                string fullName = dataSet4.Tables[0].Rows[a][1].ToString() + " " + dataSet4.Tables[0].Rows[a][2].ToString() + " " + dataSet4.Tables[a].Rows[0][3].ToString();

                                string SqlQuery2 = "  Select [attenDate],[Present] FROM [DBeZeeOnlineExam].[dbo].[tblAttendance] Where [StudentRegSNO]='" + sno + "'";
                                DataSet dataSet2 = cc.ExecuteDataset(SqlQuery2);

                                string attenDate = dataSet2.Tables[0].Rows[0][0].ToString();
                                string presenty = dataSet2.Tables[0].Rows[0][1].ToString();

                                result += attenDate + "*" + presenty + "*" + fullName + "#";
                            }
                            break;
                        }
                    }
                }
                else
                {
                    result = "2";
                    return result;
                }
            }
            else
            {
                for (int a = 0; a < dataSet.Tables[0].Rows.Count; a++)
                {
                    string sno = dataSet.Tables[0].Rows[a][0].ToString();
                    string fullName = dataSet.Tables[0].Rows[a][1].ToString() + " " + dataSet.Tables[0].Rows[a][2].ToString() + " " + dataSet.Tables[a].Rows[0][3].ToString();

                    string SqlQuery2 = "  Select [attenDate],[Present] FROM [DBeZeeOnlineExam].[dbo].[tblAttendance] Where [StudentRegSNO]='" + sno + "'";
                    DataSet dataSet2 = cc.ExecuteDataset(SqlQuery2);

                    string attenDate = dataSet2.Tables[0].Rows[0][0].ToString();
                    string presenty = dataSet2.Tables[0].Rows[0][1].ToString();

                    result += attenDate + "*" + presenty + "*" + fullName + "#";
                }
            }

            return result;
        }
        catch
        {
            result = "0";
            return result;
        }
    }
    #endregion

    #region Download Student Register Information
    [WebMethod(Description = "Download Student Register Child Information")]
    public string DownloadStudentData(string referenceMoblie, string parentOwnerMobile)
    {
        string result = string.Empty;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        string returnString = string.Empty;
        int count = 1;
        try
        {
            string str =
                       " with Event as( " +
                       " select *from( " +
                       " ( SELECT [SNO],[Adm_No],[adm_date],[DOB],[Stud_MobNo],Parent_MobNo,[StudAddress],[WardNo],[Area],[CityId],[Gender],[Pincode],[First_Name],[Last_Name],[Father_Name],[ClassSetting_id] as c FROM [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where ([Parent_MobNo]='" + parentOwnerMobile + "' or Stud_MobNo='" + parentOwnerMobile + "') and [LoginId]='" + referenceMoblie + "')as t1 " +
                       " inner join " +
                       " [DBeZeeOnlineExam].[dbo].[tblClassSetting] as t2 " +

                       " on " +
                       " t1.c=t2.ClassSetting_id " +
                       " ) " +
                       " ) ";
            str += " select [Adm_No],[adm_date],[DOB],[Stud_MobNo],[StudAddress],[WardNo],[Area],[CityId],[Gender],[Pincode],[First_Name],[Last_Name],[Father_Name],[ClassSetting_id],[Class_Id],[Session],[Batch],[Semester],[Class_Teacher],[Mob_No],[Email_Id],Parent_MobNo,AndroidClassSettingID,InstituteHeadMob,FacultyMobNo from Event";
            ds = cc.ExecuteDataset(str);

            if (ds.Tables[0].Rows.Count == 0)
            {
                string str1 = "Select [mobileNo] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] Where [RefMobileNo]='" + referenceMoblie + "' and keyword='Classapp'";
                ds1 = cc.ExecuteDatasetMYCT(str1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    for (int s = 0; s < ds1.Tables[0].Rows.Count; s++)
                    {
                        string mobileColumn = Convert.ToString(ds1.Tables[0].Rows[s][0]);
                        string str3 =
                       " with Event as( " +
                       " select *from( " +
                       " ( SELECT [SNO],[Adm_No],[adm_date],[DOB],[Stud_MobNo],[StudAddress],[WardNo],[Area],[CityId],[Gender],[Pincode],[First_Name],[Last_Name],[Father_Name],[ClassSetting_id] as c FROM [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where [Parent_MobNo]='" + parentOwnerMobile + "' and [LoginId]='" + mobileColumn + "')as t1 " +
                       " inner join " +
                       " [DBeZeeOnlineExam].[dbo].[tblClassSetting] as t2 " +

                       " on " +
                       " t1.c=t2.ClassSetting_id " +
                       " ) " +
                       " ) ";
                        str3 += " select [Adm_No],[adm_date],[DOB],[Stud_MobNo],[StudAddress],[WardNo],[Area],[CityId],[Gender],[Pincode],[First_Name],[Last_Name],[Father_Name],[ClassSetting_id],[Class_Id],[Session],[Batch],[Semester],[Class_Teacher],[Mob_No],[Email_Id],Parent_MobNo,AndroidClassSettingID,InstituteHeadMob,FacultyMobNo from Event";
                        ds2 = cc.ExecuteDataset(str);

                        if (ds2.Tables[0].Rows.Count > 0)
                        {

                            for (int rows = 0; rows < ds2.Tables[0].Rows.Count; rows++)
                            {
                                for (int cols = 0; cols < 25; cols++)
                                {
                                    if (cols != 24)
                                    {
                                        returnString += ds.Tables[0].Rows[rows][cols].ToString() + "*";
                                    }
                                    else
                                    {
                                        returnString += ds.Tables[0].Rows[rows][cols].ToString();
                                    }
                                }
                                returnString += "#";
                            }
                            return returnString;
                        }
                    }
                }
                else
                {
                    result = "2";
                    return result;
                }


            }
            else
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        for (int cols = 0; cols < 25; cols++)
                        {
                            if (cols != 24)
                            {
                                returnString += ds.Tables[0].Rows[rows][cols].ToString() + "*";
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[rows][cols].ToString();
                            }
                        }
                        returnString += "#";
                    }

                }
            }
            return returnString;
        }
        catch
        {
            result = "0";
            return result;
        }
    }
    #endregion

    #region Download All Details For Parent(Evolution)
    [WebMethod(Description = "Download All Details")]
    public string DownloadAllDetails(string keyWord, string referenceMoblie, string parentOwnerMobile, string ClassId, string batch)
    {

        int i;
        if (!string.IsNullOrEmpty(keyWord) && !string.IsNullOrEmpty(referenceMoblie) && !string.IsNullOrEmpty(parentOwnerMobile) && !string.IsNullOrEmpty(ClassId) && !string.IsNullOrEmpty(batch))
        {
            try
            {
                if (keyWord.Equals("Daily Instruction"))
                {
                    return DailyInstructionData(referenceMoblie, parentOwnerMobile, ClassId, batch);
                }
                else if (keyWord.Equals("Yearly Or Monthly Events"))
                {
                    return EventsData(referenceMoblie, parentOwnerMobile, ClassId, batch);
                }
                else if (keyWord.Equals("Subject Notes"))
                {
                    return SubjectNotesData(referenceMoblie, parentOwnerMobile, ClassId, batch);
                }
                else if (keyWord.Equals("Attendance"))
                {
                    return AttendanceData(referenceMoblie, parentOwnerMobile, ClassId, batch);
                }
                else if (keyWord.Equals("Test"))
                {
                    return TestData(referenceMoblie, parentOwnerMobile, ClassId, batch);
                }
                else if (keyWord.Equals("Exam Schedule"))
                {
                    return ExamData(referenceMoblie, parentOwnerMobile, ClassId, batch);
                }
                else if (keyWord.Equals("Fees"))
                {
                    return FeesData(referenceMoblie, parentOwnerMobile, ClassId, batch);
                }

                return null;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        else
        {

            return "0";
        }
    }
    private string DailyInstructionData(string referenceMoblie, string parentOwnerMobile, string ClassId, string batch)
    {
        string result = string.Empty;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds0 = new DataSet();
        string returnString = string.Empty;
        string c = string.Empty;
        string q = string.Empty;
        int count = 1;
        try
        {
            string s1 = " select [typeofInstruction],[date],[instructionDetails],[teacherMobNo],[Session],[InstituteHeadMob],[FacultyMobNo] from tblClassAppDailyInstruction where ([classId]='" + ClassId + "' and [InstituteHeadMob] = '" + referenceMoblie + "') OR (typeofInstruction IN ('1') AND [InstituteHeadMob] = '" + referenceMoblie + "') ORDER BY typeofInstruction";

            ds0 = cc.ExecuteDataset(s1);

            if (ds0.Tables[0].Rows.Count > 0)
            {

                for (int rows = 0; rows < ds0.Tables[0].Rows.Count; rows++)
                {
                    returnString += count++;
                    for (int cols = 0; cols < 7; cols++)
                    {
                        if (cols != 7)
                        {
                            returnString += "*" + ds0.Tables[0].Rows[rows][cols].ToString();
                        }
                        else
                        {
                            returnString += ds0.Tables[0].Rows[rows][cols].ToString();
                        }
                    }
                    returnString += "#";
                }

            }
            return returnString;
        }

        catch (SqlException ex)
        {
            throw ex;
        }
    }
    private string EventsData(string referenceMoblie, string parentOwnerMobile, string ClassId, string batch)
    {
        string result = string.Empty;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds0 = new DataSet();
        string returnString = string.Empty;
        string c = string.Empty;
        string q = string.Empty;
        int count = 1;
        try
        {
            string str = "Select ClassSetting_id from [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where ([Parent_MobNo]='" + parentOwnerMobile + "' or Stud_MobNo='" + parentOwnerMobile + "') and [LoginId]='" + referenceMoblie + "'";

            ds = cc.ExecuteDataset(str);
            string cid = Convert.ToString(ds.Tables[0].Rows[0]["ClassSetting_id"]);

            string s1 = "select [typeofEvents],[eventDetails],[date],[topic],[teacherMobNo],[Session],[InstituteHeadMob],[FacultyMobNo] from tblClassAppEvents where [classId]='" + ClassId + "' and [batch]='" + batch + "' and [ClassSettingId]='" + cid + "'";
            ds0 = cc.ExecuteDataset(s1);

            if (ds0.Tables[0].Rows.Count == 0)
            {
                string str1 = "Select [mobileNo] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] Where [RefMobileNo]='" + referenceMoblie + "'";
                ds1 = cc.ExecuteDatasetMYCT(str1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    for (int s = 0; s < ds1.Tables[0].Rows.Count; s++)
                    {
                        string mobileColumn = Convert.ToString(ds1.Tables[0].Rows[s][0]);
                        string str3 = "Select ClassSetting_id [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where [Parent_MobNo]='" + parentOwnerMobile + "' and [LoginId]='" + mobileColumn + "'";
                        ds2 = cc.ExecuteDataset(str);
                        c = Convert.ToString(ds2.Tables[0].Rows[0]["ClassSetting_id"]);

                        q = "select [typeofEvents],[eventDetails],[date],[topic],[teacherMobNo],[Session] from tblClassAppEvents where [classId]='" + ClassId + "' and [batch]='" + batch + "' and [ClassSettingId]='" + cid + "'";
                        ds3 = cc.ExecuteDataset(q);
                        if (ds3.Tables[0].Rows.Count > 0)
                        {

                            for (int rows = 0; rows < ds3.Tables[0].Rows.Count; rows++)
                            {
                                returnString += count++;
                                for (int cols = 0; cols < 8; cols++)
                                {
                                    if (cols != 8)
                                    {
                                        returnString += "*" + ds3.Tables[0].Rows[rows][cols].ToString();
                                    }
                                    else
                                    {
                                        returnString += ds3.Tables[0].Rows[rows][cols].ToString();
                                    }
                                }
                                returnString += "#";
                            }
                            return returnString;
                        }
                        else
                        {
                            result = "102";
                            return result;
                        }
                    }
                }
                else
                {
                    result = "102";
                    return result;
                }


            }
            else
            {

                if (ds0.Tables[0].Rows.Count > 0)
                {

                    for (int rows = 0; rows < ds0.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;
                        for (int cols = 0; cols < 8; cols++)
                        {
                            if (cols != 8)
                            {
                                returnString += "*" + ds0.Tables[0].Rows[rows][cols].ToString();
                            }
                            else
                            {
                                returnString += ds0.Tables[0].Rows[rows][cols].ToString();
                            }
                        }
                        returnString += "#";
                    }

                }
            }
            return returnString;
        }
        catch
        {
            result = "0";
            return result;
        }
    }

    private string SubjectNotesData(string referenceMoblie, string parentOwnerMobile, string ClassId, string batch)
    {
        string result = string.Empty;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds0 = new DataSet();
        string returnString = string.Empty;
        string c = string.Empty;
        string q = string.Empty;
        int count = 1;
        try
        {
            string str = "Select ClassSetting_id from [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where ([Parent_MobNo]='" + parentOwnerMobile + "' or Stud_MobNo='" + parentOwnerMobile + "') and [LoginId]='" + referenceMoblie + "'";

            ds = cc.ExecuteDataset(str);
            string cid = Convert.ToString(ds.Tables[0].Rows[0]["ClassSetting_id"]);

            string s1 = "select [date],[chapter],[topic],[subjectNotes],[subject],[teacherMobNo],[Session],[InstituteHeadMob],[FacultyMobNo] from tblClassAppSubjectNotes where [classId]='" + ClassId + "' and [batch]='" + batch + "' and [ClassSettingId]='" + cid + "'";
            ds0 = cc.ExecuteDataset(s1);

            if (ds0.Tables[0].Rows.Count == 0 || ds0.Tables[0].Rows.Count == null)
            {
                string str1 = "Select [mobileNo] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] Where [RefMobileNo]='" + referenceMoblie + "'";
                ds1 = cc.ExecuteDatasetMYCT(str1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    for (int s = 0; s < ds1.Tables[0].Rows.Count; s++)
                    {
                        string mobileColumn = Convert.ToString(ds1.Tables[0].Rows[s][0]);
                        string str3 = "Select ClassSetting_id [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where ([Parent_MobNo]='" + parentOwnerMobile + "' or Stud_MobNo='" + parentOwnerMobile + "') and [LoginId]='" + mobileColumn + "'";
                        ds2 = cc.ExecuteDataset(str);
                        c = Convert.ToString(ds2.Tables[0].Rows[0]["ClassSetting_id"]);

                        q = "select [date],[chapter],[topic],[subjectNotes],[subject],[teacherMobNo],[Session],[InstituteHeadMob],[FacultyMobNo] from tblClassAppSubjectNotes where [classId]='" + ClassId + "' and [batch]='" + batch + "' and [ClassSettingId]='" + cid + "'";
                        ds3 = cc.ExecuteDataset(q);
                        if (ds3.Tables[0].Rows.Count > 0)
                        {

                            for (int rows = 0; rows < ds3.Tables[0].Rows.Count; rows++)
                            {
                                returnString += count++;
                                for (int cols = 0; cols < 9; cols++)
                                {
                                    if (cols != 9)
                                    {
                                        returnString += "*" + ds3.Tables[0].Rows[rows][cols].ToString();
                                    }
                                    else
                                    {
                                        returnString += ds3.Tables[0].Rows[rows][cols].ToString();
                                    }
                                }
                                returnString += "#";
                            }
                            return returnString;
                        }
                        else
                        {
                            result = "102";
                            return result;
                        }
                    }
                }
                else
                {
                    result = "102";
                    return result;
                }



            }
            else
            {

                if (ds0.Tables[0].Rows.Count > 0)
                {

                    for (int rows = 0; rows < ds0.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;
                        for (int cols = 0; cols < 9; cols++)
                        {
                            if (cols != 9)
                            {
                                returnString += "*" + ds0.Tables[0].Rows[rows][cols].ToString();
                            }
                            else
                            {
                                returnString += ds0.Tables[0].Rows[rows][cols].ToString();
                            }
                        }
                        returnString += "#";
                    }

                }
            }
            return returnString;
        }
        catch
        {
            result = "0";
            return result;
        }
    }
    private string AttendanceData(string referenceMoblie, string parentOwnerMobile, string ClassId, string batch)
    {
        string returnString = string.Empty;
        string result = string.Empty;
        try
        {
            string SqlQuery1 = "Select [SNO],[First_Name],[Father_Name],[Last_Name] From [DBeZeeOnlineExam].[dbo].[tblStudentRegister] Where ([Parent_MobNo]='" + parentOwnerMobile + "' or Stud_MobNo='" + parentOwnerMobile + "') and [LoginId]='" + referenceMoblie + "'";
            DataSet dataSet = cc.ExecuteDataset(SqlQuery1);

            if (dataSet.Tables[0].Rows.Count == 0)
            {
                string sqlQuery3 = "Select [mobileNo] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] Where [RefMobileNo]='" + referenceMoblie + "'";
                DataSet dataset3 = cc.ExecuteDatasetMYCT(sqlQuery3);

                if (dataset3.Tables[0].Rows.Count > 0)
                {
                    for (int s = 0; s < dataset3.Tables[0].Rows.Count; s++)
                    {
                        string mobileColumn = dataset3.Tables[0].Rows[s][0].ToString();

                        string SqlQuery4 = "Select [SNO],[First_Name],[Father_Name],[Last_Name] From [DBeZeeOnlineExam].[dbo].[tblStudentRegister] Where ([Parent_MobNo]='" + parentOwnerMobile + "' or Stud_MobNo='" + parentOwnerMobile + "') and [LoginId]='" + mobileColumn + "'";
                        DataSet dataSet4 = cc.ExecuteDataset(SqlQuery4);

                        if (dataSet4.Tables[0].Rows.Count > 0)
                        {
                            for (int a = 0; a < dataSet4.Tables[0].Rows.Count; a++)
                            {
                                string sno = dataSet4.Tables[0].Rows[a][0].ToString();
                                string fullName = dataSet4.Tables[0].Rows[a][1].ToString() + " " + dataSet4.Tables[0].Rows[a][2].ToString() + " " + dataSet4.Tables[a].Rows[0][3].ToString();

                                string SqlQuery2 = "  Select [attenDate],[Present],[InstituteHeadMob],[FacultyMobNo] FROM [DBeZeeOnlineExam].[dbo].[tblAttendance] Where [StudentRegSNO]='" + sno + "'";
                                DataSet dataSet2 = cc.ExecuteDataset(SqlQuery2);
                                for (int rows = 0; rows < dataSet2.Tables[0].Rows.Count; rows++)
                                {

                                    for (int cols = 0; cols < 4; cols++)
                                    {
                                        if (cols != 4)
                                        {
                                            returnString += dataSet2.Tables[0].Rows[rows][cols].ToString() + "*";
                                        }
                                    }
                                }
                                returnString += fullName + "*" + ClassId + "*" + batch + "#";

                                result += returnString + fullName + "*" + ClassId + "*" + batch + "#";
                            }
                            break;
                        }
                        else
                        {
                            result = "2";
                            return result;
                        }
                    }
                }
                else
                {
                    result = "2";
                    return result;
                }
            }
            else
            {
                for (int a = 0; a < dataSet.Tables[0].Rows.Count; a++)
                {
                    string sno = dataSet.Tables[0].Rows[a][0].ToString();
                    string fullName = dataSet.Tables[0].Rows[a][1].ToString() + " " + dataSet.Tables[0].Rows[a][2].ToString() + " " + dataSet.Tables[0].Rows[a][3].ToString();

                    string SqlQuery2 = "  Select [attenDate],[Present],[InstituteHeadMob],[FacultyMobNo] FROM [DBeZeeOnlineExam].[dbo].[tblAttendance] Where [StudentRegSNO]='" + sno + "'";
                    DataSet dataSet2 = cc.ExecuteDataset(SqlQuery2);


                    for (int rows = 0; rows < dataSet2.Tables[0].Rows.Count; rows++)
                    {

                        for (int cols = 0; cols < 4; cols++)
                        {
                            if (cols != 4)
                            {
                                returnString += dataSet2.Tables[0].Rows[rows][cols].ToString() + "*";
                            }

                        }
                        result += fullName + "*" + returnString + ClassId + "*" + batch + "#";
                        returnString = string.Empty;
                    }
                    returnString = string.Empty;
                }
            }

            return result;
        }
        catch
        {
            result = "0";
            return result;
        }
    }

    private string TestData(string referenceMoblie, string parentOwnerMobile, string ClassId, string batch)
    {
        string result = string.Empty;
        string returnString = string.Empty;
        try
        {
            string sqlQuery1 = "Select [SNO],[First_Name],[Father_Name],[Last_Name] From [DBeZeeOnlineExam].[dbo].[tblStudentRegister] Where ([Parent_MobNo]='" + parentOwnerMobile + "' or Stud_MobNo='" + parentOwnerMobile + "') and [LoginId]='" + referenceMoblie + "'";
            DataSet dataSet = cc.ExecuteDataset(sqlQuery1);

            if (dataSet.Tables[0].Rows.Count == 0)
            {
                string sqlQuery3 = "Select [mobileNo] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] Where [RefMobileNo]='" + referenceMoblie + "'";
                DataSet dataset3 = cc.ExecuteDatasetMYCT(sqlQuery3);

                if (dataset3.Tables[0].Rows.Count > 0)
                {
                    for (int s = 0; s < dataset3.Tables[0].Rows.Count; s++)
                    {
                        string mobileColumn = dataset3.Tables[0].Rows[s][0].ToString();

                        string SqlQuery4 = "Select [SNO],[First_Name],[Father_Name],[Last_Name] From [DBeZeeOnlineExam].[dbo].[tblStudentRegister] Where ([Parent_MobNo]='" + parentOwnerMobile + "' or Stud_MobNo='" + parentOwnerMobile + "') and [LoginId]='" + mobileColumn + "'";
                        DataSet dataSet4 = cc.ExecuteDataset(SqlQuery4);

                        if (dataSet4.Tables[0].Rows.Count > 0)
                        {
                            for (int a = 0; a < dataSet4.Tables[0].Rows.Count; a++)
                            {
                                string sno = dataSet4.Tables[0].Rows[a][0].ToString();
                                string fullName = dataSet4.Tables[0].Rows[a][1].ToString() + " " + dataSet4.Tables[0].Rows[a][2].ToString() + " " + dataSet4.Tables[a].Rows[0][3].ToString();


                                string sqlQuery2 = "Select [TestNo],[TestTopic],[TestName],[OutofMark],[ObtainedMark],[Testdate],[InstituteHeadMob],[FacultyMobNo] FROM [DBeZeeOnlineExam].[dbo].[tblAndroidTestDetails] Where [StudentRegSNO]='" + sno + "'";
                                DataSet dataSet2 = cc.ExecuteDataset(sqlQuery2);
                                for (int rows = 0; rows < dataSet2.Tables[0].Rows.Count; rows++)
                                {

                                    for (int cols = 0; cols < 8; cols++)
                                    {
                                        if (cols != 8)
                                        {
                                            returnString += dataSet2.Tables[0].Rows[rows][cols].ToString() + "*";
                                        }
                                    } result += fullName + "*" + returnString + ClassId + "*" + batch + "#";
                                    returnString = string.Empty;
                                }

                                returnString = string.Empty;

                            }
                            break;
                        }
                        else
                        {
                            result = "2";
                            return result;
                        }
                    }
                }
                else
                {
                    result = "2";
                    return result;
                }
            }
            else
            {
                for (int a = 0; a < dataSet.Tables[0].Rows.Count; a++)
                {
                    string sno = dataSet.Tables[0].Rows[a][0].ToString();
                    string fullName = dataSet.Tables[0].Rows[a][1].ToString() + " " + dataSet.Tables[0].Rows[a][2].ToString() + " " + dataSet.Tables[0].Rows[a][3].ToString();

                    string sqlQuery2 = "Select [TestNo],[TestTopic],[TestName],[OutofMark],[ObtainedMark],[Testdate],[InstituteHeadMob],[FacultyMobNo] FROM [DBeZeeOnlineExam].[dbo].[tblAndroidTestDetails] Where [StudentRegSNO]='" + sno + "'";
                    DataSet dataSet2 = cc.ExecuteDataset(sqlQuery2);

                    for (int rows = 0; rows < dataSet2.Tables[0].Rows.Count; rows++)
                    {

                        for (int cols = 0; cols < 8; cols++)
                        {
                            if (cols != 8)
                            {
                                returnString += dataSet2.Tables[0].Rows[rows][cols].ToString() + "*";
                            }

                        }
                        result += fullName + "*" + returnString + ClassId + "*" + batch + "#";
                        returnString = string.Empty;
                    }

                    returnString = string.Empty;
                }
            }

            return result;
        }
        catch
        {
            result = "0";
            return result;
        }
    }
    private string ExamData(string referenceMoblie, string parentOwnerMobile, string ClassId, string batch)
    {

        string result = string.Empty;
        string sh = string.Empty;
        string SqlQuery1 = string.Empty;
        DataSet dssh = new DataSet();
        DataSet dataSet = new DataSet();
        string returnString = string.Empty;
        try
        {
            string str = "Select ClassSetting_id from [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where ([Parent_MobNo]='" + parentOwnerMobile + "' or Stud_MobNo='" + parentOwnerMobile + "') and [LoginId]='" + referenceMoblie + "'";

            ds = cc.ExecuteDataset(str);
            string cid = Convert.ToString(ds.Tables[0].Rows[0]["ClassSetting_id"]);

            sh = "Select [SNO],[First_Name],[Father_Name],[Last_Name] From [DBeZeeOnlineExam].[dbo].[tblStudentRegister] Where ([Parent_MobNo]='" + parentOwnerMobile + "' or Stud_MobNo='" + parentOwnerMobile + "') and [LoginId]='" + referenceMoblie + "'";
            dssh = cc.ExecuteDataset(sh);

            if (dssh.Tables[0].Rows.Count == 0)
            {
                string sqlQuery3 = " Select [mobileNo] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] Where [RefMobileNo]='" + referenceMoblie + "'";
                DataSet dataset3 = cc.ExecuteDatasetMYCT(sqlQuery3);

                if (dataset3.Tables[0].Rows.Count > 0)
                {
                    for (int s = 0; s < dataset3.Tables[0].Rows.Count; s++)
                    {
                        string mobileColumn = dataset3.Tables[0].Rows[s][0].ToString();
                        sh = "Select [SNO],[First_Name],[Father_Name],[Last_Name] From [DBeZeeOnlineExam].[dbo].[tblStudentRegister] Where ([Parent_MobNo]='" + parentOwnerMobile + "' or Stud_MobNo='" + parentOwnerMobile + "') and [LoginId]='" + mobileColumn + "'";
                        dssh = cc.ExecuteDataset(sh);

                        string SqlQuery4 = " Select [classId],[batch],[session],[examDate],[subject],[marks],[startTime],[endTime],[ExamName],[InstituteHeadMob],[FacultyMobNo] from [tblClassAppExamSchedule] " +
                                           " Where [ownerMobNo]='" + referenceMoblie + "' and [classId]='" + ClassId + "' and [batch]='" + batch + "' and [ClassSettingId]='" + cid + "'";
                        DataSet dataSet4 = cc.ExecuteDataset(SqlQuery4);

                        if (dataSet4.Tables[0].Rows.Count > 0)
                        {
                            for (int a = 0; a < dataSet4.Tables[0].Rows.Count; a++)
                            {
                                string fullName = dssh.Tables[0].Rows[a][1].ToString() + " " + dssh.Tables[0].Rows[a][2].ToString() + " " + dssh.Tables[a].Rows[0][3].ToString();
                                string classValue = dataSet4.Tables[0].Rows[a][0].ToString();
                                string batchValue = dataSet4.Tables[0].Rows[a][1].ToString();
                                string sessionValue = dataSet4.Tables[0].Rows[a][2].ToString();
                                string examDateValue = dataSet4.Tables[0].Rows[a][3].ToString();
                                string subject = dataSet4.Tables[0].Rows[a][4].ToString();
                                string marksValue = dataSet4.Tables[0].Rows[a][5].ToString();
                                string startTimeValue = dataSet4.Tables[0].Rows[a][6].ToString();
                                string endTimeValue = dataSet4.Tables[0].Rows[a][7].ToString();
                                string examName = dataSet4.Tables[0].Rows[a][8].ToString();

                                result += fullName + "*" + classValue + "*" + batchValue + "*" + sessionValue + "*" + examDateValue + "*" + subject + "*" + marksValue + "*" + startTimeValue + "*" + endTimeValue + "*" + examName + "#";
                            }
                            break;
                        }
                        else
                        {
                            result = "2";
                            return result;
                        }
                    }
                }
                else
                {
                    result = "2";
                    return result;
                }

            }
            else
            {
                for (int a = 0; a < dssh.Tables[0].Rows.Count; a++)
                {
                    string sno = dssh.Tables[0].Rows[a][0].ToString();
                    string fullName = dssh.Tables[0].Rows[a][1].ToString() + " " + dssh.Tables[0].Rows[a][2].ToString() + " " + dssh.Tables[0].Rows[a][3].ToString();

                    SqlQuery1 = " Select [classId],[batch],[session],[examDate],[subject],[marks],[startTime],[endTime],[ExamName],[InstituteHeadMob],[FacultyMobNo] from [tblClassAppExamSchedule] " +
                               " Where [classId]='" + ClassId + "' and [batch]='" + batch + "' and [ClassSettingId]='" + cid + "'";
                    dataSet = cc.ExecuteDataset(SqlQuery1);

                    for (int rows = 0; rows < dataSet.Tables[0].Rows.Count; rows++)
                    {

                        for (int cols = 0; cols < 11; cols++)
                        {
                            if (cols != 11)
                            {
                                returnString += dataSet.Tables[0].Rows[rows][cols].ToString() + "*";
                            }

                        }
                        result += fullName + "*" + returnString + ClassId + "*" + batch + "#";
                        returnString = string.Empty;
                    }

                    returnString = string.Empty;
                }
            }
            return result;
        }
        catch
        {
            result = "0";
            return result;
        }
    }


    private string FeesData(string referenceMoblie, string parentOwnerMobile, string ClassId, string batch)
    {
        string result = string.Empty;
        string returnString = string.Empty;
        try
        {
            string sqlQuery1 = "Select [SNO],[First_Name],[Father_Name],[Last_Name] From [DBeZeeOnlineExam].[dbo].[tblStudentRegister] Where ([Parent_MobNo]='" + parentOwnerMobile + "' or Stud_MobNo='" + parentOwnerMobile + "') and [LoginId]='" + referenceMoblie + "'";
            DataSet dataSet = cc.ExecuteDataset(sqlQuery1);

            if (dataSet.Tables[0].Rows.Count == 0)
            {
                string sqlQuery3 = "Select [mobileNo] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] Where [RefMobileNo]='" + referenceMoblie + "'";
                DataSet dataset3 = cc.ExecuteDatasetMYCT(sqlQuery3);

                if (dataset3.Tables[0].Rows.Count > 0)
                {
                    for (int s = 0; s < dataset3.Tables[0].Rows.Count; s++)
                    {
                        string mobileColumn = dataset3.Tables[0].Rows[s][0].ToString();

                        string SqlQuery4 = "Select [SNO],[First_Name],[Father_Name],[Last_Name] From [DBeZeeOnlineExam].[dbo].[tblStudentRegister] Where ([Parent_MobNo]='" + parentOwnerMobile + "' or Stud_MobNo='" + parentOwnerMobile + "') and [LoginId]='" + mobileColumn + "'";
                        DataSet dataSet4 = cc.ExecuteDataset(SqlQuery4);


                        if (dataSet4.Tables[0].Rows.Count > 0)
                        {
                            for (int a = 0; a < dataSet4.Tables[0].Rows.Count; a++)
                            {
                                string sno = dataSet4.Tables[0].Rows[a][0].ToString();
                                string fullName = dataSet4.Tables[0].Rows[a][1].ToString() + " " + dataSet4.Tables[0].Rows[a][2].ToString() + " " + dataSet4.Tables[a].Rows[0][3].ToString();

                                string sqlQuery2 = " Select [feesdate],[ReceiptNo],[Amount],[Remark],[OutofTotalFees],[NextRemDate],[InstituteHeadMob],[FacultyMobNo] FROM [DBeZeeOnlineExam].[dbo].[tblStudentFees] Where [StudentRegSNO]='" + sno + "'";
                                DataSet dataSet2 = cc.ExecuteDataset(sqlQuery2);
                                for (int rows = 0; rows < dataSet2.Tables[0].Rows.Count; rows++)
                                {

                                    for (int cols = 0; cols < 8; cols++)
                                    {
                                        if (cols != 9)
                                        {
                                            returnString += dataSet2.Tables[0].Rows[rows][cols].ToString() + "*";
                                        }

                                    }
                                    result += fullName + "*" + returnString + ClassId + "*" + batch + "#";
                                    returnString = string.Empty;
                                }

                                returnString = string.Empty;

                            }
                            break;
                        }
                        else
                        {
                            result = "2";
                            return result;
                        }
                    }
                }
                else
                {
                    result = "2";
                    return result;
                }
            }
            else
            {
                for (int a = 0; a < dataSet.Tables[0].Rows.Count; a++)
                {
                    string sno = dataSet.Tables[0].Rows[a][0].ToString();
                    string fullName = dataSet.Tables[0].Rows[a][1].ToString() + " " + dataSet.Tables[0].Rows[a][2].ToString() + " " + dataSet.Tables[0].Rows[a][3].ToString();

                    string sqlQuery2 = " Select [feesdate],[ReceiptNo],[Amount],[Remark],[OutofTotalFees],[NextRemDate],[InstituteHeadMob],[FacultyMobNo] FROM [DBeZeeOnlineExam].[dbo].[tblStudentFees] Where [StudentRegSNO]='" + sno + "'";
                    DataSet dataSet2 = cc.ExecuteDataset(sqlQuery2);
                    if (dataSet2.Tables[0].Rows.Count > 0)
                    {
                        for (int rows = 0; rows < dataSet2.Tables[0].Rows.Count; rows++)
                        {

                            for (int cols = 0; cols < 8; cols++)
                            {
                                if (cols != 9)
                                {
                                    returnString += dataSet2.Tables[0].Rows[rows][cols].ToString() + "*";
                                }

                            }
                            result += fullName + "*" + returnString + ClassId + "*" + batch + "#";
                            returnString = string.Empty;
                        }


                        returnString = string.Empty;
                    }
                    else
                    {
                        return "102";
                    }
                }
            }

            return result;
        }
        catch
        {
            result = "0";
            return result;
        }
    }

    #endregion

    #region Download Student Register Information for Teacher
    [WebMethod()]
    public string DownloadStudentInformationAll(String Login_ID)
    {
        string result = string.Empty;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        string returnString = string.Empty;

        try
        {
            string str =
                       " with Event as( " +
                       " select *from( " +
                       " ( SELECT [SNO],[Adm_No],[adm_date],[DOB],[Stud_MobNo],Parent_MobNo,[StudAddress],[WardNo],[Area],[CityId],[Gender],[Pincode],[First_Name],[Last_Name],[Father_Name],[ClassSetting_id] as c,InstituteHeadMob as i,FacultyMobNo as f FROM [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where  [LoginId]='" + Login_ID + "' or InstituteHeadMob='" + Login_ID + "')as t1 " +
                       " inner join " +
                       " [DBeZeeOnlineExam].[dbo].[tblClassSetting] as t2 " +

                       " on " +
                       " t1.c=t2.ClassSetting_id " +
                       " ) " +
                       " ) ";
            str += " select [Adm_No],[adm_date],[DOB],[Stud_MobNo],[StudAddress],[WardNo],[Area],[CityId],[Gender],[Pincode],[First_Name],[Last_Name],[Father_Name],[ClassSetting_id],[Class_Id],[Session],[Batch],[Semester],[Class_Teacher],[Mob_No],[Email_Id],Parent_MobNo,AndroidClassSettingID,InstituteHeadMob,FacultyMobNo,i,f from Event";

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                {

                    for (int cols = 0; cols < 21; cols++)
                    {
                        if (cols != 20)
                        {
                            returnString += ds.Tables[0].Rows[rows][cols].ToString() + "*";
                        }
                        else
                        {
                            returnString += ds.Tables[0].Rows[rows][cols].ToString();
                        }
                    }
                    returnString += "#";
                }
            }
            return returnString;
        }
        catch
        {
            result = "0";
            return result;
        }
    }

    #endregion

    #region DownloadSettingAndStudentReg IH AND Teacher
    [WebMethod]
    public string DownloadSettingAndStudentReg(string LoginMobNo, string keyword)
    {
        int i;
        if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(LoginMobNo))
        {
            try
            {
                if (keyword.Equals("SETTING"))
                {
                    return ClassSettingData(LoginMobNo, keyword);
                }
                else if (keyword.Equals("STUDENT"))
                {
                    return StuddentData(LoginMobNo, keyword);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else
        {
            return "0";
        }
    }

    private string ClassSettingData(string LoginMobNo, string keyword)
    {
        string x1 = "Select [ClassSetting_id],[Class_Id],[Session],[Batch],[Semester],[Class_Teacher],[Mob_No],[Email_Id],[CreateDate],[Login_Id],[AndroidClassSettingID],[InstituteHeadMob],[FacultyMobNo],[StudentStatus],[SmsStatus] FROM [DBeZeeOnlineExam].[dbo].[tblClassSetting] where Login_Id='" + LoginMobNo + "'";
        DataSet ds = cc.ExecuteDataset(x1);
        string returnString = string.Empty;
        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
            {
                for (int cols = 0; cols < 15; cols++)
                {
                    if (cols != 14)
                    {
                        returnString += ds.Tables[0].Rows[rows][cols].ToString() + "*";
                    }
                    else
                    {
                        returnString += ds.Tables[0].Rows[rows][cols].ToString();
                    }
                }
                returnString += "#";
            }
        }
        else
        {
            return "0";
        }
        return returnString;

    }

    private string StuddentData(string LoginMobNo, string keyword)
    {
        string x1 = "Select [SNO],[Adm_No],[adm_date],[DOB],[Stud_MobNo],[Parent_MobNo],[StudAddress],[WardNo],[Area],[CityId],[LoginId],[Gender],[Pincode],[First_Name],[Last_Name],[Father_Name],[ClassSetting_id],[AndroidClassSettingID],[AndroidStudentSNO],[InstituteHeadMob],[FacultyMobNo] FROM [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where [LoginId]='" + LoginMobNo + "'";
        DataSet ds = cc.ExecuteDataset(x1);
        int countds = ds.Tables[0].Rows.Count;
        if (countds > 0)
        {
            for (int rows = 0; rows < countds; rows++)
            {
                sb.Append(ds.Tables[0].Rows[rows][0].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][1].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][2].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][3].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][4].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][5].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][6].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][7].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][8].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][9].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][10].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][11].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][12].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][13].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][14].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][15].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][16].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][17].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][18].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][19].ToString() + "*");
                sb.Append(ds.Tables[0].Rows[rows][20].ToString() + "#");
            }
        }
        else
        {
            return "0";
        }
        return sb.ToString();


        //string x1 = "Select [SNO],[Adm_No],[adm_date],[DOB],[Stud_MobNo],[Parent_MobNo],[StudAddress],[WardNo],[Area],[CityId],[LoginId],[Gender],[Pincode],[First_Name],[Last_Name],[Father_Name],[ClassSetting_id],[AndroidClassSettingID],[AndroidStudentSNO],[InstituteHeadMob],[FacultyMobNo] FROM [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where [LoginId]='" + LoginMobNo + "'";
        //DataSet ds = cc.ExecuteDataset(x1);
        //string returnString = string.Empty;
        //int countds = ds.Tables[0].Rows.Count;
        //string s = string.Empty;
        //if (countds > 0)
        //{
        //    for (int rows = 0; rows < countds; rows++)
        //    {
        //        //for (int cols = 0; cols < 21; cols++)
        //        //{
        //        //    if (cols != 20)
        //        //    {
        //        //        returnString += ds.Tables[0].Rows[rows][cols].ToString() + "*";
        //        //    }
        //        //    else
        //        //    {
        //        //        returnString += ds.Tables[0].Rows[rows][cols].ToString();
        //        //    }
        //        //}
        //        //returnString += "#";

        //        s = ds.Tables[0].Rows[rows][0].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][1].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][2].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][3].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][4].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][5].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][6].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][7].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][8].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][9].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][10].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][11].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][12].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][13].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][14].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][15].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][16].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][17].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][18].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][19].ToString() + "*";
        //        s += ds.Tables[0].Rows[rows][20].ToString();

        //        returnString += s + "#";
        //    }
        //}
        //else
        //{
        //    return "0";
        //}
        //return returnString;
    }

    #endregion

    #region AddMoreClass
    [WebMethod(Description = "Add New More Class")]
    public string AddMoreClass(string LoginMobNo, string IHMobNo, string Keyword)
    {
        DataSet ds1 = new DataSet();
        DataSet ds = new DataSet();
        string CID = string.Empty;
        string returnString = string.Empty;
        if (Keyword == "TEACHER")
        {
            string t = "Select firstName,lastName,firmName from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where RefMobileNo='" + IHMobNo + "' and mobileNo='" + LoginMobNo + "' and keyword='CLASSAPP'";
            ds = cc.ExecuteDatasetMYCT(t);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string t1 = "Select firstName+ ' ' +lastName,firmName from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where mobileNo='" + IHMobNo + "' and keyword='CLASSAPP'";
                ds = cc.ExecuteDatasetMYCT(t1);
                string t2 = "select ClassSetting_id from [DBeZeeOnlineExam].[dbo].[tblClassSetting] where InstituteHeadMob='" + IHMobNo + "' and Mob_No='" + LoginMobNo + "'";
                ds1 = cc.ExecuteDataset(t2);
                CID = ds1.Tables[0].Rows[0]["ClassSetting_id"].ToString();
            }
            else
            {
                return "0";
            }

            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int col = 0; col < 2; col++)
                    {
                        if (col != 2)
                        {
                            returnString += ds.Tables[0].Rows[i][col] + "*";
                        }
                        else
                        {
                            returnString += ds.Tables[0].Rows[i][col];
                        }
                    }
                }
                returnString += CID;

            }
            else
            {
                return "0";
            }


        }
        else if (Keyword == "PARENT")
        {
            string t = "Select firstName+lastName,firmName from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where RefMobileNo='" + IHMobNo + "'and mobileNo='" + LoginMobNo + "'";
            ds = cc.ExecuteDatasetMYCT(t);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string t1 = "Select firstName + ' ' + lastName,firmName from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where mobileNo='" + IHMobNo + "' and keyword='CLASSAPP'";
                ds = cc.ExecuteDatasetMYCT(t1);
                string t2 = "select * from [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where InstituteHeadMob='" + IHMobNo + "' and Parent_MobNo='" + LoginMobNo + "'";
                ds1 = cc.ExecuteDataset(t2);
            }

            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int col = 0; col < 2; col++)
                    {
                        if (col != 1)
                        {
                            returnString += ds.Tables[0].Rows[i][col] + "*";
                        }
                        else
                        {
                            returnString += ds.Tables[0].Rows[i][col];
                        }
                    }
                }
                returnString += "#";
                return returnString;
            }
            else
            {
                return "0";
            }

        }
        else if (Keyword == "STUDENT")
        {
            string t = "Select firstName,lastName,firmName from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where RefMobileNo='" + IHMobNo + "'and mobileNo='" + LoginMobNo + "'";
            ds = cc.ExecuteDatasetMYCT(t);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string t1 = "Select firstName + ' ' + lastName,firmName from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where mobileNo='" + IHMobNo + "' and keyword='CLASSAPP'";
                ds = cc.ExecuteDatasetMYCT(t1);
                string t2 = "select * from [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where InstituteHeadMob='" + IHMobNo + "' and Parent_MobNo='" + LoginMobNo + "'";
                ds1 = cc.ExecuteDataset(t2);
            }

            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int col = 0; col < 2; col++)
                    {
                        if (col != 1)
                        {
                            returnString += ds.Tables[0].Rows[i][col] + "*";
                        }
                        else
                        {
                            returnString += ds.Tables[0].Rows[i][col];
                        }
                    }
                }
                returnString += "#";
                return returnString;
            }
            else
            {
                return "0";
            }

        }
        return returnString + "#";
    }
    #endregion

    #region AddClass
    [WebMethod(Description = "Add New Class")]
    public string AddClass(string LoginMobNo, string IHMobNo, string Keyword, string st)
    {
        DataSet ds1 = new DataSet();
        DataSet ds = new DataSet();
        string CID = string.Empty;
        string mobno = string.Empty;
        string returnString = string.Empty;
        if (Keyword == "IH")
        {
            if (st == "1")
            {
                string t = "Select firstName+ ' ' +lastName,firmName,[EzeeDrugAppId],mobileNo from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where mobileNo='" + LoginMobNo + "' and keyword='CLASSAPP'";
                ds = cc.ExecuteDatasetMYCT(t);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        for (int col = 0; col < 4; col++)
                        {
                            if (col != 3)
                            {
                                returnString += ds.Tables[0].Rows[i][col] + "*";
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[i][col];
                            }
                        }
                        returnString += "*";
                    }
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                string str = "select firstName+ ' ' +lastName,firmName,[EzeeDrugAppId],mobileNo from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where RefMobileNo='" + LoginMobNo + "' and mobileNo='" + IHMobNo + "' and keyword='CLASSAPP'";
                ds = cc.ExecuteDatasetMYCT(str);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        for (int col = 0; col < 4; col++)
                        {
                            if (col != 3)
                            {
                                returnString += ds.Tables[0].Rows[i][col] + "*";
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[i][col];
                            }
                        }
                    }
                }
                else
                {
                    return "0";
                }
            }
        }

        else if (Keyword == "TEACHER")
        {
            string q = "select ClassSetting_id from [DBeZeeOnlineExam].[dbo].[tblClassSetting] where [Login_Id]='" + IHMobNo + "' and [Mob_No]='" + LoginMobNo + "'";
            ds = cc.ExecuteDataset(q);

            if (ds.Tables[0].Rows.Count > 0)
            {
                CID = ds.Tables[0].Rows[0]["ClassSetting_id"].ToString();
                string t1 = "Select firstName+ ' ' +lastName,firmName,mobileNo from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where mobileNo='" + IHMobNo + "' and keyword='CLASSAPP'";
                ds1 = cc.ExecuteDatasetMYCT(t1);
                mobno = ds1.Tables[0].Rows[0]["mobileNo"].ToString();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        for (int col = 0; col < 2; col++)
                        {
                            if (col != 2)
                            {
                                returnString += ds1.Tables[0].Rows[i][col] + "*";
                            }
                            else
                            {
                                returnString += ds1.Tables[0].Rows[i][col];
                            }
                        }
                    }
                    returnString += CID + "*" + mobno;
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                string t2 = "select ClassSetting_id from [DBeZeeOnlineExam].[dbo].[tblClassSetting] where InstituteHeadMob='" + IHMobNo + "' and Mob_No='" + LoginMobNo + "'";
                ds1 = cc.ExecuteDataset(t2);
                string tt = "Select firstName+ ' ' +lastName,firmName,mobileNo from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where mobileNo='" + IHMobNo + "' and keyword='CLASSAPP'";
                ds = cc.ExecuteDatasetMYCT(tt);
                mobno = ds.Tables[0].Rows[0]["mobileNo"].ToString();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    for (int C = 0; C < ds1.Tables[0].Rows.Count; C++)
                    {
                        CID += ds1.Tables[0].Rows[C]["ClassSetting_id"].ToString() + "*";
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            for (int col = 0; col < 2; col++)
                            {
                                if (col != 2)
                                {
                                    returnString += ds.Tables[0].Rows[i][col] + "*";
                                }
                                else
                                {
                                    returnString += ds.Tables[0].Rows[i][col];
                                }
                            }
                        }
                    }
                    returnString += CID + "*" + mobno;
                }
                else
                {
                    return "0";
                }
            }
        }
        else if (Keyword == "PARENT")
        {
            string t2 = "select [ClassSetting_id] from [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where [LoginId]='" + IHMobNo + "' and Parent_MobNo='" + LoginMobNo + "'";
            ds1 = cc.ExecuteDataset(t2);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                string t1 = "Select firstName + ' ' + lastName,firmName,mobileNo from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where mobileNo='" + IHMobNo + "' and keyword='CLASSAPP'";
                ds = cc.ExecuteDatasetMYCT(t1);
                mobno = ds.Tables[0].Rows[0]["mobileNo"].ToString();
                CID = ds1.Tables[0].Rows[0]["ClassSetting_id"].ToString();
            }

            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int col = 0; col < 2; col++)
                    {
                        if (col != 2)
                        {
                            returnString += ds.Tables[0].Rows[i][col] + "*";
                        }
                        else
                        {
                            returnString += ds.Tables[0].Rows[i][col];
                        }
                    }
                }
                returnString += CID + "*" + mobno;
            }
            else
            {
                return "0";
            }
        }
        else if (Keyword == "STUDENT")
        {

            string t2 = "select [ClassSetting_id] from [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where [LoginId]='" + IHMobNo + "' and [Stud_MobNo]='" + LoginMobNo + "'";
            ds1 = cc.ExecuteDataset(t2);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                string t1 = "Select firstName + ' ' + lastName,firmName,mobileNo from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where mobileNo='" + IHMobNo + "' and keyword='CLASSAPP'";
                ds = cc.ExecuteDatasetMYCT(t1);
                CID = ds1.Tables[0].Rows[0]["ClassSetting_id"].ToString();
                mobno = ds.Tables[0].Rows[0]["mobileNo"].ToString();
            }

            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int col = 0; col < 2; col++)
                    {
                        if (col != 2)
                        {
                            returnString += ds.Tables[0].Rows[i][col] + "*";
                        }
                        else
                        {
                            returnString += ds.Tables[0].Rows[i][col];
                        }
                    }
                }
                returnString += CID + "*" + mobno;
            }
            else
            {
                return "0";
            }
        }
        return returnString + "*" + LoginMobNo + "#";
    }
    #endregion


    [WebMethod()]
    public string Testing(String Login_ID)
    {
        string result = string.Empty;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        string returnString = string.Empty;
        int count = 1;
        try
        {
            string str =
                       " with Event as( " +
                       " select *from( " +
                       " ( SELECT [SNO],[Adm_No],[adm_date],[DOB],[Stud_MobNo],[StudAddress],[WardNo],[Area],[CityId],[Gender],[Pincode],[First_Name],[Last_Name],[Father_Name],[ClassSetting_id] as c FROM [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where  [LoginId]='" + Login_ID + "')as t1 " +
                       " inner join " +
                       " [DBeZeeOnlineExam].[dbo].[tblClassSetting] as t2 " +

                       " on " +
                       " t1.c=t2.ClassSetting_id " +
                       " ) " +
                       " ) ";
            str += " select [Adm_No],[adm_date],[DOB],[Stud_MobNo],[StudAddress],[WardNo],[Area],[CityId],[Gender],[Pincode],[First_Name],[Last_Name],[Father_Name],[ClassSetting_id],[Class_Id],[Session],[Batch],[Semester],[Class_Teacher],[Mob_No],[Email_Id] from Event";
            ds = cc.ExecuteDataset(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                {
                    returnString += count++;
                    for (int cols = 0; cols < 21; cols++)
                    {
                        if (cols != 21)
                        {
                            returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                        }
                        else
                        {
                            returnString += ds.Tables[0].Rows[rows][cols].ToString();
                        }
                    }
                    returnString += "#";
                }
            }


            string str1 = "Select [mobileNo] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] Where [RefMobileNo]='" + Login_ID + "'";
            ds1 = cc.ExecuteDatasetMYCT(str1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int s = 0; s < ds1.Tables[0].Rows.Count; s++)
                {
                    string mobileColumn = Convert.ToString(ds1.Tables[0].Rows[s][0]);
                    string str3 =
                   " with Event as( " +
                   " select *from( " +
                   " ( SELECT [SNO],[Adm_No],[adm_date],[DOB],[Stud_MobNo],[StudAddress],[WardNo],[Area],[CityId],[Gender],[Pincode],[First_Name],[Last_Name],[Father_Name],[ClassSetting_id] as c FROM [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where [LoginId]='" + mobileColumn + "')as t1 " +
                   " inner join " +
                   " [DBeZeeOnlineExam].[dbo].[tblClassSetting] as t2 " +

                   " on " +
                   " t1.c=t2.ClassSetting_id " +
                   " ) " +
                   " ) ";
                    str3 += " select [Adm_No],[adm_date],[DOB],[Stud_MobNo],[StudAddress],[WardNo],[Area],[CityId],[Gender],[Pincode],[First_Name],[Last_Name],[Father_Name],[ClassSetting_id],[Class_Id],[Session],[Batch],[Semester],[Class_Teacher],[Mob_No],[Email_Id] from Event";
                    ds2 = cc.ExecuteDataset(str3);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        for (int rows = 0; rows < ds2.Tables[0].Rows.Count; rows++)
                        {
                            returnString += count++;
                            for (int cols = 0; cols < 21; cols++)
                            {
                                if (cols != 21)
                                {
                                    returnString += "*" + ds2.Tables[0].Rows[rows][cols].ToString();
                                }
                                else
                                {
                                    returnString += ds2.Tables[0].Rows[rows][cols].ToString();
                                }
                            }
                            returnString += "#";
                        }
                    }
                }
            }
            return returnString;
        }
        catch
        {
            result = "0";
            return result;
        }
    }


    #region Get Student TestDetails
    [WebMethod(Description = "Method to Get Student TestDetails...")]
    public string GetStudentTestDetails(string referenceMoblie, string parentOwnerMobile)
    {
        string result = string.Empty;

        try
        {
            string sqlQuery1 = "Select [SNO],[First_Name],[Father_Name],[Last_Name] From [DBeZeeOnlineExam].[dbo].[tblStudentRegister] Where [Parent_MobNo]='" + parentOwnerMobile + "' and [LoginId]='" + referenceMoblie + "'";
            DataSet dataSet = cc.ExecuteDataset(sqlQuery1);

            if (dataSet.Tables[0].Rows.Count == 0)
            {
                string sqlQuery3 = "Select [mobileNo] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] Where [RefMobileNo]='" + referenceMoblie + "'";
                DataSet dataset3 = cc.ExecuteDatasetMYCT(sqlQuery3);

                if (dataset3.Tables[0].Rows.Count > 0)
                {
                    for (int s = 0; s < dataset3.Tables[0].Rows.Count; s++)
                    {
                        string mobileColumn = dataset3.Tables[0].Rows[s][0].ToString();

                        string SqlQuery4 = "Select [SNO],[First_Name],[Father_Name],[Last_Name] From [DBeZeeOnlineExam].[dbo].[tblStudentRegister] Where [Parent_MobNo]='" + parentOwnerMobile + "' and [LoginId]='" + mobileColumn + "'";
                        DataSet dataSet4 = cc.ExecuteDataset(SqlQuery4);

                        if (dataSet4.Tables[0].Rows.Count > 0)
                        {
                            for (int a = 0; a < dataSet4.Tables[0].Rows.Count; a++)
                            {
                                string sno = dataSet4.Tables[0].Rows[a][0].ToString();
                                string fullName = dataSet4.Tables[0].Rows[a][1].ToString() + " " + dataSet4.Tables[0].Rows[a][2].ToString() + " " + dataSet4.Tables[a].Rows[0][3].ToString();

                                string sqlQuery2 = "Select [TestNo],[TestTopic],[TestName],[OutofMark],[ObtainedMark],[Testdate] FROM [DBeZeeOnlineExam].[dbo].[tblAndroidTestDetails] Where [StudentRegSNO]='" + sno + "'";
                                DataSet dataSet2 = cc.ExecuteDataset(sqlQuery2);

                                result += fullName + "*" + dataSet2.Tables[0].Rows[0][0].ToString() + "*" + dataSet2.Tables[0].Rows[0][1].ToString() + "*" + dataSet2.Tables[0].Rows[0][2].ToString() + "*" + dataSet2.Tables[0].Rows[0][3].ToString() + "*" + dataSet2.Tables[0].Rows[0][4].ToString() + "*" + dataSet2.Tables[0].Rows[0][5].ToString() + "#";
                            }
                            break;
                        }
                    }
                }
                else
                {
                    result = "2";
                    return result;
                }
            }
            else
            {
                for (int a = 0; a < dataSet.Tables[0].Rows.Count; a++)
                {
                    if (dataSet.Tables[0].Rows[a][0].ToString() != "" && dataSet.Tables[0].Rows[a][1].ToString() != "" && dataSet.Tables[0].Rows[a][2].ToString() != "" && dataSet.Tables[0].Rows[a][0].ToString() != "")
                    {
                        string sno = dataSet.Tables[0].Rows[a][0].ToString();
                        string fullName = dataSet.Tables[0].Rows[a][1].ToString() + " " + dataSet.Tables[0].Rows[a][2].ToString() + " " + dataSet.Tables[0].Rows[a][3].ToString();

                        string sqlQuery2 = "Select [TestNo],[TestTopic],[TestName],[OutofMark],[ObtainedMark],[Testdate] FROM [DBeZeeOnlineExam].[dbo].[tblAndroidTestDetails] Where [StudentRegSNO]='" + sno + "'";
                        DataSet dataSet2 = cc.ExecuteDataset(sqlQuery2);
                        if (dataSet2.Tables[0].Rows.Count > 0)
                        {
                            result += fullName + "*" + dataSet2.Tables[0].Rows[0][0].ToString() + "*" + dataSet2.Tables[0].Rows[0][1].ToString() + "*" + dataSet2.Tables[0].Rows[0][2].ToString() + "*" + dataSet2.Tables[0].Rows[0][3].ToString() + "*" + dataSet2.Tables[0].Rows[0][4].ToString() + "*" + dataSet2.Tables[0].Rows[0][5].ToString() + "#";
                        }
                    }
                }
            }

            return result;
        }
        catch (Exception ex)
        {
            result = "0";
            return ex.ToString();
        }
    }
    #endregion

    #region Get Student Fees Paid Details
    [WebMethod(Description = "Method to Get student Fees Details....")]
    public string GetStudentFeesDetails(string referenceMoblie, string parentOwnerMobile)
    {
        string result = string.Empty;

        try
        {
            string sqlQuery1 = "Select [SNO],[First_Name],[Father_Name],[Last_Name] From [DBeZeeOnlineExam].[dbo].[tblStudentRegister] Where [Parent_MobNo]='" + parentOwnerMobile + "' and [LoginId]='" + referenceMoblie + "'";
            DataSet dataSet = cc.ExecuteDataset(sqlQuery1);

            if (dataSet.Tables[0].Rows.Count == 0)
            {
                string sqlQuery3 = "Select [mobileNo] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] Where [RefMobileNo]='" + referenceMoblie + "'";
                DataSet dataset3 = cc.ExecuteDatasetMYCT(sqlQuery3);

                if (dataset3.Tables[0].Rows.Count > 0)
                {
                    for (int s = 0; s < dataset3.Tables[0].Rows.Count; s++)
                    {
                        string mobileColumn = dataset3.Tables[0].Rows[s][0].ToString();

                        string SqlQuery4 = "Select [SNO],[First_Name],[Father_Name],[Last_Name] From [DBeZeeOnlineExam].[dbo].[tblStudentRegister] Where [Parent_MobNo]='" + parentOwnerMobile + "' and [LoginId]='" + mobileColumn + "'";
                        DataSet dataSet4 = cc.ExecuteDataset(SqlQuery4);


                        if (dataSet4.Tables[0].Rows.Count > 0)
                        {
                            for (int a = 0; a < dataSet4.Tables[0].Rows.Count; a++)
                            {
                                string sno = dataSet4.Tables[0].Rows[a][0].ToString();
                                string fullName = dataSet4.Tables[0].Rows[a][1].ToString() + " " + dataSet4.Tables[0].Rows[a][2].ToString() + " " + dataSet4.Tables[0].Rows[a][3].ToString();

                                string sqlQuery2 = " Select [feesdate],[ReceiptNo],[Amount],[Remark],[OutofTotalFees],[NextRemDate] FROM [DBeZeeOnlineExam].[dbo].[tblStudentFees] Where [StudentRegSNO]='" + sno + "'";
                                DataSet dataSet2 = cc.ExecuteDataset(sqlQuery2);

                                result += fullName + "*" + dataSet2.Tables[0].Rows[0][0].ToString() + "*" + dataSet2.Tables[0].Rows[0][1].ToString() + "*" + dataSet2.Tables[0].Rows[0][2].ToString() + "*" + dataSet2.Tables[0].Rows[0][3].ToString() + "*" + dataSet2.Tables[0].Rows[0][4].ToString() + "*" + dataSet2.Tables[0].Rows[0][5].ToString() + "#";

                            }
                            break;
                        }
                    }
                }
                else
                {
                    result = "2";
                    return result;
                }
            }
            else
            {
                for (int a = 0; a < dataSet.Tables[0].Rows.Count; a++)
                {
                    string sno = dataSet.Tables[0].Rows[a][0].ToString();
                    string fullName = dataSet.Tables[0].Rows[a][1].ToString() + " " + dataSet.Tables[0].Rows[a][2].ToString() + " " + dataSet.Tables[0].Rows[a][3].ToString();

                    string sqlQuery2 = " Select [feesdate],[ReceiptNo],[Amount],[Remark],[OutofTotalFees],[NextRemDate] FROM [DBeZeeOnlineExam].[dbo].[tblStudentFees] Where [StudentRegSNO]='" + sno + "'";
                    DataSet dataSet2 = cc.ExecuteDataset(sqlQuery2);

                    result += fullName + "*" + dataSet2.Tables[0].Rows[0][0].ToString() + "*" + dataSet2.Tables[0].Rows[0][1].ToString() + "*" + dataSet2.Tables[0].Rows[0][2].ToString() + "*" + dataSet2.Tables[0].Rows[0][3].ToString() + "*" + dataSet2.Tables[0].Rows[0][4].ToString() + "*" + dataSet2.Tables[0].Rows[0][5].ToString() + "#";
                }
            }

            return result;
        }
        catch
        {
            result = "0";
            return result;
        }
    }

    #endregion

    #region Insert Method for Exam Schedule

    [WebMethod(Description = "Insert Data of Exam Schedule")]
    public string InsertExamSchedule(string insertExamSchedule)
    {
        string result = string.Empty;

        if (insertExamSchedule.ToString() != null)
        {
            string[] stringArray = insertExamSchedule.Split(new char[] { '#', '*' });
            if ((stringArray.Length % 12) == 0)
            {
                AllClassAppMethods objClassApp = new AllClassAppMethods();
                for (int i = 0; i < stringArray.Length; i += 12)
                {
                    result += objClassApp.InsertExamScheduleFunction(stringArray[i], stringArray[i + 1], stringArray[i + 2], Convert.ToString(stringArray[i + 3]), stringArray[i + 4], stringArray[i + 5], stringArray[i + 6], stringArray[i + 7], stringArray[i + 8], stringArray[i + 9], stringArray[i + 10], stringArray[i + 11]) + "*";
                }
                return result.Substring(0, result.Length - 1);
            }
            else
            {
                return "WrongString";
            }
        }
        return result;
    }

    #endregion

    #region Insert Method for DailyInstruction
    [WebMethod(Description = "Insert Data of DailyInstruction")]
    public string InsertDailyInstruction(string insertDailyInst)
    {
        string result = string.Empty;

        if (insertDailyInst.ToString() != null)
        {
            string[] stringArray = insertDailyInst.Split(new char[] { '#', '*' });
            AllClassAppMethods objClassApp = new AllClassAppMethods();
            for (int i = 1; i < stringArray.Length; i += 11)
            {
                result += objClassApp.InsertDailyInstruction(stringArray[i], stringArray[i + 1], stringArray[i + 2], stringArray[i + 3], stringArray[i + 4], stringArray[i + 5], stringArray[i + 6], stringArray[i + 7], stringArray[i + 8], stringArray[i + 9]) + "*";
            }
            return result.Substring(0, result.Length - 1);
        }
        return result;

    }
    #endregion

    #region Insert For Events
    [WebMethod(Description = "Insert Data of Events")]
    public string InsertEvents(string insertEvents)
    {
        string result = string.Empty;
        if (insertEvents.ToString() != null)
        {
            string[] stringArray = insertEvents.Split(new char[] { '#', '*' });
            AllClassAppMethods objClassApp = new AllClassAppMethods();
            for (int i = 1; i < stringArray.Length; i += 12)
            {
                result += objClassApp.InsertEvents(stringArray[i], stringArray[i + 1], stringArray[i + 2], stringArray[i + 3], stringArray[i + 4], stringArray[i + 5], stringArray[i + 6], stringArray[i + 7], stringArray[i + 8], stringArray[i + 9], stringArray[i + 10]) + "*";
            }
            return result.Substring(0, result.Length - 1);

        }
        return result;
    }

    #endregion

    #region Insert For SubjectNotes
    [WebMethod(Description = "Insert Data of SubjectNotes")]
    public string InsertSubjectNotes(string insertNotes)
    {

        string result = string.Empty;
        if (insertNotes.ToString() != null)
        {
            string[] stringArray = insertNotes.Split(new char[] { '#', '*' });
            AllClassAppMethods objClassApp = new AllClassAppMethods();
            for (int i = 1; i < stringArray.Length; i += 13)
            {
                result += objClassApp.InsertSubjectNotes(stringArray[i], stringArray[i + 1], stringArray[i + 2], stringArray[i + 3], stringArray[i + 4], stringArray[i + 5], stringArray[i + 6], stringArray[i + 7], stringArray[i + 8], stringArray[i + 9], stringArray[i + 10], stringArray[i + 11]) + "*";
            }
            return result.Substring(0, result.Length - 1);
        }
        return result;
    }
    #endregion

    #region Get Exam Schedule Details
    [WebMethod(Description = "Get Exam Schedule Details...")]
    public string GetExamScheduleDetails(string classId, string batch, string referenceMoblie)
    {
        string result = string.Empty;
        try
        {
            string SqlQuery1 = " Select [classId],[batch],[session],[examDate],[subject],[marks],[startTime],[endTime],[ExamName] from [tblClassAppExamSchedule] " +
                               " Where [LoginId]='" + referenceMoblie + "' and [classId]='" + classId + "'";
            DataSet dataSet = cc.ExecuteDataset(SqlQuery1);

            if (dataSet.Tables[0].Rows.Count == 0)
            {
                string sqlQuery3 = " Select [mobileNo] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] Where [RefMobileNo]='" + referenceMoblie + "'";
                DataSet dataset3 = cc.ExecuteDatasetMYCT(sqlQuery3);

                if (dataset3.Tables[0].Rows.Count > 0)
                {
                    for (int s = 0; s < dataset3.Tables[0].Rows.Count; s++)
                    {
                        string mobileColumn = dataset3.Tables[0].Rows[s][0].ToString();

                        string SqlQuery4 = " Select [classId],[batch],[session],[examDate],[subject],[marks],[startTime],[endTime],[ExamName] from [tblClassAppExamSchedule] " +
                                           " Where [LoginId]='" + mobileColumn + "' and [classId]='" + classId + "'";
                        DataSet dataSet4 = cc.ExecuteDataset(SqlQuery4);

                        if (dataSet4.Tables[0].Rows.Count > 0)
                        {
                            for (int a = 0; a < dataSet4.Tables[0].Rows.Count; a++)
                            {
                                string classValue = dataSet4.Tables[0].Rows[a][0].ToString();
                                string batchValue = dataSet4.Tables[0].Rows[a][1].ToString();
                                string sessionValue = dataSet4.Tables[0].Rows[a][2].ToString();
                                string examDateValue = dataSet4.Tables[0].Rows[a][3].ToString();
                                string subject = dataSet4.Tables[0].Rows[a][4].ToString();
                                string marksValue = dataSet4.Tables[0].Rows[a][5].ToString();
                                string startTimeValue = dataSet4.Tables[0].Rows[a][6].ToString();
                                string endTimeValue = dataSet4.Tables[0].Rows[a][7].ToString();
                                string examName = dataSet4.Tables[0].Rows[a][8].ToString();

                                result += classValue + "*" + batchValue + "*" + sessionValue + "*" + examDateValue + "*" + subject + "*" + marksValue + "*" + startTimeValue + "*" + endTimeValue + "*" + examName + "#";
                            }
                            break;
                        }
                    }
                }
                else
                {
                    result = "2";
                    return result;
                }

            }
            else
            {
                for (int a = 0; a < dataSet.Tables[0].Rows.Count; a++)
                {
                    string classValue = dataSet.Tables[0].Rows[a][0].ToString();
                    string batchValue = dataSet.Tables[0].Rows[a][1].ToString();
                    string sessionValue = dataSet.Tables[0].Rows[a][2].ToString();
                    string examDateValue = dataSet.Tables[0].Rows[a][3].ToString();
                    string subject = dataSet.Tables[0].Rows[a][4].ToString();
                    string marksValue = dataSet.Tables[0].Rows[a][5].ToString();
                    string startTimeValue = dataSet.Tables[0].Rows[a][6].ToString();
                    string endTimeValue = dataSet.Tables[0].Rows[a][7].ToString();
                    string examName = dataSet.Tables[0].Rows[a][8].ToString();

                    result += classValue + "*" + batchValue + "*" + sessionValue + "*" + examDateValue + "*" + subject + "*" + marksValue + "*" + startTimeValue + "*" + endTimeValue + "*" + examName + "#";
                }
            }
            return result;
        }
        catch
        {
            result = "0";
            return result;
        }
    }

    #endregion

    #region Get Daily Instruction
    [WebMethod(Description = "Get Daily Instruction Details......")]
    public string GetDailyInstruction(string typeofInstruction, string classId, string batch, string referenceMoblie)
    {
        string result = string.Empty;
        string sql = string.Empty;
        string str = string.Empty;
        DataSet ds4 = new DataSet();
        DataSet ds = new DataSet();
        try
        {
            if (typeofInstruction == "1")
            {
                sql = "Select [typeofInstruction],[date],[instructionDetails],[teacherMobNo],[ownerMobNo],[classId],,[LoginId],[Session] from [tblClassAppDailyInstruction" +
                                      "where  ownerMobNo='" + referenceMoblie + "'";
            }
            else if (typeofInstruction == "2")
            {
                sql = "Select [typeofInstruction],[date],[instructionDetails],[teacherMobNo],[ownerMobNo],[classId],,[LoginId],[Session] from [tblClassAppDailyInstruction" +
                       "where classId='" + classId + "' and ownerMobNo='" + referenceMoblie + "'";
            }
            else
            {
                sql = "Select [typeofInstruction],[date],[instructionDetails],[teacherMobNo],[ownerMobNo],[classId],,[LoginId],[Session] from [tblClassAppDailyInstruction" +
                                       "where classId='" + classId + "' and batch='" + batch + "' and ownerMobNo='" + referenceMoblie + "'";
            }

            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count == 0)
            {
                string sqlQuery3 = " Select [mobileNo] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] Where [RefMobileNo]='" + referenceMoblie + "'";
                DataSet dataset3 = cc.ExecuteDatasetMYCT(sqlQuery3);

                if (dataset3.Tables[0].Rows.Count > 0)
                {
                    for (int s = 0; s < dataset3.Tables[0].Rows.Count; s++)
                    {
                        string mobileColumn = dataset3.Tables[0].Rows[s][0].ToString();

                        if (typeofInstruction == "1")
                        {
                            str = "Select [typeofInstruction],[date],[instructionDetails],[teacherMobNo],[ownerMobNo],[classId],,[LoginId],[Session] from [tblClassAppDailyInstruction" +
                                                   "where  ownerMobNo='" + mobileColumn + "'";
                        }
                        else if (typeofInstruction == "2")
                        {
                            str = "Select [typeofInstruction],[date],[instructionDetails],[teacherMobNo],[ownerMobNo],[classId],,[LoginId],[Session] from [tblClassAppDailyInstruction" +
                                    "where classId='" + classId + "' and ownerMobNo='" + mobileColumn + "'";
                        }
                        else
                        {
                            str = "Select [typeofInstruction],[date],[instructionDetails],[teacherMobNo],[ownerMobNo],[classId],,[LoginId],[Session] from [tblClassAppDailyInstruction" +
                                                  "where classId='" + classId + "' and batch='" + batch + "' and ownerMobNo='" + mobileColumn + "'";
                        }
                        ds4 = cc.ExecuteDataset(str);

                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            for (int a = 0; a < ds4.Tables[0].Rows.Count; a++)
                            {
                                string InstructionValue = ds4.Tables[0].Rows[a][0].ToString();
                                string dateValue = ds4.Tables[0].Rows[a][1].ToString();
                                string InstDetailsValue = ds4.Tables[0].Rows[a][2].ToString();
                                string teacherValue = ds4.Tables[0].Rows[a][3].ToString();
                                string ownerValue = ds4.Tables[0].Rows[a][4].ToString();
                                string classValue = ds4.Tables[0].Rows[a][5].ToString();
                                string loginValue = ds4.Tables[0].Rows[a][6].ToString();
                                string SessionValue = ds4.Tables[0].Rows[a][7].ToString();

                                result += InstructionValue + "*" + dateValue + "*" + InstDetailsValue + "*" + teacherValue + "*" + ownerValue + "*" + classValue + "*" + loginValue + "*" + SessionValue + "#";
                            }
                            break;
                        }
                    }
                }
                else
                {
                    result = "2";
                    return result;
                }
            }
            else
            {
                for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
                {
                    string InstructionValue = ds.Tables[0].Rows[a][0].ToString();
                    string dateValue = ds.Tables[0].Rows[a][1].ToString();
                    string InstDetailsValue = ds.Tables[0].Rows[a][2].ToString();
                    string teacherValue = ds.Tables[0].Rows[a][3].ToString();
                    string ownerValue = ds.Tables[0].Rows[a][4].ToString();
                    string classValue = ds.Tables[0].Rows[a][5].ToString();
                    string loginValue = ds.Tables[0].Rows[a][6].ToString();
                    string SessionValue = ds.Tables[0].Rows[a][7].ToString();

                    result += InstructionValue + "*" + dateValue + "*" + InstDetailsValue + "*" + teacherValue + "*" + ownerValue + "*" + classValue + "*" + loginValue + "*" + SessionValue + "#";
                }
            }
            return result;

        }
        catch
        {
            result = "0";
            return result;
        }
    }
    #endregion

    #region Get Event Details
    [WebMethod(Description = "Get Event Details.....")]
    public string GetEventsDetails(string classId, string batch, string referenceMoblie)
    {
        string result = string.Empty;
        DataSet ds2 = new DataSet();
        DataSet ds1 = new DataSet();
        try
        {
            string str = "Select [typeofEvents],[eventDetails],[date],[topic],[teacherMobNo],[ownerMobNo],[classId],[batch],[LoginId],[Session] From [tblClassAppEvents]" +
                         " Where [LoginId]='" + referenceMoblie + "' and [classId]='" + classId + "'";
            DataSet ds = cc.ExecuteDataset(str);

            if (ds.Tables[0].Rows.Count == 0)
            {
                string sql = " Select [mobileNo] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] Where [RefMobileNo]='" + referenceMoblie + "'";
                ds1 = cc.ExecuteDatasetMYCT(sql);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    for (int s = 0; s < ds1.Tables[0].Rows.Count; s++)
                    {
                        string mobileColumn = ds1.Tables[0].Rows[s][0].ToString();

                        string str1 = "Select [typeofEvents],[eventDetails],[date],[topic],[teacherMobNo],[ownerMobNo],[classId],[batch],[LoginId],[Session] From [tblClassAppEvents]" +
                            " Where [LoginId]='" + mobileColumn + "' and [classId]='" + classId + "'";
                        ds2 = cc.ExecuteDataset(str1);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            for (int a = 0; a < ds2.Tables[0].Rows.Count; a++)
                            {
                                string TypeValue = ds2.Tables[0].Rows[a][0].ToString();
                                string EventValue = ds2.Tables[0].Rows[a][1].ToString();
                                string dateValue = ds2.Tables[0].Rows[a][2].ToString();
                                string TopicValue = ds2.Tables[0].Rows[a][3].ToString();
                                string teacherValue = ds2.Tables[0].Rows[a][4].ToString();
                                string ownernoValue = ds2.Tables[0].Rows[a][5].ToString();
                                string classValue = ds2.Tables[0].Rows[a][6].ToString();
                                string batchValue = ds2.Tables[0].Rows[a][7].ToString();
                                string loginValue = ds2.Tables[0].Rows[a][8].ToString();
                                string sessionValue = ds2.Tables[0].Rows[a][9].ToString();

                                result += TypeValue + "*" + EventValue + "*" + dateValue + "*" + TopicValue + "*" + teacherValue + "*" + ownernoValue + "*" + classId + "*" + batch + "*" + loginValue + "*" + sessionValue + "#";
                            }
                            break;
                        }
                    }
                }
                else
                {
                    result = "2";
                    return result;
                }
            }
            else
            {
                for (int a = 0; a < ds1.Tables[0].Rows.Count; a++)
                {
                    string TypeValue = ds1.Tables[0].Rows[a][0].ToString();
                    string EventValue = ds1.Tables[0].Rows[a][1].ToString();
                    string dateValue = ds1.Tables[0].Rows[a][2].ToString();
                    string TopicValue = ds1.Tables[0].Rows[a][3].ToString();
                    string teacherValue = ds1.Tables[0].Rows[a][4].ToString();
                    string ownernoValue = ds1.Tables[0].Rows[a][5].ToString();
                    string classValue = ds1.Tables[0].Rows[a][6].ToString();
                    string batchValue = ds1.Tables[0].Rows[a][7].ToString();
                    string loginValue = ds1.Tables[0].Rows[a][8].ToString();
                    string sessionValue = ds1.Tables[0].Rows[a][9].ToString();

                    result += TypeValue + "*" + EventValue + "*" + dateValue + "*" + TopicValue + "*" + teacherValue + "*" + ownernoValue + "*" + classId + "*" + batch + "*" + loginValue + "*" + sessionValue + "#";

                }
            }
            return result;
        }
        catch
        {
            result = "0";
            return result;
        }
    }
    #endregion

    #region Get For Subject Notes
    [WebMethod(Description = "Get for Subject Notes Details.....")]
    public string GetSubjectNotes(string classId, string batch, string referenceMoblie)
    {

        string result = string.Empty;
        try
        {
            string SqlQuery1 = " Select [date],[chapter],[topic],[subjectNotes],[subject],[teacherMobNo],[ownerMobNo],[classId],[batch],[Session] from [tblClassAppSubjectNotes] " +
                               " Where [ownerMobNo]='" + referenceMoblie + "' and [classId]='" + classId + "'";
            DataSet dataSet = cc.ExecuteDataset(SqlQuery1);

            if (dataSet.Tables[0].Rows.Count == 0)
            {
                string sqlQuery3 = " Select [mobileNo] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] Where [RefMobileNo]='" + referenceMoblie + "'";
                DataSet dataset3 = cc.ExecuteDatasetMYCT(sqlQuery3);

                if (dataset3.Tables[0].Rows.Count > 0)
                {
                    for (int s = 0; s < dataset3.Tables[0].Rows.Count; s++)
                    {
                        string mobileColumn = dataset3.Tables[0].Rows[s][0].ToString();

                        string SqlQuery4 = " Select [date],[chapter],[topic],[subjectNotes],[subject],[teacherMobNo],[ownerMobNo],[classId],[batch],[Session] from [tblClassAppSubjectNotes] " +
                               " Where [ownerMobNo]='" + mobileColumn + "' and [classId]='" + classId + "'";
                        DataSet dataSet4 = cc.ExecuteDataset(SqlQuery4);

                        if (dataSet4.Tables[0].Rows.Count > 0)
                        {
                            for (int a = 0; a < dataSet4.Tables[0].Rows.Count; a++)
                            {
                                string dateValue = dataSet4.Tables[0].Rows[a][0].ToString();
                                string chapterValue = dataSet4.Tables[0].Rows[a][1].ToString();
                                string topicValue = dataSet4.Tables[0].Rows[a][2].ToString();
                                string subjectNotesValue = dataSet4.Tables[0].Rows[a][3].ToString();
                                string subjectValue = dataSet4.Tables[0].Rows[a][4].ToString();
                                string teacherMobNoValue = dataSet4.Tables[0].Rows[a][5].ToString();
                                string ownerMobNoValue = dataSet4.Tables[0].Rows[a][6].ToString();
                                string classIdValue = dataSet4.Tables[0].Rows[a][7].ToString();
                                string batchValue = dataSet4.Tables[0].Rows[a][8].ToString();
                                string SessionValue = dataSet4.Tables[0].Rows[a][9].ToString();

                                result += dateValue + "*" + chapterValue + "*" + topicValue + "*" + subjectNotesValue + "*" + subjectValue + "*" + teacherMobNoValue + "*" + ownerMobNoValue + "*" + classIdValue + "*" + batchValue + "*" + SessionValue + "#";
                            }
                            break;
                        }
                    }
                }
                else
                {
                    result = "2";
                    return result;
                }

            }
            else
            {
                for (int a = 0; a < dataSet.Tables[0].Rows.Count; a++)
                {
                    string dateValue = dataSet.Tables[0].Rows[a][0].ToString();
                    string chapterValue = dataSet.Tables[0].Rows[a][1].ToString();
                    string topicValue = dataSet.Tables[0].Rows[a][2].ToString();
                    string subjectNotesValue = dataSet.Tables[0].Rows[a][3].ToString();
                    string subjectValue = dataSet.Tables[0].Rows[a][4].ToString();
                    string teacherMobNoValue = dataSet.Tables[0].Rows[a][5].ToString();
                    string ownerMobNoValue = dataSet.Tables[0].Rows[a][6].ToString();
                    string classIdValue = dataSet.Tables[0].Rows[a][7].ToString();
                    string batchValue = dataSet.Tables[0].Rows[a][8].ToString();
                    string SessionValue = dataSet.Tables[0].Rows[a][9].ToString();

                    result += dateValue + "*" + chapterValue + "*" + topicValue + "*" + subjectNotesValue + "*" + subjectValue + "*" + teacherMobNoValue + "*" + ownerMobNoValue + "*" + classIdValue + "*" + batchValue + "*" + SessionValue + "#";
                }
            }
            return result;
        }
        catch
        {
            result = "0";
            return result;
        }
    }
    #endregion

    public string load(string UID, string underusermobno)
    {
        if ((LoginId_PK == "ADMIN")) //ref loginid
        {
            returnstatus = Adduser(UID, underusermobno);
        }
        else
        {
            returnstatus = AddNewUser(UID, underusermobno);
        }
        return returnstatus;
    }

    public string Adduser(string UID, string underusermobno)
    {
        try
        {

            string sql = "select id from Admin_SubUser where uid='" + insertID + "'";
            string id1 = cc.ExecuteScalar(sql);
            if (!(id1 == null || id1 == ""))
            {
                string Sql = "update  Admin_SubUser set loginid='" + Login_Uid + "',loginname='" + LoginId_PK + "',uid=" + insertID + ",UnderUsername='" + underusermobno + "',roleid=3,rolename='Class-Admin',DT='" + System.DateTime.Now + "',R1='" + LoginId_PK + "',companyid='" + CompanyId + "' where id=" + id1 + " ";

                int flag = cc.ExecuteNonQuery(Sql);
                if (flag >= 1)
                {
                    returnstatus = Convert.ToString(flag);
                    returnstatus = "2";
                }
            }
            else
            {
                string Sql = "insert into Admin_SubUser(loginid,loginname,uid,UnderUsername,roleid,rolename,DT,R1,companyid)" +
                              "values('" + Login_Uid + "','" + LoginId_PK + "'," + insertID + ",'" + underusermobno + "',3,'Class-Admin','" + System.DateTime.Now + "','" + LoginId_PK + "','" + CompanyId + "')";
                int flag = cc.ExecuteNonQuery(Sql);
                if (flag >= 1)
                {
                    returnstatus = Convert.ToString(flag);
                }
            }
        }
        catch
        {
        }
        return returnstatus;
    }

    private string AddNewUser(string UID, string underusermobno)
    {
        if ((LoginId_PK != null && parentrole == ""))
        {
            string sql1 = "select id from login where Loginid='" + LoginId_PK + "'";
            LoginId_PK = cc.ExecuteScalar(sql1);
        }
        else
        {
            info12();
        }

        string R1 = initial;

        string sql12 = "select id from Admin_SubUser where UnderUsername='" + LoginId_PK + "'";
        string id = cc.ExecuteScalar(sql12);

        if (id == "")
        {

            string Sql = "insert into Admin_SubUser(loginid,loginname,uid,UnderUsername,roleid,rolename,DT,R1,R2,R3,R4,R5,R6,companyid)" +
                       "values('" + Login_Uid + "','" + LoginId_PK + "'," + insertID + ",'" + underusermobno + "',3,'Class-Admin','" + System.DateTime.Now + "','" + R1 + "','" + R2 + "','" + R3 + "','" + R4 + "','" + R5 + "','" + R6 + "'," + CompanyId + ")";
            int flag = cc.ExecuteNonQuery(Sql);
            if (flag >= 1)
            {
                returnstatus = Convert.ToString(flag);
            }
        }
        else
        {
            string id1 = "";
            string sql = "select id from Admin_SubUser where uid='" + insertID + "'";  //insert id =Uid =752
            id1 = cc.ExecuteScalar(sql);
            if (!(id1 == null || id1 == ""))
            {
                returnstatus = Convert.ToString(id1);
            }
            else
            {
                string Sql = "insert Admin_SubUser(loginid,loginname,uid,UnderUsername,roleid,rolename,DT,R1,R2,R3,R4,R5,R6,companyid)" +
                       "values('" + Login_Uid + "','" + LoginId_PK + "'," + insertID + ",'" + underusermobno + "',3,'Class-Admin','" + System.DateTime.Now + "','" + R1 + "','" + R2 + "','" + R3 + "','" + R4 + "','" + R5 + "','" + R6 + "'," + CompanyId + ")";
                int flag = cc.ExecuteNonQuery(Sql);
                if (flag >= 1)
                {
                    returnstatus = Convert.ToString(flag);
                }
            }
        }

        return returnstatus;
    }

    private void info12()
    {
        string sqlfetch = "select uid,loginid,loginname,UnderUsername,roleid,rolename,DT,R2,R3,R4,R5,R6,companyid  from Admin_SubUser where UnderUsername='" + LoginId_PK + "'"; //ref loginid
        DataSet ds1 = cc.ExecuteDataset(sqlfetch);
        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        {
            usrRole = Convert.ToString(ds1.Tables[0].Rows[0]["rolename"]);
            userid = Convert.ToString(ds1.Tables[0].Rows[0]["UnderUsername"]);
            RoleId = Convert.ToString(ds1.Tables[0].Rows[0]["roleid"]);
            R2 = Convert.ToString(ds1.Tables[0].Rows[0]["R2"]);
            if (R2 == "")
            {
                R2 = userid;
                break;
            }

            R3 = Convert.ToString(ds1.Tables[0].Rows[0]["R3"]);
            if (R3 == "")
            {
                R3 = userid;
                break;
            }

            R4 = Convert.ToString(ds1.Tables[0].Rows[0]["R4"]);
            if (R4 == "")
            {
                R4 = userid;
                break;
            }
            R5 = Convert.ToString(ds1.Tables[0].Rows[0]["R5"]);
            if (R5 == "")
            {
                R5 = userid;
                break;
            }
            R6 = Convert.ToString(ds1.Tables[0].Rows[0]["R6"]);
            if (R6 == "")
            {
                R6 = userid;
                break;
            }
        }
        initial = "Admin";
    }

    [WebMethod]
    public string DailyInstruction(string referenceMoblie, string parentOwnerMobile, string ClassId, string batch)
    {
        string result = string.Empty;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds0 = new DataSet();
        string returnString = string.Empty;
        string c = string.Empty;
        string q = string.Empty;
        int count = 1;
        try
        {

            string s1 = " select [typeofInstruction],[date],[instructionDetails],[teacherMobNo],[Session],[InstituteHeadMob],[FacultyMobNo] from tblClassAppDailyInstruction where typeofInstruction='1' and [InstituteHeadMob] = '" + referenceMoblie + "' " +
                        " select [typeofInstruction],classId,[date],[instructionDetails],[teacherMobNo],[Session],[InstituteHeadMob],[FacultyMobNo] from tblClassAppDailyInstruction where [classId]='" + ClassId + "' and [InstituteHeadMob] = '" + referenceMoblie + "' and typeofInstruction NOT IN ('1')";
            ds0 = cc.ExecuteDataset(s1);


            string SqlQuery1 = "Select [SNO],[First_Name],[Father_Name],[Last_Name] From [DBeZeeOnlineExam].[dbo].[tblStudentRegister] Where ([Parent_MobNo]='" + parentOwnerMobile + "' or Stud_MobNo='" + parentOwnerMobile + "') and [LoginId]='" + referenceMoblie + "'";
            DataSet dataSet = cc.ExecuteDataset(SqlQuery1);


            if (ds0.Tables[0].Rows.Count == 0)
            {
                string str3 = "Select ClassSetting_id [DBeZeeOnlineExam].[dbo].[tblStudentRegister] where ([Parent_MobNo]='" + parentOwnerMobile + "' or Stud_MobNo='" + parentOwnerMobile + "') and [LoginId]='" + referenceMoblie + "'";
                ds2 = cc.ExecuteDataset(str3);
                c = Convert.ToString(ds2.Tables[0].Rows[0]["ClassSetting_id"]);
                q = "select [typeofInstruction],[date],[instructionDetails],[teacherMobNo],[Session],[InstituteHeadMob],[FacultyMobNo] from tblClassAppDailyInstruction where ([classId]='" + ClassId + "' and typeofInstruction='1') OR typeofInstruction='1' OR typeofInstruction='2'";
                ds3 = cc.ExecuteDataset(q);
                if (ds3.Tables[0].Rows.Count > 0)
                {

                    for (int rows = 0; rows < ds3.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;
                        for (int cols = 0; cols < 7; cols++)
                        {
                            if (cols != 7)
                            {
                                returnString += "*" + ds3.Tables[0].Rows[rows][cols].ToString();
                            }
                            else
                            {
                                returnString += ds3.Tables[0].Rows[rows][cols].ToString();
                            }
                        }
                        returnString += "#";
                    }
                    return returnString;
                }
                else
                {
                    result = "2";
                    return result;
                }
            }
            else
            {
                s1 = "select [typeofInstruction],[date],[instructionDetails],[teacherMobNo],[Session],[InstituteHeadMob],[FacultyMobNo] from tblClassAppDailyInstruction where ([classId]='" + ClassId + "' and [batch]='" + batch + "' OR typeofInstruction='1') OR typeofInstruction='1' and [ClassSettingId]='" + cid + "' ";
                ds0 = cc.ExecuteDataset(s1);

                if (ds0.Tables[0].Rows.Count > 0)
                {

                    for (int rows = 0; rows < ds0.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;
                        for (int cols = 0; cols < 7; cols++)
                        {
                            if (cols != 7)
                            {
                                returnString += "*" + ds0.Tables[0].Rows[rows][cols].ToString();
                            }
                            else
                            {
                                returnString += ds0.Tables[0].Rows[rows][cols].ToString();
                            }
                        }
                        returnString += "#";
                    }

                }
            }
            return returnString;
        }

        catch (Exception ex)
        {
            //result = "0";
            //return result;
            throw ex;
        }
    }


    #region GCMInsertMethodRegKey
    [WebMethod]
    public string GCMInsertRegkey(string RegKey, string MobileNo)
    {
        string str = "insert into tbl_ClassApp_GCMRegkey([RegistrationKey],[MobileNo])values('" + RegKey + "','" + MobileNo + "')";
        int result = cc.ExecuteNonQuery(str);

        return "1";
    }
    #endregion

    #region GCMInsertMethodString
    [WebMethod]
    public string GCMInsertStrString(string MobileNo, string strString, string UrMobileNo)
    {
        string str = "insert into tbl_ClassApp_GCMString([MobileNo],[StrString],[UrMobileNo])values('" + MobileNo + "','" + strString + "','" + UrMobileNo + "')";
        int result = cc.ExecuteNonQuery(str);

        return "1";
    }
    #endregion

    #region METHOD TO GET ITEM MASTER FOR NOTES DETAILS
    [WebMethod(Description = "METHOD TO GET ITEM MASTER FOR NOTES DETAILS")]
    public XmlDocument GetItemMaster()
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        DataSet dataset = new DataSet();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adaper = new SqlDataAdapter();

        try
        {
            cmd.CommandText = "uspGetItemMaster";
            cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.CommandType = CommandType.StoredProcedure;

            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();

            adaper.SelectCommand = cmd;
            adaper.Fill(dataset);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NoRecord"] = "106";
                dt.Rows.Add(dr);
                dataset.Tables.Add(dt);
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
            if (cmd.Connection.State == ConnectionState.Open)
                cmd.Connection.Close();
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            dataset.Tables.Add(dt);
            xmldoc = new XmlDataDocument(dataset);
            XmlElement xmlelement = xmldoc.DocumentElement;
        }
        return xmldoc;
    }
    #endregion

    #region METHOD TO GET NOTES DETAILS ON BASIS OF CLASS,SUBJECT,CHAPTER AND TOPIC
    [WebMethod(Description = "METHOD TO GET NOTES DETAILS ON BASIS OF CLASS,SUBJECT,CHAPTER AND TOPIC")]
    public XmlDocument GetNotesDetails(int classId, int subjectId, int chapterId, int topicId)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        DataSet dataset = new DataSet();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adaper = new SqlDataAdapter();

        try
        {
            cmd.CommandText = "uspGetNotesDtails";
            cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@classID", SqlDbType.Int).Value = classId;
            cmd.Parameters.Add("@subjectID", SqlDbType.Int).Value = subjectId;
            cmd.Parameters.Add("@chapterID", SqlDbType.Int).Value = chapterId;
            cmd.Parameters.Add("@topicID", SqlDbType.Int).Value = topicId;

            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();

            adaper.SelectCommand = cmd;
            adaper.Fill(dataset);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NoRecord"] = "106";
                dt.Rows.Add(dr);
                dataset.Tables.Add(dt);
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
            if (cmd.Connection.State == ConnectionState.Open)
                cmd.Connection.Close();
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            dataset.Tables.Add(dt);
            xmldoc = new XmlDataDocument(dataset);
            XmlElement xmlelement = xmldoc.DocumentElement;
        }
        return xmldoc;
    }
    #endregion

    #region METHOD TO INSERT SHARE NOTES TO STUDENTS
    [WebMethod(Description = "METHOD TO INSERT SHARE NOTES TO STUDENTS")]
    public int ShareNotes(string studentMobNumber, int uniqueId, int classId, string batch, string ownerMobNumber, string refMobNumber)
    {
        try
        {
            string[] studNumber = studentMobNumber.Split('|');
            int count = 0;

            var temp = new List<string>();
            foreach (var s in studNumber)
            {
                if (!string.IsNullOrEmpty(s))
                    temp.Add(s);
            }
            studNumber = temp.ToArray();

            for (int i = 0; i < studNumber.Length; i++)
            {
                string sqlQuery1 = "SELECT [ShareId] FROM [tblShareNotes] WHERE [StudentMobNumbers]='" + studNumber[i] + "' AND [UniqueId]=" + uniqueId + "";
                DataSet dset = cc.ExecuteDataset(sqlQuery1);
                if (dset.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    string sqlQuery = " INSERT INTO [tblShareNotes] ([StudentMobNumbers],[UniqueId],[ClassId],[Batch],[OwnerMobNumber],[RefMobNumber]) " +
                                      " VALUES ('" + studNumber[i] + "'," + uniqueId + "," + classId + ",'" + batch + "','" + ownerMobNumber + "','" + refMobNumber + "')";
                    cc.ExecuteNonQuery(sqlQuery);
                }
                count++;
            }
            return count;
        }
        catch
        {
            return 105;
        }
    }

    #endregion

    #region METHOD GET NOTES DETAILS AS PER PARENT NUMBER
    [WebMethod(Description = "METHOD GET NOTES DETAILS AS PER PARENT NUMBER")]
    public string GetNotesDetailsToParent(string parentNumber)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        string returnstring = string.Empty;
        DataSet dataset = new DataSet();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adaper = new SqlDataAdapter();
        string uniqueId = string.Empty;

        try
        {
            string sqlQuery = "SELECT DISTINCT [UniqueId] FROM [tblShareNotes] WHERE [StudentMobNumbers]='" + parentNumber + "'";
            dataset = cc.ExecuteDataset(sqlQuery);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
                {
                    uniqueId = uniqueId + "," + dataset.Tables[0].Rows[i][0].ToString();
                }
                uniqueId = uniqueId.Substring(1);

                string sqlQuery1 = "SELECT [NoteID],[AppNoteID],[NoteHeading],[NoteDetails],[NoteType],[TypeofExamID],[TypeofExamName],[ClassID],[ClassName],[SubjectID],[SubjectName],[ChapterID],[ChapterName],[TopicID],[TopicName],[CreaterMobileNumber],[SettingID],[PublicationID],[PublicationName],[UniqueID],[InsertedBy],[InsertDate],[ModifyBy],[ModifyDate],[LoginNumber] FROM [tblNotesDetails] WHERE [UniqueID] IN (" + uniqueId + ")";
                DataSet ds = cc.ExecuteDataset(sqlQuery1);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //xmldoc = new XmlDataDocument(ds);
                    //XmlElement xmlelement = xmldoc.DocumentElement;

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        returnstring += ds.Tables[0].Rows[i][0].ToString() + "*" + ds.Tables[0].Rows[i][1].ToString() + "*" + ds.Tables[0].Rows[i][2].ToString() + "*" + ds.Tables[0].Rows[i][3].ToString() + "*" + ds.Tables[0].Rows[i][4].ToString() + "*" + ds.Tables[0].Rows[i][5].ToString() + "*" + ds.Tables[0].Rows[i][6].ToString() + "*" + ds.Tables[0].Rows[i][7].ToString() + "*" + ds.Tables[0].Rows[i][8].ToString() + "*" + ds.Tables[0].Rows[i][9].ToString() + "*" + ds.Tables[0].Rows[i][10].ToString() +
                                  "*" + ds.Tables[0].Rows[i][11].ToString() + "*" + ds.Tables[0].Rows[i][12].ToString() + "*" + ds.Tables[0].Rows[i][13].ToString() + "*" + ds.Tables[0].Rows[i][14].ToString() + "*" + ds.Tables[0].Rows[i][15].ToString() + "*" + ds.Tables[0].Rows[i][16].ToString() + "*" + ds.Tables[0].Rows[i][17].ToString() + "*" + ds.Tables[0].Rows[i][18].ToString() + "*" + ds.Tables[0].Rows[i][19].ToString() + "*" + ds.Tables[0].Rows[i][20].ToString() + "*" + ds.Tables[0].Rows[i][21].ToString() + "*" + ds.Tables[0].Rows[i][22].ToString() +
                                  "*" + ds.Tables[0].Rows[i][23].ToString() + "*" + ds.Tables[0].Rows[i][24].ToString() + "#";
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
        return returnstring.ToString();
    }
    #endregion

    #region METHOD TO GET EVALUATION RECORDS AS PER INSTITUTE HEAD AND FACULTY
    [WebMethod(Description = "METHOD TO GET EVALUATION RECORDS AS PER INSTITUTE HEAD AND FACULTY")]

    public XmlDocument GetEvaluationsIH(string instituteHeadMobNo, string keyword, string classId, string section, string facultyMobNo, string date)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        DataSet dataset = new DataSet();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adaper = new SqlDataAdapter();
        string sqlQuery1 = "";
        //string sqlQuery2 = "";

        try
        {
            if (keyword == "ATTENDANCE")
            {
                //sqlQuery2 = "SELECT [ClassSetting_id] FROM [tblClassSetting] WHERE [InstituteHeadMob]='" + instituteHeadMobNo + "' AND [Class_Id]='" + classId + "' AND [Batch]='" + section + "'";
                sqlQuery1 = "SELECT [Present],[attenDate],[ClassSetting_id],[StudentRegSNO],[FacultyMobNo],[InstituteHeadMob] FROM [tblAttendance] WHERE [FacultyMobNo]='" + facultyMobNo + "' AND [InstituteHeadMob]='" + instituteHeadMobNo + "'";
            }
            if (keyword == "TEST")
            {
                sqlQuery1 = " SELECT [TestNo],[TestTopic],[TestName],[OutofMark],[ObtainedMark],[Testdate],[StudentRegSNO],[ClassSetting_id],[FacultyMobNo],[InstituteHeadMob] " +
                            " FROM [tblAndroidTestDetails] WHERE [FacultyMobNo]='" + facultyMobNo + "' AND [InstituteHeadMob]='" + instituteHeadMobNo + "'";
            }
            if (keyword == "FEES")
            {
                sqlQuery1 = " SELECT [StudentName],[feesdate],[ReceiptNo],[Amount],[Remark],[ClassSetting_id],[StudentRegSNO],[OutofTotalFees],[NextRemDate],[InstituteHeadMob],[FacultyMobNo] " +
                            " FROM [tblStudentFees] WHERE [InstituteHeadMob]='" + instituteHeadMobNo + "' AND [FacultyMobNo]='" + facultyMobNo + "'";
            }
            if (keyword == "EXAM SCHEDULE")
            {
                sqlQuery1 = " SELECT [classId],[batch],[examDate],[subject],[marks],[startTime],[endTime],[session],[ClassSettingId],[ExamName],[InstituteHeadMob],[FacultyMobNo] " +
                            " FROM [tblClassAppExamSchedule] WHERE [InstituteHeadMob]='" + instituteHeadMobNo + "' AND [FacultyMobNo]='" + facultyMobNo + "' AND [classId]='" + classId + "' AND [batch]='" + section + "'";
            }
            if (keyword == "DAILY INSTRUCTION")
            {
                sqlQuery1 = " SELECT [typeofInstruction],[date],[instructionDetails],[classId],[batch],[ClassSettingId],[Session],[InstituteHeadMob],[FacultyMobNo] " +
                            " FROM [tblClassAppDailyInstruction] WHERE [InstituteHeadMob]='" + instituteHeadMobNo + "' AND [FacultyMobNo]='" + facultyMobNo + "' AND [classId]='" + classId + "' AND [batch]='" + section + "'";
            }
            if (keyword == "SUBJECT NOTES")
            {
                sqlQuery1 = " SELECT [date],[chapter],[topic],[subjectNotes],[subject],[classId],[batch],[Session],[ClassSettingId],[InstituteHeadMob],[FacultyMobNo] " +
                            " FROM [tblClassAppSubjectNotes] WHERE [FacultyMobNo]='" + facultyMobNo + "' AND [InstituteHeadMob]='" + instituteHeadMobNo + "' AND [classId]='" + classId + "' AND [batch]='" + section + "'";
            }
            if (keyword == "EVENTS")
            {
                sqlQuery1 = " SELECT [typeofEvents],[eventDetails],[date],[topic],[classId],[batch],[Session],[ClassSettingId],[InstituteHeadMob],[FacultyMobNo] " +
                            " FROM [tblClassAppEvents] WHERE [InstituteHeadMob]='" + instituteHeadMobNo + "' AND [FacultyMobNo]='" + facultyMobNo + "' AND [classId]='" + classId + "' AND [batch]='" + section + "'";
            }

            DataSet ds = cc.ExecuteDataset(sqlQuery1);

            if (ds.Tables[0].Rows.Count > 0)
            {
                xmldoc = new XmlDataDocument(ds);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NoRecord"] = "106";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                xmldoc = new XmlDataDocument(ds);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
            xmldoc = new XmlDataDocument(ds);
            XmlElement xmlelement = xmldoc.DocumentElement;
        }
        return xmldoc;
    }

    #endregion

    #region METHOD TO SAVE MAIN ADMIN UNDER INSTITUTE HEAD

    [WebMethod(Description = "METHOD TO SAVE MAIN ADMIN UNDER INSTITUTE HEAD")]
    public string InsertMainAdmin(string firstName, string lastName, string mainAdminNumber, string instituteHeadNumber, string designation, int isActive)
    {
        try
        {
            string sqlQuery1 = "SELECT * FROM [tblClassAppMainAdmin] WHERE [MobileNumber]='" + mainAdminNumber + "' AND [InstituteHeadNumber]='" + instituteHeadNumber + "'";
            DataSet dsMainAdmin = cc.ExecuteDataset(sqlQuery1);

            if (dsMainAdmin.Tables[0].Rows.Count > 0)
            {
                string sqlQuery2 = "UPDATE [tblClassAppMainAdmin] SET [FirstName]='" + firstName + "',[LastName]='" + lastName + "',[MobileNumber]='" + mainAdminNumber + "',[InstituteHeadNumber]='" + instituteHeadNumber + "',[Designation]='" + designation + "',[IsActive]='" + isActive + "' WHERE [MobileNumber]='" + mainAdminNumber + "' AND [InstituteHeadNumber]='" + instituteHeadNumber + "'";
                cc.ExecuteNonQuery(sqlQuery2);
            }
            else
            {
                string sqlQuery = " INSERT INTO [tblClassAppMainAdmin] ([FirstName],[LastName],[MobileNumber],[InstituteHeadNumber],[Designation],[IsActive]) " +
                                  " VALUES ('" + firstName + "','" + lastName + "','" + mainAdminNumber + "','" + instituteHeadNumber + "','" + designation + "'," + isActive + ")";
                cc.ExecuteNonQuery(sqlQuery);
            }
            return "106";
        }
        catch
        { return "105"; }
    }

    #endregion

    #region METHOD TO RETURN ALL ADMIN UNDER INSTITUTE HEAD.
    [WebMethod(Description = "METHOD TO RETURN ALL ADMIN UNDER INSTITUTE HEAD")]
    public string GetMainAdminData(string instituteHeadNumber)
    {
        string returnstring = string.Empty;
        int count = 1;
        try
        {
            string sqlquery = "SELECT [FirstName],[LastName],[MobileNumber],[InstituteHeadNumber],[Designation],[IsActive] FROM [tblClassAppMainAdmin] WHERE InstituteHeadNumber = '" + instituteHeadNumber + "'";
            DataSet dsmainAdmin = cc.ExecuteDataset(sqlquery);

            if (dsmainAdmin.Tables[0].Rows.Count > 0)
            {
                for (int rows = 0; rows < dsmainAdmin.Tables[0].Rows.Count; rows++)
                {
                    returnstring += count++;
                    for (int cols = 0; cols < 6; cols++)
                    {
                        if (cols != 6)
                        {
                            returnstring += "*" + dsmainAdmin.Tables[0].Rows[rows][cols].ToString();
                        }
                        else
                        {
                            returnstring += dsmainAdmin.Tables[0].Rows[rows][cols].ToString();
                        }
                    }
                    returnstring += "#";
                }
            }
            return returnstring;
        }
        catch (Exception ex)
        {
            return "105";
        }

    }
    #endregion

    #region METHOD TO INSERT NOTES DETAILS THROUGH CLASSAPP
    [WebMethod(Description = "INSERT NOTES DETAILS THROUGH CLASSAPP")]
    public string InsertNotesThroughClassApp(string classid, string subjectid, string chapterid, string topicid, string notesHeading, string notesDetails, string insertBy)
    {
        string SqlQry = string.Empty;
        int Uid = 0;
        DataSet ds = new DataSet();
        int res;
        try
        {
            SqlQry = "Select [UniqueID] from [tblNotesDetails] where [ClassID]='" + classid + "' and [SubjectID]='" + subjectid + "' and [ChapterID]='" + chapterid + "' and [TopicID]='" + topicid + "'";
            string id = Convert.ToString(cc.ExecuteScalar(SqlQry));
            if (id == "NULL" || id == "")
            {
                SqlQry = "select max(UniqueID)+1 from [tblNotesDetails]";
                Uid = Convert.ToInt32(cc.ExecuteScalar(SqlQry));
            }
            else
            {
                Uid = Convert.ToInt32(id);
            }

            SqlQry = "insert into [tblNotesDetails]([NoteHeading],[NoteDetails],[ClassID],[SubjectID],[ChapterID],[TopicID],[UniqueID],[InsertedBy],[InsertDate])" +
                      "values('" + notesHeading + "','" + notesDetails + "','" + classid + "','" + subjectid + "','" + chapterid + "','" + topicid + "','" + Uid + "','" + insertBy + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
            res = cc.ExecuteNonQuery(SqlQry);
        }
        catch
        {
            return "0";
        }
        return "1";
    }
    #endregion

    #region METHOD TO INSERT,DOWNLOAD WORD DETAILS
    //[WebMethod(Description = "Insert Word Details")]
    //public string InsertWordDetail(string originalWord, string class_id, string subject_id, string chapte_id, string topic_id, string lang_type, string insertby, string Class, string subject, string chapter, string topic)
    //{
    //    string SqlQry = string.Empty; string ServerId = string.Empty;
    //    DataSet ds = new DataSet();
    //    int Uid = 0;
    //    int res = 0;
    //    try
    //    {
    //        string sqlqry = "select [UniqueId] from [tblWordDetails] where [Classid]='" + class_id + "' and [Subjectid]='" + subject_id + "' and [Chapterid]='" + chapte_id + "' and [Topicid]='" + topic_id + "'";
    //        string id = Convert.ToString(cc.ExecuteScalar(sqlqry));
    //        if (id == "NULL" || id == "")
    //        {
    //            SqlQry = "select max(UniqueId)+1 from [tblWordDetails]";
    //            Uid = Convert.ToInt32(cc.ExecuteScalar(SqlQry));
    //        }
    //        else
    //        {
    //            Uid = Convert.ToInt32(id);
    //        }

    //        SqlQry = "Select [id],[OriganalWord] from [tblWordDetails] where [OriganalWord]=N'" + originalWord.Trim() + "' and [Classid]='" + class_id + "' and [Subjectid]='" + subject_id + "' and [Chapterid]='" + chapte_id + "' and [Topicid]='" + topic_id + "'";
    //        ds = cc.ExecuteDataset(SqlQry);

    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            // string serId = Convert.ToString(ds.Tables[0].Rows[0]["id"]);
    //            SqlQry = "Update [tblWordDetails] set [OriganalWord]=N'" + originalWord + "' where [OriganalWord]=N'" + originalWord.Trim() + "' and [Classid]='" + class_id + "' and [Subjectid]='" + subject_id + "' and [Chapterid]='" + chapte_id + "' and [Topicid]='" + topic_id + "'";
    //            res = cc.ExecuteNonQuery(SqlQry);

    //            string SQL = "Select [id] from [tblWordDetails] where [OriganalWord]=N'" + originalWord.Trim() + "' and [Classid]='" + class_id + "' and [Subjectid]='" + subject_id + "' and [Chapterid]='" + chapte_id + "' and [Topicid]='" + topic_id + "'";
    //            string updateServerid = Convert.ToString(cc.ExecuteScalar(SQL));

    //            return updateServerid;
    //        }
    //        else
    //        {
    //            SqlQry = "insert into [tblWordDetails]([OriganalWord],[Classid],[Class],[Subjectid],[Subject],[Chapterid],[Chapter],[Topicid],[Topic],[Languagetype],[CreatedBy],[CreatedDate],[UniqueId])" + //
    //                     "values(N'" + originalWord.Trim() + "','" + class_id + "','" + Class + "','" + subject_id + "','" + subject + "','" + chapte_id + "','" + chapter + "','" + topic_id + "','" + topic + "',N'" + lang_type + "','" + insertby + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'," + Uid + ")"; //
    //            res = Convert.ToInt32(cc.ExecuteNonQuery(SqlQry));

    //            SqlQry = "Select Max([id]) From [tblWordDetails]";
    //            ServerId = Convert.ToString(cc.ExecuteScalar(SqlQry));
    //            return ServerId;
    //        }
    //    }
    //    catch
    //    {
    //        return "0";
    //    }

    //}

    //#region METHOD TO INSERT,DOWNLOAD WORD DETAILS

    [WebMethod(Description = "Insert Word Details")]
    public string InsertWordDetail(string Word, string similarwordID, string oppositewordID, string appparentID, string class_id, string subject_id, string chapte_id, string topic_id, string lang_type, string insertby, string imei) //, string uses) string Class, string subject, string chapter, string topic,
    {
        string SqlQry = string.Empty; string ServerId = string.Empty;
        string serverid = string.Empty; string classname = string.Empty;
        DataSet ds = new DataSet(); string subjectname = string.Empty;
        int Uid = 0; string chaptername = string.Empty;
        int res = 0; string topicname = string.Empty;
        try
        {
            //SqlQry ="Select [Id] from [tblNewWordDetails] Where [Word]=N'"+ Word +"' ";  // and 
            //DataSet Ds=cc.ExecuteDataset(SqlQry);
            //if(Ds.Tables[0].Rows.Count > 0)
            //{
            //    SqlQry = "Update [tblNewWordDetails] set [Word]=N'"+ Word +"',[Similarword_Id]='"+ similarwordID +"' ,[Oppositeword_Id]='"+ oppositewordID +"',[AppParentId]='"+ appparentID +"',[LangId]='"+ lang_type +"',[ClassId]='"+ class_id +"',[ClassName]='"+ Class +"' " +
            //              " ,[SubjectId]='"+ subject_id +"',[SubjectName]='"+ subject +"',[ChapterId]='"+ chapte_id +"',[ChapterName]='"+ chapter +"',[TopicId]='"+ topic_id +"',[TopicName]='"+ topic +"',[ModifyBy]='"+ insertby +"',[ModifyDate]='"+ System.DateTime.Now.ToString("yyyy-MM-dd") +"'" +
            //              "Where [Id]="+ Ds.Tables[0].Rows[0][0].ToString() +"";
            //    res = cc.ExecuteNonQuery(SqlQry);

            //    return "1";
            //}
            //else{

            string Sql = "select [Name] from [tblItemValue] where [ItemValueId]='" + class_id + "' " +
                        "select [Name] from [tblItemValue] where [ItemValueId]='" + subject_id + "' " +
                        "select [Name] from [tblItemValue] where [ItemValueId]='" + chapte_id + "' " +
                        "select [Name] from [tblItemValue] where [ItemValueId]='" + topic_id + "'";
            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                classname = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                subjectname = Convert.ToString(ds.Tables[1].Rows[0]["Name"]);
                chaptername = Convert.ToString(ds.Tables[2].Rows[0]["Name"]);
                topicname = Convert.ToString(ds.Tables[3].Rows[0]["Name"]);
            }

            //if (uses == "0")
            //{
            string sqlqry = "select [UniqueId] from [tblNewWordDetails] where [Classid]='" + class_id + "' and [Subjectid]='" + subject_id + "' and [Chapterid]='" + chapte_id + "' and [Topicid]='" + topic_id + "'";
            string id = Convert.ToString(cc.ExecuteScalar(sqlqry));
            if (id == "NULL" || id == "")
            {
                SqlQry = "select max(UniqueId)+1 from [tblNewWordDetails]";
                Uid = Convert.ToInt32(cc.ExecuteScalar(SqlQry));
            }
            else
            {
                Uid = Convert.ToInt32(id);
            }

            //for (int i = 0; i < DataString.Length; i++)
            //{
            if (appparentID == "-1")
            {
                SqlQry = "Insert into [tblNewworddetails]([Word],[Similarword_Id],[Oppositeword_Id],[AppParentId],[LangId],[UniqueId],[ClassId],[ClassName],[SubjectId],[SubjectName],[ChapterId],[ChapterName],[TopicId],[TopicName],[CreatedBy],[CreatedDate],[Imei])" +
                         "Values(N'" + Word + "','" + similarwordID + "','" + oppositewordID + "','" + appparentID + "','" + lang_type + "','" + Uid + "','" + class_id + "','" + classname + "','" + subject_id + "','" + subjectname + "','" + chapte_id + "','" + chaptername + "','" + topic_id + "','" + topicname + "','" + insertby + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + imei + "')";
                res = cc.ExecuteNonQuery(SqlQry);

                string sql = "select max(Id) from [tblNewworddetails] WHERE [AppParentId]='-1'";
                ServerId = cc.ExecuteScalar(sql);

                return ServerId;
            }
            else
            {
                //  }

                SqlQry = "Insert into [tblNewworddetails]([Word],[Similarword_Id],[Oppositeword_Id],[AppParentId],[LangId],[UniqueId],[ClassId],[ClassName],[SubjectId],[SubjectName],[ChapterId],[ChapterName],[TopicId],[TopicName],[CreatedBy],[CreatedDate],[Imei])" +
                        "Values(N'" + Word + "','" + similarwordID + "','" + oppositewordID + "','" + appparentID + "','" + lang_type + "','" + Uid + "','" + class_id + "','" + classname + "','" + subject_id + "','" + subjectname + "','" + chapte_id + "','" + chaptername + "','" + topic_id + "','" + topicname + "','" + insertby + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + imei + "')";
                res = cc.ExecuteNonQuery(SqlQry);

                string sql = "select max(Id) from [tblNewworddetails] WHERE [AppParentId]='-1'";
                ServerId = cc.ExecuteScalar(sql);

                string Sql11 = "select max(Id) from [tblNewworddetails] WHERE [AppParentId]='" + appparentID + "'";
                serverid = cc.ExecuteScalar(Sql11);

                if (ServerId != "")
                {
                    if (similarwordID != "")
                    {
                        sqlqry = "Update [tblNewworddetails] set [Similarword_Id]='" + ServerId + "' Where [Id]='" + serverid + "'";
                        res = cc.ExecuteNonQuery(sqlqry);
                    }
                    else
                    {
                        sqlqry = "Update [tblNewworddetails] set [Oppositeword_Id]='" + ServerId + "' Where [Id]='" + serverid + "'";
                        res = cc.ExecuteNonQuery(sqlqry);
                    }
                }

                string sql1 = "select max(Id) from [tblNewworddetails]";
                ServerId = cc.ExecuteScalar(sql1);

                return ServerId;
            }
            //}
            //else
            //{
            //    string sqlqry = "select [UniqueId] from [tblUses] where [ClassId]='" + class_id + "' and [SubjectId]='" + subject_id + "' and [ChapterId]='" + chapte_id + "' and [TopicId]='" + topic_id + "'";
            //    string id = Convert.ToString(cc.ExecuteScalar(sqlqry));
            //    if (id == "NULL" || id == "")
            //    {
            //        SqlQry = "select max(UniqueId)+1 from [tblUses]";
            //        Uid = Convert.ToInt32(cc.ExecuteScalar(SqlQry));
            //    }
            //    else
            //    {
            //        Uid = Convert.ToInt32(id);
            //    }

            //    SqlQry = "Insert into [tblUses]([Word],[Word_Discription],[ClassId],[ClassName],[SubjectId],[SubjectName],[ChapterId],[ChapterName],[TopicId],[TopicName],[LangType],[UniqueId],[CreatedBy],[CreatedDate],[Imei])" +
            //             " Values(N'" + Word + "',N'" + uses + "'," + class_id + ",'" + Class + "'," + subject_id + ",'" + subject + "'," + chapte_id + ",'" + chapter + "'," + topic_id + ",'" + topic + "','" + lang_type + "','" + Uid + "','" + insertby + "','" +
            //              System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + imei + "')";
            //    res = cc.ExecuteNonQuery(SqlQry);

            //    return "1";
            //}
            //}
        }
        catch
        {
            return "0";
        }

    }

    [WebMethod(Description = "Insert Uses Details")]
    public string InsertusesDetail(string Word, string usesId, string appparentID, string class_id, string subject_id, string chapte_id, string topic_id, string lang_type, string insertby, string Class, string subject, string chapter, string topic, string imei)
    {
        string SqlQry = string.Empty; string ServerId = string.Empty;
        string serverid = string.Empty;
        DataSet ds = new DataSet();
        int Uid = 0;
        int res = 0;
        try
        {
            string sqlqry = "select [UniqueId] from [tblUses] where [ClassId]='" + class_id + "' and [SubjectId]='" + subject_id + "' and [ChapterId]='" + chapte_id + "' and [TopicId]='" + topic_id + "'";
            string id = Convert.ToString(cc.ExecuteScalar(sqlqry));
            if (id == "NULL" || id == "")
            {
                SqlQry = "select max(UniqueId)+1 from [tblUses]";
                Uid = Convert.ToInt32(cc.ExecuteScalar(SqlQry));
            }
            else
            {
                Uid = Convert.ToInt32(id);
            }

            SqlQry = "Insert into [tblUses]([Word],[UsesId],[ClassId],[ClassName],[SubjectId],[SubjectName],[ChapterId],[ChapterName],[TopicId],[TopicName],[LangType],[UniqueId],[CreatedBy],[CreatedDate],[Imei])" +
                      " Values(N'" + Word + "',N'" + usesId + "'," + class_id + ",'" + Class + "'," + subject_id + ",'" + subject + "'," + chapte_id + ",'" + chapter + "'," + topic_id + ",'" + topic + "','" + lang_type + "','" + Uid + "','" + insertby + "','" +
                      System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + imei + "')";
            res = cc.ExecuteNonQuery(SqlQry);

            string sql = "select max(Id) from [tblUses] WHERE [UsesId]='-1' ";
            ServerId = cc.ExecuteScalar(sql);

            string Sql = "select max(Id) from [tblUses] ";
            serverid = cc.ExecuteScalar(Sql);

            if (ServerId != "")
            {

                sqlqry = "Update [tblUses] set [UsesId]='" + ServerId + "' Where [Id]='" + serverid + "'";
                res = cc.ExecuteNonQuery(sqlqry);
            }
            return serverid;
        }
        catch
        {
            return "0";
        }

    }


    [WebMethod(Description = "Insert Similariy opposite and uses word Details")]
    public string InsertSimilarityAndOppositeWord(string origanalWordid, string similarWord, string oppositeWord, string uses, string langType, string insertBy, string Classid, string subjectid, string chapterid, string topicid, string Servrid) //string uid
    {
        string SqlQry = string.Empty;
        int res = 0;
        int Wid = 0;
        try
        {
            string sqlqry = "select MAX([UniqueId]) from [tblWordDetails] where [Classid]='" + Classid + "' and [Subjectid]='" + subjectid + "' and [Chapterid]='" + chapterid + "' and [Topicid]='" + topicid + "'";
            Wid = Convert.ToInt32(cc.ExecuteScalar(sqlqry));

            SqlQry = "insert into [tblWordRelationDetails]([OriganalWordId],[SimilarityWord],[OppositeWord],[Uses],[LanguageType],[CreatedBy],[CreatedDate],[Uniqueid],[Serverid])" +
                     "values('" + origanalWordid + "',N'" + similarWord + "',N'" + oppositeWord + "',N'" + uses + "',N'" + langType + "','" + insertBy + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'," + Wid + ",'" + Servrid + "')";
            res = Convert.ToInt32(cc.ExecuteNonQuery(SqlQry));
        }
        catch
        {
            return "0";
        }
        return "1";
    }

    [WebMethod(Description = "METHOD TO INSERT SHARE WORDS TO STUDENTS")]
    public int ShareWords(string studentMobNumber, int uniqueId, int classId, string batch)  //,string ownerMobNumber,string refMobNumber)
    {
        try
        {
            string[] studNumber = studentMobNumber.Split('|');
            int count = 0;

            var temp = new List<string>();
            foreach (var s in studNumber)
            {
                if (!string.IsNullOrEmpty(s))
                    temp.Add(s);
            }
            studNumber = temp.ToArray();

            for (int i = 0; i < studNumber.Length; i++)
            {
                string sqlQuery1 = "SELECT [ShareWId] FROM [tblShareWords] WHERE [StudentMobNo]='" + studNumber[i] + "' AND [UniqueId]=" + uniqueId + "";
                DataSet dset = cc.ExecuteDataset(sqlQuery1);
                if (dset.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    string sqlQuery = " INSERT INTO [tblShareWords] ([StudentMobNo],[UniqueId],[ClassId],[Batch],[CreatedBy])" +  //,[OwnerMobNumber],[RefMobNumber]) " +
                                      " VALUES ('" + studNumber[i] + "'," + uniqueId + "," + classId + ",'" + batch + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')"; //,'" + ownerMobNumber + "','" + refMobNumber + "')";
                    cc.ExecuteNonQuery(sqlQuery);
                }
                count++;
            }
            return count;
        }
        catch
        {
            return 105;
        }
    }

    [WebMethod(Description = "Method to Download Word Details")]
    public XmlDataDocument DownloadWordsData(string ClassId, string SubjectId, string ChapterId, string TopicId)
    {
        XmlDataDocument ObjXmlData = new XmlDataDocument();
        string SqlQuery = string.Empty;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        try
        {
            SqlQuery = "Select [Id],[Word],[Similarword_Id],[Oppositeword_Id],[LangId] ,[UniqueId],[ClassId],[ClassName],[SubjectId] ,[SubjectName] ,[ChapterId] ,[ChapterName]  ,[TopicId],[TopicName],[CreatedBy] from [tblNewWordDetails] WHERE [ClassId]=" +
                        ClassId + " AND [SubjectId]=" + SubjectId + " AND [ChapterId]=" + ChapterId + " AND [TopicId]=" + TopicId + "";

            ds = cc.ExecuteDataset(SqlQuery);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ObjXmlData = new XmlDataDocument(ds);
                XmlElement ObjXmlElement = ObjXmlData.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("No Record", typeof(int)));
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

    [WebMethod(Description = "Download Words Details")]
    public string DownloadWordsDataToParents(string StudMobNo)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        string returnstring = string.Empty;
        string SqlQry = string.Empty;
        string uidStr = string.Empty;
        string uniqueId = string.Empty;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string sql = string.Empty;
        try
        {
            SqlQry = "Select DISTINCT [UniqueId] from [tblShareWords] where [StudentMobNo]='" + StudMobNo + "'";
            ds = cc.ExecuteDataset(SqlQry);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int col = 0; col < ds.Tables[0].Rows.Count; col++)
                {
                    uidStr = uidStr + "," + Convert.ToString(ds.Tables[0].Rows[col]["UniqueId"]);
                }
            }
            uidStr = uidStr.Substring(1);

            //string sql = "select WRD.[OriganalWordId],WRD.[SimilarityWord],WRD.[OppositeWord],WRD.[Uses],WRD.[Serverid],w.[OriganalWord] " +
            //             "from [DBeZeeOnlineExam].[dbo].[tblWordRelationDetails] as WRD inner join [DBeZeeOnlineExam].[dbo].[tblWordDetails] as w on w.[id] = WRD.[Serverid] WHERE w.[UniqueId] IN (56)";
            //DataSet dtset = cc.ExecuteDataset(sql);
            //if (dtset.Tables[0].Rows.Count > 0)
            //{
            //    xmlData = new XmlDataDocument(dtset);
            //    XmlElement xmlEle = xmlData.DocumentElement;
            //}

            sql = "select [id],[OriganalWord],[UniqueId] from [tblWordDetails] where [UniqueId] IN (" + uidStr + ")"; //IN(" + CidStr + ")";
            DataSet dtset = cc.ExecuteDataset(sql);
            if (dtset.Tables[0].Rows.Count > 0)
            {
                //    for (int i = 0; i < dtset.Tables[0].Rows.Count; i++)
                //    {
                //        uniqueId = uniqueId + "," + dtset.Tables[0].Rows[i][0].ToString();
                //    }

                sql += "select [Sno],[OriganalWordId],[SimilarityWord],[OppositeWord],[Uses],[Uniqueid],[Serverid] from [tblWordRelationDetails] where [Uniqueid] IN (" + uidStr + ")"; //IN(" + CidStr + ")";
                DataSet DS = cc.ExecuteDataset(sql);
                if (DS.Tables[0].Rows.Count > 0)
                {
                    //xmlData = new XmlDataDocument(DS);
                    //XmlElement xmlEle = xmlData.DocumentElement;
                    for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                    {
                        returnstring += DS.Tables[0].Rows[i][0].ToString() + "*" + DS.Tables[0].Rows[i][1].ToString() + "*" + DS.Tables[0].Rows[i][2].ToString() + "*" + DS.Tables[0].Rows[i][3].ToString() + "*" + DS.Tables[0].Rows[i][4].ToString()
                                       + "*" + DS.Tables[0].Rows[i][5].ToString() + "*" + DS.Tables[0].Rows[i][6].ToString();
                    }
                }
            }
            //uniqueId = uniqueId.Substring(1);

            //sql += "select [Sno],[OriganalWordId],[SimilarityWord],[OppositeWord],[Uses],[Uniqueid],[Serverid] from [tblWordRelationDetails] where [Uniqueid] IN (" + uniqueId + ")"; //IN(" + CidStr + ")";
            //DataSet DS = cc.ExecuteDataset(sql);
            //if (DS.Tables[0].Rows.Count > 0)
            //{
            //    dt.Columns.Add(new DataColumn("Sno", typeof(string)));
            //    dt.Columns.Add(new DataColumn("OriganalWordId", typeof(string)));
            //    dt.Columns.Add(new DataColumn("OriganalWord", typeof(string)));
            //    dt.Columns.Add(new DataColumn("SimilarityWord", typeof(string)));
            //    dt.Columns.Add(new DataColumn("OppositeWord", typeof(string)));
            //    dt.Columns.Add(new DataColumn("Uses", typeof(string)));
            //    dt.Columns.Add(new DataColumn("UniqueId", typeof(string)));
            //    dt.Columns.Add(new DataColumn("Serverid", typeof(string)));

                //    int dscnt = DS.Tables[0].Rows.Count;
            //    int dsCount = ds.Tables[0].Rows.Count;

                //    for (int i = 0; i < dscnt; i++)
            //    {
            //        dt.Rows.Add(DS.Tables[0].Rows[i]["Sno"].ToString(), DS.Tables[0].Rows[i]["OriganalWordId"].ToString(), dtset.Tables[0].Rows[i]["OriganalWord"].ToString(), DS.Tables[0].Rows[i]["SimilarityWord"].ToString(), DS.Tables[0].Rows[i]["OppositeWord"].ToString(), DS.Tables[0].Rows[i]["Uses"].ToString(), DS.Tables[0].Rows[i]["Uniqueid"].ToString(), DS.Tables[0].Rows[i]["Serverid"].ToString()); //ds.Tables[0].Rows[0]["UniqueId"].ToString()
            //    }
            //    ds.Tables.RemoveAt(0);
            //    ds.Tables.Add(dt);
            //    ds.Tables[0].TableName = "Table";
            //    xmlData = new XmlDataDocument(DS);
            //    XmlElement xmlEle = xmlData.DocumentElement;
            //}
            else
            {
                //dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                //DataRow dr = dt.NewRow();
                //dr["NoRecord"] = "106";
                //dt.Rows.Add(dr);
                //ds.Tables.Add(dt);
                //xmlData = new XmlDataDocument(ds);
                //XmlElement xmlelement = xmlData.DocumentElement;

                returnstring = "106";
            }
        }
        catch
        {
            //dt.Columns.Add(new DataColumn("Error", typeof(int)));
            //DataRow dr = dt.NewRow();
            //dr["Error"] = "105";
            //dt.Rows.Add(dr);
            //ds.Tables.Add(dt);
            //xmlData = new XmlDataDocument(ds);
            //XmlElement xmlelement = xmlData.DocumentElement;

            returnstring = "105";
        }
        return returnstring;
    }
    #endregion

    #region METHOD TO SEND MSG ON PARENT MOBILE NO FOR ABSENT STUDENT ATTENDANCE

    [WebMethod(Description = "ABSENT STUDENT INFORMATION ON PARENT MOBILE NO DETAILS")]
    public int AbsentMsgOnParentMobNno(string sendTo, string fwdMessage)
    {
        int countSMS = 0;
        try
        {
            string[] sendto = Convert.ToString(sendTo).Split('*', '#');
            var temp = new List<string>();
            foreach (var s in sendto)
            {
                if (!string.IsNullOrEmpty(s))
                    temp.Add(s);
            }
            sendto = temp.ToArray();

            for (int i = 0; i < sendto.Length; i++)
            {
                objComData.SendSMS(sendto[i].ToString(), fwdMessage);
                countSMS++;
            }

            return countSMS;
        }
        catch
        {
            return countSMS;
        }
    }
    #endregion

    #region METHOD TO UPLOAD DAYSPECIAL,LONG_FORM,PHASES&IDIOMS,GOOD_THOUGHTS
    [WebMethod(Description = "Upload Day Special")]
    public string InsertDaySpecial(string date, string categoryName, string dayspecial, string lang, string insertedby, string imei)   //string classid, string subjectid, string chapterid, string topicid,
    {
        int res = 0;
        string SqlQry = string.Empty; int Uid = 0;
        try
        {
            //string Sql = "select [Name] from [tblItemValue] where [ItemValueId]='" + classid + "' " +
            //               "select [Name] from [tblItemValue] where [ItemValueId]='" + subjectid + "' " +
            //               "select [Name] from [tblItemValue] where [ItemValueId]='" + chapterid + "' " +
            //               "select [Name] from [tblItemValue] where [ItemValueId]='" + topicid + "'";
            //ds = cc.ExecuteDataset(Sql);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    classname = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
            //    subjectname = Convert.ToString(ds.Tables[1].Rows[0]["Name"]);
            //    chaptername = Convert.ToString(ds.Tables[2].Rows[0]["Name"]);
            //    topicname = Convert.ToString(ds.Tables[3].Rows[0]["Name"]);
            //}

            string sqlqry = "select [UniqueId] from [tblDaySpecial]"; // where [Classid]='" + classid + "' and [Subjectid]='" + subjectid + "' and [Chapterid]='" + chapterid + "' and [Topicid]='" + topicid + "'
            string id = Convert.ToString(cc.ExecuteScalar(sqlqry));
            if (id == "NULL" || id == "")
            {
                SqlQry = "select max(UniqueId)+1 from [tblDaySpecial]";
                Uid = Convert.ToInt32(cc.ExecuteScalar(SqlQry));
            }
            else
            {
                Uid = Convert.ToInt32(id);
            }

            string sql = "insert into [tblDaySpecial]([date],[CategoryName],[DaySpecial],[Language],[CreatedBy],[CreatedDate],[Imei],UniqueId)" +  //,[ClassId],[ClassName],[SubjectId],[SubjectName],[ChapterId],[ChapterName],[TopicId],[TopicName],
                          "Values('" + date + "','" + categoryName + "','" + dayspecial + "','" + lang + "','" + insertedby + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + imei + "','" + Uid + "')"; //,'" + classid + "','" + classname + "','" + subjectid + "','" + subjectname + "','" + chapterid + "','" + chaptername + "','" + topicid + "','" + topicname + "',
            res = cc.ExecuteNonQuery(sql);
        }
        catch
        {
            return "0";
        }
        return "1";
    }

    [WebMethod(Description = "Upload Long Form")]
    public string InsertLongForm(string word, string categoryName, string longform, string classid, string subjectid, string chapterid, string topicid, string insertedby, string imei)
    {
        int res = 0;
        string classname = string.Empty; string subjectname = string.Empty;
        string chaptername = string.Empty; string topicname = string.Empty;
        string SqlQry = string.Empty; int Uid = 0;
        try
        {
            string Sql = "select [Name] from [tblItemValue] where [ItemValueId]='" + classid + "' " +
                         "select [Name] from [tblItemValue] where [ItemValueId]='" + subjectid + "' " +
                         "select [Name] from [tblItemValue] where [ItemValueId]='" + chapterid + "' " +
                         "select [Name] from [tblItemValue] where [ItemValueId]='" + topicid + "'";
            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                classname = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                subjectname = Convert.ToString(ds.Tables[1].Rows[0]["Name"]);
                chaptername = Convert.ToString(ds.Tables[2].Rows[0]["Name"]);
                topicname = Convert.ToString(ds.Tables[3].Rows[0]["Name"]);
            }

            string sqlqry = "select [UniqueId] from [tbllongForm] where [Classid]='" + classid + "' and [Subjectid]='" + subjectid + "' and [Chapterid]='" + chapterid + "' and [Topicid]='" + topicid + "'";
            string id = Convert.ToString(cc.ExecuteScalar(sqlqry));
            if (id == "NULL" || id == "")
            {
                SqlQry = "select max(UniqueId)+1 from [tbllongForm]";
                Uid = Convert.ToInt32(cc.ExecuteScalar(SqlQry));
            }
            else
            {
                Uid = Convert.ToInt32(id);
            }

            string sql = "insert into [tblLongForm]([Word],[CategoryName],[LomgForm],[ClassId],[ClassName],[SubjectId],[SubjectName],[ChapterId],[ChapterName],[TopicId],[TopicName],[CreatedBy],[CreatedDate],[Imei],UniqueId)" +   //UniqueId
                          "Values('" + word + "','" + categoryName + "','" + longform + "','" + classid + "','" + classname + "','" + subjectid + "','" + subjectname + "','" + chapterid + "','" + chaptername + "','" + topicid + "','" + topicname + "','" + insertedby + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + imei + "','" + Uid + "')";
            res = cc.ExecuteNonQuery(sql);
        }
        catch
        {
            return "0";
        }
        return "1";
    }

    [WebMethod(Description = "Upload phases And Idioms")]
    public string InsertPhasesAndIdioms(string actualword, string categoryName, string phases_idioms, string lang, string classid, string subjectid, string chapterid, string topicid, string insertedby, string imei)
    {
        int res = 0;
        string classname = string.Empty; string subjectname = string.Empty;
        string chaptername = string.Empty; string topicname = string.Empty;
        string SqlQry = string.Empty; int Uid = 0;
        try
        {
            string Sql = "select [Name] from [tblItemValue] where [ItemValueId]='" + classid + "' " +
                         "select [Name] from [tblItemValue] where [ItemValueId]='" + subjectid + "' " +
                         "select [Name] from [tblItemValue] where [ItemValueId]='" + chapterid + "' " +
                         "select [Name] from [tblItemValue] where [ItemValueId]='" + topicid + "'";
            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                classname = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                subjectname = Convert.ToString(ds.Tables[1].Rows[0]["Name"]);
                chaptername = Convert.ToString(ds.Tables[2].Rows[0]["Name"]);
                topicname = Convert.ToString(ds.Tables[3].Rows[0]["Name"]);
            }

            string sqlqry = "select [UniqueId] from [tblPhases_Idioms] where [Classid]='" + classid + "' and [Subjectid]='" + subjectid + "' and [Chapterid]='" + chapterid + "' and [Topicid]='" + topicid + "'";
            string id = Convert.ToString(cc.ExecuteScalar(sqlqry));
            if (id == "NULL" || id == "")
            {
                SqlQry = "select max(UniqueId)+1 from [tblPhases_Idioms]";
                Uid = Convert.ToInt32(cc.ExecuteScalar(SqlQry));
            }
            else
            {
                Uid = Convert.ToInt32(id);
            }

            string sql = "insert into [tblPhases_Idioms]([ActualWord],[CategoryName],[Phases_Idioms],[language],[ClassId],[ClassName],[SubjectId],[SubjectName],[ChapterId],[ChapterName],[TopicId],[TopicName],[CreatedBy],[CreatedDate],[Imei],UniqueId)" +  //UniqueId
                         "Values('" + actualword + "','" + categoryName + "','" + phases_idioms + "','" + lang + "','" + classid + "','" + classname + "','" + subjectid + "','" + subjectname + "','" + chapterid + "','" + chaptername + "','" + topicid + "','" + topicname + "','" + insertedby + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + imei + "','" + Uid + "')";
            res = cc.ExecuteNonQuery(sql);
        }
        catch
        {
            return "0";
        }
        return "1";
    }

    [WebMethod(Description = "Upload Day Special")]
    public string InsertGoodThoughts(string date, string categoryName, string goodthughts, string lang, string insertedby, string imei) //, string classid, string subjectid, string chapterid, string topicid
    {
        int res = 0;
        //string classname = string.Empty; string subjectname = string.Empty;
        //string chaptername = string.Empty; string topicname = string.Empty;
        string SqlQry = string.Empty; int Uid = 0;
        try
        {
            //string Sql = "select [Name] from [tblItemValue] where [ItemValueId]='" + classid + "' " +
            //               "select [Name] from [tblItemValue] where [ItemValueId]='" + subjectid + "' " +
            //               "select [Name] from [tblItemValue] where [ItemValueId]='" + chapterid + "' " +
            //               "select [Name] from [tblItemValue] where [ItemValueId]='" + topicid + "'";
            //ds = cc.ExecuteDataset(Sql);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    classname = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
            //    subjectname = Convert.ToString(ds.Tables[1].Rows[0]["Name"]);
            //    chaptername = Convert.ToString(ds.Tables[2].Rows[0]["Name"]);
            //    topicname = Convert.ToString(ds.Tables[3].Rows[0]["Name"]);
            //}

            string sqlqry = "select [UniqueId] from [tblGoodThoughts] "; //where [Classid]='" + classid + "' and [Subjectid]='" + subjectid + "' and [Chapterid]='" + chapterid + "' and [Topicid]='" + topicid + "'
            string id = Convert.ToString(cc.ExecuteScalar(sqlqry));
            if (id == "NULL" || id == "")
            {
                SqlQry = "select max(UniqueId)+1 from [tblGoodThoughts]";
                Uid = Convert.ToInt32(cc.ExecuteScalar(SqlQry));
            }
            else
            {
                Uid = Convert.ToInt32(id);
            }

            string sql = "insert into [tblGoodThoughts]([date],[CategoryName],[GoodThoughts],[Language],[CreatedBy],[CreatedDate],[Imei],UniqueId)" +   //UniqueId ,[ClassId],[ClassName],[SubjectId],[SubjectName],[ChapterId],[ChapterName],[TopicId],[TopicName]
                          "Values('" + date + "','" + categoryName + "','" + goodthughts + "','" + lang + "','" + insertedby + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + imei + "','" + Uid + "')"; //,'" + classid + "','" + classname + "','" + subjectid + "','" + subjectname + "','" + chapterid + "','" + chaptername + "','" + topicid + "','" + topicname + "'
            res = cc.ExecuteNonQuery(sql);
        }
        catch
        {
            return "0";
        }
        return "1";
    }
    #endregion

    #region METHOD TO DOWNLOAD DAYSPECIAL,LONG_FORM,PHASES_IDIOMS,GOOD_THOUGHTS
    [WebMethod(Description = "Download Day Special")]
    public XmlDataDocument DownloadDaySpecial(string category, string date, string maxid)    // (string classid, string subjectid, string chapterid, string topicid)
    {
        DataTable dt = new DataTable();
        XmlDataDocument xmlData = new XmlDataDocument();
        try
        {
            string sql = "select [id],[date],[CategoryName],[DaySpecial],[Language],[ClassId],[SubjectId],[ChapterId],[TopicId],[CreatedBy],[UniqueId] from [tblDaySpecial] where [date]='" + date + "' and [CategoryName] like '" + category + "%' and [id] > " + maxid + "";    // where [ClassId]='" + classid + "' and [SubjectId]='" + subjectid + "' and [ChapterId]='" + chapterid + "' and [TopicId]='" + topicid + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NoRecord"] = "106";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);

                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);

            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
        }
        return xmlData;
    }

    [WebMethod(Description = "Download Long Form")]
    public XmlDataDocument DownloadLongForm(string category, string charaterwise, string maxid)    //(string classid, string subjectid, string chapterid, string topicid)
    {
        DataTable dt = new DataTable();
        XmlDataDocument xmlData = new XmlDataDocument();
        try
        {
            string sql = "select [Id],[Word],[CategoryName],[LomgForm],[ClassId],[SubjectId],[ChapterId],[TopicId],[CreatedBy],[UniqueId] from [tblLongForm] where [CategoryName] = '" + category + "' and  [LomgForm] like '" + charaterwise + "%' and [Id]=" + maxid + "";         //[ClassId]='" + classid + "' and [SubjectId]='" + subjectid + "' and [ChapterId]='" + chapterid + "' and [TopicId]='" + topicid + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NoRecord"] = "106";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);

                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);

            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
        }
        return xmlData;
    }

    [WebMethod(Description = "Download Phases And idioms")]
    public XmlDataDocument DownloadphasesAndIdioms(string classid, string subjectid, string chapterid, string topicid, string maxid)
    {
        DataTable dt = new DataTable();
        XmlDataDocument xmlData = new XmlDataDocument();
        try
        {
            string sql = "select [Id],[ActualWord],[CategoryName],[Phases_Idioms],[language],[ClassId],[SubjectId],[ChapterId],[TopicId],[CreatedBy],[UniqueId] from [tblPhases_Idioms] where [ClassId]='" + classid + "' and [SubjectId]='" + subjectid + "' and [ChapterId]='" + chapterid + "' and [TopicId]='" + topicid + "' and [Id]=" + maxid + "";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NoRecord"] = "106";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);

                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);

            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
        }
        return xmlData;
    }

    [WebMethod(Description = "Download Good Thoughts")]
    public XmlDataDocument DownloadGoodThoughts(string category, string maxid) // (string classid, string subjectid, string chapterid, string topicid)
    {
        DataTable dt = new DataTable();
        XmlDataDocument xmlData = new XmlDataDocument();
        try
        {
            string sql = "select id, date, CategoryName, GoodThoughts, Language, ClassId,SubjectId,ChapterId,TopicId,CreatedBy,UniqueId from [tblGoodThoughts] WHERE [CategoryName] ='" + category + "' and id=" + maxid + ""; // where [ClassId]='" + classid + "' and [SubjectId]='" + subjectid + "' and [ChapterId]='" + chapterid + "' and [TopicId]='" + topicid + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NoRecord"] = "106";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);

                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);

            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
        }
        return xmlData;
    }
    #endregion


    //STP YASHADA WORK JITENDRA PATIL 09.09.2016
    #region INSERT FIELD ITEM MASTER ONE BY ONE RETURN VALUE AS SERVER FIELD_ITEM_VALUE_ID
    [WebMethod(Description = "INSERT FIELD ITEM MASTER")]
    public string InsertFieldMaster(string fieldValue, string fieldId, string appMobileNo)
    {
        string retVal = "0";
        try
        {
            string sqlQuery = "INSERT INTO [DBeZeeOnlineExam].[dbo].[tblFieldItemMaster] ([FieldItemValue],[FieldId],[InsertBy],[InsertDate]) " +
                              "VALUES ('" + fieldValue + "','" + fieldId + "','" + appMobileNo + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
            cc.ExecuteNonQuery(sqlQuery);
            string sqlQuery1 = "SELECT MAX([FieldItemId]) FROM [DBeZeeOnlineExam].[dbo].[tblFieldItemMaster]";
            retVal = cc.ExecuteScalar(sqlQuery1);
            return retVal;
        }
        catch
        {
            return retVal;
        }
    }
    #endregion

    #region INSERT AND UPDATE TRAINNIG DETAILS
    [WebMethod(Description = "INSERT AND UPDATE METHOD FOR TRAINING DETAILS")]
    public string InsertTrainingDetails(string userMobileNumber, string courseCode, string courseTitle, string courseDirector, string startDate, string endDate, string duration,
                                        string trainingVenue, string place, string department, string typeofTraining, string trainingType, string courseCategory, string sponseredBy,
                                        string trainingCategory, string employmentGroup, string noofParticipants, string rate, string imeiNumber, string appMobileNo)
    {
        string sqlQuery = string.Empty;
        try
        {
            string sqlSelect = "SELECT * FROM [DBeZeeOnlineExam].[dbo].[tblTrainingDetails] WHERE [userMobileNumber] = '" + userMobileNumber + "' AND [CourseCode] = '" + courseCode + "'";
            DataSet dsSelect = cc.ExecuteDataset(sqlSelect);
            if (dsSelect.Tables[0].Rows.Count == 0)
            {
                //string sqlqry = "select [FieldItemValue] from [tblFieldItemMaster] where [FieldItemId]='" + trainingVenue + "'" +
                //                "select [FieldItemValue] from [tblFieldItemMaster] where [FieldItemId]='" + department + "'" +
                //                "select [FieldItemValue] from [tblFieldItemMaster] where [FieldItemId]='" + typeofTraining + "'" +
                //                "select [FieldItemValue] from [tblFieldItemMaster] where [FieldItemId]='" + trainingType + "'" +
                //                "select [FieldItemValue] from [tblFieldItemMaster] where [FieldItemId]='" + trainingCategory + "'";
                //DataSet ds = cc.ExecuteDataset(sqlqry);

                //string TraingVenueName = Convert.ToString(ds.Tables[0].Rows[0]["FieldItemValue"]);
                //string DepartmentName = Convert.ToString(ds.Tables[0].Rows[0]["FieldItemValue"]);
                //string TypeOfTraingName = Convert.ToString(ds.Tables[0].Rows[0]["FieldItemValue"]);
                //string TrainingTypeName = Convert.ToString(ds.Tables[0].Rows[0]["FieldItemValue"]);
                //string TrainingCategoryName = Convert.ToString(ds.Tables[0].Rows[0]["FieldItemValue"]);


                sqlQuery = "INSERT INTO [DBeZeeOnlineExam].[dbo].[tblTrainingDetails] ([userMobileNumber],[CourseCode],[CourseTitle],[CourseDirector],[StartDate],[EndDate],[Duration],[TrainingVenue],[PlaceTaluka] " +
                                                                     ",[Department],[TypeofTraining],[TrainingType],[CourseCategory],[SponseredBy],[TrainingCategory],[EmploymentGroup],[NoOfParticipants] " +
                                                                     ",[Rate],[ImeiNumber],[InsertBy],[InserDate]) " +
                                  "VALUES ('" + userMobileNumber + "','" + courseCode + "','" + courseTitle + "','" + courseDirector + "','" + startDate + "','" + endDate + "','" + duration + "','" + trainingVenue + "','" + place + "','" + department + "','" + typeofTraining + "','" + trainingType + "', " +
                                  "'" + courseCategory + "','" + sponseredBy + "','" + trainingCategory + "','" + employmentGroup + "','" + noofParticipants + "','" + rate + "','" + imeiNumber + "','" + appMobileNo + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
            }
            else
            {
                sqlQuery = "UPDATE [DBeZeeOnlineExam].[dbo].[tblTrainingDetails] SET [CourseTitle]='" + courseTitle + "',[CourseDirector]='" + courseDirector + "',[StartDate]='" + startDate + "',[EndDate]='" + endDate + "',[Duration]='" + duration + "',[TrainingVenue]='" + trainingVenue + "',[PlaceTaluka]='" + place + "' " +
                           ",[Department]='" + department + "',[TypeofTraining]='" + typeofTraining + "',[TrainingType]='" + trainingType + "',[CourseCategory]='" + courseCategory + "',[SponseredBy]='" + sponseredBy + "',[TrainingCategory]='" + trainingCategory + "',[EmploymentGroup]='" + employmentGroup + "',[NoOfParticipants]='" + noofParticipants + "' " +
                           ",[Rate]='" + rate + "',[ImeiNumber]='" + imeiNumber + "',[ModifyBy]='" + appMobileNo + "',[ModifyDate]='" + DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE [userMobileNumber]='" + userMobileNumber + "' AND [CourseCode]='" + courseCode + "'";
            }

            cc.ExecuteNonQuery(sqlQuery);
            return "1";
        }
        catch
        {
            return "0";
        }
    }
    #endregion

    #region INSERT AND UPDATE EMPLOYEE PERSONAL DETAILS
    [WebMethod(Description = "METHOD TO INSERT AND UPDATE EMPLOYEE PERSONAL DETAILS")]
    public string EmpPersonalDetails(string userMobileNumber, string education, string birthDate, string caste, string gender, string firstJoinDate, string permAddress, string place, string imeiNumber, string appMobileNo, string FName, string LName, string MName)
    {
        string sqlQuery = string.Empty;
        try
        {
            string sqlSelect = "SELECT * FROM [tblEmpPersonalDetails] WHERE [userMobileNumber] = '" + userMobileNumber + "'"; //[DBeZeeOnlineExam].[dbo].
            DataSet dsSelect = cc.ExecuteDataset(sqlSelect);
            if (dsSelect.Tables[0].Rows.Count == 0)
            {
                sqlQuery = "INSERT INTO [tblEmpPersonalDetails] ([userMobileNumber],[Education],[BirthDate],[Caste],[Gender],[FirstJoinDate],[PermAddress],[PlaceTaluka],[ImeiNumber],[InsertBy],[InsertDate],[FirstName],[lastName],[MiddleName]) " +
                           "VALUES ('" + userMobileNumber + "','" + education + "','" + birthDate + "','" + caste + "','" + gender + "','" + firstJoinDate + "','" + permAddress + "','" + place + "','" + imeiNumber + "','" + appMobileNo + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + FName + "','" + LName + "','" + MName + "')"; //[DBeZeeOnlineExam].[dbo].
            }
            else
            {
                sqlQuery = "UPDATE [tblEmpPersonalDetails] SET [Education]='" + education + "',[BirthDate]='" + birthDate + "',[Caste]='" + caste + "',[Gender]='" + gender + "',[FirstJoinDate]='" + firstJoinDate + "',[PermAddress]='" + permAddress + "',[PlaceTaluka]='" + place + "',[ImeiNumber]='" + imeiNumber + "',[ModifyBy]='" + appMobileNo + "',[ModifyDate]='" + DateTime.Now.ToString("yyyy-MM-dd") + "',[FirstName]='" + FName + "',[LastName]='" + LName + "',[MiddleName]='" + MName + "' " +
                           "WHERE [userMobileNumber]='" + userMobileNumber + "'"; //[DBeZeeOnlineExam].[dbo].
            }
            cc.ExecuteNonQuery(sqlQuery);
            return "1";
        }
        catch
        {
            return "0";
        }
    }
    #endregion

    #region INSERT AND UPDATE EMPLOYEE WORK DETAILS
    [WebMethod(Description = "METHOD TO INSERT AND UPDATE EMPLOYEE WORK DETAILS")]
    public string EmpWorkDetails(string userMobileNumber, string jobStatus, string deptName, string section, string designation, string place, string employmentGroup, string officeName, string officeLevel, string ptcDate, string isWorkChange, string changeType, string changeDescription, string imeiNumber, string appMobileNumber)
    {
        try
        {
            string sqlQuery = string.Empty;

            string sqlSelect = "SELECT * FROM [DBeZeeOnlineExam].[dbo].[tblEmpWorkDetails] WHERE [userMobileNumber] = '" + userMobileNumber + "' AND [JobStatus] = '" + jobStatus + "'";
            DataSet dsSelect = cc.ExecuteDataset(sqlSelect);
            if (dsSelect.Tables[0].Rows.Count == 0)
            {
                sqlQuery = "INSERT INTO [DBeZeeOnlineExam].[dbo].[tblEmpWorkDetails] ([userMobileNumber],[JobStatus],[DeptName],[Section],[Designation],[PlaceTaluka],[EmploymentGroup],[OfficeName],[OfficeLevel] " +
                                                           ",[PTCDate],[IsWorkChange],[ChangeType],[ChangeDescription],[ImeiNumber],[InsertBy],[InsertDate]) " +
                           "VALUES ('" + userMobileNumber + "','" + jobStatus + "','" + deptName + "','" + section + "','" + designation + "','" + place + "','" + employmentGroup + "','" + officeName + "','" + officeLevel + "','" + ptcDate + "','" + isWorkChange + "','" + changeType + "','" + changeDescription + "','" + imeiNumber + "','" + appMobileNumber + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
            }
            else
            {
                sqlQuery = "UPDATE [DBeZeeOnlineExam].[dbo].[tblEmpWorkDetails] SET [DeptName]='" + deptName + "',[Section]='" + section + "',[Designation]='" + designation + "',[PlaceTaluka]='" + place + "',[EmploymentGroup]='" + employmentGroup + "',[OfficeName]='" + officeName + "',[OfficeLevel]='" + officeLevel + "',[PTCDate]='" + ptcDate + "' " +
                           ",[IsWorkChange]='" + isWorkChange + "',[ChangeType]='" + changeType + "',[ChangeDescription]='" + changeDescription + "',[ImeiNumber]='" + imeiNumber + "',[ModifyBy]='" + appMobileNumber + "',[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE [userMobileNumber]='" + userMobileNumber + "',[JobStatus]='" + jobStatus + "'";
            }

            cc.ExecuteNonQuery(sqlQuery);
            return "1";
        }
        catch
        {
            return "0";
        }
    }
    #endregion

    #region METHOD TO DOWNLOAD FIELD MASTER
    [WebMethod(Description = "METHOD TO DOWNLOAD FIELD MASTER")]
    public XmlDocument DownloadFieldMaster()
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        DataSet dataset = new DataSet();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adaper = new SqlDataAdapter();
        try
        {
            string sqlQuery1 = "SELECT [FieldId] AS ServerFId,[FieldName],[InsertBy] FROM [DBeZeeOnlineExam].[dbo].[tblFieldItem] " +
                               "SELECT [FieldItemId],[FieldItemValue],[FieldId],[Type],[InsertBy] FROM [DBeZeeOnlineExam].[dbo].[tblFieldItemMaster]";

            dataset = cc.ExecuteDataset(sqlQuery1);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NoRecord"] = "106";
                dt.Rows.Add(dr);
                dataset.Tables.Add(dt);
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            dataset.Tables.Add(dt);
            xmldoc = new XmlDataDocument(dataset);
            XmlElement xmlelement = xmldoc.DocumentElement;
        }
        return xmldoc;
    }

    #endregion

    #region METHOD TO DOWNLOAD TRAINING DETAILS
    [WebMethod(Description = "METHOD TO DOWNLOAD TRAINING DETAILS")]
    public XmlDocument DownloadTrainingDetails(string userMobileNumber)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        DataSet dataset = new DataSet();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adaper = new SqlDataAdapter();

        try
        {
            string sqlQuery1 = "SELECT [Id] AS ServerId,[userMobileNumber],[CourseCode],[CourseTitle],[CourseDirector],[StartDate],[EndDate],[Duration],[TrainingVenue],[PlaceTaluka],[Department],[TypeofTraining] " +
                               ",[TrainingType],[CourseCategory],[SponseredBy],[TrainingCategory],[EmploymentGroup],[NoOfParticipants],[Rate],[ImeiNumber],[InsertBy] " +
                               "FROM [DBeZeeOnlineExam].[dbo].[tblTrainingDetails] WHERE [userMobileNumber] = '" + userMobileNumber + "'";// AND [CourseCode]='" + courseCode + "'";
            dataset = cc.ExecuteDataset(sqlQuery1);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NoRecord"] = "106";
                dt.Rows.Add(dr);
                dataset.Tables.Add(dt);
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            dataset.Tables.Add(dt);
            xmldoc = new XmlDataDocument(dataset);
            XmlElement xmlelement = xmldoc.DocumentElement;
        }
        return xmldoc;
    }
    #endregion

    #region METHOD TO DOWNLOAD EMPLOYEE PERSONAL DETAILS
    [WebMethod(Description = "METHOD TO DOWNLOAD EMPLOYEE PERSONAL DETAILS")]
    public XmlDocument DownloadPersonalDetails(string userMobileNumber)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        DataSet dataset = new DataSet();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adaper = new SqlDataAdapter();

        try
        {
            string sqlQuery1 = "SELECT [Id] AS ServerId,[userMobileNumber],[Education],[BirthDate],[Caste],[Gender],[FirstJoinDate],[PermAddress],[PlaceTaluka],[ImeiNumber],[InsertBy],[FirstName],[LastName],[MiddleName] " +
                               "FROM [DBeZeeOnlineExam].[dbo].[tblEmpPersonalDetails] WHERE [userMobileNumber] = '" + userMobileNumber + "'";
            dataset = cc.ExecuteDataset(sqlQuery1);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NoRecord"] = "106";
                dt.Rows.Add(dr);
                dataset.Tables.Add(dt);
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            dataset.Tables.Add(dt);
            xmldoc = new XmlDataDocument(dataset);
            XmlElement xmlelement = xmldoc.DocumentElement;
        }
        return xmldoc;
    }
    #endregion

    #region METHOD TO DOWNLOAD EMPLOYEE WORK DETAILS
    [WebMethod(Description = "METHOD TO DOWNLOAD EMPLOYEE WORK DETAILS")]
    public XmlDocument DownloadWorkDetails(string userMobileNumber)
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        DataSet dataset = new DataSet();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adaper = new SqlDataAdapter();
        try
        {
            string sqlQuery1 = "SELECT [Id] AS ServerId,[userMobileNumber],[JobStatus],[DeptName],[Section],[Designation],[PlaceTaluka],[EmploymentGroup],[OfficeName],[OfficeLevel],[PTCDate] " +
                               ",[IsWorkChange],[ChangeDescription],[ImeiNumber],[InsertBy] " +
                               "FROM [DBeZeeOnlineExam].[dbo].[tblEmpWorkDetails] WHERE [userMobileNumber] = '" + userMobileNumber + "'"; //AND [JobStatus]='" + jobStatus + "'";
            dataset = cc.ExecuteDataset(sqlQuery1);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NoRecord"] = "106";
                dt.Rows.Add(dr);
                dataset.Tables.Add(dt);
                xmldoc = new XmlDataDocument(dataset);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            dataset.Tables.Add(dt);
            xmldoc = new XmlDataDocument(dataset);
            XmlElement xmlelement = xmldoc.DocumentElement;
        }
        return xmldoc;
    }
    #endregion


    //Work For Directory
    #region METHOD TO INSERT AND UPDATE DIRECTORY
    [WebMethod(Description = "INSERT AND UPDDATE DIRECTORY")]
    public string InsertDirectory(string InstituteType, string InstituteSubType, string personalDes, string InstitueName, string address, string latitude, string longitude, string talukid, string imei, string IhMobNo)
    {
        string sqlquery = string.Empty;
        try
        {
            string sqlstring = "select [IH_MobNo] from [DBeZeeOnlineExam].[dbo].[tblInstituteDirectory] where [IH_MobNo]='" + IhMobNo + "' and [InstituteType]='" + InstituteType + "'";
            DataSet ds = cc.ExecuteDataset(sqlstring);
            if (ds.Tables[0].Rows.Count == 0)
            {
                sqlquery = "INSERT INTO [DBeZeeOnlineExam].[dbo].[tblInstituteDirectory]([InstituteType],[InstituteSubType],[PersonalDescription],[InstituteName],[Address],[Latitude],[Longitude],[TalukaId],[IH_MobNo],[Imei],[InsertedBy],[InsertedDate])" +
                            "VALUES('" + InstituteType + "','" + InstituteSubType + "','" + personalDes + "','" + InstitueName + "','" + address + "','" + latitude + "','" + longitude + "','" + talukid + "','" + IhMobNo + "','" + imei + "','" + IhMobNo + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
            }
            else
            {
                //sqlquery = "Update [DBeZeeOnlineExam].[dbo].[tblInstituteDirectory] Set [InstituteType]='" + InstituteType + "',[InstituteSubType]='" + InstituteSubType + "',[PersonalDescription]='" + personalDes + "',[InstituteName]='" + InstitueName + "',[Address]='" + address + "',[Latitude]='" + latitude + "',[Longitude]='" + longitude + "',[TalukaId]='" + talukid + "',[IH_MobNo]='" + IhMobNo + "',[Imei]='" + imei + "',[InsertedBy]='" + IhMobNo + "',[InsertedDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' where [IH_MobNo]='" + IhMobNo + "'";
                sqlquery = "Update [DBeZeeOnlineExam].[dbo].[tblInstituteDirectory] Set [InstituteType]='" + InstituteType + "',[InstituteSubType]='" + InstituteSubType + "',[PersonalDescription]='" + personalDes + "',[InstituteName]='" + InstitueName + "',[Address]='" + address + "',[Latitude]='" + latitude + "',[Longitude]='" + longitude + "',[TalukaId]='" + talukid + "',[IH_MobNo]='" + IhMobNo + "',[Imei]='" + imei + "',[ModifyBy]='" + IhMobNo + "',[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' where [IH_MobNo]='" + IhMobNo + "' and [InstituteType]='" + InstituteType + "'";
            }
            cc.ExecuteNonQuery(sqlquery);
        }
        catch
        {
            return "0";
        }
        return "1";
    }
    #endregion

    #region METHOD TO DOWNLOAD INSTITUTE DIRECTORY
    [WebMethod(Description = "DOWNLOAD INSTITUTE DIRECTORY DETAILS")]
    public XmlDataDocument DownloadDirectory(string City, string InstituteType, string InstituteSubtype)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        try
        {
            string sql = "Select [InstituteType],[InstituteSubType],[InstituteName],[PersonalDescription],[Address],[Latitude],[Longitude],[IH_MobNo],[TalukaId] From [DBeZeeOnlineExam].[dbo].[tblInstituteDirectory] where [InstituteType]='" + InstituteType + "' and [InstituteSubType]='" + InstituteSubtype + "' and [TalukaId]=" + City + " ";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Nodata", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["Nodata"] = "106";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlelement = xmlData.DocumentElement;
            }
        }
        catch
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
        }
        return xmlData;
    }
    #endregion

    #region METHOD TO Upload data As per Training Batch Details
    [WebMethod(Description = "Insert training batch data details")]
    public string InsertTrainingClassBatchData(string TrainingString)
    {
        string SqlQuery = string.Empty;
        AllClassAppMethods objClassApp = new AllClassAppMethods();
        DataSet ds = new DataSet();
        string[] ArryStr = TrainingString.Split(new char[] { '*', '#' });
        var temp = new List<string>();
        foreach (var s in ArryStr)
        {
            if (!string.IsNullOrEmpty(s))
                temp.Add(s);
        }
        ArryStr = temp.ToArray();
        try
        {
            for (int i = 0; i < ArryStr.Length; i += 5)
            {
                objClassApp.InsertStudentRegForTrainingClass(ArryStr[i], ArryStr[i + 1], ArryStr[i + 2], ArryStr[i + 3], ArryStr[i + 4]);

                SqlQuery = "insert into [tblTrainingBatchDetails]([TrainingClass_Id],[Section],[CourseCode],[TrainerMobNo],[CreatedBy],[CreatedDate])" +
                      "values('" + ArryStr[i].ToString() + "','" + ArryStr[i + 1].ToString() + "','" + ArryStr[i + 2].ToString() + "','" + ArryStr[i + 3].ToString() + "','" + ArryStr[i + 4].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                cc.ExecuteNonQuery(SqlQuery);
            }


        }
        catch
        {
            return "0";
        }
        return "1";
    }
    #endregion

    #region Method To Insert Visitor Data
    [WebMethod(Description = "Insert Visitor Data Details")]
    public string InsertVisitorData(string usrMobNo, string IHmobNo, string keyword, string dt, string usrName, string instituteType, string instituteSubType)
    {
        string SqlQry = string.Empty;
        try
        {
            SqlQry = "insert into [tblVisitor]([userMobNo],[IHMobNo],[Keyword],[date],[CreatedBy],[CreatedDate],[userName],[InstituteType],[InstituteSubType])" +
                     "values('" + usrMobNo + "','" + IHmobNo + "','" + keyword + "','" + dt + "','" + IHmobNo + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + usrName + "','" + instituteType + "','" + instituteSubType + "')";
            cc.ExecuteNonQuery(SqlQry);
        }
        catch
        {
            return "0";
        }
        return "1";
    }
    #endregion

    #region Method To Download Visitor Data
    [WebMethod(Description = "Download visitor data details")]
    public XmlDataDocument DownloadVisitorData(string IHmobNo)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        string SqlQry = string.Empty;
        try
        {
            SqlQry = "Select [userMobNo],[Keyword],[date],[userName],[IHMobNo],[InstituteType],[InstituteSubType],[Sno] from [tblVisitor] Where [IHMobNo]='" + IHmobNo + "'";
            ds = cc.ExecuteDataset(SqlQry);
            if (ds.Tables[0].Rows.Count > 0)
            {
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NoRecord"] = "106";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlelement = xmlData.DocumentElement;
            }
        }
        catch
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
        }
        return xmlData;
    }
    #endregion
}
