<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AudiVideoUpload.aspx.cs"
    Inherits="SubAdmin_AudiVideoUpload" Title="Upload Audio/Video" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script src="../resources/JScript/jquery-1.11.1.js" type="text/javascript"></script>

    <script src="../resources/JScript/popup.js" type="text/javascript"></script>

    <script src="../resources/JScript/jquery-ui.js" type="text/javascript"></script>

    <script src="../resources/JScript/jquery.validate.min.js" type="text/javascript"></script>

    <script src="../resources/JScript/jquery.validationEngine.js" type="text/javascript"></script>

    <script src="../resources/JScript/jquery.validationEngine-en.js" type="text/javascript"></script>

    <link rel="Stylesheet" type="text/css" href="../resources/stylesheet/jquery-ui.theme.css" />
    <link rel="Stylesheet" type="text/css" href="../resources/stylesheet/validationEngine.jquery.css" />
</head>
<style type="text/css">
    .border
    {
        border: solid 3px Brown;
        width: 70%;
        height: 70%;
    }

    .borderviewdetails
    {
        border: solid 3px Brown;
        width: 60%;
        height: 50%;
        background-color: #FFCC66;
    }

    .labeldiv
    {
        float: left;
        margin-left: 60px;
        font-family: Tahoma;
        margin-top: 10px;
    }

    .textboxdiv
    {
        float: right;
        margin-right: 400px;
        margin-top: 10px;
    }

    .btnShow
    {
        font-family: Tahoma;
        font-size: medium;
        border: solid 1px black;
        font-weight: bold;
        background-color: #FFC0C0;
        color: Green;
        cursor: pointer;
    }

        .btnShow:hover
        {
            background-color: Yellow;
            color: Blue;
        }

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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div align="center" style="margin-top: 12px;">
                    <div class="border">
                        <div style="background-color: #F38907; height: 30px; font-family: Tahoma; font-weight: bold; color: White;"
                            align="center">
                            <asp:Label ID="lblHeading" runat="server" Font-Size="Larger" Text="Upload Audio/Video File"></asp:Label>
                        </div>
                        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                        <br />
                        <div class="labeldiv">
                            <asp:Label ID="lblAVChoose" runat="server" Text="Choose Audio/Video :"></asp:Label>
                        </div>
                        <div class="textboxdiv">
                            <asp:RadioButtonList ID="rdblstAVChoose" Width="200px" Font-Bold="true" runat="server"
                                RepeatDirection="Horizontal">
                                <asp:ListItem Value="0">Audio</asp:ListItem>
                                <asp:ListItem Value="1">Video</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <br />
                        <br />
                        <br />
                        <div class="labeldiv">
                            <asp:Label ID="lblName" runat="server" Text="Enter Name :"></asp:Label>
                        </div>
                        <div style="float: right; margin-right: 315px; margin-top: 10px;">
                            <asp:TextBox ID="txtName" Width="200px" placeholder="Enter Audio/Video Name..." runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="txtName"
                                ErrorMessage="Enter Name"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <br />
                        <div class="labeldiv">
                            <asp:Label ID="lblDescription" runat="server" Text="Enter Description :"></asp:Label>
                        </div>
                        <div style="float: right; margin-right: 280px; margin-top: 10px;">
                            <asp:TextBox ID="txtDescription" Width="200px" placeholder="Enter Description Here..."
                                runat="server" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfv2" ControlToValidate="txtDescription"
                                ErrorMessage="Enter Description"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <br />
                        <br />
                        <div class="labeldiv">
                            <asp:Label ID="lblPath" runat="server" Text="Enter Youtube URL :"></asp:Label>
                        </div>
                        <div class="textboxdiv">
                            <asp:TextBox ID="txtPath" Width="200px" placeholder="Enter Youtube URL Here..." runat="server"></asp:TextBox>
                        </div>
                        <br />
                        <br />
                        <div class="labeldiv">
                            <asp:Label ID="lblAudiopath" runat="server" Text="Select Audio File :"></asp:Label>
                        </div>
                        <div style="float: right; margin-right: 410px; margin-top: 10px;">
                            <asp:FileUpload ID="FileUpload1" Width="200px" runat="server" />
                        </div>
                        <br />
                        <br />
                        <div class="textboxdiv">
                            <asp:Button ID="btnSave" runat="server" CssClass="btnShow" Width="100px" Text="Save"
                                OnClick="btnSave_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnBack" runat="server" Text="Back" CausesValidation="false" CssClass="btnShow" Width="100px" PostBackUrl="~/CreateTest/createtest.aspx" />
                            <asp:Button ID="btn123" runat="server" Text="JITU_PATIL" CausesValidation="false" PostBackUrl="~/Download/download.aspx" />

                        </div>
                        <br />
                        <br />
                        <asp:GridView ID="gvAudiVideoList" AutoGenerateColumns="false" AllowPaging="true"
                            PageSize="5" EmptyDataText="No Value Found...!!!" Width="90%" runat="server"
                            CssClass="gridview">
                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="AVID">
                                    <ItemStyle Width="2%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Name" DataField="AVName">
                                    <ItemStyle Width="4%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Description" DataField="AVDescription">
                                    <ItemStyle Width="13%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Audio/Video" DataField="AVAbbreviation">
                                    <ItemStyle Width="2%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Upload_Date" DataField="UploadDate">
                                    <ItemStyle Width="2%" HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSave" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
