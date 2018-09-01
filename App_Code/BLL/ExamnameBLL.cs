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
/// Summary description for ExamnameBLL
/// </summary>
public class ExamnameBLL
{
    enameDAL edal = new enameDAL();

	public ExamnameBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    int status;
    DataSet ds = new DataSet();

#region proregion
    private int eid;
    public int Eid
    {
        get { return eid; }
        set { eid = value; }
    }
    private string ename;
    public string Ename
    {
        get { return ename; }
        set { ename = value; }
    }
    private int cid;
    public int Cid
    {
        get { return cid; }
        set { cid = value; }
    }

    private int classid;

    public int Classid
    {
        get { return classid; }
        set { classid = value; }
    }

    private int topic_id;
    public int Topic_id
    {
        get { return topic_id; }
        set { topic_id = value; }
    }

    private int chapter_id;

    public int Chapter_id
    {
        get { return chapter_id; }
        set { chapter_id = value; }
    }

    private int subject_id;
    public int Subject_id
    {
        get { return subject_id; }
        set { subject_id = value; }
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
# endregion proregion

    //private List<ExamnameBLL> getallename;

    //public List<ExamnameBLL> Getallename
    //{
    //    get { return getallename; }
    //    set { getallename = value; }
    //}



    public int addnew(ExamnameBLL ebal)
    {
        status = edal.addnew(ebal);
        return status;
    
    }

    public int _update(ExamnameBLL ebal)
    {
        status = edal._update(ebal);
        return status;

    }
    public DataSet _selectExamname(ExamnameBLL  ebal)
    {
        ds = edal._selectExamnameDal(ebal);
        return ds;
    }

    public int _deleteExamname(ExamnameBLL ebal)
    {
        status = edal._deleteExamnameDal(ebal);
        return status;
    }

    public DataSet GetAllEName()
    {
        ds = edal.DALGetAllEName();
        return ds;
    }
    public DataSet GetAllENamecid(int cid)
    {
        ds = edal.DALGetAllENamecid(cid);
        return ds;
    }


    //public DataSet GetAllENamecid(int cid)
    //{
    //    ds = edal.DALGetAllENamecid(cid);
    //    return ds;
    //}

// for select exam name by class name
    public DataSet GetAllENameclassid( string examtype)
    {
        ds = edal.DALGetAllENameclassid(examtype);
        return ds;
    }



    public  ExamnameBLL(string nm,int cid)

    {
        this.Ename = nm;
        this.Cid = cid;
    
    }

    public void addexam(string nm,int cid)
    {

        edal.addExam(Ename,Cid);
         
    }

    //public void BLLGetSelectedCategory(CategoryBLL ct)
    //{
    //    categoryDALObj.DALGetSelectedCategory(ct);
    //}
}
