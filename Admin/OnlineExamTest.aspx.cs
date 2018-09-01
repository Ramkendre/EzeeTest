using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;

public partial class Admin_OnlineExamTest : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();    
    string Sql = "";    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                Sql = " drop view stud1";
                int i = cc.ExecuteNonQuery(Sql);
            }
            catch
            {
            }
            Sql = "CREATE   view [dbo].[stud1] as " +
 " Select ROW_NUMBER() OVER( ORDER BY Question_id) " +
 " EQID,Question_id,Question,QType,Answer1,AType,Answer2,BType,Answer3,CType,Answer4,DType,OptionE,EType,OptionP,PType,OptionQ,QType1,OptionR,RType,OptionS,SType,OptionT,TType,Passage,passageType,QuesWithImage,Q1Type,Qhint,hType,Correct_answer,QuestionLevel," +
 " SettingId,TypeOFExam,tblItemValue.Name as TypeofQues,Class_id,Subject_id,Chapter_id,Topic_id,UniqueId,LoginId,Test_ID,Image,MediumID," +
 " Sellanguage,userClass_id,userSubject_id,userChapter_id,userTopic_id,userCompitativeExam,TypeofMaterial,TypeofDB" +
 " from tblMahatetExamQuestionSet " +
 " inner join tblItemValue on tblItemValue.ItemValueId=tblMahatetExamQuestionSet.TypeofQues";

            int k = cc.ExecuteNonQuery(Sql);
            data();
        }
    }

    void data()
    {
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            string sql = "select EQID from stud1"; //where NewQID<=150";     //Question_id>=194 and Question_id<199";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Session["EQID"] = 1;      // lblLogin.Text;            
            lblQuesTo.Text = (ds.Tables[0].Rows.Count - 1).ToString();

            for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
            {
                Panel pnlQues = new Panel();
                //pnlQues.ID = "pnlQues" + (i + 1);
                pnlQues.ID = "pnlQues" + i;
                pnlQues.Width = 800;
                pnlQues.Wrap = true;
                pnlQues.Height = 400;
                pnlQues.Style.Add(HtmlTextWriterStyle.BackgroundColor, "White");
                pnlQues.ScrollBars = ScrollBars.Auto;
                pnlQues.Style.Add(HtmlTextWriterStyle.Display, "none");

                if (i == 0)
                    pnlQues.Style.Add(HtmlTextWriterStyle.Display, "block");
                else
                {
                    pnlQues.Style.Add(HtmlTextWriterStyle.Display, "none");                    
                }

                if (i == 0)
                {
                    Control ctl = LoadControl("../InstructionControl.ascx");  //?reqQid=" + ds.Tables[0].Rows[i]["Question_id"]);                
                    ctl.ID = "UC" + i;
                    pnlQues.Controls.Add(ctl);
                    this.UCPlaceHolder.Controls.Add(pnlQues);
                }
                else if (i == Convert.ToInt32(lblQuesTo.Text) + 1)
                {
                    Control ctl = LoadControl("../ExamReportControl.ascx");  //?reqQid=" + ds.Tables[0].Rows[i]["Question_id"]);                
                    ctl.ID = "UC_Finish";
                    pnlQues.Controls.Add(ctl);
                    this.UCPlaceHolder.Controls.Add(pnlQues);
                }
                else
                {
                    Control ctl = LoadControl("../ExamUserControl.ascx");  //?reqQid=" + ds.Tables[0].Rows[i]["Question_id"]);                
                    ctl.ID = "UC" + i;
                    pnlQues.Controls.Add(ctl);
                    this.UCPlaceHolder.Controls.Add(pnlQues);
                }                
            }
        }
        catch (Exception ex)
        { }
    }
}