using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Andorid_Class_App_AttendanceReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string Sql = "";
    int Pcount = 0, Acount = 0;
    DataSet ds = new DataSet();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadDetails();
        }

    }



    protected void ddlsearchby_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlsearchby.SelectedValue == "0")
            {
                // Tr_date.Visible = true;
                Tr_stud.Visible = false;
                gvAttendanceReport.DataSource = null;
                gvAttendanceReport.DataBind();
                divHData.Visible = false;

            }
            else if (ddlsearchby.SelectedValue == "1")
            {
                // Tr_date.Visible = false;
                Tr_stud.Visible = true;
                BindStudentName();
                gvAttendanceReport.DataSource = null;
                gvAttendanceReport.DataBind();

            }
        }
        catch
        {
        }
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
        catch
        {

        }

    }

  
    int tempcount=0;

    public void bindgrid()
    {
        Sql = ";with T as  (  select A.SNO,[Present],[attenDate] ,CompanyMaster.DisplayName,   R.First_Name+' '+R.Father_Name+' '+R.Last_Name  as name  from [tblAttendance]as A inner join tblStudentRegister as R on A.[StudentRegSNO] =R.SNO  and A.[ClassSetting_id]= R.ClassSetting_id  inner join Login on  A.LoginId=Login.LoginId   inner join CompanyMaster on CompanyMaster.CompanyId=Login.CompanyId   where [attenDate] between  '" + txtfromdate.Text + "' and '" + txtTodate.Text + "' and  A.LoginId='" + Convert.ToString(Session["LoginId"]) + "' and A.ClassSetting_id=(select ClassSetting_id from tblClassSetting where Class_Id='" + ddlClass.SelectedValue + "' and  Batch='" + ddlBatch.SelectedItem.Text + "' and  Session='" + ddlSession.SelectedItem.Text + "' and Login_Id='" + Convert.ToString(Session["LoginId"]) + "')     )   select *,count(name) over(partition by name)as count1  from T   ";
        DataTable dt = new DataTable();
        if (ddlsearchby.SelectedValue == "0")
        {
            //select * from [tblStudentFees] where feesdate between '2014-04-12' and '2014-04-29'
            string dsaf = txtfromdate.Text;
            string dz = txtTodate.Text;
            divHData.Visible = false;
            Sql = Sql + "   order by  name,[attenDate] asc ";

            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {

                Sql = ";with T as  (  select A.SNO,[Present],[attenDate] ,CompanyMaster.DisplayName,   R.First_Name+' '+R.Father_Name+' '+R.Last_Name  as name  from [tblAttendance]as A inner join tblStudentRegister as R on A.[StudentRegSNO] =R.SNO  and A.[ClassSetting_id]= R.ClassSetting_id  inner join Login on  A.LoginId=Login.LoginId   inner join CompanyMaster on CompanyMaster.CompanyId=Login.CompanyId   where [attenDate] between  '" + txtfromdate.Text + "' and '" + txtTodate.Text + "' and  A.LoginId='" + Convert.ToString(Session["LoginId"]) + "' and A.ClassSetting_id=(select ClassSetting_id from tblClassSetting where Class_Id='" + ddlClass.SelectedValue + "' and  Batch='" + ddlBatch.SelectedItem.Text + "' and  Session='" + ddlSession.SelectedItem.Text + "' and Login_Id='" + Convert.ToString(Session["LoginId"]) + "')     )    select name as distingName from T group by name order by name asc   ";
                DataSet dstemp = new DataSet();
                dstemp = cc.ExecuteDataset(Sql);

                dt.Columns.Add("SNO");
                dt.Columns.Add("name");
                dt.Columns.Add("Present1");
                dt.Columns.Add("Absent1");

                for (int j = 0; j < dstemp.Tables[0].Rows.Count; j++)
                {
                    tempcount++;
                    string distingName = Convert.ToString(dstemp.Tables[0].Rows[j]["distingName"]);

                    DataRow[] dr = ds.Tables[0].Select("name='" + distingName + "'");

                    for (int i = 0; i < dr.Length; i++)
                    {
                        string Present = Convert.ToString(dr[i]["Present"]);
                        if (Present == "P")
                            Pcount++;
                        else if (Present == "A")
                            Acount++;

                    }
                    string name1 = Convert.ToString(dr[0]["name"]);
                    string Present1 = Convert.ToString(Pcount);
                    string Absent1 = Convert.ToString(Acount);

                    DataRow dtrow = dt.NewRow(); //hahfsjkhkjfas

                    dtrow["SNO"] = tempcount;
                    dtrow["name"] = name1;
                    dtrow["Present1"] = Present1;
                    dtrow["Absent1"] = Absent1;

                    dt.Rows.Add(dtrow);
                    Pcount = 0;
                    Acount = 0;


                }

                gvAttendanceReport.Columns[1].Visible = true;
                gvAttendanceReport.Columns[2].Visible = false;
                gvAttendanceReport.Columns[3].Visible = false;
                tr_DStudentname.Visible = false;
                gvAttendanceReport.Columns[4].Visible = true;
                gvAttendanceReport.Columns[5].Visible = true;
               

                gvAttendanceReport.DataSource = dt;
                gvAttendanceReport.DataBind();

                
            }
        }
        else if (ddlsearchby.SelectedValue == "1" && ddlStudent.SelectedItem.Text != "--Select--") // student
        {


            // Sql = "with T as  (  select [Present],[attenDate] ,   R.First_Name+' '+R.Father_Name+' '+R.Last_Name  as name  from [tblAttendance]as A inner join tblStudentRegister as R on A.[StudentRegSNO] =R.SNO  and A.[ClassSetting_id]= R.ClassSetting_id   where [attenDate] between  '2014-04-13' and '2014-04-14'    )  select * from T where name='asd sdgsdg dsgfdsfg' order by name asc ";
            //Sql = ";with T as  (  select A.SNO,[Present],[attenDate] ,CompanyMaster.DisplayName,   R.First_Name+' '+R.Father_Name+' '+R.Last_Name  as name  from [tblAttendance]as A inner join tblStudentRegister as R on A.[StudentRegSNO] =R.SNO  and A.[ClassSetting_id]= R.ClassSetting_id  inner join Login on  A.LoginId=Login.LoginId   inner join CompanyMaster on CompanyMaster.CompanyId=Login.CompanyId   where [attenDate] between  '" + txtfromdate.Text + "' and '" + txtTodate.Text + "' and  A.LoginId='" + Convert.ToString(Session["LoginId"]) + "' and A.ClassSetting_id=(select ClassSetting_id from tblClassSetting where Class_Id='" + ddlClass.SelectedValue + "' and  Batch='" + ddlBatch.SelectedItem.Text + "' and  Session='" + ddlSession.SelectedItem.Text + "' and Login_Id='" + Convert.ToString(Session["LoginId"]) + "')     )  select * from T where name='" + ddlStudent.SelectedItem.Text + "' order by attenDate asc  ";

            Sql = Sql + " where name='" + ddlStudent.SelectedItem.Text + "' order by attenDate asc ";

            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvAttendanceReport.Columns[1].Visible = false;
                gvAttendanceReport.Columns[2].Visible = true;
                gvAttendanceReport.Columns[3].Visible = true;
                gvAttendanceReport.Columns[4].Visible = false;
                gvAttendanceReport.Columns[5].Visible = false;
                tr_DStudentname.Visible = true;
                divHData.Visible = true;

                lblDStudentName.Text = ddlStudent.SelectedItem.Text;


                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string temp = Convert.ToString(ds.Tables[0].Rows[i]["Present"]);
                    if (temp == "P")
                    {
                        Pcount++;
                    }
                    else if (temp == "A")
                    {
                        Acount++;
                    }
                }

                lblHPDay.Text = "Total Present days: " + Convert.ToString(Pcount);
                lblHADay.Text = "Total Absent Days: " + Convert.ToString(Acount);
               // lblHTotalDay.Text = "Attendance From: " + txtfromdate.Text + " To " + txtTodate.Text;
                gvAttendanceReport.DataSource = ds.Tables[0];
                gvAttendanceReport.DataBind();
            }

        }



        if (ds.Tables[0].Rows.Count > 0)
        {
            DateTime dt1 = Convert.ToDateTime(txtfromdate.Text);           
           string  fromdate =dt1.ToString("dd'-'MM'-'yyyy''");
           DateTime dt2 = Convert.ToDateTime(txtTodate.Text);
           string Todate = dt2.ToString("dd'-'MM'-'yyyy''");
           lblDDate.Text = "Attendance Date : " + fromdate + " To " + Todate;

            lblDschoolname.Text = Convert.ToString(ds.Tables[0].Rows[0]["DisplayName"]);
            lblDClass.Text = "Class: " + Convert.ToString(ddlClass.SelectedItem.Text);
            lblDSession.Text = "Session: " + Convert.ToString(ddlSession.SelectedItem.Text);
            lblDBatch.Text = "Batch: " + Convert.ToString(ddlBatch.SelectedItem.Text);
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

    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if ((ddlClass.SelectedItem.Text == "--Select--") || (ddlBatch.SelectedItem.Text == "--Select--"))
            {
                pnl1.Visible = false;
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
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if ((ddlClass.SelectedItem.Text == "--Select--") || (ddlBatch.SelectedItem.Text == "--Select--") || (ddlSession.SelectedItem.Text == "--Select--"))
            {
                pnl1.Visible = false;
                lblError.Visible = true;
                lblError.Text = "Please select all field !!";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select all field !!')", true);
            }
            else
            {
                pnl1.Visible = true;
            }
        }
        catch
        {
        }
    }
    public void BindStudentName()
    {

        Sql = " select distinct tblStudentRegister.First_Name+' '+tblStudentRegister.Father_Name+' '+tblStudentRegister.Last_Name  as name " +
          " from [tblAttendance] inner join tblStudentRegister on [tblAttendance].[StudentRegSNO] =tblStudentRegister.SNO " +
           " and [tblAttendance].[ClassSetting_id]= tblStudentRegister.ClassSetting_id " +
           "  where  tblAttendance.[LoginId]='" + Convert.ToString(Session["LoginId"]) + "' and tblAttendance.ClassSetting_id=(select ClassSetting_id from tblClassSetting where Class_Id='" + ddlClass.SelectedValue + "' and  Batch='" + ddlBatch.SelectedItem.Text + "' and  Session='" + ddlSession.SelectedItem.Text + "' and Login_Id='" + Convert.ToString(Session["LoginId"]) + "') order by name asc ";
        ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlStudent.DataSource = ds.Tables[0];
            ddlStudent.DataTextField = "name";
            ddlStudent.DataBind();
            ddlStudent.Items.Add("--Select--");
            ddlStudent.SelectedIndex = ddlStudent.Items.Count - 1;

        }
        else
        {
            ddlStudent.Items.Clear();
        }
    }

}