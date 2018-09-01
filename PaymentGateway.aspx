<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentGateway.aspx.cs" Inherits="PaymentGateway" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>

<style type="text/css">
        .gridview
        {
            background-color: #f2f9f8;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
            font-family: Arial;
        }
        .gridview td
        {
            padding: 2px;
            border: solid 1px #c1c1c1;
            color: black;
            font-size: 12px;
        }
        .gridview td:hover
        {
            padding: 2px;
            border: solid 1px #c1c1c1;
            font-size: 13px;
            background: #dddddd;
        }
        .gridview th
        {
            padding: 4px 2px;
            color: #fff;
            background: #164854;
            border-left: solid 1px #525252;
            font-size: 12px;
        }
        .gridview .gridview_alter
        {
            background: #E7E7E7;
        }
        .gridview .gridview_pager
        {
            background: #424242;
        }
        .gridview .gridview_pager table
        {
            margin: 5px 0;
        }
        .gridview .gridview_pager td
        {
            border-width: 0;
            padding: 0 6px;
            border-left: solid 1px #666;
            font-weight: bold;
            color: #fff;
            line-height: 12px;
        }
        .gridview .gridview_pager a
        {
            color: #666;
            text-decoration: none;
        }
        .gridview .gridview_pager a:hover
        {
            color: #000;
            text-decoration: none;
        }
        .lnkbtnerror
        {
            color: HighlightText;
            font-family: Courier New;
            font-size: medium;
            font-weight: bold;
            text-shadow: 2px 2px 2px yellow;
        }
        .lnkbtnerror:hover
        {
            text-decoration: underline;
            color: Red;
        }
        .pointer
        {
            cursor: pointer;
        }
        .lnkbtnGiveTest
        {
            color: Blue;
            font-family: Courier New;
            font-size: small;
        }
        .lnkbtnGiveTest:hover
        {
            color: Red;
        }
    </style>

<body>
    <form id="form1" runat="server">
    <div style="width: 100%;" align="center">
        <table>
            <tr>
                <th>
                    <asp:Label ID="lblhead" runat="server" Font-Size="Medium" Font-Names="Tahoma" Text="Make Payment...!!!"
                        Font-Bold="true" ForeColor="Green"></asp:Label>
                </th>
            </tr>
        </table>
        <br />
        <table style="width: 60%; height: 100px; border: 2px solid black; vertical-align: text-top;">
            <tr>
                <td width="22%">
                    <b>Select GroupOfExam :</b>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlGroupofExam" runat="server" OnSelectedIndexChanged="ddlGroupofExam_SelectedIndexChanged"
                        AutoPostBack="true">
                        <asp:ListItem Value="1">--Select--</asp:ListItem>
                        <asp:ListItem Value="143">Competitive Exam</asp:ListItem>
                        <asp:ListItem Value="140">Scholarship</asp:ListItem>
                        <asp:ListItem Value="141">Engineering Entrance</asp:ListItem>
                        <asp:ListItem Value="142">Medical Entrance</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqddlGroupofExam" runat="server" ControlToValidate="ddlGroupofExam"
                        ErrorMessage=" * Required " InitialValue="1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Select Exam Name :</b>
                </td>
                <td>
                    <asp:DropDownList ID="ddlExamName" runat="server" AutoPostBack="true"
                        onselectedindexchanged="ddlExamName_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqddlExamName" runat="server" ControlToValidate="ddlExamName"
                        ErrorMessage=" * Required " InitialValue="1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Amount To Pay :</b>
                </td>
                <td>
                    <asp:Label ID="lblAmount" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Green"></asp:Label>
                </td>
            </tr>
            <td>
                <b>Enter Amount Here :</b>
            </td>
            <td>
                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
            </td>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnProceed" runat="server" Font-Bold="true" BackColor="#800000" ForeColor="White"
                        Text="Click To Proceed !!!" OnClick="btnProceed_Click" CssClass="pointer" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
