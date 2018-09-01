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

/// <summary>
/// Summary description for StudentScoreReport
/// </summary>
public class StudentScoreReport
{
	public StudentScoreReport()
	{
		//
		// TODO: Add constructor logic here
		//
    }


    #region Properties

    private string username;

    public string Username
    {
        get { return username; }
        set { username = value; }
    }
    private string usermobileno;

    public string Usermobileno
    {
        get { return usermobileno; }
        set { usermobileno = value; }
    }
    private string teachermobileno;

    public string Teachermobileno
    {
        get { return teachermobileno; }
        set { teachermobileno = value; }
    }
    private string testid;

    public string Testid
    {
        get { return testid; }
        set { testid = value; }
    }
    private string testdate;

    public string Testdate
    {
        get { return testdate; }
        set { testdate = value; }
    }
    private string imei;

    public string Imei
    {
        get { return imei; }
        set { imei = value; }
    }
    private string starttime;

    public string Starttime
    {
        get { return starttime; }
        set { starttime = value; }
    }
    private string endtime;

    public string Endtime
    {
        get { return endtime; }
        set { endtime = value; }
    }
    private string status;

    public string Status
    {
        get { return status; }
        set { status = value; }
    }
    private string centername;

    public string Centername
    {
        get { return centername; }
        set { centername = value; }
    }
    private string percentage;

    public string Percentage
    {
        get { return percentage; }
        set { percentage = value; }
    }
    private string testname;

    public string Testname
    {
        get { return testname; }
        set { testname = value; }
    }

    #endregion









}
