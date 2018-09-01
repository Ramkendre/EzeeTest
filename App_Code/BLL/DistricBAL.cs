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
/// Summary description for DistricBAL
/// </summary>
public class DistricBAL
{
    int status;
    DistricDAL ddal = new DistricDAL();
    DataSet ds=new DataSet ();


	public DistricBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int DistrictId;
    public int DistrictId1
    {
        get { return DistrictId; }
        set { DistrictId = value; }
    }
    private string DistrictName;
    public string DistrictName1
    {
        get { return DistrictName; }
        set { DistrictName = value; }
    }
    private int StateId;
    public int StateId1
    {
        get { return StateId; }
        set { StateId = value; }
    }

    public int _insertDistric(DistricBAL dbal)
    {
        status = ddal._insertDistric(dbal);
        return status;
    }
    public int _updateDidtric(DistricBAL dbal)
    {
        status = ddal._updateDidtric(dbal);
        return status;
    }
    public DataSet _selectDistric(DistricBAL dbal)
    {

        ds = ddal._selectDistric(dbal);
        return ds;
    }

    public int _deleteDistric(DistricBAL dbal)
    {
        status = ddal._deleteDistric(dbal);
        return status;
    }


    


}
