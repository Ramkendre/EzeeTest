using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;


public partial class SubAdmin_Advertisement : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            LoadState();
    }
    public void LoadState()
    {
        sql = "Select DISTINCT StateId,StateName, 'India' as CountryName from StateMaster Order by StateName  ";
        DataSet ds = cc.ExecuteDataset(sql);

        ddlStateName.DataSource = ds.Tables[0];
        ddlStateName.DataTextField = "StateName";
        ddlStateName.DataValueField = "StateId";
        ddlStateName.DataBind();

        ddlStateName.Items.Add("--Select--");
        ddlStateName.SelectedIndex = ddlStateName.Items.Count - 1;
        ddlDistrictName.Items.Add("--Select--");
        ddlDistrictName.SelectedIndex = ddlDistrictName.Items.Count - 1;
    }
    protected void rdoAdvType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoAdvType.SelectedValue == "0")
        {
            ImgUpload.Visible = false;
            txtText.Visible = true;
        }
        else
        {
            txtText.Visible = false;
            ImgUpload.Visible = true;
        }
    }
    public void AddNew()
    {
        try
        {
            if (ddlStateName.SelectedValue == "--Select--")
            {
                lblError.Visible = true;
                lblError.Text = "Select State Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select State Name')", true);
            }
            else if (ddlDistrictName.SelectedValue == "")
            {
                lblError.Visible = true;
                lblError.Text = "Select District Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select District Name')", true);
            }
            else if (rdoAdvType.SelectedValue == "")
            {
                lblError.Visible = true;
                lblError.Text = "Select any one Content Type";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select any one Content Type')", true);
            }
            else
            {
                if (rdoAdvType.SelectedValue == "0")
                {
                    string sql = "INSERT INTO tblAdvertise ([StateId],StateName,[DistrictId],DistrictName,[AddType],[AdvContent],[InsertDate]) VALUES ('" + ddlStateName.SelectedValue + "','" + ddlStateName.SelectedItem.Text + "','" + ddlDistrictName.SelectedValue + "','" + ddlDistrictName.SelectedItem.Text + "'," + rdoAdvType.SelectedValue + ",'" + txtText.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";

                    int result = Convert.ToInt32(cc.ExecuteNonQuery(sql));
                    if (result > 0)
                    {
                        lblError.Text = "Record Saved successfully.";
                        lblError.Visible = true;
                        BindGridAdvertise();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Saved successfully.')", true);
                    }
                }
                else
                {
                    string imageValue = string.Empty;
                    if (ImgUpload.HasFile)
                    {
                        Stream fs = ImgUpload.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        imageValue = Convert.ToBase64String(bytes);
                    }

                    string sql = "INSERT INTO tblAdvertise ([StateId],StateName,[DistrictId],DistrictName,[AddType],[AdvContent],[InsertDate]) VALUES ('" + ddlStateName.SelectedValue + "','" + ddlStateName.SelectedItem.Text + "','" + ddlDistrictName.SelectedValue + "','" + ddlDistrictName.SelectedItem.Text + "'," + rdoAdvType.SelectedValue + ",'" + imageValue + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";

                    int result = Convert.ToInt32(cc.ExecuteNonQuery(sql));
                    if (result > 0)
                    {
                        lblError.Text = "Record Saved successfully.";
                        lblError.Visible = true;
                        BindGridAdvertise();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Saved successfully.')", true);
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);

        }
    }
    public void Update(string id)
    {
        try
        {
            if (ddlStateName.SelectedValue == "--Select--")
            {
                lblError.Text = "Select State Name";
                lblError.Visible = true;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alter('Select State Name')", true);
            }
            else if (ddlDistrictName.SelectedValue == "")
            {
                lblError.Text = "Select District Name";
                lblError.Visible = true;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alter('Select District Name')", true);
            }
            else if (rdoAdvType.SelectedValue == "")
            {
                lblError.Text = "Select Content Type";
                lblError.Visible = true;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alter('Select Content Type')", true);
            }
            else
            {
                if (rdoAdvType.SelectedValue == "0")
                {
                    string sql = "UPDATE tblAdvertise SET StateId='" + ddlStateName.SelectedValue + "',StateName='" + ddlStateName.SelectedItem.Text + "',DistrictId='" + ddlDistrictName.SelectedValue + "',DistrictName='" + ddlDistrictName.SelectedItem.Text + "',AddType='" + rdoAdvType.SelectedValue + "',AdvContent='" + txtText.Text + "' WHERE Id='" + id + "'";
                    int result = Convert.ToInt32(cc.ExecuteNonQuery(sql));
                    if (result == 0)
                    {
                        lblError.Text = "Record not Update";
                        lblError.Visible = true;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alter('Record not Update')", true);
                        BindGridAdvertise();
                    }
                    else
                    {
                        lblError.Text = "Record Update Successfully";
                        lblError.Visible = true;
                        BindGridAdvertise();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alter('Record Update Successfully')", true);
                    }
                }
                else
                {
                    string imageValue = string.Empty;
                    if (ImgUpload.HasFile)
                    {
                        Stream fs = ImgUpload.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        imageValue = Convert.ToBase64String(bytes);
                    }

                    string sql = "UPDATE tblAdvertise SET StateId='" + ddlStateName.SelectedValue + "',StateName='" + ddlStateName.SelectedItem.Text + "',DistrictId='" + ddlDistrictName.SelectedValue + "',DistrictName='" + ddlDistrictName.SelectedItem.Text + "',AddType='" + rdoAdvType.SelectedValue + "',AdvContent='" + imageValue + "' WHERE Id='" + id + "'";
                    int result = Convert.ToInt32(cc.ExecuteNonQuery(sql));
                    if (result == 0)
                    {
                        lblError.Text = "Record not Update";
                        lblError.Visible = true;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alter('Record not Update')", true);
                        BindGridAdvertise();
                    }
                    else
                    {
                        lblError.Text = "Record Update Successfully";
                        lblError.Visible = true;
                        BindGridAdvertise();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alter('Record Update Successfully')", true);
                    }
                }
            }
        }
        catch(Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string id = Convert.ToString(lblId.Text);
        if (id == "" || id == null)
        {
            AddNew();
        }
        else
        {
            Update(id);
        }
    }

    protected void ddlDistrictName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        string dId = Convert.ToString(ddlStateName.SelectedValue);

        sql = "Select Distinct DistrictId,DistrictName from DistrictMaster where StateId='" + dId + "' ";
        DataSet ds = cc.ExecuteDataset(sql);

        ddlDistrictName.DataSource = ds.Tables[0];
        ddlDistrictName.DataTextField = "DistrictName";
        ddlDistrictName.DataValueField = "DistrictId";
        ddlDistrictName.DataBind();

        BindGridAdvertise();
    }
    public void BindGridAdvertise()
    {
        string sql = " SELECT Id,StateId,StateName,DistrictName,AdvContent FROM tblAdvertise";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvAdvertise.DataSource = ds.Tables[0];
            gvAdvertise.DataBind();
            gvAdvertise.Visible = true;
        }
        else
        {
            gvAdvertise.DataSource = ds.Tables[0];
            gvAdvertise.DataSource = null;
        }
    }
    protected void gvAdvertise_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = Convert.ToString(e.CommandArgument);
        lblId.Text = id;
        if (Convert.ToString(e.CommandName) == "Modify")
        {
            btnAdd.Text = "Update";
            string sql = "SELECT StateName,DistrictName,AddType,AdvContent FROM tblAdvertise WHERE Id = '" + lblId.Text + "' ";
            DataSet ds = cc.ExecuteDataset(sql);
            try
            {
                ddlStateName.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["StateName"]);
                ddlDistrictName.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
                rdoAdvType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AddType"]);
                if (rdoAdvType.SelectedValue == "0")
                {
                    txtText.Visible = true;
                    ImgUpload.Visible = false;
                    imgmodify.Visible = false;
                    txtText.Text = Convert.ToString(ds.Tables[0].Rows[0]["AdvContent"]);
                }
                else
                {
                    imgmodify.Visible = true;
                    ImgUpload.Visible = true;
                    txtText.Visible = false;
                    imgmodify.ImageUrl = "~/AdvertiseImghandler.ashx?Id=" + id; 
                }
            }
            catch (Exception ex)
            {
                Response.Write("<h4>" + ex.Message);
            }
        }
        else if (Convert.ToString(e.CommandName) == "Delete")
        {
            try
            {
                string sql = "DELETE FROM tblAdvertise WHERE Id ='" + lblId.Text + "' ";
                int status = cc.ExecuteNonQuery(sql);
                if (status == 1)
                {
                    lblError.Text = "Record deleted Successfully";
                    lblError.Visible = true;
                    BindGridAdvertise();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Recored deleted successfully')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<h4>" + ex.Message);
            }
        }
    }
    protected void gvAdvertise_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("createtest.aspx");
    }
}