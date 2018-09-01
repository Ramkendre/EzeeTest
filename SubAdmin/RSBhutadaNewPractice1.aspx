<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RSBhutadaNewPractice1.aspx.cs" Inherits="SubAdmin_RSBhutadaNewPractice1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
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

<script type="text/javascript">
    function showProgress() {
        var img = document.getElementById('imgLoad');
        img.style.visibility = "visible";
        return true;
    }
                                                    
</script>

<style type="text/css">
    .radio
    {
    }
    .select
    {
        position: absolute;
        width: 100%;
        height: 21px;
        padding: 0 24px 0 8px;
        font: 12px/21px arial,sans-serif;
        overflow: hidden;
    }
    .button
    {
        border-top: 1px solid #96d1f8;
        background: #040505;
        background: -webkit-gradient(linear, left top, left bottom, from(#bd402f), to(#040505));
        background: -webkit-linear-gradient(top, #bd402f, #040505);
        background: -moz-linear-gradient(top, #bd402f, #040505);
        background: -ms-linear-gradient(top, #bd402f, #040505);
        background: -o-linear-gradient(top, #bd402f, #040505);
        padding: 5px 10px;
        -webkit-border-radius: 8px;
        -moz-border-radius: 8px;
        border-radius: 8px;
        -webkit-box-shadow: rgba(0,0,0,1) 0 1px 0;
        -moz-box-shadow: rgba(0,0,0,1) 0 1px 0;
        box-shadow: rgba(0,0,0,1) 0 1px 0;
        text-shadow: rgba(0,0,0,.4) 0 1px 0;
        color: white;
        font-size: 19px;
        font-family: Georgia, Serif;
        text-decoration: none;
        vertical-align: middle;
    }
    .button:hover
    {
        border-top-color: #b32d2d;
        background: #b32d2d;
        color: #ccc;
    }
    .button:active
    {
        border-top-color: #1b435e;
        background: #1b435e;
    }
    .btnradius
    {
        border: 2px solid #a1a1a1;
        background-color: #4098d3;
        color: #fff;
        background-image: linear-gradient(0deg, rgba(255,255,255,0) 0%, rgba(255,255,255,0) 50%, rgba(255,255,255,0.5) 51%);
        border-radius: 5px;
    }
    
    </style>

<script type="text/javascript" language="javascript">
    function numbersonly(evt) {
        debugger;
        var charCode = (evt.fwhich) ? evt.which : event.keyCode;
        if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }
</script>

<head id="Head1" runat="server">
    <title>Exam Practice </title>
</head>
<body style="background-image: url(../resources/Image1/image11.jpg); background-position: center">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" width="70%" bgcolor="White">
                    <div style="width: 80%">
                        <table width="101%" height="100%" border="0">
                            <tr>
                                <td height="27" bgcolor="#091C5A">
                                    <div align="center">
                                        <marquee direction="Right" behavior="alternate" onmouseover="this.setAttribute('scrollamount', 0, 0);"
                                            onmouseout="this.setAttribute('scrollamount', 5, 0);">
                                        <font size="+1"><font color="#FFFFFF">Practice Examination </font>                                        
                                        </font>
                                        </marquee>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td height="500" valign="top">
                                    <div id="question_1">
                                        <br>
                                        <br>
                                        <blockquote>
                                            <table style="width: 91%" cellspacing="7px" bgcolor="White">
                                                <tr>
                                                    <td bgcolor="#F2CE6E" colspan="4" height="25">
                                                        <table border="0" height="25" width="100%">
                                                            <tr>
                                                                <td width="33%">
                                                                    <div align="center">
                                                                        <asp:Label ID="lblqn" runat="server" Font-Size="Large" Text="Q.No. :" BackColor="#009900"
                                                                            Height="23px" ForeColor="White" Font-Bold="True"></asp:Label>
                                                                        <asp:Label ID="lblQNo" runat="server" Font-Size="Large" Text="Q" BackColor="#009900"
                                                                            Height="23px" Width="45px" ForeColor="White" Font-Bold="True"></asp:Label>
                                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                        <asp:Label ID="lblQuestion_id" runat="server" Font-Bold="True" Font-Size="Medium"
                                                                            BackColor="#009900" Height="23px" ForeColor="White" Text="Question_id" Visible="False"></asp:Label>
                                                                </td>
                                                                <td width="33%">
                                                                    <div align="center">
                                                                        <asp:Label ID="lbltypeQues" runat="server" Font-Size="Medium" Text="Type of Ques"
                                                                            BackColor="#009900" Height="23px" ForeColor="White" Font-Bold="True"></asp:Label>
                                                                </td>
                                                                <td width="33%">
                                                                    <div align="center">
                                                                        <asp:Label ID="lblcount" runat="server" Font-Size="Medium" Text="count" BackColor="#009900"
                                                                            Height="23px" Width="250px" ForeColor="White" Font-Bold="True"></asp:Label>
                                                                        &nbsp;
                                                                        <asp:Label ID="lblMasterID" runat="server" Font-Bold="True" Font-Size="Medium" BackColor="#009900"
                                                                            Height="23px" ForeColor="White" Text="" Visible="true"></asp:Label>
                                                                        <asp:Label ID="lblSno" runat="server" Font-Bold="True" Font-Size="Medium" BackColor="#009900"
                                                                            Height="23px" ForeColor="White" Text="SNO" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 84px">
                                                        <asp:Label ID="lblpassage1" runat="server" Text="Passage" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                                    </td>
                                                    <td colspan="2" align="left">
                                                        <asp:Label ID="lblPassage" runat="server" Font-Size="Medium" Text="Passage"></asp:Label>
                                                        <asp:Image ID="imgPassage" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 84px">
                                                        <asp:Label ID="lblQues" runat="server" Text="Question" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                                    </td>
                                                    <td colspan="2" align="left">
                                                        <asp:Label ID="lblQuestion" runat="server" Font-Size="Medium" Text="Question"></asp:Label>
                                                        <asp:Image ID="imgQues" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 84px">
                                                        <asp:Label ID="QuestionImage" runat="server" Text="QuestionImage" Font-Size="Large"
                                                            ForeColor="#CC3300"></asp:Label>
                                                    </td>
                                                    <td colspan="2" align="left">
                                                        <asp:Label ID="lblQuestionwithImage" runat="server" Font-Size="Medium" Text="QuestionwithImage"></asp:Label>
                                                        <asp:Image ID="imgQuesImage" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 84px; text-align: center;">
                                                        <asp:Label ID="lblA" runat="server" Text="A" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <asp:Label ID="lblOptA" runat="server" Font-Size="Medium" Text="OptionA"></asp:Label>
                                                        <asp:Image ID="imgoptA" runat="server" />
                                                    </td>
                                                    <td style="width: 84px; text-align: center;">
                                                        <asp:Label ID="lblP" runat="server" Text="P" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <asp:Label ID="lblOptP" runat="server" Font-Size="Medium" Text="OptionP"></asp:Label>
                                                        <asp:Image ID="imgoptP" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 84px; text-align: center;">
                                                        <asp:Label ID="lblB" runat="server" Text="B" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <asp:Label ID="lblOptB" runat="server" Font-Size="Medium" Text="OptionB"></asp:Label>
                                                        <asp:Image ID="imgoptB" runat="server" />
                                                    </td>
                                                    <td style="width: 84px; text-align: center;">
                                                        <asp:Label ID="lblQ" runat="server" Text="Q" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <asp:Label ID="lblOptQ" runat="server" Font-Size="Medium" Text="OptionQ"></asp:Label>
                                                        <asp:Image ID="imgoptQ" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 84px; text-align: center;">
                                                        <asp:Label ID="lblC" runat="server" Text="C" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <asp:Label ID="lblOptC" runat="server" Font-Size="Medium" Text="OptionC"></asp:Label>
                                                        <asp:Image ID="imgoptC" runat="server" />
                                                    </td>
                                                    <td style="width: 84px; text-align: center;">
                                                        <asp:Label ID="lblR" runat="server" Text="R" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <asp:Label ID="lblOptR" runat="server" Font-Size="Medium" Text="OptionR"></asp:Label>
                                                        <asp:Image ID="imgoptR" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 84px; text-align: center;">
                                                        <asp:Label ID="lblD" runat="server" Text="D" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <asp:Label ID="lblOptD" runat="server" Font-Size="Medium" Text="OptionD"></asp:Label>
                                                        <asp:Image ID="imgoptD" runat="server" />
                                                    </td>
                                                    <td style="width: 84px; text-align: center;">
                                                        <asp:Label ID="lblS" runat="server" Text="S" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <asp:Label ID="lblOptS" runat="server" Font-Size="Medium" Text="OptionS"></asp:Label>
                                                        <asp:Image ID="imgoptS" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 84px; text-align: center;">
                                                        <asp:Label ID="lblE" runat="server" Text="E" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <asp:Label ID="lblOptE" runat="server" Font-Size="Medium" Text="OptionE"></asp:Label>
                                                        <asp:Image ID="imgoptE" runat="server" />
                                                    </td>
                                                    <td style="width: 84px; text-align: center;">
                                                        <asp:Label ID="lblT" runat="server" Text="T" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 300px">
                                                        <asp:Label ID="lblOptT" runat="server" Font-Size="Medium" Text="OptionT"></asp:Label>
                                                        <asp:Image ID="imgoptT" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 84px; text-align: center;">
                                                        <asp:Label ID="lblH" runat="server" Text="Hint" Font-Size="Large" ForeColor="#CC3300"
                                                            Visible="False"></asp:Label>
                                                        <br />
                                                        <asp:DropDownList ID="ddlhint" runat="server" AutoPostBack="True" Enabled="False"
                                                            Visible="False">
                                                            <asp:ListItem Value="0">English</asp:ListItem>
                                                            <asp:ListItem Value="1">Marathi</asp:ListItem>
                                                            <asp:ListItem Value="3">MarathiMangal</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td colspan="3" align="left">
                                                        <asp:Label ID="txtHint" runat="server" Text="Hint" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                                        <asp:Image ID="imgHint" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 84px; text-align: center; vertical-align: top;" bgcolor="White">
                                                        <asp:Label ID="lblAns" runat="server" Text="Answer" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                                    </td>
                                                    <td colspan="2" align="left">
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
                                                            Visible="False">
                                                            <asp:ListItem Value="0">A</asp:ListItem>
                                                            <asp:ListItem Value="1">B</asp:ListItem>
                                                            <asp:ListItem Value="2">C</asp:ListItem>
                                                            <asp:ListItem Value="3">D</asp:ListItem>
                                                            <asp:ListItem Value="4">E</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                        <asp:Panel ID="pnlAnsMat" runat="server" Visible="False" Height="110px" Width="305px">
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
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 84px; text-align: center;">
                                                        <asp:Label ID="lbllevel" runat="server" Font-Size="Large" ForeColor="#CC3300" Text="Level"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rdoLevelList" runat="server" Font-Names="Arial" Font-Size="Small"
                                                            RepeatDirection="Horizontal" ToolTip="Click to select level" Enabled="False">
                                                            <asp:ListItem Value="1">Level1</asp:ListItem>
                                                            <asp:ListItem Value="2">Level2</asp:ListItem>
                                                            <asp:ListItem Value="3">Level3</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAnsMatA" runat="server" Visible="False" Width="19px"></asp:TextBox>
                                                        <asp:TextBox ID="txtAnsMatB" runat="server" Visible="False" Width="19px"></asp:TextBox>
                                                        <asp:TextBox ID="txtAnsMatC" runat="server" Visible="False" Width="19px"></asp:TextBox>
                                                        <asp:TextBox ID="txtAnsMatD" runat="server" Visible="False" Width="19px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="2" style="width: 84px; text-align: center;">
                                                        <asp:Label ID="lblCans" runat="server" Font-Size="Large" ForeColor="#CC3300" Text="lblCans"
                                                            Font-Bold="True"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </blockquote>
                                    </div>
                                    <div style="text-align: center; height: 10px;">
                                        <img src="../resources/Image1/loading5.gif" alt="Loading .. " style="visibility: hidden"
                                            id="imgLoad" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#F2CE6E" height="30">
                                    <table border="0" height="33" width="100%">
                                        <tr>
                                            <td width="20%">
                                                <div align="center">
                                                    <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" BackColor="#009900"
                                                        Height="33px" Width="125px" ForeColor="White" Font-Bold="True" Font-Size="Medium"
                                                        OnClientClick="showProgress();" />
                                                </div>
                                            </td>
                                            <td width="20%">
                                                <div align="center">
                                                    <asp:Button ID="btnNext" runat="server" CssClass="btn" OnClick="btnNext_Click" Text="Next"
                                                        BackColor="#009900" Height="33px" Width="125px" ForeColor="White" Font-Bold="True"
                                                        Font-Size="Medium" OnClientClick="showProgress();" />
                                                </div>
                                            </td>
                                            <td width="20%">
                                                <div align="center">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit " BackColor="#009900" Height="33px"
                                                        Width="125px" Font-Size="Medium" ForeColor="White" OnClick="btnSubmit_Click"
                                                        OnClientClick="showProgress();" Font-Bold="True" />
                                                </div>
                                            </td>
                                            <td width="20%">
                                                <div align="center">
                                                    <asp:Button ID="btnexit" runat="server" BackColor="#009900" PostBackUrl="~/SubAdmin/RSBhutadaNewPractice.aspx"
                                                        Height="33px" Width="125px" Text="Exit" ForeColor="White" Font-Bold="True" Font-Size="Medium"
                                                        OnClientClick="showProgress();" />
                                                </div>
                                            </td>
                                            <td width="20%">
                                                <div align="center">
                                                    <asp:TextBox ID="txtgoto" runat="server" Width="40px" MaxLength="5" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                    <asp:Button ID="btnGoto" runat="server" CssClass="btn" Text="Go to Question" BackColor="#009900"
                                                        Height="33px" Width="129px" ForeColor="White" Font-Bold="True" Font-Size="Medium"
                                                        OnClick="btnGoto_Click" OnClientClick="showProgress();" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div height="10px" width="99%" style="text-align: center">
                            <asp:Button ID="btnbackRowset" runat="server" Text="<<" OnClick="btnbackRowset_Click"
                                CssClass="button" Font-Size="12" Width="50px" OnClientClick="showProgress();" />
                            <asp:Button ID="Button1" runat="server" Text="1" OnClick="Button1_Click" Visible="false"
                                CssClass="btnradius" OnClientClick="showProgress();" />
                            <asp:Button ID="Button2" runat="server" Text="2" OnClick="Button1_Click" Visible="false"
                                CssClass="btnradius" OnClientClick="showProgress();" />
                            <asp:Button ID="Button3" runat="server" Text="3" OnClick="Button1_Click" Visible="false"
                                OnClientClick="showProgress();" CssClass="btnradius" />
                            <asp:Button ID="Button4" runat="server" Text="4" OnClick="Button1_Click" Visible="false"
                                OnClientClick="showProgress();" CssClass="btnradius" />
                            <asp:Button ID="Button5" runat="server" Text="5" OnClick="Button1_Click" Visible="false"
                                OnClientClick="showProgress();" CssClass="btnradius" />
                            <asp:Button ID="Button6" runat="server" Text="6" OnClick="Button1_Click" Visible="false"
                                OnClientClick="showProgress();" CssClass="btnradius" />
                            <asp:Button ID="Button7" runat="server" Text="7" OnClick="Button1_Click" Visible="false"
                                OnClientClick="showProgress();" CssClass="btnradius" />
                            <asp:Button ID="Button8" runat="server" Text="8" OnClick="Button1_Click" Visible="false"
                                OnClientClick="showProgress();" CssClass="btnradius" />
                            <asp:Button ID="Button9" runat="server" Text="9" OnClick="Button1_Click" Visible="false"
                                OnClientClick="showProgress();" CssClass="btnradius" />
                            <asp:Button ID="Button10" runat="server" Text="10" OnClick="Button1_Click" Visible="false"
                                OnClientClick="showProgress();" CssClass="btnradius" />
                            <asp:Button ID="btnNextRowset" runat="server" Text=">>" OnClick="btnNextRowset_Click"
                                OnClientClick="showProgress();" CssClass="button" Font-Size="12" Width="50px" />
                            <asp:Label ID="lbldsLastrowscount" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lbldsFirstrowscount" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
