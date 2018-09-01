<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true" CodeFile="Advertisement.aspx.cs" Inherits="SubAdmin_Advertisement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="middle">
                <table cellpadding="0" cellspacing="0" width="100%" border="1">
                    <tr>
                        <td align="center">
                            <tr>
                                <td align="center" style="text-align: center">

                                    <h3 style="color: Green; font-size: x-large;">Add Advertisement</h3>
                                    <table style="width: 100%">
                                        <tr>
                                            <td colspan="5">
                                                <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <asp:Label ID="lblError" runat="server" Text="Label" Style="color: red;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 35px"></td>
                                            <td style="width: 258px; height: 35px">Select State Name:*

                                            </td>
                                            <td style="width: 236px; height: 35px">
                                                <asp:DropDownList ID="ddlStateName" runat="server" AutoPostBack="true" Style="height: 20px" OnSelectedIndexChanged="ddlStateName_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 247px; height: 35px"></td>
                                            <td style="height: 35px"></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 35px"></td>
                                            <td style="width: 245px; height: 35px">Select District Name:

                                            </td>
                                            <td style="width: 236px; height: 35px">
                                                <asp:DropDownList ID="ddlDistrictName" runat="server" AutoPostBack="true" Style="height: 20px" OnSelectedIndexChanged="ddlDistrictName_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 247px; height: 35px"></td>
                                            <td style="height: 35px"></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 35px"></td>
                                            <td style="width: 258px; height: 36px;">Select ContentType:

                                            </td>
                                            <td style="width: 236px; height: 35px;">
                                                <asp:RadioButtonList ID="rdoAdvType" runat="server" CssClass="radio" AutoPostBack="true"
                                                    Font-Size="Medium" RepeatDirection="Horizontal" Width="211px" Style="padding-left: 47px" OnSelectedIndexChanged="rdoAdvType_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Text</asp:ListItem>
                                                    <asp:ListItem Value="1">Image</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>

                                            <td style="height: 35px"></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 35px"></td>
                                            <td style="width: 258px; height: 36px;"></td>
                                            <td style="height: 35px;">
                                                <asp:TextBox ID="txtText" runat="server" Visible="false" Style="padding-left: 53px"></asp:TextBox>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:FileUpload ID="ImgUpload" runat="server" Visible="false" Style="padding-bottom: 7px; padding-left: 53px" />
                                                <asp:Image ID="imgmodify" runat="server" Height="200px" Visible="false" Width="200px" />
                                            </td>
                                            <tr>
                                                <td style="height: 35px;"></td>
                                                <td colspan="4" style="height: 35px"></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 35px"></td>
                                                <td style="width: 258px; height: 36px;"></td>
                                                <td style="height: 35px;">
                                                    <asp:Button ID="btnAdd" runat="server" CssClass="btn" Height="24px" OnClick="btnAdd_Click" Text="ADD" ValidationGroup="other" Width="78px" />
                                                </td>
                                                <td style="height: 35px;">
                                                    <asp:Button ID="btnBack" runat="server" CssClass="btn" Height="24px" Text="Back" Width="78px" OnClick="btnBack_Click" />
                                                </td>
                                                <td colspan="4" style="height: 35px"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="5"></td>
                                            </tr>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
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
                                        <asp:GridView ID="gvAdvertise" runat="server" Width="100%" CssClass="datatable" CellPadding="3"
                                            CellSpacing="0" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="Id"
                                            EmptyDataText="Item List is not available." PageSize="25" OnRowCommand="gvAdvertise_RowCommand" OnRowDeleting="gvAdvertise_RowDeleting">
                                            <Columns>
                                                <asp:BoundField DataField="Id" HeaderText="ID">
                                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="StateId" HeaderText="StateID">
                                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="StateName" HeaderText="State Name">
                                                    <HeaderStyle HorizontalAlign="Center" Width="30%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DistrictName" HeaderText="District Name">
                                                    <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="AdvertiseImage">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Advimg" runat="server" ImageUrl='<%# "~/AdvertiseImghandler.ashx?Id="+ Eval("Id") %>'
                                                            Height="100px" Width="100px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Modify">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("Id") %>' runat="server"
                                                            ImageUrl="../resources/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgdelete" CommandArgument='<%#Bind("Id") %>' runat="server"
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
                </div>


            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAdd" />
            <asp:PostBackTrigger ControlID="btnBack" />
            <asp:PostBackTrigger ControlID="ddlStateName" />
            <asp:PostBackTrigger ControlID="rdoAdvType" />
            <asp:PostBackTrigger ControlID="gvAdvertise" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

