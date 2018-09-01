using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using OMRServerConfig;


/// <summary>
/// Summary description for OMRScanDetails
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class OMRScanDetails : System.Web.Services.WebService
{

    public string retrunValue = string.Empty;
    CommonCode cc = new CommonCode();
    //string returnString = "", returnTest_ID = "", returnExam_date = "", returnExam_Duration = "", returnMarkCorrA = "", returnMarkPass = "", returnNegativeMark = "", returnMarkForNegative = "", returnTestofType = "", returnLogin = "";
   
    public OMRScanDetails()
    {
    }

    [WebMethod(Description = "INSERT DATA TO SERVER OF OMR SHEET SCANNED AS PER ROLLNO AND TESTID")]

    public string InsertOmrScanDetails(string rollNo, string testId, string testName, string testCreaterMobno, string q1, string q2, string q3, string q4, string q5, string q6, string q7, string q8, string q9, string q10, string q11, string q12, string q13, string q14, string q15, string q16, string q17, string q18, string q19, string q20, string q21, string q22, string q23, string q24, string q25, string q26, string q27, string q28, string q29, string q30, string q31, string q32, string q33, string q34, string q35, string q36, string q37, string q38, string q39, string q40, string q41, string q42, string q43, string q44, string q45, string q46, string q47, string q48, string q49, string q50, string q51, string q52, string q53, string q54, string q55, string q56, string q57, string q58, string q59, string q60, string q61, string q62, string q63, string q64, string q65, string q66, string q67, string q68, string q69, string q70, string q71, string q72, string q73, string q74, string q75, string q76, string q77, string q78, string q79, string q80, string q81, string q82, string q83, string q84, string q85, string q86, string q87, string q88, string q89, string q90, string q91, string q92, string q93, string q94, string q95, string q96, string q97, string q98, string q99, string q100)
    {

        try
        {
            string sql = " INSERT INTO tblOMRScanDetails ([RollNumber],[TestId],[TestName],[TestCreaterId],[InsertDate],[Q1],[Q2],[Q3],[Q4],[Q5],[Q6],[Q7],[Q8],[Q9],[Q10],[Q11],[Q12],[Q13],[Q14],[Q15],[Q16],[Q17],[Q18],[Q19],[Q20],[Q21],[Q22],[Q23],[Q24],[Q25],[Q26],[Q27],[Q28],[Q29],[Q30],[Q31],[Q32],[Q33],[Q34],[Q35],[Q36],[Q37],[Q38],[Q39],[Q40],[Q41],[Q42],[Q43],[Q44],[Q45],[Q46],[Q47],[Q48],[Q49],[Q50],[Q51],[Q52],[Q53],[Q54],[Q55],[Q56],[Q57],[Q58],[Q59],[Q60],[Q61],[Q62],[Q63],[Q64],[Q65],[Q66],[Q67],[Q68],[Q69],[Q70],[Q71],[Q72],[Q73],[Q74],[Q75],[Q76],[Q77],[Q78],[Q79],[Q80],[Q81],[Q82],[Q83],[Q84],[Q85],[Q86],[Q87],[Q88],[Q89],[Q90],[Q91],[Q92],[Q93],[Q94],[Q95],[Q96],[Q97],[Q98],[Q99],[Q100]) " +
                         " VALUES ('" + rollNo + "','" + testId + "','" + testName + "','" + testCreaterMobno + "','" + DateTime.Today.ToString("yyyy-MM-dd hh:mm:ss tt") + "','" + q1 + "','" + q2 + "','" + q3 + "','" + q4 + "','" + q5 + "','" + q6 + "','" + q7 + "','" + q8 + "','" + q9 + "','" + q10 + "','" + q11 + "','" + q12 + "','" + q13 + "','" + q14 + "','" + q15 + "','" + q16 + "','" + q17 + "','" + q18 + "','" + q19 + "','" + q20 + "','" + q21 + "','" + q22 + "','" + q23 + "','" + q24 + "','" + q25 + "','" + q26 + "','" + q27 + "','" + q28 + "','" + q29 + "','" + q30 + "','" + q31 + "','" + q32 + "','" + q33 + "','" + q34 + "','" + q35 + "','" + q36 + "','" + q37 + "','" + q38 + "','" + q39 + "','" + q40 + "','" + q41 + "','" + q42 + "','" + q43 + "','" + q44 + "','" + q45 + "','" + q46 + "','" + q47 + "','" + q48 + "','" + q49 + "','" + q50 + "','" + q51 + "','" + q52 + "','" + q53 + "','" + q54 + "','" + q55 + "','" + q56 + "','" + q57 + "','" + q58 + "','" + q59 + "','" + q60 + "','" + q61 + "','" + q62 + "','" + q63 + "','" + q64 + "','" + q65 + "','" + q66 + "','" + q67 + "','" + q68 + "','" + q69 + "','" + q70 + "','" + q71 + "','" + q72 + "','" + q73 + "','" + q74 + "','" + q75 + "','" + q76 + "','" + q77 + "','" + q78 + "','" + q79 + "','" + q80 + "','" + q81 + "','" + q82 + "','" + q83 + "','" + q84 + "','" + q85 + "','" + q86 + "','" + q87 + "','" + q88 + "','" + q89 + "','" + q90 + "','" + q91 + "','" + q92 + "','" + q93 + "','" + q94 + "','" + q95 + "','" + q96 + "','" + q97 + "','" + q98 + "','" + q99 + "','" + q100 + "')";
            cc.ExecuteNonQuery(sql);

            retrunValue = "1";
        }
        catch
        {
            retrunValue = "0";
        }
        finally
        {

        }

        return retrunValue;
    }

    [WebMethod(Description = "INSERT SYSTEM CONFIGURATION TO THE SERVER OF THE LOCAL MACHINE")]
    public string InsertSystemConfiguration(OmrApiMachinHelper sysInfo)
    {
            string osName = sysInfo.osName;
            string hddModel = sysInfo.hddModel;
            string hddSerialNo = sysInfo.hddSerialNo;
            string hddType = sysInfo.hddType;
            int cores = sysInfo.cores;
            string osArchitecture = sysInfo.osArchitecture;
            string processorId = sysInfo.processorId;
            string processorName = sysInfo.processorName;
            string processorStatus = sysInfo.processorStatus;
            string ram = sysInfo.ram;
            string systemName = sysInfo.systemName;
            string code = sysInfo.code;
            string userId = sysInfo.userId;

            string sql = " INSERT INTO tblOMRSystemConfig ([OSName],[HDDModel],[HDDSerialNo],[HDDType],[Cores],[OSArchitecure],[ProcessorId],[ProcessorName],[ProcessorStatus],[Ram],[SystemName],[Code],[UserId],[InsertDate]) " +
                         " VALUES ('" + osName + "','" + hddModel + "','" + hddSerialNo + "','" + hddType + "'," + cores + ",'" + osArchitecture + "','" + processorId + "','" + processorName + "','" + processorStatus + "','" + ram + "','" + systemName + "','" + code + "','" + userId + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "') ";
             int returnVal = cc.ExecuteNonQuery(sql);
             if (returnVal > 0)
                retrunValue = "1";
             else
                 retrunValue = "0";
       
            return retrunValue;
    }


    [WebMethod(Description = "VERIFY SYSTEM CONFIGURATION TO THE SERVER OF THE LOCAL MACHINE")]
    // Return 1 = Verify valid user. & Return 0 = Verify invalid user.
    public string verifySystemConfiguration(OmrApiMachinHelper sysInfo)
    {
       
            string osName = sysInfo.osName;
            string hddModel = sysInfo.hddModel;
            string hddSerialNo = sysInfo.hddSerialNo;
            string hddType = sysInfo.hddType;
            int cores = sysInfo.cores;
            string osArchitecture = sysInfo.osArchitecture;
            string processorId = sysInfo.processorId;
            string processorName = sysInfo.processorName;
            string processorStatus = sysInfo.processorStatus;
            string ram = sysInfo.ram;
            string systemName = sysInfo.systemName;
            string code = sysInfo.code;
            string userId = sysInfo.userId;

            string sql = "Select * from tblOMRSystemConfig Where [UserId]='" + userId + "' and [ProcessorName] = '" + processorName + "' and [OSName] = '" + osName + "' and [ProcessorId] = '"+ processorId +"'";
            int itemSelectRow = cc.ExecuteDataset(sql).Tables[0].Rows.Count;

            if (itemSelectRow > 0)
                retrunValue = "1";
            else
                retrunValue = "0";
       
            return retrunValue;
    }

    [WebMethod(Description = "GET DETAILS OF DEFINE TEST UNDER THE PORVIDE MOBILE NUMBER OF INSTITUTE HEAD")]
    public List<OmrApiTestDetailHelper> GetDefineTestDetails(string instituteHeadNumber)
    {
        List<OmrApiTestDetailHelper> ListOfTest = new List<OmrApiTestDetailHelper>();
      
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();

        string sql = "SELECT [Test_ID],[Exam_name],[Exam_Duration],[MarkCorrA],[MarkPass],[NegativeMark],[MarkforNegative],[TypeofTest],[Exam_date],[LoginId] FROM tblTestDefinition WHERE [LoginId]='" + instituteHeadNumber + "'";
        ds = cc.ExecuteDataset(sql);
        int countValue = ds.Tables[0].Rows.Count;
        if (countValue > 0)
        {
            for (int i = 0; i < countValue; i++)
            {
                OmrApiTestDetailHelper testInfo = new OmrApiTestDetailHelper();
                testInfo.TestId = Convert.ToString(ds.Tables[0].Rows[i]["Test_ID"]);
                testInfo.TestName = Convert.ToString(ds.Tables[0].Rows[i]["Exam_name"]);
                testInfo.TestMarkPerQue = Convert.ToString(ds.Tables[0].Rows[i]["MarkCorrA"]);
                testInfo.TestMarkPerQue = Convert.ToString(ds.Tables[0].Rows[i]["MarkPass"]);
                testInfo.isNegativeMarking = (Convert.ToString(ds.Tables[0].Rows[i]["NegativeMark"]) == "Yes" ? true : false);
                testInfo.dateOfExam = Convert.ToString(ds.Tables[0].Rows[i]["Exam_date"]).Remove(Convert.ToString(ds.Tables[0].Rows[i]["Exam_date"]).Length - 12);

                if (testInfo.isNegativeMarking == true)
                {
                    testInfo.negativeMarkPerQue = Convert.ToInt16(ds.Tables[0].Rows[i]["MarkforNegative"]);
                }
                else
                {
                    testInfo.negativeMarkPerQue = 0;
                }

                string sql1 = " SELECT [tbl5164].[SNO] FROM [tbl5164] WHERE [TestID]='" + testInfo.TestId + "' and [TestCreaterID]='" + instituteHeadNumber + "'";
                ds1 = cc.ExecuteDataset(sql1);

                if (ds1.Tables[0].Rows.Count > 0)
                    testInfo.NumberOfQuestions = Convert.ToString(ds1.Tables[0].Rows.Count);
                else
                    testInfo.NumberOfQuestions = "0";
                ListOfTest.Add(testInfo);
            }                
        }
        return ListOfTest;
    }

    [WebMethod(Description = "GET DETAILS OF QUESTION AND ANSWERS FOR THE GIVEN TEST")]

    public OmrApiAnswerSheetHelper GetTestAnswersList(string testId, string testCreaterMobNo)
    {
        string correctAnswerVal = string.Empty;
        DataSet ds = new DataSet();
        OmrApiAnswerSheetHelper TestAnswerObj = new OmrApiAnswerSheetHelper();
        TestAnswerObj.TestId = testId;

        string sql = " WITH T AS (SELECT ROW_NUMBER() OVER (ORDER BY [tbl5164].[SNO]) AS EQID, [tbl5164].[SNO],[tbl5164].[Correct_answer],[tbl5164].[TestID],[tbl5164].[TestCreaterID] FROM [tbl5164] WHERE [tbl5164].[TestID] = '" + testId + "' and [tbl5164].[TestCreaterID]='" + testCreaterMobNo + "') SELECT * FROM T ";
        ds = cc.ExecuteDataset(sql);
        int countValue = ds.Tables[0].Rows.Count;
        if (countValue > 0)
        {
            for (int i = 0; i < countValue; i++)
            {
                if (Convert.ToString(ds.Tables[0].Rows[i]["Correct_answer"]) == "A")
                {
                    correctAnswerVal = "1";
                }
                else if (Convert.ToString(ds.Tables[0].Rows[i]["Correct_answer"]) == "B")
                {
                    correctAnswerVal = "2";
                }
                else if (Convert.ToString(ds.Tables[0].Rows[i]["Correct_answer"]) == "C")
                {
                    correctAnswerVal = "3";
                }
                else if (Convert.ToString(ds.Tables[0].Rows[i]["Correct_answer"]) == "D")
                {
                    correctAnswerVal = "4";
                }
                else
                {
                    correctAnswerVal = "5";
                }

                if (i == 0) TestAnswerObj.AnswerQue1 = correctAnswerVal;
                if (i == 1) TestAnswerObj.AnswerQue2 = correctAnswerVal;
                if (i == 2) TestAnswerObj.AnswerQue3 = correctAnswerVal;
                if (i == 3) TestAnswerObj.AnswerQue4 = correctAnswerVal;
                if (i == 4) TestAnswerObj.AnswerQue5 = correctAnswerVal;
                if (i == 5) TestAnswerObj.AnswerQue6 = correctAnswerVal;
                if (i == 6) TestAnswerObj.AnswerQue7 = correctAnswerVal;
                if (i == 7) TestAnswerObj.AnswerQue8 = correctAnswerVal;
                if (i == 8) TestAnswerObj.AnswerQue9 = correctAnswerVal;
                if (i == 9) TestAnswerObj.AnswerQue10 = correctAnswerVal;

                if (i == 10) TestAnswerObj.AnswerQue11 = correctAnswerVal;
                if (i == 11) TestAnswerObj.AnswerQue12 = correctAnswerVal;
                if (i == 12) TestAnswerObj.AnswerQue13 = correctAnswerVal;
                if (i == 13) TestAnswerObj.AnswerQue14 = correctAnswerVal;
                if (i == 14) TestAnswerObj.AnswerQue15 = correctAnswerVal;
                if (i == 15) TestAnswerObj.AnswerQue16 = correctAnswerVal;
                if (i == 16) TestAnswerObj.AnswerQue17 = correctAnswerVal;
                if (i == 17) TestAnswerObj.AnswerQue18 = correctAnswerVal;
                if (i == 18) TestAnswerObj.AnswerQue19 = correctAnswerVal;
                if (i == 19) TestAnswerObj.AnswerQue20 = correctAnswerVal;

                if (i == 20) TestAnswerObj.AnswerQue21 = correctAnswerVal;
                if (i == 21) TestAnswerObj.AnswerQue22 = correctAnswerVal;
                if (i == 22) TestAnswerObj.AnswerQue23 = correctAnswerVal;
                if (i == 23) TestAnswerObj.AnswerQue24 = correctAnswerVal;
                if (i == 24) TestAnswerObj.AnswerQue25 = correctAnswerVal;
                if (i == 25) TestAnswerObj.AnswerQue26 = correctAnswerVal;
                if (i == 26) TestAnswerObj.AnswerQue27 = correctAnswerVal;
                if (i == 27) TestAnswerObj.AnswerQue28 = correctAnswerVal;
                if (i == 28) TestAnswerObj.AnswerQue29 = correctAnswerVal;
                if (i == 29) TestAnswerObj.AnswerQue30 = correctAnswerVal;

                if (i == 30) TestAnswerObj.AnswerQue31 = correctAnswerVal;
                if (i == 31) TestAnswerObj.AnswerQue32 = correctAnswerVal;
                if (i == 32) TestAnswerObj.AnswerQue33 = correctAnswerVal;
                if (i == 33) TestAnswerObj.AnswerQue34 = correctAnswerVal;
                if (i == 34) TestAnswerObj.AnswerQue35 = correctAnswerVal;
                if (i == 35) TestAnswerObj.AnswerQue36 = correctAnswerVal;
                if (i == 36) TestAnswerObj.AnswerQue37 = correctAnswerVal;
                if (i == 37) TestAnswerObj.AnswerQue38 = correctAnswerVal;
                if (i == 38) TestAnswerObj.AnswerQue39 = correctAnswerVal;
                if (i == 39) TestAnswerObj.AnswerQue40 = correctAnswerVal;

                if (i == 40) TestAnswerObj.AnswerQue41 = correctAnswerVal;
                if (i == 41) TestAnswerObj.AnswerQue42 = correctAnswerVal;
                if (i == 42) TestAnswerObj.AnswerQue43 = correctAnswerVal;
                if (i == 43) TestAnswerObj.AnswerQue44 = correctAnswerVal;
                if (i == 44) TestAnswerObj.AnswerQue45 = correctAnswerVal;
                if (i == 45) TestAnswerObj.AnswerQue46 = correctAnswerVal;
                if (i == 46) TestAnswerObj.AnswerQue47 = correctAnswerVal;
                if (i == 47) TestAnswerObj.AnswerQue48 = correctAnswerVal;
                if (i == 48) TestAnswerObj.AnswerQue49 = correctAnswerVal;
                if (i == 49) TestAnswerObj.AnswerQue50 = correctAnswerVal;

                if (i == 50) TestAnswerObj.AnswerQue51 = correctAnswerVal;
                if (i == 51) TestAnswerObj.AnswerQue52 = correctAnswerVal;
                if (i == 52) TestAnswerObj.AnswerQue53 = correctAnswerVal;
                if (i == 53) TestAnswerObj.AnswerQue54 = correctAnswerVal;
                if (i == 54) TestAnswerObj.AnswerQue55 = correctAnswerVal;
                if (i == 55) TestAnswerObj.AnswerQue56 = correctAnswerVal;
                if (i == 56) TestAnswerObj.AnswerQue57 = correctAnswerVal;
                if (i == 57) TestAnswerObj.AnswerQue58 = correctAnswerVal;
                if (i == 58) TestAnswerObj.AnswerQue59 = correctAnswerVal;
                if (i == 59) TestAnswerObj.AnswerQue60 = correctAnswerVal;

                if (i == 60) TestAnswerObj.AnswerQue61 = correctAnswerVal;
                if (i == 61) TestAnswerObj.AnswerQue62 = correctAnswerVal;
                if (i == 62) TestAnswerObj.AnswerQue63 = correctAnswerVal;
                if (i == 63) TestAnswerObj.AnswerQue64 = correctAnswerVal;
                if (i == 64) TestAnswerObj.AnswerQue65 = correctAnswerVal;
                if (i == 65) TestAnswerObj.AnswerQue66 = correctAnswerVal;
                if (i == 66) TestAnswerObj.AnswerQue67 = correctAnswerVal;
                if (i == 67) TestAnswerObj.AnswerQue68 = correctAnswerVal;
                if (i == 68) TestAnswerObj.AnswerQue69 = correctAnswerVal;
                if (i == 69) TestAnswerObj.AnswerQue70 = correctAnswerVal;

                if (i == 70) TestAnswerObj.AnswerQue71 = correctAnswerVal;
                if (i == 71) TestAnswerObj.AnswerQue72 = correctAnswerVal;
                if (i == 72) TestAnswerObj.AnswerQue73 = correctAnswerVal;
                if (i == 73) TestAnswerObj.AnswerQue74 = correctAnswerVal;
                if (i == 74) TestAnswerObj.AnswerQue75 = correctAnswerVal;
                if (i == 75) TestAnswerObj.AnswerQue76 = correctAnswerVal;
                if (i == 76) TestAnswerObj.AnswerQue77 = correctAnswerVal;
                if (i == 77) TestAnswerObj.AnswerQue78 = correctAnswerVal;
                if (i == 78) TestAnswerObj.AnswerQue79 = correctAnswerVal;
                if (i == 79) TestAnswerObj.AnswerQue80 = correctAnswerVal;

                if (i == 80) TestAnswerObj.AnswerQue81 = correctAnswerVal;
                if (i == 81) TestAnswerObj.AnswerQue82 = correctAnswerVal;
                if (i == 82) TestAnswerObj.AnswerQue83 = correctAnswerVal;
                if (i == 83) TestAnswerObj.AnswerQue84 = correctAnswerVal;
                if (i == 84) TestAnswerObj.AnswerQue85 = correctAnswerVal;
                if (i == 85) TestAnswerObj.AnswerQue86 = correctAnswerVal;
                if (i == 86) TestAnswerObj.AnswerQue87 = correctAnswerVal;
                if (i == 87) TestAnswerObj.AnswerQue88 = correctAnswerVal;
                if (i == 88) TestAnswerObj.AnswerQue89 = correctAnswerVal;
                if (i == 89) TestAnswerObj.AnswerQue90 = correctAnswerVal;

                if (i == 90) TestAnswerObj.AnswerQue91 = correctAnswerVal;
                if (i == 91) TestAnswerObj.AnswerQue92 = correctAnswerVal;
                if (i == 92) TestAnswerObj.AnswerQue93 = correctAnswerVal;
                if (i == 93) TestAnswerObj.AnswerQue94 = correctAnswerVal;
                if (i == 94) TestAnswerObj.AnswerQue95 = correctAnswerVal;
                if (i == 95) TestAnswerObj.AnswerQue96 = correctAnswerVal;
                if (i == 96) TestAnswerObj.AnswerQue97 = correctAnswerVal;
                if (i == 97) TestAnswerObj.AnswerQue98 = correctAnswerVal;
                if (i == 98) TestAnswerObj.AnswerQue99 = correctAnswerVal;
                if (i == 99) TestAnswerObj.AnswerQue100 = correctAnswerVal;

            }
        }
        return TestAnswerObj;
    }

    [WebMethod(Description="INSERT MARKS DETAILS")]
    public int InsertMarksDetails(List<OmrApiResultHelper> ResultList, string TestCreater)
    {
        int rowUpdateCount = 0;
        for(int count = 0; count < ResultList.Count; count++)
        {
            string rollNo = ResultList[count].RollNumber;
            string testCreaterMobNo = TestCreater;
            string testId = ResultList[count].TestId;
            int corrAnsCount = Convert.ToInt32(ResultList[count].NumberOfRightAns);
            int inCorrAnsCount = Convert.ToInt32(ResultList[count].NumberOfWrongAns);
            int notAnsCount = 0;
            int totalMarks = Convert.ToInt32(ResultList[count].TotalMarks);

            string sql = " INSERT INTO tblOMRScoreReport ([RollNo],[TeacherORDefaultMobNo],[TestId],[TestCreaterId],[InsertDate],[CorrectAnswersCount],[InCorrectAnswersCount],[NotAnsweredQuetionsCount],[TotalMarks]) " +
                            " VALUES ('" + rollNo + "','" + testCreaterMobNo + "','" + testId + "','" + testCreaterMobNo + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + corrAnsCount + "','" + inCorrAnsCount + "','" + notAnsCount + "','" + totalMarks + "')";
            cc.ExecuteNonQuery(sql);
            rowUpdateCount += 1;

        }
        return rowUpdateCount;
    }

    [WebMethod(Description = "Check For Valid Installation Key")]
    public int CheckValidKey(string mobileNumber,string key)
    {
        int valid;
        string sql = "SELECT * FROM tblOMRSystemKey WHERE [InstituteHeadMobNumber]='" + mobileNumber + "' and [OMRKEY]='" + key + "'";
        DataSet ds = cc.ExecuteDataset(sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            valid = 1;
        }
        else
        {
            valid = 0;
        }
        return valid;
    }
}
