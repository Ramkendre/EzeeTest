<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Master.master" AutoEventWireup="true"
    CodeFile="ChangeDetails.aspx.cs" Inherits="Admin_ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:UpdatePanel ID="UpdatePanel1" runat="server"  >

<ContentTemplate >
&nbsp;<table cellpadding="0" cellspacing="0" width="70%" border="1"   >
<tr>
<td align="center" style="width: 790px" >
        <div style="width: 88%; margin-left: 15px;">
          <%--  <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                <div style="width: 80%">--%>
        <table cellpadding="0" cellspacing="0" border="0" class="tables" 
                        style="width: 83%; margin-left: 102px">
                <tr>
                    <td  colspan="2"  style="height: 20px;">
                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                    </td>
               
                </tr>
                
                
                
                
                
                <tr>
                 <td style="height: 20px;">
       <table style="width: 79%; margin-left: 68px;" class="tables" cellspacing="2" cellpadding="2">
        <tr>
             <td></td>
            <td colspan="3" align="center" 
                 
                 
                 style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                    <b> Login Id
            </b>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="text-align: left" >
                &nbsp;&nbsp;<asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Label"></asp:Label><asp:Label ID="lblSuccess" runat="server"  CssClass="error" Visible="False" ></asp:Label></td>
        </tr>
                <tr>
                
                
                  <td align="left" style="width:23%; text-align: left;"  >
              <asp:Label ID="lblLoginId" runat="server" Font-Bold="False" 
                    Font-Names="Arial" Font-Size="11pt" Text=" Login Id"></asp:Label></td>
                       
                <%-- <td style="width: 50px; height: 15px; text-align: left;font-size:large;" align="center">
                        Login Id
                    </td>--%>
                    <td style="width: 100px; height: 25px; text-align: left;">
                        <asp:TextBox ID="txtLoginId" MaxLength="30" ReadOnly="true" runat="server" CssClass="txtcss" AutoPostBack="false"
                            TabIndex="1" Height="25px" Width="120px"></asp:TextBox>
                    </td>
                </tr>
                
                
                <tr>
                
                 <td align="left" style="width:23%; text-align: left; height: 10px;"  >
                <asp:Label ID="lblUserName"  runat="server" Font-Bold="False" 
                    Font-Names="Arial" Font-Size="11pt" Text="User Name *"></asp:Label></td>
                
                
                    <%--<td style="Width:50px;  height: 25px; text-align: left; font-size: large;" 
                        align="center">
                        User Name
                    </td>--%>
                    
                    <td style="height: 10px; text-align: left; font-size: large;">
                        <asp:TextBox ID="txtUserName" ValidationGroup="user" CssClass="txtcss" runat="server"
                            MaxLength="100" TabIndex="1" Height="25px" Width="120px"></asp:TextBox>
                       <%-- <span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtUserName" ErrorMessage=" User Name is Missing..." 
                            ValidationGroup="user"></asp:RequiredFieldValidator>--%>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUserName"
                                ErrorMessage=" User Name is Missing.." ValidationGroup="user">&nbsp;</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    
                 <td align="left" style="width:23%; text-align: left; height: 9px;"  >
                <asp:Label ID="lblPassword"   runat="server" Font-Bold="False" 
                    Font-Names="Arial" Font-Size="11pt" Text="Password *"></asp:Label></td>
                    
                    <td style="height: 9px; text-align: left;">
                        <asp:TextBox ID="txtPassword" runat="server"  Height="22px" Width="120px" ValidationGroup="user"
                            CssClass="txtcss" MaxLength="20" AutoPostBack="false" TabIndex="1" 
                            TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="user" runat="server"
                            ControlToValidate="txtPassword" ErrorMessage=" Password is Missing.." 
                             Font-Size="12px"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                      
                 <td align="left" style="width:23%; text-align: left; height: 10px;"  >
                <asp:Label ID="lblRePassword"    runat="server" Font-Bold="False" 
                    Font-Names="Arial" Font-Size="11pt" Text="Re-Password *"></asp:Label></td>
                    
                    <td style="height: 10px; text-align: left;">
                        <asp:TextBox ID="txtRePassword" Height="25px" Width="120px" ValidationGroup="user"
                            CssClass="txtcss" runat="server" AutoPostBack="false" TabIndex="1" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="comValid" ValidationGroup="user" runat="server" ControlToValidate="txtRePassword"
                            ControlToCompare="txtPassword" ErrorMessage="Re-Password should be same as password"
                            Type="String" Font-Size="12px"></asp:CompareValidator>
                    </td>
                </tr>
                
                <tr>
                  <td align="left" style="width:23%; text-align: left; height: 7px;"  >
               <asp:Label ID="lblContactNo"    runat="server" Font-Bold="False" 
                    Font-Names="Arial" Font-Size="11pt" Text=" Contact No *"></asp:Label></td>
                    
                   
                    <td style="height: 7px; text-align: left;">
                        <asp:TextBox ID="txtContactNo"  ValidationGroup="user" CssClass="txtcss" 
                            Height="25px" Width="120px"
                            onkeypress="return numbersonly(this,event)" runat="server" MaxLength="12" 
                            TabIndex="1" ontextchanged="txtContactNo_TextChanged"></asp:TextBox>
                        <span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContactNo"
                                ValidationGroup="user" ErrorMessage="*" 
                            Font-Size="Medium"></asp:RequiredFieldValidator></span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Font-Size="12px" ControlToValidate="txtContactNo" Display="Dynamic" ValidationGroup="user" ErrorMessage="<br>Contact Number must be 8 to 13 digit" ValidationExpression="^[0-9]{8,13}$"></asp:RegularExpressionValidator>
                       
                    </td>
                </tr>
                <tr>
                    
                    <td align="left" style="width:23%; text-align: left; height: 10px;"  >
                <asp:Label ID="lblAddress"     runat="server" Font-Bold="False" 
                    Font-Names="Arial" Font-Size="11pt" Text=" Address"></asp:Label></td>
                    
                    <td style="height: 10px; text-align: left;">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="txtcss" MaxLength="100" Height="25px"
                            Width="120px" TabIndex="1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 25px; text-align: left; width: 23%;">
                    </td>
                    <td style="height: 25px; text-align: left;">
                        <asp:Button ID="btnUpdate" ValidationGroup="user" runat="server" Text="Update" 
                            CssClass="btn" OnClick="btnUpdate_Click" />
                        &nbsp;<asp:Button ID="btnback" runat="server" CssClass="btn" PostBackUrl="~/Admin/Home.aspx"
                            Text="Back" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
