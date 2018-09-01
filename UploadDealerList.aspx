<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadDealerList.aspx.cs"
    Inherits="UploadData_UploadDealerList" %>

<%@ OutputCache Duration="10" VaryByParam="none" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 231px;
        }
    </style>

    <script language="javascript" type="text/javascript">
        function disableselect(e) {

            return false
        }
        function reEnable() {
            return true
        }
        document.onselectstart = new Function("return false")
        if (window.sidebar) {
            document.onmousedown = disableselect                    // for mozilla           
            document.onclick = reEnable
        }
        function clickIE() {
            if (document.all) {
                (message);
                return false;
            }
        }
        document.oncontextmenu = new Function("return false")
        var element = document.getElementById('tbl');
        element.onmousedown = function() { return false; }        // For Mozilla Browser
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnInserted" />
        </Triggers>
        <ContentTemplate>

            <script language="javascript" type="text/javascript">

                function RefreshCaptcha() {
                    var img = document.getElementById('Captcha1');
                    img.src = "~/captcha.ashx";
                }   
    
            </script>

            <center>
                <div>
                    <table class="tblSubFull">
                        <tr>
                            <td colspan="2" align="center" class="headerText">
                                <img src="../Resource/Images/hospital-icon.png" height="30px" alt="" /><span class="spanTitle">
                                    Upload Dealer List</span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <div style="height: 20px">
                                    <span style="color: red; font-size: 14px">All * field Mondatory</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="lblerror" runat="server" CssClass="error" Visible="False" Font-Size="Medium"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                &nbsp;
                            </td>
                            <td align="left">
                                <asp:Button ID="btnDownload" runat="server" CssClass="cssbtn" Style="text-align: left"
                                    Target="_blank" Text="Download Dealer Format" OnClick="btnDownload_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                Select file
                            </td>
                            <td align="left">
                                <asp:UpdatePanel ID="U2" runat="server">
                                    <ContentTemplate>
                                        <asp:FileUpload ID="databasefile" runat="server" Class="icon-file" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnUpload" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                            </td>
                            <td align="left">
                                <asp:Button ID="btnInserted" runat="server" CssClass="cssbtn" Text="Add" ToolTip="Only insert new record ,not update any record if already exist "
                                    OnClick="btnInserted_Click" />
                                &nbsp;
                                <asp:Button ID="btnUpload" runat="server" CssClass="cssbtn" Text="Update" ToolTip="Insert record and Update record if already exist"
                                    OnClick="btnUpload_Click" />
                                &nbsp;<asp:Button ID="btnClear" runat="server" CssClass="cssbtn" Text="Clear" OnClick="btnClear_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <asp:GridView ID="gvDealerlist" Width="100%" runat="server" AutoGenerateColumns="false"
                        CssClass="gridview" AllowPaging="true" PageSize="15" EmptyDataText="Dealer list Not Available">
                        <Columns>
                            <asp:BoundField DataField="Sr_No" HeaderText="Sr No.">
                                <HeaderStyle HorizontalAlign="left" Width="2%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="left" Width="2%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="NameFirm_Hospital" HeaderText="Firm Name">
                                <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="CP_FirstName" HeaderText="First Name">
                                <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="CP_LastName" HeaderText="Last Name">
                                <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Address" HeaderText="Address">
                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Pincode" HeaderText="Pincode">
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="City" HeaderText="City">
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="PhoneNo1" HeaderText="Phone No.">
                                <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="MobileNo1" HeaderText="Mobile No.">
                                <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Email_Id" HeaderText="Email Id">
                                <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                            </asp:BoundField>
                        </Columns>
                        <RowStyle CssClass="row" HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <PagerStyle CssClass="pager-row" />
                    </asp:GridView>
                    <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
