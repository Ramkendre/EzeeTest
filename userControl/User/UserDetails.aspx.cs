using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

public partial class User_UserDetails : System.Web.UI.Page
{
    string username, testassign, companyname,abc;
    int status;
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
       
        username = Convert.ToString(Session["username"]);
        companyname = Convert.ToString(Session["companyid"]);
        if (!IsPostBack)
        {
            select_Examname();

        }
        this.Set_Page_Level_Setting();
    }
    protected void Set_Page_Level_Setting()
    {
        //set page heading
        Label lblMainHeading = (Label)Master.FindControl("lblMainHeading");
        if (lblMainHeading != null)
            lblMainHeading.Text = "All menus";
    }
    private void select_Examname()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
       
        try
        {
            getmenu();
          //use inner join
            string str1 = " select distinct Total_que,tblTestDefinition.Test_ID as Id from tblTestDefinition ,Login1 where login1.examid=tblTestDefinition.Test_ID and   tblTestDefinition.Test_ID in(" + testassign + ") and companyId= " + companyname + "";
            DataSet ds = cc.ExecuteDataset(str1);
            ddlEname.DataSource = ds.Tables[0];
            ddlEname.DataTextField = "Total_que";
            ddlEname.DataValueField = "Id";
            ddlEname.DataBind();
            ddlEname.Items.Add("--Select--");
            ddlEname.SelectedIndex = ddlEname.Items.Count - 1;
           

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {
            con.Close();
        }
    }
    public void getmenu()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
       
        try
        {
            string sql = "select MenuId from Login1 where LoginId='" + username + "'";
             DataSet ds=cc.ExecuteDataset(sql);
             if(ds.Tables[0].Rows.Count>0)
             {
                 testassign = Convert.ToString(ds.Tables[0].Rows[0]["MenuId"]);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {
            con.Close();
        }

    }
    private void LoadValue(string Id)
    {
        try
        {
            int LoginId = Convert.ToInt32(Session["LoginId"]);
            string Sql = " Select MenuId from Login1 where LoginId=" + LoginId + "";
            string Menus = Convert.ToString(cc.ExecuteScalar(Sql));


            Sql = "SELECT   MenuName, MenuUrl from Menu where ParentId=" + Id + " and MenuId in(" + Menus + ") order by MenuSequence  ";
            DataSet ds = cc.ExecuteDataset(Sql);
        }
        catch (Exception ex)
        {

        }
    }
    protected void gvState_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvState_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvState_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void ddlEname_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
       
        try
        {

            string ste = "select Status from tblStudentStatus where LoginId='" + username + "' and Test_Name='" + ddlEname.SelectedValue + "' ";
            DataSet ds = cc.ExecuteDataset(ste);
           if (ds.Tables[0].Rows.Count > 0)
               status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]); 
            if (status == 1)
            {
                string s = "select tblStudentStatus.LoginId as Id ,Login1.UserName as name,Test_Name as testname ,Marks from tblStudentStatus,Login1 where login1.LoginId=tblStudentStatus.LoginId and tblStudentStatus.loginId='" + username + "' and Test_Name='" + ddlEname.SelectedValue + "' ";

                ds = cc.ExecuteDataset(s);
                gvState.DataSource = ds.Tables[0];
                gvState.DataBind();


            }
            else
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Result Not Found Because Exam Not attent.')", true);

            }

        }
        catch (SqlException ex)
        {


        }
    }

    //LinkButton1
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
       
        if (ddlEname.SelectedIndex == ddlEname.Items.Count - 1)
        {
            string str4 = "UPDATE tblStudentStatus set  Status=" + 0 + " WHERE LoginId='" + Session["username"].ToString() + "' and Test_Name='" + ddlEname.SelectedValue + "' ";
            DataSet ds = cc.ExecuteDataset(str4);


            Response.Redirect("Exam.aspx");


        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "Select Test  Name";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Test Name which you want retesting.')", true);



        }
    }
    protected void gvState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}