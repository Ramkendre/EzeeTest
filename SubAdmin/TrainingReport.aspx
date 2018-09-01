<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true" CodeFile="TrainingReport.aspx.cs" Inherits="SubAdmin_TrainingReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../resources/JScript/jquery-1.11.1.js" type="text/javascript"></script>

    <script src="../resources/JScript/popup.js" type="text/javascript"></script>

    <script src="../resources/JScript/jquery-ui.js" type="text/javascript"></script>

    <link rel="Stylesheet" type="text/css" href="../resources/stylesheet/jquery-ui.theme.css" />

    <script type="text/javascript" language="javascript">

        $(document).ready(function () {
            $("#<%=txtSrchNumber.ClientID%>").datepicker({

                changeMonth: true,
                changeYear: true,
                dateFormat: 'yy-mm-dd',
                showOn: 'button',
                buttonImage: '../resources/iconCalendar.gif',
                buttonText: 'Show Date',
                buttonImageOnly: true

            });


            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (prm != null) {
                prm.add_endRequest(function (sender, e) {
                    if (sender._postBackSettings.panelsToUpdate != null) {
                        $("#<%=txtSrchNumber.ClientID%>").datepicker({

                            changeMonth: true,
                            changeYear: true,
                            dateFormat: 'yy-mm-dd',
                            showOn: 'button',
                            buttonImage: '../resources/iconCalendar.gif',
                            buttonText: 'Show Date',
                            buttonImageOnly: true

                        });
                    }
                });
            };
        });


    </script>

    <style type="text/css">
        .Space {
            height: 8px;
        }

        .ui-datepicker {
            font-size: 8pt !important;
        }

        .SpcBwnBtnAndGv {
            /*height: 7px;*/
            height: 52px;
            padding-left: 142px;
        }

        .btnDispaly {
            margin-top: 9px;
            padding-top: 5px;
            width: 332px;
            height: 38px;
            text-align: right;
            float: left;
        }
    </style>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div style="width: 100%;" align="center">
                &nbsp;<table cellpadding="0" cellspacing="0" width="80%" border="1">
                    <tr>
                        <td align="center">
                            <div id="div" style="width: 100%; margin-right: 7px;">
                                <table cellpadding="0" cellspacing="0" border="0" width="70%" class="tables">
                                    <div style="width: 96%">
                                        <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                            <tr>
                                                <td style="height: 20px;">
                                                    <table style="width: 81%; margin-left: 148px;" class="tables" cellspacing="2" cellpadding="2">
                                                        <tr>
                                                            <td colspan="2" align="center" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                                <h3 style="color: Green">Training Report</h3>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="width: 628px; text-align: Center;">
                                                                <asp:Label ID="lblslctField" runat="server" Font-Bold="true" Font-Names="Arial"
                                                                    Font-Size="11pt" Text="Select Field"></asp:Label>
                                                                <span class="warning1" style="color: Red;">*&nbsp;</span>
                                                            </td>
                                                            <td style="width: 628px; text-align: center;">
                                                                <asp:Label ID="lblSlctoperator" runat="server" Font-Bold="true" Font-Names="Arial"
                                                                    Font-Size="11pt" Text="Select Operator"></asp:Label>
                                                                <span class="warning1" style="color: Red;">*&nbsp;</span>
                                                            </td>
                                                            <td style="width: 628px; text-align: left;">&nbsp;
                                                               <asp:Label ID="lblSlctFielditem" runat="server" Font-Bold="true" Font-Names="Arial" Visible="false"
                                                                   Font-Size="11pt" Text="Select Field Item"></asp:Label>
                                                                <asp:Label ID="lblSlctDate" runat="server" Font-Bold="true" Visible="false" Font-Names="Arial"
                                                                    Font-Size="11pt" Text="Select Date"></asp:Label>
                                                            </td>
                                                            <td style="width: 628px; text-align: left;">&nbsp;
                                                             
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 276px; text-align: Center;">
                                                                <asp:DropDownList ID="ddlField" runat="server" OnSelectedIndexChanged="ddlField_SelectedIndexChanged" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 34%; text-align: center;">
                                                                <asp:DropDownList ID="ddlOperator" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 18%; text-align: right;">
                                                                <asp:DropDownList ID="ddlFieldItem" runat="server" Visible="false" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                                <asp:TextBox ID="txtSrchNumber" runat="server" Visible="false"></asp:TextBox>
                                                                <%--  <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                    PopupButtonID="imgFromDate" TargetControlID="txtSrchNumber">
                                                                </asp:CalendarExtender>--%>
                                                                <%-- <img id="imgFromDate" align="middle" alt="ezeesofts &amp; Co." border="0" height="24"
                                                                    src="../resources/images/calendarclick.gif" />--%>
                                                            </td>
                                                            <td align="left" style="width: 18%; text-align: Center;">
                                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn" Width="70px" OnClick="btnAdd_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td align="left" style="width: 37%; text-align: center">
                                                                <asp:CheckBoxList runat="server" ID="ChkAddList">
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                        <div class="Space">
                                                        </div>
                                                        <tr>
                                                            <td style="width: 5%; text-align: center">
                                                                <asp:Label ID="lblshwField" runat="server" Text="Show Field" Font-Bold="true" Font-Names="Arial" Font-Size="11pt">

                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <%-- <td style="width:5%; text-align:right">
                                                                <asp:Label ID="lblshwField" runat="server" Text="Show Field" Font-Bold="true" Font-Names="Arial" Font-Size="11pt">

                                                                </asp:Label>
                                                            </td>--%>
                                                            <td style="width: 15%; text-align: left">
                                                                <asp:ListBox ID="lstbox1" runat="server" Width="200px" Height="170px" SelectionMode="Multiple">
                                                                    <%--   <asp:ListItem Value="1">userMobileNumber</asp:ListItem>
                                                                    <asp:ListItem Value="2">CourseCode</asp:ListItem>
                                                                    <asp:ListItem Value="3">CourseTitle</asp:ListItem>
                                                                    <asp:ListItem Value="4">CourseDirector</asp:ListItem>
                                                                    <asp:ListItem Value="5">StartDate</asp:ListItem>
                                                                    <asp:ListItem Value="6">EndDate</asp:ListItem>
                                                                    <asp:ListItem Value="7">Duration</asp:ListItem>
                                                                    <asp:ListItem Value="8">TrainingVenue</asp:ListItem>
                                                                    <asp:ListItem Value="9">PlaceTaluka</asp:ListItem>
                                                                    <asp:ListItem Value="10">Department</asp:ListItem>
                                                                    <asp:ListItem Value="11">TypeofTraining</asp:ListItem>
                                                                    <asp:ListItem Value="12">TrainingType</asp:ListItem>
                                                                    <asp:ListItem Value="13">CourseCategory</asp:ListItem>
                                                                    <asp:ListItem Value="14">SponseredBy</asp:ListItem>
                                                                    <asp:ListItem Value="15">TrainingCategory</asp:ListItem>
                                                                    <asp:ListItem Value="16">EmploymentGroup</asp:ListItem>
                                                                    <asp:ListItem Value="17">NoOfParticipants</asp:ListItem>
                                                                    <asp:ListItem Value="18">Rate</asp:ListItem>--%>
                                                                </asp:ListBox>
                                                            </td>
                                                            <td style="width: 10%; text-align: center">
                                                                <asp:Button ID="btnRight" runat="server" Text=" >> " CssClass="btn" OnClick="btnRight_Click" /><br />
                                                                <br />
                                                                <asp:Button ID="btnleft" runat="server" Text=" << " CssClass="btn" OnClick="btnleft_Click" />
                                                            </td>
                                                            <td>
                                                                <asp:ListBox ID="lstbox2" runat="server" Width="180px" Height="170px" SelectionMode="Multiple"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <div class="btnDispaly">
                                                        <asp:Button ID="btdisplay" runat="server" Text="Display" CssClass="btn" OnClick="btdisplay_Click" />
                                                    </div>
                                                    <div class="btnDispaly">
                                                        <asp:Button ID="btnExportToExcel" runat="server" Text="ExportToExcel" CssClass="btn" OnClick="btnExportToExcel_Click" />
                                                    </div>
                                                    <div class="SpcBwnBtnAndGv">
                                                    </div>
                                                    <div class="SpcBwnBtnAndGv">
                                                        <table>
                                                            <tr>
                                                                <td>Record Count:
                                                                    <asp:Label ID="lblCount" runat="server" Font-Bold="true" Font-Size="14pt"></asp:Label>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </div>
                                                    <div class="grid" style="width: 100%">
                                                        <div class="rounded">
                                                            <div class="top-outer">
                                                                <div class="top-inner">
                                                                    <div class="top">
                                                                        &nbsp;
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="mid-outer">
                                                                <div class="mid-inner">
                                                                    <div class="mid">
                                                                        <div class="pager">
                                                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="datatable" EmptyDataText="Not Found Record."
                                                                                CellSpacing="3" CellPadding="2">
                                                                            </asp:GridView>
                                                                            <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="bottom-outer">
                                                                <div class="bottom-inner">
                                                                    <div class="bottom">
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                        </td>
                    </tr>
                </table>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

