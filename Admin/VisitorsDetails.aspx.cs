using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Admin_VisitorsDetails : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    string Sql;
    int status;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }

    }

    protected void ddlsortby_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlsortby.SelectedValue == "0")
            {
                bindnullgrid();
                pnl1.Visible = false;
            }
            if (ddlsortby.SelectedValue == "1")
            {
                bindnullgrid();
                pnl1.Visible = true;
                trdate.Visible = true;
                trloginname.Visible = false;
                trrole.Visible = false;

            }
            if (ddlsortby.SelectedValue == "2")
            {
                bindnullgrid();
                pnl1.Visible = true;
                trloginname.Visible = true;
                trdate.Visible = false;
                trrole.Visible = false;
                bindroleloginname();
            }
            if (ddlsortby.SelectedValue == "3")
            {
                pnl1.Visible = false;           
                loaddata();

            }
            if (ddlsortby.SelectedValue == "4")
            {
                bindnullgrid();
                pnl1.Visible = true;
                trrole.Visible = true;
                trdate.Visible = false;
                trloginname.Visible = false;

                bindrole();

            }
        }
        catch
        {

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        loaddata();

    }


    public void bindnullgrid()
    {
        gvVisitors.DataSource = null;
        gvVisitors.DataBind();
    }
    public void bindroleloginname()
    {
        Sql = " select distinct[Loginname] from [VisitorIPDetails]";
        ds = cc.ExecuteDataset(Sql);
        ddlLoginname.DataSource = ds.Tables[0];
        ddlLoginname.DataTextField = "Loginname";
        ddlLoginname.DataBind();
        ddlLoginname.Items.Add("--Select--");
        ddlLoginname.SelectedIndex = ddlLoginname.Items.Count - 1;
    }


    public void bindrole()
    {
        Sql = " select distinct [VisitorIPDetails].[RoleId],Role.RoleName from Role inner join [VisitorIPDetails]   on [VisitorIPDetails].[RoleId]=Role.RoleId ";
        ds = cc.ExecuteDataset(Sql);
        ddlrole.DataSource = ds.Tables[0];
        ddlrole.DataTextField = "RoleName";
        ddlrole.DataValueField = "RoleId";
        ddlrole.DataBind();
        ddlrole.Items.Add("--Select--");
        ddlrole.SelectedIndex = ddlrole.Items.Count - 1;

    }


   
    protected void gvVisitors_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvVisitors.PageIndex = e.NewPageIndex;
        loaddata();

    }

    public void loaddata()
    {
        try
        {
            Sql = "  select [VisitorId]  ,[VisitDateTime]  ,[IPAdd] ,[Loginname] ,Login.UserName ,CompanyMaster.DisplayName,Role.RoleName,[NumofVisit] " +
               "  from [VisitorIPDetails] inner join Role   on [VisitorIPDetails].[RoleId]=Role.RoleId  left outer join CompanyMaster on CompanyMaster.CompanyId=[VisitorIPDetails].[School_Collegename] inner join Login on  Login.LoginId=[VisitorIPDetails].Loginname " +
               "    ";
            if (txtdate.Text!=""  && ddlsortby.SelectedValue == "1")
            {
                string date = Convert.ToString(cc.DTInsert_Local(txtdate.Text));

                Sql = Sql + "where cast(VisitDateTime as date)='" + date + "' order by VisitorId desc  ";
            }
           
            if (ddlLoginname.SelectedIndex != ddlLoginname.Items.Count - 1 && ddlsortby.SelectedValue == "2")
            {
                Sql = Sql + " where [VisitorIPDetails].[Loginname]='" + ddlLoginname.SelectedValue + "' order by [VisitDateTime] desc ";
            }
            if (ddlsortby.SelectedValue == "3")
            {
                Sql = Sql + " order by [NumofVisit] desc";
            }
            if (ddlrole.SelectedIndex != ddlrole.Items.Count - 1 && ddlsortby.SelectedValue == "4")
            {
                Sql = Sql + " where [VisitorIPDetails].[RoleId]='" + ddlrole.SelectedValue + "' order by [VisitDateTime] desc ";
            }
            
            ds = cc.ExecuteDataset(Sql);
            gvVisitors.DataSource = ds;
            gvVisitors.DataBind();
        }
        catch (Exception ex)
        {
        }

    }
}