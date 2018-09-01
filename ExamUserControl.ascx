<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExamUserControl.ascx.cs"
    Inherits="ExamUserControl" %>
<div style="width: 100%;">
    <table style="width: 100%; height: 100%" cellspacing="7px" bgcolor="White">
        <tr bgcolor="#FFFFCC">
            <td>
                <asp:Label ID="lblqn" runat="server" Font-Size="Medium" Text="Q.No. :" ForeColor="#00CC00"
                    Font-Bold="True"></asp:Label>
                <asp:Label ID="lblQNo" runat="server" Font-Size="Medium" Text="Q" ForeColor="#00CC00"
                    Font-Bold="True"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblQuestion_id" runat="server" Font-Bold="True" Font-Size="Small"
                    ForeColor="#FFFFCC" Text="Question_id" Visible="true"></asp:Label>
                <asp:Label ID="lbltypeQues" runat="server" Font-Size="Medium" Text="Type of Ques"
                    ForeColor="#CC3300" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblCorrectAns" runat="server" Font-Size="Small" Text="sdff" ForeColor="#FFFFCC"
                    Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbllevel" runat="server" Font-Size="Medium" ForeColor="#CC3300" Text="Level"></asp:Label>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblpassage1" runat="server" Text="Passage" Font-Size="Medium" ForeColor="#CC3300"></asp:Label>
                &nbsp;
                <asp:Label ID="lblPassage" runat="server" Font-Size="Medium" Text="Passage" Width="300px"></asp:Label>
                <asp:Image ID="imgPassage" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="Label7" runat="server" Text="Question" Font-Size="Medium" Font-Names="Tahoma" ForeColor="#CC3300" style="vertical-align:text-top;"></asp:Label>
                &nbsp;
                <asp:Label ID="lblQuestion" runat="server" Font-Size="Medium" Text="Question" Width="400px" style="font-family:Tahoma;font-size:15px;color:Black;"></asp:Label>
                <asp:Image ID="imgQues" runat="server" />
                <br />
                <asp:Label ID="lblQuestionwithImage" runat="server" Font-Size="Small" Text="QuestionwithImage"></asp:Label>
                <asp:Image ID="imgQuesImage" runat="server" />
            </td>
        </tr>
       
    </table>
    
    <hr />
    
    <table style="width: 100%; height: 100%" cellspacing="7px" bgcolor="White">
        <tr>
            <td>
                <asp:Label ID="lblA" runat="server" Text="A" Font-Size="Medium" ForeColor="#CC3300"></asp:Label>
                &nbsp;
                <asp:Label ID="lblOptA" runat="server"  Text="Option A" style="font-size:medium;"></asp:Label>
                <asp:Image ID="imgoptA" ImageUrl="" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblP" runat="server" Text="P" Font-Size="Medium" ForeColor="#CC3300"></asp:Label>
                &nbsp;
                <asp:Label ID="lblOptP" runat="server"  Text="OptionP" style="font-size:medium;"></asp:Label>
                <asp:Image ID="imgoptP" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblB" runat="server" Text="B" Font-Size="Medium" ForeColor="#CC3300"></asp:Label>
                &nbsp;
                <asp:Label ID="lblOptB" runat="server"  Text="OptionB" style="font-size:medium;"></asp:Label>
                <asp:Image ID="imgoptB" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblQ" runat="server" Text="Q" Font-Size="Medium" ForeColor="#CC3300"></asp:Label>
                &nbsp;
                <asp:Label ID="lblOptQ" runat="server"  Text="OptionQ" style="font-size:medium;"></asp:Label>
                <asp:Image ID="imgoptQ" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblC" runat="server" Text="C" Font-Size="Medium" ForeColor="#CC3300"></asp:Label>
                &nbsp;
                <asp:Label ID="lblOptC" runat="server"  Text="OptionC" style="font-size:medium;"></asp:Label>
                <asp:Image ID="imgoptC" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblR" runat="server" Text="R" Font-Size="Medium" ForeColor="#CC3300"></asp:Label>
                &nbsp;
                <asp:Label ID="lblOptR" runat="server"  Text="OptionR" style="font-size:medium;"></asp:Label>
                <asp:Image ID="imgoptR" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblD" runat="server" Text="D" Font-Size="Medium" ForeColor="#CC3300"></asp:Label>
                &nbsp;
                <asp:Label ID="lblOptD" runat="server"  Text="OptionD" style="font-size:medium;"></asp:Label>
                <asp:Image ID="imgoptD" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblS" runat="server" Text="S" Font-Size="Medium" ForeColor="#CC3300"></asp:Label>
                &nbsp;
                <asp:Label ID="lblOptS" runat="server"  Text="OptionS" style="font-size:medium;"></asp:Label>
                <asp:Image ID="imgoptS" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblE" runat="server" Text="E" Font-Size="Medium" ForeColor="#CC3300"></asp:Label>
                &nbsp;
                <asp:Label ID="lblOptE" runat="server"  Text="OptionE" style="font-size:medium;"></asp:Label>
                <asp:Image ID="imgoptE" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblT" runat="server" Text="T" Font-Size="Medium" ForeColor="#CC3300"></asp:Label>
                &nbsp;
                <asp:Label ID="lblOptT" runat="server"  Text="OptionT" style="font-size:medium;"></asp:Label>
                <asp:Image ID="imgoptT" runat="server" />
            </td>
        </tr>
        <%--<tr>
                <td colspan="3">
                    <asp:Label ID="lblH" runat="server" Text="Hint" Font-Size="Small" ForeColor="#CC3300"></asp:Label>
                    &nbsp;
                    <asp:Label ID="txtHint" runat="server"></asp:Label>
                    <asp:Image ID="imgHint" runat="server" />
                </td>
            </tr>--%>
    </table>
</div>
