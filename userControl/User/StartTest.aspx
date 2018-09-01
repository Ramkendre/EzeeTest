<%@ Page Language="C#" MasterPageFile="~/Layout/MasterPageNew.master" AutoEventWireup="true"
    CodeFile="StartTest.aspx.cs" Inherits="User_StartTest" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <table cellpadding="0" cellspacing="0" width="70%" border="1">
           <tr>
            <td align="center">
                <div style="width: 100%">
                    <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                        <tr>
                            <td colspan="2" style="height: 20px;">
                                <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 20px;">
                                <table style="width: 80%; font-family: 'Times New Roman', Times, serif; font-size: medium;"
                                    class="tables" cellspacing="7px">
                                    <tr>
                                        <td style="text-align: center; width: 103px;">
                                        </td>
                                        <td style="text-align: center;" colspan="4" align="center" style="text-align: left;
                                            font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                            <b style="font-size: x-large">Sample Test </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="text-align: left">
                                            &nbsp;&nbsp;<span style="font-size: medium"><asp:Label ID="lblError" Visible="false"
                                                runat="server" CssClass="error" Text="Label"></asp:Label><asp:Label ID="lblSuccess"
                                                    runat="server" Visible="False" CssClass="error"></asp:Label></span><br />
                                            <span style="font-size: medium">
                                                <asp:Label ID="Label1" runat="server" CssClass="error"></asp:Label>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 103px; text-align: center;">
                                            &nbsp;Language
                                        </td>
                                        <td align="center" colspan="5" style="text-align: left">
                                            <asp:DropDownList ID="cmbSelectlang" runat="server" ToolTip="Click to select language"
                                                Width="140px" OnSelectedIndexChanged="cmbSelectlang_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem>English</asp:ListItem>
                                                <asp:ListItem>Hindi</asp:ListItem>
                                                <asp:ListItem>Marathi</asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 103px; text-align: center;">
                                            Subject <span class="warning1" style="color: Red;">*</span>
                                        </td>
                                        <td style="text-align: left" colspan="3">
                                            <asp:DropDownList ID="cmbSelectSub" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbSelectsub_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="error">
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 103px; text-align: center;">
                                            &nbsp;Chapter <span class="warning1" style="color: Red;">*</span>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:ListBox ID="lstboxSeltopic" runat="server" BackColor="Transparent" Height="62px"
                                               AutoPostBack="True"
                                                SelectionMode="Multiple" Width="172px"></asp:ListBox>
                                        </td>
                                        <td style="text-align: left">
                                            &nbsp;&nbsp;Select&nbsp; Level :<br />
                                            <asp:RadioButtonList ID="rdoLevelList" runat="server" ToolTip="Click to select level"
                                                 AutoPostBack="True"
                                                Font-Names="Arial" Font-Size="Small" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Level1" Selected="True">Level1</asp:ListItem>
                                                <asp:ListItem Value="Level2">Level2</asp:ListItem>
                                                <asp:ListItem Value="Level3">Level3</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 103px">
                                            &nbsp;
                                        </td>
                                        <td style="text-align: left" colspan="3">
                                            &nbsp;<asp:Button ID="btnStart" runat="server" CssClass="btn" Text="Start Test" ToolTip="Click here to start the test"
                                                OnClick="btnStart_Click1" />
                                            &nbsp;
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn" 
                                                Text="Cancel" ToolTip="Click here to Cancel" ValidationGroup="other" PostBackUrl="~/html/UserHome.aspx" />
                                            <asp:Label ID="lblCans" runat="server"></asp:Label>
                                        </td>
                                        <td class="error">
                                            &nbsp;
                                        </td>
                                        <td style="text-align: left">
                                        </td>
                                        <td class="error">
                                            &nbsp;
                                        </td>
                                    </tr>
        </table>
    </center>
</asp:Content>
