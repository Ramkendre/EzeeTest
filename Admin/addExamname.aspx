<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="addExamname.aspx.cs" Inherits="addExamname" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;
    <table cellpadding="0" cellspacing="0" width="70%" border="1">
        <tr>
            <td align="center">
                <div style="width: 80%; margin-left: 34px; margin-right: 19px;">
                    <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                        <tr>
                            <td colspan="2" style="height: 20px;">
                                <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 20px;">
                                <table style="width: 97%; margin-left: 36px; height: 238px;" class="tables" 
                                    cellspacing="7px">
                                    <tr>
                                        <td colspan="4" align="center" style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                            <b>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Add Exam Name
                                            
                                            </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="width: 45%; text-align: left;">
                                            <asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Label"></asp:Label><asp:Label
                                                ID="lblSuccess" runat="server" Visible="False" CssClass="error"></asp:Label><br />
                                            <asp:Label ID="Label1" runat="server" CssClass="error"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 628px; text-align: right;">
                                            <asp:Label ID="lblSelectCollegeName" runat="server" Font-Bold="False" Font-Names="Arial"
                                                Font-Size="11pt" Text="Select School/ College Name"></asp:Label>
                                        </td>
                                        <td style="height: 31px">
                                            <asp:DropDownList ID="ddlCollege" runat="server" AutoPostBack="True" CssClass="ddlcsswidth "
                                                OnSelectedIndexChanged="ddlCollege_SelectedIndexChanged1">
                                            </asp:DropDownList>
                                            <br />
                                        </td>
                                        <td class="error" style="height: 29px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCollege"
                                                ErrorMessage="You have not selected college name" SetFocusOnError="True" Width="225px"
                                                ValidationGroup="other"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 628px; text-align: right;">
                                            <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Type of Exam"></asp:Label>
                                            &nbsp;<span class="warning1" style="color: Red;">*</span>
                                        </td>
                                        <td style="height: 31px">
                                            <asp:DropDownList ID="ddlTypeofExam" runat="server" AutoPostBack="True" CssClass="ddlcsswidth "
                                                OnSelectedIndexChanged="ddlTypeofExam_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <br />
                                        </td>
                                        <td class="error" style="height: 29px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlTypeofExam"
                                                ErrorMessage="You have not selected Type of Exam" SetFocusOnError="True" Width="225px"
                                                ValidationGroup="other"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 628px; text-align: right;">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Class Name"></asp:Label>
                                            &nbsp;
                                        </td>
                                        <td style="height: 31px">
                                            <asp:DropDownList ID="ddlAddClass" runat="server" AutoPostBack="True" CssClass="ddlcsswidth "
                                                OnSelectedIndexChanged="ddlAddClass_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <br />
                                        </td>
                                        <%-- <td class="error" style="height: 29px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlAddClass"
                                                ErrorMessage="You have not selected Class name" SetFocusOnError="True" Width="225px"
                                                ValidationGroup="other"></asp:RequiredFieldValidator>
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td style="width: 628px; text-align: right;">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Medium  Name"></asp:Label>
                                            &nbsp;
                                        </td>
                                        <td style="height: 31px">
                                            <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" CssClass="ddlcsswidth "
                                                OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">English</asp:ListItem>
                                                <asp:ListItem Value="2">Semi-English</asp:ListItem>
                                                <asp:ListItem Value="3">Marathi</asp:ListItem>
                                            </asp:DropDownList>
                                            <br />
                                        </td>
                                        <td class="error" style="height: 29px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 628px; text-align: right;">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Subject"></asp:Label>
                                            &nbsp;<span class="warning1" style="color: Red;">*</span>
                                        </td>
                                        <td style="height: 31px">
                                            <asp:DropDownList ID="cmbSelectsubject" runat="server" AutoPostBack="True" CssClass="ddlcsswidth "
                                                OnSelectedIndexChanged="cmbSelectsubject_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <br />
                                        </td>
                                        <td class="error" style="height: 29px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cmbSelectsubject"
                                                ErrorMessage="You have not selected Subject" SetFocusOnError="True" Width="225px"
                                                ValidationGroup="other"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 628px; text-align: right;">
                                            <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Topic/Chapter"></asp:Label>
                                            &nbsp;<span class="warning1" style="color: Red;">*</span>
                                        </td>
                                        <td style="height: 31px">
                                            <asp:DropDownList ID="ddlChapter" runat="server" AutoPostBack="True" CssClass="ddlcsswidth "
                                                OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <br />
                                        </td>
                                       
                                    </tr>
                                    <tr>
                                        <td style="width: 628px; text-align: right;">
                                            <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Sub Topic"></asp:Label>
                                            &nbsp;
                                        </td>
                                        <td style="height: 31px">
                                            <asp:DropDownList ID="ddlTopic" runat="server" AutoPostBack="True" CssClass="ddlcsswidth "
                                                OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 628px; text-align: right;">
                                            <asp:Label ID="lblAddExamName" runat="server" Font-Bold="False" Font-Names="Arial"
                                                Font-Size="11pt" Text=" Add Exam Name"></asp:Label>
                                            &nbsp;<span class="warning1" style="color: Red;">*</span>
                                        </td>
                                        <td style="height: 29px">
                                            <asp:TextBox ID="txtexamname" runat="server" CssClass="txthiwidth" ToolTip="Click here to enter subject"></asp:TextBox>
                                            <br />
                                        </td>
                                        <td class="error" style="height: 29px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtexamname"
                                                ErrorMessage="You have not entered subject name" SetFocusOnError="True" Width="225px"
                                                ValidationGroup="other"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 628px" class="style1">
                                        </td>
                                        <td colspan="2" align="center" style="text-align: left">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" ValidationGroup="other"
                                                CssClass="btn" />
                                            &nbsp;
                                            <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btncancel_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnback" runat="server" Text="Back" CssClass="btn" PostBackUrl="~/Admin/Home.aspx" />
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
                                                        <asp:GridView ID="gvcompetitive" runat="server" Width="122%" CssClass="datatable "
                                                            Visible="false" OnRowCommand="gdExam_RowCommand" OnPageIndexChanging="gdExam_PageIndexChanging"
                                                            CellPadding="5" CellSpacing="0" GridLines="None" AutoGenerateColumns="False"
                                                            AllowPaging="True" EmptyDataText="Exam  List is not available." PageSize="15"
                                                            OnRowDeleted="gdExam_RowDeleted" OnRowDeleting="gdExam_RowDeleting" OnSelectedIndexChanged="gdExam_SelectedIndexChanged"
                                                            OnRowDataBound="gdExam_RowDataBound">
                                                            <Columns>
                                                                <asp:BoundField DataField="Id" HeaderText="Id">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="examname" HeaderText="Exam Name">
                                                                    <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <%--<asp:BoundField DataField="Class_id" HeaderText="Class Name">
                                                                    <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                </asp:BoundField>--%>
                                                                <asp:BoundField DataField="Subject_id" HeaderText="Subject Name">
                                                                    <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Chapter_id" HeaderText="Chapter Name">
                                                                    <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="MediumID" HeaderText="Medium Name">
                                                                    <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="TypeOfExam" HeaderText="Exam Type">
                                                                    <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Modify">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("Id") %>' runat="server"
                                                                            ImageUrl="../resources/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("Id") %>' runat="server"
                                                                            ImageUrl="../resources/images/close.gif" CommandName="Delete"></asp:ImageButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <PagerStyle CssClass="pager-row" />
                                                        </asp:GridView>
                                                        <asp:GridView ID="gdExam" runat="server" Width="122%" CssClass="datatable " Visible="false"
                                                            OnRowCommand="gdExam_RowCommand" OnPageIndexChanging="gdExam_PageIndexChanging"
                                                            CellPadding="5" CellSpacing="0" GridLines="None" AutoGenerateColumns="False"
                                                            AllowPaging="True" EmptyDataText="Exam  List is not available." PageSize="15"
                                                            OnRowDeleted="gdExam_RowDeleted" OnRowDeleting="gdExam_RowDeleting" OnSelectedIndexChanged="gdExam_SelectedIndexChanged"
                                                            OnRowDataBound="gdExam_RowDataBound">
                                                            <Columns>
                                                                <asp:BoundField DataField="Id" HeaderText="Id">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="examname" HeaderText="Exam Name">
                                                                    <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Class_id" HeaderText="Class Name">
                                                                    <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Subject_id" HeaderText="Subject Name">
                                                                    <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Chapter_id" HeaderText="Chapter Name">
                                                                    <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Topic_id" HeaderText="Topic Name">
                                                                    <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="MediumID" HeaderText="Medium Name">
                                                                    <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="TypeOfExam" HeaderText="Exam Type">
                                                                    <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Modify">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("Id") %>' runat="server"
                                                                            ImageUrl="../resources/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("Id") %>' runat="server"
                                                                            ImageUrl="../resources/images/close.gif" CommandName="Delete"></asp:ImageButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <PagerStyle CssClass="pager-row" />
                                                        </asp:GridView>
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
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
