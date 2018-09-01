<%@ Page Title="Student Registration Excel FileUpload" Language="C#" AutoEventWireup="true"
    CodeFile="UploadStudentRegExcel.aspx.cs" MasterPageFile="~/Layout/AdminMaster.master" Inherits="Andorid_Class_App_UploadStudentRegExcel" %>

<%@ Register Assembly="AjaxcontrolToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>

    <script type="text/javascript">
        $(function () {
            blinkeffect('#txtblnk');
        })
        function blinkeffect(selector) {
            $(selector).fadeOut('slow', function () {
                $(this).fadeIn('slow', function () {
                    blinkeffect(this);
                });
            });
        }
    </script>

    <div style="width: 100%;" align="center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <table cellpadding="0" cellspacing="0" width="75%" border="1" class="tables">
                    <tr>
                        <td style="text-align: center;">
                            <div style="width: 100%">
                                <center>
                                    <table cellpadding="2" cellspacing="2" width="75%" class="tables">
                                        <tr>
                                            <td colspan="4" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                <h4 style="color: Green; font-family: Consolas">UPLOAD EXCELFILE FOR STUDENT REGISTRATION
                                                </h4>
                                            </td>
                                        </tr>
                                        <tr style="background-color: #FFFFBB;">
                                            <td colspan="4" style="text-align: left; width: 150px">
                                                <asp:Label ID="lblClass" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                    Text="Select Class :"></asp:Label>
                                                <asp:DropDownList ID="ddlClass" AutoPostBack="true" runat="server">
                                                </asp:DropDownList>&nbsp;&nbsp;
                                        <asp:Label ID="lblBatch" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                            Text="Select Batch :"></asp:Label>
                                                <asp:DropDownList ID="ddlBatch" runat="server">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem>A</asp:ListItem>
                                                    <asp:ListItem>B</asp:ListItem>
                                                    <asp:ListItem>C</asp:ListItem>
                                                    <asp:ListItem>D</asp:ListItem>
                                                    <asp:ListItem>E</asp:ListItem>
                                                    <asp:ListItem>F</asp:ListItem>
                                                    <asp:ListItem>H</asp:ListItem>
                                                    <asp:ListItem>I</asp:ListItem>
                                                    <asp:ListItem>J</asp:ListItem>
                                                    <asp:ListItem>K</asp:ListItem>
                                                    <asp:ListItem>L</asp:ListItem>
                                                    <asp:ListItem>M</asp:ListItem>
                                                    <asp:ListItem>N</asp:ListItem>
                                                    <asp:ListItem>O</asp:ListItem>
                                                    <asp:ListItem>P</asp:ListItem>
                                                    <asp:ListItem>Q</asp:ListItem>
                                                    <asp:ListItem>R</asp:ListItem>
                                                    <asp:ListItem>S</asp:ListItem>
                                                    <asp:ListItem>T</asp:ListItem>
                                                    <asp:ListItem>U</asp:ListItem>
                                                    <asp:ListItem>V</asp:ListItem>
                                                    <asp:ListItem>W</asp:ListItem>
                                                    <asp:ListItem>X</asp:ListItem>
                                                    <asp:ListItem>Y</asp:ListItem>
                                                    <asp:ListItem>Z</asp:ListItem>
                                                </asp:DropDownList>&nbsp;&nbsp;
                                        <asp:Label ID="lblSession" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                            Text="Select Session :"></asp:Label>
                                                <asp:DropDownList ID="ddlSession" runat="server">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem>2015-16</asp:ListItem>
                                                    <asp:ListItem>2016-17</asp:ListItem>
                                                    <asp:ListItem>2017-18</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <asp:Label ID="lblDownloadExcel" runat="server" Font-Size="Medium" Text="First Download ExcelFile Format :"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:LinkButton ID="lnkdownload" runat="server" Text="Click Here To Download" Font-Size="Medium" OnClick="lnkdownload_Click"></asp:LinkButton>
                                                <div id="txtblnk"><font color="red">New..!!!</font></div>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Select Excel File :"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:FileUpload ID="excelFileUpload" runat="server" Font-Bold="true" Visible="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td colspan="2">
                                                <asp:Button ID="btnupload" runat="server" Font-Bold="true" Text="Upload File" Visible="true"
                                                    OnClick="btnupload_Click" CssClass="btn" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <br />
                                                <br />
                                                <asp:Label ID="lblStatus" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblMessage" runat="server" Text="" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnupload" />
                <asp:PostBackTrigger ControlID="lnkdownload" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
