<%@ Page Title=" Role Master " Language="C#" MasterPageFile="~/Layout/AdminMaster.master"
    AutoEventWireup="true" CodeFile="Role.aspx.cs" Inherits="Admin_Role" EnableViewState="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div style="width:100%;" align="center">
            <table cellpadding="0" cellspacing="0" width="70%" border="1">
                <tr>
                    <td align="center">
                        <div style="width: 80%">
                            <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                               
                                <tr>
                                    <td style="height: 20px;">
                                        <table style="width: 100%" class="tables" cellspacing="7px">
                                            <tr>
                                                <td align="center" colspan="3" style="text-align: center">
                                                  
                                                          <h3 style="color: Green;font-family:Times New Roman;font-size:x-large">
                                            Role Master</h3>
                                                </td>
                                            </tr>
                                             <tr>
                                    <td class="error">
                                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                    </td>
                                </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="text-align: left">
                                                    &nbsp;&nbsp;<asp:Label ID="lblError" runat="server" CssClass="error" Text="Label"
                                                        Visible="false"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblRoleName0" runat="server" Font-Size="Medium" Text="Select Parent Role:" 
                                                        Width="200px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlparentrole" runat="server" CssClass="ddlcsswidth">
                                                    </asp:DropDownList>
                                                    <span style="color: #FF0000">*</span></td>
                                                <td class="error">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblRoleName" runat="server" Font-Size="Medium" Text="Role Name :"></asp:Label>
                                                    <label>
                                                        *</label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRoleName" runat="server" CssClass="txtcss"></asp:TextBox>
                                                    <span style="color: #FF0000">*</span></td>
                                                <td class="error">
                                                    &nbsp;
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vgpStateSubmit"
                                                        SetFocusOnError="true" ControlToValidate="txtRoleName" ErrorMessage="* Role Name is Must"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbldescription" runat="server" Font-Size="Medium" Text="Role Description :"></asp:Label>
                                                    <label>
                                                        *</label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtdescription" runat="server" CssClass="txtcss" Height="48px" 
                                                        TextMode="MultiLine" Width="188px"></asp:TextBox>
                                                    <span style="color: #FF0000">*</span></td>
                                                <td class="error">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td colspan="2" align="center">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" ValidationGroup="vgpStateSubmit"
                                                        OnClick="btnSubmit_Click" />
                                                    &nbsp;
                                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn" OnClick="btnCancel_Click"
                                                        Text="Cancel" />
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
                                                <asp:GridView ID="gvRole" runat="server" Width="100%" CssClass="datatable" OnRowCommand="gvRole_RowCommand"
                                                    OnPageIndexChanging="gvRole_PageIndexChanging" CellPadding="5" CellSpacing="0"
                                                    GridLines="None" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="Role List is not available."
                                                    PageSize="25" OnRowDeleting="gvRole_RowDeleting" OnRowDataBound="gvRole_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField DataField="Id" HeaderText="Id">
                                                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Name" HeaderText="Role Name">
                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Describtion" HeaderText="Description">
                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="PrentRolename" HeaderText="Parent Role">
                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        
                                                        <asp:TemplateField HeaderText="Modify">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("Id")%>' runat="server"
                                                                    ImageUrl="../resources/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="Assign Menu">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("Id")%>' runat="server"
                                                                    ImageUrl="../resources/images/ico_yes1.gif" CommandName="Assign"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton3" CommandArgument='<%#Bind("Id")%>' runat="server" OnClientClick="return confirmationDelete();"
                                                                    ImageUrl="../resources/images/close.gif" CommandName="Delete"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:TemplateField>
                                                        <%-- <asp:TemplateField HeaderText="Delete User Details">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkdelete" runat="server" OnClick="lnkdelete_Click">Delete User</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
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
