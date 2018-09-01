<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="TestDefinition.aspx.cs" Inherits="TestDefinition" Title="eZeeTest:Test Definition" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../resources/JScript/jquery-1.11.1.js" type="text/javascript"></script>

    <script src="../resources/JScript/popup.js" type="text/javascript"></script>

    <script src="../resources/JScript/jquery-ui.js" type="text/javascript"></script>

    <script type="text/javascript">
        function toTop(id) {
            document.getElementById(id).scrollTop = 0
        }


    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:LinkButton ID="lnkbtnBackToPanel" runat="server" Text="<<< Back To Panel" Visible="false"
                Font-Bold="true" ForeColor="HighlightText" PostBackUrl="~/CreateTest/createtest.aspx"></asp:LinkButton>
            <div style="width: 100%;" align="center">
                &nbsp;<table cellpadding="0" cellspacing="0" width="80%" border="1">
                    <tr>
                        <td align="center">
                            <div id="div" style="width: 100%; margin-right: 7px;">
                                <table cellpadding="0" cellspacing="0" border="0" width="70%" class="tables">
                                    <div style="width: 96%">
                                        <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                            <tr>
                                                <td style="height: 20px;">
                                                    <table style="width: 81%; margin-left: 148px;" class="tables" cellspacing="2" cellpadding="2">
                                                        <tr>
                                                            <td colspan="2" align="center" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                                <h3 style="color: Green">Test Definition</h3>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="4" style="text-align: left">&nbsp;&nbsp;<asp:Label ID="lblError" Visible="False" runat="server" CssClass="error"
                                                                Text="Label" Font-Size="Medium" ForeColor="Red"></asp:Label><asp:Label ID="lblSuccess"
                                                                    runat="server" CssClass="error" Visible="False" Font-Size="Medium"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 628px; text-align: left;">
                                                                <asp:Label ID="lblGroupOFQues" runat="server" Font-Bold="False" Font-Names="Arial"
                                                                    Font-Size="11pt" Text="Select Group of Questions"></asp:Label>
                                                                <span class="warning1" style="color: Red;">*&nbsp;</span>
                                                            </td>
                                                            <td style="height: 31px; width: 200px;">
                                                                <asp:RadioButtonList ID="rdoGroupOFQues" runat="server" AutoPostBack="True" CssClass="radio"
                                                                    Font-Size="Medium" RepeatDirection="Vertical" Width="203px" OnSelectedIndexChanged="rdoGroupOFQues_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">Objective Question</asp:ListItem>
                                                                    <asp:ListItem Value="1">Theory Question</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td class="error" style="height: 29px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rdoGroupOFQues"
                                                                    ErrorMessage="You have not selected Group of Questions" Font-Size="Small" SetFocusOnError="True"
                                                                    ValidationGroup="other" Width="225px"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 276px; text-align: left;">
                                                                <asp:Label ID="lblTestName" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Name of Test :"></asp:Label>&nbsp;<span class="warning1" style="color: Red;">*</span>
                                                            </td>
                                                            <td align="left" style="width: 34%; text-align: left;">
                                                                <asp:TextBox ID="txtTestName" runat="server" CssClass="txthiwidth" Height="36px"
                                                                    TextMode="MultiLine" Width="213px"></asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                    TargetControlID="txtExamDate">
                                                                </asp:CalendarExtender>
                                                            </td>
                                                            <td align="left" style="width: 18%; text-align: left;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtExamDate"
                                                                    SetFocusOnError="True" Width="161px" ErrorMessage="Enter Test Name" ValidationGroup="other"
                                                                    Font-Size="Medium"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 276px; text-align: left;">
                                                                <asp:Label ID="lblExamdate" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Date of exam :"></asp:Label>&nbsp;<span class="warning1" style="color: Red;">*</span>
                                                            </td>
                                                            <td align="left" style="width: 34%; text-align: left;">
                                                                <asp:TextBox ID="txtExamDate" runat="server" CssClass="txtcss" Enabled="false"></asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                    PopupButtonID="imgFromDate" TargetControlID="txtExamDate">
                                                                </asp:CalendarExtender>
                                                                <img id="imgFromDate" align="middle" alt="ezeesofts &amp; Co." border="0" height="24"
                                                                    src="../resources/images/calendarclick.gif" />
                                                            </td>
                                                            <td align="left" style="width: 18%; text-align: left;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtExamDate"
                                                                    SetFocusOnError="True" Width="161px" ErrorMessage="select Exam Date." ValidationGroup="other"
                                                                    Font-Size="Medium"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 276px; text-align: left;">
                                                                <asp:Label ID="lblExamduration" runat="server" Font-Bold="False" Font-Names="Arial"
                                                                    Font-Size="11pt" Text="Duration of Exam  :"></asp:Label>
                                                                &nbsp;<span class="warning1" style="color: Red;">*</span>&nbsp;
                                                            </td>
                                                            <td align="left" style="width: 34%; text-align: left;">
                                                                <asp:TextBox ID="txtExamduration" runat="server" CssClass="txthiwidth" MaxLength="3"
                                                                    onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                                <asp:Label ID="lblError0" runat="server" Font-Size="Medium" Text="Min"></asp:Label>
                                                            </td>
                                                            <td align="left" style="width: 18%; text-align: left;">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 276px; text-align: left;">
                                                                <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select Medium  Name"></asp:Label>
                                                                &nbsp;<span class="warning1" style="color: Red;">*</span>
                                                            </td>
                                                            <td style="height: 31px; width: 34%;">
                                                                <asp:DropDownList ID="ddlMedium" runat="server" CssClass="ddlcsswidth ">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">English</asp:ListItem>
                                                                    <asp:ListItem Value="2">Semi-English</asp:ListItem>
                                                                    <asp:ListItem Value="3">Marathi</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <br />
                                                            </td>
                                                            <td class="error" style="height: 29px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlMedium"
                                                                    ErrorMessage="Please  selected Medium name" SetFocusOnError="True" Width="225px"
                                                                    ValidationGroup="other" Font-Size="Medium"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 628px; text-align: left;">
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
                                                        <%-- Newly Added Rows--%>
                                                        <tr>
                                                            <td style="width: 628px; text-align: left;">
                                                                <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select Type of Exam"></asp:Label><span class="warning1" style="color: Red">*</span>
                                                            </td>
                                                            <td style="width: 100px; height: 31px;">
                                                                <asp:DropDownList ID="ddlGroupofExam" runat="server" CssClass="ddlcsswidth " Height="22px"
                                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlGroupofExam_SelectedIndexChanged1">
                                                                </asp:DropDownList>
                                                                <br />
                                                            </td>
                                                            <td class="error" style="height: 29px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlGroupofExam"
                                                                    InitialValue="1" ErrorMessage="You have not selected Type of Exam" SetFocusOnError="True"
                                                                    Width="225px" ValidationGroup="other" Enabled="False" Font-Size="Small"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <%-- Newly Added Rows--%>
                                                        <tr>
                                                            <td style="width: 628px; text-align: left;">
                                                                <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select ExamName"></asp:Label>
                                                                &nbsp;<asp:Label ID="Label10" runat="server" Font-Bold="False" Font-Names="Arial"
                                                                    Font-Size="14pt" Text="*" ForeColor="Red" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="width: 100px; height: 31px;">
                                                                <asp:DropDownList ID="ddlTypeofExam" runat="server" CssClass="ddlcsswidth " Height="22px"
                                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlTypeofExam_SelectedIndexChanged1">
                                                                    <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <br />
                                                            </td>
                                                            <td class="error" style="height: 29px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlTypeofExam"
                                                                    InitialValue="1" ErrorMessage="You have not selected Type of Exam" SetFocusOnError="True"
                                                                    Width="225px" ValidationGroup="other" Enabled="False" Font-Size="Small"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 628px; text-align: left;">
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
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlAddClass"
                                                                    InitialValue="1" ErrorMessage="You have not selected Class" SetFocusOnError="True"
                                                                    Width="225px" ValidationGroup="other" Enabled="False" Font-Size="Small"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 628px; text-align: left;">
                                                                <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                                    Text="Select Subject" Width="100px"></asp:Label>
                                                                <span class="warning1" style="color: Red;">*</span>&nbsp;
                                                            </td>
                                                            <td style="height: 31px; width: 200px;">
                                                                <div class="container">
                                                                    <asp:CheckBoxList ID="chkSubject" runat="server" Font-Size="Medium">
                                                                    </asp:CheckBoxList>
                                                                    <br />
                                                                </div>
                                                            </td>
                                                        </tr>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 276px; height: 20px; text-align: left;">
                                                    <asp:Label ID="lblMarkcorrAns" runat="server" Font-Bold="False" Font-Names="Arial"
                                                        Font-Size="11pt" Text="Marks For Correct Ans :"></asp:Label>
                                                    &nbsp;<span class="warning1" style="color: Red;">*</span>
                                                </td>
                                                <td align="left" style="width: 34%; height: 20px; text-align: left;">
                                                    <asp:TextBox ID="txtmarkCorrect" runat="server" CssClass="txtcss" MaxLength="3" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 30%; height: 20px;">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 276px; height: 36px; text-align: left;">
                                                    <asp:Label ID="lblmarkpassing" runat="server" Font-Bold="False" Font-Names="Arial"
                                                        Font-Size="11pt" Text="Marks For Passing:"></asp:Label>
                                                    &nbsp;<span class="warning1" style="color: Red;">*</span>
                                                </td>
                                                <td align="left" style="width: 34%; height: 36px; text-align: left;">
                                                    <asp:TextBox ID="txtmarkPassing" runat="server" CssClass="txtcss" MaxLength="3" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 30%; height: 36px;">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 276px; text-align: left;">
                                                    <asp:Label ID="lblRetakeallow" runat="server" Font-Bold="False" Font-Names="Arial"
                                                        Font-Size="11pt" Text="Retake Allowed :"></asp:Label>&nbsp;
                                                </td>
                                                <td align="left" style="width: 34%; text-align: left;">
                                                    <asp:RadioButtonList ID="rdoRetake" runat="server" EnableTheming="True" Style="font-family: 'Times New Roman', Times, serif"
                                                        Height="28px" Width="121px" RepeatDirection="Horizontal" Font-Size="Medium">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 276px; text-align: left;">
                                                    <asp:Label ID="lblBreakallow" runat="server" Font-Bold="False" Font-Names="Arial"
                                                        Font-Size="11pt" Text="Break Allowed :"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 34%; text-align: left;">
                                                    <asp:RadioButtonList ID="rdoBreakAllow" runat="server" EnableTheming="True" Style="font-family: 'Times New Roman', Times, serif"
                                                        Height="28px" Width="121px" RepeatDirection="Horizontal" Font-Size="Medium">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 276px; text-align: left;">
                                                    <asp:Label ID="lblReverseNavig" runat="server" Font-Bold="False" Font-Names="Arial"
                                                        Font-Size="11pt" Text="Reverse Navigation :"></asp:Label>&nbsp;<span class="warning1"
                                                            style="color: Red;">*</span>
                                                </td>
                                                <td align="left" style="width: 34%; text-align: left;">
                                                    <asp:RadioButtonList ID="rdoReverseNavigation" runat="server" EnableTheming="True"
                                                        Style="font-family: 'Times New Roman', Times, serif" Height="28px" Width="121px"
                                                        RepeatDirection="Horizontal" Font-Size="Medium">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td align="left" style="width: 18%; text-align: left;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="rdoReverseNavigation"
                                                        SetFocusOnError="True" Width="161px" ErrorMessage="Select Reverse Navigation"
                                                        ValidationGroup="other" Font-Size="Medium"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 276px; text-align: left;">
                                                    <asp:Label ID="lblNegativemark" runat="server" Font-Bold="False" Font-Names="Arial"
                                                        Font-Size="11pt" Text="Negative Marking :"></asp:Label>&nbsp;<span class="warning1"
                                                            style="color: Red;">*</span>
                                                </td>
                                                <td align="left" style="width: 34%; text-align: left;">
                                                    <asp:RadioButtonList ID="rdoNegativeMark" runat="server" EnableTheming="True" Style="font-family: 'Times New Roman', Times, serif"
                                                        Height="28px" Width="121px" RepeatDirection="Horizontal" Font-Size="Medium" OnSelectedIndexChanged="rdoNegativeMark_SelectedIndexChanged"
                                                        AutoPostBack="True">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td align="left" style="width: 18%; text-align: left;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="rdoNegativeMark"
                                                        SetFocusOnError="True" Width="161px" ErrorMessage="Select Negative Marking" ValidationGroup="other"
                                                        Font-Size="Medium"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 276px; height: 36px; text-align: left;">
                                                    <asp:Label ID="lblIfYes" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="If Yes:"></asp:Label>
                                                    &nbsp;<span class="warning1" style="color: Red;">*</span>
                                                </td>
                                                <td align="left" style="width: 34%; height: 36px; text-align: left;">
                                                    <asp:TextBox ID="txtSelectMarkforNege" runat="server" CssClass="txthiwidth" MaxLength="4"
                                                        onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 30%; height: 36px;">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 276px; height: 36px; text-align: left;">
                                                    <asp:Label ID="lblTestType" runat="server" Font-Size="11pt" Font-Names="Arial" Text="Select Test Type"></asp:Label>
                                                    &nbsp;<span class="warning1" style="color: Red;">*</span>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTestType" runat="server">
                                                        <asp:ListItem Value="0">Free Test</asp:ListItem>
                                                        <asp:ListItem Value="1">Premium Test</asp:ListItem>
                                                        <asp:ListItem Value="2">Pro Test</asp:ListItem>
                                                        <asp:ListItem Value="3">Pro-Plus Test</asp:ListItem>
                                                        <asp:ListItem Value="4">Model Test</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 276px; height: 36px; text-align: left;">
                                                    <asp:Label ID="lblIndexNo" runat="server" Font-Size="11pt" Font-Names="Arial" Text="Enter Sequnce No."></asp:Label>
                                                </td>
                                                <td align="left" style="width: 34%; height: 36px; text-align: left;">
                                                    <asp:TextBox ID="txtIndexNo" runat="server" CssClass="txtcss" MaxLength="4" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnUpdateSeqNo" runat="server" Text="Update SeqNo" OnClick="btnUpdateSeqNo_Click"
                                                        Visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 276px; text-align: left;"></td>
                                                <td align="left" style="width: 34%; text-align: left;">
                                                    <asp:Label ID="lblNoofQue" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="11pt"
                                                        Font-Underline="True" Text="Number of Questions :" Width="171px"></asp:Label>
                                                    <br />
                                                </td>
                                                <td align="left" style="width: 18%;">
                                                    <asp:Label ID="lblSubjectID" runat="server" Font-Bold="False" Font-Names="Arial"
                                                        Font-Size="11pt" Text="subjectID" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 276px; text-align: left;" rowspan="3"></td>
                                                <td align="left" style="width: 34%;">
                                                    <asp:Label ID="lblLabel1" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Level1" Width="56px"></asp:Label>
                                                    <asp:TextBox ID="txtLevel1" runat="server" Height="25px" Width="54px" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 34%;">
                                                    <asp:Label ID="Level2" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Level2" Width="56px"></asp:Label>
                                                    <asp:TextBox ID="txtLevel2" runat="server" Height="25px" Width="54px" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 34%;">
                                                    <asp:Label ID="Level3" runat="server" Width="56px" Font-Bold="False" Font-Names="Arial"
                                                        Font-Size="11pt" Text="Level3"></asp:Label>
                                                    <asp:TextBox ID="txtLevel3" runat="server" Height="25px" Width="54px" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 276px;"></td>
                                                <td colspan="2" align="right" style="padding-right: 20px; text-align: left;">
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" ValidationGroup="other"
                                                        OnClick="btnSave_Click" Width="58px" />
                                                    &nbsp;<asp:Button ID="btncancel" runat="server" CssClass="btn" Text="Cancel" OnClick="btncancel_Click" />
                                                    &nbsp;
                                                    <asp:Button ID="btnback" runat="server" CssClass="btn" PostBackUrl="~/Admin/Home.aspx"
                                                        Text="Back" OnClick="btnback_Click" />
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="grid" style="width: 100%">
                                            <div class="rounded">
                                                <div class="top-outer">
                                                    <div class="top-inner">
                                                        <div class="top">
                                                            &nbsp;
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="mid-outer">
                                                    <div class="mid-inner">
                                                        <div class="mid">
                                                            <div class="pager">
                                                                <asp:GridView ID="gvState" runat="server" CssClass="datatable" OnRowCommand="gvState_RowCommand"
                                                                    OnPageIndexChanging="gvState_PageIndexChanging" CellPadding="5" GridLines="None"
                                                                    AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="Test Defination List is not available."
                                                                    PageSize="10" OnPageIndexChanged="gvState_PageIndexChanged" OnRowDeleting="gvState_RowDeleting"
                                                                    OnRowUpdating="gvState_RowUpdating" AllowSorting="true" OnRowDataBound="gvState_RowDataBound"
                                                                    OnSorting="gvState_Sorting">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id">
                                                                            <HeaderStyle HorizontalAlign="Center" Width=""></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center" Width=""></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Exam_name" HeaderText="Exam Name">
                                                                            <HeaderStyle HorizontalAlign="Center" Width=""></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center" Width=""></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Exam_date" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy}">
                                                                            <HeaderStyle HorizontalAlign="center" Width=""></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="center" Width=""></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="TypeofMaterial" HeaderText="Type of Material">
                                                                            <HeaderStyle HorizontalAlign="left" Width=""></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width=""></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="SubjectName" HeaderText="Subject">
                                                                            <HeaderStyle HorizontalAlign="left" Width=""></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width=""></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Class_id" HeaderText="Class">
                                                                            <HeaderStyle HorizontalAlign="Center" Width=""></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center" Width=""></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="TypeOFExam" HeaderText="Type Of Exam">
                                                                            <HeaderStyle HorizontalAlign="left" Width=""></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width=""></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="MediumID" HeaderText="Medium">
                                                                            <HeaderStyle HorizontalAlign="Center" Width=""></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center" Width=""></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Exam_Duration" HeaderText="Duration">
                                                                            <HeaderStyle HorizontalAlign="Center" Width=""></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center" Width=""></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DLevel1" HeaderText="Level1">
                                                                            <HeaderStyle HorizontalAlign="Center" Width=""></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center" Width=""></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DLevel2" HeaderText="Level2">
                                                                            <HeaderStyle HorizontalAlign="Center" Width=""></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center" Width=""></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DLevel3" HeaderText="Level3">
                                                                            <HeaderStyle HorizontalAlign="Center" Width=""></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center" Width=""></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <%--<asp:BoundField DataField="column" HeaderText="Test Expire Days" ItemStyle-ForeColor="Red">
                                                                            <HeaderStyle HorizontalAlign="left" Width=""></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width=""></ItemStyle>
                                                                        </asp:BoundField>--%>
                                                                        <asp:TemplateField Visible="false" HeaderText="Assign Test">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("Id") %>' runat="server"
                                                                                    ImageUrl="../resources/images/ico_yes1.gif" CommandName="Assign"></asp:ImageButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Modify">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("Id")%>' runat="server"
                                                                                    ImageUrl="../resources/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                        </asp:TemplateField>
                                                                        <%--<asp:TemplateField HeaderText="SeqNo">
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImageButton4" CommandArgument='<%#Bind("Id")%>' runat="server"
                                                                                    ImageUrl="../resources/images/ico_yes1.gif" CommandName="ModifySeqNo"></asp:ImageButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Delete">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImageButton3" CommandArgument='<%#Bind("Id")%>' runat="server"
                                                                                    OnClientClick="if(!confirm(' Are you sure you want delete All Question related to this Test Name ?')) return false;"
                                                                                    ImageUrl="../resources/images/close.gif" CommandName="Delete"></asp:ImageButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <PagerStyle CssClass="pager-row" />
                                                                </asp:GridView>
                                                                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="bottom-outer">
                                                    <div class="bottom-inner">
                                                        <div class="bottom">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                        </td>
                    </tr>
                </table>
                </td></tr></table> </table>
            </div>
            <asp:LinkButton ID="lnkbtnTop" Text="Go To Top" OnClientClick="toTop('UpdatePanel1')"
                runat="server" Font-Bold="true" Style="border: 1px Solid red; background-color: Yellow; margin-left: 10px;"
                ForeColor="HighlightText"></asp:LinkButton>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
