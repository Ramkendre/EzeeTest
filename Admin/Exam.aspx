<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true" CodeFile="Exam.aspx.cs" Inherits="Exam" Title="Exam" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript" language="javascript">

      function confirmation() {
          var answer = confirm("Do u want to stop!!");
          if (answer == false) {
              return false;
          }
          else {
              return true;
          }
      }

</script>
    
   &nbsp; <table cellpadding="0" cellspacing="0" width="100%" border="1" 
        style="font-family: 'Times New Roman', Times, serif; font-size: medium" ><tr><td align="center" >
            <div style="width: 95%">
                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                    <tr>
                        <td colspan="2"  style="height: 20px;">
                            <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 20px;">
       <table style="width: 95%" class="tables" cellspacing="7px">
       <tr>
             <td style="text-align: left"></td>
            <td colspan="4" align="center" 
                 
                 style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                    <b>Exam
            </b>
            </td>
        </tr>
        
         <td>
                  
                  &nbsp;</td>
                          
            <td align="center" colspan="3" style="text-align: right" >
               <asp:UpdatePanel ID="TimedPanel" runat="server" updatemode="Conditional">
                       <triggers>
                           <asp:AsyncPostBackTrigger controlid="UpdateTimer" eventname="Tick" />
                           

                       </triggers>
                       <ContentTemplate>
                           <asp:Timer ID="UpdateTimer" runat="server" interval="1000" 
                               ontick="UpdateTimer_Tick" />
                           <asp:Label ID="Label5" runat="server"  Font-Size="Medium" ForeColor="#663300"  
                               Visible="False">Total Time</asp:Label>
                           &nbsp;&nbsp;&nbsp;
                           <asp:Label ID="Label1" runat="server"  Font-Size="medium" ForeColor="#663300"  
                               Visible="False"></asp:Label>
                           <asp:Label ID="Label3" runat="server" Font-Size="medium" ForeColor="#663300"  Text=":" Visible="False"></asp:Label>
                           <asp:Label ID="Label4" runat="server" Font-Size="medium" ForeColor="#663300"  Visible="False"></asp:Label>
                       </ContentTemplate>
                   </asp:UpdatePanel>
                   </td>
                            
           <tr>
           
               <td>
                   Select Subject
               <span class="warning1" style="color: Red;">*</span></td>
               <td style="text-align: left">
                   <asp:ListBox ID="lstSelectsub" runat="server" Height="58px" 
                 Width="198px" AutoPostBack="True" 
                 OnSelectedIndexChanged="lstSelectsub_SelectedIndexChanged" 
                 Font-Names="Arial" Font-Size="Small">
        </asp:ListBox>
        
           </td>
              
           </tr>
           <tr>
               <td>
                   Select Topic
               <span class="warning1" style="color: Red;">*</span></td>
               <td style="text-align: left">
        
        <asp:ListBox ID="lstboxSeltopic" runat="server" AutoPostBack="True" 
            BackColor="Transparent" 
            OnSelectedIndexChanged="lstboxSeltopic_SelectedIndexChanged" 
            SelectionMode="Multiple" Width="197px" Height="53px" >
        </asp:ListBox>
              
           </tr>
        
        <tr>
            <td >
                   &nbsp;&nbsp; &nbsp;</td>
            <td style="text-align: left" >
                          <asp:TextBox ID="txtcurrentNo" runat="server"  OnTextChanged="txtcurrentNo_TextChanged" ToolTip="Enter the question number to whick u want to navigate"  Width="30px"></asp:TextBox> &nbsp;
                          <asp:Label ID="lblOf" runat="server" Text="Of" ></asp:Label>&nbsp;
                          <asp:TextBox ID="lblTotalQue" runat="server"  OnTextChanged="txtcurrentNo_TextChanged" ToolTip="Enter the question number to whick u want to navigate"  Width="30px"></asp:TextBox> 
                          &nbsp; 
                          <asp:Button ID="btnStart" runat="server"  Text="Start Exam"  CssClass="btn" OnClick="btnStart_Click" BorderStyle="Ridge" Height="29px" Width="94px"  />
             &nbsp; <asp:Label ID="lblcnt" runat="server" Visible="False"></asp:Label>
             </td>
           
        </tr>
         <tr>
            <td style="text-align: left" >
        
                                                                </td>
            <td style="text-align: left" >
        <asp:Label ID="lblCans" runat="server" ></asp:Label>
                                                                </td>
            
        </tr>
        
        <tr>
            <td >
        <asp:Label ID="lblQno" runat="server" Font-Bold="False" Font-Names="Arial" 
                Font-Size="11pt"></asp:Label>
                   </td>
            <td style="text-align: left" >
                   <asp:Label ID="lblQuestion" runat="server" Width="321px" 
                Font-Names="Arial" Font-Size="Small" Height="16px" 
                       style="font-weight: 700; color: #800000"></asp:Label>
                                                                </td>
        </tr>
        <tr>
            <td >
        <asp:Label ID="lblAns" runat="server" Text="Answer" Font-Bold="False" 
                Font-Names="Arial" Font-Size="Small"></asp:Label></td>
            <td >
        <asp:RadioButtonList ID="rdoSelectAnswer" runat="server" 
                onselectedindexchanged="rdoSelectAnswer_SelectedIndexChanged" Height="18px">           <asp:ListItem>Option1</asp:ListItem>
            <asp:ListItem>Option2</asp:ListItem>
            <asp:ListItem>Option3</asp:ListItem>
            <asp:ListItem>Option4</asp:ListItem>
        </asp:RadioButtonList>
                   </td>
           
        </tr>
        <tr>
          <td>
                   <asp:Label ID="lblattemp" runat="server" Text="Attempted :" Visible="False"></asp:Label>
                   <asp:Label ID="lblatcnt" runat="server" ForeColor="Blue" Visible="False" 
                  Width="20px" Height="16px">0</asp:Label>
            </td>
            <td colspan="2" align="center" style="text-align: left">
                &nbsp;
                        
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                    ToolTip="Click here to Submit your answer"   CssClass="btn" 
            OnClick="btnSubmit_Click" ValidationGroup="other" 
               />
           &nbsp;&nbsp;
                     <asp:Button ID="btnPrev" runat="server"  OnClick="btnPrev_Click"   CssClass="btn" ToolTip="Click here to see previous question" Text="Prev;" />
                         &nbsp;&nbsp; 
                         <asp:Button ID="btnNext" runat="server" CssClass="btn" BorderStyle="Ridge" 
                         Text="Next" OnClick="btnNext_Click"  ToolTip="Click here to get a new question." 
                         ValidationGroup="other" />
                          &nbsp;&nbsp;
           <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click"    CssClass="btn" 
                OnClientClick="return confirmation();" Text="Finish" 
                    ToolTip="Click here to exit" ValidationGroup="other" 
             BorderStyle="Ridge" />
            </td>
        </tr>
    </table>
    <br />
    </td></tr></table>
      </div>
    
     </td></tr></table>
</asp:Content>

