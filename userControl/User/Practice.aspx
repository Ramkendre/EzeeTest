<%@ Page Language="C#" MasterPageFile="~/Layout/MasterPageNew.master" AutoEventWireup="true"
    CodeFile="Practice.aspx.cs" Inherits="Practice" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            width: 129px;
            height: 63px;
        }
        .style3
        {
            height: 63px;
            
        }
        .style4
        {
            font-size: 12px;
            color: Red;
            height: 63px;
        }
        .style5
        {
            height: 28px;
            width: 129px;
        }
        .style6
        {
            width: 129px;
        }
    .style7
    {
        width: 129px;
        height: 41px;
    }
    .style8
    {
        height: 41px;
    }
        .style9
        {
            width: 129px;
            height: 77px;
        }
        .style10
        {
            height: 77px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <center>
                <table cellpadding="0" cellspacing="0" width="70%" border="1">
                    <tr>
                        <%--<td align="center">--%>
                            <div style="width: 100%">
                                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                 
                                      <tr>
                                    <td colspan="2" style="height: 20px;">
                                        <table style="width: 80%; font-family: 'Times New Roman', Times, serif; font-size: medium;"
                                            class="tables" cellspacing="7px">
                                            <tr>
                                               <%-- <td style="text-align: center; width: 103px;">
                                                </td>--%>
                                                <td style="text-align: center;" colspan="4" align="center" style="text-align: left;
                                                    font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                   <%-- <b style="font-size: x-large">Sample Test </b>
                                                    --%>
                                                    <div class="graybox">Start Test</div>

                                                    
                                                    
                                                </td>
                                            </tr>
                                            
                                            
                                               <tr>
                                        <td colspan="2" class="style1">
                                            <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                        </td>
                                    </tr>
                                            
                                            <tr>
                                                <td align="center" colspan="3" style="text-align: left">
                                                    &nbsp;&nbsp;<span style="font-size: medium"><asp:Label ID="lblError" Visible="false"
                                                        runat="server" CssClass="error" Text="Label"></asp:Label><asp:Label ID="lblSuccess"
                                                            runat="server" Visible="False" CssClass="error"></asp:Label></span><br />
                                                    <span style="font-size: medium">
                                                        <asp:Label ID="Label1" runat="server" CssClass="error"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 103px; text-align: center;">
                                                    &nbsp;Language
                                                </td>
                                                <td align="center" colspan="5" style="text-align: left">
                                                    <asp:DropDownList ID="cmbSelectlang" runat="server" ToolTip="Click to select language"
                                                        Width="140px" OnSelectedIndexChanged="cmbSelectlang_SelectedIndexChanged" AutoPostBack="True">
                                                        <asp:ListItem>English</asp:ListItem>
                                                        <asp:ListItem>Hindi</asp:ListItem>
                                                        <asp:ListItem>Marathi</asp:ListItem>
                                                        <asp:ListItem></asp:ListItem>
                                                    </asp:DropDownList>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 103px; text-align: center;">
                                                    Subject <span class="warning1" style="color: Red;">*</span>
                                                </td>
                                                <td style="text-align: left" colspan="3">
                                                    <asp:DropDownList ID="cmbSelectSub" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbSelectsub_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="error">
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 103px; text-align: center;">
                                                    &nbsp;Chapter <span class="warning1" style="color: Red;">*</span>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:ListBox ID="lstboxSeltopic" runat="server" BackColor="Transparent" Height="62px"
                                                        OnSelectedIndexChanged="lstboxSeltopic_SelectedIndexChanged" AutoPostBack="True"
                                                        SelectionMode="Multiple" Width="172px"></asp:ListBox>
                                                </td>
                                                <td style="text-align: left">
                                                    &nbsp;&nbsp;<br />
                                                    <asp:RadioButtonList ID="rdoLevelList" runat="server" ToolTip="Click to select level"
                                                        OnSelectedIndexChanged="rdoLevelList_SelectedIndexChanged" AutoPostBack="True"
                                                        Font-Names="Arial" Font-Size="Small" RepeatDirection="Horizontal" 
                                                        Visible="False">
                                                        <asp:ListItem Value="Level1" Selected="True">Level1</asp:ListItem>
                                                        <asp:ListItem Value="Level2">Level2</asp:ListItem>
                                                        <asp:ListItem Value="Level3">Level3</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 103px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: left" colspan="3">
                                                    &nbsp;<asp:Button ID="btnStart" runat="server" CssClass="btn" Text="Start Test" ToolTip="Click here to start the test"
                                                        OnClick="btnStart_Click1" />
                                                    &nbsp;
                                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn" OnClick="btnExit_Click"
                                                        Text="Cancel" ToolTip="Click here to Cancel" ValidationGroup="other" PostBackUrl="~/html/UserHome.aspx" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label2" runat="server" CssClass="label" Text="Label"></asp:Label>
                                                </td>
                                                <td class="error">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: left">
                                                </td>
                                                <td class="error">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        </td>
                                        </tr>
                                </table>
                </table>
            </center>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <center>
                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                  <tr>
                                               
                                                <td style="text-align: center;" colspan="4" align="center" style="text-align: left;
                                                    font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                   <%-- <b style="font-size: x-large">Sample Test </b>
                                                    --%>
                                                    <div class="graybox">Sample Test</div>


                                                    
                                                    
                                                </td>
                                            </tr>
                 
                    <tr>
                        <td style="text-align: center;" class="style5">
                            &nbsp;
                        </td>
                        <td style="text-align: left; height: 28px;" colspan="3">
                            <asp:Label ID="lblCans" runat="server"></asp:Label>
                        </td>
                        <td class="error">
                            &nbsp;
                        </td>
                        <td style="text-align: left">
                        </td>
                        <td class="error" style="height: 28px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center;" class="style2">
                            <asp:Label ID="lblCans0" runat="server" Text="Q.No."></asp:Label>
                            <asp:Label ID="lblQuestion" runat="server" Text="Question  :" Width="95px" Font-Bold="True"></asp:Label>
                        </td>
                        <td style="text-align: left; " colspan="3" class="style3">
                          <asp:Label ID="lblQue" runat="server" Width="573px" Style="font-size: medium; font-weight: 700;
                                color: #800000"></asp:Label>
                                
                                
                                
                        </td>
                        <td class="style4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                       <%-- <td class="style9">--%>
                       <td>
                        </td>
                       <%-- <td class="style10">--%>
                        <td>
                            <asp:Image ID="ImgSfeed" runat="server" Height="77px" Width="135px" ImageAlign="Left" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center;" class="style6">
                            <asp:Label ID="lblAnswer" runat="server" Text="Answer "></asp:Label>
                        </td>
                        <td style="text-align: left" colspan="3">
                            <asp:RadioButtonList ID="rdoAnswerlist" runat="server" ToolTip="Click to select answer"
                                CellSpacing="4" OnSelectedIndexChanged="rdoAnswerlist_SelectedIndexChanged" EnableTheming="True"
                                Style="font-family: 'Times New Roman', Times, serif" Height="36px" Width="477px"
                                RepeatDirection="Horizontal">
                                <asp:ListItem>Answer1</asp:ListItem>
                                <asp:ListItem>Answer2</asp:ListItem>
                                <asp:ListItem>Answer3</asp:ListItem>
                                <asp:ListItem>Answer4</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                        </td>
                        <td class="error">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                       <td style="text-align: center;" class="style7">
                            <asp:LinkButton ID="AnswerHint" runat="server" OnClick="AnswerHint_Click">Hint</asp:LinkButton>
                        </td>
                        <td style="text-align: left" colspan="3" class="style8">
                            <asp:Label ID="txtQhint" runat="server" Width="573px" Style="font-size: medium; color: #800000"></asp:Label>
                            <br />
                        </td>
                        <td class="style8">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style6">
                        </td>
                        <td colspan="4" align="center" style="text-align: left">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" ValidationGroup="vgpStateSubmit"
                                OnClick="btnSubmit_Click" ToolTip="Click here to submit" />
                            &nbsp;<asp:Button ID="btnPrevious" CssClass="btn" runat="server" OnClick="btnPrevious_Click"
                                Text="Prev" />
                            &nbsp;<asp:Label ID="txtGoto" runat="server" ForeColor="#006600" Style="font-weight: 700"
                                Width="30px"></asp:Label><asp:Button ID="btnNext" CssClass="btn" runat="server" Text="Next"
                                    ToolTip="Click here to go to next question" OnClick="btnNext_Click" />
                            &nbsp;&nbsp;<asp:Label ID="TxtCount" runat="server" ForeColor="#006600" Style="font-weight: 700"
                                Width="31px"></asp:Label>&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnExit" runat="server" CssClass="btn" OnClick="btnExit_Click" Text="Exit"
                                ToolTip="Click here to exit" ValidationGroup="other" PostBackUrl="~/html/UserHome.aspx" />
                            &nbsp;&nbsp;
                            <asp:Label ID="lblQues_id" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center;" class="style5">
                        </td>
                        <td style="text-align: left; height: 28px;" colspan="3">
                        </td>
                        <td class="error">
                        </td>
                        <td style="text-align: left">
                        </td>
                        <td class="error" style="height: 28px">
                        </td>
                    </tr>
                </table>
            </center>
        </asp:View>
        <%--  </tr> </table> </div> </td> </tr> </table> </center>--%>
    </asp:MultiView>
</asp:Content>
