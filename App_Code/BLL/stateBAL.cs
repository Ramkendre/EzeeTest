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
/// Summary description for stateBAL
/// </summary>
public class stateBAL
{
    int status;
    stateDAL sdal = new stateDAL();
    DataSet ds = new DataSet();


	public stateBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int StateId;
    public int StateId1
    {
        get { return StateId; }
        set { StateId = value; }
    }

    private string StateName;
    public string StateName1
    {
        get { return StateName; }
        set { StateName = value; }
    }

    private int CountryId;
    public int CountryId1
    {
        get { return CountryId; }
        set { CountryId = value; }
    }

    public int _insertstate(stateBAL sbal)
    {
        status = sdal._insertstate(sbal);
        return status;
    }
    public int _updatestate(stateBAL sbal)
    {
        status = sdal._updatestate(sbal);
        return status;
    }
    public DataSet _selectstate(stateBAL sbal)
    {
        ds = sdal._selectstate(sbal);
        return ds;
    }
    public int _deletestate(stateBAL sbal)
    {
        status = sdal._deletestate(sbal);
        return status;
    }


}
