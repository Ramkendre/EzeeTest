using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Configuration;

public partial class SubAdmin_TrainingReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    ArrayList ArryLst1 = new ArrayList();
    ArrayList ArryLst2 = new ArrayList();
    string LSTString = "";
    string Chklist = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            loadDDLField();
        }
    }

    public void loadDDLField()
    {
        string sql = "select [FieldId],[FieldName] from [tblFieldItem]";
        ds = cc.ExecuteDataset(sql);

        ddlField.DataSource = ds.Tables[0];
        ddlField.DataTextField = "FieldName";
        ddlField.DataValueField = "FieldId";
        ddlField.DataBind();
        ddlField.Items.Add("--Select--");
        ddlField.SelectedIndex = ddlField.Items.Count - 1;

    }

    protected void ddlField_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Sql = "Select [FieldItemId],[FieldItemValue],[Type] from [tblFieldItemMaster] where [FieldId]= '" + ddlField.SelectedValue + "'";
        ds = cc.ExecuteDataset(Sql);
        string typeChk = ds.Tables[0].Rows[0]["Type"].ToString();
        if (typeChk == "String")
        {
            lblSlctFielditem.Visible = true;
            ddlFieldItem.Visible = true;
            lblSlctDate.Visible = false;
            txtSrchNumber.Visible = false;

            ddlOperator.Items.Add("=");
            ddlOperator.Items.Add("!=");
            ddlFieldItem.DataSource = ds.Tables[0];
            ddlFieldItem.DataTextField = "FieldItemValue";
            ddlFieldItem.DataValueField = "FieldItemId";
            ddlFieldItem.DataBind();

        }
        else if (typeChk == "Numeric")
        {
            lblSlctDate.Visible = true;
            txtSrchNumber.Visible = true;
            lblSlctFielditem.Visible = false;
            ddlFieldItem.Visible = false;
            ddlOperator.Items.Add(">");
            ddlOperator.Items.Add("<");
            ddlOperator.Items.Add(">=");
            ddlOperator.Items.Add("=<");
        }
        else if (typeChk == "Date")
        {
            lblSlctDate.Visible = true;
            txtSrchNumber.Visible = true;
            lblSlctFielditem.Visible = false;
            ddlFieldItem.Visible = false;
        }
     
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string field = string.Empty; string fielditem = string.Empty;
        string oprt = string.Empty; string valOrdate = string.Empty;
        try
        {
            string Sql = "Select [FieldItemId],[FieldItemValue],[Type] from [tblFieldItemMaster] where [FieldId]='" + ddlField.SelectedValue + "'";
            ds = cc.ExecuteDataset(Sql);
            string typeChk = ds.Tables[0].Rows[0]["Type"].ToString();
            if (typeChk == "String")
            {
                field = ddlField.SelectedItem.Text;
                fielditem = ddlFieldItem.SelectedValue;                            //SelectedItem.Text; 
                oprt = ddlOperator.SelectedItem.Text;
                ChkAddList.Items.Add(field.Trim() + " " + oprt + " " + "'" + fielditem + "'");
            }
            else if (typeChk == "Numeric")
            {
                field = ddlField.SelectedItem.Text;
                valOrdate = txtSrchNumber.Text;
                oprt = ddlOperator.SelectedItem.Text;
                ChkAddList.Items.Add(field.Trim() + " " + oprt + " " + "'" + valOrdate + "'");
            }
            //ChkAddList.Items.Add(field.Trim() + " " + oprt + " " + "'" + fielditem + "'" + " " + valOrdate);
            ddlOperator.Items.Clear();
        }
        catch
        {

        }
    }

    protected void btnRight_Click(object sender, EventArgs e)
    {
        try
        {
            if (lstbox1.SelectedIndex >= 0)
            {
                for (int i = 0; i < lstbox1.Items.Count; i++)
                {
                    if (lstbox1.Items[i].Selected)
                    {
                        if (!ArryLst1.Contains(lstbox1.Items[i]))
                        {
                            ArryLst1.Add(lstbox1.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < ArryLst1.Count; i++)
                {
                    if (!lstbox2.Items.Contains(((ListItem)ArryLst1[i])))
                    {
                        lstbox2.Items.Add(((ListItem)ArryLst1[i]));
                    }
                }
            }
        }
        catch
        {

        }
    }

    protected void btnleft_Click(object sender, EventArgs e)
    {
        try
        {
            if (lstbox2.SelectedIndex >= 0)
            {
                for (int i = 0; i < lstbox2.Items.Count; i++)
                {
                    if (lstbox2.Items[i].Selected)
                    {
                        if (!ArryLst2.Contains(lstbox2.Items[i]))
                        {
                            ArryLst2.Add(lstbox2.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < ArryLst2.Count; i++)
                {
                    if (!lstbox1.Items.Contains(((ListItem)ArryLst2[i])))
                    {
                        lstbox1.Items.Add(((ListItem)ArryLst2[i]));
                    }
                    lstbox2.Items.Remove(((ListItem)ArryLst2[i]));
                }
                lstbox1.SelectedIndex = -1;
            }
        }
        catch
        {

        }
    }

    public void BindGvTrngReport(string LSTString, string chklist)
    {
        string SqlQry = string.Empty; string Countid = string.Empty;
        ViewState["LSTString"] = LSTString;
        DataSet ds = new DataSet();
        if (chklist != "")
        {
            ViewState["chklist"] = chklist;

            string sql = "SELECT " + LSTString + " FROM [tblTrainingDetails] WHERE " + chklist + "";
            ds = cc.ExecuteDataset(sql);

            //SqlQry = "Select Count(*) from   [tblTrainingDetails] where " + chklist + "";
            Countid = Convert.ToString(ds.Tables[0].Rows.Count);                // Convert.ToString(cc.ExecuteScalar(SqlQry));
            lblCount.Text = Countid;
        }
        else if (ddlFieldItem.SelectedValue != "")
        {
            string sql = "SELECT " + LSTString + " FROM [tblTrainingDetails] WHERE " + ddlField.SelectedItem.Text.Trim() + " " + ddlOperator.SelectedItem.Text + " '" + ddlFieldItem.SelectedValue + "'";
            ds = cc.ExecuteDataset(sql);

            //SqlQry = "Select Count(*) from   [tblTrainingDetails] where " + ddlField.SelectedItem.Text.Trim() + " " + ddlOperator.SelectedItem.Text + " '" + ddlFieldItem.SelectedValue + "'";
            Countid = Convert.ToString(ds.Tables[0].Rows.Count);                                  // Convert.ToString(cc.ExecuteScalar(SqlQry));
            lblCount.Text = Countid;
        }
        else if (txtSrchNumber.Text != "")
        {
            string sql = "SELECT " + LSTString + " FROM [tblTrainingDetails] WHERE " + ddlField.SelectedItem.Text.Trim() + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "'";
            ds = cc.ExecuteDataset(sql);

            //SqlQry = "Select Count(*) from   [tblTrainingDetails] where " + ddlField.SelectedItem.Text.Trim() + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "'";
            Countid = Convert.ToString(ds.Tables[0].Rows.Count);          //Convert.ToString(cc.ExecuteScalar(SqlQry));
            lblCount.Text = Countid;
        }
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }

    public void SelectAllTextInListBox()
    {
        foreach (ListItem item in lstbox2.Items)
        {
            item.Selected = true;
        }
    }

    protected void btdisplay_Click(object sender, EventArgs e)
    {
        //string LSTString = "";
        //for (int i = 0; i < lstbox2.Items.Count; i++)
        //{
        //    if (lstbox2.Items[i].Selected == true)
        //    {
        //        LSTString = LSTString + "," + lstbox2.Items[i].Text;
        //    }
        //}
        //if (LSTString.Length > 1)
        //{
        //    LSTString = LSTString.Substring(1);
        //}

        ////string Chklist = "";
        //for (int c = 0; c < ChkAddList.Items.Count; c++)
        //{
        //    if (ChkAddList.Items[c].Selected == true)
        //    {
        //        Chklist = Chklist + " and " + ChkAddList.Items[c].Text;
        //    }
        //}
        //if (Chklist.Length > 1)
        //{
        //    Chklist = Chklist.Substring(4);
        //}
        SelectAllTextInListBox();
        CommanData();
        BindGvTrngReport(LSTString, Chklist);
    }

    public void CommanData()
    {
        for (int i = 0; i < lstbox2.Items.Count; i++)
        {
            if (lstbox2.Items[i].Selected == true)
            {
                LSTString = LSTString + "," + lstbox2.Items[i].Text;

            }
        }
        if (LSTString.Length > 1)
        {
            LSTString = LSTString.Substring(1);
        }

        //string Chklist = "";
        for (int c = 0; c < ChkAddList.Items.Count; c++)
        {
            if (ChkAddList.Items[c].Selected == true)
            {
                Chklist = Chklist + " and " + ChkAddList.Items[c].Text;
            }
        }
        if (Chklist.Length > 1)
        {
            Chklist = Chklist.Substring(4);
        }
        // BindGvTrngReport(LSTString, Chklist);
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            SelectAllTextInListBox();
            CommanData();

            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Excel.xls"));
            Response.ContentType = "application/excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                BindGvTrngReport(LSTString, Chklist);

                GridView1.HeaderRow.BackColor = Color.Yellow;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }
                GridView1.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.End();
            }
        }
        catch
        {

        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            LSTString = ViewState["LSTString"].ToString();

            GridView1.PageIndex = e.NewPageIndex;
            BindGvTrngReport(LSTString, Chklist);
        }
        catch
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGvTrngReport(LSTString, Chklist);
        }
    }
}