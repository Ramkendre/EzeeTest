using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_AssignMenu : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {  
        if (!IsPostBack)
        {
            string RoleId = Convert.ToString(Request.QueryString["Id"]);
            this.getInitialData(RoleId);
        }
        this.Set_Page_Level_Setting();
    }
    protected void Set_Page_Level_Setting()
    {
        //set page heading
        Label lblMainHeading = (Label)Master.FindControl("lblMainHeading");
        if (lblMainHeading != null)
            lblMainHeading.Text = "Assign the Menu";
    }

    private void getInitialData(string RoleId)
    {
        //For Loading parent Menu
        string Sql = "Select MenuId, MenuName from Menu where ParentId=-1";
        try
        {
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlParent.DataSource = ds.Tables[0];
            ddlParent.DataValueField = "MenuId";
            ddlParent.DataTextField = "MenuName";
            ddlParent.DataBind();
            ddlParent.Items.Add("--Select--");
            ddlParent.SelectedIndex = ddlParent.Items.Count - 1;
        }
        catch(Exception ex){}

        //For Loading the initial menu
        Sql = "Select RoleId, RoleName,MenuId from Role where RoleId="+RoleId +"";
        try
        {
            DataSet ds = cc.ExecuteDataset(Sql);
            txtRoleName.Text = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
            string MenuId = Convert.ToString(ds.Tables[0].Rows[0]["MenuId"]);

            MenuId = MenuId.Replace(",", "','");
            Sql = "Select MenuId, MenuName from Menu where MenuId in('" + MenuId + "') ";
            ds = cc.ExecuteDataset(Sql);
            lstAssignedMenu.DataSource = ds.Tables[0];
            lstAssignedMenu.DataTextField = "MenuName";
            lstAssignedMenu.DataValueField = "MenuId";
            lstAssignedMenu.DataBind();
        }
        catch { }
    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Role.aspx");
    }
    protected void ddlParent_SelectedIndexChanged(object sender, EventArgs e)
    {
        
       try
        {
           // string Sql = "Select MenuId, MenuName from Menu where ParentId ="+ddlParent.SelectedValue +" ";
          // ATUL BY 22 .10.13
                    string Sql = "Select MenuId, MenuName from Menu where ParentId =" + ddlParent.SelectedValue + " OR MenuId=" + ddlParent.SelectedValue + " ";
            DataSet ds = cc.ExecuteDataset(Sql);
             lstMainMenu.DataSource = ds.Tables[0];
            lstMainMenu.DataTextField = "MenuName";
            lstMainMenu.DataValueField = "MenuId";
            lstMainMenu.DataBind();
        }
        catch 
        { }
    }
    protected void btnRight_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (ListItem lst in lstMainMenu.Items)
            {
                if (lst.Selected)
                {
                    int flag = 0;
                    foreach (ListItem lst1 in lstAssignedMenu.Items)
                    {
                        if (lst.Value == lst1.Value)
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                    {
                        lstAssignedMenu.Items.Add(lst);
                    }
                }
            }
        }
        catch 
        { }
    }
    protected void btnLeft_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (ListItem lst in lstAssignedMenu.Items)
            {
                if (lst.Selected)
                {
                    lstAssignedMenu.Items.Remove(lst);
                }
            }
        }
        catch (Exception ex)
        { }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
        if (lstAssignedMenu.Items.Count==0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select atleast one Menu')", true);
            lblError.Visible = true;
            lblError.Text = "Please Select atleast one menu";
        }
        else
        {
            try
            {
                string MenuId = "";
                foreach (ListItem lst in lstAssignedMenu.Items)
                {
                    MenuId = MenuId + "," + lst.Value.ToString();
                }
                if (MenuId.Length > 1)
                {
                    MenuId = MenuId.Substring(1);
                }
                    string RoleId = Convert.ToString(Request.QueryString["Id"]);

                string Sql = "Update Role set MenuId='" + MenuId + "' where RoleId=" + RoleId + "";
                int count = cc.ExecuteNonQuery(Sql);
                if (count == 1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Role Updated successfully')", true);
                    lblError.Visible = true;
                    lblError.Text = "Role Updated successfully.";
                }
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Role Updated successfully')", true);
                lblError.Visible = true;
                lblError.Text = "Role Updated successfully.";
                lstAssignedMenu.Text = "";
            }
        }
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Role.aspx");
    }
    protected void btnExit_Click1(object sender, EventArgs e)
    {

    }
    protected void lstMainMenu_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
