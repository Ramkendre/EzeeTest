<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true" CodeFile="AssignMenu.aspx.cs" Inherits="Admin_AssignMenu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div style="width:100%;" align="center">
<table cellpadding="0" cellspacing="0" width="70%" border="1" ><tr><td align="center" >
            <div style="width: 80%">
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
             <td></td>
            <td colspan="3" style="text-align: left">
                <h3>
                    <asp:Label ID="lblHeader" runat="server" Text="Assign Menu"></asp:Label></h3>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" >
                &nbsp;&nbsp;<asp:Label ID="lblError" Visible="False" runat="server" 
                    CssClass="error" Text="Label" Font-Size="Large" ForeColor="Red"></asp:Label></td>
        </tr>
           
        <tr>
            <td >
                <asp:Label ID="lblRoleName" runat="server" Text="Role Name :"></asp:Label>
                <label >*</label>
            </td>
            <td style="text-align: left" >
                
                <asp:Label ID="txtRoleName" runat="server" Text="Role Name :"></asp:Label>
            </td>
            <td class="error">
                &nbsp;
                 
            </td>
        </tr>
        
        
        <tr>
            <td colspan="3" style="height: 173px" >
            <table cellpadding="5" width="100%" cellspacing="5" border="1">
                <tr>
                   <td style="width:40%">Menu Items</td>
                <td style="width:10%"></td>
                <td style="width:40%">Assigned Menu</td>
                </tr>
                
                <tr>
                   <td style="width:40%">
                       <asp:DropDownList ID="ddlParent" AutoPostBack="true" runat="server" Height="25px" 
                           Width="175px" onselectedindexchanged="ddlParent_SelectedIndexChanged"></asp:DropDownList> </td>
                <td style="width:10%"></td>
                <td style="width:40%"></td>
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
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" ValidationGroup="vgpStateSubmit"
                    OnClick="btnSubmit_Click"  />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="btn" 
                    OnClick="btnCancel_Click" Text="Cancel" />
                &nbsp;
                <asp:Button ID="btnback0" runat="server" CssClass="btn" 
                    OnClick="btnExit_Click1" Text="Back" PostBackUrl="~/Admin/Home.aspx" 
                   />
            </td>
        </tr>
    </table>
    <br />
    </td></tr></table></div>
    
     </td></tr></table></div>
            </ContentTemplate></asp:UpdatePanel>
</asp:Content>

