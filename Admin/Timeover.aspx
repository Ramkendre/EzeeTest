<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminMaster.master"  AutoEventWireup="true" CodeFile="Timeover.aspx.cs" Inherits="Timeover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <table    cellpadding="0" cellspacing="0" width="70%" border="1" ><tr><td align="center" >
            <div style="width: 80%">
                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                    <tr>
                        <td colspan="2"  style="height: 20px;">
                            <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 20px;">
       <table  >
        <tr>
             <td style="text-align: center">
                   <div style="text-align: center">
                       <span style="color: #FF6600; font-size: x-large; font-weight: bold">Time Over
                       </span>
                       <br />
                       <span style="font-size: large"><span style="color: #800000"><b>You have finished with the exam. 
                     Thank you!!</span></b></span></span></div>
                   </h3>
                 
             </td>
        </tr>
        <tr>
            <td  style="text-align: center">
        <asp:Button ID="btnScore" runat="server"  CssClass="btn"
            onclick="btnScore_Click" Text="Get Score" />
            </td>
        </tr>
           <tr>
               <td  style="text-align: center">
                   
                        <asp:Label ID="lblscore" runat="server" Font-Bold="True" 
                            Font-Names="Times New Roman" Font-Size="Large" Font-Underline="True" 
                            ForeColor="Black" Text="Test Score" Width="96px" 
                            style="text-align: left; color: #990000;"></asp:Label>
      
               </td>
               
           </tr>
        
           <tr>
               <td  style="text-align: center">
                   
                   Attempted :<asp:Label ID="lbltattempt" runat="server" Font-Bold="False" Font-Names="Times New Roman" 
                            Font-Size="Medium" ForeColor="Black" Style="text-align: left;"></asp:Label></td>
           </tr>
        
           <tr>
               <td  style="text-align: center">
                   
                   Correct :<asp:Label ID="lbltcorrect" runat="server" Font-Bold="False" ForeColor="Black" 
                            Font-Names="Times New Roman" Font-Size="Medium"></asp:Label></td>
           </tr>
        
           <tr>
               <td  style="text-align: center">
                   
                   Wrong :<asp:Label ID="lbltwrong" runat="server" Font-Bold="False" ForeColor="Black" 
                            Font-Names="Times New Roman" Font-Size="Medium"></asp:Label></td>
           </tr>
        
           <tr>
               <td  style="text-align: center">
                   
                   <asp:LinkButton ID="linkbtnDetail" runat="server" Font-Names="Times New Roman" 
                            Font-Size="Medium" OnClick="linkbtnDetail_Click" Width="90px" 
                            ForeColor="Black" style="text-align: left; color: #800000;">Detail Result</asp:LinkButton>
      
               </td>
           </tr>
        
        <tr>
          <td  style="text-align: center">&nbsp;
                &nbsp;
                <asp:Button 
            ID="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"  CssClass="btn"/>
            &nbsp;
        <asp:Button ID="btnback" runat="server" Text="Back" 
                    CssClass="btn" 
                    PostBackUrl="~/Admin/Home.aspx" />
            </td>
        </tr>
    </table>
    <br />
    </td></tr></table></div>
     </td></tr></table>

</asp:Content>

