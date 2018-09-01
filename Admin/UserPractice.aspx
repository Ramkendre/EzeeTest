<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserPractice.aspx.cs" Inherits="Admin_UserPractice" %>


<%@ Register Src="~/ExamUserControl.ascx" TagName="pControl" TagPrefix="pCntrl" %>
<%@ Register Src="~/InstructionControl.ascx" TagName="instr" TagPrefix="pInstrCntrl" %>
<%--<%@ Register Src="~/staticControl.ascx" TagName="pControl" TagPrefix="pCntrl" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Padmaraj Exam</title>
    <link href="../resources/stylesheet/styleExamControl.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>

    <%--Next/Back Qno, Run Timer, create array of answers  --%>

    <script language="jscript" type="text/javascript">

        var lblValue = "";      //label value
        var n = "";             //Ques from
        var QuesTo = "";        //Ques to       

        var examAns = new Array();

        //function for next buttton click
        function nextQues() {
            //get current Ques No from Label value
            lblValue = document.getElementById("<%=lblQues.ClientID%>").innerText;
            n = lblValue.split("Ques:")[1];

            QuesTo = document.getElementById("<%=lblQuesTo.ClientID%>").innerText;

            if (parseInt(n) + 1 <= parseInt(QuesTo)) {
                var nextQuesNo = parseInt(n) + 1;
                var str1 = "pnlQues" + nextQuesNo;
                var str2 = "pnlQues" + (parseInt(n));

                document.getElementById("<%=lblQues.ClientID%>").innerText = "Ques:" + nextQuesNo;

                document.getElementById(str1).style.display = "block";
                document.getElementById(str2).style.display = "none";

                if (document.forms[0].elements["timer1"].value == "" || n == 0) {
                    startTimer();
                }
                showAnswerType(nextQuesNo);
            }
        }

        //function for back buttton click
        function backQues() {
            //get urrent Ques No from Label value
            lblValue = document.getElementById("<%=lblQues.ClientID%>").innerText;
            n = lblValue.split("Ques:")[1];

            if (parseInt(n) - 1 > 0) {
                var backQuesNo = parseInt(n) - 1;
                var str1 = "pnlQues" + backQuesNo;
                var str2 = "pnlQues" + (parseInt(n));

                document.getElementById("<%=lblQues.ClientID%>").innerText = "Ques:" + backQuesNo;

                document.getElementById(str1).style.display = "block";
                document.getElementById(str2).style.display = "none";

                showAnswerType(backQuesNo);
            }
        }


        //function to start timer
        var c1, c2, c3, ID = null;
        function startTimer() {
            if (ID != null) {
                stopTimer();
            }
            c1 = 60;
            c2 = 1;
            c3 = 0;
            ID = window.setInterval(run, 1000);

            //create array for number of ques
            for (var i = 0; i <= parseInt(QuesTo); i++) {
                examAns[i] = 0;
            }

            //display timer
            document.getElementById("divTimer").style.display = "block";

            //display submit,finish,Answer label
            document.getElementById("btnSubmit").style.display = "block";
            document.getElementById("btnFinish").style.display = "block";
            document.getElementById("lblAns").style.display = "block";
        }

        function stopTimer() {
            window.clearInterval(ID);
            ID = null;
            document.getElementById("divTimer").style.display = "none";
        }

        function run() {
            c1--;
            if (c1 == 0 && c2 == 0 && c3 == 0) {
                alert('Exam Time Over');
                stopTimer();
            }
            else {
                if (c1 == 0) {
                    c1 = 60;
                    c2--;
                    if (c2 == 0 && c1 == 0) {
                        c2 = 00;
                    }
                    else if (c2 == 0 && c1 != 0) {
                        c2 = 00;
                    }
                }
            }

            var o1 = (c1 <= 9 ? "0" : "") + c1;
            var o2 = (c2 <= 9 ? "0" : "") + c2;
            var o3 = (c3 <= 9 ? "0" : "") + c3;
            document.forms[0].elements["timer1"].value = o3 + ":" + o2 + ":" + o1;
        }

        function showAnswerType(v) {
            try {
                var typeQues = document.getElementById("UC" + v + "_lbltypeQues").innerText;

                if (typeQues == "Type of Question : Basic Type" || typeQues == "Type of Question : Question On Passage" || typeQues == "Type of Question : Reasoning Type") {
                    document.getElementById("divrdoAnswerlist").style.display = "block";
                    document.getElementById("divchkAnslist").style.display = "none";
                    document.getElementById("divpnlAnsMat").style.display = "none";
                    document.getElementById("divtxtAns").style.display = "none";

                    //clear/select radio
                    if (examAns[v] == "0")
                        uncheckRadio();
                    else {
                        checkRadio(v);
                    }
                }
                else if (typeQues == "Type of Question : Multiple Correct Choice") {
                    document.getElementById("divchkAnslist").style.display = "block";
                    document.getElementById("divrdoAnswerlist").style.display = "none";
                    document.getElementById("divpnlAnsMat").style.display = "none";
                    document.getElementById("divtxtAns").style.display = "none";

                    //clear/select Multiple
                    if (examAns[v] == "0")
                        uncheckMultiple();
                    else {
                        checkMultiple(v);
                    }
                }
                else if (typeQues == "Type of Question : Integer Answer Type") {
                    document.getElementById("divtxtAns").style.display = "block";
                    document.getElementById("divchkAnslist").style.display = "none";
                    document.getElementById("divrdoAnswerlist").style.display = "none";
                    document.getElementById("divpnlAnsMat").style.display = "none";

                    //clear/select Multiple
                    if (examAns[v] == "0")
                        uncheckInteger();
                    else {
                        checkInteger(v);
                    }
                }
                else if (typeQues == "Type of Question : Matrix Match Type") {
                    document.getElementById("divpnlAnsMat").style.display = "block";
                    document.getElementById("divrdoAnswerlist").style.display = "none";
                    document.getElementById("divchkAnslist").style.display = "none";
                    document.getElementById("divtxtAns").style.display = "none";

                    //clear/select matrix
                    if (examAns[v] == "0")
                        uncheckMatrix();
                    else {
                        checkMatrix(v);
                    }
                }
            }
            catch (err) {
                txt = "There was an error on this page.\n\n";
                txt += "Error description: " + err.message + "\n\n";
                txt += "Click OK to continue.\n\n";
                alert(txt);
            }

        }
    </script>

    <%--windows.OnLoad() for session login using xml file --%>

    <script type="text/javascript" language="javascript">
        window.onload = function() {
            try {
                var ip = '<%= Request.UserHostAddress %>';
                                
                if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                    xmlhttp = new XMLHttpRequest();
                }
                else {// code for IE6, IE5
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.open("GET", "../pExamSession.xml", false);
                xmlhttp.send();
                xmlDoc = xmlhttp.responseXML;

                var x = xmlDoc.getElementsByTagName("Users");
                for (i = 0; i < x.length; i++) {
                    var y = x[i].getElementsByTagName("session");
                    for (j = 0; j < y.length; j++) {
                        if (y[j].getElementsByTagName("ipAddress")[0].childNodes[0].nodeValue == ip) {
                            
                            document.getElementById("<%=lblLogin.ClientID%>").innerText = y[j].getElementsByTagName("LoginId")[0].childNodes[0].nodeValue;

                            var login = document.getElementById("<%=lblLogin.ClientID%>").innerText;
                            '<%Session["Test"] = "' + login + '";%>';
                            var session_value = '<%=Session["Test"]%>';
                            //alert(session_value);
                            break;
                        }
                    }
                }

                if (document.getElementById("<%=lblLogin.ClientID%>").innerText == "Login") {
                    redirectToLoginPage();
                } else {
                    document.getElementById("btnSubmit").style.display = "none";
                    document.getElementById("btnFinish").style.display = "none";
                    document.getElementById("lblAns").style.display = "none";
                }
            } catch (err) {
                alert(err.message);
            }
        }       
    </script>

    <%--Radio button check unchek --%>

    <script type="text/javascript" language="javascript">
        //function to uncheck radio button list
        function uncheckRadio() {
            var elementRef = document.getElementById('<%= rdoAnswerlist.ClientID %>');
            var inputElementArray = elementRef.getElementsByTagName('input');

            for (var i = 0; i < inputElementArray.length; i++) {
                var inputElement = inputElementArray[i];

                inputElement.checked = false;
            }
        }

        //function to check radio button list
        function checkRadio(Qno) {
            var elementRef = document.getElementById('<%= rdoAnswerlist.ClientID %>');
            var inputElementArray = elementRef.getElementsByTagName('input');

            for (var i = 0; i < inputElementArray.length; i++) {
                var inputElement = inputElementArray[i];
                if (inputElement.value == examAns[Qno]) {
                    inputElement.checked = true;
                }
            }
        }
    </script>

    <%--Matrix Type check unchek --%>

    <script type="text/javascript" language="javascript">
        //function to uncheck radio button list
        function uncheckMatrix() {
            //for A
            var CHK = document.getElementById('<%= ChkansMatA.ClientID %>');
            var checkbox = CHK.getElementsByTagName('input');

            for (var i = 0; i < checkbox.length; i++) {
                var inputElement = checkbox[i];
                inputElement.checked = false;
            }

            //for B
            CHK = document.getElementById('<%= ChkansMatB.ClientID %>');
            checkbox = CHK.getElementsByTagName('input');

            for (var i = 0; i < checkbox.length; i++) {
                var inputElement = checkbox[i];
                inputElement.checked = false;
            }

            //for C
            CHK = document.getElementById('<%= ChkansMatC.ClientID %>');
            checkbox = CHK.getElementsByTagName('input');

            for (var i = 0; i < checkbox.length; i++) {
                var inputElement = checkbox[i];
                inputElement.checked = false;
            }

            //for D
            CHK = document.getElementById('<%= ChkansMatD.ClientID %>');
            checkbox = CHK.getElementsByTagName('input');

            for (var i = 0; i < checkbox.length; i++) {
                var inputElement = checkbox[i];
                inputElement.checked = false;
            }
        }

        //function to check radio button list
        function checkMatrix(Qno) {

            var matAns = examAns[Qno];
            var arrayAns = matAns.split('*');

            //for A
            arrayAns[0] = arrayAns[0].substr(2, arrayAns[0].length - 2);

            var array1 = arrayAns[0].split(',');
            //alert(arrayAns[0]);
            var CHK = document.getElementById('<%=ChkansMatA.ClientID %>');
            var checkbox = CHK.getElementsByTagName('input');
            var label = CHK.getElementsByTagName("label");

            for (var i = 0; i < checkbox.length; i++) {
                for (var j = 0; j < array1.length; j++) {
                    //var inputElement = checkbox[i];                
                    if (label[i].innerHTML == array1[j]) {
                        checkbox[i].checked = true;
                    }
                }
            }

            //for B
            arrayAns[1] = arrayAns[1].substr(2, arrayAns[1].length - 2);

            var array1 = arrayAns[1].split(',');
            //alert(arrayAns[1]);
            CHK = document.getElementById('<%=ChkansMatB.ClientID %>');
            checkbox = CHK.getElementsByTagName('input');
            label = CHK.getElementsByTagName("label");

            for (var i = 0; i < checkbox.length; i++) {
                for (var j = 0; j < array1.length; j++) {
                    //var inputElement = checkbox[i];                
                    if (label[i].innerHTML == array1[j]) {
                        checkbox[i].checked = true;
                    }
                }
            }

            //for C
            arrayAns[2] = arrayAns[2].substr(2, arrayAns[2].length - 2);

            var array1 = arrayAns[2].split(',');
            //alert(arrayAns[2]);
            var CHK = document.getElementById('<%=ChkansMatC.ClientID %>');
            var checkbox = CHK.getElementsByTagName('input');
            var label = CHK.getElementsByTagName("label");

            for (var i = 0; i < checkbox.length; i++) {
                for (var j = 0; j < array1.length; j++) {
                    //var inputElement = checkbox[i];                
                    if (label[i].innerHTML == array1[j]) {
                        checkbox[i].checked = true;
                    }
                }
            }

            //for D
            arrayAns[3] = arrayAns[3].substr(2, arrayAns[3].length - 2);

            var array1 = arrayAns[3].split(',');
            //alert(arrayAns[3]);
            var CHK = document.getElementById('<%=ChkansMatD.ClientID %>');
            var checkbox = CHK.getElementsByTagName('input');
            var label = CHK.getElementsByTagName("label");

            for (var i = 0; i < checkbox.length; i++) {
                for (var j = 0; j < array1.length; j++) {
                    //var inputElement = checkbox[i];                
                    if (label[i].innerHTML == array1[j]) {
                        checkbox[i].checked = true;
                    }
                }
            }
        }
    </script>

    <%--Multiple Type check unchek --%>

    <script type="text/javascript" language="javascript">
        //function to uncheck Multiple checkbox list
        function uncheckMultiple() {
            var CHK = document.getElementById('<%=chkAnslist.ClientID %>');
            var checkbox = CHK.getElementsByTagName('input');

            for (var i = 0; i < checkbox.length; i++) {
                var inputElement = checkbox[i];
                inputElement.checked = false;
            }
        }

        //function to check Multiple checkbox list
        function checkMultiple(Qno) {

            var multtAns = examAns[Qno];
            var arrayAns = multtAns.split(',');

            //alert(arrayAns);
            var CHK = document.getElementById('<%=chkAnslist.ClientID %>');
            var checkbox = CHK.getElementsByTagName('input');
            var label = CHK.getElementsByTagName("label");

            for (var i = 0; i < checkbox.length; i++) {
                for (var j = 0; j < arrayAns.length; j++) {
                    if (label[i].innerHTML == arrayAns[j]) {
                        checkbox[i].checked = true;
                    }
                }
            }
        }
    </script>

    <%--Integer Type check unchek --%>

    <script type="text/javascript" language="javascript">
        //function to null textBox
        function uncheckInteger() {
            document.getElementById('<%=txtAns.ClientID %>').value = "";
        }

        //function to insert value in textBox
        function checkInteger(Qno) {
            document.getElementById('<%=txtAns.ClientID %>').value = examAns[Qno];
        }
    </script>

    <%--Collect solved answers --%>

    <script type="text/javascript" language="javascript">
        function GetListItem() {
            try {
                //get urrent Ques No from Label value
                var Qno1 = parseInt(document.getElementById("<%=lblQues.ClientID%>").innerText.split("Ques:")[1]);
                var typeQues = document.getElementById("UC" + Qno1 + "_lbltypeQues").innerText;

                if (typeQues == "Type of Question : Basic Type" || typeQues == "Type of Question : Question On Passage" || typeQues == "Type of Question : Reasoning Type") {
                    examAns[Qno1] = $('#<%=rdoAnswerlist.ClientID %> input:checked').val();
                    //alert(Qno1 + examAns[Qno1]);
                }
                else if (typeQues == "Type of Question : Multiple Correct Choice") {
                    var A = "";
                    var CHK = document.getElementById("<%=chkAnslist.ClientID%>");
                    var checkbox = CHK.getElementsByTagName("input");
                    var label = CHK.getElementsByTagName("label");

                    for (var i = 0; i < checkbox.length; i++) {
                        if (checkbox[i].checked) {
                            A += label[i].innerHTML + ",";
                        }
                    }
                    A = A.substr(0, A.length - 1);
                    examAns[Qno1] = A;
                    //alert(examAns[Qno1]);
                }
                else if (typeQues == "Type of Question : Integer Answer Type") {
                    examAns[Qno1] = document.getElementById('<%=txtAns.ClientID%>').value;
                    //alert(examAns[Qno1]);
                }
                else if (typeQues == "Type of Question : Matrix Match Type") {

                    var A = "A-";
                    var CHK = document.getElementById("<%=ChkansMatA.ClientID%>");
                    var checkbox = CHK.getElementsByTagName("input");
                    var label = CHK.getElementsByTagName("label");

                    for (var i = 0; i < checkbox.length; i++) {
                        if (checkbox[i].checked) {
                            //alert("Selected = " + label[i].innerHTML);
                            A += label[i].innerHTML + ",";
                        }
                    }
                    A = A.substr(0, A.length - 1);
                    //alert(A);

                    var B = "B-";
                    var CHK = document.getElementById("<%=ChkansMatB.ClientID%>");
                    var checkbox = CHK.getElementsByTagName("input");
                    var label = CHK.getElementsByTagName("label");

                    for (var i = 0; i < checkbox.length; i++) {
                        if (checkbox[i].checked) {
                            //alert("Selected = " + label[i].innerHTML);
                            B += label[i].innerHTML + ",";
                        }
                    }
                    B = B.substr(0, B.length - 1);
                    //alert(B);

                    var C = "C-";
                    var CHK = document.getElementById("<%=ChkansMatC.ClientID%>");
                    var checkbox = CHK.getElementsByTagName("input");
                    var label = CHK.getElementsByTagName("label");

                    for (var i = 0; i < checkbox.length; i++) {
                        if (checkbox[i].checked) {
                            //alert("Selected = " + label[i].innerHTML);
                            C += label[i].innerHTML + ",";
                        }
                    }
                    C = C.substr(0, C.length - 1);
                    //alert(C);

                    var D = "D-";
                    var CHK = document.getElementById("<%=ChkansMatD.ClientID%>");
                    var checkbox = CHK.getElementsByTagName("input");
                    var label = CHK.getElementsByTagName("label");

                    for (var i = 0; i < checkbox.length; i++) {
                        if (checkbox[i].checked) {
                            //alert("Selected = " + label[i].innerHTML);
                            D += label[i].innerHTML + ",";
                        }
                    }
                    D = D.substr(0, D.length - 1);
                    //alert(D);

                    examAns[Qno1] = A + "*" + B + "*" + C + "*" + D;
                    //alert(examAns[Qno1]);
                }
            }
            catch (err) {
                alert(err.message);
            }
        }

        //not in use to clear selected radio button
        function removeListItem() {
            var elementRef = document.getElementById('<%= rdoAnswerlist.ClientID %>');
            var inputElementArray = elementRef.getElementsByTagName('input');

            for (var i = 0; i < inputElementArray.length; i++) {
                var inputElement = inputElementArray[i];

                inputElement.checked = false;
            }

            examAns[parseInt(document.getElementById("<%=lblQues.ClientID%>").innerText.split("Ques:")[1])] = 0;
        } 
    </script>

    <%--Not in use to Save session in cookie --%>

    <script type="text/javascript" language="javascript">

        function writeCookie(name, value, days) {
            try {
                var date, expires;
                if (days) {
                    date = new Date();
                    date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                    expires = "; expires=" + date.toGMTString();
                } else {
                    expires = "";
                }
                document.cookie = name + "=" + value + expires + "; path=/";
            }
            catch (err)
            { alert(err.message); }
        }

        function readCookie(name) {
            try {
                var i, c, ca, nameEQ = name + "=";
                ca = document.cookie.split(';');
                for (i = 0; i < ca.length; i++) {
                    c = ca[i];
                    while (c.charAt(0) == ' ') {
                        c = c.substring(1, c.length);
                    }
                    if (c.indexOf(nameEQ) == 0) {
                        return c.substring(nameEQ.length, c.length);
                    }
                }
            }
            catch (err)
            { alert(err.message); }
            return '';
        }
    </script>

    <%--function to redirect to login page --%>

    <script>
        function redirectToLoginPage() {
            window.location.assign("../User/usrLogin.aspx");
        }
    </script>

    <%--function to finish exam --%>

    <script type="text/javascript" language="javascript">
        function finishExam() {
            stopTimer();
            var QuesCurr = document.getElementById("<%=lblQues.ClientID%>").innerText;
            var QuesTo = document.getElementById("<%=lblQuesTo.ClientID%>").innerText;
            //alert(QuesTo + QuesCurr);
            var str1 = "pnlQues" + (parseInt(QuesTo) + 1);
            var str2 = "pnlQues" + parseInt(QuesCurr.split(':')[1]);

            document.getElementById("<%=lblQues.ClientID%>").innerText = "Ques:-1";

            document.getElementById(str1).style.display = "block";
            document.getElementById(str2).style.display = "none";

            document.getElementById("btnBack").style.display = "none";
            document.getElementById("btnNext").style.display = "none";

            document.getElementById("btnSubmit").style.display = "none";
            document.getElementById("btnFinish").style.display = "none";
            document.getElementById("lblAns").style.display = "none";

            document.getElementById("divrdoAnswerlist").style.display = "none";
            document.getElementById("divtxtAns").style.display = "none";
            document.getElementById("divchkAnslist").style.display = "none";
            document.getElementById("divpnlAnsMat").style.display = "none";

            var totalQues = document.getElementById("<%=lblQuesTo.ClientID%>").innerText;
            var typeQues = document.getElementById("txtTotalQues").value = totalQues;

            var attemptQ = 0, correctQ = 0, incorrectQ = 0;

            for (i = 1; i <= totalQues; i++) {
                if (examAns[i] != 0) {
                    attemptQ++;
                    if (examAns[i] == document.getElementById("UC" + i + "_lblCorrectAns").innerText) {
                        correctQ++;
                    }
                }
            }

            document.getElementById("txtAttempt").value = attemptQ;
            document.getElementById("txtCorrect").value = correctQ;
            document.getElementById("txtIncorrect").value = (attemptQ - correctQ);
        }
    </script>

</head>
<body>
    <form id="form1" name="timeForm" runat="server">
    <div id="divTimer" class="displayBlock">
        <input type="text" name="timer1" disabled="disabled" style="border-width: 0px; font-family: digital, arial, verdana;" />
    </div>
    <div>
        <center>
            <asp:Label ID="lblLogin" runat="server" Text="Login"></asp:Label>
            <asp:Label ID="lblQues" runat="server" ForeColor="White" Text="Ques:0"></asp:Label>
            <asp:Label ID="lblQuesTo" runat="server" ForeColor="White" Text="0"></asp:Label>
            <br />
            <table width="70%">
                <tr>
                    <td class="tdMiddle">
                        <%--<input type="button" id="Button1" name="btnBack" value="Back" onclick="backQues()" />--%>
                        <input type="button" id="btnBack" name="btnBack" value="Back" onclick="backQues()" />
                    </td>
                    <td align="center">
                        <asp:PlaceHolder ID="UCPlaceHolder" runat="server"></asp:PlaceHolder>
                    </td>
                    <td class="tdMiddle">
                        <input type="button" id="btnNext" class="btnBackImg" name="btnNext" value="Next"
                            onclick="nextQues()" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblAns" runat="server" Text="Answer" Font-Size="Small" ForeColor="#CC3300" />
                        <div id="divrdoAnswerlist" class="displayBlock">
                            <asp:RadioButtonList ID="rdoAnswerlist" runat="server" Font-Size="Small" RepeatDirection="Horizontal">
                                <asp:ListItem Value="A" Text="A"></asp:ListItem>
                                <asp:ListItem Value="B" Text="B"></asp:ListItem>
                                <asp:ListItem Value="C" Text="C"></asp:ListItem>
                                <asp:ListItem Value="D" Text="D"></asp:ListItem>
                                <asp:ListItem Value="E" Text="E"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div id="divtxtAns" class="displayBlock">
                            <asp:TextBox ID="txtAns" runat="server" MaxLength="15" Width="158px"></asp:TextBox>
                        </div>
                        <div id="divchkAnslist" class="displayBlock">
                            <asp:CheckBoxList ID="chkAnslist" runat="server" Font-Size="Small" RepeatDirection="Horizontal">
                                <asp:ListItem Value="A" Text="A"></asp:ListItem>
                                <asp:ListItem Value="B" Text="B"></asp:ListItem>
                                <asp:ListItem Value="C" Text="C"></asp:ListItem>
                                <asp:ListItem Value="D" Text="D"></asp:ListItem>
                                <asp:ListItem Value="E" Text="E"></asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                        <div id="divpnlAnsMat" class="displayBlock">
                            <asp:Panel ID="pnlAnsMat" runat="server">
                                <table>
                                    <tr>
                                        <td style="font-size: Small">
                                            A->
                                        </td>
                                        <td>
                                            <asp:CheckBoxList ID="ChkansMatA" runat="server" Font-Size="Small" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="P" Text="P"></asp:ListItem>
                                                <asp:ListItem Value="Q" Text="Q"></asp:ListItem>
                                                <asp:ListItem Value="R" Text="R"></asp:ListItem>
                                                <asp:ListItem Value="S" Text="S"></asp:ListItem>
                                                <asp:ListItem Value="T" Text="T"></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: Small" bgcolor="White">
                                            B->
                                        </td>
                                        <td>
                                            <asp:CheckBoxList ID="ChkansMatB" runat="server" Font-Size="Small" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="P" Text="P"></asp:ListItem>
                                                <asp:ListItem Value="Q" Text="Q"></asp:ListItem>
                                                <asp:ListItem Value="R" Text="R"></asp:ListItem>
                                                <asp:ListItem Value="S" Text="S"></asp:ListItem>
                                                <asp:ListItem Value="T" Text="T"></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: Small">
                                            C->
                                        </td>
                                        <td>
                                            <asp:CheckBoxList ID="ChkansMatC" runat="server" Font-Size="Small" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="P" Text="P"></asp:ListItem>
                                                <asp:ListItem Value="Q" Text="Q"></asp:ListItem>
                                                <asp:ListItem Value="R" Text="R"></asp:ListItem>
                                                <asp:ListItem Value="S" Text="S"></asp:ListItem>
                                                <asp:ListItem Value="T" Text="T"></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: Small">
                                            D->
                                        </td>
                                        <td>
                                            <asp:CheckBoxList ID="ChkansMatD" runat="server" Font-Size="Small" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="P" Text="P"></asp:ListItem>
                                                <asp:ListItem Value="Q" Text="Q"></asp:ListItem>
                                                <asp:ListItem Value="R" Text="R"></asp:ListItem>
                                                <asp:ListItem Value="S" Text="S"></asp:ListItem>
                                                <asp:ListItem Value="T" Text="T"></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                        &nbsp;
                        <%-- <input type="button" id="btnClear" value="Clear" name="Clear" onclick="removeListItem()" />--%>
                        <input type="button" id="btnSubmit" value="Submit" name="Submit" onclick="GetListItem()" />
                        <input type="button" id="btnFinish" value="Finish Exam" name="btnFinish" onclick="finishExam()" />
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>

