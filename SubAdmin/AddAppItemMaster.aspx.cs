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

public partial class SubAdmin_AddAppItemMaster : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDropDownLists();
            gvAddAppItemMaster.Visible = false;
        }
    }

    public void BindDropDownLists()
    {
        string sqlQuery = " SELECT [ItemValueId],[Name] FROM [tblItemValue] WHERE [ItemId]='0' OR [ItemId]='6' ";
        sqlQuery += " SELECT [ItemValueId],[Name] FROM [tblItemValue] WHERE [ItemId]='0' OR [ItemId]='1' ";
        sqlQuery += " SELECT [ItemValueId],[Name] FROM [tblItemValue] WHERE [ItemId]='2' ";

        DataSet ds = cc.ExecuteDataset(sqlQuery);

        ddlTypeofExam.DataSource = ds.Tables[0];
        ddlTypeofExam.DataTextField = "Name";
        ddlTypeofExam.DataValueField = "ItemValueId";
        ddlTypeofExam.DataBind();

        ddlClass.DataSource = ds.Tables[1];
        ddlClass.DataTextField = "Name";
        ddlClass.DataValueField = "ItemValueId";
        ddlClass.DataBind();

        chkSubject.DataSource = ds.Tables[2];
        chkSubject.DataTextField = "Name";
        chkSubject.DataValueField = "ItemValueId";
        chkSubject.DataBind();
    }

    public void BindGridViewAppItemMaster()
    {
        string sqlQuery = " SELECT [TypeofExamName] AS EXAM_NAME,[ClassName] AS CLASS_NAME ,[SubjectName] AS SUBJECT_NAME FROM [tblAppItemMaster] WHERE [TypeofExamID]='" + ddlTypeofExam.SelectedValue + "' ";
        DataSet ds = cc.ExecuteDataset(sqlQuery);

        gvAddAppItemMaster.DataSource = ds.Tables[0];
        gvAddAppItemMaster.DataBind();
        gvAddAppItemMaster.Visible = true;
    }

    protected void ddlTypeofExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTypeofExam.SelectedValue == "1")
        { }
        else
        {
            BindGridViewAppItemMaster();
        }
    }
    protected void gvAddAppItemMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ddlClass.SelectedValue == "1")
        {
            gvAddAppItemMaster.PageIndex = e.NewPageIndex;
            BindGridViewAppItemMaster();
        }
        else
        {
            gvAddAppItemMaster.PageIndex = e.NewPageIndex;
            string sqlQuery = " SELECT [TypeofExamName] AS EXAM_NAME,[ClassName] AS CLASS_NAME ,[SubjectName] AS SUBJECT_NAME FROM [tblAppItemMaster] WHERE [TypeofExamID]='" + ddlTypeofExam.SelectedValue + "' AND [ClassID]='" + ddlClass.SelectedValue + "' ";
            DataSet ds = cc.ExecuteDataset(sqlQuery);

            gvAddAppItemMaster.DataSource = ds.Tables[0];
            gvAddAppItemMaster.DataBind();
            gvAddAppItemMaster.Visible = true;
        }
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            for (int c = 0; c < chkSubject.Items.Count; c++)
            {
                if (chkSubject.Items[c].Selected == true)
                {
                    string sqlQuery1 = " SELECT * FROM [tblAppItemMaster] WHERE [TypeofExamID]='" + ddlTypeofExam.SelectedValue + "' AND [ClassID]='" + ddlClass.SelectedValue + "' AND [SubjectID]='" + chkSubject.Items[c].Value + "' ";
                    DataSet dSet = cc.ExecuteDataset(sqlQuery1);

                    if (dSet.Tables[0].Rows.Count > 0)
                    {
                        string sqlQueryUpdate = " UPDATE [tblAppItemMaster] SET [TypeofExamName]='" + ddlTypeofExam.SelectedItem.Text + "',[ClassName]='" + ddlClass.SelectedItem.Text + "',[SubjectName]='" + chkSubject.Items[c].Text + "' WHERE [TypeofExamID]='" + ddlTypeofExam.SelectedValue + "' AND [ClassID]='" + ddlClass.SelectedValue + "' AND [SubjectID]='" + chkSubject.Items[c].Value + "'";
                        cc.ExecuteNonQuery(sqlQueryUpdate);
                        lblSubjectID.Text = "Record Updated Successfully";
                        lblSubjectID.Visible = true;
                    }
                    else
                    {
                        string sqlQuery = " INSERT INTO [tblAppItemMaster] ([TypeofExamID],[ClassID],[SubjectID],[TypeofExamName],[ClassName],[SubjectName]) " +
                                          " VALUES ('" + ddlTypeofExam.SelectedValue + "','" + ddlClass.SelectedValue + "','" + chkSubject.Items[c].Value + "','" + ddlTypeofExam.SelectedItem.Text + "','" + ddlClass.SelectedItem.Text + "','" + chkSubject.Items[c].Text + "') ";
                        cc.ExecuteNonQuery(sqlQuery);
                        lblSubjectID.Text = "Record Added Successfully";
                        lblSubjectID.Visible = true;
                    }
                }
            }
        }
        catch { }
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sqlQuery = " SELECT [TypeofExamName] AS EXAM_NAME,[ClassName] AS CLASS_NAME ,[SubjectName] AS SUBJECT_NAME FROM [tblAppItemMaster] WHERE [TypeofExamID]='" + ddlTypeofExam.SelectedValue + "' AND [ClassID]='" + ddlClass.SelectedValue + "' ";
        DataSet ds = cc.ExecuteDataset(sqlQuery);

        gvAddAppItemMaster.DataSource = ds.Tables[0];
        gvAddAppItemMaster.DataBind();
        gvAddAppItemMaster.Visible = true;
    }
}