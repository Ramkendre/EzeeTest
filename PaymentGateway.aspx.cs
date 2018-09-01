using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.UI.HtmlControls;


public partial class PaymentGateway : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string Sql;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region BinddropdownExamName

    protected void ddlGroupofExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGroupofExam.SelectedValue == Convert.ToString(140))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=17196  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(141))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=16998 ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(142))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=17099  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
        else if (ddlGroupofExam.SelectedValue == Convert.ToString(143))
        {
            Sql = "select Name,ItemValueIdNew from tblItemValue where  ItemIdNew=0 or ItemIdNew=203";// 167103  ";
            DataSet ds = cc.ExecuteDataset(Sql);

            ddlExamName.DataSource = ds.Tables[0];
            ddlExamName.DataTextField = "Name";
            ddlExamName.DataValueField = "ItemValueIdNew";
            ddlExamName.DataBind();
        }
    }
    #endregion

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        PaymentGateWayDll.RequestForPayment PaymentGatway = new PaymentGateWayDll.RequestForPayment();
        string P1;
        
        if (ddlExamName.SelectedValue.Length == 3)
        {
             P1 = "2" + "0" + ddlGroupofExam.SelectedValue + "00" + ddlExamName.SelectedValue;
        }
        else
        {
             P1 = "2" + "0" + ddlGroupofExam.SelectedValue + "000" + ddlExamName.SelectedValue;
        }
            string P2 = ddlExamName.SelectedItem.Text;
            string P3 = txtAmount.Text;

            string s = PaymentGatway.getPostRequest(P1, P2, P3);
            Page.Controls.Add(new LiteralControl(s));
        
    }
    protected void ddlExamName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlExamName.SelectedValue == Convert.ToString(103) || ddlExamName.SelectedValue == Convert.ToString(165))
        {
            lblAmount.Text = (300).ToString();
        }
        else if (ddlExamName.SelectedValue == Convert.ToString(176))
        {
            lblAmount.Text = (300).ToString();
        }
        else if (ddlExamName.SelectedValue == Convert.ToString(96))
        {
            lblAmount.Text = (300).ToString();
        }
    }
}
