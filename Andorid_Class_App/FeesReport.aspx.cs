using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Andorid_Class_App_FeesReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    string Sql;
    decimal total = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadDetails();
        }

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
        try
        {
            if (ddlBatch.SelectedItem.Text == "--Select--")
            {
                lblError.Visible = true;
                lblError.Text = "Please select Batch";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select Batch!!!!')", true);


            }
            else if (ddlSession.SelectedItem.Text == "--Select--")
            {
                lblError.Visible = true;
                lblError.Text = "Please select Session";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select Session!!!!')", true);

            }
            else
            {

                bindgrid();
            }
        }
        catch (Exception ex)
        {
            
        }


    }




    public void bindgrid()
    {
        if (ddlsearchby.SelectedValue == "0")
        {
            //select * from [tblStudentFees] where feesdate between '2014-04-12' and '2014-04-29'
            string dsaf = txtfromdate.Text;
            string dz = txtTodate.Text;


            Sql = "select tblStudentFees.SNO,StudentName ,feesdate,ReceiptNo,Amount,sum(Amount) over()as grandTotal from tblStudentFees inner join tblClassSetting on tblStudentFees.ClassSetting_id= tblClassSetting.ClassSetting_id " +
           " where  tblStudentFees.LoginId='" + Convert.ToString(Session["LoginId"]) + "' and feesdate between '" + txtfromdate.Text + "' and '" + txtTodate.Text + "' and tblStudentFees.ClassSetting_id=(select ClassSetting_id from tblClassSetting where Class_Id='" + ddlClass.SelectedValue + "' and  Batch='" + ddlBatch.SelectedItem.Text + "' and  Session='" + ddlSession.SelectedItem.Text + "' and Login_Id='" + Convert.ToString(Session["LoginId"]) + "') ";
            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvFessReport.Columns[1].Visible = true;
                tr_DStudentname.Visible = false;
            }
        }
        else if (ddlsearchby.SelectedValue == "1" && ddlStudent.SelectedItem.Text!="--Select--") // student
        {


            Sql = "select tblStudentFees.SNO,StudentName ,feesdate,ReceiptNo,Amount,sum(Amount) over()as grandTotal  from tblStudentFees inner join tblClassSetting on tblStudentFees.ClassSetting_id= tblClassSetting.ClassSetting_id  inner join Login on  tblStudentFees.LoginId=Login.LoginId   inner join CompanyMaster on CompanyMaster.CompanyId=Login.CompanyId  " +
           " where  tblStudentFees.LoginId='" + Convert.ToString(Session["LoginId"]) + "' and tblStudentFees.StudentName='" + ddlStudent.SelectedItem.Text + "' and tblStudentFees.ClassSetting_id=(select ClassSetting_id from tblClassSetting where Class_Id='" + ddlClass.SelectedValue + "' and  Batch='" + ddlBatch.SelectedItem.Text + "' and  Session='" + ddlSession.SelectedItem.Text + "' and Login_Id='" + Convert.ToString(Session["LoginId"]) + "') ";
            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvFessReport.Columns[1].Visible = false;
                tr_DStudentname.Visible = true;
                lblDStudentName.Text = ddlStudent.SelectedItem.Text;
            }

        }



        if (ds.Tables[0].Rows.Count > 0)
        {
            gvFessReport.DataSource = ds.Tables[0];
            gvFessReport.DataBind();

           

            lblDschoolname.Text = Convert.ToString(Session["DisplayName"]);
            lblDClass.Text = "Class: " + Convert.ToString(ddlClass.SelectedItem.Text);
            lblDSession.Text = "Session: " + Convert.ToString(ddlSession.SelectedItem.Text);
            lblDBatch.Text = "Batch: " + Convert.ToString(ddlBatch.SelectedItem.Text);
        }


    }


    public void clear()
    {
        lblHpaid.Text = "";
        lblHRemainFess.Text = "";
        lblHTotalfees.Text = "";
    }
    protected void ddlsearchby_SelectedIndexChanged(object sender, EventArgs e)
    {
        clear();
        try
        {
            if (ddlsearchby.SelectedValue == "0")
            {
                Tr_date.Visible = true;
                Tr_stud.Visible = false;
                gvFessReport.DataSource = null;
                gvFessReport.DataBind();
                divHData.Visible = false;
            }
            else if (ddlsearchby.SelectedValue == "1")
            {
                Tr_date.Visible = false;
                Tr_stud.Visible = true;
                BindStudentName();
                gvFessReport.DataSource = null;
                gvFessReport.DataBind();

            }

        }
        catch
        {
        }
    }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if ((ddlClass.SelectedItem.Text == "--Select--") || (ddlBatch.SelectedItem.Text == "--Select--"))
            {
                pnl1.Visible = false;
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


    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if ((ddlClass.SelectedItem.Text == "--Select--") || (ddlBatch.SelectedItem.Text == "--Select--") || (ddlSession.SelectedItem.Text == "--Select--"))
            {
                pnl1.Visible = false;
                lblError.Visible = true;
                lblError.Text = "Please select all field !!";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select all field !!')", true);
            }
            else
            {
                pnl1.Visible = true;
            }
        }
        catch
        {
        }
    }

    public void BindStudentName()
    {
        //Sql = "select SNO,First_Name +' '+Father_Name+' '+Last_Name as name from tblStudentRegister "+
        //    " where  LoginId='" + Convert.ToString(Session["LoginId"]) + "' and ClassSetting_id=(select ClassSetting_id from tblClassSetting where Class_Id='" + ddlClass.SelectedValue + "' and  Batch='" + ddlBatch.SelectedItem.Text + "' and  Session='" + ddlSession.SelectedItem.Text + "' and Login_Id='" + Convert.ToString(Session["LoginId"]) + "') order by SNO DESC ";

        Sql = " select distinct tblStudentFees.StudentName as name from tblStudentRegister inner join  tblStudentFees " +
            " on tblStudentFees.StudentName=tblStudentRegister.First_Name +' '+Father_Name+' '+Last_Name " +
            " where  tblStudentFees.LoginId='" + Convert.ToString(Session["LoginId"]) + "' and tblStudentFees.ClassSetting_id=(select ClassSetting_id from tblClassSetting where Class_Id='" + ddlClass.SelectedValue + "' and  Batch='" + ddlBatch.SelectedItem.Text + "' and  Session='" + ddlSession.SelectedItem.Text + "' and Login_Id='" + Convert.ToString(Session["LoginId"]) + "') order by name DESC ";
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

    int tempTotal = 0;
    protected void gvFessReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (ddlsearchby.SelectedValue == "1") //student
        {
            // gvFessReport.Columns[0].HeaderStyle.Width = 10;
            gvFessReport.Columns[6].Visible = false;
            divHData.Visible = true;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                decimal price = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
                lblAmount.Text = price.ToString();
                total += price;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int calcu = 0;
                Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                lblTotal.Text = total.ToString();

                divHData.Visible = true;
                lblHTotalfees.Text = "Total  Fees :" + txtTotalfees.Text;
                lblHpaid.Text = "Total Paid Fees :" + total;

                if (lblTotal.Text != "")
                {
                    calcu = Convert.ToInt32(txtTotalfees.Text) - Convert.ToInt32(total);
                }

                lblHRemainFess.Text = "Total Remaining Fees :" + Convert.ToString(calcu);
            }
        }
        else if (ddlsearchby.SelectedValue == "0")
        {
            gvFessReport.Columns[6].Visible = true;
            // divHData.Visible = false;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int temp = 0;

                Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                decimal price = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
                lblAmount.Text = price.ToString();
                total += price;


                Label lblremaingPaid = (Label)e.Row.FindControl("lblremaingPaid");
                int amount = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Amount"));



                temp = Convert.ToInt32(txtTotalfees.Text) - amount;

                lblremaingPaid.Text = Convert.ToString(temp);
                tempTotal += temp;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                lblTotal.Text = total.ToString();

                Label lnlTotalFessRemaining = (Label)e.Row.FindControl("lnlTotalFessRemaining");
                lnlTotalFessRemaining.Text = Convert.ToString(tempTotal);


            }
        }




    }

}