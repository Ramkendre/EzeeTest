using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

// NOTE: If you change the class name "TestAppQuestion" here, you must also update the reference to "TestAppQuestion" in Web.config.
public class TestAppQuestion : ITestAppQuestion
{
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    string sql = "";

	public void DoWork()
	{
	}

    public DataSet dsgetQuestionbyClassid(GetQuestion objGetQuestion)
    {
        try
        {
            sql = "select top 5 * from   viewtblQuestionAccess where Class_id='" + objGetQuestion.Classid + "' ";
            ds = cc.ExecuteDataset(sql);

        }
        catch
        {
        }
        return ds;

    }

    public string XmlgetQuestionbyClassid(GetQuestion objGetQuestion)
    {
        string getxmlQues = "";
        try
        {
            sql = "select top 5 * from   viewtblQuestionAccess where Class_id='" + objGetQuestion.Classid + "' ";
            ds = cc.ExecuteDataset(sql);
            getxmlQues = ds.GetXml();
        }
        catch
        {
        }
        return getxmlQues;

    }

    public string HelloAtul()
    {
        string abc = "Hello ezeedrug App";
        return abc;
    }

    //public XmlDocument XmldatatypeGetQues(GetQuestion objGetQuestion)
    //{
    //    XmlDataDocument xmldatadoc = new XmlDataDocument();
    //    try
    //    {
    //        sql = "select top 5 * from   viewtblQuestionAccess where Class_id='" + objGetQuestion.Classid + "' ";
    //        ds = cc.ExecuteDataset(sql);
    //        xmldatadoc = new XmlDataDocument(ds);
    //        XmlElement xmlelement = xmldatadoc.DocumentElement;

    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //    return xmldatadoc;
    //}




}

