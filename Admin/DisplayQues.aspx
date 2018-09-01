<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="DisplayQues.aspx.cs" Inherits="Admin_DisplayQues" Title="Check Questions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .protected {
            -moz-user-select: none;
            -webkit-user-select: none;
            user-select: none;
        }

        .style2 {
            width: 103px;
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
        element.onmousedown = function () { return false; }        // For Mozilla Browser
    </script>

    <script language="javascript" type="text/javascript">
        function check(checkbox) {
            var cbl = document.getElementById('<%=ddlChapter.ClientID %>').getElementsByTagName("input");
            for (i = 0; i < cbl.length; i++)
                cbl[i].checked = checkbox.checked;
        }

    </script>

    <script type="text/javascript" language="javascript">
        function validatecheck(CheckBoxList) {
            try {
                var atleast = 1;
                var counter = 0;


                var chk = document.getElementById('<%=ddlChapter.ClientID%>');
                var checkboxlist = chk.getElementsByTagName("Input");

                for (var i = 0; i < checkboxlist.length; i++) {
                    if (checkboxlist[i].checked) {
                        counter++;
                    }
                }

                if (atleast > counter) {
                    alert('Please select atleast One Chapter !!! ');
                    return false;
                }
            }
            catch (Error) {
                alert('Please select atleast One Chapter !!! ');
                return false;
            }
        }
    </script>

    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <asp:UpdatePanel ID="updatePane2" runat="server">
                <ContentTemplate>
                    <div style="width: 100%;" align="center">
                        <div style="width: 95%; color: #000000;">
                            <table cellpadding="0" cellspacing="0" width="90%">
                                <%--<td align="center">--%>
                                <div style="width: 100%">
                                    <table cellpadding="0" cellspacing="0" width="75%" class="tables" border="1">
                                        <tr>
                                            <%--<td width="200px"></td>--%>
                                            <td colspan="2" style="height: 20px;">
                                                <center>
                                                    <table style="width: 75%; font-family: 'Times New Roman', Times, serif; font-size: medium;"
                                                        class="tables" cellspacing="7px">
                                                        <tr>
                                                            <td></td>
                                                            <td style="text-align: center;" colspan="2" align="center" style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                                <h2 style="color: Green; text-align: center;">Question For Checking</h2>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td class="error" colspan="3" width="200px">
                                                                <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="text-align: left;" width="200px">
                                                                <asp:Label ID="lblTypeofMaterial" runat="server" Font-Bold="False" Font-Names="Arial"
                                                                    Font-Size="11pt" Text="Select Type of Material"></asp:Label>
                                                                <span class="warning1" style="color: Red;">*&nbsp;</span>
                                                            </td>
                                                            <td style="height: 31px; width: 200px;">
                                                                <asp:RadioButtonList ID="rdoTypeofMaterial" runat="server" AutoPostBack="True" CssClass="radio"
                                                                    Font-Size="Medium" OnSelectedIndexChanged="rdoTypeofMaterial_SelectedIndexChanged"
                                                                    RepeatDirection="Horizontal" Width="203px">
                                                                    <asp:ListItem Value="0">Class</asp:ListItem>
                                                                    <asp:ListItem Value="1">Competitive Exam</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td class="error" style="height: 29px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="rdoTypeofMaterial"
                                                                    ErrorMessage="You have not selected Type of Material" Font-Size="Small" SetFocusOnError="True"
                                                                    ValidationGroup="other" Width="225px"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <%--New Row Added--%>
                                                        <tr>
                                                            <td width="200px"></td>
                                                            <td style="text-align: left;">
                                                                <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select Type of Exam"></asp:Label><span class="warning1" style="color: Red; font-style: normal">*&nbsp;</span>
                                                            </td>
                                                            <td style="width: 100px; height: 31px;">
                                                                <asp:DropDownList ID="ddlGroupofExam" runat="server" CssClass="ddlcsswidth " AutoPostBack="true"
                                                                    Height="22px" OnSelectedIndexChanged="ddlGroupofExam_SelectedIndexChanged">
                                                                    <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <br />
                                                            </td>
                                                            <td class="error">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlGroupofExam"
                                                                    InitialValue="1" ErrorMessage="You have not selected Type of Exam" SetFocusOnError="True"
                                                                    Width="225px" ValidationGroup="other" Enabled="False" Font-Size="Small"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <%--New Row Added--%>
                                                        <tr>
                                                            <td width="200px"></td>
                                                            <td style="text-align: left;">
                                                                <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select ExamName"></asp:Label>
                                                                &nbsp;<asp:Label ID="Label10" runat="server" Font-Bold="False" Font-Names="Arial"
                                                                    Font-Size="14pt" Text="*" ForeColor="Red" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="width: 100px; height: 31px;">
                                                                <asp:DropDownList ID="ddlTypeofExam" runat="server" CssClass="ddlcsswidth " AutoPostBack="true"
                                                                    Height="22px" OnSelectedIndexChanged="ddlTypeofExam_SelectedIndexChanged">
                                                                    <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <br />
                                                            </td>
                                                            <td class="error">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlTypeofExam"
                                                                    InitialValue="1" ErrorMessage="You have not selected Type of Exam" SetFocusOnError="True"
                                                                    Width="225px" ValidationGroup="other" Enabled="False" Font-Size="Small"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="text-align: left;">
                                                                <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select Class Name"></asp:Label>
                                                                <asp:Label ID="Label11" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="14pt"
                                                                    Text="*" ForeColor="Red" Visible="False"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                            <td style="height: 31px; width: 200px;">
                                                                <asp:DropDownList ID="ddlAddClass" runat="server" CssClass="ddlcsswidth " AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddlAddClass_SelectedIndexChanged">
                                                                    <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <br />
                                                            </td>
                                                            <td class="error" style="height: 29px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlAddClass"
                                                                    InitialValue="1" ErrorMessage="You have not selected Class" SetFocusOnError="True"
                                                                    Width="225px" ValidationGroup="other" Enabled="False" Font-Size="Small"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="text-align: left;">
                                                                <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select Subject" Width="100px"></asp:Label>
                                                                <span class="warning1" style="color: Red;">*</span>&nbsp;
                                                            </td>
                                                            <td style="height: 31px; width: 200px;">
                                                                <asp:DropDownList ID="cmbSelectsubject" runat="server" CssClass="ddlcsswidth " OnSelectedIndexChanged="cmbSelectsubject_SelectedIndexChanged"
                                                                    AutoPostBack="true">
                                                                    <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <br />
                                                            </td>
                                                            <td class="error" style="height: 29px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbSelectsubject"
                                                                    ErrorMessage="You have not selected Subject" SetFocusOnError="True" Width="225px"
                                                                    ValidationGroup="other" InitialValue="1" Font-Size="Small" Enabled="True"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="1"></td>
                                                            <td style="text-align: left;">
                                                                <asp:Label ID="lblMedium" runat="server" Font-Bold="false" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select Medium" Width="170px"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlMedium" runat="server" CssClass="ddlcsswidth " OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">English</asp:ListItem>
                                                                    <asp:ListItem Value="2">Semi-English</asp:ListItem>
                                                                    <asp:ListItem Value="3">Marathi</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td colspan="1"></td>
                                                            <td style="text-align: left;">
                                                                <asp:Label ID="lblchaptername" runat="server" Font-Bold="false" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select Chapter" Width="170px"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlTopik" runat="server" CssClass="ddlcsswidth " AutoPostBack="true" OnSelectedIndexChanged="ddlTopik_SelectedIndexChanged">
                                                                    <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="error" style="height: 29px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTopik"
                                                                    ErrorMessage="You have not selected Any Chapter" SetFocusOnError="True" Width="225px"
                                                                    ValidationGroup="other" InitialValue="1" Font-Size="Small" Enabled="True"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td></td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select Topic" Width="150px"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                            <td style="height: 31px; width: 200px;">
                                                                <div class="container">
                                                                    <asp:CheckBox ID="ChkSelectALL" runat="server" OnClick="check(this)" Text="Select ALL Topic"
                                                                        Visible="False" />
                                                                    <%--OnClick="check(this)"--%>
                                                                    <asp:CheckBoxList ID="ddlChapter" runat="server" RepeatColumns="1" BorderWidth="0px"
                                                                        Datafield="description" DataValueField="value" OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged">
                                                                    </asp:CheckBoxList>
                                                                </div>
                                                            </td>
                                                            <td class="error" style="height: 29px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="text-align: center;">&nbsp;
                                                            </td>
                                                            <td style="text-align: left">&nbsp;
                                                            </td>
                                                            <td style="text-align: left">&nbsp;&nbsp;<br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td class="style2">&nbsp;
                                                            </td>
                                                            <td style="text-align: left" colspan="3">&nbsp;<asp:Button ID="btnStart" runat="server" CssClass="btn" OnClick="btnStart_Click1"
                                                                OnClientClick="return validatecheck()" Text="View Question" ToolTip="Click here to start the test"
                                                                ValidationGroup="other" />
                                                                &nbsp;
                                                                <asp:Button ID="btnCancel" runat="server" CssClass="btn" Text="Cancel" ToolTip="Click here to Cancel"
                                                                    CausesValidation="false" OnClick="btnCancel_Click" />
                                                                &nbsp;&nbsp;&nbsp;
                                                            </td>
                                                            <td class="error">&nbsp;
                                                            </td>
                                                            <td style="text-align: left"></td>
                                                            <td class="error">&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </center>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </table>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnStart" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div style="width: 100%; font-family: Times New Roman" align="center">
                        <table cellpadding="0" cellspacing="0" width="70%" bgcolor="White">
                            <div style="width: 80%">
                                <table style="width: 91%" cellspacing="7px" bgcolor="White">
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
                                            <asp:DropDownList ID="ddlhint" runat="server" OnSelectedIndexChanged="ddlhint_SelectedIndexChanged"
                                                AutoPostBack="True">
                                                <asp:ListItem Value="0">English</asp:ListItem>
                                                <asp:ListItem Value="1">Marathi</asp:ListItem>
                                                <asp:ListItem Value="3">MarathiMangal</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td colspan="4" align="left">
                                            <asp:TextBox ID="txtHint" runat="server" Height="32px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                            <asp:Image ID="imgHint" runat="server" />
                                            <asp:Image ID="imgHint2" runat="server" />
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnUpdateHint" runat="server" Text="Update Hint" Font-Bold="true"
                                                OnClick="btnUpdateHint_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px; text-align: center;" bgcolor="White">
                                            <asp:Label ID="lblAns" runat="server" Text="Answer" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                        </td>
                                        <td colspan="3" align="left">
                                            <asp:RadioButtonList ID="rdoAnswerlist" runat="server" Font-Size="Medium" RepeatDirection="Horizontal"
                                                Visible="False">
                                                <asp:ListItem Value="0">A</asp:ListItem>
                                                <asp:ListItem Value="1">B</asp:ListItem>
                                                <asp:ListItem Value="2">C</asp:ListItem>
                                                <asp:ListItem Value="3">D</asp:ListItem>
                                                <asp:ListItem Value="4">E</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:TextBox ID="txtAns" runat="server" MaxLength="15" Visible="False" Width="158px"></asp:TextBox>
                                            <asp:CheckBoxList ID="chkAnslist" runat="server" Font-Size="Medium" RepeatDirection="Horizontal"
                                                Visible="False" OnSelectedIndexChanged="chkAnslist_SelectedIndexChanged">
                                                <asp:ListItem Value="0">A</asp:ListItem>
                                                <asp:ListItem Value="1">B</asp:ListItem>
                                                <asp:ListItem Value="2">C</asp:ListItem>
                                                <asp:ListItem Value="3">D</asp:ListItem>
                                                <asp:ListItem Value="4">E</asp:ListItem>
                                            </asp:CheckBoxList>
                                            <asp:Panel ID="pnlAnsMat" runat="server" Visible="False" Height="110px" Width="305px">
                                                <table>
                                                    <tr>
                                                        <td style="font-size: medium">A-
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
                                                        <td style="font-size: medium" bgcolor="White">B-
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
                                                        <td style="font-size: medium">C-
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
                                                        <td style="font-size: medium">D-
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
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtAnsMatA" runat="server" Visible="False" Width="39px"></asp:TextBox>
                                                <asp:TextBox ID="txtAnsMatB" runat="server" Visible="False" Width="39px"></asp:TextBox>
                                                <asp:TextBox ID="txtAnsMatC" runat="server" Visible="False" Width="39px"></asp:TextBox>
                                                <asp:TextBox ID="txtAnsMatD" runat="server" Visible="False" Width="39px"></asp:TextBox>
                                            </td>
                                            <td colspan="4" style="text-align: center">
                                                <asp:Button ID="btnBack" runat="server" Height="39px" OnClick="btnBack_Click" Text="Back"
                                                    Width="71px" />
                                                &nbsp;<asp:Button ID="btnUpdate" runat="server" Height="39px" Text="Update" OnClick="btnUpdate_Click"
                                                    Width="74px" />
                                                &nbsp;<asp:Button ID="btnNext" runat="server" Height="39px" OnClick="btnNext_Click"
                                                    Text="Next" Width="71px" />
                                                &nbsp;&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="txtGotoQues" runat="server" Width="50px"></asp:TextBox>
                                                <asp:Button ID="btnGotoQues" runat="server" Height="30px" Text="Go to Question No."
                                                    Width="118px" OnClick="btnGotoQues_Click" />
                                                <br />
                                            </td>
                                        </tr>
                                    </tr>
                                </table>
                            </div>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:View>
    </asp:MultiView>
</asp:Content>
