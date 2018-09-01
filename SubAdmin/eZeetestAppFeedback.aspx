<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eZeetestAppFeedback.aspx.cs" Inherits="SubAdmin_eZeetestAppFeedback" Title="eZeeTest:Feedback" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <script type="text/javascript" src="../resources/JScript/jquery-1.11.1.js"></script>
    <script type="text/javascript" src="../resources/JScript/jquery-ui.js"></script>
    <link href="../resources/stylesheet/jquery-ui.theme.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript">
        $(document).ready(function () {

            $("#<%=txtFromDate.ClientID%>").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'yy-mm-dd'
            });

            $('#<%=txtToDate.ClientID%>').datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'yy-mm-dd'
            });

            $("#<%=btnGetData.ClientID%>").click(function () {

                var val1 = $('input[name=rdolstReport]:checked').val();
                var val2 = $('#ddlDistrict option:selected').val();

                if (val1 == '0') {
                    if (val2 == '0') {
                        alert('Please Select District.!!!');
                        return false;
                    }

                }

            });

        });
    </script>


</head>
<body>

    <style type="text/css">
        .divBorder
        {
            width: 99%;
            height: 100%;
            border: 5px rgb(62, 162, 97) solid;
            -webkit-box-sizing: inherit;
            -moz-box-sizing: inherit;
            box-sizing: inherit;
            background: white;
            color: rgb(25,25,25);
            font-size: inherit;
            font-weight: inherit;
            font-family: inherit;
            font-style: inherit;
            text-decoration: inherit;
            text-align: center;
            line-height: 1.3em;
            -moz-box-shadow: 0px 0px 40px 8px rgb(128,128,128);
            -webkit-box-shadow: 0px 0px 40px 8px rgb(128,128,128);
            box-shadow: 0px 0px 40px 8px rgb(128,128,128);
        }

        .divBorder2
        {
            -moz-border-radius: 0px 0px 0px 0px;
            -webkit-border-radius: 0px 0px 0px 0px;
            border: 2px solid #1aad30;
            width: 99.8%;
            height: 25px;
            font-family: 'Comic Sans MS';
            font-size: 18px;
            font-weight: bold;
            background-color: green;
            color: white;
        }

        .button
        {
            border-top: 1px solid #97e9f7;
            background: #e6e315;
            background: -webkit-gradient(linear, left top, left bottom, from(#10e887), to(#e6e315));
            background: -webkit-linear-gradient(top, #10e887, #e6e315);
            background: -moz-linear-gradient(top, #10e887, #e6e315);
            background: -ms-linear-gradient(top, #10e887, #e6e315);
            background: -o-linear-gradient(top, #10e887, #e6e315);
            padding: 7px 14px;
            -webkit-border-radius: 9px;
            -moz-border-radius: 9px;
            border-radius: 9px;
            -webkit-box-shadow: rgba(0,0,0,1) 0 1px 0;
            -moz-box-shadow: rgba(0,0,0,1) 0 1px 0;
            box-shadow: rgba(0,0,0,1) 0 1px 0;
            text-shadow: rgba(0,0,0,.4) 0 1px 0;
            color: #2c782f;
            font-size: 19px;
            font-family: Consolas;
            text-decoration: none;
            vertical-align: middle;
        }

            .button:hover
            {
                border-top-color: #458f1b;
                background: #458f1b;
                color: #bacf1b;
                cursor: pointer;
            }

            .button:active
            {
                border-top-color: #f27516;
                background: #f27516;
            }

        .dap_text_box
        { /*EBEAC8*/
            background: #EBEAC8;
            color: #804811;
            border: 2px solid #12F00E;
            border-radius: 4px;
            font-size: 15px;
            height: 18px;
            line-height: 22px;
            width: 213px;
            padding: 8px;
            box-shadow: 2px 1px 2px #E7DAED;
            -webkit-box-shadow: 2px 1px 2px #E7DAED;
            -moz-box-shadow: 2px 1px 2px #E7DAED;
        }

        .dap_drop_box
        {
            width: 219px;
            padding: 8px;
            border: 2px solid #93f35c;
            border-radius: 6px;
            font-family: Consolas;
            font-size: 15px;
            background-color: #EBEAC8;
        }

        .checkbx
        {
            float: left;
        }

        .textbx
        {
            margin-top: 2px;
        }

        .divLabel
        {
            float: left;
            margin-left: 150px;
        }

        .divTextBox
        {
            float: right;
            margin-right: 390px;
        }

        .gridview
        {
            background-color: #f3f090;
            margin: 5px 0 10px 0;
            border: 2px solid #05c705;
            border-collapse: collapse;
            font-family: Calibri;
        }

            .gridview td
            {
                padding: 2px;
                border: 1px solid black;
                color: #905011;
                font-size: 14px;
            }

                .gridview td:hover
                {
                    padding: 2px;
                    border: solid 1px #c1c1c1;
                    font-size: 15px;
                    background: #b6ff00;
                }

            .gridview th
            {
                padding: 6px 3px;
                color: #905011;
                background: #6cf66c;
                border: 1px solid black;
                font-size: 18px;
            }

            .gridview .gridview_alter
            {
                background: #E7E7E7;
            }

            .gridview .gridview_pager
            {
                background: #05c705;
            }

                .gridview .gridview_pager table
                {
                    margin: 5px 0;
                }

                .gridview .gridview_pager td
                {
                    border-width: 0;
                    padding: 0 6px;
                    border-left: 1px solid #905011;
                    font-weight: bold;
                    color: #fff;
                    line-height: 13px;
                }

                .gridview .gridview_pager a
                {
                    color: #666;
                    text-decoration: none;
                }

                    .gridview .gridview_pager a:hover
                    {
                        color: #b6ff00;
                        text-decoration: none;
                    }

        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup
        {
            background-color: #f27516;
            border-width: thin;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: auto;
            position: absolute;
            top: 40%;
            left: 40%;
            border-radius:4px;
        }
    </style>




    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="divBorder">

            <div class="divBorder2">
                <span style="margin-top: 8px;">GET FEEDBACK DETAILS </span>
            </div>

            <div style="width: 75%;">
                <div style="width: 66%; float: left;">
                    <div style="float: left; margin-left: 4px; margin-top: 20px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">
                        <div>
                            <asp:Label ID="lblFromDate" runat="server" Text="Select From Date" Font-Bold="true"></asp:Label>
                        </div>
                    </div>
                    <div style="float: left; margin-left: 74px; margin-top: 20px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">:</div>
                    <div style="float: left; margin-left: 4px; margin-top: 10px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">
                        <div>
                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="dap_text_box" placeholder="Select From Date" Width="200px"></asp:TextBox>
                        </div>
                    </div>
                    <div style="float: left; margin-left: 10px; margin-top: 20px;">
                        <div>
                            <asp:Button ID="btnGetTest" runat="server" Text="GET_TEST" ForeColor="Maroon" BackColor="GreenYellow" Font-Names="Consolas" Font-Size="Medium" Font-Bold="true" Visible="false" OnClick="btnGetTest_Click" />
                        </div>
                    </div>
                </div>

                <div style="width: 68%; float: left; margin-top: 14px;">
                    <div style="float: left; margin-left: 4px; margin-top: 10px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">
                        <div>
                            <asp:Label ID="lblToDate" runat="server" Text="Select To Date"></asp:Label>
                        </div>
                    </div>
                    <div style="float: left; margin-left: 94px; margin-top: 10px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">
                        <div>
                            :
                        </div>
                    </div>
                    <div style="float: left; margin-left: 5px; margin-top: 5px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">
                        <div>
                            <asp:TextBox ID="txtToDate" runat="server" placeholder="Select To Date" CssClass="dap_text_box" Width="200px"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div style="width: 68%; float: left; margin-top: 14px;">
                    <div style="float: left; margin-left: 4px; margin-top: 10px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">
                        <div>
                            <asp:Label ID="lblSelectFeedback" runat="server" Text="Select Type of Feedback"></asp:Label>
                        </div>
                    </div>
                    <div style="float: left; margin-left: 15px; margin-top: 10px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">
                        <div>
                            :
                        </div>
                    </div>
                    <div style="float: left; margin-left: 5px; margin-top: 5px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">
                        <div>
                            <asp:DropDownList ID="ddlSelectFeedback" runat="server" CssClass="dap_drop_box">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">Demand</asp:ListItem>
                                <asp:ListItem Value="2">Complaint</asp:ListItem>
                                <asp:ListItem Value="3">Suggetion</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div style="width: 68%; float: left; margin-top: 14px; margin-bottom: 50px;">
                    <div>
                        <asp:Button ID="btnGetData" runat="server" Text="Get Result" CssClass="button" OnClick="btnGetData_Click" />&nbsp;
                        <asp:Button ID="btnBack" CssClass="button" runat="server" Text="Go Back" PostBackUrl="~/CreateTest/createtest.aspx" />
                        <asp:Button ID="Button1" CssClass="button" runat="server" Text="POPUP" OnClientClick="return false;" Visible="false" />
                    </div>
                </div>
            </div>

            <div style="width: 100%;" align="Center">
                <div>
                    <asp:GridView ID="gvShowResult" CssClass="gridview" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" OnPageIndexChanging="gvShowResult_PageIndexChanging" runat="server">
                        <Columns>

                            <asp:BoundField HeaderText="FIRST_NAME" DataField="firstName" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="LAST_NAME" DataField="lastName" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="MOBILE_NUMBER" DataField="userMobNo" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="IMEI_NUMBER" DataField="imei" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="FEEDBACK_TYPE" DataField="typeOfFeedback" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="FEEDBCAK_DETAILS" DataField="feedbackContent" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="FEEDBACK_DATE" DataField="feedbackDate" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                        </Columns>

                    </asp:GridView>
                </div>
            </div>
        </div>
        <cc1:ModalPopupExtender ID="mpe1" runat="server" TargetControlID="Button1" BackgroundCssClass="modalBackground" OkControlID="btnOK" PopupControlID="Panel1"></cc1:ModalPopupExtender>
        <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none">
            <div style="margin-top: 6px; color: white; font-family: Constantia; font-style: italic; font-size: medium;" align="Center">NO DATA FOUND FOR THIS COMBINATION.!!!</div>
            <div style="float: right; margin-right:10px;margin-top:6px;">
                <asp:Button ID="btnOK" runat="server" Text="OK" Width="100px" />
            </div>
        </asp:Panel>
    </form>
</body>
</html>
