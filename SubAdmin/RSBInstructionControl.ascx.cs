using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


public partial class SubAdmin_RSBInstructionControl : System.Web.UI.UserControl
{
    CommonCode cc = new CommonCode();

    protected void Page_Load(object sender, EventArgs e)
    {
        getTestDefinition();
    }

    int Qno = 0;
    int hr = 0, min = 0;
    string exNm = "";

    void getTestDefinition()
    {
        try
        {
            //string sqlTest = "SELECT [Test_ID],[Exam_name],[Exam_date],[Exam_Duration],[DLevel1],[DLevel2],[DLevel3] ,[MarkCorrA],[MarkPass],[NegativeMark],[MarkforNegative] FROM tblTestDefinition" +
            //    " where Test_ID='" + Convert.ToString(Session["TestID"]) + "'";

            string sqlTest = "SELECT [Test_ID],[Exam_name],[Exam_date],[Exam_Duration],[MarkCorrA],[MarkPass],[NegativeMark],[MarkforNegative],[TotNoQues] FROM tblTestDefinition" +
                " where Test_ID='" + Convert.ToString(Session["TestID"]) + "'";




            DataSet ds = cc.ExecuteDataset(sqlTest);

            exNm = Convert.ToString(ds.Tables[0].Rows[0]["Exam_name"]);
            lblExnm.Text = exNm;

            //Qno = Convert.ToInt32(ds.Tables[0].Rows[0]["DLevel1"]) + Convert.ToInt32(ds.Tables[0].Rows[0]["DLevel2"]) + Convert.ToInt32(ds.Tables[0].Rows[0]["DLevel3"]);
            //lblQnoI.Text = Qno.ToString();

            Qno = Convert.ToInt32(ds.Tables[0].Rows[0]["TotNoQues"]);
            lblQnoI.Text = Qno.ToString();


            hr = Convert.ToInt32(ds.Tables[0].Rows[0]["Exam_Duration"]) / 60;
            min = Convert.ToInt32(ds.Tables[0].Rows[0]["Exam_Duration"]) % 60;

            if (hr != 0 && min != 0)
                lblTime1.Text = hr + " hrs & " + min + " mins";
            else if (hr != 0)
                lblTime1.Text = hr + " hrs";
            else if (min != 0)
                lblTime1.Text = min + " mins";

        }
        catch (Exception ex) { }
    }
}
