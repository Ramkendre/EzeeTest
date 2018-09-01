using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CityBLL
/// </summary>
public class UserBLL
{
    UserDAL userDAL = new UserDAL();
    public UserBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    int status;
    DataSet ds = new DataSet();
    private int L_Id;

    public int L_Id1
    {
        get { return L_Id; }
        set { L_Id = value; }
    }
    private string _loginid;
    private string _username;
    private string _password;
    private string _contactno;
    private string _address;
    private string  _doj;
    private int _role;
    private int _companyId;
    private string _rolename;
    private string _companyname;

    public string Companyname
    {
        get { return _companyname; }
        set { _companyname = value; }
    }

    private List<UserBLL> _getAllUser;

    #region Properties
    public string LoginId
    {
        get
        {
            return _loginid;
        }
        set
        {
            _loginid = value;
        }
    }

    public string UserName
    {
        get
        {
            return _username;
        }
        set
        {
            _username = value;
        }
    }

    public string Password 
    {
        get
        {
            return _password;
        }
        set
        {
            _password = value;
        }
    }

    public string ContactNo
    {
        get
        {
            return _contactno;
        }
        set
        {
            _contactno = value;
        }
    }

    public string Address
    {
        get
        {
            return _address;
        }
        set
        {
            _address = value;
        }
    }


    //cc.dtinsert_local
    public string  DOJ
    {
        get
        {
            return _doj;
        }
        set
        {
            _doj = value;
        }
    }

    public int Role
    {
        get
        {
            return _role;
        }
        set
        {
            _role = value;
        }
    }

    public string RoleName
    {
        get
        {
            return _rolename;
        }
        set
        {
            _rolename = value;
        }
    }
    public int CompanyId
    {
        get
        {
            return _companyId;
        }
        set
        {
            _companyId = value;
        }
    }

    private string company;

    public string Company
    {
        get { return company; }
        set { company = value; }
    }




    public int _insertUser(UserBLL userbal)
    {
        status = userDAL._insertUser(userbal);
        return status;
    }


    public int _updateUser(UserBLL userbal)
    {
        status = userDAL._updateUser(userbal);
        return status;
    }


    public int _deleteUser(UserBLL userbal)
    {
        status = userDAL._deleteUser(userbal);
        return status;
    }



    public List<UserBLL> getAllUser
    {
        get
        {
            return _getAllUser;
        }
        set
        {
            _getAllUser = value;
        }
    }

#endregion properties 

    public DataSet GetUserDetails(UserBLL user)
    {
        ds = userDAL.DALShowUserDetails(user);
        return ds;
    }
    public int UpdateOwnDetails(UserBLL user)
    {
        status = userDAL.UpdateOwnDetails(user);
        return status;
    }
    


    //public DataSet  BLLShowAllUser()
    //{
    //    DataTable dtCityShowAll = cityDALObj.DALShowAllCity();
    //    return dtCityShowAll;
    //}


    //public bool BLLIsExistCityName(CityBLL ct)
    //{
    //    bool flag = false;
    //    flag = cityDALObj.DALIsExistCityName(ct);
    //    return flag;
    //}

    //public int BLLInsertCity(CityBLL ct)
    //{
    //    status = cityDALObj.DALInsertCity(ct);
    //    return status;
    //}


    


    

}
