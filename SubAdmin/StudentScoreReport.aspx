<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="StudentScoreReport.aspx.cs"
    Inherits="SubAdmin_MangalDemo" Title="eZeeTest:Exam_Results" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script src="../resources/JScript/jquery-1.11.1.js" type="text/javascript"></script>

    <script src="../resources/JScript/popup.js" type="text/javascript"></script>

    <script src="../resources/JScript/jquery-ui.js" type="text/javascript"></script>

    <link rel="Stylesheet" type="text/css" href="../resources/stylesheet/jquery-ui.theme.css" />

    <script type="text/javascript" language="javascript">

        $(document).ready(function () {
            $("#<%=txtDate.ClientID%>").datepicker({

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
                        $("#<%=txtDate.ClientID%>").datepicker({

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
        .border {
            border: solid 3px Brown;
            width: 100%;
            height: 50%;
        }

        .borderviewdetails {
            border: solid 3px Brown;
            width: 700px;
            height: 340px;
            background-color: #FFCC66;
        }

        .labeldiv {
            float: left;
            margin-left: 20px;
            font-family: Tahoma;
            margin-top: 10px;
        }

        .textboxdiv {
            float: right;
            margin-right: 56%;
            margin-top: 10px;
        }

        .btnShow {
            font-family: Tahoma;
            font-size: medium;
            border: solid 1px black;
            font-weight: bold;
            background-color: #FFC0C0;
            color: Green;
            cursor: pointer;
        }

            .btnShow:hover {
                background-color: Yellow;
                color: Blue;
            }

        .gridview {
            background-color: #f2f9f8;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
            font-family: Arial;
        }

            .gridview td {
                padding: 2px;
                border: solid 1px #c1c1c1;
                color: black;
                font-size: 12px;
            }

                .gridview td:hover {
                    padding: 2px;
                    border: solid 1px #c1c1c1;
                    font-size: 13px;
                    background: #dddddd;
                }

            .gridview th {
                padding: 4px 2px;
                color: #fff;
                background: #164854;
                border-left: solid 1px #525252;
                font-size: 12px;
            }

            .gridview .gridview_alter {
                background: #E7E7E7;
            }

            .gridview .gridview_pager {
                background: #424242;
            }

                .gridview .gridview_pager table {
                    margin: 5px 0;
                }

                .gridview .gridview_pager td {
                    border-width: 0;
                    padding: 0 6px;
                    border-left: solid 1px #666;
                    font-weight: bold;
                    color: #fff;
                    line-height: 12px;
                }

                .gridview .gridview_pager a {
                    color: #666;
                    text-decoration: none;
                }

                    .gridview .gridview_pager a:hover {
                        color: #000;
                        text-decoration: none;
                    }

        .lnkbtnerror {
            color: HighlightText;
            font-family: Courier New;
            font-size: medium;
            font-weight: bold;
            text-shadow: 2px 2px 2px yellow;
        }

            .lnkbtnerror:hover {
                text-decoration: underline;
                color: Red;
            }

        .pointer {
            cursor: pointer;
        }

        .lnkbtnGiveTest {
            color: Blue;
            font-family: Courier New;
            font-size: small;
        }

            .lnkbtnGiveTest:hover {
                color: Red;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>

                <script type="text/javascript">
                    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InIEvent);
                    //Sys.Application.add_load(jScript);
                </script>

                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <div align="center">
                            <div class="border">

                                <div class="labeldiv">
                                    <asp:Label ID="lblGroupofExam" runat="server" Text="Select Type of Exam :"></asp:Label>
                                </div>
                                <div class="textboxdiv">
                                    <asp:DropDownList ID="ddlGroupofExam" runat="server" AutoPostBack="true" Width="170px"
                                        OnSelectedIndexChanged="ddlGroupofExam_SelectedIndexChanged">
                                        <asp:ListItem Value="1">--Select--</asp:ListItem>
                                        <asp:ListItem Value="140">Scholarship</asp:ListItem>
                                        <asp:ListItem Value="143">Competitive Exam</asp:ListItem>
                                        <asp:ListItem Value="141">Engineering Entrance</asp:ListItem>
                                        <asp:ListItem Value="142">Medical Entrance</asp:ListItem>
                                        <asp:ListItem Value="144">Computer Courses</asp:ListItem>
                                        <asp:ListItem Value="177">Skill Tests</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="reqddlGroupofExam" runat="server" ControlToValidate="ddlGroupofExam"
                                        ErrorMessage=" * Required " InitialValue="1"></asp:RequiredFieldValidator>
                                </div>
                                <br />
                                <br />
                                <div class="labeldiv">
                                    <asp:Label ID="lblTypeofExam" runat="server" Text="Select Exam Name :"></asp:Label>
                                </div>
                                <div class="textboxdiv">
                                    <asp:DropDownList ID="ddlExamName" Width="170px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlExamName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="reqddlExamName" runat="server" ControlToValidate="ddlExamName"
                                        ErrorMessage=" * Required " InitialValue="1"></asp:RequiredFieldValidator>
                                </div>
                                <br />
                                <br />
                                <div class="labeldiv">
                                    <asp:Label ID="lblSubject" runat="server" Text="Select Subject Name :" Visible="false"></asp:Label>
                                </div>
                                <div class="textboxdiv">
                                    <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="true" Width="170px" Visible="false">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="134">CCC Demo</asp:ListItem>
                                        <asp:ListItem Value="164">MSCIT Demo</asp:ListItem>
                                        <asp:ListItem Value="111">Tally</asp:ListItem>
                                        <asp:ListItem Value="112">DTP</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSubject"
                                        ErrorMessage=" * Required " InitialValue="1"></asp:RequiredFieldValidator>
                                </div>
                                <br />
                                <br />
                                <div class="labeldiv">
                                    <asp:Label ID="lblSearchBy" runat="server" Text="Search By :"></asp:Label>
                                </div>
                                <div style="margin-right: 39%">
                                    <asp:RadioButtonList ID="rdolstSearchBy" runat="server" RepeatDirection="Vertical">
                                        <asp:ListItem Value="0">User_Mobile_No</asp:ListItem>
                                        <asp:ListItem Value="1">UDISE_Code/School_Code</asp:ListItem>
                                        <asp:ListItem Value="2">IMEI_No</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="reqSearchBy" runat="server" ControlToValidate="rdolstSearchBy"
                                        ErrorMessage=" * Required "></asp:RequiredFieldValidator>
                                </div>
                                <div class="labeldiv">
                                    <asp:Label ID="lblCenterNo" runat="server" Text="Enter User_Mob_No/UDISE_Code/IMEI_No :"></asp:Label>
                                </div>
                                <div class="textboxdiv">
                                    <asp:TextBox ID="txtCenterNo" runat="server" MaxLength="16"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqtxtCenterNo" runat="server" ControlToValidate="txtCenterNo"
                                        ErrorMessage=" * Required "></asp:RequiredFieldValidator>
                                </div>
                                <br />
                                <br />
                                <div class="labeldiv">
                                    <asp:Label ID="lblDate" runat="server" Text="Select Date of Exam :"></asp:Label>
                                </div>
                                <div class="textboxdiv" style="margin-right: 60%;">
                                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>&nbsp;&nbsp;
                                </div>
                                <br />
                                <div class="textboxdiv">
                                    <asp:Button ID="btnGetData" runat="server" CssClass="btnShow" Text="Show Details"
                                        OnClick="btnGetData_Click" />
                                    &nbsp;&nbsp;
                                <asp:Button ID="btnBack" runat="server" CausesValidation="false" CssClass="btnShow"
                                    Text="Back" PostBackUrl="~/CreateTest/createtest.aspx" />
                                </div>
                                <div style="margin-top: 100px;">
                                    <asp:Button ID="btnExportExcel" runat="server" CssClass="btnShow" Text="Export_To_Excel"
                                        OnClick="btnExportExcel_Click" />
                                    <asp:GridView ID="gvStudentData" AutoGenerateColumns="false" CssClass="gridview"
                                        EmptyDataText="No Result found for this combination" AllowPaging="true" PageSize="10"
                                        Width="90%" runat="server" OnPageIndexChanging="gvStudentData_PageIndexChanging"
                                        OnRowCommand="gvStudentData_RowCommand" OnRowDataBound="gvStudentData_RowDataBound">
                                        <Columns>
                                            <asp:BoundField HeaderText="UserID" DataField="UserMobileNo">
                                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="First_Name" DataField="firstName">
                                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Last_Name" DataField="lastName">
                                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="UDISE_CODE" DataField="UDISE_Code">
                                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="IMEI_NO" DataField="IMEI">
                                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Exam_Date" DataField="TestDate">
                                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Paper_Name" DataField="PaperName">
                                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Obtain_Marks" DataField="ObtainMarks">
                                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Total_Marks" DataField="Total">
                                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Result" DataField="Status">
                                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="ViewDetails" Visible="false">
                                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="gvlnkbtnView" Text="ViewDetails" CommandName="ViewDetails" runat="server"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:Panel ID="pnlViewDetails" CssClass="borderviewdetails" runat="server">
                            <div align="center" style="background-color: #FF66CC; margin-top: 5px;">
                                <b style="font-family: Tahoma; font-size: medium; font-weight: bold;">Student Result
                                Details</b>
                            </div>
                            <hr />
                            <br />
                            <div style="float: left; margin-left: 10px;">
                                <div style="float: left; margin-left: 10px;">
                                    <b style="color: #3366FF;">UserId :</b>
                                </div>
                                &nbsp;
                            <div style="float: right; margin-right: 100px;">
                                <asp:Label ID="lblUserId" runat="server" Text=""></asp:Label>
                            </div>
                            </div>
                            <div style="float: right; margin-right: 200px;">
                                <div style="float: left; margin-left: 10px;">
                                    <b style="color: #3366FF;">StudentName :</b>
                                </div>
                                &nbsp;
                            <div style="float: right; margin-right: 10px;">
                                <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                            </div>
                            </div>
                            <br />
                            <br />
                            <div style="float: left; margin-left: 10px;">
                                <div style="float: left; margin-left: 10px;">
                                    <b style="color: #3366FF;">CenterID :</b>
                                </div>
                                &nbsp;
                            <div style="float: right; margin-right: 100px;">
                                <asp:Label ID="lblCenterNoView" runat="server" Text=""></asp:Label>
                            </div>
                            </div>
                            <div style="float: right; margin-right: 157px;">
                                <div style="float: left; margin-left: 10px;">
                                    <b style="color: #3366FF;">CenterName :</b>
                                </div>
                                &nbsp;
                            <div style="float: right; margin-right: 10px;">
                                <asp:Label ID="lblCenterName" runat="server" Text=""></asp:Label>
                            </div>
                            </div>
                            <br />
                            <br />
                            <div style="float: left; margin-left: 10px;">
                                <div style="float: left; margin-left: 10px;">
                                    <b style="color: #3366FF;">PaperID :</b>
                                </div>
                                &nbsp;
                            <div style="float: right; margin-right: 100px;">
                                <asp:Label ID="lblPaperID" runat="server" Text=""></asp:Label>
                            </div>
                            </div>
                            <div style="float: right; margin-right: 200px;">
                                <div style="float: left; margin-left: 10px;">
                                    <b style="color: #3366FF;">PaperName :</b>
                                </div>
                                &nbsp;
                            <div style="float: right; margin-right: 10px;">
                                <asp:Label ID="lblPaperName" runat="server" Text=""></asp:Label>
                            </div>
                            </div>
                            <br />
                            <br />
                            <div style="float: left; margin-left: 10px;">
                                <div style="float: left; margin-left: 10px;">
                                    <b style="color: #3366FF;">PaperDate :</b>
                                </div>
                                &nbsp;
                            <div style="float: right; margin-right: 10px;">
                                <asp:Label ID="lblPaperDate" runat="server" Text=""></asp:Label>
                            </div>
                            </div>
                            <br />
                            <br />
                            <div style="float: left; margin-left: 10px;">
                                <div style="float: left; margin-left: 10px;">
                                    <b style="color: #3366FF;">IMEI/DeviceID :</b>
                                </div>
                                &nbsp;
                            <div style="float: right; margin-right: 100px;">
                                <asp:Label ID="lblIMEI" runat="server" Text=""></asp:Label>
                            </div>
                            </div>
                            <div style="float: right; margin-right: 200px;">
                                <div style="float: left; margin-left: 10px;">
                                    <b style="color: #3366FF;">StartTime :</b>
                                </div>
                                &nbsp;
                            <div style="float: right; margin-right: 10px;">
                                <asp:Label ID="lblStartTime" runat="server" Text=""></asp:Label>
                            </div>
                                <br />
                                <div style="float: left; margin-left: 10px;">
                                    <b style="color: #3366FF;">EndTime :</b>
                                </div>
                                &nbsp;
                            <div style="float: right; margin-right: 10px;">
                                <asp:Label ID="lblEndTime" runat="server" Text=""></asp:Label>
                            </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <div style="float: left; margin-left: 10px;">
                                <div style="float: left; margin-left: 10px;">
                                    <b style="color: #3366FF;">Percentage :</b>
                                </div>
                                &nbsp;
                            <div style="float: right; margin-right: 100px;">
                                <asp:Label ID="lblPercentage" runat="server" Text=""></asp:Label>
                            </div>
                            </div>
                            <div style="float: right; margin-right: 200px;">
                                <div style="float: left; margin-left: 10px;">
                                    <b style="color: #3366FF;">Result :</b>
                                </div>
                                &nbsp;
                            <div style="float: right; margin-right: 10px;">
                                <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                            </div>
                            </div>
                            <br />
                            <br />
                            <div align="center">
                                <asp:Button ID="btnClose" CssClass="btnShow" runat="server" Text="Back" PostBackUrl="~/SubAdmin/StudentScoreReport.aspx"
                                    OnClick="btnClose_Click" />
                            </div>
                        </asp:Panel>
                    </asp:View>
                </asp:MultiView>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnExportExcel" />
                <asp:PostBackTrigger ControlID="ddlExamName" />
                <asp:PostBackTrigger ControlID="btnGetData" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
