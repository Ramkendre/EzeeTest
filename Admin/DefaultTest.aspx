<%@ Page Title="Default Test" Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="DefaultTest.aspx.cs" Inherits="Admin_DefaultTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div style="width:100%;" align="center">
            <table cellpadding="0" cellspacing="0" width="70%" border="1">
                <tr>
                    <td align="center">
                        <div style="width: 85%">
                            <table cellpadding="0" cellspacing="0" border="0" width="85%" class="tables">
                                <caption>
                                    <h3 style="color: Green;font-size:x-large;font-family:Times New Roman;">
                                        Add Default Test
                                    </h3>
                                    <tr>
                                        <td>
                                            <center>
                                                <table class="tables" style="width: 97%">
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblError" runat="server" CssClass="error" Visible="False" Font-Bold="True"
                                                                Font-Size="Medium"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                      <tr>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text="Enter Institute ID"></asp:Label>
                                                            <span class="warning1" style="color: Red;">*</span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtcompanyid" runat="server"  
                                                                onkeypress="return numbersonly(this,event)" AutoPostBack="true" ontextchanged="txtcompanyid_TextChanged"
                                                                ></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                      <tr>
                                                        <td>
                                                            <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text="Institute Name"></asp:Label>
                                                            &nbsp;</td>
                                                        <td>
                                                            <asp:Label ID="lblCompanyname" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text=""></asp:Label>
                                                        </td>
                                                        </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbltext" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text="Enter Test ID"></asp:Label>
                                                            <span class="warning1" style="color: Red;">*</span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTestID" runat="server" AutoPostBack="true" onkeypress="return numbersonly(this,event)"
                                                                OnTextChanged="txtTestID_TextChanged"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text="Test Name"></asp:Label>
                                                            &nbsp;</td>
                                                        <td>
                                                            <asp:Label ID="lbltestName" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text=""></asp:Label>
                                                        </td>
                                                        </tr>
                                                              <tr>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text="LoginId  Name"></asp:Label>
                                                            &nbsp;</td>
                                                        <td>
                                                            <asp:Label ID="lblLoginID" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text=""></asp:Label>
                                                        </td>
                                                        </tr>
                                                         <tr>
                                                <td>
                                                  
                                                  <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                Text="Default Test for"></asp:Label>
                                                                 <span class="warning1" style="color: Red;">*</span>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddluserType" runat="server" CssClass="ddlcsswidth"  >
                                                    <asp:ListItem Value="1">Free User</asp:ListItem>
                                                    <asp:ListItem Value="2">Silver User</asp:ListItem>
                                                    <asp:ListItem Value="3">Gold User</asp:ListItem>
                                                    <asp:ListItem Value="4">Platinum User</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>



                        </div>
                    </td>
                </tr>
              
                <tr>
                    <td>
                    </td>
                    <td>
                        &nbsp;<asp:Button ID="btnStart" runat="server" CssClass="btn" Text="Submit" 
                            ValidationGroup="other" onclick="btnStart_Click1" OnClientClick="if(!confirm(' Are you sure you want add default Test  ?')) return false;" />
                        &nbsp;
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn" Text="Cancel" ToolTip="Click here to Cancel"
                            ValidationGroup="other" CausesValidation="false" onclick="btnCancel_Click1" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnback" runat="server" CssClass="btn" PostBackUrl="~/Admin/Home.aspx"
                            Text="Back" ToolTip="Click here to Back" />
                        &nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            </center> </td> </tr>
            <tr>
                <td>
                    <center>
                        <div class="grid" style="width: 85%">
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
                                                <asp:GridView ID="gvDefaultTest" runat="server" Width="100%" CssClass="datatable"
                                                    CellPadding="5" CellSpacing="0" GridLines="None" AutoGenerateColumns="False"
                                                    AllowPaging="True" EmptyDataText="List is not available." PageSize="40" 
                                                    onrowcommand="gvDefaultTest_RowCommand">
                                                    <Columns>
                                                        <asp:BoundField DataField="SNO" HeaderText="SNO">
                                                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TestID" HeaderText="Test Id">
                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TestName" HeaderText="Test Name">
                                                            <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                    
                                                        <asp:BoundField DataField="TestCreateLogin" HeaderText="Test Create Login">
                                                            <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("SNO") %>' runat="server"
                                                                    ImageUrl="../resources/images/close.gif" CommandName="Delete"  OnClientClick="if(!confirm(' Are you sure you want delete default Test  ?')) return false;"></asp:ImageButton>
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
                    </center>
                </td>
            </tr>
            </caption> </table> </td> </tr> </table></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
