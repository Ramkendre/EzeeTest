<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true" CodeFile="AndroidTestDetails.aspx.cs" Inherits="Andorid_Class_App_AndroidTestDetails" Title="Test Details" %>

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
                                            <td colspan="4" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                <h3 style="color: Green">Test Details
                                                </h3>
                                            </td>

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
                                                <asp:Label ID="Label12" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                    Text="Test Date : "></asp:Label>

                                                <asp:TextBox ID="txtdate" runat="server" Width="70px" ReadOnly="true"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd-MM-yyyy"
                                                    PopupButtonID="img1" TargetControlID="txtdate">
                                                </asp:CalendarExtender>
                                                <img id="img1" align="middle" alt="ezeesofts &amp; Co." border="0" height="20" src="../resources/images/calendarclick.gif" />

                                            </td>
                                        </tr>
                                        <tr style="background-color: #FFFFBB;">
                                            <span>
                                                <td colspan="4" style="text-align: left; width: 150px">
                                                    <asp:Label ID="lblClass1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                        Text="Class : "></asp:Label>
                                                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="ddlcsswidth" Width="90px"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    &nbsp;
                                                <asp:Label ID="lblBatch1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                    Text="Batch : "></asp:Label>
                                                    <asp:DropDownList ID="ddlBatch" runat="server" CssClass="ddlcsswidth" Width="75px"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    &nbsp;
                                                <asp:Label ID="lblSession1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                    Text=" Session : "></asp:Label>
                                                    <asp:DropDownList ID="ddlSession" runat="server" CssClass="ddlcsswidth" Width="90px"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </span>
                                        </tr>
                                        <tr>

                                            <td style="text-align: left; height: 26px;">
                                                <asp:Label ID="lblAdm_No" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Test No"></asp:Label>
                                            </td>
                                            <td style="text-align: left; height: 26px;">
                                                <asp:TextBox ID="txtTestNo" runat="server" CssClass="txtcssNo" MaxLength="4"
                                                    onkeypress="return numbersonly(this,event)" AutoPostBack="True"
                                                    OnTextChanged="txtTestNo_TextChanged" TabIndex="1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTestNo" Font-Size="Medium" ErrorMessage="*" ValidationGroup="other"></asp:RequiredFieldValidator>
                                            </td>

                                            <td style="text-align: left; height: 26px;">
                                                <asp:Label ID="lblAdm_Date" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Test Topic"></asp:Label>
                                            </td>
                                            <td style="text-align: left; height: 26px;">
                                                <asp:TextBox ID="txtTestTopic" runat="server" CssClass="txthiwidth"
                                                    TabIndex="3"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rq1" runat="server" ControlToValidate="txtTestTopic" Font-Size="Medium" ErrorMessage="*" ValidationGroup="other"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>
                                        <tr>

                                            <td style="text-align: left; width: 100px; height: 26px;">
                                                <asp:Label ID="lblFN" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Test Name "></asp:Label>
                                            </td>
                                            <td style="text-align: left; height: 26px;">
                                                <asp:TextBox ID="txtTestName" runat="server" CssClass="txthiwidth" TabIndex="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTestName" Font-Size="Medium" ErrorMessage="*" ValidationGroup="other"></asp:RequiredFieldValidator>
                                            </td>
                                            <td style="text-align: left; width: 100px; height: 26px;">
                                                <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Out Of "></asp:Label>
                                            </td>
                                            <td style="text-align: left; height: 26px;">
                                                <asp:TextBox ID="txtOutOf" runat="server" CssClass="txtcssNo" MaxLength="4"
                                                    onkeypress="return numbersonly(this,event)" TabIndex="4"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOutOf" Font-Size="Medium" ErrorMessage="*" ValidationGroup="other"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr style="height: 60px; vertical-align: bottom">
                                            <td colspan="2" style="text-align: center">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" Enabled="false" ValidationGroup="other"
                                                    Width="61px" OnClick="btnSave_Click" />
                                                &nbsp;<asp:Button ID="btncancel" runat="server" CssClass="btn"
                                                    Text="Cancel" OnClick="btncancel_Click" />
                                                &nbsp;
                                                <asp:Button ID="btnback" runat="server" CssClass="btn" PostBackUrl="~/Admin/Home.aspx"
                                                    Text="Back" />
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
                                                            <asp:GridView ID="gvTestDetails" runat="server" CssClass="datatable"
                                                                CellPadding="5" GridLines="None"
                                                                AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="Student List is not available."
                                                                PageSize="40" Font-Bold="True"
                                                                OnPageIndexChanging="gvTestDetails_PageIndexChanging"
                                                                DataKeyNames="SNO">
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


                                                                    <asp:TemplateField HeaderText="Obtained Marks" ItemStyle-HorizontalAlign="Right">
                                                                        <ItemStyle HorizontalAlign="left" Width="5%"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtObtainedMarks" runat="server" CssClass="txtcssNo" MaxLength="4" onkeypress="return numbersonly(this,event)" BorderColor="#6699FF" Width="50px"></asp:TextBox>
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


