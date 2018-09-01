<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ExcelUpload.aspx.cs" Inherits="Admin_ExcelUpload" Title="eZeeTest:Upload Excel File" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 100%;" align="center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" width="80%" border="1">
                    <tr>
                        <td align="center">
                            <div style="width: 97%">
                                <table cellpadding="0" cellspacing="0" border="0" width="75%" class="tables">
                                    <tr>
                                        <td style="height: 20px;">
                                            <table style="width: 90%" class="tables" cellspacing="7px">
                                                <tr>
                                                    <td colspan="2" align="center" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                        <h3 style="color: Green">
                                                            Excel Upload</h3>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px;">
                                                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblcount" runat="server" Font-Size="Small" ForeColor="#0066FF" Text="Count"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                    <td style="text-align: right">
                                                        <asp:Label ID="lblUpdated" runat="server" Font-Size="Small" Text="Updated Count"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblcount2" runat="server" Font-Size="Small" ForeColor="#0066FF" Text="Count2"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                    <td style="text-align: right">
                                                        <asp:Label ID="lblSubmitted" runat="server" Font-Size="Small" Text="Submiited cout"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="text-align: left">
                                                        &nbsp;&nbsp;<asp:Label ID="lblError" Visible="False" runat="server" CssClass="error"
                                                            Text="Label" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                                    </td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Select Type of Language of Excel File"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="cmbSelectlang" runat="server" ToolTip="Click to select language"
                                                            AutoPostBack="True" Font-Names="Arial" CssClass="ddlcsswidth" Height="20px">
                                                            <asp:ListItem>English</asp:ListItem>
                                                            <asp:ListItem>Marathi</asp:ListItem>
                                                            <asp:ListItem>MarathiMangal</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTypeofQues" runat="server" Font-Bold="False" Font-Names="Arial"
                                                            Font-Size="11pt" Text="Select Type of Question"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlTypeofQues" runat="server" CssClass="ddlcsswidth " Height="20px">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlTypeofQues"
                                                            InitialValue="1" ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                            Font-Size="Small"></asp:RequiredFieldValidator>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 49px">
                                                        <asp:Label ID="lblTypeofMaterial" runat="server" Font-Bold="False" Font-Names="Arial"
                                                            Font-Size="11pt" Text="Select Type of Material"></asp:Label>
                                                        &nbsp;<span class="warning1" style="color: Red">*</span>
                                                    </td>
                                                    <td style="height: 49px">
                                                        <asp:RadioButtonList ID="rdoTypeofMaterial" runat="server" CssClass="radio" Font-Size="Medium"
                                                            RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rdoTypeofMaterial_SelectedIndexChanged">
                                                            <asp:ListItem Value="0">Class</asp:ListItem>
                                                            <asp:ListItem Value="1">Competitive Exam</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="rdoTypeofMaterial"
                                                            ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                            Font-Size="Small"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <%--New Row Added--%>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label12" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Select Type of Exam"></asp:Label>
                                                        <span class="warning1" style="color: Red">*</span>&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlGroupofExam" runat="server" CssClass="ddlcsswidth " AutoPostBack="true"
                                                            Height="22px" OnSelectedIndexChanged="ddlGroupofExam_SelectedIndexChanged">
                                                            <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlGroupofExam"
                                                            InitialValue="1" ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                            Enabled="False" Font-Size="Small"></asp:RequiredFieldValidator>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <%--New Row Added--%>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Select ExamName"></asp:Label>
                                                        <asp:Label ID="Label10" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="14pt"
                                                            Text="*" ForeColor="Red" Visible="False"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlTypeofExam" runat="server" CssClass="ddlcsswidth " AutoPostBack="true"
                                                            Height="22px" OnSelectedIndexChanged="ddlTypeofExam_SelectedIndexChanged">
                                                            <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlTypeofExam"
                                                            InitialValue="1" ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                            Enabled="False" Font-Size="Small"></asp:RequiredFieldValidator>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Select Class Name"></asp:Label>
                                                        <asp:Label ID="Label11" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="14pt"
                                                            Text="*" ForeColor="Red" Visible="False"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlAddClass" runat="server" CssClass="ddlcsswidth " AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlAddClass_SelectedIndexChanged">
                                                            <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlAddClass"
                                                            InitialValue="1" ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                            Enabled="False" Font-Size="Small"></asp:RequiredFieldValidator>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Select Medium  Name"></asp:Label>
                                                        <span class="warning1" style="color: Red;">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlMedium" runat="server" CssClass="ddlcsswidth " OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">English</asp:ListItem>
                                                            <asp:ListItem Value="2">Semi-English</asp:ListItem>
                                                            <asp:ListItem Value="3">Marathi</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlMedium"
                                                            InitialValue="0" ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                            Font-Size="Small" Enabled="False"></asp:RequiredFieldValidator>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Select Subject"></asp:Label>
                                                        &nbsp;<span class="warning1" style="color: Red;">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="cmbSelectsubject" runat="server" CssClass="ddlcsswidth " OnSelectedIndexChanged="cmbSelectsubject_SelectedIndexChanged">
                                                            <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbSelectsubject"
                                                            ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                            InitialValue="1" Font-Size="Small"></asp:RequiredFieldValidator>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Select Topic/Chapter"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlChapter" runat="server" CssClass="ddlcsswidth ">
                                                        </asp:DropDownList>
                                                        <br />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlChapter"
                                                            ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                             Font-Size="Small" Enabled="False"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblpublication" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Select Publication"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlpublication" runat="server" CssClass="ddlcsswidth ">
                                                        </asp:DropDownList>
                                                        <br />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlpublication"
                                                            ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                            InitialValue="1" Font-Size="Small" Enabled="False"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label9" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Select Sub Topic"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td style="height: 31px; width: 400px;">
                                                        <asp:DropDownList ID="ddlTopic" runat="server" CssClass="ddlcsswidth ">
                                                            <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlTopic"
                                                            ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                            InitialValue="1" Font-Size="Small" ></asp:RequiredFieldValidator>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
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
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Enter Mobile No."></asp:Label>
                                                        &nbsp;<span class="warning1" style="color: Red;">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMobileNo2" runat="server" MaxLength="10" onkeypress="return numbersonly(this,event)"
                                                            Height="20px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobileNo2"
                                                            ErrorMessage="*" Font-Size="Small" SetFocusOnError="True" ValidationGroup="other"
                                                            Width="172px"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtMobileNo2"
                                                            Display="Dynamic" ErrorMessage="&lt;br&gt;Mobile Number must be 10 digit" Font-Size="12px"
                                                            ValidationExpression="^[0-9]{10}$" ValidationGroup="other"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" style="text-align: left">
                                                        <asp:Button ID="btnDowmLoad" runat="server" CssClass="btn" OnClick="btnDowmLoad_Click"
                                                            Text="DownLoad Excel Format" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <%-- <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" ValidationGroup="other" usesubmitbehavior="true" OnClientClick="if(!confirm('Please Make sure to attach correct File and Select correct options !!')) return false;"
                                                    OnClick="btnSubmit_Click1"  />--%>
                                                        <%-- OnClientClick="return confirm('Please Make sure to attach correct File and Select correct options !!');"--%>
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" ValidationGroup="other"
                                                            OnClick="btnSubmit_Click1" />
                                                        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" CssClass="btn" Text="Back"
                                                            OnClick="btnBack_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSubmit" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
