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
using System.Data.SqlClient;
using System.IO;

public partial class Andorid_Class_App_ClassSetting : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    string Sql = "", EntryDate;
    int status;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            loadClass();
            BindGrid();
        }
        Dateformat();
    }

    public void BindGrid()
    {
        // string SqlCount = "select COUNT(Distinct(CS.Mob_No)) from tblClassSetting CS inner join  tblItemValue IV on CS.Class_Id= IV.ItemValueId where Login_Id='" + Convert.ToString(Session["LoginId"]) + "' ";
        string SqlCount = "select COUNT(*) as StudentTotal from tblClassSetting CS inner join [tblStudentRegister] SR on CS.[ClassSetting_id]= SR.ClassSetting_id  where Login_Id='" + Convert.ToString(Session["LoginId"]) + "' ";
        lblClassCuntDisplay.Text = Convert.ToString(cc.ExecuteScalar(SqlCount));
        //Sql = "select DISTINCT(Mob_No),tblClassSetting.* ,Name as Class_Name from tblClassSetting  inner join  tblItemValue on tblClassSetting.Class_Id= tblItemValue.ItemValueId where Login_Id='" + Convert.ToString(Session["LoginId"]) + "' order by ClassSetting_id DESC ";
        //Sql = "WITH AllData (Mob_No,[ClassSetting_id],[Session],[Semester],Class_Teacher,Batch,Class_Name,Class_Id) " +
        //      "AS " +
        //      "( " +
        //      " select DISTINCT(CS.Mob_No),CS.[ClassSetting_id],CS.[Session],CS.[Semester],CS.Class_Teacher,CS.Batch,IV.Name as Class_Name,CS.Class_Id " +
        //       " from tblClassSetting CS inner join  tblItemValue IV on CS.Class_Id= IV.ItemValueId where Login_Id='" + Convert.ToString(Session["LoginId"]) + "' " +
        //       "  ) " +
        //        "  , " +
        //        " ClassCount (classTotal,Name,Class_Id) " +
        //         " AS " +
        //          "  ( " +
        //           "  select COUNT(Distinct(CS.Mob_No)) as classTotal,IV.Name,CS.Class_Id from tblClassSetting CS inner join  tblItemValue IV " +
        //            " on CS.Class_Id= IV.ItemValueId where Login_Id='" + Convert.ToString(Session["LoginId"]) + "' GROUP BY IV.Name,CS.Class_Id " +
        //           " ) " +
        //           " SELECT Mob_No,[ClassSetting_id],[Session],[Semester],Class_Teacher,Batch,Class_Name,classTotal,Name " +
        //           " FROM AllData AD Join ClassCount CC ON AD.Class_Id = CC.Class_Id";

        Sql = "WITH AllData (Mob_No,[ClassSetting_id],[Session],[Semester],Class_Teacher,Batch,Class_Name,Class_Id) " +
             "AS " +
             "( " +
         " select DISTINCT(CS.Mob_No),CS.[ClassSetting_id],CS.[Session],CS.[Semester],CS.Class_Teacher,CS.Batch,IV.Name as Class_Name,CS.Class_Id " +
          " from tblClassSetting CS inner join  tblItemValue IV on CS.Class_Id= IV.ItemValueId where Login_Id='" + Convert.ToString(Session["LoginId"]) + "' " +
          "  ) " +
           "  , " +
           " StudentCount (StudentTotal,ClassSetting_id) " +
            " AS " +
             "  ( " +
              "   select COUNT(SR.[ClassSetting_id]) as StudentTotal,SR.[ClassSetting_id] from tblClassSetting CS inner join [tblStudentRegister] SR " +
               "    on CS.[ClassSetting_id]= SR.ClassSetting_id  where Login_Id='" + Convert.ToString(Session["LoginId"]) + "' GROUP BY SR.ClassSetting_id " +
              " ) " +
              " SELECT Mob_No,AD.[ClassSetting_id],[Session],[Semester],Class_Teacher,Batch,Class_Name,StudentTotal " +
              " FROM AllData AD LEFT JOIN StudentCount SC ON AD.ClassSetting_id = SC.ClassSetting_id ORDER BY AD.[ClassSetting_id] DESC ";

        //Per Class Student Count in IH LOgin 
        //        WITH ClassWiseCount (StudentTotal,[ClassSetting_id],Class_Id)
        //AS(
        //select COUNT(SR.[ClassSetting_id]) as StudentTotal,SR.[ClassSetting_id],CS.Class_Id
        //from tblClassSetting CS inner join [tblStudentRegister] SR 
        //on CS.[ClassSetting_id]= SR.ClassSetting_id 
        //where Login_Id='8605669442' GROUP BY SR.ClassSetting_id,CS.Class_Id 
        //)SELECT SUM(StudentTotal),Class_Id FROM ClassWiseCount GROUP BY Class_Id

        ds = cc.ExecuteDataset(Sql);
        gvclassSetting.DataSource = ds.Tables[0];
        gvclassSetting.DataBind();
    }

    public void Dateformat()
    {
        DateTime dt = DateTime.Now;
        DateTime SystemDate = Convert.ToDateTime(dt);
        EntryDate = SystemDate.ToString("dd'-'MM'-'yyyy''");
    }

    public void loadClass()
    {
        try
        {
            Sql = "select Name,ItemValueId from tblItemValue where ItemId=0 or ItemId=1 ";
            ds = cc.ExecuteDataset(Sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlClass.DataSource = ds.Tables[0];
                ddlClass.DataTextField = "Name";
                ddlClass.DataValueField = "ItemValueId";
                ddlClass.DataBind();
            }
        }
        catch (Exception)
        {

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string Id = Convert.ToString(lblId.Text);
            if (Id == "")
            {
                Addnew();
            }
            else
            {
                UpdateRecord(Id);
            }
        }
        catch
        {
        }
    }

    public void Addnew()
    {
        try
        {
            Sql = "select ClassSetting_id from tblClassSetting where  [Class_Id]=" + ddlClass.SelectedValue + " and   [Session]='" + ddlSession.SelectedItem.Text + "' and [Batch]='" + ddlBatch.SelectedItem.Text + "'  and Mob_No='" + txtMobNo.Text + "' and " +
                "  Login_Id='" + Convert.ToString(Session["LoginId"]) + "' ";

            string ClassSetting_id = Convert.ToString(cc.ExecuteScalar(Sql));
            if (ClassSetting_id == "")
            {

                Sql = "insert into tblClassSetting  ([Class_Id],   [Session],[Batch],[Semester], " +
                " [Class_Teacher],[Mob_No],[Email_Id],[CreateDate],[Login_Id]) " +
                    " values (" + ddlClass.SelectedValue + ", " +
                    " '" + ddlSession.SelectedItem.Text + "','" + ddlBatch.SelectedItem.Text + "','" + ddlSemester.SelectedItem.Text + "','" + txtClasTeach.Text + "' , " +
                    " '" + txtMobNo.Text + "' ,'" + txtEmailId.Text + "','" + EntryDate + "', '" + Convert.ToString(Session["LoginId"]) + "') ";
                status = cc.ExecuteNonQuery(Sql);
                if (status == 1)
                {
                    BindGrid();
                    clear();
                    lblError.Visible = true;
                    lblError.Text = "Record saved successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record saved successfully')", true);
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Record not saved successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record not saved successfully')", true);
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Record already  exist";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record already  exist')", true);
            }
        }
        catch
        {
        }
    }

    public void UpdateRecord(string Id)
    {
        try
        {
            Sql = "Update tblClassSetting set  [Class_Id]=" + ddlClass.SelectedValue + ",   [Session]='" + ddlSession.SelectedItem.Text + "',[Batch]='" + ddlBatch.SelectedItem.Text + "',[Semester]='" + ddlSemester.SelectedItem.Text + "', " +
            " [Class_Teacher]='" + txtClasTeach.Text + "',[Mob_No]='" + txtMobNo.Text + "' ,[Email_Id]='" + txtEmailId.Text + "',[CreateDate]='" + EntryDate + "',[Login_Id]='" + Convert.ToString(Session["LoginId"]) + "' where ClassSetting_id='" + Id + "' ";

            status = cc.ExecuteNonQuery(Sql);
            if (status == 1)
            {
                BindGrid();
                clear();
                lblError.Visible = true;
                lblError.Text = "Record updated successfully";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record updated successfully')", true);
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Record not updated successfully";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record not updated successfully')", true);
            }
        }
        catch
        {
        }
    }
    protected void gvclassSetting_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvclassSetting_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvclassSetting.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void gvclassSetting_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblId.Text = Convert.ToString(e.CommandArgument);
            string Id1 = lblId.Text;
            if (Convert.ToString(e.CommandName) == "Modify")
            {
                btnSave.Text = "Update";
                Sql = "select * from tblClassSetting where ClassSetting_id='" + lblId.Text + "' ";
                ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtClasTeach.Text = Convert.ToString(ds.Tables[0].Rows[0]["Class_Teacher"]);
                    txtMobNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mob_No"]);
                    txtEmailId.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email_Id"]);
                    ddlClass.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Class_Id"]);  // Clasname in andriod
                    ddlSemester.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["Semester"]);
                    ddlSession.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["Session"]);
                    ddlBatch.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["Batch"]);
                }
            }
            if (Convert.ToString(e.CommandName) == "RegisterStudent")
            {
                Response.Redirect("StudentRegister.aspx?Id=" + Id1);
            }
        }
        catch
        {
        }

    }

    public void clear()
    {
        try
        {
            txtClasTeach.Text = "";
            txtEmailId.Text = "";
            txtMobNo.Text = "";

            ddlClass.SelectedIndex = -1;

            ddlSemester.SelectedItem.Text = "--Select--";
            ddlSession.SelectedItem.Text = "--Select--";
            ddlBatch.SelectedItem.Text = "--Select--";
            btnSave.Text = "Submit";
            lblId.Text = "";
        }
        catch
        {
        }
    }

    protected void gvclassSetting_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvclassSetting_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void gvclassSetting_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}
