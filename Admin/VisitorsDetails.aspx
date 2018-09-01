<%@ Page Title="Visitors Details" Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="VisitorsDetails.aspx.cs" Inherits="Admin_VisitorsDetails" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
         <div style="width:100%;" align="center">
            <table cellpadding="0" cellspacing="0" width="70%" border="1" class="tables">
                <tr>
                    <td style="text-align: center;">
                        <div style="width: 100%">
                            <center>
                                <table cellpadding="2" cellspacing="2" width="60%" class="tables">
                                    <tr>
                                        <td colspan="2" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                            <h3 style="color: Green">
                                                Visitors Log Details
                                            </h3>
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="text-align: left">
                                            <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; height: 20px">
                                            <asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Error"
                                                Font-Size="Medium" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <%--    <tr>
                                           <td style="text-align: left; width:150px">
                                            <asp:Label ID="lblInstituteName1" runat="server" Font-Bold="False" Font-Names="Arial"
                                                Font-Size="11pt" Text="Institute Id"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Institute Name"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td style="text-align: left; width: 150px">
                                            <asp:Label ID="lblsortby" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Search by"></asp:Label><span class="warning1"
                                                        style="color: Red;">&nbsp;*</span>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList ID="ddlsortby" runat="server" CssClass="ddlcsswidth " 
                                                Height="22px" AutoPostBack="True" 
                                                onselectedindexchanged="ddlsortby_SelectedIndexChanged">
                                                <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Date</asp:ListItem>
                                                <asp:ListItem Value="2">Login Name</asp:ListItem>
                                                <asp:ListItem Value="3">Max Visitor</asp:ListItem>
                                                <asp:ListItem Value="4">Role</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                  <panel id="pnl1" visible="false" runat="server">
                                    <tr id="trdate" runat="server" visible="false">
                                        <td style="text-align: left; width: 150px">
                                            <asp:Label ID="lbldate" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Date"></asp:Label><span class="warning1"
                                                        style="color: Red;">&nbsp;*</span>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtdate" runat="server" CssClass="txthiwidth" 
                                                ></asp:TextBox>
                                             <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                PopupButtonID="imgFromDate" TargetControlID="txtdate">
                                                            </asp:CalendarExtender>
                                                            <img id="imgFromDate" align="middle" alt="ezeesofts &amp; Co." border="0" height="19"
                                                                src="../resources/images/calendarclick.gif" />

                                        </td>
                                    </tr>
                                    <tr id ="trloginname" runat="server" visible="false">
                                        <td style="text-align: left; width: 150px">
                                            <asp:Label ID="lblloginname" runat="server" Font-Bold="False" Font-Names="Arial"
                                                Font-Size="11pt" Text="Select Login Name"></asp:Label><span class="warning1"
                                                        style="color: Red;">&nbsp;*</span>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList ID="ddlLoginname" runat="server" CssClass="ddlcsswidth " 
                                                Height="22px"  
                                           >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr id="trrole" runat="server" visible="false">
                                        <td style="text-align: left; width: 150px">
                                            <asp:Label ID="lblrole" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Role"></asp:Label><span class="warning1"
                                                        style="color: Red;">&nbsp;*</span>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList ID="ddlrole" runat="server" CssClass="ddlcsswidth " 
                                                Height="22px"  
                                                >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    </panel>

                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" ValidationGroup="other"
                                                Width="67px" OnClick="btnSearch_Click" />
                                            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnback" runat="server" CssClass="btn" PostBackUrl="~/Admin/Home.aspx"
                                                Text="Back" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>

                         <div class="grid" style="width: 100%">
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
                                                            <asp:GridView ID="gvVisitors" runat="server" CssClass="datatable" 
                                                                CellPadding="5" GridLines="None"
                                                                AutoGenerateColumns="False" AllowPaging="True" 
                                                                PageSize="25" onpageindexchanging="gvVisitors_PageIndexChanging" >
                                                                <Columns>
                                                                    <asp:BoundField DataField="VisitorId" HeaderText="VisitorId">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="VisitDateTime" HeaderText="VisitDateTime">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="IPAdd" HeaderText="IP Add" >
                                                                        <HeaderStyle HorizontalAlign="center" Width="20%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="center" Width="20%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                      <asp:BoundField DataField="UserName" HeaderText="User Name">
                                                                        <HeaderStyle HorizontalAlign="left" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="Loginname" HeaderText="Login Name">
                                                                        <HeaderStyle HorizontalAlign="left" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DisplayName" HeaderText="Institute Name">
                                                                        <HeaderStyle HorizontalAlign="left" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="RoleName" HeaderText="RoleId">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="NumofVisit" HeaderText="Num of Visit">
                                                                        <HeaderStyle HorizontalAlign="left" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>
                                                              
                                                                
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
            </table></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
