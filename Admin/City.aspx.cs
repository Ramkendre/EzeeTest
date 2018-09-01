using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;


public partial class Admin_City : System.Web.UI.Page
{
    Location location = new Location();
    CommonCode cc = new CommonCode();
    string language;
    int flag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = location.GetAllState();
            ddlState.DataSource = ds.Tables[0];
            ddlState.DataTextField = "Name";
            ddlState.DataValueField = "Id";

            ddlState.DataBind();
            ddlState.Items.Add("--Select--");
            ddlState.SelectedIndex = ddlState.Items.Count - 1;
            ListControlCollections();
            pnl_grade.Visible = false;
        }
        Set_Page_Level_Setting();
    }

    protected void Set_Page_Level_Setting()
    {
        //set page heading
        Label lblMainHeading = (Label)Master.FindControl("lblMainHeading");
        if (lblMainHeading != null)
            lblMainHeading.Text = "City Master - Village master";
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string Id = Convert.ToString(lblId.Text.ToString());

        if (Id == "" || Id == null)
        {
            AddNew();
        }
        else
        {
            Update(Id);
        }
    }
    public void panel()
    {
        chkcitylist.Items.Clear();
        pnl_grade.Visible = false;
        chkdata.Checked = false;
    }
    private void AddNew()
    {
        CommonCode cc = new CommonCode();
        try
        {
            if (chkdata.Checked == true)
            {

                for (int i = 0; i < chkcitylist.Items.Count; i++)
                {
                    if (chkcitylist.Items[i].Selected == true)
                    {
                        string Sql = "Select TalukaID from TalukaMaster where TalukaName='" + chkcitylist.Items[i].Text + "' And TalukaID =" + ddltaluka.SelectedValue + "";
                        string Id = Convert.ToString(cc.ExecuteScalar(Sql));
                        if (!(Id == null || Id == ""))
                        {
                            lblError.Visible = true;
                            lblError.Text = "This Name is already exist";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                        }
                        else
                        {
                            Sql = "Insert into TalukaMaster(TalukaName, Cityid) Values (N'" + chkcitylist.Items[i].Text + "'," + ddltaluka.SelectedValue.ToString() + ") ";
                            flag = cc.ExecuteNonQuery(Sql);
                        }
                    }
                }
                if (flag == 1)
                {
                    panel();
                    lblError.Visible = true;
                    lblError.Text = "City/Village Added Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('City/Village added successfully')", true);
                    //Response.Redirect("State.aspx");
                    DataSet ds = location.GetAllTaluka(ddltaluka.SelectedValue.ToString());
                    gvCity.DataSource = ds.Tables[0];
                    gvCity.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select at least one City/Village')", true);


                }

            }
            else
            {
                if (ddlState.SelectedIndex == ddlState.Items.Count - 1)
                {
                    lblError.Visible = true;
                    lblError.Text = "Please Select the State";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select the State')", true);

                }
                else if (ddlDistrict.SelectedIndex == ddlDistrict.Items.Count - 1)
                {
                    lblError.Visible = true;
                    lblError.Text = "Please Select the District";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select the District')", true);

                }
                else if (ddltaluka.SelectedIndex == ddltaluka.Items.Count - 1)
                {
                    lblError.Visible = true;
                    lblError.Text = "Please Select the Taluka";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select the Taluka')", true);

                }
                else if (txtCityName.Text == "")
                {
                    lblError.Visible = true;
                    lblError.Text = "Please Enter the City/Village Name";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the City/Village Name')", true);
                }

                else
                {
                    string Sql = "Select TalukaID from TalukaMaster where TalukaName='" + txtCityName.Text.ToString() + "' And TalukaId =" + ddltaluka.SelectedValue + "";
                    string Id = Convert.ToString(cc.ExecuteScalar(Sql));
                    if (!(Id == null || Id == ""))
                    {
                        lblError.Visible = true;
                        lblError.Text = "This Name is already exist";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                    }
                    else
                    {
                        Sql = "Insert into TalukaMaster(TalukaName, Cityid) Values (N'" + txtCityName.Text + "'," + ddltaluka.SelectedValue.ToString() + ") ";
                        int flag = cc.ExecuteNonQuery(Sql);
                        txtCityName.Text = "";
                        lblError.Visible = true;
                        lblError.Text = "City/Village Added Successfully";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('City/Village added successfully')", true);
                        //Response.Redirect("State.aspx");
                        DataSet ds = location.GetAllTaluka(ddltaluka.SelectedValue.ToString());
                        gvCity.DataSource = ds.Tables[0];
                        gvCity.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('City/Village not added')", true);
        }
    }
    private void Update(string Id)
    {
        CommonCode cc = new CommonCode();
        try
        {
            if (ddlDistrict.SelectedIndex == ddlDistrict.Items.Count - 1)
            {
                lblError.Visible = true;
                lblError.Text = "Please Select the District";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select District')", true);
            }
            else if (ddltaluka.SelectedIndex == ddltaluka.Items.Count - 1)
            {
                lblError.Visible = true;
                lblError.Text = "Please Select the Taluka";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Taluka')", true);
            }
            else if (txtCityName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the City/Village  Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the City/Village Name')", true);
            }
            else
            {
                string Sql = "Select TalukaId from Talukamaster where TalukaName='" + txtCityName.Text.ToString() + "' and TalukaID<>" + Id + "";
                string Id1 = Convert.ToString(cc.ExecuteScalar(Sql));
                if (!(Id1 == null || Id1 == ""))
                {
                    lblError.Visible = true;
                    lblError.Text = "This Name is already exist";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                }
                else
                {
                    Sql = "Update TalukaMaster set TalukaName=N'" + txtCityName.Text.ToString() + "' , " +
                        " CityId=" + ddlDistrict.SelectedValue.ToString() + " where Talukaid=" + Id + "  ";
                    int flag = cc.ExecuteNonQuery(Sql);
                    txtCityName.Text = "";
                    lblError.Visible = true;
                    lblError.Text = "City/Village updated Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('City/Village updated successfully')", true);
                    //Response.Redirect("State.aspx");
                    DataSet ds = location.GetAllCity(ddltaluka.SelectedValue);
                    gvCity.DataSource = ds.Tables[0];
                    gvCity.DataBind();
                    lblId.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('City/Village not Updated')", true);
        }
    }
    protected void gvCity_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCity.PageIndex = e.NewPageIndex;
        DataSet ds = location.GetAllTaluka(ddltaluka.SelectedValue);
        gvCity.DataSource = ds.Tables[0];
        gvCity.DataBind();
    }
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;
        if (Convert.ToString(e.CommandName) == "Modify")
        {

            string Sql = "Select talukaId, TalukaName, CityId from TalukaMaster where TalukaId=" + Id + "";
            try
            {
                DataSet ds = cc.ExecuteDataset(Sql);
                txtCityName.Text = Convert.ToString(ds.Tables[0].Rows[0]["TalukaName"]);
            }
            catch (Exception ex)
            { }
        }
        else if (Convert.ToString(e.CommandName) == "Delete")
        {
            string Sql3 = "Select companyid from CompanyMaster where  Taluka='" + Id + "'";
            string Id3 = Convert.ToString(cc.ExecuteScalar(Sql3));
            string Sql4 = "Select AddmissionId from AddmissionMaster where  City='" + Id + "' or LCity='" + Id + "'";
            string Id4 = Convert.ToString(cc.ExecuteScalar(Sql4));
            string Sql5 = "Select empid from Employee where   PCityId='" + Id + "' or LCityId='" + Id + "'";
            string Id5 = Convert.ToString(cc.ExecuteScalar(Sql5));
            if (!(Id3 == null || Id3 == "") && (Id4 == null || Id4 == "") && (Id5 == null || Id5 == ""))
            {
                lblError.Visible = true;
                lblError.Text = "This record reference use Other Location";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This record reference use Other Location')", true);
            }
            else
            {
                string Sql = "Delete from TalukaMaster where TalukaId=" + Id + "";
                try
                {
                    cc.ExecuteNonQuery(Sql);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('City/Village deleted successfully')", true);
                    DataSet ds = location.GetAllCity(ddltaluka.SelectedValue);
                    gvCity.DataSource = ds.Tables[0];
                    gvCity.DataBind();
                }
                catch (Exception ex)
                { }
            }
        }
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex == ddlState.Items.Count - 1)
        {
            ddlDistrict.DataSource = null;
            ddlDistrict.DataBind();
        }
        else
        {
            DataSet ds = location.GetAllDistrict(ddlState.SelectedValue.ToString());
            ddlDistrict.DataSource = ds.Tables[0];
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "Id";

            ddlDistrict.DataBind();
            ddlDistrict.Items.Add("--Select--");
            ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
        }
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDistrict.SelectedIndex == ddlDistrict.Items.Count - 1)
            {
                gvCity.DataSource = "";
                gvCity.DataBind();
            }
            else
            {
                DataSet ds = location.GetAllCity(ddlDistrict.SelectedValue.ToString());
                ddltaluka.DataSource = ds.Tables[0];
                ddltaluka.DataTextField = "Name";
                ddltaluka.DataValueField = "Id";

                ddltaluka.DataBind();
                ddltaluka.Items.Add("--Select--");
                ddltaluka.SelectedIndex = ddltaluka.Items.Count - 1;
                //gvCity.DataSource = ds.Tables[0];
                //gvCity.DataBind();
                //panel();
                //txtCityName.Text = "";
            }
        }
        catch { }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
        ddlState.SelectedIndex = ddlState.Items.Count - 1;
        ddltaluka.SelectedIndex = ddltaluka.Items.Count - 1;
        txtCityName.Text = "";
        lblId.Text = "";
    }
    protected void gvCity_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
    private void ListControlCollections()
    {
        ArrayList controlList = new ArrayList();

        // AddControls(Page.Controls, controlList);
        if (Convert.ToString(Session["Marathi"]) == null || Convert.ToString(Session["Marathi"]) == "Marathi")
        {
            language = "Marathi";
        }
        else if (Convert.ToString(Session["English"]) == null || Convert.ToString(Session["English"]) == "English")
        {
            language = "English";

        }
        //cc.AddControls(Page.Controls, controlList, language);

    }



    protected void gvCity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //getting username from particular row
            string username = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Name"));
            //identifying the control in gridview
            //raising javascript confirmationbox whenver user clicks on link button 
            ImageButton btnimg = (ImageButton)e.Row.FindControl("ImageButton2");
            btnimg.Attributes.Add("onclick", "javascript:return ConfirmationBox('" + username + "')");

        }
    }
    protected void txtCityName_TextChanged(object sender, EventArgs e)
    {
        chkdata.Checked = false;
    }
    protected void chkdata_CheckedChanged(object sender, EventArgs e)
    {
        if (ddltaluka.SelectedIndex == ddltaluka.Items.Count - 1)
        {
            lblError.Visible = true;
            lblError.Text = "Please Select the Taluka";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Taluka')", true);
        }
        else
        {
            if (chkdata.Checked == true)
            {
                pnl_grade.Visible = true;
                DataSet ds = location.GetAllTaluka_default(ddltaluka.SelectedItem.Text);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    chkcitylist.DataSource = ds.Tables[0];
                    chkcitylist.DataTextField = "Name";
                    chkcitylist.DataValueField = "Id";
                    chkcitylist.DataBind();
                }
                if (chkcitylist.SelectedIndex == chkcitylist.Items.Count - 1)
                {
                    pnl_grade.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('City/Village Details Not Available')", true);
                }
                else
                {
                    pnl_grade.Visible = true;
                }
            }
            else
            {
                pnl_grade.Visible = false;

            }
        }
    }
    protected void ddltaluka_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltaluka.SelectedIndex == ddltaluka.Items.Count - 1)
        {
            lblError.Visible = true;
            lblError.Text = "Please Select the City/Village";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select City/Village')", true);
            gvCity.DataSource = null;
            gvCity.DataBind();
        }
        else
        {
            DataSet ds = location.GetAllTaluka(ddltaluka.SelectedValue);
            gvCity.DataSource = ds.Tables[0];
            gvCity.DataBind();
            panel();
            txtCityName.Text = "";
            chkdata0.Checked = false;
        }
    }
    protected void chkdata0_CheckedChanged(object sender, EventArgs e)
    {
        if (chkdata0.Checked == true)
        {
            for (int i = 0; i < chkcitylist.Items.Count; i++)
            {
                chkcitylist.Items[i].Selected = true;
            }
        }
        else
        {
            for (int i = 0; i < chkcitylist.Items.Count; i++)
            {
                chkcitylist.Items[i].Selected = false;
            }
        }
    }
}
