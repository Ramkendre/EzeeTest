using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class html_MenuMaster : System.Web.UI.Page
{

    CommonCode cc = new CommonCode();
    string language;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Id = Convert.ToString(Request.QueryString["Id"]);
            LoadValue(Id);
            ListControlCollections();
        }
        this.Set_Page_Level_Setting();
    }
    private void ListControlCollections()
    {
        ArrayList controlList = new ArrayList();

        // AddControls(Page.Controls, controlList);
        if (Convert.ToString(Session["language"]) != null)
        {
            cc.AddCon(Page.Controls, controlList, Convert.ToString(Session["language"]));
        }

    }
    protected void Set_Page_Level_Setting()
    {
        //set page heading
        Label lblMainHeading = (Label)Master.FindControl("lblMainHeading");
        if (lblMainHeading != null)
            lblMainHeading.Text = "All menus";
    }

    private void LoadValue(string Id)
    {
        try
        {
            int Role = Convert.ToInt32(Session["Role"]);
            string Sql = " Select MenuId from Role where RoleId=" + Role + "";
            string Menus = Convert.ToString(cc.ExecuteScalar(Sql));

            if (Session["language"].ToString()=="Shivaji05")
            {
                Sql = "SELECT   MenuNameMarathi as MenuName, MenuUrl from Menu where ParentId=" + Id + " and MenuId in(" + Menus + ") order by MenuSequence  ";
                DataSet ds = cc.ExecuteDataset(Sql);
                gvMenu.DataSource = ds.Tables[0];
                gvMenu.DataBind();
                

            }
            else
            {
                Sql = "SELECT   MenuName, MenuUrl from Menu where ParentId=" + Id + " and MenuId in(" + Menus + ") order by MenuSequence  ";
                DataSet ds = cc.ExecuteDataset(Sql);
                gvMenu.DataSource = ds.Tables[0];
                gvMenu.DataBind();              
            
            }

        }
        catch (Exception ex)
        {

        }
    }

    protected void gvMenu_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
