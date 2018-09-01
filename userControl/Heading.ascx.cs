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

public partial class userControl_Heading : System.Web.UI.UserControl
{
    SqlConnection con = null;
    SqlDataAdapter da = null;
    DataSet ds = new DataSet();
    string s11;
    string[] arr2 = null;
    int r;
    string ID1;
    int count = 0;

    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        string SNO1 = null;
         SNO1 = Convert.ToString(Session["TheoryId1"]); // get Sno of All Question of table 
        string[] arr2 = SNO1.Split(',');
        if (arr2.Length > r)
        {
            Session["ID1"] = Convert.ToInt32(Session["ID1"]) + 1;  // Initial value is  Session["SNO"]=-1;
            r = Convert.ToInt32(Session["ID1"]);

            ID1 = Convert.ToString(arr2[r]);
        }

        loadControl();
        Session["SubSubQuestionNo"] = "0";

        //Session["mainQuestion"]=
    }

    void loadControl()
    {
        try
        {
            string sql = "SELECT * FROM  TheoryQuesTestDetails  WHERE ID=" + ID1 + " ";
            DataSet ds = cc.ExecuteDataset(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                fetchCommonData(ds.Tables[0].Rows[0]);
            }

            ds = null;
        }
        catch
        {
        }
    }

    public void fetchCommonData(DataRow row)
    {
        try
        {
            if (row.ItemArray.Count() > 0)
            {

                string Or = Convert.ToString(row["ORMainQuestion"]);
                if (Or == "1")
                {
                    lblOR.Visible = true;
                }
                else
                {
                    lblOR.Visible = false;
                }

                //Session["mainQuestion"] = Convert.ToString(row["MainQuestion"]);

                lblQNoHead.Text = Convert.ToString(row["MainQuestion"]);
                lblSubQNO.Text = Convert.ToString(row["SubQuestion"]) + "" + ")";
                lblHeading.Text = Convert.ToString(row["HeadingText"]);
                lblMarks.Text = "[" + Convert.ToString(row["MarkAllQuestion"]) +"]";

                string lang = Convert.ToString(row["Queslanguage"]);
                if (lang == "1")
                {
                    lblOR.Text = "किंवा";
                    lblHeading.Font.Name = "Cambria Math";
                    lblHeading.Font.Bold = false;
                    lblHeading.Font.Size = 11;
                }
            }
        }
        catch { }
    }
}
