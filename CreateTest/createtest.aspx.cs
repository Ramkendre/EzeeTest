using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class CreateTest_createtest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["LoginId"]) == "9292929292")
        {
            imgDailyQuestions.Visible = true;
            imgInsertChapters.Visible = false;
        }
        else if (Convert.ToString(Session["LoginId"]) == "9422324927")
        {
            imgDailyQuestions.Visible = false;
            imgFeedback.Visible = true;
            imgInsertChapters.Visible = true;
        }
        else
        {
            imgDailyQuestions.Visible = false;
            imgFeedback.Visible = false;
            imgInsertChapters.Visible = false;
        }
    }
}
