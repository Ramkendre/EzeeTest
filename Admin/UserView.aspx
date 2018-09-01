<%@ Page Title="eZeeTest:View User Profile" Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="UserView.aspx.cs" Inherits="Admin_UserView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script src="../resources/JScript/jquery-1.11.1.js" type="text/javascript"></script>

    <script src="../resources/JScript/jquery-ui.js" type="text/javascript"></script>

<script type="text/javascript">
    $(function() {
        $("#<%=btnSubmit.ClientID%>").click(function() {

            window.close();
        });


    });

</script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
         <div style="width:100%;" align="center">
            <table cellpadding="0" cellspacing="0" width="70%" border="1">
                <tr>
                    <td align="center">
                        <div style="width: 95%">
                            <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                <tr>
                                    <td colspan="2" style="height: 20px;">
                                        <span class="warning1" style="color: Red;"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 20px;">
                                        <table style="width: 100%" class="tables" cellspacing="2" cellpadding="2">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="lblHeader" Font-Bold="true" ForeColor="Green" Text="UserDetails" Font-Size="X-Large" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="width: 100%" class="tables"  cellspacing="2" cellpadding="2">
                                            <tr>
                                                <td align="center" colspan="4">
                                                    &nbsp;&nbsp;<asp:Label ID="lblError" Visible="false" runat="server" CssClass="error"
                                                        Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 20%;font-size:medium; ">
                                                    Login Id :
                                                </td>
                                                <td align="left" style="width: 30%;">
                                                    <asp:Label ID="lblId" runat="server" Font-Bold="true" Font-Size="Large" Text="0"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 20%;font-size:medium;">
                                                    Password :
                                                </td>
                                                <td align="left" style="width: 30%;">
                                                    <asp:Label ID="lblPassword" Font-Bold="true" Font-Size="Large" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td align="left" style="width: 20%;font-size:medium;">
                                                    User Name : 
                                                </td>
                                                <td align="left" style="width: 30%;">
                                                    <asp:Label ID="lblUserName" Font-Bold="true" Font-Size="Large" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 20%;font-size:medium;">
                                                    Contact No : 
                                                </td>
                                                <td align="left" style="width: 30%;">
                                                    <asp:Label ID="lblContactNo" Font-Bold="true" Font-Size="Large" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 20%;font-size:medium;">
                                                    Address :
                                                </td>
                                                <td align="left" style="width: 30%;">
                                                    <asp:Label ID="lblAddress" Font-Bold="true" Font-Size="Large" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 20%;font-size:medium;">
                                                    DOJ :
                                                </td>
                                                <td align="left" style="width: 30%;">
                                                    <asp:Label ID="lblDOJ" Font-Bold="true" Font-Size="Large" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 20%;font-size:medium;">
                                                    Role Name :
                                                </td>
                                                <td align="left" style="width: 30%;">
                                                    <asp:Label ID="lblRole" Font-Bold="true" Font-Size="Large" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 20%;font-size:medium;">
                                                    Institute : 
                                                </td>
                                                <td align="left" style="width: 30%;">
                                                    <asp:Label ID="lblCompany" Font-Bold="true" Font-Size="Large" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 20%;font-size:medium;">
                                                    User Type :
                                                </td>
                                                <td align="left" style="width: 30%;">
                                                    <asp:Label ID="lblusertype" Font-Bold="true" Font-Size="Large" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%">
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Close" CssClass="btn" 
                                                        Width="80px" />
                                                        <%--OnClick="btnSubmit_Click"--%>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
