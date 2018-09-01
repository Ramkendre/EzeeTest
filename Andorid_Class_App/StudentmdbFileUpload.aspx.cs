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
using System.Web.Caching;

public partial class Andorid_Class_App_StudentmdbFileUpload : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sql, connpath = "", EntryDate = "";
    int status, count;

    OleDbConnection conn = null;
    CommonCode cc = new CommonCode();


    protected void Page_Load(object sender, EventArgs e)
    {
        string Id1 = Convert.ToString(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            if (Id1 != "" && Id1 != null)
            {
                Session["ClassSetting_id"] = Id1;
                getDatailsclass(Id1);

            }
        }
        Dateformat();
    }


    public void Dateformat()
    {
        DateTime dt = DateTime.Now;
        DateTime SystemDate = Convert.ToDateTime(dt);        
        EntryDate = SystemDate.ToString("dd'/'MM'/'yyyy''");
    }

    public void getDatailsclass(string Id)
    {
        try
        {
            string Sql = "select  Name as Class_Name,Class_Id,Session,Batch from tblClassSetting inner join  tblItemValue on tblClassSetting.Class_Id= tblItemValue.ItemValueId where ClassSetting_id=" + Id + " ";
            ds = cc.ExecuteDataset(Sql);
            lblBatch.Text = Convert.ToString(ds.Tables[0].Rows[0]["Batch"]);
            lblClass.Text = Convert.ToString(ds.Tables[0].Rows[0]["Class_Name"]);
            // lblClassid.Text = Convert.ToString(ds.Tables[0].Rows[0]["Class_Id"]);
            lblSession.Text = Convert.ToString(ds.Tables[0].Rows[0]["Session"]);

        }
        catch
        {
        }

    }

    public DataSet getAccessDS(string sql)
    {
        DataSet tempds = null;
        try
        {
            string filename1 = Convert.ToString(Session["filename"]);
            string filepath = Server.MapPath("StudentmdbFileUpload\\" + filename1);


            connpath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Persist Security Info=True;Jet OLEDB:Database Password=MS#CITSol@rNov2008;";

            conn = new OleDbConnection(connpath);
            conn.Open();

            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            tempds = new DataSet();
            adapter.Fill(tempds);
        }
        catch
        {
            throw;
        }

        conn.Close();
        return tempds;
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string path;
            path = Server.MapPath("StudentmdbFileUpload");

            path = path + "\\" + FileUpload1.FileName;
            Session["filename"] = FileUpload1.FileName;

            if (File.Exists(path))
            {
                File.Delete(path);
                FileUpload1.SaveAs(path);
            }
            else
            {
                FileUpload1.SaveAs(path);
            }
            bindGrid();


        }
        catch
        {

            throw;
        }
    }

    public void bindGrid()
    {
        try
        {
            //sql = "select pklLearnerId,vsFname,vsMname,vsLname,dtDob,vsGender from eflearnermaster ";

            sql = "select * from eflearnermaster ";
            ds = getAccessDS(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvmdbupload.DataSource = ds;
                gvmdbupload.DataBind();

                //Cache.Remove("dsData");
                //if (Cache["dsData"] == null)
                //{
                //    HttpContext.Current.Cache["dsData"] = ds;
                //}
            }


        }
        catch
        {
            throw;
        }
    }


    protected void gvmdbupload_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvmdbupload_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // gvmdbupload.PageIndex = e.NewPageIndex;
        // bindGrid();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet ds1 = new DataSet();
       // ds1 = (DataSet)HttpContext.Current.Cache["dsData"];

      

        string idset = addchapselect();

        if (idset != "")
        {
            sql = "select * from eflearnermaster ";
            ds1 = getAccessDS(sql);

            DataRow[] dr = ds1.Tables[0].Select("pklLearnerId in (" + idset + ")");


            if (dr.Length > 0)
            {
                insertdata(dr);

            }
        }
        else
        {
            lblError.Text = "Please select atleast one student from gridview";
            lblError.Visible = true;
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "msg", "alert('Please select atleast one student from gridview')", true);

        }





    }

    int newadm_no;
    string gender;
    public void insertdata(DataRow[] dr)
    {
        count = 0;
        try
        {
            string Sql = " select max(Adm_No) from tblStudentRegister where   ClassSetting_id='" + Convert.ToString(Session["ClassSetting_id"]) + "' and  LoginId='" + Convert.ToString(Session["LoginId"]) + "' ";
            string Adm_No = Convert.ToString(cc.ExecuteScalar(Sql));

            for (int i = 0; i < dr.Length; i++)
            {

                if (Adm_No != "")
                    newadm_no = Convert.ToInt32(Adm_No);
                newadm_no = newadm_no + 1;


                string gen = Convert.ToString(dr[i]["vsGender"]);
                if (gen == "Male")
                    gender = "Boy";
                else
                    gender = "Girl";

                string[] tmp1 = Convert.ToString(dr[i]["dtDob"]).Split(' ');
                string[] tmp = tmp1[0].Split('/');
                string DOB = tmp[1].ToString() + "/" + tmp[0].ToString() + "/" + tmp[2].ToString();
                string dateofbirth = DOB;

                Sql = "select SNO from tblStudentRegister where First_Name='" + Convert.ToString(dr[i]["vsFname"]) + "' and  Last_Name='" + Convert.ToString(dr[i]["vsLname"]) + "' and Father_Name='" + Convert.ToString(dr[i]["vsMname"]) + "' and ClassSetting_id=" + Convert.ToInt32(Session["ClassSetting_id"]) + " and LoginId='" + Convert.ToString(Session["LoginId"]) + "'  ";
                string Sno=Convert.ToString(cc.ExecuteScalar(Sql));

                if (Sno == "")
                {

                    string Sql11 = "insert into tblStudentRegister  (Adm_No,adm_date,ClassSetting_id,First_Name , Last_Name,Father_Name,Stud_MobNo, " +

                       " Parent_MobNo,StudAddress,WardNo, Area , CityId, Gender,Pincode,LoginId  , vsMStatus,vsNationality,vsCAddress,vsCCity,vscSuburb, " +

                        " fklCCountryId,  fklCStateId,fklCDistrictId,vsCTaluka,vsCPin,fklPCountryId,fklPStateId,  fklPDistrictId,vsPTaluka,vsAreaResi, " +
                        " vsEmail,vsQualification,fklCategoryId,  vsFormNo,vsProof,vsMotherTongue,vsCertName,vsage,vsTitle,vsMobile2Reference,vsBloodGroup ) values " +
                        " (" + newadm_no + ",'" + EntryDate + "'," + Convert.ToInt32(Session["ClassSetting_id"]) + ",'" + Convert.ToString(dr[i]["vsFname"]) + "'   ," +
                        " '" + Convert.ToString(dr[i]["vsLname"]) + "','" + Convert.ToString(dr[i]["vsMname"]) + "'," +

                        " '" + Convert.ToString(dr[i]["vsMobile"]) + "','" + Convert.ToString(dr[i]["vsMobile2"]) + "','" + Convert.ToString(dr[i]["vsPAddress"]) + "'," +
                        "  '" + Convert.ToString(dr[i]["vsNumberResi"]) + "','" + Convert.ToString(dr[i]["vsPSuburb"]) + "' , '" + Convert.ToString(dr[i]["vsPCity"]) + "'," +

                        " '" + gender + "','" + Convert.ToInt32(dr[i]["vsPPin"]) + "','" + Convert.ToString(Session["LoginId"]) + "' ,  '" + Convert.ToString(dr[i]["vsMStatus"]) + "'," +

                        " '" + Convert.ToString(dr[i]["vsNationality"]) + "','" + Convert.ToString(dr[i]["vsCAddress"]) + "','" + Convert.ToString(dr[i]["vsCCity"]) + "' ," +

                        " '" + Convert.ToString(dr[i]["vscSuburb"]) + "' ," + Convert.ToInt32(dr[i]["fklCCountryId"]) + " ,   " + Convert.ToInt32(dr[i]["fklCStateId"]) + "," +
                        " " + Convert.ToInt32(dr[i]["fklCDistrictId"]) + ",'" + Convert.ToString(dr[i]["vsCTaluka"]) + "'," + Convert.ToInt32(dr[i]["vsCPin"]) + " ," +
                        " " + Convert.ToInt32(dr[i]["fklPCountryId"]) + " ,'" + Convert.ToInt32(dr[i]["fklPStateId"]) + "' ,  " + Convert.ToInt32(dr[i]["fklPDistrictId"]) + "," +
                        " '" + Convert.ToString(dr[i]["vsPTaluka"]) + "','" + Convert.ToString(dr[i]["vsAreaResi"]) + "','" + Convert.ToString(dr[i]["vsEmail"]) + "' ," +
                        " '" + Convert.ToString(dr[i]["vsQualification"]) + "' ," + Convert.ToInt32(dr[i]["fklCategoryId"]) + " ,  '" + Convert.ToString(dr[i]["vsFormNo"]) + "'," +
                        " '" + Convert.ToString(dr[i]["vsProof"]) + "','" + Convert.ToString(dr[i]["vsMotherTongue"]) + "','" + Convert.ToString(dr[i]["vsCertName"]) + "' ," +
                        " '" + Convert.ToString(dr[i]["vsage"]) + "' ,'" + Convert.ToString(dr[i]["vsTitle"]) + "' ,   '" + Convert.ToString(dr[i]["vsMobile2Reference"]) + "'," +
                        " '" + Convert.ToString(dr[i]["vsBloodGroup"]) + "'  ) ";




                    status = cc.ExecuteNonQuery(Sql11);
                    count++;
                }
                

            }
            lblError.Text = "Total " +count+ " Student add successfully";
            lblError.Visible = true;
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "msg", "alert('Total " +count+ " Student add successfully !!!!')", true);


        }
        catch(Exception ex)
        {
        }

    }

    public string addchapselect()
    {
        string idset = "";

        for (int i = 0; i < gvmdbupload.Rows.Count; i++)
        {

            System.Web.UI.WebControls.CheckBox chkbox = (System.Web.UI.WebControls.CheckBox)gvmdbupload.Rows[i].Cells[6].FindControl("chkSelect");
            if (chkbox != null)
            {
                if (chkbox.Checked == true)
                {

                    idset += Convert.ToString(gvmdbupload.Rows[i].Cells[0].Text) + ",";

                }
            }
            chkbox.Checked = false;
        }
        if (idset != "")
            idset = idset.Substring(0, idset.Length - 1);

        return idset;
    }

}