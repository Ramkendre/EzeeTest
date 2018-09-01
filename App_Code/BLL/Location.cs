using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CityBLL
/// </summary>
public class Location
{
    LocationDAL locationdal = new LocationDAL();
    public Location()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    int status;
    DataSet ds = new DataSet();
    private int student_id;
    private int _countryid;
    private int _stateid;
    private string _statename;
    private int _districtid;
    private string _districtname;
    private int _cityid;

    public int Cityid
    {
        get { return _cityid; }
        set { _cityid = value; }
    }
    private string _cityname;

    public string Cityname
    {
        get { return _cityname; }
        set { _cityname = value; }
    }
   
    private List<Location> _getAllLocation;

    #region Properties
    public int CountryId
    {
        get
        {
            return _countryid;
        }
        set
        {
            _countryid  = value;
        }
    }

    public int StateId
    {
        get
        {
            return _stateid;
        }
        set
        {
            _stateid = value;
        }
    }

    public string StateName
    {
        get
        {
            return _statename;
        }
        set
        {
            _statename  = value;
        }
    }

    public int DistrictId
    {
        get
        {
            return _districtid;
        }
        set
        {
            _districtid  = value;
        }
    }

    public string DistrictName
    {
        get
        {
            return _districtname;
        }
        set
        {
            _districtname = value;
        }
    }

    private int Collegeid;

    public int Collegeid1
    {
        get { return Collegeid; }
        set { Collegeid = value; }
    }
    private string CollegeName;

    public string CollegeName1
    {
        get { return CollegeName; }
        set { CollegeName = value; }
    }

    public List<Location > getAllLocation
    {
        get
        {
            return _getAllLocation;
        }
        set
        {
            _getAllLocation = value;
        }
    }

    #endregion properties

    public DataSet GetAllState()
    {
        ds = locationdal.DALGetAllState();
        return ds;
    }
    public DataSet GetAllState_default()
    {
        ds = locationdal.DALGetAllState_default();
        return ds;
    }
    public DataSet GetAllDistrict(string StateId)
    {
        ds = locationdal.DALGetAllDistrict(StateId);
        return ds;
    }
    public DataSet GetAllDistrict_default(string StateName)
    {
        ds = locationdal.DALGetAllDistrict_default(StateName);
        return ds;
    }
    

    // city means taluka as per database
    public DataSet GetAllCity(string DistrictId)
    {
        ds = locationdal.DALGetAllCity(DistrictId);
        return ds;
    }
    public DataSet GetAllCity_default(string DistrictName)
    {
        ds = locationdal.DALGetAllCity_default(DistrictName);
        return ds;
    }
    public DataSet GetAllCity1()
    {
        ds = locationdal.DALGetAllCity();
        return ds;
    }

    public DataSet GetCollegeName()
    {

        ds = locationdal._GetCollegeName();
        return ds;
    
    }
    public DataSet GetCollegeNamecid(string cid)
    {

        ds = locationdal._GetCollegeNamecid(cid);
        return ds;

    }


    // taluka means city as per database
    public DataSet GetAllTaluka_default(string Talukaname)
    {
        ds = locationdal.DALGetAllTaluka_default(Talukaname);
        return ds;
    }
    public DataSet GetAllTaluka(string Talukaid)
    {
        ds = locationdal.DALGetAllTaluka(Talukaid);
        return ds;
    }


}
