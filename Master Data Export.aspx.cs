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
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class Master_Data_Export : System.Web.UI.Page
{
    public string path = string.Empty;
    CommonCode cc = new CommonCode();
    string fileExtension = string.Empty;
    string inupcount = string.Empty;
    public static string connectionString { get { return "server=103.16.140.243;Initial Catalog=OKCLDB;User id=TrueVoter;Password=TrueVoter@#123;"; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        if (gvExportToExcel.Visible)
        {
            Response.AddHeader("content-disposition", "attachment; filename='" + Session["LoginId"] + "'Excel.xls");
            Response.ContentType = "application/excel";
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
            gvExportToExcel.RenderControl(hTextWriter);
            Response.Write(sWriter.ToString());
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void btnShowMasterData_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string path = "";
            path = Server.MapPath("Download");
            path = path + "\\" + FileUpload1.FileName;
            string ab = FileUpload1.FileName;

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                FileUpload1.SaveAs(path);
            }
            else
            {
                FileUpload1.SaveAs(path);
            }
        }

        string strQuery = "SELECT * FROM [LongCode$]";
        DataSet dscount = GetDataTable(strQuery);

        if (dscount != null || dscount.Tables[0].Rows.Count > 0)
        {
            inupcount = FetchData(dscount);
        }
    }

    public string FetchData(DataSet excelData)
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();

        for (int k = 0; k < excelData.Tables[0].Rows.Count; k++)
        {
            string mobileNumber = excelData.Tables[0].Rows[k][0].ToString();
            string msgBody = excelData.Tables[0].Rows[k][1].ToString();

            mobileNumber = mobileNumber.Trim();
           
            msgBody = msgBody.Trim();
            string[] mms = msgBody.Split('*');

            if (mms[0].ToString() == "EVIDYALAYA" || mms[0].ToString() == "Evidyalaya" || mms[0].ToString() == "evidyalaya" || mms[0].ToString() == "EVIDYALAYA " || mms[0].ToString() == " EVIDYALAYA")
            {
                string code = mms[1].ToString();

                string sqlQuery = " Select [OKCLDB].[dbo].[Attendence].[User],[OKCLDB].[dbo].[Attendence].[InsertionDate],[OKCLDB].[dbo].[Attendence].[InsertiionTime],[OKCLDB].[dbo].[Attendence].[Code] " +
                              " From [OKCLDB].[dbo].[Attendence] INNER JOIN [OKCLDB].[dbo].[Users] ON [OKCLDB].[dbo].[Attendence].[User]=[OKCLDB].[dbo].[Users].[Id] " +
                              " Where [OKCLDB].[dbo].[Users].[MobileNo]='" + mobileNumber + "' AND [OKCLDB].[dbo].[Attendence].[InsertionDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' ";


                cmd.CommandText = sqlQuery;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = new SqlConnection(connectionString);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //School Coordinator is Attendance Already Present for the day.
                }
                else
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "uspInsertDataToOkcl";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = new SqlConnection(connectionString);

                    SqlParameter[] parameter = new SqlParameter[]
                        {       
                           new SqlParameter("@userName",mobileNumber),
                           new SqlParameter("@insertDate",System.DateTime.Now.ToString("yyyy-MM-dd")),
                           new SqlParameter("@insertTime",System.DateTime.Now.ToString("hh:mm:ss tt")),
                           new SqlParameter("@code",code)
           
                        };

                    sqlCommand.Parameters.AddRange(parameter);
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();

                    //SendSmsToHM(); //to Sent Presenty SMS to Respective Head Master Number

                    sqlCommand.Connection.Close();
                }

            }

        }

        return "abc";
    }


    public DataSet GetDataTable(string strQuery)
    {
        DataSet tempDs = null;
        OleDbConnection conn = null;
        string conPath = string.Empty;
        //string fileExtension = string.Empty;

        string filePath = Server.MapPath("Download\\" + FileUpload1.FileName);

        fileExtension = Path.GetExtension(filePath);


        if (this.fileExtension == ".xls")
        {
            conPath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
        }
        else
        {
            conPath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
        }
        conn = new OleDbConnection(conPath);
        try
        {
            conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(strQuery, conn);
            tempDs = new DataSet();
            adapter.Fill(tempDs);
        }
        catch
        {

        }
        finally
        {
            conn.Close();
        }

        return tempDs;
    }
}
