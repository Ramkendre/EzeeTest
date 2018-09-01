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
using System.Net.Mail;
using System.Collections.Generic;

/// <summary>
/// Summary description for SendMail
/// </summary>
public class SendMail
{
    CommonCode cc = new CommonCode();
    public SendMail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int sendMailSupport(string message1, string description)
    {
        int status = 0;
        try
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new MailAddress("mpsc.ezeetest@gmail.com");
            msg.To.Add("mpsc.ezeetest@gmail.com");
            msg.Subject = "Support Online Exam";
            msg.IsBodyHtml = true;
            msg.Body = message1 + " " + description;
            msg.Priority = MailPriority.High;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("mpsc.ezeetest@gmail.com", "mpscezee1");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            object userstate = msg;
            client.Send(msg);
            status = 1;
        }
        catch
        {
        }
        return status;
    }
}
