<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Master Data Export.aspx.cs" Inherits="Master_Data_Export" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnExportExcel" runat="server" Text="ExportToExcel"
                OnClick="btnExportExcel_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnShowMasterData" runat="server"
                Text="Show Master Student Data" OnClick="btnShowMasterData_Click" />

            <asp:FileUpload ID="FileUpload1" runat="server" />

            <br />
            <br />
            <asp:GridView ID="gvExportToExcel" runat="server" AutoGenerateColumns="true"></asp:GridView>

        </div>
    </form>
</body>
</html>
