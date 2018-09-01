using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
//using Microsoft.Office.Interop.Excel;

public partial class Admin_UserList : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string language;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            load();
            hideButton();

        }

    }

    
    public void load()
    {
        

        string dd = Convert.ToString(Session["LoginId"]);
        string bb = Convert.ToString(Session["parentrole"]);
        string s = Convert.ToString(Session["Role"]);

        if ((Convert.ToString(Session["LoginId"]) != null && Convert.ToString(Session["parentrole"]) == "1") || (Convert.ToString(Session["Role"]) == "8"))
        {
            show();
        }
        else
        {
            LoadValue();
        }
    }
    private void show()
    {
        try
        {
            
            string Sql = " SELECT Login.LoginId,Login.Active, Login.UserName,loginname, Login.Password, Login.ContactNo, " +
                         " Login.Address, Login.DOJ, Login.Role, Login.CompanyId, Login.Active, " +
                         " Role.RoleName " +
                         " FROM Login INNER JOIN  " +
                         " Role ON Login.Role = Role.RoleId INNER JOIN " +
                         " Admin_SubUser on Admin_SubUser.uid= login.uid  " +
                         " where loginname='" + Convert.ToString(Session["LoginId"]) + "' ";



            if (Active.Checked == true)
            {
                Sql = Sql + " and Login.Active=1 ";
            }
            if (DeActive.Checked == true)
            {
                Sql = Sql + " and Login.Active=0";
            }

           
            Sql = Sql + "ORDER BY Login.uid desc";

            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvUser.DataSource = ds.Tables[0];
                gvUser.DataBind();
            }
            else
            {
                gvUser.DataSource = null;
                gvUser.DataBind();

            }
        }
        catch (Exception ex)
        {
            Response.Write("<h5>" + ex.Message);
        }
    }
    private void LoadValue()
    {
        try
        {

            string Sql = "SELECT   Login.LoginId, Login.UserName,loginname, Login.Password,role.parentrole, " +
                 " Login.ContactNo,Login.Address, Login.DOJ, Login.Role, Login.CompanyId, Login.Active," +
                 " Role.RoleName, CompanyMaster.DisplayName   FROM Login   Left outer JOIN CompanyMaster " +
                 " ON Login.CompanyId = CompanyMaster.CompanyId " +
                 " Left outer JOIN   Role ON Login.Role = Role.RoleId  " +
                 " inner join Admin_SubUser on Admin_SubUser.uid= login.uid    ";

            if (Session["Role"].ToString() == "2" || Session["Role"].ToString() == "8") // change on 28.10.13
            {
                Sql = Sql + "where R1='Admin'";
            }
            else
            {
                if (Convert.ToString(Session["Role"]) == "21")
                {
                    Sql = Sql + "where loginname='" + Convert.ToString(Session["LoginId"]) + "' and Admin_SubUser.roleid='10' ";
                }
                else
                {
                    Sql = Sql + "where loginname='" + Convert.ToString(Session["LoginId"]) + "'";
                }
            }
            if (Active.Checked == true)
            {
                Sql = Sql + " and  Login.Active=1 ";
            }
            if (DeActive.Checked == true)
            {
                Sql = Sql + " and Login.Active=0 ";
            }
           
            Sql = Sql + "ORDER BY Login.uid desc";


            DataSet ds = cc.ExecuteDataset(Sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvUser1.DataSource = ds.Tables[0];
                gvUser1.DataBind();
            }
            else
            {
                gvUser1.DataSource = null;
                gvUser1.DataBind();

            }
        }
        catch (Exception ex)
        {
            Response.Write("<h5>" + ex.Message);
        }
    }

    protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUser.PageIndex = e.NewPageIndex;
        load();
    }
    protected void gvUser1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUser1.PageIndex = e.NewPageIndex;
        load();
    }

    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("User.aspx");
    //}
    protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;
        if (Convert.ToString(e.CommandName) == "Modify")
        {
           // Response.Redirect("User.aspx?Id=" + Id);
        }
        else if (Convert.ToString(e.CommandName) == "View")
        {
           // Response.Redirect("UserView.aspx?Id=" + Id); //Do not Delete this Line commented by me

        }
        else if (Convert.ToString(e.CommandName) == "Assign")
        {
            Response.Redirect("AssignChapter.aspx?Id=" + Id);

        }

        else if (Convert.ToString(e.CommandName) == "Active")
        {
            try
            {
                
                string Sql = "Update Login set Active=1 where LoginId='" + Id + "'";
                cc.ExecuteNonQuery(Sql);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Active Successfully')", true);

                load();
            }
            catch (Exception ex)
            {
                Response.Write("<h5>" + ex.Message);
            }
        }
        else if (Convert.ToString(e.CommandName) == "Deactive")
        {
            try
            {

                string Sql = "Update Login set Active=0 where LoginId='" + Id + "'";
                cc.ExecuteNonQuery(Sql);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Deactive Successfully')", true);

                load();
            }
            catch (Exception ex)
            {
                Response.Write("<h5>" + ex.Message);
            }
        }


    }
    protected void gvUser1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;
        if (Convert.ToString(e.CommandName) == "Modify")
        {
           // Response.Redirect("User.aspx?Id=" + Id);
        }
        else if (Convert.ToString(e.CommandName) == "View")
        {
           // Response.Redirect("UserView.aspx?Id=" + Id);
        }
        else if (Convert.ToString(e.CommandName) == "Assign")
        {
            Response.Redirect("ClassStudentAssign.aspx?Id=" + Id);

        }

        else if (Convert.ToString(e.CommandName) == "Active")
        {
            try
            {
                
                string Sql = "Update Login set Active=1 where LoginId='" + Id + "'";
                cc.ExecuteNonQuery(Sql);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Active Successfully')", true);

                load();
            }
            catch (Exception ex)
            {
                Response.Write("<h5>" + ex.Message);
            }
        }
        else if (Convert.ToString(e.CommandName) == "Deactive")
        {
            try
            {
                
                string Sql = "Update Login set Active=0 where LoginId='" + Id + "'";
                cc.ExecuteNonQuery(Sql);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Deactive Successfully')", true);

                load();
            }
            catch (Exception ex)
            {
                Response.Write("<h5>" + ex.Message);
            }
        }


    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
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



    protected void gvUser_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //getting username from particular row
            string username = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LoginId"));
            //identifying the control in gridview
            //raising javascript confirmationbox whenver user clicks on link button 
            ImageButton btnimg = (ImageButton)e.Row.FindControl("ImageButton3");
            btnimg.Attributes.Add("onclick", "javascript:return ConfirmationBox('" + username + "')");

        }
    }
    protected void Active_CheckedChanged(object sender, EventArgs e)
    {
        if (Active.Checked == true)
        {
            DeActive.Checked = false;
            load();
        }
        else
        {
            Active.Checked = false;
        }
    }
    protected void DeActive_CheckedChanged(object sender, EventArgs e)
    {
        if (DeActive.Checked == true)
        {
            Active.Checked = false;
            load();
        }
        else
        {

            DeActive.Checked = false;
        }
    }

    public void hideButton()
    {
        if (Convert.ToString(Session["Role"]) == "8" || Convert.ToString(Session["Role"]) == "2" || Convert.ToString(Session["Role"]) == "3")
            Button1.Visible = true;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Id = Convert.ToString(Session["LoginId"]);
        Response.Redirect("AssignChapter.aspx?Id=" + Id);
    }



    protected void btnsearch1_Click(object sender, EventArgs e)
    {
        try
        {
            string Id = Convert.ToString(txtMobileNo.Text);
            string loginID = Convert.ToString(Session["LoginId"]);

            if (loginID == "ADMIN")
            {
                string Sql = " SELECT   Login.LoginId,Login.Active, Login.UserName,loginname, Login.Password, Login.ContactNo, " +
                         " Login.Address, Login.DOJ, Login.Role, Login.CompanyId, Login.Active, " +
                         " Role.RoleName " +
                         " FROM Login INNER JOIN  " +
                         " Role ON Login.Role = Role.RoleId INNER JOIN " +
                         " Admin_SubUser on Admin_SubUser.uid= login.uid  " +
                         " where Login.LoginId like '%" + Id + "%'";
                DataSet ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvUser.DataSource = ds.Tables[0];
                    gvUser.DataBind();
                }
                else
                {
                    gvUser.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('No Such Record!!! Please Enter valid Number')", true);

                }
            }
            else
            {
                string Sql1 = " SELECT   Login.LoginId,Login.Active, Login.UserName,loginname, Login.Password, Login.ContactNo, " +
                        " Login.Address, Login.DOJ, Login.Role, Login.CompanyId, Login.Active, " +
                        " Role.RoleName " +
                        " FROM Login INNER JOIN  " +
                        " Role ON Login.Role = Role.RoleId INNER JOIN " +
                        " Admin_SubUser on Admin_SubUser.uid= login.uid  " +
                        " where Login.LoginId like '%" + Id + "%' and loginname = '" + Convert.ToString(Session["LoginId"]) + "'";

                DataSet ds = cc.ExecuteDataset(Sql1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvUser.DataSource = ds.Tables[0];
                    gvUser.DataBind();
                }
                else
                {
                    gvUser.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('No Such Record!!! Please Enter valid Number')", true);

                }


            }

        }
        catch (Exception ex)
        {
             throw ex;
        }
    }


    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        //string SqlQuery = "Select Login.LoginId,Login.UserName,Login.Password,Admin_SubUser.loginname From Login Inner Join Admin_SubUser ON Login.LoginId=Admin_SubUser.UnderUsername Where Admin_SubUser.loginname='" + Session["LoginId"] + "'";
        
        //DataSet dataset = cc.ExecuteDataset(SqlQuery);

        //DataTable dt = new DataTable();
        //dt.Columns.Add(new DataColumn("UserNo", typeof(string)));
        //dt.Columns.Add(new DataColumn("UserName", typeof(string)));
        //dt.Columns.Add(new DataColumn("Password", typeof(string)));
        //dt.Columns.Add(new DataColumn("CenterNo", typeof(string)));


        //for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
        //{
        //    dt.Rows.Add(dataset.Tables[0].Rows[i][0].ToString(),dt.Rows.Add(dataset.Tables[0].Rows[i][1].ToString(),cc.DESDecrypt(dataset.Tables[0].Rows[i][2].ToString()),dt.Rows.Add(dataset.Tables[0].Rows[i][3].ToString())));

        //}
        //dataset.Tables.RemoveAt(0);
        //dataset.Tables.Add(dt);


    }
    protected void btndatashowany_Click(object sender, EventArgs e)
    {

    }
}
