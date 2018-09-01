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
using System.Xml;

public partial class User_usrLogin : System.Web.UI.Page
{
    string file = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        file = MapPath("~/pExamSession.xml");
    }

    public void create(string IPAdd)
    {
        //Start writer
        XmlTextWriter writer = new XmlTextWriter(Server.MapPath(file), System.Text.Encoding.UTF8);
        //Start XM DOcument
        writer.WriteStartDocument(true);
        writer.Formatting = Formatting.Indented;
        writer.Indentation = 2;
        //ROOT Element
        writer.WriteStartElement("Users");
        //call create nodes method
        writer.WriteStartElement("session");
            createNode(txtUserName.Text, IPAdd, writer);
        writer.WriteEndElement();
        writer.WriteEndElement();
        //End XML Document
        writer.WriteEndDocument();
        //Close writer
        writer.Close();
    }

    private void createNode(string logId, string ipAddr, XmlTextWriter writer)
    {        
        //LoginId
        writer.WriteStartElement("LoginId");
        writer.WriteString(logId);
        writer.WriteEndElement();
        
        //ipAddress
        writer.WriteStartElement("ipAddress");
        writer.WriteString(ipAddr);
        writer.WriteEndElement();
       
        //lblResult.Text = "XML File ceated!";        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string IPAdd = string.Empty;
            IPAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(IPAdd))
                IPAdd = Request.ServerVariables["REMOTE_ADDR"];           

            XDocument doc = null;

            //Verify whether a file is exists or not
            if (!System.IO.File.Exists(file))
            {
                create(IPAdd);
            }
            else
            {
                doc = XDocument.Load(file);
            }

            XElement eleS = new XElement("session");
            doc.Root.Add(eleS);
            XElement ele1 = new XElement("LoginId", txtUserName.Text);
            eleS.Add(ele1);
            //doc.Root.Add(ele1);
            XElement ele2 = new XElement("ipAddress", IPAdd);
            eleS.Add(ele2);
            //doc.Root.Add(ele2);
            doc.Save(file);           

            Response.Redirect("../Admin/exTest.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {            
            if (System.IO.File.Exists(file))            
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(file);

                string searchstr = txtUserName.Text;                
                XmlNodeList xNodeList = xDoc.SelectNodes("Users/session");                
               
                foreach (XmlNode xNode in xNodeList)
                {
                    if (xNode.InnerText.Contains(searchstr))
                    {
                        string result = xNode.InnerText;
                        xNode.ParentNode.RemoveChild(xNode);                        
                        xDoc.Save(file);                        
                    }
                }               
            }
        }

        catch (Exception ex)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "LogOut", "alert('Error on page please Logout again!'", true);
        }
    }
}
