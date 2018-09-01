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

public partial class ExamUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] id = Session["EQID"].ToString().Split(',');        
            loadControl(id[0]);

        Session["EQID"] = "";
        for (int i = 1; i < id.Length; i++)
        {
            if (id[i] != "")
            Session["EQID"] += id[i].ToString() + ",";
        }
    }

    public string myId = "";
    string s11 = "";

    public void loadControl(string reqQid)
    {
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            s11 = "tbl" + Convert.ToString(Session["CompanyId"]);

            string testID = Convert.ToString(Session["TestID"]);

            string Sql = "select SNO from  tblDefaultTest where TestID='" + testID + "' ";
            string defId = cc.ExecuteScalar(Sql);


            if (defId != "")
            {
                s11 = "tbl5164";
            }
                     

           string sql = "  with t as   (  select ROW_NUMBER()over(order by " + s11 + ".SNO)as EQID, " + s11 + ".*,tblItemValue.ItemValueId, tblItemValue.ItemId, tblItemValue.Name from " + s11 + "   inner join tblItemValue on tblItemValue.ItemValueId=" + s11 + ".TypeofQues    " +
           " where TestID='" + testID + "'  )select * from t where EQID=" + reqQid+" ";

            
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                fetchCommonData(ds.Tables[0].Rows[0]);                
            }
        }
        catch (Exception ex) 
        {
 
        }
    }

    CommonCode cc = new CommonCode();
    public string Chapter_id = "";
    public int TypeOFExam = 0;
    public int Class_id = 0;
    public int Subject_id = 0;

    public string TypeofQues = "";
    public string QType = "", Q1Type = "", AType = "", BType = "", CType = "", DType = "", EType = "", PType = "", RType = "", QType1 = "",
        SType = "", TType = "", passageType = "", hType = "";
    public string TypeDB = "", lang = "";
    public static string hintDB = "";
    public int settingid1 = 0;

    public void fetchCommonData(DataRow row)
    {
        try
        {
            string testID = Convert.ToString(Session["TestID"]);
            //string loginId = Convert.ToString(Session["LoginId"]);

            if (row.ItemArray.Count() > 0)
            {

                int QId = Convert.ToInt32(row["Question_id"]);

                int EQID = Convert.ToInt32(row["EQID"]);
                //lblQNo.Text = EQID.ToString();

                lblQuestion_id.Text = Convert.ToString(EQID);
                lblCorrectAns.Text = Convert.ToString(row["Correct_answer"]);

                TypeDB = Convert.ToString(row["TypeofDB"]);
                lang = Convert.ToString(row["Sellanguage"]);

                try
                {
                    settingid1 = Convert.ToInt32(row["SettingId"]);
                }
                catch { }

                string level = Convert.ToString(row["QuestionLevel"]);
                lbllevel.Text = "Level :" + level;

                TypeofQues = Convert.ToString(row["Name"]);
                lbltypeQues.Text = "Type of Question : " + TypeofQues;

                if (TypeDB == "Access")
                {
                    QType = Convert.ToString(row["QType"]);
                    Q1Type = Convert.ToString(row["Q1Type"]);
                    AType = Convert.ToString(row["AType"]);
                    BType = Convert.ToString(row["BType"]);
                    CType = Convert.ToString(row["CType"]);
                    DType = Convert.ToString(row["DType"]);
                    EType = Convert.ToString(row["EType"]);
                    PType = Convert.ToString(row["pType"]);
                    QType1 = Convert.ToString(row["QType1"]);
                    RType = Convert.ToString(row["RType"]);
                    SType = Convert.ToString(row["SType"]);
                    TType = Convert.ToString(row["TType"]);
                    passageType = Convert.ToString(row["passageType"]);
                    hType = Convert.ToString(row["hType"]);

                    settingid1 = Convert.ToInt32(row["SettingId"]);

                }
                else if (TypeDB == "Excel" && lang == "Marathi")
                {
                    QType = "1";
                    Q1Type = "1";
                    AType = "1";
                    BType = "1";
                    CType = "1";
                    DType = "1";
                    EType = "1";
                    PType = "1";
                    QType1 = "1";
                    RType = "1";
                    SType = "1";
                    TType = "1";
                    passageType = "1";
                    hType = "1";
                }
                else if (TypeDB == "Excel" && lang == "English")
                {
                    QType = "0";
                    Q1Type = "0";
                    AType = "0";
                    BType = "0";
                    CType = "0";
                    DType = "0";
                    EType = "0";
                    PType = "0";
                    QType1 = "0";
                    RType = "0";
                    SType = "0";
                    TType = "0";
                    passageType = "0";
                    hType = "0";
                }
                else if (TypeDB == "Excel" && lang == "MarathiMangal")
                {
                    QType = "3";
                    Q1Type = "3";
                    AType = "3";
                    BType = "3";
                    CType = "3";
                    DType = "3";
                    EType = "3";
                    PType = "3";
                    QType1 = "3";
                    RType = "3";
                    SType = "3";
                    TType = "3";
                    passageType = "3";
                    hType = "3";
                }
                //Question
                if (QType == "0")
                {
                    string s = Convert.ToString(row["Question"]);
                    s = s.Replace("@011", "'");
                    lblQuestion.Text = s;
                    lblQuestion.Visible = true;
                    lblQuestion.Font.Name = "Times New Roman";
                    lblQuestion.Font.Size = 10;
                    imgQues.Visible = false;
                }
                else if (QType == "1")
                {
                    string s = Convert.ToString(row["Question"]);
                    s = s.Replace("@011", "'");
                    lblQuestion.Text = s;
                    lblQuestion.Visible = true;
                    lblQuestion.Font.Name = "Shivaji01";
                    lblQuestion.Font.Size = 12;
                    imgQues.Visible = false;
                }
                else if (QType == "3")
                {
                    string s = Convert.ToString(row["Question"]);
                    s = s.Replace("@011", "'");
                    lblQuestion.Text = s;
                    lblQuestion.Visible = true;
                    lblQuestion.Font.Name = "Mangal";
                    lblQuestion.Font.Size = 12;
                    imgQues.Visible = false;
                }
                else
                {
                    lblQuestion.Visible = false;
                    imgQues.Visible = true;
                    imgQues.ImageUrl = "~/imgExamHandler.ashx?para=" + EQID + ",Question," + s11 + "," + testID + "";
                }

                //Option A
                if (AType == "0")
                {
                    string s = Convert.ToString(row["Answer1"]);
                    s = s.Replace("@011", "'");
                    lblOptA.Text = s;
                    imgoptA.Visible = false;
                    if (lblOptA.Text == "")
                    {
                        lblOptA.Visible = false;
                        lblA.Visible = false;
                    }
                    else
                    {
                        lblA.Visible = true;
                        lblOptA.Visible = true;
                    }
                    lblOptA.Font.Name = "Times New Roman";
                    lblOptA.Font.Size = 10;
                }
                else if (AType == "1")
                {
                    string s = Convert.ToString(row["Answer1"]);
                    s = s.Replace("@011", "'");
                    lblOptA.Text = s;
                    imgoptA.Visible = false;
                    if (lblOptA.Text == "")
                    {
                        lblOptA.Visible = false;
                        lblA.Visible = false;
                    }
                    else
                    {
                        lblA.Visible = true;
                        lblOptA.Visible = true;
                    }
                    lblOptA.Font.Name = "Shivaji01";
                    lblOptA.Font.Size = 12;
                }
                else if (AType == "3")
                {
                    string s = Convert.ToString(row["Answer1"]);
                    s = s.Replace("@011", "'");
                    lblOptA.Text = s;
                    imgoptA.Visible = false;
                    if (lblOptA.Text == "")
                    {
                        lblOptA.Visible = false;
                        lblA.Visible = false;
                    }
                    else
                    {
                        lblA.Visible = true;
                        lblOptA.Visible = true;
                    }
                    lblOptA.Font.Name = "Mangal";
                    lblOptA.Font.Size = 12;
                }
                else
                {
                    lblOptA.Visible = false;
                    imgoptA.Visible = true;
                    lblA.Visible = true;
                    imgoptA.ImageUrl = "~/imgExamHandler.ashx?para=" + EQID + ",Answer1," + s11 + "," + testID + "";
                }

                //Option B
                if (BType == "0")
                {
                    string s = Convert.ToString(row["Answer2"]);
                    s = s.Replace("@011", "'");
                    lblOptB.Text = s;
                    imgoptB.Visible = false;
                    if (lblOptB.Text == "")
                    {
                        lblOptB.Visible = false;
                        lblB.Visible = false;
                    }
                    else
                    {
                        lblB.Visible = true;
                        lblOptB.Visible = true;
                    }
                    lblOptB.Font.Name = "Times New Roman";
                    lblOptB.Font.Size = 10;
                }
                else if (BType == "1")
                {
                    string s = Convert.ToString(row["Answer2"]);
                    s = s.Replace("@011", "'");
                    lblOptB.Text = s;
                    imgoptB.Visible = false;
                    if (lblOptB.Text == "")
                    {
                        lblOptB.Visible = false;
                        lblB.Visible = false;
                    }
                    else
                    {
                        lblB.Visible = true;
                        lblOptB.Visible = true;
                    }
                    lblOptB.Font.Name = "Shivaji01";
                    lblOptB.Font.Size = 12;
                }
                else if (BType == "3")
                {
                    string s = Convert.ToString(row["Answer2"]);
                    s = s.Replace("@011", "'");
                    lblOptB.Text = s;
                    imgoptB.Visible = false;
                    if (lblOptB.Text == "")
                    {
                        lblOptB.Visible = false;
                        lblB.Visible = false;
                    }
                    else
                    {
                        lblB.Visible = true;
                        lblOptB.Visible = true;
                    }
                    lblOptB.Font.Name = "Mangal";
                    lblOptB.Font.Size = 12;
                }
                else
                {
                    imgoptB.ImageUrl = "~/imgExamHandler.ashx?para=" + EQID + ",Answer2," + s11 + "," + testID + "";
                    lblOptB.Visible = false;
                    imgoptB.Visible = true;
                    lblB.Visible = true;
                }

                //Option C
                if (CType == "0")
                {
                    string s = Convert.ToString(row["Answer3"]);
                    s = s.Replace("@011", "'");
                    lblOptC.Text = s;
                    imgoptC.Visible = false;
                    if (lblOptC.Text == "")
                    {
                        lblOptC.Visible = false;
                        lblC.Visible = false;
                    }
                    else
                    {
                        lblC.Visible = true;
                        lblOptC.Visible = true;
                    }
                    lblOptC.Font.Name = "Times New Roman";
                    lblOptC.Font.Size = 10;
                }
                else if (CType == "1")
                {
                    string s = Convert.ToString(row["Answer3"]);
                    s = s.Replace("@011", "'");
                    lblOptC.Text = s;
                    imgoptC.Visible = false;
                    if (lblOptC.Text == "")
                    {
                        lblOptC.Visible = false;
                        lblC.Visible = false;
                    }
                    else
                    {
                        lblC.Visible = true;
                        lblOptC.Visible = true;
                    }
                    lblOptC.Font.Name = "Shivaji01";
                    lblOptC.Font.Size = 12;
                }
                else if (CType == "3")
                {
                    string s = Convert.ToString(row["Answer3"]);
                    s = s.Replace("@011", "'");
                    lblOptC.Text = s;
                    imgoptC.Visible = false;
                    if (lblOptC.Text == "")
                    {
                        lblOptC.Visible = false;
                        lblC.Visible = false;
                    }
                    else
                    {
                        lblC.Visible = true;
                        lblOptC.Visible = true;
                    }
                    lblOptC.Font.Name = "Mangal";
                    lblOptC.Font.Size = 12;
                }
                else
                {
                    imgoptC.ImageUrl = "~/imgExamHandler.ashx?para=" + EQID + ",Answer3," + s11 + "," + testID + "";
                    lblOptC.Visible = false;
                    imgoptC.Visible = true;
                    lblC.Visible = true;
                }

                //Option D
                if (DType == "0")
                {
                    string s = Convert.ToString(row["Answer4"]);
                    s = s.Replace("@011", "'");
                    lblOptD.Text = s;
                    imgoptD.Visible = false;
                    if (lblOptD.Text == "")
                    {
                        lblOptD.Visible = false;
                        lblD.Visible = false;
                    }
                    else
                    {
                        lblD.Visible = true;
                        lblOptD.Visible = true;
                    }
                    lblOptD.Font.Name = "Times New Roman";
                    lblOptD.Font.Size = 10;
                }
                else if (DType == "1")
                {
                    string s = Convert.ToString(row["Answer4"]);
                    s = s.Replace("@011", "'");
                    lblOptD.Text = s;
                    imgoptD.Visible = false;
                    if (lblOptD.Text == "")
                    {
                        lblOptD.Visible = false;
                        lblD.Visible = false;
                    }
                    else
                    {
                        lblD.Visible = true;
                        lblOptD.Visible = true;
                    }
                    lblOptD.Font.Name = "Shivaji01";
                    lblOptD.Font.Size = 12;
                }
                else if (DType == "3")
                {
                    string s = Convert.ToString(row["Answer4"]);
                    s = s.Replace("@011", "'");
                    lblOptD.Text = s;
                    imgoptD.Visible = false;
                    if (lblOptD.Text == "")
                    {
                        lblOptD.Visible = false;
                        lblD.Visible = false;
                    }
                    else
                    {
                        lblD.Visible = true;
                        lblOptD.Visible = true;
                    }
                    lblOptD.Font.Name = "Mangal";
                    lblOptD.Font.Size = 12;
                }
                else
                {
                    imgoptD.ImageUrl = "~/imgExamHandler.ashx?para=" + EQID + ",Answer4," + s11 + "," + testID + "";
                    lblOptD.Visible = false;
                    imgoptD.Visible = true;
                    lblD.Visible = true;
                }

                //Option E
                if (EType == "0")
                {
                    string s = Convert.ToString(row["OptionE"]);
                    s = s.Replace("@011", "'");
                    lblOptE.Text = s;
                    imgoptE.Visible = false;
                    if (lblOptE.Text == " " || lblOptE.Text == "")
                    {
                        lblOptE.Visible = false;
                        lblE.Visible = false;
                        lblE.Visible = false;
                    }
                    else
                    {
                        lblE.Visible = true;
                        lblOptE.Visible = true;
                        lblE.Visible = true;
                    }
                    lblOptE.Font.Name = "Times New Roman";
                    lblOptE.Font.Size = 10;
                }
                else if (EType == "1")
                {
                    string s = Convert.ToString(row["OptionE"]);
                    s = s.Replace("@011", "'");
                    lblOptE.Text = s;
                    imgoptE.Visible = false;
                    if (lblOptE.Text == " " || lblOptE.Text == "")
                    {
                        lblOptE.Visible = false;
                        lblE.Visible = false;
                        lblE.Visible = false;
                    }
                    else
                    {
                        lblE.Visible = true;
                        lblOptE.Visible = true;
                        lblE.Visible = true;
                    }
                    lblOptD.Font.Name = "Shivaji01";
                    lblOptD.Font.Size = 12;
                }
                else if (EType == "3")
                {
                    string s = Convert.ToString(row["OptionE"]);
                    s = s.Replace("@011", "'");
                    lblOptE.Text = s;
                    imgoptE.Visible = false;
                    if (lblOptE.Text == " " || lblOptE.Text == "")
                    {
                        lblOptE.Visible = false;
                        lblE.Visible = false;
                        lblE.Visible = false;
                    }
                    else
                    {
                        lblE.Visible = true;
                        lblOptE.Visible = true;
                        lblE.Visible = true;
                    }
                    lblOptD.Font.Name = "Mangal";
                    lblOptD.Font.Size = 12;
                }

                else
                {
                    imgoptE.ImageUrl = "~/imgExamHandler.ashx?para=" + EQID + ",OptionE," + s11 + "," + testID + "";
                    lblOptE.Visible = false;
                    imgoptE.Visible = true;
                    lblE.Visible = true;
                    lblE.Visible = true;
                }

                //Option P
                if (PType == "0")
                {

                    string s = Convert.ToString(row["OptionP"]);
                    s = s.Replace("@011", "'");
                    lblOptP.Text = s;


                    imgoptP.Visible = false;
                    if (lblOptP.Text == "")
                    {
                        lblOptP.Visible = false;
                        lblP.Visible = false;
                    }
                    else
                    {
                        lblP.Visible = true;
                        lblOptP.Visible = true;
                    }
                    lblOptP.Font.Name = "Times New Roman";
                    lblOptP.Font.Size = 10;
                }
                else if (PType == "1")
                {
                    string s = Convert.ToString(row["OptionP"]);
                    s = s.Replace("@011", "'");
                    lblOptP.Text = s;
                    imgoptP.Visible = false;
                    if (lblOptP.Text == "")
                    {
                        lblOptP.Visible = false;
                        lblP.Visible = false;
                    }
                    else
                    {
                        lblP.Visible = true;
                        lblOptP.Visible = true;
                    }
                    lblOptP.Font.Name = "Shivaji01";
                    lblOptP.Font.Size = 12;
                }
                else if (PType == "3")
                {
                    string s = Convert.ToString(row["OptionP"]);
                    s = s.Replace("@011", "'");
                    lblOptP.Text = s;
                    imgoptP.Visible = false;
                    if (lblOptP.Text == "")
                    {
                        lblOptP.Visible = false;
                        lblP.Visible = false;
                    }
                    else
                    {
                        lblP.Visible = true;
                        lblOptP.Visible = true;
                    }
                    lblOptP.Font.Name = "Mangal";
                    lblOptP.Font.Size = 12;
                }
                else
                {
                    imgoptP.ImageUrl = "~/imgExamHandler.ashx?para=" + EQID + ",OptionP," + s11 + "," + testID + "";
                    lblOptP.Visible = false;
                    imgoptP.Visible = true;
                    lblP.Visible = true;
                }

                //Option Q
                if (QType1 == "0")
                {
                    string s = Convert.ToString(row["OptionQ"]);
                    s = s.Replace("@011", "'");
                    lblOptQ.Text = s;
                    imgoptQ.Visible = false;
                    if (lblOptQ.Text == "")
                    {
                        lblOptQ.Visible = false;
                        lblQ.Visible = false;
                    }
                    else
                    {
                        lblQ.Visible = true;
                        lblOptQ.Visible = true;
                    }
                    lblOptQ.Font.Name = "Times New Roman";
                    lblOptQ.Font.Size = 10;
                }
                else if (QType1 == "1")
                {
                    string s = Convert.ToString(row["OptionQ"]);
                    s = s.Replace("@011", "'");
                    lblOptQ.Text = s;
                    imgoptQ.Visible = false;
                    if (lblOptQ.Text == "")
                    {
                        lblOptQ.Visible = false;
                        lblQ.Visible = false;
                    }
                    else
                    {
                        lblQ.Visible = true;
                        lblOptQ.Visible = true;
                    }
                    lblOptQ.Font.Name = "Shivaji01";
                    lblOptQ.Font.Size = 12;
                }
                else if (QType1 == "3")
                {
                    string s = Convert.ToString(row["OptionQ"]);
                    s = s.Replace("@011", "'");
                    lblOptQ.Text = s;
                    imgoptQ.Visible = false;
                    if (lblOptQ.Text == "")
                    {
                        lblOptQ.Visible = false;
                        lblQ.Visible = false;
                    }
                    else
                    {
                        lblQ.Visible = true;
                        lblOptQ.Visible = true;
                    }
                    lblOptQ.Font.Name = "Mangal";
                    lblOptQ.Font.Size = 12;
                }

                else
                {
                    imgoptQ.ImageUrl = "~/imgExamHandler.ashx?para=" + EQID + ",OptionQ," + s11 + "," + testID + "";
                    lblOptQ.Visible = false;
                    imgoptQ.Visible = true;
                    lblQ.Visible = true;
                }

                //Option R
                if (RType == "0")
                {
                    string s = Convert.ToString(row["OptionR"]);
                    s = s.Replace("@011", "'");
                    lblOptR.Text = s;
                    imgoptR.Visible = false;
                    if (lblOptR.Text == "")
                    {
                        lblOptR.Visible = false;
                        lblR.Visible = false;
                    }
                    else
                    {
                        lblR.Visible = true;
                        lblOptR.Visible = true;
                    }
                    lblOptR.Font.Name = "Times New Roman";
                    lblOptR.Font.Size = 10;
                }
                else if (RType == "1")
                {
                    string s = Convert.ToString(row["OptionR"]);
                    s = s.Replace("@011", "'");
                    lblOptR.Text = s;
                    imgoptR.Visible = false;
                    if (lblOptR.Text == "")
                    {
                        lblOptR.Visible = false;
                        lblR.Visible = false;
                    }
                    else
                    {
                        lblR.Visible = true;
                        lblOptR.Visible = true;
                    }
                    lblOptR.Font.Name = "Shivaji01";
                    lblOptR.Font.Size = 12;
                }
                else if (RType == "3")
                {
                    string s = Convert.ToString(row["OptionR"]);
                    s = s.Replace("@011", "'");
                    lblOptR.Text = s;
                    imgoptR.Visible = false;
                    if (lblOptR.Text == "")
                    {
                        lblOptR.Visible = false;
                        lblR.Visible = false;
                    }
                    else
                    {
                        lblR.Visible = true;
                        lblOptR.Visible = true;
                    }
                    lblOptR.Font.Name = "Mangal";
                    lblOptR.Font.Size = 12;
                }
                else
                {
                    imgoptR.ImageUrl = "~/imgExamHandler.ashx?para=" + EQID + ",OptionR," + s11 + "," + testID + "";
                    lblOptR.Visible = false;
                    imgoptR.Visible = true;
                    lblR.Visible = true;
                }

                //Option S
                if (SType == "0")
                {
                    string s = Convert.ToString(row["OptionS"]);
                    s = s.Replace("@011", "'");
                    lblOptS.Text = s;
                    imgoptS.Visible = false;
                    if (lblOptS.Text == "")
                    {
                        lblOptS.Visible = false;
                        lblS.Visible = false;
                    }
                    else
                    {
                        lblS.Visible = true;
                        lblOptS.Visible = true;
                    }
                    lblOptS.Font.Name = "Times New Roman";
                    lblOptS.Font.Size = 10;
                }
                else if (SType == "1")
                {
                    string s = Convert.ToString(row["OptionS"]);
                    s = s.Replace("@011", "'");
                    lblOptS.Text = s;
                    imgoptS.Visible = false;
                    if (lblOptS.Text == "")
                    {
                        lblOptS.Visible = false;
                        lblS.Visible = false;
                    }
                    else
                    {
                        lblS.Visible = true;
                        lblOptS.Visible = true;
                    }
                    lblOptS.Font.Name = "Shivaji01";
                    lblOptS.Font.Size = 12;
                }
                else if (SType == "3")
                {
                    string s = Convert.ToString(row["OptionS"]);
                    s = s.Replace("@011", "'");
                    lblOptS.Text = s;
                    imgoptS.Visible = false;
                    if (lblOptS.Text == "")
                    {
                        lblOptS.Visible = false;
                        lblS.Visible = false;
                    }
                    else
                    {
                        lblS.Visible = true;
                        lblOptS.Visible = true;
                    }
                    lblOptS.Font.Name = "Mangal";
                    lblOptS.Font.Size = 12;
                }
                else
                {
                    imgoptS.ImageUrl = "~/imgExamHandler.ashx?para=" + EQID + ",OptionS," + s11 + "," + testID + "";
                    lblOptS.Visible = false;
                    imgoptS.Visible = true;
                    lblS.Visible = true;
                }

                //Option T
                if (TType == "0")
                {
                    string s = Convert.ToString(row["OptionT"]);
                    s = s.Replace("@011", "'");
                    lblOptT.Text = s;
                    imgoptT.Visible = false;
                    if (lblOptT.Text == "" || lblOptT.Text == " ")
                    {
                        lblOptT.Visible = false;
                        lblT.Visible = false;
                        lblT.Visible = false;
                    }
                    else
                    {
                        lblT.Visible = true;
                        lblOptT.Visible = true;
                        lblT.Visible = true;
                    }
                    lblOptT.Font.Name = "Times New Roman";
                    lblOptT.Font.Size = 10;
                }
                else if (TType == "1")
                {
                    string s = Convert.ToString(row["OptionT"]);
                    s = s.Replace("@011", "'");
                    lblOptT.Text = s;
                    imgoptT.Visible = false;
                    if (lblOptT.Text == "" || lblOptT.Text == " ")
                    {
                        lblOptT.Visible = false;
                        lblT.Visible = false;
                        lblT.Visible = false;
                    }
                    else
                    {
                        lblT.Visible = true;
                        lblOptT.Visible = true;
                        lblT.Visible = true;
                    }
                    lblOptT.Font.Name = "Shivaji01";
                    lblOptT.Font.Size = 12;
                }
                else if (TType == "3")
                {
                    string s = Convert.ToString(row["OptionT"]);
                    s = s.Replace("@011", "'");
                    lblOptT.Text = s;
                    imgoptT.Visible = false;
                    if (lblOptT.Text == "" || lblOptT.Text == " ")
                    {
                        lblOptT.Visible = false;
                        lblT.Visible = false;
                        lblT.Visible = false;
                    }
                    else
                    {
                        lblT.Visible = true;
                        lblOptT.Visible = true;
                        lblT.Visible = true;
                    }
                    lblOptT.Font.Name = "Mangal";
                    lblOptT.Font.Size = 12;
                }
                else
                {
                    imgoptT.ImageUrl = "~/imgExamHandler.ashx?para=" + EQID + ",OptionT," + s11 + "," + testID + "";
                    lblOptT.Visible = false;
                    imgoptT.Visible = true;
                    lblT.Visible = true;
                }

                //Option O
                if (passageType == "0")
                {
                    string s = Convert.ToString(row["Passage"]);
                    s = s.Replace("@011", "'");
                    lblPassage.Text = s;

                    imgPassage.Visible = false;
                    if (lblPassage.Text == "")
                    {
                        lblPassage.Visible = false;
                        lblpassage1.Visible = false;
                    }
                    else
                    {
                        lblpassage1.Visible = true;
                        lblPassage.Visible = true;
                    }
                    lblPassage.Font.Name = "Times New Roman";
                    lblPassage.Font.Size = 10;

                }
                else if (passageType == "1")
                {
                    string s = Convert.ToString(row["Passage"]);
                    s = s.Replace("@011", "'");
                    lblPassage.Text = s;

                    imgPassage.Visible = false;
                    if (lblPassage.Text == "")
                    {
                        lblPassage.Visible = false;
                        lblpassage1.Visible = false;
                    }
                    else
                    {
                        lblpassage1.Visible = true;
                        lblPassage.Visible = true;
                    }
                    lblPassage.Font.Name = "Shivaji01";
                    lblPassage.Font.Size = 12;
                }
                else if (passageType == "3")
                {
                    string s = Convert.ToString(row["Passage"]);
                    s = s.Replace("@011", "'");
                    lblPassage.Text = s;

                    imgPassage.Visible = false;
                    if (lblPassage.Text == "")
                    {
                        lblPassage.Visible = false;
                        lblpassage1.Visible = false;
                    }
                    else
                    {
                        lblpassage1.Visible = true;
                        lblPassage.Visible = true;
                    }
                    lblPassage.Font.Name = "Mangal";
                    lblPassage.Font.Size = 12;
                }
                else
                {
                    imgPassage.ImageUrl = "~/imgExamHandler.ashx?para=" + EQID + ",Passage," + s11 + "," + testID + "";
                    lblPassage.Visible = false;
                    imgPassage.Visible = true;
                    lblpassage1.Visible = true;
                }

                //QuesWithImage
                if (Q1Type == "0")
                {
                    string s = Convert.ToString(row["QuesWithImage"]);
                    s = s.Replace("@011", "'");
                    lblQuestionwithImage.Text = s;
                    imgQuesImage.Visible = false;
                    if (lblQuestionwithImage.Text == "")
                    {
                        lblQuestionwithImage.Visible = false;    //for reasoning type Question
                    }
                    else
                    {
                        lblQuestionwithImage.Visible = true;    //for reasoning type Question
                    }
                    lblQuestionwithImage.Font.Name = "Times New Roman";
                    lblQuestionwithImage.Font.Size = 10;
                }
                else if (Q1Type == "1")
                {
                    string s = Convert.ToString(row["QuesWithImage"]);
                    s = s.Replace("@011", "'");
                    lblQuestionwithImage.Text = s;

                    imgQuesImage.Visible = false;
                    if (lblQuestionwithImage.Text == "")
                    {
                        lblQuestionwithImage.Visible = false;
                    }
                    else
                    {
                        lblQuestionwithImage.Visible = true;
                    }
                    lblQuestionwithImage.Font.Name = "Shivaji01";
                    lblQuestionwithImage.Font.Size = 12;
                }
                else if (Q1Type == "3")
                {
                    string s = Convert.ToString(row["QuesWithImage"]);
                    s = s.Replace("@011", "'");
                    lblQuestionwithImage.Text = s;

                    imgQuesImage.Visible = false;
                    if (lblQuestionwithImage.Text == "")
                    {
                        lblQuestionwithImage.Visible = false;
                    }
                    else
                    {
                        lblQuestionwithImage.Visible = true;
                    }
                    lblQuestionwithImage.Font.Name = "Mangal";
                    lblQuestionwithImage.Font.Size = 12;
                }
                else
                {
                    lblQuestionwithImage.Text = Convert.ToString(row["QuesWithImage"]);
                    if (lblQuestionwithImage.Text != "")
                    {
                        imgQuesImage.ImageUrl = "~/imgExamHandler.ashx?para=" + EQID + ",QuesWithImage," + s11 + "," + testID + "";
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
        catch (Exception ex) { }
    }
}
