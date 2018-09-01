using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Admin_Role : System.Web.UI.Page
{
    Role role = new Role();
    CommonCode cc = new CommonCode();
    string language, refID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load();
            ListControlCollections();

        }
        Set_Page_Level_Setting();
    }

    public void load()
    {
        if ((Convert.ToString(Session["LoginId"]) == "ADMIN"))
        {
            show();
        }
        else
        {
            displya();
        }
    }
    protected void Set_Page_Level_Setting()
    {
        //set page heading
        Label lblMainHeading = (Label)Master.FindControl("lblMainHeading");
        if (lblMainHeading != null)
            lblMainHeading.Text = "Role Master";
    }

    public void displya()
    {
        string sql = "select ParentRole,RoleId,reference from role where RoleId='" + Convert.ToString(Session["Role"]) + "'";
        DataSet ds = cc.ExecuteDataset(sql);
        string roleid = Convert.ToString(ds.Tables[0].Rows[0]["RoleId"]);
        string underole = Convert.ToString(ds.Tables[0].Rows[0]["ParentRole"]);
        string refrence = Convert.ToString(ds.Tables[0].Rows[0]["reference"]);
        if (underole == "1")
        {

            sql = " SELECT r2.RoleId as Id,r2.RoleName as  Name, r2.Describ as Describtion, r1.RoleName AS PrentRolename " +
                  " FROM role r1 INNER JOIN role r2 ON r1.RoleId = r2.ParentRole  where r1.RoleId=r2.ParentRole and  r2.Parentrole='" + roleid + "' or r2.CollegeId=" + Convert.ToString(Session["CompanyId"]) + "";
        }
        else
        {
            sql = " SELECT r2.RoleId as Id,r2.RoleName as  Name, r2.Describ as Describtion,r2.ParentRole, r1.ParentRole, r1.Reference,r2.Reference, r1.RoleName AS PrentRolename " +
                   " FROM role r1 INNER JOIN role r2 ON r1.RoleId = r2.ParentRole  where r1.RoleId=r2.ParentRole  and r2.RoleId='" + roleid + "' or r2.CollegeId=" + Convert.ToString(Session["CompanyId"]) + "";
        }
        DataSet ds1 = cc.ExecuteDataset(sql);
        gvRole.DataSource = ds1.Tables[0];
        gvRole.DataBind();
        ddlparentrole.DataSource = ds1.Tables[0];
        ddlparentrole.DataTextField = "Name";
        ddlparentrole.DataValueField = "Id";

        ddlparentrole.DataBind();
        ddlparentrole.Items.Add("--Select--");
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
    private void AddNew()
    {
        CommonCode cc = new CommonCode();
        try
        {
            if (txtRoleName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the Role Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the Role Name')", true);
            }
            else
            {
                string Sql = "Select RoleId from Role where RoleName='" + txtRoleName.Text.ToString() + "' and ParentRole='" + ddlparentrole.SelectedValue + "'";
                string Id = Convert.ToString(cc.ExecuteScalar(Sql));
                if (!(Id == null || Id == ""))
                {
                    lblError.Visible = true;
                    lblError.Text = "This Name is already exist";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                }
                else
                {

                    string Sql1 = "Select RoleId,Reference from Role where RoleId='" + ddlparentrole.SelectedValue + "'";
                    DataSet ds1 = cc.ExecuteDataset(Sql1);
                    string refrole = Convert.ToString(ds1.Tables[0].Rows[0]["Reference"]);
                    if (refrole == "")
                    {
                        string roleid = Convert.ToString(ds1.Tables[0].Rows[0]["RoleId"]);
                        refrole = roleid;
                    }
                    if (ddlparentrole.SelectedValue == "0")
                    {
                        refrole = "";
                    }


                    // Sql = "Insert into Role(RoleName,Describ,ParentRole,Reference,CollegeId) Values (N'" + txtRoleName.Text.ToString() + "','" + txtdescription.Text + "','" + ddlparentrole.SelectedValue + "','" + refrole.ToString() + "'," + Session["CompanyId"].ToString() + ") ";
                    Sql = "Insert into Role(RoleName,Describ,ParentRole,Reference) Values (N'" + txtRoleName.Text.ToString() + "','" + txtdescription.Text + "','" + ddlparentrole.SelectedValue + "','" + refrole.ToString() + "') ";
                    int flag = cc.ExecuteNonQuery(Sql);

                    lblError.Visible = true;
                    lblError.Text = "Role Added Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Role added successfully')", true);
                    txtRoleName.Text = "";
                    txtdescription.Text = "";
                    ddlparentrole.SelectedIndex = ddlparentrole.Items.Count - 1;
                    load();

                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Role not added')", true);
        }
    }
    private void Update(string Id)
    {
        CommonCode cc = new CommonCode();
        try
        {
            if (txtRoleName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the role name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the Role Name')", true);
            }
            else
            {
                string Sql = "Select RoleId from Role where RoleName='" + txtRoleName.Text.ToString() + "' and ParentRole='" + ddlparentrole.SelectedValue + "' and RoleId<>" + Id + "";
                string Id1 = Convert.ToString(cc.ExecuteScalar(Sql));
                if (!(Id1 == null || Id1 == ""))
                {
                    lblError.Visible = true;
                    lblError.Text = "This Name is already exist";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                }
                else
                {
                    string Sql1 = "Select RoleId,Reference from Role where RoleId='" + ddlparentrole.SelectedValue + "'";
                    DataSet ds1 = cc.ExecuteDataset(Sql1);
                    string refrole = Convert.ToString(ds1.Tables[0].Rows[0]["Reference"]);
                    if (refrole == "")
                    {
                        string roleid = Convert.ToString(ds1.Tables[0].Rows[0]["RoleId"]);
                        refrole = roleid;
                    }
                    if (ddlparentrole.SelectedValue == "0")
                    {
                        refrole = "";
                    }

                    //  Sql = "Update Role set RoleName='" + txtRoleName.Text.ToString() + "',Describ='" + txtdescription.Text + "',ParentRole='" + ddlparentrole.SelectedValue + "',Reference='" + refrole.ToString() + "' ,CollegeId=" + Convert.ToString(Session["CompanyId"]) + " where RoleId=" + Id + "  ";
                    Sql = "Update Role set RoleName='" + txtRoleName.Text.ToString() + "',Describ='" + txtdescription.Text + "',ParentRole='" + ddlparentrole.SelectedValue + "',Reference='" + refrole.ToString() + "'  where RoleId=" + Id + "  ";
                    int flag = cc.ExecuteNonQuery(Sql);
                    txtRoleName.Text = "";
                    lblId.Text = "";
                    txtdescription.Text = "";
                    btnSubmit.Text = "Submit";
                    ddlparentrole.SelectedIndex = ddlparentrole.Items.Count - 1;
                    lblError.Visible = true;
                    lblError.Text = "Role updated Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Role updated successfully')", true);
                    load();

                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Role not Updated')", true);
        }
    }

    public void show()
    {
        //DataSet ds = role.GetAllRole();
        //DataSet ds = role.GetAllRole(Convert.ToString(Session["Role"]));


        string Sql = "Select b.RoleId as Id, b.RoleName as Name,b.Describ as Describtion,a.Reference,a.RoleName as PrentRolename from Role a,Role b where b.parentrole=a.RoleId  Order by Id  ";
        DataSet ds = cc.ExecuteDataset(Sql);
        gvRole.DataSource = ds.Tables[0];
        gvRole.DataBind();
        ddlparentrole.DataSource = ds.Tables[0];
        ddlparentrole.DataTextField = "Name";
        ddlparentrole.DataValueField = "Id";

        ddlparentrole.DataBind();
        ddlparentrole.Items.Add("--Select--");
        ddlparentrole.SelectedIndex = ddlparentrole.Items.Count - 1;
    }
    protected void gvRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRole.PageIndex = e.NewPageIndex;
        load();
    }
    protected void gvRole_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Convert.ToString(e.CommandName) == "Modify")
        {
            string Id = Convert.ToString(e.CommandArgument);
            if (Id == "2" || Id == "3" || Id == "4")
            {
                if (Session["LoginId"].ToString() == "ADMIN")
                {
                    btnSubmit.Text = "Update";
                    lblId.Text = Id;
                    string Sql = "Select RoleId,Describ, RoleName,ParentRole from Role where RoleId=" + Id + "";
                    try
                    {
                        DataSet ds = cc.ExecuteDataset(Sql);
                        txtRoleName.Text = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
                        txtdescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["Describ"]);
                        ddlparentrole.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ParentRole"]);
                    }
                    catch (Exception ex)
                    { }
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "This record Not Modify Bcoz permission is denied";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This record Not Modify Bcoz permission is denied')", true);
                }

            }
            else
            {

                if (Session["Role"].ToString() == Id)
                {
                    lblError.Visible = true;
                    lblError.Text = "This record Not Modify Bcoz permission is denied";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This record Not Modify Bcoz permission is denied')", true);

                }
                else
                {
                    btnSubmit.Text = "Update";
                    lblId.Text = Id;
                    string Sql = "Select RoleId,Describ, RoleName,ParentRole from Role where RoleId=" + Id + "";
                    try
                    {
                        DataSet ds = cc.ExecuteDataset(Sql);
                        txtRoleName.Text = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
                        txtdescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["Describ"]);
                        ddlparentrole.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ParentRole"]);
                    }
                    catch
                    { }
                }
            }

        }
        else if (Convert.ToString(e.CommandName) == "Assign")
        {
            string Id = Convert.ToString(e.CommandArgument);
            if (Id == "2" || Id == "3" || Id == "4")
            {
                if (Session["LoginId"].ToString() == "ADMIN")
                {
                    Response.Redirect("AssignMenu.aspx?Id=" + Id + "");
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Permission is denied";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Permission is denied')", true);
                }
            }
            else
            {
                if (Session["Role"].ToString() == Id)
                {
                    lblError.Visible = true;
                    lblError.Text = "Permission is denied";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Permission is denied')", true);

                }
                else
                {
                    Response.Redirect("AssignMenu.aspx?Id=" + Id + "");
                }
            }
        }
        else if (Convert.ToString(e.CommandName) == "Delete")
        {

            string Id = Convert.ToString(e.CommandArgument);
            if (Id == "2" || Id == "3" || Id == "4")
            {
                lblError.Visible = true;
                lblError.Text = "This record Not Delete Bcoz permission is denied";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This record Not Delete Bcoz permission is denied')", true);
            }
            else
            {
                if (Session["Role"].ToString() == Id)
                {
                    lblError.Visible = true;
                    lblError.Text = "This record Not Delete Bcoz permission is denied";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This record Not Delete Bcoz permission is denied')", true);
                }
                else
                {
                    lblId.Text = Id;
                    string Sql5 = "Select loginid from Login where   Role=" + Id + " ";
                    string Id3 = Convert.ToString(cc.ExecuteScalar(Sql5));
                    if (!(Id3 == null || Id3 == ""))
                    {
                        lblError.Visible = true;
                        lblError.Text = "This record reference use Other Location";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This record reference use Other Location')", true);
                    }

                    else
                    {
                        string Sql = "Delete from Role where RoleId=" + Id + "";
                        try
                        {
                            cc.ExecuteNonQuery(Sql);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Role Deleted')", true);
                            load();
                            lblId.Text = "";
                            lblError.Text = "";
                        }
                        catch
                        { }
                    }
                }
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlparentrole.SelectedIndex = ddlparentrole.Items.Count - 1;
        txtdescription.Text = string.Empty;
        txtRoleName.Text = "";
        lblId.Text = "";
    }
    protected void gvRole_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvRole_SelectedIndexChanged(object sender, EventArgs e)
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
        // cc.AddControls(Page.Controls, controlList, language);
    }

    #region Commented Lines of Function
    //private void AddControls(ControlCollection page, ArrayList controlList)
    //{

    //    if (Convert.ToString(Session["Marathi"]) == null || Convert.ToString(Session["Marathi"]) == "Marathi")
    //    {
    //        foreach (Control c in page)
    //        {
    //            Type tp = c.GetType();
    //            if (c.ID != null)
    //            {

    //                if (tp.Name.ToUpper().ToString() == "TEXTBOX")
    //                {
    //                    TextBox TXT = (TextBox)c;
    //                    if (TXT.Text != null)
    //                    {
    //                        TXT.CssClass = "marathiFont";
    //                    }

    //                }
    //                //else if ((tp.Name.ToUpper().ToString() == "LABEL"))
    //                //{
    //                //    Label lbl = (Label)c;
    //                //    if (lbl.Text != null)
    //                //    {
    //                //        lbl.CssClass = "marathiFont";
    //                //    }
    //                 //}

    //                else if ((tp.Name.ToUpper().ToString() == "RADIOBUTTON"))
    //                {
    //                    RadioButton rdb = (RadioButton)c;
    //                    if (rdb.Text != null)
    //                    {
    //                        rdb.CssClass = "marathiFont";
    //                    }

    //                }
    //                else if ((tp.Name.ToUpper().ToString() == "DROPDOWNLIST"))
    //                {
    //                    DropDownList ddl = (DropDownList)c;
    //                    if (ddl.Text != null)
    //                    {
    //                        ddl.CssClass = "marathiFont";
    //                    }


    //                }
    //                else if ((tp.Name.ToUpper().ToString() == "BUTTON"))
    //                {
    //                    Button btn = (Button)c;
    //                    if (btn.Text != null)
    //                    {
    //                        btn.CssClass = "marathiFont";

    //                    }

    //                }
    //            }

    //            if (c.HasControls())
    //            {
    //                AddControls(c.Controls, controlList);
    //            }
    //        }
    //    }
    //    //else if (rdenglish.Checked == true)
    //    else if (Convert.ToString(Session["English"]) == null || Convert.ToString(Session["English"]) == "English")
    //    {

    //        foreach (Control c in page)
    //        {
    //            Type tp = c.GetType();
    //            if (c.ID != null)
    //            {
    //                if (tp.Name.ToUpper().ToString() == "TEXTBOX")
    //                {
    //                    TextBox TXT = (TextBox)c;
    //                    if (TXT.Text != null)
    //                    {
    //                        TXT.CssClass = "EnglishFont";

    //                    }
    //                }
    //                else if ((tp.Name.ToUpper().ToString() == "LABEL"))
    //                {
    //                    Label lbl = (Label)c;
    //                    if (lbl.Text != null)
    //                    {
    //                        lbl.CssClass = "EnglishFont";

    //                    }


    //                }
    //                else if ((tp.Name.ToUpper().ToString() == "RADIOBUTTON"))
    //                {
    //                    RadioButton rdb = (RadioButton)c;
    //                    if (rdb.Text != null)
    //                    {

    //                        rdb.CssClass = "EnglishFont";

    //                    }

    //                }
    //                else if ((tp.Name.ToUpper().ToString() == "DROPDOWNLIST"))
    //                {
    //                    DropDownList ddl = (DropDownList)c;
    //                    if (ddl.Text != null)
    //                    {
    //                        ddl.CssClass = "EnglishFont";

    //                    }

    //                }
    //                else if ((tp.Name.ToUpper().ToString() == "BUTTON"))
    //                {
    //                    Button btn = (Button)c;
    //                    if (btn.Text != null)
    //                    {
    //                        btn.CssClass = "EnglishFont";

    //                    }

    //                }
    //            }

    //            if (c.HasControls())
    //            {
    //                AddControls(c.Controls, controlList);
    //            }
    //        }
    //    }
    //}
    #endregion

    protected void gvRole_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //getting username from particular row
            string username = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Name"));
            //identifying the control in gridview
            //raising javascript confirmationbox whenver user clicks on link button 
            ImageButton btnimg = (ImageButton)e.Row.FindControl("ImageButton3");
            btnimg.Attributes.Add("onclick", "javascript:return ConfirmationBox('" + username + "')");
        }
    }

    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        //getting particular row linkbutton
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        //getting userid of particular row

        int ID = Convert.ToInt32(gvRole.DataKeys[gvrow.RowIndex].Value.ToString());
        string username = gvrow.Cells[0].Text;

        string Sql = "Delete from Role where RoleId=" + ID + "";
        try
        {
            int result = cc.ExecuteNonQuery(Sql);
            if (result == 1)
            {
                load();
                lblId.Text = "";
                //Displaying alert message after successfully deletion of user
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('" + username + " details deleted successfully')", true);
            }
        }
        catch 
        { }

    }
}
