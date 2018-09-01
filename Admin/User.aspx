<%@ Page Title="eZeeTest:Add New User" Language="C#" MasterPageFile="~/Layout/AdminMaster.master"
    AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="Admin_User" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../resources/JScript/jquery-1.11.1.js" type="text/javascript"></script>

    <script src="../resources/JScript/jquery-ui.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function() {
            $("#<%=btnBack.ClientID%>").click(function() {

                window.close();
                return false;
            });


        });

    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 100%;" align="center">
                <table cellpadding="0" cellspacing="0" width="70%" border="1">
                    <tr>
                        <td align="center">
                            <div style="width: 88%">
                                <table cellpadding="0" cellspacing="0" border="0" width="85%" class="tables">
                                    <tr>
                                        <td class="error">
                                            <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table style="width: 100%;" class="tables" cellspacing="7px">
                                                <tr>
                                                    <td colspan="2" style="text-align: center">
                                                        <h3 style="color: Green; font-size: x-large;">
                                                            Add New User</h3>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2" style="text-align: left">
                                                        &nbsp;&nbsp;<asp:Label ID="lblError" Visible="false" runat="server" CssClass="error"
                                                            Text="Label"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblname" runat="server" Font-Size="Medium" Text="Enter Name"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="txtcss" MaxLength="100"></asp:TextBox>
                                                        &nbsp;<asp:TextBox ID="txtUserNameL" runat="server" CssClass="txtcss" MaxLength="100"></asp:TextBox></tr>
                                                <tr>
                                                    <td style="font-size: medium">
                                                        Mobile No.&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtLoginId" MaxLength="10" onkeypress="return numbersonly(this,event)"
                                                            CssClass="txtcss" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoginId"
                                                            ErrorMessage="" Font-Size="Small" SetFocusOnError="True" ValidationGroup="other"
                                                            Width="25px"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtLoginId"
                                                            Display="Dynamic" ErrorMessage="&lt;br&gt;Mobile Number must be 10 digit" Font-Size="12px"
                                                            ValidationExpression="^[0-9]{10}$" ValidationGroup="other"></asp:RegularExpressionValidator>
                                                        <span style="color: #FF0000; font-size: small;">*</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="font-size: medium">
                                                        Address
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAddress" Rows="3" TextMode="MultiLine" runat="server" MaxLength="20"
                                                            CssClass="txtcss" Height="55px" Width="209px"></asp:TextBox>
                                                        <span style="color: #FF0000; font-size: small;">*</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="font-size: medium">
                                                        Alternate Mobile No&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtContactNo" runat="server" MaxLength="10" CssClass="txtcss" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Wrong"
                                                            ValidationGroup="other" ValidationExpression="[0-9]*" ControlToValidate="txtContactNo"
                                                            Font-Size="Medium"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="Panelcompany" Visible="false" runat="server">
                                                    <tr>
                                                        <td>
                                                            School/Class/Institute
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCompany" runat="server" CssClass="ddlcsswidth" Height="25px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td style="font-size: medium">
                                                        Role
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="ddlcsswidth" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged"
                                                            AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="font-size: medium">
                                                        User Type
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddluserType" runat="server" CssClass="ddlcsswidth">
                                                            <asp:ListItem Value="1">Free User</asp:ListItem>
                                                            <asp:ListItem Value="2">Silver User</asp:ListItem>
                                                            <asp:ListItem Value="3">Gold User</asp:ListItem>
                                                            <asp:ListItem Value="4">Platinum User</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="p1" Visible="false" runat="server">
                                                    <tr>
                                                        <td>
                                                            Select category
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlcategory" runat="server" CssClass="ddlcsswidth" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                                                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Primary School"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Secondary School"> </asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Junior College"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="Senior College"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="1st-12th Tution Classes"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Computer Classes"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="MPSC,UPSC,..Classes"></asp:ListItem>
                                                                <asp:ListItem Value="8" Text="Any Other Classes"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlcategory"
                                                            ErrorMessage="*" Font-Size="Small" SetFocusOnError="True" ValidationGroup="other"
                                                            Width="225px" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="right" style="padding-right: 20px; text-align: left;">
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" OnClick="btnSubmit_Click"
                                                            Width="80px" ValidationGroup="other" />
                                                        &nbsp;&nbsp;
                                                        <asp:Button ID="btnBack" runat="server" CssClass="btn" Text="Close" />
                                                        <%-- //PostBackUrl="~/Admin/UserList.aspx"--%>
                                                        &nbsp;
                                                        <asp:Button ID="btnDelete" runat="server" CssClass="btn" OnClick="btnDelete_Click"
                                                            Text="Delete" Visible="False" Width="81px" />
                                                        &nbsp;
                                                        <asp:Button ID="btnRegister" runat="server" CssClass="btn" Visible="false" 
                                                            Text="Register" onclick="btnRegister_Click" />&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <center>
                                                            <div class="grid" style="width: 85%; margin-right: 0px;">
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
                                                                                    <asp:GridView ID="gvUser" runat="server" Width="85%" CssClass="datatable" CellPadding="5"
                                                                                        CellSpacing="0" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                                                        EmptyDataText="User List is not available." PageSize="5">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="Name" HeaderText="User Name">
                                                                                                <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                                                                <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="ID" HeaderText="Login Id/Mobile No.">
                                                                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="ContactNo" HeaderText="Contact Number">
                                                                                                <HeaderStyle HorizontalAlign="left" Width="10%"></HeaderStyle>
                                                                                                <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="RoleName" HeaderText="Role Name">
                                                                                                <HeaderStyle HorizontalAlign="left" Width="10%"></HeaderStyle>
                                                                                                <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                                                            </asp:BoundField>
                                                                                            <%--  <asp:TemplateField HeaderText="Modify">
                                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("ID")%>' runat="server"
                                                                                                ImageUrl="../resources/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="View">
                                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("ID")%>' runat="server"
                                                                                                ImageUrl="../resources/images/Search.jpg" CommandName="View"></asp:ImageButton>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Delete">
                                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ImageButton3" CommandArgument='<%#Bind("ID")%>' runat="server"
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
                                                        </center>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
