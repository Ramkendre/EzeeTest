using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for AssignQuestionInExamBAL
/// </summary>
public class AssignQuestionInExamBAL
{
    AssignQuestionInExamDAL assignQuestioninexamDal = new AssignQuestionInExamDAL();
    DataSet ds = new DataSet();
    int status;

    public AssignQuestionInExamBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private string QuesVerify;

    public string QuesVerify1
    {
        get { return QuesVerify; }
        set { QuesVerify = value; }
    }

    private string Class_AdmSuggest;
    public string Class_AdmSuggest1
    {
        get { return Class_AdmSuggest; }
        set { Class_AdmSuggest = value; }
    }


    private string Class_AdmVerify;

    public string Class_AdmVerify1
    {
        get { return Class_AdmVerify; }
        set { Class_AdmVerify = value; }
    }

    private string Class_AdmLogin;

    public string Class_AdmLogin1
    {
        get { return Class_AdmLogin; }
        set { Class_AdmLogin = value; }
    }

    private int SNO;

    public int SNO1
    {
        get { return SNO; }
        set { SNO = value; }
    }


    private string ViewtblName;

    public string ViewtblName1
    {
        get { return ViewtblName; }
        set { ViewtblName = value; }
    }
    private int NewQID;

    public int NewQID1
    {
        get { return NewQID; }
        set { NewQID = value; }
    }

   

    public int UpdateQuestionVerifyClassAdmin(AssignQuestionInExamBAL assignQuestioninexamBal)
    {
        status = assignQuestioninexamDal.UpdateQuestionVerifyClassAdmin(assignQuestioninexamBal);
        return status;
    }

    public DataSet SelectQuestionAssignVIEW(AssignQuestionInExamBAL assignQuestioninexamBal)
    {
        ds = assignQuestioninexamDal.SelectQuestionAssignVIEW(assignQuestioninexamBal);
        return ds;
    }

    public DataSet SelectInCorrectQuestions(AssignQuestionInExamBAL assignQuestioninexamBal)
    {
        ds = assignQuestioninexamDal.SelectInCorrectQuestions(assignQuestioninexamBal);
        return ds;
    }






}