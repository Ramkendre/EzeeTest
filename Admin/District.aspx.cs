using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;


public partial class Admin_District : System.Web.UI.Page
{
    Location location = new Location();
    CommonCode cc = new CommonCode();
    string language;
    int flag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = location.GetAllState();
            ddlState.DataSource = ds.Tables[0];
            ddlState.DataTextField = "Name";
            ddlState.DataValueField = "Id";

            ddlState.DataBind();
            ddlState.Items.Add("--Select--");
            ddlState.SelectedIndex = ddlState.Items.Count - 1;
            ListControlCollections();
            pnl_grade.Visible = false;
        }

       // selfont();
        Set_Page_Level_Setting();
    }


    public void selfont()
    {
        //if (rdmarathi.Checked == true)
        //{
        //    txtDistrictName.CssClass = "marathiFont";
        //    gvDistrict.CssClass = "marathiFont";
        //    ddlCountry.CssClass = "marathiFont";
        //    ddlState.CssClass = "marathiFont";
        //}
        //else if (rdenglish.Checked == true)
        //{
        //    txtDistrictName.CssClass = "EnglishFont";
        //    gvDistrict.CssClass = "EnglishFont";
        //    ddlCountry.CssClass = "EnglishFont";
        //    ddlState.CssClass = "EnglishFont";
        //}

    }
    protected void Set_Page_Level_Setting()
    {
        //set page heading
        Label lblMainHeading = (Label)Master.FindControl("lblMainHeading");
        if (lblMainHeading != null)
            lblMainHeading.Text = "State Master /District Master";




    }
    protected void Set_Lng_Setting()
    {
        //set page heading
        RadioButton lblMainHeading = (RadioButton)
            Master.FindControl("lblMainHeading");
        if (lblMainHeading != null)
            lblMainHeading.Text = "Addmission Details";
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
    public void panel()
    {
        chkstatelist.Items.Clear();
        pnl_grade.Visible = false;
        chkdata.Checked = false;
    }
    private void AddNew()
    {

        CommonCode cc = new CommonCode();
        try
        {
            if (chkdata.Checked == true)
            {
                //int flag;
                for (int i = 0; i < chkstatelist.Items.Count; i++)
                {
                    if (chkstatelist.Items[i].Selected == true)
                    {
                        string Sql = "Select DistrictId from DistrictMaster where DistrictName='" + chkstatelist.Items[i].Text + "' And StateId =" + ddlState.SelectedValue + "";
                        string Id = Convert.ToString(cc.ExecuteScalar(Sql));
                        if (!(Id == null || Id == ""))
                        {
                            lblError.Visible = true;
                            lblError.Text = "This Name is already exist";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                        }
                        else
                        {
                            Sql = "Insert into DistrictMaster(DistrictName, StateId) Values (N'" + chkstatelist.Items[i].Text + "'," + ddlState.SelectedValue.ToString() + ") ";
                            flag = cc.ExecuteNonQuery(Sql);

                        }
                    }
                }

                if (flag == 1)
                {
                    panel();
                    lblId.Text = "";
                    lblError.Visible = true;
                    lblError.Text = "District Added Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('District added successfully')", true);
                    //Response.Redirect("State.aspx");
                    DataSet ds = location.GetAllDistrict(ddlState.SelectedValue.ToString());
                    gvDistrict.DataSource = ds.Tables[0];
                    gvDistrict.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select at least one District')", true);


                }
            }
            else
            {
                if (txtDistrictName.Text == "")
                {
                    lblError.Visible = true;
                    lblError.Text = "Please Enter the District Name";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the District Name')", true);
                }
                else if (ddlState.SelectedIndex == ddlState.Items.Count - 1)
                {
                    lblError.Visible = true;
                    lblError.Text = "Please Select the State";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select the State')", true);

                }
                else
                {
                    string Sql = "Select DistrictId from DistrictMaster where DistrictName='" + txtDistrictName.Text.ToString() + "' And StateId =" + ddlState.SelectedValue + "";
                    string Id = Convert.ToString(cc.ExecuteScalar(Sql));
                    if (!(Id == null || Id == ""))
                    {
                        lblError.Visible = true;
                        lblError.Text = "This Name is already exist";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                    }
                    else
                    {
                        Sql = "Insert into DistrictMaster(DistrictName, StateId) Values (N'" + txtDistrictName.Text + "'," + ddlState.SelectedValue.ToString() + ") ";
                        int flag1 = cc.ExecuteNonQuery(Sql);
                        txtDistrictName.Text = "";
                        lblId.Text = "";
                        lblError.Visible = true;
                        lblError.Text = "District Added Successfully";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('District added successfully')", true);
                        //Response.Redirect("State.aspx");
                        DataSet ds = location.GetAllDistrict(ddlState.SelectedValue.ToString());
                        gvDistrict.DataSource = ds.Tables[0];
                        gvDistrict.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('District not added')", true);
        }
    }
    private void Update(string Id)
    {
        CommonCode cc = new CommonCode();
        try
        {
            if (txtDistrictName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the District  Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the District Name')", true);
            }
            else if (ddlState.SelectedIndex == ddlState.Items.Count - 1)
            {
                lblError.Visible = true;
                lblError.Text = "Please Select the State";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select State')", true);
            }
            else
            {
                string Sql = "Select DistrictId from DistrictMaster where DistrictName='" + txtDistrictName.Text.ToString() + "' and DistrictId<>" + Id + "";
                string Id1 = Convert.ToString(cc.ExecuteScalar(Sql));
                if (!(Id1 == null || Id1 == ""))
                {
                    lblError.Visible = true;
                    lblError.Text = "This Name is already exist";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                }
                else
                {
                    Sql = "Update DistrictMaster set DistrictName=N'" + txtDistrictName.Text.ToString() + "', " +
                        " StateId=" + ddlState.SelectedValue.ToString() + " where DistrictId=" + Id + "  ";
                    int flag = cc.ExecuteNonQuery(Sql);
                    txtDistrictName.Text = "";
                    lblId.Text = "";
                    lblError.Visible = true;
                    lblError.Text = "District updated Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('District updated successfully')", true);
                    //Response.Redirect("State.aspx");
                    DataSet ds = location.GetAllDistrict(ddlState.SelectedValue);
                    gvDistrict.DataSource = ds.Tables[0];
                    gvDistrict.DataBind();
                    lblId.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('District not Updated')", true);
        }
    }
    protected void gvDistrict_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDistrict.PageIndex = e.NewPageIndex;
        DataSet ds = location.GetAllDistrict(ddlState.SelectedValue);
        gvDistrict.DataSource = ds.Tables[0];
        gvDistrict.DataBind();
    }
    protected void gvDistrict_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;
        if (Convert.ToString(e.CommandName) == "Modify")
        {

            string Sql = "Select DistrictId, DistrictName, StateId from DistrictMaster where DistrictId=" + Id + "";
            try
            {
                DataSet ds = cc.ExecuteDataset(Sql);
                txtDistrictName.Text = Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
            }
            catch (Exception ex)
            { }
        }
        else if (Convert.ToString(e.CommandName) == "Delete")
        {
            string Sql3 = "Select CityId from CityMaster where  DistrictId='" + Id + "'";
            string Id3 = Convert.ToString(cc.ExecuteScalar(Sql3));
            if (!(Id3 == null || Id3 == ""))
            {
                lblError.Visible = true;
                lblError.Text = "This record reference use Other Location";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This record reference use Other Location')", true);
            }

            else
            {
                string Sql = "Delete from DistrictMaster where DistrictId=" + Id + " ";
                try
                {
                    cc.ExecuteNonQuery(Sql);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('District deleted successfully')", true);
                    DataSet ds = location.GetAllDistrict(ddlState.SelectedValue);
                    gvDistrict.DataSource = ds.Tables[0];
                    gvDistrict.DataBind();
                    lblId.Text = "";

                }
                catch (Exception ex)
                { }
            }
        }
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = location.GetAllDistrict(ddlState.SelectedValue.ToString());
            gvDistrict.DataSource = ds.Tables[0];
            gvDistrict.DataBind();
            panel();
            txtDistrictName.Text = "";
            chkdata0.Checked = false;
        }
        catch { }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlState.SelectedIndex = ddlState.Items.Count - 1;
        txtDistrictName.Text = "";
        lblId.Text = "";

    }
    protected void gvDistrict_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
    private void ListControlCollections()
    {
        ArrayList controlList = new ArrayList();

        // AddControls(Page.Controls, controlList);
        if (Convert.ToString(Session["Marathi"]) == null || Convert.ToString(Session["Marathi"]) == "Marathi")
        {
            language = "Marathi";
        }
        else if (Convert.ToString(Session["English"]) == null || Convert.ToString(Session["English"]) == "English")
        {
            language = "English";

        }
        // cc.AddControls(Page.Controls, controlList, language);

    }

    //private void AddControls(ControlCollection page, ArrayList controlList)
    //{

    //    if (Convert.ToString(Session["Marathi"]) == null || Convert.ToString(Session["Marathi"]) == "Marathi")
    //    {
    //        foreach (Control c in page)
    //        {
    //            Type tp = c.GetType();
    //            if (c.ID != null)
    //            {

    //                if (tp.Name.ToUpper().ToString() == "TEXTBOX")
    //                {
    //                    TextBox TXT = (TextBox)c;
    //                    if (TXT.Text != null)
    //                    {
    //                        TXT.CssClass = "marathiFont";
    //                    }

    //                }
    //                //else if ((tp.Name.ToUpper().ToString() == "LABEL"))
    //                //{
    //                //    Label lbl = (Label)c;
    //                //    if (lbl.Text != null)
    //                //    {
    //                //        lbl.CssClass = "marathiFont";
    //                //    }
    //                 //}

    //                else if ((tp.Name.ToUpper().ToString() == "RADIOBUTTON"))
    //                {
    //                    RadioButton rdb = (RadioButton)c;
    //                    if (rdb.Text != null)
    //                    {
    //                        rdb.CssClass = "marathiFont";
    //                    }

    //                }
    //                else if ((tp.Name.ToUpper().ToString() == "DROPDOWNLIST"))
    //                {
    //                    DropDownList ddl = (DropDownList)c;
    //                    if (ddl.Text != null)
    //                    {
    //                        ddl.CssClass = "marathiFont";
    //                    }


    //                }
    //                else if ((tp.Name.ToUpper().ToString() == "BUTTON"))
    //                {
    //                    Button btn = (Button)c;
    //                    if (btn.Text != null)
    //                    {
    //                        btn.CssClass = "marathiFont";

    //                    }

    //                }
    //            }

    //            if (c.HasControls())
    //            {
    //                AddControls(c.Controls, controlList);
    //            }
    //        }
    //    }
    //    //else if (rdenglish.Checked == true)
    //    else if (Convert.ToString(Session["English"]) == null || Convert.ToString(Session["English"]) == "English")
    //    {

    //        foreach (Control c in page)
    //        {
    //            Type tp = c.GetType();
    //            if (c.ID != null)
    //            {
    //                if (tp.Name.ToUpper().ToString() == "TEXTBOX")
    //                {
    //                    TextBox TXT = (TextBox)c;
    //                    if (TXT.Text != null)
    //                    {
    //                        TXT.CssClass = "EnglishFont";

    //                    }
    //                }
    //                else if ((tp.Name.ToUpper().ToString() == "LABEL"))
    //                {
    //                    Label lbl = (Label)c;
    //                    if (lbl.Text != null)
    //                    {
    //                        lbl.CssClass = "EnglishFont";

    //                    }


    //                }
    //                else if ((tp.Name.ToUpper().ToString() == "RADIOBUTTON"))
    //                {
    //                    RadioButton rdb = (RadioButton)c;
    //                    if (rdb.Text != null)
    //                    {

    //                        rdb.CssClass = "EnglishFont";

    //                    }

    //                }
    //                else if ((tp.Name.ToUpper().ToString() == "DROPDOWNLIST"))
    //                {
    //                    DropDownList ddl = (DropDownList)c;
    //                    if (ddl.Text != null)
    //                    {
    //                        ddl.CssClass = "EnglishFont";

    //                    }

    //                }
    //                else if ((tp.Name.ToUpper().ToString() == "BUTTON"))
    //                {
    //                    Button btn = (Button)c;
    //                    if (btn.Text != null)
    //                    {
    //                        btn.CssClass = "EnglishFont";

    //                    }

    //                }
    //            }

    //            if (c.HasControls())
    //            {
    //                AddControls(c.Controls, controlList);
    //            }
    //        }
    //    }
    //}

    protected void gvDistrict_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //getting username from particular row
            string username = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Name"));
            //identifying the control in gridview
            //raising javascript confirmationbox whenver user clicks on link button 
            ImageButton btnimg = (ImageButton)e.Row.FindControl("ImageButton2");
            btnimg.Attributes.Add("onclick", "javascript:return ConfirmationBox('" + username + "')");

        }
    }
    protected void chkdata_CheckedChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex == ddlState.Items.Count - 1)
        {
            lblError.Visible = true;
            lblError.Text = "Please Select the State";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select State')", true);
        }
        else
        {
            if (chkdata.Checked == true)
            {
                pnl_grade.Visible = true;
                DataSet ds = location.GetAllDistrict_default(ddlState.SelectedItem.Text);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    chkstatelist.DataSource = ds.Tables[0];
                    chkstatelist.DataTextField = "Name";
                    chkstatelist.DataValueField = "Id";
                    chkstatelist.DataBind();
                }
                if (chkstatelist.SelectedIndex == chkstatelist.Items.Count - 1)
                {
                    pnl_grade.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('District Details Not Available')", true);
                }
                else
                {
                    pnl_grade.Visible = true;
                }
            }
            else
            {
                pnl_grade.Visible = false;

            }
        }
    }
    protected void txtDistrictName_TextChanged(object sender, EventArgs e)
    {
        chkdata.Checked = false;
    }
    protected void chkdata0_CheckedChanged(object sender, EventArgs e)
    {
        if (chkdata0.Checked == true)
        {
            for (int i = 0; i < chkstatelist.Items.Count; i++)
            {
                chkstatelist.Items[i].Selected = true;
            }
        }
        else
        {
            for (int i = 0; i < chkstatelist.Items.Count; i++)
            {
                chkstatelist.Items[i].Selected = false;
            }
        }
    }
}
