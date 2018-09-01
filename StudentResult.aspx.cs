using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.IO;

using System.Collections.Generic;
using System.Security.Permissions;
using System.Security.AccessControl;
using System.Security.Authentication;

public partial class StudentResult : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string SqlQuery = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        goDataToServer();
    }

    public void goDataToServer()
    {
       
        DataSet ds = new DataSet();
        XmlReader xmlFile;
        string sql = string.Empty;
        string paperID = Convert.ToString(Session["TestID"]);
        string login = Convert.ToString(Session["Loginid"]);

        string pathString = "D:\\eZeeTest\\eZee'" + login + paperID + "'.xml";

        string[] dirs = Directory.GetFiles(@"D:\eZeeTest\", "eZee*");

        var temp = new List<string>();
        foreach (var s in dirs)
        {
            if (!string.IsNullOrEmpty(s))
                temp.Add(s);
        }
        dirs = temp.ToArray();

        foreach (string dir in dirs)
        {
            xmlFile = XmlReader.Create(dir, new XmlReaderSettings());
            ds.ReadXml(xmlFile);
        }
        string B1, B2, B3, B4, B6, B7, B5, B8, B9, B10, B11, B12, B13;


        for (int h = 0; h < ds.Tables[0].Rows.Count; h++)
        {
            if (ds.Tables[0].Rows[h].IsNull(0) == true)
            {
                ds.Tables[0].Rows[h].Delete();
            }
        }


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            B1 = (ds.Tables[0].Rows[i].ItemArray[0]).ToString();
            B2 = (ds.Tables[0].Rows[i].ItemArray[1]).ToString();
            B3 = (ds.Tables[0].Rows[i].ItemArray[2]).ToString();
            B4 = (ds.Tables[0].Rows[i].ItemArray[3]).ToString();
            B5 = (ds.Tables[0].Rows[i].ItemArray[4]).ToString();
            B6 = (ds.Tables[0].Rows[i].ItemArray[5]).ToString();
            B7 = (ds.Tables[0].Rows[i].ItemArray[6]).ToString();
            B8 = (ds.Tables[0].Rows[i].ItemArray[7]).ToString();
            B9 = (ds.Tables[0].Rows[i].ItemArray[8]).ToString();
            B10 = (ds.Tables[0].Rows[i].ItemArray[9]).ToString();
            B11 = (ds.Tables[0].Rows[i].ItemArray[10]).ToString();
            B12 = (ds.Tables[0].Rows[i].ItemArray[11]).ToString();
            B13 = (ds.Tables[0].Rows[i].ItemArray[12]).ToString();


            string SqlQuery4 = "Select UserMobileNo From tblAppScoreReport Where UserMobileNo='" + B1 + "'and TeacherMobNo='" + B2 + "' and TestId='" + B4 + "' and ipAddress='" + B13 + "'";
            string StatusValue = cc.ExecuteScalar(SqlQuery4);

            if (StatusValue == "")
            {
                string SqlQuery2 = " Insert Into tblAppScoreReport([UserMobileNo],[TeacherMobNo],[ExamId],[TestId],[IMEI],[TestDate],[StartTime],[EndTime] " +
                       " ,[CorrectAnswered_count],[InCorrectanswered_count],[NotAnsweredQuestions_count], " +
                       " [Status],[ipAddress]) Values('" + B1 + "','" + B2 + "','" + B3 + "','" + B4 + "','" + B5 + "','" + B6 + "','" + B7 + "','" + B8 + "','" + B9 + "','" + B10 + "','" + B11 + "','" + B12 + "','" + B13 + "')";

                int status = cc.ExecuteNonQuery(SqlQuery2);
                
                if (status != 0)
                {
                    Label lbl = new Label();
                    lbl.ForeColor = System.Drawing.Color.Green;
                    lbl.Font.Bold = true;
                    lbl.Text = "Record Inserted Successfully!!!";
                    this.Controls.Add(lbl);
                }
                else
                {
                    Label lbl = new Label();
                    lbl.ForeColor = System.Drawing.Color.Green;
                    lbl.Font.Bold = true;
                    lbl.Text = "Record Not Inserted Successfully!!!";
                    this.Controls.Add(lbl);
                }
            }
        }
    }

    protected void button_Click(object sender, EventArgs e)
    {
        goDataToServer();
    }
}
