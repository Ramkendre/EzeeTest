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

public partial class userControl_ShowTheoryQuestion : System.Web.UI.UserControl
{
    SqlConnection con = null;
    SqlDataAdapter da = null;
    DataSet ds = new DataSet();
    string s11;
    string[] arr2 = null;
    int r;
    string SNONewID;

    CommonCode cc = new CommonCode();
    public string Chapter_id = "";
    public int TypeOFExam = 0;
    public int Class_id = 0;
    public int Subject_id = 0;

    public string TypeofQues = "";
    public string QType = "", Q1Type = "";
    public string TypeDB = "", lang = "";
    public static string hintDB = "";
    public int settingid1 = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string SNO1 = Convert.ToString(Session["QuestionID1"]); // get Sno of All Question of table 
        string[] arr2 = SNO1.Split(',');
        if (arr2.Length > r)
        {
            Session["SNO"] = Convert.ToInt32(Session["SNO"]) + 1;  // Initial value is  Session["SNO"]=-1;
            r = Convert.ToInt32(Session["SNO"]);

            SNONewID = Convert.ToString(arr2[r]);
        }

        loadControl();
    }

    void loadControl()
    {
        try
        {
            string s11 = "tblT5167"; //+ Convert.ToString(Session["CompanyId"]);  //+ "" + Convert.ToString(Session["TestID"]);

            string sql = "SELECT * FROM  " + s11 + "  WHERE SNO=" + SNONewID + " ";
            DataSet ds = cc.ExecuteDataset(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                fetchCommonData(ds.Tables[0].Rows[0]);
            }

            ds = null;
        }
        catch
        {
        }
    }

    public void fetchCommonData(DataRow row)
    {
        string s11 = "tblT5167";// +Convert.ToString(Session["CompanyId"]);    //+ "" + Convert.ToString(Session["TestID"]);

        try
        {
            string loginId = Convert.ToString(Session["LoginId"]);
            string resolve = string.Empty;

            if (row.ItemArray.Count() > 0)
            {
                int SNO = Convert.ToInt32(row["SNO"]);
                int EQID = Convert.ToInt32(row["EQID"]);

                char qno = 'a';

                if (Session["SubSubQuestionNo"] == "0")
                    lblqn.Text = qno.ToString();
                else
                {
                    qno = Convert.ToString(Session["SubSubQuestionNo"]).ToCharArray()[0];
                    lblqn.Text = ((char)(qno + 1)).ToString();
                }
                Session["SubSubQuestionNo"] = lblqn.Text;

                lblqn.Text = "(" + lblqn.Text + ")";

                //************************************

                QType = Convert.ToString(row["QType"]);
                Q1Type = Convert.ToString(row["Q1Type"]);
                TypeDB = Convert.ToString(row["TypeofDB"]);
                lang = Convert.ToString(row["Sellanguage"]);
                if (TypeDB == "Excel" && lang == "English")
                {
                    QType = "0";
                    Q1Type = "0";
                }
                else if (TypeDB == "Excel" && lang == "Marathi")
                {
                    QType = "1";
                    Q1Type = "1";
                }
                else if (TypeDB == "Excel" && lang == "MarathiMangal")
                {
                    QType = "3";
                    Q1Type = "3";
                }
                if (QType == "0")
                {
                    lblQuestion.Text = Convert.ToString(row["Question"]);
                    lblQuestion.Text.Replace("@011", "'");
                    lblQuestion.Visible = true;
                    lblQuestion.Font.Name = "Cambria Math"; //Times New Roman
                    lblQuestion.Font.Size = 9;
                    imgQues.Visible = false;
                }
                else if (QType == "1")
                {
                    lblQuestion.Text = Convert.ToString(row["Question"]);
                    lblQuestion.Text.Replace("@011", "'");
                    lblQuestion.Visible = true;
                    lblQuestion.Font.Name = "Cambria Math"; //Shivaji01
                    lblQuestion.Font.Size = 9;
                    imgQues.Visible = false;
                }
                else if (QType == "3")
                {
                    resolve = Convert.ToString(row["Question"]);
                    resolve = resolve.Replace("@011", "'");
                    lblQuestion.Text = resolve; //Convert.ToString(row["Question"]);
                    //lblQuestion.Text.Replace("@011", "'");
                    lblQuestion.Visible = true;
                    lblQuestion.Font.Name = "Cambria Math"; //Shivaji01
                    lblQuestion.Font.Size = 9;
                    imgQues.Visible = false;
                }
                else
                {
                    lblQuestion.Visible = false;
                    imgQues.Visible = true;
                    imgQues.ImageUrl = "TheoryQuesImagehandler.ashx?para=" + EQID + ",Question," + s11 + "";
                }

                //QuesWithImage
                if (Q1Type == "0")
                {
                    lblQuestionwithImage.Text = Convert.ToString(row["QuesWithImage"]);
                    lblQuestionwithImage.Text.Replace("@011", "'");
                    imgQuesImage.Visible = false;
                    if (lblQuestionwithImage.Text == "")
                    {
                        lblQuestionwithImage.Visible = false;    //for reasoning type Question
                    }
                    else
                    {
                        lblQuestionwithImage.Visible = true;    //for reasoning type Question
                    }

                    lblQuestionwithImage.Font.Name = "Cambria Math";
                    lblQuestionwithImage.Font.Size = 9;
                }
                else if (Q1Type == "1")
                {
                    lblQuestionwithImage.Text = Convert.ToString(row["QuesWithImage"]);
                    lblQuestionwithImage.Text.Replace("@011", "'");
                    imgQuesImage.Visible = false;
                    if (lblQuestionwithImage.Text == "")
                    {
                        lblQuestionwithImage.Visible = false;
                    }
                    else
                    {
                        lblQuestionwithImage.Visible = true;
                    }
                    lblQuestionwithImage.Font.Name = "Cambria Math";
                    lblQuestionwithImage.Font.Size = 9;
                }
                else if (Q1Type == "3")
                {
                    resolve = Convert.ToString(row["QuesWithImage"]);
                    resolve = resolve.Replace("@011", "'");

                    lblQuestionwithImage.Text = resolve;//Convert.ToString(row["QuesWithImage"]);
                   // lblQuestionwithImage.Text.Replace("@011", "'");
                    imgQuesImage.Visible = false;
                    if (lblQuestionwithImage.Text == "")
                    {
                        lblQuestionwithImage.Visible = false;
                    }
                    else
                    {
                        lblQuestionwithImage.Visible = true;
                    }
                    lblQuestionwithImage.Font.Name = "Cambria Math";
                    lblQuestionwithImage.Font.Size = 9;
                }
                else
                {
                    lblQuestionwithImage.Text = Convert.ToString(row["QuesWithImage"]);
                    if (lblQuestionwithImage.Text != "")
                    {
                        imgQuesImage.ImageUrl = "TheoryQuesImagehandler.ashx?para=" + EQID + ",QuesWithImage," + s11 + "";
                        lblQuestionwithImage.Visible = false;
                        imgQuesImage.Visible = true;
                    }
                    else
                    {
                        imgQuesImage.Visible = false;
                        lblQuestionwithImage.Visible = false;
                    }
                }
            }
        }
        catch { }
    }
}
