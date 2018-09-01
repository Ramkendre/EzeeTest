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

public partial class Admin_AddExamChapter : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    TestDefinationBLL testDefBAL = new TestDefinationBLL();
    AddExamChapterBAL addexamchapterbal = new AddExamChapterBAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            displya(); // load all chapter assign to subject and test name
        }
    }

    protected void rdoGroupOFQues_SelectedIndexChanged(object sender, EventArgs e)
    {
        string groupofQues = Convert.ToString(rdoGroupOFQues.SelectedValue);
        loadTestName(groupofQues); // load All test Name under login id 
    }

    public void loadTestName(string groupofQues)
    {
        testDefBAL.LoginId1 = Convert.ToString(Session["LoginId"]);  //use sp
        testDefBAL.GroupOfQuestion1 = groupofQues;

        DataSet ds = testDefBAL.TestbyGroupofQuesLoginId5(testDefBAL);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddltextName.DataSource = ds.Tables[0];
            ddltextName.DataTextField = "Exam_name";
            ddltextName.DataValueField = "Test_ID";
            ddltextName.DataBind();
            ddltextName.Items.Add("--Select--");
            ddltextName.SelectedIndex = ddltextName.Items.Count - 1;
            cmbSelectsubject.Items.Add("--Select--");
            cmbSelectsubject.SelectedIndex = cmbSelectsubject.Items.Count - 1;
        }
        else
        {
            ddltextName.Items.Clear();
        }
    }

    public void loadTestName1(string groupofQues) // here  cmbSelectsubject is not bind 
    {

        testDefBAL.LoginId1 = Convert.ToString(Session["LoginId"]);  //use sp
        testDefBAL.GroupOfQuestion1 = groupofQues;

        DataSet ds = testDefBAL.TestbyGroupofQuesLoginId5(testDefBAL);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddltextName.DataSource = ds.Tables[0];
            ddltextName.DataTextField = "Exam_name";
            ddltextName.DataValueField = "Test_ID";
            ddltextName.DataBind();
        }
        else
        {
            ddltextName.Items.Clear();
        }
    }

    protected void ddltextName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddltextName.SelectedIndex == ddltextName.Items.Count - 1)
            {
            }
            else
            {
                loadSubject(ddltextName.SelectedValue); // load all subject under test name selected
            }
        }
        catch
        {

        }
    }

    private void loadSubject(string test)
    {
        DataSet ds = testDefBAL.loadsubject(test);

        if (ds.Tables[0].Rows.Count > 0)
        {
            cmbSelectsubject.DataSource = ds.Tables[0];
            cmbSelectsubject.DataTextField = "Name";
            cmbSelectsubject.DataValueField = "ItemValueId";
            cmbSelectsubject.DataBind();
            cmbSelectsubject.Items.Add("--Select--");
            cmbSelectsubject.SelectedIndex = cmbSelectsubject.Items.Count - 1;
        }
    }
    protected void cmbSelectsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadChapter();
        displya();
    }

    private void LoadChapter()
    {
        try
        {
            ChkSelectALL.Checked = false;

            string sql = "SELECT [TypeOFExam],[Class_id] FROM [tblTestDefinition] WHERE [Test_ID]='" + ddltextName.SelectedValue + "'";
            DataSet ds = cc.ExecuteDataset(sql);

            string TOE_id = Convert.ToString(ds.Tables[0].Rows[0]["TypeOFExam"]);
            string Cl_id = Convert.ToString(ds.Tables[0].Rows[0]["Class_id"]);

            string sqlQuery = " SELECT [ChapterID],[ChapterName] FROM [tblChapterANDTopicNames] WHERE [TypeofExamId]='" + TOE_id + "' AND [ClassID]='" + Cl_id + "' AND [SubjectID]='" + cmbSelectsubject.SelectedValue + "'"; //and [ChapterID] IN(" + Id + ") ";
            DataSet dataset = cc.ExecuteDataset(sqlQuery);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                string chaptername = Convert.ToString(dataset.Tables[0].Rows[0]["ChapterName"]);
                if (chaptername == "")
                {
                    sqlQuery = "select Name,ItemValueId from dbo.tblItemValue where ItemId=3";
                    dataset = cc.ExecuteDataset(sqlQuery);

                    chkChapter.DataSource = dataset.Tables[0];
                    chkChapter.DataTextField = "Name";
                    chkChapter.DataValueField = "ItemValueId";
                    chkChapter.DataBind();

                    ChkSelectALL.Visible = true;
                }
                else
                {
                    chkChapter.DataSource = dataset.Tables[0];
                    chkChapter.DataTextField = "ChapterName";
                    chkChapter.DataValueField = "ChapterID";
                    chkChapter.DataBind();

                    ChkSelectALL.Visible = true;
                }
            }
            else
            {
                sqlQuery = "select Name,ItemValueId from dbo.tblItemValue where ItemId=3";
                dataset = cc.ExecuteDataset(sqlQuery);

                chkChapter.DataSource = dataset.Tables[0];
                chkChapter.DataTextField = "Name";
                chkChapter.DataValueField = "ItemValueId";
                chkChapter.DataBind();

                ChkSelectALL.Visible = true;
            }

        }
        catch
        {

        }
    }
    protected void btnStart_Click(object sender, EventArgs e)
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
        clear();
    }

    private void AddNew()
    {
        try
        {

            string Sql = "SELECT AecID FROM [tblAssignExamChapter]  WHERE TestID = " + ddltextName.SelectedValue + " AND Subject_id=" + cmbSelectsubject.SelectedValue + " AND LoginId='" + Convert.ToString(Session["LoginId"]) + "'";
            string Id = Convert.ToString(cc.ExecuteScalar(Sql));
            if (!(Id == null || Id == ""))
            {
                lblError.Visible = true;
                lblError.Text = cmbSelectsubject.SelectedItem.Text + " Subject Details is already exist,You can Update Test " + ddltextName.SelectedItem.Text + "";
            }
            else
            {
                string chapterID = "", chapterName = ""; ;
                for (int c = 0; c < chkChapter.Items.Count; c++)
                {
                    if (chkChapter.Items[c].Selected == true)
                    {
                        chapterID = chapterID + "," + chkChapter.Items[c].Value;
                        chapterName = chapterName + "," + chkChapter.Items[c].Text;
                    }
                }
                if (chapterID.Length > 1)
                {
                    chapterID = chapterID.Substring(1);
                }
                if (chapterName.Length > 1)
                {
                    chapterName = chapterName.Substring(1);
                }

                addexamchapterbal.TestID1 = Convert.ToInt32(ddltextName.SelectedValue);
                addexamchapterbal.ChapterName1 = chapterName;
                addexamchapterbal.Chapter_id1 = chapterID;
                addexamchapterbal.Subject_id1 = Convert.ToInt32(cmbSelectsubject.SelectedValue);
                addexamchapterbal.EntryDate1 = Convert.ToString(System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                addexamchapterbal.LoginId1 = Convert.ToString(Session["Loginid"]);

                int status = addexamchapterbal.InsertUpdateExamChapter(addexamchapterbal);
                if (status == 1)
                {
                    displya();
                    lblError.Text = "RECORD SUBMITTED SUCCESSFULLY.!!!";
                    lblError.Visible = true;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('RECORD SUBMITTED SUCCESSFULLY.!!!')", true);
                }
            }
        }
        catch
        {

        }
    }

    private void Update(string id)
    {
        try
        {
            string Sql = "select AecID from [tblAssignExamChapter]  where TestID = " + ddltextName.SelectedValue + " and Subject_id=" + cmbSelectsubject.SelectedValue + " and LoginId='" + Convert.ToString(Session["LoginId"]) + "' and AecID <> " + id + "";
            string Id = Convert.ToString(cc.ExecuteScalar(Sql));
            if (!(Id == null || Id == ""))
            {
                lblError.Visible = true;
                lblError.Text = cmbSelectsubject.SelectedItem.Text + " Subject Details is already exist for exam" + ddltextName.SelectedItem.Text + "";
            }
            else
            {
                string chapterID = "", chapterName = ""; ;
                for (int c = 0; c < chkChapter.Items.Count; c++)
                {
                    if (chkChapter.Items[c].Selected == true)
                    {
                        chapterID = chapterID + "," + chkChapter.Items[c].Value;
                        chapterName = chapterName + "," + chkChapter.Items[c].Text;

                    }
                }
                if (chapterID.Length > 1)
                {
                    chapterID = chapterID.Substring(1);
                }
                if (chapterName.Length > 1)
                {
                    chapterName = chapterName.Substring(1);
                }

                addexamchapterbal.TestID1 = Convert.ToInt32(ddltextName.SelectedValue);
                addexamchapterbal.ChapterName1 = chapterName;
                addexamchapterbal.Chapter_id1 = chapterID;
                addexamchapterbal.Subject_id1 = Convert.ToInt32(cmbSelectsubject.SelectedValue);
                addexamchapterbal.EntryDate1 = Convert.ToString(System.DateTime.Now);
                addexamchapterbal.LoginId1 = Convert.ToString(Session["Loginid"]);
                addexamchapterbal.AecID1 = Convert.ToInt32(id); // id 

                int status = addexamchapterbal.InsertUpdateExamChapter(addexamchapterbal);
                if (status == 1)
                {
                    displya();
                    Id = "";
                    id = "";
                    lblError.Text = "RECORD UPDATED SUCCESSFULLY.!!!";
                    lblError.Visible = true;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('RECORD UPDATED SUCCESSFULLY.!!!')", true);

                }
            }
        }
        catch
        {

        }
    }
    
    private void clear()
    {
        ddltextName.SelectedIndex = ddltextName.Items.Count - 1;
        cmbSelectsubject.SelectedIndex = cmbSelectsubject.Items.Count - 1;
        chkChapter.Items.Clear();
        rdoGroupOFQues.ClearSelection();
        ChkSelectALL.Checked = false;
        btnStart.Text = "Submit";
        lblId.Text = "";
    }

    private void displya() // load all chapter assign to subject and test name
    {
        try
        {
            string SQl = "  select AecID,Exam_name,Name,dbo.[tblAssignExamChapter].ChapterName from dbo.[tblAssignExamChapter]  " +
                      " inner join tblItemValue on tblItemValue.ItemValueId = [tblAssignExamChapter].Subject_id  " +
                       " inner join tblTestDefinition on tblTestDefinition.Test_ID = [tblAssignExamChapter].TestID where tblAssignExamChapter.LoginId ='" + Convert.ToString(Session["LoginId"]) + "' ";

            if (ddltextName.SelectedIndex != ddltextName.Items.Count - 1)
            {
                SQl = SQl + " and TestID=" + ddltextName.SelectedValue + "";
            }
            if (cmbSelectsubject.SelectedIndex != cmbSelectsubject.Items.Count - 1)
            {
                SQl = SQl + " and tblAssignExamChapter.Subject_id=" + cmbSelectsubject.SelectedValue + "";
            }

            DataSet ds = cc.ExecuteDataset(SQl);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                gvchapter.DataSource = ds.Tables[0];
                gvchapter.DataBind();
            }
            else
            {
                gvchapter.DataSource = null;
                gvchapter.DataBind();
            }
        }
        catch
        {

        }
    }
    protected void gvchapter_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvchapter_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;
        if (Convert.ToString(e.CommandName) == "Modify")
        {
            chkChapter.ClearSelection();
            btnStart.Text = "Update";

            addexamchapterbal.AecID1 = Convert.ToInt32(Id);
            DataSet ds = addexamchapterbal.GetRecordModify(addexamchapterbal);

            try
            {
                string groupofQues = Convert.ToString(ds.Tables[0].Rows[0]["GroupOfQuestion"]);
                rdoGroupOFQues.SelectedValue = groupofQues;
                loadTestName1(groupofQues);

                ddltextName.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TestID"]);
                loadSubject(ddltextName.SelectedValue);
                cmbSelectsubject.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Subject_id"]);
                LoadChapter();
                string Chapter_id = Convert.ToString(ds.Tables[0].Rows[0]["Chapter_id"]);
                string[] chapter = Chapter_id.Split(',');

                for (int c = 0; c < chkChapter.Items.Count; c++)
                {
                    if (Chapter_id.Contains(chkChapter.Items[c].Value.ToString()))
                    {
                        chkChapter.Items[c].Selected = true;
                    }
                }

            }
            catch
            {
            }
        }
        else if (Convert.ToString(e.CommandName) == "Delete")
        {

        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in chkChapter.Items)
        {
            li.Selected = false;

        }
        clear();
    }
    protected void chkChapter_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}