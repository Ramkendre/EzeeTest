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



public partial class addExamname : System.Web.UI.Page
{
    Location location = new Location();
    ExamnameBLL ebal = new ExamnameBLL();
    CommonCode cc = new CommonCode();
    int flag = 0, status, sel = 0;
    String examtxt, s, abc;
    protected void Page_Load(object sender, EventArgs e)
    {

        lblError.Text = "";
        if (!IsPostBack)
        {
            GetcollegeName();
            Bindgrid();
        }
        Set_Page_Level_Setting();

    }

    public void GetcollegeName()
    {
        DataSet ds = location.GetCollegeName();
        ddlCollege.DataSource = ds.Tables[0];
        ddlCollege.DataTextField = "Name";
        ddlCollege.DataValueField = "Id";

        ddlCollege.DataBind();
        ddlCollege.Items.Add("--Select--");
        ddlCollege.SelectedIndex = ddlCollege.Items.Count - 1;

    }
    protected void Set_Page_Level_Setting()
    {
        //Label lblMainHeading = (Label)Master.FindControl("lblMainHeading");
        //if (lblMainHeading != null)
        //    lblMainHeading.Text = "Exam Name";
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string Id = Convert.ToString(lblId.Text.ToString());

        if (Id == "" || Id == null)
        {
            AddNew();
        }
        else
        {
            Update(Id);
        }

    }

    private void AddNew()
    {
        try
        {
            if (ddlCollege.SelectedIndex == ddlCollege.Items.Count - 1)
            {
                lblError.Visible = true;
                lblError.Text = "Please Select the College";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select the College')", true);
            }
            else if (txtexamname.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the Exam Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the Exam Name')", true);
            }
            else
            {
                string Sql = "Select examid from tblExamName where examname='" + txtexamname.Text.ToString() + "'";
                string Id = Convert.ToString(cc.ExecuteScalar(Sql));
                if (!(Id == null || Id == ""))
                {
                    lblError.Visible = true;
                    lblError.Text = "This Name is already exist";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                }
                else
                {
                    ebal.Ename = txtexamname.Text;
                    ebal.Cid = Convert.ToInt32(ddlCollege.SelectedValue);

                    status = ebal.addnew(ebal);
                    if (status == 1)
                    {
                        Bindgrid();
                        clear();
                        lblError.Text = "Exam Name Added Successfully";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('ExamName added successfully')", true);
                    }
                    else
                    {
                        lblError.Text = "Exam Name Added Successfully";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('ExamName added successfully')", true);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    private void Update(string Id)
    {
        try
        {
            if (txtexamname.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the Exam Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the Exam Name')", true);
            }
            else
            {
                string Sql = "Select examid from tblExamName where examname='" + txtexamname.Text.ToString() + "' and examid<>" + Id + "";
                string Id1 = Convert.ToString(cc.ExecuteScalar(Sql));
                if (!(Id1 == null || Id1 == ""))
                {
                    lblError.Visible = true;
                    lblError.Text = "This Name is already exist";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                }
                else
                {
                    ebal.Eid = Convert.ToInt32(Id);
                    ebal.Ename = txtexamname.Text;
                    ebal.Cid = Convert.ToInt32(ddlCollege.SelectedValue);
                    status = ebal._update(ebal);

                    if (status == 1)
                    {
                        Bindgrid();
                        clear();
                        lblError.Text = "Exam Name updated Successfully";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Exam name updated successfully')", true);
                    }
                    else
                    {
                        clear();
                        lblError.Text = "Exam Name not updated Successfully";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Exam name not updated successfully')", true);
                    }
                }
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }

    }
    


    protected void gdExam_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gdExam.PageIndex = e.NewPageIndex;
        Bindgrid();
    }
    protected void gdExam_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;
        if (Convert.ToString(e.CommandName) == "Modify")
        {
            btnSubmit.Text = "Update";
            ebal.Eid = Convert.ToInt32(Id);
            DataSet ds = ebal._selectExamname(ebal);
            try
            {

                txtexamname.Text = Convert.ToString(ds.Tables[0].Rows[0]["examname"]);
                ddlCollege.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CompanyId"]);
            }
            catch (Exception ex)
            { }
        }

        else if (Convert.ToString(e.CommandName) == "Delete")
        {
            try
            {
                ebal.Eid = Convert.ToInt32(Id);
                status = ebal._deleteExamname(ebal);
                if (status == 1)
                {
                    Bindgrid();
                    clear();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('ExamName deleted successfully')", true);
                    lblError.Text = "Exam Name Deleted Successfully";

                }
                else
                {
                    clear();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('ExamName not deleted successfully')", true);

                }
            }
            catch (Exception ex)
            {
                lblId.Text = "";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('ex. This record reference use Other Location ')", true);
            }
        }
    }

    protected void gdExam_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void gdExam_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void ddlCollege_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCollege.SelectedIndex == ddlCollege.Items.Count - 1)
            {
                Bindgrid();
            }
            else
            {
                Collegewise();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    public void Bindgrid()
    {
        DataSet ds = ebal.GetAllEName();
        gdExam.DataSource = ds.Tables[0];
        gdExam.DataBind();
    }    
    public void Collegewise()
    {

        DataSet ds = ebal.GetAllENamecid(Convert.ToInt32(ddlCollege.SelectedValue.ToString()));
        gdExam.DataSource = ds.Tables[0];
        gdExam.DataBind();

    }

    public void clear()
    {
        lblError.Visible = true;
        lblId.Text = "";
        btnSubmit.Text = "Save";
        ddlCollege.SelectedIndex = ddlCollege.Items.Count - 1;
        txtexamname.Text = "";

    }
    protected void btnback_Click(object sender, EventArgs e)
    {
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear();
    }
}
