<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userinstruction.ascx.cs"
    Inherits="userControl_userinstruction" %>
<table style="width: 70%;" cellspacing="1px">
    <tr>
        <td colspan="4" style="text-align: left;">
            <%--<div id="divInstruction" runat="server" class="displayDiv">
            </div>--%>
            <span>
                <asp:Label ID="lblInstrNo" runat="server" Font-Bold="True" Font-Size="Medium" Text="*"></asp:Label>
                &nbsp;
                <asp:Label ID="lblInstruction" runat="server" Font-Size="Medium" ForeColor="Green"></asp:Label>
            </span>
        </td>
    </tr>

</table>

