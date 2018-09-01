using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
public partial class Admin_State : System.Web.UI.Page
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
            gvState.DataSource = ds.Tables[0];
            gvState.DataBind();
            ListControlCollections();
            pnl_grade.Visible = false;
        }
        Set_Page_Level_Setting();
    }

    protected void Set_Page_Level_Setting()
    {
        //set page heading
        Label lblMainHeading = (Label)Master.FindControl("lblMainHeading");
        if (lblMainHeading != null)
            lblMainHeading.Text = "State Master";
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

                for (int i = 0; i < chkstatelist.Items.Count; i++)
                {
                    if (chkstatelist.Items[i].Selected == true)
                    {
                        string Sql = "Select StateId from StateMaster where StateName='" + chkstatelist.Items[i].Text + "'";
                        string Id = Convert.ToString(cc.ExecuteScalar(Sql));
                        if (!(Id == null || Id == ""))
                        {
                            lblError.Visible = true;
                            lblError.Text = "This Name is already exist";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                        }
                        else
                        {
                            Sql = "Insert into StateMaster(StateName, CountryId) Values (N'" + chkstatelist.Items[i].Text + "'," + ddlCountry.SelectedValue.ToString() + ") ";
                            flag = cc.ExecuteNonQuery(Sql);


                        }
                    }
                }
                if (flag == 1)
                {
                    panel();
                    lblError.Visible = true;
                    lblError.Text = "State Added Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('State added successfully')", true);
                    DataSet ds = location.GetAllState();
                    gvState.DataSource = ds.Tables[0];
                    gvState.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select at least one State')", true);


                }


            }
            else
            {

                if (txtStateName.Text == "")
                {
                    lblError.Visible = true;
                    lblError.Text = "Please Enter the State Name";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the State Name')", true);
                }
                else
                {
                    string Sql = "Select StateId from StateMaster where StateName='" + txtStateName.Text.ToString() + "'";
                    string Id = Convert.ToString(cc.ExecuteScalar(Sql));
                    if (!(Id == null || Id == ""))
                    {
                        lblError.Visible = true;
                        lblError.Text = "This Name is already exist";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                    }
                    else
                    {
                        Sql = "Insert into StateMaster(StateName, CountryId) Values (N'" + txtStateName.Text.ToString() + "'," + ddlCountry.SelectedValue.ToString() + ") ";
                        int flag = cc.ExecuteNonQuery(Sql);
                        txtStateName.Text = "";
                        lblError.Visible = true;
                        lblError.Text = "State Added Successfully";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('State added successfully')", true);
                        //Response.Redirect("State.aspx");
                        DataSet ds = location.GetAllState();
                        gvState.DataSource = ds.Tables[0];
                        gvState.DataBind();
                        //RepDetails.DataSource = ds.Tables[0];
                        //RepDetails.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('State not added')", true);
        }
    }
    private void Update(string Id)
    {
        CommonCode cc = new CommonCode();
        try
        {
            if (txtStateName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the State Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the State Name')", true);
            }
            else
            {
                string Sql = "Select StateId from StateMaster where StateName='" + txtStateName.Text.ToString() + "' and StateId<>" + Id + "";
                string Id1 = Convert.ToString(cc.ExecuteScalar(Sql));
                if (!(Id1 == null || Id1 == ""))
                {
                    lblError.Visible = true;
                    lblError.Text = "This Name is already exist";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                }
                else
                {
                    Sql = "Update StateMaster set StateName=N'" + txtStateName.Text.ToString() + "' where StateId=" + Id + "  ";
                    int flag = cc.ExecuteNonQuery(Sql);
                    txtStateName.Text = "";
                    lblError.Visible = true;
                    lblError.Text = "State updated Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('State updated successfully')", true);
                    //Response.Redirect("State.aspx");
                    DataSet ds = location.GetAllState();
                    gvState.DataSource = ds.Tables[0];
                    gvState.DataBind();
                    lblId.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('State not Updated')", true);
        }
    }
    protected void gvState_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvState.PageIndex = e.NewPageIndex;
        DataSet ds = location.GetAllState();
        gvState.DataSource = ds.Tables[0];
        gvState.DataBind();
    }
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;
        if (Convert.ToString(e.CommandName) == "Modify")
        {

            string Sql = "Select StateId, StateName, CountryId from StateMaster where StateId=" + Id + "";
            try
            {
                DataSet ds = cc.ExecuteDataset(Sql);
                txtStateName.Text = Convert.ToString(ds.Tables[0].Rows[0]["StateName"]);
            }
            catch (Exception ex)
            { }
        }
        else if (Convert.ToString(e.CommandName) == "Delete")
        {
            string Sql3 = "Select DistrictId from DistrictMaster where  StateId='" + Id + "'";
            string Id3 = Convert.ToString(cc.ExecuteScalar(Sql3));
            if (!(Id3 == null || Id3 == ""))
            {
                lblError.Visible = true;
                lblError.Text = "This record reference use Other Location";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This record reference use Other Location')", true);
            }

            else
            {
                try
                {
                    string Sql = "Delete from StateMaster where StateId=" + Id + " ";
                    cc.ExecuteNonQuery(Sql);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('State deleted successfully')", true);

                    DataSet ds = location.GetAllState();
                    gvState.DataSource = ds.Tables[0];
                    gvState.DataBind();
                }
                catch (Exception ex)
                {
                }
            }
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtStateName.Text = "";
        lblId.Text = "";
    }
    protected void gvState_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
        //        cc.AddControls(Page.Controls, controlList, language);

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

    protected void gvState_RowDataBound(object sender, GridViewRowEventArgs e)
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
        if (chkdata.Checked == true)
        {
            pnl_grade.Visible = true;
            DataSet ds = location.GetAllState_default();
            chkstatelist.DataSource = ds.Tables[0];
            chkstatelist.DataTextField = "Name";
            chkstatelist.DataValueField = "Id";
            chkstatelist.DataBind();
        }
        else
        {
            pnl_grade.Visible = false;

        }
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
