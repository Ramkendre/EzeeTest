using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.SessionState;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommanDDLbindclass
/// </summary>
public class CommanDDLbindclass
{
    CommonCode cc = new CommonCode();
    string Sql;
    DataSet ds;
    public CommanDDLbindclass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void loadGroupofExam(DropDownList ddlGroupofExam) // class file created by Ram
    {
        string Sql = " SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId=0 OR ItemId=8 ";
        DataSet ds = cc.ExecuteDataset(Sql);
        ddlGroupofExam.DataSource = ds.Tables[0];
        ddlGroupofExam.DataTextField = "Name";
        ddlGroupofExam.DataValueField = "ItemValueId";
        ddlGroupofExam.DataBind();
    }

    #region TestDefination ddlGroupOfExam to bind ddlTypeofExam
    public void BindTypeofExamOnGroup(DropDownList ddlTypeofExam, string groupExId)
    {
        if (groupExId == Convert.ToString(135))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 212 ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
            // binddropdown212();
        }
        else if (groupExId == Convert.ToString(136))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 213 ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
            //binddropdown213();
        }
        else if (groupExId == Convert.ToString(137))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 214 ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
            //binddropdown214();
        }
        else if (groupExId == Convert.ToString(140)) //Scholarship
        {
            Sql = " SELECT Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=210  ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (groupExId == Convert.ToString(141))
        {
            Sql = " SELECT Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=207  ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (groupExId == Convert.ToString(142))
        {
            Sql = " SELECT Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=206  ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (groupExId == Convert.ToString(143))
        {
            Sql = " SELECT Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=203  ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (groupExId == Convert.ToString(144))
        {
            Sql = " SELECT Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=205  ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (groupExId == Convert.ToString(177))
        {
            Sql = " SELECT Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=1796  ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (groupExId == Convert.ToString(178))
        {
            Sql = " SELECT Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=1806  ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (groupExId == Convert.ToString(183))
        {
            Sql = " SELECT Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=1846  ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (groupExId == Convert.ToString(231))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 2310  ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (groupExId == Convert.ToString(232))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 2310  ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (groupExId == Convert.ToString(233))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 2310  ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
        else if (groupExId == Convert.ToString(257))
        {
            string loginid = HttpContext.Current.Session["LoginId"].ToString();
            string Sql = "Select Niitaps From Login Where [LoginId]='" + loginid + "'";
            string ntps = Convert.ToString(cc.ExecuteScalar(Sql));
            if (ntps == "" || ntps == null)
            {

            }
            else if (ntps == "1")
            {
                Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 257";
                DataSet ds = cc.ExecuteDataset(Sql);
                ddlTypeofExam.DataSource = ds.Tables[0];
                ddlTypeofExam.DataTextField = "Name";
                ddlTypeofExam.DataValueField = "ItemValueIdNew";
                ddlTypeofExam.DataBind();
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Not Permission to create test!!!')", true);
            }
        }
        else if (groupExId == Convert.ToString(273))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 273 ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
            //binddropdown273();
        }
        else if (groupExId == Convert.ToString(274))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 274 ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
            //binddropdown274();
        }
        else if (groupExId == Convert.ToString(275))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 275 ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
            //binddropdown275();
        }
        else if (groupExId == Convert.ToString(276))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 276 ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
            //binddropdown276();
        }
        else if (groupExId == Convert.ToString(277))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 277 ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
            //binddropdown277();
        }
        else if (groupExId == Convert.ToString(278))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 278 ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
            //binddropdown278();
        }
        else if (groupExId == Convert.ToString(445))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 279 ";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
            //binddropdown279();
        }
        else if(groupExId == Convert.ToString(455))
        {
            Sql = "SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 455";
            DataSet ds = cc.ExecuteDataset(Sql);
            ddlTypeofExam.DataSource = ds.Tables[0];
            ddlTypeofExam.DataTextField = "Name";
            ddlTypeofExam.DataValueField = "ItemValueIdNew";
            ddlTypeofExam.DataBind();
        }
    }
    #endregion

    #region TestDefination ddltypeofexam to bind ddladdclass

    protected void binddropdown202(DropDownList ddlAddClass)
    {
        ddlAddClass.Enabled = true;
        Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 202 ";
        DataSet ds = cc.ExecuteDataset(Sql);

        ddlAddClass.DataSource = ds.Tables[0];
        ddlAddClass.DataTextField = "Name";
        ddlAddClass.DataValueField = "ItemValueIdNew";
        ddlAddClass.DataBind();
    }

    protected void binddropdown211(DropDownList ddlAddClass)
    {
        ddlAddClass.Enabled = true;
        Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 211 ";
        DataSet ds = cc.ExecuteDataset(Sql);

        ddlAddClass.DataSource = ds.Tables[0];
        ddlAddClass.DataTextField = "Name";
        ddlAddClass.DataValueField = "ItemValueIdNew";
        ddlAddClass.DataBind();
    }

    protected void binddropdown2(DropDownList ddlAddClass, CheckBoxList chkSubject)
    {
        Sql = " SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId = 2";
        ds = cc.ExecuteDataset(Sql);
        chkSubject.DataSource = ds.Tables[0];
        chkSubject.DataTextField = "Name";
        chkSubject.DataValueField = "ItemValueId";
        chkSubject.DataBind();
        ddlAddClass.SelectedValue = "1";
        ddlAddClass.Enabled = false;
    }

    protected void binddropdown201(DropDownList ddlAddClass)
    {
        ddlAddClass.Enabled = true;
        Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 201 ";
        DataSet ds = cc.ExecuteDataset(Sql);

        ddlAddClass.DataSource = ds.Tables[0];
        ddlAddClass.DataTextField = "Name";
        ddlAddClass.DataValueField = "ItemValueIdNew";
        ddlAddClass.DataBind();
    }

    public void BindClassOrSubject(DropDownList ddlAddClass,string addClassOrSubject,CheckBoxList chkSubject)
    {
        if (addClassOrSubject == Convert.ToString(88) || addClassOrSubject == Convert.ToString(271) || addClassOrSubject == Convert.ToString(272))
        {
            binddropdown201(ddlAddClass);
        }
        else if (addClassOrSubject == Convert.ToString(98) || addClassOrSubject == Convert.ToString(99) || addClassOrSubject == Convert.ToString(100))
        {
            binddropdown202(ddlAddClass);
        }
        else if (addClassOrSubject == Convert.ToString(96) || addClassOrSubject == Convert.ToString(101) || addClassOrSubject == Convert.ToString(102))
        {
            binddropdown211(ddlAddClass);
        }
        else if (addClassOrSubject == Convert.ToString(89) || addClassOrSubject == Convert.ToString(94) || addClassOrSubject == Convert.ToString(95))
        {
            binddropdown2(ddlAddClass, chkSubject);
        }
        else if (addClassOrSubject == Convert.ToString(130))
        {
            binddropdown2(ddlAddClass, chkSubject);
        }
        else if (addClassOrSubject == Convert.ToString(110))
        {
            Sql = " SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId = 204 OR ItemId = 2 ORDER BY ItemValueId ASC";
            DataSet ds = cc.ExecuteDataset(Sql);

            chkSubject.DataSource = ds.Tables[0];
            chkSubject.DataTextField = "Name";
            chkSubject.DataValueField = "ItemValueId";
            chkSubject.DataBind();
            ddlAddClass.SelectedValue = "1";
            ddlAddClass.Enabled = false;
        }

        else if (addClassOrSubject == Convert.ToString(103) || addClassOrSubject == Convert.ToString(165) || addClassOrSubject == Convert.ToString(179))
        {
            binddropdown2(ddlAddClass, chkSubject);
        }
        else if (addClassOrSubject == Convert.ToString(180) || addClassOrSubject == Convert.ToString(176) || addClassOrSubject == Convert.ToString(184))
        {
            binddropdown2(ddlAddClass, chkSubject);
        }
        else if (addClassOrSubject == Convert.ToString(185) || addClassOrSubject == Convert.ToString(191) || addClassOrSubject == Convert.ToString(193))
        {
            binddropdown2(ddlAddClass, chkSubject);
        }
        else if (addClassOrSubject == Convert.ToString(200) || addClassOrSubject == Convert.ToString(201) || addClassOrSubject == Convert.ToString(202) || addClassOrSubject == Convert.ToString(203) || addClassOrSubject == Convert.ToString(204) || addClassOrSubject == Convert.ToString(205) || addClassOrSubject == Convert.ToString(206) || addClassOrSubject == Convert.ToString(207))
        {
            binddropdown2(ddlAddClass, chkSubject);
        }
        else if (addClassOrSubject == Convert.ToString(217))
        {
            binddropdown2(ddlAddClass, chkSubject);
        }
        else if (addClassOrSubject == Convert.ToString(224))
        {
            ddlAddClass.Enabled = true;
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 201 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlAddClass.DataSource = ds.Tables[0];
            ddlAddClass.DataTextField = "Name";
            ddlAddClass.DataValueField = "ItemValueIdNew";
            ddlAddClass.DataBind();
        }
        else if (addClassOrSubject == Convert.ToString(227) || addClassOrSubject == Convert.ToString(228) || addClassOrSubject == Convert.ToString(229))
        {
            binddropdown2(ddlAddClass, chkSubject);
        }
        else if (addClassOrSubject == Convert.ToString(230) || addClassOrSubject == Convert.ToString(234) || addClassOrSubject == Convert.ToString(235))
        {
            binddropdown2(ddlAddClass, chkSubject);
        }
        else if (addClassOrSubject == Convert.ToString(236) || addClassOrSubject == Convert.ToString(237) || addClassOrSubject == Convert.ToString(248))
        {
            binddropdown2(ddlAddClass, chkSubject);
        }
        else if (addClassOrSubject == Convert.ToString(254))
        {
            binddropdown2(ddlAddClass, chkSubject);
        }
        else if (addClassOrSubject == Convert.ToString(258) || addClassOrSubject == Convert.ToString(259) || addClassOrSubject == Convert.ToString(260) || addClassOrSubject == Convert.ToString(261) || addClassOrSubject == Convert.ToString(262) || addClassOrSubject == Convert.ToString(263) || addClassOrSubject == Convert.ToString(264) || addClassOrSubject == Convert.ToString(265))
        {
            binddropdown201(ddlAddClass);
        }
        else if (addClassOrSubject == Convert.ToString(266) || addClassOrSubject == Convert.ToString(267) || addClassOrSubject == Convert.ToString(268) || addClassOrSubject == Convert.ToString(269) || addClassOrSubject == Convert.ToString(270))
        {
            binddropdown201(ddlAddClass);
        }
        else if (addClassOrSubject == Convert.ToString(446) || addClassOrSubject == Convert.ToString(447) || addClassOrSubject == Convert.ToString(448) || addClassOrSubject == Convert.ToString(449))
        {
            binddropdown2(ddlAddClass, chkSubject);
        }
        else if (addClassOrSubject == Convert.ToString(456))
        {
            binddropdown201(ddlAddClass);
        }
    }
    #endregion

    #region TestDefination ddlAddClass to bind cmbSubject
    public void BindAddSubjectOnClassId(CheckBoxList chkSubject, string addClassIDNew, DropDownList ddlTypeofExam)
    {
        for (int count = 0; count < 15; count++)
        {
            if (addClassIDNew == Convert.ToString(count))
            {
                Sql = " SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId=2 ";
                DataSet ds = cc.ExecuteDataset(Sql);

                chkSubject.DataSource = ds.Tables[0];
                chkSubject.DataTextField = "Name";
                chkSubject.DataValueField = "ItemValueId";
                chkSubject.DataBind();
            }
        }
        if ((addClassIDNew == Convert.ToString(15) || addClassIDNew == Convert.ToString(16)) && ddlTypeofExam.SelectedValue == Convert.ToString(99))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew=209 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            chkSubject.DataSource = ds.Tables[0];
            chkSubject.DataTextField = "Name";
            chkSubject.DataValueField = "ItemValueIdNew";
            chkSubject.DataBind();
        }
        else if ((addClassIDNew == Convert.ToString(15) || addClassIDNew == Convert.ToString(16)) && (ddlTypeofExam.SelectedValue == Convert.ToString(98) || ddlTypeofExam.SelectedValue == Convert.ToString(100)))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew=208 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            chkSubject.DataSource = ds.Tables[0];
            chkSubject.DataTextField = "Name";
            chkSubject.DataValueField = "ItemValueIdNew";
            chkSubject.DataBind();
        }
        else if (addClassIDNew == Convert.ToString(188))
        {
            Sql = " SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId=2 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            chkSubject.DataSource = ds.Tables[0];
            chkSubject.DataTextField = "Name";
            chkSubject.DataValueField = "ItemValueId";
            chkSubject.DataBind();
        }
        else if (addClassIDNew == Convert.ToString(189))
        {
            Sql = " SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId=2 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            chkSubject.DataSource = ds.Tables[0];
            chkSubject.DataTextField = "Name";
            chkSubject.DataValueField = "ItemValueId";
            chkSubject.DataBind();
        }
    }
    #endregion

    #region ExcelUpload,MsAccessUpload ddlTypeofExam to bind ddladdClass

    protected void Binddropdown202(DropDownList ddlAddClass)
    {
        ddlAddClass.Enabled = true;
        Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 202 ";
        DataSet ds = cc.ExecuteDataset(Sql);

        ddlAddClass.DataSource = ds.Tables[0];
        ddlAddClass.DataTextField = "Name";
        ddlAddClass.DataValueField = "ItemValueIdNew";
        ddlAddClass.DataBind();
    }

    protected void Binddropdown211(DropDownList ddlAddClass)
    {
        ddlAddClass.Enabled = true;
        Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 211 ";
        DataSet ds = cc.ExecuteDataset(Sql);

        ddlAddClass.DataSource = ds.Tables[0];
        ddlAddClass.DataTextField = "Name";
        ddlAddClass.DataValueField = "ItemValueIdNew";
        ddlAddClass.DataBind();
    }

    protected void Binddropdown2(DropDownList ddlAddClass, DropDownList cmbSelectsubject)
    {
        Sql = " SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId = 2";
        ds = cc.ExecuteDataset(Sql);
        cmbSelectsubject.DataSource = ds.Tables[0];
        cmbSelectsubject.DataTextField = "Name";
        cmbSelectsubject.DataValueField = "ItemValueId";
        cmbSelectsubject.DataBind();
        ddlAddClass.SelectedValue = "1";
        ddlAddClass.Enabled = false;
    }

    protected void Binddropdown201(DropDownList ddlAddClass)
    {
        ddlAddClass.Enabled = true;
        Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 201 ";
        DataSet ds = cc.ExecuteDataset(Sql);

        ddlAddClass.DataSource = ds.Tables[0];
        ddlAddClass.DataTextField = "Name";
        ddlAddClass.DataValueField = "ItemValueIdNew";
        ddlAddClass.DataBind();
    }

    public void BindClassOrSubject(DropDownList ddlAddClass, string addClassOrSubject, DropDownList cmbSelectsubject)
    {
        if (addClassOrSubject == Convert.ToString(88) || addClassOrSubject == Convert.ToString(271) || addClassOrSubject == Convert.ToString(272))
        {
            Binddropdown201(ddlAddClass);
        }
        else if (addClassOrSubject == Convert.ToString(98) || addClassOrSubject == Convert.ToString(99) || addClassOrSubject == Convert.ToString(100))
        {
            binddropdown202(ddlAddClass);
        }
        else if (addClassOrSubject == Convert.ToString(96) || addClassOrSubject == Convert.ToString(101) || addClassOrSubject == Convert.ToString(102))
        {
            Binddropdown211(ddlAddClass);
        }
        else if (addClassOrSubject == Convert.ToString(89) || addClassOrSubject == Convert.ToString(94) || addClassOrSubject == Convert.ToString(95))
        {
            Binddropdown2(ddlAddClass, cmbSelectsubject);
        }
        else if (addClassOrSubject == Convert.ToString(130))
        {
            Binddropdown2(ddlAddClass, cmbSelectsubject);
        }
        else if (addClassOrSubject == Convert.ToString(110))
        {
            Sql = " SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId = 204 OR ItemId = 2 ORDER BY ItemValueId ASC";
            DataSet ds = cc.ExecuteDataset(Sql);

            cmbSelectsubject.DataSource = ds.Tables[0];
            cmbSelectsubject.DataTextField = "Name";
            cmbSelectsubject.DataValueField = "ItemValueId";
            cmbSelectsubject.DataBind();
            ddlAddClass.SelectedValue = "1";
            ddlAddClass.Enabled = false;
        }

        else if (addClassOrSubject == Convert.ToString(103) || addClassOrSubject == Convert.ToString(165) || addClassOrSubject == Convert.ToString(179))
        {
            Binddropdown2(ddlAddClass, cmbSelectsubject);
        }
        else if (addClassOrSubject == Convert.ToString(180) || addClassOrSubject == Convert.ToString(176) || addClassOrSubject == Convert.ToString(184))
        {
            Binddropdown2(ddlAddClass, cmbSelectsubject);
        }
        else if (addClassOrSubject == Convert.ToString(185) || addClassOrSubject == Convert.ToString(191) || addClassOrSubject == Convert.ToString(193))
        {
            Binddropdown2(ddlAddClass, cmbSelectsubject);
        }
        else if (addClassOrSubject == Convert.ToString(200) || addClassOrSubject == Convert.ToString(201) || addClassOrSubject == Convert.ToString(202) || addClassOrSubject == Convert.ToString(203) || addClassOrSubject == Convert.ToString(204) || addClassOrSubject == Convert.ToString(205) || addClassOrSubject == Convert.ToString(206) || addClassOrSubject == Convert.ToString(207))
        {
            Binddropdown2(ddlAddClass, cmbSelectsubject);
        }
        else if (addClassOrSubject == Convert.ToString(217))
        {
            Binddropdown2(ddlAddClass, cmbSelectsubject);
        }
        else if (addClassOrSubject == Convert.ToString(224))
        {
            ddlAddClass.Enabled = true;
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew = 0 OR ItemIdNew = 201 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlAddClass.DataSource = ds.Tables[0];
            ddlAddClass.DataTextField = "Name";
            ddlAddClass.DataValueField = "ItemValueIdNew";
            ddlAddClass.DataBind();
        }
        else if (addClassOrSubject == Convert.ToString(227) || addClassOrSubject == Convert.ToString(228) || addClassOrSubject == Convert.ToString(229))
        {
            Binddropdown2(ddlAddClass, cmbSelectsubject);
        }
        else if (addClassOrSubject == Convert.ToString(230) || addClassOrSubject == Convert.ToString(234) || addClassOrSubject == Convert.ToString(235))
        {
            Binddropdown2(ddlAddClass, cmbSelectsubject);
        }
        else if (addClassOrSubject == Convert.ToString(236) || addClassOrSubject == Convert.ToString(237) || addClassOrSubject == Convert.ToString(248))
        {
            Binddropdown2(ddlAddClass, cmbSelectsubject);
        }
        else if (addClassOrSubject == Convert.ToString(254))
        {
            Binddropdown2(ddlAddClass, cmbSelectsubject);
        }
        else if (addClassOrSubject == Convert.ToString(258) || addClassOrSubject == Convert.ToString(259) || addClassOrSubject == Convert.ToString(260) || addClassOrSubject == Convert.ToString(261) || addClassOrSubject == Convert.ToString(262) || addClassOrSubject == Convert.ToString(263) || addClassOrSubject == Convert.ToString(264) || addClassOrSubject == Convert.ToString(265))
        {
            Binddropdown201(ddlAddClass);
        }
        else if (addClassOrSubject == Convert.ToString(266) || addClassOrSubject == Convert.ToString(267) || addClassOrSubject == Convert.ToString(268) || addClassOrSubject == Convert.ToString(269) || addClassOrSubject == Convert.ToString(270))
        {
            Binddropdown201(ddlAddClass);
        }
        else if (addClassOrSubject == Convert.ToString(446) || addClassOrSubject == Convert.ToString(447) || addClassOrSubject == Convert.ToString(448) || addClassOrSubject == Convert.ToString(449))
        {
            Binddropdown2(ddlAddClass, cmbSelectsubject);
        }
        else if(addClassOrSubject == Convert.ToString(456))
        {
            Binddropdown201(ddlAddClass);
        }
    }
    #endregion

    #region ExcelUpload,MsAccessUpload ddlAddClass to bind cmbSubject
    public void BindAddSubjectOnClassId(DropDownList cmbSelectsubject, string addClassIDNew, DropDownList ddlTypeofExam)
    {
        for (int count = 0; count < 15; count++)
        {
            if (addClassIDNew == Convert.ToString(count))
            {
                Sql = " SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId=0 OR ItemId=2 ";
                DataSet ds = cc.ExecuteDataset(Sql);

                cmbSelectsubject.DataSource = ds.Tables[0];
                cmbSelectsubject.DataTextField = "Name";
                cmbSelectsubject.DataValueField = "ItemValueId";
                cmbSelectsubject.DataBind();
            }
        }
        if ((addClassIDNew == Convert.ToString(15) || addClassIDNew == Convert.ToString(16)) && ddlTypeofExam.SelectedValue == Convert.ToString(99))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew=0 OR ItemIdNew=209 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            cmbSelectsubject.DataSource = ds.Tables[0];
            cmbSelectsubject.DataTextField = "Name";
            cmbSelectsubject.DataValueField = "ItemValueIdNew";
            cmbSelectsubject.DataBind();
        }
        else if ((addClassIDNew == Convert.ToString(15) || addClassIDNew == Convert.ToString(16)) && (ddlTypeofExam.SelectedValue == Convert.ToString(98) || ddlTypeofExam.SelectedValue == Convert.ToString(100)))
        {
            Sql = " SELECT Name,ItemValueIdNew FROM tblItemValue WHERE ItemIdNew=0 OR ItemIdNew=208 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            cmbSelectsubject.DataSource = ds.Tables[0];
            cmbSelectsubject.DataTextField = "Name";
            cmbSelectsubject.DataValueField = "ItemValueIdNew";
            cmbSelectsubject.DataBind();
        }
        else if (addClassIDNew == Convert.ToString(188))
        {
            Sql = " SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId=0 OR ItemId=2 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            cmbSelectsubject.DataSource = ds.Tables[0];
            cmbSelectsubject.DataTextField = "Name";
            cmbSelectsubject.DataValueField = "ItemValueId";
            cmbSelectsubject.DataBind();
        }
        else if (addClassIDNew == Convert.ToString(189))
        {
            Sql = " SELECT Name,ItemValueId FROM tblItemValue WHERE ItemId=0 OR ItemId=2 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            cmbSelectsubject.DataSource = ds.Tables[0];
            cmbSelectsubject.DataTextField = "Name";
            cmbSelectsubject.DataValueField = "ItemValueId";
            cmbSelectsubject.DataBind();
        }
    }
    #endregion

    #region Practice ddlmedium to bind ddltopik ChapterName
    public void GetChapterNames(DropDownList ddlTopik, DropDownList ddlGroupofExam, DropDownList ddlTypeofExam, DropDownList ddlMedium, DropDownList ddlAddClass, DropDownList cmbSelectsubject)
    {
        string sqlQuery = " SELECT [ChapterID],[ChapterName] FROM [tblChapterANDTopicNames] WHERE [GroupofExamId]='" + ddlGroupofExam.SelectedValue + "' AND [TypeofExamId]='" + ddlTypeofExam.SelectedValue + "' AND [Medium]='" + ddlMedium.SelectedItem.Text + "' AND [ClassID]='" + ddlAddClass.SelectedValue + "' AND [SubjectID]='" + cmbSelectsubject.SelectedValue + "' ";
        DataSet dataset = cc.ExecuteDataset(sqlQuery);

        if (dataset.Tables[0].Rows.Count > 0)
        {
            ddlTopik.DataSource = dataset.Tables[0];  //ddlChapter
            ddlTopik.DataTextField = "ChapterName";
            ddlTopik.DataValueField = "ChapterID";
            ddlTopik.DataBind();
            ddlTopik.Items.Add("--Select--");
            ddlTopik.SelectedIndex = ddlTopik.Items.Count - 1;
        }
        else
        {
            Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 3 ";
            dataset = cc.ExecuteDataset(Sql);

            ddlTopik.DataSource = dataset.Tables[0];
            ddlTopik.DataTextField = "Name";
            ddlTopik.DataValueField = "ItemValueId";
            ddlTopik.DataBind();
            ddlTopik.Items.Add("--Select--");
            ddlTopik.SelectedIndex = ddlTopik.Items.Count - 1;
        }
    }
    #endregion

    #region Practice ddltopik to bind TopicName 
    public void GetToipcName(CheckBoxList ddlChapter,string tpkid, CheckBox ChkSelectALL, DropDownList ddlGroupofExam, DropDownList ddlTypeofExam, DropDownList ddlMedium, DropDownList ddlAddClass, DropDownList cmbSelectsubject,DropDownList ddltopik)
    {
        string sqlQuery = " SELECT [TopicID],[TopicName] FROM [tblChapterANDTopicNames] WHERE [GroupofExamId]='" + ddlGroupofExam.SelectedValue + "' AND [TypeofExamId]='" + ddlTypeofExam.SelectedValue + "' AND [Medium]='" + ddlMedium.SelectedItem.Text + "' AND [ClassID]='" + ddlAddClass.SelectedValue + "' AND [SubjectID]='" + cmbSelectsubject.SelectedValue + "' AND [ChapterID]='"+ ddltopik.SelectedValue +"' ";
        DataSet dataset = cc.ExecuteDataset(sqlQuery);
        if (dataset.Tables[0].Rows.Count > 0)
        {
            string topicname = Convert.ToString(dataset.Tables[0].Rows[0]["TopicName"]);
            if (topicname == "")
            {
                Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 4 ";
                dataset = cc.ExecuteDataset(Sql);

                ddlChapter.DataSource = dataset.Tables[0];
                ddlChapter.DataTextField = "Name";
                ddlChapter.DataValueField = "ItemValueId";
                ddlChapter.DataBind();

                ChkSelectALL.Visible = true;
            }
            else
            {
                ddlChapter.DataSource = dataset.Tables[0];  //ddlChapter
                ddlChapter.DataTextField = "TopicName";
                ddlChapter.DataValueField = "TopicID";
                ddlChapter.DataBind();

                ChkSelectALL.Visible = true;
            }
        }
        else
        {
            Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 4 ";
            dataset = cc.ExecuteDataset(Sql);

            ddlChapter.DataSource = dataset.Tables[0];
            ddlChapter.DataTextField = "Name";
            ddlChapter.DataValueField = "ItemValueId";
            ddlChapter.DataBind();

            ChkSelectALL.Visible = true;
        }
    }
    #endregion

    #region Display Question cmbSelectsubject to bind ddltopik ChapterName
    public void GetChapterNames(DropDownList ddlTopik, DropDownList ddlTypeofExam, DropDownList ddlAddClass, DropDownList cmbSelectsubject)
    {
        string sqlQuery = " SELECT [ChapterID],[ChapterName] FROM [tblChapterANDTopicNames] WHERE   [TypeofExamId]='" + ddlTypeofExam.SelectedValue + "'  AND [ClassID]='" + ddlAddClass.SelectedValue + "' AND [SubjectID]='" + cmbSelectsubject.SelectedValue + "' ";
        DataSet dataset = cc.ExecuteDataset(sqlQuery);

        if (dataset.Tables[0].Rows.Count > 0)
        {
            ddlTopik.DataSource = dataset.Tables[0];  //ddlChapter
            ddlTopik.DataTextField = "ChapterName";
            ddlTopik.DataValueField = "ChapterID";
            ddlTopik.DataBind();
            ddlTopik.Items.Add("--Select--");
            ddlTopik.SelectedIndex = ddlTopik.Items.Count - 1;
        }
        else
        {
            Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 3 ";
            dataset = cc.ExecuteDataset(Sql);

            ddlTopik.DataSource = dataset.Tables[0];
            ddlTopik.DataTextField = "Name";
            ddlTopik.DataValueField = "ItemValueId";
            ddlTopik.DataBind();
            ddlTopik.Items.Add("--Select--");
            ddlTopik.SelectedIndex = ddlTopik.Items.Count - 1;
        }
    }
    #endregion

    #region Display Question ddltopik to bind TopicName
    public void GetToipcName(CheckBoxList ddlChapter, CheckBox ChkSelectALL, DropDownList ddlTypeofExam, DropDownList ddlAddClass, DropDownList cmbSelectsubject, DropDownList ddlTopik)
    {
        string sqlQuery = " SELECT [TopicID],[TopicName] FROM [tblChapterANDTopicNames] WHERE   [TypeofExamId]='" + ddlTypeofExam.SelectedValue + "' AND [ClassID]='" + ddlAddClass.SelectedValue + "' AND [SubjectID]='" + cmbSelectsubject.SelectedValue + "' AND [ChapterID]='" + ddlTopik.SelectedValue + "' "; 
        DataSet dataset = cc.ExecuteDataset(sqlQuery);
        if (dataset.Tables[0].Rows.Count > 0)
        {
            string topicname = Convert.ToString(dataset.Tables[0].Rows[0]["TopicName"]);
            if (topicname == "")
            {
                Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 4 ";
                dataset = cc.ExecuteDataset(Sql);

                ddlChapter.DataSource = dataset.Tables[0];
                ddlChapter.DataTextField = "Name";
                ddlChapter.DataValueField = "ItemValueId";
                ddlChapter.DataBind();

                ChkSelectALL.Visible = true;
            }
            else
            {
                ddlChapter.DataSource = dataset.Tables[0];  //ddlChapter
                ddlChapter.DataTextField = "TopicName";
                ddlChapter.DataValueField = "TopicID";
                ddlChapter.DataBind();

                ChkSelectALL.Visible = true;
            }
        }
        else
        {
            Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 4 ";
            dataset = cc.ExecuteDataset(Sql);

            ddlChapter.DataSource = dataset.Tables[0];
            ddlChapter.DataTextField = "Name";
            ddlChapter.DataValueField = "ItemValueId";
            ddlChapter.DataBind();

            ChkSelectALL.Visible = true;
        }
    }
    #endregion

    #region Method-1,2,3 ddlmedium to bind ddltopik ChapterName
    public void GetChapterNames(DropDownList ddlTopik, DropDownList ddltextName, DropDownList cmbSelectsubject)
    {
        string sql = "SELECT [TypeOFExam],[Class_id] FROM [tblTestDefinition] WHERE [Test_ID]='" + ddltextName.SelectedValue + "'";
        DataSet ds = cc.ExecuteDataset(sql);

        string TOE_id = Convert.ToString(ds.Tables[0].Rows[0]["TypeOFExam"]);
        string Cl_id = Convert.ToString(ds.Tables[0].Rows[0]["Class_id"]);

        string sqlQuery = " SELECT [ChapterID],[ChapterName] FROM [tblChapterANDTopicNames] WHERE [TypeofExamId]='" + TOE_id + "' AND [ClassID]='" + Cl_id + "' AND [SubjectID]='" + cmbSelectsubject.SelectedValue + "' "; 
        DataSet dataset = cc.ExecuteDataset(sqlQuery);

        if (dataset.Tables[0].Rows.Count > 0)
        {
            string chaptername = Convert.ToString(dataset.Tables[0].Rows[0]["ChapterName"]);
            if (chaptername == "")
            {
                Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 0 OR [ItemId] = 3"; 
                dataset = cc.ExecuteDataset(Sql);

                ddlTopik.DataSource = dataset.Tables[0];
                ddlTopik.DataTextField = "Name";
                ddlTopik.DataValueField = "ItemValueId";
                ddlTopik.DataBind();
            }
            else
            {
                ddlTopik.DataSource = dataset.Tables[0];  
                ddlTopik.DataTextField = "ChapterName";
                ddlTopik.DataValueField = "ChapterID";
                ddlTopik.DataBind();
                ddlTopik.Items.Add("--Select--");
                ddlTopik.SelectedIndex = ddlTopik.Items.Count - 1;
            }
        }
        else
        {
            string Sql = "SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 0 OR [ItemId] = 3"; 
            dataset = cc.ExecuteDataset(Sql);

            ddlTopik.DataSource = dataset.Tables[0];
            ddlTopik.DataTextField = "Name";
            ddlTopik.DataValueField = "ItemValueId";
            ddlTopik.DataBind();
        }
    }
    #endregion

    #region Method-1,2,3 ddltopik to bind ddlChapter 
    public void GetToipcName(DropDownList ddltextName, DropDownList cmbSelectsubject, DropDownList ddlTopik, CheckBoxList ddlChapter, CheckBox ChkSelectALL)
    {
        string sql = "SELECT [TypeOFExam],[Class_id] FROM [tblTestDefinition] WHERE [Test_ID]='" + ddltextName.SelectedValue + "'";
        DataSet ds = cc.ExecuteDataset(sql);

        string TOE_id = Convert.ToString(ds.Tables[0].Rows[0]["TypeOFExam"]);
        string Cl_id = Convert.ToString(ds.Tables[0].Rows[0]["Class_id"]);

        string Sql = " SELECT [TopicID],[TopicName] FROM [tblChapterANDTopicNames] WHERE  [SubjectID]='" + cmbSelectsubject.SelectedValue + "' AND [ChapterID]='" + ddlTopik.SelectedValue + "' AND TypeofExamId='" + TOE_id + "' AND ClassID='" + Cl_id + "' ";
        DataSet dataset = cc.ExecuteDataset(Sql);

        if (dataset.Tables[0].Rows.Count > 0)
        {
            string topicname = Convert.ToString(dataset.Tables[0].Rows[0]["TopicName"]);
            if (topicname == "")
            {
                Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 4 ";
                dataset = cc.ExecuteDataset(Sql);

                ddlChapter.DataSource = dataset.Tables[0];
                ddlChapter.DataTextField = "Name";
                ddlChapter.DataValueField = "ItemValueId";
                ddlChapter.DataBind();

                ChkSelectALL.Visible = true;
            }
            else
            {
                ddlChapter.DataSource = dataset.Tables[0];
                ddlChapter.DataTextField = "TopicName";
                ddlChapter.DataValueField = "TopicID";
                ddlChapter.DataBind();

                ChkSelectALL.Visible = true;
            }
        }
        else
        {

            Sql = " SELECT [Name],[ItemValueId] FROM [tblItemValue] WHERE [ItemId] = 4 ";
            dataset = cc.ExecuteDataset(Sql);

            ddlChapter.DataSource = dataset.Tables[0];
            ddlChapter.DataTextField = "Name";
            ddlChapter.DataValueField = "ItemValueId";
            ddlChapter.DataBind();

            ChkSelectALL.Visible = true;
        }
    }
    #endregion
}
