using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class OpratorDetails : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string sql;
    DataSet ds = new DataSet();
    int Status;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            insertOpratorList();
            Bindgrid();
        }

    }

    public void insertOpratorList()
    {
        try
        {
           // sql = "select distinct Login.LoginId,UserName,Role from Login inner join tblQuestionAccess on  Login.LoginId= tblQuestionAccess.LoginId ";

            sql = "select distinct Login.LoginId,UserName,Role.RoleName from Login inner join tblQuestionAccess on  Login.LoginId= tblQuestionAccess.LoginId " +
                "  inner join Role on Role.RoleId=Login.Role ";
 

            ds = cc.ExecuteDataset(sql);
         if(ds.Tables[0].Rows.Count>0)
         {
             for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
             {
                 sql = "select OpSNO from tblOpratorDetails where LoginId='" + Convert.ToString(ds.Tables[0].Rows[i]["LoginId"]) + "' ";
                 string Id = cc.ExecuteScalar(sql);
                 if (string.IsNullOrEmpty(Id))
                 {

                     sql = "insert into tblOpratorDetails (LoginId,OpratorName,RoleId,Flag) values " +
                         " ('" + Convert.ToString(ds.Tables[0].Rows[i]["LoginId"]) + "','" + Convert.ToString(ds.Tables[0].Rows[i]["UserName"]) + "','" + Convert.ToString(ds.Tables[0].Rows[i]["RoleName"]) + "','1') ";

                     Status = cc.ExecuteNonQuery(sql);
                     if (Status == 1)
                     {
                         Bindgrid();
                         //   ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('select Option of Break')", true);

                     }
                     else
                     {
                     }
                 }

             }
         }
 
 
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void Bindgrid()
    {
        sql = "select * from tblOpratorDetails where Flag='1' ";
        ds = cc.ExecuteDataset(sql);
        gvOprators.DataSource = ds.Tables[0];
        gvOprators.DataBind();
    }


    protected void gvOprators_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOprators.PageIndex = e.NewPageIndex;
        gvOprators.DataBind();

    }
    protected void gvOprators_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = Convert.ToString(e.CommandArgument);
        lblId.Text = id;
        if (Convert.ToString(e.CommandName) == "Modify")
        {
           
            try
            {
                sql = "select * from tblOpratorDetails where OpSNO='" + lblId.Text + "' ";
                ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtOpSNO.Text = lblId.Text;
                    txtLoginID.Text = Convert.ToString(ds.Tables[0].Rows[0]["LoginId"]);
                    txtOperatorsName.Text = Convert.ToString(ds.Tables[0].Rows[0]["OpratorName"]);
                    txtQuesCount.Text = Convert.ToString(ds.Tables[0].Rows[0]["QuesCount"]);
                    string paidStatus = Convert.ToString(ds.Tables[0].Rows[0]["PaidStatus"]);
                    if (paidStatus == "Paid")
                        rdoPaidStatus.SelectedValue = "0";
                    else
                        rdoPaidStatus.SelectedValue ="1";

                   // txtdatepayment.Text = cc.DTGet_Local(Convert.ToString(ds.Tables[0].Rows[0]["PaidDate"]));
                    txtdatepayment.Text = Convert.ToString(ds.Tables[0].Rows[0]["PaidDate"]);


                    txtAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["Amount"]);
                    chkQuesCount.Checked = false;
                }
            }
            catch
            {
            }
        }
        if (Convert.ToString(e.CommandName) == "Delete")
        {
            sql = "update tblOpratorDetails set Flag='0' where OpSNO='" + Convert.ToString(lblId.Text) + "' ";
            Status = cc.ExecuteNonQuery(sql);
            if (Status == 1)
            {
                clear();
                Bindgrid();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Details deleted successfully')", true);

            }
        }

    }
    protected void gvOprators_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvOprators_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (lblId.Text != "")
        {
            sql="update tblOpratorDetails set QuesCount='"+txtQuesCount.Text+"' ,PaidStatus='"+rdoPaidStatus.SelectedItem.Text+"' , "+ 
                " PaidDate='"+Convert.ToString(txtdatepayment.Text)+"' ,Amount='"+txtAmount.Text+"', "+ 
                " PaidLoginId='"+Convert.ToString(Session["LoginId"])+"' where OpSNO='"+Convert.ToString(lblId.Text)+"' ";
            Status=cc.ExecuteNonQuery(sql);
            if(Status==1)
            {
                lblError.Text="Details updated successfully ";
                lblError.Visible=true;
                Bindgrid();
                clear();
                 ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Details updated successfully')", true);

            }
            else
            {
                 lblError.Text="Details not updated successfully ";
                lblError.Visible=true;
             
                 ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Details not updated successfully')", true);

            }

            
        }
    }

    public void clear()
    {
        lblError.Visible = false;
        lblId.Text = "";
        
        txtAmount.Text = "";
        txtdatepayment.Text = "";
        txtLoginID.Text = "";
        txtOperatorsName.Text = "";
        txtOpSNO.Text = "";
        txtQuesCount.Text = "";
        chkQuesCount.Checked = false;
        rdoPaidStatus.ClearSelection();

    }
    protected void chkQuesCount_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            string id1=Convert.ToString(txtLoginID.Text);
            if (id1 != "")
            {
                sql = "select COUNT (*) from tblQuestionAccess where tblQuestionAccess.LoginId='" + id1 + "' ";
                string count = cc.ExecuteScalar(sql);
                txtQuesCount.Text = count;
            }
        }
        catch
        {
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear();
    }
}
