using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Layout_AdminMaster : System.Web.UI.MasterPage
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;

        lblUserName.Text = " Welcome : " + Convert.ToString(Session["UserName"]);
        string a = Convert.ToString(Session["CompanyName"]);

        if ((Convert.ToString(Session["LoginId"]) == null || Convert.ToString(Session["LoginId"]) == "" && Convert.ToString(Session["Rname"]) != "Administator"))
        {
            Response.Redirect("../UserLogin.aspx");
        }
        if (!IsPostBack)
        {
            getAllMainMenu();
        }
        //ListControlCollections();
    }
    private void getAllMainMenu()
    {
        try
        {
            mcity.Visible = false;
            mdistrict.Visible = false;
            mState.Visible = false;
            mtaluka.Visible = false;
            mcity.Visible = false;
            mexam.Visible = false;
            mquestion.Visible = false;
            mRole.Visible = false;
            massignChapter.Visible = false;
            mSetExamPaper.Visible = false;
            mSetExamPaper1.Visible = false;
            mSetExamPaper2.Visible = false;
            mTheoryQuestionPaper.Visible = false;
            mOperatorDetails.Visible = false;
            //mschool.Visible = false;
            mtestDefination.Visible = false;
            mUpdateProfile.Visible = false;
            mUploadAccessDB.Visible = false;
            mUploadexcel.Visible = false;
            mUserRegister.Visible = false;

            mlocation.Visible = false;
            msuperadmin.Visible = false;
            msubadmin.Visible = false;
            muser.Visible = false;
            mItemMaster.Visible = false;
            mVisitorsDetails.Visible = false;
            mDefulatTest.Visible = false;
            mCheckAllInCorrectQuestions.Visible = false;

            //android  class App
            mAndroidClassApp.Visible = false;
            mAndroidClassSetting.Visible = false;
            mAndroidEvalution.Visible = false;
            mAndroidTestDetails.Visible = false;
            mAndroidStudentAttendance.Visible = false;
            mAndroidStudentFees.Visible = false;

            //report
            mReport.Visible = false;
            mReportAttendance.Visible = false;
            mReportFees.Visible = false;
            mReportTest.Visible = false;


            int Role = Convert.ToInt32(Session["Role"]);

            if (Role == 7 || Role == 10 || Role == 4 || Role == 6 || Role == 23)
            {
                lnkbtnDashboard.Visible = false;
            }
            else
            {
                lnkbtnDashboard.Visible = true;
            }

            if (Role == 22 || Role == 23)
            {
                muser.Visible = false;
                mPractice.Visible = false;
                mPractice1.Visible = false;
                mmcq.Visible = false;
                Li1.Visible = true;
                Li2.Visible = true;
                Li4.Visible = true;
            }
            else
            {
                muser.Visible = true;
                mPractice.Visible = true;
                mPractice1.Visible = true;
                mmcq.Visible = true;
                Li1.Visible = false;
                Li2.Visible = false;
                Li4.Visible = false;
            }

            if (Role != 1)
            {
                string Sql = " Select MenuId from Role where RoleId=" + Role + "";
                string Menus = Convert.ToString(cc.ExecuteScalar(Sql));

                if (Menus == "")
                {
                    if (Convert.ToString(Session["admintype"]) == "1")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Not assign Admin authority')", true);
                    }
                    else if (Convert.ToString(Session["admintype"]) == "2")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Not assign user athority')", true);
                    }
                }
                else
                {
                    Sql = "Select distinct MenuId,MenuName from Menu where MenuId in(" + Menus + ")";
                    // Sql = "Select distinct menuid ,MenuName from Menu where ParentId in(-2)";

                    DataSet ds = cc.ExecuteDataset(Sql);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string Id = Convert.ToString(dr["MenuId"]);

                        if (Id == "1")
                        {
                            mhomwe.Visible = true;
                            mUpdateProfile.Visible = true;
                        }
                        else if (Id == "5") //Super Admin Panel
                        {
                            msuperadmin.Visible = true;

                            Sql = "Select distinct MenuId,MenuName from Menu where ParentId=" + Id + " and MenuId in(" + Menus + ")";
                            ds = cc.ExecuteDataset(Sql);
                            foreach (DataRow dr1 in ds.Tables[0].Rows)
                            {

                                string MenuId = Convert.ToString(dr1["MenuId"]);
                                if (MenuId == "20")
                                {
                                    mState.Visible = true;
                                }
                                else if (MenuId == "21")
                                {
                                    mdistrict.Visible = true;
                                }
                                else if (MenuId == "26")
                                {
                                    mlocation.Visible = true;
                                }
                                else if (MenuId == "22")
                                {
                                    mtaluka.Visible = true;
                                }
                                else if (MenuId == "23")
                                {
                                    mcity.Visible = true;
                                }
                                else if (MenuId == "15")
                                {
                                    mRole.Visible = true;
                                }
                                //else if (MenuId == "24")
                                //{
                                //    mschool.Visible = true;
                                //}

                                else if (MenuId == "25")
                                {
                                    mItemMaster.Visible = true;
                                }
                                else if (MenuId == "13")
                                {
                                    // mexam.Visible = true;
                                }

                                else if (MenuId == "17")
                                {
                                    mUserRegister.Visible = true;
                                }

                                else if (MenuId == "14")
                                {
                                    mtestDefination.Visible = true;
                                }

                                else if (MenuId == "27")
                                {
                                    massignChapter.Visible = true;
                                }

                                else if (MenuId == "28")
                                {
                                    mSetExamPaper.Visible = true;
                                }
                                else if (MenuId == "45")
                                {
                                    mSetExamPaper1.Visible = true;
                                }
                                else if (MenuId == "46")
                                {
                                    mSetExamPaper2.Visible = true;
                                }

                                else if (MenuId == "30")
                                {
                                    mTheoryQuestionPaper.Visible = true;
                                }
                                else if (MenuId == "31")
                                {
                                    mOperatorDetails.Visible = true;
                                }
                                else if (MenuId == "38")
                                {
                                    mVisitorsDetails.Visible = true;
                                }
                                else if (MenuId == "43")
                                {
                                    mDefulatTest.Visible = true;
                                }
                            }
                        }

                        else if (Id == "9")
                        {
                            msubadmin.Visible = true;

                            Sql = "Select distinct MenuId,MenuName from Menu where ParentId=" + Id + " and MenuId in(" + Menus + ")";
                            ds = cc.ExecuteDataset(Sql);
                            foreach (DataRow dr1 in ds.Tables[0].Rows)
                            {
                                string MenuId = Convert.ToString(dr1["MenuId"]);
                                if (MenuId == "11")
                                {
                                    mUploadAccessDB.Visible = true;
                                }
                                else if (MenuId == "10")
                                {
                                    mUploadexcel.Visible = true;
                                }
                                else if (MenuId == "12")
                                {
                                    mquestion.Visible = true;
                                }
                                else if (MenuId == "44")
                                {
                                    mCheckAllInCorrectQuestions.Visible = true;
                                }
                            }
                        }
                        else if (Id == "16")
                        {
                            muser.Visible = true;
                            mmcq.Visible = true;
                            Sql = "Select distinct MenuId,MenuName from Menu where ParentId=" + Id + " and MenuId in(" + Menus + ")";
                            ds = cc.ExecuteDataset(Sql);
                            foreach (DataRow dr1 in ds.Tables[0].Rows)
                            {
                                string MenuId = Convert.ToString(dr1["MenuId"]);
                                if (MenuId == "18")
                                {
                                    mPractice.Visible = true;
                                }
                            }
                        }

                            // Android Class App
                        else if (Id == "32")
                        {
                            mAndroidClassApp.Visible = true;
                            Sql = "select distinct MenuId,MenuName from Menu where ParentId=" + Id + " and MenuId in(" + Menus + ")";
                            ds = cc.ExecuteDataset(Sql);
                            foreach (DataRow dr1 in ds.Tables[0].Rows)
                            {
                                string MenuId = Convert.ToString(dr1["MenuId"]);
                                if (MenuId == "33")
                                {
                                    mAndroidClassSetting.Visible = true;
                                }
                                if (MenuId == "34")
                                {
                                    mAndroidEvalution.Visible = true;
                                }
                                if (MenuId == "35")
                                {
                                    mAndroidStudentAttendance.Visible = true;
                                }
                                if (MenuId == "36")
                                {
                                    mAndroidTestDetails.Visible = true;
                                }
                                if (MenuId == "37")
                                {
                                    mAndroidStudentFees.Visible = true;
                                }
                                if (MenuId == "39")
                                {
                                    mReport.Visible = true;
                                }
                                if (MenuId == "40")
                                {
                                    mReportFees.Visible = true;
                                }
                                if (MenuId == "41")
                                {
                                    mReportAttendance.Visible = true;
                                }
                                if (MenuId == "42")
                                {
                                    mReportTest.Visible = true;
                                }
                                if (MenuId == "48")
                                {
                                    mAndroidStudentReg.Visible = true;
                                }
                            }

                        }

                    }
                }
            }
            else
            {
            }
        }
        catch
        { }
    }
}

