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

public partial class userControl_showQuestion : System.Web.UI.UserControl
{
    SqlConnection con = null;
    SqlDataAdapter da = null;
    DataSet ds = new DataSet();
    string s11;
    

    protected void Page_Load(object sender, EventArgs e)
    {
       
        loadControl();

        Session["SNO"] = Convert.ToInt32(Session["SNO"]) + 1;
       
    }

    void loadControl()
    {
        try
        {
             s11 = "tbl5164";

             string sql = " WITH t AS (SELECT ROW_NUMBER() OVER (ORDER BY " + s11 + ".SNO) AS EQID, " + s11 + ".*,tblItemValue.ItemValueId, tblItemValue.ItemId, tblItemValue.Name FROM " + s11 + " INNER JOIN tblItemValue ON tblItemValue.ItemValueId=" + s11 + ".TypeofQues " +
                          " WHERE TestID='" + Convert.ToString(Session["TestID"]) + "') SELECT * FROM t WHERE EQID=" + Convert.ToInt32(Session["SNO"].ToString());

            con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            da = new SqlDataAdapter(sql, con);

            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fetchCommonData(ds.Tables[0].Rows[0]);
            }
        }
        catch
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
        string s11 = "tbl5164";
        string testID = Convert.ToString(Session["TestID"]);
        string replaceValue = string.Empty;

        try
        {
            string loginId = Convert.ToString(Session["LoginId"]);
            
            if (row.ItemArray.Count() > 0)
            {
                int SNO = Convert.ToInt32(row["EQID"]);
                lblqn.Text = "Q.No. " + SNO.ToString();
                TypeDB = Convert.ToString(row["TypeofDB"]);
                lang = Convert.ToString(row["Sellanguage"]);

                try
                {
                    settingid1 = Convert.ToInt32(row["SettingId"]);
                }
                catch
                { 
                }

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
                    lblQuestion.Text = Convert.ToString(row["Question"]);
                    lblQuestion.Text.Replace("@011", "'");
                    lblQuestion.Visible = true;
                    lblQuestion.Font.Name = "Times New Roman";
                    lblQuestion.Font.Size = 10;
                    imgQues.Visible = false;
                }
                else if (QType == "1")
                {
                    lblQuestion.Text = Convert.ToString(row["Question"]);
                    lblQuestion.Text.Replace("@011", "'");
                    lblQuestion.Visible = true;
                    lblQuestion.Font.Name = "Shivaji01";
                    lblQuestion.Font.Size = 12;
                    imgQues.Visible = false;
                }
                else if (QType == "3")
                {
                    replaceValue = Convert.ToString(row["Question"]);
                    replaceValue = replaceValue.Replace("@011", "'");
                    lblQuestion.Text = replaceValue;
                    //lblQuestion.Text = Convert.ToString(row["Question"]);
                    //lblQuestion.Text.Replace("@011", "'");
                    lblQuestion.Visible = true;
                    lblQuestion.Font.Name = "Cambria Math";
                    lblQuestion.Font.Size = 11;
                    imgQues.Visible = false;
                }
                else
                {
                    lblQuestion.Visible = false;
                    imgQues.Visible = true;
                    imgQues.ImageUrl = "imageHandler.ashx?para=" + SNO + ",Question," + s11 + "," + testID + "";
                }

                //Option A
                if (AType == "0")
                {
                   
                    lblOptA.Text = Convert.ToString(row["Answer1"]);
                    lblOptA.Text.Replace("@011", "'");
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
                    lblOptA.Text = Convert.ToString(row["Answer1"]);
                    lblOptA.Text.Replace("@011", "'");
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
                    replaceValue = Convert.ToString(row["Answer1"]);
                    replaceValue = replaceValue.Replace("@011", "'");
                    lblOptA.Text = replaceValue;
                    //lblOptA.Text = Convert.ToString(row["Answer1"]);
                    //lblOptA.Text.Replace("@011", "'");
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
                    lblOptA.Font.Name = "Cambria Math";
                    lblOptA.Font.Size = 11;
                }
                else
                {
                    lblOptA.Visible = false;
                    imgoptA.Visible = true;
                    lblA.Visible = true;
                    imgoptA.ImageUrl = "imageHandler.ashx?para=" + SNO + ",Answer1," + s11 + "," + testID + "";

                    string w = imgoptA.Width.ToString();
                }

                //Option B
                if (BType == "0")
                {
                    lblOptB.Text = Convert.ToString(row["Answer2"]);
                    lblOptB.Text.Replace("@011", "'");
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
                    lblOptB.Text = Convert.ToString(row["Answer2"]);
                    lblOptB.Text.Replace("@011", "'");
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
                    replaceValue = Convert.ToString(row["Answer2"]);
                    replaceValue = replaceValue.Replace("@011", "'");
                    lblOptB.Text = replaceValue;

                    //lblOptB.Text = Convert.ToString(row["Answer2"]);
                    //lblOptB.Text.Replace("@011", "'");
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
                    lblOptB.Font.Name = "Cambria Math";
                    lblOptB.Font.Size = 11;
                }
                else
                {
                    imgoptB.ImageUrl = "imageHandler.ashx?para=" + SNO + ",Answer2," + s11 + "," + testID + "";
                    lblOptB.Visible = false;
                    imgoptB.Visible = true;
                    lblB.Visible = true;
                }

                //Option C
                if (CType == "0")
                {
                    lblOptC.Text = Convert.ToString(row["Answer3"]);
                    lblOptC.Text.Replace("@011", "'");
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
                    lblOptC.Text = Convert.ToString(row["Answer3"]);
                    lblOptC.Text.Replace("@011", "'");
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
                    replaceValue = Convert.ToString(row["Answer3"]);
                    replaceValue = replaceValue.Replace("@011", "'");
                    lblOptC.Text = replaceValue;

                    //lblOptC.Text = Convert.ToString(row["Answer3"]);
                    //lblOptC.Text.Replace("@011", "'");
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
                    lblOptC.Font.Name = "Cambria Math";
                    lblOptC.Font.Size = 11;
                }
                else
                {
                    imgoptC.ImageUrl = "imageHandler.ashx?para=" + SNO + ",Answer3," + s11 + "," + testID + "";
                    lblOptC.Visible = false;
                    imgoptC.Visible = true;
                    lblC.Visible = true;
                }

                //Option D
                if (DType == "0")
                {
                    lblOptD.Text = Convert.ToString(row["Answer4"]);
                    lblOptD.Text.Replace("@011", "'");
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
                    lblOptD.Text = Convert.ToString(row["Answer4"]);
                    lblOptD.Text.Replace("@011", "'");
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
                    replaceValue = Convert.ToString(row["Answer4"]);
                    replaceValue = replaceValue.Replace("@011", "'");
                    lblOptD.Text = replaceValue;

                    //lblOptD.Text = Convert.ToString(row["Answer4"]);
                    //lblOptD.Text.Replace("@011", "'");
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
                    lblOptD.Font.Name = "Cambria Math";
                    lblOptD.Font.Size = 11;
                }
                else
                {
                    imgoptD.ImageUrl = "imageHandler.ashx?para=" + SNO + ",Answer4," + s11 + "," + testID + "";
                    lblOptD.Visible = false;
                    imgoptD.Visible = true;
                    lblD.Visible = true;
                }

                //Option E
                if (EType == "0")
                {
                    lblOptE.Text = Convert.ToString(row["OptionE"]);
                    lblOptE.Text.Replace("@011", "'");
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
                    lblOptE.Text = Convert.ToString(row["OptionE"]);
                    lblOptE.Text.Replace("@011", "'");
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
                    lblOptE.Font.Name = "Shivaji01";
                    lblOptE.Font.Size = 12;
                }
                else if (EType == "3")
                {
                    replaceValue = Convert.ToString(row["OptionE"]);
                    replaceValue = replaceValue.Replace("@011", "'");
                    lblOptE.Text = replaceValue;

                    //lblOptE.Text = Convert.ToString(row["OptionE"]);
                    //lblOptE.Text.Replace("@011", "'");
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
                    lblOptE.Font.Name = "Cambria Math";
                    lblOptE.Font.Size = 11;
                }

                else
                {
                    imgoptE.ImageUrl = "imageHandler.ashx?para=" + SNO + ",OptionE," + s11 + "," + testID + "";
                    lblOptE.Visible = false;
                    imgoptE.Visible = true;
                    lblE.Visible = true;
                    lblE.Visible = true;
                }

                //Option P
                if (PType == "0")
                {
                    lblOptP.Text = Convert.ToString(row["OptionP"]);
                    lblOptP.Text.Replace("@011", "'");
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
                    lblOptP.Text = Convert.ToString(row["OptionP"]);
                    lblOptP.Text.Replace("@011", "'");
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
                    lblOptP.Text = Convert.ToString(row["OptionP"]);
                    lblOptP.Text.Replace("@011", "'");
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
                    imgoptP.ImageUrl = "imageHandler.ashx?para=" + SNO + ",OptionP," + s11 + "," + testID + "";
                    lblOptP.Visible = false;
                    imgoptP.Visible = true;
                    lblP.Visible = true;
                }

                //Option Q
                if (QType1 == "0")
                {
                    lblOptQ.Text = Convert.ToString(row["OptionQ"]);
                    lblOptQ.Text.Replace("@011", "'");
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
                    lblOptQ.Text = Convert.ToString(row["OptionQ"]);
                    lblOptQ.Text.Replace("@011", "'");
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
                    lblOptQ.Text = Convert.ToString(row["OptionQ"]);
                    lblOptQ.Text.Replace("@011", "'");
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
                    imgoptQ.ImageUrl = "imageHandler.ashx?para=" + SNO + ",OptionQ," + s11 + "," + testID + "";
                    lblOptQ.Visible = false;
                    imgoptQ.Visible = true;
                    lblQ.Visible = true;
                }

                //Option R
                if (RType == "0")
                {
                    lblOptR.Text = Convert.ToString(row["OptionR"]);
                    lblOptR.Text.Replace("@011", "'");
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
                    lblOptR.Text = Convert.ToString(row["OptionR"]);
                    lblOptR.Text.Replace("@011", "'");
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
                    lblOptR.Text = Convert.ToString(row["OptionR"]);
                    lblOptR.Text.Replace("@011", "'");
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
                    imgoptR.ImageUrl = "imageHandler.ashx?para=" + SNO + ",OptionR," + s11 + "," + testID + "";
                    lblOptR.Visible = false;
                    imgoptR.Visible = true;
                    lblR.Visible = true;
                }

                //Option S
                if (SType == "0")
                {
                    lblOptS.Text = Convert.ToString(row["OptionS"]);
                    lblOptS.Text.Replace("@011", "'");
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
                    lblOptS.Text = Convert.ToString(row["OptionS"]);
                    lblOptS.Text.Replace("@011", "'");
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
                    lblOptS.Text = Convert.ToString(row["OptionS"]);
                    lblOptS.Text.Replace("@011", "'");
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
                    imgoptS.ImageUrl = "imageHandler.ashx?para=" + SNO + ",OptionS," + s11 + "," + testID + "";
                    lblOptS.Visible = false;
                    imgoptS.Visible = true;
                    lblS.Visible = true;
                }

                //Option T
                if (TType == "0")
                {
                    lblOptT.Text = Convert.ToString(row["OptionT"]);
                    lblOptT.Text.Replace("@011", "'");
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
                    lblOptT.Text = Convert.ToString(row["OptionT"]);
                    lblOptT.Text.Replace("@011", "'");
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
                    lblOptT.Text = Convert.ToString(row["OptionT"]);
                    lblOptT.Text.Replace("@011", "'");
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
                    imgoptT.ImageUrl = "imageHandler.ashx?para=" + SNO + ",OptionT," + s11 + "," + testID + "";
                    lblOptT.Visible = false;
                    imgoptT.Visible = true;
                    lblT.Visible = true;
                }

                //Option O
                if (passageType == "0")
                {
                    lblPassage.Text = Convert.ToString(row["Passage"]);
                    lblPassage.Text.Replace("@011", "'");
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
                    lblPassage.Text = Convert.ToString(row["Passage"]);
                    lblPassage.Text.Replace("@011", "'");
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
                    lblPassage.Text = Convert.ToString(row["Passage"]);
                    lblPassage.Text.Replace("@011", "'");
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
                    imgPassage.ImageUrl = "imageHandler.ashx?para=" + SNO + ",Passage," + s11 + "," + testID + "";
                    lblPassage.Visible = false;
                    imgPassage.Visible = true;
                    lblpassage1.Visible = true;
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
                        //QuestionImage.Visible = false;         //label for Question header
                    }
                    else
                    {
                        lblQuestionwithImage.Visible = true;    //for reasoning type Question
                        //QuestionImage.Visible = true;         //label for Question header
                    }
                    lblQuestionwithImage.Font.Name = "Times New Roman";
                    lblQuestionwithImage.Font.Size = 10;
                }
                else if (Q1Type == "1")
                {
                    lblQuestionwithImage.Text = Convert.ToString(row["QuesWithImage"]);
                    lblQuestionwithImage.Text.Replace("@011", "'");
                    imgQuesImage.Visible = false;
                    if (lblQuestionwithImage.Text == "")
                    {
                        lblQuestionwithImage.Visible = false;
                        //QuestionImage.Visible = false;
                    }
                    else
                    {
                        lblQuestionwithImage.Visible = true;
                        //QuestionImage.Visible = true;
                    }
                    lblQuestionwithImage.Font.Name = "Shivaji01";
                    lblQuestionwithImage.Font.Size = 12;
                }
                else if (Q1Type == "3")
                {
                    lblQuestionwithImage.Text = Convert.ToString(row["QuesWithImage"]);
                    lblQuestionwithImage.Text.Replace("@011", "'");
                    imgQuesImage.Visible = false;
                    if (lblQuestionwithImage.Text == "")
                    {
                        lblQuestionwithImage.Visible = false;
                        //QuestionImage.Visible = false;
                    }
                    else
                    {
                        lblQuestionwithImage.Visible = true;
                        //QuestionImage.Visible = true;
                    }
                    lblQuestionwithImage.Font.Name = "Mangal";
                    lblQuestionwithImage.Font.Size = 12;
                }
                else
                {
                    lblQuestionwithImage.Text = Convert.ToString(row["QuesWithImage"]);
                    if (lblQuestionwithImage.Text != "")
                    {
                        imgQuesImage.ImageUrl = "imageHandler.ashx?para=" + SNO + ",QuesWithImage," + s11 + "," + testID + "";
                        lblQuestionwithImage.Visible = false;
                        imgQuesImage.Visible = true;
                        //QuestionImage.Visible = true;
                    }
                    else
                    {
                        //QuestionImage.Visible = false;
                        imgQuesImage.Visible = false;
                        lblQuestionwithImage.Visible = false;
                    }
                }
            }
        }
        catch { }
    }  
}
