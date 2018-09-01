<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="TestHome.aspx.cs" Inherits="Admin_TestHome" Title="Online Exam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function() { null };
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 100%;" align="center">
                <table cellpadding="0" cellspacing="0" width="70%" border="1">
                    <tr>
                        <td align="center">
                            <div style="width: 80%">
                                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                    <tr>
                                        <td colspan="2" style="height: 20px;">
                                            <span class="warning1" style="color: Red;"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 20px;">
                                            <table style="width: 100%" class="tables" cellspacing="7px">
                                                <tr>
                                                    <td align="center">
                                                        <span style="color: Maroon; font-size: x-large; width: 190px">Welcome </span>&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <span style="color: Green; font-size: x-large; width: 210px">
                                                            <%=Convert.ToString(Session["UserName"])%>
                                                        </span>
                                                    </td>
                                                    <td align="left">
                                                        <%--<span style="color: Green;font-size:medium;width:210px">
                                                        <%=Convert.ToString(Session["UserName"])%>
                                                    </span>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="font-size: medium" colspan="2">
                                                        Select Exam Name :&nbsp;
                                                        <asp:DropDownList ID="ddltest" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddltest_SelectedIndexChanged"
                                                            Width="120Px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 20px;">
                                            <span class="warning1" style="color: Red;"></span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <br />
            <div align="center">
                <asp:Button ID="btnSendDataToServer" runat="server" Visible="false" Text="Upload Result"
                    PostBackUrl="~/StudentResult.aspx" Width="200px" Font-Bold="true" ForeColor="Chocolate"
                    BackColor="AliceBlue" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
