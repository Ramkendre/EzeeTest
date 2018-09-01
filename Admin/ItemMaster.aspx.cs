using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;


public partial class Admin_ItemMaster : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string sql;
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadItemGroup();
        }
    }

    public void loadItemGroup()
    {
        try
        {
            string sql = "Select [tblItem].[Name],[tblItem].[ID] from [tblItem] where tblItem.ID=1 or tblItem.ID=2 or tblItem.ID=3 or tblItem.ID=4 or tblItem.ID=6 or tblItem.ID=7 or tblItem.ID=8  ";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(sql);
            ddlItem.DataSource = ds.Tables[0];
            ddlItem.DataTextField = "Name";

            ddlItem.DataValueField = "ID";
            ddlItem.DataBind();
            ddlItem.Items.Add("--Select--");
            ddlItem.SelectedIndex = ddlItem.Items.Count - 1;

        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
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
    public void AddNew()
    {
        try
        {
            if (txtItemName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Enter Item Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Item Name')", true);
            }
            else if (ddlItem.Text == "--Select--")
            {
                lblError.Visible = true;
                lblError.Text = "Select Item Group";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select item Group')", true);
            }
            else if (txtMobileNo.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Enter Mobile Number";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter  Mobile Number')", true);
            }
            else
            {
                string sql = "select ItemValueId as ID from tblItemValue where ItemId='" + ddlItem.SelectedValue + "' and Name='" + txtItemName.Text + "' ";
                string Id = Convert.ToString(cc.ExecuteScalar(sql));

                if (Id != "")
                {
                    lblError.Visible = true;
                    lblError.Text = "This Name is already exist";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                }
                else
                {
                    sql = "select max(ItemValueId)+1 from tblItemValue";
                    int ItemValueId = Convert.ToInt32(cc.ExecuteScalar(sql));

                    sql = "INSERT INTO tblItemValue (ItemValueId,ItemId,Name,MobileNo,[ItemValueIdNew]) VALUES (" + ItemValueId + ", '" + ddlItem.SelectedValue + "','" + txtItemName.Text + "','" + txtMobileNo.Text + "','" + ItemValueId + "')";

                    int result = Convert.ToInt32(cc.ExecuteNonQuery(sql));
                    if (result > 0)
                    {
                        BindgriditembyGroup();
                        lblError.Text = "Record Saved successfully.";
                        lblError.Visible = true;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Saved successfully.')", true);
                        Clear();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
    }
    public void Update(string Id)
    {
        try
        {
            if (txtItemName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Enter Item Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Item Name')", true);
            }
            else if (ddlItem.Text == "--Select--")
            {
                lblError.Visible = true;
                lblError.Text = "Select Item Group";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select item Group')", true);
            }
            else if (txtMobileNo.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Enter Mobile Number";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter  Mobile Number')", true);
            }
            else
            {
                sql = "update  tblItemValue set ItemId= '" + ddlItem.SelectedValue + "' ,Name='" + txtItemName.Text + "',MobileNo='" + txtMobileNo.Text + "' where ItemValueId=" + Id + " ";
                int result = Convert.ToInt32(cc.ExecuteNonQuery(sql));
                if (result == 0)
                {
                    lblError.Text = "Item Not Update";
                    lblError.Visible = true;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Item Not Update')", true);
                }
                else
                {
                    lblError.Text = "Item Updated Successfully";
                    lblError.Visible = true;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Item Updated Successfully')", true);
                    Clear();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
    }

    string ItemExist()
    {

        string sql = "select ItemValueId as ID from tblItemValue where ItemId='" + ddlItem.SelectedValue + "' and Name='" + txtItemName.Text + "' ";
        try
        {
            string Id = Convert.ToString(cc.ExecuteScalar(sql));

            return ID;
        }
        catch { return ID; }
        finally
        {
            con.Close();
        }


    }
    public void BindgriditembyGroup()
    {
        string sql = " select tblItemValue.ItemValueId ,tblItemValue.Name ,tblItemValue.MobileNo from  tblItemValue where ItemId='" + ddlItem.SelectedValue + "' order by ItemValueId DESC ";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();
            gvItem.Visible = true;
        }
        else
        {
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataSource = null;
        }

    }
    protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItem.PageIndex = e.NewPageIndex;
        BindgriditembyGroup();

    }
    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;
        if (Convert.ToString(e.CommandName) == "Modify")
        {
            btnSubmit.Text = "Update";

            string sql = "select tblItemValue.ItemId ,tblItemValue.Name,tblItemValue.MobileNo from  tblItemValue where  tblItemValue.ItemValueId='" + lblId.Text + "' ";
            ds = cc.ExecuteDataset(sql);
            try
            {
                ddlItem.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ItemId"]);
                txtItemName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                txtMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
            }
            catch (Exception ex)
            {
                Response.Write("<h4>" + ex.Message);
            }
        }
    }
    protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindgriditembyGroup();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
    public void Clear()
    {
        ddlItem.SelectedIndex = ddlItem.Items.Count - 1;
        lblId.Text = "";
        txtItemName.Text = "";
        txtMobileNo.Text = "";

        btnSubmit.Text = "Submit";
    }

    protected void gvItem_DataBound(object sender, EventArgs e)
    {

    }
}
