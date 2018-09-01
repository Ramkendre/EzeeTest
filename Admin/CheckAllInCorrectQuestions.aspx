<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout/AdminMaster.master"
    CodeFile="CheckAllInCorrectQuestions.aspx.cs" Inherits="Admin_CheckQuestions" Title="eZeeTest:Incorrect Questions" %>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div style="width:100%;font-family:Times New Roman" align="center">
            <table cellpadding="0" cellspacing="0" bgcolor="white" width="70%">
                <div style="width: 80%">
                    <table style="width: 91%" cellspacing="7px" bgcolor="white">
                        <tr bgcolor="#FFFFCC">
                            <td colspan="2" align="left">
                                <asp:Label ID="lblqn" runat="server" Font-Size="Large" Text="Q.No. :" ForeColor="#00CC00"
                                    Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblQNo" runat="server" Font-Size="Large" Text="Q" ForeColor="#00CC00"
                                    Font-Bold="True"></asp:Label>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:Label ID="lblQuestion_id" runat="server" Font-Bold="True" Font-Size="Medium"
                                    ForeColor="#009933" Text="Question_id" Visible="False"></asp:Label>
                            </td>
                            <td colspan="3" style="width: 84px; text-align: left;">
                                <asp:Label ID="lbltypeQues" runat="server" Font-Size="Medium" Text="Type of Ques"
                                    ForeColor="#CC3300" Font-Bold="True"></asp:Label>
                                &nbsp;
                            </td>
                            <td colspan="2" align="left">
                                <asp:Label ID="lblcount" runat="server" Font-Size="Medium" Text="count" ForeColor="#009933"
                                    Font-Bold="True"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblMasterID" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#009933"
                                    Text="Master ID :" Visible="true"></asp:Label>
                                <asp:Label ID="lblSno" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#009933"
                                    Text="SNO" Visible="False"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px">
                                <asp:Label ID="lblpassage1" runat="server" Text="Passage" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:Label ID="lblPassage" runat="server" Font-Size="Medium" Text="Passage"></asp:Label>
                                <asp:Image ID="imgPassage" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px">
                                <asp:Label ID="lblQues" runat="server" Text="Question" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:Label ID="lblQuestion" runat="server" Font-Size="Medium" Text="Question"></asp:Label>
                                <asp:Image ID="imgQues" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px">
                                <asp:Label ID="QuestionImage" runat="server" Text="QuestionImage" Font-Size="Large"
                                    ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:Label ID="lblQuestionwithImage" runat="server" Font-Size="Medium" Text="QuestionwithImage"></asp:Label>
                                <asp:Image ID="imgQuesImage" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblA" runat="server" Text="A" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptA" runat="server" Font-Size="Medium" Text="OptionA"></asp:Label>
                                <asp:Image ID="imgoptA" runat="server" />
                            </td>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblP" runat="server" Text="P" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptP" runat="server" Font-Size="Medium" Text="OptionP"></asp:Label>
                                <asp:Image ID="imgoptP" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblB" runat="server" Text="B" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptB" runat="server" Font-Size="Medium" Text="OptionB"></asp:Label>
                                <asp:Image ID="imgoptB" runat="server" />
                            </td>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblQ" runat="server" Text="Q" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptQ" runat="server" Font-Size="Medium" Text="OptionQ"></asp:Label>
                                <asp:Image ID="imgoptQ" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblC" runat="server" Text="C" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptC" runat="server" Font-Size="Medium" Text="OptionC"></asp:Label>
                                <asp:Image ID="imgoptC" runat="server" />
                            </td>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblR" runat="server" Text="R" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptR" runat="server" Font-Size="Medium" Text="OptionR"></asp:Label>
                                <asp:Image ID="imgoptR" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblD" runat="server" Text="D" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptD" runat="server" Font-Size="Medium" Text="OptionD"></asp:Label>
                                <asp:Image ID="imgoptD" runat="server" />
                            </td>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblS" runat="server" Text="S" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptS" runat="server" Font-Size="Medium" Text="OptionS"></asp:Label>
                                <asp:Image ID="imgoptS" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblE" runat="server" Text="E" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptE" runat="server" Font-Size="Medium" Text="OptionE"></asp:Label>
                                <asp:Image ID="imgoptE" runat="server" />
                            </td>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblT" runat="server" Text="T" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptT" runat="server" Font-Size="Medium" Text="OptionT"></asp:Label>
                                <asp:Image ID="imgoptT" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblH" runat="server" Text="Hint" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                <br />
                                <asp:DropDownList ID="ddlhint" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlhint_SelectedIndexChanged">
                                    <asp:ListItem Value="0">English</asp:ListItem>
                                    <asp:ListItem Value="1">Marathi</asp:ListItem>
                                    <asp:ListItem Value="3">MarathiMangal</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td colspan="4" align="left">
                                <asp:TextBox ID="txtHint" runat="server" Height="32px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                <asp:Image ID="imgHint" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center;" bgcolor="White">
                                <asp:Label ID="lblAns" runat="server" Text="Answer" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:RadioButtonList ID="rdoAnswerlist" runat="server" Font-Size="Medium" RepeatDirection="Horizontal"
                                    Visible="true">
                                    <asp:ListItem Value="0">A</asp:ListItem>
                                    <asp:ListItem Value="1">B</asp:ListItem>
                                    <asp:ListItem Value="2">C</asp:ListItem>
                                    <asp:ListItem Value="3">D</asp:ListItem>
                                    <asp:ListItem Value="4">E</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:TextBox ID="txtAns" runat="server" MaxLength="15" Visible="False" Width="158px"></asp:TextBox>
                                <asp:CheckBoxList ID="chkAnslist" runat="server" Font-Size="Medium" RepeatDirection="Horizontal"
                                    Visible="False">
                                    <asp:ListItem Value="0">A</asp:ListItem>
                                    <asp:ListItem Value="1">B</asp:ListItem>
                                    <asp:ListItem Value="2">C</asp:ListItem>
                                    <asp:ListItem Value="3">D</asp:ListItem>
                                    <asp:ListItem Value="4">E</asp:ListItem>
                                </asp:CheckBoxList>
                                <asp:Panel ID="pnlAnsMat" runat="server" Visible="false" Height="110px" Width="305px">
                                    <table>
                                        <tr>
                                            <td style="font-size: medium">
                                                A-
                                            </td>
                                            <td style="width: 300px; text-align: center;">
                                                <asp:CheckBoxList ID="ChkansMatA" runat="server" Font-Size="Medium" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="0">P</asp:ListItem>
                                                    <asp:ListItem Value="1">Q</asp:ListItem>
                                                    <asp:ListItem Value="2">R</asp:ListItem>
                                                    <asp:ListItem Value="3">S</asp:ListItem>
                                                    <asp:ListItem Value="4">T</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: medium" bgcolor="White">
                                                B-
                                            </td>
                                            <td style="width: 300px; text-align: center;">
                                                <asp:CheckBoxList ID="ChkansMatB" runat="server" Font-Size="Medium" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="0">P</asp:ListItem>
                                                    <asp:ListItem Value="1">Q</asp:ListItem>
                                                    <asp:ListItem Value="2">R</asp:ListItem>
                                                    <asp:ListItem Value="3">S</asp:ListItem>
                                                    <asp:ListItem Value="4">T</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: medium">
                                                C-
                                            </td>
                                            <td style="width: 300px; text-align: center;">
                                                <asp:CheckBoxList ID="ChkansMatC" runat="server" Font-Size="Medium" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="0">P</asp:ListItem>
                                                    <asp:ListItem Value="1">Q</asp:ListItem>
                                                    <asp:ListItem Value="2">R</asp:ListItem>
                                                    <asp:ListItem Value="3">S</asp:ListItem>
                                                    <asp:ListItem Value="4">T</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: medium">
                                                D-
                                            </td>
                                            <td style="width: 300px; text-align: center;">
                                                <asp:CheckBoxList ID="ChkansMatD" runat="server" Font-Size="Medium" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="0">P</asp:ListItem>
                                                    <asp:ListItem Value="1">Q</asp:ListItem>
                                                    <asp:ListItem Value="2">R</asp:ListItem>
                                                    <asp:ListItem Value="3">S</asp:ListItem>
                                                    <asp:ListItem Value="4">T</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lbllevel" runat="server" Font-Size="Large" ForeColor="#CC3300" Text="Level"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:RadioButtonList ID="rdoLevelList" runat="server" Font-Names="Arial" Font-Size="Small"
                                    RepeatDirection="Horizontal" ToolTip="Click to select level">
                                    <asp:ListItem Value="1">Level1</asp:ListItem>
                                    <asp:ListItem Value="2">Level2</asp:ListItem>
                                    <asp:ListItem Value="3">Level3</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center; height: 29px;">
                                <asp:Label ID="lblQuesVerify" runat="server" Font-Size="Large" ForeColor="#CC3300"
                                    Text="Question Verify ?"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px; height: 29px;">
                                <asp:RadioButtonList ID="rdoQuesVerify" runat="server" Font-Size="Medium" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="0">Correct</asp:ListItem>
                                    <asp:ListItem Value="1">InCorrect</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="width: 84px; text-align: center; height: 29px;">
                                <asp:Label ID="lblSuggest" runat="server" Font-Size="Large" ForeColor="#CC3300" Text="Suggestion"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px; height: 29px;">
                                <asp:TextBox ID="txtSuggest" runat="server" Height="32px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                                <asp:Label ID="lblTypeofQuesID" runat="server" Font-Size="Small" Text="Label" Visible="False"></asp:Label>
                            </td>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtAnsMatA" runat="server" Visible="False" Width="39px"></asp:TextBox>
                                    <asp:TextBox ID="txtAnsMatB" runat="server" Visible="False" Width="39px"></asp:TextBox>
                                    <asp:TextBox ID="txtAnsMatC" runat="server" Visible="False" Width="39px"></asp:TextBox>
                                    <asp:TextBox ID="txtAnsMatD" runat="server" Visible="False" Width="39px"></asp:TextBox>
                                </td>
                                <td colspan="4" style="text-align: center">
                                <asp:Button ID="btnDelete" runat="server" Height="39px" Text="Delete" Width="71px" 
                                        onclick="btnDelete_Click" Visible="false" />&nbsp;
                                         
                                    <asp:Button ID="btnBack" runat="server" Height="39px" Text="Back" Width="71px" 
                                        onclick="btnBack_Click" />
                                    &nbsp;<asp:Button ID="btnUpdate" runat="server" Height="39px" Text="Update" 
                                        Width="74px" onclick="btnUpdate_Click" />
                                    &nbsp;<asp:Button ID="btnNext" runat="server" Height="39px" Text="Next" 
                                        Width="71px" onclick="btnNext_Click" />
                                    &nbsp;&nbsp;
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtGotoQues" runat="server" Width="50px"></asp:TextBox>
                                    <asp:Button ID="btnGotoQues" runat="server" Height="30px" Text="Go to Question No."
                                        Width="118px" onclick="btnGotoQues_Click" />
                                    <br />
                                </td>
                            </tr>
                        </tr>
                    </table>
                </div>
            </table></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
