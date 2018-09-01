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

public partial class Admin_Talukamaster : System.Web.UI.Page
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
            lblMainHeading.Text = "District Master - Taluka/Block Master";
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
        chkstatelist.Items.Clear();
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

                for (int i = 0; i < chkstatelist.Items.Count; i++)
                {
                    if (chkstatelist.Items[i].Selected == true)
                    {
                        string Sql = "Select CityId from CityMaster where CityName='" + chkstatelist.Items[i].Text + "' And DistrictId =" + ddlDistrict.SelectedValue + "";
                        string Id = Convert.ToString(cc.ExecuteScalar(Sql));
                        if (!(Id == null || Id == ""))
                        {
                            lblError.Visible = true;
                            lblError.Text = "This Name is already exist";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                        }
                        else
                        {
                            Sql = "Insert into CityMaster(CityName, DistrictId) Values (N'" + chkstatelist.Items[i].Text + "'," + ddlDistrict.SelectedValue.ToString() + ") ";
                            flag = cc.ExecuteNonQuery(Sql);

                        }
                    }
                }
                if (flag == 1)
                {
                    panel();
                    lblError.Visible = true;
                    lblError.Text = "Taluka/Block Added Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Taluka/Block added successfully')", true);
                    //Response.Redirect("State.aspx");
                    DataSet ds = location.GetAllCity(ddlDistrict.SelectedValue.ToString());
                    gvCity.DataSource = ds.Tables[0];
                    gvCity.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select at least one Taluka/Block')", true);


                }

            }
            else
            {
                if (ddlDistrict.SelectedIndex == ddlDistrict.Items.Count - 1)
                {
                    lblError.Visible = true;
                    lblError.Text = "Please Select the District";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select the District')", true);

                }
                else if (txtCityName.Text == "")
                {
                    lblError.Visible = true;
                    lblError.Text = "Please Enter the Taluka/Block Name";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the Taluka/Block Name')", true);
                }
                else
                {
                    string Sql = "Select CityId from CityMaster where CityName='" + txtCityName.Text.ToString() + "' And DistrictId =" + ddlDistrict.SelectedValue + "";
                    string Id = Convert.ToString(cc.ExecuteScalar(Sql));
                    if (!(Id == null || Id == ""))
                    {
                        lblError.Visible = true;
                        lblError.Text = "This Name is already exist";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                    }
                    else
                    {
                        Sql = "Insert into CityMaster(CityName, DistrictId) Values (N'" + txtCityName.Text + "'," + ddlDistrict.SelectedValue.ToString() + ") ";
                        int flag = cc.ExecuteNonQuery(Sql);
                        txtCityName.Text = "";
                        lblError.Visible = true;
                        lblError.Text = "Taluka/Block Added Successfully";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Taluka/Block added successfully')", true);
                        //Response.Redirect("State.aspx");
                        DataSet ds = location.GetAllCity(ddlDistrict.SelectedValue.ToString());
                        gvCity.DataSource = ds.Tables[0];
                        gvCity.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('City not added')", true);
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
            else if (txtCityName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the Taluka/Block  Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the Taluka/Block Name')", true);
            }

            else
            {
                string Sql = "Select CityId from CityMaster where CityName='" + txtCityName.Text.ToString() + "' and CityId<>" + Id + "";
                string Id1 = Convert.ToString(cc.ExecuteScalar(Sql));
                if (!(Id1 == null || Id1 == ""))
                {
                    lblError.Visible = true;
                    lblError.Text = "This Name is already exist";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                }
                else
                {
                    Sql = "Update CityMaster set CityName=N'" + txtCityName.Text.ToString() + "' , " +
                        " DistrictId=" + ddlDistrict.SelectedValue.ToString() + " where CityId=" + Id + "  ";
                    int flag = cc.ExecuteNonQuery(Sql);
                    txtCityName.Text = "";
                    lblError.Visible = true;
                    lblError.Text = "Taluka/Block updated Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Taluka/Block updated successfully')", true);
                    //Response.Redirect("State.aspx");
                    DataSet ds = location.GetAllCity(ddlDistrict.SelectedValue);
                    gvCity.DataSource = ds.Tables[0];
                    gvCity.DataBind();
                    lblId.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Taluka/Block not Updated')", true);
        }
    }
    protected void gvCity_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCity.PageIndex = e.NewPageIndex;
        DataSet ds = location.GetAllCity(ddlDistrict.SelectedValue);
        gvCity.DataSource = ds.Tables[0];
        gvCity.DataBind();
    }
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;
        if (Convert.ToString(e.CommandName) == "Modify")
        {

            string Sql = "Select CityId, CityName, DistrictId from CityMaster where CityId=" + Id + "";
            try
            {
                DataSet ds = cc.ExecuteDataset(Sql);
                txtCityName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CityName"]);
            }
            catch (Exception ex)
            { }
        }
        else if (Convert.ToString(e.CommandName) == "Delete")
        {
            string Sql3 = "Select companyid from CompanyMaster where  cityid='" + Id + "'";
            string Id3 = Convert.ToString(cc.ExecuteScalar(Sql3));
            string Sql4 = "Select AddmissionId from AddmissionMaster where  Taluka='" + Id + "' or LTaluka='" + Id + "'";
            string Id4 = Convert.ToString(cc.ExecuteScalar(Sql4));
            string Sql5 = "Select empid from Employee where   PTaluka='" + Id + "' or LTaluka='" + Id + "'";
            string Id5 = Convert.ToString(cc.ExecuteScalar(Sql5));
            if (!(Id3 == null || Id3 == "") && (Id4 == null || Id4 == "") && (Id5 == null || Id5 == ""))
            {
                lblError.Visible = true;
                lblError.Text = "This record reference use Other Location";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This record reference use Other Location')", true);
            }

            else
            {
                string Sql = "Delete from CityMaster where CityId=" + Id + "";
                try
                {
                    cc.ExecuteNonQuery(Sql);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Taluka/Block  deleted successfully')", true);
                    DataSet ds = location.GetAllCity(ddlDistrict.SelectedValue);
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
                gvCity.DataSource = ds.Tables[0];
                gvCity.DataBind();
                panel();
                txtCityName.Text = "";
                chkdata0.Checked = false;
            }
        }
        catch { }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
        ddlState.SelectedIndex = ddlState.Items.Count - 1;
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
        if (ddlDistrict.SelectedIndex == ddlDistrict.Items.Count - 1)
        {
            lblError.Visible = true;
            lblError.Text = "Please Select the District";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select District')", true);
        }
        else
        {
            if (chkdata.Checked == true)
            {
                pnl_grade.Visible = true;
                DataSet ds = location.GetAllCity_default(ddlDistrict.SelectedItem.Text);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    chkstatelist.DataSource = ds.Tables[0];
                    chkstatelist.DataTextField = "Name";
                    chkstatelist.DataValueField = "Id";
                    chkstatelist.DataBind();
                }
                if (chkstatelist.SelectedIndex == chkstatelist.Items.Count - 1)
                {
                    pnl_grade.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Taluka/Block Details Not Available')", true);
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
    protected void chkdata0_CheckedChanged(object sender, EventArgs e)
    {
        if (chkdata0.Checked == true)
        {
            for (int i = 0; i < chkstatelist.Items.Count; i++)
            {
                chkstatelist.Items[i].Selected = true;
            }
        }
        else
        {
            for (int i = 0; i < chkstatelist.Items.Count; i++)
            {
                chkstatelist.Items[i].Selected = false;
            }
        }
    }
}
