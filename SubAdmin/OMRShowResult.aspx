<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OMRShowResult.aspx.cs" Inherits="SubAdmin_OMRShowResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    </style>
    <form id="form1" runat="server">
        <div class="divBorder">

            <div class="divBorder2">
                <span style="margin-top: 8px;"> OMRSHEET SCAN RESULT DETAILS</span>
            </div>

            <div style="width: 75%;">
                <div style="width: 66%; float: left;">
                    <div style="float: left; margin-left: 4px; margin-top: 20px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">
                        <div>
                            <asp:Label ID="lblIHMob" runat="server" Text="Enter Institute Head Number" Font-Bold="true"></asp:Label>
                        </div>
                    </div>
                    <div style="float: left; margin-left: 4px; margin-top: 20px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">:</div>
                    <div style="float: left; margin-left: 4px; margin-top: 10px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">
                        <div>
                            <asp:TextBox ID="txtIHMobile" runat="server" CssClass="dap_text_box" MaxLength="10" placeholder="Enter Institute Head Mobile" Width="200px"></asp:TextBox>
                        </div>
                    </div>
                    <div style="float: left; margin-left: 10px; margin-top: 20px;">
                        <div>
                            <asp:Button ID="btnGetTest" runat="server" Text="GET_TEST" ForeColor="Maroon" BackColor="GreenYellow" Font-Names="Consolas" Font-Size="Medium" Font-Bold="true" OnClick="btnGetTest_Click" />
                        </div>
                    </div>

                </div>

                <div style="width: 68%; float: left; margin-top: 14px;">
                    <div style="float: left; margin-left: 4px; margin-top: 10px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">
                        <div>
                            <asp:Label ID="lblSelectTest" runat="server" Text="Select Test"></asp:Label>
                        </div>
                    </div>
                    <div style="float: left; margin-left: 150px; margin-top: 10px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">
                        <div>
                            :
                        </div>
                    </div>
                    <div style="float: left; margin-left: 5px; margin-top: 5px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">
                        <div>
                            <asp:DropDownList ID="ddlSelectTest" runat="server" CssClass="dap_drop_box">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>


                </div>

                <div style="width: 68%; float: left; margin-top: 14px;">
                    <div style="float: left; margin-left: 4px; margin-top: 10px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">
                        <div>
                            <asp:Label ID="lblRollno" runat="server" Text="Enter Roll Number"></asp:Label>
                        </div>
                    </div>
                    <div style="float: left; margin-left: 90px; margin-top: 10px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">
                        <div>
                            :
                        </div>
                    </div>
                    <div style="float: left; margin-left: 5px; margin-top: 5px; font-family: Tahoma; font-size: 16px; color: blueviolet; font-weight: bold;">
                        <div>
                            <asp:TextBox ID="txtRollNo" runat="server" placeholder="Enter Roll Number" MaxLength="10" CssClass="dap_text_box" Width="200px"></asp:TextBox>
                        </div>
                    </div>

                </div>

                <div style="width: 68%; float: left; margin-top: 14px;margin-bottom:50px;">
                    <div>
                        <asp:Button ID="btnGetData" runat="server" Text="Get Result" CssClass="button" OnClick="btnGetData_Click" />&nbsp;
                        <asp:Button ID="btnBack" CssClass="button" runat="server" Text="Go Back" PostBackUrl="~/UserLogin.aspx" />
                    </div>

                </div>

            </div>
           
            <div style="width: 100%;" align="Center">
                <div>
                    <asp:GridView ID="gvShowResult" CssClass="gridview" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvShowResult_PageIndexChanging" PageSize="20" runat="server">
                        <Columns>

                            <asp:BoundField HeaderText="ID" DataField="ID" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="ROLL_NUMBER" DataField="RollNo" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="INSTITUTE_HEAD" DataField="TeacherORDefaultMobNo" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="TEST_ID" DataField="TestId" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="DATE OF SUBMISSION" DataField="InsertDate" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="CORRECT_ANSWERS" DataField="CorrectAnswersCount" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="INCORRECT_ANSWERS" DataField="InCorrectAnswersCount" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="NOT_ANSWERED_QUESTIONS" DataField="NotAnsweredQuetionsCount" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="TOTAL_MARKS" DataField="TotalMarks" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>

                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
