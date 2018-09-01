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

public partial class Andorid_Class_App_Attendance : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string Sql;
    int status;
    DataSet ds = new DataSet();
    string EntryDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            loadDetails();
        }
        Dateformat();
    }

    public void Dateformat()
    {
        DateTime dt = DateTime.Now;
        dt=dt.AddHours(12.50);
        DateTime SystemDate = Convert.ToDateTime(dt);
        EntryDate = SystemDate.ToString("yyyy'-'MM'-'dd''");
       // EntryDate = SystemDate.ToString("dd'-'MM'-'yyyy''");
        lblDate.Text = EntryDate;


    }


    public void loadDetails()
    {
        try
        {
            Sql = "select distinct Class_Id,Name from  tblClassSetting inner join tblItemValue on tblClassSetting.Class_Id=tblItemValue.ItemValueId  where Login_Id='" + Convert.ToString(Session["LoginId"]) + "' ";
            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlClass.DataSource = ds.Tables[0];
                ddlClass.DataTextField = ds.Tables[0].Columns["Name"].ToString();
                ddlClass.DataValueField = ds.Tables[0].Columns["Class_Id"].ToString();
                ddlClass.DataBind();
                ddlClass.Items.Add("--Select--");
                ddlClass.SelectedIndex = ddlClass.Items.Count - 1;             
            }
        }
        catch
        {

        }
    }

    protected void gvclassSetting_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if ((ddlClass.SelectedItem.Text == "--Select--") || (ddlBatch.SelectedItem.Text == "--Select--") || (ddlSession.SelectedItem.Text == "--Select--"))
            {
                lblError.Visible = true;
                lblError.Text = "Please select all field !!";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select all field !!')", true);
            }
            else
            {

                Sql = "select SNO,First_Name,Last_Name,Father_Name from tblStudentRegister where  LoginId='" + Convert.ToString(Session["LoginId"]) + "' and ClassSetting_id=(select ClassSetting_id from tblClassSetting where Class_Id='" + ddlClass.SelectedValue + "' and  Batch='" + ddlBatch.SelectedItem.Text + "' and  Session='" + ddlSession.SelectedItem.Text + "' and  Login_Id='" + Convert.ToString(Session["LoginId"]) + "')  order by SNO DESC ";
                
                ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvAttendance.DataSource = ds.Tables[0];
                    gvAttendance.DataBind();
                }
                else
                {
                    gvAttendance.DataSource = null;
                    gvAttendance.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
           
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DateTime dtfinal = Convert.ToDateTime(lblDate.Text);



        Sql = "select ClassSetting_id from tblClassSetting where  Class_Id='" + ddlClass.SelectedValue + "'  and Batch='" + ddlBatch.SelectedItem.Text + "' and Session='" + ddlSession.SelectedItem.Text + "' and  Login_Id='" + Convert.ToString(Session["LoginId"]) + "' ";
        string ClassSetting_id = cc.ExecuteScalar(Sql);

        for (int i = 0; i < gvAttendance.Rows.Count; i++)
        {
           // string FN = gvAttendance.Rows[i].Cells[1].Text;
           // string LN = gvAttendance.Rows[i].Cells[2].Text;
           // string FatherName = gvAttendance.Rows[i].Cells[3].Text;

            string StudentRegSNO = gvAttendance.Rows[i].Cells[0].Text;


            RadioButtonList rdo = (RadioButtonList)gvAttendance.Rows[i].Cells[4].FindControl("rbd_attendance");


         //   Sql = "select SNO from tblStudentRegister where  First_Name='" + FN + "' and Last_Name='" + LN + "' and Father_Name ='" + FatherName + "' and ClassSetting_id='" + ClassSetting_id + "' and  LoginId ='" + Convert.ToString(Session["LoginId"]) + "' ";
           // string StudentRegSNO = cc.ExecuteScalar(Sql);


            Sql = "select SNO from tblAttendance where  StudentRegSNO="+StudentRegSNO+" and  LoginId='" + Convert.ToString(Session["LoginId"]) + "' and attenDate='" +Convert.ToDateTime(dtfinal) + "' and  ClassSetting_id=" + ClassSetting_id + " ";
            string SNO = Convert.ToString(cc.ExecuteScalar(Sql));
            if (SNO == "")
            {

                Sql = " insert  into tblAttendance( StudentRegSNO,ClassSetting_id,Present,LoginId,attenDate) values " +
                    " (" + StudentRegSNO + "," + ClassSetting_id + ",'" + rdo.SelectedItem.Text + "','" + Convert.ToString(Session["LoginId"]) + "','" +Convert.ToDateTime(dtfinal) + "' ) ";
                status = cc.ExecuteNonQuery(Sql);
                if (status == 1)
                {
                    lblError.Visible = true;
                    lblError.Text = "Record submitted successfully !!";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record submitted successfully !!')", true);

                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Record not submitted successfully !!";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record not submitted successfully !!')", true);

                }
            }
            else
            {
                Sql = " update tblAttendance set  StudentRegSNO=" + StudentRegSNO + ",ClassSetting_id="+ClassSetting_id+" ,Present='" + rdo.SelectedItem.Text + "',LoginId='" + Convert.ToString(Session["LoginId"]) + "',attenDate='" +Convert.ToDateTime(dtfinal) + "'  where SNO=" + SNO + " ";
                status = cc.ExecuteNonQuery(Sql);
                if (status == 1)
                {
                    lblError.Visible = true;
                    lblError.Text = "Record updated successfully !!";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record updated successfully !!')", true);

                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Record not updated successfully !!";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record not updated successfully !!')", true);

                }
            }
        }
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClass.SelectedItem.Text == "--Select--")
        {

            ddlBatch.Items.Clear();
            ddlSession.Items.Clear();
            gvAttendance.DataSource = null;
            gvAttendance.DataBind();
        }
        else
        {
            Sql = "select distinct Batch from  tblClassSetting  where Login_Id='" + Convert.ToString(Session["LoginId"]) + "' and Class_Id=" + ddlClass.SelectedValue + " ";
            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlBatch.DataSource = ds.Tables[0];
                ddlBatch.DataTextField = ds.Tables[0].Columns["Batch"].ToString();
                ddlBatch.DataBind();
                ddlBatch.Items.Add("--Select--");
                ddlBatch.SelectedIndex = ddlBatch.Items.Count - 1;


            }
        }

    }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if ((ddlClass.SelectedItem.Text == "--Select--") || (ddlBatch.SelectedItem.Text == "--Select--"))
            {

                ddlSession.Items.Clear();
                gvAttendance.DataSource = null;
                gvAttendance.DataBind();

                lblError.Visible = true;
                lblError.Text = "Please select all field !!";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select all field !!')", true);
            }
            else
            {
                Sql = "select distinct Session from  tblClassSetting  where Login_Id='" + Convert.ToString(Session["LoginId"]) + "' and Batch='" + ddlBatch.SelectedValue + "' ";
                ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    ddlSession.DataSource = ds.Tables[0];
                    ddlSession.DataTextField = ds.Tables[0].Columns["Session"].ToString();
                    ddlSession.DataBind();
                    ddlSession.Items.Add("--Select--");
                    ddlSession.SelectedIndex = ddlSession.Items.Count - 1;
                }
               
            }
        }
        catch (Exception ex)
        {
            
        }
    }
}
