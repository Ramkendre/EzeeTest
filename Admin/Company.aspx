<%@ Page Title="eZeeTest:Add Institute" Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Company.aspx.cs" Inherits="Admin_Company" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 100%;" align="center">
                <table cellpadding="0" cellspacing="0" width="60%" border="1">
                    <tr>
                        <td align="center" style="font-size: medium; font-family: 'Times New Roman', Times, serif">
                            <div style="width: 95%">
                                <table cellpadding="0" cellspacing="0" border="0" class="tables" style="width: 80%;">
                                    <tr>
                                        <td colspan="2" style="height: 20px;">
                                            <center>
                                                <table style="width: 90%" class="tables" cellspacing="2" cellpadding="2">
                                                    <tr>
                                                        <td align="center" colspan="5" style="font-size: large">
                                                            <h3 style="color: Green">College/School/Institute Profile</h3>


                                                            &nbsp;&nbsp;<asp:Label ID="lblError" Visible="false" runat="server" CssClass="error"
                                                                Text="Label"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 20px;">
                                                            <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 27%; text-align: left;">
                                                            <asp:Label ID="lblCollegeIDSchoolID" runat="server" Font-Bold="False" Font-Names="Arial"
                                                                Font-Size="11pt" Text="College ID/School ID"></asp:Label>
                                                            &nbsp;:</td>

                                                        <td align="left" style="width: 30%;">
                                                            <asp:Label ID="lblId" runat="server" Text="0"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="text-align: left;">
                                                            <asp:Label ID="lblCollegeNameSchoolName" runat="server" Font-Bold="False" Font-Names="Arial"
                                                                Font-Size="11pt" Text="CollegeName/SchoolName" Width="200px"></asp:Label>
                                                            <span class="warning1" style="color: Red;">*</span>

                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCompanyName" MaxLength="100" Height="30px" Width="257px" placeholder="Enter Your Institution Name" runat="server"></asp:TextBox>

                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="text-align: left;">
                                                            <asp:Label ID="lblDisplayName" runat="server" Font-Bold="False" Font-Names="Arial"
                                                                Font-Size="11pt" Text="Display Name (Short Name)"></asp:Label>&nbsp;<span class="warning1"
                                                                    style="color: Red;">*</span>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtDisplayName" runat="server" CssClass="txtcss " MaxLength="100"
                                                                Height="25px" Width="251px"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="text-align: left;">
                                                            <asp:Label ID="lblAddress1" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text="Address"></asp:Label>&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtAddress1" TextMode="MultiLine" MaxLength="100" runat="server"
                                                                CssClass="txtcss " Height="31px" Width="248px"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="text-align: left;">
                                                            <asp:Label ID="lblStateName" runat="server" Font-Bold="False" Font-Names="Arial"
                                                                Font-Size="11pt" Text="State Name"></asp:Label>&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlState" runat="server" CssClass="ddlcsswidth" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlState_SelectedIndexChanged" Width="137px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="text-align: left;">
                                                            <asp:Label ID="lblDistrict" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text="District "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="ddlcsswidth" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Width="137px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="text-align: left;">
                                                            <asp:Label ID="lbltaluka" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text="Taluka "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlTaluka" runat="server" CssClass="ddlcsswidth" AutoPostBack="True"
                                                                Width="137px" OnSelectedIndexChanged="ddlTaluka_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="text-align: left;">
                                                            <asp:Label ID="lblCityName" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text="City Name "></asp:Label>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                                                runat="server" ControlToValidate="ddlCity" Font-Size="Medium" ValidationGroup="save"
                                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="left">

                                                            <asp:DropDownList ID="ddlCity" Visible="false" runat="server" CssClass="ddlcsswidth" Height="25"
                                                                Width="137px" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                                                            </asp:DropDownList>

                                                            <asp:TextBox ID="txtCityName" runat="server" BorderStyle="Inset" Height="25px" placeholder="Enter CityName"></asp:TextBox>

                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="text-align: left;">
                                                            <asp:Label ID="lblPinCode" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text="Pin Code "></asp:Label>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                                                ValidationGroup="save" runat="server" ControlToValidate="txtPin" Font-Size="Medium"
                                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPin" runat="server" onkeypress="return numbersonly(this,event)"
                                                                CssClass="txtcss" MaxLength="6" Width="94px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                                ControlToValidate="txtPin" Display="Dynamic"
                                                                ErrorMessage="&lt;br&gt;Pin code must be 6 digit" Font-Size="12px"
                                                                ValidationExpression="[0-9]{6}" ValidationGroup="save" Width="200px"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td class="error" height="25px" width="200px">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="text-align: left;">
                                                            <asp:Label ID="lblMobileNo1" runat="server" Font-Bold="False" Font-Names="Arial"
                                                                Font-Size="11pt" Text=" Mobile No1  "></asp:Label>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                                                runat="server" ControlToValidate="txtMobile1" Font-Size="Medium" ValidationGroup="save"
                                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMobile1" Width="120px" MaxLength="10" runat="server"
                                                                onkeypress="return numbersonly(this,event)" CssClass="txtcss"
                                                                ReadOnly="true"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                                                ControlToValidate="txtMobile1" Display="Dynamic"
                                                                ErrorMessage="&lt;br&gt;Mobile Number must be 10 digit" Font-Size="12px"
                                                                ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td class="error">&nbsp;</td>
                                                    </tr>
                                                    <tr>


                                                        <td align="left" style="text-align: left;">
                                                            <asp:Label ID="lblPhoneNo1" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text="Phone No1 "></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPhone1" MaxLength="13" runat="server" onkeypress="return numbersonly(this,event)"
                                                                CssClass="txtcss" Width="116px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                                                ControlToValidate="txtPhone1" Display="Dynamic"
                                                                ErrorMessage="&lt;br&gt;Telephone Number must be 8 to 13 digit"
                                                                Font-Size="12px" ValidationExpression="^[0-9]{8,13}$" ValidationGroup="save"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="text-align: left;">
                                                            <asp:Label ID="lblFaxNo" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text=" Fax No "></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFax" MaxLength="12" runat="server" CssClass="txtcss" Width="115px"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="text-align: left;">
                                                            <asp:Label ID="lblEmailId" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text=" EmailId "></asp:Label>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                                                runat="server" ControlToValidate="txtEmail" Font-Size="Medium" ValidationGroup="save"
                                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="txtcss" Width="120px"
                                                                MaxLength="100"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                                                ControlToValidate="txtEmail" Display="Dynamic"
                                                                ErrorMessage="Enter Proper Email Id" Font-Size="12px"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ValidationGroup="save"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblAdmissionQuota" runat="server" Font-Bold="False"
                                                                Font-Names="Arial" Font-Size="11pt"
                                                                Text="  No. of Admissions Quota "></asp:Label>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                                runat="server" ControlToValidate="txtAdmissionsQuota"
                                                                Font-Size="Medium" ValidationGroup="save"
                                                                ErrorMessage="*" Font-Bold="True" Enabled="False"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAdmissionsQuota" runat="server" CssClass="txtcss" Width="120px"
                                                                MaxLength="5">0</asp:TextBox>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td colspan="2" align="center" style="padding-right: 20px;">
                                                            <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn" OnClick="btnSubmit_Click"
                                                                Width="80px" ValidationGroup="save" />
                                                            &nbsp;&nbsp;
                                                    <asp:Button ID="btnDelete" runat="server" Visible="false" CssClass="btn" OnClick="btnDelete_Click" OnClientClick="return confirmationDelete();"
                                                        Text="Delete" Width="81px" />

                                                            &nbsp;
                                                    <asp:Button ID="btnBack" runat="server" CssClass="btn" OnClick="btnBack_Click" Text="Back" PostBackUrl="~/Admin/Home.aspx" CausesValidation="false" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        </td>
                                                        <td align="right" style="padding-right: 20px;">&nbsp;
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </center>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
