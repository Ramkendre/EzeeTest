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

public partial class Andorid_Class_App_FeesDetails : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string Sql;
    int status;
    DataSet ds = new DataSet();
    DateTime dtfinal = new DateTime();
    string EntryDate;
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (IsPostBack == false)
        {
            loadDetails();
            Dateformat();
        }
      
    }

    public void Dateformat()
    {
        DateTime dt = DateTime.Now;
        DateTime SystemDate = Convert.ToDateTime(dt);
        SystemDate = SystemDate.AddHours(12.50);
        EntryDate = SystemDate.ToString("yyyy'-'MM'-'dd''");
       // EntryDate =SystemDate.ToString("dd'-'MM'-'yyyy''");
        txtdate.Text = EntryDate;
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        dtfinal = Convert.ToDateTime(txtdate.Text);
        //dt2 = dt2.AddHours(12.50);



        try
        {
            Sql = "select ClassSetting_id from tblClassSetting where  Class_Id='" + ddlClass.SelectedValue + "'  and Batch='" + ddlBatch.SelectedItem.Text + "' and Session='" + ddlSession.SelectedItem.Text + "' and  Login_Id='" + Convert.ToString(Session["LoginId"]) + "' ";
            string ClassSetting_id = cc.ExecuteScalar(Sql);

            Sql = "select SNO from tblStudentFees where StudentName='" + ddlStudent.SelectedItem.Text + "' and ClassSetting_id=" + ClassSetting_id + " and ReceiptNo=" + Convert.ToInt32(txtRecept.Text) + " ";
            string sno = Convert.ToString(cc.ExecuteScalar(Sql));

            if (sno == "")
            {
                Sql = " insert  into tblStudentFees(StudentName,ClassSetting_id,LoginId,feesdate, ReceiptNo,Amount,Remark) values " +
                        " ('" + ddlStudent.SelectedItem.Text + "'," + ClassSetting_id + ", '" + Convert.ToString(Session["LoginId"]) + "','" + Convert.ToDateTime(dtfinal) + "' , " +
                        "  " + Convert.ToInt32(txtRecept.Text) + "," + Convert.ToInt32(txtAmount.Text) + ",'" + txtRemark.Text + "' ) ";
                status = cc.ExecuteNonQuery(Sql);
                if (status == 1)
                {
                    // string studName1=ddlStudent.SelectedItem.Text;
                    bindstudentFees();
                    txtRecept.Text = "";
                    lblError.Visible = true;
                    lblError.Text = "Record submitted successfully !!!";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record submitted successfully !!')", true);
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Record not submitted successfully !!!";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record not submitted successfully !!')", true);
                }
            }
            else
            {
                bindstudentFees();
                lblError.Visible = true;
                lblError.Text = "Receipt Number is already exist !!";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Receipt Number is already exist !!')", true);

            }

            //Sql = " update tblStudentFees set StudentName='" + ddlStudent.SelectedItem.Text + "' ,ClassName='" + ddlClass.SelectedItem.Text + "',Class_id='" + ddlClass.SelectedValue + "',Batch='" + ddlBatch.SelectedItem.Text + "', " +
            //   " Session='" + ddlSession.SelectedItem.Text + "',LoginId='" + Convert.ToString(Session["LoginId"]) + "',feesdate='" + txtdate.Text + "' , " +
            //   " ReceiptNo=" + Convert.ToInt32(txtRecept.Text) + ",Amount=" + Convert.ToInt32(txtAmount.Text) + ",Remark=" + Convert.ToInt32(txtRemark.Text) + " where SNO=" + SNO + " ";
            //status = cc.ExecuteNonQuery(Sql);
            //if (status == 1)
            //{
            //    lblError.Visible = true;
            //    lblError.Text = "Record updated successfully !!";
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record updated successfully !!')", true);

            //}
            //else
            //{
            //    lblError.Visible = true;
            //    lblError.Text = "Record not updated successfully !!";
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record not updated successfully !!')", true);

            //}

        }
        catch
        {
        }
    }

    public void bindstudentFees()
    {
        Sql = "select ClassSetting_id from tblClassSetting where  Class_Id='" + ddlClass.SelectedValue + "'  and Batch='" + ddlBatch.SelectedItem.Text + "' and Session='" + ddlSession.SelectedItem.Text + "' and  Login_Id='" + Convert.ToString(Session["LoginId"]) + "' ";
        string ClassSetting_id = cc.ExecuteScalar(Sql);

        Sql = "select * from tblStudentFees where StudentName='" + ddlStudent.SelectedItem.Text + "' and LoginId='" + Convert.ToString(Session["LoginId"]) + "' and  ClassSetting_id=" + ClassSetting_id + " ";
        ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvFeesDetails.DataSource = ds.Tables[0];
            gvFeesDetails.DataBind();
        }
        else
        {
            gvFeesDetails.DataSource = null;
            gvFeesDetails.DataBind();

        }


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
                BindStudentName();
            }
        }
        catch
        {
        }
    }


    public void BindStudentName()
    {
        Sql = "select SNO,First_Name +' '+Father_Name+' '+Last_Name as name from tblStudentRegister where  LoginId='" + Convert.ToString(Session["LoginId"]) + "' and ClassSetting_id=(select ClassSetting_id from tblClassSetting where Class_Id='" + ddlClass.SelectedValue + "' and  Batch='" + ddlBatch.SelectedItem.Text + "' and  Session='" + ddlSession.SelectedItem.Text + "' and Login_Id='" + Convert.ToString(Session["LoginId"]) + "') order by SNO DESC ";

        ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlStudent.DataSource = ds.Tables[0];
            ddlStudent.DataTextField = "name";
            ddlStudent.DataBind();
            ddlStudent.Items.Add("--Select--");
            ddlStudent.SelectedIndex = ddlStudent.Items.Count - 1;

        }
        else
        {
            ddlStudent.Items.Clear();
        }
    }

    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClass.SelectedItem.Text == "--Select--")
        {
            ddlBatch.Items.Clear();
            ddlSession.Items.Clear();
            ddlStudent.Items.Clear();
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
                ddlStudent.Items.Clear();
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
        catch
        {
        }
    }
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindstudentFees();
    }
    protected void txtRecept_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlClass.SelectedItem.Text == "--Select--")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Class,Batch,Session')", true);

                txtRecept.Text = "";

            }
            else if (ddlBatch.SelectedItem.Text == "--Select--")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Class,Batch,Session')", true);

                txtRecept.Text = "";
            }
            else if (ddlSession.SelectedItem.Text == "--Select--")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Class,Batch,Session')", true);

                txtRecept.Text = "";

            }
            else
            {
                Sql = "select ClassSetting_id from tblClassSetting where  Class_Id='" + ddlClass.SelectedValue + "'  and Batch='" + ddlBatch.SelectedItem.Text + "' and Session='" + ddlSession.SelectedItem.Text + "' and  Login_Id='" + Convert.ToString(Session["LoginId"]) + "' ";
                string ClassSetting_id = cc.ExecuteScalar(Sql);

                Sql = "select ReceiptNo from tblStudentFees where ReceiptNo ='" + txtRecept.Text + "' and  ClassSetting_id='" + ClassSetting_id + "' and  LoginId='" + Convert.ToString(Session["LoginId"]) + "' ";
                string ReceiptNo = Convert.ToString(cc.ExecuteScalar(Sql));
                if (!String.IsNullOrEmpty(ReceiptNo))
                {
                    txtRecept.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Receipt Number is already exist')", true);

                }
                else
                {
                    txtRecept.ForeColor = System.Drawing.Color.Black;
                }

            }
        }


        catch (Exception ex)
        {
        }


    }
}
