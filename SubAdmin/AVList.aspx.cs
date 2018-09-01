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

public partial class SubAdmin_AVList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Name = @"~/SubAdmin/AudioVideoList/" + Convert.ToString(Request.QueryString["name"]);
       // string Name = @"~/SubAdmin/AudioVideoList/01 Mauli Mauli(VipMarathi.Com).mp3";

        string s = Server.MapPath(Name);

        var Response = HttpContext.Current.Response;
        Response.ContentType = "audio/mpeg3";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + s);
        Response.WriteFile(Name);
        Response.End();

    }
}
