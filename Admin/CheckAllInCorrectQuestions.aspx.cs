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
using System.Data.SqlClient;


public partial class Admin_CheckQuestions : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();

    AssignQuestionInExamBAL assignQuestioninexamBal = new AssignQuestionInExamBAL();

    DataSet dsStatic = null;
    DataSet dsItemValue = null;

    string Sql = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            LoadQuestions();
        }

    }


    public void LoadQuestions()
    {

        try
        {
            //In  below query the word "top 10" is newly inserted on date 06_sep_2014
            Sql = "Select top 10 *,Row_Number()Over(Order By SNO Asc) As NewQID from dbo.tblQuestionAccess where Class_AdmVerify ='1'" + " OR QuesVerify ='1' ";

            int k = cc.ExecuteNonQuery(Sql);

            Sql = "Select Count(*) from dbo.tblQuestionAccess where Class_AdmVerify ='1'" + " OR QuesVerify ='1' ";
            string tempcount = cc.ExecuteScalar(Sql);

            lblcount.Text = "Total Number of Question : " + tempcount;

           // string viewtblName = "tblQuestionAccess";
           // assignQuestioninexamBal.ViewtblName1 = viewtblName;

            assignQuestioninexamBal.NewQID1 = 1;

            dsStatic = assignQuestioninexamBal.SelectInCorrectQuestions(assignQuestioninexamBal);

            if (dsStatic.Tables[0].Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('No Question found!!!')", true);
            }
            else
            {
                fetchCommonData(dsStatic.Tables[0].Rows[0]);
            }
           
        }
        catch(Exception ex)
        {
           // Response.Write("<h4>" + ex.Message);
        }
    }

    public string TypeofQues = "";
    public string QType = "", Q1Type = "", AType = "", BType = "", CType = "", DType = "", EType = "", PType = "", RType = "", QType1 = "",
        SType = "", TType = "", passageType = "", hType = "";
    public string TypeDB = "", lang = "";
    public static string hintDB = "";
    public int settingid1 = 0;


    void fetchCommonData(DataRow row)
    {
 
        string loginId = Convert.ToString(Session["LoginId"]);

        clearcontrol();

        if (row.ItemArray.Count() > 0)
        {


            txtSuggest.Text = Convert.ToString(row["Suggestion"]);
            string QuesVerify = Convert.ToString(row["QuesVerify"]);

            rdoQuesVerify.SelectedIndex = 0;
            if (QuesVerify == "1")
                rdoQuesVerify.SelectedIndex = 1;

            int QId = Convert.ToInt32(row["Question_id"]);

            int NewQID = Convert.ToInt32(row["NewQID"]);
            lblQNo.Text = Convert.ToString(NewQID);

            lblQuestion_id.Text = Convert.ToString(QId);
            lblSno.Text = Convert.ToString(row["SNO"]);
            lblMasterID.Text = "Master ID : " + lblSno.Text;

            TypeDB = Convert.ToString(row["TypeofDB"]);
            lang = Convert.ToString(row["Sellanguage"]);

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




            string level = Convert.ToString(row["QuestionLevel"]);
            if (level == "1")
                rdoLevelList.SelectedIndex = 0;
            if (level == "2")
                rdoLevelList.SelectedIndex = 1;
            if (level == "3")
                rdoLevelList.SelectedIndex = 2;

            TypeofQues = Convert.ToString(row["TypeofQues"]);
            lblTypeofQuesID.Text = TypeofQues;
            string Sql = "select Name,ItemValueId from tblItemValue";
            dsItemValue = cc.ExecuteDataset(Sql);
            DataRow[] dr = dsItemValue.Tables[0].Select("ItemValueId=" + TypeofQues);
            lbltypeQues.Text = "Type of Question : " + dr[0]["Name"].ToString();

            string ans = Convert.ToString(row["Correct_answer"]);

            if (TypeofQues == "80" || TypeofQues == "86" || TypeofQues == "82")
            {
                if (ans == "A")
                    rdoAnswerlist.SelectedIndex = 0;
                if (ans == "B")
                    rdoAnswerlist.SelectedIndex = 1;
                if (ans == "C")
                    rdoAnswerlist.SelectedIndex = 2;
                if (ans == "D")
                    rdoAnswerlist.SelectedIndex = 3;
                if (ans == "E")
                    rdoAnswerlist.SelectedIndex = 4;
                txtAns.Visible = false;
                chkAnslist.Visible = false;
                pnlAnsMat.Visible = false;

                rdoAnswerlist.Visible = true;
            }
            else if (TypeofQues == "93" || TypeofQues == "84")
            {
                txtAns.Text = ans;
                txtAns.Visible = true;
                rdoAnswerlist.Visible = false;
                chkAnslist.Visible = false;
                pnlAnsMat.Visible = false;
            }

            else if (TypeofQues == "83")
            {
                string[] chk = ans.Split(',');

                foreach (string s in chk)
                {
                    if (s == "A")
                        chkAnslist.Items[0].Selected = true;
                    if (s == "B")
                        chkAnslist.Items[1].Selected = true;
                    if (s == "C")
                        chkAnslist.Items[2].Selected = true;
                    if (s == "D")
                        chkAnslist.Items[3].Selected = true;
                    if (s == "E")
                        chkAnslist.Items[4].Selected = true;
                }
                txtAns.Visible = false;
                rdoAnswerlist.Visible = false;
                chkAnslist.Visible = true;
                pnlAnsMat.Visible = false;

            }
            else if (TypeofQues == "87")
            {
                string[] splitstar = ans.Split('*');

                string[] splitcomma = splitstar[0].Split('-')[1].Split(',');
                foreach (string s in splitcomma)
                {
                    if (s == "P")
                        ChkansMatA.Items[0].Selected = true;
                    if (s == "Q")
                        ChkansMatA.Items[1].Selected = true;
                    if (s == "R")
                        ChkansMatA.Items[2].Selected = true;
                    if (s == "S")
                        ChkansMatA.Items[3].Selected = true;
                    if (s == "T")
                        ChkansMatA.Items[4].Selected = true;
                }

                splitcomma = splitstar[1].Split('-')[1].Split(',');
                foreach (string s in splitcomma)
                {
                    if (s == "P")
                        ChkansMatB.Items[0].Selected = true;
                    if (s == "Q")
                        ChkansMatB.Items[1].Selected = true;
                    if (s == "R")
                        ChkansMatB.Items[2].Selected = true;
                    if (s == "S")
                        ChkansMatB.Items[3].Selected = true;
                    if (s == "T")
                        ChkansMatB.Items[4].Selected = true;
                }

                splitcomma = splitstar[2].Split('-')[1].Split(',');
                foreach (string s in splitcomma)
                {
                    if (s == "P")
                        ChkansMatC.Items[0].Selected = true;
                    if (s == "Q")
                        ChkansMatC.Items[1].Selected = true;
                    if (s == "R")
                        ChkansMatC.Items[2].Selected = true;
                    if (s == "S")
                        ChkansMatC.Items[3].Selected = true;
                    if (s == "T")
                        ChkansMatC.Items[4].Selected = true;
                }

                splitcomma = splitstar[3].Split('-')[1].Split(',');
                foreach (string s in splitcomma)
                {
                    if (s == "P")
                        ChkansMatD.Items[0].Selected = true;
                    if (s == "Q")
                        ChkansMatD.Items[1].Selected = true;
                    if (s == "R")
                        ChkansMatD.Items[2].Selected = true;
                    if (s == "S")
                        ChkansMatD.Items[3].Selected = true;
                    if (s == "T")
                        ChkansMatD.Items[4].Selected = true;
                }
                txtAns.Visible = false;
                rdoAnswerlist.Visible = false;
                chkAnslist.Visible = false;
                pnlAnsMat.Visible = true;
            }



            if (QType == "0")
            {


                string s = Convert.ToString(row["Question"]);
                s = s.Replace("@011", "'");
                lblQuestion.Text = s;
                lblQuestion.Visible = true;

                lblQuestion.Font.Name = "Times New Roman";
                lblQuestion.Font.Size = 12;
                imgQues.Visible = false;
            }
            else if (QType == "1")
            {
                string s = Convert.ToString(row["Question"]);
                s = s.Replace("@011", "'");
                lblQuestion.Text = s;
                lblQuestion.Visible = true;

                lblQuestion.Font.Name = "Shivaji01";
                lblQuestion.Font.Size = 14;
                imgQues.Visible = false;
            }
            else if (QType == "3")
            {
                string s = Convert.ToString(row["Question"]);
                s = s.Replace("@011", "'");
                lblQuestion.Text = s;
                lblQuestion.Visible = true;

                lblQuestion.Font.Name = "Mangal";
                lblQuestion.Font.Size = 14;
                imgQues.Visible = false;
            }
            else
            {
                lblQuestion.Visible = false;
                imgQues.Visible = true;
                imgQues.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Question," + loginId + "";
            }


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
                lblOptA.Font.Size = 12;
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
                lblOptA.Font.Size = 14;
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
                lblOptA.Font.Size = 14;
            }
            else
            {
                lblOptA.Visible = false;
                imgoptA.Visible = true;
                lblA.Visible = true;
                imgoptA.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Answer1," + loginId + "";


            }

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
                lblOptB.Font.Size = 12;
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
                lblOptB.Font.Size = 14;
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
                lblOptB.Font.Size = 14;
            }
            else
            {
                imgoptB.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Answer2," + loginId + "";
                lblOptB.Visible = false;
                imgoptB.Visible = true;
                lblB.Visible = true;
            }

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
                lblOptC.Font.Size = 12;
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
                lblOptC.Font.Size = 14;
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
                lblOptC.Font.Size = 14;
            }
            else
            {
                imgoptC.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Answer3," + loginId + "";
                lblOptC.Visible = false;
                imgoptC.Visible = true;
                lblC.Visible = true;
            }


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
                lblOptD.Font.Size = 12;
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
                lblOptD.Font.Size = 14;
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
                lblOptD.Font.Size = 14;
            }
            else
            {
                imgoptD.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Answer4," + loginId + "";
                lblOptD.Visible = false;
                imgoptD.Visible = true;
                lblD.Visible = true;
            }

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
                lblOptE.Font.Size = 12;
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
                lblOptD.Font.Size = 14;
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
                lblOptD.Font.Size = 14;
            }

            else
            {
                imgoptE.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",OptionE," + loginId + "";
                lblOptE.Visible = false;
                imgoptE.Visible = true;
                lblE.Visible = true;
                lblE.Visible = true;
            }


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
                lblOptP.Font.Size = 12;
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
                lblOptP.Font.Size = 14;
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
                lblOptP.Font.Size = 14;
            }
            else
            {
                imgoptP.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",OptionP," + loginId + "";
                lblOptP.Visible = false;
                imgoptP.Visible = true;
                lblP.Visible = true;
            }

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
                lblOptQ.Font.Size = 12;
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
                lblOptQ.Font.Size = 14;
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
                lblOptQ.Font.Size = 14;
            }
            else
            {
                imgoptQ.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",OptionQ," + loginId + "";
                lblOptQ.Visible = false;
                imgoptQ.Visible = true;
                lblQ.Visible = true;
            }

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
                lblOptR.Font.Size = 12;
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
                lblOptR.Font.Size = 14;
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
                lblOptR.Font.Size = 14;
            }
            else
            {
                imgoptR.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",OptionR," + loginId + "";
                lblOptR.Visible = false;
                imgoptR.Visible = true;
                lblR.Visible = true;
            }

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
                lblOptS.Font.Size = 12;
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
                lblOptS.Font.Size = 14;
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
                lblOptS.Font.Size = 14;
            }
            else
            {
                imgoptS.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",OptionS," + loginId + "";
                lblOptS.Visible = false;
                imgoptS.Visible = true;
                lblS.Visible = true;
            }

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
                lblOptT.Font.Size = 12;
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
                lblOptT.Font.Size = 14;
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
                lblOptT.Font.Size = 14;
            }
            else
            {
                imgoptT.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",OptionT," + loginId + "";
                lblOptT.Visible = false;
                imgoptT.Visible = true;
                lblT.Visible = true;
            }

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
                lblPassage.Font.Size = 12;

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
                lblPassage.Font.Size = 14;
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
                lblPassage.Font.Size = 14;
            }
            else
            {
                imgPassage.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Passage," + loginId + "";
                lblPassage.Visible = false;
                imgPassage.Visible = true;
                lblpassage1.Visible = true;
            }

            if (Q1Type == "0")
            {
                string s = Convert.ToString(row["QuesWithImage"]);
                s = s.Replace("@011", "'");
                lblQuestionwithImage.Text = s;

                
                imgQuesImage.Visible = false;
                if (lblQuestionwithImage.Text == "")
                {
                    lblQuestionwithImage.Visible = false;
                    QuestionImage.Visible = false;
                }
                else
                {
                    lblQuestionwithImage.Visible = true;
                    QuestionImage.Visible = true;
                }
                lblQuestionwithImage.Font.Name = "Times New Roman";
                lblQuestionwithImage.Font.Size = 11;
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
                    QuestionImage.Visible = false;
                }
                else
                {
                    lblQuestionwithImage.Visible = true;
                    QuestionImage.Visible = true;
                }
                lblQuestionwithImage.Font.Name = "Shivaji01";
                lblQuestionwithImage.Font.Size = 14;
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
                    QuestionImage.Visible = false;
                }
                else
                {
                    lblQuestionwithImage.Visible = true;
                    QuestionImage.Visible = true;
                }
                lblQuestionwithImage.Font.Name = "Mangal";
                lblQuestionwithImage.Font.Size = 14;
            }
            else
            {
                lblQuestionwithImage.Text = Convert.ToString(row["QuesWithImage"]);
                if (lblQuestionwithImage.Text != "")
                {
                    imgQuesImage.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",QuesWithImage," + loginId + "";
                    lblQuestionwithImage.Visible = false;
                    imgQuesImage.Visible = true;
                    QuestionImage.Visible = true;
                }
                else
                {
                    QuestionImage.Visible = false;
                    imgQuesImage.Visible = false;
                    lblQuestionwithImage.Visible = false;
                }
            }

            if (hType == "0")
            {
                string s = Convert.ToString(row["Qhint"]);
                s = s.Replace("@011", "'");
                txtHint.Text = s;


                
                hintDB = s;
                ddlhint.SelectedIndex = Convert.ToInt32(hType);
                txtHint.Font.Name = "Times New Roman";
                txtHint.Font.Size = 11;
                imgHint.Visible = false;
                txtHint.Visible = true;
                lblH.Visible = true;
                ddlhint.Visible = true;

            }
            else if (hType == "1")
            {
                string s = Convert.ToString(row["Qhint"]);
                s = s.Replace("@011", "'");
                txtHint.Text = s;

                
                hintDB = s;
                ddlhint.SelectedIndex = Convert.ToInt32(hType);
                txtHint.Font.Name = "Shivaji01";
                txtHint.Font.Size = 14;
                imgHint.Visible = false;

                txtHint.Visible = true;
                lblH.Visible = true;
                ddlhint.Visible = true;

            }
            else if (hType == "3")
            {
                string s = Convert.ToString(row["Qhint"]);
                s = s.Replace("@011", "'");
                txtHint.Text = s;


                hintDB = s;
                //ddlhint.SelectedIndex = Convert.ToInt32(hType);
                txtHint.Font.Name = "Mangal";
                txtHint.Font.Size = 14;
                imgHint.Visible = false;

                txtHint.Visible = true;
                lblH.Visible = true;
                ddlhint.Visible = true;

            }
            else
            {
                imgHint.ImageUrl = "~/ImageHandlerQues.ashx?para=" + NewQID + ",Qhint," + loginId + "";
                txtHint.Visible = false;
                imgHint.Visible = true;
                lblH.Visible = true;
                ddlhint.Visible = false;
            }

        }

    }


    
    protected void btnNext_Click(object sender, EventArgs e)
    {
        int NewQID = Convert.ToInt32(lblQNo.Text);
        int asdhjgahjsghj = Convert.ToInt32((lblcount.Text.Split(':')[1]));
        if (NewQID < Convert.ToInt32((lblcount.Text.Split(':')[1])))
        {

            ddlhint.SelectedIndex = 0;
            NewQID = Convert.ToInt32(lblQNo.Text);
            NewQID = NewQID + 1;

           // string s11 = Convert.ToString(Session["LoginId"]);
            //string viewtblName = "tblQuestionAccess";
            //assignQuestioninexamBal.ViewtblName1 = viewtblName;

            assignQuestioninexamBal.NewQID1 = NewQID;
            dsStatic = assignQuestioninexamBal.SelectInCorrectQuestions(assignQuestioninexamBal);
            fetchCommonData(dsStatic.Tables[0].Rows[0]);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry You Can Not GoTo Next Question')", true);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            collectAnswer();
            if (txtAns.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('please select Answer')", true);
            }
            
            else if ((hType == "0") || (hType == "1"))
            {
                string Sql = "update dbo.tblQuestionAccess set QuestionLevel=" + rdoLevelList.SelectedValue + " , Correct_answer='" + txtAns.Text + "',Qhint='" + txtHint.Text + "' ,hType='" + ddlhint.SelectedValue + "',Suggestion='" + txtSuggest.Text + "',QuesVerify='" + rdoQuesVerify.SelectedValue + "',checkerLoginId='" + Session["LoginId"] + "' where  SNo='" + lblSno.Text + "'  ";
                int flag = cc.ExecuteNonQuery(Sql);
                if (flag == 1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Your Question is Updated')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Your Question is Not Updated')", true);
                }
            }
            else
            {
                string Sql = "update dbo.tblQuestionAccess set QuestionLevel=" + rdoLevelList.SelectedValue + " , Correct_answer='" + txtAns.Text + "' ,Suggestion='" + txtSuggest.Text + "',QuesVerify='" + rdoQuesVerify.SelectedValue + "',checkerLoginId='" + Session["LoginId"] + "' where   SNo='" + lblSno.Text + "'  ";
                int flag = cc.ExecuteNonQuery(Sql);
                if (flag == 1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Your Question is Updated')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Your Question is Not Updated')", true);
                }
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select answer and Question level')", true);
            Response.Write("<h4>" + ex.Message);
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        int NewQID = Convert.ToInt32(lblQNo.Text);
        if (NewQID > 1)
        {
            NewQID = NewQID - 1;
            ddlhint.SelectedIndex = 0;

            //string s11 = Convert.ToString(Session["LoginId"]);
            //string viewtblName = "tblQuestionAccess";
            //assignQuestioninexamBal.ViewtblName1 = viewtblName;

            assignQuestioninexamBal.NewQID1 = NewQID;
            dsStatic = assignQuestioninexamBal.SelectInCorrectQuestions(assignQuestioninexamBal);
            fetchCommonData(dsStatic.Tables[0].Rows[0]);


        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry!!! You Can't Go Backword ')", true);

        }
    }
    protected void btnGotoQues_Click(object sender, EventArgs e)
    {
        try
        {
            int NewQID = Convert.ToInt32(txtGotoQues.Text);


            if (NewQID < Convert.ToInt32((lblcount.Text.Split(':')[1])))
            {


                //string s11 = Convert.ToString(Session["LoginId"]);
               // string viewtblName = "tblQuestionAccess";
               // assignQuestioninexamBal.ViewtblName1 = viewtblName;

                assignQuestioninexamBal.NewQID1 = NewQID;
                dsStatic = assignQuestioninexamBal.SelectInCorrectQuestions(assignQuestioninexamBal);
                fetchCommonData(dsStatic.Tables[0].Rows[0]);


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry!!! You Can't Go Forword ')", true);
            }
        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
    }
    protected void ddlhint_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlhint.SelectedIndex == 0)
        {
            txtHint.Font.Name = "Times New Roman";
            txtHint.Font.Size = 11;
        }
        else if(ddlhint.SelectedIndex==1)
        {
            txtHint.Font.Name = "Shivaji01";
            txtHint.Font.Size = 14;
        }
        else if (ddlhint.SelectedIndex == 3)
        {
            txtHint.Font.Name = "Mangal";
            txtHint.Font.Size = 14;
        }
    }

    public void clearcontrol()
    {
        lblQuestion.Text = "";
        lblQuestionwithImage.Text = "";
        lblPassage.Text = "";
        lblOptA.Text = "";
        lblOptB.Text = "";
        lblOptC.Text = "";
        lblOptD.Text = "";
        lblOptE.Text = "";
        lblOptP.Text = "";
        lblOptQ.Text = "";
        lblOptR.Text = "";
        lblOptS.Text = "";
        lblOptT.Text = "";
        txtHint.Text = "";
        txtSuggest.Text = "";

        imgQues.ImageUrl = "";
        imgPassage.ImageUrl = "";
        imgoptA.ImageUrl = "";
        imgoptB.ImageUrl = "";
        imgoptC.ImageUrl = "";
        imgoptD.ImageUrl = "";
        imgoptE.ImageUrl = "";
        imgoptP.ImageUrl = "";
        imgoptQ.ImageUrl = "";
        imgoptR.ImageUrl = "";
        imgoptS.ImageUrl = "";
        imgoptT.ImageUrl = "";
        imgQuesImage.ImageUrl = "";
        imgHint.ImageUrl = "";


    }

    public void collectAnswer()
    {
        TypeofQues = lblTypeofQuesID.Text;
        if (TypeofQues == "80" || TypeofQues == "86" || TypeofQues == "82")
        {
            txtAns.Text = "";
            if (rdoAnswerlist.SelectedValue == "0")
                txtAns.Text = "A";
            if (rdoAnswerlist.SelectedValue == "1")
                txtAns.Text = "B";
            if (rdoAnswerlist.SelectedValue == "2")
                txtAns.Text = "C";
            if (rdoAnswerlist.SelectedValue == "3")
                txtAns.Text = "D";
            if (rdoAnswerlist.SelectedValue == "4")
                txtAns.Text = "E";
        }
        else if (TypeofQues == "93" || TypeofQues == "84")
        {
            txtAns.Text = txtAns.Text;
        }
        else if (TypeofQues == "83") // Multiple correct ans.
        {
            txtAns.Text = "";
            if (chkAnslist.Items[0].Selected == true)
                txtAns.Text = "A,";
            if (chkAnslist.Items[1].Selected == true)
                txtAns.Text += "B,";
            if (chkAnslist.Items[2].Selected == true)
                txtAns.Text += "C,";
            if (chkAnslist.Items[3].Selected == true)
                txtAns.Text += "D,";
            if (chkAnslist.Items[4].Selected == true)
                txtAns.Text += "E,";

            txtAns.Text = txtAns.Text.Substring(0, txtAns.Text.Length - 1);
        }
        else if (TypeofQues == "87") // matrix type Question 
        {
            txtAns.Text = "";
            if (ChkansMatA.Items[0].Selected == true)
                txtAnsMatA.Text = "P,";
            if (ChkansMatA.Items[1].Selected == true)
                txtAnsMatA.Text += "Q,";
            if (ChkansMatA.Items[2].Selected == true)
                txtAnsMatA.Text += "R,";
            if (ChkansMatA.Items[3].Selected == true)
                txtAnsMatA.Text += "S,";
            if (ChkansMatA.Items[4].Selected == true)
                txtAnsMatA.Text += "T,";

            if (ChkansMatB.Items[0].Selected == true)
                txtAnsMatB.Text = "P,";
            if (ChkansMatB.Items[1].Selected == true)
                txtAnsMatB.Text += "Q,";
            if (ChkansMatB.Items[2].Selected == true)
                txtAnsMatB.Text += "R,";
            if (ChkansMatB.Items[3].Selected == true)
                txtAnsMatB.Text += "S,";
            if (ChkansMatB.Items[4].Selected == true)
                txtAnsMatB.Text += "T,";


            if (ChkansMatC.Items[0].Selected == true)
                txtAnsMatC.Text = "P,";
            if (ChkansMatC.Items[1].Selected == true)
                txtAnsMatC.Text += "Q,";
            if (ChkansMatC.Items[2].Selected == true)
                txtAnsMatC.Text += "R,";
            if (ChkansMatC.Items[3].Selected == true)
                txtAnsMatC.Text += "S,";
            if (ChkansMatC.Items[4].Selected == true)
                txtAnsMatC.Text += "T,";

            if (ChkansMatD.Items[0].Selected == true)
                txtAnsMatD.Text = "P,";
            if (ChkansMatD.Items[1].Selected == true)
                txtAnsMatD.Text += "Q,";
            if (ChkansMatD.Items[2].Selected == true)
                txtAnsMatD.Text += "R,";
            if (ChkansMatD.Items[3].Selected == true)
                txtAnsMatD.Text += "S,";
            if (ChkansMatD.Items[4].Selected == true)
                txtAnsMatD.Text += "T,";

            txtAnsMatA.Text = txtAnsMatA.Text.Substring(0, txtAnsMatA.Text.Length - 1);
            txtAnsMatB.Text = txtAnsMatB.Text.Substring(0, txtAnsMatB.Text.Length - 1);
            txtAnsMatC.Text = txtAnsMatC.Text.Substring(0, txtAnsMatC.Text.Length - 1);
            if (txtAnsMatD.Text != "")
                txtAnsMatD.Text = txtAnsMatD.Text.Substring(0, txtAnsMatD.Text.Length - 1);

            //combine 4 textbox ans.
            txtAns.Text = "A-" + txtAnsMatA.Text + "*" + "B-" + txtAnsMatB.Text + "*" + "C-" + txtAnsMatC.Text + "*" + "D-" + txtAnsMatD.Text;

        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int masterID = 0;
        int flag = 0;

        masterID = Convert.ToInt32(lblSno.Text);

        Sql = " Delete from tblQuestionAccess Where SNO=" + masterID;
        flag = cc.ExecuteNonQuery(Sql);
        if (flag == 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Question Deleted Successfully!!!')", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Question Deletion Failed!!!')", true);
        
        }
        
    }
}
