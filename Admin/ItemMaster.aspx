<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ItemMaster.aspx.cs" Inherits="Admin_ItemMaster" Title="eZeeTest:Item Master" %>

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
                                        <table style="width: 94%" class="tables" cellspacing="7px">
                                            <tr>
                                                <td align="center" colspan="3" style="text-align: center">
                                                    
                                                         <h3 style="color: Green;font-size:x-large;">
                                           Item Master</h3>
                                                </td>
                                            </tr>
                                             <tr>
                                        <td colspan="3">
                                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                       
                                    </td>
                                        </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="text-align: left">
                                                    &nbsp;&nbsp;<asp:Label ID="lblError" runat="server" CssClass="error" Text="Label"
                                                        Visible="false"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="style1" style="width: 140px; height: 36px;">
                                                    <asp:Label ID="lblSelectGroup" runat="server" Text=" Select Group Name :" Font-Size="Medium"></asp:Label>
                                                    <label>
                                                        *</label>
                                                </td>
                                                <td style="width: 38%; height: 36px;">
                                                    <asp:DropDownList ID="ddlItem" runat="server" AutoPostBack=true CssClass="ddlcsswidth " OnSelectedIndexChanged="ddlItem_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="error" style="width: 29%; height: 36px;">
                                                    &nbsp;
                                                    <%--  <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3">
                                                    </asp:ValidatorCalloutExtender>--%>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlItem"
                                                        ErrorMessage="Please select Group Name" SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1" style="width: 140px">
                                                    <asp:Label ID="lblItemName" runat="server" Text="Enter Item Name :" Font-Size="Medium"></asp:Label>
                                                    <label>
                                                        *</label>
                                                </td>
                                                <td style="width: 38%">
                                                    <asp:TextBox ID="txtItemName" runat="server" CssClass="txtcss" Width="124px" 
                                                        Height="26px"></asp:TextBox>
                                                    <br />
                                                </td>
                                                <td class="error" style="width: 29%">
                                                    &nbsp;
                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vgpStateSubmit"
                                                        SetFocusOnError="true" ControlToValidate="txtItemValue" ErrorMessage="* Item Value is Must"></asp:RequiredFieldValidator>
                                              --%>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtItemName"
                                                        ErrorMessage="Enter item Name" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1" style="width: 140px">
                                                    <asp:Label ID="lblMobileNo" runat="server" Text="Enter Mobile No." Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td style="width: 38%">
                                                    <asp:TextBox ID="txtMobileNo" runat="server" onkeypress="return numbersonly(this,event)" CssClass="txtcss" Width="129px" 
                                                        Height="25px" MaxLength="10"></asp:TextBox>
                                                </td>
                                                <td class="error" style="width: 29%">
                                                    &nbsp;
                                                    <%--  <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3">
                                                    </asp:ValidatorCalloutExtender>--%>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobileNo"
                                                        ErrorMessage="Please Enter Mobile No." ValidationGroup="other"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                                                        ControlToValidate="txtMobileNo" Display="Dynamic" 
                                                        ErrorMessage="&lt;br&gt;Mobile Number must be 10 digit" Font-Size="12px" 
                                                        ValidationExpression="^[0-9]{10}$" ValidationGroup="other"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                               <td></td>
                                                <td colspan="2" valign="middle" align="left" style="width: 38%">
                                                    &nbsp;<asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="Submit" OnClick="btnSubmit_Click"
                                                        ValidationGroup="other" Height="34px" />
                                                    &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="btn" 
                                                        Text="Cancel" onclick="btnCancel_Click" CausesValidation="false" Height="34px" />
                                                    &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="btn" Text="Back" 
                                                        PostBackUrl="~/Admin/Home.aspx"  Height="34px" /><%--PostBackUrl="~/html/MenuMaster.aspx?Id=1"--%>
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
                                                <asp:GridView ID="gvItem" runat="server" Width="100%" CssClass="datatable" CellPadding="5"
                                                    CellSpacing="0" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                    EmptyDataText="Item List is not available." PageSize="25" OnPageIndexChanging="gvItem_PageIndexChanging"
                                                    OnRowCommand="gvItem_RowCommand" OnRowDeleting="gvItem_RowDeleting" 
                                                    ondatabound="gvItem_DataBound">
                                                    <Columns>
                                                        <asp:BoundField DataField="ItemValueId" HeaderText="Id">
                                                            <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Name" HeaderText="Item Name">
                                                            <HeaderStyle HorizontalAlign="left" Width="40%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="40%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <%--   <asp:BoundField DataField="GroupName" HeaderText="Group">
                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>--%>
                                                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile No.">
                                                            <HeaderStyle HorizontalAlign="Left" Width="20%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Modify">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("ItemValueId") %>' runat="server"
                                                                    ImageUrl="../resources/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:TemplateField>
                                                      <%--  <asp:TemplateField HeaderText="Delete">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("ItemValueId") %>' runat="server"
                                                                    ImageUrl="../resources/images/close.gif" CommandName="Delete"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
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
