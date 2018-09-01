using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UploadAPK : System.Web.UI.Page
{
    public string path;
    string conPath = string.Empty;
    string fileExtension = string.Empty;
    Label lblStatus = new Label();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUploadAPK.HasFile)
            {
                path = Server.MapPath("Download");
                path = path + "\\" + FileUploadAPK.FileName;
                string ab = FileUploadAPK.FileName;
                fileExtension = Path.GetExtension(path);

                if (ab == "ezeeclass.apk" || ab == "ezeetest.apk" || ab == "myct.apk" || ab == "ezeejob.apk" || ab == "ezeestorm.apk")
                {
                    if (fileExtension == ".apk")
                    {
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                            FileUploadAPK.SaveAs(path);

                            lblStatus.Text = "File Uploaded Successfully.!!!";
                            lblStatus.ForeColor = System.Drawing.Color.Green;
                            lblStatus.Font.Bold = true;
                            lblStatus.Font.Size = 15;
                            Controls.Add(lblStatus);
                            lblInstruction.Text = path;
                        }
                        else
                        {
                            FileUploadAPK.SaveAs(path);

                            lblStatus.Text = "File Uploaded Successfully.!!!";
                            lblStatus.ForeColor = System.Drawing.Color.Green;
                            lblStatus.Font.Bold = true;
                            lblStatus.Font.Size = 15;
                            Controls.Add(lblStatus);
                            lblInstruction.Text = path;
                        }
                    }
                    else
                    {
                        lblStatus.Text = "Please Give .apk Extention to File.!!!";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        lblStatus.Font.Bold = true;
                        lblStatus.Font.Size = 15;
                        Controls.Add(lblStatus);
                    }
                }
                else
                {
                    lblStatus.Text = "Please Give Valid Name to File ezeeclass or ezeetest.!!!";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Font.Bold = true;
                    lblStatus.Font.Size = 15;
                    Controls.Add(lblStatus);
                }
            }
            else
            {
                lblStatus.Text = "Please Select APK File.!!!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Font.Bold = true;
                lblStatus.Font.Size = 15;
                Controls.Add(lblStatus);
            }
        }
        catch
        {
 
        }
    }
}