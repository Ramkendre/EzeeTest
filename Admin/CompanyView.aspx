<%@ Page Title="eZeeTest:Institution Details" Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="CompanyView.aspx.cs" Inherits="Admin_CompanyView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div style="width:100%;" align="center">
            <table width="90%" border="2" cellpadding="0" cellspacing="0" class="tables">
                <tr>
                    <td>
                        <div align="center" width="90%" style="font-size:medium" >
                            <table width="98%" border="0" cellpadding="0" cellspacing="0"  >
                                <tr>
                                    <td>
                                    <tr>
                                        <td>
                                            School/College ID :
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Label ID="lblId" runat="server"></asp:Label></b>
                                        </td>
                                    </tr>
                                <tr>
                                    <td width="17%">
                                        School/College Name :
                                    </td>
                                    <td>
                                        <b>
                                            <asp:Label ID="lblCompanyName" runat="server"></asp:Label></b>
                                    </td>
                                    <td width="13%">
                                        DisplayName :
                                    </td>
                                    <td>
                                        <b>
                                            <asp:Label ID="lblDisplayName" runat="server"></asp:Label></b>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        Address1 :
                                    </td>
                                    <td>
                                        <b>
                                            <asp:Label ID="lblAddress1" runat="server"></asp:Label></b>
                                    </td>
                                    <td>
                                        Address2 :
                                    </td>
                                    <td>
                                        <b>
                                            <asp:Label ID="lblAddress2" runat="server"></asp:Label></b>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td>
                                        StateName :
                                    </td>
                                    <td>
                                        <b>
                                            <asp:Label ID="lblStateName" runat="server"></asp:Label></b>
                                    </td>
                                    <td>
                                        DisrtictName :
                                    </td>
                                    <td>
                                        <b>
                                            <asp:Label ID="lblDisrictName" runat="server"></asp:Label></b>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        CityName :
                                    </td>
                                    <td>
                                        <b>
                                            <asp:Label ID="lblCityName" runat="server"></asp:Label></b>
                                    </td>
                                    <td>
                                        PinCode :
                                    </td>
                                    <td>
                                        <b>
                                            <asp:Label ID="lblPinCode" runat="server"></asp:Label></b>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        MobileNo1 :
                                    </td>
                                    <td>
                                        <b>
                                            <asp:Label ID="lblMobileNo1" runat="server"></asp:Label></b>
                                    </td>
                                    <td>
                                        MobileNo2 :
                                    </td>
                                    <td>
                                        <b>
                                            <asp:Label ID="lblMobileNo2" runat="server"></asp:Label></b>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        Phone1 :
                                    </td>
                                    <td>
                                        <b>
                                            <asp:Label ID="lblPhone1" runat="server"></asp:Label></b>
                                    </td>
                                    <td>
                                        Phone2 :
                                    </td>
                                    <td>
                                        <b>
                                            <asp:Label ID="lblPhone2" runat="server"></asp:Label></b>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        FaxNo :
                                    </td>
                                    <td>
                                        <b>
                                            <asp:Label ID="lblFaxNo" runat="server"></asp:Label></b>
                                    </td>
                                    <td>
                                        EmailId :
                                    </td>
                                    <td>
                                        <b>
                                            <asp:Label ID="lblEmailId" runat="server"></asp:Label></b>
                                    </td>
                                </tr>
                                
                            </table>
                            <br />
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn" 
                                PostBackUrl="~/Admin/CompanyList.aspx" onclick="btnBack_Click" />
                        </div>
                    </td>
                </tr>
            </table></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
