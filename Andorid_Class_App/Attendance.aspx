<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Attendance.aspx.cs" Inherits="Andorid_Class_App_Attendance" Title="Attendance Details" %>

<%@ Register Assembly="AjaxcontrolToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div style="width: 100%;" align="center">
                <table cellpadding="0" cellspacing="0" width="75%" border="1" class="tables">
                    <tr>
                        <td style="text-align: center;">
                            <div style="width: 100%">
                                <center>
                                    <table cellpadding="2" cellspacing="2" width="65%" class="tables">
                                        <tr>
                                            <td colspan="2" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                <h3 style="color: Green">Student Attendance
                                                </h3>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">
                                                <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; height: 20px">
                                                <asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Error"
                                                    Font-Size="Medium" ForeColor="Red"></asp:Label>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="Label12" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                    Text=" Date : "></asp:Label>
                                                <asp:Label ID="lblDate" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                    Text="Date"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="background-color: #FFFFBB;">
                                            <span>
                                                <td colspan="2" style="text-align: left; width: 150px">
                                                    <asp:Label ID="lblClass1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                        Text="Class : "></asp:Label>
                                                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="ddlcsswidth" Width="90px"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                                    </asp:DropDownList>


                                                    &nbsp;
                                            <asp:Label ID="lblBatch1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                Text="Batch : "></asp:Label>
                                                    <asp:DropDownList ID="ddlBatch" runat="server" Width="75px"
                                                        AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    &nbsp;
                                            <asp:Label ID="lblSession1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                Text=" Session : "></asp:Label>
                                                    <asp:DropDownList ID="ddlSession" runat="server" CssClass="ddlcsswidth" AutoPostBack="True" Width="90px"
                                                        OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </span>
                                        </tr>
                                        <tr style="height: 60px; vertical-align: bottom; text-align: center">
                                            <td>
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit Attendance" Enabled="false" CssClass="btn"
                                                    OnClick="btnSubmit_Click" Width="150px" ValidationGroup="other" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="grid" style="width: 70%">
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
                                                            <asp:GridView ID="gvAttendance" runat="server" CssClass="datatable" CellPadding="5"
                                                                GridLines="None" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="Student List is not available."
                                                                PageSize="20" Font-Bold="True">
                                                                <Columns>
                                                                    <asp:BoundField DataField="SNO" HeaderText="SNO">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="First_Name" HeaderText="First Name">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Last_Name" HeaderText="Last Name">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Father_Name" HeaderText="Father Name">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:TemplateField HeaderText="Attendance" ItemStyle-HorizontalAlign="Right">
                                                                        <ItemStyle HorizontalAlign="left" Width="5%"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:RadioButtonList ID="rbd_attendance" AutoPostBack="False" runat="server" RepeatDirection="Horizontal"
                                                                                BorderStyle="Double" BorderWidth="0px" BorderColor="Transparent" DataValueField="is_selected"
                                                                                ToolTip="Please select for Attendance for this student" Font-Bold="True" Font-Size="Larger"
                                                                                ForeColor="Red">
                                                                                <asp:ListItem Text="Present" Selected="True" Value="0">P</asp:ListItem>
                                                                                <asp:ListItem Text="Absent" Value="1">A</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                                </center>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
