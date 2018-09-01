<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InstructionControl.ascx.cs"
    Inherits="InstructionControl" %>
<div style="width: 100%;">
    <table style="width: 100%; height: 100%" cellspacing="7px" bgcolor="White">
        <tr bgcolor="#952500">
            <td colspan="2" align="center">
                <span style="font: bold 18px/22px georgia; color: #FFFFCC;">Instructions before starting
                    Test </span>
            </td>
        </tr>
        <tr>
            <td class="tdInstruction">
                Test:
            </td>
            <td class="tdInstruction">
                <asp:Label ID="lblExnm" runat="server" Text="" />
            </td>
        </tr>
        <tr>
            <td class="tdInstruction">
                Number of Questions:
            </td>
            <td>
                <asp:Label ID="lblQnoI" runat="server" Text="" />
            </td>
        </tr>
        <tr>
            <td class="tdInstruction">
                Time:
            </td>
            <td class="tdInstruction">
                <asp:Label ID="lblTime1" runat="server" Text="" />
            </td>
        </tr>
        <tr>
            <td class="tdInstruction">
                Instructions:
            </td>
            <td class="tdInstruction">
                1. The question paper consists of Basic Type questions i.e. Each question has Five
                choices (A), (B), (C), (D) and (E) out of which ONLY ONE is correct.
                <br />
                2. To mark your answer for the question, first select the option and press on Submit
                Answer button to submit your answer.<br />
                3. To finish exam before timeout press on Finish Exam button either exam will be
                finshed automatically after specified time duration.
            </td>
        </tr>
    </table>
</div>
