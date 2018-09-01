using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class mainform : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Page_Init(object sender, EventArgs e)
    {

    }
      
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    { 
        
        if (MenuList.SelectedValue.CompareTo("Add Topic") == 0)
            Response.Redirect("addTopic.aspx");
        if (MenuList.SelectedValue.CompareTo("Add Question") == 0)
            Response.Redirect("addQuestion.aspx");
        if (MenuList.SelectedValue.CompareTo("Practice") == 0)
            Response.Redirect("Practice.aspx");

       if (MenuList.SelectedValue.CompareTo("ExamName") == 0)
            Response.Redirect("addExamname.aspx");
       // if (Menu1.SelectedValue.CompareTo("Exam") == 0)
         //   Response.Redirect("Exam.aspx");
        if (MenuList.SelectedValue.CompareTo("Exit") == 0)
        {
                Response.Write("index.aspx");
            
        }
        if (MenuList.SelectedValue.CompareTo("Add Subject") == 0)
            Response.Redirect("Subject.aspx");
        if (MenuList.SelectedValue.CompareTo("Exam") == 0)
            Response.Redirect("Login.aspx");
        if (MenuList.SelectedValue.CompareTo("Test Definition") == 0)

        {
           
            Response.Redirect("Exam.aspx");
        }
       
    }
}
