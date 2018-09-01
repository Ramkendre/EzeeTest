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

public partial class Admin_AssignChapter : System.Web.UI.Page
{
    Location location = new Location();
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    CommanDDLbindclass Cds = new CommanDDLbindclass();
    int flag = 0, sel = 0, status;
    String examtxt, s;
    string abc, Sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (!IsPostBack)
        {
            string UserName = Convert.ToString(Request.QueryString["Id"]);
            lblUserName.Text = UserName;
            bindgridgvAssignChapter();
            BindgvChapter();
            Cds.loadGroupofExam(ddlGroupofExam);
            //Sql = "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=8 ";
            //DataSet ds = cc.ExecuteDataset(Sql);

            //ddlGroupofExam.DataSource = ds.Tables[0];
            //ddlGroupofExam.DataTextField = "Name";
            //ddlGroupofExam.DataValueField = "ItemValueId";
            //ddlGroupofExam.DataBind();
        }
    }

    public void bindgridgvAssignChapter()
    {

        Sql = "  Select tblAssignChapter.SNO as Id, Chapter_id as ItemValueId,TypeofMaterial,tblItemValue1.Name as Class_id , tblItemValue3.Name as Subject_id, tblItemValue4.Name as TypeOfExam " +
             "  from tblAssignChapter inner join tblItemValue as tblItemValue1 on tblItemValue1.ItemValueId =tblAssignChapter.Class_id " +
             " inner join  tblItemValue as tblItemValue3 on tblItemValue3.ItemValueId=tblAssignChapter.Subject_id " +
             "  inner join  tblItemValue as tblItemValue4 on tblItemValue4.ItemValueId=tblAssignChapter.TypeOFExam " +
             "  where LoginId='" + Session["LoginId"] + "' and AssignUserName='" + lblUserName.Text + "' order by Id desc ";

        DataSet ds = cc.ExecuteDataset(Sql);
        gvAssignChapter.DataSource = ds.Tables[0];
        gvAssignChapter.DataBind();
        gvAssignChapter.Visible = true;
    }

    #region commented Lines loaddropdown
    //public void loadTypeofExam()
    //{
    //    Sql = "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=6  ";
    //    DataSet ds = cc.ExecuteDataset(Sql);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        ddlTypeofExam.DataSource = ds.Tables[0];
    //        ddlTypeofExam.DataTextField = "Name";
    //        ddlTypeofExam.DataValueField = "ItemValueId";
    //        ddlTypeofExam.DataBind();
    //    }
    //}
    //public void loadClass()
    //{
    //    Sql = "select Name,ItemValueId from tblItemValue where ItemId=0 or ItemId=1";
    //    ds = cc.ExecuteDataset(Sql);
    //    ddlAddClass.DataSource = ds.Tables[0];
    //    ddlAddClass.DataTextField = "Name";
    //    ddlAddClass.DataValueField = "ItemValueId";
    //    ddlAddClass.DataBind();
    //}
    //public void loadSubject()
    //{
    //    Sql = "select Name,ItemValueId from tblItemValue where ItemId =0 or ItemId=2";
    //    ds = cc.ExecuteDataset(Sql);
    //    cmbSelectsubject.DataSource = ds.Tables[0];
    //    cmbSelectsubject.DataTextField = "Name";
    //    cmbSelectsubject.DataValueField = "ItemValueId";
    //    cmbSelectsubject.DataBind();
    //}

    //public void loadChapter()
    //{
    //    Sql = "select Name,ItemValueId from tblItemValue where ItemId=0 or ItemId=3";
    //    ds = cc.ExecuteDataset(Sql);
    //    ddlChapter.DataSource = ds.Tables[0];
    //    ddlChapter.DataTextField = "Name";
    //    ddlChapter.DataValueField = "ItemValueId";
    //    ddlChapter.DataBind();
    //}
    #endregion

    protected void ddlTypeofExam_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void BindgvChapter()
    {
        Sql = "select ItemValueId,Name from tblItemValue where ItemId=3";
        ds = cc.ExecuteDataset(Sql);
        gvChapter.DataSource = ds.Tables[0];
        gvChapter.DataBind();
        gvChapter.Visible = true;

    }

    string ItemValueId;

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

    public void AddNew()
    {
        try
        {
            if (rdoTypeofMaterial.SelectedValue == "0" && ddlAddClass.SelectedValue == "1")
            {
                lblError.Text = "Please Select Class Name";
                lblError.Visible = true;
                Response.Write("<script LANGUAGE='JavaScript' >alert('Please Select Class Name')</script>");
            }
            else if (rdoTypeofMaterial.SelectedValue == "1" && ddlTypeofExam.SelectedValue == "1")
            {
                lblError.Text = "Please Select Type Of Exam Name";
                lblError.Visible = true;
                Response.Write("<script LANGUAGE='JavaScript' >alert('Please Select Type Of Exam Name')</script>");
            }
            else
            {
                if (rdoTypeofMaterial.SelectedIndex == 0)
                {
                    Sql = "select SNO from tblAssignChapter where  Class_id ='" + ddlAddClass.SelectedValue + "' " +
                          " and Subject_id='" + cmbSelectsubject.SelectedValue + "' and TypeofMaterial='" + rdoTypeofMaterial.SelectedItem.Text + "' " +
                          "  and LoginId='" + Session["LoginId"] + "' and AssignUserName='" + lblUserName.Text + "' ";
                }
                else
                {
                    Sql = "select SNO from tblAssignChapter where TypeOFExam='" + ddlTypeofExam.SelectedValue + "'  " +
                        " and Subject_id='" + cmbSelectsubject.SelectedValue + "' and TypeofMaterial='" + rdoTypeofMaterial.SelectedItem.Text + "' " +
                        "  and LoginId='" + Session["LoginId"] + "' and AssignUserName='" + lblUserName.Text + "' ";
                }

                string Id = Convert.ToString(cc.ExecuteScalar(Sql));
                if (Id != "")
                {
                    lblError.Text = "Already Chapter Assign";
                    lblError.Visible = true;
                    Response.Write("<Script>alert('Already Chapter Assign !!!!!!! ')</Script>");
                }
                else
                {
                    addchapselect();
                    ItemValueId = TextBox1.Text;

                    Sql = "insert into tblAssignChapter (Chapter_id,Subject_id,Class_id,TypeOFExam,LoginId,AssignUserName,TypeofMaterial) values('" + ItemValueId + "' ," + cmbSelectsubject.SelectedValue + " ," + ddlAddClass.SelectedValue + "," + ddlTypeofExam.SelectedValue + " ,'" + Session["LoginId"] + "','" + lblUserName.Text + "','" + rdoTypeofMaterial.SelectedItem.Text + "') ";
                    flag = cc.ExecuteNonQuery(Sql);
                    if (flag == 1)
                    {
                        lblError.Text = "Chapter Assign Successfully";
                        lblError.Visible = true;
                        rdoTypeofMaterial.ClearSelection();
                        Response.Write("<Script>alert('Assign Chapter Successfully!!! ')</Script>");

                        clear();
                        bindgridgvAssignChapter();
                    }
                    else
                    {
                        lblError.Text = "Chapter not  Assign";
                        lblError.Visible = true;
                        Response.Write("<Script>alert('Chapter not  Assign!!! ')</Script>");
                    }
                }
            }
        }
        catch
        {
        }

    }

    public void addchapselect()
    {
        TextBox1.Text = "";

        for (int i = 0; i < gvChapter.Rows.Count; i++)
        {
            CheckBox chkbox = (CheckBox)gvChapter.Rows[i].Cells[2].FindControl("chkSelect");
            if (chkbox != null)
            {
                if (chkbox.Checked == true)
                {
                    TextBox1.Text += Convert.ToString(gvChapter.Rows[i].Cells[0].Text) + ",";
                    string Name = Convert.ToString(gvChapter.Rows[i].Cells[1].Text);
                }
            }
            chkbox.Checked = false;
        }
        if (TextBox1.Text != "")
            TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.Length - 1);
    }


    public void Update(string Id)
    {
        try
        {
            if (rdoTypeofMaterial.SelectedValue == "0" && ddlAddClass.SelectedValue == "1")
            {
                lblError.Text = "Please Select Class Name";
                lblError.Visible = true;
                Response.Write("<Script>alert('Please Select Class Name ')</Script>");
            }
            else if (rdoTypeofMaterial.SelectedValue == "1" && ddlTypeofExam.SelectedValue == "1")
            {
                lblError.Text = "Please Select Type Of Exam Name";
                lblError.Visible = true;
                Response.Write("<script>alert('Please Select Type Of Exam Name')</script>");
            }
            else
            {

                addchapselect();
                ItemValueId = TextBox1.Text;

                Sql = "Update tblAssignChapter set Chapter_id='" + ItemValueId + "',TypeofMaterial='" + rdoTypeofMaterial.SelectedItem.Text + "' ,Subject_id=" + cmbSelectsubject.SelectedValue + " ,Class_id=" + ddlAddClass.SelectedValue + ",TypeOFExam=" + ddlTypeofExam.SelectedValue + ",LoginId='" + Session["LoginId"] + "' where SNO='" + Id + "' ";
                flag = cc.ExecuteNonQuery(Sql);
                if (flag == 1)
                {
                    lblError.Text = "Chapter Assign Update Successfully";
                    rdoTypeofMaterial.ClearSelection();
                    Response.Write("<script>alert('Assign Chapter Updated Successfully')</script>");
                    lblError.Visible = true;
                    bindgridgvAssignChapter();
                    clear();
                    btnSubmit.Text = "Submit";
                }
                else
                {
                    lblError.Text = "Chapter Not Assign ";
                    Response.Write("<script>alert('Chapter Not Assign ')</script>");
                }
                lblId.Text = "";
            }
        }
        catch
        {
        }
    }

    public void clear()
    {
        ddlGroupofExam.SelectedValue = "1";
        ddlAddClass.SelectedValue = "1";
        ddlTypeofExam.SelectedValue = "1";
        cmbSelectsubject.SelectedValue = "1";

        btnSubmit.Text = "Submit";
    }

    protected void gvAssignChapter_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;

        clear();
        if (Convert.ToString(e.CommandName) == "Modify")
        {
            btnSubmit.Text = "Update";
            try
            {

                foreach (GridViewRow row in gvChapter.Rows) // coding for clear checked selected previous
                {
                    var cb = row.FindControl("chkSelect") as CheckBox;
                    if (cb != null)
                        cb.Checked = false;

                }

                int Id1 = Convert.ToInt32(Id);
                Sql = "select TypeOFExam,Class_id,AssignUserName,TypeofMaterial,Chapter_id,Subject_id from tblAssignChapter where SNO=" + Id1 + " and AssignUserName='" + lblUserName.Text + "' ";
                ds = cc.ExecuteDataset(Sql);

                string s = Convert.ToString(ds.Tables[0].Rows[0]["TypeofMaterial"]);
                rdoTypeofMaterial.SelectedIndex = 1;
                if (s == "Class")
                    rdoTypeofMaterial.SelectedIndex = 0;

                ddlTypeofExam.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TypeOFExam"]);
                ddlAddClass.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Class_id"]);
                cmbSelectsubject.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Subject_id"]);
                lblUserName.Text = Convert.ToString(ds.Tables[0].Rows[0]["AssignUserName"]);

                TextBox1.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chapter_id"]);

                string[] top = TextBox1.Text.Split(',');

                int j;

                foreach (GridViewRow r in gvChapter.Rows)
                {
                    CheckBox chk = (CheckBox)r.FindControl("chkSelect");
                    string ItemValueId = r.Cells[0].Text.ToString();

                    for (j = 0; j < top.Length; j++)
                    {
                        string k = Convert.ToString(top[j]);

                        if (ItemValueId == k)
                        {
                            chk.Checked = true;
                        }
                        else
                        {
                            //chk.Checked = false;
                        }
                    }
                }
            }
            catch
            {
            }
        }
        else if (Convert.ToString(e.CommandName) == "Delete")
        {
            try
            {
                int Id1 = Convert.ToInt32(Id);
                Sql = "delete from tblAssignChapter where SNO=" + Id1 + " ";
                flag = cc.ExecuteNonQuery(Sql);
                if (flag == 1)
                {
                    lblError.Text = "Assign Chapter Deleted Successfully";
                    lblError.Visible = true;
                    bindgridgvAssignChapter();
                }
                else
                {
                    lblError.Text = "Assign Chapter Not Deleted ";
                    lblError.Visible = true;
                }
                lblId.Text = "";

            }
            catch (Exception ex)
            {
                string err = ex.InnerException.Message;
            }

        }

    }
    protected void gvAssignChapter_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvAssignChapter_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void gvAssignChapter_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void gvAssignChapter_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        clear();

        foreach (GridViewRow row in gvChapter.Rows) // coding for clear checked selected previous
        {
            var cb = row.FindControl("chkSelect") as CheckBox;
            if (cb != null)
                cb.Checked = false;

        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {

    }

    protected void gvChapter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvChapter.PageIndex = e.NewPageIndex;
        BindgvChapter();
    }
    protected void gvAssignChapter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssignChapter.PageIndex = e.NewPageIndex;
        bindgridgvAssignChapter();
    }
    protected void gvChapter_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void rdoTypeofMaterial_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoTypeofMaterial.SelectedValue == "0")
        {
            Label7.Visible = true;
            Label6.Visible = false;
            RequiredFieldValidator8.Enabled = true;
            RequiredFieldValidator7.Enabled = false;
        }
        else
        {
            Label7.Visible = false;
            Label6.Visible = true;
            RequiredFieldValidator8.Enabled = false;
            RequiredFieldValidator7.Enabled = true;
        }

    }
    protected void gvChapter_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvChapter_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }


    #region ddlGroupofExam

    //protected void binddropdown212()
    //{
    //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=212 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlTypeofExam.DataSource = ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //protected void BindDropDown213()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 213 ";
    //    DataSet DS = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = DS.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //protected void BindDropDown214()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 214 ";
    //    DataSet DS = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = DS.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown273()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 273 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown274()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 274 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown275()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 275 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown276()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 276 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown277()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 277 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown278()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 278 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //public void binddropdown279()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 445";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    protected void ddlGroupofExam_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string groupExamid = ddlGroupofExam.SelectedValue;
        Cds.BindTypeofExamOnGroup(ddlTypeofExam, groupExamid);
        //if (ddlGroupofExam.SelectedValue == Convert.ToString(135))
        //{
        //    binddropdown212();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(136))
        //{
        //    BindDropDown213();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(137))
        //{
        //    BindDropDown214();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(140))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=210  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(141))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=207  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(142))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=206  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(143))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=203  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(144))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=205  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(177))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=1796  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(178))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=1806  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(183))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=1846  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(231))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=2310  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(232))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=2310  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(233))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=2310  ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(257))
        //{
        //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 257";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlTypeofExam.DataSource = ds.Tables[0];
        //    ddlTypeofExam.DataTextField = "Name";
        //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
        //    ddlTypeofExam.DataBind();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(273))
        //{
        //    binddropdown273();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(274))
        //{
        //    binddropdown274();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(275))
        //{
        //    binddropdown275();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(276))
        //{
        //    binddropdown276();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(277))
        //{
        //    binddropdown277();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(278))
        //{
        //    binddropdown278();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(445))
        //{
        //    binddropdown279();
        //}
    }

    #endregion

    #region ddlTypeofExam

    //protected void binddropdown211()
    //{
    //    ddlAddClass.Enabled = true;
    //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=211 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlAddClass.DataSource = ds.Tables[0];
    //    ddlAddClass.DataTextField = "Name";
    //    ddlAddClass.DataValueField = "ItemValueIdNew";
    //    ddlAddClass.DataBind();
    //}

    //protected void binddropdown202()
    //{
    //    ddlAddClass.Enabled = true;
    //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=202 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlAddClass.DataSource = ds.Tables[0];
    //    ddlAddClass.DataTextField = "Name";
    //    ddlAddClass.DataValueField = "ItemValueIdNew";
    //    ddlAddClass.DataBind();
    //}
    //protected void binddropdown201()
    //{
    //    ddlAddClass.Enabled = true;
    //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=201 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlAddClass.DataSource = ds.Tables[0];
    //    ddlAddClass.DataTextField = "Name";
    //    ddlAddClass.DataValueField = "ItemValueIdNew";
    //    ddlAddClass.DataBind();
    //}
    //protected void bindropdown2()
    //{
    //    Sql = Sql + "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=2 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    cmbSelectsubject.DataSource = ds.Tables[0];
    //    cmbSelectsubject.DataTextField = "Name";
    //    cmbSelectsubject.DataValueField = "ItemValueId";
    //    cmbSelectsubject.DataBind();
    //    ddlAddClass.SelectedValue = "1";
    //    ddlAddClass.Enabled = false;
    //}
    protected void ddlTypeofExam_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string classORSubject = ddlTypeofExam.SelectedValue;
        Cds.BindClassOrSubject(ddlAddClass, classORSubject, cmbSelectsubject);
        //if (ddlTypeofExam.SelectedValue == Convert.ToString(88))
        //{
        //    binddropdown201();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(271))
        //{
        //    binddropdown201();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(272))
        //{
        //    binddropdown201();
        //}

        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(98))
        //{
        //    binddropdown202();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(99))
        //{
        //    binddropdown202();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(100))
        //{
        //    binddropdown202();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(96))
        //{
        //    binddropdown211();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(101))
        //{
        //    binddropdown211();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(102))
        //{
        //    binddropdown211();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(89))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(94))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(95))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(130))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(110))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=204 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    cmbSelectsubject.DataSource = ds.Tables[0];
        //    cmbSelectsubject.DataTextField = "Name";
        //    cmbSelectsubject.DataValueField = "ItemValueIdNew";
        //    cmbSelectsubject.DataBind();
        //    ddlAddClass.SelectedValue = "1";
        //    ddlAddClass.Enabled = false;
        //}

        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(103))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(165))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(179))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(180))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(176))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(184))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(185))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(191))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(193))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(200) || ddlTypeofExam.SelectedValue == Convert.ToString(201) || ddlTypeofExam.SelectedValue == Convert.ToString(202) || ddlTypeofExam.SelectedValue == Convert.ToString(203) || ddlTypeofExam.SelectedValue == Convert.ToString(204) || ddlTypeofExam.SelectedValue == Convert.ToString(205) || ddlTypeofExam.SelectedValue == Convert.ToString(206) || ddlTypeofExam.SelectedValue == Convert.ToString(207))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(217))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(224))
        //{
        //    ddlAddClass.Enabled = true;
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=201 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    ddlAddClass.DataSource = ds.Tables[0];
        //    ddlAddClass.DataTextField = "Name";
        //    ddlAddClass.DataValueField = "ItemValueIdNew";
        //    ddlAddClass.DataBind();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(227))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(228))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(229))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(230))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(234))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(235))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(236))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(237))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(248))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(254))
        //{
        //    bindropdown2();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(258) || ddlTypeofExam.SelectedValue == Convert.ToString(259) || ddlTypeofExam.SelectedValue == Convert.ToString(260) || ddlTypeofExam.SelectedValue == Convert.ToString(261) || ddlTypeofExam.SelectedValue == Convert.ToString(262) || ddlTypeofExam.SelectedValue == Convert.ToString(263) || ddlTypeofExam.SelectedValue == Convert.ToString(264) || ddlTypeofExam.SelectedValue == Convert.ToString(265))
        //{
        //    binddropdown201();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(266) || ddlTypeofExam.SelectedValue == Convert.ToString(267) || ddlTypeofExam.SelectedValue == Convert.ToString(268) || ddlTypeofExam.SelectedValue == Convert.ToString(269) || ddlTypeofExam.SelectedValue == Convert.ToString(270))
        //{
        //    binddropdown201();
        //}
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(446) || ddlTypeofExam.SelectedValue == Convert.ToString(447) || ddlTypeofExam.SelectedValue == Convert.ToString(448) || ddlTypeofExam.SelectedValue == Convert.ToString(449))
        //{
        //    bindropdown2();
        //}
    }
    #endregion

    #region ddlAddClass

    protected void ddlAddClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        string addClassIDNew = ddlAddClass.SelectedValue;
        Cds.BindAddSubjectOnClassId(cmbSelectsubject, addClassIDNew, ddlTypeofExam);
        //for (int count = 0; count < 15; count++)
        //{
        //    if (ddlAddClass.SelectedValue == Convert.ToString(count))
        //    {
        //        Sql = Sql + "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=2 ";
        //        DataSet ds = cc.ExecuteDataset(Sql);

        //        cmbSelectsubject.DataSource = ds.Tables[0];
        //        cmbSelectsubject.DataTextField = "Name";
        //        cmbSelectsubject.DataValueField = "ItemValueId";
        //        cmbSelectsubject.DataBind();
        //    }
        //}
        //if ((ddlAddClass.SelectedValue == Convert.ToString(15) || ddlAddClass.SelectedValue == Convert.ToString(16)) && ddlTypeofExam.SelectedValue == Convert.ToString(99))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemId=0 or ItemIdNew=209 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    cmbSelectsubject.DataSource = ds.Tables[0];
        //    cmbSelectsubject.DataTextField = "Name";
        //    cmbSelectsubject.DataValueField = "ItemValueIdNew";
        //    cmbSelectsubject.DataBind();
        //}

        //else if ((ddlAddClass.SelectedValue == Convert.ToString(15) || ddlAddClass.SelectedValue == Convert.ToString(16)) && (ddlTypeofExam.SelectedValue == Convert.ToString(98) || ddlTypeofExam.SelectedValue == Convert.ToString(100)))
        //{
        //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=208 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    cmbSelectsubject.DataSource = ds.Tables[0];
        //    cmbSelectsubject.DataTextField = "Name";
        //    cmbSelectsubject.DataValueField = "ItemValueIdNew";
        //    cmbSelectsubject.DataBind();
        //}
        //else if (ddlAddClass.SelectedValue == Convert.ToString(188))
        //{
        //    Sql = Sql + "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=2 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    cmbSelectsubject.DataSource = ds.Tables[0];
        //    cmbSelectsubject.DataTextField = "Name";
        //    cmbSelectsubject.DataValueField = "ItemValueId";
        //    cmbSelectsubject.DataBind();
        //}
        //else if (ddlAddClass.SelectedValue == Convert.ToString(189))
        //{
        //    Sql = Sql + "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=2 ";
        //    DataSet ds = cc.ExecuteDataset(Sql);

        //    cmbSelectsubject.DataSource = ds.Tables[0];
        //    cmbSelectsubject.DataTextField = "Name";
        //    cmbSelectsubject.DataValueField = "ItemValueId";
        //    cmbSelectsubject.DataBind();
        //}
    }
    #endregion

    #region To display chapter name
    public void LoadChapter()
    {
        //string SQl = "select Chapter_id from dbo.tblAssignChapter where Subject_id=" + cmbSelectsubject.SelectedValue + "  and TypeofMaterial='" + rdoTypeofMaterial.SelectedItem.Text + "' and TypeOFExam=" + ddlTypeofExam.SelectedValue + " ";
        //string Id = Convert.ToString(cc.ExecuteScalar(SQl));

        string sqlQuery = " SELECT [ChapterID] as ItemValueId,[ChapterName] as Name  FROM [tblChapterANDTopicNames] WHERE [TypeofExamId]='" + ddlTypeofExam.SelectedValue + "' AND [ClassID]='" + ddlAddClass.SelectedValue + "' AND [SubjectID]='" + cmbSelectsubject.SelectedValue + "'";// and [ChapterID] IN(" + Id + ") ";
        DataSet dataset = cc.ExecuteDataset(sqlQuery);

        if (dataset.Tables[0].Rows.Count > 0)
        {
            gvChapter.DataSource = dataset.Tables[0];
            gvChapter.DataBind();
        }
        else
        {
            Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 3 ";
            dataset = cc.ExecuteDataset(Sql);

            gvChapter.DataSource = dataset.Tables[0];
            gvChapter.DataBind();
        }
    }

    #endregion 
    
    protected void cmbSelectsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadChapter();
    }

    protected void gvAssignChapter_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}
