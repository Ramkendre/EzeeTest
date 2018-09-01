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

public partial class Admin_UserLoginUpload : System.Web.UI.Page
{
    Microsoft.Office.Interop.Excel.Application xlApp = null;
    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
    Microsoft.Office.Interop.Excel.Range range;
    Object ConfirmConversions = false;
    Object isVisible = true;
    object misValue = System.Reflection.Missing.Value;
    Regex regex1 = new Regex(@"ADDR:");



    string Sql;
    public static string EntryDate = "";
    CommonCode cc = new CommonCode();

    //for excel connection
    string pathOnly = string.Empty;
    string fileName = string.Empty;
    string fileExtension = string.Empty;
    string conPath = "";
    OleDbConnection conn = null;
    DataSet ds = null;

    RegisterToMyct reg = new RegisterToMyct();
    string UserName = "", UserID = "", R1 = "", R2 = "", R3 = "", R4 = "", R5 = "", R6 = "", initial = "", usrRole = "", RoleId = "", userid;
    string roleId = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }



    public DataSet GetDataTable(string strQuery)
    {
        DataSet tempDs = null;
        string filePath = Server.MapPath("LoginDATA_Upload\\" + FileUpload1.FileName);
        fileExtension = Path.GetExtension(filePath);

        //if (this.fileExtension == ".xls")
        //{
        //    conPath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
        //}
        //else
        //{
        //    conPath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
        //}

        if (this.fileExtension == ".xls")
        {
            conPath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
        }
        else
        {
            conPath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
        }

        //if (this.fileExtension == ".xls")
        //{
        //    conPath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"";
        //}
        //else
        //{
        //    conPath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"";
        //}
        conn = new OleDbConnection(conPath);
        try
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(strQuery, conn);
            tempDs = new DataSet();
            adapter.Fill(tempDs);
        }
        catch (Exception ex)
        {

        }

        return tempDs;
    }



    string LoginIdExcel = "", StudentName = "", PINCode = "", Address = "";
    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        string path = "";
        int sheetNo = Convert.ToInt32(1);

        if (FileUpload1.HasFile)
        {

            path = Server.MapPath("LoginDATA_Upload");
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
        }

        Sql = "select * from [Sheet1$]";
        DataSet dscount = GetDataTable(Sql);

        if (dscount.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dscount.Tables[0].Rows.Count; i++)
            {
                LoginIdExcel = Convert.ToString(dscount.Tables[0].Rows[i]["Mobile No"]);
                StudentName = Convert.ToString(dscount.Tables[0].Rows[i]["Name(LN FN MN)"]);
                PINCode = Convert.ToString(dscount.Tables[0].Rows[i]["PIN Code"]);
                Address = Convert.ToString(dscount.Tables[0].Rows[i]["Address"]);
                if (LoginIdExcel != "")
                {
                    Addexcel(LoginIdExcel, StudentName, PINCode, Address);
                }
            }
        }
    }

    int count1 = 0, count2 = 0;
    string FName, LName;
    string AlredyLogins = string.Empty;

    public void Addexcel(string LoginIdExcel, string StudentName, string PINCode, string Address)
    {
        try
        {
            Sql = "select LoginId from Login where LoginId='" + LoginIdExcel + "' ";
            string ab = Convert.ToString(cc.ExecuteScalar(Sql));

            if (ab != "")
            {
                AlredyLogins = AlredyLogins + "," + ab;
                count1++;
                btnRegister.Visible = true;
                lblAlready.Visible = true;
            }
            else
            {
                try
                {
                    string[] SeparateName = StudentName.Split(' ');
                    if (SeparateName.Length > 2)
                    {
                        FName = SeparateName[1];
                        LName = SeparateName[2] + " " + SeparateName[0];
                    }
                    else
                    {
                        FName = SeparateName[1];
                        LName = SeparateName[0];
                    }
                }
                catch
                {
                }

                int companyID = Convert.ToInt32(Session["CompanyId"]);

                string regid = reg.Addnew(FName, LName, LoginIdExcel, Address, PINCode, "0");
                if (regid != "" || regid == null)
                {
                    if (Session["Role"].ToString() == "22")
                    {
                        roleId = "23";
                    }
                    else
                    {
                        roleId = "10";
                    }
                    Sql = "Insert into Login(LoginId, UserName, Password, " +
                        " ContactNo,Address, DOJ, Role, CompanyId,Active,admintype ,UserType) Values " +
                        " (N'" + LoginIdExcel + "',N'" + StudentName + "',N'" + regid + "', " +
                        " N'" + LoginIdExcel + "', N'" + Address + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + roleId.ToString() + "', " + companyID + ",1,'1','1') ";


                    int flag = cc.ExecuteNonQuery(Sql);
                    count2++;
                    if (flag == 1)
                    {
                        string sql = "SELECT MAX(Uid) AS LastID FROM Login";
                        string Id1 = cc.ExecuteScalar(sql);
                        Session["insertID"] = Id1;
                        if (!(Id1 == null))
                        {
                            load(Id1);
                        }

                    }
                    else
                    {

                    }

                }

            }

            ExistLoginId.Text = AlredyLogins.ToString();
            lblcount.Text = "Total No. of Student is Already Exist : " + count1;
            lblcount2.Text = "Total No. of Student Submitted is : " + count2;
            lblcount.Visible = true;
            lblcount2.Visible = true;
        }
        catch (Exception ex)
        {
        }
    }


    public void load(string UID)
    {
        if ((Convert.ToString(Session["LoginId"]) == "ADMIN"))
        {
            Adduser(UID);
        }
        else
        {

            AddNewUser(UID);
        }
    }
    public void Adduser(string UID)
    {
        try
        {

            string sql = "select id from Admin_SubUser where uid='" + Convert.ToString(Session["insertID"]) + "'";
            string id1 = cc.ExecuteScalar(sql);
            if (!(id1 == null || id1 == ""))
            {
                Response.Write("<script>(alert)('This User is already  of other, You cannot assign ')</script>");
            }

            else
            {
                if (Session["Role"].ToString() == "22")
                {
                    roleId = "23";
                }
                else
                {
                    roleId = "10";
                }
                string Sql = "insert Admin_SubUser(loginid,loginname,uid,UnderUsername,roleid,rolename,DT,R1,companyid)" +
                              "values('" + Convert.ToString(Session["LoginName"]) + "','" + Convert.ToString(Session["LoginId"]) + "'," + Convert.ToString(Session["insertID"]) + ",'" + LoginIdExcel + "','" + roleId.ToString() + "','Students','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + Convert.ToString(Session["LoginId"]) + "'," + Convert.ToInt32(Session["CompanyId"]) + ")";
                int flag = cc.ExecuteNonQuery(Sql);


            }


        }
        catch (Exception ex)
        {


        }
    }
    private void AddNewUser(string UID)
    {

        UserName = Convert.ToString(Session["Loginid"]);
        UserID = Convert.ToString(Session["LoginName"]);

        if ((Convert.ToString(Session["LoginId"]) != null && Convert.ToString(Session["parentrole"]) == ""))
        {
            string sql1 = "select id from login where Loginid='" + UserName + "'";
            UserName = cc.ExecuteScalar(sql1);
        }
        else
        {
            info12();
        }

        string R1 = initial;

        string Sub_UID = Convert.ToString(Session["Sub_UID"]);
        string sql12 = "select id from Admin_SubUser where UnderUsername='" + UserName + "'";
        string id = cc.ExecuteScalar(sql12);

        if (id == "")
        {
            if (Session["Role"].ToString() == "22")
            {
                roleId = "23";
            }
            else
            {
                roleId = "10";
            }

            string Sql = "insert Admin_SubUser(loginid,loginname,uid,UnderUsername,roleid,rolename,DT,R1,R2,R3,R4,R5,R6,companyid)" +
          "values('" + Convert.ToString(Session["LoginName"]) + "','" + Convert.ToString(Session["LoginId"]) + "'," + Convert.ToString(Session["insertID"]) + ",'" + LoginIdExcel + "','" + roleId.ToString() + "','Students','" + System.DateTime.Now + "','" + R1 + "','" + R2 + "','" + R3 + "','" + R4 + "','" + R5 + "','" + R6 + "'," + Convert.ToInt32(Session["CompanyId"]) + " )";
            int flag = cc.ExecuteNonQuery(Sql);
        }
        else
        {
            string id1 = "";


            string sql = "select id from Admin_SubUser where uid='" + Convert.ToString(Session["insertID"]) + "'";
            id1 = cc.ExecuteScalar(sql);
            if (!(id1 == null || id1 == ""))
            {
                Response.Write("<script>(alert)('This User is already  of other, You cannot assign ')</script>");
            }

            else
            {
                if (Session["Role"].ToString() == "22")
                {
                    roleId = "23";
                }
                else
                {
                    roleId = "10";
                }
                string Sql = "insert Admin_SubUser(loginid,loginname,uid,UnderUsername,roleid,rolename,DT,R1,R2,R3,R4,R5,R6,companyid)" +
                       "values('" + Convert.ToString(Session["LoginName"]) + "','" + Convert.ToString(Session["LoginId"]) + "'," + Convert.ToString(Session["insertID"]) + ",'" + LoginIdExcel + "','" + roleId.ToString() + "','Students','" + System.DateTime.Now + "','" + R1 + "','" + R2 + "','" + R3 + "','" + R4 + "','" + R5 + "','" + R6 + "'," + Convert.ToInt32(Session["CompanyId"]) + " )";
                int flag = cc.ExecuteNonQuery(Sql);
            }
        }
    }


    private void info12()
    {
        string sqlfetch = "select uid,loginid,loginname,UnderUsername,roleid,rolename,DT,R2,R3,R4,R5,R6,companyid  from Admin_SubUser where UnderUsername='" + UserName + "'";
        DataSet ds1 = cc.ExecuteDataset(sqlfetch);
        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        {
            usrRole = Convert.ToString(ds1.Tables[0].Rows[0]["rolename"]);
            userid = Convert.ToString(ds1.Tables[0].Rows[0]["UnderUsername"]);
            RoleId = Convert.ToString(ds1.Tables[0].Rows[0]["roleid"]);
            R2 = Convert.ToString(ds1.Tables[0].Rows[0]["R2"]);
            if (R2 == "")
            {
                R2 = userid;
                break;
            }

            R3 = Convert.ToString(ds1.Tables[0].Rows[0]["R3"]);
            if (R3 == "")
            {
                R3 = userid;
                break;
            }

            R4 = Convert.ToString(ds1.Tables[0].Rows[0]["R4"]);
            if (R4 == "")
            {
                R4 = userid;
                break;
            }
            R5 = Convert.ToString(ds1.Tables[0].Rows[0]["R5"]);
            if (R5 == "")
            {
                R5 = userid;
                break;
            }
            R6 = Convert.ToString(ds1.Tables[0].Rows[0]["R6"]);
            if (R6 == "")
            {
                R6 = userid;
                break;
            }


        }


        initial = "Admin";
    }
    protected void btnDowmLoad_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Excel Upload/Student List Upload Format.xlsx");
    }


    //For Multiple Class-Admin of single Number by Jitendra
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string sVal = ExistLoginId.Text;
        sVal = sVal.Substring(1);
        string[] sValues = sVal.Split(',');
        for (int j = 0; j < sValues.Length; j++)
        {
            string SQLQuery1 = "Select SLoginId from tblMulClassAdmin Where SLoginId='" + sValues[j].ToString() + "' and CLALoginId='" + Session["LoginId"].ToString() + "'";
            string log = cc.ExecuteScalar(SQLQuery1);
            if (log != "")
            {
            }
            else
            {
                string role = string.Empty;
                if (Session["Role"].ToString() == "22")
                {
                    role = "23";
                }
                else
                {
                    role = "10";
                }
                string SQLQuery = "Insert Into tblMulClassAdmin(SLoginId,CLALoginId,RoleId,CompanyId,EntryDate)Values('" + sValues[j].ToString() + "','" + Session["LoginId"].ToString() + "','" + role.ToString() + "','" + Session["CompanyId"].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                int status = cc.ExecuteNonQuery(SQLQuery);
            }
        }
        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "msg", "alert('Record Added Successfully..!!!')", true);
    }
}
