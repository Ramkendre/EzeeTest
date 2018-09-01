using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubAdmin_UplaodeZeeSchoolData : System.Web.UI.Page
{

    public string path;
    string conPath = string.Empty;
    OleDbConnection conn;
    CommonCode cc = new CommonCode();
    string excelSubject = "ezeeschool";
    SqlConnection consql = new SqlConnection(ConfigurationManager.AppSettings["SchoolConnectionString"]);
    //SqlConnection consql = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolConnectionString"].ConnectionString);

    double txtstudentid;
    string txtstudentid1, txtAcademicYear, txtSchoolCode, txtAdmnNo, txtStudFName, txtStudMName, txtStudLName,
        txtStudName, txtMomName, txtAdhaar, txtDOB, txtDOA, txtStream, txtSemienglish, txtclass, txtDivision, txtMedium, txtEID,
        txtAdmisionType, txtBloodgrp, txtinitStd, txtgender,txtAdmdate;

    string cmbGender, cmbClass, cmbDivision, cmdAcademicyear, cmbSemiEnglish, cmbMedium, cmbAdmisionType, cmbCompanyId = string.Empty;
    string DuplicateAddmissionid = "", incorrectaddmissionid = "";
    int insCount = 0, dupli = 0, upCount = 0;
    

    SqlCommand cmd1 = new SqlCommand();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUploadeZeeSchool.HasFile)
            {
                //string path = "";
                path = Server.MapPath("Access_upload");
                path = path + "\\" + FileUploadeZeeSchool.FileName;
                string ab = FileUploadeZeeSchool.FileName;

                if (File.Exists(path))
                {
                    File.Delete(path);
                    FileUploadeZeeSchool.SaveAs(path);
                }
                else
                {
                    FileUploadeZeeSchool.SaveAs(path);
                }

                string strQuery = "select * from [" + excelSubject + "$]";
                DataSet dscount = GetDataTable(strQuery);
                int count2 = Convert.ToInt32(dscount.Tables[0].Rows.Count);

                if (count2 > 0)
                {
                    for (int i = 0; i < count2; i++)
                    {
                        txtstudentid = Convert.ToDouble(dscount.Tables[0].Rows[i]["StudentID"]);
                        decimal t = (decimal)txtstudentid;
                        txtstudentid1 = t.ToString("F0");
                        txtAcademicYear = "2015-2016";  //academic year
                        txtSchoolCode = txtstudentid1.Substring(4, 11);//row["UdiseCode"].ToString();        
                        txtAdmnNo = Convert.ToString(dscount.Tables[0].Rows[i]["GRNo"]);   //general reg no. or udise id

                        //if (txtSchoolCode != Session["SC_ID"].ToString())
                        //{
                        string[] Name = dscount.Tables[0].Rows[i]["StudentName"].ToString().Split(new char[] { ' ' });
                        txtStudFName = Name[0];
                        txtStudMName = Name[1];
                        txtStudLName = Name[2];
                        txtStudName = dscount.Tables[0].Rows[i]["StudentName"].ToString();  //studName
                        txtMomName = dscount.Tables[0].Rows[i]["MotherName"].ToString(); //studMotherName
                        txtAdhaar = dscount.Tables[0].Rows[i]["UID"].ToString();  //studName
                        txtDOB = Convert.ToString(dscount.Tables[0].Rows[i]["BirthDate"]);  //DOB dd/mm/yyyy
                        txtDOA = Convert.ToString(dscount.Tables[0].Rows[i]["InitialAdmissionDate"]);  //DOA dd/mm/yyyy
                        //txtAddmissionDate = DateTime.Parse(txtDOA);//dscount.Tables[0].Rows[i]["InitialAdmissionDate"]);  //DOA dd/mm/yyyy
                        txtStream = dscount.Tables[0].Rows[i]["Stream"].ToString();   //stream
                        txtSemienglish = dscount.Tables[0].Rows[i]["SemiEnglish"].ToString();
                        txtclass = dscount.Tables[0].Rows[i]["Standard"].ToString();
                        txtDivision = dscount.Tables[0].Rows[i]["Division"].ToString();
                        txtMedium = dscount.Tables[0].Rows[i]["Medium"].ToString();
                        txtAdmisionType = dscount.Tables[0].Rows[i]["AdmissionType"].ToString();
                        txtEID = dscount.Tables[0].Rows[i]["EID"].ToString();
                        txtBloodgrp = dscount.Tables[0].Rows[i]["BloodGroup"].ToString();
                        txtinitStd = dscount.Tables[0].Rows[i]["InitialStandard"].ToString();

                        if (dscount.Tables[0].Rows[i]["Gender"].ToString() == "M")
                        {
                            txtgender = "boy";
                        }
                        else if (dscount.Tables[0].Rows[i]["Gender"].ToString() == "F")
                        {
                            txtgender = "girl";
                        }

                        # region replacefieldsvalues

                        string sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                               "where [ItemValue].[ItemId]='61' and [ItemValue].Name='" + txtgender + "'";
                        DataSet ds1 = cc.ExecuteDataseteZeeSchool(sql);

                        sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                               "where [ItemValue].[ItemId]='66' and [ItemValue].Name='" + txtclass + "'";
                        DataSet ds2 = cc.ExecuteDataseteZeeSchool(sql);

                        sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                               "where [ItemValue].[ItemId]='80' and [ItemValue].Name='" + txtDivision + "'";
                        DataSet ds3 = cc.ExecuteDataseteZeeSchool(sql);

                        sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                               "where [ItemValue].[ItemId] ='99' and [ItemValue].Name='" + txtAcademicYear + "'";
                        DataSet ds4 = cc.ExecuteDataseteZeeSchool(sql);

                        sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                               "where [ItemValue].[ItemId]='64' and [ItemValue].Name='" + txtSemienglish + "'";
                        DataSet ds5 = cc.ExecuteDataseteZeeSchool(sql);

                        sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                               "where [ItemValue].[ItemId]='69' and [ItemValue].Name='" + txtMedium + "'";
                        DataSet ds6 = cc.ExecuteDataseteZeeSchool(sql);

                        sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                                "where [ItemValue].[ItemId]='25' and [ItemValue].Name='" + txtAdmisionType + "'";
                        DataSet ds7 = cc.ExecuteDataseteZeeSchool(sql);

                        sql = "select CompanyId from [DBeZeeSchool].[dbo].[CompanyMaster] where SchoolCode='" + txtSchoolCode + "'";
                        DataSet ds8 = cc.ExecuteDataseteZeeSchool(sql);

                        if (ds1.Tables[0].Rows.Count > 0)
                            cmbGender = ds1.Tables[0].Rows[0][0].ToString();
                        if (ds2.Tables[0].Rows.Count > 0)
                            cmbClass = ds2.Tables[0].Rows[0][0].ToString();
                        if (ds3.Tables[0].Rows.Count > 0)
                            cmbDivision = ds3.Tables[0].Rows[0][0].ToString();
                        if (ds4.Tables[0].Rows.Count > 0)
                            cmdAcademicyear = ds4.Tables[0].Rows[0][0].ToString();
                        if (ds5.Tables[0].Rows.Count > 0)
                            cmbSemiEnglish = ds5.Tables[0].Rows[0][0].ToString();
                        if (ds6.Tables[0].Rows.Count > 0)
                            cmbMedium = ds6.Tables[0].Rows[0][0].ToString();
                        if (ds7.Tables[0].Rows.Count > 0)
                            cmbAdmisionType = ds7.Tables[0].Rows[0][0].ToString();
                        if (ds8.Tables[0].Rows.Count > 0)
                            cmbCompanyId = ds8.Tables[0].Rows[0][0].ToString();

                        # endregion
                        // }

                        insertSaralFunction1();
                    }
                    //lblComment.Text = +insCount + " new records added successfully and " + dupli + " records already exists!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + insCount + " new records added successfully and " + upCount + " records Updated Successfully!');", true);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("ERROR : " + ex);
        }
    }

    public string dateformat(string doa)
    {
        string[] dateVal = doa.Split('-');

        string dd = dateVal[0].ToString();
        string mm = dateVal[1].ToString();
        string yy = dateVal[2].ToString();

        txtAdmdate = yy + "-" + mm + "-" + dd;

        return txtAdmdate;
    }

    public void insertSaralFunction1()
    {
        try
        {
            string str = "select UdiseAddmissionId from AddmissionMaster where UdiseAddmissionId='" + Convert.ToInt32(txtAdmnNo) + "' and SchoolCode='" + Convert.ToString(txtSchoolCode) + "'";
            cmd1 = new SqlCommand(str, consql);
            consql.Open();
            string val = Convert.ToString(cmd1.ExecuteScalar());
            
            if (val == "")
            {
                DateTime dtModified = DateTime.Parse(DateTime.Today.ToString("yyyy-MM-dd"));
                DateTime admDate = DateTime.Parse(dateformat(txtDOA));

                str += "insert into AddmissionMaster([StudentCode],[UdiseAddmissionId],[Stream],[SessionId],[Class],[Section],[FName],[MName],[LName],[StudentName],[DOB],[Gender],[MotherName],[SchoolCode],[Medium],[semiEnglish],[DOA],[AddmissionType],[AdhaarName],[DateModified],[BloodGroup],[EID],[InitialStandard],[AddmissionDate],[CompanyId])";

                str += " values(@studentid,@UdiseAddmissionId,@Stream,@SessionId,@Class,@Section,@FName,@MName,@LName,@StudentName,@DOB,@Gender,@MotherName,@SchoolCode,@Medium,@semiEnglish,@DOA,@AddmissionType,@AdhaarName,@DateModified,@Bloodgrp,@eid,@initStd,@AddmissionDate,@CompanyId)";

                cmd1 = new SqlCommand(str, consql);
                cmd1.Parameters.AddWithValue("@UdiseAddmissionId", Convert.ToInt32(txtAdmnNo));
                cmd1.Parameters.AddWithValue("@Stream", txtStream);
                cmd1.Parameters.AddWithValue("@SessionId", Convert.ToInt32(cmdAcademicyear));
                cmd1.Parameters.AddWithValue("@Class", Convert.ToInt32(cmbClass));
                cmd1.Parameters.AddWithValue("@Section", Convert.ToInt32(cmbDivision));
                cmd1.Parameters.AddWithValue("@FName", txtStudFName);
                cmd1.Parameters.AddWithValue("@MName", txtStudMName);
                cmd1.Parameters.AddWithValue("@LName", txtStudLName);
                cmd1.Parameters.AddWithValue("@StudentName", txtStudName);
                cmd1.Parameters.AddWithValue("@DOB", txtDOB);
                cmd1.Parameters.AddWithValue("@Gender", cmbGender);
                cmd1.Parameters.AddWithValue("@MotherName", txtMomName);
                cmd1.Parameters.AddWithValue("@SchoolCode", txtSchoolCode);
                cmd1.Parameters.AddWithValue("@Medium", Convert.ToInt32(cmbMedium));
                cmd1.Parameters.AddWithValue("@semiEnglish", cmbSemiEnglish);
                cmd1.Parameters.AddWithValue("@DOA", txtDOA);
                cmd1.Parameters.AddWithValue("@AddmissionType", Convert.ToInt32(cmbAdmisionType));
                cmd1.Parameters.AddWithValue("@AdhaarName", txtAdhaar);
                cmd1.Parameters.AddWithValue("@DateModified", dtModified);
                cmd1.Parameters.AddWithValue("@Bloodgrp", txtBloodgrp);
                cmd1.Parameters.AddWithValue("@eid", txtEID);
                cmd1.Parameters.AddWithValue("@initStd", txtinitStd);
                cmd1.Parameters.AddWithValue("@studentid", txtstudentid1);
                cmd1.Parameters.AddWithValue("@AddmissionDate", admDate);
                cmd1.Parameters.AddWithValue("@CompanyId", cmbCompanyId);

                int i = cmd1.ExecuteNonQuery();


                if (i > 0)
                {
                    insCount++;
                }
            }
            else
            {
                updateFunction();
                dupli++;
                if (DuplicateAddmissionid == "" || DuplicateAddmissionid == null)
                {
                    DuplicateAddmissionid = txtAdmnNo;
                }
                else
                {
                    DuplicateAddmissionid += "," + txtAdmnNo;
                }
            }
        }
        catch
        {
            if (incorrectaddmissionid == "" || incorrectaddmissionid == null)
            {
                incorrectaddmissionid = txtAdmnNo;
            }
            else
            {
                incorrectaddmissionid += "," + txtAdmnNo;
            }
        }
        finally
        {
            consql.Close();
        }
    }

    void updateFunction()
    {
        try
        {

            DateTime admDate = DateTime.Parse(dateformat(txtDOA));
            //dbCon.Open();
            DateTime dtModified = DateTime.Parse(DateTime.Today.ToString("yyyy-MM-dd"));
            string str = " UPDATE AddmissionMaster set [StudentCode]=@studentid,[Stream]=@Stream,[SessionId]=@SessionId,[Class]=@Class,[Section]=@Section,[FName]=@FName,[MName]=@MName,[LName]=@LName,[StudentName]=@StudentName" +
                ",[DOB]=@DOB,[Gender]=@Gender,[MotherName]=@MotherName,[Medium]=@Medium,[semiEnglish]=@semiEnglish,[DOA]=@DOA,[AddmissionType]=@AddmissionType,[AdhaarName]=@AdhaarName" +
                ",[DateModified]=@DateModified,[BloodGroup]=@Bloodgrp,[EID]=@eid,[InitialStandard]=@initStd,[AddmissionDate]=@AddmissionDate,[CompanyId]=@CompanyId where UdiseAddmissionId=@UdiseAddmissionId and SchoolCode=@SchoolCode";

            cmd1 = new SqlCommand(str, consql);
            //cmd1.Parameters.AddWithValue("@UdiseAddmissionId", Convert.ToInt32(txtAdmnNo));
            cmd1.Parameters.AddWithValue("@UdiseAddmissionId", txtAdmnNo);
            cmd1.Parameters.AddWithValue("@Stream", txtStream);
            cmd1.Parameters.AddWithValue("@SessionId", Convert.ToInt32(cmdAcademicyear));
            cmd1.Parameters.AddWithValue("@Class", Convert.ToInt32(cmbClass));
            cmd1.Parameters.AddWithValue("@Section", Convert.ToInt32(cmbDivision));
            cmd1.Parameters.AddWithValue("@FName", txtStudFName);
            cmd1.Parameters.AddWithValue("@MName", txtStudMName);
            cmd1.Parameters.AddWithValue("@LName", txtStudLName);
            cmd1.Parameters.AddWithValue("@StudentName", txtStudName);
            cmd1.Parameters.AddWithValue("@DOB", txtDOB);
            cmd1.Parameters.AddWithValue("@Gender", cmbGender);
            cmd1.Parameters.AddWithValue("@MotherName", txtMomName);
            cmd1.Parameters.AddWithValue("@SchoolCode", txtSchoolCode);
            cmd1.Parameters.AddWithValue("@Medium", Convert.ToInt32(cmbMedium));
            cmd1.Parameters.AddWithValue("@semiEnglish", cmbSemiEnglish);
            cmd1.Parameters.AddWithValue("@DOA", txtDOA);
            cmd1.Parameters.AddWithValue("@AddmissionType", Convert.ToInt32(cmbAdmisionType));
            cmd1.Parameters.AddWithValue("@AdhaarName", txtAdhaar);
            cmd1.Parameters.AddWithValue("@DateModified", dtModified);
            cmd1.Parameters.AddWithValue("@Bloodgrp", txtBloodgrp);
            cmd1.Parameters.AddWithValue("@eid", txtEID);
            cmd1.Parameters.AddWithValue("@initStd", txtinitStd);
            cmd1.Parameters.AddWithValue("@studentid", txtstudentid1);
            cmd1.Parameters.AddWithValue("@AddmissionDate", admDate);
            cmd1.Parameters.AddWithValue("@CompanyId", cmbCompanyId);

            //TodayDateTime()

            int i = cmd1.ExecuteNonQuery();
            if (i == 1)
            {
                upCount++;
            }
        }
        catch { }
        finally
        {

        }
    }

    public DataSet GetDataTable(string strQuery)
    {
        DataSet tempDs = null;
        path = Server.MapPath("Access_upload");
        path = path + "\\" + FileUploadeZeeSchool.FileName;

        if (Path.GetExtension(path) == ".xls")
        {
            conPath = @"provider=Microsoft.Jet.OLEDB.4.0;data source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
        }
        else
        {
            conPath = @"provider=Microsoft.ACE.OLEDB.12.0;data source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
        }

        conn = new OleDbConnection(conPath);

        try
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(strQuery, conn);
            tempDs = new DataSet();
            adapter.Fill(tempDs);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('6 " + ex.Message + "');", true);
        }

        return tempDs;
    }

    protected void lnkbtndownloadFormat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SubAdmin/AudioVideoList/eZeeSchool Student Data Upload.xlsx");
    }
}