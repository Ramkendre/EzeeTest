<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="Admin_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .playstorelink
        {
            text-decoration: none;
            font-weight: bold;
            color: Black;
        }
        .playstorelink:hover
        {
            color: Red;
            text-shadow: 2px 2px 2px yellow;
            text-decoration:underline;
        }
    </style>
    <meta name="keywords" content="" />
    <meta name="descriptions" content="" />

    <script type="text/JavaScript">
<!--
        function AutoRefresh(t) {
            setTimeout("location.reload(true);", t);
        }
//   -->
    </script>

    <div style="text-align: center; font-weight: bold; font-size: medium; width: 100%;">
        Welcome to eZeeTest Portal
    </div>
    <br />
    <div style="float:left;">
                    <%--<a href="https://play.google.com/store/apps/details?id=ezee.abhinav.ezeetest">
                        <img alt="" style="margin-top: 0px;" src="../Images/Untitled.png" id="img12" /></a>--%> <br /><br />
                        
                      

                        </div><br /><br />
                        
    <div align="center">
        <table>
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server" Width="400px" Visible="False">
                        <asp:Label ID="Label1" runat="server" Text="Select Role"></asp:Label>
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                    </asp:Panel>
                    
                    <%--<img src="../Images/Log2.jpg" height="450px" alt="" />--%>
                </td>
                <td>
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div style="width: 100%; height: 200px; overflow: scroll; text-align: center; float: left;">
                                <asp:Timer ID="AutoRefreshTimer" runat="server" Interval="5000" OnTick="AutoRefreshTimer_Tick" />
                                <asp:Label ID="lblcount" runat="server" BackColor="LightGreen" Font-Size="Small"></asp:Label>
                                <asp:GridView ID="gvUseronline" runat="server" AutoGenerateColumns="false" BorderWidth="1px"
                                    Width="120px" CssClass="GridContent" BackColor="#FFFFCC" PageSize="15">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Online Users" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true"
                                            HeaderStyle-BorderColor="Blue" HeaderStyle-BackColor="LightGreen">
                                            <ItemTemplate>
                                                <table class="">
                                                    <tr>
                                                        <td width="2%" style="text-align: left;">
                                                            <img alt="" src="../Images/status.png" width="7px" height="7px" />
                                                        </td>
                                                        <td width="10%" style="text-align: left;">
                                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Font-Bold="True" ForeColor="Blue" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </td>
            </tr>
        </table>
       
    </div>
</asp:Content>
