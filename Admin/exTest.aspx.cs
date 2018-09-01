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
using System.Xml;
using System.IO;
using System.Security.Permissions;
using System.Security.AccessControl;
using System.Security.Authentication;

public partial class Admin_exTest : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string Sql = "";
    string file = "";
    string destFile = "";
    string s11 = "";        //s11 is table name where questions for test definition is saved.

    XDocument doc = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Corrhidden3"] = Corrhidden3.Value;
        Session["Atthidden2"] = Atthidden2.Value;
        Session["Incorrhidden4"] = Incorrhidden4.Value;
        Session["NotAnswered"] = NotAnswered.Value;

        if (!IsPostBack)
        {
            getSession();
            s11 = "tbl" + Convert.ToString(Session["CompanyId"]);



            //file = Server.MapPath("../ExamHistory/pExamSession.xml");
            //destFile = Server.MapPath("../ExamHistory/" + Session["LoginId"].ToString() + ".xml");

            //createXMLFile();
            //creatXML();

            //filesReadWrite();

            data();
        }
    }

    void getSession()
    {
        try
        {
            if (Request.Cookies["Credentials"].Value != null)
            {
                string value = Request.Cookies["Credentials"].Value;
                Session["UserName"] = value.Split('&')[0].Split('=')[1];
                Session["mobNo"] = value.Split('&')[1].Split('=')[1];

                Session["LoginId"] = Session["mobNo"].ToString();

                Session["CompanyId"] = value.Split('&')[2].Split('=')[1];
                Session["TestID"] = value.Split('&')[3].Split('=')[1];

                lblLogin.Text = Session["UserName"].ToString();
                //Response.Redirect("../Setting/HomePage.aspx?util=033");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
    }

    void data()
    {
        try
        {
            lblTestId.Text = "tbl" + Convert.ToString(Session["CompanyId"]);

            //on 21.02.14 defualt test
            string testID = Convert.ToString(Session["TestID"]);

            Sql = "select SNO from tblDefaultTest  where TestID='" + testID + "' ";
            string defId = cc.ExecuteScalar(Sql);



            if (defId != "")
            {
                lblTestId.Text = "tbl5164";
            }

            string sql1 = "";

            sql1 = " SELECT  TOP 100 percent ROW_NUMBER()over(order by SNO)as EQID, * FROM " + lblTestId.Text + " where TestID='" + testID + "' ORDER BY NEWID()";


            DataSet ds = cc.ExecuteDataset(sql1);
            lblQuesTo.Text = (ds.Tables[0].Rows.Count - 1).ToString();
            bool flagInstr = false;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Session["EQID"] += ds.Tables[0].Rows[i][0].ToString() + ",";
                if (flagInstr == false)
                {
                    Panel pnlQues = new Panel();
                    pnlQues.ID = "pnlQues" + "-1";
                    pnlQues.Width = 800;
                    pnlQues.Wrap = true;
                    pnlQues.Height = 400;
                    pnlQues.Style.Add(HtmlTextWriterStyle.BackgroundColor, "White");
                    pnlQues.ScrollBars = ScrollBars.Auto;
                    pnlQues.Style.Add(HtmlTextWriterStyle.Display, "block");

                    Control ctl = LoadControl("../InstructionControl.ascx");  //?reqQid=" + ds.Tables[0].Rows[i]["Question_id"]);                
                    ctl.ID = "UC" + "-1";
                    pnlQues.Controls.Add(ctl);
                    this.UCPlaceHolder.Controls.Add(pnlQues);

                    flagInstr = true;

                }
                if (flagInstr == true)
                {
                    Panel pnlQues = new Panel();
                    pnlQues.ID = "pnlQues" + i;
                    pnlQues.Width = 800;
                    pnlQues.Wrap = true;
                    pnlQues.Height = 400;
                    pnlQues.Style.Add(HtmlTextWriterStyle.BackgroundColor, "White");
                    pnlQues.ScrollBars = ScrollBars.Auto;
                    pnlQues.Style.Add(HtmlTextWriterStyle.Display, "block");
                    pnlQues.Style.Add(HtmlTextWriterStyle.Display, "none");

                    Control ctl1 = LoadControl("../ExamUserControl.ascx");  //?reqQid=" + ds.Tables[0].Rows[i]["Question_id"]);                
                    ctl1.ID = "UC" + i;
                    pnlQues.Controls.Add(ctl1);
                    this.UCPlaceHolder.Controls.Add(pnlQues);

                    if (i == Convert.ToInt32(lblQuesTo.Text))
                    {
                        Panel pnlQues1 = new Panel();
                        pnlQues1.ID = "pnlQues" + (i + 1);
                        pnlQues1.Width = 800;
                        pnlQues1.Wrap = true;
                        pnlQues1.Height = 400;
                        pnlQues1.Style.Add(HtmlTextWriterStyle.BackgroundColor, "White");
                        pnlQues1.ScrollBars = ScrollBars.Auto;
                        pnlQues1.Style.Add(HtmlTextWriterStyle.Display, "none");

                        Control ctl = LoadControl("../ExamReportControl.ascx");  //?reqQid=" + ds.Tables[0].Rows[i]["Question_id"]);                
                        ctl.ID = "UC_Finish";
                        pnlQues1.Controls.Add(ctl);
                        this.UCPlaceHolder.Controls.Add(pnlQues1);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
    }
    protected void btnFinish_Click(object sender, EventArgs e)
    {
        string aa = Convert.ToString(Request.Cookies);


        if (Request.Cookies["Credentials"].Value != null)
        {
            string value = Request.Cookies["Credentials"].Value;
            Session["Login"] = value.Split('&')[0].Split('=')[1];
            Session["mobNo"] = value.Split('&')[1].Split('=')[1];

            //Response.Redirect("../Setting/HomePage.aspx?util=033");
        }
    }

    void createXMLFile()
    {
        try
        {
            if (File.Exists(destFile))
            {
                File.Delete(destFile);
                File.Copy(file, destFile);
            }
            else
                File.Copy(file, destFile);
        }
        catch { }
    }

    void creatXML()
    {
        try
        {
            string IPAdd = string.Empty;
            IPAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(IPAdd))
                IPAdd = Request.ServerVariables["REMOTE_ADDR"];


            //Verify whether a file is exists or not
            if (!System.IO.File.Exists(destFile))
            {
                createExamHistory(IPAdd);
            }
            else
            {
                doc = XDocument.Load(destFile);
            }


            XElement eleRoot = new XElement("Session");
            doc.Root.Add(eleRoot);

            /***direct way to create element
             * 
             * XElement ele2 = new XElement("ipAddress", IPAdd);
             * eleRoot.Add(ele2);
             ***/

            //add child elements
            eleRoot.Add(createElement("ipAddress", IPAdd));
            eleRoot.Add(createElement("Date", DateTime.Now.ToShortDateString()));
            eleRoot.Add(createElement("Time", DateTime.Now.ToShortTimeString()));
            eleRoot.Add(createElement("CollegeID", Convert.ToString(Session["CompanyId"])));
            eleRoot.Add(createElement("TestID", Convert.ToString(Session["TestID"])));
            eleRoot.Add(createElement("TestTable", s11));

            doc.Save(destFile);
        }
        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
        }
    }

    void createExamHistory(string IPAdd)
    {
        //Start writer
        XmlTextWriter writer = new XmlTextWriter(Server.MapPath(destFile), System.Text.Encoding.UTF8);
        //Start XM DOcument
        writer.WriteStartDocument(true);
        writer.Formatting = Formatting.Indented;
        writer.Indentation = 2;

        //ROOT Element
        writer.WriteStartElement("Users");

        //call create nodes method
        writer.WriteStartElement("session");

        createNode(IPAdd, "ipAddress", writer);


        writer.WriteEndElement();



        //end root element
        writer.WriteEndElement();
        //End XML Document
        writer.WriteEndDocument();
        //Close writer
        writer.Close();
    }

    void createNode(string ipAddr, string nodeNm, XmlTextWriter writer)
    {
        //ipAddress
        writer.WriteStartElement(nodeNm);
        writer.WriteString(ipAddr);
        writer.WriteEndElement();

        //lblResult.Text = "XML File ceated!";        
    }


    XElement createElement(string eleName, string eleValue)
    {
        return (new XElement(eleName, eleValue));
    }


    void Button2_Click()
    {
        try
        {
            if (System.IO.File.Exists(destFile))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(destFile);

                string searchstr = "txtUserName.Text";
                XmlNodeList xNodeList = xDoc.SelectNodes("Users/session");

                foreach (XmlNode xNode in xNodeList)
                {
                    if (xNode.InnerText.Contains(searchstr))
                    {
                        string result = xNode.InnerText;
                        xNode.ParentNode.RemoveChild(xNode);
                        xDoc.Save(destFile);
                    }
                }
            }
        }

        catch (Exception ex)
        {
            Response.Write("<h4>" + ex.Message);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "LogOut", "alert('Error on page please Logout again!'", true);
        }
    }






}