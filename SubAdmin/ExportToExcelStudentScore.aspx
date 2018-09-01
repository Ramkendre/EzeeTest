<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExportToExcelStudentScore.aspx.cs" Inherits="SubAdmin_ExportToExcelStudentScore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="btnExportExcel" runat="server" Visible="false" Text="ExportToExcel" 
            onclick="btnExportExcel_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
            <asp:TextBox ID="txtCenterNo" Visible="false" runat="server"></asp:TextBox>
            
            
            
            <asp:Button ID="btnShowMasterData" Visible="false" runat="server" 
            Text="Show Master Student Data" onclick="btnShowMasterData_Click" />
            
            
            <br /><br />
    <asp:GridView ID="gvExportToExcel" runat="server" AutoGenerateColumns="true"></asp:GridView>
    
    </div>
    </form>
</body>
</html>
