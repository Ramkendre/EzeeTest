using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;


public partial class Admin_UserView : System.Web.UI.Page
{

    CommonCode cc = new CommonCode();
    string language;
    protected void Page_Load(object sender, EventArgs e)
    {
        string Id = Convert.ToString(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            if (Id != "" && Id != null)
            {

                this.GetUserValue(Id);
            }


        }
        this.Set_Page_Level_Setting();
    }

    protected void Set_Page_Level_Setting()
    {
        //set page heading
        Label lblMainHeading = (Label)Master.FindControl("lblMainHeading");

        if (lblMainHeading != null)
            lblMainHeading.Text = "View User Details";

    }
    private void GetUserValue(string Id)
    {
        string Sql = " SELECT   Login.LoginId,Login.UserType, Login.UserName, Login.Password, Login.ContactNo, " +
                     " Login.Address, Login.DOJ, Login.Role, Login.CompanyId, Login.Active, " +
                     " Role.RoleName, CompanyMaster.DisplayName  " +
                     " FROM         Login INNER JOIN  " +
                     " Role ON Login.Role = Role.RoleId left outer JOIN " +
                     " CompanyMaster ON Login.CompanyId = CompanyMaster.CompanyId " +
                     " WHERE     (Login.LoginId = '" + Id + "')";

        try
        {
            CommonCode cc = new CommonCode();
            DataSet ds = cc.ExecuteDataset(Sql);
            lblUserName.Text = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
            lblPassword.Text = cc.DESDecrypt(Convert.ToString(ds.Tables[0].Rows[0]["Password"]));
            lblContactNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ContactNo"]);
            lblAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);

            lblRole.Text = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
            lblCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["DisplayName"]);
            lblusertype.Text = Convert.ToString(ds.Tables[0].Rows[0]["UserType"]);


            lblId.Text = Id.ToString();
            lblDOJ.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOJ"]).ToString("dd-MM-yyyy");

        }
        catch (Exception ex)
        {
            string error = ex.Message;
        }
    }
    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("UserList.aspx");
    //}
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
}