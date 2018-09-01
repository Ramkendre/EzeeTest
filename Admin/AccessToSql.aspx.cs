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

using System.Security.Cryptography;


public partial class Admin_AccessToSql : System.Web.UI.Page
{
    Microsoft.Office.Interop.Excel.Application xlApp;
    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
    Microsoft.Office.Interop.Excel.Range range;
    Object ConfirmConversions = false;
    Object isVisible = true;
    object misValue = System.Reflection.Missing.Value;
    Regex regex1 = new Regex(@"ADDR:");
    CommonCode cc = new CommonCode();

    string Question = "", Answer = "", QuestionWithImage = "", Hint = "", Passage = "", MobileNo = "";
    string OptionA = "", OptionB = "", OptionC = "", OptionD = "", OptionE = "", OptionP = "", OptionQ = "", OptionR = "", OptionS = "", OptionT = "", Medium = "", changesDate = "", OptionF = "", OptionG = "", OptionH = "", OptionU = "", OptionV = "", OptionW = "";
    int QType, QuesNo, i, AType, BType, CType, DType, EType, hType, Q1Type, PType, QType1, RType, SType, TType, passageType, Level1, SettingId, TypeOfQues, QuestionID, FType, GType, H1Type, UType, VType, WType;
    string ePublication = "", eFontname = "", Name = "", Details = "", ItemId = "";
    int ID, TypeOFExam, Class_id, Subject_id, Chapter_id, Topic_id, Server_SettingID;
    int ItemValueId;
    string EntryDate = "";
    int TypeOFExam1, Class_id1, Subject_id1;
    string Chapter_id1 = "", userChapterName = "";
    string Sql;
    string QuesErrorID = string.Empty;
    //for excel connection
    string pathOnly = string.Empty;
    string fileName = string.Empty;
    string fileExtension = string.Empty;
    string conPath = "";
    OleDbConnection conn = null;
    DataSet ds = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            loadRecord(); // Bind all DropDownlist 
            LoadRecordUpdateChapter();

            Sql = "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=8 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlGroupofExam.DataSource = ds.Tables[0];
            ddlGroupofExam.DataTextField = "Name";
            ddlGroupofExam.DataValueField = "ItemValueId";
            ddlGroupofExam.DataBind();

        }
        Dateformat();
    }


    public DataSet GetDataTable(string strQuery)
    {
        DataSet tempDs = null;
        string filePath = Server.MapPath("Access_upload\\" + FileUpload1.FileName);
        fileExtension = Path.GetExtension(filePath);

        if (this.fileExtension == ".xls")
        {
            conPath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
        }
        else
        {
            conPath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
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
            Response.Write("<h4>Error :" + ex.Message);
        }
        conn.Close();

        return tempDs;
    }


    public DataSet GetAccessDataTable(string strQuery)
    {
        DataSet tempDs = null;
        string filePath = Server.MapPath("Access_upload\\" + FileUpload1.FileName);
        fileExtension = Path.GetExtension(filePath);

        if (this.fileExtension == ".mdb")
        {
            conPath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Persist Security Info=True;Jet OLEDB:Database Password=ezeeQues!@#";
        }
        else
        {
            conPath = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Persist Security Info=True;Jet OLEDB:Database Password=ezeeQues!@#";
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
            Response.Write("<h4>Error :" + ex.Message);
        }
        conn.Close();

        return tempDs;

    }




    protected void btnSubmitQues_Click(object sender, EventArgs e)
    {
        lblQuesError.Text = "";
        DataSet ds = new DataSet();

        try
        {
            string path = "";
            path = Server.MapPath("Access_upload"); // Save file on server folder 
            path = path + "\\" + FileUpload1.FileName;
            if (File.Exists(path))
            {
                File.Delete(path);
                FileUpload1.SaveAs(path);
            }
            else
            {
                FileUpload1.SaveAs(path);
            }


            if (rdoTypeofMaterial.SelectedIndex == 0) // 0 mean choose check radio Class *change by me on 04.02.2015
            {
                Sql = "select * from tblAssignChapter where AssignUserName='" + Session["LoginId"] + "' and Class_id='" + ddlAddClass.SelectedValue + "' and Subject_id='" + cmbSelectsubject.SelectedValue + "' and TypeofMaterial='" + rdoTypeofMaterial.SelectedItem.Text + "' and Chapter_id like '%" + ddlChapter.SelectedValue + "%' ";
            }
            else
            {
                Sql = "select * from tblAssignChapter where AssignUserName='" + Session["LoginId"] + "' and TypeOFExam='" + ddlTypeofExam.SelectedValue + "' and Subject_id='" + cmbSelectsubject.SelectedValue + "' and TypeofMaterial='" + rdoTypeofMaterial.SelectedItem.Text + "' and Chapter_id like '%" + ddlChapter.SelectedValue + "%' ";
            }

            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strQuery = "select * from [tblSettings$]";
                DataSet dscount = GetDataTable(strQuery);
                int count2 = Convert.ToInt32(dscount.Tables[0].Rows.Count);

                strQuery = "SELECT *  FROM [tblSettings$] ";
                DataSet ds1 = new DataSet();
                ds1 = GetDataTable(strQuery);

                if (ds1.Tables[0].Rows.Count >= 1)
                {
                    for (int k = 1; k < ds1.Tables[0].Rows.Count; k++) // change on 01.01.14 for read  2nd rows from tbl
                    {
                        ID = Convert.ToInt16(ds1.Tables[0].Rows[k]["ID"]);
                        TypeOFExam = Convert.ToInt32(ds1.Tables[0].Rows[k]["examName"]);
                        Class_id = Convert.ToInt32(ds1.Tables[0].Rows[k]["eClass"]);
                        Subject_id = Convert.ToInt32(ds1.Tables[0].Rows[k]["eSubject"]);
                        Chapter_id = Convert.ToInt32(ds1.Tables[0].Rows[k]["eChapter"]);
                        Topic_id = Convert.ToInt32(ds1.Tables[0].Rows[k]["eTopic"]);
                        ePublication = Convert.ToString(ds1.Tables[0].Rows[k]["ePublication"]);
                        eFontname = Convert.ToString(ds1.Tables[0].Rows[k]["eFontName"]);
                        MobileNo = Convert.ToString(ds1.Tables[0].Rows[k]["MobileNo"]);

                        try
                        {
                            Server_SettingID = Convert.ToInt32(ds1.Tables[0].Rows[k]["Server_SettingID"]);
                        }
                        catch
                        {
                            Server_SettingID = 0;
                        }


                        if (MobileNo != "")
                        {
                            if (Server_SettingID != 0)
                            {
                                ID = Server_SettingID;
                            }
                            else
                            {
                                ID = Convert.ToInt16(ds1.Tables[0].Rows[k]["ID"]);
                            }

                            Addexcelsetting(ID, TypeOFExam, Class_id, Subject_id, Chapter_id, Topic_id, ePublication, eFontname, MobileNo);//, Medium, QuestionID);
                            UniqueId1 = 0;
                        }
                    }
                    Response.Write("<Script>alert('File Save Successfully !!!!!!! ')</Script>");
                    lblError.Visible = true;
                    lblError.Text = "File Save Successfully !!!!!!! ";
                }
                else
                {
                    lblError.Text = "No Setting Available";
                    lblError.Visible = true;
                    Response.Write("<Script>alert('No Question Available')</Script>");
                }
            }
            else
            {

                lblError.Text = "Please select proper Chapter ,Subject,Type Of Exam,Class Which is Assign you";
                lblError.Visible = true;
                Response.Write("<Script>alert('Please select proper Chapter ,Subject,Type Of Exam,Class Which is Assign you')</Script>");

            }


            //if (File.Exists(path))
            //{
            //    File.Delete(path);

            //}
        }

        catch (Exception ex)
        {
            // Response.Write("<h4>Error :" + ex.Message);
            // throw ex;
        }
    }

    public void Addexcel(int QuesNo, string Question, int QType, string OptionA, int AType, string OptionB, int BType, string OptionC, int CType, string OptionD, int DType, string OptionE, int EType, string Hint, int hType, string Answer, string MobileNo, int SettingId, int Level1, string QuestionWithImage, int Q1Type, int TypeOfQues, string OptionP, int PType, string OptionQ, int QType1, string OptionR, int RType, string OptionS, int SType, string OptionT, int TType, string Passage, int passageType, string changesDate, int UniqId, string OptionF, int FType, string OptionG, int GType, string OptionH, int H1Type, string OptionU, int UType, string OptionV, int VType, string OptionW, int WType)//,string Medium,int QuestionID)
    {
        Sql = "Select SNO from tblQuestionAccess where Question_id=" + QuesNo + "   and SettingId=" + SettingId + " and UniqueId=" + UniqId + " and LoginId='" + Session["LoginId"] + "'"; //and PublicationName='" + ddlpublication.SelectedItem.Text + "'";
        string Id = cc.ExecuteScalar(Sql);
        if (Id == "")
        {
            try
            {
                Sql = "insert into tblQuestionAccess " +
                        "( Question_id,Question,QType, Answer1,AType, Answer2,BType ,Answer3,CType, Answer4,DType,OptionE, EType, QHint, hType,Correct_Answer, MobileNo, SettingId, QuestionLevel, QuesWithImage, Q1Type, TypeOfQues, OptionP,PType, OptionQ, QType1, OptionR, RType, OptionS, SType,OptionT, TType, Passage, passageType, changeDate,UploaderMoNo ,UniqueId,DOUpload,LoginId, " +
                        " TypeOfExam,Class_id, Subject_id,Chapter_id, Topic_id,MediumID,TypeofMaterial,TypeofDB,PublicationName,OptionF,FType,OptionG,GType,OptionH,HType,OptionU,UType,OptionV,VType,OptionW,WType) values" +
                        "(" + QuesNo + ",N'" + Question.Replace("'", "@011") + "', " + QType + ", N'" + OptionA.Replace("'", "@011") + "'," + AType + ",N'" + OptionB.Replace("'", "@011") + "'," + BType + ",N'" + OptionC.Replace("'", "@011") + "'," + CType + ",N'" + OptionD.Replace("'", "@011") + "'," + DType + ",N'" + OptionE.Replace("'", "@011") + "'," + EType + ",N'" + Hint.Replace("'", "@011") + "'," + hType + ",'" + Answer + "','" + MobileNo + "'," + SettingId + "," + Level1 + ",N'" + QuestionWithImage.Replace("'", "@011") + "', " + Q1Type + "," + TypeOfQues + ", N'" + OptionP.Replace("'", "@011") + "', " + PType + ",N'" + OptionQ.Replace("'", "@011") + "', " + QType1 + ",N'" + OptionR.Replace("'", "@011") + "', " + RType + ",N'" + OptionS.Replace("'", "@011") + "', " + SType + ",N'" + OptionT.Replace("'", "@011") + "', " + TType + ",N'" + Passage.Replace("'", "@011") + "', " + passageType + ",'" + changesDate + "','" + txtMobileNo1.Text + "'," + UniqId + ",'" + EntryDate + "','" + Session["LoginId"] + "'  " +
                        " ,  '" + ddlTypeofExam.SelectedValue + "','" + ddlAddClass.SelectedValue + "','" + cmbSelectsubject.SelectedValue + "','" + ddlChapter.SelectedValue + "','" + ddlTopic.SelectedValue + "','" + ddlMedium.SelectedItem.Text + "','" + rdoTypeofMaterial.SelectedItem.Text + "','Access','" + ddlpublication.SelectedItem.Text + "',N'" + OptionF.Replace("'", "@011") + "'," + FType + ",N'" + OptionG.Replace("'", "@011") + "'," + GType + ",N'" + OptionH.Replace("'", "@011") + "'," + H1Type + ",N'" + OptionU.Replace("'", "@011") + "'," + UType + ",N'" + OptionV.Replace("'", "@011") + "'," + VType + ",N'" + OptionW.Replace("'", "@011") + "'," + WType + " )";

                int flag = cc.ExecuteNonQuery(Sql);
                submitcount++;

            }
            catch (Exception ex)
            {
                // Response.Write("<h4>Error :" + ex.Message);
            }
        }
        else
        {
            Sql = " Update tblQuestionAccess  set  Question_id = " + QuesNo + ",Question = N'" + Question.Replace("'", "@011") + "',QType = " + QType + ", " +
                  " Answer1 = N'" + OptionA.Replace("'", "@011") + "',AType = " + AType + ", Answer2 = N'" + OptionB.Replace("'", "@011") + "',BType = " + BType + ", " +
                  " Answer3 = N'" + OptionC.Replace("'", "@011") + "',CType = " + CType + ", Answer4 = N'" + OptionD.Replace("'", "@011") + "',DType = " + DType + " , " +
                  " OptionE = N'" + OptionE.Replace("'", "@011") + "', EType = " + EType + ", QHint = N'" + Hint.Replace("'", "@011") + "', hType = " + hType + ", " +
                  " Correct_Answer = '" + Answer + "', MobileNo = '" + MobileNo + "', SettingId = " + SettingId + ", " +
                  " QuestionLevel = " + Level1 + ", QuesWithImage = N'" + QuestionWithImage.Replace("'", "@011") + "', Q1Type = " + Q1Type + ", TypeOfQues = " + TypeOfQues + ", " +
                  " OptionP = N'" + OptionP.Replace("'", "@011") + "',PType = " + PType + ", OptionQ = N'" + OptionQ.Replace("'", "@011") + "', QType1 = " + QType1 + ", " +
                  " OptionR = N'" + OptionR.Replace("'", "@011") + "', RType = " + RType + ", OptionS = N'" + OptionS.Replace("'", "@011") + "', SType = " + SType + ",OptionT = N'" + OptionT.Replace("'", "@011") + "' , " +
                  " TType = " + TType + ", Passage = N'" + Passage.Replace("'", "@011") + "', passageType = " + passageType + ", changeDate = '" + changesDate + "', " +
                  " UploaderMoNo = '" + txtMobileNo1.Text + "' ,UniqueId = " + UniqId + ",DOUpload = '" + EntryDate + "',LoginId = '" + Session["LoginId"] + "' , " +
                  " TypeOfExam = '" + ddlTypeofExam.SelectedValue + "',Class_id = '" + ddlAddClass.SelectedValue + "', Subject_id = '" + cmbSelectsubject.SelectedValue + "',  " +
                  " Chapter_id = '" + ddlChapter.SelectedValue + "', Topic_id = '" + ddlTopic.SelectedValue + "',MediumID = '" + ddlMedium.SelectedItem.Text + "' ,TypeofMaterial = '" + rdoTypeofMaterial.SelectedItem.Text + "' ,PublicationName = '" + ddlpublication.SelectedItem.Text + "' " +
                  " OptionF = N'" + OptionF.Replace("'", "@011") + "',FType=" + FType + ", OptionG = N'" + OptionG.Replace("'", "@011") + "', GType=" + GType + ", OptionH = N'" + OptionH.Replace("'", "@011") + "', H1Type=" + H1Type + ", OptionU = N'" + OptionU.Replace("'", "@011") + "', UType=" + UType + ", OptionV = N'" + OptionV.Replace("'", "@011") + "', VType=" + VType + ", OptionW = N'" + OptionW.Replace("'", "@011") + "', WType=" + WType + "    where SNO=" + Id + "  ";

            int flag = cc.ExecuteNonQuery(Sql);
            updateCount++;
        }
    }

    public int UniqueId1 = 0;
    public void Addexcelsetting(int ID, int TypeOFExam, int Class_id, int Subject_id, int Chapter_id, int Topic_id, string ePublication, string eFontname, string MobileNo)
    {
        Sql = "select SNO from tblSettings where ID=" + ID + " and TypeOFExam=" + TypeOFExam + " and Class_id=" + Class_id + " and Subject_id=" + Subject_id + " and Chapter_id=" + Chapter_id + " and Topic_id=" + Topic_id + " and  MobileNo='" + MobileNo + "' and eFontname='" + eFontname + "' ";
        string SNO = Convert.ToString(cc.ExecuteScalar(Sql));

        Sql = "Select UniqueId from tblSettings where TypeOFExam=" + TypeOFExam + " and Class_id=" + Class_id + " and Subject_id=" + Subject_id + " and Chapter_id=" + Chapter_id + " and Topic_id=" + Topic_id + " ";
        string id = Convert.ToString(cc.ExecuteScalar(Sql));
        if (id == "NULL" || id == "")
        {
            Sql = "select max(UniqueId)+1 from tblSettings";
            UniqueId1 = Convert.ToInt32(cc.ExecuteScalar(Sql));
            //UniqueId1 = UniqueId1 + 1;
        }
        else
        {
            UniqueId1 = Convert.ToInt32(id);
        }

        if (SNO == "")
        {
            Sql = "insert into tblSettings " +
                       "( ID,TypeOFExam,Class_id,Subject_id,Chapter_id,Topic_id,ePublication,eFontname,MobileNo,UploaderMoNo,UniqueId,DOUpload,LoginId) values" +
                       "(" + ID + ", " + TypeOFExam + ", " + Class_id + "," + Subject_id + ", " + Chapter_id + "," + Topic_id + ",'" + ePublication + "','" + eFontname + "','" + MobileNo + "','" + txtMobileNo1.Text + "'," + UniqueId1 + " ,'" + EntryDate + "','" + Session["LoginId"] + "' )";

            int flag = cc.ExecuteNonQuery(Sql);
            tblQuestion(ID);  // ID=setting ID 
        }
        else
        {
            tblQuestion(ID);  // ID=setting ID  and insert all  Question  related to Setting id
        }

        lblInserted.Text = "Total Question Submitted : " + submitcount;
        lblInserted.Visible = true;
        lblUpdated.Text = "Total Question Updated : " + updateCount;
        lblUpdated.Visible = true;
    }

    int count = 0;
    int submitcount = 0;
    int updateCount = 0;
    int QuesError = 0;

    void tblQuestion(int ID) //This Function Read the Dycrypted Uploaded File of Excel from eZeeQuestion SoftWare 
    {
        Sql = "select * from [tblQuestion$] where SettingId=" + ID + "";

        DataSet dsQues = new DataSet();
        dsQues = GetDataTable(Sql);

        if (dsQues.Tables[0].Rows.Count >= 1)
        {
            for (int i = 0; i < dsQues.Tables[0].Rows.Count; i++)
            {
                count++;
                lblcount.Text = "Total Question Uploaded : " + count;
                lblcount.Visible = true;

                SettingId = Convert.ToInt32(dsQues.Tables[0].Rows[i]["SettingId"]);
                Level1 = Convert.ToInt32(dsQues.Tables[0].Rows[i]["Level1"]);
                QuestionWithImage = Convert.ToString(dsQues.Tables[0].Rows[i]["QuesWithImage"]);
                Q1Type = Convert.ToInt32(dsQues.Tables[0].Rows[i]["Q1Type"]);
                TypeOfQues = Convert.ToInt32(dsQues.Tables[0].Rows[i]["TypeOfQues"]);
                Hint = Convert.ToString(dsQues.Tables[0].Rows[i]["Hint"]);   //newly added by jitu

                if (TypeOfQues == 84 || TypeOfQues == 93) // 84- interger type, 93 theory type
                {
                    QuesNo = Convert.ToInt32(dsQues.Tables[0].Rows[i]["QuesNo"]);
                    Question = Convert.ToString(dsQues.Tables[0].Rows[i]["Question"]);
                    QType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["QType"]);

                    Hint = Convert.ToString(dsQues.Tables[0].Rows[i]["Hint"]);
                    hType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["hType"]);
                    Answer = Convert.ToString(dsQues.Tables[0].Rows[i]["Answer"]);
                }
                else
                {
                    QuesNo = Convert.ToInt32(dsQues.Tables[0].Rows[i]["QuesNo"]);
                    Question = Convert.ToString(dsQues.Tables[0].Rows[i]["Question"]);
                    QType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["QType"]);

                    OptionA = Convert.ToString(dsQues.Tables[0].Rows[i]["OptionA"]);
                    AType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["AType"]);
                    OptionB = Convert.ToString(dsQues.Tables[0].Rows[i]["OptionB"]);
                    BType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["BType"]);
                    OptionC = Convert.ToString(dsQues.Tables[0].Rows[i]["OptionC"]);
                    CType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["CType"]);
                    OptionD = Convert.ToString(dsQues.Tables[0].Rows[i]["OptionD"]);
                    DType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["DType"]);

                    if (TypeOfQues == 87)
                    {
                    }
                    else
                    {
                        OptionE = Convert.ToString(dsQues.Tables[0].Rows[i]["OptionE"]);
                        EType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["EType"]);
                    }

                    Answer = Convert.ToString(dsQues.Tables[0].Rows[i]["Answer"]);
                    MobileNo = Convert.ToString(dsQues.Tables[0].Rows[i]["MobileNo"]);
                }

                if (TypeOfQues == 87) // 87- matrix 
                {
                    OptionP = Convert.ToString(dsQues.Tables[0].Rows[i]["OptionP"]);
                    int a = Convert.ToInt16(dsQues.Tables[0].Rows[i]["PType"]);
                    PType = Convert.ToInt32(a);
                    OptionQ = Convert.ToString(dsQues.Tables[0].Rows[i]["OptionQ"]);
                    QType1 = Convert.ToInt32(dsQues.Tables[0].Rows[i]["QType1"]);
                    OptionR = Convert.ToString(dsQues.Tables[0].Rows[i]["OptionR"]);
                    RType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["RType"]);
                    OptionS = Convert.ToString(dsQues.Tables[0].Rows[i]["OptionS"]);
                    SType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["SType"]);
                    OptionT = Convert.ToString(dsQues.Tables[0].Rows[i]["OptionT"]);
                    TType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["TType"]);

                    //Newly Added by jitendra 14.09.2015
                    OptionF = Convert.ToString(dsQues.Tables[0].Rows[i]["OptionF"]);
                    FType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["FType"]);
                    OptionG = Convert.ToString(dsQues.Tables[0].Rows[i]["OptionG"]);
                    GType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["GType"]);
                    OptionH = Convert.ToString(dsQues.Tables[0].Rows[i]["OptionH"]);
                    H1Type = Convert.ToInt32(dsQues.Tables[0].Rows[i]["H1Type"]);
                    OptionU = Convert.ToString(dsQues.Tables[0].Rows[i]["OptionU"]);
                    UType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["UType"]);
                    OptionV = Convert.ToString(dsQues.Tables[0].Rows[i]["OptionV"]);
                    VType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["VType"]);
                    OptionW = Convert.ToString(dsQues.Tables[0].Rows[i]["OptionW"]);
                    WType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["WType"]);

                }

                if (TypeOfQues == 82 || TypeOfQues == 86) //   passage  86- Reasoning 
                {
                    Passage = Convert.ToString(dsQues.Tables[0].Rows[i]["Passage"]);
                    passageType = Convert.ToInt32(dsQues.Tables[0].Rows[i]["passageType"]);
                }

                CryptorEngine crypto = new CryptorEngine();

                changesDate = Convert.ToString(dsQues.Tables[0].Rows[i]["changesDate"]);

                try
                {


                    Question = CryptorEngine.Decrypt(Question, true);
                    if (Hint != "")
                        Hint = CryptorEngine.Decrypt(Hint, true);

                    if (OptionA != "")
                        OptionA = CryptorEngine.Decrypt(OptionA, true);
                    if (OptionB != "")
                        OptionB = CryptorEngine.Decrypt(OptionB, true);
                    if (OptionC != "")
                        OptionC = CryptorEngine.Decrypt(OptionC, true);
                    if (OptionD != "")
                        OptionD = CryptorEngine.Decrypt(OptionD, true);
                    if (OptionE != "")
                        OptionE = CryptorEngine.Decrypt(OptionE, true);
                    if (OptionP != "")
                        OptionP = CryptorEngine.Decrypt(OptionP, true);
                    if (OptionQ != "")
                        OptionQ = CryptorEngine.Decrypt(OptionQ, true);
                    if (OptionR != "")
                        OptionR = CryptorEngine.Decrypt(OptionR, true);
                    if (OptionS != "")
                        OptionS = CryptorEngine.Decrypt(OptionS, true);
                    if (OptionT != "")
                        OptionT = CryptorEngine.Decrypt(OptionT, true);

                    if (OptionF != "")
                        OptionF = CryptorEngine.Decrypt(OptionF, true);
                    if (OptionG != "")
                        OptionG = CryptorEngine.Decrypt(OptionG, true);
                    if (OptionH != "")
                        OptionH = CryptorEngine.Decrypt(OptionH, true);
                    if (OptionU != "")
                        OptionU = CryptorEngine.Decrypt(OptionU, true);
                    if (OptionV != "")
                        OptionV = CryptorEngine.Decrypt(OptionV, true);
                    if (OptionW != "")
                        OptionW = CryptorEngine.Decrypt(OptionW, true);


                    if (Question != "")
                    {
                        Addexcel(QuesNo, Question, QType, OptionA, AType, OptionB, BType, OptionC, CType, OptionD, DType, OptionE, EType, Hint, hType, Answer, MobileNo, SettingId, Level1, QuestionWithImage, Q1Type, TypeOfQues, OptionP, PType, OptionQ, QType1, OptionR, RType, OptionS, SType, OptionT, TType, Passage, passageType, changesDate, UniqueId1, OptionF, FType, OptionG, GType, OptionH, H1Type, OptionU, UType, OptionV, VType, OptionW, WType);//, Medium, QuestionID);
                        clear();
                    }
                    else
                    {
                        Response.Write("<Script>alert('File Save Successfully !!!!!!! ')</Script>");
                        clear();
                    }

                }
                catch (Exception ex)
                {
                    QuesError++;
                    lblQuesError.Text = " Error in " + QuesError + " Question";
                    lblQuesError.Visible = true;


                    QuesErrorID = QuesErrorID + "," + QuesNo;
                    lblErrorQuesID.Text = "Error QuesID are :" + QuesErrorID;
                    lblErrorQuesID.Visible = true;
                }

            }

        }

    }



    protected void rdoTypeofMaterial_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoTypeofMaterial.SelectedItem.Text == "Class")
        {

            RequiredFieldValidator8.Enabled = true;
            RequiredFieldValidator11.Enabled = false;
        }
        else
        {

            RequiredFieldValidator8.Enabled = false;
            RequiredFieldValidator11.Enabled = true;
        }
    }

    public void clear()
    {
        QuesNo = 0;
        Question = "";
        QType = 0;
        OptionA = ""; AType = 0; OptionB = ""; BType = 0; OptionC = ""; CType = 0; OptionD = ""; DType = 0; OptionE = ""; EType = 0; Hint = "";
        hType = 0; Answer = ""; MobileNo = ""; SettingId = 0; Level1 = 0; QuestionWithImage = ""; Q1Type = 0; TypeOfQues = 0; OptionP = "";
        PType = 0; OptionQ = ""; QType1 = 0; OptionR = ""; RType = 0; OptionS = ""; SType = 0; OptionT = ""; TType = 0; Passage = ""; passageType = 0;
        changesDate = "";
        OptionF = ""; OptionG = ""; OptionH = ""; OptionU = ""; OptionV = ""; OptionW = "";
        FType = 0; GType = 0; H1Type = 0; UType = 0; VType = 0; WType = 0;
    }


    protected void btnBackQues_Click(object sender, EventArgs e)
    {
        Response.Redirect("~//Admin/Home.aspx");
    }

    public void loadRecord()
    {
        Sql = Sql + "select Name as Chapter,ItemValueId as csid from tblItemValue where ItemId=0 or ItemId=3";
        Sql = Sql + " Select Name as Topic, ItemValueId as tid from tblItemValue where ItemId=0 or ItemId=4";
        Sql = Sql + "Select Name as BookPublication, ItemValueId as PublicationId from tblItemValue where ItemId=0 or ItemId=7";

        DataSet ds = cc.ExecuteDataset(Sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlChapter.DataSource = ds.Tables[0];
            ddlChapter.DataTextField = "Chapter";
            ddlChapter.DataValueField = "csid";
            ddlChapter.DataBind();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            ddlTopic.DataSource = ds.Tables[1];
            ddlTopic.DataTextField = "Topic";
            ddlTopic.DataValueField = "tid";
            ddlTopic.DataBind();
        }
        if (ds.Tables[2].Rows.Count > 0)
        {
            ddlpublication.DataSource = ds.Tables[2];
            ddlpublication.DataTextField = "BookPublication";
            ddlpublication.DataValueField = "PublicationId";
            ddlpublication.DataBind();
        }

    }

    public void Dateformat()
    {
        DateTime dt = DateTime.Now;
        DateTime SystemDate = Convert.ToDateTime(dt);
        EntryDate = SystemDate.ToString("yyyy'-'MM'-'dd''");
    }

    protected void txtMobileNo1_TextChanged(object sender, EventArgs e)
    {

    }

    #region Loaddata To Dropdownlist of UpdatechapterPanel

    public void LoadRecordUpdateChapter()
    {
        Sql = "select Name as exam ,ItemValueId as eid from tblItemValue11 where  ItemId=0 or ItemId=6";
        Sql = Sql + " Select Name as Question, ItemValueId as QID from tblItemValue11 where ItemId=0 or ItemId=5";
        Sql = Sql + "select Name as class ,ItemValueId  as cid from tblItemValue11 where ItemId=0 or ItemId=1";
        Sql = Sql + "select Name as suject,ItemValueId as sid from tblItemValue11 where ItemId =0 or ItemId=2";
        Sql = Sql + "select Name as Chapter,ItemValueId as csid from tblItemValue11 where ItemId=0 or ItemId=3";
        Sql = Sql + " Select Name as Topic, ItemValueId as tid from tblItemValue11 where ItemId=0 or ItemId=4";


        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlTypeofExam1.DataSource = ds.Tables[0];
            ddlTypeofExam1.DataTextField = "exam";
            ddlTypeofExam1.DataValueField = "eid";
            ddlTypeofExam1.DataBind();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            ddlTypeofQues1.DataSource = ds.Tables[1];
            ddlTypeofQues1.DataTextField = "Question";
            ddlTypeofQues1.DataValueField = "QID";
            ddlTypeofQues1.DataBind();
        }

        if (ds.Tables[2].Rows.Count > 0)
        {
            ddlClassId1.DataSource = ds.Tables[2];
            ddlClassId1.DataTextField = "class";
            ddlClassId1.DataValueField = "cid";
            ddlClassId1.DataBind();
        }


        if (ds.Tables[3].Rows.Count > 0)
        {
            ddlSubjectId1.DataSource = ds.Tables[3];
            ddlSubjectId1.DataTextField = "suject";
            ddlSubjectId1.DataValueField = "sid";
            ddlSubjectId1.DataBind();
        }
        if (ds.Tables[4].Rows.Count > 0)
        {
            ddlChapterId1.DataSource = ds.Tables[4];
            ddlChapterId1.DataTextField = "Chapter";
            ddlChapterId1.DataValueField = "csid";
            ddlChapterId1.DataBind();
        }
        if (ds.Tables[5].Rows.Count > 0)
        {
            ddlTopicId1.DataSource = ds.Tables[5];
            ddlTopicId1.DataTextField = "Topic";
            ddlTopicId1.DataValueField = "tid";
            ddlTopicId1.DataBind();
        }

    }

    #endregion

    protected void btnUpdateChapter_Click(object sender, EventArgs e)
    {
        Sql = " Update tblQuestionAccess Set userChapterName='" + txtChapterName.Text + "' " +
              " Where TypeOFExam='" + ddlTypeofExam1.SelectedValue + "' and TypeofQues='" + ddlTypeofQues1.SelectedValue + "' and Class_id='" + ddlClassId1.SelectedValue + "' and Subject_id='" + ddlSubjectId1.SelectedValue + "' " +
              " and Chapter_id='" + ddlChapterId1.SelectedValue + "' and Topic_id='" + ddlTopicId1.SelectedValue + "'  and MediumID='" + ddlMediumId1.SelectedItem.Text + "' " +
              " and TypeofMaterial='" + rdblistTypeofMaterial.SelectedItem.Text + "' and TypeofDB='" + ddlTypeofDB1.SelectedItem.Text + "'";
        // TypeofDB='Access' and DOUpload='" + txtDOUpload1.Text + "'
        int flag = cc.ExecuteNonQuery(Sql);

        if (flag == 0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "msg", "alert('Chapter Updation Failed!!!')", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "msg", "alert('Chapter Updated Successfully!!!')", true);
        }
    }


    #region ddlgroupofExam

    protected void BindDropDown212()
    {
        Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=212 ";
        DataSet ds = cc.ExecuteDataset(Sql);

        ddlTypeofExam.DataSource = ds.Tables[0];
        ddlTypeofExam.DataTextField = "Name";
        ddlTypeofExam.DataValueField = "ItemValueIdNew";
        ddlTypeofExam.DataBind();
    }


    protected void ddlGroupofExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGroupofExam.SelectedValue == Convert.ToString(135))
        {
            BindDropDown212();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(136))
        {
            BindDropDown212();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(137))
        {
            BindDropDown212();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(140))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=210  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(141))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=207  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(142))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=206  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(143))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=203  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(144))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=205  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(177))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=1796  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(178))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=1806  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
    }
    #endregion

    #region ddlTypeofExam

    protected void BindDropDown2()
    {
        Sql = Sql + "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=2 ";
        DataSet ds = cc.ExecuteDataset(Sql);

        cmbSelectsubject.DataSource = ds.Tables[0];
        cmbSelectsubject.DataTextField = "Name";
        cmbSelectsubject.DataValueField = "ItemValueId";
        cmbSelectsubject.DataBind();
        ddlAddClass.SelectedValue = "1";
        ddlAddClass.Enabled = false;
    }
    protected void BindDropDown211()
    {
        ddlAddClass.Enabled = true;
        Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=211 ";
        DataSet ds = cc.ExecuteDataset(Sql);

        ddlAddClass.DataSource = ds.Tables[0];
        ddlAddClass.DataTextField = "Name";
        ddlAddClass.DataValueField = "ItemValueIdNew";
        ddlAddClass.DataBind();
    }
    protected void BindDropDown202()
    {
        ddlAddClass.Enabled = true;
        Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=202 ";
        DataSet ds = cc.ExecuteDataset(Sql);

        ddlAddClass.DataSource = ds.Tables[0];
        ddlAddClass.DataTextField = "Name";
        ddlAddClass.DataValueField = "ItemValueIdNew";
        ddlAddClass.DataBind();
    }

    protected void ddlTypeofExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTypeofExam.SelectedValue == Convert.ToString(88))
        {
            ddlAddClass.Enabled = true;
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=201 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlAddClass.DataSource = ds.Tables[0];
            ddlAddClass.DataTextField = "Name";
            ddlAddClass.DataValueField = "ItemValueIdNew";
            ddlAddClass.DataBind();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(98))
        {
            BindDropDown202();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(99))
        {
            BindDropDown202();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(100))
        {
            BindDropDown202();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(96))
        {
            BindDropDown211();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(101))
        {
            BindDropDown211();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(102))
        {
            BindDropDown211();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(89))
        {
            BindDropDown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(94))
        {
            BindDropDown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(95))
        {
            BindDropDown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(130))
        {
            BindDropDown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(110))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=204 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            cmbSelectsubject.DataSource = ds.Tables[0];
            cmbSelectsubject.DataTextField = "Name";
            cmbSelectsubject.DataValueField = "ItemValueIdNew";
            cmbSelectsubject.DataBind();
            ddlAddClass.SelectedValue = "1";
            ddlAddClass.Enabled = false;
        }

        else if (ddlTypeofExam.SelectedValue == Convert.ToString(103))
        {
            BindDropDown2();
            //ddlAddClass.Enabled = true;
            //Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=20103 ";
            //DataSet ds = cc.ExecuteDataset(Sql);

            //ddlAddClass.DataSource = ds.Tables[0];
            //ddlAddClass.DataTextField = "Name";
            //ddlAddClass.DataValueField = "ItemValueIdNew";
            //ddlAddClass.DataBind();

        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(165))
        {
            BindDropDown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(179))
        {
            BindDropDown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(180))
        {
            BindDropDown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(176))
        {
            BindDropDown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(191))
        {
            BindDropDown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(193))
        {
            BindDropDown2();
        }
    }
    #endregion

    #region ddlAddclass
    protected void ddlAddClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int count = 0; count < 15; count++)
        {
            if (ddlAddClass.SelectedValue == Convert.ToString(count))
            {
                Sql = Sql + "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=2 ";
                DataSet ds = cc.ExecuteDataset(Sql);

                cmbSelectsubject.DataSource = ds.Tables[0];
                cmbSelectsubject.DataTextField = "Name";
                cmbSelectsubject.DataValueField = "ItemValueId";
                cmbSelectsubject.DataBind();
            }
        }
        if ((ddlAddClass.SelectedValue == Convert.ToString(15) || ddlAddClass.SelectedValue == Convert.ToString(16)) && ddlTypeofExam.SelectedValue == Convert.ToString(99))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemId=0 or ItemIdNew=209 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            cmbSelectsubject.DataSource = ds.Tables[0];
            cmbSelectsubject.DataTextField = "Name";
            cmbSelectsubject.DataValueField = "ItemValueIdNew";
            cmbSelectsubject.DataBind();
        }

        else if ((ddlAddClass.SelectedValue == Convert.ToString(15) || ddlAddClass.SelectedValue == Convert.ToString(16)) && (ddlTypeofExam.SelectedValue == Convert.ToString(98) || ddlTypeofExam.SelectedValue == Convert.ToString(100)))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=208 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            cmbSelectsubject.DataSource = ds.Tables[0];
            cmbSelectsubject.DataTextField = "Name";
            cmbSelectsubject.DataValueField = "ItemValueIdNew";
            cmbSelectsubject.DataBind();
        }
        else if (ddlAddClass.SelectedValue == Convert.ToString(188))
        {
            Sql = Sql + "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=2 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            cmbSelectsubject.DataSource = ds.Tables[0];
            cmbSelectsubject.DataTextField = "Name";
            cmbSelectsubject.DataValueField = "ItemValueId";
            cmbSelectsubject.DataBind();
        }
        else if (ddlAddClass.SelectedValue == Convert.ToString(189))
        {
            Sql = Sql + "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=2 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            cmbSelectsubject.DataSource = ds.Tables[0];
            cmbSelectsubject.DataTextField = "Name";
            cmbSelectsubject.DataValueField = "ItemValueId";
            cmbSelectsubject.DataBind();
        }
    }
    #endregion

    protected void cmbSelectsubject_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

}







