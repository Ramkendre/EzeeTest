using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
/// <summary>
/// Summary description for RegistrationBll
/// </summary>
public class RegistrationBll
{
    //SqlConnection con=new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"])
    RegistrationDal reddal = new RegistrationDal();

    private int student_id;
    private string Name;
    private string password;
    private string cpwd;


    public int Student_id
    {
        get { return student_id; }
        set { student_id = value; }
    }
    

    public string Name1
    {
        get { return Name; }
        set { Name = value; }
    }
    

    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    

    public string Cpwd
    {
        get { return cpwd; }
        set { cpwd = value; }
    }

    private List<RegistrationBll> allRecord;

    public List<RegistrationBll> AllRecord
    {
        get { return allRecord; }
        set { allRecord = value; }
    }

    public int insertstudent(RegistrationBll regbll)
    {
        int i = reddal.inseret(regbll);
        return i;
    
    }
    public List<RegistrationBll> loadStudent()
    {
        return reddal.Load();
    }

    public bool isExistUserName(RegistrationBll regbll)
    {
        bool flag = false;
        flag = reddal.isExistName(regbll);
        
        return flag;

    }
    public bool isExistStudent(RegistrationBll regbll)
    {
        bool flag = false;
        int i;
        flag = reddal.isExist(regbll);
          
            //createuserDALObj.isExist(cu);
        if (flag == false)
        {

            i = reddal.update(regbll);
                //regbll.update(regbll);
            if (i == 0)
            {
                flag = true;
            }

        }
        return flag;

    }


    //public int insertSchool(SchoolRegistrationBLL sbll)
    //{
    //    int i = schoolDALObj.insertData(sbll);
    //    return i;
    //}


    //public void getSelectedRecord(SchoolRegistrationBLL sbll)
    //{
    //    this.allRecord = schoolDALObj.loadSelectedRecord(sbll);

    //}

    //public int DeleteSchool(SchoolRegistrationBLL sbll)
    //{
    //    // int i = cityDALObj.delete(ct);
    //    int i = schoolDALObj.deleteSchool(sbll);
    //    return i;
    //}











	public RegistrationBll()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
