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


public partial class userControl_userinstruction : System.Web.UI.UserControl
{
    SqlConnection con = null;
    SqlDataAdapter da = null;
    DataSet ds = new DataSet();
    string s11;
    string[] arr2 = null;
    int r;
    string ID2;
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        string SNO1 = null;
        SNO1 = Convert.ToString(Session["InstruID"]); // get Sno of All Question of table 
        string[] arr2 = SNO1.Split(',');

        if (arr2.Length > r)
        {
            Session["ID2"] = Convert.ToInt32(Session["ID2"]) + 1;  // Initial value is  Session["SNO"]=-1;
            r = Convert.ToInt32(Session["ID2"]);

            ID2 = Convert.ToString(arr2[r]);
        }

        loadControl();

    }

    void loadControl()
    {
        try
        {
            string sql = "SELECT Instruction,Instrulanguage FROM tblInstructionTheory WHERE ID=" + ID2 + " ";
                DataSet ds = cc.ExecuteDataset(sql);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblInstruction.Text = Convert.ToString(ds.Tables[0].Rows[0]["Instruction"]);
                    string lang = Convert.ToString(ds.Tables[0].Rows[0]["Instrulanguage"]);
                    if (lang == "Marathi")
                    {
                        lblInstruction.Font.Name = "Cambria Math";
                        lblInstruction.Font.Size = 12;
                    }
                    else
                    {
                        lblInstruction.Font.Name = "Garamond";
                        lblInstruction.Font.Size = 11;
                    }
                   
                }
                ds = null;
        }
        catch 
        {
        }
    }
}
