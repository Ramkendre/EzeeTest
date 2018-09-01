<%@ Page Title="Upload CenterCode File" Language="C#" MasterPageFile="~/Layout/AdminMaster.master"
    AutoEventWireup="true" CodeFile="UploadCenterCode.aspx.cs" Inherits="Admin_UploadCenterCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 100%;" align="center">
        <table cellpadding="0" cellspacing="0" width="75%" border="1" class="tables">
            <tr>
                <td style="text-align: center;">
                    <div style="width: 100%">
                        <center>
                            <table cellpadding="2" cellspacing="2" width="75%" class="tables">
                                <tr>
                                    <td colspan="4" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                        <h3 style="color: Green">
                                            Center Code File Upload
                                        </h3>
                                    </td>
                                    <%--<td>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>--%>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left">
                                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: left; height: 20px">
                                        <asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Error"
                                            Font-Size="Medium" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: left; height: 20px">
                                        <asp:Label ID="lblinsert" Visible="false" runat="server" CssClass="error" Text="Insert"
                                            Font-Size="Medium" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: left; height: 20px">
                                        <asp:Label ID="lblupdate" Visible="false" runat="server" CssClass="error" Text="Update"
                                            Font-Size="Medium" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center">
                                        <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Select Excel CenterCode File "></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUpload1"
                                            ErrorMessage="*" Font-Size="Small" SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center">
                                        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click" Text="Upload file"
                                            ValidationGroup="other" Width="71px" />
                                        &nbsp;<asp:Button ID="btncancel" runat="server" CssClass="btn" Text="Cancel" />
                                        &nbsp;
                                        <asp:Button ID="btnback" runat="server" CssClass="btn" PostBackUrl="~/Admin/CompanyList.aspx"
                                            Text="Back" />
                                        <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Download Format" OnClick="Button1_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center;">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
