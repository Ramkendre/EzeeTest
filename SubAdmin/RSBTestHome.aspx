<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout/AdminMaster.master"
    CodeFile="RSBTestHome.aspx.cs" Inherits="SubAdmin_RSBTestHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                                <tr>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnBack" runat="server" CssClass="btn" Text="Back To TestDefine"
                                                            PostBackUrl="~/SubAdmin/RSBCustomerTestDefine.aspx" />
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
                                <asp:Label ID="lblChapterID" runat="server" Visible="false"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
