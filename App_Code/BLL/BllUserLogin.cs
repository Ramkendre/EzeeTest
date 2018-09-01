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
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BllUserLogin
/// </summary>
public class BllUserLogin
{
   // SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    DalUserLogin dlllogin = new DalUserLogin();
     
    private int Student_id;
    private string Name;
    private string Password;
    private string Confirmpass;
    DataSet ds = new DataSet();


    private List<BllUserLogin> abtlist;
    private List<BllUserLogin> allrecord;
    #region properties

    public int Student_id1
    {
        get { return Student_id; }
        set { Student_id = value; }
    }
     

    public string Name1
    {
        get { return Name; }
        set { Name = value; }
    }
    

    public string Password1
    {
        get { return Password; }
        set { Password = value; }
    }

    #endregion Procedure

    public List<BllUserLogin> Allrecord
    {
        get { return allrecord; }
        set { allrecord = value; }
    }
    

    public List<BllUserLogin> Abtlist
    {
        get { return abtlist; }
        set { abtlist = value; }
    }

    public bool studentlogin(BllUserLogin bn)
    {
        bool flag = false;

        flag = dlllogin.login(bn);
        return flag;

        //flag = loginDALObj.isExist(lb);
    }


    public DataSet _Menu(string LoginId)
    {
        UserDAL udal = new UserDAL();
        ds = udal.returnMenu(LoginId);
        return ds;

    }


    //public List<AboutUsBLL> LoadAbout()
    //{
    //    return aboutUSDALObj.load();
    //}

    //public int InsertAboutUs(AboutUsBLL abutbll)
    //{

    //    int i = aboutUSDALObj.InsertData(abutbll);
    //    return i;
    //}

    //public void getSelectedRecord(AboutUsBLL abutBll)
    //{
    //    this.allRecords = aboutUSDALObj.loadSelectedRecord(abutBll);
    //}





	public BllUserLogin()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
