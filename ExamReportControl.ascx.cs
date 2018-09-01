using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.IO;

public partial class ExamReportControl : System.Web.UI.UserControl
{
    CommonCode cc = new CommonCode();
    string SqlQuery = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
          
        }
    }


    
    protected void btnBackToTestHome_Click(object sender, EventArgs e)
    {
        
    }
}
