using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;

public partial class Admin_ExcelUpload : System.Web.UI.Page
{
    //Microsoft.Office.Interop.Excel.Application xlApp;
    //Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
    //Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
    //Microsoft.Office.Interop.Excel.Range range;

    Object ConfirmConversions = false;
    Object isVisible = true;
    object misValue = System.Reflection.Missing.Value;
    Regex regex1 = new Regex(@"ADDR:");

    string subject = "", chaptorno = "", classname = "", userTopic_id = "", srno = "", Question = "", option1 = "", option2 = "", option3 = "", option4 = "", OptionE = "", correctoption = "", hint = "", level = "", userCompitativeExam = "";
    string userChapterName = "";
    string Sql;
    public static string EntryDate = "";

    CommonCode cc = new CommonCode();

    int TypeOFExam1, Class_id1, Subject_id1, Chapter_id1;

    //for excel connection
    string pathOnly = string.Empty;
    string fileName = string.Empty;
    string fileExtension = string.Empty;
    string conPath = "";
    OleDbConnection conn = null;
    //DataSet ds = null;

    GetExcelSheetName objGetExcelSheetName = new GetExcelSheetName();
    CommanDDLbindclass Cds = new CommanDDLbindclass();

    List<string> listExcelSheet = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadrecord();
            Dateformat();
            LoadPublication();
            Cds.loadGroupofExam(ddlGroupofExam);
            //Sql = "SELECT Name,ItemValueId FROM tblItemValue WHERE  ItemId=0 OR ItemId=8 ";
            //DataSet ds = cc.ExecuteDataset(Sql);

            //ddlGroupofExam.DataSource = ds.Tables[0];
            //ddlGroupofExam.DataTextField = "Name";
            //ddlGroupofExam.DataValueField = "ItemValueId";
            //ddlGroupofExam.DataBind();

            //ddlpublication.SelectedItem.Text = "--Select--";
        }
    }

    public void LoadPublication()
    {
        string role = Convert.ToString(Session["Role"]);
        if (role == "8" || role == "19")
        {
            Sql = "SELECT Name,ItemValueId FROM tblItemValue WHERE  ItemId=0 OR ItemId=7 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlpublication.DataSource = ds.Tables[0];
            ddlpublication.DataTextField = "Name";
            ddlpublication.DataValueField = "ItemValueId";
            ddlpublication.DataBind();
        }
        else
        {
            Sql = "SELECT Name,ItemValueId FROM tblItemValue WHERE  ItemId=0 OR ItemId=7 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlpublication.DataSource = ds.Tables[0];
            ddlpublication.DataTextField = "Name";
            ddlpublication.DataValueField = "ItemValueId";
            ddlpublication.DataBind();

            lblpublication.Visible = false;
            ddlpublication.Visible = false;
        }
    }

    public DataSet GetDataTable(string strQuery)
    {
        DataSet tempDs = null;
        string filePath = Server.MapPath("File_Upload\\" + FileUpload1.FileName);
        fileExtension = Path.GetExtension(filePath);

        if (this.fileExtension == ".xls")
        {
            conPath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"";
        }
        else
        {
            conPath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"";
        }
        conn = new OleDbConnection(conPath);
        try
        {
            conn.Open();

            OleDbDataAdapter adapter = new OleDbDataAdapter(strQuery, conn);
            tempDs = new DataSet();
            adapter.Fill(tempDs);
        }
        catch (Exception ex)
        {
            Response.Write("<Script>alert('" + ex.Message + "')</Script>");
        }
        conn.Close();

        return tempDs;
    }


    int count = 0;
    DataSet ExcelDs = null;
    public string excelSubject = "";

    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string path = "";
            path = Server.MapPath("File_Upload");
            path = path + "\\" + FileUpload1.FileName;
            string ab = FileUpload1.FileName;

            if (File.Exists(path))
            {
                File.Delete(path);
                FileUpload1.SaveAs(path);
            }
            else
            {
                FileUpload1.SaveAs(path);
            }

            //listExcelSheet = objGetExcelSheetName.ListSheetInExcel(path); // THIS CLASS & METHOD READ THE NAMES OF SHEETS OF EXCEL.
        }

        string Sql = "";
        if (rdoTypeofMaterial.SelectedIndex == 0)
        {
            Sql = "SELECT * FROM tblAssignChapter WHERE AssignUserName='" + Session["LoginId"] + "' AND Class_id='" + ddlAddClass.SelectedValue + "' AND Subject_id='" + cmbSelectsubject.SelectedValue + "' AND TypeofMaterial='" + rdoTypeofMaterial.SelectedItem.Text + "' ";
        }
        else
        {
            Sql = "SELECT * FROM tblAssignChapter WHERE AssignUserName='" + Session["LoginId"] + "' AND TypeOFExam='" + ddlTypeofExam.SelectedValue + "' AND Subject_id='" + cmbSelectsubject.SelectedValue + "' AND TypeofMaterial='" + rdoTypeofMaterial.SelectedItem.Text + "' ";
        }

        DataSet ds5 = cc.ExecuteDataset(Sql);
        int countValue = ds5.Tables[0].Rows.Count;
        if (countValue > 0)
        {
            for (int c = 0; c < countValue; c++)
            {
                TypeOFExam1 = Convert.ToInt32(ds5.Tables[0].Rows[c]["TypeOFExam"]);
                Class_id1 = Convert.ToInt32(ds5.Tables[0].Rows[c]["Class_id"]);
                Subject_id1 = Convert.ToInt32(ds5.Tables[0].Rows[c]["Subject_id"]);
                string ch = Convert.ToString(ds5.Tables[0].Rows[c]["Chapter_id"]);

                if (rdoTypeofMaterial.SelectedItem.Text == "Class")
                {
                    if (ch != "")
                    {
                        try
                        {
                            Chapter_id1 = Convert.ToInt32(ch);
                        }
                        catch
                        {
                            Response.Write("<Script>alert('ASSIGN ONLY 1 CHAPTER TO EXCEL UPLOAD..!!!')</Script>");
                            break;
                        }

                        if (Class_id1 != 1)
                        {
                            Class_id1 = Class_id1 - 4;
                        }

                        if (Chapter_id1 != 1)
                        {
                            Chapter_id1 = Chapter_id1 - 34;
                        }
                        try
                        {
                            if (TypeOFExam1 == Convert.ToInt32(ddlTypeofExam.SelectedValue))
                            {

                                if (Class_id1 == (Convert.ToInt32(ddlAddClass.SelectedValue) - 4))
                                {
                                    if (Subject_id1 == Convert.ToInt32(cmbSelectsubject.SelectedValue))
                                    {
                                        if (Chapter_id1 == (Convert.ToInt32(ddlChapter.SelectedValue) - 34))
                                        {
                                            //excelSubject = cmbSelectsubject.SelectedItem.Text;
                                            excelSubject = "UPLOAD";

                                            string strQuery = "SELECT * FROM [" + excelSubject + "$]";
                                            DataSet dscount = GetDataTable(strQuery);
                                            int count2 = Convert.ToInt32(dscount.Tables[0].Rows.Count);

                                            strQuery = "SELECT * FROM [" + excelSubject + "$] WHERE [Class] =" + Class_id1 + " AND [Chapter No] =" + Chapter_id1 + " ";
                                            ExcelDs = GetDataTable(strQuery);

                                            if (ExcelDs.Tables.Count == 0)
                                            {
                                                strQuery = "SELECT * FROM [" + excelSubject + "$] WHERE [Class] = " + Class_id1 + " AND [Chapter No] = " + Chapter_id1 + " ";
                                                ExcelDs = GetDataTable(strQuery);

                                                if (ExcelDs.Tables.Count == 0)
                                                {
                                                    strQuery = "SELECT * FROM [" + excelSubject + "$] WHERE [Class] = '" + Class_id1 + "' AND [Chapter No] = " + Chapter_id1 + " ";
                                                    ExcelDs = GetDataTable(strQuery);

                                                    if (ExcelDs.Tables.Count == 0)
                                                    {
                                                        strQuery = "SELECT * FROM [" + excelSubject + "$] WHERE [Class] = " + Class_id1 + " AND [Chapter No] = '" + Chapter_id1 + "' ";
                                                        ExcelDs = GetDataTable(strQuery);
                                                    }
                                                }
                                            }

                                            FetchQuestion(ExcelDs);

                                            count2 = count2 - count;
                                            lblcount2.Text = "NUMBER OF QUESTIONS NOT UPLOADED : " + count2;
                                            lblcount2.Visible = true;
                                            lblcount2.Font.Bold = true;
                                            lblcount2.ForeColor = System.Drawing.Color.RoyalBlue;

                                        }
                                        else
                                        {
                                            lblError.Text = "SELECT PROPER CHAPTER ASSIGN TO YOU..!!!";
                                            lblError.Visible = true;
                                            lblError.ForeColor = System.Drawing.Color.Red;
                                            lblError.Font.Bold = true;
                                            Response.Write("<Script>alert('SELECT PROPER CHAPTER ASSIGN TO YOU..!!!')</Script>");
                                        }
                                    }
                                    else
                                    {
                                        lblError.Text = "SELECT PROPER SUBJECT ASSIGN TO YOU..!!!";
                                        lblError.Visible = true;
                                        lblError.ForeColor = System.Drawing.Color.Red;
                                        lblError.Font.Bold = true;
                                        Response.Write("<Script>alert('SELECT PROPER SUBJECT ASSIGN TO YOU..!!!')</Script>");
                                    }
                                }
                                else
                                {
                                    lblError.Text = "SELECT PROPER CLASS ASSIGN TO YOU..!!!";
                                    lblError.Visible = true;
                                    lblError.ForeColor = System.Drawing.Color.Red;
                                    lblError.Font.Bold = true;
                                    Response.Write("<Script>alert('SELECT PROPER CLASS ASSIGN TO YOU..!!!')</Script>");
                                }
                            }
                            else
                            {
                                lblError.Text = "SELECT PROPER EXAM ASSIGN TO YOU..!!!";
                                lblError.Visible = true;
                                lblError.ForeColor = System.Drawing.Color.Red;
                                lblError.Font.Bold = true;
                                Response.Write("<Script>alert('SELECT PROPER EXAM ASSIGN TO YOU..!!!')</Script>");
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<h4>" + ex.Message);
                        }
                    }

                    else
                    {
                        if (Class_id1 != 1)
                        {
                            Class_id1 = Class_id1 - 4;
                        }
                        try
                        {
                            if (TypeOFExam1 == Convert.ToInt32(ddlTypeofExam.SelectedValue))
                            {

                                if (Class_id1 == (Convert.ToInt32(ddlAddClass.SelectedValue) - 4))
                                {

                                    if (Subject_id1 == Convert.ToInt32(cmbSelectsubject.SelectedValue))
                                    {
                                        //excelSubject = cmbSelectsubject.SelectedItem.Text;
                                        excelSubject = "UPLOAD";

                                        string strQuery = "SELECT * FROM [" + excelSubject + "$]";
                                        DataSet dscount = GetDataTable(strQuery);
                                        int count2 = Convert.ToInt32(dscount.Tables[0].Rows.Count);

                                        strQuery = "SELECT * FROM [" + excelSubject + "$] WHERE [Class]='" + Class_id1 + "' ";
                                        ExcelDs = GetDataTable(strQuery);

                                        if (ExcelDs.Tables.Count == 0)
                                        {
                                            strQuery = "SELECT * FROM [" + excelSubject + "$] WHERE [Class]=" + Class_id1 + " ";
                                            ExcelDs = GetDataTable(strQuery);
                                        }

                                        FetchQuestion(ExcelDs);

                                        count2 = count2 - count;
                                        lblcount2.Text = "NUMBER OF QUESTIONS NOT UPLOADED : " + count2;
                                        lblcount2.Visible = true;
                                        lblcount2.Font.Bold = true;
                                        lblcount2.ForeColor = System.Drawing.Color.RoyalBlue;
                                    }
                                    else
                                    {
                                        lblError.Text = "SELECT PROPER SUBJECT ASSIGN TO YOU..!!!";
                                        lblError.Visible = true;
                                        lblError.ForeColor = System.Drawing.Color.Red;
                                        lblError.Font.Bold = true;
                                        Response.Write("<Script>alert('SELECT PROPER SUBJECT ASSIGN TO YOU..!!!')</Script>");
                                    }
                                }

                                else
                                {
                                    lblError.Text = "SELECT PROPER CLASS ASSIGN TO YOU..!!!";
                                    lblError.Visible = true;
                                    lblError.ForeColor = System.Drawing.Color.Red;
                                    lblError.Font.Bold = true;
                                    Response.Write("<Script>alert('SELECT PROPER CLASS ASSIGN TO YOU..!!!')</Script>");
                                }
                            }
                            else
                            {
                                lblError.Text = "SELECT PROPER EXAM ASSIGN TO YOU..!!!";
                                lblError.Visible = true;
                                lblError.ForeColor = System.Drawing.Color.Red;
                                lblError.Font.Bold = true;
                                Response.Write("<Script>alert('SELECT PROPER SUBJECT ASSIGN TO YOU..!!!')</Script>");
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<h4>" + ex.Message);
                        }
                    }
                }
                else if (rdoTypeofMaterial.SelectedItem.Text == "Competitive Exam") // class not compare in loop
                {
                    if (ch != "")
                    {
                        try
                        {
                            Chapter_id1 = Convert.ToInt32(ch);
                        }
                        catch
                        {

                            Response.Write("<Script>alert('SELECT ONLY 1 CHAPETR TO UPLOAD..!!!')</Script>");
                            break;
                        }

                        if (Chapter_id1 != 1)
                        {
                            Chapter_id1 = Chapter_id1 - 34;
                        }

                        try
                        {
                            if (TypeOFExam1 == Convert.ToInt32(ddlTypeofExam.SelectedValue))
                            {
                                // class if not taken 

                                if (Subject_id1 == Convert.ToInt32(cmbSelectsubject.SelectedValue))
                                {
                                    if (Chapter_id1 == (Convert.ToInt32(ddlChapter.SelectedValue) - 34))
                                    {
                                        //excelSubject = cmbSelectsubject.SelectedItem.Text;
                                        excelSubject = "UPLOAD";   //UPLOAD

                                        string strQuery = "SELECT * FROM [" + excelSubject + "$]";
                                        DataSet dscount = GetDataTable(strQuery);
                                        int count2 = Convert.ToInt32(dscount.Tables[0].Rows.Count);

                                        strQuery = "SELECT * FROM [" + excelSubject + "$] WHERE [Chapter No]=" + Chapter_id1 + " AND [Competitive Exam]<>''";
                                        ExcelDs = GetDataTable(strQuery);

                                        if (ExcelDs.Tables.Count == 0)
                                        {
                                            strQuery = "SELECT * FROM [" + excelSubject + "$] WHERE [Chapter No]=" + Chapter_id1 + " AND [Competitive Exam]<>''";
                                            ExcelDs = GetDataTable(strQuery);
                                        }

                                        FetchQuestion(ExcelDs);

                                        count2 = count2 - count;
                                        lblcount2.Text = "NUMBER OF QUESTIONS NOT UPLOADED : " + count2;
                                        lblcount2.Visible = true;
                                        lblcount2.Font.Bold = true;
                                        lblcount2.ForeColor = System.Drawing.Color.RoyalBlue;
                                    }
                                    else
                                    {
                                        lblError.Text = "SELECT PROPER CHAPTER ASSIGN TO YOU..!!!";
                                        lblError.Visible = true;
                                        lblError.ForeColor = System.Drawing.Color.Red;
                                        lblError.Font.Bold = true;
                                        Response.Write("<Script>alert('SELECT PROPER CHAPTER ASSIGN TO YOU..!!!')</Script>");
                                    }
                                }
                                else
                                {
                                    lblError.Text = "SELECT PROPER SUBJECT ASSIGN TO YOU..!!!";
                                    lblError.Visible = true;
                                    lblError.ForeColor = System.Drawing.Color.Red;
                                    lblError.Font.Bold = true;
                                    Response.Write("<Script>alert('SELECT PROPER SUBJECT ASSIGN TO YOU..!!!')</Script>");
                                }
                            }
                            else
                            {
                                lblError.Text = "SELECT PROPER EXAM ASSIGN TO YOU..!!!";
                                lblError.Visible = true;
                                lblError.ForeColor = System.Drawing.Color.Red;
                                lblError.Font.Bold = true;
                                Response.Write("<Script>alert('SELECT PROPER EXAM ASSIGN TO YOU..!!!')</Script>");
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<h4>" + ex.Message); //Competitive Exam cha!=null
                        }
                    }

                    else
                    {
                        try
                        {
                            if (TypeOFExam1 == Convert.ToInt32(ddlTypeofExam.SelectedValue))
                            {
                                //if (Class_id1 == (Convert.ToInt32(ddlAddClass.SelectedValue) - 4))
                                //{
                                if (Subject_id1 == Convert.ToInt32(cmbSelectsubject.SelectedValue))
                                {
                                    //excelSubject = cmbSelectsubject.SelectedItem.Text;
                                    excelSubject = "UPLOAD";

                                    string strQuery = "SELECT * FROM [" + excelSubject + "$]";
                                    DataSet dscount = GetDataTable(strQuery);
                                    int count2 = Convert.ToInt32(dscount.Tables[0].Rows.Count);

                                    strQuery = "SELECT * FROM [" + excelSubject + "$] WHERE [Competitive Exam]<>''";

                                    ExcelDs = GetDataTable(strQuery);
                                    FetchQuestion(ExcelDs);

                                    count2 = count2 - count;
                                    lblcount2.Text = "NUMBER OF QUESTIONS NOT UPLOADED : " + count2;
                                    lblcount2.Visible = true;
                                    lblcount2.Font.Bold = true;
                                    lblcount2.ForeColor = System.Drawing.Color.RoyalBlue;
                                }
                                else
                                {
                                    lblError.Text = "SELECT PROPER SUBJECT ASSIGN TO YOU..!!!";
                                    lblError.Visible = true;
                                    lblError.ForeColor = System.Drawing.Color.Red;
                                    lblError.Font.Bold = true;
                                    Response.Write("<Script>alert('SELECT PROPER SUBJECT ASSIGN TO YOU..!!!')</Script>");
                                }
                            }
                            else
                            {
                                lblError.Text = "SELECT PROPER EXAM ASSIGN TO YOU..!!!";
                                lblError.Visible = true;
                                lblError.Font.Bold = true;
                                lblError.ForeColor = System.Drawing.Color.Red;

                                Response.Write("<Script>alert('SELECT PROPER EXAM ASSIGN TO YOU..!!!')</Script>");
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<h4>" + ex.Message); //Competitive Exam cha==null
                        }
                    }
                }
            }
        }
        else
        {
            lblError.Text = "ASSIGN ONLY 1 CHAPTER FOR THIS EXAM..!!!";
            lblError.Visible = true;
            lblError.Font.Bold = true;
            lblError.ForeColor = System.Drawing.Color.Red;

            Response.Write("<Script>alert('ASSIGN ONLY 1 CHAPTER FOR THIS EXAM..!!!')</Script>");
        }
    }

    public void FetchQuestion(DataSet ExcelDs)
    {
        int countVal = ExcelDs.Tables[0].Rows.Count;

        for (int i = 0; i < countVal; i++)
        {
            srno = Convert.ToString(ExcelDs.Tables[0].Rows[i]["SrNo"]);
            Question = Convert.ToString(ExcelDs.Tables[0].Rows[i]["Question"]);
            option1 = Convert.ToString(ExcelDs.Tables[0].Rows[i]["Option A"]);
            option2 = Convert.ToString(ExcelDs.Tables[0].Rows[i]["Option B"]);
            option3 = Convert.ToString(ExcelDs.Tables[0].Rows[i]["Option C"]);
            option4 = Convert.ToString(ExcelDs.Tables[0].Rows[i]["Option D"]);
            OptionE = Convert.ToString(ExcelDs.Tables[0].Rows[i]["Option E"]);
            correctoption = Convert.ToString(ExcelDs.Tables[0].Rows[i]["Answer"]);
            hint = Convert.ToString(ExcelDs.Tables[0].Rows[i]["Hint"]);
            level = Convert.ToString(ExcelDs.Tables[0].Rows[i]["Level"]);
            chaptorno = Convert.ToString(ExcelDs.Tables[0].Rows[i]["Chapter No"]);
            userChapterName = Convert.ToString(ExcelDs.Tables[0].Rows[i]["Chapter Name"]); //New Line Added to ExcelUpload
            subject = Convert.ToString(cmbSelectsubject.SelectedItem.Text);  //Convert.ToString(ExcelDs.Tables[0].Rows[i]["Subject"]);
            classname = Convert.ToString(ExcelDs.Tables[0].Rows[i]["Class"]);
            userCompitativeExam = Convert.ToString(ExcelDs.Tables[0].Rows[i]["Competitive Exam"]);
            userTopic_id = Convert.ToString(ExcelDs.Tables[0].Rows[i]["Topic No"]);

            if (Question != "")
            {
                Addexcel(srno, Question, option1, option2, option3, option4, OptionE, correctoption, hint, level, chaptorno, subject, classname, userCompitativeExam, userTopic_id, userChapterName);
                count++;
            }
        }

        if (submitcount > 0 || updateCount > 0)
        {
            lblError.Text = "THIS ' " + FileUpload1.FileName + " ' FILE SUBMITED SUCCESSFULLY..!!!";
            lblError.Visible = true;
            lblError.Font.Bold = true;
            lblError.ForeColor = System.Drawing.Color.Green;
        }

        lblcount.Text = "TOTAL QUESTIONS UPLOADED : " + count;
        lblcount.Visible = true;
        lblcount.Font.Bold = true;
        lblcount.ForeColor = System.Drawing.Color.DarkGreen;

        lblSubmitted.Text = "TOTAL QUESTIONS SUBMITED : " + submitcount;
        lblSubmitted.Visible = true;
        lblSubmitted.Font.Bold = true;
        lblSubmitted.ForeColor = System.Drawing.Color.Violet;

        lblUpdated.Text = "TOTAL QUESTIONS UPDATED : " + updateCount;
        lblUpdated.Visible = true;
        lblUpdated.Font.Bold = true;
        lblUpdated.ForeColor = System.Drawing.Color.Indigo;
    }

    int submitcount = 0;
    int updateCount = 0;

    public void Addexcel(string srno, string Question, string Answer1, string Answer2, string Answer3, string Answer4, string OptionE, string Correct_answer, string Qhint, string QuestionLevel, string chaptorno, string Subject_id, string class1, string userCompitativeExam, string userTopic_id, string userChapterName)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))

            try
            {
                con.Open();
                string Sql = "SELECT [SNO] FROM [tblQuestionAccess] WHERE TypeOfExam='" + ddlTypeofExam.SelectedValue + "' AND Question_id='" + srno + "' AND  userChapter_id='" + chaptorno + "' AND userSubject_id='" + Subject_id + "' AND userClass_id='" + class1 + "' AND userTopic_id='" + userTopic_id + "' AND UploadFileName='" + FileUpload1.FileName + "' AND TypeofDB='Excel'  ";

                string Qid = cc.ExecuteScalar(Sql);
                if (Qid != "")
                {
                    string str = " UPDATE tblQuestionAccess SET  " +
                           " Question_id=N'" + srno + "',Question=N'" + Question.Replace("'", "@011") + "', Answer1=N'" + Answer1.Replace("'", "@011") + "', Answer2=N'" + Answer2.Replace("'", "@011") + "', Answer3=N'" + Answer3.Replace("'", "@011") + "', Answer4=N'" + Answer4.Replace("'", "@011") + "',OptionE=N'" + OptionE.Replace("'", "@011") + "', Correct_answer=N'" + Correct_answer + "', Qhint=N'" + Qhint.Replace("'", "@011") + "',  " +
                           " QuestionLevel=N'" + QuestionLevel + "',userCompitativeExam=N'" + userCompitativeExam + "',userTopic_id=N'" + userTopic_id + "',userChapter_id=N'" + chaptorno + "',userChapterName=N'" + userChapterName + "',userSubject_id=N'" + Subject_id + "',userClass_id=N'" + class1 + "',Ischecked='0', " +
                           " TypeofQues= N'" + ddlTypeofQues.SelectedValue + "',TypeOfExam=N'" + ddlTypeofExam.SelectedValue + "',Class_id=N'" + ddlAddClass.SelectedValue + "', Subject_id=N'" + cmbSelectsubject.SelectedValue + "',  " +
                           " Chapter_id=N'" + ddlChapter.SelectedValue + "', Topic_id=N'" + ddlTopic.SelectedValue + "',MediumID=N'" + ddlMedium.SelectedItem.Text + "',LoginId=N'" + Session["LoginId"] + "',DOUpload=N'" + EntryDate + "', " +
                           " UploaderMoNo=N'" + txtMobileNo2.Text + "',TypeofMaterial='" + rdoTypeofMaterial.SelectedItem.Text + "',Sellanguage='" + cmbSelectlang.SelectedItem.Text + "',PublicationName='" + ddlpublication.SelectedItem.Text + "' " +
                           " WHERE LoginId='" + Session["LoginId"] + "' AND SNO='" + Qid + "' AND UploadFileName='" + FileUpload1.FileName + "' AND TypeofDB='Excel' ";

                    SqlCommand cmd5 = new SqlCommand(str, con);
                    cmd5.ExecuteNonQuery();

                    updateCount++;

                    lblError.Text = "THIS '" + FileUpload1.FileName + "' FILE SUBMITED SUCCESSFULLY..!!!";
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Green;

                    Response.Write("<Script>alert('THIS '" + FileUpload1.FileName + "' FILE SUBMITED SUCCESSFULLY..!!!')</Script>");
                }

                else
                {
                    string str = " INSERT INTO tblQuestionAccess " +
                                 " (Question_id,Question, Answer1, Answer2, Answer3, Answer4,OptionE, Correct_answer, Qhint, QuestionLevel,userCompitativeExam,userTopic_id,userChapter_id,userSubject_id,userClass_id,Ischecked, " +
                                 " TypeofQues,TypeOfExam,Class_id, Subject_id,Chapter_id, Topic_id,MediumID,LoginId,DOUpload, UploaderMoNo,TypeofMaterial,TypeofDB,Sellanguage,UploadFileName,PublicationName,userChapterName) VALUES" +
                                 " (N'" + srno + "',N'" + Question.Replace("'", "@011") + "',N'" + Answer1.Replace("'", "@011") + "',N'" + Answer2.Replace("'", "@011") + "',N'" + Answer3.Replace("'", "@011") + "',N'" + Answer4.Replace("'", "@011") + "',N'" + OptionE.Replace("'", "@011") + "',N'" + Correct_answer + "',N'" + Qhint.Replace("'", "@011") + "',N'" + QuestionLevel + "',N'" + userCompitativeExam + "',N'" + userTopic_id + "',N'" + chaptorno + "',N'" + Subject_id + "',N'" + class1 + "','0', " +
                                 " N'" + ddlTypeofQues.SelectedValue + "',  N'" + ddlTypeofExam.SelectedValue + "',N'" + ddlAddClass.SelectedValue + "',N'" + cmbSelectsubject.SelectedValue + "',N'" + ddlChapter.SelectedValue + "',N'" + ddlTopic.SelectedValue + "',N'" + ddlMedium.SelectedItem.Text + "',N'" + Session["LoginId"] + "',N'" + EntryDate + "',N'" + txtMobileNo2.Text + "',N'" + rdoTypeofMaterial.SelectedItem.Text + "','Excel','" + cmbSelectlang.SelectedItem.Text + "','" + FileUpload1.FileName + "',N'" + ddlpublication.SelectedItem.Text + "',N'" + userChapterName + "')";

                    SqlCommand cmd5 = new SqlCommand(str, con);
                    cmd5.ExecuteNonQuery();
                    submitcount++;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "UPLOAD ERROR..!!! PLEASE CHECK EXCEL_FILE FORMAT OR " + ex.Message;
            }
    }

    #region LoadRecordIndropdownList at PageLoad

    public void loadrecord()
    {
        Sql = " SELECT Name, ItemValueId FROM tblItemValue WHERE ItemId=0 OR ItemId=5"; //loadTypeofQues
        Sql = Sql + "SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId=0 OR ItemId=3";  //loadChapter
        Sql = Sql + " SELECT Name, ItemValueId FROM tblItemValue WHERE ItemId=0 OR ItemId=4"; //loadTopic

        DataSet ds = cc.ExecuteDataset(Sql);

        ddlTypeofQues.DataSource = ds.Tables[0];
        ddlTypeofQues.DataTextField = "Name";
        ddlTypeofQues.DataValueField = "ItemValueId";
        ddlTypeofQues.DataBind();

        ddlChapter.DataSource = ds.Tables[1];
        ddlChapter.DataTextField = "Name";
        ddlChapter.DataValueField = "ItemValueId";
        ddlChapter.DataBind();

        ddlTopic.DataSource = ds.Tables[2];
        ddlTopic.DataTextField = "Name";
        ddlTopic.DataValueField = "ItemValueId";
        ddlTopic.DataBind();
    }

    #endregion

    public void Dateformat()
    {
        DateTime dt = DateTime.Now;
        DateTime SystemDate = Convert.ToDateTime(dt);
        EntryDate = SystemDate.ToString("yyyy'-'MM'-'dd''");
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~//Admin/Home.aspx");
    }

    protected void btnDowmLoad_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Excel Upload/Format of Question Upload.xlsx");
    }

    protected void rdoTypeofMaterial_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoTypeofMaterial.SelectedIndex == 0)
        {
            Label11.Visible = true;
            Label10.Visible = false;
            RequiredFieldValidator8.Enabled = true;
            RequiredFieldValidator7.Enabled = false;
        }
        else
        {
            Label11.Visible = false;
            Label10.Visible = true;
            RequiredFieldValidator8.Enabled = false;
            RequiredFieldValidator7.Enabled = true;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }

    #region ddlGropuofExam

    //protected void BindDropDown212()
    //{
    //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew=0 OR ItemIdNew=212 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlTypeofExam.DataSource = ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //protected void binddropdown213()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 213 ";
    //    DataSet DS = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = DS.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //protected void binddropdown214()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 214 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown273()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 273 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown274()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 274 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown275()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 275 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown276()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 276 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown277()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 277 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown278()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 278 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown279()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 445 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    protected void ddlGroupofExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        string groupExamid = ddlGroupofExam.SelectedValue;
        Cds.BindTypeofExamOnGroup(ddlTypeofExam, groupExamid);
        //if (ddlGroupofExam.SelectedValue == Convert.ToString(135))
        //{
        //    BindDropDown212();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(136))
        //{
        //    binddropdown213();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(137))
        //{
        //    binddropdown214();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(140))
        //{
        //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew=0 OR ItemIdNew=210  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(141))
        //{
        //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=207  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(142))
        //{
        //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=206  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(143))
        //{
        //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=203  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(144))
        //{
        //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=205  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(177))
        //{
        //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=1796  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(178))
        //{
        //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=1806  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(183))
        //{
        //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=1846  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(231))
        //{
        //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=2310  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(232))
        //{
        //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=2310  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(233))
        //{
        //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=2310  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(257))
        //{
        //    string loginid = Session["LoginId"].ToString();
        //    string Sql = "Select Niitaps From Login Where [LoginId]='" + loginid + "'";
        //    string ntps = Convert.ToString(cc.ExecuteScalar(Sql));
        //    if (ntps == "" || ntps == null)
        //    {
        //        lblError.Text = "Not permission to Upload Excel file...!!";
        //        lblError.Visible = true;
        //        lblError.ForeColor = System.Drawing.Color.Red;
        //        lblError.Font.Bold = true;
            
        //    }
        //    else if (ntps == "1")
        //    {
        //        Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 257";
        //        DataSet ds = cc.ExecuteDataset(Sql);

        //        ddlTypeofExam.DataSource = ds.Tables[0];
        //        ddlTypeofExam.DataTextField = "Name";
        //        ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //        ddlTypeofExam.DataBind();
        //    }
        //    else
        //    {
        //        Response.Write("<Script>alert('Not permission to create test..!!!')</Script>");
        //    }
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(273))
        //{
        //    binddropdown273();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(274))
        //{
        //    binddropdown274();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(275))
        //{
        //    binddropdown275();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(276))
        //{
        //    binddropdown276();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(277))
        //{
        //    binddropdown277();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(278))
        //{
        //    binddropdown278();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(445))
        //{
        //    binddropdown279();
        //}
    }
    #endregion

    #region ddlTypeofExam

    //protected void BindDropDown202()
    //{
    //    ddlAddClass.Enabled = true;
    //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=202 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlAddClass.DataSource = ds.Tables[0];
    //    ddlAddClass.DataTextField = "Name";
    //    ddlAddClass.DataValueField = "ItemValueIdNew";
    //    ddlAddClass.DataBind();
    //}
    //protected void BindDropDown211()
    //{
    //    ddlAddClass.Enabled = true;
    //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=211 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlAddClass.DataSource = ds.Tables[0];
    //    ddlAddClass.DataTextField = "Name";
    //    ddlAddClass.DataValueField = "ItemValueIdNew";
    //    ddlAddClass.DataBind();
    //}
    //protected void BindDropDown2()
    //{
    //    Sql = Sql + "SELECT Name,ItemValueId FROM tblItemValue WHERE  ItemId=0 OR ItemId=2 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    cmbSelectsubject.DataSource = ds.Tables[0];
    //    cmbSelectsubject.DataTextField = "Name";
    //    cmbSelectsubject.DataValueField = "ItemValueId";
    //    cmbSelectsubject.DataBind();
    //    ddlAddClass.SelectedValue = "1";
    //    ddlAddClass.Enabled = false;
    //}
    //protected void Binddropdown201()
    //{
    //    ddlAddClass.Enabled = true;
    //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=201 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlAddClass.DataSource = ds.Tables[0];
    //    ddlAddClass.DataTextField = "Name";
    //    ddlAddClass.DataValueField = "ItemValueIdNew";
    //    ddlAddClass.DataBind();
    //}

    protected void ddlTypeofExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        string classORSubject = ddlTypeofExam.SelectedValue;
        Cds.BindClassOrSubject(ddlAddClass, classORSubject, cmbSelectsubject);
        //if (ddlTypeofExam.SelectedValue == Convert.ToString(88))
        //{
        //    Binddropdown201();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(271))
        //{
        //    Binddropdown201();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(272))
        //{
        //    Binddropdown201();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(98))
        //{
        //    BindDropDown202();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(99))
        //{
        //    BindDropDown202();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(100))
        //{
        //    BindDropDown202();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(96))
        //{
        //    BindDropDown211();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(101))
        //{
        //    BindDropDown211();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(102))
        //{
        //    BindDropDown211();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(89))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(94))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(95))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(130))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(110))
        //{
        //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=204 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    cmbSelectsubject.DataSource = ds.Tables[0];
        //    cmbSelectsubject.DataTextField = "Name";
        //    cmbSelectsubject.DataValueField = "ItemValueIdNew";
        //    cmbSelectsubject.DataBind();
        //    ddlAddClass.SelectedValue = "1";
        //    ddlAddClass.Enabled = false;
        //}

        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(103))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(165))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(179))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(180))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(176))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(184))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(185))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(191))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(193))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(200) || ddlTypeofExam.SelectedValue == Convert.ToString(201) || ddlTypeofExam.SelectedValue == Convert.ToString(202) || ddlTypeofExam.SelectedValue == Convert.ToString(203) || ddlTypeofExam.SelectedValue == Convert.ToString(204) || ddlTypeofExam.SelectedValue == Convert.ToString(205) || ddlTypeofExam.SelectedValue == Convert.ToString(206) || ddlTypeofExam.SelectedValue == Convert.ToString(207))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(217))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(224))
        //{
        //    ddlAddClass.Enabled = true;
        //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=201 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlAddClass.DataSource = ds.Tables[0];
        //    ddlAddClass.DataTextField = "Name";
        //    ddlAddClass.DataValueField = "ItemValueIdNew";
        //    ddlAddClass.DataBind();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(227))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(228))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(229))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(230))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(234))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(235))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(236))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(237))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(248))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(254))
        //{
        //    BindDropDown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(258) || ddlTypeofExam.SelectedValue == Convert.ToString(259) || ddlTypeofExam.SelectedValue == Convert.ToString(260) || ddlTypeofExam.SelectedValue == Convert.ToString(261) || ddlTypeofExam.SelectedValue == Convert.ToString(262) || ddlTypeofExam.SelectedValue == Convert.ToString(263) || ddlTypeofExam.SelectedValue == Convert.ToString(264) || ddlTypeofExam.SelectedValue == Convert.ToString(265))
        //{
        //    Binddropdown201();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(266) || ddlTypeofExam.SelectedValue == Convert.ToString(267) || ddlTypeofExam.SelectedValue == Convert.ToString(268) || ddlTypeofExam.SelectedValue == Convert.ToString(269) || ddlTypeofExam.SelectedValue == Convert.ToString(270))
        //{
        //    Binddropdown201();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(446) || ddlTypeofExam.SelectedValue == Convert.ToString(447) || ddlTypeofExam.SelectedValue == Convert.ToString(448) || ddlTypeofExam.SelectedValue == Convert.ToString(449))
        //{
        //    BindDropDown2();
        //}
    }
    #endregion

    #region ddlAddClass
    protected void ddlAddClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        string addClassIDNew = ddlAddClass.SelectedValue;
        Cds.BindAddSubjectOnClassId(cmbSelectsubject, addClassIDNew, ddlTypeofExam);
        //for (int count = 0; count < 15; count++)
        //{
        //    if (ddlAddClass.SelectedValue == Convert.ToString(count))
        //    {
        //        Sql = Sql + "SELECT Name,ItemValueId FROM tblItemValue WHERE  ItemId=0 OR ItemId=2 ";
        //        DataSet ds = cc.ExecuteDataset(Sql);

        //        cmbSelectsubject.DataSource = ds.Tables[0];
        //        cmbSelectsubject.DataTextField = "Name";
        //        cmbSelectsubject.DataValueField = "ItemValueId";
        //        cmbSelectsubject.DataBind();
        //    }
        //}
        //if ((ddlAddClass.SelectedValue == Convert.ToString(15) || ddlAddClass.SelectedValue == Convert.ToString(16)) && ddlTypeofExam.SelectedValue == Convert.ToString(99))
        //{
        //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemId=0 OR ItemIdNew=209 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    cmbSelectsubject.DataSource = ds.Tables[0];
        //    cmbSelectsubject.DataTextField = "Name";
        //    cmbSelectsubject.DataValueField = "ItemValueIdNew";
        //    cmbSelectsubject.DataBind();
        //}

        //else if ((ddlAddClass.SelectedValue == Convert.ToString(15) || ddlAddClass.SelectedValue == Convert.ToString(16)) && (ddlTypeofExam.SelectedValue == Convert.ToString(98) || ddlTypeofExam.SelectedValue == Convert.ToString(100)))
        //{
        //    Sql = Sql + "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=208 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    cmbSelectsubject.DataSource = ds.Tables[0];
        //    cmbSelectsubject.DataTextField = "Name";
        //    cmbSelectsubject.DataValueField = "ItemValueIdNew";
        //    cmbSelectsubject.DataBind();
        //}
        //else if (ddlAddClass.SelectedValue == Convert.ToString(188))
        //{
        //    Sql = Sql + "SELECT Name,ItemValueId FROM tblItemValue WHERE  ItemId=0 OR ItemId=2 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    cmbSelectsubject.DataSource = ds.Tables[0];
        //    cmbSelectsubject.DataTextField = "Name";
        //    cmbSelectsubject.DataValueField = "ItemValueId";
        //    cmbSelectsubject.DataBind();
        //}
        //else if (ddlAddClass.SelectedValue == Convert.ToString(189))
        //{
        //    Sql = Sql + "SELECT Name,ItemValueId FROM tblItemValue WHERE  ItemId=0 OR ItemId=2 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    cmbSelectsubject.DataSource = ds.Tables[0];
        //    cmbSelectsubject.DataTextField = "Name";
        //    cmbSelectsubject.DataValueField = "ItemValueId";
        //    cmbSelectsubject.DataBind();
        //}
    }
    #endregion

    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void cmbSelectsubject_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


}
