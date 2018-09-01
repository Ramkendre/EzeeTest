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
/// Summary description for BindQuestionsToGridBAL
/// </summary>
public class BindQuestionsToGridBAL
{

    BindQuestionsToGridDAL objBindQuestionsToGridDAL = new BindQuestionsToGridDAL();
    DataSet ds = new DataSet();
	public BindQuestionsToGridBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    private int SNO;

    public int SNO1
    {
        get { return SNO; }
        set { SNO = value; }
    }
    private int Question;

    public int Question1
    {
        get { return Question; }
        set { Question = value; }
    }

    public DataSet BindQuestionsToGrid(BindQuestionsToGridBAL objBindQuestionsToGridBAL)
    {
        ds = objBindQuestionsToGridDAL.BindQuestionsToGrid(objBindQuestionsToGridBAL);
        return ds;
    }

}
