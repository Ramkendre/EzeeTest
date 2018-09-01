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
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

public partial class Andorid_Class_App_UploadStudentRegExcel : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    RegisterToMyct reg = new RegisterToMyct();

    string loginNumber = string.Empty;
    string SNO1 = string.Empty;
    string CSID = string.Empty;
    string Adm_No = string.Empty;
    string adm_date = string.Empty;
    string Stud_MobNo = string.Empty;
    string Parent_MobNo = string.Empty;
    string StudAddress = string.Empty;
    string WardNo = string.Empty;
    string First_Name = string.Empty;
    string Last_Name = string.Empty;
    string Father_Name = string.Empty;
    string InstituteHeadMob = string.Empty;
    string FacultyMobNo = string.Empty;
    int updateCount = 0, insertCount = 0, totalCount = 0;
    string inupcount = string.Empty;
    string returnString = string.Empty;
    string errorString = string.Empty;
    string pincode = "411038";
    string fileExtension = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillClass();
        }
    }

    public void FillClass()
    {
        string Sql = "SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId=0 or ItemId=1 ";
        DataSet dsC = cc.ExecuteDataset(Sql);

        if (dsC.Tables[0].Rows.Count > 0)
        {
            ddlClass.DataSource = dsC.Tables[0];
            ddlClass.DataValueField = "ItemValueId";
            ddlClass.DataTextField = "Name";
            ddlClass.DataBind();
        }
    }

    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Andorid_Class_App/StudentmdbFileUpload/StudentRegistration.xlsx");
    }

    protected void btnupload_Click(object sender, EventArgs e)
    {
        loginNumber = Convert.ToString(Session["LoginId"]);
        try
        {
            if (ddlClass.SelectedItem.Text == "--Select--" || ddlBatch.SelectedItem.Text == "--Select--" || ddlSession.SelectedItem.Text == "--Select--")
            {
                lblMessage.Text = "Please Select All Fields..!!!";
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Font.Bold = true;
                lblMessage.Font.Size = 12;
            }
            else
            {
                if (excelFileUpload.HasFile)
                {
                    string path = "";
                    path = Server.MapPath("Download");
                    path = path + "\\" + excelFileUpload.FileName;
                    string ab = excelFileUpload.FileName;

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                        excelFileUpload.SaveAs(path);
                    }
                    else
                    {
                        excelFileUpload.SaveAs(path);
                    }

                    string sqlQuery = "SELECT [Role] FROM [Login] WHERE [LoginId]='" + loginNumber + "' ";
                    string role = cc.ExecuteScalar(sqlQuery);

                    if (role == "3")
                    {
                        string strQuery = "SELECT * FROM [CLASSAPP$]";
                        DataSet dscount = GetDataTable(strQuery);

                        if (dscount != null || dscount.Tables[0].Rows.Count > 0)
                        {
                            inupcount = FetchData(dscount);
                        }
                        else
                        {
                            inupcount = "PLEASE GIVE NAME OF SHEET AS CLASSAPP";
                        }

                        lblStatus.Visible = true;
                        lblStatus.Text = inupcount;
                        lblStatus.ForeColor = System.Drawing.Color.Maroon;
                        lblStatus.Font.Name = "Consolas";
                        lblStatus.Font.Bold = true;
                        lblStatus.Font.Size = 12;
                    }
                    else
                    {
                        lblMessage.Text = "PLEASE LOGIN WITH VALID INSTITUTE HEAD..!!!";
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Font.Bold = true;
                        lblMessage.Font.Size = 12;
                    }
                }
                else
                {
                    lblMessage.Text = "Please Select Excel File To Upload..!!!";
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Font.Bold = true;
                    lblMessage.Font.Size = 12;
                }
            }
        }
        catch
        {

        }
    }

    public string FetchData(DataSet excelDs)
    {
        int countValue = excelDs.Tables[0].Rows.Count;

        for (int k = 0; k < countValue; k++)
        {
            Adm_No = excelDs.Tables[0].Rows[k]["AdmNo"].ToString();
            if (Adm_No != "")
                Adm_No.Trim();
            // adm_date = excelDs.Tables[0].Rows[k]["AdmDate"].ToString();

            adm_date = System.DateTime.Now.ToString("yyyy-MM-dd");

            //if (adm_date != "")
            //{
            //    if (adm_date.Length >= 22)
            //    {
            //        adm_date = adm_date.Substring(0, 11);
            //        adm_date = adm_date.Trim();
            //    }
            //}
            //else
            //{
            //    adm_date = "2015-12-25";
            //}

            First_Name = excelDs.Tables[0].Rows[k]["FirstName"].ToString();
            if (First_Name != "")
                First_Name.Trim();

            Father_Name = excelDs.Tables[0].Rows[k]["FatherName"].ToString();
            if (Father_Name != "")
                Father_Name.Trim();
            else
                Father_Name = "NA";

            Last_Name = excelDs.Tables[0].Rows[k]["LastName"].ToString();
            if (Last_Name != "")
                Last_Name.Trim();

            StudAddress = excelDs.Tables[0].Rows[k]["StudAddress"].ToString();
            if (StudAddress != "")
                StudAddress.Trim();
            else
                StudAddress = "Pune";

            Parent_MobNo = excelDs.Tables[0].Rows[k]["ParentMobNo"].ToString();
            if (Parent_MobNo != "")
                Parent_MobNo.Trim();
            else
                Parent_MobNo = "0";

            //Stud_MobNo = excelDs.Tables[0].Rows[k]["StudMobNo"].ToString();
            //if (Stud_MobNo != "")
            //    Stud_MobNo.Trim();
            //else
            Stud_MobNo = Parent_MobNo;

            //WardNo = excelDs.Tables[0].Rows[k][5].ToString();
            //if (WardNo != "")
            //    WardNo.Trim();
            //else
            //    WardNo = "0";
            WardNo = "17";

            //InstituteHeadMob = excelDs.Tables[0].Rows[k][9].ToString();
            //if (InstituteHeadMob != "")
            //    InstituteHeadMob.Trim();

            //FacultyMobNo = excelDs.Tables[0].Rows[k]["FacultyMobNo"].ToString();
            //if (FacultyMobNo != "")
            //    FacultyMobNo.Trim();
            //else
            FacultyMobNo = loginNumber;

            if (Adm_No == "" || First_Name == "" || Last_Name == "" || Parent_MobNo == "")
            {
                returnString = "PLEASE INSERT AT LEAST REQUIRED VALUES..!!!";
            }
            else
            {
                string strQuery = "SELECT [ClassSetting_id] FROM [tblClassSetting] WHERE [Class_Id]='" + ddlClass.SelectedValue + "' AND [Session]='" + ddlSession.Text + "' AND [Batch]='" + ddlBatch.Text + "' AND [Login_Id]='" + loginNumber + "'";
                CSID = cc.ExecuteScalar(strQuery);

                if (CSID != "" && CSID.ToString() != null)
                {
                    //and [ClassSetting_id]='" + CSID + "'

                    string str3 = "SELECT [SNO] FROM [tblStudentRegister] WHERE [Adm_No]=" + Adm_No + " AND [LoginId]='" + loginNumber + "'";
                    SNO1 = cc.ExecuteScalar(str3);

                    if (SNO1 != "" && SNO1 != null)
                    {
                        string sqlQuery1 = "UPDATE [tblStudentRegister] SET [adm_date]='" + adm_date + "',[ClassSetting_id]='" + CSID + "' ,[First_Name]='" + First_Name + "', [Last_Name]='" + Last_Name + "',[Father_Name]='" + Father_Name + "',[Parent_MobNo]='" + Parent_MobNo + "',[LoginId]='" + loginNumber + "' ,InstituteHeadMob='" + loginNumber + "',FacultyMobNo='" + FacultyMobNo + "',[Stud_MobNo]='" + Stud_MobNo + "' WHERE SNO='" + SNO1 + "' ";
                        cc.ExecuteNonQuery(sqlQuery1);
                        //updateCount++;

                        if (Parent_MobNo != null && Parent_MobNo != "" && Parent_MobNo != "0")
                        {
                            string sqlCompId = "SELECT [CompanyId] FROM [Login] WHERE [LoginId] = '" + loginNumber + "' ";
                            string companyId = cc.ExecuteScalar(sqlCompId);

                            if (companyId != null && companyId != "")
                            {
                                string alredyLogin = "SELECT [CompanyId] FROM [Login] WHERE [LoginId]='" + Parent_MobNo + "'";
                                string compId = cc.ExecuteScalar(alredyLogin);

                                if (compId != null && compId != "")
                                {
                                    if (companyId == compId)
                                    {
                                        string sqlLoginUpdate = " UPDATE [Login] SET [UserName]='" + First_Name + " " + Father_Name + " " + Last_Name + "',[Address]='" + StudAddress + "',[DOJ]='" + DateTime.Today.ToString("yyyy-MM-dd") + "',[Role]='10',[CompanyId]='" + companyId + "',[DataFromApp]='2' " +
                                                                " WHERE  [LoginId]='" + Parent_MobNo + "'";
                                        cc.ExecuteNonQuery(sqlLoginUpdate);
                                    }
                                    else
                                    {
                                        string sqlSelectMulCla = "SELECT [SLoginId] FROM [tblMulClassAdmin] WHERE [SLoginId]='" + Parent_MobNo + "' and [CLALoginId]='" + loginNumber + "'";
                                        string log = cc.ExecuteScalar(sqlSelectMulCla);
                                        if (log != "")
                                        {
                                        }
                                        else
                                        {
                                            string sqlInsertMulCla = " INSERT INTO [tblMulClassAdmin] ([SLoginId],[CLALoginId],[RoleId],[CompanyId],[EntryDate],[Active/Deactive]) " +
                                                                     " VALUES ('" + Parent_MobNo + "','" + loginNumber + "','10','" + companyId + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','1')";
                                            cc.ExecuteNonQuery(sqlInsertMulCla);
                                        }
                                    }
                                }
                                else
                                {
                                    string regid = reg.Addnew(First_Name + " " + Father_Name, Last_Name, Stud_MobNo, StudAddress, pincode, "1");

                                    string sqlLogin = " INSERT INTO [Login] ([LoginId],[UserName],[Password],[ContactNo],[Address],[DOJ],[Role],[CompanyId],[admintype],[Active],[UserType],[Category],[DataFromApp]) " +
                                                      " VALUES ('" + Parent_MobNo + "','" + First_Name + " " + Father_Name + " " + Last_Name + "','" + regid + "','" + Parent_MobNo + "','" + StudAddress + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','10','" + companyId + "','0','1','1','--Select--','2')";
                                    cc.ExecuteNonQuery(sqlLogin);

                                    string sql = "SELECT MAX(Uid) AS LastID FROM Login";
                                    string Id1 = cc.ExecuteScalar(sql);

                                    string sqlLogid = "SELECT [uid] FROM Login WHERE [LoginId]='" + loginNumber + "'";
                                    string logid = cc.ExecuteScalar(sqlLogid);

                                    string sqlAdminSubUser = " INSERT INTO [Admin_SubUser] ([loginid],[loginname],[uid],[UnderUsername],[roleid],[rolename],[DT],[R1],[R2],[R3],[R4],[R5],[R6],[companyid]) " +
                                                             " VALUES ('" + logid + "','" + loginNumber + "','" + Id1 + "','" + Parent_MobNo + "','10','Student','" + DateTime.Today.ToString("yyyy-MM-dd") + "','Admin','" + loginNumber + "','" + Parent_MobNo + "','0','0','0','" + companyId + "')";
                                    cc.ExecuteNonQuery(sqlAdminSubUser);
                                }
                            }
                        }
                        updateCount++;
                    }
                    else
                    {
                        string sqlQuery2 = " INSERT INTO [tblStudentRegister] ([Adm_No],[adm_date],[Stud_MobNo],[Parent_MobNo],[StudAddress],[WardNo],[First_Name],[Last_Name],[Father_Name],[InstituteHeadMob],[LoginId],[ClassSetting_id],[FacultyMobNo],[DOB],[Area],[CityId],[Gender],[Pincode],[AndroidClassSettingID],[AndroidStudentSNO])" +
                                           " VALUES (" + Adm_No + ",N'" + adm_date + "',N'" + Stud_MobNo + "',N'" + Parent_MobNo + "',N'" + StudAddress + "',N'" + WardNo + "',N'" + First_Name + "',N'" + Last_Name + "',N'" + Father_Name + "','" + loginNumber + "','" + loginNumber + "','" + CSID + "','" + FacultyMobNo + "','1995-10-26','0','0','0','411038','0','0')"; //InstituteHeadMob  
                        cc.ExecuteNonQuery(sqlQuery2);
                        //insertCount++;

                        if (Parent_MobNo != null && Parent_MobNo != "" && Parent_MobNo != "0")
                        {
                            string sqlCompId = "SELECT [CompanyId] FROM [Login] WHERE [LoginId] = '" + loginNumber + "' ";
                            string companyId = cc.ExecuteScalar(sqlCompId);

                            if (companyId != null && companyId != "")
                            {
                                string alredyLogin = "SELECT [CompanyId] FROM [Login] WHERE [LoginId]='" + Parent_MobNo + "'";
                                string compId = cc.ExecuteScalar(alredyLogin);

                                if (compId != null && compId != "")
                                {
                                    if (companyId == compId)
                                    {
                                        string sqlLoginUpdate = " UPDATE [Login] SET [UserName]='" + First_Name + " " + Father_Name + " " + Last_Name + "',[Address]='" + StudAddress + "',[DOJ]='" + DateTime.Today.ToString("yyyy-MM-dd") + "',[Role]='10',[CompanyId]='" + companyId + "',[DataFromApp]='2' " +
                                                                " WHERE  [LoginId]='" + Parent_MobNo + "'";
                                        cc.ExecuteNonQuery(sqlLoginUpdate);
                                    }
                                    else
                                    {
                                        string sqlSelectMulCla = "SELECT [SLoginId] FROM [tblMulClassAdmin] WHERE [SLoginId]='" + Parent_MobNo + "' and [CLALoginId]='" + loginNumber + "'";
                                        string log = cc.ExecuteScalar(sqlSelectMulCla);
                                        if (log != "")
                                        {
                                        }
                                        else
                                        {
                                            string sqlInsertMulCla = " INSERT INTO [tblMulClassAdmin] ([SLoginId],[CLALoginId],[RoleId],[CompanyId],[EntryDate],[Active/Deactive]) " +
                                                                     " VALUES ('" + Parent_MobNo + "','" + loginNumber + "','10','" + companyId + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','1')";
                                            cc.ExecuteNonQuery(sqlInsertMulCla);
                                        }
                                    }
                                }
                                else
                                {
                                    string regid = reg.Addnew(First_Name + " " + Father_Name, Last_Name, Stud_MobNo, StudAddress, pincode, "1"); //Registered to myct

                                    string sqlLogin = " INSERT INTO [Login] ([LoginId],[UserName],[Password],[ContactNo],[Address],[DOJ],[Role],[CompanyId],[admintype],[Active],[UserType],[Category],[DataFromApp]) " +
                                                      " VALUES ('" + Parent_MobNo + "','" + First_Name + " " + Father_Name + " " + Last_Name + "','" + regid + "','" + Parent_MobNo + "','" + StudAddress + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','10','" + companyId + "','0','1','1','--Select--','2')";
                                    cc.ExecuteNonQuery(sqlLogin);

                                    string sql = "SELECT MAX(Uid) AS LastID FROM Login";
                                    string Id1 = cc.ExecuteScalar(sql);

                                    string sqlLogid = "SELECT [uid] FROM Login WHERE [LoginId]='" + loginNumber + "'";
                                    string logid = cc.ExecuteScalar(sqlLogid);

                                    string sqlAdminSubUser = " INSERT INTO [Admin_SubUser] ([loginid],[loginname],[uid],[UnderUsername],[roleid],[rolename],[DT],[R1],[R2],[R3],[R4],[R5],[R6],[companyid]) " +
                                                             " VALUES ('" + logid + "','" + loginNumber + "','" + Id1 + "','" + Parent_MobNo + "','10','Student','" + DateTime.Today.ToString("yyyy-MM-dd") + "','Admin','" + loginNumber + "','" + Parent_MobNo + "','0','0','0','" + companyId + "')";
                                    cc.ExecuteNonQuery(sqlAdminSubUser);
                                }

                            }

                        }
                        insertCount++;
                    }
                }
                else
                {
                    errorString = "CLASSSETTING IS NOT DEFINE FOR THE FACULTY '" + FacultyMobNo + "'";
                    break;
                }
            }
        }
        totalCount = insertCount + updateCount;
        returnString = "NUMBER OF RECORDS UPLOADED : " + totalCount + " INSERTED : " + insertCount + " AND UPDATED : " + updateCount;

        if (errorString != "")
            return errorString;
        else
            return returnString;
    }


    //function To Fetch the data from MS EXCEL FILE In any format extension
    public DataSet GetDataTable(string strQuery)
    {
        DataSet tempDs = null;
        OleDbConnection conn = null;
        string conPath = string.Empty;

        string filePath = Server.MapPath("Download\\" + excelFileUpload.FileName);

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
        catch
        {

        }
        finally
        {
            conn.Close();
        }

        return tempDs;
    }
}
