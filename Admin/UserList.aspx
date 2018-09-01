<%@ Page Title="eZeeTest:UserList" Language="C#" MasterPageFile="~/Layout/AdminMaster.master"
    AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="Admin_UserList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        #loginform
        {
            min-width: 200px;
            height: 110px;
            background-color: #ffffff;
            border: 1px solid;
            border-color: #555555;
            padding: 16px 16px;
            border-radius: 4px;
            -webkit-box-shadow: 0px 1px 6px rgba(75, 31, 57, 0.8);
            -moz-box-shadow: 0px 1px 6px rgba(75, 31, 57, 0.8);
            box-shadow: 0px 1px 6px rgba(223, 88, 13, 0.8);
        }
        .modalBackground
        {
            background-color: #333333;
            filter: alpha(opacity=80);
            opacity: 0.8;
        }
        .txt
        {
            color: #505050;
        }
        .redstar
        {
            color: #FF0000;
        }
        .popupdiv
        {
            border: 1px solid black;
            border-radius: 5px;
            background-color: #FFFFBC;
            width: 550px;
            height: 400px;
            font-size: small;
        }
    </style>
    <%-- <link href="../resources/stylesheet/jquery-ui.theme.css" rel="Stylesheet" type="text/css" />--%>

    <script src="../resources/JScript/jquery-1.11.1.js" type="text/javascript"></script>

    <script src="../resources/JScript/jquery-ui.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(document).ready(function() {
            $(function() {
                $("#<%=popUpPanel.ClientID%>").dialog({

                    resizable: false,
                    modal: true,
                    autoOpen: false,


                    open: function(type, data) {
                        $(this).parent().appendTo("form");
                        $(this).parent().children().children('.ui-dialog-titlebar-close').hide();
                    }

                });
                $("#<%=btnSearch.ClientID%>").click(function() {
                    $("#<%=popUpPanel.ClientID%>").dialog('open');
                    $("#<%=txtMobileNo.ClientID%>").focus();
                    return false;

                });
                $("#<%=btnclose.ClientID%>").click(function() {
                    $("#<%=popUpPanel.ClientID%>").dialog('close');
                    return false;
                });
            });

        });

        $(function() {

            $('[id*=ImageButton2]').click(function() {


                var par = $(this).parent();
                var Id = par.parent()[0].children[0].innerHTML;

                var query = "UserView.aspx?Id=" + Id;

                window.open(query, 'User Details', 'toolbar=no', 'scrollbars=no', 'location=no', 'statusbar=no', 'menubar=no', 'resizable=0', 'width=100', 'height=100', 'left = 490', 'top=300');


            });
        });

        $(function() {

            $('[id*=ImageButton1]').click(function() {

                var par = $(this).parent();
                var Id = par.parent()[0].children[0].innerHTML;

                var query = "User.aspx?Id=" + Id;

                window.open(query, "Modify UserDetails", 'toolbar=no', 'scrollbars=no', 'location=no', 'statusbar=no', 'menubar=no', 'resizable=0', 'width=100', 'height=100', 'left = 490', 'top=300');

            });
        });

        $(function() {

            $("#<%=btnSubmit.ClientID%>").click(function() {

                var query = "User.aspx";

                window.open(query, "Modify UserDetails", 'toolbar=no', 'scrollbars=no', 'location=no', 'statusbar=no', 'menubar=no', 'resizable=0', 'width=100', 'height=100', 'left = 490', 'top=300');

            });
        });
    </script>

    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <div style="width: 100%;" align="center">
        <table cellpadding="0" cellspacing="0" width="80%" border="1">
            <tr>
                <td align="center">
                    <div style="width: 80%">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tables">
                            <tr>
                                <td style="height: 20px;">
                                    <span class="warning1" style="color: Red;"></span>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px;">
                                    <table style="width: 100%" class="tables" cellspacing="7px">
                                        <tr>
                                            <td>
                                            </td>
                                            <td colspan="2" align="center">
                                                <h3 style="color: Green; font-size: x-large">
                                                    User List</h3>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3">
                                                &nbsp;&nbsp;<asp:Label ID="lblError" Visible="False" runat="server" CssClass="error"
                                                    Text="Label" Font-Size="Medium"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center" colspan="3">
                                                <asp:RadioButton ID="Active" AutoPostBack="true" Text="Active User" Font-Size="Medium"
                                                    runat="server" OnCheckedChanged="Active_CheckedChanged" />
                                                &nbsp;<asp:RadioButton ID="DeActive" AutoPostBack="true" Text="Deactivate User" Font-Size="Medium"
                                                    runat="server" OnCheckedChanged="DeActive_CheckedChanged" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right" style="padding-right: 20px;">
                                                <asp:Button ID="btndatashowany" Enabled="true" Visible="false" runat="server" Text="DailyQuestions"
                                                    CssClass="btn" OnClick="btndatashowany_Click" PostBackUrl="~/SubAdmin/RSBCustomerTestDefine.aspx" />
                                                <asp:Button ID="btnExportToExcel" runat="server" Text="Export_To_Excel" CssClass="btn"
                                                    OnClick="btnExportToExcel_Click" PostBackUrl="~/SubAdmin/ExportToExcel.aspx" />
                                                <asp:Button ID="btnUploadStudList" runat="server" Text="Upload Student List" PostBackUrl="UserLoginUpload.aspx"
                                                    CssClass="btn" Width="140px" />
                                                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click"
                                                    Text="Assign To Self" Visible="false" />
                                                <asp:Button ID="btnSubmit" runat="server" Text="Add New User" CssClass="btn" />
                                                &nbsp;
                                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn" OnClick="btnBack_Click" />
                                                &nbsp;
                                                <asp:Button ID="btnSearch" runat="server" Text="Search Record" CssClass="btn" Visible="true"
                                                    ValidationGroup="instruc" Height="31px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <center>
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
                                                                <asp:GridView ID="gvUser" runat="server" Width="95%" CssClass="datatable" OnPageIndexChanging="gvUser_PageIndexChanging"
                                                                    CellPadding="5" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                                    EmptyDataText="User List is not available." PageSize="25" OnRowCommand="gvUser_RowCommand"
                                                                    OnRowDataBound="gvUser_RowDataBound">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="LoginId" HeaderText="Login Id">
                                                                            <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="UserName" HeaderText="User Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="RoleName" HeaderText="Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="loginname" HeaderText="Under User">
                                                                            <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Active" HeaderText="Active">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="Modify">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("LoginId")%>' runat="server"
                                                                                    ImageUrl="../resources/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Assign Chapter">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImageButton9" CommandArgument='<%#Bind("LoginId")%>' runat="server"
                                                                                    ImageUrl="../resources/images/ico_yes1.gif" CommandName="Assign"></asp:ImageButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Active">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImageButton3" CommandArgument='<%#Bind("LoginId")%>' runat="server"
                                                                                    ImageUrl="../resources/images/ico_yes1.gif" CommandName="Active"></asp:ImageButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Deactive">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImageButton4" CommandArgument='<%#Bind("LoginId")%>' runat="server"
                                                                                    ImageUrl="../resources/images/close.gif" CommandName="Deactive"></asp:ImageButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="View">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("LoginId")%>' runat="server"
                                                                                    ImageUrl="../resources/images/Search.jpg" CommandName="View"></asp:ImageButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <PagerStyle CssClass="pager-row" />
                                                                </asp:GridView>
                                                                <asp:GridView ID="gvUser1" runat="server" Width="95%" CssClass="datatable" OnPageIndexChanging="gvUser1_PageIndexChanging"
                                                                    CellPadding="5" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                                    EmptyDataText="User List is not available." PageSize="25" OnRowCommand="gvUser1_RowCommand"
                                                                    OnRowDataBound="gvUser_RowDataBound">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="LoginId" HeaderText="Login Id">
                                                                            <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="UserName" HeaderText="User Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="RoleName" HeaderText="Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="loginname" HeaderText="Under User">
                                                                            <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Active" HeaderText="Active">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="Modify">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("LoginId")%>' runat="server"
                                                                                    ImageUrl="../resources/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Active">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImageButton3" CommandArgument='<%#Bind("LoginId")%>' runat="server"
                                                                                    ImageUrl="../resources/images/ico_yes1.gif" CommandName="Active"></asp:ImageButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Deactive">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImageButton4" CommandArgument='<%#Bind("LoginId")%>' runat="server"
                                                                                    ImageUrl="../resources/images/close.gif" CommandName="Deactive"></asp:ImageButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="View">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("LoginId")%>' runat="server"
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
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="popUpPanel" runat="server" Width="95%" Style="display: none">
        <div id="loginform">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 240px; vertical-align: middle">
                        Enter Mobile No: &nbsp;
                    </td>
                    <td style="width: 240px; vertical-align: middle">
                        <asp:TextBox ID="txtMobileNo" runat="server" placeholder="Mobile No" Width="96px"
                            MaxLength="10" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobileNo"
                            ErrorMessage="*" Font-Size="Small" SetFocusOnError="True" ValidationGroup="btnsearch1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="color: Gray; font-family: Tahoma; font-size: xx-small">
                        [Enter Valid MobileNo Min 10Digits]
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnsearch1" runat="server" Text="Search" ValidationGroup="btnsearch1"
                            OnClick="btnsearch1_Click" />
                        &nbsp;<asp:Button ID="btnclose" runat="server" Text="Close" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
