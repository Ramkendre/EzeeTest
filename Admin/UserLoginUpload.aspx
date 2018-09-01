<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="UserLoginUpload.aspx.cs" Inherits="Admin_UserLoginUpload" Title="Upload StudentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 100%;" align="center">
        <table cellpadding="0" cellspacing="0" width="70%" border="1">
            <tr>
                <td align="center">
                    <div style="width: 87%">
                        <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                            <tr>
                                <td style="height: 20px;">
                                    <table style="width: 80%" class="tables" cellspacing="7px">
                                        <tr>
                                            <td colspan="2" align="center" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                <h3 style="color: Green">
                                                    Student List Upload</h3>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px;">
                                                <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center" style="text-align: left; font-size: small; font-family: 'Times New Roman', Times, serif;">
                                                <h4>
                                                    Please Upload Only Student List and Excel file should be .xls format</h4>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblcount2" runat="server" Font-Size="Medium" ForeColor="#0066FF" Text="Count2"
                                                    Visible="False"></asp:Label>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblcount" runat="server" Font-Size="Medium" ForeColor="#0066FF" Text="Count"
                                                    Visible="False"></asp:Label>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="ExistLoginId" runat="server" Text="" Font-Bold="true" ForeColor="BlueViolet"></asp:Label>
                                                &nbsp;<asp:Label ID="lblAlready" runat="server" Visible="false" Font-Bold="true" Text="Already Exists..!!!" ForeColor="BlueViolet"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right; vertical-align: top;">
                                                <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Select Excel File"></asp:Label>
                                                <span class="warning1" style="color: Red;">*</span>
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUpload1"
                                                    ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                    Font-Size="Small"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="text-align: center">
                                                <asp:Button ID="btnDowmLoad" runat="server" CssClass="btn" Text="DownLoad Student Excel Format"
                                                    Width="210px" OnClick="btnDowmLoad_Click" />
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" ValidationGroup="other"
                                                    OnClick="btnSubmit_Click1" />
                                                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" CssClass="btn" Text="Back"
                                                    PostBackUrl="~/Admin/UserList.aspx" />
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnRegister" runat="server" CssClass="btn" Text="Register" Visible="false"
                                                    OnClick="btnRegister_Click" />
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
        </table>
    </div>
</asp:Content>
