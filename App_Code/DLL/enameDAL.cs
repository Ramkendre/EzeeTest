using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for enameDAL
/// </summary>
///


public class enameDAL
{
    // DataSet ds = new DataSet();
    int status;
    DataSet ds;
    //ExamnameBLL ebll = new ExamnameBLL();

    public enameDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public int addnew(ExamnameBLL ebal)
    {
        DataSet ds = new DataSet();
       // string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "Insert into tblExamName(examname,CompanyId,Class_id,Chapter_id,MediumID,TypeOfExam,Subject_id,Topic_id) Values ('" + ebal.Ename + "'," + Convert.ToInt32(ebal.Cid) + "," + Convert.ToInt32(ebal.Classid) + ",'" + ebal.Chapter_id + "','" + ebal.MediumID + "','" + ebal.TypeOfExam + "','" + ebal.Subject_id + "',"+ebal.Topic_id+") ";
                status = SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return status;
    }

    public int _update(ExamnameBLL ebal)
    {
      //  string abc = ";Initial Catalog = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))// using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        {
            try
            {
                string sql = "Update tblExamName set examname='" + Convert.ToString(ebal.Ename) + "',CompanyId='" + ebal.Cid + "',Class_id='" + ebal.Classid + "',Chapter_id ='" + ebal.Chapter_id + "' ,MediumID='" + ebal.MediumID + "',TypeOfExam='" + ebal.TypeOfExam + "',Subject_id='" + ebal.Subject_id + "' ,Topic_id="+ebal.Topic_id+"  where examid=" + ebal.Eid + "  ";
                status = SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return status;
    }

    public DataSet _selectExamnameDal(ExamnameBLL ebal)
    {
      //  string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
      //  using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        try
            {
                string sql = "  Select tblExamName.examid,examname,tblExamName.CompanyId ,tblExamName.Chapter_id,tblExamName.Topic_id,tblExamName.Class_id,tblExamName.Subject_id, tblExamName.MediumID,tblExamName.TypeOfExam from tblExamName  where tblExamName.examid=" + ebal.Eid + "";
                
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        return ds;
    }


    public int _deleteExamnameDal(ExamnameBLL ebal)
    {
      //  string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"])) 
        try
            {
                string sql = "Delete from tblExamName where examid=" + ebal.Eid + " ";
                status = SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql);
                return status;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

    }

    public DataSet DALGetAllEName()
    {
       // string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                // string Sql = "Select examid as Id, examname as Name from tblExamName ";

               // string Sql = "select tblExamName.examid as Id, tblExamName.examname as Name ,tblSubject.Subject_Name,tblClass.Class_Name,tblExamName.MediumID  , tblExamName.TypeOfExam from tblExamName,tblSubject,tblTopic,tblClass where tblSubject.Subject_id=tblExamName.Subject_id and tblExamName.Class_id=tblClass.Class_id and tblExamName.CompanyId=tblTopic.CompanyId and tblExamName.MediumID=tblTopic.MediumID ";
               // string Sql = "  select tblExamName.examid as Id, tblExamName.examname as Name from tblExamName";
                string Sql = "select examid as Id, examname as Name from tblExamName";

                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
        return ds;

    }

    public DataSet DALGetAllENamecid(int comid)
    {
       // string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string Sql = "Select examid as Id, examname as Name from tblExamName where CompanyId=" + comid + " ";
                // "select examname from tblExamName where CompanyId=" + (Convert.ToInt32(ddlCollege.SelectedValue.ToString())) + " order by examname";

                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;

    }


    // for select exam name by class name 
    public DataSet DALGetAllENameclassid(string examtype)
    {
       // string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
       // using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {


            
                if (examtype =="88")
                {
                    string Sql = "Select tblExamName.examid as Id ,tblExamName.examname ,tblItemValue1.Name as Class_id , " +
                        " tblItemValue2.Name as Topic_id,tblItemValue3.Name as Subject_id,tblExamName.MediumID  , " +
                        " tblItemValue4.Name as TypeOfExam ,tblItemValue5.Name  as Chapter_id " +
                        " from tblExamName inner join tblItemValue as tblItemValue1 on tblItemValue1.ItemValueId =tblExamName.Class_id  " +
                        " inner join tblItemValue as tblItemValue2 on tblItemValue2.ItemValueId= tblExamName. Topic_id " +
                        " inner join tblItemValue as tblItemValue3 on tblItemValue3.ItemValueId=tblExamName.Subject_id  " +
                        " inner join  tblItemValue as tblItemValue4 on tblItemValue4.ItemValueId=tblExamName.TypeOFExam " +
                        "  inner join tblItemValue as tblItemValue5 on tblItemValue5.ItemValueId=tblExamName.Chapter_id " +
                        "  where tblExamName. TypeOfExam='" + examtype + "' ";


                    ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
                }
                else
                {

                    string Sql = "Select tblExamName.examid as Id ,tblExamName.examname , " +
                         " tblItemValue3.Name as Subject_id,tblExamName.MediumID  , " +
                         " tblItemValue4.Name as TypeOfExam ,tblItemValue5.Name  as Chapter_id " +
                         " from tblExamName inner join tblItemValue as tblItemValue3 on tblItemValue3.ItemValueId=tblExamName.Subject_id  " +
                         " inner join  tblItemValue as tblItemValue4 on tblItemValue4.ItemValueId=tblExamName.TypeOFExam " +
                         "  inner join tblItemValue as tblItemValue5 on tblItemValue5.ItemValueId=tblExamName.Chapter_id " +
                         "  where tblExamName. TypeOfExam='" + examtype + "' ";

                    ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;

    }


    public int addExam(string enm, int cid)
    {
        string abc = "Database = " + Convert.ToString(HttpContext.Current.Session["DBName"]);
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"] + abc))
        {
            int row;
            try
            {
                SqlParameter[] par = new SqlParameter[3];

                par[0] = new SqlParameter("@examname", enm);
                par[1] = new SqlParameter("@CollegeId", cid);
                par[2] = new SqlParameter("@status", 100);
                par[2].Direction = ParameterDirection.Output;

                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "addExamName", par);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return row;
        }
    }
}
