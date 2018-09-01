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

public partial class Andorid_Class_App_StudentRegister : System.Web.UI.Page
{
    Location location = new Location();
    CommonCode cc = new CommonCode();
    string Sql;
    int status;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        string Id1 = Convert.ToString(Request.QueryString["Id"]);
        if (IsPostBack == false)
        {
           // GetState();
            if (Id1 != "" && Id1 != null)
            {
                Session["ClassSetting_id"] = Id1;
                getDatailsclass(Id1);
              //  getmaxAdmNo(Id1);
                recordcount();
                BindGrid();

            }
        }



    }

    public void BindGrid()
    {

        //one student should be multiple class 
        Sql = "select * from tblStudentRegister where ClassSetting_id=" + Convert.ToInt32(Session["ClassSetting_id"]) + " and LoginId='" + Convert.ToString(Session["LoginId"]) + "' order by SNO DESC ";
        ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvStudentRegister.DataSource = ds.Tables[0];
            gvStudentRegister.DataBind();
        }
    }


    public void recordcount()
    {
        Sql = "select count(*) from tblStudentRegister where  ClassSetting_id=" + Convert.ToInt32(Session["ClassSetting_id"]) + " and  LoginId='" + Convert.ToString(Session["LoginId"]) + "' ";
        ds = cc.ExecuteDataset(Sql);
        int record = Convert.ToInt32(ds.Tables[0].Rows[0]["Column1"]);
        lblRecordNo.Text = Convert.ToString(record);
    }

    public void getDatailsclass(string Id)
    {
        try
        {
            // Sql = "select Class_Name,Class_Id,Session,Batch from tblClassSetting where ClassSetting_id=" + Id + " ";
            Sql = "select  Name as Class_Name,Class_Id,Session,Batch from tblClassSetting inner join  tblItemValue on tblClassSetting.Class_Id= tblItemValue.ItemValueId where ClassSetting_id=" + Id + " ";
            // Sql = Sql + "select  max( Adm_No)+1 as maxid from tblStudentRegister where ClassSetting_id='" + Id + "'  ";

            ds = cc.ExecuteDataset(Sql);
            lblBatch.Text = Convert.ToString(ds.Tables[0].Rows[0]["Batch"]);
            lblClass.Text = Convert.ToString(ds.Tables[0].Rows[0]["Class_Name"]);
            lblClassid.Text = Convert.ToString(ds.Tables[0].Rows[0]["Class_Id"]);
            lblSession.Text = Convert.ToString(ds.Tables[0].Rows[0]["Session"]);
            
        }
        catch
        {
        }

    }
    public void getmaxAdmNo(string Id)
    {
        try
        {
            //Sql = "select  max( Adm_No)+1 as maxid from tblStudentRegister where ClassSetting_id='" + Id + "' and  LoginId='" + Convert.ToString(Session["LoginId"]) + "' ";
            //string maxid = cc.ExecuteScalar(Sql);
            //if (maxid != "")
            //{
            //    txtAdm_No.Text = maxid;
            //}
            //else
            //{
            //    txtAdm_No.Text = "1";
            //}
        }
        catch
        {
        }
    }

       


    protected void btncancel_Click(object sender, EventArgs e)
    {
        txtAdm_No.Text = "";
        clear();
        string id5 = Convert.ToString(Session["ClassSetting_id"]);
       // getmaxAdmNo(id5);
    }
    int maxrecord;
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtAdm_No.ForeColor == System.Drawing.Color.Red)
            {
                lblError.Visible = true;
                lblError.Text = "Please Change Admission Number";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Change Admission Number!!!!')", true);

            }
            else
            {

                string id = lblId.Text;
                if (id == "")
                {
                    Addnew();
                }
                else
                {
                    UpdateRecord(id);

                }
                BingFamily();
                Button11.Visible = true;
                ImageButton btndetails = new ImageButton();
                btndetails.ID = "Button11";
                ModalPopupExtender1.TargetControlID = btndetails.ID;
                this.ModalPopupExtender1.Show();
            }

        }
        catch (Exception ex)
        {

        }

    }


    public void Addnew()
    {
        try
        {
            Sql = "select SNO from tblStudentRegister where Adm_No='"+txtAdm_No.Text+"'  and ClassSetting_id=" + Convert.ToInt32(Session["ClassSetting_id"]) + " and   LoginId='" + Convert.ToString(Session["LoginId"]) + "'  ";
            string Admno = Convert.ToString(cc.ExecuteScalar(Sql));
            if (Admno == "")
            {

                Sql = "insert into tblStudentRegister  (Adm_No,adm_date,ClassSetting_id,First_Name , " +
                    " Last_Name,Father_Name,DOB,Stud_MobNo,Parent_MobNo,StudAddress,WardNo,Area, " +
                    " CityId,Gender,Pincode,LoginId) " +
                    " values ('" + txtAdm_No.Text + "','" + txtAdm_Date.Text + "'," + Convert.ToInt32(Session["ClassSetting_id"]) + ",'" + txtFN.Text + "'  ,  " +
                    "   '" + txtLN.Text + "','" + txtFatherName.Text + "', '" + txtDOB.Text + "','" + txtStudMob_No.Text + "','" + txtParaentMob_No.Text + "','" + txtAddress.Text + "','" + txtwardNo.Text + "','" + txtArea.Text + "' , " +
                    "   '" + txtCity.Text + "','" + rdoGender.SelectedItem.Text + "','" + txtPincode.Text + "','" + Convert.ToString(Session["LoginId"]) + "' ) ";

                status = cc.ExecuteNonQuery(Sql);
                if (status == 1)
                {
                    Sql = "select SNO from tblStudentRegister where First_Name='" + txtFN.Text + "' and Last_Name='" + txtLN.Text + "' and ClassSetting_id=" + Convert.ToInt32(Session["ClassSetting_id"]) + " and  LoginId='" + Convert.ToString(Session["LoginId"]) + "' and Adm_No ='" + txtAdm_No.Text + "' ";
                    lblSNo1.Text = Convert.ToString(cc.ExecuteScalar(Sql));
                    pnllblStudName.Text = txtFN.Text + " " + txtLN.Text;
                    clear();
                    int Adm_No1 = Convert.ToInt32(txtAdm_No.Text);
                   // txtAdm_No.Text = Convert.ToString(Adm_No1 + 1);

                    BindGrid();
                    recordcount();
                    lblError.Visible = true;
                    lblError.Text = "Record Submitted successfuly  !!!!";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Submitted successfuly !!!!')", true);
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Record not Submitted !!!!";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record not Submitted !!!!')", true);
                }

            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Admission number is already used !!!!";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Admission number is already used !!!!')", true);
            }
        }


        catch (Exception ex)
        {
        }
    }
    public void UpdateRecord(string id)
    {
        try
        {
            Sql = "Update  tblStudentRegister set Adm_No='" + txtAdm_No.Text + "',adm_date='" + txtAdm_Date.Text + "',ClassSetting_id=" + Convert.ToInt32(Session["ClassSetting_id"]) + ",First_Name='" + txtFN.Text + "'  ,  " +
                    "   Last_Name='" + txtLN.Text + "',Father_Name='" + txtFatherName.Text + "',DOB= '" + txtDOB.Text + "',Stud_MobNo='" + txtStudMob_No.Text + "',Parent_MobNo='" + txtParaentMob_No.Text + "',StudAddress='" + txtAddress.Text + "',WardNo='" + txtwardNo.Text + "',Area='" + txtArea.Text + "' , " +
                    "   CityId='" + txtCity.Text + "',Gender='" + rdoGender.SelectedItem.Text + "',Pincode='" + txtPincode.Text + "',LoginId='" + Convert.ToString(Session["LoginId"]) + "'  where SNO=" + id + " ";

            status = cc.ExecuteNonQuery(Sql);
            if (status == 1)
            {
                Sql = "select SNO from tblStudentRegister where First_Name='" + txtFN.Text + "' and Last_Name='" + txtLN.Text + "' and ClassSetting_id=" + Convert.ToInt32(Session["ClassSetting_id"]) + " and  LoginId='" + Convert.ToString(Session["LoginId"]) + "' and Adm_No ='" + txtAdm_No.Text + "' ";
                lblSNo1.Text = Convert.ToString(cc.ExecuteScalar(Sql));
                pnllblStudName.Text = txtFN.Text + " " + txtLN.Text;
                clear();
                BindGrid();

              
               // string id5 = Convert.ToString(Session["ClassSetting_id"]);
               // getmaxAdmNo(id5);

                lblError.Visible = true;
                lblError.Text = "Record updated successfuly  !!!!";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record updated successfuly !!!!')", true);
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Record not updated !!!!";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record not updated !!!!')", true);
            }


        }


        catch
        {
        }
    }



    public void clear()
    {
        txtFN.Text = "";
        txtFatherName.Text = "";
        txtLN.Text = "";
        txtDOB.Text = "";
        txtArea.Text = "";
        // txtAdm_No.Text = "";
        txtAdm_Date.Text = "";
        txtAddress.Text = "";
        txtwardNo.Text = "";
        txtParaentMob_No.Text = "";
        txtStudMob_No.Text = "";
        //  txtAdm_No.Enabled = true;
        btnSave.Text = "Save";
        lblId.Text = "";


    }

   
    protected void txtAdm_Date_TextChanged(object sender, EventArgs e)
    {

    }

    protected void gvStudentRegister_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStudentRegister.PageIndex = e.NewPageIndex;
        BindGrid();


    }
    protected void gvStudentRegister_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            clear();
            string Id = Convert.ToString(e.CommandArgument);
            lblId.Text = Id;

            if (Convert.ToString(e.CommandName) == "Modify")
            {
                
                btnSave.Text = "Update";

                //Sql = " SELECT distinct   Adm_No,adm_date,First_Name, " +
                //   " Last_Name,Father_Name,DOB,Stud_MobNo,Parent_MobNo,StudAddress,WardNo,Area, " +
                //    " tblStudentRegister.CityId,Gender,Pincode,LoginId,CityMaster.CityName, CityMaster.CityId AS CityID1,  DistrictMaster.DistrictName,DistrictMaster.DistrictId, " +
                //    " StateMaster.StateName, StateMaster.StateId,  CountryMaster.CountryName, CountryMaster.CountryId  " +
                //   " FROM  tblStudentRegister,   CityMaster,  TalukaMaster ,   DistrictMaster,    StateMaster ,   CountryMaster  " +
                //  "  WHERE tblStudentRegister.TalukaID=CityMaster.CityId  " +
                //"  and  StateMaster.CountryId=CountryMaster.CountryId and DistrictMaster.StateId=StateMaster.StateId    " +
                //"  and    CityMaster.DistrictId=DistrictMaster.DistrictId and tblStudentRegister.SNO='" + lblId.Text + "' ";


                  Sql = "select * from tblStudentRegister where SNO='" + lblId.Text + "' ";
                ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtAdm_No.Text = Convert.ToString(ds.Tables[0].Rows[0]["Adm_No"]);
                    txtAdm_Date.Text = Convert.ToString(ds.Tables[0].Rows[0]["adm_date"]);
                    txtFN.Text = Convert.ToString(ds.Tables[0].Rows[0]["First_Name"]);
                    txtLN.Text = Convert.ToString(ds.Tables[0].Rows[0]["Last_Name"]);
                    txtFatherName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Father_Name"]);
                    txtDOB.Text = Convert.ToString(ds.Tables[0].Rows[0]["DOB"]);
                    txtCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["CityId"]);
                    txtArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["Area"]);
                    txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["StudAddress"]);
                    txtParaentMob_No.Text = Convert.ToString(ds.Tables[0].Rows[0]["Parent_MobNo"]);
                    txtPincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Pincode"]);
                    txtStudMob_No.Text = Convert.ToString(ds.Tables[0].Rows[0]["Stud_MobNo"]);
                    txtwardNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["WardNo"]);
                    string gender = Convert.ToString(ds.Tables[0].Rows[0]["Gender"]);
                    if (gender == "Boy")
                    {
                        rdoGender.SelectedValue = "0";
                    }
                    else
                        rdoGender.SelectedValue = "1";
                    //  string taluka = Convert.ToString(ds.Tables[0].Rows[0]["TalukaID"]);

                    //ddlState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["StateId"]);

                    //DataSet ds1 = location.GetAllDistrict(ddlState.SelectedValue.ToString());
                    //ddlDistrict.DataSource = ds1.Tables[0];
                    //ddlDistrict.DataTextField = "Name";
                    //ddlDistrict.DataValueField = "Id";

                    //ddlDistrict.DataBind();
                    //ddlDistrict.Items.Add("--Select--");
                    //ddlDistrict.SelectedIndex = ddlState.Items.Count - 1;
                    //ddlDistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["DistrictId"]);

                    //ds1 = location.GetAllCity(ddlDistrict.SelectedValue.ToString());
                    //ddlTaluka.DataSource = ds1.Tables[0];
                    //ddlTaluka.DataTextField = "Name";
                    //ddlTaluka.DataValueField = "Id";
                    //ddlTaluka.DataBind();
                    //ddlTaluka.Items.Add("--Select--");
                    //ddlTaluka.SelectedIndex = ddlTaluka.Items.Count - 1;
                    //ddlTaluka.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CityID1"]);

                }



            }
            if (Convert.ToString(e.CommandName) == "Delete")
            {
                Sql = "delete from tblStudentRegister where SNO='" + lblId.Text + "' ";
                status = cc.ExecuteNonQuery(Sql);
                if (status == 1)
                {
                    clear();
                    BindGrid();
                    recordcount();
                    lblError.Visible = true;
                    lblError.Text = "Record deleted successfuly  !!!!";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record deleted successfuly !!!!')", true);
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Record not deleted !!!!";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record not deleted !!!!')", true);
                }
            }
        }
        catch(Exception ex)
        {
           // throw;
        }
    }
    protected void gvStudentRegister_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvStudentRegister_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvStudentRegister_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void btnInstru_Click(object sender, EventArgs e)
    {
        try
        {

            Sql = "insert into tblfamilyDetails (Relation,Rel_Name,Education,Occupation,Age,StudentRegSNO) values " +
                " ('" + txtRelation.Text + "','" + txtRelName.Text + "','" + txtEducation.Text + "','" + txtOccupation.Text + "','" + txtAge.Text + "', " + Convert.ToInt32(lblSNo1.Text) + ") ";
            status = cc.ExecuteNonQuery(Sql);
            if (status == 1)
            {
                clearFamily();
                BingFamily();



                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Family Details Submitted successfuly !!!!')", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Family Details not Submitted !!!!')", true);

            }

        }
        catch
        {

        }

        Button11.Visible = true;
        ImageButton btndetails = new ImageButton();
        btndetails.ID = "Button11";
        ModalPopupExtender1.TargetControlID = btndetails.ID;
        this.ModalPopupExtender1.Show();
        //// Button11.Visible = false;
    }

    public void clearFamily()
    {
        txtAge.Text = "";
        txtEducation.Text = "";
        txtOccupation.Text = "";
        txtRelation.Text = "";
        txtRelName.Text = "";
        lblid2.Text = "";
    }

    public void BingFamily()
    {
        Sql = "select * from tblfamilyDetails where StudentRegSNO=" + Convert.ToInt32(lblSNo1.Text) + " ";
        ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvFamilyDetails.DataSource = ds.Tables[0];
            gvFamilyDetails.DataBind();
        }
    }

    protected void btnclose0_Click(object sender, EventArgs e)
    {
        txtAge.Text = "";
        txtEducation.Text = "";
        txtOccupation.Text = "";
        txtRelation.Text = "";
        txtRelName.Text = "";
        lblid2.Text = "";

        Button11.Visible = true;
        ImageButton btndetails = new ImageButton();
        btndetails.ID = "Button11";
        ModalPopupExtender1.TargetControlID = btndetails.ID;
        this.ModalPopupExtender1.Show();

    }
    protected void gvFamilyDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblid2.Text = Convert.ToString(e.CommandArgument);
            if (Convert.ToString(e.CommandName) == "Delete")
            {
                Sql = "delete from tblfamilyDetails where SNO='" + lblid2.Text + "' ";
                status = cc.ExecuteNonQuery(Sql);
                if (status == 1)
                {
                    clearFamily();
                    BingFamily();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Family Details deleted successfuly !!!!')", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Family Details not deleted !!!!')", true);
                }
                Button11.Visible = true;
                ImageButton btndetails = new ImageButton();
                btndetails.ID = "Button11";
                ModalPopupExtender1.TargetControlID = btndetails.ID;
                this.ModalPopupExtender1.Show();
            }
        }
        catch
        {
        }

    }
    protected void gvFamilyDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void txtAdm_No_TextChanged(object sender, EventArgs e)
    {

        if (txtAdm_No.Text == "")
        {

        }
        else
        {
            string Id = Convert.ToString(Session["ClassSetting_id"]);
            Sql = " select  Adm_No from tblStudentRegister where Adm_No='"+txtAdm_No.Text+"' and  ClassSetting_id='" + Id + "' and  LoginId='" + Convert.ToString(Session["LoginId"]) + "' ";
             string Adm_No = Convert.ToString(cc.ExecuteScalar(Sql));

             if (!String.IsNullOrEmpty(Adm_No)  )
             {
                 txtAdm_No.ForeColor = System.Drawing.Color.Red;
                 ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Admission No is already exist')", true);

             }
             else
             {
                 txtAdm_No.ForeColor = System.Drawing.Color.Black;
             }
        }
    
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        string Id1 = Convert.ToString(Request.QueryString["Id"]);
        Response.Redirect("StudentmdbFileUpload.aspx?Id=" + Id1);
    }
}
