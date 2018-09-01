<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true" CodeFile="ChatApps.aspx.cs" Inherits="Admin_ChatApps" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/JavaScript">
<!--
        function AutoRefresh(t) {
            setTimeout("location.reload(true);", t);
        }
//   -->
    </script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Timer ID="AutoRefreshTimer" runat="server" Interval="5000" OnTick="AutoRefreshTimer_Tick" />
                <asp:GridView ID="gvUseronline" runat="server" AutoGenerateColumns="false" BorderWidth="2px"
                    Width="300px" >
                    <Columns>
                        <asp:TemplateField HeaderText="Online" HeaderStyle-ForeColor="white">
                            <ItemTemplate>
                                <table class="">
                                    <tr>
                                        <td width="70%">
                                            <%--<asp:LinkButton ID="lnkName" runat="server" Text='<%#Eval("Fullname") %>' Font-Underline="false"></asp:LinkButton>--%>
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                        </td>
                                        <td width="30%">
                                            <img alt="" src="../Images/status.png" width="7px" height="7px" />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

