<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAppItemMaster.aspx.cs" Inherits="SubAdmin_AddAppItemMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .container
        {
            border: 2px solid #ccc;
            width: 300px;
            height: 105px;
            overflow-y: scroll;
            font-size: medium;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>SELECT TYPEOFEXAM</td>
                    <td>:</td>
                    <td>
                        <asp:DropDownList ID="ddlTypeofExam" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTypeofExam_SelectedIndexChanged"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>SELECT CLASS</td>
                    <td>:</td>
                    <td>
                        <asp:DropDownList ID="ddlClass" runat="server" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>SELECT SUBJECTS</td>
                    <td>:</td>
                    <td style="height: 40px; width: 350px;">
                        <div class="container">
                            <asp:CheckBoxList ID="chkSubject" runat="server">
                            </asp:CheckBoxList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnInsert" runat="server" Text="INSERT_RECORDS" OnClick="btnInsert_Click" />
                    </td>
                </tr>
            </table>

            <table>
                <tr>
                    <td>
                        <asp:GridView ID="gvAddAppItemMaster" runat="server" AutoGenerateColumns="true" AllowPaging="true" OnPageIndexChanging="gvAddAppItemMaster_PageIndexChanging" PageSize="10"></asp:GridView>
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblSubjectID" runat="server" Visible="true"></asp:Label>
        </div>
    </form>
</body>
</html>
