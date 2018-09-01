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
using System.Drawing.Text;
using System.Collections.Generic;
using System.Timers;

public partial class SubAdmin_RSBCustomerTestDefine : System.Web.UI.Page
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
    int j1 = 1, k1;

    string Sql = "", Sqlquery = "", SNOstring = "";


    int i1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string Sql = "select Name,ItemValueId from tblItemValue where  ItemId=3";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlChapter.DataSource = ds.Tables[0];
            ddlChapter.DataTextField = "Name";
            ddlChapter.DataValueField = "ItemValueId";
            ddlChapter.DataBind();
            ChkSelectALL.Visible = true;

            BindGridViewTest();
        }
    }

    private void BindGridViewTest()
    {
        string Sql = "Select *from tblTestDefinition Where LoginId='" + Convert.ToString(Session["Loginid"]) + "' Order By Test_ID DESC";
        DataSet ds = cc.ExecuteDataset(Sql);
        gvRSBTestList.DataSource = ds.Tables[0];
        gvRSBTestList.DataBind();
    }

    #region Group of Exams

    protected void ddlGroupofExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGroupofExam.SelectedValue == Convert.ToString(135))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=212  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(136))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=213  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(137))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=214  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(141))
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
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=206";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }

        else if (ddlGroupofExam.SelectedValue == Convert.ToString(140))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=210";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }

        else if (ddlGroupofExam.SelectedValue == Convert.ToString(143))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=203";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(144))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=205";
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
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(445))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=445";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
    }

    #endregion

    #region TypeOFExam

    protected void binddropdown202()
    {
        ddlClassName.Enabled = true;
        Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=202 ";
        DataSet ds = cc.ExecuteDataset(Sql);

        ddlClassName.DataSource = ds.Tables[0];
        ddlClassName.DataTextField = "Name";
        ddlClassName.DataValueField = "ItemValueIdNew";
        ddlClassName.DataBind();
    }
    protected void binddropdown201()
    {
        ddlClassName.Enabled = true;
        Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=201 ";
        DataSet ds = cc.ExecuteDataset(Sql);

        ddlClassName.DataSource = ds.Tables[0];
        ddlClassName.DataTextField = "Name";
        ddlClassName.DataValueField = "ItemValueIdNew";
        ddlClassName.DataBind();
    }
    protected void binddropdown211()
    {
        ddlClassName.Enabled = true;
        Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=211 ";
        DataSet ds = cc.ExecuteDataset(Sql);

        ddlClassName.DataSource = ds.Tables[0];
        ddlClassName.DataTextField = "Name";
        ddlClassName.DataValueField = "ItemValueIdNew";
        ddlClassName.DataBind();
    }
    protected void binddropdown2()
    {
        Sql = "select Name,ItemValueId from tblItemValue where ItemId=2";
        DataSet ds = cc.ExecuteDataset(Sql);
        ddlSubjectName.DataSource = ds.Tables[0];
        ddlSubjectName.DataTextField = "Name";
        ddlSubjectName.DataValueField = "ItemValueId";
        ddlSubjectName.DataBind();
        ddlClassName.SelectedValue = "1";
        ddlClassName.Enabled = false;
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

        else if (ddlTypeofExam.SelectedValue == Convert.ToString(88))
        {
           binddropdown201();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(271))
        {
            binddropdown201();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(272))
        {
            binddropdown201();
        }

        else if (ddlTypeofExam.SelectedValue == Convert.ToString(96))
        {
            binddropdown211();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(101))
        {
            binddropdown211();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(102))
        {
            binddropdown211();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(89))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(94))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(95))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(130))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(110))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=204 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlSubjectName.DataSource = ds.Tables[0];
            ddlSubjectName.DataTextField = "Name";
            ddlSubjectName.DataValueField = "ItemValueIdNew";
            ddlSubjectName.DataBind();
            ddlClassName.SelectedValue = "1";
            ddlClassName.Enabled = false;
        }

        else if (ddlTypeofExam.SelectedValue == Convert.ToString(103))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(165))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(179))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(180))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(176))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(184))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(185))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(191))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(193))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(200) || ddlTypeofExam.SelectedValue == Convert.ToString(201) || ddlTypeofExam.SelectedValue == Convert.ToString(202) || ddlTypeofExam.SelectedValue == Convert.ToString(203) || ddlTypeofExam.SelectedValue == Convert.ToString(204) || ddlTypeofExam.SelectedValue == Convert.ToString(205) || ddlTypeofExam.SelectedValue == Convert.ToString(206) || ddlTypeofExam.SelectedValue == Convert.ToString(207))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(217))
        {
            binddropdown2();
        }

        else if (ddlTypeofExam.SelectedValue == Convert.ToString(227))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(228))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(229))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(230))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(234))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(235))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(236))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(237))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(248))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(254))
        {
            binddropdown2();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(224))
        {
            ddlClassName.Enabled = true;
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=201 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlClassName.DataSource = ds.Tables[0];
            ddlClassName.DataTextField = "Name";
            ddlClassName.DataValueField = "ItemValueIdNew";
            ddlClassName.DataBind();
        }
        else if (ddlTypeofExam.SelectedValue == Convert.ToString(446) || ddlTypeofExam.SelectedValue == Convert.ToString(447) || ddlTypeofExam.SelectedValue == Convert.ToString(448) || ddlTypeofExam.SelectedValue == Convert.ToString(449))
        {
            binddropdown2();
        }
    }
    #endregion

    #region ClassNames

    protected void ddlClassName_SelectedIndexChanged(object sender, EventArgs e)
    {

        for (int count = 0; count < 15; count++)
        {
            if (ddlClassName.SelectedValue == Convert.ToString(count))
            {
                Sql = Sql + "select Name,ItemValueId from tblItemValue where ItemIdNew=0 or ItemId=2 ";
                DataSet ds = cc.ExecuteDataset(Sql);

                ddlSubjectName.DataSource = ds.Tables[0];
                ddlSubjectName.DataTextField = "Name";
                ddlSubjectName.DataValueField = "ItemValueId";
                ddlSubjectName.DataBind();
            }
        }

        if ((ddlClassName.SelectedValue == Convert.ToString(15) || ddlClassName.SelectedValue == Convert.ToString(16)) && ddlTypeofExam.SelectedValue == Convert.ToString(99))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where ItemIdNew=0 or  ItemIdNew=209 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlSubjectName.DataSource = ds.Tables[0];
            ddlSubjectName.DataTextField = "Name";
            ddlSubjectName.DataValueField = "ItemValueIdNew";
            ddlSubjectName.DataBind();
        }

        else if ((ddlClassName.SelectedValue == Convert.ToString(16) || ddlClassName.SelectedValue == Convert.ToString(15)) && (ddlTypeofExam.SelectedValue == Convert.ToString(98) || ddlTypeofExam.SelectedValue == Convert.ToString(100)))
        {
            Sql = Sql + "select Name,ItemValueIdNew from tblItemValue where ItemIdNew=0 or  ItemIdNew=208 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlSubjectName.DataSource = ds.Tables[0];
            ddlSubjectName.DataTextField = "Name";
            ddlSubjectName.DataValueField = "ItemValueIdNew";
            ddlSubjectName.DataBind();
        }
        else if (ddlClassName.SelectedValue == Convert.ToString(188))
        {
            Sql = Sql + "select Name,ItemValueId from tblItemValue where   ItemId=2 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlSubjectName.DataSource = ds.Tables[0];
            ddlSubjectName.DataTextField = "Name";
            ddlSubjectName.DataValueField = "ItemValueId";
            ddlSubjectName.DataBind();
        }
        else if (ddlClassName.SelectedValue == Convert.ToString(189))
        {
            Sql = Sql + "select Name,ItemValueId from tblItemValue where   ItemId=2 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlSubjectName.DataSource = ds.Tables[0];
            ddlSubjectName.DataTextField = "Name";
            ddlSubjectName.DataValueField = "ItemValueId";
            ddlSubjectName.DataBind();
        }
    }

    #endregion

    protected void btnCreateTest_Click(object sender, EventArgs e)
    {
        int totques1 = 0;
        int.TryParse(TextBox0.Text, out totques1);
        int totques2 = 0;
        int.TryParse(TextBox1.Text, out totques2);
        int totques3 = 0;
        int.TryParse(TextBox2.Text, out totques3);
        int totques4 = 0;
        int.TryParse(TextBox3.Text, out totques4);
        int totques5 = 0;
        int.TryParse(TextBox4.Text, out totques5);
        int totques6 = 0;
        int.TryParse(TextBox5.Text, out totques6);
        int totques7 = 0;
        int.TryParse(TextBox6.Text, out totques7);
        int totques8 = 0;
        int.TryParse(TextBox7.Text, out totques8);
        int totques9 = 0;
        int.TryParse(TextBox8.Text, out totques9);
        int totques10 = 0;
        int.TryParse(TextBox9.Text, out totques10);
        int totques11 = 0;
        int.TryParse(TextBox10.Text, out totques11);
        int totques12 = 0;
        int.TryParse(TextBox11.Text, out totques12);
        int totques13 = 0;
        int.TryParse(TextBox12.Text, out totques13);
        int totques14 = 0;
        int.TryParse(TextBox13.Text, out totques14);
        int totques15 = 0;
        int.TryParse(TextBox14.Text, out totques15);
        int totques16 = 0;
        int.TryParse(TextBox15.Text, out totques16);
        int totques17 = 0;
        int.TryParse(TextBox16.Text, out totques17);
        int totques18 = 0;
        int.TryParse(TextBox17.Text, out totques18);
        int totques19 = 0;
        int.TryParse(TextBox18.Text, out totques19);
        int totques20 = 0;
        int.TryParse(TextBox19.Text, out totques20);
        int totques21 = 0;
        int.TryParse(TextBox20.Text, out totques21);
        int totques22 = 0;
        int.TryParse(TextBox21.Text, out totques22);
        int totques23 = 0;
        int.TryParse(TextBox22.Text, out totques23);
        int totques24 = 0;
        int.TryParse(TextBox23.Text, out totques24);
        int totques25 = 0;
        int.TryParse(TextBox24.Text, out totques25);
        int totques26 = 0;
        int.TryParse(TextBox25.Text, out totques26);
        int totques27 = 0;
        int.TryParse(TextBox26.Text, out totques27);
        int totques28 = 0;
        int.TryParse(TextBox27.Text, out totques28);
        int totques29 = 0;
        int.TryParse(TextBox28.Text, out totques29);
        int totques30 = 0;
        int.TryParse(TextBox29.Text, out totques30);
        int totques31 = 0;
        int.TryParse(TextBox30.Text, out totques31);
        int totques32 = 0;
        int.TryParse(TextBox31.Text, out totques32);
        int totques33 = 0;
        int.TryParse(TextBox32.Text, out totques33);
        int totques34 = 0;
        int.TryParse(TextBox33.Text, out totques34);
        int totques35 = 0;
        int.TryParse(TextBox34.Text, out totques35);

        int totques = totques1 + totques2 + totques3 + totques4 + totques5 + totques6 + totques7 + totques8 + totques9 + totques10 + totques11 + totques12 + totques13 + totques14 + totques15 + totques16 + totques17 + totques18 + totques19 + totques20 + totques21 + totques22 + totques23 + totques24 + totques25 + totques26 + totques27 + totques28 + totques29 + totques30 + totques31 + totques32 + totques33 + totques34 + totques35;

        if (Convert.ToInt32(txtTotalNoQues.Text) == totques)
        {
            if (Convert.ToString(Session["Loginid"]) == "9292929292")
            {
                AddNewInsert();
            }
            else
            {
                string SqlQuery = "Select COUNT(*) from tblTestDefinition Where LoginId='" + Convert.ToString(Session["Loginid"]) + "'";
                string val = cc.ExecuteScalar(SqlQuery);
                int val1 = Convert.ToInt32(val);

                if (val1 >= 30)
                {
                    lblError.Text = "You Can not Permit More than 30 Test Plz Contact Us...";
                    lblError.ForeColor = System.Drawing.Color.BlueViolet;
                    lblError.Font.Bold = true;
                }
                else
                {
                    AddNewInsert();
                }
            }
            DataSet ds = new DataSet();
            Sql = "Select *from tblTestDefinition Where LoginId='" + Convert.ToString(Session["Loginid"]) + "' Order By Test_ID DESC";
            ds = cc.ExecuteDataset(Sql);
            gvRSBTestList.DataSource = ds.Tables[0];
            gvRSBTestList.DataBind();

        }
        else
        {
            lblError.Text = "Total No of Questions and Chapter Wise Question Value Should Match.";
            lblError.ForeColor = System.Drawing.Color.BlueViolet;
        }
    }

    private void AddNewInsert()
    {
        string ChapWiseQues = "";


        try
        {

            string chapterID = "", chapterName = "";

            for (int c = 0; c < ddlChapter.Items.Count; c++)
            {
                if (ddlChapter.Items[c].Selected == true)
                {
                    chapterID = chapterID + "," + ddlChapter.Items[c].Value;
                    chapterName = chapterName + "," + ddlChapter.Items[c].Text;
                }
            }
            if (chapterID.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select AtLeast One Chapter.!!!')", true);
            }
            else
            {


                if (chapterID.Length > 1)
                {

                    chapterID = chapterID.Substring(1);
                }
                if (chapterName.Length > 1)
                {
                    chapterName = chapterName.Substring(1);
                }


                if (TextBox0.Text != "" || TextBox1.Text != "" || TextBox2.Text != "" || TextBox3.Text != "" || TextBox4.Text != "" || TextBox5.Text != "" || TextBox6.Text != "" || TextBox7.Text != "" || TextBox8.Text != "" || TextBox9.Text != "" || TextBox10.Text != "" || TextBox11.Text != "" || TextBox12.Text != "" || TextBox13.Text != "" || TextBox14.Text != "" || TextBox15.Text != "" || TextBox16.Text != "" || TextBox17.Text != "" || TextBox18.Text != "" || TextBox19.Text != "" || TextBox20.Text != "" || TextBox21.Text != "" || TextBox22.Text != "" || TextBox23.Text != "" || TextBox24.Text != "" || TextBox25.Text != "" || TextBox26.Text != "" || TextBox27.Text != "" || TextBox28.Text != "" || TextBox29.Text != "" || TextBox30.Text != "" || TextBox31.Text != "" || TextBox32.Text != "" || TextBox33.Text != "" || TextBox34.Text != "")
                {
                    ChapWiseQues = TextBox0.Text + "*" + TextBox1.Text + "*" + TextBox2.Text + "*" + TextBox3.Text + "*" + TextBox4.Text + "*" + TextBox5.Text + "*" + TextBox6.Text + "*" + TextBox7.Text + "*" + TextBox8.Text + "*" + TextBox9.Text + "*" + TextBox10.Text + "*" + TextBox11.Text + "*" + TextBox12.Text + "*" + TextBox13.Text + "*" + TextBox14.Text + "*" + TextBox15.Text + "*" + TextBox16.Text + "*" + TextBox17.Text + "*" + TextBox18.Text + "*" + TextBox19.Text + "*" + TextBox20.Text + "*" + TextBox21.Text + "*" + TextBox22.Text + "*" + TextBox23.Text + "*" + TextBox24.Text + "*" + TextBox25.Text + "*" + TextBox26.Text + "*" + TextBox27.Text + "*" + TextBox28.Text + "*" + TextBox29.Text + "*" + TextBox30.Text + "*" + TextBox31.Text + "*" + TextBox32.Text + "*" + TextBox33.Text + "*" + TextBox34.Text;
                }


                string Login = Convert.ToString(Session["Loginid"]);
                string UserType = Convert.ToString(Session["UserType"]);
                string ParentID = Convert.ToString(Session["parentrole"]);



                for (int i1 = 0; i1 < Convert.ToInt32(txtNoofRepeat.Text); i1++)
                {
                    string TestName = txtTestName.Text + " Set " + j1;

                    string Sql1 = "Insert Into tblTestDefinition (Exam_Name,Exam_date,Exam_Duration,DLevel1,DLevel2,DLevel3,TypeofMaterial,TypeofExam,Class_id,Subject_id," +
                    " LoginId,MediumID,MarkCorrA,MarkPass,Retake,BreakAllow,ReverseNavig,NegativeMark,MarkforNegative,SubjectName," +
                    " GroupOfQuestion,IndexNo,TypeofTest,ParentID,UserType,TestCreateDate,TotNoQues,ChapWiseQues,ExamName,ClassName,ChapterName,ChapterID)" +
                    " Values " +
                                " ('" + TestName + "','" + System.DateTime.Now.Date.AddDays(j1).ToString("yyyy-MM-dd") + "','" + txtTestDuration.Text + "','1','1','1','Competitive Exam','" + ddlTypeofExam.SelectedValue + "','" + ddlClassName.SelectedValue + "'" +
                               " ,'" + ddlSubjectName.SelectedValue + "','" + Login + "','" + ddlMedium.SelectedItem.Text + "','" + txtMarkForCorrA.Text + "','" + txtMarkForPass.Text + "','" + rdolstretake.SelectedItem.Text + "','" + rdolstBreak.SelectedItem.Text + "','" + rdolstReverseNavi.SelectedItem.Text + "','" + rdolstNegativeMarks.SelectedItem.Text + "','" + txtIfYes.Text + "'," +
                    " '" + ddlSubjectName.SelectedItem.Text + "','0','0','" + ddlTypeofTest.SelectedValue + "','" + ParentID + "','" + UserType + "','" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "'," +
                    " '" + txtTotalNoQues.Text + "','" + ChapWiseQues + "','" + ddlTypeofExam.SelectedItem.Text + "'," +
                    " '" + ddlClassName.SelectedItem.Text + "','" + chapterName + "','" + chapterID + "')";

                    int status = cc.ExecuteNonQuery(Sql1);

                    j1++;


                    if (status > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('" + j1 + "'' Test Created Successfully !!!')", true);
                        lblError.ForeColor = System.Drawing.Color.Green;

                        lblError.Font.Bold = true;

                        lblError.Text = j1 + " Test Created Successfully !!!";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Test Not Created. !!!')", true);
                        lblError.Text = "Test Not Created. !!!";
                    }
                }


            }
        }
        catch 
        {

        }

    }

    protected void lnkbtnRSBTestHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SubAdmin/RSBTestHome.aspx");

    }

    protected void gvRSBTestList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRSBTestList.PageIndex = e.NewPageIndex;

        DataSet ds = new DataSet();
        Sql = "Select *from tblTestDefinition Where LoginId='" + Convert.ToString(Session["Loginid"]) + "' Order By Test_ID DESC";
        ds = cc.ExecuteDataset(Sql);
        gvRSBTestList.DataSource = ds.Tables[0];
        gvRSBTestList.DataBind();
    }


    protected void rdolstNegativeMarks_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdolstNegativeMarks.SelectedItem.Text == "No")
        {
            txtIfYes.Text = "";
            txtIfYes.Enabled = false;
        }
        else
        {
            txtIfYes.Enabled = true;
        }
    }
    protected void gvRSBTestList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            string Id = Convert.ToString(e.CommandArgument);

            if (Convert.ToString(e.CommandName) == "Prepare_Test")
            {
                Session["TestID"] = Id;
                PrepareTest();
            }
            if (Convert.ToString(e.CommandName) == "Delete")
            {
                Session["TestID"] = Id;
                DeleteTest();
                BindGridViewTest();
            }
        }
        catch (Exception ex)
        {

        }

    }

    protected void gvRSBTestList_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    private void DeleteTest()
    {
        string SqlQuery = "Delete From tblTestDefinition Where Test_ID ='" + Session["TestID"] + "' ";
        int status = cc.ExecuteNonQuery(SqlQuery);

        if (status != 0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Test Deleted Successfully..!!!')", true);

            this.lblResult.Visible = true;
            this.lblResult.ForeColor = System.Drawing.Color.Green;
            this.lblResult.Font.Bold = true;
            this.lblResult.Text = "Test Deleted Successfully...!!!";
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Test Not Deleted..!!!')", true);
        }
    }


    //Below function is for Perparing Test 
    private void PrepareTest()
    {
        try
        {
            //string s11 = "tbl" + Convert.ToString(Session["CompanyId"]);

            DataSet dataset = new DataSet();

            string Login = Convert.ToString(Session["Loginid"]);

            Sql = "Select SNO from tbl5254 Where TestID='" + Convert.ToInt32(Session["TestID"]) + "'";

            dataset = cc.ExecuteDataset(Sql);

            if (dataset.Tables[0].Rows.Count == 0)
            {

                string SQLQuery = "Select *from tblTestDefinition where Test_ID='" + Convert.ToInt32(Session["TestID"]) + "' and LoginId='" + Login + "'";

                dataset = cc.ExecuteDataset(SQLQuery);

                string sTypeofMaterial = dataset.Tables[0].Rows[0][7].ToString();
                string sTypeofExam = dataset.Tables[0].Rows[0][8].ToString();
                string sClassid = dataset.Tables[0].Rows[0][9].ToString();
                string sSubjectid = dataset.Tables[0].Rows[0][10].ToString();


                string TotNoQues = dataset.Tables[0].Rows[0][29].ToString();
                string chawiseques = dataset.Tables[0].Rows[0][30].ToString();
                string chapterID = dataset.Tables[0].Rows[0][34].ToString();

                string[] chapwiseques1 = chawiseques.Split('*');


                var temp = new List<string>();
                foreach (var s in chapwiseques1)
                {
                    if (!string.IsNullOrEmpty(s))
                        temp.Add(s);
                }
                chapwiseques1 = temp.ToArray();


                string[] ChapterID1 = chapterID.Split(',');

                foreach (string label in ChapterID1)
                {
                    lblChapterID.Text += " ' " + label + " ' " + ",";
                }

                if (lblChapterID.Text != "")
                {
                    lblChapterID.Text = lblChapterID.Text.Substring(0, lblChapterID.Text.Length - 1);
                }

                for (int i = 0; i < ChapterID1.Length; i++)
                {
                    Sqlquery = @"SELECT [questions] FROM QuestionsUsed where  [userId]='" + Login + "' and [typeofexam]='" + sTypeofExam + "' and [class]='" + sClassid + "' and [subject]='" + sSubjectid + "' and [chapter]='" + ChapterID1[i1] + "'";
                    SNOstring = cc.ExecuteScalar(Sqlquery);

                    if (lblChapterID.Text != "")
                    {
                        chapwiseques1[k1].Trim();
                        ChapterID1[i1].Trim();

                        int noofquestion = 0;
                        if (string.IsNullOrEmpty(SNOstring))
                        {
                            Sql = @" SELECT count(SNO) FROM tblQuestionAccess  where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ")";
                            noofquestion = Convert.ToInt32(cc.ExecuteScalar(Sql));
                            SNOstring = "0";
                        }
                        else
                        {
                            //SNOstring = SNOstring.Substring(1);
                            Sql = @" SELECT count(SNO) FROM tblQuestionAccess  where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ") and SNO NOT IN (" + SNOstring + ")";
                            noofquestion = Convert.ToInt32(cc.ExecuteScalar(Sql));
                        }
                        int qustion = Convert.ToInt32(chapwiseques1[k1]);

                        if (noofquestion > qustion)
                        {
                            Sql = " insert into tbl5254" +
                                                           " SELECT Top " + chapwiseques1[k1] + "  SNO,Question_id,Question,QType,Answer1,AType,Answer2,BType,Answer3,CType,Answer4,DType,OptionE,EType,OptionP,PType,OptionQ,QType1,OptionR,RType,OptionS,SType, " +
                                                           " OptionT,TType,Passage,passageType,QuesWithImage,Q1Type,Qhint,hType,Correct_answer,QuestionLevel,MobileNo,SettingId,changeDate,Ischecked,TypeOFExam,TypeofQues,Class_id, " +
                                                           " Subject_id,Chapter_id,Topic_id,QuesVerify,Suggestion,UploaderMoNo,UniqueId,DOUpload,LoginId,checkerLoginId,Test_ID,Image,MediumID,Sellanguage,userClass_id,userSubject_id, " +
                                                           " userChapter_id,userTopic_id,userCompitativeExam,TypeofMaterial,TypeofDB,examQwener,flag,createdate,UploadFileName,Class_AdmVerify,Class_AdmSuggest,Class_AdmLogin,PublicationName, " +
                                                           " '" + Convert.ToInt32(Session["TestID"]) + "','" + Login + "'	FROM tblQuestionAccess " +
                                                           " where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ") and SNO NOT IN (" + SNOstring + ")";

                            int status1 = cc.ExecuteNonQuery(Sql);

                            Sql = @" SELECT Top " + chapwiseques1[k1] + " SNO FROM tblQuestionAccess  where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ") and SNO NOT IN (" + SNOstring + ")";
                            dataset = cc.ExecuteDataset(Sql);
                            string s = "";
                            for (int ia = 0; ia < dataset.Tables[0].Rows.Count; ia++)
                                s += "," + dataset.Tables[0].Rows[ia][0].ToString() + "";

                            s = s.Substring(1);

                            if (SNOstring == "0")
                            {
                                string sql = @"insert into QuestionsUsed ([userId],[typeofexam],[class],[subject],[chapter],[questions]) values('" + Login + "','" + sTypeofExam + "','" + sClassid + "','" + sSubjectid + "','" + ChapterID1[i1] + "','" + s + "')";
                                status1 = cc.ExecuteNonQuery(sql);
                            }
                            else
                            {
                                string s1 = SNOstring + "," + s;
                                string sql = @"update QuestionsUsed set [questions]='" + s1 + "' where [userId]='" + Login + "' and [typeofexam]='" + sTypeofExam + "' and [class]='" + sClassid + "' and [subject]='" + sSubjectid + "' and [chapter]='" + ChapterID1[i1] + "' ";
                                status1 = cc.ExecuteNonQuery(sql);
                            }
                        }
                        else
                        {
                            string s2 = "";

                            Sql = " insert into " + "tbl5254" +
                                                           " SELECT Top " + noofquestion + "  SNO,Question_id,Question,QType,Answer1,AType,Answer2,BType,Answer3,CType,Answer4,DType,OptionE,EType,OptionP,PType,OptionQ,QType1,OptionR,RType,OptionS,SType, " +
                                                           " OptionT,TType,Passage,passageType,QuesWithImage,Q1Type,Qhint,hType,Correct_answer,QuestionLevel,MobileNo,SettingId,changeDate,Ischecked,TypeOFExam,TypeofQues,Class_id, " +
                                                           " Subject_id,Chapter_id,Topic_id,QuesVerify,Suggestion,UploaderMoNo,UniqueId,DOUpload,LoginId,checkerLoginId,Test_ID,Image,MediumID,Sellanguage,userClass_id,userSubject_id, " +
                                                           " userChapter_id,userTopic_id,userCompitativeExam,TypeofMaterial,TypeofDB,examQwener,flag,createdate,UploadFileName,Class_AdmVerify,Class_AdmSuggest,Class_AdmLogin,PublicationName, " +
                                                           " '" + Convert.ToInt32(Session["TestID"]) + "','" + Login + "'	FROM tblQuestionAccess " +
                                                           " where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ") and SNO NOT IN (" + SNOstring + ")";
                            int status1 = cc.ExecuteNonQuery(Sql);

                            Sql = @" SELECT Top " + chapwiseques1[k1] + " SNO FROM tblQuestionAccess  where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ") and SNO NOT IN (" + SNOstring + ")";
                            dataset = cc.ExecuteDataset(Sql);
                            string s = "";
                            for (int ia = 0; ia < dataset.Tables[0].Rows.Count; ia++)
                                s += "," + dataset.Tables[0].Rows[ia][0].ToString() + "";
                            s = s.Substring(1);

                            noofquestion = qustion - noofquestion;
                            if (SNOstring == "'0'")
                            {
                                s = SNOstring;
                            }

                            Sql = " insert into " + "tbl5254" +
                                                           " SELECT Top " + noofquestion + "  SNO,Question_id,Question,QType,Answer1,AType,Answer2,BType,Answer3,CType,Answer4,DType,OptionE,EType,OptionP,PType,OptionQ,QType1,OptionR,RType,OptionS,SType, " +
                                                           " OptionT,TType,Passage,passageType,QuesWithImage,Q1Type,Qhint,hType,Correct_answer,QuestionLevel,MobileNo,SettingId,changeDate,Ischecked,TypeOFExam,TypeofQues,Class_id, " +
                                                           " Subject_id,Chapter_id,Topic_id,QuesVerify,Suggestion,UploaderMoNo,UniqueId,DOUpload,LoginId,checkerLoginId,Test_ID,Image,MediumID,Sellanguage,userClass_id,userSubject_id, " +
                                                           " userChapter_id,userTopic_id,userCompitativeExam,TypeofMaterial,TypeofDB,examQwener,flag,createdate,UploadFileName,Class_AdmVerify,Class_AdmSuggest,Class_AdmLogin,PublicationName, " +
                                                           " '" + Convert.ToInt32(Session["TestID"]) + "','" + Login + "'	FROM tblQuestionAccess " +
                                                           " where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ") and SNO NOT IN (" + s + ")";
                            status1 = cc.ExecuteNonQuery(Sql);

                            Sql = @" SELECT Top " + noofquestion + " SNO FROM tblQuestionAccess  where  TypeofExam='" + sTypeofExam + "' and Class_id='" + sClassid + "' and Subject_id='" + sSubjectid + "' and Chapter_id IN(" + ChapterID1[i1] + ") and SNO NOT IN (" + s + ")";
                            dataset = cc.ExecuteDataset(Sql);

                            for (int ia = 0; ia < dataset.Tables[0].Rows.Count; ia++)
                                s2 += "," + dataset.Tables[0].Rows[ia][0].ToString() + "";


                            if (SNOstring == "0")
                            {
                                string sql = @"insert into QuestionsUsed ([userId],[typeofexam],[class],[subject],[chapter],[questions]) values('" + Login + "','" + sTypeofExam + "','" + sClassid + "','" + sSubjectid + "','" + ChapterID1[i1] + "','" + s + "')";
                                status1 = cc.ExecuteNonQuery(sql);
                            }
                            else
                            {
                                string s1 = s2 + "," + s;
                                s1 = s1.Substring(1);

                                string sql = @"update QuestionsUsed set [questions]='" + s1 + "' where [userId]='" + Login + "' and [typeofexam]='" + sTypeofExam + "' and [class]='" + sClassid + "' and [subject]='" + sSubjectid + "' and [chapter]='" + ChapterID1[i1] + "' ";
                                status1 = cc.ExecuteNonQuery(sql);
                            }
                        }

                        k1++; i1++;
                    }

                }
            }
           
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Test Prepared Successfully...!!!')", true);

            this.lblResult.Visible = true;
            this.lblResult.ForeColor = System.Drawing.Color.Green;
            this.lblResult.Font.Bold = true;
            this.lblResult.Text = "Test Prepared Successfully...!!!";
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Test Not Prepared...!!!')", true);

            this.lblResult.Visible = true;
            this.lblResult.ForeColor = System.Drawing.Color.Green;
            this.lblResult.Font.Bold = true;
            this.lblResult.Text = "Test Not Prepared...!!! Check Settings";
        }
    }
}
