<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AddExamChapter.aspx.cs" Inherits="Admin_AddExamChapter" Title="eZeeTest:Assign Chapter to Test" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script language="javascript" type="text/javascript">

        function check(checkbox) {
            var cbl = document.getElementById('<%=chkChapter.ClientID %>').getElementsByTagName("input");
            for (i = 0; i < cbl.length; i++)
                cbl[i].checked = checkbox.checked;
        }

    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:LinkButton ID="lnkbtnBackToPanel" runat="server" Visible="false" Text="<<< Back To Panel" Font-Bold="true" ForeColor="HighlightText" PostBackUrl="~/CreateTest/createtest.aspx"></asp:LinkButton>
            <div style="width: 100%;" align="center">
                <table cellpadding="0" cellspacing="0" width="70%" border="1">
                    <tr>
                        <td align="center">
                            <div style="width: 85%">
                                <table cellpadding="0" cellspacing="0" border="0" width="85%" class="tables">
                                    <caption>
                                        <h3 style="color: Green; font-family: Times New Roman; font-size: x-large;">Add Chapter for Exam &nbsp;</h3>
                                        <tr>
                                            <td>
                                                <center>
                                                    <table class="tables" style="width: 75%">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="lblError" runat="server" CssClass="error" Visible="false"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 628px; text-align: left;">
                                                                <asp:Label ID="lblGroupOFQues" runat="server" Font-Bold="False" Font-Names="Arial"
                                                                    Font-Size="11pt" Text="Select Group of Questions" Width="190px"></asp:Label>
                                                                <span class="warning1" style="color: Red;">*&nbsp;</span>
                                                            </td>
                                                            <td style="height: 31px; width: 200px;">
                                                                <asp:RadioButtonList ID="rdoGroupOFQues" runat="server" AutoPostBack="True" CssClass="radio"
                                                                    Font-Size="Medium"
                                                                    RepeatDirection="Vertical" Width="203px"
                                                                    OnSelectedIndexChanged="rdoGroupOFQues_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">Objective Question</asp:ListItem>
                                                                    <asp:ListItem Value="1">Theory Question</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td class="error" style="height: 29px">&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rdoGroupOFQues"
                                                                ErrorMessage="You have not selected Group of Questions" Font-Size="Small" SetFocusOnError="True"
                                                                ValidationGroup="other" Width="225px"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbltext" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select Test Name"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddltextName" runat="server" CssClass="ddlcsswidth " AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddltextName_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddltextName"
                                                                    Enabled="True" ErrorMessage="*" Font-Size="Small"
                                                                    InitialValue="--Select--" SetFocusOnError="True"
                                                                    ValidationGroup="other"></asp:RequiredFieldValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                                    ControlToValidate="ddltextName" ErrorMessage="You have not selected Test name"
                                                                    Font-Size="Small" SetFocusOnError="True" ValidationGroup="other" Width="225px"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select Subject" Width="100px"></asp:Label>
                                                                <span class="warning1" style="color: Red;">*</span>&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="cmbSelectsubject" runat="server" CssClass="ddlcsswidth" AutoPostBack="true"
                                                                    OnSelectedIndexChanged="cmbSelectsubject_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbSelectsubject"
                                                                    Enabled="True" ErrorMessage="*" Font-Size="Small"
                                                                    InitialValue="--Select--" SetFocusOnError="True"
                                                                    ValidationGroup="other"></asp:RequiredFieldValidator>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select Chapter" Width="150px"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <div class="container">
                                                                    <asp:CheckBox ID="ChkSelectALL" runat="server" onClick="check(this)"
                                                                        Text="Select ALL Chapter"
                                                                        Visible="False" />
                                                                    <asp:CheckBoxList ID="chkChapter" runat="server" RepeatColumns="1" BorderWidth="0px"
                                                                        Datafield="description" DataValueField="value"
                                                                        OnSelectedIndexChanged="chkChapter_SelectedIndexChanged">
                                                                    </asp:CheckBoxList>
                                                                    <br />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td>&nbsp;<asp:Button ID="btnStart" runat="server" CssClass="btn" Text="Submit" ToolTip="Click here to start the test"
                                                                ValidationGroup="other" OnClick="btnStart_Click" />
                                                                &nbsp;
                                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn"
                                                                Text="Cancel" ToolTip="Click here to Cancel" CausesValidation="false" ValidationGroup="other"
                                                                OnClick="btnCancel_Click" />
                                                                &nbsp;&nbsp;
                                                             <asp:Button ID="btnback" runat="server" CssClass="btn" PostBackUrl="~/Admin/Home.aspx"
                                                                 Text="Back" ToolTip="Click here to Back" />
                                                                &nbsp;&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </center>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <center>
                                                    <div class="grid" style="width: 85%">
                                                        <div class="rounded">
                                                            <div class="top-outer">
                                                                <div class="top-inner">
                                                                    <div class="top">
                                                                        &nbsp;
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="mid-outer">
                                                                <div class="mid-inner">
                                                                    <div class="mid">
                                                                        <div class="pager">
                                                                            <asp:GridView ID="gvchapter" runat="server" Width="100%" CssClass="datatable"
                                                                                CellPadding="5" CellSpacing="0"
                                                                                GridLines="None" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="Chapter List is not available."
                                                                                PageSize="25" OnRowCommand="gvchapter_RowCommand"
                                                                                OnSelectedIndexChanged="gvchapter_SelectedIndexChanged">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="AecID" HeaderText="Id">
                                                                                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Exam_name" HeaderText="Test Name">
                                                                                        <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Name" HeaderText="Subject Name">
                                                                                        <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="ChapterName" HeaderText="Chapter Name">
                                                                                        <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="Modify">
                                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("AecID")%>' runat="server"
                                                                                                ImageUrl="../resources/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
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
                                                </center>
                                            </td>
                                        </tr>
                                    </caption>
                                </table>
                        </td>
                    </tr>
                </table>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
