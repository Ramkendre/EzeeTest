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

public partial class TestDefinition : System.Web.UI.Page
{
    int status;
    string Id, abc, Sql;
    DataSet ds = new DataSet();
    CommonCode cc = new CommonCode();
    ExamnameBLL ebal = new ExamnameBLL();

    TestDefinationBLL BllTestd = new TestDefinationBLL();
    CommanDDLbindclass Cds = new CommanDDLbindclass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindgridbyClassIDTypeExam();

            Cds.loadGroupofExam(ddlGroupofExam);
            //ddlGroupofExam.DataSource = ds.Tables[0];
            //ddlGroupofExam.DataTextField = "Name";
            //ddlGroupofExam.DataValueField = "ItemValueId";
            //ddlGroupofExam.DataBind();
        }
    }

    public string TestExpire(string Id)
    {
        try
        {
            // Below code donot deleted Commented by JITENDRA PATIL

            //string tblName = Convert.ToString(Session["CompanyId"]) + "" + Convert.ToString(Id);  // for table create

            //Sql = "SELECT create_date FROM sys.Tables where name='tbl" + tblName + "' ";
            //ds = cc.ExecuteDataset(Sql);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    DateTime dt2 = new DateTime();
            //    dt2 = Convert.ToDateTime(ds.Tables[0].Rows[0]["create_date"]);
            //    DateTime dt1 = new DateTime();

            //    dt1 = Convert.ToDateTime(System.DateTime.Now);

            //    TimeSpan ts3 = dt1 - dt2;
            //    int d = ts3.Days;


            //    d = 60 - d;

            //    day = Convert.ToString(d);
            //}
        }
        catch
        {
        }
        return day;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Id = Convert.ToString(lblId.Text.ToString());

        if (Id == "" || Id == null)
        {
            AddNewInsert();
        }
        else
        {
            Updatedefination(Id);
            btnSave.Text = "Save";
        }
    }


    private void AddNewInsert()
    {
        try
        {
            if (txtExamDate.Text == "" || txtExamduration.Text == "" || txtLevel1.Text == "" || txtLevel2.Text == "" || txtLevel3.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Enter All Record";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Enter All Record')", true);
            }
            else
            {
                if (txtmarkPassing.Text == "")
                {
                    lblError.Visible = true;
                    lblError.Text = "please Enter Mark for Passing";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select Mark for Passing')", true);
                }
                else if (rdoRetake.SelectedIndex != 1 && rdoRetake.SelectedIndex != 0)
                {
                    lblError.Visible = true;
                    lblError.Text = "select Option of Retake";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('select Option of Retake')", true);
                }
                else if (rdoBreakAllow.SelectedIndex != 1 && rdoBreakAllow.SelectedIndex != 0)
                {
                    lblError.Visible = true;
                    lblError.Text = "select Option of Break";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('select Option of Break')", true);
                }
                else
                {
                    string SubjectID = "", SubjectName = "";
                    for (int c = 0; c < chkSubject.Items.Count; c++)
                    {
                        if (chkSubject.Items[c].Selected == true)
                        {
                            SubjectID = SubjectID + "," + chkSubject.Items[c].Value;
                            SubjectName = SubjectName + "," + chkSubject.Items[c].Text;
                        }
                    }
                    if (SubjectID.Length > 1)
                    {
                        SubjectID = SubjectID.Substring(1);
                        lblSubjectID.Text = SubjectID;
                    }
                    if (SubjectName.Length > 1)
                    {
                        SubjectName = SubjectName.Substring(1);
                    }
                    string Sql = "Select Test_ID from tblTestDefinition where  Subject_id='" + lblSubjectID.Text + "' and Exam_name='" + txtTestName.Text + "' ";
                    string Id1 = Convert.ToString(cc.ExecuteScalar(Sql));
                    if (!(Id1 == null || Id1 == ""))
                    {
                        lblError.Visible = true;
                        lblError.Text = "This Exam Name is already exist";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Exam Name is already exist')", true);
                    }
                    else
                    {
                        BllTestd.TestName = txtTestName.Text;
                        BllTestd.Exandate1 = Convert.ToString(cc.DTInsert_Local(txtExamDate.Text));
                        BllTestd.Duration = txtExamduration.Text;

                        BllTestd.D1 = Convert.ToInt32(txtLevel1.Text);
                        BllTestd.D2 = Convert.ToInt32(txtLevel2.Text);
                        BllTestd.D3 = Convert.ToInt32(txtLevel3.Text);
                        BllTestd.LoginId1 = Convert.ToString(Session["LoginId"]);

                        BllTestd.MarkCorrA = Convert.ToString(txtmarkCorrect.Text);
                        BllTestd.MarkPass = Convert.ToString(txtmarkPassing.Text);
                        BllTestd.ReverseNavig = Convert.ToString(rdoReverseNavigation.SelectedItem.Text);
                        BllTestd.NegativeMark = Convert.ToString(rdoNegativeMark.SelectedItem.Text);
                        if (rdoNegativeMark.SelectedItem.Text == "Yes")
                        {
                            BllTestd.MarkforNegative = Convert.ToString(txtSelectMarkforNege.Text);
                        }
                        BllTestd.MediumID = Convert.ToString(ddlMedium.SelectedItem.Text);

                        BllTestd.TypeOfExam = Convert.ToInt32(ddlTypeofExam.SelectedValue);

                        BllTestd.Class_id1 = Convert.ToInt32(ddlAddClass.SelectedValue);


                        BllTestd.Subject_id1 = Convert.ToString(lblSubjectID.Text);
                        BllTestd.SubjectName1 = Convert.ToString(SubjectName);

                        BllTestd.Retake = Convert.ToString(rdoRetake.SelectedItem.Text);
                        BllTestd.BreakAllow = Convert.ToString(rdoBreakAllow.SelectedItem.Text);
                        BllTestd.TypeofMaterial1 = Convert.ToString(rdoTypeofMaterial.SelectedItem.Text);
                        BllTestd.GroupOfQuestion1 = Convert.ToString(rdoGroupOFQues.SelectedValue);
                        BllTestd.Testtype = Convert.ToString(ddlTestType.SelectedValue);
                        BllTestd.IndexNo1 = Convert.ToInt32(txtIndexNo.Text);
                        BllTestd.GroupofExam = Convert.ToInt32(ddlGroupofExam.SelectedValue);

                        status = BllTestd._insertTestDefi(BllTestd);

                        if (status == 1)
                        {

                            bindgridbyClassIDTypeExam();
                            clear();

                            lblError.Text = "TestDefination Insert Successfully";
                            lblError.Visible = true;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('TestDefination Insert successfully')", true);
                        }
                        else
                        {
                            bindgridbyClassIDTypeExam();
                            lblError.Text = "TestDefination not Insert Successfully";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('TestDefination not Insert successfully')", true);
                        }
                    }
                }
            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('ex.Exam Name not added')", true);
        }
    }

    private void Updatedefination(string Id)
    {
        try
        {
            if (txtExamDate.Text == "" || txtExamduration.Text == "" || txtLevel1.Text == "" || txtLevel2.Text == "" || txtLevel3.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Enter All Record";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Enter All Record')", true);
            }
            else
            {

                if (txtmarkPassing.Text == "")
                {
                    lblError.Visible = true;
                    lblError.Text = "Select Mark for Passing";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select Mark for Passing')", true);

                }
                else if (rdoRetake.SelectedIndex != 1 && rdoRetake.SelectedIndex != 0)
                {
                    lblError.Visible = true;
                    lblError.Text = "select Option of Retake";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('select Option of Retake')", true);

                }
                else if (rdoBreakAllow.SelectedIndex != 1 && rdoBreakAllow.SelectedIndex != 0)
                {
                    lblError.Visible = true;
                    lblError.Text = "select Option of Break";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('select Option of Break')", true);

                }
                else
                {
                    string SubjectID = "", SubjectName = ""; ;
                    for (int c = 0; c < chkSubject.Items.Count; c++)
                    {
                        if (chkSubject.Items[c].Selected == true)
                        {
                            SubjectID = SubjectID + "," + chkSubject.Items[c].Value;
                            SubjectName = SubjectName + "," + chkSubject.Items[c].Text;
                        }
                    }
                    if (SubjectID.Length > 1)
                    {
                        SubjectID = SubjectID.Substring(1);
                        lblSubjectID.Text = SubjectID;
                    }
                    if (SubjectName.Length > 1)
                    {
                        SubjectName = SubjectName.Substring(1);
                    }

                    //string Sql = "Select Test_ID from tblTestDefinition where   Subject_id='" + chkSubject.SelectedValue + "' and Exam_name='" + txtTestName + "' ";
                    //string Id1 = Convert.ToString(cc.ExecuteScalar(Sql));
                    //if (!(Id1 == null || Id1 == ""))
                    //{
                    //    lblError.Visible = true;
                    //    lblError.Text = "This Exam Name is already exist";
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Exam Name is already exist')", true);
                    //}
                    //else
                    //{

                    BllTestd.Test_ID1 = Convert.ToInt32(Id);
                    BllTestd.TestName = txtTestName.Text;
                    BllTestd.Exandate1 = Convert.ToString(cc.DTInsert_Local(txtExamDate.Text));
                    BllTestd.Duration = txtExamduration.Text;
                    BllTestd.D1 = Convert.ToInt32(txtLevel1.Text);
                    BllTestd.D2 = Convert.ToInt32(txtLevel2.Text);
                    BllTestd.D3 = Convert.ToInt32(txtLevel3.Text);
                    BllTestd.LoginId1 = Convert.ToString(Session["LoginId"]);
                    BllTestd.MarkCorrA = Convert.ToString(txtmarkCorrect.Text);
                    BllTestd.MarkPass = Convert.ToString(txtmarkPassing.Text);
                    BllTestd.ReverseNavig = Convert.ToString(rdoReverseNavigation.SelectedItem.Text);
                    BllTestd.NegativeMark = Convert.ToString(rdoNegativeMark.SelectedItem.Text);
                    if (rdoNegativeMark.SelectedItem.Text == "Yes")
                    {
                        BllTestd.MarkforNegative = Convert.ToString(txtSelectMarkforNege.Text);
                    }
                    BllTestd.MediumID = Convert.ToString(ddlMedium.SelectedItem.Text);
                    BllTestd.TypeOfExam = Convert.ToInt32(ddlTypeofExam.SelectedValue);

                    BllTestd.Class_id1 = Convert.ToInt32(ddlAddClass.SelectedValue);

                    BllTestd.Subject_id1 = Convert.ToString(lblSubjectID.Text);
                    BllTestd.SubjectName1 = Convert.ToString(SubjectName);

                    BllTestd.Retake = Convert.ToString(rdoRetake.SelectedItem.Text);
                    BllTestd.BreakAllow = Convert.ToString(rdoBreakAllow.SelectedItem.Text);
                    BllTestd.TypeofMaterial1 = Convert.ToString(rdoTypeofMaterial.SelectedItem.Text);
                    BllTestd.GroupOfQuestion1 = Convert.ToString(rdoGroupOFQues.SelectedValue);
                    BllTestd.Testtype = Convert.ToString(ddlTestType.SelectedValue);
                    BllTestd.IndexNo1 = Convert.ToInt32(txtIndexNo.Text);
                    BllTestd.GroupofExam = Convert.ToInt32(ddlGroupofExam.SelectedValue);

                    status = BllTestd._updatetestdef(BllTestd);

                    if (status == 1)
                    {
                        bindgridbyClassIDTypeExam();
                        clear();

                        lblError.Text = "TestDefination updated Successfully";
                        lblError.Visible = true;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('TestDefination updated successfully')", true);
                    }
                    else
                    {

                        bindgridbyClassIDTypeExam();
                        lblError.Text = "TestDefination not  updated Successfully";
                        lblError.Visible = true;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('TestDefination not  updated successfully')", true);
                    }
                    // }
                }
            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('TestDefination not Updated')", true);
        }
    }

    public void clear()
    {
        lblId.Text = "";
        btnSave.Text = "Save";
        txtExamduration.Text = "";
        txtExamDate.Text = "";
        txtLevel1.Text = "";
        txtLevel2.Text = "";
        txtLevel3.Text = "";
        txtTestName.Text = "";

        lblError.Visible = true;
        rdoRetake.ClearSelection();
        rdoBreakAllow.ClearSelection();
        rdoReverseNavigation.ClearSelection();
        rdoNegativeMark.ClearSelection();
        txtmarkCorrect.Text = "";
        txtmarkPassing.Text = "";
        txtSelectMarkforNege.Text = "";
        rdoTypeofMaterial.ClearSelection();
        rdoGroupOFQues.ClearSelection();
        chkSubject.ClearSelection();
        ddlAddClass.SelectedValue = "1";
        ddlTypeofExam.SelectedValue = "1";
    }

    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;

        if (Convert.ToString(e.CommandName) == "Assign")
        {
            Sql = "select SNO from tblDefaultTest where TestID='" + Id + "' ";
            string defId = cc.ExecuteScalar(Sql);

            if (defId == "")
            {
                Response.Redirect("ClassStudentAssign.aspx?Id=" + Id);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You cann't Assign Test,Its already Assign to all Students')", true);
            }
        }

        if (Convert.ToString(e.CommandName) == "Modify")
        {
            chkSubject.ClearSelection();
            btnSave.Text = "Update";
            BllTestd.Test_ID1 = Convert.ToInt32(Id);
            DataSet ds = BllTestd._selecttestdef(BllTestd);

            try
            {
                string testLoginID = Convert.ToString(ds.Tables[0].Rows[0]["LoginId"]);
                string LoginId = Convert.ToString(Session["LoginId"]);

                //if (testLoginID == "" && LoginId != "7588419504") //7588419504 this no is gayatri Mam Class Admin role. she can change modify test only
                //{

                //if (LoginId == "9999999999")
                //{
                //    clear();
                //    lblError.Text = "You can not Modify this Test !";
                //    lblError.Visible = true;
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You can not Modify this default Test !')", true);
                //}
                //else
                //{
                //txtExamDate.Text = cc.DTGet_LocalNew(Convert.ToString(ds.Tables[0].Rows[0]["Exam_date"]));
                try
                {
                    //THE BELOW CODE OF DATE IS RUNNING ON SERVER NOT LOCAL MACHINE SO BE CAREFULL WHILE UPLOAD OR CHANGE
                    string ddate = Convert.ToString(ds.Tables[0].Rows[0]["Exam_date"]);
                    if (ddate.Length > 20)
                    {
                        ddate = ddate.Substring(0, 10);
                    }
                    ddate = ddate.Trim();
                    string[] tmpDate = ddate.Split('/');
                    ddate = tmpDate[1].ToString() + "/" + tmpDate[0].ToString() + "/" + tmpDate[2].ToString();

                    txtExamDate.Text = ddate;//Convert.ToString(ds.Tables[0].Rows[0]["Exam_date"]);
                }
                catch { }
                txtTestName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Exam_name"]);
                txtExamduration.Text = Convert.ToString(ds.Tables[0].Rows[0]["Exam_Duration"]);
                txtLevel1.Text = Convert.ToString(ds.Tables[0].Rows[0]["DLevel1"]);
                txtLevel2.Text = Convert.ToString(ds.Tables[0].Rows[0]["DLevel2"]);
                txtLevel3.Text = Convert.ToString(ds.Tables[0].Rows[0]["DLevel3"]);
                txtIndexNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["IndexNo"]);
                ddlGroupofExam.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["GroupofExamId"]);
                Cds.BindTypeofExamOnGroup(ddlTypeofExam,ddlGroupofExam.SelectedValue);
                ddlTypeofExam.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TypeOFExam"]);
                Cds.BindClassOrSubject(ddlAddClass,ddlTypeofExam.SelectedValue,chkSubject);
                ddlAddClass.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Class_id"]);
                Cds.BindAddSubjectOnClassId(chkSubject, ddlAddClass.SelectedValue, ddlTypeofExam);

                string Subject_id = Convert.ToString(ds.Tables[0].Rows[0]["Subject_id"]);
                string[] subjlist2 = Subject_id.Split(',');
                for (int c = 0; c < chkSubject.Items.Count; c++)
                {
                    if (Subject_id.Contains(chkSubject.Items[c].Value.ToString()))
                    {
                        chkSubject.Items[c].Selected = true;
                    }
                }

                txtmarkCorrect.Text = Convert.ToString(ds.Tables[0].Rows[0]["MarkCorrA"]);
                string a = Convert.ToString(ds.Tables[0].Rows[0]["ReverseNavig"]);
                if (a == "Yes")
                {
                    rdoReverseNavigation.SelectedIndex = 0;
                }
                else
                {
                    rdoReverseNavigation.SelectedIndex = 1;
                }
                string b = Convert.ToString(ds.Tables[0].Rows[0]["NegativeMark"]);
                if (b == "Yes")
                {
                    rdoNegativeMark.SelectedIndex = 0;
                }
                else
                {
                    rdoNegativeMark.SelectedIndex = 1;
                    txtSelectMarkforNege.Enabled = false;
                }
                if (b == "Yes")
                {
                    txtSelectMarkforNege.Enabled = true;
                    txtSelectMarkforNege.Text = Convert.ToString(ds.Tables[0].Rows[0]["MarkforNegative"]);
                }
                ddlMedium.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["MediumID"]);

                string r = Convert.ToString(ds.Tables[0].Rows[0]["TypeofMaterial"]);
                if (r == "Class")
                {
                    rdoTypeofMaterial.SelectedIndex = 0;
                    Label11.Visible = true;
                    Label10.Visible = false;
                    RequiredFieldValidator4.Enabled = true;
                    RequiredFieldValidator1.Enabled = false;
                }
                else
                {
                    rdoTypeofMaterial.SelectedIndex = 1;
                    Label10.Visible = true;
                    Label11.Visible = false;
                    RequiredFieldValidator4.Enabled = false;
                    RequiredFieldValidator1.Enabled = true;
                }

                rdoGroupOFQues.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["GroupOfQuestion"]);

                if (rdoGroupOFQues.SelectedValue == "1")
                {
                    lblMarkcorrAns.Text = "Total Max Marks : ";
                }
                else
                {
                    lblMarkcorrAns.Text = "Marks For Correct Ans :";
                }

                string Retake = Convert.ToString(ds.Tables[0].Rows[0]["Retake"]);
                if (Retake == "Yes")
                {
                    rdoRetake.SelectedIndex = 0;
                }
                else
                {
                    rdoRetake.SelectedIndex = 1;
                }
                string BreakAllow = Convert.ToString(ds.Tables[0].Rows[0]["BreakAllow"]);
                if (BreakAllow == "Yes")
                {
                    rdoBreakAllow.SelectedIndex = 0;
                }
                else
                {
                    rdoBreakAllow.SelectedIndex = 1;
                }

                txtmarkPassing.Text = Convert.ToString(ds.Tables[0].Rows[0]["MarkPass"]);
                ddlTestType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TypeofTest"]);
                // }
            }
            catch
            {

            }
        }

        if (Convert.ToString(e.CommandName) == "Delete")
        {
            try
            {
                BllTestd.Test_ID1 = Convert.ToInt32(Id);
                Sql = "select LoginId from tblTestDefinition where Test_ID =" + BllTestd.Test_ID1 + "";
                string testLoginID = cc.ExecuteScalar(Sql);
                string LoginId = Convert.ToString(Session["LoginId"]);

                //if (testLoginID == "" && LoginId != "7588419504") //7588419504 this no is gayatri Mam Class Admin role. she can change modify test only
                //{
                //    clear();
                //    lblError.Text = "You can not Delete this Test !";
                //    lblError.Visible = true;
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You can not Delete this Test !')", true);
                //}
                //else
                //{
                //string s11 = Convert.ToString(Session["CompanyId"]) + "" + Convert.ToString(Id);  //// for table create
                //try
                //{
                //    Sql = "drop table tbl" + s11 + "";
                //    int Status2 = cc.ExecuteNonQuery(Sql);
                //    Sql = "drop view tbll" + s11 + "";
                //    Status2 = cc.ExecuteNonQuery(Sql);
                //}
                //catch (Exception ex)
                //{
                //    Response.Write("<h5>" + ex.Message);
                //}

                if (LoginId == "9999999999")
                {

                }
                else
                {
                    BllTestd.Test_ID1 = Convert.ToInt32(Id);
                    status = BllTestd._deletetestdef(BllTestd);

                    if (status == 1)
                    {
                        clear();
                        bindgridbyClassIDTypeExam();

                        lblError.Text = "Test Deleted Successfully";
                        lblError.Visible = true;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Defination Record Deleted successfully')", true);
                    }
                    else
                    {
                        lblError.Text = "Test not  Deleted Successfully";
                        lblError.Visible = true;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Defination not Record Deleted')", true);
                    }
                    // }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This record reference use Other Location')", true);
                lblError.Text = "TestDefination not Deleted Successfully";
            }
        }

        //if (Convert.ToString(e.CommandName) == "ModifySeqNo")
        //{
        //    try
        //    {
        //        BllTestd.Test_ID1 = Convert.ToInt32(Id);
        //        Sql = "select LoginId from tblTestDefinition where Test_ID =" + BllTestd.Test_ID1 + "";
        //        string testLoginID = cc.ExecuteScalar(Sql);
        //        string LoginId = Convert.ToString(Session["LoginId"]);

        //        if (testLoginID == "" && LoginId != "7588419504") //7588419504 this no is gayatri Mam Class Admin role. she can change modify test only
        //        {
        //            clear();
        //            lblError.Text = "You can not Modify this Test !";
        //            lblError.Visible = true;
        //            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You can not Modify this Test !')", true);
        //        }
        //        else
        //        {
        //            ViewState["Testid"] = BllTestd.Test_ID1;
        //            Sql = "Select IndexNo from tblTestDefinition where Test_ID =" + BllTestd.Test_ID1 + "";

        //            ds = cc.ExecuteDataset(Sql);

        //            txtIndexNo.Text = Convert.ToString(ds.Tables[0].Rows[0][0]);

        //            btnUpdateSeqNo.Visible = true;
        //        }
        //    }
        //    catch
        //    {

        //    }
        // }
    }

    protected void btnUpdateSeqNo_Click(object sender, EventArgs e)
    {
        Sql = "Update tblTestDefinition Set IndexNo=" + txtIndexNo.Text + "Where Test_ID = " + ViewState["Testid"] + "";
        int st1 = cc.ExecuteNonQuery(Sql);

        if (st1 > 0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sequence Number Added Successfully !!!')", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sequence Number Not Added !!!')", true);
        }

        btnUpdateSeqNo.Visible = false;
        txtIndexNo.Text = string.Empty;
    }

    protected void gvState_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvState.PageIndex = e.NewPageIndex;
        bindgridbyClassIDTypeExam();
    }


    protected void btncancel_Click(object sender, EventArgs e)
    {
        clear();
    }

    public void bindgridbyClassIDTypeExam()
    {
        BllTestd.LoginId1 = Convert.ToString(Session["LoginId"]);
        DataSet ds = BllTestd.GetTestByGroupofQues(BllTestd);

        //DON NOT DELETE THE BELOW CODE FOR EXPIRY OF TEST

        //DataColumn column = new DataColumn();
        //column.ColumnName = "ExpireDate";
        //column.DataType = System.Type.GetType("System.String");
        //column.AutoIncrement = false;
        //column.ReadOnly = false;
        //ds.Tables[0].Columns.Add(new DataColumn("column"));

        if (ds.Tables[0].Rows.Count > 0)
        {
            gvState.DataSource = ds.Tables[0];
            gvState.DataBind();
            gvState.Visible = true;
        }
    }

    protected void rdoNegativeMark_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoNegativeMark.SelectedItem.Text == "No")
        {
            txtSelectMarkforNege.Text = "";
            txtSelectMarkforNege.Enabled = false;
        }
        else
        {
            txtSelectMarkforNege.Enabled = true;
        }
    }

    protected void ddlMedium_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }

    protected void rdoTypeofMaterial_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoTypeofMaterial.SelectedIndex == 0)
        {
            Label11.Visible = true;
            Label10.Visible = false;
            RequiredFieldValidator4.Enabled = true;
            RequiredFieldValidator1.Enabled = false;
        }
        else
        {
            Label11.Visible = false;
            Label10.Visible = true;
            RequiredFieldValidator4.Enabled = false;
            RequiredFieldValidator1.Enabled = true;
        }
    }

    string day;
    protected void rdoGroupOFQues_SelectedIndexChanged(object sender, EventArgs e)
    {
        BllTestd.LoginId1 = Convert.ToString(Session["LoginId"]);
        BllTestd.GroupOfQuestion1 = Convert.ToString(rdoGroupOFQues.SelectedValue);
        DataSet ds = BllTestd.GetTestByGroupofQues(BllTestd);

        DataColumn column = new DataColumn();
        column.ColumnName = "ExpireDate";
        column.DataType = System.Type.GetType("System.String");
        column.AutoIncrement = false;
        column.ReadOnly = false;
        ds.Tables[0].Columns.Add(new DataColumn("column"));

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string testid = Convert.ToString(ds.Tables[0].Rows[i]["Id"]);
                string LoginIddal = Convert.ToString(ds.Tables[0].Rows[i]["LoginId"]); //LoginId

                if (LoginIddal != "")//default test //These lines are commented by me do not delete any way
                {
                    //string tblName = Convert.ToString(Session["CompanyId"]) + "" + Convert.ToString(testid);  //// for table create
                    //string day = TestExpire(testid); // get day from test expire on testid
                    //int dayint = Convert.ToInt32(day);
                    //if (day != null)
                    //{
                    //    day = day + " Days left";
                    //    ds.Tables[0].Rows[i]["column"] = Convert.ToString(day);
                    //    if (dayint <= 0)
                    //    {
                    //        try
                    //        {
                    //            Sql = "drop table tbl" + tblName + "";
                    //            int Status2 = cc.ExecuteNonQuery(Sql);
                    //            Sql = "drop view tbll" + tblName + "";
                    //            Status2 = cc.ExecuteNonQuery(Sql);
                    //            Sql = "Delete from tblTestDefinition where Test_ID=" + testid + "";
                    //            Status2 = cc.ExecuteNonQuery(Sql);
                    //        }
                    //        catch(Exception ex)
                    //        {
                    //            //Response.Write("<h4>" + ex.Message);
                    //        }
                    //    }

                    //}
                }

            }

            gvState.DataSource = ds.Tables[0];
            gvState.DataBind();
            gvState.Visible = true;
        }
        else
        {
            gvState.DataSource = null;
            gvState.DataBind();
        }

        if (rdoGroupOFQues.SelectedItem.Text == "Theory Question")
        {
            lblMarkcorrAns.Text = "Total Max Marks : ";
        }
        else
        {
            lblMarkcorrAns.Text = "Marks For Correct Ans :";
        }

    }
    protected void btnback_Click(object sender, EventArgs e)
    {

    }
    protected void gvState_PageIndexChanged(object sender, EventArgs e)
    {
    }
    protected void gvState_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    protected void gvState_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
    }
    protected void gvState_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //This Commented by jitu on 03.02.2015 this imp for test expiry 

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    string[] expiredaySplit = Convert.ToString(e.Row.Cells[12].Text).Split(' '); ;

        //    if (expiredaySplit[0] != "&nbsp;")
        //    {
        //        if (Convert.ToInt32(expiredaySplit[0]) < 10)
        //        {
        //            e.Row.Cells[12].BackColor = System.Drawing.Color.Red;
        //            e.Row.Cells[12].ForeColor = System.Drawing.Color.White;
        //            e.Row.Cells[12].Font.Bold = true;
        //        }
        //    }
        //}
    }


    protected void gvState_Sorting(object sender, GridViewSortEventArgs e)
    {

    }

    //#region ddlGropuofExam

    //protected void binddropdown212()
    //{
    //    //DataSet dataSet = new DataSet();
    //    //SqlCommand sqlCommand = new SqlCommand();
    //    //SqlDataAdapter adaper = new SqlDataAdapter();

    //    //sqlCommand.CommandText = "uspBindAllDropDownLists";
    //    //sqlCommand.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    //    //sqlCommand.CommandType = CommandType.StoredProcedure;

    //    //SqlParameter[] parameter = new SqlParameter[] 
    //    //{
    //    //    new SqlParameter("@groupofExamId", "135")
    //    //};

    //    //sqlCommand.Parameters.AddRange(parameter);

    //    //adaper.SelectCommand = sqlCommand;
    //    //adaper.Fill(dataSet);

    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 212 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = ds.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //protected void binddropdown213()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 213 ";
    //    DataSet DS = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = DS.Tables[0];
    //    ddlTypeofExam.DataTextField = "Name";
    //    ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //    ddlTypeofExam.DataBind();
    //}
    //protected void binddropdown214()
    //{
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 214 ";
    //    DataSet Ds = cc.ExecuteDataset(Sql);
    //    ddlTypeofExam.DataSource = Ds.Tables[0];
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
    //public void BindTypeofExamOnGroup(string groupExId)
    //{

    //    if (groupExId == Convert.ToString(135))
    //    {
    //        binddropdown212();
    //    }
    //    else if (groupExId == Convert.ToString(136))
    //    {
    //        binddropdown213();
    //    }
    //    else if (groupExId == Convert.ToString(137))
    //    {
    //        binddropdown214();
    //    }
    //    else if (groupExId == Convert.ToString(140)) //Scholarship
    //    {
    //        Sql = " SELECT Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=210  ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        ddlTypeofExam.DataSource = ds.Tables[0];
    //        ddlTypeofExam.DataTextField = "Name";
    //        ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //        ddlTypeofExam.DataBind();
    //    }
    //    else if (groupExId == Convert.ToString(141))
    //    {
    //        Sql = " SELECT Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=207  ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        ddlTypeofExam.DataSource = ds.Tables[0];
    //        ddlTypeofExam.DataTextField = "Name";
    //        ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //        ddlTypeofExam.DataBind();
    //    }
    //    else if (groupExId == Convert.ToString(142))
    //    {
    //        Sql = " SELECT Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=206  ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        ddlTypeofExam.DataSource = ds.Tables[0];
    //        ddlTypeofExam.DataTextField = "Name";
    //        ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //        ddlTypeofExam.DataBind();
    //    }
    //    else if (groupExId == Convert.ToString(143))
    //    {
    //        Sql = " SELECT Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=203  ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        ddlTypeofExam.DataSource = ds.Tables[0];
    //        ddlTypeofExam.DataTextField = "Name";
    //        ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //        ddlTypeofExam.DataBind();
    //    }
    //    else if (groupExId == Convert.ToString(144))
    //    {
    //        Sql = " SELECT Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=205  ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        ddlTypeofExam.DataSource = ds.Tables[0];
    //        ddlTypeofExam.DataTextField = "Name";
    //        ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //        ddlTypeofExam.DataBind();
    //    }

    //    else if (groupExId == Convert.ToString(177))
    //    {
    //        Sql = " SELECT Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=1796  ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        ddlTypeofExam.DataSource = ds.Tables[0];
    //        ddlTypeofExam.DataTextField = "Name";
    //        ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //        ddlTypeofExam.DataBind();
    //    }
    //    else if (groupExId == Convert.ToString(178))
    //    {
    //        Sql = " SELECT Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=1806  ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        ddlTypeofExam.DataSource = ds.Tables[0];
    //        ddlTypeofExam.DataTextField = "Name";
    //        ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //        ddlTypeofExam.DataBind();
    //    }
    //    else if (groupExId == Convert.ToString(183))
    //    {
    //        Sql = " SELECT Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=1846  ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        ddlTypeofExam.DataSource = ds.Tables[0];
    //        ddlTypeofExam.DataTextField = "Name";
    //        ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //        ddlTypeofExam.DataBind();

    //    }
    //    else if (groupExId == Convert.ToString(231))
    //    {
    //        Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 2310  ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        ddlTypeofExam.DataSource = ds.Tables[0];
    //        ddlTypeofExam.DataTextField = "Name";
    //        ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //        ddlTypeofExam.DataBind();
    //    }
    //    else if (groupExId == Convert.ToString(232))
    //    {
    //        Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 2310  ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        ddlTypeofExam.DataSource = ds.Tables[0];
    //        ddlTypeofExam.DataTextField = "Name";
    //        ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //        ddlTypeofExam.DataBind();
    //    }
    //    else if (groupExId == Convert.ToString(233))
    //    {
    //        Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 2310  ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        ddlTypeofExam.DataSource = ds.Tables[0];
    //        ddlTypeofExam.DataTextField = "Name";
    //        ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //        ddlTypeofExam.DataBind();
    //    }
    //    else if (groupExId == Convert.ToString(257))
    //    {
    //        string loginid = Session["LoginId"].ToString();
    //        string Sql = "Select Niitaps From Login Where [LoginId]='" + loginid + "'";
    //        string ntps = Convert.ToString(cc.ExecuteScalar(Sql));
    //        if (ntps == "" || ntps == null)
    //        {

    //        }
    //        else if (ntps == "1")
    //        {
    //            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 257";
    //            DataSet ds = cc.ExecuteDataset(Sql);

    //            ddlTypeofExam.DataSource = ds.Tables[0];
    //            ddlTypeofExam.DataTextField = "Name";
    //            ddlTypeofExam.DataValueField = "ItemValueIdNew";
    //            ddlTypeofExam.DataBind();
    //        }
    //        else
    //        {
    //           ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Not Permission to create test!!!')", true);
    //        }
    //    }
    //    else if (groupExId == Convert.ToString(273))
    //    {
    //        binddropdown273();
    //    }
    //    else if (groupExId == Convert.ToString(274))
    //    {
    //        binddropdown274();
    //    }
    //    else if (groupExId == Convert.ToString(275))
    //    {
    //        binddropdown275();
    //    }
    //    else if (groupExId == Convert.ToString(276))
    //    {
    //        binddropdown276();
    //    }
    //    else if (groupExId == Convert.ToString(277))
    //    {
    //        binddropdown277();
    //    }
    //    else if (groupExId == Convert.ToString(278))
    //    {
    //        binddropdown278();
    //    }
    //    else if (groupExId == Convert.ToString(445))
    //    {
    //        binddropdown279();
    //    }
    //}

    protected void ddlGroupofExam_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string groupExamid = ddlGroupofExam.SelectedValue;
        Cds.BindTypeofExamOnGroup(ddlTypeofExam,groupExamid);
    }

    #region ddlTypeofExam

    //protected void binddropdown202()
    //{
    //    ddlAddClass.Enabled = true;
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 202 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlAddClass.DataSource = ds.Tables[0];
    //    ddlAddClass.DataTextField = "Name";
    //    ddlAddClass.DataValueField = "ItemValueIdNew";
    //    ddlAddClass.DataBind();
    //}
    //protected void binddropdown211()
    //{
    //    ddlAddClass.Enabled = true;
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 211 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlAddClass.DataSource = ds.Tables[0];
    //    ddlAddClass.DataTextField = "Name";
    //    ddlAddClass.DataValueField = "ItemValueIdNew";
    //    ddlAddClass.DataBind();
    //}
    //protected void binddropdown2()
    //{
    //    Sql = " SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId = 2";
    //    ds = cc.ExecuteDataset(Sql);
    //    chkSubject.DataSource = ds.Tables[0];
    //    chkSubject.DataTextField = "Name";
    //    chkSubject.DataValueField = "ItemValueId";
    //    chkSubject.DataBind();
    //    ddlAddClass.SelectedValue = "1";
    //    ddlAddClass.Enabled = false;
    //}

    //protected void binddropdown201()
    //{
    //    ddlAddClass.Enabled = true;
    //    Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 201 ";
    //    DataSet ds = cc.ExecuteDataset(Sql);

    //    ddlAddClass.DataSource = ds.Tables[0];
    //    ddlAddClass.DataTextField = "Name";
    //    ddlAddClass.DataValueField = "ItemValueIdNew";
    //    ddlAddClass.DataBind();
    //}

    //public void BindClassOrSubject(string addClassOrSubject)
    //{
    //    if (addClassOrSubject == Convert.ToString(88))
    //    {
    //        binddropdown201();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(271))
    //    {
    //        binddropdown201();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(272))
    //    {
    //        binddropdown201();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(98))
    //    {
    //        binddropdown202();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(99))
    //    {
    //        binddropdown202();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(100))
    //    {
    //        binddropdown202();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(96))
    //    {
    //        binddropdown211();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(101))
    //    {
    //        binddropdown211();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(102))
    //    {
    //        binddropdown211();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(89))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(94))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(95))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(130))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(110))
    //    {
    //        Sql = " SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId = 204 OR ItemId = 2 ORDER BY ItemValueId ASC";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        chkSubject.DataSource = ds.Tables[0];
    //        chkSubject.DataTextField = "Name";
    //        chkSubject.DataValueField = "ItemValueId";
    //        chkSubject.DataBind();
    //        ddlAddClass.SelectedValue = "1";
    //        ddlAddClass.Enabled = false;
    //    }

    //    else if (addClassOrSubject == Convert.ToString(103))
    //    {
    //        binddropdown2();
    //    }

    //    else if (addClassOrSubject == Convert.ToString(165))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(179))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(180))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(176))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(184))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(185))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(191))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(193))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(200) || addClassOrSubject == Convert.ToString(201) || addClassOrSubject == Convert.ToString(202) || addClassOrSubject == Convert.ToString(203) || addClassOrSubject == Convert.ToString(204) || addClassOrSubject == Convert.ToString(205) || addClassOrSubject == Convert.ToString(206) || addClassOrSubject == Convert.ToString(207))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(217))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(224))
    //    {
    //        ddlAddClass.Enabled = true;
    //        Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 201 ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        ddlAddClass.DataSource = ds.Tables[0];
    //        ddlAddClass.DataTextField = "Name";
    //        ddlAddClass.DataValueField = "ItemValueIdNew";
    //        ddlAddClass.DataBind();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(227))
    //    {
    //        binddropdown2();
    //    }

    //    else if (addClassOrSubject == Convert.ToString(228))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(229))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(230))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(234))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(235))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(236))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(237))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(248))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(254))
    //    {
    //        binddropdown2();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(258) || addClassOrSubject == Convert.ToString(259) || addClassOrSubject == Convert.ToString(260) || addClassOrSubject == Convert.ToString(261) || addClassOrSubject == Convert.ToString(262) || addClassOrSubject == Convert.ToString(263) || addClassOrSubject == Convert.ToString(264) || addClassOrSubject == Convert.ToString(265))
    //    {
    //        binddropdown201();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(266) || addClassOrSubject == Convert.ToString(267) || addClassOrSubject == Convert.ToString(268) || addClassOrSubject == Convert.ToString(269) || addClassOrSubject == Convert.ToString(270))
    //    {
    //        binddropdown201();
    //    }
    //    else if (addClassOrSubject == Convert.ToString(446) || addClassOrSubject == Convert.ToString(447) || addClassOrSubject == Convert.ToString(448) || addClassOrSubject == Convert.ToString(449))
    //    {
    //        binddropdown2();
    //    }
    //}

    protected void ddlTypeofExam_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string classORSubject = ddlTypeofExam.SelectedValue;
        Cds.BindClassOrSubject(ddlAddClass, classORSubject, chkSubject);
    }
    #endregion

    #region ddlAddClass

    //public void BindAddSubjectOnClassId(string addClassID)
    //{
    //    for (int count = 0; count < 15; count++)
    //    {
    //        if (addClassID == Convert.ToString(count))
    //        {
    //            Sql = " SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId=2 ";
    //            DataSet ds = cc.ExecuteDataset(Sql);

    //            chkSubject.DataSource = ds.Tables[0];
    //            chkSubject.DataTextField = "Name";
    //            chkSubject.DataValueField = "ItemValueId";
    //            chkSubject.DataBind();
    //        }
    //    }
    //    if ((addClassID == Convert.ToString(15) || addClassID == Convert.ToString(16)) && ddlTypeofExam.SelectedValue == Convert.ToString(99))
    //    {
    //        Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew=209 ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        chkSubject.DataSource = ds.Tables[0];
    //        chkSubject.DataTextField = "Name";
    //        chkSubject.DataValueField = "ItemValueIdNew";
    //        chkSubject.DataBind();
    //    }

    //    else if ((addClassID == Convert.ToString(15) || addClassID == Convert.ToString(16)) && (ddlTypeofExam.SelectedValue == Convert.ToString(98) || ddlTypeofExam.SelectedValue == Convert.ToString(100)))
    //    {
    //        Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew=208 ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        chkSubject.DataSource = ds.Tables[0];
    //        chkSubject.DataTextField = "Name";
    //        chkSubject.DataValueField = "ItemValueIdNew";
    //        chkSubject.DataBind();
    //    }
    //    else if (addClassID == Convert.ToString(188))
    //    {
    //        Sql = " SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId=2 ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        chkSubject.DataSource = ds.Tables[0];
    //        chkSubject.DataTextField = "Name";
    //        chkSubject.DataValueField = "ItemValueId";
    //        chkSubject.DataBind();
    //    }
    //    else if (addClassID == Convert.ToString(189))
    //    {
    //        Sql = " SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId=2 ";
    //        DataSet ds = cc.ExecuteDataset(Sql);

    //        chkSubject.DataSource = ds.Tables[0];
    //        chkSubject.DataTextField = "Name";
    //        chkSubject.DataValueField = "ItemValueId";
    //        chkSubject.DataBind();
    //    }
    //}

    protected void ddlAddClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        string addClassIDNew = ddlAddClass.SelectedValue;
        Cds.BindAddSubjectOnClassId(chkSubject, addClassIDNew, ddlTypeofExam);
    }

    #endregion

}
