<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShowTheoryQuestion.ascx.cs" Inherits="userControl_ShowTheoryQuestion" %>
<link href="../resources/stylesheet/styleExamControl.css" rel="stylesheet" type="text/css" />
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
        margin-top: -20px;
    }
</style>
<script type="text/javascript" language="javascript">
    window.print();
</script>

<div id="td12" class="divremovespace">
    <table style="width: 70%;" cellspacing="1px">

        <%--for Heading--%>
        <%--<tr>
            <td colspan="3" style="text-align: left;">

                <div id="divHeading" runat="server" class="displayDiv">
                </div>
                <asp:LinkButton ID="lbHeading" runat="server" class="hidewhileprinting" Text="Insert Blank Line"
                    OnClientClick="return add(this)" />

                <asp:LinkButton ID="lbHeadingDel" runat="server" class="hidewhileprinting" Text="Delete Blank Line"
                    OnClientClick="return del(this)" />

                <asp:Label ID="lblHeading" runat="server" Font-Size="Small" Font-Bold="false" ForeColor="Red" Width="550px"></asp:Label>
            </td>
            <td style="text-align: right;">
                <asp:Label ID="lblMarks" runat="server" Font-Size="Small" Font-Bold="false" Width="25px"></asp:Label>
            </td>
        </tr>--%>

        <%--for Question--%>

        <tr style="vertical-align: top">

            <td colspan="3" style="vertical-align: top;"><%--&nbsp;&nbsp;&nbsp;&nbsp;--%>
                <div id="divQuestion" runat="server" class="displayDiv"
                    style="vertical-align: top">
                </div>
                <asp:LinkButton ID="Question" runat="server" class="hidewhileprinting" Text="Insert Blank Line"
                    OnClientClick="return add(this)" />

                <asp:LinkButton ID="QuestionDel" runat="server" class="hidewhileprinting" Text="Delete Blank Line"
                    OnClientClick="return del(this)" />

                <asp:Label ID="lblqn" runat="server" Font-Bold="false" Font-Size="Small" Text=""></asp:Label>
                <asp:Label ID="lblQuestion" runat="server" Font-Size="Small" Text="Question" style="width:auto" ></asp:Label> <%--Width="540px"--%>
                <asp:Image ID="imgQues" runat="server" />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblQuestionwithImage" runat="server" Font-Size="Small" Text="QuestionwithImage" style="width:auto"></asp:Label>
                <asp:Image ID="imgQuesImage" runat="server" />
            </td>
        </tr>

        <%--for Heading or--%>
        <%--<tr>
            <td>
                <div id="div2" runat="server" class="displayDiv">
                </div>
                <asp:LinkButton ID="lbHeading1" runat="server" class="hidewhileprinting" Text="Insert Blank Line"
                    OnClientClick="return add(this)" />

                <asp:LinkButton ID="lbHeadingDel1" runat="server" class="hidewhileprinting" Text="Delete Blank Line"
                    OnClientClick="return del(this)" />

                <asp:Label ID="lblHeading1" runat="server" Font-Size="Small" Width="575px"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMarks1" runat="server" Font-Size="Small" Width="25px"></asp:Label>
            </td>
        </tr>--%>
    </table>

</div>
