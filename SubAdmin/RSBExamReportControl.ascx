<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RSBExamReportControl.ascx.cs" Inherits="SubAdmin_ExamReportControl" %>

<link href="resources/stylesheet/styleExamControl.css" rel="stylesheet" type="text/css" />

<div style="width: 100%;">
    <center>
        <div class="subColorStip">
        </div>
        <div class="report_top_row02" id="reportTable">
            <div class="table02">
                <table cellspacing="0" cellpadding="0" class="table_section" style="border: thin groove #808080">
                    <tbody>
                        <tr>
                            <td align="center">
                                Total Questions No.<br />
                                <input disabled="disabled" class="txtReportText" type="text" id="txtTotalQues" value=""
                                    name="txtTotalQues" />
                            </td>
                            <td align="center">
                                Attempted Questions<br />
                                <input disabled="disabled" class="txtReportText" type="text" id="txtAttempt" value=""
                                    name="txtAttempt" />
                            </td>
                            <td align="center">
                                Correct Questions<br />
                                <input disabled="disabled" class="txtReportText" type="text" id="txtCorrect" value=""
                                    name="txtCorrect" />
                            </td>
                            <td align="center">
                                Incorrect Questions<br />
                                <input disabled="disabled" class="txtReportText" type="text" id="txtIncorrect" value=""
                                    name="txtIncorrect" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div><br /><br /><br /><br />
        <asp:Button ID="btnBackToTestHome" runat="server" Text="BackToHome" PostBackUrl="~/SubAdmin/RSBTestHome.aspx" CssClass="btn"  /> 
    </center>
</div>
