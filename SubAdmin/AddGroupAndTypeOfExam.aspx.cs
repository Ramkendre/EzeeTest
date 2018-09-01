using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;

public partial class SubAdmin_AddGroupAndTypeOfExam : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadView1();
            loadView2();
        }

        txtmobNo.Text = Convert.ToString(Session["LoginId"]);
        txtmobNo0.Text = Convert.ToString(Session["LoginId"]);

    }
    public void loadView1()
    {
        string sql = " select [Name],[ItemValueId]  FROM [tblItemValue] where ItemValueId=257  or ItemId=0"; //  257 serverId
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(sql);
        ddlGroupExamName.DataSource = ds.Tables[0];
        ddlGroupExamName.DataTextField = "Name";
        ddlGroupExamName.DataValueField = "ItemValueId";
        ddlGroupExamName.DataBind();

    }

    public void loadView2()
    {
        string sql = " select [Name],[ItemValueId]  FROM [tblItemValue] where ItemValueId=257 or ItemId=0"; //257
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(sql);
        ddlGroupExamName0.DataSource = ds.Tables[0];
        ddlGroupExamName0.DataTextField = "Name";
        ddlGroupExamName0.DataValueField = "ItemValueId";
        ddlGroupExamName0.DataBind();


        string Sql = " select [Name],[ItemValueId] FROM [tblItemValue] where ItemValueId=1 or ItemValueId IN (258,259,260,261,262,263,264,265,266,267,268,269,270)";  //(258,259,260,261,262,263,264,265,266,267,268,269,270) 244,245,246,247,248,249,250,251,252,253,254,255,256,257

        DataSet ds1 = new DataSet();
        ds1 = cc.ExecuteDataset(Sql);
        ddltypeExam.DataSource = ds1.Tables[0];
        ddltypeExam.DataTextField = "Name";
        ddltypeExam.DataValueField = "ItemValueId";
        ddltypeExam.DataBind();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Id = Convert.ToString(lblId.Text);
        if (Id == "" || Id == null)
        {
            AddOne();
        }
        else
        {
            UpDate(Id);
        }
    }

    public void AddOne()
    {
        try
        {
            if (ddlGroupExamName.SelectedItem.Text == "--Select--")
            {
                lblError.Visible = true;
                lblError.Text = "Select Group Exam Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select Group Exam Name.')", true);
            }
            else if (txtGroupname.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Enter Group Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alter('Enter Group Name.')", true);
            }

            else
            {
                string loginid = Session["LoginId"].ToString();
                string Sql = "Select Niitaps From Login Where [LoginId]='" + loginid + "'";
                string ntps = Convert.ToString(cc.ExecuteScalar(Sql));
                if (ntps == "" || ntps == null)
                {

                }
                else if (ntps == "1")
                {
                string sql = "INSERT INTO tblDynamicGroupExam (GroupOfExamId,GroupOfExamName,InsertBy,[InsertDate]) VALUES ('" + ddlGroupExamName.SelectedValue + "','" + txtGroupname.Text + "','" + Convert.ToString(Session["LoginId"]) + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";

                int result = Convert.ToInt32(cc.ExecuteNonQuery(sql));
                if (result > 0)
                {

                    lblError.Text = "Record Saved successfully.";
                    lblError.Visible = true;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Saved successfully.')", true);
                    BindGDview1();
                    Clear();
                }
               
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);

        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Not permission to create test!!!!')", true);
    }

    public void UpDate(string Id)
    {
        try
        {
            if (ddlGroupExamName.SelectedValue == "")
            {
                lblError.Visible = true;
                lblError.Text = "Select Group Exam Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select Group Exam Name.')", true);
            }
            else if (txtGroupname.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Enter Group Exam Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Enter Type Exam Name.')", true);
            }
            else
            {
                string sql = "update tblDynamicGroupExam set GroupOfExamId='" + ddlGroupExamName.SelectedValue + "',GroupOfExamName='" + txtGroupname.Text + "' where Id='" + Id + "' ";
                int result = Convert.ToInt32(cc.ExecuteNonQuery(sql));
                if (result == 0)
                {
                    lblError.Text = "Item Not Update";
                    lblError.Visible = true;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Item Not Update')", true);
                }
                else
                {
                    lblError.Text = "Item Updated Successfully";
                    lblError.Visible = true;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Item Updated Successfully')", true);
                    BindGDview1();
                    Clear();
                }

            }
        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex += 1;

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string Id = Convert.ToString(lblId.Text.ToString());
        if (Id == "" || Id == null)
        {
            InsertRecord();
        }
        else
        {
            UpdateTE(Id);
        }

    }
    public void InsertRecord()
    {
        try
        {
            if (ddlGroupExamName0.SelectedItem.Text == "--Select--")
            {
                lblError.Visible = true;
                lblError.Text = "Please select Group Exam Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select Group Exam Name.')", true);
            }
            else if (ddltypeExam.SelectedItem.Text == "--Select--")
            {
                lblError.Visible = true;
                lblError.Text = "Please select Type Exam Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select Type Exam Name.')", true);
            }
            else if (txtTypeExam.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please enter Type Exam Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alter('Please enter Type Exam Name.')", true);
            }

            else
            {
                string loginid = Session["LoginId"].ToString();
                string Sql = "Select Niitaps From Login Where [LoginId]='" + loginid + "'";
                string ntps = Convert.ToString(cc.ExecuteScalar(Sql));
                if (ntps == "" || ntps == null)
                {

                }
                else if (ntps == "1")
                {
                     string sql = "INSERT INTO tblDynamicTypeExam (GroupOfExamId,TypeOfExamId,TypeOfExamName,InsertBy,InsertDate) VALUES ('" + ddlGroupExamName0.SelectedValue + "','" + ddltypeExam.SelectedValue + "','" + txtTypeExam.Text + "','" + Convert.ToString(Session["LoginId"]) + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";

                     int result = Convert.ToInt32(cc.ExecuteNonQuery(sql));
                     if (result > 0)
                     {

                         lblError.Text = "Record Saved successfully.";
                         lblError.Visible = true;
                         ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Saved successfully.')", true);
                         BindGDview2();
                         Clear();
                     }
                 }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Not permission to create test!!!!')", true);
    }
    public void UpdateTE(string Id)
    {
        try
        {
            if (ddlGroupExamName0.SelectedValue == "")
            {
                lblError.Visible = true;
                lblError.Text = "Select Group Exam Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select Group Exam Name')", true);
            }
            else if (ddltypeExam.SelectedValue == "")
            {
                lblError.Visible = true;
                lblError.Text = "select Type Exam Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('select Type Exam Name')", true);
            }
            else if (txtTypeExam.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Enter Type Exam Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Enter Group Exam Name')", true);
            }
            else
            {
                string sql = "update  tblDynamicTypeExam set GroupOfExamId= '" + ddlGroupExamName0.SelectedValue + "', TypeOfExamName='" + txtTypeExam.Text + "', TypeOfExamId='" + ddltypeExam.SelectedValue + "' where Id=" + Id + " ";
                int result = Convert.ToInt32(cc.ExecuteNonQuery(sql));
                if (result == 0)
                {
                    lblError.Text = "Item Not Update";
                    lblError.Visible = true;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Item Not Update')", true);
                }
                else
                {
                    lblError.Text = "Item Updated Successfully";
                    lblError.Visible = true;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Item Updated Successfully')", true);
                    BindGDview2();
                    Clear();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
    }
    public void Clear()
    {

        txtGroupname.Text = "";
        txtTypeExam.Text = "";

    }

    public void BindGDview1()
    {
        string Id = lblId.Text;
        string sql = " select tDGE.Id, tDGE.GroupOfExamId ,tDGE.GroupOfExamName  from  [tblDynamicGroupExam] tDGE where InsertBy='" + Convert.ToString(Session["LoginId"]) + "' order by Id desc ";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GDview1.DataSource = ds.Tables[0];
            GDview1.DataBind();
            GDview1.Visible = true;
        }
        else
        {
            GDview1.DataSource = ds.Tables[0];
            GDview1.DataSource = null;
        }
    }

    protected void ddlGroupExamName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGDview1();
    }
    protected void GDview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;
        if (Convert.ToString(e.CommandName) == "Modify")
        {
            btnSave.Text = "Update";

            string sql = "select tGDE.GroupOfExamId ,tGDE.GroupOfExamName from tblDynamicGroupExam tGDE where  tGDE.Id='" + lblId.Text + "'";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(sql);
            try
            {
                ddlGroupExamName.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["GroupOfExamId"]);
                txtGroupname.Text = Convert.ToString(ds.Tables[0].Rows[0]["GroupOfExamName"]);

            }
            catch (Exception ex)
            {
                Response.Write("<h4>" + ex.Message);
            }
        }
    }
    public void BindGDview2()
    {
        string sql = " select tDTE.Id,tDTE.GroupOfExamId ,tDTE.TypeOfExamName,tDTE.TypeOfExamId  from  [tblDynamicTypeExam] tDTE where InsertBy='" + Convert.ToString(Session["LoginId"]) + "' order by Id desc ";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GDview2.DataSource = ds.Tables[0];
            GDview2.DataBind();
            GDview2.Visible = true;
        }
        else
        {
            GDview1.DataSource = ds.Tables[0];
            GDview1.DataSource = null;
        }
    }
    protected void GDview2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;
        if (Convert.ToString(e.CommandName) == "Modify")
        {
            btnSubmit.Text = "Update";
            string sql = "select tDTE.GroupOfExamId,tDTE.TypeOfExamName,tDTE.TypeOfExamId from tblDynamicTypeExam tDTE where tDTE.Id='" + lblId.Text + "' ";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(sql);
            try
            {
                ddlGroupExamName0.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["GroupOfExamId"]);
                txtTypeExam.Text = Convert.ToString(ds.Tables[0].Rows[0]["TypeOfExamName"]);
                ddltypeExam.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TypeOfExamId"]);
            }
            catch (Exception ex)
            {
                Response.Write("<h4>" + ex.Message);
            }
        }

    }

    protected void ddlGroupExamName0_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGDview2();
    }

    //protected void txtGroupname_TextChanged(object sender, EventArgs e)
    //{
    //    string loginid =Convert.ToString( Session["LoginId"]);

    //    if (loginid == "9999999999")
    //    {

    //    }
    //    else
    //    {
    //        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Not permission to create test!!!!')", true);
    //    }
    //}
}