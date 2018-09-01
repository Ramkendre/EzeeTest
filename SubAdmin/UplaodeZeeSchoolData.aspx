<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UplaodeZeeSchoolData.aspx.cs" Inherits="SubAdmin_UplaodeZeeSchoolData"  Title="eZeeSchool DataUpload"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUploadeZeeSchool" runat="server" />&nbsp;&nbsp;

        <asp:Button ID="btnUpload" runat="server" Text="UPLAOD_DATA" OnClick="btnUpload_Click" />
            &nbsp;&nbsp;

        <asp:Button ID="btnBack" runat="server" Text="BACK" PostBackUrl="http://www.ezeeschool.in:8085/html/Home.aspx" />

            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton runat="server" Text="CLICK HERE TO DOWNLOAD EXCELFILE FORMAT..!!!" ID="lnkbtndownloadFormat" OnClick="lnkbtndownloadFormat_Click"></asp:LinkButton>
        </div>
    </form>
</body>
</html>
