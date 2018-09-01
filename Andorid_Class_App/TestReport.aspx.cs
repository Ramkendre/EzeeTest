using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Andorid_Class_App_TestReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    string Sql;
    int count;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadDetails();
        }

    }


    protected void ddlsearchby_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            if (ddlsearchby.SelectedValue == "1") //test
            {
                Tr_test.Visible = true;
                Tr_stud.Visible = false;
                gvTestReport.DataSource = null;
                gvTestReport.DataBind();
                bindTest();

            }
            else if (ddlsearchby.SelectedValue == "2")
            {
                Tr_test.Visible =false;
                Tr_stud.Visible = true;

                gvTestReport.DataSource = null;
                gvTestReport.DataBind();
                BindStudentName();
            }

        }
        catch
        {
        }
    }

    public void bindTest()
    {
        Sql = "select distinct TestNo,TestName from tblAndroidTestDetails where LoginId='" + Convert.ToString(Session["LoginId"]) + "' and ClassSetting_id=(select ClassSetting_id from tblClassSetting where Class_Id='" + ddlClass.SelectedValue + "' and  Batch='" + ddlBatch.SelectedItem.Text + "' and  Session='" + ddlSession.SelectedItem.Text + "' and Login_Id='" + Convert.ToString(Session["LoginId"]) + "') ";
        ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddltest.DataSource = ds.Tables[0];
            ddltest.DataTextField = "TestName";
            ddltest.DataValueField = "TestNo";
            ddltest.DataBind();
            ddltest.Items.Add("--Select--");
            ddltest.SelectedIndex = ddltest.Items.Count - 1;
        }

       
    }

    public void BindStudentName()
    {

        Sql = " select distinct tblAndroidTestDetails.StudentRegSNO, tblStudentRegister.First_Name+' '+tblStudentRegister.Father_Name+' '+tblStudentRegister.Last_Name as name from tblStudentRegister inner join  tblAndroidTestDetails " +
    " on tblAndroidTestDetails.StudentRegSNO=tblStudentRegister.SNO "+
    "  where  tblAndroidTestDetails.LoginId='" + Convert.ToString(Session["LoginId"]) + "'  and tblAndroidTestDetails.ClassSetting_id=(select ClassSetting_id from tblClassSetting where Class_Id='" + ddlClass.SelectedValue + "' and  Batch='" + ddlBatch.SelectedItem.Text + "' and  Session='" + ddlSession.SelectedItem.Text + "' and Login_Id='" + Convert.ToString(Session["LoginId"]) + "') order by name asc ";
  

        ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlStudent.DataSource = ds.Tables[0];
            ddlStudent.DataTextField = "name";
            ddlStudent.DataValueField = "StudentRegSNO";
            ddlStudent.DataBind();
            ddlStudent.Items.Add("--Select--");
            ddlStudent.SelectedIndex = ddlStudent.Items.Count - 1;

        }
        else
        {
            ddlStudent.Items.Clear();
        }
    }

    public void loadDetails()
    {
        try
        {
            Sql = "select distinct Class_Id,Name from  tblClassSetting inner join tblItemValue on tblClassSetting.Class_Id=tblItemValue.ItemValueId  where Login_Id='" + Convert.ToString(Session["LoginId"]) + "' ";
            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlClass.DataSource = ds.Tables[0];
                ddlClass.DataTextField = ds.Tables[0].Columns["Name"].ToString();
                ddlClass.DataValueField = ds.Tables[0].Columns["Class_Id"].ToString();
                ddlClass.DataBind();
                ddlClass.Items.Add("--Select--");
                ddlClass.SelectedIndex = ddlClass.Items.Count - 1;
            }
        }
        catch
        {

        }
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClass.SelectedItem.Text == "--Select--")
        {
            ddlBatch.Items.Clear();
            ddlSession.Items.Clear();
            ddlStudent.Items.Clear();
        }
        else
        {
            Sql = "select distinct Batch from  tblClassSetting  where Login_Id='" + Convert.ToString(Session["LoginId"]) + "' and Class_Id=" + ddlClass.SelectedValue + " ";
            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlBatch.DataSource = ds.Tables[0];
                ddlBatch.DataTextField = ds.Tables[0].Columns["Batch"].ToString();
                ddlBatch.DataBind();
                ddlBatch.Items.Add("--Select--");
                ddlBatch.SelectedIndex = ddlBatch.Items.Count - 1;
            }
        }



    }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if ((ddlClass.SelectedItem.Text == "--Select--") || (ddlBatch.SelectedItem.Text == "--Select--"))
            {
             
                ddlSession.Items.Clear();
                ddlStudent.Items.Clear();
                lblError.Visible = true;
                lblError.Text = "Please select all field !!";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select all field !!')", true);
            }
            else
            {
                Sql = "select distinct Session from  tblClassSetting  where Login_Id='" + Convert.ToString(Session["LoginId"]) + "' and Batch='" + ddlBatch.SelectedValue + "' ";
                ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlSession.DataSource = ds.Tables[0];
                    ddlSession.DataTextField = ds.Tables[0].Columns["Session"].ToString();
                    ddlSession.DataBind();
                    ddlSession.Items.Add("--Select--");
                    ddlSession.SelectedIndex = ddlSession.Items.Count - 1;
                }
            }
        }
        catch
        {
        }
    }

    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if ((ddlClass.SelectedItem.Text == "--Select--") || (ddlBatch.SelectedItem.Text == "--Select--") || (ddlSession.SelectedItem.Text == "--Select--"))
            {
               
                lblError.Visible = true;
                lblError.Text = "Please select all field !!";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select all field !!')", true);
            }
            else
            {
               
            }
        }
        catch
        {
        }
    }
  
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlBatch.SelectedItem.Text == "--Select--")
            {
                lblError.Visible = true;
                lblError.Text = "Please select Batch";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select Batch!!!!')", true);


            }
            else if (ddlSession.SelectedItem.Text == "--Select--")
            {
                lblError.Visible = true;
                lblError.Text = "Please select Session";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select Session!!!!')", true);

            }
            else
            {

                bindgrid();
            }
        }
        catch (Exception ex)
        {

        }

    }

    public void bindgrid()
    {
        if (ddlsearchby.SelectedValue == "1")  // test 
        {

            Sql = " select [TestName] ,[OutofMark] ,[ObtainedMark],[Testdate],  cast( (1.*[ObtainedMark]/[OutofMark] ) * 100 as decimal(5,2)) as perc, tblAndroidTestDetails.StudentRegSNO, tblStudentRegister.First_Name+' '+tblStudentRegister.Father_Name+' '+tblStudentRegister.Last_Name as name from tblStudentRegister inner join  tblAndroidTestDetails " +
         " on tblAndroidTestDetails.StudentRegSNO=tblStudentRegister.SNO " +
         "  where [TestNo]='"+ddltest.SelectedValue+"' and  tblAndroidTestDetails.LoginId='" + Convert.ToString(Session["LoginId"]) + "'  and tblAndroidTestDetails.ClassSetting_id=(select ClassSetting_id from tblClassSetting where Class_Id='" + ddlClass.SelectedValue + "' and  Batch='" + ddlBatch.SelectedItem.Text + "' and  Session='" + ddlSession.SelectedItem.Text + "' and Login_Id='" + Convert.ToString(Session["LoginId"]) + "') order by name asc ";
            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
              

                gvTestReport.Columns[1].Visible = false; // test name
                gvTestReport.Columns[3].Visible = true;  // stud name
                gvTestReport.Columns[4].Visible = true;  //out of mark
                gvTestReport.Columns[2].Visible = false;  // date
                
                tr_DStudentname.Visible = false;
                tr_D_TestnameDate.Visible = true;
                lblDTestname.Visible = true;
                lblDtestDate.Visible = true;
               // tr_D_outAvg.Visible = true;
                //lblDOutofmark.Visible = true;
               // lblDAvgMark.Visible = false;

                lblDTestname.Text = " Test name : " + Convert.ToString(ds.Tables[0].Rows[0]["TestName"]);
                lblDtestDate.Text = "Test Date : " + Convert.ToString(ds.Tables[0].Rows[0]["Testdate"]);
              //  lblDOutofmark.Text = "Total Marks : " + Convert.ToString(ds.Tables[0].Rows[0]["OutofMark"]);
            }
        }
        else if (ddlsearchby.SelectedValue == "2" && ddlStudent.SelectedItem.Text != "--Select--") // student
        {


            Sql = " ;with   T as ( select [TestTopic] ,[TestName] ,[OutofMark] ,[ObtainedMark],[Testdate],   cast(1.*[ObtainedMark]/[OutofMark] *100 as decimal(5,2)) as perc  ,tblStudentRegister.First_Name+' '+tblStudentRegister.Father_Name+' '+tblStudentRegister.Last_Name as name from tblStudentRegister inner join  tblAndroidTestDetails " +
               " on tblAndroidTestDetails.StudentRegSNO=tblStudentRegister.SNO " +
               "  where [StudentRegSNO]='"+ddlStudent.SelectedValue+"' and   tblAndroidTestDetails.LoginId='" + Convert.ToString(Session["LoginId"]) + "'  and tblAndroidTestDetails.ClassSetting_id=(select ClassSetting_id from tblClassSetting where Class_Id='" + ddlClass.SelectedValue + "' and  Batch='" + ddlBatch.SelectedItem.Text + "' and  Session='" + ddlSession.SelectedItem.Text + "' and Login_Id='" + Convert.ToString(Session["LoginId"]) + "')  "+
            " )select T.* from T order by [Testdate] asc   ";

            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
               

                gvTestReport.Columns[1].Visible = true; // test name
                gvTestReport.Columns[3].Visible = false;  // stud name
                gvTestReport.Columns[4].Visible = true;  //out of mark
                gvTestReport.Columns[2].Visible = true;

                tr_DStudentname.Visible = true;
                lblDStudentName.Text = ddlStudent.SelectedItem.Text;


                //gvTestReport.Columns[1].Visible = true; // test name
                //gvTestReport.Columns[2].Visible = false;  // stud name
                //gvTestReport.Columns[3].Visible = true;  //out of mark
                //gvTestReport.Columns[6].Visible = true;  // date

              
                tr_D_TestnameDate.Visible = false;
              
                //tr_D_outAvg.Visible = true;
                //lblDOutofmark.Visible = false;
                
               // lblDAvgMark.Visible = true;

               // lblDAvgMark.Text = " Average Percentage : " + Convert.ToString(ds.Tables[0].Rows[0]["avgperc"]);
              

            }

        }



        if (ds.Tables[0].Rows.Count > 0)
        {
            gvTestReport.DataSource = ds.Tables[0];
            gvTestReport.DataBind();
            lblDschoolname.Text = Convert.ToString(Session["DisplayName"]);
            lblDClass.Text = "Class: " + Convert.ToString(ddlClass.SelectedItem.Text);
            lblDSession.Text = "Session: " + Convert.ToString(ddlSession.SelectedItem.Text);
            lblDBatch.Text = "Batch: " + Convert.ToString(ddlBatch.SelectedItem.Text);
        }


    }
}