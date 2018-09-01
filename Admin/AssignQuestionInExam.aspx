<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AssignQuestionInExam.aspx.cs" Inherits="Admin_AssignQuestionInExam"
    Culture="auto" MaintainScrollPositionOnPostback="true" meta:resourcekey="PageResource1"
    UICulture="auto" Title="eZeeTest:Add Question Method 1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .protected
        {
            -moz-user-select: none;
            -webkit-user-select: none;
            user-select: none;
        }
    </style>

    <script language="javascript" type="text/javascript">
        function disableselect(e) {
            return false
        }
        function reEnable() {
            return true
        }
        document.onselectstart = new Function("return false")
        if (window.sidebar) {
            document.onmousedown = disableselect                    // for mozilla           
            document.onclick = reEnable
        }
        function clickIE() {
            if (document.all) {
                (message);
                return false;
            }
        }
        document.oncontextmenu = new Function("return false")
        var element = document.getElementById('tbl');
        element.onmousedown = function() { return false; }        // For Mozilla Browser
    </script>

    <div style="width: 100%;" align="center">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:UpdatePanel ID="updatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkbtnBackToPanel" runat="server" Visible="false" Text="<<< Back To Panel"
                            Font-Bold="true" ForeColor="HighlightText" PostBackUrl="~/CreateTest/createtest.aspx"></asp:LinkButton>
                        <table cellpadding="0" cellspacing="0" width="65%" class="tables" border="1">
                            <tr>
                                <td>
                                    <center>
                                        <table style="width: 55%" class="tables" width="160">
                                            <tr>
                                                <td colspan="3" style="text-align: center">
                                                    <h3 style="color: Green; font-size: x-large">
                                                        Add Question for Exam&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </h3>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                    <br />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbltext" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Test Name" Width="120px" meta:resourcekey="lbltextResource1"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddltextName" runat="server" CssClass="ddlcsswidth " AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddltextName_SelectedIndexChanged" meta:resourcekey="ddltextNameResource1">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddltextName"
                                                        ErrorMessage="Please select Test Name." Font-Size="Small" InitialValue="--Select--"
                                                        SetFocusOnError="True" ValidationGroup="other" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Subject" Width="100px" meta:resourcekey="Label7Resource1"></asp:Label>
                                                    <span class="warning1" style="color: Red;">*</span>&nbsp;
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="cmbSelectsubject" runat="server" CssClass="ddlcsswidth " AutoPostBack="True"
                                                        OnSelectedIndexChanged="cmbSelectsubject_SelectedIndexChanged" meta:resourcekey="cmbSelectsubjectResource1">
                                                        
                                                    </asp:DropDownList>
                                                    <br />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbSelectsubject"
                                                        ErrorMessage="You have not selected Subject" Font-Size="Small" InitialValue="--Select--"
                                                        SetFocusOnError="True" ValidationGroup="other" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblchapter" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Chapter" Width="100px" meta:resourcekey="lblchapterResource1"></asp:Label>
                                                    <span class="warning1" style="color: Red;">*</span>&nbsp;
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTopik" runat="server" CssClass="ddlcsswidth " AutoPostBack="True"
                                                         meta:resourcekey="ddlTopicResource1" OnSelectedIndexChanged="ddlTopik_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <br />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTopik"
                                                        ErrorMessage="You have not selected Chapter" Font-Size="Small" InitialValue="--Select--"
                                                        SetFocusOnError="True" ValidationGroup="other" meta:resourcekey="RequiredFieldValidator1Resource3"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblMedium" runat="server" Font-Bold="False" Font-Names="arial" Font-Size="11pt"
                                                        Text="Select Medium" Width="170px" meta:resourcekey="lblMediumResource1"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="ddlcsswidth " meta:resourcekey="ddlMediumResource1">
                                                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource2">English</asp:ListItem>
                                                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource3">Semi-English</asp:ListItem>
                                                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource4">Marathi</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblpublication" runat="server" Font-Bold="false" Font-Names="arial" Font-Size="11pt" 
                                                        Text="Select Publication" Width="170px" meta:resourcekey="lblpublicationResource1"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlpublication" runat="server" CssClass="ddlcsswidth " meta:resourcekey="ddlpublicationResource1" AutoPostBack="true"> <%--OnSelectedIndexChanged="ddlpublication_SelectedIndexChanged">--%>
                                                    </asp:DropDownList>
                                                 </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblTopic" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Topic" Width="150px" meta:resourcekey="lblTopicResource1"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <div class="container">
                                                        <asp:CheckBox ID="ChkSelectALL" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSelectALL_CheckedChanged"
                                                            Text="Select ALL Topic" Visible="False" meta:resourcekey="ChkSelectALLResource1"/>
                                                        <asp:CheckBoxList ID="ddlChapter" runat="server" RepeatColumns="1" BorderWidth="0px"
                                                            Datafield="description" DataValueField="value" OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged"
                                                            meta:resourcekey="ddlChapterResource1">
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Level of Question " Width="160px" meta:resourcekey="Label8Resource1"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rdoLevelList1" runat="server" Font-Names="Arial" Font-Size="Small"
                                                        AutoPostBack="True" RepeatDirection="Horizontal" ToolTip="Click to select level"
                                                        OnSelectedIndexChanged="rdoLevelList1_SelectedIndexChanged" meta:resourcekey="rdoLevelList1Resource1">
                                                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource5">Level1</asp:ListItem>
                                                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource6">Level2</asp:ListItem>
                                                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource7">Level3</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td colspan="2">
                                                    &nbsp;<asp:Button ID="btnStart" runat="server" CssClass="btn" OnClick="btnStart_Click1"
                                                        Text="Find Question" ToolTip="Click here to start the test" ValidationGroup="other"
                                                        meta:resourcekey="btnStartResource1" />
                                                    &nbsp;
                                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn" Text="Cancel" ToolTip="Click here to Cancel"
                                                        ValidationGroup="other" CausesValidation="False" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                                                    &nbsp;&nbsp;<asp:LinkButton ID="btnarchive" runat="server" Visible="False" Text="Get BackUp Selected Test."
                                                        ToolTip="Click Here to Trasfer Archive." Font-Size="Small" OnClick="btnarchive_Click"
                                                        meta:resourcekey="btnarchiveResource1" />
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Panel ID="pnl1" runat="server" meta:resourcekey="pnl1Resource1">
                                                        <asp:Label ID="lblTotalQNo" runat="server" CssClass="error" meta:resourcekey="lblTotalQNoResource1"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="lblAvailable" runat="server" CssClass="error" meta:resourcekey="lblAvailableResource1"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="lblRemaininhg" runat="server" CssClass="error" meta:resourcekey="lblRemaininhgResource1"></asp:Label>
                                                        <br />
                                                    </asp:Panel>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnStart" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:LinkButton ID="LinkButton1" runat="server" Visible="false" Text="<<< Back To Panel"
                    Font-Bold="true" ForeColor="HighlightText" PostBackUrl="~/CreateTest/createtest.aspx"></asp:LinkButton>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table cellpadding="0" cellspacing="0" width="70%" bgcolor="White">
                            <div style="width: 80%;">
                                <table style="width: 91%; font-family: Times New Roman;" cellspacing="7px" bgcolor="White">
                                    <tr bgcolor="#FFFFCC">
                                        <td colspan="2" align="left">
                                            <asp:Label ID="lblqn" runat="server" Font-Size="Large" Text="Q.No. :" ForeColor="#00CC00"
                                                Font-Bold="True" meta:resourcekey="lblqnResource1"></asp:Label>
                                            <asp:Label ID="lblQNo" runat="server" Font-Size="Large" Text="Q" ForeColor="#00CC00"
                                                Font-Bold="True" meta:resourcekey="lblQNoResource1"></asp:Label>
                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                            <asp:Label ID="lblQuestion_id" runat="server" Font-Bold="True" Font-Size="Medium"
                                                ForeColor="#009933" Text="Question_id" Visible="False" meta:resourcekey="lblQuestion_idResource1"></asp:Label>
                                        </td>
                                        <td colspan="3" style="width: 84px; text-align: left;">
                                            <asp:Label ID="lbltypeQues" runat="server" Font-Size="Medium" Text="Type of Ques"
                                                ForeColor="#CC3300" Font-Bold="True" meta:resourcekey="lbltypeQuesResource1"></asp:Label>
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblcount" runat="server" Font-Size="Medium" Text="count" ForeColor="#009933"
                                                Font-Bold="True" meta:resourcekey="lblcountResource1"></asp:Label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblSno" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#009933"
                                                Text="SNO" Visible="False" meta:resourcekey="lblSnoResource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px">
                                            <asp:Label ID="lblpassage1" runat="server" Text="Passage" Font-Size="Large" ForeColor="#CC3300"
                                                meta:resourcekey="lblpassage1Resource1"></asp:Label>
                                        </td>
                                        <td colspan="3" align="left">
                                            <asp:Label ID="lblPassage" runat="server" Font-Size="Medium" Text="Passage" meta:resourcekey="lblPassageResource1"></asp:Label>
                                            <asp:Image ID="imgPassage" runat="server" meta:resourcekey="imgPassageResource1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px">
                                            <asp:Label ID="lblQues" runat="server" Text="Question" Font-Size="Large" ForeColor="#CC3300"
                                                meta:resourcekey="lblQuesResource1"></asp:Label>
                                        </td>
                                        <td colspan="3" align="left">
                                            <asp:Label ID="lblQuestion" runat="server" Font-Size="Medium" Text="Question" meta:resourcekey="lblQuestionResource1"></asp:Label>
                                            <asp:Image ID="imgQues" runat="server" meta:resourcekey="imgQuesResource1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px">
                                            <asp:Label ID="QuestionImage" runat="server" Text="QuestionImage" Font-Size="Large"
                                                ForeColor="#CC3300" meta:resourcekey="QuestionImageResource1"></asp:Label>
                                        </td>
                                        <td colspan="3" align="left">
                                            <asp:Label ID="lblQuestionwithImage" runat="server" Font-Size="Medium" Text="QuestionwithImage"
                                                meta:resourcekey="lblQuestionwithImageResource1"></asp:Label>
                                            <asp:Image ID="imgQuesImage" runat="server" meta:resourcekey="imgQuesImageResource1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px; text-align: center;">
                                            <asp:Label ID="lblA" runat="server" Text="A" Font-Size="Large" ForeColor="#CC3300"
                                                meta:resourcekey="lblAResource1"></asp:Label>
                                        </td>
                                        <td colspan="2" align="left" style="width: 300px">
                                            <asp:Label ID="lblOptA" runat="server" Font-Size="Medium" Text="OptionA" meta:resourcekey="lblOptAResource1"></asp:Label>
                                            <asp:Image ID="imgoptA" runat="server" meta:resourcekey="imgoptAResource1" />
                                        </td>
                                        <td style="width: 84px; text-align: center;">
                                            <asp:Label ID="lblP" runat="server" Text="P" Font-Size="Large" ForeColor="#CC3300"
                                                meta:resourcekey="lblPResource1"></asp:Label>
                                        </td>
                                        <td colspan="2" align="left" style="width: 300px">
                                            <asp:Label ID="lblOptP" runat="server" Font-Size="Medium" Text="OptionP" meta:resourcekey="lblOptPResource1"></asp:Label>
                                            <asp:Image ID="imgoptP" runat="server" meta:resourcekey="imgoptPResource1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px; text-align: center;">
                                            <asp:Label ID="lblB" runat="server" Text="B" Font-Size="Large" ForeColor="#CC3300"
                                                meta:resourcekey="lblBResource1"></asp:Label>
                                        </td>
                                        <td colspan="2" align="left" style="width: 300px">
                                            <asp:Label ID="lblOptB" runat="server" Font-Size="Medium" Text="OptionB" meta:resourcekey="lblOptBResource1"></asp:Label>
                                            <asp:Image ID="imgoptB" runat="server" meta:resourcekey="imgoptBResource1" />
                                        </td>
                                        <td style="width: 84px; text-align: center;">
                                            <asp:Label ID="lblQ" runat="server" Text="Q" Font-Size="Large" ForeColor="#CC3300"
                                                meta:resourcekey="lblQResource1"></asp:Label>
                                        </td>
                                        <td colspan="2" align="left" style="width: 300px">
                                            <asp:Label ID="lblOptQ" runat="server" Font-Size="Medium" Text="OptionQ" meta:resourcekey="lblOptQResource1"></asp:Label>
                                            <asp:Image ID="imgoptQ" runat="server" meta:resourcekey="imgoptQResource1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px; text-align: center;">
                                            <asp:Label ID="lblC" runat="server" Text="C" Font-Size="Large" ForeColor="#CC3300"
                                                meta:resourcekey="lblCResource1"></asp:Label>
                                        </td>
                                        <td colspan="2" align="left" style="width: 300px">
                                            <asp:Label ID="lblOptC" runat="server" Font-Size="Medium" Text="OptionC" meta:resourcekey="lblOptCResource1"></asp:Label>
                                            <asp:Image ID="imgoptC" runat="server" meta:resourcekey="imgoptCResource1" />
                                        </td>
                                        <td style="width: 84px; text-align: center;">
                                            <asp:Label ID="lblR" runat="server" Text="R" Font-Size="Large" ForeColor="#CC3300"
                                                meta:resourcekey="lblRResource1"></asp:Label>
                                        </td>
                                        <td colspan="2" align="left" style="width: 300px">
                                            <asp:Label ID="lblOptR" runat="server" Font-Size="Medium" Text="OptionR" meta:resourcekey="lblOptRResource1"></asp:Label>
                                            <asp:Image ID="imgoptR" runat="server" meta:resourcekey="imgoptRResource1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px; text-align: center;">
                                            <asp:Label ID="lblD" runat="server" Text="D" Font-Size="Large" ForeColor="#CC3300"
                                                meta:resourcekey="lblDResource1"></asp:Label>
                                        </td>
                                        <td colspan="2" align="left" style="width: 300px">
                                            <asp:Label ID="lblOptD" runat="server" Font-Size="Medium" Text="OptionD" meta:resourcekey="lblOptDResource1"></asp:Label>
                                            <asp:Image ID="imgoptD" runat="server" meta:resourcekey="imgoptDResource1" />
                                        </td>
                                        <td style="width: 84px; text-align: center;">
                                            <asp:Label ID="lblS" runat="server" Text="S" Font-Size="Large" ForeColor="#CC3300"
                                                meta:resourcekey="lblSResource1"></asp:Label>
                                        </td>
                                        <td colspan="2" align="left" style="width: 300px">
                                            <asp:Label ID="lblOptS" runat="server" Font-Size="Medium" Text="OptionS" meta:resourcekey="lblOptSResource1"></asp:Label>
                                            <asp:Image ID="imgoptS" runat="server" meta:resourcekey="imgoptSResource1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px; text-align: center;">
                                            <asp:Label ID="lblE" runat="server" Text="E" Font-Size="Large" ForeColor="#CC3300"
                                                meta:resourcekey="lblEResource1"></asp:Label>
                                        </td>
                                        <td colspan="2" align="left" style="width: 300px">
                                            <asp:Label ID="lblOptE" runat="server" Font-Size="Medium" Text="OptionE" meta:resourcekey="lblOptEResource1"></asp:Label>
                                            <asp:Image ID="imgoptE" runat="server" meta:resourcekey="imgoptEResource1" />
                                        </td>
                                        <td style="width: 84px; text-align: center;">
                                            <asp:Label ID="lblT" runat="server" Text="T" Font-Size="Large" ForeColor="#CC3300"
                                                meta:resourcekey="lblTResource1"></asp:Label>
                                        </td>
                                        <td colspan="2" align="left" style="width: 300px">
                                            <asp:Label ID="lblOptT" runat="server" Font-Size="Medium" Text="OptionT" meta:resourcekey="lblOptTResource1"></asp:Label>
                                            <asp:Image ID="imgoptT" runat="server" meta:resourcekey="imgoptTResource1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px; text-align: center;">
                                            <asp:Label ID="lblH" runat="server" Text="Hint" Font-Size="Large" ForeColor="#CC3300"
                                                meta:resourcekey="lblHResource1"></asp:Label>
                                            <br />
                                            <asp:DropDownList ID="ddlhint" runat="server" OnSelectedIndexChanged="ddlhint_SelectedIndexChanged"
                                                AutoPostBack="True" Enabled="False" Visible="False" meta:resourcekey="ddlhintResource1">
                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource8">English</asp:ListItem>
                                                <asp:ListItem Value="1" meta:resourcekey="ListItemResource9">Marathi</asp:ListItem>
                                                <asp:ListItem Value="3" meta:resourcekey="ListItemResource10">MarathiMangal</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td colspan="4" align="left">
                                            <asp:TextBox ID="txtHint" runat="server" Height="29px" TextMode="MultiLine" Width="300px"
                                                ReadOnly="True" meta:resourcekey="txtHintResource1"></asp:TextBox>
                                            <asp:Image ID="imgHint" runat="server" meta:resourcekey="imgHintResource1" />
                                            <asp:Image ID="imgHint2" runat="server" meta:resourcekey="imgHintResource1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px; text-align: center; vertical-align: top;" bgcolor="White">
                                            <asp:Label ID="lblAns" runat="server" Text="Answer" Font-Size="Large" ForeColor="#CC3300"
                                                meta:resourcekey="lblAnsResource1"></asp:Label>
                                        </td>
                                        <td colspan="3" align="left">
                                            <asp:RadioButtonList ID="rdoAnswerlist" runat="server" Font-Size="Medium" RepeatDirection="Horizontal"
                                                Visible="False" Enabled="False" meta:resourcekey="rdoAnswerlistResource1">
                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource10">A</asp:ListItem>
                                                <asp:ListItem Value="1" meta:resourcekey="ListItemResource11">B</asp:ListItem>
                                                <asp:ListItem Value="2" meta:resourcekey="ListItemResource12">C</asp:ListItem>
                                                <asp:ListItem Value="3" meta:resourcekey="ListItemResource13">D</asp:ListItem>
                                                <asp:ListItem Value="4" meta:resourcekey="ListItemResource14">E</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:TextBox ID="txtAns" runat="server" MaxLength="15" Visible="False" Width="158px"
                                                Enabled="False" meta:resourcekey="txtAnsResource1"></asp:TextBox>
                                            <asp:CheckBoxList ID="chkAnslist" runat="server" Font-Size="Medium" RepeatDirection="Horizontal"
                                                Visible="False" Enabled="False" meta:resourcekey="chkAnslistResource1">
                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource15">A</asp:ListItem>
                                                <asp:ListItem Value="1" meta:resourcekey="ListItemResource16">B</asp:ListItem>
                                                <asp:ListItem Value="2" meta:resourcekey="ListItemResource17">C</asp:ListItem>
                                                <asp:ListItem Value="3" meta:resourcekey="ListItemResource18">D</asp:ListItem>
                                                <asp:ListItem Value="4" meta:resourcekey="ListItemResource19">E</asp:ListItem>
                                            </asp:CheckBoxList>
                                            <asp:Panel ID="pnlAnsMat" runat="server" Visible="False" Height="110px" Width="305px"
                                                meta:resourcekey="pnlAnsMatResource1">
                                                <table>
                                                    <tr>
                                                        <td style="font-size: medium">
                                                            A-
                                                        </td>
                                                        <td style="width: 300px; text-align: center;">
                                                            <asp:CheckBoxList ID="ChkansMatA" runat="server" Font-Size="Medium" RepeatDirection="Horizontal"
                                                                Enabled="False" meta:resourcekey="ChkansMatAResource1">
                                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource20">P</asp:ListItem>
                                                                <asp:ListItem Value="1" meta:resourcekey="ListItemResource21">Q</asp:ListItem>
                                                                <asp:ListItem Value="2" meta:resourcekey="ListItemResource22">R</asp:ListItem>
                                                                <asp:ListItem Value="3" meta:resourcekey="ListItemResource23">S</asp:ListItem>
                                                                <asp:ListItem Value="4" meta:resourcekey="ListItemResource24">T</asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: medium" bgcolor="White">
                                                            B-
                                                        </td>
                                                        <td style="width: 300px; text-align: center;">
                                                            <asp:CheckBoxList ID="ChkansMatB" runat="server" Font-Size="Medium" RepeatDirection="Horizontal"
                                                                Enabled="False" meta:resourcekey="ChkansMatBResource1">
                                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource25">P</asp:ListItem>
                                                                <asp:ListItem Value="1" meta:resourcekey="ListItemResource26">Q</asp:ListItem>
                                                                <asp:ListItem Value="2" meta:resourcekey="ListItemResource27">R</asp:ListItem>
                                                                <asp:ListItem Value="3" meta:resourcekey="ListItemResource28">S</asp:ListItem>
                                                                <asp:ListItem Value="4" meta:resourcekey="ListItemResource29">T</asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: medium">
                                                            C-
                                                        </td>
                                                        <td style="width: 300px; text-align: center;">
                                                            <asp:CheckBoxList ID="ChkansMatC" runat="server" Font-Size="Medium" RepeatDirection="Horizontal"
                                                                Enabled="False" meta:resourcekey="ChkansMatCResource1">
                                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource30">P</asp:ListItem>
                                                                <asp:ListItem Value="1" meta:resourcekey="ListItemResource31">Q</asp:ListItem>
                                                                <asp:ListItem Value="2" meta:resourcekey="ListItemResource32">R</asp:ListItem>
                                                                <asp:ListItem Value="3" meta:resourcekey="ListItemResource33">S</asp:ListItem>
                                                                <asp:ListItem Value="4" meta:resourcekey="ListItemResource34">T</asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: medium">
                                                            D-
                                                        </td>
                                                        <td style="width: 300px; text-align: center;">
                                                            <asp:CheckBoxList ID="ChkansMatD" runat="server" Font-Size="Medium" RepeatDirection="Horizontal"
                                                                meta:resourcekey="ChkansMatDResource1">
                                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource35">P</asp:ListItem>
                                                                <asp:ListItem Value="1" meta:resourcekey="ListItemResource36">Q</asp:ListItem>
                                                                <asp:ListItem Value="2" meta:resourcekey="ListItemResource37">R</asp:ListItem>
                                                                <asp:ListItem Value="3" meta:resourcekey="ListItemResource38">S</asp:ListItem>
                                                                <asp:ListItem Value="4" meta:resourcekey="ListItemResource39">T</asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px; text-align: center;">
                                            <asp:Label ID="lbllevel" runat="server" Font-Size="Large" ForeColor="#CC3300" Text="Level"
                                                meta:resourcekey="lbllevelResource1"></asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:RadioButtonList ID="rdoLevelList" runat="server" Font-Names="Arial" Font-Size="Small"
                                                RepeatDirection="Horizontal" ToolTip="Click to select level" Enabled="False"
                                                meta:resourcekey="rdoLevelListResource1">
                                                <asp:ListItem Value="1" meta:resourcekey="ListItemResource40">Level1</asp:ListItem>
                                                <asp:ListItem Value="2" meta:resourcekey="ListItemResource41">Level2</asp:ListItem>
                                                <asp:ListItem Value="3" meta:resourcekey="ListItemResource42">Level3</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAnsMatA" runat="server" Visible="False" Width="19px" meta:resourcekey="txtAnsMatAResource1"></asp:TextBox>
                                            <asp:TextBox ID="txtAnsMatB" runat="server" Visible="False" Width="19px" meta:resourcekey="txtAnsMatBResource1"></asp:TextBox>
                                            <asp:TextBox ID="txtAnsMatC" runat="server" Visible="False" Width="19px" meta:resourcekey="txtAnsMatCResource1"></asp:TextBox>
                                            <asp:TextBox ID="txtAnsMatD" runat="server" Visible="False" Width="19px" meta:resourcekey="txtAnsMatDResource1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px; text-align: center;">
                                            <asp:Label ID="lblQuesVerify" runat="server" Font-Size="Large" ForeColor="#CC3300"
                                                Text="Question Verify ?" meta:resourcekey="lblQuesVerifyResource1"></asp:Label>
                                        </td>
                                        <td colspan="2" align="left" style="width: 300px;">
                                            <asp:RadioButtonList ID="rdoQuesVerify" runat="server" Font-Size="Medium" RepeatDirection="Horizontal"
                                                meta:resourcekey="rdoQuesVerifyResource1">
                                                <asp:ListItem Value="0" meta:resourcekey="ListItemResource43">Correct</asp:ListItem>
                                                <asp:ListItem Value="1" meta:resourcekey="ListItemResource44">InCorrect</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="width: 84px; text-align: center; vertical-align: top;">
                                            &nbsp;<asp:Label ID="lblSuggest" runat="server" Font-Size="Large" ForeColor="#CC3300"
                                                Text="Suggestion" meta:resourcekey="lblSuggestResource1"></asp:Label>
                                        </td>
                                        <td colspan="2" align="left" style="width: 300px;">
                                            <asp:TextBox ID="txtSuggest" runat="server" Height="32px" TextMode="MultiLine" Width="233px"
                                                meta:resourcekey="txtSuggestResource1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center; height: 29px;">
                                            <asp:Label ID="lblt1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#009933"
                                                Text="lblt1 " Visible="False" meta:resourcekey="lblt1Resource1"></asp:Label>
                                        </td>
                                        <td colspan="2" style="text-align: center; height: 29px;">
                                            <asp:Label ID="lblt2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#009933"
                                                Text="lblt2 " Visible="False" meta:resourcekey="lblt2Resource1"></asp:Label>
                                        </td>
                                        <td colspan="2" style="text-align: center; height: 29px;">
                                            <asp:Label ID="lblt3" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#009933"
                                                Text="lblt3 " Visible="False" meta:resourcekey="lblt3Resource1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="text-align: center">
                                            &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                            <asp:CheckBox ID="chkAddQuestion" runat="server" AutoPostBack="True" BackColor="White"
                                                Font-Bold="True" Font-Italic="True" Font-Names="Times New Roman" Font-Overline="False"
                                                Font-Underline="False" ForeColor="Red" OnCheckedChanged="chkAddQuestion_CheckedChanged"
                                                Text="Add Question " meta:resourcekey="chkAddQuestionResource1" />
                                            &nbsp;&nbsp; &nbsp;&nbsp;
                                            <asp:TextBox ID="txtGotoQues" runat="server" Width="50px" onkeypress="return numbersonly(this,event)"
                                                meta:resourcekey="txtGotoQuesResource1"></asp:TextBox>
                                            &nbsp;<asp:Button ID="btnGotoQues" runat="server" Height="30px" OnClick="btnGotoQues_Click"
                                                Text="Go to Question No." Width="118px" meta:resourcekey="btnGotoQuesResource1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="text-align: center">
                                            <asp:Button ID="btnBack" runat="server" Height="39px" OnClick="btnBack_Click" Text="Back"
                                                Width="71px" CssClass="btn" Font-Size="Small" meta:resourcekey="btnBackResource1" />
                                            &nbsp;<asp:Button ID="btnNext" runat="server" Height="39px" OnClick="btnNext_Click"
                                                Text="Next" Width="71px" CssClass="btn" Font-Size="Small" meta:resourcekey="btnNextResource1" />
                                            &nbsp;<asp:Button ID="btnSubmit" runat="server" Height="39px" Text="Add " Width="71px"
                                                OnClick="btnSubmit_Click" CssClass="btn" Font-Size="Small" meta:resourcekey="btnSubmitResource1" />
                                            &nbsp;<asp:Button ID="btnUpdate" runat="server" CssClass="btn" Height="39px" OnClick="btnUpdate_Click"
                                                Text="Update" Width="74px" Font-Size="Small" meta:resourcekey="btnUpdateResource1" />
                                            &nbsp;
                                        </td>
                                        <td colspan="2" style="text-align: left">
                                            <asp:Button ID="btnPrint" runat="server" Height="31px" Text="Print Question" Width="89px"
                                                OnClick="btnPrint_Click" meta:resourcekey="btnPrintResource1" />
                                            <asp:Button ID="btnInsturc" runat="server" Height="31px" Text="Print Instruction"
                                                Width="94px" OnClick="btnInsturc_Click" meta:resourcekey="btnInsturcResource1" />
                                            <asp:Button ID="btnBack1" runat="server" CssClass="btn" Height="31px" OnClick="btnBack1_Click"
                                                Text="Back" Width="61px" ToolTip="Back to Setting Page" Visible="False" meta:resourcekey="btnBack1Resource1" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnSubmit" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:View>
        </asp:MultiView></div>
</asp:Content>
