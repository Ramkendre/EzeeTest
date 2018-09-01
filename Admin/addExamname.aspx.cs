using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Linq;


public partial class addExamname : System.Web.UI.Page
{
    Location location = new Location();
    ExamnameBLL ebal = new ExamnameBLL();
    //   AddClassBLL classbal = new AddClassBLL();
    //  SubjectBLL sbll = new SubjectBLL();
    //  Topicbll tbll = new Topicbll();

    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    int flag = 0, sel = 0, status;
    String examtxt, s;
    string abc, Sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (!IsPostBack)
        {
            GetcollegeName(); //get all college name

            loadTypeofExam();
            loadClass();
            loadChapter();
            loadSubject();
            loadTopic();


        } Set_Page_Level_Setting();
    }

    public void loadTypeofExam()
    {
        Sql = "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=6  ";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueId";
            ddlTypeofExam.DataBind();
        }
    }
    public void loadClass()
    {
        Sql = "select Name,ItemValueId from tblItemValue where ItemId=0 or ItemId=1";
        ds = cc.ExecuteDataset(Sql);
        ddlAddClass.DataSource = ds.Tables[0];
        ddlAddClass.DataTextField = "Name";
        ddlAddClass.DataValueField = "ItemValueId";
        ddlAddClass.DataBind();
    }
    public void loadSubject()
    {
        Sql = "select Name,ItemValueId from tblItemValue where ItemId =0 or ItemId=2";
        ds = cc.ExecuteDataset(Sql);
        cmbSelectsubject.DataSource = ds.Tables[0];
        cmbSelectsubject.DataTextField = "Name";
        cmbSelectsubject.DataValueField = "ItemValueId";
        cmbSelectsubject.DataBind();
    }

    public void loadChapter()
    {
        Sql = "select Name,ItemValueId from tblItemValue where ItemId=0 or ItemId=3";
        ds = cc.ExecuteDataset(Sql);
        ddlChapter.DataSource = ds.Tables[0];
        ddlChapter.DataTextField = "Name";
        ddlChapter.DataValueField = "ItemValueId";
        ddlChapter.DataBind();
    }
    public void loadTopic()
    {
        Sql = " Select Name, ItemValueId from tblItemValue where ItemId=0 or ItemId=4";
        ds = cc.ExecuteDataset(Sql);
        ddlTopic.DataSource = ds.Tables[0];
        ddlTopic.DataTextField = "Name";
        ddlTopic.DataValueField = "ItemValueId";
        ddlTopic.DataBind();
    }

    protected void Set_Page_Level_Setting()
    {
        Label lblMainHeading = (Label)Master.FindControl("lblMainHeading");
        if (lblMainHeading != null)
            lblMainHeading.Text = "Add Exam Name ";
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string Id = Convert.ToString(lblId.Text.ToString());

        if ( Id == "" || Id == null)
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
            else if (cmbSelectsubject.SelectedItem.Text == "--Select--")
            {
                lblError.Visible = true;
                lblError.Text = "Please Select Subject Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select the Subject Name')", true);

            }
            else if (ddlChapter.SelectedItem.Text == "--Select--")
            {
                lblError.Visible = true;
                lblError.Text = "Please Select Chapter Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select the Chapter Name')", true);
            }

            //if (ddlTypeofExam.SelectedItem.Text == "1st - 10th Standard")
            //{
            //    if (ddlAddClass.SelectedIndex == ddlAddClass.Items.Count - 1)
            //    {
            //        lblError.Visible = true;
            //        lblError.Text = "Please Select the Class Name";
            //        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select the class Name')", true);

            //    }
            //}

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
                    lblError.Text = "This Exam Name is already exist";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                }
                else
                {
                    ebal.Ename = txtexamname.Text;
                    ebal.Cid = Convert.ToInt32(ddlCollege.SelectedValue);
                    ebal.MediumID = Convert.ToString(ddlMedium.SelectedItem.Text);
                    ebal.Subject_id = Convert.ToInt32(cmbSelectsubject.SelectedValue);
                    ebal.Topic_id = Convert.ToInt32(ddlTopic.SelectedValue);
                    ebal.Chapter_id = Convert.ToInt32(ddlChapter.SelectedValue);
                    ebal.Classid = Convert.ToInt32(ddlAddClass.SelectedValue);
                    ebal.TypeOfExam = Convert.ToInt32(ddlTypeofExam.SelectedValue);
                    //ebal.TypeOfExam = a;
                    //if (a == "Competative")
                    //{
                    //    ebal.Classid = Convert.ToInt32(ddlAddClass.SelectedValue);
                    //}
                    //else
                    //{
                    //    ebal.Chapter_id = Convert.ToInt32(ddlChapter.SelectedValue);
                    //    ebal.Classid = Convert.ToInt32(ddlAddClass.SelectedValue);
                    //}
                    status = ebal.addnew(ebal);
                    if (status == 1)
                    {
                        txtexamname.Text = "";
                        lblError.Text = "ExamName Added Successfully";
                        lblError.Visible = true;
                        clear();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('ExamName added successfully')", true);
                        bindgridbyClassID();
                    }
                    else
                    {
                        lblError.Text = "ExamName not  Added ";
                        lblError.Visible = true;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('ExamName not added successfully')", true);
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void Update(string Id)
    {
        try
        {
            if (ddlCollege.SelectedIndex == ddlCollege.Items.Count - 1)
            {
                lblError.Visible = true;
                lblError.Text = " Plaese  Select Class Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select Class Name ')", true);
            }
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
                    ebal.MediumID = Convert.ToString(ddlMedium.SelectedItem.Text);
                    ebal.Subject_id = Convert.ToInt32(cmbSelectsubject.SelectedValue);
                    ebal.Topic_id = Convert.ToInt32(ddlTopic.SelectedValue);
                    ebal.Chapter_id = Convert.ToInt32(ddlChapter.SelectedValue);
                    ebal.Classid = Convert.ToInt32(ddlAddClass.SelectedValue);
                    ebal.TypeOfExam = Convert.ToInt32(ddlTypeofExam.SelectedValue);
                    //ebal.TypeOfExam = a;

                    //if (a == "Competative")
                    //{
                    //    ebal.Classid = Convert.ToInt32(ddlAddClass.SelectedValue);
                    //}
                    //else
                    //{
                    //    ebal.Topic_id = Convert.ToInt32(ddlTopic.SelectedValue);
                    //    ebal.Classid = Convert.ToInt32(ddlAddClass.SelectedValue);
                    //}

                    // ebal.Chapter_id = Convert.ToInt32(ddlChapter.SelectedValue);
                    //ebal.MediumID = Convert.ToString(ddlMedium.SelectedItem.Text);
                    //ebal.Subject_id = Convert.ToInt32(cmbSelectsubject.SelectedValue);

                    status = ebal._update(ebal);
                    if (status == 1)
                    {

                        // Bindgrid();
                        bindgridbyClassID();
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
                
                ddlMedium.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["MediumID"]);
                ddlTypeofExam.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TypeOfExam"]);

                if (ddlTypeofExam.SelectedItem.Text == "Cometative")
                {
                    ddlChapter.Items.Clear();
                    ddlChapter.Enabled = false;
                    ddlAddClass.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["Class_id"]);
                }
                else
                {
                    ddlChapter.Enabled = true;
                    ddlAddClass.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Class_id"]);
                    cmbSelectsubject.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Subject_id"]);
                    ddlTopic.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Topic_id"]);
                    ddlChapter.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Chapter_id"]);
                    ddlAddClass.Enabled = true;
                }
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
                    // Bindgrid();
                    bindgridbyClassID();
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
                //DataSet ds = classbal.GetAllClassNamecid(Convert.ToInt32(ddlCollege.SelectedValue.ToString()));
                //ddlAddClass.DataSource = ds.Tables[0];
                //ddlAddClass.DataTextField = "Name";
                //ddlAddClass.DataValueField = "Id";
                //ddlAddClass.DataBind();
                //ddlAddClass.Items.Add("--Select--");
                //ddlAddClass.SelectedIndex = ddlCollege.Items.Count - 1;
                //// bind grid by college name
                //BindgridByCID();
            }
        }
        catch (Exception ex)
        {
        }
    }
    public void clear()
    {
        lblError.Visible = true;
        lblId.Text = "";
        btnSubmit.Text = "Save";
        ddlCollege.SelectedIndex = ddlCollege.Items.Count - 1;
        ddlAddClass.SelectedValue = "1";
        ddlChapter.SelectedValue = "1";
        ddlTopic.SelectedValue = "1";
        cmbSelectsubject.SelectedValue = "1";
        txtexamname.Text = "";
    }
    private void Bindgrid()
    {
        DataSet ds = ebal.GetAllEName();
        gdExam.DataSource = ds.Tables[0];
        gdExam.DataBind();
    }
    public void BindgridByCID()
    {
        DataSet ds1 = ebal.GetAllENamecid(Convert.ToInt32(ddlCollege.SelectedValue.ToString()));
        gdExam.DataSource = ds1.Tables[0];
        gdExam.DataBind();
    }
    public void bindgridbyClassID()
    {

        if (ddlTypeofExam.SelectedItem.Text == "1st - 10th Standard")
        {
            gvcompetitive.Visible = false;
            DataSet ds = ebal.GetAllENameclassid(ddlTypeofExam.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdExam.DataSource = ds.Tables[0];
                gdExam.DataBind();
                gdExam.Visible = true;
            }
        }
        else
            if (ddlTypeofExam.SelectedItem.Text == "Competative")
            {
                gdExam.Visible = false;

                DataSet ds = ebal.GetAllENameclassid(ddlTypeofExam.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvcompetitive.DataSource = ds.Tables[0];
                    gvcompetitive.DataBind();
                    gvcompetitive.Visible = true;
                }
            }
    }

    protected void ddlAddClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlAddClass.SelectedIndex == ddlCollege.Items.Count - 1)
            {
                txtexamname.Text = "";
                //BindgridByCID();
            }
            else
            {
                // bindgridbyClassID();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void gdExam_RowDeleted(object sender, GridViewDeletedEventArgs e)
    { }
    protected void gdExam_RowDeleting(object sender, GridViewDeleteEventArgs e)
    { }
    protected void gdExam_SelectedIndexChanged(object sender, EventArgs e)
    { }
    protected void gdExam_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        clear();
        ddlCollege.Enabled = true;
    }
    protected void btnback_Click(object sender, EventArgs e)
    {

    }
    protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMedium.SelectedItem.Text == "")
        {
        }
        else
        {
            if (ddlTypeofExam.SelectedItem.Text == "--Select--" || ddlAddClass.SelectedValue == "--Select--" || ddlAddClass.SelectedIndex == ddlAddClass.Items.Count - 1)
            {
            }
            else
            {

            }

            if (ddlTypeofExam.SelectedItem.Text == "1st - 10th Standard")
            {
                gvcompetitive.Visible = false;
                DataSet ds = ebal.GetAllENameclassid(ddlTypeofExam.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gdExam.DataSource = ds.Tables[0];
                    gdExam.DataBind();
                    gdExam.Visible = true;
                }
            }
            else
            {
                gdExam.Visible = false;

                DataSet ds = ebal.GetAllENameclassid(ddlTypeofExam.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvcompetitive.DataSource = ds.Tables[0];
                    gvcompetitive.DataBind();
                    gvcompetitive.Visible = true;

                }
            }
        }
    }
    protected void cmbSelectsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbSelectsubject.SelectedIndex == cmbSelectsubject.Items.Count - 1)
        {
        }
        else
        {



        }
    }






    protected void ddlTypeofExam_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {

            if (ddlTypeofExam.SelectedIndex == ddlTypeofExam.Items.Count - 2)
            {
                ddlChapter.Enabled = true;
                ddlAddClass.Enabled = true;
            }
            else if (ddlTypeofExam.SelectedIndex == ddlTypeofExam.Items.Count - 1)
            {

                ddlChapter.SelectedIndex = ddlChapter.Items.Count - 1;
                ddlChapter.Enabled = false;


            }

            if (ddlTypeofExam.SelectedItem.Text == "1st - 10th Standard")
            {
                gvcompetitive.Visible = false;
                DataSet ds = ebal.GetAllENameclassid(ddlTypeofExam.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gdExam.DataSource = ds.Tables[0];
                    gdExam.DataBind();
                    gdExam.Visible = true;
                }
            }
            else
            {
                gdExam.Visible = false;

                DataSet ds = ebal.GetAllENameclassid(ddlTypeofExam.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvcompetitive.DataSource = ds.Tables[0];
                    gvcompetitive.DataBind();
                    gvcompetitive.Visible = true;

                }
            }



        }
        catch (Exception ex)
        {
        }

    }
    protected void ddlCollege_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            if (ddlCollege.SelectedIndex == ddlCollege.Items.Count - 1)
            {

                cmbSelectsubject.Items.Clear();

            }
            else
            {

                //DataSet ds = classbal.GetAllClassNamecid(Convert.ToInt32(ddlCollege.SelectedValue.ToString()));
                //ddlAddClass.DataSource = ds.Tables[0];
                //ddlAddClass.DataTextField = "Name";
                //ddlAddClass.DataValueField = "Id";

                //ddlAddClass.DataBind();
                //ddlAddClass.Items.Add("--Select--");
                //ddlAddClass.SelectedIndex = ddlAddClass.Items.Count - 1;
                //DataSet ds1 = tbll._getIntegertopic(Convert.ToInt32(ddlCollege.SelectedValue.ToString()));

            }


        }

        catch { }
    }
}
