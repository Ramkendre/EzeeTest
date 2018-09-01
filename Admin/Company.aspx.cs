using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Company : System.Web.UI.Page
{
    Location location = new Location();
    CompanyBAL compbal = new CompanyBAL();
    CommonCode cc = new CommonCode();
    int status;
    DataSet ds = new DataSet();


    protected void Page_Load(object sender, EventArgs e)
    {
        string Id = Convert.ToString(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            DataSet ds = location.GetAllState();
            ddlState.DataSource = ds.Tables[0];
            ddlState.DataTextField = "Name";
            ddlState.DataValueField = "Id";

            ddlState.DataBind();
            ddlState.Items.Add("--Select--");
            ddlState.SelectedIndex = ddlState.Items.Count - 1;
            if (Id != "" && Id != null)
            {
                this.GetCompanyValue(Id);
            }

            string Role = Convert.ToString(Session["Role"]);
            txtAdmissionsQuota.Enabled = false;
            if (Role == "2")
                txtAdmissionsQuota.Enabled = true;

            txtMobile1.Text = Convert.ToString(Session["LoginId"]);

        }

        // this.Set_Page_Level_Setting(Id);
    }

    protected void Set_Page_Level_Setting(string Id)
    {
        //set page heading
        Label lblMainHeading = (Label)Master.FindControl("lblMainHeading");
        if (Id == "" || Id == null)
        {
            if (lblMainHeading != null)
                lblMainHeading.Text = "Add new College/School Details  ";
            btnSubmit.Text = " Save ";
            btnDelete.Visible = false;
        }
        else
        {
            if (lblMainHeading != null)
                lblMainHeading.Text = " Update College/School";
            btnSubmit.Text = " Update ";
            btnDelete.Visible = true;
        }
    }

    private void GetCompanyValue(string Id)
    {
        lblId.Text = Id;
        compbal.CompanyId1 = Convert.ToInt32(Id);

        DataSet ds = compbal._selectCompany(compbal);
        try
        {
            txtCompanyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
            txtDisplayName.Text = Convert.ToString(ds.Tables[0].Rows[0]["DisplayName"]);
            txtMobile1.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo1"]);

            txtPhone1.Text = Convert.ToString(ds.Tables[0].Rows[0]["PhoneNo1"]);

            txtFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["FaxNo"]);

            txtAddress1.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address1"]);

            txtCityName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompCityName"]);

            txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailId"]);
            txtPin.Text = Convert.ToString(ds.Tables[0].Rows[0]["PinCode"]);

            txtAdmissionsQuota.Text = Convert.ToString(ds.Tables[0].Rows[0]["AdmissionQuota"]);

            ddlState.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["StateId"]);

            DataSet ds1 = location.GetAllDistrict(ddlState.SelectedValue.ToString());
            ddlDistrict.DataSource = ds1.Tables[0];
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "Id";

            ddlDistrict.DataBind();
            ddlDistrict.Items.Add("--Select--");
            ddlDistrict.SelectedIndex = ddlState.Items.Count - 1;
            ddlDistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["DistrictId"]);

            ds1 = location.GetAllCity(ddlDistrict.SelectedValue.ToString());
            ddlTaluka.DataSource = ds1.Tables[0];
            ddlTaluka.DataTextField = "Name";
            ddlTaluka.DataValueField = "Id";
            ddlTaluka.DataBind();
            ddlTaluka.Items.Add("--Select--");
            ddlTaluka.SelectedIndex = ddlTaluka.Items.Count - 1;
            ddlTaluka.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TalukaId"]); //CityID1

            ds1 = location.GetAllTaluka(ddlTaluka.SelectedValue.ToString());
            ddlCity.DataSource = ds1.Tables[0];
            ddlCity.DataTextField = "Name";
            ddlCity.DataValueField = "Id";

            ddlCity.DataBind();
            ddlCity.Items.Add("--Select--");
            ddlCity.SelectedIndex = ddlCity.Items.Count - 1;
            ddlCity.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CityID1"]);//TalukaId
            lblId.Text = Id.ToString();
        }
        catch
        {

        }
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex == ddlState.Items.Count - 1)
        {
            ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
            ddlTaluka.SelectedIndex = ddlDistrict.Items.Count - 1;
            ddlCity.SelectedIndex = ddlCity.Items.Count - 1;
        }
        else
        {
            DataSet ds1 = location.GetAllDistrict(ddlState.SelectedValue.ToString());
            ddlDistrict.DataSource = ds1.Tables[0];
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "Id";

            ddlDistrict.DataBind();
            ddlDistrict.Items.Add("--Select--");
            ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
        }
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistrict.SelectedIndex == ddlDistrict.Items.Count - 1)
        {

            ddlTaluka.SelectedIndex = ddlDistrict.Items.Count - 1;
            ddlCity.SelectedIndex = ddlCity.Items.Count - 1;
        }
        else
        {
            // city means taluka in database  so use getallcity()
            DataSet ds1 = location.GetAllCity(ddlDistrict.SelectedValue.ToString());
            ddlTaluka.DataSource = ds1.Tables[0];
            ddlTaluka.DataTextField = "Name";
            ddlTaluka.DataValueField = "Id";

            ddlTaluka.DataBind();
            ddlTaluka.Items.Add("--Select--");
            ddlTaluka.SelectedIndex = ddlTaluka.Items.Count - 1;
        }
    }

    protected void ddlTaluka_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTaluka.SelectedIndex == ddlTaluka.Items.Count - 1)
        {

            ddlCity.SelectedIndex = ddlCity.Items.Count - 1;
        }
        else
        {
            // taluka means city in database 
            DataSet ds1 = location.GetAllTaluka(ddlTaluka.SelectedValue.ToString());
            ddlCity.DataSource = ds1.Tables[0];
            ddlCity.DataTextField = "Name";
            ddlCity.DataValueField = "Id";

            ddlCity.DataBind();
            ddlCity.Items.Add("--Select--");
            ddlCity.SelectedIndex = ddlCity.Items.Count - 1;
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //change on 11.02.14
        string GayatriMam = Convert.ToString(Session["LoginId"]);

        string companyID = Convert.ToString(Session["CompanyId"]);

        if (GayatriMam == "7588419504" || companyID != "16")
        {
            string Id = Convert.ToString(Request.QueryString["Id"]);
            if (Id == "" || Id == null)
            {
                AddNew();
            }
            else
            {
                Update(Id);
            }
        }
    }

    private void AddNew()
    {
        try
        {
            if (txtCompanyName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the College/School Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the College/School Name')", true);
            }
            else if (txtDisplayName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the Display Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the Display Name')", true);
            }
            else if (txtMobile1.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the Mobile No1";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Mobile No1')", true);
            }

            //else if (ddlCity.SelectedIndex == ddlCity.Items.Count - 1)
            //{
            //    lblError.Visible = true;
            //    lblError.Text = "Please Select the City";
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select the city')", true);
            //}

            else if (txtCityName.Text == "" || txtCityName.Text == null)
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter CityName.";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter CityName.')", true);
            }

            else
            {
                string Sql = "Select CompanyId from CompanyMaster where MobileNo1='" + Convert.ToString(Session["LoginId"]) + "' ";
                string Id = Convert.ToString(cc.ExecuteScalar(Sql));
                if (!(Id == null || Id == ""))
                {
                    lblError.Visible = true;
                    lblError.Text = "This Company Name is already exist";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This College/School is already exist')", true);
                }
                else
                {
                    compbal.CompanyName1 = txtCompanyName.Text;
                    compbal.DisplayName1 = txtDisplayName.Text;
                    compbal.Address1 = txtAddress1.Text;

                    //  compbal.City = Convert.ToInt32(ddlCity.SelectedValue);
                    compbal.CityName = txtCityName.Text.Trim();
                    compbal.Pincode = txtPin.Text;
                    compbal.Mobile1 = txtMobile1.Text;
                    compbal.StateId = Convert.ToInt32(ddlState.SelectedValue);
                    compbal.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
                    compbal.TalukaId = Convert.ToInt32(ddlTaluka.SelectedValue);
                    compbal.Phone1 = txtPhone1.Text;

                    compbal.Emailid = txtEmail.Text;
                    compbal.Faxno = txtFax.Text;
                    compbal.AdmissionQuota1 = Convert.ToInt32(txtAdmissionsQuota.Text);

                    status = compbal._insertCompany(compbal);

                    if (status >= 1)
                    {
                        Sql = " SELECT CompanyId FROM CompanyMaster WHERE MobileNo1='" + Convert.ToString(Session["LoginId"]) + "' ";
                        string Companyid = Convert.ToString(cc.ExecuteScalar(Sql));
                        Session["CompanyId"] = Companyid;
                        Session["DisplayName"] = txtDisplayName.Text;

                        Sql = " UPDATE Login SET CompanyId='" + Companyid + "'  WHERE LoginId='" + Convert.ToString(Session["LoginId"]) + "' ";
                        status = cc.ExecuteNonQuery(Sql);
                        if (status >= 1)
                        {

                            lblError.Visible = true;
                            lblError.Text = "College/School Added Successfully";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('College/School Added Successfully')", true);
                            clear();
                            Response.Redirect("CompanyList.aspx?Flag=S ");
                        }
                        else
                        {
                            lblError.Visible = true;
                            lblError.Text = "Cant Add the College/School";
                            clear();
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Cant Add the College/School')", true);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
    }

    private void Update(string Id1)
    {
        try
        {
            if (txtCompanyName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the College/School Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the College/School Name')", true);
            }
            else if (txtDisplayName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the Display Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the Display Name')", true);
            }

            //else if (ddlCity.SelectedIndex == ddlCity.Items.Count - 1)
            //{
            //    lblError.Visible = true;
            //    lblError.Text = "Please Select the City";
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select the city')", true);
            //}

            else if (txtCityName.Text == "" || txtCityName.Text == null)
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter CityName.";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter CityName.')", true);
            }
            else
            {
                string Sql = "Select CompanyId from CompanyMaster where   MobileNo1='" + Convert.ToString(Session["LoginId"]) + "'   and CompanyId<>" + Id1 + "";
                string Id = Convert.ToString(cc.ExecuteScalar(Sql));
                if (!(Id == null || Id == ""))
                {
                    lblError.Visible = true;
                    lblError.Text = "This College/School Name is already exist";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This College/School Name is already exist')", true);
                }
                else
                {
                    compbal.CompanyId1 = Convert.ToInt32(Id1);

                    compbal.CompanyName1 = txtCompanyName.Text;
                    compbal.DisplayName1 = txtDisplayName.Text;
                    compbal.Address1 = txtAddress1.Text;

                    // compbal.City = Convert.ToInt32(ddlCity.SelectedValue);
                    compbal.CityName = txtCityName.Text.Trim();
                    compbal.Pincode = txtPin.Text;
                    compbal.Mobile1 = txtMobile1.Text;
                    compbal.StateId = Convert.ToInt32(ddlState.SelectedValue);
                    compbal.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
                    compbal.TalukaId = Convert.ToInt32(ddlTaluka.SelectedValue);
                    compbal.Phone1 = txtPhone1.Text;

                    compbal.Emailid = txtEmail.Text;
                    compbal.Faxno = txtFax.Text;

                    if (txtAdmissionsQuota.Text == "")
                        txtAdmissionsQuota.Text = "0";

                    compbal.AdmissionQuota1 = Convert.ToInt32(txtAdmissionsQuota.Text);
                    status = compbal._updateCompany(compbal);

                    if (status == 1)
                    {
                        lblError.Visible = true;
                        lblError.Text = "College/School Updated Successfully";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert(' update the College/School sucessfully')", true);
                        clear();
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Cant update the College/School";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Cant update the College/School')", true);
                    }
                }
            }
        }

        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string Id = Convert.ToString(Request.QueryString["Id"]);
        try
        {
            compbal.CompanyId1 = Convert.ToInt32(Id);
            status = compbal._deleteCompany(compbal);

            if (status == 1)
            {
                lblError.Text = "College/School deactivated Successfully";
                lblError.Visible = true;
                clear();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('College/School  deactivated successfully')", true);
            }
            else
            {
                lblError.Text = "Cant deactivate College/School";
                lblError.Visible = true;

                Response.Redirect("CompanyList.aspx?Flag=D ");
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Can not deactivate College/School";
            lblError.Visible = true;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('ex. This record reference use Other Location')", true);
            Response.Write("<h4>" + ex.Message);
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Server.Transfer("CompanyList.aspx");
    }

    public void clear()
    {
        txtCompanyName.Text = "";
        txtDisplayName.Text = "";
        txtAddress1.Text = "";
        txtCityName.Text = "";
        txtEmail.Text = "";
        txtFax.Text = "";
        txtMobile1.Text = "";

        txtPhone1.Text = "";

        txtPin.Text = "";
        ddlCity.SelectedIndex = ddlCity.Items.Count - 1;
        ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
        ddlState.SelectedIndex = ddlState.Items.Count - 1;

        ddlTaluka.Items.Clear();

    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

}



