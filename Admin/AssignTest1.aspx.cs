using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Admin_AssignTest : System.Web.UI.Page
{
     string s,abc,cid;
    Location location = new Location();
    CommonCode cc = new CommonCode();
    ExamnameBLL ebal=new ExamnameBLL();
    BllUserLogin ubll = new BllUserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {  
         
        string Id = Convert.ToString(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
           
            if (!IsPostBack)
            {    
                GetcollegeName();
                string LoginId = Convert.ToString(Request.QueryString["Id"]);
                this.getInitialData(LoginId);
                getmenu(LoginId);

            }
        }
      
    }

    public void GetcollegeName()
    {
        ddlCompany.Items.Add("--Select--");
        DataSet ds = location.GetCollegeName();
        ddlCollege.DataSource = ds.Tables[0];
        ddlCollege.DataTextField = "Name";
        ddlCollege.DataValueField = "Id";
        ddlCollege.DataBind();
        ddlCollege.Items.Add("--Select--");
        ddlCollege.SelectedIndex = ddlCollege.Items.Count - 1;


    }
    public void getmenu(string LoginID)
{ 
       
    try{

        DataSet ds = ubll._Menu(LoginID);
        s = Convert.ToString(ds.Tables[0].Rows[0]["MenuId"]);
       
            string MenuId = "";
            foreach (ListItem lst in lstAssignedMenu.Items)
            {
                MenuId = MenuId + "," + lst.Value.ToString();
            }
            if (MenuId.Length > 1)
            {
                MenuId = MenuId.Substring(1);
            }
            string s1 = " select tblTestDefinition.Total_que from tblTestDefinition where  tblTestDefinition.Test_ID in(" +s+ ")";
          }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {
            
        }


    }
    private void getInitialData(string LoginId)
    {   
             
        

            string Sql = "Select LoginId, UserName,MenuId from Login1 where LoginId='" + LoginId + "'";
            try
            {
                DataSet ds = cc.ExecuteDataset(Sql);
                txtRoleName.Text = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                string MenuId = Convert.ToString(ds.Tables[0].Rows[0]["MenuId"]);

                MenuId = MenuId.Replace(",", "','");
                 //Sql = "Select MenuId, MenuName from MenuTest where MenuId in('" + MenuId + "') ";
                 // Sql = " select Test_ID,Exam_Topic from tblTestDefinition where  tblTestDefinition.Test_ID in('" + MenuId + "')order by Exam_Topic";

                Sql = " Select Test_ID as Id,Total_que from tblTestDefinition ,tblExamName,tblTopic,tblSubject where tblTestDefinition.examid = tblExamName.examid and tblTestDefinition.Topic_id = tblTopic.Topic_id and tblTestDefinition.Subject_id = tblSubject.Subject_id and tblTestDefinition.Test_ID in('" + MenuId + "')order by Total_que";
                ds = cc.ExecuteDataset(Sql);
                lstAssignedMenu.DataSource = ds.Tables[0];
                lstAssignedMenu.DataTextField = "Total_que";
                lstAssignedMenu.DataValueField = "Id";
                lstAssignedMenu.DataBind();

            }
            catch (Exception ex) { }
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
        catch (Exception ex)
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
   
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Sql = " Select Test_ID,Total_que from tblTestDefinition where examid=" + ddlCompany.SelectedValue + "";
        DataSet ds = cc.ExecuteDataset(Sql);
        lstMainMenu.DataSource = ds.Tables[0];
        lstMainMenu.DataTextField = "Total_que";
        lstMainMenu.DataValueField = "Test_ID";
        lstMainMenu.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lstAssignedMenu.Items.Count == 0)
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
                string LoginId = Convert.ToString(Request.QueryString["Id"]);

                string Sql = "Update Login1 set MenuId='" + MenuId + "' where LoginId='" + LoginId + "'";
                int count = cc.ExecuteNonQuery(Sql);
                if (count == 1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Login Updated successfully')", true);
                    lblError.Visible = true;
                    lblError.Text = "Login Updated successfully.";
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Login Updated successfully')", true);
                lblError.Visible = true;
                lblError.Text = "Login Updated successfully.";
                lstAssignedMenu.Text = "";
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
     
    }
    protected void ddlCollege_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectExam();
    }

    public void SelectExam()
    {
        DataSet ds = ebal.GetAllENamecid(Convert.ToInt32(ddlCollege.SelectedValue.ToString()));
        ddlCompany.DataSource = ds.Tables[0];
        ddlCompany.DataBind();
        ddlCompany.DataTextField = "Name";
        ddlCompany.DataValueField = "Id";

        ddlCompany.DataBind();
        ddlCompany.Items.Add("--Select--");
        ddlCompany.SelectedIndex = ddlCompany.Items.Count - 1;


    }
    protected void lstMainMenu_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
