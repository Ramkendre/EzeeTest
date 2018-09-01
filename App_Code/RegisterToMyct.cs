using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RegisterToMyct
/// </summary>
public class RegisterToMyct
{
    CommonCode cc = new CommonCode();
    string pwd;
   // @in.myct.ExamMyct objEx = new @in.myct.ExamMyct();
    myct.ExamMyct objEx = new myct.ExamMyct();

	public RegisterToMyct()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string Addnew(string fname, string lname, string mobileno, string txtAddress, string pincode,string msgstatus)
    {
        int ID;
        try
        {
            string sql = "select usrAutoId from usermaster where usrMobileNo= '" + mobileno + "' ";
            string already = cc.ExecuteScalarCt1(sql);// check this user already register
            if (already == "" || already == null)
            {
                string a12 = objEx.GetRegisterRecord(mobileno, fname, lname, txtAddress, pincode, msgstatus);
                string sql1 = "select usrPassword from usermaster where usrMobileNo= '" + mobileno + "' ";
                pwd = cc.ExecuteScalarCt1(sql1);// check this user already register
               // pwd = cc.DESDecrypt(pwd);
                return pwd;


              // string userid = System.Guid.NewGuid().ToString();
                //Random rnd = new Random();
              
                //pwd = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                //string Sql = "insert into usermaster(usrUserId,usrFirstName,usrLastName,usrMobileNo,usrPassword)" +
                //         " values('" + userid + "','" + fname + "','" + lname + "','" + mobileno + "','" + pwd + "')";
                //ID = cc.ExecuteNonQuery1(Sql);
                //if (ID == 1)
                //{
                //   // pwd = cc.DESDecrypt(pwd);                 
                //    return pwd;
                //}
                //else
                //{
                //    string error = "error";
                //    return error;
                //}
            }
            else
            {
                string sql1 = "select usrPassword from usermaster where usrMobileNo= '" + mobileno + "' ";
                pwd = cc.ExecuteScalarCt1(sql1);// check this user already register                  
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return pwd;
    }



    //Newly Added Below Function on 30.03.2015 for ezeehealth problem
    public string Addnew(string fname, string lname, string mobileno)
    {
        int ID;
        try
        {
            string sql = "select usrPassword from usermaster where usrMobileNo= '" + mobileno + "' ";
            string already = cc.ExecuteScalarCt1(sql);// check this user already register
            if (already == "" || already == null)
            {
                string userid = System.Guid.NewGuid().ToString();
                Random rnd = new Random();

                pwd = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                string Sql = "insert into usermaster(usrUserId,usrFirstName,usrLastName,usrMobileNo,usrPassword)" +
                         " values('" + userid + "','" + fname + "','" + lname + "','" + mobileno + "','" + pwd + "')";
                ID = cc.ExecuteNonQuery1(Sql);
                if (ID == 1)
                {
                    pwd = cc.DESDecrypt(pwd);
                    return pwd;
                }
                else
                {
                    string error = "error";
                    return error;
                }
            }
            else
            {
                pwd = cc.DESDecrypt(already);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return pwd;
    }
}