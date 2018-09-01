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
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.Data.OleDb;
using Myct;

public partial class UploadData_UploadDealerList : System.Web.UI.Page
{
    HttpCookie Cookie;
    CommonCode cc = new CommonCode();
    string ConnPath = "", Sql;
    int count = 0, count1 = 0;
    string schoolId, TeacherMobileNo, message, date, Empmobile;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.Cookies["Name"] != null)
        //{
        //    Cookie = Request.Cookies["Name"];
        //}
        //else
        //{
        //    Response.Redirect("../UserSite/Login.aspx");
        //}
        if (!IsPostBack)
        { 
        }
    }

    protected void btnInserted_Click(object sender, EventArgs e)
    {
        OleDbConnection conn;

        SqlConnection consql = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringeZeeHealth"]);
        consql.Open();
        try
        {

            DataSet ds = new DataSet();
            if (databasefile.PostedFile != null)
            {

                // Check file size
                HttpPostedFile myFile = databasefile.PostedFile;
                string fname = myFile.FileName;
                int nFileLen = myFile.ContentLength;
                if (nFileLen == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Upload file.')", true);
                    return;
                }
                else
                {

                    string[] filearray = fname.Split('.');
                    string fileExtension = filearray[1].ToLower();
                    string connstring = "";
                    string filePath = Server.MapPath("StoreDealerFile\\") + fname;
                    FileInfo fr = new FileInfo(filePath);

                    if (fr.Exists == true)
                    {
                        fr.Delete();
                        databasefile.SaveAs(filePath);

                    }
                    else
                    {
                        databasefile.SaveAs(filePath);

                    }

                    if (fileExtension.Trim() == "xls")
                    {
                        connstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    else if (fileExtension.Trim() == "xlsx")
                    {
                        connstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    conn = new OleDbConnection(connstring);



                    ///////////// code for insert uniform scholarship details
                    ds.Reset();

                    string Sql11 = " select Sr_No,NameFirm_Hospital,CP_FirstName,CP_LastName,Address,Pincode,State,District,Taluka,City,Fax,MobileNo1,MobileNo2,MobileNo3,Email_Id,Website" +
                                   " from [tblRegistration$] ";
                    //if (conn.State == ConnectionState.Closed)
                      //  conn.Open();

                    OleDbCommand cmd1 = new OleDbCommand(Sql11, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd1);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {

                            string srno = Convert.ToString(ds.Tables[0].Rows[i]["Sr_No"]);
                            if (srno == "1078")
                            {
                            }

                            SqlParameter[] par = new SqlParameter[19];
                            par[0] = new SqlParameter("@SrNo", Convert.ToString(ds.Tables[0].Rows[i]["Sr_No"]));
                            par[1] = new SqlParameter("@FirmName", Convert.ToString(ds.Tables[0].Rows[i]["NameFirm_Hospital"]));
                            par[2] = new SqlParameter("@FirstName", Convert.ToString(ds.Tables[0].Rows[i]["CP_FirstName"]));
                            par[3] = new SqlParameter("@LastName", Convert.ToString(ds.Tables[0].Rows[i]["CP_LastName"]));
                            par[4] = new SqlParameter("@Address", Convert.ToString(ds.Tables[0].Rows[i]["Address"]));
                            par[5] = new SqlParameter("@Pincode", Convert.ToString(ds.Tables[0].Rows[i]["Pincode"]));
                            par[6] = new SqlParameter("@City", Convert.ToString(ds.Tables[0].Rows[i]["City"]));
                           
                            par[7] = new SqlParameter("@Fax", Convert.ToString(ds.Tables[0].Rows[i]["Fax"]));
                            par[8] = new SqlParameter("@MobileNo1", Convert.ToString(ds.Tables[0].Rows[i]["MobileNo1"]));
                            par[9] = new SqlParameter("@MobileNo2", Convert.ToString(ds.Tables[0].Rows[i]["MobileNo2"]));
                            par[10] = new SqlParameter("@MobileNo3", Convert.ToString(ds.Tables[0].Rows[i]["MobileNo3"]));
                            par[11] = new SqlParameter("@EmailId", Convert.ToString(ds.Tables[0].Rows[i]["Email_Id"]));

                            par[12] = new SqlParameter("@Website", Convert.ToString(ds.Tables[0].Rows[i]["Website"]));
                            par[13] = new SqlParameter("@EntryDate", System.DateTime.Now);
                            par[14] = new SqlParameter("@LoginID", "9158696413");//Cookie["MobileNo"]

                            par[15] = new SqlParameter("@insertUpdate", 1);

                            par[16] = new SqlParameter("@status", 0);
                            par[16].Direction = ParameterDirection.InputOutput;


                            int s = SqlHelper.ExecuteNonQuery(consql, CommandType.StoredProcedure, "DealerListInfo_Sp", par);


                          //  par[18].Direction = ParameterDirection.ReturnValue;

                            int id = 1;//Convert.ToInt32(par[18].Value);

                            string fname1, lname, mobno, firmname, emailid;
                            fname1=Convert.ToString(ds.Tables[0].Rows[i]["CP_FirstName"]);
                            lname=Convert.ToString(ds.Tables[0].Rows[i]["CP_LastName"]);
                            mobno=Convert.ToString(ds.Tables[0].Rows[i]["MobileNo1"]);
                            firmname = Convert.ToString(ds.Tables[0].Rows[i]["NameFirm_Hospital"]);
                            emailid=Convert.ToString(ds.Tables[0].Rows[i]["Email_Id"]);

                            SendMail semdmail = new SendMail();
                            MYCT myct = new MYCT();
                            string regid = myct.registerUser(fname1, lname, mobno);
                            string pass = cc.DESDecrypt(regid);
                            string passwordMessage = "Dear Dealer " + lname + ",ur " + firmname + "  is added ur login pwd is " + pass + " for www.ezeehealth.in and  " + cc.AddSMS(mobno);
                            int smslength = passwordMessage.Length;
                            cc.SendMessageLongCodeSMS("ezeehealth", mobno, passwordMessage, smslength);
                            if (emailid != "")
                            {
                                try
                                {
                                  //  semdmail.SendMeail(emailid, mobno, regid, firmname);
                                }
                                catch
                                {
                                }
                            }


                            if (id == 1)
                            {
                                count++;
                            }
                            else if (id == 3)
                            {
                                count1++;
                            }

                        }

                        if (count == 0 && count1 == 0)
                        {
                            if (conn.State == ConnectionState.Open)
                            conn.Close();
                        }
                        else
                        {
                            if (conn.State == ConnectionState.Open)
                                conn.Close();
                            lblerror.Text = " Total " + count + " Dealer record inserted and " + count1 + " Dealer record not updated  Successfully ";

                            lblerror.Visible = true;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Total " + count + " Dealer record inserted and " + count1 + " Dealer record not updated  Successfully ')", true);
                            Loaddata(4);
                        }



                    }

                }

            }
        }
        catch (Exception ex)
        {

            throw ex;

        }
        finally
        {
            // conn.Close();
        }

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        OleDbConnection conn;

        SqlConnection consql = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        consql.Open();
        try
        {

            DataSet ds = new DataSet();
            if (databasefile.PostedFile != null)
            {

                // Check file size
                HttpPostedFile myFile = databasefile.PostedFile;
                string fname = myFile.FileName;
                int nFileLen = myFile.ContentLength;
                if (nFileLen == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Upload file.')", true);
                    return;
                }
                else
                {

                    string[] filearray = fname.Split('.');
                    string fileExtension = filearray[1].ToLower();
                    string connstring = "";
                    string filePath = Server.MapPath("StoreDealerFile\\") + fname;
                    FileInfo fr = new FileInfo(filePath);

                    if (fr.Exists == true)
                    {
                        fr.Delete();
                        databasefile.SaveAs(filePath);

                    }
                    else
                    {
                        databasefile.SaveAs(filePath);

                    }

                    if (fileExtension.Trim() == "xls")
                    {
                        connstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    else if (fileExtension.Trim() == "xlsx")
                    {
                        connstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    conn = new OleDbConnection(connstring);



                    ///////////// code for insert uniform scholarship details
                    ds.Reset();

                    string Sql11 = " select Sr_No,NameFirm_Hospital,CP_FirstName,CP_LastName,Address,Pincode,State,District,Taluka,City,Phone1,Phone11,Fax,MobileNo1,MobileNo2,MobileNo3,Email_Id,Website" +
                                   " from [tblRegistration$] ";
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    OleDbCommand cmd1 = new OleDbCommand(Sql11, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd1);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {

                            string srno = Convert.ToString(ds.Tables[0].Rows[i]["Sr_No"]);
                            if (srno == "1078")
                            {
                            }

                            SqlParameter[] par = new SqlParameter[19];
                            par[0] = new SqlParameter("@SrNo", Convert.ToString(ds.Tables[0].Rows[i]["Sr_No"]));
                            par[1] = new SqlParameter("@FirmName", Convert.ToString(ds.Tables[0].Rows[i]["NameFirm_Hospital"]));
                            par[2] = new SqlParameter("@FirstName", Convert.ToString(ds.Tables[0].Rows[i]["CP_FirstName"]));
                            par[3] = new SqlParameter("@LastName", Convert.ToString(ds.Tables[0].Rows[i]["CP_LastName"]));
                            par[4] = new SqlParameter("@Address", Convert.ToString(ds.Tables[0].Rows[i]["Address"]));
                            par[5] = new SqlParameter("@Pincode", Convert.ToString(ds.Tables[0].Rows[i]["Pincode"]));
                            par[6] = new SqlParameter("@City", Convert.ToString(ds.Tables[0].Rows[i]["City"]));
                            par[7] = new SqlParameter("@PhoneNo1", Convert.ToString(ds.Tables[0].Rows[i]["Phone1"]));
                            par[8] = new SqlParameter("@PhoneNo2", Convert.ToString(ds.Tables[0].Rows[i]["Phone11"]));
                            par[9] = new SqlParameter("@Fax", Convert.ToString(ds.Tables[0].Rows[i]["Fax"]));
                            par[10] = new SqlParameter("@MobileNo1", Convert.ToString(ds.Tables[0].Rows[i]["MobileNo1"]));
                            par[11] = new SqlParameter("@MobileNo2", Convert.ToString(ds.Tables[0].Rows[i]["MobileNo2"]));
                            par[12] = new SqlParameter("@MobileNo3", Convert.ToString(ds.Tables[0].Rows[i]["MobileNo3"]));
                            par[13] = new SqlParameter("@EmailId", Convert.ToString(ds.Tables[0].Rows[i]["Email_Id"]));

                            par[14] = new SqlParameter("@Website", Convert.ToString(ds.Tables[0].Rows[i]["Website"]));
                            par[15] = new SqlParameter("@EntryDate", System.DateTime.Now);
                            par[16] = new SqlParameter("@LoginID", Cookie["MobileNo"]);

                            par[17] = new SqlParameter("@insertUpdate", 1);

                            par[18] = new SqlParameter("@status", 0);
                            par[18].Direction = ParameterDirection.InputOutput;


                            int s = SqlHelper.ExecuteNonQuery(consql, CommandType.StoredProcedure, "DealerListInfo_Sp", par);


                            par[18].Direction = ParameterDirection.ReturnValue;

                            int id = Convert.ToInt32(par[18].Value);



                            if (id == 1)
                            {
                                count++;
                            }
                            else if (id == 2)
                            {
                                count1++;
                            }

                        }

                        if (count == 0 && count1 == 0)
                        {
                            conn.Close();
                        }
                        else
                        {
                            conn.Close();
                            lblerror.Text = " Total " + count + " Dealer record inserted and " + count1 + " Dealer record  updated  Successfully ";

                            lblerror.Visible = true;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Total " + count + " Dealer record inserted and " + count1 + " Dealer record  updated  Successfully ')", true);
                            Loaddata(4);
                        }



                    }

                }

            }
        }
        catch (Exception ex)
        {

            throw ex;

        }
        finally
        {
            // conn.Close();
        }
    }

    private void Loaddata(int a)
    {
        try
        {
            string Sql = "Select Sr_No,NameFirm_Hospital,CP_FirstName,CP_LastName,Address,Pincode,City,PhoneNo1,PhoneNo11,Fax,MobileNo1,MobileNo2,MobileNo3,Email_Id,Website from tblRegistration$ where FirmType='" + a + "' ";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDealerlist.DataSource = ds.Tables[0];
                gvDealerlist.DataBind();
                if (a == 1)
                {
                    //lblerror.Text = " Company details Upload Successfully ";
                    //lblerror.Visible = true;
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Company details Upload Successfully ')", true);

                }

            }
            else
            {
                gvDealerlist.DataSource = ds.Tables[0];
                gvDealerlist.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        Response.Redirect("../UploadData/UploadFormat/RegistrationDetails_UploadFormat.xls");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {

    }
}
