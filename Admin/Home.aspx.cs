using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Linq;


public partial class Admin_Home : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string ipAddress, hostName;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         
            loadDDLRole();
            ipAddress = IpAddress();
            hostName = Dns.GetHostName();          
            Addvisitor();
            AddcompanyProfile();
           
            
        }

    }

    public void AddcompanyProfile()
    {
        try
        {
            string asds=Convert.ToString(  Session["LoginId"]);
            string com = Convert.ToString(Session["CompanyId"]);
            if ((Convert.ToString( Session["LoginId"]) != "ADMIN") && (Convert.ToString( Session["CompanyId"]) == "0"))
            {
                Response.Redirect("Company.aspx",false);
            }
        }
        catch(Exception ex)
        {
        }

    }


   // ************************************************* Coding Online**************************************************************

    private void GetOnline() //add on 6.12.13
    {
        
        string sql = "select  userid from DemoOnline where  status='Active'";
        DataSet ds = ExecuteDataset(sql);
        //gvUseronline.DataSource = ds.Tables[0];
        //gvUseronline.DataBind();

        //lblcount.Text ="("+ Convert.ToString( ds.Tables[0].Rows.Count)+")";        
       
    }
    protected void AutoRefreshTimer_Tick(object sender, EventArgs e)
    {
       // GetOnline();
    }
    public DataSet ExecuteDataset(string Sql)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
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

//******************************************** End Online Coding *********************************************


    public void loadDDLRole()
    {
        string sql = "select RoleId,RoleName from Role where RoleId='2' or RoleId='8'";
        DataSet ds = cc.ExecuteDataset(sql);
        DropDownList1.DataSource = ds.Tables[0];
        DropDownList1.DataTextField = "RoleName";
        DropDownList1.DataValueField = "RoleId";
        DropDownList1.DataBind();

        string a = Convert.ToString(Session["Role"]);
        if (a == "8" || a == "2")
        {
           // Panel1.Visible = true;
        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["Role"] = Convert.ToString(DropDownList1.SelectedValue);
        string Role = Convert.ToString(Session["Role"]);
        Response.Redirect("./Home.aspx");
    }
    protected void Set_Page_Level_Setting()
    {

        Label lblMainHeading = (Label)Master.FindControl("lblMainHeading");
        if (lblMainHeading != null)
            lblMainHeading.Text = "Welcome Admin Panel";
    }


    //****************************************************** coding for visitors counter ********************************//



    string Sql;
    protected void Addvisitor()
    {
        try
        {           
            Sql = " SELECT  VisitorId,VisitDateTime,NumofVisit FROM VisitorIPDetails  where VisitorID=(select MAX(VisitorID) from VisitorIPDetails where HostName='" + hostName + "' and RoleId='" + Convert.ToInt32(Session["Role"]) + "' and School_Collegename='" + Convert.ToString(Session["CompanyId"]) + "'  and  IPAdd ='" + ipAddress + "' and  Loginname='" + Convert.ToString(Session["LoginId"]) + "' ) ";
            DataSet ds = cc.ExecuteDataset(Sql);

           
            string loginid = Convert.ToString(Session["LoginId"]);
            if (loginid != "")
            {

                DateTime dt2 = new DateTime();
                dt2 = System.DateTime.Now;
                dt2 = dt2.AddHours(12.50);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    DateTime dt1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["VisitDateTime"]);
                    // dt1 = Convert.ToDateTime("2013-4-13 2:30:01 AM");

                   
                    //  dt2 = Convert.ToDateTime("2013-4-15 3:30:01 AM");   // system data time is = 12/4/2013 6:30:51 PM   in db save 2013-12-04 18:30:51.000

                 

                    TimeSpan ts3 = dt2 - dt1;
                    int d = ts3.Days;
                    d = d * 24;
                    int hr = ts3.Hours;
                    int min = ts3.Minutes;
                    hr = hr + d;


                    if (hr < 3)
                    {
                        string VisitorId = Convert.ToString(ds.Tables[0].Rows[0]["VisitorId"]);
                        int NumofVisit = Convert.ToInt32(ds.Tables[0].Rows[0]["NumofVisit"]);
                        NumofVisit++;
                        Sql = "update VisitorIPDetails set NumofVisit=" + NumofVisit + " where VisitorId='" + VisitorId + "' ";
                        int status = cc.ExecuteNonQuery(Sql);
                    }

                    else
                    {

                        Sql = "insert into VisitorIPDetails(HostName,VisitDateTime,IPAdd,RequestURL,Loginname,School_Collegename,RoleId,NumofVisit)" +
                                  "values('" + hostName + "','" + dt2 + "','" + ipAddress + "','" + Request.Url.ToString() + "','" + Convert.ToString(Session["LoginId"]) + "','" + Convert.ToString(Session["CompanyId"]) + "','" + Convert.ToInt32(Session["Role"]) + "','1')";
                        int status = cc.ExecuteNonQuery(Sql);

                    }
                }
                else
                {
                    Sql = "insert into VisitorIPDetails(HostName,VisitDateTime,IPAdd,RequestURL,Loginname,School_Collegename,RoleId,NumofVisit)" +
                                 "values('" + hostName + "','" + dt2 + "','" + ipAddress + "','" + Request.Url.ToString() + "','" + Convert.ToString(Session["LoginId"]) + "','" + Convert.ToString(Session["CompanyId"]) + "','" + Convert.ToInt32(Session["Role"]) + "','1')";
                    int status = cc.ExecuteNonQuery(Sql);
                }
            }

        }
        catch (Exception ex)
        {
        }

    }
    private string IpAddress()
    {
        // string ip = Request.UserHostAddress;
        string strIpAddress;
        strIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (strIpAddress == null)
            strIpAddress = Request.ServerVariables["REMOTE_ADDR"];
        return strIpAddress;
    }
    //Add the Namespace

    //Get Visitor IP address method
    public string GetVisitorIpAddress() 
    {
        string stringIpAddress;
        stringIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (stringIpAddress == null) //may be the HTTP_X_FORWARDED_FOR is null
        {
            stringIpAddress = Request.ServerVariables["REMOTE_ADDR"];//we can use REMOTE_ADDR
        }
        return "Your ip is " + stringIpAddress;
    }
    //Get Lan Connected IP address method
    public string GetLanIPAddress()
    {
        //Get the Host Name
        string stringHostName = Dns.GetHostName();
        //Get The Ip Host Entry
        IPHostEntry ipHostEntries = Dns.GetHostEntry(stringHostName);
        //Get The Ip Address From The Ip Host Entry Address List
        IPAddress[] arrIpAddress = ipHostEntries.AddressList;
        return arrIpAddress[arrIpAddress.Length - 1].ToString();
    }


    //****************************************************** End coding for visitors counter ********************************//






}
