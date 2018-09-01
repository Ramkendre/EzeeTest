using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AddExamChapterBAL
/// </summary>
public class AddExamChapterBAL
{
    AddExamChapterDAL addexamchapterdal = new AddExamChapterDAL();
    DataSet ds = new DataSet();
    int status;

	public AddExamChapterBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //[TestID],[ChapterName],[Subject_id],Chapter_id,[EntryDate],[LoginId]) 

    private int AecID;
    public int AecID1
    {
        get { return AecID; }
        set { AecID = value; }
    }

    private int TestID;
    public int TestID1
    {
        get { return TestID; }
        set { TestID = value; }
    }

    private int Subject_id;
    public int Subject_id1
    {
        get { return Subject_id; }
        set { Subject_id = value; }
    }

    private string ChapterName;
    public string ChapterName1
    {
        get { return ChapterName; }
        set { ChapterName = value; }
    }


    private string Chapter_id;
    public string Chapter_id1
    {
        get { return Chapter_id; }
        set { Chapter_id = value; }
    }

    private string EntryDate;
    public string EntryDate1
    {
        get { return EntryDate; }
        set { EntryDate = value; }
    }

    private string LoginId;
    public string LoginId1
    {
        get { return LoginId; }
        set { LoginId = value; }
    }


    public int InsertUpdateExamChapter(AddExamChapterBAL addexamchapterbal)
    {
        status = addexamchapterdal.InsertUpdateExamChapter(addexamchapterbal);
        return status;
    }

    public DataSet GetRecordModify(AddExamChapterBAL addexamchapterbal)
    {
        ds = addexamchapterdal.GetRecordModify(addexamchapterbal);
        return ds;
    }

}