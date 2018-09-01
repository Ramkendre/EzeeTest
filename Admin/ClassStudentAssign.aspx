<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ClassStudentAssign.aspx.cs" Inherits="Admin_ClassStudentAssign" Title="Assign Test to Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 100%" align="center">
                <table cellpadding="0" cellspacing="0" width="70%" border="1">
                    <tr>
                        <td align="center">
                            <div style="width: 85%">
                                <table cellpadding="0" cellspacing="0" border="0" width="85%" class="tables">
                                    <caption>
                                        <h3 style="color: Green; font-family: Times New Roman; font-size: x-large">
                                            Assign Exam to&nbsp; Student
                                        </h3>
                                        <tr>
                                            <td>
                                                <center>
                                                    <table class="tables" style="width: 97%">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="lblError" runat="server" CssClass="error" Visible="False" Font-Bold="True"
                                                                    Font-Size="Medium"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbltext" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select Test Name"></asp:Label>
                                                                <span class="warning1" style="color: Red;">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblTestname" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select Test Name"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select Student Name"></asp:Label>
                                                                <span class="warning1" style="color: Red;">*</span>
                                                            </td>
                                            </td>
                                            <td>
                                                <div class="container">
                                                    <asp:CheckBox ID="ChkSelectALL" runat="server" AutoPostBack="True" Text="Select ALL"
                                                        Visible="true" OnCheckedChanged="ChkSelectALL_CheckedChanged" />
                                                    <asp:CheckBoxList ID="chkstudentlist" runat="server" Font-Size="Small" Height="24px">
                                                    </asp:CheckBoxList>
                                                </div>
                            </div>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                        </td>
                        <td>
                            &nbsp;<asp:Button ID="btnStart" runat="server" CssClass="btn" Text="Submit" ToolTip="Click here to start the test"
                                ValidationGroup="other" OnClick="btnStart_Click" />
                            &nbsp;
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn" Text="Cancel" ToolTip="Click here to Cancel"
                                ValidationGroup="other" OnClick="btnCancel_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnback" runat="server" CssClass="btn" PostBackUrl="~/Admin/TestDefinition.aspx"
                                Text="Back" ToolTip="Click here to Back" />
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
                </center> </td> </tr>
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
                                                    <asp:GridView ID="gvStudentAssignList" runat="server" Width="100%" CssClass="datatable"
                                                        CellPadding="5" CellSpacing="0" GridLines="None" AutoGenerateColumns="False"
                                                        AllowPaging="True" EmptyDataText="Chapter List is not available." PageSize="25"
                                                        OnRowCommand="gvStudentAssignList_RowCommand" OnRowDataBound="gvStudentAssignList_RowDataBound"
                                                        OnPageIndexChanging="gvStudentAssignList_PageIndexChanging">
                                                        <Columns>
                                                            <asp:BoundField DataField="ATStudent_ID" HeaderText="Id">
                                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TestName" HeaderText="Test Name">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="StudentMobileNo" HeaderText="Student Mobile No.">
                                                                <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                                                                <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Modify">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("ATStudent_ID")%>' runat="server"
                                                                        ImageUrl="../resources/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("ATStudent_ID") %>' runat="server"
                                                                        ImageUrl="../resources/images/close.gif" CommandName="Delete"></asp:ImageButton>
                                                                </ItemTemplate>
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
                </caption> </table> </td> </tr> </table></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
