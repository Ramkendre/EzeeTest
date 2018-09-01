<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true" CodeFile="AssignChapter.aspx.cs" Inherits="Admin_AssignChapter" Title="Assign Chapter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 100%;" align="center">
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" width="85%" border="1">
                    <tr>
                        <td align="center">
                            <div style="width: 90%; margin-left: 34px; margin-right: 19px;">
                                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                    <tr>
                                        <td colspan="2" style="height: 20px;">
                                            <table style="width: 97%; margin-left: 36px; height: 238px;" class="tables" cellspacing="7px">
                                                <tr>
                                                    <td colspan="2" align="center" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                        <h3 style="color: Green">
                                                            Assign Chapter</h3>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 20px;">
                                                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3" style="width: 45%; text-align: left;">
                                                        <asp:Label ID="lblError" Visible="False" runat="server" CssClass="error" Text="Label"
                                                            ForeColor="Red"></asp:Label><asp:Label ID="lblSuccess" runat="server" Visible="False"
                                                                CssClass="error"></asp:Label><br />
                                                        <asp:Label ID="Label1" runat="server" CssClass="error"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="User Name"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblUserName" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12pt"
                                                            Text="UserName"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTypeofMaterial" runat="server" Font-Bold="False" Font-Names="Arial"
                                                            Font-Size="11pt" Text="Select Type of Material"></asp:Label>
                                                        <span class="warning1" style="color: Red;">&nbsp;*</span>
                                                    </td>
                                                    <td>
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
                                                        <asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Select Type of Exam"></asp:Label>
                                                        <span class="warning1" style="color: Red">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlGroupofExam" runat="server" CssClass="ddlcsswidth " AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlGroupofExam_SelectedIndexChanged1">
                                                            <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlGroupofExam"
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
                                                        <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="14pt"
                                                            Text="*" ForeColor="Red" Visible="False"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlTypeofExam" runat="server" CssClass="ddlcsswidth " AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlTypeofExam_SelectedIndexChanged1">
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
                                                        <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Select Class Name"></asp:Label>
                                                        <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="14pt"
                                                            Text="*" ForeColor="Red" Visible="False"></asp:Label>
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
                                                        <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Select Subject"></asp:Label>
                                                        &nbsp;<span class="warning1" style="color: Red;">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="cmbSelectsubject" runat="server" CssClass="ddlcsswidth" AutoPostBack="true" OnSelectedIndexChanged="cmbSelectsubject_SelectedIndexChanged">
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
                                                        <%--Select Chapter from Grid&nbsp;&nbsp;--%>
                                                    </td>
                                                    <td>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="41px"></asp:TextBox>
                                                    </td>
                                                    <td colspan="2" align="center" style="text-align: left">
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                                            ValidationGroup="other" CssClass="btn" />
                                                        &nbsp;
                                                        <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btncancel_Click" />
                                                        &nbsp;
                                                        <asp:Button ID="btnback" runat="server" Text="Back" CssClass="btn" PostBackUrl="~/Admin/UserList.aspx"
                                                            OnClick="btnback_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="font-family: Times New Roman; font-size: medium; color: Maroon; font-weight: bold">
                                                        Select Chapter From Below List
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <div class="mid">
                                                <div class="grid" style="width: 70%; margin-right: 102px;">
                                                    <div class="rounded">
                                                        <div class="top-outer">
                                                            <div class="top-inner">
                                                                <div class="top" style="height: 20px; width: 557px; margin-left: 0px;">
                                                                    &nbsp;
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="mid-outer">
                                                            <div class="mid-inner">
                                                                <div class="pager" style="width: 424px">
                                                                    <asp:UpdatePanel ID="panel1" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:GridView ID="gvChapter" runat="server" Width="122%" CssClass="datatable " CellPadding="5"
                                                                                GridLines="None" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="Exam  List is not available."
                                                                                PageSize="35" OnPageIndexChanged="gvChapter_PageIndexChanged" OnPageIndexChanging="gvChapter_PageIndexChanging"
                                                                                OnRowDataBound="gvChapter_RowDataBound" OnRowDeleting="gvChapter_RowDeleting">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="ItemValueId" HeaderText="Chapter Id">
                                                                                        <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Name" HeaderText="Chapter Name">
                                                                                        <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="Assign Chapter" ItemStyle-Width="30%" ItemStyle-HorizontalAlign="left">
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <PagerStyle CssClass="pager-row" />
                                                                            </asp:GridView>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                    <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bottom-outer">
                                                        <div class="bottom-inner">
                                                            <div class="bottom">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="mid">
                                                <div class="grid" style="width: 95%; margin-right: 102px;">
                                                    <div class="rounded">
                                                        <div class="top-outer">
                                                            <div class="top-inner">
                                                                <div class="top" style="height: 20px; width: 857px; margin-left: 0px;">
                                                                    &nbsp;
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="mid-outer">
                                                            <div class="mid-inner">
                                                                <div class="pager" style="width: 700px">
                                                                    <asp:GridView ID="gvAssignChapter" runat="server" Width="122%" CssClass="datatable "
                                                                        CellPadding="5" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                                        EmptyDataText="Exam  List is not available." PageSize="15" OnRowCommand="gvAssignChapter_RowCommand"
                                                                        OnRowDeleted="gvAssignChapter_RowDeleted" OnRowDeleting="gvAssignChapter_RowDeleting"
                                                                        OnRowUpdated="gvAssignChapter_RowUpdated" OnRowUpdating="gvAssignChapter_RowUpdating"
                                                                        OnPageIndexChanging="gvAssignChapter_PageIndexChanging" OnRowDataBound="gvAssignChapter_RowDataBound">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="Id" HeaderText="SNO">
                                                                                <HeaderStyle HorizontalAlign="left" Width="10%"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="ItemValueId" HeaderText="Chapter Id">
                                                                                <HeaderStyle HorizontalAlign="left" Width="35%"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="left" Width="35%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Subject_id" HeaderText="Subject Name">
                                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Class_id" HeaderText="Class Name">
                                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="TypeofMaterial" HeaderText="Type of Material">
                                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="TypeOFExam" HeaderText="Type of exam">
                                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="Delete">
                                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("Id") %>' runat="server"
                                                                                        OnClientClick="if(!confirm(' Are you Sure to Delete ?')) return false;" ImageUrl="../resources/images/close.gif"
                                                                                        CommandName="Delete"></asp:ImageButton>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <PagerStyle CssClass="pager-row" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bottom-outer">
                                                        <div class="bottom-inner">
                                                            <div class="bottom">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSubmit" />
                <asp:PostBackTrigger ControlID="cmbSelectsubject" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
