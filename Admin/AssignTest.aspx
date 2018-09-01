<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true" CodeFile="AssignTest.aspx.cs" Inherits="Admin_AssignTest" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width:100%;" align="center">
    <table cellpadding="0" cellspacing="0" width="70%" border="1" ><tr><td align="center" >
            <div style="width: 100%">
                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                    <tr>
                        <td colspan="2"  style="height: 20px;">
                            <span class="warning1" style="color: Red;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 20px;">
       <table style="width: 100%" class="tables" cellspacing="7px">
        <tr>
             <td colspan="3" style="text-align: center">
                <h3 style="text-align: center">
                    <asp:Label ID="lblHeader" runat="server" Text="Assign Test"></asp:Label></h3>
             </td>
        </tr>
        <tr>
            <td align="center" colspan="3" >
                &nbsp;&nbsp;<asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Label"></asp:Label></td>
        </tr>
           
        <tr>
            <td >
                <asp:Label ID="lblRoleName" runat="server" Text="User Name :"></asp:Label>
                <label >*</label>
                
                <asp:Label ID="txtRoleName" runat="server" 
                    style="font-weight: 700; font-size: large; color: #FF6600"></asp:Label>
            </td>
            <td >
                
                &nbsp;</td>
            <td class="error">
                &nbsp;
                 
            </td>
        </tr>
        
        
        <tr>
            <td colspan="3" style="height: 173px" >
                <table cellpadding="5" width="100%" cellspacing="5" border="1">
                
        <td style="text-align: left; height: 20px;" colspan="3">
            Select College Name :&nbsp;&nbsp; <asp:DropDownList ID="ddlCollege"    CssClass="txthiwidth" runat="server" AutoPostBack="True" 
                       onselectedindexchanged="ddlCollege_SelectedIndexChanged">
                   </asp:DropDownList>
                &nbsp;
                <br />
                
               </td>
        </tr><tr>
                  
                 <td style="text-align: left; height: 20px;" colspan="3">
           Test Items :&nbsp;&nbsp; <asp:DropDownList ID="ddlCompany" AutoPostBack="true" runat="server" Height="25px" 
                           Width="175px" onselectedindexchanged="ddlCompany_SelectedIndexChanged" ></asp:DropDownList>
                &nbsp;
                <br />
                
               </td></tr>
                <tr>
                   <td style="height: 18px; text-align: center;" colspan="3">
                        Assigned Test</td>
                </tr>
                
                
                <tr>
                   <td style="width:40%">
                   <asp:ListBox ID="lstMainMenu" Width="175px" Height="136px" SelectionMode="Multiple" 
                           runat="server" onselectedindexchanged="lstMainMenu_SelectedIndexChanged"></asp:ListBox> </td>
                <td style="width:10%">
                   <asp:Button ID="btnRight" runat="server" Text=" >> " CssClass="btn" 
                        onclick="btnRight_Click" /><br />
                   <asp:Button ID="btnLeft" runat="server" Text=" << " CssClass="btn" 
                        onclick="btnLeft_Click" />
                </td>
                <td style="width:40%"><asp:ListBox ID="lstAssignedMenu" SelectionMode="Multiple" 
                        runat="server" Width="175px" Height="136px"></asp:ListBox></td>
                </tr>
                
                </table> 
            </td>
        </tr>
        
        <tr>
          <td></td>
            <td colspan="2" align="center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" 
                    ValidationGroup="vgpStateSubmit" onclick="btnSubmit_Click"
                     />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="btn" 
                    Text="Cancel" onclick="btnCancel_Click" 
                    PostBackUrl="~/Admin/AssignTest.aspx" />
                &nbsp;
                <asp:Button ID="btnback0" runat="server" CssClass="btn" 
                    Text="Back" PostBackUrl="~/Admin/UserList.aspx" 
                   />
            </td>
        </tr>
    </table>
    <br /></div>
    </td></tr></table>
    
     </td></tr></table></div>
</asp:Content>

