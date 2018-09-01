<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Master.master" AutoEventWireup="true" CodeFile="MenuMaster.aspx.cs" Inherits="html_MenuMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<table cellpadding="0" cellspacing="0" width="70%" border="1" ><tr><td align="center" >
            <div style="width: 80%">
                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                    <tr>
                        <td colspan="2"  style="height: 20px;">
                            <span class="warning1" style="color: Red;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 20px;">
       <table style="width: 100%" class="tables" cellspacing="7px">
       
        <tr>
            <td align="center" colspan="3" >
                &nbsp;&nbsp;<asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Label"></asp:Label></td>
        </tr>
    </table>
    <br />
    </td></tr></table></div>
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
                                   
                                     <asp:GridView ID="gvMenu" runat="server" Width="100%" CssClass="datatable" 
                                      CellPadding="5" CellSpacing="0" GridLines="None" AutoGenerateColumns="False" 
                                        EmptyDataText="Menu List is not available." 
                                         onselectedindexchanged="gvMenu_SelectedIndexChanged" AllowPaging="True" >   
                                       
                                        
                                        <Columns>
                                            <asp:HyperLinkField DataNavigateUrlFields="MenuUrl" Text="&lt;img src='../resources/images/ICON.png' border=0&amp;gt"
                                                DataNavigateUrlFormatString="#">
                                                <ItemStyle Width="5%" HorizontalAlign="Right" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField DataNavigateUrlFields="MenuUrl" DataTextField="MenuName" DataNavigateUrlFormatString="{0}"
                                                ControlStyle-Font-Size="10pt">
                                                <ControlStyle Font-Size="10pt" />
                                                <ItemStyle Width="40%" HorizontalAlign="Center" />
                                            </asp:HyperLinkField>
                                            
                                            
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
     </td></tr></table>
            </ContentTemplate></asp:UpdatePanel>
</asp:Content>

