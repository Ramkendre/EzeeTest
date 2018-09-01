<%@ Page Title="::Lodgin : State Master ::" Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true" 
CodeFile="State.aspx.cs" Inherits="Admin_State" EnableViewState="true"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div style="width:100%;" align="center">
            <table cellpadding="0" cellspacing="0" width="70%" border="1">
                <tr>
                    <td align="center">
                        <div style="width: 70%">
                            <table cellpadding="0" cellspacing="0" border="0" width="85%" class="tables">
                                <tr>
                                    <td class="error" >
                                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;">
                                        <table style="width: 100%; height: 290px;" class="tables" cellspacing="7px">
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    <h3>
                                                        <asp:Label ID="lblHeader" runat="server" Text="State Master"></asp:Label>
                                                    </h3>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="text-align: left">
                                                    <asp:Label ID="lblError" Visible="false" runat="server" CssClass="error"
                                                        Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 161px" >
                                                    <asp:Label ID="lblSelectCountry" runat="server" Text=" Select Country Name :" 
                                                        Font-Size="Medium"></asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                        ControlToValidate="ddlCountry" Display="None" ErrorMessage="* Select Country" 
                                                        InitialValue="" SetFocusOnError="true" >*</asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender" 
                                                        runat="server" TargetControlID="RequiredFieldValidator3">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="ddlcsswidth" 
                                                      >
                                                        <asp:ListItem Value="1">India</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 161px" >
                                                    <asp:Label ID="lblStateName" runat="server" Text="State Name :" 
                                                        Font-Size="Medium"></asp:Label>
                                                    <label>
                                                        *</label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtStateName" runat="server" CssClass="txtcss"></asp:TextBox>
                                                    <asp:TextBoxWatermarkExtender WatermarkCssClass="watermark" ID="TextBoxWatermarkExtender1"
                                                        TargetControlID="txtStateName" WatermarkText="Enter The State Name" runat="server">
                                                    </asp:TextBoxWatermarkExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 161px" >
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkdata" Text="Get Multiple State name" CssClass="watermark" 
                                                        runat="server" AutoPostBack="True" 
                                                        oncheckedchanged="chkdata_CheckedChanged" Font-Size="Medium" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Panel ID="pnl_grade" runat="server" BackColor="White"   >
                                                   <%-- Style="display: none"--%>
                                                        <table  class="tables" cellspacing="7px" style="width: 100%" >
                                                            <tr>
                                                            <td style="font-size: medium"> Select State</td>
                                                                <td>
                                                                    <div class="container" style="height: 71px; width: 295px">
                                                                        <asp:CheckBox ID="chkdata0" runat="server" AutoPostBack="True" 
                                                                            oncheckedchanged="chkdata0_CheckedChanged" Text="Select All" 
                                                                            Font-Size="Medium" />
                                                                        <asp:CheckBoxList ID="chkstatelist" runat="server" RepeatColumns="1" BorderWidth="0px"
                                                                            Datafield="description" DataValueField="value" Font-Size="Medium">
                                                                        </asp:CheckBoxList>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                            </tr>
                                            <tr>
                                                <td style="width: 161px">
                                                </td>
                                                <td align="center">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn"
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
                                                <asp:GridView ID="gvState" runat="server" Width="100%" CssClass="datatable" OnRowCommand="gvState_RowCommand"
                                                    OnPageIndexChanging="gvState_PageIndexChanging" CellPadding="5" CellSpacing="0"
                                                    GridLines="None" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="State List is not available."
                                                    PageSize="25" OnRowDeleting="gvState_RowDeleting" OnRowDataBound="gvState_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField DataField="Id" HeaderText="Id">
                                                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Name" HeaderText="State Name">
                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="countryName" HeaderText="Country">
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
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("Id")%>' runat="server"
                                                                    ImageUrl="../resources/images/close.gif" CommandName="Delete"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <PagerStyle CssClass="pager-row" />
                                                </asp:GridView>
                                                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                                <%--<asp:Repeater ID="RepDetails" runat="server">
<HeaderTemplate>
<table border="1" width="100%">
<tr >
<th>Id</th>
<th>Name</th>
<th>Country Name</th>
</tr>
</HeaderTemplate>

<ItemTemplate>
<tr>

<td ><%# DataBinder.Eval(Container.DataItem, "Id")%></td>
<td ><%# DataBinder.Eval(Container.DataItem, "Name")%></td>
<td ><%# DataBinder.Eval(Container.DataItem, "countryName")%></td>

</tr>
</ItemTemplate>


<ItemTemplate>
<tr style="background-color:#EBEFF0">

<td>
<asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Id") %>' Font-Bold="true"/>
</td>
<td>

<asp:Label ID="Label1" runat="server" Text='<%#Eval("Name") %>' Font-Bold="true"/>
</td>
<td>
<asp:Label ID="Label2" runat="server" Text='<%#Eval("countryName") %>'/>
</td>

<tr>

</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>

</asp:Repeater>--%>
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

