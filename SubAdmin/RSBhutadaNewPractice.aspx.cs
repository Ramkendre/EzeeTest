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


public partial class SubAdmin_RSBhutadaNewPractice : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void ddlGroupofExam_SelectedIndexChanged(object sender, EventArgs e)
    {
         if (ddlGroupofExam.SelectedValue == Convert.ToString(141))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=207  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
         else if (ddlGroupofExam.SelectedValue == Convert.ToString(142))
         {
             Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=206  ";
             DataSet ds = cc.ExecuteDataset(Sql);

             ddlTypeofExam.DataSource = ds.Tables[0];
             ddlTypeofExam.DataTextField = "Name";
             ddlTypeofExam.DataValueField = "ItemValueIdNew";
             ddlTypeofExam.DataBind();
         }
    }
    protected void ddlTypeofExam_SelectedIndexChanged(object sender, EventArgs e)
    {
         if (ddlTypeofExam.SelectedValue == Convert.ToString(98))
        {
            ddlClassName.Enabled = true;
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=202 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlClassName.DataSource = ds.Tables[0];
            ddlClassName.DataTextField = "Name";
            ddlClassName.DataValueField = "ItemValueIdNew";
            ddlClassName.DataBind();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(99))
        {
            ddlClassName.Enabled = true;
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=202 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlClassName.DataSource = ds.Tables[0];
            ddlClassName.DataTextField = "Name";
            ddlClassName.DataValueField = "ItemValueIdNew";
            ddlClassName.DataBind();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(100))
        {
            ddlClassName.Enabled = true;
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=202 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlClassName.DataSource = ds.Tables[0];
            ddlClassName.DataTextField = "Name";
            ddlClassName.DataValueField = "ItemValueIdNew";
            ddlClassName.DataBind();
        }
    }
    protected void ddlClassName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlClassName.SelectedValue == Convert.ToString(15) || ddlClassName.SelectedValue == Convert.ToString(16)) && ddlTypeofExam.SelectedValue == Convert.ToString(99))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where ItemIdNew=0 or  ItemIdNew=209 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlSubject.DataSource = ds.Tables[0];
            ddlSubject.DataTextField = "Name";
            ddlSubject.DataValueField = "ItemValueIdNew";
            ddlSubject.DataBind();
        }

        else if ((ddlClassName.SelectedValue == Convert.ToString(16) || ddlClassName.SelectedValue == Convert.ToString(15)) && (ddlTypeofExam.SelectedValue == Convert.ToString(98) || ddlTypeofExam.SelectedValue == Convert.ToString(100)))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where ItemIdNew=0 or  ItemIdNew=208 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlSubject.DataSource = ds.Tables[0];
            ddlSubject.DataTextField = "Name";
            ddlSubject.DataValueField = "ItemValueIdNew";
            ddlSubject.DataBind();
        }
    }
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        

        Sql = " select distinct ISNULL(userChapterName,'') as userChapterName  from tblQuestionAccess " +
              " where TypeOFExam='" + ddlTypeofExam.SelectedValue + "' and Subject_id='" + ddlSubject.SelectedValue + "' and MediumID='English'  " +
              " and TypeofMaterial='Competitive Exam' and Class_id='" + ddlClassName.SelectedValue + "' and userChapterName NOT IN (' ') ";

        ds = cc.ExecuteDataset(Sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            LoadChapter();
        }
        else
        {
            Sql = " select Name,ItemValueId from tblItemValue where ItemId = 3 ";
            ds = cc.ExecuteDataset(Sql);

            ddlChapter.DataSource = ds.Tables[0];
            ddlChapter.DataTextField = "Name";
            ddlChapter.DataValueField = "ItemValueId";
            ddlChapter.DataBind();

            ChkSelectALL.Visible = true;
        }

    
    }


    #region LoadChapter in CheckBox_selectAll

    private void LoadChapter()
    {
        try
        {
            ChkSelectALL.Checked = false;

            string Sql = " select distinct ISNULL(Chapter_id,'') as Chapter_id , ISNULL(userChapterName,'') as userChapterName  from tblQuestionAccess " +
                         " where TypeOFExam='" + ddlTypeofExam.SelectedValue + "' and Subject_id='" + ddlSubject.SelectedValue + "' and MediumID='English'  " +
                         " and TypeofMaterial='Competitive Exam' and Class_id='" + ddlClassName.SelectedValue + "' and Chapter_id NOT IN ('1') and userChapterName NOT IN (' ') ";


            DataSet ds = cc.ExecuteDataset(Sql);
            if (ddlSubject.SelectedItem.Text == "--Select--")
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


    int count = 0;

    protected void btnFindQuestions_Click(object sender, EventArgs e)
    {
        try
        {
           
             if (ddlSubject.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Subject Name')", true);

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


                // string material = Convert.ToString(rdoTypeofMaterial.SelectedItem.Text);
                string exam = Convert.ToString(ddlTypeofExam.SelectedValue);
                string cl = Convert.ToString(ddlClassName.SelectedValue);
                string su = Convert.ToString(ddlSubject.SelectedValue);
                string ch = chapterID;
                //string level = Convert.ToString(rdoLevelList1.SelectedValue);
                //string Medium = Convert.ToString(ddlMedium.SelectedItem.Text);

                if (ch == "")
                {

                    Sql = "select count(*) from dbo.tblQuestionAccess where Subject_id=" + su + " and MediumID='English' and TypeOFExam='" + exam + "' and Class_id=" + cl + " and TypeofMaterial='Competitive Exam' ";

                }
                else
                {
                    Sql = "select count(*) from dbo.tblQuestionAccess where Subject_id=" + su + " and MediumID='English'   and Chapter_id in(" + ch + ")  and TypeOFExam='" + exam + "' and Class_id=" + cl + " and TypeofMaterial='Competitive Exam' ";

                }

                string combo = su + "*" + ch + "*" + "Competitive Exam" + "*" + exam + "*" + cl + "*" + "English";
                count = Convert.ToInt32(cc.ExecuteScalar(Sql));
                if (count > 0)
                {

                    Response.Redirect("~/SubAdmin/RSBhutadaNewPractice1.aspx?combo=" + combo, true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('No Question found for this combination ')", true);

                }
            }

        }
        catch 
        {
 
        }
    }
}