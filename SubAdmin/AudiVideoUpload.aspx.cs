using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

public partial class SubAdmin_AudiVideoUpload : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string Sql; string filePath = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindGridView();
            rdblstAVChoose.SelectedIndex = 0;
            
        }
    }

    public void AudioUpload()
    {
        if (FileUpload1.HasFile)
        {
            string path = "";
            path = Server.MapPath("AudioVideoList");
            path = path + "\\" + FileUpload1.FileName;
            string ab = FileUpload1.FileName;

            if (File.Exists(path))
            {
                File.Delete(path);
                FileUpload1.SaveAs(path);
            }
            else
            {
                FileUpload1.SaveAs(path);
            }
        }

        filePath = FileUpload1.FileName;

        Sql = "Insert Into tblAudioVideoList(AVName,AVDescription,AVPath,UploadDate,AVAbbreviation)Values('" + txtName.Text + "','" + txtDescription.Text + "','" + filePath + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','A') ";
        int status = cc.ExecuteNonQuery(Sql);

        if (status != 0)
        {
            lblResult.Text = "Data Saved Successfully..!!!";
            lblResult.Font.Bold = true;
            lblResult.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            lblResult.Text = "Data Not Saved Successfully..!!!";
            lblResult.Font.Bold = true;
            lblResult.ForeColor = System.Drawing.Color.Red;
        }
    }

    public void VideoUpload()
    {
        Sql = "Insert Into tblAudioVideoList(AVName,AVDescription,AVPath,UploadDate,AVAbbreviation)Values('" + txtName.Text + "','" + txtDescription.Text + "','" + txtPath.Text + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','V') ";
        int status = cc.ExecuteNonQuery(Sql);

        if (status != 0)
        {
            lblResult.Text = "Data Saved Successfully..!!!";
            lblResult.Font.Bold = true;
            lblResult.ForeColor = System.Drawing.Color.Green;
            
        }
        else
        {
            lblResult.Text = "Data Not Saved Successfully..!!!";
            lblResult.Font.Bold = true;
            lblResult.ForeColor = System.Drawing.Color.Red;
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        if (rdblstAVChoose.SelectedItem.Text == "Audio")
        {
            if (rdblstAVChoose.SelectedIndex == 0)
            {
                lblResult.Text = "Choose File For Upload..!!!";
                lblResult.Font.Bold = true;
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                AudioUpload();
            }
            bindGridView();
        }
        else
        {
            if (rdblstAVChoose.SelectedIndex == 1)
            {
                txtPath.BorderColor = System.Drawing.Color.Red;
                lblResult.Text = "";
            }
            else
            {
                VideoUpload();
            }
            bindGridView();
        }
    }

    public void bindGridView()
    {
        string SQLQuery = "Select [AVID],[AVName],[AVDescription],[AVAbbreviation],SUBSTRING(CAST([UploadDate] as nvarchar),1,11) AS UploadDate From [tblAudioVideoList] ";
        DataSet dataset = cc.ExecuteDataset(SQLQuery);
        gvAudiVideoList.DataSource = dataset.Tables[0];
        gvAudiVideoList.DataBind();
    }
}
