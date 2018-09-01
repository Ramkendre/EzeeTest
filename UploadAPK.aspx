<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadAPK.aspx.cs" Inherits="UploadAPK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblHeading" runat="server" Text="*** UPLOAD APK FOR EZEETEST AND EZEECLASS ***" Font-Bold="true" Font-Size="Medium" BackColor="DarkOrange" ForeColor="White"></asp:Label><br />
            <br />
            <asp:FileUpload ID="FileUploadAPK" runat="server" />&nbsp;&nbsp;
        
        <asp:Button ID="btnUpload" runat="server" Text="UPLAOD_APK" OnClick="btnUpload_Click" /><br />
            <br />
            <asp:Label ID="lblInstruction" runat="server" Text="" Font-Size="Small" ForeColor="Wheat"></asp:Label>

        </div>
    </form>
</body>
</html>
