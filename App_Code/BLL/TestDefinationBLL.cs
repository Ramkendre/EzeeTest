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
using System.Collections.Generic;

/// <summary>
/// Summary description for TestDefinationBLL
/// </summary>
public class TestDefinationBLL
{
    TestDefijnationDLL testdal = new TestDefijnationDLL();
	public TestDefinationBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
     
    
    int status;
    DataSet ds = new DataSet();

    #region Properties
    private int Test_ID;

    public int Test_ID1
    {
        get { return Test_ID; }
        set { Test_ID = value; }
    }
    private string ExamName;

    public string ExamName1
    {
        get { return ExamName; }
        set { ExamName = value; }
    }

    private string testtype;

    public string Testtype
    {
        get { return testtype; }
        set { testtype = value; }
    }
   
    private int examid;

    public int Examid
    {
        get { return examid; }
        set { examid = value; }
    }

    private string Exandate;

    public string Exandate1
    {
        get { return Exandate; }
        set { Exandate = value; }
    }
    private string testName;

    public string TestName
    {
        get { return testName; }
        set { testName = value; }
    }
    private string duration;

    public string Duration
    {
        get { return duration; }
        set { duration = value; }
    }
    private string Exam_Subject;

    public string Exam_Subject1
    {
        get { return Exam_Subject; }
        set { Exam_Subject = value; }
    }
    private string topic;

    public string Topic
    {
        get { return topic; }
        set { topic = value; }
    }

    private int Chapter_id;

    public int Chapter_id1
    {
        get { return Chapter_id; }
        set { Chapter_id = value; }
    }

    private int IndexNo;

    public int IndexNo1
    {
        get { return IndexNo; }
        set { IndexNo = value; }
    }

    private int Topic_id;

    public int Topic_id1
    {
        get { return Topic_id; }
        set { Topic_id = value; }
    }

    private string Subject_id;

    public string Subject_id1
    {
        get { return Subject_id; }
        set { Subject_id = value; }
    }

    private string SubjectName;

    public string SubjectName1
    {
        get { return SubjectName; }
        set { SubjectName = value; }
    }
   
    private int Class_id;

    public int Class_id1
    {
        get { return Class_id; }
        set { Class_id = value; }
    }

    private string mediumID;
    public string MediumID
    {
        get { return mediumID; }
        set { mediumID = value; }
    }

    private int typeOfExam;
    public int TypeOfExam
    {
        get { return typeOfExam; }
        set { typeOfExam = value; }
    }


    private int d1;

    public int D1
    {
        get { return d1; }
        set { d1 = value; }
    }
    private int d2;

    public int D2
    {
        get { return d2; }
        set { d2 = value; }
    }
    private int d3;

    public int D3
    {
        get { return d3; }
        set { d3 = value; }
    }

    private string LoginId;

    public string LoginId1
    {
        get { return LoginId; }
        set { LoginId = value; }
    }

    private string markCorrA;
    public string MarkCorrA
    {
        get { return markCorrA; }
        set { markCorrA = value; }
    }

    private string markPass;

    public string MarkPass
    {
        get { return markPass; }
        set { markPass = value; }
    }
    private string retake;

    public string Retake
    {
        get { return retake; }
        set { retake = value; }
    }
    private string breakAllow;

    public string BreakAllow
    {
        get { return breakAllow; }
        set { breakAllow = value; }
    }

    private string reverseNavig;

    public string ReverseNavig
    {
        get { return reverseNavig; }
        set { reverseNavig = value; }
    }
    private string negativeMark;

    public string NegativeMark
    {
        get { return negativeMark; }
        set { negativeMark = value; }
    }

    private string markforNegative;

    public string MarkforNegative
    {
        get { return markforNegative; }
        set { markforNegative = value; }
    }

    private string TypeofMaterial;

    public string TypeofMaterial1
    {
        get { return TypeofMaterial; }
        set { TypeofMaterial = value; }
    }
    private string GroupOfQuestion;

    public string GroupOfQuestion1
    {
        get { return GroupOfQuestion; }
        set { GroupOfQuestion = value; }
    }

    private int groupofExam;

    public int GroupofExam
    {
        get { return groupofExam; }
        set { groupofExam = value; }
    }

    #endregion properties

    

    public int _insertTestDefi(TestDefinationBLL BllTestd)
    {
        status = testdal._insertTestDefi(BllTestd);
        return status;
    }

    public DataSet _selecttestdef(TestDefinationBLL BllTestd)
    {
        ds = testdal._selecttestdef(BllTestd);
        return ds;
    }

    public int _updatetestdef(TestDefinationBLL BllTestd)
    {
        status = testdal._updatetestdef(BllTestd);
        return status;
    }


    public int _deletetestdef(TestDefinationBLL BllTestd)
    {
        status = testdal._deletetestdef(BllTestd);
        return status;
    }


    public DataSet GetAllTestDefinesubject(int examid)
    {
        ds = testdal.GetAllTestDefinesubject(examid);
        return ds;
    }



    private List<TestDefinationBLL> _getAlltestdefination;

    public List<TestDefinationBLL> GetAlltestdefination
    {
        get { return _getAlltestdefination; }
        set { _getAlltestdefination = value; }
    }

   
    public DataSet GetAllTestDefine()
    {
        ds = testdal.DALGetAllTestDefination();
        return ds;
    }

    public DataSet GetAllTestDefineEname(string  ename )
    {
        ds = testdal.DALGetAllTDename(ename);
        return ds;
    }

    public DataSet GetAllTestDefineSub(string sname)
    {
        ds = testdal.DALGetAllTDsname(sname);
        return ds;
    }
    public DataSet GetAllTestDefinetid(string tid)
    {
        ds = testdal.DALGetAllTDtid(tid);
        return ds;
    }


    public DataSet GetTestByGroupofQues(TestDefinationBLL testbal)
    {
        ds = testdal.GetTestByGroupofQues(testbal);
        return ds;
    }



    //********************** AddExamchapter *************
    public DataSet TestbyGroupofQuesLoginId5(TestDefinationBLL testbal)
    {
        ds = testdal.TestbyGroupofQuesLoginId5(testbal);
        return ds;
    }

    public DataSet loadsubject(string TestId)
    {
        ds = testdal.loadsubject(TestId);
        return ds;
    }


    //********************** Assign QuestionInExam page *************

    public DataSet getAssignTestDetails(TestDefinationBLL testbal)
    {
        ds = testdal.getAssignTestDetails(testbal);
        return ds;
    }

    public DataSet getLevelTestDef(TestDefinationBLL testbal)
    {
        ds = testdal.getLevelTestDef(testbal);
        return ds;
    }


}
