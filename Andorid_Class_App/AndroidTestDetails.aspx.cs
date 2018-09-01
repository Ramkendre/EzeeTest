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
using System.IO;

public partial class Andorid_Class_App_AndroidTestDetails : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    string Sql,EntryDate;
    int status;


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
        DateTime SystemDate = Convert.ToDateTime(dt);
        //EntryDate = SystemDate.ToString("yyyy'-'MM'-'dd''");
        EntryDate = SystemDate.ToString("dd'-'MM'-'yyyy''");
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
                BindGrid(); 
            }
        }
        catch(Exception ex)
        {
        }
    }

    public void BindGrid()
    {
       // Sql = "select SNO,First_Name,Last_Name,Father_Name from tblStudentRegister where Class_Name='" + ddlClass.SelectedItem.Text + "' and  Batch='" + ddlBatch.SelectedItem.Text + "' and  classSession='" + ddlSession.SelectedItem.Text + "' and LoginId='" + Convert.ToString(Session["LoginId"]) + "' ";
        Sql = "select SNO,First_Name,Last_Name,Father_Name from tblStudentRegister where  LoginId='" + Convert.ToString(Session["LoginId"]) + "' and ClassSetting_id=(select ClassSetting_id from tblClassSetting where Class_Id='" + ddlClass.SelectedValue + "' and  Batch='" + ddlBatch.SelectedItem.Text + "' and  Session='" + ddlSession.SelectedItem.Text + "' and Login_Id='" + Convert.ToString(Session["LoginId"]) + "') order by SNO DESC ";

        ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvTestDetails.DataSource = ds.Tables[0];
            gvTestDetails.DataBind();
        }
        else
        {
            gvTestDetails.DataSource = null;
            gvTestDetails.DataBind();
        }
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClass.SelectedItem.Text == "--Select--")
        {
            ddlBatch.Items.Clear();
            ddlSession.Items.Clear();
            gvTestDetails.DataSource = null;
            gvTestDetails.DataBind();
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
                gvTestDetails.DataSource = null;
                gvTestDetails.DataBind();

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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Sql = "select ClassSetting_id from tblClassSetting where  Class_Id='" + ddlClass.SelectedValue + "'  and Batch='" + ddlBatch.SelectedItem.Text + "' and Session='" + ddlSession.SelectedItem.Text + "' and  Login_Id='" + Convert.ToString(Session["LoginId"]) + "' ";
        string ClassSetting_id = cc.ExecuteScalar(Sql);

        for (int i = 0; i < gvTestDetails.Rows.Count; i++)
        {
           // string FN = gvTestDetails.Rows[i].Cells[1].Text;
          //  string LN = gvTestDetails.Rows[i].Cells[2].Text;
           // string FatherName = gvTestDetails.Rows[i].Cells[3].Text;

            string StudentRegSNO = gvTestDetails.Rows[i].Cells[0].Text;


            TextBox txtobtainedmarks = (TextBox)gvTestDetails.Rows[i].Cells[4].FindControl("txtObtainedMarks");

            if (txtobtainedmarks.Text != "")
            {

               // Sql = "select SNO from tblStudentRegister where  First_Name='" + FN + "' and Last_Name='" + LN + "' and Father_Name ='" + FatherName + "' and LoginId ='" + Convert.ToString(Session["LoginId"]) + "' ";
               // string StudentRegSNO = cc.ExecuteScalar(Sql);

                Sql = "select SNO from tblAndroidTestDetails where TestNo ='" + txtTestNo.Text + "' and   StudentRegSNO=" + StudentRegSNO + " and ClassSetting_id=" + ClassSetting_id + "  and LoginId='" + Convert.ToString(Session["LoginId"]) + "' ";                    
                string SNO = Convert.ToString(cc.ExecuteScalar(Sql));
                if (SNO == "")
                {

                    Sql = " insert  into tblAndroidTestDetails( StudentRegSNO,ClassSetting_id,LoginId,Testdate,OutofMark,ObtainedMark,TestNo,TestTopic,TestName) values " +
                        " (" + StudentRegSNO + "," + ClassSetting_id + ",'" + Convert.ToString(Session["LoginId"]) + "','" + txtdate.Text + "' , " +
                        "  " + Convert.ToInt32(txtOutOf.Text) + "," + Convert.ToInt32(txtobtainedmarks.Text) + "," + Convert.ToInt32(txtTestNo.Text) + ",'" + txtTestTopic.Text + "','" + txtTestName.Text + "'  ) ";
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


                    Sql = " update tblAndroidTestDetails set  StudentRegSNO="+StudentRegSNO+",ClassSetting_id="+ClassSetting_id+",LoginId='" + Convert.ToString(Session["LoginId"]) + "',Testdate='" + txtdate.Text + "' , " +
                       " OutofMark=" + Convert.ToInt32(txtOutOf.Text) + ",ObtainedMark=" + Convert.ToInt32(txtobtainedmarks.Text) + ",TestNo=" + Convert.ToInt32(txtTestNo.Text) + ",TestTopic='" + txtTestTopic.Text + "',TestName='" + txtTestName.Text + "'  where SNO=" + SNO + " ";
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
        clear();
    }
    protected void gvTestDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTestDetails.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        clear();
    }

    public void clear()
    {
        txtOutOf.Text = "";
        txtTestName.Text = "";
        txtTestNo.Text = "";
        txtTestTopic.Text = "";
    }

    protected void txtTestNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlClass.SelectedItem.Text == "--Select--")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Class,Batch,Session')", true);

                txtTestNo.Text = "";

            }
            else if (ddlBatch.SelectedItem.Text == "--Select--")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Class,Batch,Session')", true);

                txtTestNo.Text = "";
            }
            else if (ddlSession.SelectedItem.Text == "--Select--")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Class,Batch,Session')", true);

                txtTestNo.Text = "";

            }
            else
            {


                Sql = "select ClassSetting_id from tblClassSetting where  Class_Id='" + ddlClass.SelectedValue + "'  and Batch='" + ddlBatch.SelectedItem.Text + "' and Session='" + ddlSession.SelectedItem.Text + "' and  Login_Id='" + Convert.ToString(Session["LoginId"]) + "' ";
                string ClassSetting_id = cc.ExecuteScalar(Sql);

                Sql = "select * from tblAndroidTestDetails where TestNo ='" + txtTestNo.Text + "' and  ClassSetting_id='" + ClassSetting_id + "' and  LoginId='" + Convert.ToString(Session["LoginId"]) + "' order by StudentRegSNO desc ";
                 ds =cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count>0)
                {
                    txtTestNo.ForeColor = System.Drawing.Color.Red;

                    txtTestNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["TestNo"]);
                    txtTestName.Text = Convert.ToString(ds.Tables[0].Rows[0]["TestName"]);
                    txtOutOf.Text = Convert.ToString(ds.Tables[0].Rows[0]["OutofMark"]);
                    txtdate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Testdate"]);
                    txtTestTopic.Text = Convert.ToString(ds.Tables[0].Rows[0]["TestTopic"]);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string StudentSno = Convert.ToString(ds.Tables[0].Rows[i]["StudentRegSNO"]);

                        string  Id =Convert.ToString( gvTestDetails.DataKeys[i].Values["SNO"]);
                       // string ab =Convert.ToString( gvTestDetails.Rows[i].Cells[0].Text);

                        if (Id== StudentSno)
                        {
                       
                            ((TextBox)gvTestDetails.Rows[i].Cells[4].FindControl("txtObtainedMarks")).Text = Convert.ToString(ds.Tables[0].Rows[i]["ObtainedMark"]); ;

                       }
                    }

                }
                else
                {
                    txtOutOf.Text = "";
                    txtTestName.Text = "";
                   
                    txtTestTopic.Text = "";
                   // ((TextBox)gvTestDetails.FindControl("txtObtainedMarks")).Text = "";
                   // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Test Number is already exist')", true);

                }

            }
        }


        catch (Exception ex)
        {
        }

    }
}