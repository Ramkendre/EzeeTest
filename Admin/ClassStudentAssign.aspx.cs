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
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Admin_ClassStudentAssign : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    string Sql;
    int Status;
    string EntryDate = "";
    int Test_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_ID = Convert.ToInt32(Request.QueryString["Id"]);
        if (IsPostBack == false)
        {
            loadTestName(Test_ID);
            BindGrid(Test_ID);
            load();
        }
        Dateformat();
    }

    public void load()
    {
        if ((Convert.ToString(Session["LoginId"]) != null && Convert.ToString(Session["parentrole"]) == ""))
        {
            show();
        }
        else
        {
            LoadValue();
        }
    }
    private void show()
    {
        try
        {
            string Sql = "SELECT   Login.LoginId,Login.Active, Login.UserName,loginname, Login.Password, Login.ContactNo, " +
                " Login.Address, Login.DOJ, Login.Role, Login.CompanyId, Login.Active, " +
                " Role.RoleName, CompanyMaster.DisplayName  " +
                " FROM   Login INNER JOIN  " +
                " Role ON Login.Role = Role.RoleId INNER JOIN " +
                " CompanyMaster ON Login.CompanyId = CompanyMaster.CompanyId " +
                " inner join Admin_SubUser on Admin_SubUser.uid= login.uid  " +
                " where loginname='" + Convert.ToString(Session["LoginId"]) + "' and Login.Active=1 ";
                //" where Login.Active=1 " +

            Sql = Sql + " Order by loginname,CompanyMaster.DisplayName,Role.RoleName,Login.UserName";


            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                chkstudentlist.DataSource = ds.Tables[0];
                chkstudentlist.DataTextField = "UserName";
                chkstudentlist.DataValueField = "LoginId";
                chkstudentlist.DataBind();
            }
            else
            {
                chkstudentlist.DataSource = null;
                chkstudentlist.DataBind();

            }
        }
        catch (Exception ex)
        {

        }
    }
    private void LoadValue()
    {
        try
        {
            //string Sql = " SELECT   Login.LoginId, Login.UserName, Login.Password,role.parentrole, Login.ContactNo," +
            //             "Login.Address, Login.DOJ, Login.Role, Login.CompanyId, Login.Active,  Role.RoleName, CompanyMaster.DisplayName   FROM Login " +
            //             "  Left outer JOIN CompanyMaster ON Login.CompanyId = CompanyMaster.CompanyId " +
            //             "  INNER JOIN   Role ON Login.Role = Role.RoleId " +
            //             "  where Login.LoginId<>'" + Convert.ToString(Session["LoginId"]) + "' and parentrole='" + Convert.ToString(Session["Role"])+"' " +
            //             " Order by CompanyMaster.DisplayName,Role.RoleName,Login.UserName ";

            string Sql = "SELECT   Login.LoginId, Login.UserName,loginname, Login.Password,role.parentrole, " +
                 " Login.ContactNo,Login.Address, Login.DOJ, Login.Role, Login.CompanyId, Login.Active," +
                 " Role.RoleName, CompanyMaster.DisplayName   FROM Login   Left outer JOIN CompanyMaster " +
                 "ON Login.CompanyId = CompanyMaster.CompanyId " +
                 " Left outer JOIN   Role ON Login.Role = Role.RoleId  " +
                 " inner join Admin_SubUser on Admin_SubUser.uid= login.uid  ";

            if (Session["Role"].ToString() == "2" || Session["Role"].ToString() == "8") // change on 28.10.13
            {
                Sql = Sql + "where R1='Admin'";
            }
            else
            {

                Sql = Sql + "where loginname='" + Convert.ToString(Session["LoginId"]) + "' and  Login.Active=1 ";
            }

            Sql = Sql + " Order by loginname,CompanyMaster.DisplayName,Role.RoleName,Login.UserName";

            // string Sql = " select * from login inner join Admin_SubUser on Admin_SubUser.uid= login.uid  where username='" + Convert.ToString(Session["LoginId"]) + "'";

            //  string Sql = " select username from login inner join Admin_SubUser on login.uid=Admin_SubUser.uid  where loginname='" + Convert.ToString(Session["LoginId"]) + "' ";
            DataSet ds = cc.ExecuteDataset(Sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                chkstudentlist.DataSource = ds.Tables[0];
                chkstudentlist.DataTextField = "UserName";
                chkstudentlist.DataValueField = "LoginId";
                chkstudentlist.DataBind();
            }
            else
            {


            }
        }
        catch (Exception ex)
        {

        }
    }
    public void loadTestName(int testId)
    {
        //change on 12.12.13
        //string Sql = "select Test_ID,Exam_name from tblTestDefinition where LoginId ='" + Convert.ToString(Session["LoginId"]) + "' and Test_ID=" + Test_ID + " ";
        string Sql = "select Test_ID,Exam_name from tblTestDefinition where  Test_ID=" + Test_ID + " ";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblTestname.Text =Convert.ToString(ds.Tables[0].Rows[0]["Exam_name"]);
            
            //chkTest.DataSource = ds.Tables[0];
            //chkTest.DataTextField = "Exam_name";
            //chkTest.DataValueField = "Test_ID";
            //chkTest.DataBind();
        }
    }
    public void Dateformat()
    {
        DateTime dt = DateTime.Now;
        DateTime SystemDate = Convert.ToDateTime(dt);
        EntryDate = SystemDate.ToString("yyyy'-'MM'-'dd''");
    }

    protected void btnStart_Click(object sender, EventArgs e)
    {
        string Id = Convert.ToString(lblId.Text.ToString());
        if (Id == "" || Id == null)
        {
            AddNewInsert();
        }
        else
        {
            Updated(Id);
            btnStart.Text = "Submit";
        }
        clear();
    }
    public void AddNewInsert()
    {
        try
        {


            //string TestName = "", Test_ID = "";
            //for (int c = 0; c < chkTest.Items.Count; c++)
            //{
            //    if (chkTest.Items[c].Selected == true)
            //    {
            //        Test_ID = Test_ID + "," + chkTest.Items[c].Value;
            //        TestName = TestName + "," + chkTest.Items[c].Text;

            //    }
            //}
            //if (Test_ID.Length > 1)
            //{
            //    Test_ID = Test_ID.Substring(1);
            //}
            //if (TestName.Length > 1)
            //{
            //    TestName = TestName.Substring(1);
            //}

            for (int c = 0; c < chkstudentlist.Items.Count; c++)
            {
                if (chkstudentlist.Items[c].Selected == true)
                {
                    Sql = "select ATStudent_ID from tblAssignTestToStudent where StudentMobileNo='" + chkstudentlist.Items[c].Value + "' and Test_ID in ('" + Test_ID + "') and LoginID='" + Convert.ToString(Session["Loginid"]) + "' ";
                    string SNO = Convert.ToString(cc.ExecuteScalar(Sql));
                    if (SNO != "")
                    {
                        lblError.Text = "Sorry This Test Allready Assing !!";
                        lblError.Visible = true;
                        //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry This Mobile Number Already Exist !!')", true);

                    }
                    else
                    {

                        Sql = "select ATStudent_ID from tblAssignTestToStudent where (StudentMobileNo='" + chkstudentlist.Items[c].Value + "' or Test_ID in ('" + Test_ID + "')) and (StudentMobileNo='" + chkstudentlist.Items[c].Value + "' and Test_ID in ('" + Test_ID + "')) and LoginID='" + Convert.ToString(Session["Loginid"]) + "' ";
                        SNO = Convert.ToString(cc.ExecuteScalar(Sql));
                        if (SNO != "")
                        {
                            lblError.Text = "Sorry This Test Allready Assing !!";
                            lblError.Visible = true;
                            // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry This Mobile Number Already Exist !!')", true);

                        }
                        else
                        {

                            Sql = "insert into tblAssignTestToStudent(StudentMobileNo,TestName,Test_ID,createdate,LoginID,StudentName)" +
                                " values('" + chkstudentlist.Items[c].Value + "','" + lblTestname.Text + "','" + Test_ID + "','" + EntryDate + "','" + Convert.ToString(Session["Loginid"]) + "','" + chkstudentlist.Items[c].Text + "' )";
                            Status = cc.ExecuteNonQuery(Sql);
                            if (Status == 1)
                            {
                                BindGrid(Test_ID);
                                lblError.Text = "Record Added Successfully";
                                lblError.Visible = true;
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Added Successfully')", true);

                            }
                            else
                            {
                                lblError.Text = "Record Not Added ";
                                lblError.Visible = true;
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Not Added ')", true);

                            }
                        }

                    }
                }
            }
            BindGrid(Test_ID);
        }
        catch (Exception ex)
        {
        }
    }

    public void Updated(string Id)
    {
        try
        {


            //string TestName = "", Test_ID = "";
            //for (int c = 0; c < chkTest.Items.Count; c++)
            //{
            //    if (chkTest.Items[c].Selected == true)
            //    {
            //        Test_ID = Test_ID + "," + chkTest.Items[c].Value;
            //        TestName = TestName + "," + chkTest.Items[c].Text;

            //    }
            //}
            //if (Test_ID.Length > 1)
            //{
            //    Test_ID = Test_ID.Substring(1);
            //}
            //if (TestName.Length > 1)
            //{
            //    TestName = TestName.Substring(1);
            //}

            for (int c = 0; c < chkstudentlist.Items.Count; c++)
            {
                if (chkstudentlist.Items[c].Selected == true)
                {
                    Sql = "select ATStudent_ID from tblAssignTestToStudent where StudentMobileNo='" + chkstudentlist.Items[c].Value + "' and Test_ID in ('" + Test_ID + "') and LoginID='" + Convert.ToString(Session["Loginid"]) + "' and ATStudent_ID <> " + Id + " ";
                    string SNO = Convert.ToString(cc.ExecuteScalar(Sql));
                    if (SNO != "")
                    {
                        lblError.Text = "Sorry This Test Allready Assing !!";
                        lblError.Visible = true;
                        // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry This Mobile Number Already Exist !!')", true);

                    }
                    else
                    {

                        Sql = "Update tblAssignTestToStudent set StudentMobileNo='" + chkstudentlist.Items[c].Value + "',TestName='" + lblTestname.Text + "',Test_ID='" + Test_ID + "',createdate='" + EntryDate + "',LoginID='" + Convert.ToString(Session["Loginid"]) + "',StudentName='" + chkstudentlist.Items[c].Text + "'  where ATStudent_ID = " + Id + " ";
                        Status = cc.ExecuteNonQuery(Sql);
                        if (Status == 1)
                        {
                            BindGrid(Test_ID);
                            lblError.Text = "Record Updated Successfully";
                            lblError.Visible = true;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Updated Successfully')", true);

                        }
                        else
                        {
                            lblError.Text = "Record Not Updated ";
                            lblError.Visible = true;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Not Updated ')", true);

                        }

                    }
                }


            }
            BindGrid(Test_ID);
        }
        catch (Exception ex)
        {
        }
    }


    public void BindGrid(int testId)
    {
        Sql = "select * from tblAssignTestToStudent where LoginID='" + Convert.ToString(Session["Loginid"]) + "' and Test_ID=" + testId + " ";
        ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvStudentAssignList.DataSource = ds.Tables[0];
            gvStudentAssignList.DataBind();
        }

    }
    protected void gvStudentAssignList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
        chkstudentlist.ClearSelection();
        ChkSelectALL.Checked = false;
        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;
        if (Convert.ToString(e.CommandName) == "Modify")
        {
            btnStart.Text = "Update";
            Sql = "Select StudentMobileNo,StudentName,TestName,Test_ID from tblAssignTestToStudent where ATStudent_ID=" + Convert.ToInt32(lblId.Text) + " and LoginID='" + Convert.ToString(Session["Loginid"]) + "' ";
            try
            {
                ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    lblTestname.Text = Convert.ToString(ds.Tables[0].Rows[0]["TestName"]);

                    //for (int c = 0; c < chkTest.Items.Count; c++)
                    //{
                    //    if (a.Contains(chkTest.Items[c].Value.ToString()))
                    //    {
                    //        chkTest.Items[c].Selected = true;
                    //    }
                    //}

                    string b = Convert.ToString(ds.Tables[0].Rows[0]["StudentMobileNo"]);
                    for (int c = 0; c < chkstudentlist.Items.Count; c++)
                    {
                        if (b.Contains(chkstudentlist.Items[c].Value.ToString()))
                        {
                            chkstudentlist.Items[c].Selected = true;
                        }
                    }
                }
            }
            catch
            {
            }

        }

        if (Convert.ToString(e.CommandName) == "Delete")
        {
            Sql = "delete from tblAssignTestToStudent where ATStudent_ID=" + Convert.ToInt32(lblId.Text) + " and LoginID='" + Convert.ToString(Session["Loginid"]) + "' ";
            try
            {
                 Status = cc.ExecuteNonQuery(Sql);
                 if (Status == 1)
                 {
                     BindGrid(Test_ID);
                     lblError.Text = "Record Deleted Successfully";
                     lblError.Visible = true;
                     ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Deleted Successfully')", true);
                   
                 }
                 else
                 {
                     lblError.Text = "Record Not Deleted";
                     lblError.Visible = true;
                     ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Not Deleted')", true);
                 }
               
            }
            catch (Exception ex)
            {
            }


        }


    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        clear();
    }

    private void clear()
    {

        for (int c = 0; c < chkstudentlist.Items.Count; c++)
        {
            if (chkstudentlist.Items[c].Selected = true)
            {
                chkstudentlist.Items[c].Selected = false;
            }
        }
        //for (int c = 0; c < chkTest.Items.Count; c++)
        //{
        //    if (chkTest.Items[c].Selected = true)
        //    {
        //        chkTest.Items[c].Selected = false;
        //    }
        //}

        lblId.Text = "";
    }
    protected void ChkSelectALL_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkSelectALL.Checked == true)
        {
            foreach (ListItem li in chkstudentlist.Items)
            {
                li.Selected = true;
            }
        }
        else
        {
            foreach (ListItem li in chkstudentlist.Items)
            {
                li.Selected = false;

            }
        }
    }
    protected void gvStudentAssignList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    //getting username from particular row
        //    string username = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Name"));
        //    //identifying the control in gridview
        //    //raising javascript confirmationbox whenver user clicks on link button 
        //    ImageButton btnimg = (ImageButton)e.Row.FindControl("ImageButton2");
        //    btnimg.Attributes.Add("onclick", "javascript:return ConfirmationBox('" + username + "')");

        //}
    }
    protected void gvStudentAssignList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStudentAssignList.PageIndex = e.NewPageIndex;
        BindGrid(Test_ID);
    }
}
