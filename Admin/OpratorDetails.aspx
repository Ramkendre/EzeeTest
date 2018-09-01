<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true" CodeFile="OpratorDetails.aspx.cs" Inherits="OpratorDetails" Title="Operator Details" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="Updatepanel1" runat="server">
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
                                        <table style="width: 70%; height: 290px;" class="tables" cellspacing="7px">
                                          <tr>
                                                <td colspan="2" style="text-align: right" >
                                                
                                                    <h4>
                                                   
                                                        <asp:Label ID="lblHeader" runat="server" ForeColor="Green" Font-Size="X-Large" Text="Operators Payment Details"></asp:Label>
                                                    </h4>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center"  class="error" colspan="2">
                                                    &nbsp;&nbsp;<asp:Label ID="lblError" Visible="false" runat="server" CssClass="error"
                                                        Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblOpSNO" runat="server" Text="Operators ID " 
                                                        Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOpSNO" runat="server" CssClass="txtcss" Enabled="False" ></asp:TextBox>
                                                
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblLoginID" runat="server" Text="Operators LoginID " 
                                                        Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtLoginID" runat="server" CssClass="txtcss" Enabled="False" ></asp:TextBox>
                                                
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblOperatorsName" runat="server" Text="Operators Name" 
                                                        Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOperatorsName" runat="server" CssClass="txtcss" 
                                                        Enabled="False" ></asp:TextBox>
                                                
                                                </td>
                                            </tr>
                                            <tr>
                                                <td >
                                                    <asp:Label ID="lblQuesCount" runat="server" Text="Count Questions" 
                                                        Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td style="height: 47px">
                                                    <asp:CheckBox ID="chkQuesCount" runat="server" Font-Size="Small" Text="Count" 
                                                        AutoPostBack="True" oncheckedchanged="chkQuesCount_CheckedChanged" />
                                                     <asp:TextBox ID="txtQuesCount" runat="server" CssClass="txtcss" 
                                                        Enabled="False" ></asp:TextBox>
                                                </td>
                                            </tr>
                                              <tr>
                                                <td>
                                                    <asp:Label ID="lblAmount" runat="server" Text="Total Amount" 
                                                        Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAmount" runat="server" CssClass="txtcss" ></asp:TextBox>
                                                
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblPaidStatus" runat="server" Text="Paid Status" 
                                                        Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rdoPaidStatus" runat="server" Font-Size="Medium" 
                                                        RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="0">Paid</asp:ListItem>
                                                        <asp:ListItem Value="1">NotPaid</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                           <tr>
                                                <td>
                                                    <asp:Label ID="lblPaidDate" runat="server" Text="Date of Payment" 
                                                        Font-Size="Medium"></asp:Label>
                                                        
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtdatepayment" runat="server" CssClass="txtcss" ></asp:TextBox>
                                                    
                                                      <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                PopupButtonID="imgFromDate" TargetControlID="txtdatepayment">
                                                            </asp:CalendarExtender>
                                                            <img id="imgFromDate" align="middle" alt="ezeesofts &amp; Co." border="0" height="24"
                                                                src="../resources/images/calendarclick.gif" />
                                                                
                                                </td>
                                            </tr>
                                          
                                            <tr>
                                                <td>
                                                </td>
                                                <td align="center" style="text-align: left">
                                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn" 
                                                        onclick="btnUpdate_Click"  />
                                                    &nbsp;
                                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn" 
                                                        Text="Cancel" onclick="btnCancel_Click" />
                                                    &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="btn" 
                                                        Text="Back" Visible="False" />
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="grid" style="width: 90%">
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
                                                <asp:GridView ID="gvOprators" runat="server" Width="100%" CssClass="datatable" OnRowCommand="gvOprators_RowCommand"
                                                    OnPageIndexChanging="gvOprators_PageIndexChanging" CellPadding="5" CellSpacing="1"
                                                    GridLines="None" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="Oprators List is not available."
                                                    PageSize="15" OnRowDeleting="gvOprators_RowDeleting" OnRowDataBound="gvOprators_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField DataField="OpSNO" HeaderText="ID">
                                                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="LoginId" HeaderText="LoginId">
                                                            <HeaderStyle HorizontalAlign="left" Width="10%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        
                                                          <asp:BoundField DataField="OpratorName" HeaderText="Operators Name">
                                                            <HeaderStyle HorizontalAlign="left" Width="10%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                         <asp:BoundField DataField="RoleId" HeaderText="Role Name">
                                                            <HeaderStyle HorizontalAlign="left" Width="10%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                        </asp:BoundField>                                                     
                                                        <asp:BoundField DataField="PaidStatus" HeaderText="Paid Status">
                                                            <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        
                                                          <asp:BoundField DataField="Amount" HeaderText="Paid Amount">
                                                            <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        
                                                        <asp:BoundField DataField="PaidLoginId" HeaderText="Paid LoginId">
                                                            <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        
                                                        
                                                            <asp:BoundField DataField="QuesCount" HeaderText="Total Questions">
                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                          <asp:BoundField DataField="PaidDate" HeaderText="Paid Date">
                                                            <HeaderStyle HorizontalAlign="left" Width="40%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="40%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Modify" >
                                                            <ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("OpSNO") %>' runat="server"
                                                                    ImageUrl="../resources/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Deleted">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("OpSNO") %>' runat="server" OnClientClick="return confirmationDelete();"
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

