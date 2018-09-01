using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_DefaultTest : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string Sql = "";
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
        }
    }
    protected void btnStart_Click(object sender, EventArgs e)
    {

    }
    
    protected void txtTestID_TextChanged(object sender, EventArgs e)
    {
        if (txtTestID.Text != "")
        {
            int id=Convert.ToInt32(txtTestID.Text);
            Sql = "select  Test_ID,Exam_name,LoginId from tblTestDefinition where Test_ID=" + id + " and LoginId<>'' ";
            ds = cc.ExecuteDataset(Sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lbltestName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Exam_name"]);
                lblLoginID.Text = Convert.ToString(ds.Tables[0].Rows[0]["LoginId"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Test is not Available or It  may be Defualt Test already')", true);
                clear();
            }
        }
    }
    protected void btnStart_Click1(object sender, EventArgs e)
    {
        try
        {
            string MainLoginId = Convert.ToString(Session["LoginId"]);
            if (txtTestID.Text != "" && lbltestName.Text != "" && txtcompanyid.Text != "")
            {

                string oldname = "tbl" + txtcompanyid.Text; //+ "" + txtTestID.Text;
                Sql = "select top 1 *  from " + oldname + " ";
                ds = cc.ExecuteDataset(Sql);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    Sql = "select SNO from tblDefaultTest where TestID='" + txtTestID.Text + "' ";
                    string sno = cc.ExecuteScalar(Sql);

                    if (sno == "")
                    {
                        Sql = "insert into tblDefaultTest(TestID,TestName,TestCreateLogin,MainLoginId,UserType) values('" + txtTestID.Text + "','" + lbltestName.Text + "','" + lblLoginID.Text + "','" + MainLoginId + "','" + ddluserType.SelectedValue + "')";
                        int status = cc.ExecuteNonQuery(Sql);
                        if (status == 1)
                        {
                            //Below Change to be done byme on dated 20.02.2015
                            //Sql = " update tblTestDefinition set LoginId='' where Test_ID='" + txtTestID.Text + "' ";
                                                        
                            Sql =  "insert into tblAssignTestToStudent([TestName],[StudentMobileNo],[Test_ID],[createdate],[LoginID],UserType)values " +
                                 " ('" + lbltestName.Text + "','','" + txtTestID.Text + "','" + System.DateTime.Now + "','" + MainLoginId + "','" + ddluserType.SelectedValue + "') ";


                            //Sql = Sql + "insert into tblAssignTestToStudent([TestName],[StudentMobileNo],[Test_ID],[createdate],[LoginID],UserType)values " +
                            //     " ('" + lbltestName.Text + "','','" + txtTestID.Text + "','" + System.DateTime.Now + "','" + MainLoginId + "','" + ddluserType.SelectedValue + "') ";
                            
                            
                            status = cc.ExecuteNonQuery(Sql);


                            if (status == 2)
                            {
                                string newname = "tbl5119";// + txtTestID.Text;
                                oldname = "tbl" + txtcompanyid.Text;// +"" + txtTestID.Text;


                                Sql = "insert into tbl5119  (SNO,Question_id,Question,QType,Answer1,AType,Answer2,BType,Answer3,CType,Answer4,DType,OptionE,EType,OptionP,PType,OptionQ,QType1,OptionR,RType,OptionS,SType, " +
   " OptionT,TType,Passage,passageType,QuesWithImage,Q1Type,Qhint,hType,Correct_answer,QuestionLevel,MobileNo,SettingId,changeDate,Ischecked,TypeOFExam,TypeofQues,Class_id,  " +
 "  Subject_id,Chapter_id,Topic_id,QuesVerify,Suggestion,UploaderMoNo,UniqueId,DOUpload,LoginId,checkerLoginId,Test_ID,Image,MediumID,Sellanguage,userClass_id,userSubject_id,  " +
  " userChapter_id,userTopic_id,userCompitativeExam,TypeofMaterial,TypeofDB,examQwener,flag,createdate,UploadFileName,Class_AdmVerify,Class_AdmSuggest,Class_AdmLogin,TestID) " +

  " SELECT  SNO,Question_id,Question,QType,Answer1,AType,Answer2,BType,Answer3,CType,Answer4,DType,OptionE,EType,OptionP,PType,OptionQ,QType1,OptionR,RType,OptionS,SType, " +
  " OptionT,TType,Passage,passageType,QuesWithImage,Q1Type,Qhint,hType,Correct_answer,QuestionLevel,MobileNo,SettingId,changeDate,Ischecked,TypeOFExam,TypeofQues,Class_id, " +
  " Subject_id,Chapter_id,Topic_id,QuesVerify,Suggestion,UploaderMoNo,UniqueId,DOUpload,LoginId,checkerLoginId,Test_ID,Image,MediumID,Sellanguage,userClass_id,userSubject_id, " +
  " userChapter_id,userTopic_id,userCompitativeExam,TypeofMaterial,TypeofDB,examQwener,flag,createdate,UploadFileName,Class_AdmVerify,Class_AdmSuggest,Class_AdmLogin,'" + txtTestID.Text + "'  	FROM " + oldname + " ";
       


                                //Sql = "sp_rename '" + oldname + "' , '" + newname + "'";
                                int status1 = cc.ExecuteNonQuery(Sql);
                                if (status1 >0)
                                {
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('The Test is add as Default Test Successfully, Total No. of Question is "+status1+" ')", true);

                                }


                            }


                            clear();
                            bindgrid();
                        }
                    }
                }
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert(' error- "+ex.Message+"')", true);

        }
    }


    public void bindgrid()
    {
        Sql = "select * from tblDefaultTest ";
        ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvDefaultTest.DataSource = ds;
            gvDefaultTest.DataBind();
        }
    }

    public void clear()
    {
        txtcompanyid.Text = string.Empty;
        lblCompanyname.Text = string.Empty;
        txtTestID.Text = string.Empty;
        lbltestName.Text = string.Empty;
        lblLoginID.Text = string.Empty;

    }
    protected void gvDefaultTest_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string sno =Convert.ToString(e.CommandArgument);

        if (Convert.ToString(e.CommandName) == "Delete")
        {
            Sql = "delete from tblDefaultTest where SNO='" + sno + "' ";
            int status = cc.ExecuteNonQuery(Sql);

            bindgrid();
        }
    }
    protected void txtcompanyid_TextChanged(object sender, EventArgs e)
    {
        try
        {
            Sql = "select DisplayName from CompanyMaster where CompanyId='" + txtcompanyid.Text + "' ";
            string comanyname =Convert.ToString( cc.ExecuteScalar(Sql));
            if (comanyname != "")
            {
                lblCompanyname.Text = comanyname;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Company Name is not available')", true);
               txtcompanyid.Text = "";

            }
  
        }
        catch
        {
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
        
    }
    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        clear();
    }
}