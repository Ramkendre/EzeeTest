using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_CompanyList : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            load();
        }
        this.Set_Page_Level_Setting();
    }
    protected void Set_Page_Level_Setting()
    {
        //set page heading
        Label lblMainHeading = (Label)Master.FindControl("lblMainHeading");
        if (lblMainHeading != null)
            lblMainHeading.Text = "School/College Master";
    }


    public void load()
    {
        string companyID = Convert.ToString(Session["CompanyId"]);
        if ((Convert.ToString(Session["LoginId"]) == "ADMIN"))
        {
            LoadValue();
        }
        else
        {
            if (companyID == "0")
            {
                Response.Redirect("Company.aspx");
            }
            else
            {
                Response.Redirect("Company.aspx?Id=" + companyID);
            }
        }
    }

    private void LoadValue()
    {
        try
        {

            string Sql = " SELECT  CompanyMaster.CompanyId, CompanyMaster.CompanyName, CompanyMaster.Address1, " +
                         " TalukaMaster.TalukaName FROM CompanyMaster inner JOIN " + " TalukaMaster ON CompanyMaster.CityId = TalukaMaster.TalukaId Order by CompanyMaster.CompanyId Desc ";

            DataSet ds = cc.ExecuteDataset(Sql);
            gvCompany.DataSource = ds.Tables[0];
            gvCompany.DataBind();
        }
        catch (Exception ex)
        {
            Response.Redirect("<h4>" + ex.Message);
        }
    }

    protected void gvCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCompany.PageIndex = e.NewPageIndex;
        LoadValue();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        Response.Redirect("Company.aspx");
    }
    protected void gvCompany_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;

        if (Convert.ToString(e.CommandName) == "Modify")
        {
            Response.Redirect("Company.aspx?Id=" + Id);
        }
        else if (Convert.ToString(e.CommandName) == "View")
        {
            Response.Redirect("CompanyView.aspx?Id=" + Id);
        }

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
    protected void gvCompany_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("UploadCenterCode.aspx");
    }
}
