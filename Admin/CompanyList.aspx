<%@ Page Title="eZeeTest:Institution List" Language="C#" MasterPageFile="~/Layout/AdminMaster.master"
    AutoEventWireup="true" CodeFile="CompanyList.aspx.cs" Inherits="Admin_CompanyList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 100%;" align="center">
                &nbsp;<table cellpadding="0" cellspacing="0" width="70%" border="1">
                    <tr>
                        <td align="center">
                            <div style="width: 80%">
                                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                    <tr>
                                        <td colspan="2" style="height: 20px;">
                                            <span class="warning1" style="color: Red;"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 20px;">
                                            <table style="width: 100%" class="tables" cellspacing="7px">
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        <h3>
                                                            <asp:Label ID="lblHeader" Font-Size="X-Large" ForeColor="Green" runat="server" Text="School/College List"></asp:Label></h3>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3">
                                                        &nbsp;&nbsp;<asp:Label ID="lblError" Visible="false" runat="server" CssClass="error"
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="2" align="right" style="padding-right: 20px;">
                                                        <asp:Button ID="Button1" runat="server" Text="Upload CenterCode/Company file" CssClass="btn"
                                                            OnClick="Button1_Click" />
                                                        &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Add New School/College" CssClass="btn"
                                                            OnClick="btnSubmit_Click" />
                                                        &nbsp;
                                                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn" OnClick="btnBack_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </div>
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
                                                    <asp:GridView ID="gvCompany" runat="server" Width="100%" CssClass="datatable" OnPageIndexChanging="gvCompany_PageIndexChanging"
                                                        CellPadding="5" CellSpacing="0" GridLines="None" AutoGenerateColumns="False"
                                                        AllowPaging="True" EmptyDataText="College List is not available." PageSize="25"
                                                        OnRowCommand="gvCompany_RowCommand">
                                                        <Columns>
                                                            <asp:BoundField DataField="CompanyId" HeaderText="Id">
                                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CompanyName" HeaderText="School/College Name">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Address1" HeaderText="Address">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TalukaName" HeaderText="City">
                                                                <HeaderStyle HorizontalAlign="left" Width="10%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Modify">
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("CompanyId")%>' runat="server"
                                                                        ImageUrl="../resources/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="View">
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("CompanyId")%>' runat="server"
                                                                        ImageUrl="../resources/images/Search.jpg" CommandName="View"></asp:ImageButton>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
