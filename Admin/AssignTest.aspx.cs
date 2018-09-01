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

    protected void Page_Load(object sender, EventArgs e)
    {  
           abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
         
        string Id = Convert.ToString(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
           
            if (!IsPostBack)
            {
                 
                //GetcollegeName();
                string LoginId = Convert.ToString(Request.QueryString["Id"]);
                this.getInitialData(LoginId);
                getCollege(LoginId);
               // getmenu(LoginId);

            }
        }
       // this.Set_Page_Level_Setting(Id);
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
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
    try{
       string sql="select MenuId from Login1 where LoginId='"+LoginID+"'";
       SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            lstAssignedMenu.Items.Clear();
             while (dr.Read())
            {

            s=(dr.GetValue(0).ToString());
              }
            dr.Close();

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
            con.Close();
        }

}
    public void setexam()
    {
           using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc)) 
       
        try
        {
            string Sql = "select examname from tblExamName where CompanyId=" + Session["companyid"].ToString() + " order by examname";
          
            //string Sql = "Select examname  from tblExamName order by examname   ";
            SqlCommand cmd = new SqlCommand(Sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ddlCompany.Items.Clear();
            ddlCompany.Items.Add("--select--");
            while (dr.Read())
            {

                ddlCompany.Items.Add(dr.GetValue(0).ToString());
            }
            dr.Close();
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

    private void getCollege(string LoginId)
    {

        // setexam();

        string Sql = "Select CompanyId from Login1 where LoginId='" + LoginId + "'";
        try
        {
            DataSet ds = cc.ExecuteDataset(Sql);
            cid = Convert.ToString(ds.Tables[0].Rows[0]["CompanyId"]);

            ddlCompany.Items.Add("--Select--");
            ds = location.GetCollegeNamecid(cid);
            ddlCollege.DataSource = ds.Tables[0];
            ddlCollege.DataTextField = "Name";
            ddlCollege.DataValueField = "Id";

            ddlCollege.DataBind();
            ddlCollege.Items.Add("--Select--");
            ddlCollege.SelectedIndex = ddlCollege.Items.Count - 1;
           
        }
        catch (Exception ex) { }
    }
    private void getInitialData(string LoginId)
    {   
             
          // setexam();

            string Sql = "Select LoginId, UserName,MenuId from Login1 where LoginId='" + LoginId + "'";
            try
            {
                DataSet ds = cc.ExecuteDataset(Sql);
                txtRoleName.Text = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                string MenuId = Convert.ToString(ds.Tables[0].Rows[0]["MenuId"]);
                MenuId = MenuId.Replace(",", "','");
                Sql = " select Test_ID,Total_que from tblTestDefinition where  tblTestDefinition.Test_ID in('" + MenuId + "')order by Exam_Topic";
                //Sql = "Select MenuId, MenuName from MenuTest where MenuId in('" + MenuId + "') ";
                ds = cc.ExecuteDataset(Sql);
                lstAssignedMenu.DataSource = ds.Tables[0];
                lstAssignedMenu.DataTextField = "Total_que";
                lstAssignedMenu.DataValueField = "Test_ID";
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
        string Sql = " Select Test_ID,Total_que from tblTestDefinition where Examid='" + ddlCompany.SelectedValue+ " '";
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
                //string LoginId = Convert.ToString(Session["LoginId"]);

               // string Sql = "insert into tblTestAssign (Assign_Test,Assingn_Menu,LoginId,Test_ID)values('" + lstAssignedMenu.SelectedItem + "','" + ddlCollege. SelectedValue + "','" + LoginId + "','" + ddlCompany.SelectedValue + "')";

               string Sql = "Update Login1 set MenuId='" + MenuId + "' where LoginId='" + LoginId + "'";
                int count = cc.ExecuteNonQuery(Sql);
                if (count == 1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Login Updated successfully')", true);
                    lblError.Visible = true;
                    lblError.Text = "Assign  successfully.";
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
        ddlCollege.SelectedIndex = ddlCollege.Items.Count - 1;
        ddlCompany.SelectedIndex=ddlCompany.Items.Count-1;
        lstMainMenu.Items.Clear();
        lstAssignedMenu.Items.Clear();

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
