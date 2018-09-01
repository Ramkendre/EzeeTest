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
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for cityBAL
/// </summary>
public class cityBAL
{
    cityDAL cdal = new cityDAL();
    int status;
    DataSet ds = new DataSet();
	public cityBAL()
	{		
		// TODO: Add constructor logic here		
	}
    

    private int CityId;
    public int CityId1
    {
        get { return CityId; }
        set { CityId = value; }
    }

    private string CityName;
    public string CityName1
    {
        get { return CityName; }
        set { CityName = value; }
    }
    private int DistrictId;
    public int DistrictId1
    {
        get { return DistrictId; }
        set { DistrictId = value; }
    }

    public int _insertcity(cityBAL cbal)
    {
        status = cdal._insertcity(cbal);
        return status;
    }
    public DataSet _selectcity(cityBAL cbal)
    {
        ds = cdal._selectcity(cbal);
        return ds;
    }
    public int _updatecity(cityBAL cbal)
    {
        status = cdal._updatecity(cbal);
        return status;
    }
    public int _deletecity(cityBAL cbal)
    {
        status = cdal._deletecity(cbal);
        return status;
    }

    public DataSet citywise(string DistrictId)
    {
        ds = cdal.citywise(DistrictId);
        return ds ;
    }

}
