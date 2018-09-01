using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SubAdmin_GiveNamestoChapters : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string Sql;
    public int cRowID = 0;
    InsertChaptersTopics objInsertChapterTopics = new InsertChaptersTopics();
    DataSet dataset = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindItemMaster();
            BindInsertChapterGridview();
            BindStateDropDownList();
        }
    }

    #region ON SELECTED INDEX CHANGED FOR GROUP OF EXAM TO BIND TYPE OF EXAM

    public void BindTypeofExamByGroupExId(int ExamGroupId)
    {
        if (ExamGroupId == 135)
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=212  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(136))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 213 ";
            DataSet DS = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = DS.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(137))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 214 ";
            DataSet Ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = Ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ExamGroupId == 140)
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew=0 OR ItemIdNew=210";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ExamGroupId == 141)
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=207 "; //16998
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ExamGroupId == 142)
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=206  "; //17099
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ExamGroupId == 143)
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=203";// 167103  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ExamGroupId == 144)
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=205";// 167103  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ExamGroupId == 177)
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=1796";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ExamGroupId == 231)
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE  ItemIdNew=0 OR ItemIdNew=2310";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(257))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=257  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(140))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=210  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(141))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=207 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(142))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=206  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(143))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=203";// 167103  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(144))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=205";// 167103  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(177))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=1796";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(231))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=2310";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(273))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 273";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(274))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 274";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(275))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 275";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(276))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 276";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(277))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 277";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(278))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 278";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(445))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 445";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(455))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 455";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
    }

    protected void ddlGroupofExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ExamGroupIdVal = Convert.ToInt32(ddlGroupofExam.SelectedValue);
        BindTypeofExamByGroupExId(ExamGroupIdVal);
    }

    #endregion

    #region ONSELECTED INDEX CHANGED FOR TYPE OF EXAM TO BIND STATE

    public void BindStateDropDownList()
    {
        string Sql = " SELECT DISTINCT StateId AS Id, StateName AS Name, 'India' AS CountryName FROM StateMaster ORDER BY StateName ";
        DataSet ds = cc.ExecuteDataset(Sql);

        ddlState.DataSource = ds.Tables[0];
        ddlState.DataTextField = "Name";
        ddlState.DataValueField = "Id";
        ddlState.DataBind();

        ddlState.Items.Add("--Select--");
        ddlState.SelectedIndex = ddlState.Items.Count - 1;
    }

    protected void ddlTypeofExam_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    #endregion

    #region ONSELECTED INDEX CHANGED EVENT FOR STATE TO BIND DISTRICTS

    public void BindDistrictByStateId(int stateId)
    {
        string Sql = " SELECT DISTINCT DistrictMaster.DistrictId AS Id, DistrictMaster.DistrictName AS Name, " +
                                " StateMaster.StateName, CountryMaster.CountryName " +
                                " FROM DistrictMaster INNER JOIN " +
                                " StateMaster ON DistrictMaster.StateId = StateMaster.StateId INNER JOIN " +
                                " CountryMaster ON StateMaster.CountryId = CountryMaster.CountryId  " +
                                " WHERE StateMaster.StateId=" + stateId + " ORDER BY DistrictMaster.DistrictName ";

        DataSet ds = cc.ExecuteDataset(Sql);

        ddlDistrict.DataSource = ds.Tables[0];
        ddlDistrict.DataTextField = "Name";
        ddlDistrict.DataValueField = "Id";
        ddlDistrict.DataBind();

        ddlDistrict.DataBind();
        ddlDistrict.Items.Add("--Select--");
        ddlDistrict.SelectedIndex = ddlState.Items.Count - 1;
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlState.SelectedIndex == ddlState.Items.Count - 1)
        {
            ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
        }
        else
        {
            BindDistrictByStateId(Convert.ToInt32(ddlState.SelectedValue));
        }
    }

    #endregion

    #region BIND DROPDOWNLISTS FROM ITEMMASTER AS CLASS,SUBJECT,PUBLICATION AND CHAPTERID

    public void BindItemMaster()
    {
        string sqlQuery = " SELECT [ItemValueId] AS Id,[Name] FROM [tblItemValue] WHERE [ItemId] = 0 OR [ItemId] = 1 ";
        //sqlQuery += " SELECT [ItemValueId] AS Id,[Name] FROM [tblItemValue] WHERE [ItemId] = 0 OR [ItemId] = 2 ";
        sqlQuery += " SELECT [ItemValueId] AS Id,[Name] FROM tblItemValue WHERE [ItemId] = 0 OR ItemId = 204 OR ItemId = 2 ORDER BY ItemValueId ASC";
        sqlQuery += " SELECT [ItemValueId] AS Id,[Name] FROM [tblItemValue] WHERE [ItemId] = 0 OR [ItemId] = 7 ";
        sqlQuery += " SELECT [ItemValueId] AS Id,[Name] FROM [tblItemValue] WHERE [ItemId] = 0 OR [ItemId] = 3 ";
        sqlQuery += " SELECT [ItemValueId] AS Id,[Name] FROM [tblItemValue] WHERE [ItemId] = 0 OR [ItemId] = 4 ";

        DataSet ds = cc.ExecuteDataset(sqlQuery);

        ddlClass.DataSource = ds.Tables[0];
        ddlClass.DataTextField = "Name";
        ddlClass.DataValueField = "Id";
        ddlClass.DataBind();

        ddlClass.DataBind();
        ddlClass.Items.Add("--Select--");
        ddlClass.SelectedIndex = ddlState.Items.Count - 1;

        ddlSubject.DataSource = ds.Tables[1];
        ddlSubject.DataTextField = "Name";
        ddlSubject.DataValueField = "Id";
        ddlSubject.DataBind();

        ddlSubject.DataBind();
        ddlSubject.Items.Add("--Select--");
        ddlSubject.SelectedIndex = ddlState.Items.Count - 1;

        ddlPublication.DataSource = ds.Tables[2];
        ddlPublication.DataTextField = "Name";
        ddlPublication.DataValueField = "Id";
        ddlPublication.DataBind();

        ddlPublication.DataBind();
        ddlPublication.Items.Add("--Select--");
        ddlPublication.SelectedIndex = ddlState.Items.Count - 1;

        ddlChapter.DataSource = ds.Tables[3];
        ddlChapter.DataTextField = "Name";
        ddlChapter.DataValueField = "Id";
        ddlChapter.DataBind();

        ddlChapter.DataBind();
        ddlChapter.Items.Add("--Select--");
        ddlChapter.SelectedIndex = ddlState.Items.Count - 1;

        ddlTopic.DataSource = ds.Tables[4];
        ddlTopic.DataTextField = "Name";
        ddlTopic.DataValueField = "Id";
        ddlTopic.DataBind();

        ddlTopic.DataBind();
        ddlTopic.Items.Add("--Select--");
        ddlTopic.SelectedIndex = ddlState.Items.Count - 1;
    }

    #endregion

    #region BIND INSERT CHAPTER GRIDVIEW

    public void BindInsertChapterGridview()
    {
        string sqlQuery = "SELECT * FROM [tblChapterANDTopicNames] ORDER BY [SnoID] DESC";
        DataSet ds = cc.ExecuteDataset(sqlQuery);

        gvInsertChapters.DataSource = ds.Tables[0];
        gvInsertChapters.DataBind();
    }

    #endregion

    #region INSERT AND UPDATE METHOD TO CHAPTER NAME

    public void UpdateChapterName(int IdSno)
    {
        objInsertChapterTopics.SnoId = IdSno;
        objInsertChapterTopics.GroupofExam = Convert.ToInt32(ddlGroupofExam.SelectedValue);
        objInsertChapterTopics.GroupofExamName = ddlGroupofExam.SelectedItem.Text;
        objInsertChapterTopics.TypeofExam = Convert.ToInt32(ddlTypeofExam.SelectedValue);
        objInsertChapterTopics.TypeofExamName = ddlTypeofExam.SelectedItem.Text;
        objInsertChapterTopics.StateId = Convert.ToInt32(ddlState.SelectedValue);
        objInsertChapterTopics.StateName = ddlState.SelectedItem.Text;
        objInsertChapterTopics.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
        objInsertChapterTopics.DistrictName = ddlDistrict.SelectedItem.Text;
        objInsertChapterTopics.BoardId = 1;
        objInsertChapterTopics.BoardName = txtBoard.Text;
        objInsertChapterTopics.UniversityId = 1;
        objInsertChapterTopics.UniversityName = txtUniversity.Text;
        objInsertChapterTopics.Medium = ddlMedium.SelectedItem.Text;
        objInsertChapterTopics.ClassId = Convert.ToInt32(ddlClass.SelectedValue);
        objInsertChapterTopics.ClassName = ddlClass.SelectedItem.Text;
        objInsertChapterTopics.SubjectId = Convert.ToInt32(ddlSubject.SelectedValue);
        objInsertChapterTopics.SubjectName = ddlSubject.SelectedItem.Text;
        objInsertChapterTopics.PublicationId = Convert.ToInt32(ddlPublication.SelectedValue);
        objInsertChapterTopics.PublicationName = ddlPublication.SelectedItem.Text;
        objInsertChapterTopics.ChapterId = Convert.ToInt32(ddlChapter.SelectedValue);
        objInsertChapterTopics.ChapterName = txtChapterName.Text;
        objInsertChapterTopics.TopicId = Convert.ToInt32(ddlTopic.SelectedValue);//1;
        objInsertChapterTopics.TopicName = txtTopicName.Text;//"";
        objInsertChapterTopics.LoginUser = Convert.ToString(Session["LoginId"]);

        if (objInsertChapterTopics.UpdateChapterName() == 106)
        {
            lblStatus.Text = "Record Updated Successfully..!!!";
            lblStatus.ForeColor = System.Drawing.Color.White;
            lblStatus.BackColor = System.Drawing.Color.Chocolate;
            BindInsertChapterGridview();
        }
        else
        {
            lblStatus.Text = "Error to Update Record..!!!";
            lblStatus.ForeColor = System.Drawing.Color.White;
            lblStatus.BackColor = System.Drawing.Color.Crimson;
        }
    }

    public void AddNewChapterName()
    {

        objInsertChapterTopics.GroupofExam = Convert.ToInt32(ddlGroupofExam.SelectedValue);
        objInsertChapterTopics.GroupofExamName = ddlGroupofExam.SelectedItem.Text;
        objInsertChapterTopics.TypeofExam = Convert.ToInt32(ddlTypeofExam.SelectedValue);
        objInsertChapterTopics.TypeofExamName = ddlTypeofExam.SelectedItem.Text;
        objInsertChapterTopics.StateId = Convert.ToInt32(ddlState.SelectedValue);
        objInsertChapterTopics.StateName = ddlState.SelectedItem.Text;
        objInsertChapterTopics.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
        objInsertChapterTopics.DistrictName = ddlDistrict.SelectedItem.Text;
        objInsertChapterTopics.BoardId = 1;
        objInsertChapterTopics.BoardName = txtBoard.Text;
        objInsertChapterTopics.UniversityId = 1;
        objInsertChapterTopics.UniversityName = txtUniversity.Text;
        objInsertChapterTopics.Medium = ddlMedium.SelectedItem.Text;
        objInsertChapterTopics.ClassId = Convert.ToInt32(ddlClass.SelectedValue);
        objInsertChapterTopics.ClassName = ddlClass.SelectedItem.Text;
        objInsertChapterTopics.SubjectId = Convert.ToInt32(ddlSubject.SelectedValue);
        objInsertChapterTopics.SubjectName = ddlSubject.SelectedItem.Text;
        objInsertChapterTopics.PublicationId = Convert.ToInt32(ddlPublication.SelectedValue);
        objInsertChapterTopics.PublicationName = ddlPublication.SelectedItem.Text;
        objInsertChapterTopics.ChapterId = Convert.ToInt32(ddlChapter.SelectedValue);
        objInsertChapterTopics.ChapterName = txtChapterName.Text;
        objInsertChapterTopics.TopicId = Convert.ToInt32(ddlTopic.SelectedValue);//1;
        objInsertChapterTopics.TopicName = txtTopicName.Text;//"";
        objInsertChapterTopics.LoginUser = Convert.ToString(Session["LoginId"]);

        string sql = "Select * from [tblChapterANDTopicNames] where [TypeofExamId]=" + objInsertChapterTopics.TypeofExam + " and [ClassID]=" + objInsertChapterTopics.ClassId + " and [SubjectID]=" + objInsertChapterTopics.SubjectId + " and [ChapterID]=" + objInsertChapterTopics.TopicId + " ";
        DataSet ds = cc.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
           
        }
        else
        {
            if (objInsertChapterTopics.InsertChapterNames() == 106)
            {
                lblStatus.Text = "Record Added Successfully..!!!";
                lblStatus.ForeColor = System.Drawing.Color.White;
                lblStatus.BackColor = System.Drawing.Color.Chocolate;
                BindInsertChapterGridview();
            }
            else
            {
                lblStatus.Text = "Error to Add Record..!!!";
                lblStatus.ForeColor = System.Drawing.Color.White;
                lblStatus.BackColor = System.Drawing.Color.Crimson;
            }
        }

    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnInsert.Text == "INSERT_RECORD")
            {
                AddNewChapterName();
            }
            else
            {
                UpdateChapterName(Convert.ToInt32(hiddenSnoId.Value));
            }
        }
        catch { }
    }

    #endregion

    protected void gvInsertChapters_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInsertChapters.PageIndex = e.NewPageIndex;
        BindInsertChapterGridview();
    }

    protected void gvInsertChapters_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int snoId = Convert.ToInt32(e.CommandArgument);

        if (Convert.ToString(e.CommandName) == "MODIFY")
        {
            hiddenSnoId.Value = Convert.ToString(snoId);
            objInsertChapterTopics.SnoId = snoId;
            dataset = objInsertChapterTopics.GetChapterDataBySnoId();
            if (dataset != null && dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
            {
                ddlGroupofExam.SelectedValue = dataset.Tables[0].Rows[0]["GroupofExamId"].ToString();
                BindTypeofExamByGroupExId(Convert.ToInt32(ddlGroupofExam.SelectedValue));
                ddlTypeofExam.SelectedValue = dataset.Tables[0].Rows[0]["TypeofExamId"].ToString();
                ddlState.SelectedValue = dataset.Tables[0].Rows[0]["StateID"].ToString();
                BindDistrictByStateId(Convert.ToInt32(ddlState.SelectedValue));
                ddlDistrict.SelectedValue = dataset.Tables[0].Rows[0]["DistrictID"].ToString();
                txtBoard.Text = dataset.Tables[0].Rows[0]["BoardName"].ToString();
                txtUniversity.Text = dataset.Tables[0].Rows[0]["UniversityName"].ToString();
                ddlMedium.SelectedItem.Text = dataset.Tables[0].Rows[0]["Medium"].ToString();
                ddlClass.SelectedValue = dataset.Tables[0].Rows[0]["ClassID"].ToString();
                ddlSubject.SelectedValue = dataset.Tables[0].Rows[0]["SubjectID"].ToString();
                ddlPublication.SelectedValue = dataset.Tables[0].Rows[0]["PublicationID"].ToString();
                ddlChapter.SelectedValue = dataset.Tables[0].Rows[0]["ChapterID"].ToString();
                txtChapterName.Text = dataset.Tables[0].Rows[0]["ChapterName"].ToString();
                ddlTopic.SelectedValue = dataset.Tables[0].Rows[0]["TopicID"].ToString();
                txtTopicName.Text = dataset.Tables[0].Rows[0]["TopicName"].ToString();

                btnInsert.Text = "UPDATE_RECORD";
            }
        }
        else if (Convert.ToString(e.CommandName) == "DELETE")
        {
            objInsertChapterTopics.SnoId = snoId;
            if (objInsertChapterTopics.DeleteChapterName() > 106)
            {
                lblStatus.Text = "Record Deleted Successfully..!!!";
                lblStatus.ForeColor = System.Drawing.Color.White;
                lblStatus.BackColor = System.Drawing.Color.Chocolate;
            }
            else
            {
                lblStatus.Text = "Error to Delete Record..!!!";
                lblStatus.ForeColor = System.Drawing.Color.White;
                lblStatus.BackColor = System.Drawing.Color.Crimson;
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {

    }
}