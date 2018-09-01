using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using System.Net;
using System.Data.SqlClient;

public partial class UserLogin : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string language, Imageurl, Id;
    string password = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        string S = cc.DESDecrypt("jvLo9/p5Rvc=");   //asdf
        Id = Convert.ToString(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            ChatappsDeActive();

            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            txtUserName.Focus();

            if (Id != "" && Id != null)
            {

            }
            //ddltype.SelectedValue = "0";
            visitorcounter();
            Page.Header.DataBind();

        }

        Session["CompanyName"] = "Online School/College Solution ";
    }

    public void visitorcounter()
    {
        string sql = "select count(*)  from VisitorIPDetails";
        int counter = Convert.ToInt32(cc.ExecuteScalar(sql));
        counter = counter + 100;
        string counter1 = Convert.ToString(counter);
        lblcounter.Text = "Visitors Counter : " + counter1;
    }


    public void lag()
    {
        string sql = "Select  lagid , Name  from AALanuage";
        DataSet ds = cc.ExecuteDataset(sql);
        //ddltype.DataSource = ds.Tables[0];
        //ddltype.DataTextField = "Name";
        //ddltype.DataValueField = "lagid";
        //ddltype.DataBind();
    }



    protected override void InitializeCulture()
    {
        base.InitializeCulture();
        string cult = Request["DropDownList1"];

        if (cult != null)
        {
            Culture = cult;
            UICulture = cult;

        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();


            //if (ddlSchool.SelectedIndex == 0)
            if (txtUserName.Text == "")     // code to check empty user name,if empty raise error messege 
            {
                ltrlMessage.Text = "Please Enter User ID";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter User ID')", true);

            }
            else if (txtPassword.Text == "")     // code to check empty password, if empty raise error messege
            {
                ltrlMessage.Text = "Please Enter Password";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Password')", true);

            }

            else
            {

                Session["DBName"] = "online exam atul";   // store information of database name in session 
                Session["SchoolName"] = "Online Exam";
                Session["SC_ID"] = "1";
                try
                {
                    string UId = txtUserName.Text.ToString();      //save username in UID
                    string Pwd = cc.DESEncrypt(txtPassword.Text.ToString()); //Retrive password by using decryption

                    ds = cc.getLoginDetails(UId, Pwd);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string com = Convert.ToString(Session["CompanyName"]); // All information of user required through out session is store in specific session
                        Session["LoginId"] = Convert.ToString(ds.Tables[0].Rows[0]["LoginId"]).ToUpper();
                        ////Session["LoginIdSubClassAdmin"] = Convert.ToString(ds.Tables[0].Rows[0]["LoginId"]).ToUpper();
                        Session["LoginName"] = Convert.ToString(ds.Tables[0].Rows[0]["uid"]);
                        Session["UserName"] = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                        Session["CompanyId"] = Convert.ToString(ds.Tables[0].Rows[0]["CompanyId"]);
                        Session["DisplayName"] = Convert.ToString(ds.Tables[0].Rows[0]["DisplayName"]);
                        Session["lastvisit"] = DateTime.Now;
                        string userName = Session["UserName"].ToString();
                        DateTime lastVisit = (DateTime)Session["lastvisit"];

                        Session["UserType"] = Convert.ToString(ds.Tables[0].Rows[0]["UserType"]);
                        Session["admintype"] = Convert.ToString(ds.Tables[0].Rows[0]["admintype"]);
                        string admintype = Convert.ToString(Session["admintype"]);

                        Session["Role"] = Convert.ToString(ds.Tables[0].Rows[0]["Role"]);
                        string Role = Convert.ToString(Session["Role"]);

                        if (Role == "21")
                        {
                            string sql1 = " select loginname from Admin_SubUser where UnderUsername ='" + Convert.ToString(Session["LoginId"]) + "' ";
                            string upperlogin = Convert.ToString(cc.ExecuteScalar(sql1));
                            Session["LoginId"] = upperlogin;

                        }


                        Session["parentrole"] = Convert.ToString(ds.Tables[0].Rows[0]["parentrole"]);
                        string parentrole = Convert.ToString(Session["parentrole"]);

                        Session["Rname"] = Convert.ToString(ds.Tables[0].Rows[0]["rolename"]);
                        string rolename = Convert.ToString(Session["Rname"]);
                        // Response.Redirect("Html/Home.aspx");
                        if ((admintype == "1" || admintype == "0"))
                        {
                            Session["CompanyName"] = Convert.ToString(ds.Tables[0].Rows[0]["DisplayName"]);
                            Chatapps(); //add on 6.12.13
                            Response.Redirect("Admin/Home.aspx", false);

                        }
                        else if (admintype == "2")
                        {
                            Session["CompanyName"] = Convert.ToString(ds.Tables[0].Rows[0]["DisplayName"]);
                            Chatapps(); //add on 6.12.13
                            Response.Redirect("Html/Home.aspx", false);
                        }
                        else
                        {
                            if ((admintype == "1" || admintype == "0"))
                            {
                                ltrlMessage.Text = "Authority Not Assign to Admin panel";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Authority Not Assign to Admin panel')", true);
                            }
                            else if ((admintype == "2"))
                            {
                                ltrlMessage.Text = "Authority Not Assign to User panel";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Authority Not Assign to User panel')", true);
                            }
                        }

                    }
                    else
                    {
                        ltrlMessage.Text = "Invalid User";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Name or Password is Incorrect...Please try again')", true);

                    }

                }
                catch (Exception ex)
                {
                    ltrlMessage.Text = "Invalid User";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Name or Password is Incorrect...Please try again')", true);

                }
            }
        }
        catch (Exception ex)
        {


        }
    }

    public void Chatapps() //add on 6.12.13
    {
        try
        {
            string sql = "select id from DemoOnline where userid='" + Session["UserName"] + "'";
            string id = cc.ExecuteScalar(sql);
            if (id == "" || id == null)
            {
                sql = "insert into DemoOnline(userid,status)values('" + Session["UserName"] + "','Active')";
                int a = cc.ExecuteNonQuery(sql);
            }
            else
            {
                sql = "update DemoOnline set status='Active' where userid='" + Session["UserName"] + "'";
                int a = cc.ExecuteNonQuery(sql);
            }
        }
        catch (Exception ex)
        {

        }

    }

    public void ChatappsDeActive() //add on 6.12.13
    {
        try
        {

            string sql = "update DemoOnline set status='DeActive' where userid='" + Session["UserName"] + "'";
            int a = cc.ExecuteNonQuery(sql);

        }
        catch (Exception ex)
        { }

    }

    protected void btnDemouser_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();


            Session["DBName"] = "online exam atul";   // store information of database name in session 
            Session["SchoolName"] = "Online Exam";
            Session["SC_ID"] = "1";
            try
            {
                string UId = "1919191919";  // add company static add by 16 id in login tbl & sunAdminlogin tbl
                string Pwd = "dL+Gb1Egswc=";


                ds = cc.getLoginDetails(UId, Pwd);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string com = Convert.ToString(Session["CompanyName"]); // All information of user required through out session is store in specific session
                    Session["LoginId"] = Convert.ToString(ds.Tables[0].Rows[0]["LoginId"]).ToUpper();
                    Session["LoginName"] = Convert.ToString(ds.Tables[0].Rows[0]["uid"]);
                    Session["UserName"] = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                    Session["CompanyId"] = Convert.ToString(ds.Tables[0].Rows[0]["CompanyId"]);
                    Session["DisplayName"] = Convert.ToString(ds.Tables[0].Rows[0]["DisplayName"]);
                    Session["lastvisit"] = DateTime.Now;
                    string userName = Session["UserName"].ToString();
                    DateTime lastVisit = (DateTime)Session["lastvisit"];

                    Session["UserType"] = Convert.ToString(ds.Tables[0].Rows[0]["UserType"]);
                    Session["admintype"] = Convert.ToString(ds.Tables[0].Rows[0]["admintype"]);
                    string admintype = Convert.ToString(Session["admintype"]);

                    Session["Role"] = Convert.ToString(ds.Tables[0].Rows[0]["Role"]);
                    string Role = Convert.ToString(Session["Role"]);

                    Session["parentrole"] = Convert.ToString(ds.Tables[0].Rows[0]["parentrole"]);
                    string parentrole = Convert.ToString(Session["parentrole"]);

                    Session["Rname"] = Convert.ToString(ds.Tables[0].Rows[0]["rolename"]);
                    string rolename = Convert.ToString(Session["Rname"]);
                    // Response.Redirect("Html/Home.aspx");
                    if ((admintype == "1" || admintype == "0"))
                    {
                        Session["CompanyName"] = Convert.ToString(ds.Tables[0].Rows[0]["DisplayName"]);
                        Chatapps(); //add on 6.12.13
                        Response.Redirect("Admin/Home.aspx");

                    }
                    else if (admintype == "2")
                    {
                        Session["CompanyName"] = Convert.ToString(ds.Tables[0].Rows[0]["DisplayName"]);
                        Chatapps(); //add on 6.12.13
                        Response.Redirect("Html/Home.aspx");
                    }
                    else
                    {
                        if ((admintype == "1" || admintype == "0"))
                        {
                            ltrlMessage.Text = "Authority Not Assign to Admin panel";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Authority Not Assign to Admin panel')", true);
                        }
                        else if ((admintype == "2"))
                        {
                            ltrlMessage.Text = "Authority Not Assign to User panel";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Authority Not Assign to User panel')", true);
                        }
                    }

                }
                else
                {
                    ltrlMessage.Text = "Invalid User";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Name or Password is Incorrect...Please try again')", true);

                }
            }
            catch (Exception ex)
            {
                ltrlMessage.Text = "Invalid User";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Name or Password is Incorrect...Please try again')", true);
            }
        }
        catch (Exception ex)
        {

        }
    }


    protected void btnS_Send_Click(object sender, EventArgs e)
    {
        try
        {
            SendMail sendmail = new SendMail();
            string message1 = "User Details :User  Name is '" + txtS_Name.Text + "' and Mobile No. = '" + txtS_MobNO.Text + "' and Email Id =" + txtS_Email.Text + " and  user want support for  '" + ddlS_subject.SelectedItem.Text + "'  ,";
            string description = "The Message is " + txtS_Msg.Text;
            int status = sendmail.sendMailSupport(message1, description);
            if (status == 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Your message has been received !!! ,We will get back to you within 24 Hrs ')", true);
                txtS_Msg.Text = "";
                txtS_MobNO.Text = "";

            }
        }
        catch
        {
        }
    }
    protected void btnPayment_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PaymentGateway.aspx");
    }
    protected void btndatashowany_Click(object sender, EventArgs e)
    {

    }


    public string GetPassword(string pwd)
    {

        using (var con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT [Password] FROM [DBeZeeOnlineExam].[dbo].[Login] WHERE LoginId = '" + pwd + "'";
                con.Open();
                password = Convert.ToString(cmd.ExecuteScalar());
                con.Close();
                password = cc.DESDecrypt(password);
            }
        }
        return password.ToString();
    }

    protected void lnkforgetPwd_Click1(object sender, EventArgs e)
    {
        try
        {
            if (txtUserName.Text == "" || txtUserName.Text.Length < 10)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter valid 10 Digits Mobile No. in the UserName field!!!')", true);
            }
            else
            {
                password = GetPassword(txtUserName.Text);
                if (password != "")
                {
                    string msg = "Your password is " + password + "";
                    cc.TransactionalSMSCountry("123456789", txtUserName.Text, msg);

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Password Send Successfully...')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Register First...')", true);
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}

