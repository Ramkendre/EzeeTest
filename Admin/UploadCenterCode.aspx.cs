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

public partial class Admin_UploadCenterCode : System.Web.UI.Page
{
    CompanyBAL compbal = new CompanyBAL();
    RegisterToMyct reg = new RegisterToMyct();
    CommonCode cc = new CommonCode();
    OleDbConnection conn = new OleDbConnection();
    DataSet ds = new DataSet();


    int status, count, countupdate;
    string Sql = "", Sql1 = "", filepath = "", connpath = "", initial = "";
    string fileExtension = string.Empty;
    string UserName = "", UserID = "", R1 = "", R2 = "", R3 = "", R4 = "", R5 = "", R6 = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }

    }

    public DataSet getdata(string sql)
    {
        DataSet tempds = new DataSet();

        filepath = Server.MapPath("LoginDATA_Upload\\" + FileUpload1.FileName);
        fileExtension = Path.GetExtension(filepath);

        if (this.fileExtension == ".xls")
        {
            connpath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
        }
        else
        {
            connpath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
        }
        conn = new OleDbConnection(connpath);
        try
        {
            conn.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, conn);
            ad.Fill(tempds);
        }
        catch (Exception ex)
        {
        }
        conn.Close();

        return tempds;
    }

    string Lastname;
    protected void btnSave_Click(object sender, EventArgs e)
    {
        count = 0;
        countupdate = 0;
        if (FileUpload1.HasFile)
        {
            filepath = Server.MapPath("LoginDATA_Upload\\" + FileUpload1.FileName);

            if (File.Exists(filepath))
            {
                File.Delete(filepath);
                FileUpload1.SaveAs(filepath);
            }
            else
            {
                FileUpload1.SaveAs(filepath);
            }


            string strQuery = "select * from [data$]";

            ds = getdata(strQuery);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    string Sql = "Select CompanyId from CompanyMaster where MobileNo1='" + Convert.ToString(ds.Tables[0].Rows[i]["Mobile No"]) + "' ";
                    string Id = Convert.ToString(cc.ExecuteScalar(Sql));
                    if (!(Id == null || Id == ""))
                    {
                        countupdate++;
                    }
                    else
                    {

                        compbal.DisplayName1 = compbal.CompanyName1 = Convert.ToString(ds.Tables[0].Rows[i]["Network Partner Name"]).Replace("'", " ");
                        // compbal.DisplayName1 = txtDisplayName.Text;
                        compbal.Address1 = Convert.ToString(ds.Tables[0].Rows[i]["Address"]);
                        compbal.Address1 = compbal.Address1.Replace("'", " ");

                        // compbal.Pincode = txtPin.Text; Co-Ordinator Name ,Center Code
                        compbal.Mobile1 = Convert.ToString(ds.Tables[0].Rows[i]["Mobile No"]);
                        compbal.Emailid = Convert.ToString(ds.Tables[0].Rows[i]["Email"]);

                        compbal.CenterCode1 = Convert.ToString(ds.Tables[0].Rows[i]["Center Code"]);


                        int companyID = compbal._insertCompany(compbal);

                        if (companyID >= 1)
                        {
                            compbal.TempCompanyId = companyID;
                            count++;

                            Sql = "Select LoginId from Login where LoginId='" + Convert.ToString(ds.Tables[0].Rows[i]["Mobile No"]) + "' ";
                            Id = Convert.ToString(cc.ExecuteScalar(Sql));
                            if (!(Id == null || Id == ""))
                            {

                            }
                            else
                            {

                                string[] fullname = Convert.ToString(ds.Tables[0].Rows[i]["Co-Ordinator Name"]).Split(' ');
                                string FirstName = fullname[0];
                                if (fullname.Length > 2)
                                    Lastname = fullname[1] + " " + fullname[2];
                                else if (fullname.Length > 1)
                                    Lastname = fullname[1];

                                if (Lastname == "")
                                    Lastname = "Sir";

                                string pincode = "411039";
                                string regid = reg.Addnew(FirstName, Lastname, compbal.Mobile1, compbal.Address1, pincode, "1"); // 1 means msg send

                                if (regid != "" || regid == null)
                                {
                                    Sql = "Insert into Login(LoginId, UserName, Password,  " +
                              " Address, DOJ, Role, CompanyId,Active,admintype ,UserType,Category,ContactNo) Values " +
                              " (N'" + compbal.Mobile1 + "',N'" + FirstName + "',N'" + regid + "', " +
                              " N'" + compbal.Address1 + "','" + System.DateTime.Now + "',3, " + companyID + "   ,1,'1','1','Computer Classes','" + compbal.Mobile1 + "') ";
                                    int flag = cc.ExecuteNonQuery(Sql);


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


                                }
                            }

                        }
                    }


                }
                lblinsert.Text = " Total record Added : " + count;
                lblupdate.Text = "Total record not Added : " + countupdate;
                lblinsert.Visible = true;
                lblupdate.Visible = true;

            }

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

            //string Sql = "insert Admin_SubUser(uid,loginid,roleid,rolename,DT,R1,companyid)" +
            //              "values(" + UID + ",'" + txtLoginId.Text + "'," + ddlRole.SelectedValue + ",'" + ddlRole.SelectedItem.Text + "','" + cc.DTInsert_Local(txtDOJ.Text) + "'," + UID + ",'" + Convert.ToString(Session["CompanyId"]) + "')";
            //int flag = cc.ExecuteScalar1(Sql);

            string sql = "select id from Admin_SubUser where uid='" + Convert.ToString(Session["insertID"]) + "'";
            string id1 = cc.ExecuteScalar(sql);
            if (!(id1 == null || id1 == ""))
            {
                Response.Write("<script>(alert)('This User is already  of other, You cannot assign ')</script>");
            }

            else
            {
                string Sql = "insert Admin_SubUser(loginid,loginname,uid,UnderUsername,roleid,rolename,DT,R1,companyid)" +
                              "values('" + Convert.ToString(Session["LoginName"]) + "','" + Convert.ToString(Session["LoginId"]) + "'," + Convert.ToString(Session["insertID"]) + ",'" + compbal.Mobile1 + "', 3 ,'Class-Admin','" + System.DateTime.Now + "','" + Convert.ToString(Session["LoginId"]) + "'," + compbal.TempCompanyId + ")";
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
        // string R1 = Convert.ToString(Session["LoginId"]);
        string Sub_UID = Convert.ToString(Session["Sub_UID"]);
        string sql12 = "select id from Admin_SubUser where UnderUsername='" + UserName + "'";
        string id = cc.ExecuteScalar(sql12);

        if (id == "")
        {
            string Sql = "insert Admin_SubUser(loginid,loginname,uid,UnderUsername,roleid,rolename,DT,R1,R2,R3,R4,R5,R6,companyid)" +
                       "values('" + Convert.ToString(Session["LoginName"]) + "','" + Convert.ToString(Session["LoginId"]) + "'," + Convert.ToString(Session["insertID"]) + ",'" + compbal.Mobile1 + "',3,'Class-Admin','" + System.DateTime.Now + "','" + R1 + "','" + R2 + "','" + R3 + "','" + R4 + "','" + R5 + "','" + R6 + "'," + compbal.TempCompanyId + ")";
            int flag = cc.ExecuteNonQuery(Sql);
        }
        else
        {
            string id1 = "";

            // string sql = "select id from Admin_SubUser where uid='" + Sub_UID + "'";
            string sql = "select id from Admin_SubUser where uid='" + Convert.ToString(Session["insertID"]) + "'";
            id1 = cc.ExecuteScalar(sql);
            if (!(id1 == null || id1 == ""))
            {
                Response.Write("<script>(alert)('This User is already  of other, You cannot assign ')</script>");
            }

            else
            {


                string Sql = "insert Admin_SubUser(loginid,loginname,uid,UnderUsername,roleid,rolename,DT,R1,R2,R3,R4,R5,R6,companyid)" +
                       "values('" + Convert.ToString(Session["LoginName"]) + "','" + Convert.ToString(Session["LoginId"]) + "'," + Convert.ToString(Session["insertID"]) + ",'" + compbal.Mobile1 + "',3, 'Class-Admin','" + System.DateTime.Now + "','" + R1 + "','" + R2 + "','" + R3 + "','" + R4 + "','" + R5 + "','" + R6 + "','" + compbal.TempCompanyId + "')";
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
            string usrRole = Convert.ToString(ds1.Tables[0].Rows[0]["rolename"]);
            string userid = Convert.ToString(ds1.Tables[0].Rows[0]["UnderUsername"]);
            string RoleId = Convert.ToString(ds1.Tables[0].Rows[0]["roleid"]);
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Excel Upload/CenterCode xls file format.xls");
    }
}