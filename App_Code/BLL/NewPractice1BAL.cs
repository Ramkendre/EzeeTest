using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for NewPractice1BAL
/// </summary>
public class NewPractice1BAL
{
    DataSet ds = new DataSet();
    NewPractice1DAL newpractice1dal = new NewPractice1DAL();
	public NewPractice1BAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string medium;

    public string Medium
    {
        get { return medium; }
        set { medium = value; }
    }

    private string subjectid;

    public string Subjectid
    {
        get { return subjectid; }
        set { subjectid = value; }
    }

    private string Queslevel;

    public string Queslevel1
    {
        get { return Queslevel; }
        set { Queslevel = value; }
    }

    private string typeofexam;

    public string Typeofexam
    {
        get { return typeofexam; }
        set { typeofexam = value; }
    }

    private string Class_id;

    public string Class_id1
    {
        get { return Class_id; }
        set { Class_id = value; }
    }

    private string material;

    public string Material
    {
        get { return material; }
        set { material = value; }
    }
    private string RoleID;

    public string RoleID1
    {
        get { return RoleID; }
        set { RoleID = value; }
    }


    private string usertype;

    public string Usertype
    {
        get { return usertype; }
        set { usertype = value; }
    }

    private string chapter;

    public string Chapter
    {
        get { return chapter; }
        set { chapter = value; }
    }
    private string rowFrom;

    public string RowFrom
    {
        get { return rowFrom; }
        set { rowFrom = value; }
    }

    private string rowTo;

    public string RowTo
    {
        get { return rowTo; }
        set { rowTo = value; }
    }

    private string topicid;

    public string Topicid
    {
        get { return topicid; }
        set { topicid = value; }
    }

    public DataSet getQuestionNewpractice(NewPractice1BAL newpractice1bal)
    {
        ds = newpractice1dal.getQuestionNewpractice(newpractice1bal);
        return ds;
    }


    public DataSet getQuestionNewpracticeCount(NewPractice1BAL newpractice1bal)
    {
        ds = newpractice1dal.getQuestionNewpracticeCount(newpractice1bal);
        return ds;
    }

    public DataSet getQuestionNewpracticeRSB(NewPractice1BAL newpractice1bal)
    {
        ds = newpractice1dal.getQuestionNewpracticeRSB(newpractice1bal);
        return ds;
    }


    public DataSet getQuestionNewpracticeCountRSB(NewPractice1BAL newpractice1bal)
    {
        ds = newpractice1dal.getQuestionNewpracticeCountRSB(newpractice1bal);
        return ds;
    }

}