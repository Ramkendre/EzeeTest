using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Success : System.Web.UI.Page
{
    private string mobileNumber = string.Empty, emailId = string.Empty, txnid = string.Empty, mihpayid = string.Empty, payUmoneyId = string.Empty,
       bankRefId = string.Empty, otherInformation1 = string.Empty, otherInformation2 = string.Empty, otherInformation3 = string.Empty, otherInformation4 = string.Empty;
    private int product = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string message = string.Empty;
        
       
        mobileNumber = Request.Form["phone"];
        emailId = Request.Form["email"];
        txnid = Request.Form["txnid"];
        mihpayid = Request.Form["mihpayid"];
        payUmoneyId = Request.Form["payuMoneyId"];
        bankRefId = Request.Form["bank_ref_num"];
        product = 1;
      
        PayuMoney.PayuMoney pm = new PayuMoney.PayuMoney();
       bool b= pm.InsertPaymentDetails(mobileNumber, emailId, txnid, mihpayid, payUmoneyId, bankRefId, product, otherInformation1, otherInformation2, otherInformation3, otherInformation4);
       message = "You made your transaction Successfully.Your password for mobile Application is :<b>" + pm.scrachcode() + "<b />";
        message += "<center><hr /><h3>"+message+"</h3><hr /></center>";
        message += "<br>Please Remember Your Scratch Code for Future Reference.";
        if (b)
        {
            message += "<br><hr />:" + pm.emailResponse(); //Email Response
            message += "<br><hr />:" + pm.smsResponse();//Sms Response
        }
        else
        {
            message += "<br><hr />:" + pm.ErrorMessage();//Error Message
            message += "<br><hr />:" + pm.ErrorNumber();//Error Number
        }
        
        Response.Write(message);
        


    }
}