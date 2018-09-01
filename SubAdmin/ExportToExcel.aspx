<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExportToExcel.aspx.cs" Inherits="SubAdmin_ExportToExcel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script src="../resources/JScript/jquery-1.11.1.js" type="text/javascript"></script>

    <script src="../resources/JScript/popup.js" type="text/javascript"></script>

    <script src="../resources/JScript/jquery-ui.js" type="text/javascript"></script>

    <link href="../resources/stylesheet/jquery-ui.theme.css" type="text/css" rel="Stylesheet" />

    <script type="text/javascript">
        $(document).ready(function() {
            //Generate dialog on panel
            $(function() {
                $("#<%=txtDate.ClientID%>").datepicker({
                    changeMonth: true,
                    changeYear: true,
                    dateFormat: 'yy-mm-dd'
                });
            });


//Below Code is For Working of Jquery within UpdatePanel
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (prm != null) {
                prm.add_endRequest(function(sender, e) {
                    if (sender._postBackSettings.panelsToUpdate != null) {
                        $(function() {
                            $("#<%=txtDate.ClientID%>").datepicker({
                                changeMonth: true,
                                changeYear: true,
                                dateFormat: 'yy-mm-dd'
                            });
                        });
                    }
                });
            };

        });
            
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <asp:Button ID="btnExportExcel" runat="server" Text="ExportToExcel" Font-Bold="true"
                    OnClick="btnExportExcel_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnShowMasterData" Visible="false" runat="server" Text="Show Master Student Data"
                    OnClick="btnShowMasterData_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnShowDataStudentsofPerClassAdmin" runat="server" Font-Bold="true"
                    Text="Shows_AllUsers_Details_AsPerLogin" OnClick="btnShowDataStudentsofPerClassAdmin_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlCenterNo" runat="server" Font-Bold="true">
                </asp:DropDownList>
                <asp:TextBox ID="txtCenterNo" placeholder="Enter Center No." Visible="false" Font-Bold="true"
                    MaxLength="10" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:TextBox ID="txtDate" placeholder="Select Date Of Exam" Font-Bold="true" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="btnShowStudentScoreDetails" runat="server" Font-Bold="true" Text="Shows_Students_ScoreDetails_AsPerCenterNo"
                    OnClick="btnShowStudentScoreDetails_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnGetTeacMoNo" runat="server" Text="Get_CenterNo_AsPerDate" Font-Bold="true"
                    OnClick="btnGetTeacMoNo_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnBack" runat="server" Font-Bold="true" Text="Back" PostBackUrl="~/Admin/UserList.aspx" /><br /><br />
                <asp:TextBox ID="txtCenterCode" runat="server" placeholder="Enter Center_Code..." MaxLength="10" Font-Bold="true" Visible="false"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Button ID="btnPrint" runat="server" Font-Bold="true" Text="Print" visible="false"
                    onclick="btnPrint_Click" />
                
                <br />
                <br />
                <asp:GridView ID="gvExportToExcel" runat="server" AutoGenerateColumns="true">
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportExcel" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
