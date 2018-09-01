using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Admin_NewPractice : System.Web.UI.Page
{
    int status, TotalQuetion, AddingQuestion;
    CommonCode cc = new CommonCode();
    public static string Chapter_id = "";
    public static int TypeOFExam = 0;
    public static int Class_id = 0;
    public static int Subject_id = 0;
    public static string Subjectid = "";

    public DataSet dsStatic = null;
    public DataSet dsItemValue = null;

    string Sql = "";
    CommanDDLbindclass Cds = new CommanDDLbindclass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Cds.loadGroupofExam(ddlGroupofExam);
            //  loadrecord();
            //Sql = "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=8 ";
            //DataSet ds = cc.ExecuteDataset(Sql);

            //ddlGroupofExam.DataSource = ds.Tables[0];
            //ddlGroupofExam.DataTextField = "Name";
            //ddlGroupofExam.DataValueField = "ItemValueId";
            //ddlGroupofExam.DataBind();
            //ddlTopik.Items.Add("--Select--");
            //ddlTopik.SelectedIndex = ddlTopik.Items.Count - 1;
        }
    }


    #region LaodRecord Commented
    public void loadrecord()
    {
        Sql = "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=8 "; //GroupofExams

        Sql = Sql + "select Name,ItemValueId from tblItemValue where ItemId=0 or ItemId=1";  //loadClass
        Sql = Sql + "select Name,ItemValueId from tblItemValue where ItemId =0 or ItemId=2";  //loadSubject
        //Sql = Sql + "select Name,ItemValueId from tblItemValue where ItemId=3"; //loadChapter

        Sql = Sql + "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=6  ";  //loadTypeofExam
        DataSet ds = cc.ExecuteDataset(Sql);

        ddlTypeofExam.DataSource = ds.Tables[3];
        ddlTypeofExam.DataTextField = "Name";
        ddlTypeofExam.DataValueField = "ItemValueId";
        ddlTypeofExam.DataBind();

        ddlAddClass.DataSource = ds.Tables[1];
        ddlAddClass.DataTextField = "Name";
        ddlAddClass.DataValueField = "ItemValueId";
        ddlAddClass.DataBind();

        cmbSelectsubject.DataSource = ds.Tables[2];
        cmbSelectsubject.DataTextField = "Name";
        cmbSelectsubject.DataValueField = "ItemValueId";
        cmbSelectsubject.DataBind();

        //ddlChapter.DataSource = ds.Tables[3];
        //ddlChapter.DataTextField = "Name";
        //ddlChapter.DataValueField = "ItemValueId";
        //ddlChapter.DataBind();

        ddlGroupofExam.DataSource = ds.Tables[0];
        ddlGroupofExam.DataTextField = "Name";
        ddlGroupofExam.DataValueField = "ItemValueId";
        ddlGroupofExam.DataBind();

        ChkSelectALL.Checked = false;
        ChkSelectALL.Visible = false;
    }
    #endregion

    int count = 0;
    protected void btnStart_Click1(object sender, EventArgs e)
    {
        try
        {
            if (cmbSelectsubject.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Subject Name')", true);
            }
            else if (rdoLevelList1.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select level ')", true);
            }
            else if (ddlChapter.SelectedValue == "" )
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select atleast one Topic Name ')", true);
            }

            else
            {
                string chapterID = "", chapterName = "";
                Session["QuestionID"] = "";
                for (int c = 0; c < ddlChapter.Items.Count; c++)
                {
                    if (ddlChapter.Items[c].Selected == true)
                    {
                        chapterID = chapterID + ddlChapter.Items[c].Value + ",";
                    }
                }

                if (chapterID != "")
                    chapterID = chapterID.Substring(0, chapterID.Length - 1);


                string material = Convert.ToString(rdoTypeofMaterial.SelectedItem.Text);
                string exam = Convert.ToString(ddlTypeofExam.SelectedValue);
                string cl = Convert.ToString(ddlAddClass.SelectedValue);
                string su = Convert.ToString(cmbSelectsubject.SelectedValue);
                string ch = chapterID;
                string level = Convert.ToString(rdoLevelList1.SelectedValue);
                string Medium = Convert.ToString(ddlMedium.SelectedItem.Text);
                string tpk = Convert.ToString(ddlTopik.SelectedValue);

                if (ch == "")
                {
                    Sql = "select count(*) from dbo.tblQuestionAccess where Subject_id=" + su + " and MediumID='" + (ddlMedium.SelectedItem.Text) + "' and Chapter_id=" + tpk + "  and QuestionLevel='" + level + "' and TypeOFExam='" + exam + "' and Class_id=" + cl + " and TypeofMaterial='" + material + "' ";
                    ch = "1";
                }
                else
                {
                    Sql = "select count(*) from dbo.tblQuestionAccess where Subject_id=" + su + " and MediumID='" + (ddlMedium.SelectedItem.Text) + "' and Chapter_id=" + tpk + " and Topic_id in(" + ch + ") and QuestionLevel='" + level + "' and TypeOFExam='" + exam + "' and Class_id=" + cl + " and TypeofMaterial='" + material + "' ";
                }

                string combo = su + "*" + ch + "*" + level + "*" + material + "*" + exam + "*" + cl + "*" + Medium + "*" + tpk;

                count = Convert.ToInt32(cc.ExecuteScalar(Sql));
                if (count > 0)
                {
                    Response.Redirect("~/Admin/NewPractice1.aspx?combo=" + combo, true);
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('No Question found for this combination ')", true);
                    Sql = "select count(*) from dbo.tblQuestionAccess where Subject_id=" + su + " and MediumID='" + (ddlMedium.SelectedItem.Text) + "' and Chapter_id=" + tpk + "  and QuestionLevel='" + level + "' and TypeOFExam='" + exam + "' and Class_id=" + cl + " and TypeofMaterial='" + material + "' ";
                    count = Convert.ToInt32(cc.ExecuteScalar(Sql));
                    if (count > 0)
                    {
                        ch = "1";
                        combo = su + "*" + ch + "*" + level + "*" + material + "*" + exam + "*" + cl + "*" + Medium + "*" + tpk;
                        Response.Redirect("~/Admin/NewPractice1.aspx?combo=" + combo, true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('No Question found for this combination ')", true);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
    }


    string QuestionID, s1;

    private void loadSubject(string test)
    {
        string Sql = "select Name,ItemValueId from tblItemValue where ItemId=2 ";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            cmbSelectsubject.DataSource = ds.Tables[0];
            cmbSelectsubject.DataTextField = "Name";
            cmbSelectsubject.DataValueField = "ItemValueId";
            cmbSelectsubject.DataBind();
            cmbSelectsubject.Items.Add("--Select--");
            cmbSelectsubject.SelectedIndex = cmbSelectsubject.Items.Count - 1;
            Session["TestID"] = test;
        }
        else
        {
            Session["TestID"] = "dummy";
        }
    }

    #region LoadChapter in CheckBox_selectAll

    private void LoadChapter()
    {
        try
        {
            ChkSelectALL.Checked = false;

            string Sql = " select distinct ISNULL(Chapter_id,'') as Chapter_id , ISNULL(userChapterName,'') as userChapterName  from tblQuestionAccess " +
                         " where TypeOFExam='" + ddlTypeofExam.SelectedValue + "' and Subject_id='" + cmbSelectsubject.SelectedValue + "' and MediumID='" + ddlMedium.SelectedItem.Text + "'  " +
                         " and TypeofMaterial='" + rdoTypeofMaterial.SelectedItem.Text + "' and Class_id='" + ddlAddClass.SelectedValue + "' and Chapter_id NOT IN ('1') and userChapterName NOT IN (' ') ";


            DataSet ds = cc.ExecuteDataset(Sql);
            if (cmbSelectsubject.SelectedItem.Text == "--Select--")
            {
                ddlChapter.Items.Clear();
            }
            else
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlChapter.DataSource = ds.Tables[0];
                    ddlChapter.DataTextField = "userChapterName";
                    ddlChapter.DataValueField = "Chapter_id";
                    ddlChapter.DataBind();

                    ChkSelectALL.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<h4> ERROR : " + ex.Message.ToString());
        }
    }
    #endregion

    protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void rdoTypeofMaterial_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoTypeofMaterial.SelectedItem.Text == "Class")
        {
            Label3.Visible = true;
            RequiredFieldValidator8.Enabled = true;

            Label6.Visible = false;
            RequiredFieldValidator7.Enabled = false;
        }
        else
        {
            Label6.Visible = true;
            RequiredFieldValidator7.Enabled = true;

            Label3.Visible = false;
            RequiredFieldValidator8.Enabled = false;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void rdoLevelList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        ddlGroupofExam.SelectedIndex = 0;
        ddlMedium.SelectedIndex = 0;
        ddlTypeofExam.SelectedIndex = 0;
        ddlAddClass.SelectedIndex = 0;
        cmbSelectsubject.SelectedIndex = 0;
        rdoTypeofMaterial.ClearSelection();
        rdoLevelList1.ClearSelection();
        ChkSelectALL.Checked = false;
        ddlAddClass.Enabled = true;
        foreach (ListItem li in ddlChapter.Items)
        {
            li.Selected = false;
        }
    }

    #region Get Names For Chapters

    //public void GetChapterNames()
    //{
    //    string sqlQuery = " SELECT [ChapterID],[ChapterName] FROM [tblChapterANDTopicNames] WHERE [GroupofExamId]='" + ddlGroupofExam.SelectedValue + "' AND [TypeofExamId]='" + ddlTypeofExam.SelectedValue + "' AND [Medium]='" + ddlMedium.SelectedItem.Text + "' AND [ClassID]='" + ddlAddClass.SelectedValue + "' AND [SubjectID]='" + cmbSelectsubject.SelectedValue + "' ";
    //    DataSet dataset = cc.ExecuteDataset(sqlQuery);

    //    if (dataset.Tables[0].Rows.Count > 0)
    //    {

    //        ddlTopik.DataSource = dataset.Tables[0];  //ddlChapter
    //        ddlTopik.DataTextField = "ChapterName";
    //        ddlTopik.DataValueField = "ChapterID";
    //        ddlTopik.DataBind();
    //        ddlTopik.Items.Add("--Select--");
    //        ddlTopik.SelectedIndex = ddlTopik.Items.Count - 1;
    //    }
    //    else
    //    {
    //        Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 3 ";
    //        dataset = cc.ExecuteDataset(Sql);

    //        ddlTopik.DataSource = dataset.Tables[0];
    //        ddlTopik.DataTextField = "Name";
    //        ddlTopik.DataValueField = "ItemValueId";
    //        ddlTopik.DataBind();
    //        ddlTopik.Items.Add("--Select--");
    //        ddlTopik.SelectedIndex = ddlTopik.Items.Count - 1;
    //    }
    //}

    #endregion

    #region ddlMedium
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataSet ds = new DataSet();

        //Sql = " select distinct ISNULL(userChapterName,'') as userChapterName  from tblQuestionAccess " +
        //      " where TypeOFExam='" + ddlTypeofExam.SelectedValue + "' and Subject_id='" + cmbSelectsubject.SelectedValue + "' and MediumID='" + ddlMedium.SelectedItem.Text + "'  " +
        //      " and TypeofMaterial='" + rdoTypeofMaterial.SelectedItem.Text + "' and Class_id='" + ddlAddClass.SelectedValue + "' and userChapterName NOT IN (' ') ";

        //ds = cc.ExecuteDataset(Sql);

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    LoadChapter();
        //}
        //else
        //{
        //    Sql = " select Name,ItemValueId from tblItemValue where ItemId = 3 ";
        //    ds = cc.ExecuteDataset(Sql);

        //    ddlChapter.DataSource = ds.Tables[0];
        //    ddlChapter.DataTextField = "Name";
        //    ddlChapter.DataValueField = "ItemValueId";
        //    ddlChapter.DataBind();

        //    ChkSelectALL.Visible = true;
        //}

        Cds.GetChapterNames(ddlTopik, ddlGroupofExam, ddlTypeofExam, ddlMedium, ddlAddClass, cmbSelectsubject);
    }
    #endregion

    #region ddlGroupofExam

    //protected void BindDropdown212()
    //{
    //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=212 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlTypeofExam.DataSource = ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //protected void BindDropdown213()
    //{
    //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=213 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlTypeofExam.DataSource = ds.Tables[0];
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
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 445 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //protected void BindDropdown214()
    //{
    //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=214 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlTypeofExam.DataSource = ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    protected void ddlGroupofExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        string groupExamid = ddlGroupofExam.SelectedValue;
        Cds.BindTypeofExamOnGroup(ddlTypeofExam, groupExamid);
        //if (ddlGroupofExam.SelectedValue == Convert.ToString(135))
        //{
        //    BindDropdown212();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(136))
        //{
        //    BindDropdown213();
        //}
        //else if (ddlGroupofExam.SelectedValue == Convert.ToString(137))
        //{
        //    BindDropdown214();
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

    //protected void Binddropdown202()
    //{
    //    ddlAddClass.Enabled = true;
    //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=202 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlAddClass.DataSource = ds.Tables[0];
    //    ddlAddClass.DataTextField = "Name";
    //    ddlAddClass.DataValueField = "ItemValueIdNew";
    //    ddlAddClass.DataBind();
    //}
    //protected void Binddropdown201()
    //{
    //    ddlAddClass.Enabled = true;
    //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=201 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlAddClass.DataSource = ds.Tables[0];
    //    ddlAddClass.DataTextField = "Name";
    //    ddlAddClass.DataValueField = "ItemValueIdNew";
    //    ddlAddClass.DataBind();
    //}
    //protected void Binddropdown211()
    //{
    //    ddlAddClass.Enabled = true;
    //    Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=211 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlAddClass.DataSource = ds.Tables[0];
    //    ddlAddClass.DataTextField = "Name";
    //    ddlAddClass.DataValueField = "ItemValueIdNew";
    //    ddlAddClass.DataBind();
    //}
    //protected void Bindropdown2()
    //{ 
    //        Sql = Sql + "select Name,ItemValueId from tblItemValue where  ItemId=0 or ItemId=2 ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        cmbSelectsubject.DataSource = ds.Tables[0];
    //        cmbSelectsubject.DataTextField = "Name";
    //        cmbSelectsubject.DataValueField = "ItemValueId";
    //        cmbSelectsubject.DataBind();
    //        ddlAddClass.SelectedValue = "1";
    //        ddlAddClass.Enabled = false;
    //}
    protected void ddlTypeofExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        string classORSubject = ddlTypeofExam.SelectedValue;
        Cds.BindClassOrSubject(ddlAddClass, classORSubject, cmbSelectsubject);

        // if (ddlTypeofExam.SelectedValue == Convert.ToString(88))
        // {
        //     Binddropdown201();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(271))
        // {
        //     Binddropdown201();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(272))
        // {
        //     Binddropdown201();
        // }
        //else if (ddlTypeofExam.SelectedValue == Convert.ToString(98))
        // {
        //     Binddropdown202();

        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(99))
        // {
        //     Binddropdown202();

        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(100))
        // {
        //     Binddropdown202();

        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(96))
        // {
        //     Binddropdown211();

        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(101))
        // {
        //     Binddropdown211();

        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(102))
        // {
        //     Binddropdown211();

        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(89))
        // {
        //     Bindropdown2();

        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(94))
        // {
        //    Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(95))
        // {
        //    Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(130))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(110))
        // {
        //     Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=204 ";
        //     DataSet ds = cc.ExecuteDataset(Sql);

        //     cmbSelectsubject.DataSource = ds.Tables[0];
        //     cmbSelectsubject.DataTextField = "Name";
        //     cmbSelectsubject.DataValueField = "ItemValueIdNew";
        //     cmbSelectsubject.DataBind();
        //     ddlAddClass.SelectedValue = "1";
        //     ddlAddClass.Enabled = false;
        // }

        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(103))
        // {
        //     Bindropdown2();
        // }

        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(165))
        // {
        //     Bindropdown2();
        // }

        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(179))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(180))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(176))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(184))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(185))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(191))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(193))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(200) || ddlTypeofExam.SelectedValue == Convert.ToString(201) || ddlTypeofExam.SelectedValue == Convert.ToString(202) || ddlTypeofExam.SelectedValue == Convert.ToString(203) || ddlTypeofExam.SelectedValue == Convert.ToString(204) || ddlTypeofExam.SelectedValue == Convert.ToString(205) || ddlTypeofExam.SelectedValue == Convert.ToString(206) || ddlTypeofExam.SelectedValue == Convert.ToString(207))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(217))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(224))
        // {
        //     ddlAddClass.Enabled = true;
        //     Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=201 ";
        //     DataSet ds = cc.ExecuteDataset(Sql);

        //     ddlAddClass.DataSource = ds.Tables[0];
        //     ddlAddClass.DataTextField = "Name";
        //     ddlAddClass.DataValueField = "ItemValueIdNew";
        //     ddlAddClass.DataBind();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(227))
        // {
        //     Bindropdown2();
        // }

        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(228))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(229))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(230))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(234))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(235))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(236))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(237))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(248))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(254))
        // {
        //     Bindropdown2();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(258) || ddlTypeofExam.SelectedValue == Convert.ToString(259) || ddlTypeofExam.SelectedValue == Convert.ToString(260) || ddlTypeofExam.SelectedValue == Convert.ToString(261) || ddlTypeofExam.SelectedValue == Convert.ToString(262) || ddlTypeofExam.SelectedValue == Convert.ToString(263) || ddlTypeofExam.SelectedValue == Convert.ToString(264) || ddlTypeofExam.SelectedValue == Convert.ToString(265))
        // {
        //     Binddropdown201();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(266) || ddlTypeofExam.SelectedValue == Convert.ToString(267) || ddlTypeofExam.SelectedValue == Convert.ToString(268) || ddlTypeofExam.SelectedValue == Convert.ToString(269) || ddlTypeofExam.SelectedValue == Convert.ToString(270))
        // {
        //     Binddropdown201();
        // }
        // else if (ddlTypeofExam.SelectedValue == Convert.ToString(446) || ddlTypeofExam.SelectedValue == Convert.ToString(447) || ddlTypeofExam.SelectedValue == Convert.ToString(448) || ddlTypeofExam.SelectedValue == Convert.ToString(449))
        // {
        //     Bindropdown2();
        // }
    }
    #endregion

    #region ddlAddClass
    protected void ddlAddClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        string addClassIDNew = ddlAddClass.SelectedValue;
        Cds.BindAddSubjectOnClassId(cmbSelectsubject, addClassIDNew, ddlTypeofExam);
        //for (int count = 0; count < 15;count++ )
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

    #region cmbselectsubject
    protected void cmbSelectsubject_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    #endregion

    # region Get Name For Topic
    //public void GetToipcName(string topicid)
    //{
    //    string sqlQuery = " SELECT [TopicID],[TopicName] FROM [tblChapterANDTopicNames] WHERE [GroupofExamId]='" + ddlGroupofExam.SelectedValue + "' AND [TypeofExamId]='" + ddlTypeofExam.SelectedValue + "' AND [Medium]='" + ddlMedium.SelectedItem.Text + "' AND [ClassID]='" + ddlAddClass.SelectedValue + "' AND [SubjectID]='" + cmbSelectsubject.SelectedValue + "' ";
    //    DataSet dataset = cc.ExecuteDataset(sqlQuery);
    //    if (dataset.Tables[0].Rows.Count > 0)
    //    {
    //        string topicname = Convert.ToString(dataset.Tables[0].Rows[0]["TopicName"]);
    //        if (topicname == "")
    //        {
    //            Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 4 ";
    //            dataset = cc.ExecuteDataset(Sql);

    //            ddlChapter.DataSource = dataset.Tables[0];
    //            ddlChapter.DataTextField = "Name";
    //            ddlChapter.DataValueField = "ItemValueId";
    //            ddlChapter.DataBind();

    //            ChkSelectALL.Visible = true;
    //        }
    //        else
    //        {
    //            ddlChapter.DataSource = dataset.Tables[0];  //ddlChapter
    //            ddlChapter.DataTextField = "TopicName";
    //            ddlChapter.DataValueField = "TopicID";
    //            ddlChapter.DataBind();

    //            ChkSelectALL.Visible = true;
    //        }
    //    }
    //    else
    //    {
    //        Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 4 ";
    //        dataset = cc.ExecuteDataset(Sql);

    //        ddlChapter.DataSource = dataset.Tables[0];
    //        ddlChapter.DataTextField = "Name";
    //        ddlChapter.DataValueField = "ItemValueId";
    //        ddlChapter.DataBind();

    //        ChkSelectALL.Visible = true;
    //    }
    //}
    #endregion

    protected void ddlTopik_SelectedIndexChanged(object sender, EventArgs e)
    {
        string tpkid = Convert.ToString(ddlTopik.SelectedValue);
        Cds.GetToipcName(ddlChapter, tpkid, ChkSelectALL, ddlGroupofExam, ddlTypeofExam, ddlMedium, ddlAddClass, cmbSelectsubject, ddlTopik);
    }
}
