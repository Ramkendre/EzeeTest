using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.IO;

public partial class Admin_User : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();

    string language = string.Empty;
    RegisterToMyct reg = new RegisterToMyct();
    string UserName = "", UserID = "", R1 = "", R2 = "", R3 = "", R4 = "", R5 = "", R6 = "", initial = "", usrRole = "", RoleId = "", userid;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string Id = Convert.ToString(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            load();
            
            if (Id != "" && Id != null)
            {

                this.GetUserValue(Id);
            }
            ListControlCollections();

        }

        companypanel();

    }

    public void companypanel()
    {
        
    }


    private void gridviewshow()
    {
        try
        {
            string sql = "select login.Uid as ID,login.UserName as Name,Admin_SubUser.RoleName,login.ContactNo from login " +
                "inner join Admin_SubUser on Login.Uid=Admin_SubUser.Uid where Admin_SubUser.UnderUsername='" + Convert.ToString(Session["LoginId"]) + "'";
            DataSet ds = cc.ExecuteDataset(sql);
            gvUser.DataSource = ds.Tables[0];
            gvUser.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<h5>" + ex.Message);
        }

    }
    private void gridviewshow_admin()
    {
        try
        {
            string sql = "select login.Uid as ID,login.UserName as Name,Admin_SubUser.RoleName,login.ContactNo from login " +
                "where login.LoginId='" + Convert.ToString(Session["LoginId"]) + "'";
            DataSet ds = cc.ExecuteDataset(sql);
            gvUser.DataSource = ds.Tables[0];
            gvUser.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<h5>" + ex.Message);
        }

    }

    private void gvshow()
    {

        string sql = "select UID,UserName from login left outer join companymaster on companymaster.companyid=login.companyid where uid='" + Convert.ToString(Session["insertID"]) + "'";
        DataSet ds = cc.ExecuteDataset(sql);
        string Sub_UID = Convert.ToString(ds.Tables[0].Rows[0]["UID"]);
        Session["Sub_UID"] = Sub_UID;

    }

    public void loadv()
    {
        CommonCode cc = new CommonCode();
        string Sql = "Select CompanyId, DisplayName from CompanyMaster order by DisplayName ";
        DataSet ds = cc.ExecuteDataset(Sql);
        ddlCompany.DataSource = ds.Tables[0];
        ddlCompany.DataTextField = "DisplayName";
        ddlCompany.DataValueField = "CompanyId";

        ddlCompany.DataBind();
        ddlCompany.Items.Add("--Select--");
        ddlCompany.SelectedIndex = ddlCompany.Items.Count - 1;
        load();

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
            gridviewshow();
        }
    }


    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRole.SelectedValue == "3")
        {
            p1.Visible = true;
        }
        else
        {
            p1.Visible = false;
            ddlcategory.SelectedValue = "0";
        }

    }


    public void show()
    {
        try
        {
            string Sql = "Select RoleId, RoleName from Role where Roleid <>'" + Convert.ToString(Session["Role"]) + "' order by RoleName ";
            Sql = Sql + "Select CompanyId, DisplayName from CompanyMaster order by DisplayName ";
            Sql = Sql + "select login.Uid as ID,login.UserName as Name,role.RoleName,login.ContactNo from login " +
               " inner join role on role.roleid=login.role where login.LoginId='" + Convert.ToString(Session["LoginId"]) + "'";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvUser.DataSource = ds.Tables[2];
            gvUser.DataBind();
            ddlRole.DataSource = ds.Tables[0];
            ddlRole.DataTextField = "RoleName";
            ddlRole.DataValueField = "RoleId";

            ddlRole.DataBind();
            ddlRole.Items.Add("--Select--");
            ddlRole.SelectedIndex = ddlRole.Items.Count - 1;

            ddlCompany.DataSource = ds.Tables[1];
            ddlCompany.DataTextField = "DisplayName";
            ddlCompany.DataValueField = "CompanyId";
            ddlCompany.DataBind();
            ddlCompany.Items.Add("--Select--");
            ddlCompany.SelectedIndex = ddlCompany.Items.Count - 1;
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('exception')", true);
        }
    }

    public void displya()
    {
        try
        {
            string Sql = " select ParentRole,RoleId,reference from role where RoleId='" + Convert.ToString(Session["Role"]) + "'";
            Sql = Sql + " Select CompanyId, DisplayName from CompanyMaster where CompanyId=" + Session["CompanyId"].ToString() + " or SubCId=" + Session["CompanyId"].ToString() + "  order by DisplayName ";
            Sql = Sql + " select login.Uid as ID,login.UserName as Name,Admin_SubUser.RoleName,login.ContactNo from login " +
                        " inner join Admin_SubUser on Login.Uid=Admin_SubUser.Uid where Admin_SubUser.UnderUsername='" + Convert.ToString(Session["LoginId"]) + "'";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvUser.DataSource = ds.Tables[2];
            gvUser.DataBind();

            string roleid = Convert.ToString(ds.Tables[0].Rows[0]["RoleId"]);
            string underole = Convert.ToString(ds.Tables[0].Rows[0]["ParentRole"]);
            string refrence = Convert.ToString(ds.Tables[0].Rows[0]["reference"]);
            if (underole == "1")  // for Administrator login 
            {

                Sql = "select roleid,RoleName from role where Parentrole='" + roleid + "' or CollegeId=" + Convert.ToString(Session["CompanyId"]) + " ";

            }
            else
            {
                Sql = "  select * from Role where  ParentRole='" + roleid + "' ";

                string loginid = Convert.ToString(Session["LoginId"]);

                if (loginid == "7588419504" || loginid == "8421670939" || loginid == "7620829452") // for Class-Admin 
                {
                    Sql = "  select * from Role where RoleId='" + roleid + "' or ParentRole='" + roleid + "' ";
                }

                if (roleid == "19")// for SubAdmin
                {
                    Sql = "  select * from Role where RoleId=3 or ParentRole=3 ";
                }
                if (roleid == "8") // for Admin
                {
                    Sql = " select * from Role where RoleId=3 or ParentRole=3  or RoleId=19  ";
                }
                if (roleid == "21") // for Sub-ClassAdmin
                {
                    Sql = " select * from Role where RoleId=10 ";
                }
                if (roleid == "22") //For Junior Class-Admin For RSB 12th Class
                {
                    Sql = "Select *from Role where RoleId=23 ";
                }


            }
            DataSet ds1 = cc.ExecuteDataset(Sql);
            ddlRole.DataSource = ds1.Tables[0];
            ddlRole.DataTextField = "RoleName";
            ddlRole.DataValueField = "roleid";
            ddlRole.DataBind();
            ddlRole.Items.Add("--Select--");
            ddlRole.SelectedIndex = ddlRole.Items.Count - 1;

            if (ds.Tables[1].Rows.Count > 0)
            {
                ddlCompany.DataSource = ds.Tables[1];
                ddlCompany.DataTextField = "DisplayName";
                ddlCompany.DataValueField = "CompanyId";
                ddlCompany.DataBind();
                ddlCompany.Items.Add("--Select--");
                ddlCompany.SelectedIndex = ddlCompany.Items.Count - 1;
            }
            else
            {
                ddlCompany.Items.Add("--Select--");
                ddlCompany.SelectedIndex = ddlCompany.Items.Count - 1;
            }
        }
        catch (Exception ex)
        {
            Response.Write("<h5>" + ex.Message); 
        }
    }
    


    private void GetUserValue(string Id) //modify
    {
        btnSubmit.Text = "Update";
        
        string Sql = " SELECT   Login.LoginId,admintype, Login.UserName, Login.Password, Login.ContactNo, " +
                     " Login.Address, Login.DOJ, Login.Role, Login.CompanyId, Login.Active,  Login.Category, " +
                     " Role.RoleName,Login.UserType  " +
                     " FROM Login INNER JOIN  " +
                     " Role ON Login.Role = Role.RoleId " +
                     " WHERE (Login.LoginId = '" + Id + "')";


        try
        {
            CommonCode cc = new CommonCode();
            DataSet ds = cc.ExecuteDataset(Sql);

            txtLoginId.Text = Convert.ToString(ds.Tables[0].Rows[0]["LoginId"]);
            txtUserName.Text = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
            txtContactNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ContactNo"]);
            txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
            ddlCompany.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CompanyId"]);
            ddlRole.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Role"]);
            ddluserType.SelectedValue=Convert.ToString(ds.Tables[0].Rows[0]["UserType"]);


            if (Convert.ToString(ddlRole.SelectedValue) == "3")
            {
                p1.Visible = true;
                string category = Convert.ToString(ds.Tables[0].Rows[0]["Category"]);
                if (category == "")
                    ddlcategory.SelectedValue = "0";
                else
                    ddlcategory.SelectedItem.Text = category;
            }

        }
        catch (Exception ex)
        {
            Response.Write("<h5>" + ex.Message);
        }
    }
    private string ChangeDate(string Date)
    {
        string Date1 = "";
        try
        {
            string[] tmp = Date.Split('/');
            DateTime dt = Convert.ToDateTime(tmp[1] + "/" + tmp[0] + "/" + tmp[2]);
            Date1 = Convert.ToString(tmp[1] + "-" + tmp[0] + "-" + tmp[2]);
        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message); //To Display Exception.
        }
        return Date1;
    }
    private string ChangeDate1(string Date)
    {
        string Date1 = "";
        try
        {
            string[] tmp = Date.Split(' ');
            tmp = tmp[0].Split('-');
            Date1 = Convert.ToString(tmp[1] + "-" + tmp[0] + "-" + tmp[2]);
        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
        return Date1;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
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
    int flag;

    private void AddNew()
    {
        CommonCode cc = new CommonCode();
        try
        {
            if (txtLoginId.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the Login Id";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the Login Id')", true);
            }
            else if (txtUserName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the User Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the User Name')", true);
            }

            else if (ddlRole.SelectedIndex == ddlRole.Items.Count - 1)
            {
                lblError.Visible = true;
                lblError.Text = "Please Select the Role";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select the Role')", true);

            }
            
            else
            {
                string Sql = "Select LoginId from Login where LoginId='" + txtLoginId.Text.ToString() + "'";
                string Id = Convert.ToString(cc.ExecuteScalar(Sql));
                if (!(Id == null || Id == ""))
                {
                    Sql = "Select loginname from Admin_SubUser where UnderUsername='" + Id + "'"; //This Line Added by Jitu dated on 18.04.2015
                    string CLADMIN = Convert.ToString(cc.ExecuteScalar(Sql));



                    lblError.Visible = true;
                    lblError.Text = "This LoginId is Already Exist Under_User ' " + CLADMIN + " ' Do You Want to Take Him Under You ? If 'Yes' Click On *Register* / If 'No' Ignore It";
                    btnRegister.Visible = true;
                    // lblError.Font.Bold = true;
                   // ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('This LoginId is Already Exist')", true);
                }
                else
                {
                    string pincode = "411039";
                    string regid = reg.Addnew(txtUserName.Text, txtUserNameL.Text, txtLoginId.Text, txtAddress.Text, pincode, "1"); // 1 means msg send

                    if (regid != "" || regid == null)
                    {
                        if (ddlRole.SelectedValue != "10" && ddlRole.SelectedValue != "21" && ddlRole.SelectedValue != "23")
                        {
                            Sql = " Insert into Login(LoginId, UserName, Password, ContactNo, " +
                                  " Address, DOJ, Role, CompanyId,Active,admintype ,UserType,Category) Values " +
                                  " (N'" + txtLoginId.Text.ToString() + "',N'" + txtUserName.Text.ToString() + "',N'" + regid + "','" + txtContactNo.Text.ToString() + "', " +
                                  " N'" + txtAddress.Text + "','" + System.DateTime.Now + "'," + ddlRole.SelectedValue + ",0,1,'1','" + ddluserType.SelectedValue + "','" + ddlcategory.SelectedItem.Text + "') ";
                            flag = cc.ExecuteNonQuery(Sql);
                        }
                        if (ddlRole.SelectedValue == "10" || ddlRole.SelectedValue == "21" || ddlRole.SelectedValue == "23")
                        {
                            if (Convert.ToString(Session["CompanyId"]) != "0")
                            {
                                Sql = " Insert into Login(LoginId, UserName, Password, ContactNo, " +
                                      " Address, DOJ, Role, CompanyId, Active, admintype ,UserType, Category) Values " +
                                      " (N'" + txtLoginId.Text.ToString() + "',N'" + txtUserName.Text.ToString() + "',N'" + regid + "','" + txtContactNo.Text.ToString() + "', " +
                                      " N'" + txtAddress.Text + "','" + System.DateTime.Now + "'," + ddlRole.SelectedValue + ",'" + Convert.ToString(Session["CompanyId"]) + "' ,1,'1','" + ddluserType.SelectedValue + "','" + ddlcategory.SelectedItem.Text + "') ";
                                flag = cc.ExecuteNonQuery(Sql);
                            }
                            else
                            {
                                lblError.Visible = true;
                                lblError.Text = "Please Add your Company Profile";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Add your Company Profile')", true);
                                Response.Redirect("Company.aspx", false);

                            }
                        }
                        
                        if (flag == 1)
                        {
                            string sql = "SELECT MAX(Uid) AS LastID FROM Login";
                            string Id1 = cc.ExecuteScalar(sql);
                            Session["insertID"] = Id1;
                            if (!(Id1 == null))
                            {
                                load(Id1);
                            }
                         
                            lblError.Text = "User Added Successfully";
                            lblError.Visible = true;
                            Response.Redirect("UserList.aspx?Flag=S");
                        }
                        else
                        {
                           
                            lblError.Text = "Cant Add the User";
                            lblError.Visible = true;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Cant Add the User')", true);

                        }

                    }
                }
            }

        }
        catch (Exception ex)
        {
        }
    }

    public void load(string UID)
    {
        if ((Convert.ToString(Session["LoginId"]) == "ADMIN"))
        {
            Adduser(UID);
        }
        else
        {
            //AddSubUSer(UID);
            AddNewUser(UID);
        }
    }
    public void Adduser(string UID)
    {
        try
        {
            string sql = "select id from Admin_SubUser where uid='" + Convert.ToString(Session["insertID"]) + "'";
            string id1 = cc.ExecuteScalar(sql);
            if (!(id1 == null || id1 == ""))
            {
                Response.Write("<script>(alert)('This User is already  of other, You cannot assign ')</script>");
            }

            else
            {
                string Sql = "insert Admin_SubUser(loginid,loginname,uid,UnderUsername,roleid,rolename,DT,R1,companyid)" +
                             "values('" + Convert.ToString(Session["LoginName"]) + "','" + Convert.ToString(Session["LoginId"]) + "'," + Convert.ToString(Session["insertID"]) + ",'" + txtLoginId.Text + "'," + ddlRole.SelectedValue + ",'" + ddlRole.SelectedItem.Text + "','" + System.DateTime.Now + "','" + Convert.ToString(Session["LoginId"]) + "','" + Convert.ToString(Session["CompanyId"]) + "')";
                int flag = cc.ExecuteNonQuery(Sql);
            }
        }
        catch (Exception ex)
        {
            Response.Write("<h5>" + ex.Message);
        }
    }
    public void AddSubUSer(int UID)
    {
        try
        {
            string Sql = "insert Admin_SubUser(uid,loginid,roleid,rolename,DT,R2,R3,R4,R5,companyid)" +
                         "values(" + UID + ",'" + txtLoginId.Text + "'," + ddlRole.SelectedValue + ",'" + ddlRole.Items.ToString() + "','" + System.DateTime.Now + "'," + UID + ",'" + Convert.ToString(Session["CompanyId"]) + "')";
            int flag = cc.ExecuteNonQuery(Sql);
        }
        catch (Exception ex)
        {
            Response.Write("<h5>" + ex.Message);

        }
    }
    
    private void info12()
    {
        string sqlfetch = "select uid,loginid,loginname,UnderUsername,roleid,rolename,DT,R2,R3,R4,R5,R6,companyid  from Admin_SubUser where UnderUsername='" + UserName + "'";
        DataSet ds1 = cc.ExecuteDataset(sqlfetch);
        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        {
            usrRole = Convert.ToString(ds1.Tables[0].Rows[0]["rolename"]);
            userid = Convert.ToString(ds1.Tables[0].Rows[0]["UnderUsername"]);
            RoleId = Convert.ToString(ds1.Tables[0].Rows[0]["roleid"]);
            R2 = Convert.ToString(ds1.Tables[0].Rows[0]["R2"]);
            if (R2 == "")
            {
                R2 = userid;
                break;
            }

            R3 = Convert.ToString(ds1.Tables[0].Rows[0]["R3"]);
            if (R3 == "")
            {
                R3 = userid;
                break;
            }

            R4 = Convert.ToString(ds1.Tables[0].Rows[0]["R4"]);
            if (R4 == "")
            {
                R4 = userid;
                break;
            }
            R5 = Convert.ToString(ds1.Tables[0].Rows[0]["R5"]);
            if (R5 == "")
            {
                R5 = userid;
                break;
            }
            R6 = Convert.ToString(ds1.Tables[0].Rows[0]["R6"]);
            if (R6 == "")
            {
                R6 = userid;
                break;
            }

        }

        initial = "Admin";
    }
    private void AddNewUser(string UID)
    {
        UserName = Convert.ToString(Session["Loginid"]);
        UserID = Convert.ToString(Session["LoginName"]);

        if ((Convert.ToString(Session["LoginId"]) != null && Convert.ToString(Session["parentrole"]) == ""))
        {
            string sql1 = "select id from login where Loginid='" + UserName + "'";
            UserName = cc.ExecuteScalar(sql1);
        }
        else
        {
            info12();
        }
        gvshow();
        string R1 = initial;
        string Sub_UID = Convert.ToString(Session["Sub_UID"]);
        string sql12 = "select id from Admin_SubUser where UnderUsername='" + UserName + "'";
        string id = cc.ExecuteScalar(sql12);

        if (id == "")
        {
            string Sql = "insert Admin_SubUser(loginid,loginname,uid,UnderUsername,roleid,rolename,DT,R1,R2,R3,R4,R5,R6,companyid)" +
                         "values('" + Convert.ToString(Session["LoginName"]) + "','" + Convert.ToString(Session["LoginId"]) + "'," + Convert.ToString(Session["insertID"]) + ",'" + txtLoginId.Text + "'," + ddlRole.SelectedValue + ",'" + ddlRole.SelectedItem.Text + "','" + System.DateTime.Now + "','" + R1 + "','" + R2 + "','" + R3 + "','" + R4 + "','" + R5 + "','" + R6 + "','" + Convert.ToString(Session["CompanyId"]) + "')";
            int flag = cc.ExecuteNonQuery(Sql);
        }
        else
        {
            string id1 = "";

            string sql = "select id from Admin_SubUser where uid='" + Convert.ToString(Session["insertID"]) + "'";
            id1 = cc.ExecuteScalar(sql);
            if (!(id1 == null || id1 == ""))
            {
                Response.Write("<script>(alert)('This User is already  of other, You cannot assign ')</script>");
            }

            else
            {
                string Sql = "insert Admin_SubUser(loginid,loginname,uid,UnderUsername,roleid,rolename,DT,R1,R2,R3,R4,R5,R6,companyid)" +
                       "values('" + Convert.ToString(Session["LoginName"]) + "','" + Convert.ToString(Session["LoginId"]) + "'," + Convert.ToString(Session["insertID"]) + ",'" + txtLoginId.Text + "'," + ddlRole.SelectedValue + ",'" + ddlRole.SelectedItem.Text + "','" + System.DateTime.Now + "','" + R1 + "','" + R2 + "','" + R3 + "','" + R4 + "','" + R5 + "','" + R6 + "','" + Convert.ToString(Session["CompanyId"]) + "')";
                int flag = cc.ExecuteNonQuery(Sql);
            }
        }
    }

    private void Update(string Id)
    {
        CommonCode cc = new CommonCode();
        try
        {
            
            if (txtLoginId.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the Login Id";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the Login Id')", true);
            }
            else if (txtUserName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the User Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the User Name')", true);
            }

            else if (ddlRole.SelectedIndex == ddlRole.Items.Count - 1)
            {
                lblError.Visible = true;
                lblError.Text = "Please Select the Role";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select the Role')", true);

            }
            
            else
            {
                
                string pincode = "411039";
                string regid = reg.Addnew(txtUserName.Text, txtUserNameL.Text, txtLoginId.Text, txtAddress.Text, pincode, "0");
                if (regid != "" || regid == null)
                {

                    if (ddlRole.SelectedValue != "10" && ddlRole.SelectedValue != "23")
                    {
                       string  Sql = " Update Login set UserName=N'" + txtUserName.Text.ToString() + "', " +
                                     " Password=N'" + regid + "', " +
                                     " ContactNo='" + txtContactNo.Text.ToString() + "', " +
                                     " Address=N'" + txtAddress.Text.ToString() + "' , " +
                                     " DOJ='" + regid + "', " +
                                     " Role=" + ddlRole.SelectedValue.ToString() + ", " +
                                     " CompanyId=0, " +
                                     " admintype='1' , " +
                                     " UserType='"+ddluserType.SelectedValue+"' ," +
                                     " Category='" + ddlcategory.SelectedItem.Text + "' " +
                                     " Where LoginId='" + Id + "'";
                         flag = cc.ExecuteNonQuery(Sql);
                    }
                    if (ddlRole.SelectedValue == "10" || ddlRole.SelectedValue == "23")
                    {
                        if (Convert.ToString(Session["CompanyId"]) != "0")
                        {
                            string Sql = " Update Login set UserName=N'" + txtUserName.Text.ToString() + "', " +
                                         " Password=N'" + regid + "', " +
                                         " ContactNo='" + txtContactNo.Text.ToString() + "', " +
                                         " Address=N'" + txtAddress.Text.ToString() + "' , " +
                                         " DOJ='" + regid + "', " +
                                         " Role=" + ddlRole.SelectedValue.ToString() + ", " +
                                         " CompanyId='" + Convert.ToString(Session["CompanyId"]) + "', " +
                                         " admintype='1' , " +
                                         " UserType='"+ddluserType.SelectedValue+"' ," +
                                         " Category='" + ddlcategory.SelectedItem.Text + "' " +
                                         " Where LoginId='" + Id + "'";
                             flag = cc.ExecuteNonQuery(Sql);
                        }
                        else
                        {
                            lblError.Visible = true;
                            lblError.Text = "Please Add your Company Profile";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Add your Company Profile')", true);
                            Response.Redirect("Company.aspx", false);
                        }
                    }

                    if (flag == 1)
                    {
                        string sql = "SELECT Uid AS LastID FROM Login where loginid='" + Id + "'";
                        string Id1 = cc.ExecuteScalar(sql);
                        Session["insertID"] = Id1;
                        
                        if (!(Id1 == null))
                        {
                            load(Id1);
                        }
                        btnSubmit.Text = "Submit";
                        lblError.Visible = true;
                        lblError.Text = "User Updated Successfully";
                     
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Updated Successfully')", true);
                        Response.Redirect("UserList.aspx?Flag=S", false);

                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Cant Update the User";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Cant Update the User')", true);

                    }
                }

            }
        }
        catch (Exception ex)
        {
            Response.Write("<h5>" + ex.Message);
        }

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string Id = Convert.ToString(Request.QueryString["Id"]);
        try
        {
            string Sql = "Update Login set Active=0 where LoginId='" + Id + "'";
            CommonCode cc = new CommonCode();
            int flag = cc.ExecuteNonQuery(Sql);
            if (flag == 1)
            {
                lblError.Text = "Login deactivated Successfully";
                lblError.Visible = true;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Login deactivated successfully')", true);
            }
            else
            {
                lblError.Text = "Cant deactivate Login";
                lblError.Visible = true;
                Response.Redirect("UserList.aspx?Flag=D ");
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Cant deactivate Login";
            lblError.Visible = true;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Cant deactivate Login')", true);

        }
    }
    // Add Back Button Functionality.
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserList.aspx");
    }
    private void ListControlCollections()
    {
        ArrayList controlList = new ArrayList();

        if (Convert.ToString(Session["Marathi"]) == null || Convert.ToString(Session["Marathi"]) == "Marathi")
        {
            language = "Marathi";
        }
        else if (Convert.ToString(Session["English"]) == null || Convert.ToString(Session["English"]) == "English")
        {
            language = "English";

        }

    }

  
    protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    // To Set Multiple Class-Admin to Already Exits Numbers by Jitendra Patil
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (txtLoginId.Text == "")
        {
            lblError.Visible = true;
            lblError.Text = "Please Enter the MobileNo.";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the Login Id')", true);
        }
        else
        {
            string SQLQuery1 = "Select SLoginId from tblMulClassAdmin Where SLoginId='" + txtLoginId.Text + "' and CLALoginId='" + Session["LoginId"].ToString() + "'";
            string log = cc.ExecuteScalar(SQLQuery1);
            if (log != "")
            {
            }
            else
            {
                string role = string.Empty;
                if (Session["Role"].ToString() == "22")
                {
                    role = "23";
                }
                else
                {
                    role = "10";
                }
                string SQLQuery = "Insert Into tblMulClassAdmin(SLoginId,CLALoginId,RoleId,CompanyId,EntryDate)Values('" + txtLoginId.Text + "','" + Session["LoginId"].ToString() + "','" + role.ToString() + "','" + Session["CompanyId"].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                int status = cc.ExecuteNonQuery(SQLQuery);
                if (status != 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Added Successfully..!!!')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record NOT Added..!!!')", true);
                }
            }
        }
    }
}
