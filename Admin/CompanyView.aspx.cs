using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_CompanyView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Id = Convert.ToString(Request.QueryString["Id"]);
        if (!Page.IsPostBack)
        {
            if (Id != "" && Id != null)
            {

                this.GetCompanyValue(Id);
            }
            
            
        }
        this.Set_Page_Level_Setting();
    }

    protected void Set_Page_Level_Setting()
    {
        //set page heading
        Label lblMainHeading = (Label)Master.FindControl("lblMainHeading");
        
            if (lblMainHeading != null)
                lblMainHeading.Text = "View College/School Details";
        
    }
    private void GetCompanyValue(string Id)
    {
        
        string sql1 = " Select CompanyMaster.CompanyId, CompanyMaster.CompanyName," + 
                      " CompanyMaster.DisplayName, CompanyMaster.MobileNo1,CompanyMaster.MobileNo2," + 
                      " CompanyMaster.PhoneNo1, CompanyMaster.PhoneNo2, CompanyMaster.FaxNo," + 
                      " CompanyMaster.CityId,CompanyMaster.Address1, CompanyMaster.Address2, CompanyMaster.EmailId," +
                      " CompanyMaster.PinCode,CompanyMaster.Active,TalukaMaster.TalukaName,TalukaMaster.TalukaID," +
                      " TalukaMaster.CityID,CityMaster.CityName,DistrictMaster.DistrictName," +
                      " StateMaster.StateName " +
                 " from CompanyMaster inner join " + 
                      " TalukaMaster on TalukaMaster.TalukaID=CompanyMaster.CityID inner join " +
                      " CityMaster on CityMaster.CityID=TalukaMaster.CityID inner join " +
                      " DistrictMaster on CityMaster.DistrictID=DistrictMaster.DistrictID inner join " +
                      " StateMaster on StateMaster.StateID=DistrictMaster.StateID " +
                 " where CompanyMaster.CompanyId='"+Id+"'";

        try
        {
            CommonCode cc = new CommonCode();
            DataSet ds = cc.ExecuteDataset(sql1);
            lblId.Text = Id;
            lblCompanyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
            lblDisplayName.Text = Convert.ToString(ds.Tables[0].Rows[0]["DisplayName"]);
            lblMobileNo1.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo1"]);
            lblMobileNo2.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo2"]);
            lblPhone1.Text = Convert.ToString(ds.Tables[0].Rows[0]["PhoneNo1"]);
            lblPhone2.Text = Convert.ToString(ds.Tables[0].Rows[0]["PhoneNo2"]);
            lblFaxNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["FaxNo"]);

            lblAddress1.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address1"]);
            lblAddress2.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address2"]);
            lblEmailId.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailId"]);
            lblPinCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["PinCode"]);

            lblStateName.Text  = Convert.ToString(ds.Tables[0].Rows[0]["StateName"]);
            lblDisrictName.Text = Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
            lblCityName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CityName"]);
           // lblId.Text = Id.ToString();


        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
    }
  
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CompanyList.aspx");
    }
}
