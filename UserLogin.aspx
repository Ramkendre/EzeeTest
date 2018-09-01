<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="x-ua-compatible" content="IE=8" />
    <meta http-equiv="x-ua-compatible" content="IE=9" />
    <title>eZeeTest:Login</title>
    <link rel="icon" href="EZEE TEST.png" type="image/x-icon" />
    <meta name="Description" content="Online Exam Portal important for IIT, Jee Main, MH-CET, engineering entrance and medical entrance mahatet police bharti talathi exam postam and mailgaurd exam mpsc upsc ibps all competitive exam practice jee main last year question papers mahatet exam full practice mahatet modal question papers mahatet last year all question paper with answers key mahatet exam 2013 2014 2015 2016 Ezee test is a easy test app. Useful for 4th scholarship, 7th scholarship, 12th CE, Medical entrance, Engineering Entrance, for all class study material, for all objective questions , for all multiple choice questions ( MCQ ), MAHATET ( MAHA TET ), SKILL TESTS, NSDC EXAM, MPSC EXAM, UPSC EXAM, IAS EXAM, SSC EXAM, IBPS EXAM, MSCIT EXAM, CCC EXAM, 10TH STANDARD STUDY MATERIAL, MATHS, PHYSICS, CHEMISTARY, BIOLOGY, ZOOLOGY, BOTANY, ANIMAL SCIENCE, GENERAL SCIENCE, GENERAL KNOWLEDGE, APTITUDE TEST, MH-CET, MHCET, MH CET, NEET, JEE MAIN, JEE ADVANCE, BANK EXAM, PO, PROBESSIONARY OFFICER, POLICE BHARTI, PSI, STI, ONLINE TAYARI, ONLINE EXAM APP, MSSCHOLARSHIP, MCQ QUIZ, NEGATIVE MARKING FACILITY, OFFLINE APP FOR GOVERNMENT EXAM, Current Affairs 2015-16, General Awareness, (G.K.), History , Computer Knowledge , Culture and Arts , Economics, CSAT, RAS,, PCS, SSC CGL , CLAT, GK IN MARATHI, State Service Examination (SSE), Tax Assistant, Police sub-inspector Exam, Maharashtra Forest Services,, Agricultural services, Clerk jobs, FOR ALL SPARDHA PARIKSHA, PRATIYOGITA, SUCCESS MANTRA, medical colleges medical question bank, Learn when you can and from wherever you are, AIEEE, MOCK TEST, online tayari, online tyari in hindi, Marathi, for civil services, online test series, for aptitude test and preparation, railway exam, SSC CGL (Staff Selection Commission Combined Graduate Level ), for stenographers, It is useful for all educational categories from 1st standard to 12 th Standard and for competitive exam preparing student also. " />
    <meta name="Author" content="Abhinav IT Solutions Pvt.Ltd. Pune" />
    <link href="resources/stylesheet/css.css" rel="stylesheet" type="text/css" />
    <link href="resources/generic.css" rel="Stylesheet" type="text/css" />
    <link href="resources/js-image-slider.css" rel="Stylesheet" type="text/css" />

    <script src="resources/js-image-slider.js" type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            width: 88px;
        }

        .style4
        {
            text-align: center;
        }

        .style5
        {
            font-family: "Times New Roman", Times, serif;
        }

        .style6
        {
            color: #000000;
            font-weight: bold;
            font-family: Constantia;
            color: #8B0000;
            text-shadow: 2px 2px 2px #DCDCDC;
        }

        .style7
        {
            width: 152px;
        }
    </style>

    <script src="resources/JScript/jquery-1.3.2.js" type="text/javascript"></script>

    <script src="resources/JScript/popup.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $('.slide-out-div').tabSlideOut({
                tabHandle: '.handle',
                pathToTabImage: 'resources/Image1/support11.png',
                imageHeight: '104px',
                imageWidth: '40px',
                tabLocation: 'right',
                speed: 250,
                action: 'click',
                topPos: '134px',
                leftPos: '20px',
                fixedPosition: false
            });
        });

        function btnS_Send_onclick() {

        }

    </script>

    <script src="resources/JScript/jquery-blink.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('.blink').blink();
        });

    </script>

    <script type="text/javascript">
        function validateSupport() {
            // alert(document.getElementById("txtS_Name").value);
            if (document.getElementById("txtS_Name").value == "") {
                alert("Please Enter Your Name");
                document.getElementById("txtS_Name").focus();
                return false;
            }
            if (document.getElementById("txtS_Email").value == "") {
                alert("Please Enter Your Email-ID");
                document.getElementById("txtS_Email").focus();
                return false;
            }

            var emailPat = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
            var emailid = document.getElementById("txtS_Email").value;
            var matchArray = emailid.match(emailPat);
            if (matchArray == null) {
                alert("Your email address seems incorrect. Please try again.");
                document.getElementById("txtS_Email").focus();
                return false;
            }
            if (document.getElementById("txtS_Msg").value == "") {
                alert("Please Enter Your Message");
                document.getElementById("txtS_Msg").focus();
                return false;
            }

        }

    </script>

    <style type="text/css">
        .slide-out-div
        {
            padding: 20px;
            width: auto;
            background: #006666;
            border: 2px solid #FFFFFF;
        }

        .submit
        {
            background: none repeat scroll 0 0 #B60001;
            border: 3px solid #B60001;
            color: #FFFFFF;
            cursor: pointer;
            font-family: Helvetica;
            font-size: 1em;
            font-weight: bolder;
            margin-top: 4px;
            outline: medium none;
            padding: 5px;
            text-transform: uppercase;
            width: 207px;
            height: 36px;
        }

        .customCalloutStyle div, .customCalloutStyle td
        {
            border: solid 1px Black;
            background-color: #FFE4C4;
            font-family: Arial;
            font-size: 11px;
            font-weight: bold;
            color: Red;
        }

        .ajax__validatorcallout_icon_cell img
        {
            display: none;
        }

        .playstorelink
        {
            text-decoration: none;
            font-weight: bold;
            color: Black;
        }

            .playstorelink:hover
            {
                color: Red;
                text-shadow: 2px 2px 2px yellow;
            }
    </style>

    <script language="javascript" type="text/javascript">
        // <!CDATA[



        // ]]>
    </script>

    <script type="text/javascript" language="javascript">
        function getCookie(c_name) {
            var c_value = document.cookie;
            var c_start = c_value.indexOf(" " + c_name + "=");
            if (c_start == -1) {
                c_start = c_value.indexOf(c_name + "=");
            }
            if (c_start == -1) {
                c_value = null;
            }
            else {
                c_start = c_value.indexOf("=", c_start) + 1;
                var c_end = c_value.indexOf(";", c_start);
                if (c_end == -1) {
                    c_end = c_value.length;
                }
                c_value = unescape(c_value.substring(c_start, c_end));
            }
            return c_value;
        }

        function setCookie1(c_name, value, exdays) {

            if (value == '') {

                var exdate = new Date();
                exdate.setDate(exdate.getDate() + exdays);
                var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
                //document.cookie = c_name + "=" + c_value;
                c_value = c_value + '; path=/';
                document.cookie = c_name + "=" + c_value;
            }

            else if (document.getElementById("<%#txtUserName.ClientID%>").value == "") {
                alert("Insert UserName!");
            }
            else if (value == 'P') {
                value = document.getElementById("<%#txtUserName.ClientID%>").value;
                var exdate = new Date();
                exdate.setDate(exdate.getDate() + exdays);
                var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
                //document.cookie = c_name + "=" + c_value;
                c_value = c_value + '; path=/';
                document.cookie = c_name + "=" + c_value;
            }
}

function checkCookie() {
    var username = getCookie("ezeeUser123");
    if (username != null && username != "") {
        alert(username);
    }
    else {
        redirectToLoginPage();
    }
}

    </script>

</head>
<body>
    <form id="form1" runat="server" method="post" defaultbutton="btnLogin">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div>
            <table cellpadding="0" cellspacing="0" border="0" width="100%" align="center">
                <tr>
                    <td class="header_bg" align="left" valign="bottom" colspan="5">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td valign="middle" style="background-color: #F9FF9B" class="style1">
                                    <img src="Images/it.jpg" alt="LogoImage Abhinav IT Solutions Pvt.Ltd. Pune" style="width: 145px; height: 84px; float: right; margin-right: 0px;" />
                                </td>
                                <td style="height: 90px; color: #FF8000; background-color: #F9FF9B; font-size: xx-large; font-family: 'Times New Roman', Times, serif; text-align: center; font-weight: 700;"
                                    align="left" valign="middle">
                                    <%--   <%=Convert.ToString(Session["examname"]) %>
                                    --%>
                                OnLine ExamModel
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 5px; background-color: White;" colspan="5"></td>
                </tr>
                <tr>
                    <td class="menu_bg" style="padding-left: 20px;" colspan="5"></td>
                </tr>
                <tr>
                    <td class="style7">
                        <br />
                    </td>
                    <td class="style4" style="color: #FF0000"></td>
                </tr>
                <tr>
                    <td>
                        <%--<a href="https://play.google.com/store/apps/details?id=ezee.abhinav.ezeetest">
                        <img alt="" style="margin-top: 0px;" src="Images/Untitled.png" id="img12" />
                    </a>--%>
                    </td>
                    <td>
                        <%--<asp:ImageButton ID="btnPayment" runat="server" AlternateText="MakePayment" ImageUrl="~/resources/MakePayment.png"
                        OnClick="btnPayment_Click" />--%>

                        <asp:Button ID="btndatashowany" runat="server" Text="SHOW_OMRRESULT" CssClass="btn"
                            OnClick="btndatashowany_Click" PostBackUrl="~/SubAdmin/OMRShowResult.aspx" />
                        <%--<asp:Button ID="btndatashowany" runat="server" Text="Show_Result" CssClass="btn"
                        OnClick="btndatashowany_Click" PostBackUrl="~/SubAdmin/UplaodeZeeSchoolData.aspx" />--%>

                    </td>
                    <td style="width: 100%">
                        <%--<a href="HOW TO PAY FOR MAHATET ANDROID APP.docx"><span style="font-family: Constantia;
                        color: Blue; font-size: small; font-weight: bold; text-decoration: none;">Click
                        Here To Download User Manual for Payment MAHATET Android App</span></a> <span style="color: Red;
                            font-size: 12px; font-weight: bold; font-family: Tahoma;" class="blink">New!</span>--%>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; vertical-align: bottom; width: 180px;" class="style7">
                        <asp:Label ID="lblcounter" runat="server" Text="Counter" BackColor="#FFFF99" Font-Bold="True"
                            Font-Size="Medium" ForeColor="#CC0000"></asp:Label>
                        &nbsp;
                    <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </td>
                    <td class="style4" style="color: #FF0000" colspan="3">
                        <asp:Literal ID="ltrlMessage" runat="server"></asp:Literal>
                        <table cellpadding="2" cellspacing="0" bgcolor="#F9FF9B" align="center" style="font-family: 'Times New Roman', Times, serif">
                            <tr>
                                <td colspan="2" height="30px" align="center" class="style6">LOGIN
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px; height: 25px; color: #800000;" align="right" class="style5">User Name :
                                </td>
                                <td align="left" style="width: 280px;">
                                    <span class="style5">
                                        <asp:TextBox ID="txtUserName" runat="server" Width="180" CssClass="txtcss" ToolTip="Enter Mobile Number"
                                            MaxLength="10"></asp:TextBox>
                                    </span>&nbsp;<span class="style5"></span><asp:RequiredFieldValidator ID="reqUserName"
                                        runat="server" ControlToValidate="txtUserName" CssClass="error" Display="None"
                                        ErrorMessage="Required UserName " SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vce1" TargetControlID="reqUserName" WarningIconImageUrl="~/resources/Image1/001_30.ico"
                                        CssClass="customCalloutStyle" runat="server">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 25px; color: #800000;" align="right" class="style5">Password :
                                </td>
                                <td align="left">
                                    <span class="style5">
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="txtcss" Width="180" TextMode="Password"></asp:TextBox>
                                    </span>&nbsp;<span class="style5"><asp:RequiredFieldValidator ID="reqPassword" runat="server"
                                        ControlToValidate="txtPassword" CssClass="error" Display="None" ErrorMessage="Required Password"
                                        SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator></span>
                                    <asp:ValidatorCalloutExtender ID="vce2" runat="server" TargetControlID="reqPassword"
                                        WarningIconImageUrl="~/resources/Image1/001_30.ico" CssClass="customCalloutStyle">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 40px;" align="left"></td>
                                <td align="left">
                                    <span class="style5">
                                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClientClick="setCookie1('ezeeUser123','P',365)"
                                            CssClass="btn" OnClick="btnLogin_Click" ValidationGroup="other" Width="90px" />
                                        &nbsp; </span><span class="style5">&nbsp;</span> <span class="style5">
                                            <asp:Button ID="btnDemouser" runat="server" Text="View Demo" CssClass="btn" OnClick="btnDemouser_Click"
                                                Width="79px" />
                                            &nbsp; </span><span class="style5">&nbsp;</span>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 24px;" align="left"></td>
                                <td align="left">
                                    <span class="style5">
                                        <asp:LinkButton ID="lnkforgetPwd" runat="server" Text="Forget Password" Font-Size="11pt" OnClick="lnkforgetPwd_Click1"
                                            CssClass="btn" Width="160px" />
                                        &nbsp; </span><span class="style5">&nbsp;</span>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div style="height: 300px;">
                        </div>

                        <%--<div id="sliderFrame">
                        <div id="slider">
                            <img src="resources/IMG-20150121-WA0054.jpg" alt="" height="200px" width="300px" />
                            <img src="resources/IMG-20150121-WA0055.jpg" alt="" height="200px" width="300px" />
                        </div>
                    </div>--%>

                    </td>
                </tr>
            </table>
        </div>
        <div id="page_wrapper">
            <div class="slide-out-div" style="clear: both; height: 400px; width: 200px;">
                <a class="handle" href="#">Visit Us</a>
                <h3 style="color: #FFFFFF; padding-left: 70px; font-family: Arial; font-weight: bold; font-size: 20px; display: inline;">Support<br />
                    <input type="hidden" name="redirect" value="" />
                </h3>
                <p style="color: #FFFFFF; font-size: 14px; font-family: Georgia;">
                    Sorry, we aren't online at the moment. Leave a message and we'll get back to you.
                <a href="http://www.ezeesoftindia.com" style="color: Red" target="_blank">for more visit
                    ezeesoftindia </a>
                </p>
                <div id="DivName" style="overflow: hidden; padding-bottom: 4px; width: 280px;">
                    <div style="color: #FFFFFF; font-size: 0.9em; font-family: Georgia; padding-bottom: 4px;">
                        Name <span style="color: #F5410F;">*</span>
                    </div>
                    <asp:TextBox ID="txtS_Name" runat="server" MaxLength="50" placeholder="Name" Style="width: 200px; height: 20px;"></asp:TextBox>
                </div>
                <div id="DivEmail" style="overflow: hidden; padding-bottom: 10px; width: 280px;">
                    <div style="color: #FFFFFF; font-size: 0.9em; font-family: Georgia; padding-bottom: 4px;">
                        E-mail<span style="color: #F5410F;">*</span>
                    </div>
                    <asp:TextBox ID="txtS_Email" runat="server" MaxLength="100" placeholder="Enter Email"
                        Style="width: 200px; height: 20px;"></asp:TextBox>
                </div>
                <div id="DivMob" style="overflow: hidden; padding-bottom: 10px; width: 280px;">
                    <div style="color: #FFFFFF; font-size: 0.9em; font-family: Georgia; padding-bottom: 4px;">
                        Mobile No
                    </div>
                    <asp:TextBox ID="txtS_MobNO" runat="server" MaxLength="100" placeholder="Enter Mobile"
                        Style="width: 200px; height: 20px;"></asp:TextBox>
                </div>
                <div id="DivSub" style="overflow: hidden; padding-bottom: 10px; width: 280px;">
                    <div style="color: #FFFFFF; font-size: 0.9em; font-family: Georgia; padding-bottom: 4px;">
                        Subject<span style="color: #F5410F;">*</span>
                    </div>
                    <asp:DropDownList ID="ddlS_subject" runat="server" Style="width: 200px; height: 25px;">
                        <asp:ListItem Value="">Technical Support</asp:ListItem>
                        <asp:ListItem Value="">Submit a Feedback</asp:ListItem>
                        <asp:ListItem Value="">General Enquiry</asp:ListItem>
                        <asp:ListItem Value="">Extension of Service</asp:ListItem>
                        <asp:ListItem Value="">other products of ezeesoftindia</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="DivMsg" style="overflow: hidden; padding-bottom: 10px; width: 280px;">
                    <div style="color: #FFFFFF; font-size: 0.9em; font-family: Georgia; padding-bottom: 4px;">
                        Message <span style="color: #F5410F;">*</span>
                    </div>
                    <asp:TextBox ID="txtS_Msg" runat="server" TextMode="MultiLine" Rows="2" Columns="20"
                        placeholder="Enter Message" Style="width: 200px; height: 70px;"></asp:TextBox>
                </div>
                <div align="left">
                    <%--<input type="submit" name="btnS_Send" value="send" onclick="return validateSupport();"
                        id="btnS_Send" class="submit" autopostback="false" onclick="return btnS_Send_onclick()" />
                    --%>
                    <asp:Button ID="btnS_Send" runat="server" CssClass="submit" OnClientClick="return validateSupport();"
                        Text="Submit" OnClick="btnS_Send_Click" />
                    -
                </div>
            </div>
        </div>
    </form>
    <p>
        &nbsp;
    </p>
</body>
</html>
