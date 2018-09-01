<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ex.aspx.cs" Inherits="Admin_ex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Padmaraj Exam</title>

    <script language="jscript" type="text/javascript">
        function nextQues() {
            //get urrent Ques No from Label value
            var lblValue = document.getElementById("<%=lblQues.ClientID%>").innerText;
            var n = lblValue.split("Ques:")[1];
            //alert(parseInt(n) + 1);

            if (parseInt(n) + 1 < 7) {
                var nextQuesNo = parseInt(n) + 1;
                var str1 = "pnlQues" + nextQuesNo;
                var str2 = "pnlQues" + (parseInt(n));

                document.getElementById("<%=lblQues.ClientID%>").innerText = "Ques:" + nextQuesNo;

                document.getElementById(str1).style.display = "block";
                document.getElementById(str2).style.display = "none";
            }
        }


        function backQues() {
            //get urrent Ques No from Label value
            var lblValue = document.getElementById("<%=lblQues.ClientID%>").innerText;
            var n = lblValue.split("Ques:")[1];
            //alert(parseInt(n) - 1);

            if (parseInt(n) - 1 > 0) {
                var backQuesNo = parseInt(n) - 1;
                var str1 = "pnlQues" + backQuesNo;
                var str2 = "pnlQues" + (parseInt(n));

                document.getElementById("<%=lblQues.ClientID%>").innerText = "Ques:" + backQuesNo;

                document.getElementById(str1).style.display = "block";
                document.getElementById(str2).style.display = "none";
            }
        }
    
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <asp:Label ID="lblQues" runat="server" Text="Ques:1"></asp:Label>
            <table>
                <tr>
                    <td>
                        <input type="button" id="Button1" name="btnBack" value="Back" onclick="backQues()" />
                    </td>
                    <td>
                        <asp:Panel ID="pnlQues1" runat="server" Width="800px" Wrap="true" Height="500px"
                            BackColor="White" Style="display: block" ScrollBars="Auto">
                            <asp:Label ID="Label1" runat="server" Text="Ques:1"></asp:Label>
                            <div style="width: 100%;">
                                <center>
                                    <%--style="width: 98%; height: 460px"--%>
                                    <table style="width: 100%; height: 100%" cellspacing="7px" bgcolor="White">
                                        <tr bgcolor="#FFFFCC">
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblqn" runat="server" Font-Size="Small" Text="Q.No. :" ForeColor="#00CC00"
                                                    Font-Bold="True"></asp:Label>
                                                <asp:Label ID="lblQNo" runat="server" Font-Size="Small" Text="Q" ForeColor="#00CC00"
                                                    Font-Bold="True"></asp:Label>
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                <asp:Label ID="lblQuestion_id" runat="server" Font-Bold="True" Font-Size="Small"
                                                    ForeColor="#009933" Text="Question_id" Visible="False"></asp:Label>
                                            </td>
                                            <td colspan="3" style="text-align: left;">
                                                <asp:Label ID="lbltypeQues" runat="server" Font-Size="Small" Text="Type of Ques"
                                                    ForeColor="#CC3300" Font-Bold="True"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblcount" runat="server" Font-Size="Small" Text="count" ForeColor="#009933"
                                                    Font-Bold="True"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="lblSno" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#009933"
                                                    Text="SNO" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblpassage1" runat="server" Text="Passage" Font-Size="Small" ForeColor="#CC3300"></asp:Label>
                                            </td>
                                            <td colspan="3" align="left">
                                                <asp:Label ID="lblPassage" runat="server" Font-Size="Small" Text="Passage"></asp:Label>
                                                <asp:Image ID="imgPassage" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text="Question" Font-Size="Small" ForeColor="#CC3300"></asp:Label>
                                            </td>
                                            <td colspan="3" align="left">
                                                <asp:Label ID="lblQuestion" runat="server" Font-Size="Small" Text="Question"></asp:Label>
                                                <asp:Image ID="imgQues" runat="server" />
                                                <%--</td>--%>
                                                <%--  </tr>
                                    <tr>
                                        <td style="width: 84px">
                                            <asp:Label ID="QuestionImage" runat="server" Text="QuestionImage" Font-Size="Small"
                                                ForeColor="#CC3300"></asp:Label>
                                        </td><td colspan="3" align="left">--%>
                                                <br />
                                                <asp:Label ID="lblQuestionwithImage" runat="server" Font-Size="Small" Text="QuestionwithImage"></asp:Label>
                                                <asp:Image ID="imgQuesImage" runat="server" />
                                                <%--</td>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblA" runat="server" Text="A" Font-Size="Small" ForeColor="#CC3300"></asp:Label>
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblOptA" runat="server" Font-Size="Small" Text="Option A"></asp:Label>
                                                <asp:Image ID="imgoptA" ImageUrl="" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblP" runat="server" Text="P" Font-Size="Small" ForeColor="#CC3300"></asp:Label>
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblOptP" runat="server" Font-Size="Small" Text="OptionP"></asp:Label>
                                                <asp:Image ID="imgoptP" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblB" runat="server" Text="B" Font-Size="Small" ForeColor="#CC3300"></asp:Label>
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblOptB" runat="server" Font-Size="Small" Text="OptionB"></asp:Label>
                                                <asp:Image ID="imgoptB" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblQ" runat="server" Text="Q" Font-Size="Small" ForeColor="#CC3300"></asp:Label>
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblOptQ" runat="server" Font-Size="Small" Text="OptionQ"></asp:Label>
                                                <asp:Image ID="imgoptQ" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblC" runat="server" Text="C" Font-Size="Small" ForeColor="#CC3300"></asp:Label>
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblOptC" runat="server" Font-Size="Small" Text="OptionC"></asp:Label>
                                                <asp:Image ID="imgoptC" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblR" runat="server" Text="R" Font-Size="Small" ForeColor="#CC3300"></asp:Label>
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblOptR" runat="server" Font-Size="Small" Text="OptionR"></asp:Label>
                                                <asp:Image ID="imgoptR" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblD" runat="server" Text="D" Font-Size="Small" ForeColor="#CC3300"></asp:Label>
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblOptD" runat="server" Font-Size="Small" Text="OptionD"></asp:Label>
                                                <asp:Image ID="imgoptD" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblS" runat="server" Text="S" Font-Size="Small" ForeColor="#CC3300"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblOptS" runat="server" Font-Size="Small" Text="OptionS"></asp:Label>
                                                <asp:Image ID="imgoptS" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblE" runat="server" Text="E" Font-Size="Small" ForeColor="#CC3300"></asp:Label>
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblOptE" runat="server" Font-Size="Small" Text="OptionE"></asp:Label>
                                                <asp:Image ID="imgoptE" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblT" runat="server" Text="T" Font-Size="Small" ForeColor="#CC3300"></asp:Label>
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="lblOptT" runat="server" Font-Size="Small" Text="OptionT"></asp:Label>
                                                <asp:Image ID="imgoptT" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblH" runat="server" Text="Hint" Font-Size="Small" ForeColor="#CC3300"></asp:Label>
                                            </td>
                                            <td colspan="4" align="left">
                                                <asp:TextBox ID="txtHint" runat="server" Height="32px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                <asp:Image ID="imgHint" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="White">
                                                <asp:Label ID="lblAns" runat="server" Text="Answer" Font-Size="Small" ForeColor="#CC3300"></asp:Label>
                                            </td>
                                            <td colspan="3" align="left">
                                                <asp:RadioButtonList ID="rdoAnswerlist" runat="server" Font-Size="Small" RepeatDirection="Horizontal"
                                                    Visible="False">
                                                    <asp:ListItem Value="0">A</asp:ListItem>
                                                    <asp:ListItem Value="1">B</asp:ListItem>
                                                    <asp:ListItem Value="2">C</asp:ListItem>
                                                    <asp:ListItem Value="3">D</asp:ListItem>
                                                    <asp:ListItem Value="4">E</asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:TextBox ID="txtAns" runat="server" MaxLength="15" Visible="False" Width="158px"></asp:TextBox>
                                                <asp:CheckBoxList ID="chkAnslist" runat="server" Font-Size="Small" RepeatDirection="Horizontal"
                                                    Visible="False">
                                                    <asp:ListItem Value="0">A</asp:ListItem>
                                                    <asp:ListItem Value="1">B</asp:ListItem>
                                                    <asp:ListItem Value="2">C</asp:ListItem>
                                                    <asp:ListItem Value="3">D</asp:ListItem>
                                                    <asp:ListItem Value="4">E</asp:ListItem>
                                                </asp:CheckBoxList>
                                                <asp:Panel ID="pnlAnsMat" runat="server" Visible="False">
                                                    <table>
                                                        <tr>
                                                            <td style="font-size: Small">
                                                                A-
                                                            </td>
                                                            <td>
                                                                <asp:CheckBoxList ID="ChkansMatA" runat="server" Font-Size="Small" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="0">P</asp:ListItem>
                                                                    <asp:ListItem Value="1">Q</asp:ListItem>
                                                                    <asp:ListItem Value="2">R</asp:ListItem>
                                                                    <asp:ListItem Value="3">S</asp:ListItem>
                                                                    <asp:ListItem Value="4">T</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-size: Small" bgcolor="White">
                                                                B-
                                                            </td>
                                                            <td>
                                                                <asp:CheckBoxList ID="ChkansMatB" runat="server" Font-Size="Small" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="0">P</asp:ListItem>
                                                                    <asp:ListItem Value="1">Q</asp:ListItem>
                                                                    <asp:ListItem Value="2">R</asp:ListItem>
                                                                    <asp:ListItem Value="3">S</asp:ListItem>
                                                                    <asp:ListItem Value="4">T</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-size: Small">
                                                                C-
                                                            </td>
                                                            <td>
                                                                <asp:CheckBoxList ID="ChkansMatC" runat="server" Font-Size="Small" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="0">P</asp:ListItem>
                                                                    <asp:ListItem Value="1">Q</asp:ListItem>
                                                                    <asp:ListItem Value="2">R</asp:ListItem>
                                                                    <asp:ListItem Value="3">S</asp:ListItem>
                                                                    <asp:ListItem Value="4">T</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-size: Small">
                                                                D-
                                                            </td>
                                                            <td>
                                                                <asp:CheckBoxList ID="ChkansMatD" runat="server" Font-Size="Small" RepeatDirection="Horizontal">
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
                                            <td>
                                                <asp:Label ID="lbllevel" runat="server" Font-Size="Small" ForeColor="#CC3300" Text="Level"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtAnsMatA" runat="server" Visible="False" Width="39px"></asp:TextBox>
                                                <asp:TextBox ID="txtAnsMatB" runat="server" Visible="False" Width="39px"></asp:TextBox>
                                                <asp:TextBox ID="txtAnsMatC" runat="server" Visible="False" Width="39px"></asp:TextBox>
                                                <asp:TextBox ID="txtAnsMatD" runat="server" Visible="False" Width="39px"></asp:TextBox>
                                            </td>
                                            <td colspan="4">
                                                <%-- <asp:Button ID="btnBack" runat="server" Height="39px" OnClick="btnBack_Click" Text="Back"
                                                    Width="71px" />                                                
                                                &nbsp;<asp:Button ID="Button2" runat="server" Height="39px" OnClick="btnNext_Click"
                                                    Text="Next" Width="71px" />--%>
                                                &nbsp;
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlQues2" runat="server" Width="800px" Wrap="true" Height="500px"
                            BackColor="#aa0002" Style="display: none">
                            <asp:Label ID="Label2" runat="server" Text="Ques:2"></asp:Label>
                            <%--<asp:DataList ID="DataList1" runat="server" Width="600px" GridLines="Horizontal"
                                RepeatColumns="1" RepeatDirection="Vertical" CellPadding="3" BorderWidth="1px"
                                BorderStyle="None" BorderColor="#E7E7FF" BackColor="White">
                                <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
                                <AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
                                <SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
                                <ItemStyle ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
                                <HeaderTemplate>
                                    <table width="600px">
                                        <tr>
                                            <td width="300px">
                                                <b>Topic Name</b>
                                            </td>
                                            <td width="300px">
                                                <b>User Name</b>
                                            </td>
                                            <td width="300px">
                                                <b>Post Count</b>
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table width="900px" cellpadding="1">
                                        <tr>
                                            <td align="left" width="300px">                                            
                                                <%# DataBinder.Eval(Container.DataItem, "Tname") %>
                                            </td>
                                            <td align="left" width="300px">
                                                <%# DataBinder.Eval(Container.DataItem, "UserName") %>
                                            </td>
                                            <td align="left" width="300px">
                                                <%# DataBinder.Eval(Container.DataItem, "Count") %>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <SeparatorTemplate>
                                    <hr />
                                </SeparatorTemplate>
                                <HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
                            </asp:DataList>--%>
                        </asp:Panel>
                        <asp:Panel ID="pnlQues3" runat="server" Width="800px" Wrap="true" Height="500px"
                            BackColor="#ffffff" Style="display: none">
                            <asp:Label ID="Label3" runat="server" Text="Ques:3"></asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="pnlQues4" runat="server" Width="800px" Wrap="true" Height="500px"
                            BackColor="#cccccc" Style="display: none">
                            <asp:Label ID="Label4" runat="server" Text="Ques:4"></asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="pnlQues5" runat="server" Width="800px" Wrap="true" Height="500px"
                            BackColor="#aaaaaa" Style="display: none">
                            <asp:Label ID="Label5" runat="server" Text="Ques:5"></asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="pnlQues6" runat="server" Width="800px" Wrap="true" Height="500px"
                            BackColor="#123ddd" Style="display: none">
                            <asp:Label ID="Label6" runat="server" Text="Ques:6"></asp:Label>
                        </asp:Panel>
                    </td>
                    <td>
                        <input type="button" id="btnNext" name="btnNext" value="Next" onclick="nextQues()" />
                    </td>
                </tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>
