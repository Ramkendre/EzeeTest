using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Xml;

// NOTE: If you change the interface name "ITestAppQuestion" here, you must also update the reference to "ITestAppQuestion" in Web.config.
[ServiceContract]
public interface ITestAppQuestion
{
	
    [OperationContract]
    void DoWork();

    [OperationContract]
    DataSet dsgetQuestionbyClassid(GetQuestion objGetQuestion);

    [OperationContract]
    string XmlgetQuestionbyClassid(GetQuestion objGetQuestion);

    //[OperationContract]
    //XmlDocument XmldatatypeGetQues(GetQuestion objGetQuestion);

    [OperationContract]
    string HelloAtul();
}

[DataContract]
public class GetQuestion
{
    int QiesID;

   


   

    string TypeofExam = string.Empty;
    string classid = string.Empty;

    public string Classid
    {
        get { return classid; }
        set { classid = value; }
    }

    [DataMember]
    public int QiesID1
    {
        get { return QiesID; }
        set { QiesID = value; }
    }

    [DataMember]
    public string TypeofExam1
    {
        get { return TypeofExam; }
        set { TypeofExam = value; }
    }

  

    

}


