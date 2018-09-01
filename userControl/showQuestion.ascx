<%@ Control Language="C#" AutoEventWireup="true" CodeFile="showQuestion.ascx.cs"
    Inherits="userControl_showQuestion" %>
<link href="../resources/stylesheet/styleExamControl.css" rel="stylesheet" type="text/css" />

<script src="../html/jquery-ui.js" type="text/javascript"></script>
<link href="../html/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../html/jquery-ui.theme.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../html/jquery-2.1.4.js"></script>


<style type="text/css">
    @media print
    {
        .hidewhileprinting
        {
            display: none;
        }
    }
</style>

<style type="text/css">
    .divremovespace
    {
        margin-top: -25px;
    }
</style>
<script type="text/javascript">
    window.print();
</script>

<div id="td12" class="divremovespace">
    <table style="width: 70%;" cellspacing="1px">
        <tr>
            <td colspan="3">
                <div id="divPassage" runat="server" class="displayDiv">
                </div>
                <br />
                <asp:LinkButton ID="Passage" runat="server" class="hidewhileprinting" Text="Insert Blank Line"
                    OnClientClick="return add(this)" />

                <asp:LinkButton ID="PassageDel" runat="server" class="hidewhileprinting" Text="Delete Blank Line"
                    OnClientClick="return del(this)" />

                <asp:Label ID="lblqn" runat="server" Font-Bold="true" Font-Size="Small" Text="Q.No. :"></asp:Label>
                <asp:Label ID="lblpassage1" runat="server" Text="Passage" Font-Size="Small" />
                &nbsp;
            <asp:Label ID="lblPassage" runat="server" Font-Size="Small" Width="300px"></asp:Label>
                <asp:Image ID="imgPassage" runat="server" />
            </td>
        </tr>

        <tr>
            <td colspan="3">
                <div id="divQuestion" runat="server" class="displayDiv">
                </div>
                <%--<asp:LinkButton ID="Question" runat="server" class="hidewhileprinting" Text="Insert Blank Line"
                    OnClientClick="return add(this)" />--%>

                <%--<asp:LinkButton ID="QuestionDel" runat="server" class="hidewhileprinting" Text="Delete Blank Line"
                    OnClientClick="return del(this)" />--%>

                <asp:Label ID="lblQuestion" runat="server" Font-Size="Small" Text="Question" Width="300px"></asp:Label>
                <asp:Image ID="imgQues" runat="server" />

                <br />
                <asp:Label ID="lblQuestionwithImage" runat="server" Font-Size="Small" Text="QuestionwithImage"></asp:Label>
                <asp:Image ID="imgQuesImage" runat="server" />
            </td>
        </tr>

        <tr>
            <td colspan="3">
                <div id="divOptionA" runat="server" class="displayDiv">
                </div>
                <%--<asp:LinkButton ID="OptionA" runat="server" class="hidewhileprinting" Text="Insert Blank Line"
                    OnClientClick="return add(this)" />--%>

                <%--<asp:LinkButton ID="OptionADel" runat="server" class="hidewhileprinting" Text="Delete Blank Line"
                    OnClientClick="return del(this)" />--%>

                <asp:Label ID="lblA" runat="server" Text="A)" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptA" runat="server" Font-Size="Small" Text="Option A"></asp:Label>
                <asp:Image ID="imgoptA" runat="server" />

                &nbsp;
                <asp:Label ID="lblB" runat="server" Text="B)" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptB" runat="server" Font-Size="Small" Text="OptionB"></asp:Label>
                <asp:Image ID="imgoptB" runat="server" />
                <br /><%--&nbsp;--%>
                <asp:Label ID="lblC" runat="server" Text="C)" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptC" runat="server" Font-Size="Small" Text="OptionC"></asp:Label>
                <asp:Image ID="imgoptC" runat="server" />
                &nbsp;
                 <asp:Label ID="lblD" runat="server" Text="D)" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptD" runat="server" Font-Size="Small" Text="OptionD"></asp:Label>
                <asp:Image ID="imgoptD" runat="server" />
                <br /><%--&nbsp;--%>
                <asp:Label ID="lblE" runat="server" Text="E)" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptE" runat="server" Font-Size="Small" Text="OptionE"></asp:Label>
                <asp:Image ID="imgoptE" runat="server" />

                &nbsp;&nbsp;
            <asp:Label ID="lblP" runat="server" Text="P" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptP" runat="server" Font-Size="Small" Text="OptionP"></asp:Label>
                <asp:Image ID="imgoptP" runat="server" />
                &nbsp;&nbsp;
            <asp:Label ID="lblQ" runat="server" Text="Q" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptQ" runat="server" Font-Size="Small" Text="OptionQ"></asp:Label>
                <asp:Image ID="imgoptQ" runat="server" />
                &nbsp;&nbsp;
            <asp:Label ID="lblR" runat="server" Text="R" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptR" runat="server" Font-Size="Small" Text="OptionR"></asp:Label>
                <asp:Image ID="imgoptR" runat="server" />
                &nbsp;&nbsp;
            <asp:Label ID="lblS" runat="server" Text="S" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptS" runat="server" Font-Size="Small" Text="OptionS"></asp:Label>
                <asp:Image ID="imgoptS" runat="server" />
                &nbsp;&nbsp;
            <asp:Label ID="lblT" runat="server" Text="T" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptT" runat="server" Font-Size="Small" Text="OptionT"></asp:Label>
                <asp:Image ID="imgoptT" runat="server" />

            </td>
        </tr>
        <%--<tr>
            <td colspan="3">
                <div id="divOptionB" runat="server" class="displayDiv">
                </div>
                 <asp:LinkButton ID="OptionB" runat="server" class="hidewhileprinting" Text="Insert Blank Line"
                    OnClientClick="return add(this)" />

                <asp:LinkButton ID="OptionBDel" runat="server" class="hidewhileprinting" Text="Delete Blank Line"
                    OnClientClick="return del(this)" />

                <asp:Label ID="lblB" runat="server" Text="B)" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptB" runat="server" Font-Size="Small" Text="OptionB"></asp:Label>
                <asp:Image ID="imgoptB" runat="server" />
                &nbsp;&nbsp;
            <asp:Label ID="lblQ" runat="server" Text="Q" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptQ" runat="server" Font-Size="Small" Text="OptionQ"></asp:Label>
                <asp:Image ID="imgoptQ" runat="server" />
            </td>
        </tr>--%>
        <%--<tr>
            <td colspan="3">
                <div id="divOptionC" runat="server" class="displayDiv">
                </div>
                 <asp:LinkButton ID="OptionC" runat="server" class="hidewhileprinting" Text="Insert Blank Line"
                    OnClientClick="return add(this)" />
                <asp:LinkButton ID="OptionCDel" runat="server" class="hidewhileprinting" Text="Delete Blank Line"
                    OnClientClick="return del(this)" />

                <asp:Label ID="lblC" runat="server" Text="C)" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptC" runat="server" Font-Size="Small" Text="OptionC"></asp:Label>
                <asp:Image ID="imgoptC" runat="server" />
                &nbsp;&nbsp;
            <asp:Label ID="lblR" runat="server" Text="R" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptR" runat="server" Font-Size="Small" Text="OptionR"></asp:Label>
                <asp:Image ID="imgoptR" runat="server" />
            </td>
        </tr>--%>
        <%--<tr>
            <td colspan="3">
                <div id="divOptionD" runat="server" class="displayDiv">
                </div>
                <asp:LinkButton ID="OptionD" runat="server" class="hidewhileprinting" Text="Insert Blank Line"
                    OnClientClick="return add(this)" />
                <asp:LinkButton ID="OptionDDel" runat="server" class="hidewhileprinting" Text="Delete Blank Line"
                    OnClientClick="return del(this)" />
                <asp:Label ID="lblD" runat="server" Text="D)" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptD" runat="server" Font-Size="Small" Text="OptionD"></asp:Label>
                <asp:Image ID="imgoptD" runat="server" />
                &nbsp;&nbsp;
            <asp:Label ID="lblS" runat="server" Text="S" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptS" runat="server" Font-Size="Small" Text="OptionS"></asp:Label>
                <asp:Image ID="imgoptS" runat="server" />
            </td>
        </tr>--%>
        <%--<tr>
            <td colspan="3">
                <div id="divOptionE" runat="server" class="displayDiv">
                </div>
                 <asp:LinkButton ID="OptionE" runat="server" class="hidewhileprinting" Text="Insert Blank Line"
                    OnClientClick="return add(this)" />
                <asp:LinkButton ID="OptionEDel" runat="server" class="hidewhileprinting" Text="Delete Blank Line"
                    OnClientClick="return del(this)" />

                <asp:Label ID="lblE" runat="server" Text="E)" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptE" runat="server" Font-Size="Small" Text="OptionE"></asp:Label>
                <asp:Image ID="imgoptE" runat="server" />
                &nbsp;&nbsp;
            <asp:Label ID="lblT" runat="server" Text="T" Font-Size="Small"></asp:Label>
                &nbsp;
            <asp:Label ID="lblOptT" runat="server" Font-Size="Small" Text="OptionT"></asp:Label>
                <asp:Image ID="imgoptT" runat="server" />
            </td>
        </tr>--%>
    </table>
</div>

