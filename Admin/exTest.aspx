<%@ Page Language="C#" AutoEventWireup="true" CodeFile="exTest.aspx.cs" Inherits="Admin_exTest" %>

<%@ Register Src="~/ExamUserControl.ascx" TagName="pControl" TagPrefix="pCntrl" %>
<%@ Register Src="~/InstructionControl.ascx" TagName="instr" TagPrefix="pInstrCntrl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eZeeTest:Online Exam</title>
    <link href="../resources/stylesheet/css.css" rel="stylesheet" type="text/css" />
    <link href="../resources/stylesheet/styleExamControl.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>

    <%--script for protection of right click, etc--%>
    <style type="text/css">
        .protected
        {
            -moz-user-select: none;
            -webkit-user-select: none;
            user-select: none;
        }
        .style2
        {
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
        element.onmousedown = function() { return false; }        // For Mozilla Browser
    </script>

    <script type="text/javascript" language="javascript">
        function disableCntrl(e) {
            var key;
            var keychar;

            if (window.event) {
                key = window.event.keyCode;

                //17-cntrl, 83-s, 115-S
                if (key == 17 || key == 83 || key == 115)
                    return false;
                else return true;
            }

        }    
    </script>

    <%--windows.OnLoad() for session login using xml file --%>

    <script type="text/javascript" language="javascript">

        window.onload = function() {
            try {
                //setCookie1('ezeeUser123', '', -1);

                checkCookie();
            } catch (err) {
                alert(err.message);
            }
        }


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
            var exdate = new Date();
            exdate.setDate(exdate.getDate() + exdays);
            var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
            document.cookie = c_name + "=" + c_value;
        }

        function checkCookie() {
            try {
                var userName = getCookie("ezeeUser123");
                if (userName != null && userName != "") {
                    //alert(userName);
                    //  No local side it displays userName&mobNo=9766306701&CompanyId=16     but 
                    //  on server side it displays only username

                    // var nm = userName.split('&');
                    // nm[1] = nm[1].split('=')[1];
                    //document.getElementById('<%= lblLogin.ClientID %>').innerText = userName;
                }
                else {
                    window.location.assign("UserLogin.aspx");
                }
            }
            catch (err) {
                //alert(err.message);
            }
        }
        
    </script>

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

            if (parseInt(n) < parseInt(QuesTo)) {

                if (n == -1)
                    var nextQuesNo = 0;
                else
                    var nextQuesNo = parseInt(n) + 1;

                var str1 = "pnlQues" + nextQuesNo;
                var str2 = "pnlQues" + (parseInt(n));

                document.getElementById("<%=lblQues.ClientID%>").innerText = "Ques:" + nextQuesNo;

                document.getElementById(str1).style.display = "block";
                document.getElementById(str2).style.display = "none";

                document.getElementById("UC" + (nextQuesNo) + "_lblQNo").innerText = nextQuesNo + 1;

                if (document.forms[0].elements["timer1"].value == "" || n == -1) {
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

            if (parseInt(n) > 0) {
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
        var hr = 0, min = 0;
        function startTimer() {
            if (ID != null) {
                stopTimer();
            }

            var timeString = document.getElementById("UC-1_lblTime1").innerText;

            try {
                if (timeString.indexOf('&') > 0) {
                    hr = timeString.split('&')[0].split(' ')[0];
                    min = timeString.split('&')[1].split(' ')[1];
                }
                else {
                    hr = min = 0;
                    if (timeString.split(' ')[1] == "hrs")
                        hr = timeString.split(' ')[0];
                    if (timeString.split(' ')[1] == "mins")
                        min = timeString.split(' ')[0];
                }
            }
            catch (err) {
            }

            c1 = 60;    //sec
            c2 = min;   //min
            c3 = hr;    //hr
            ID = window.setInterval(run, 1000);

            //create array for number of ques
            for (var i = 0; i <= parseInt(QuesTo); i++) {
                examAns[i] = 0;
            }

            //Get history of answers for this login            
            var hisQ = checkCookieHistory();
            if (hisQ != null && hisQ != "") {
                var Qid = 0;

                for (var j = 0; j <= parseInt(QuesTo); j++) {
                    Qid = document.getElementById("UC" + j + "_lblQuestion_id").innerText;

                    try {
                        for (var i = 0; i <= parseInt(QuesTo); i++) {

                            if (Qid == hisQ.split('@')[i].split(':')[0])
                                examAns[j] = hisQ.split('@')[i].split(':')[1];
                        }
                    }
                    catch (e) { }
                }
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
                //stopTimer();
                finishExam();
            }
            else {
                if (c1 == 0) {
                    c1 = 60;
                    if (c3 != 0 && c2 == 0) {
                        c2 = 59;
                        c3--;
                    }
                    else c2--;
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

                document.getElementById("tblAnswer").style.display = "block";

                if (typeQues == "Type of Question : Basic Type" || typeQues == "Type of Question : Question On Passage" || typeQues == "Type of Question : Reasoning Type") {
                    document.getElementById("divrdoAnswerlist").style.display = "block";
                    document.getElementById("divchkAnslist").style.display = "none";
                    document.getElementById("divpnlAnsMat").style.display = "none";
                    document.getElementById("divtxtAns").style.display = "none";

                    //clear/select radio
                    if (examAns[v] == "0")
                        uncheckRadio();
                    else
                        checkRadio(v);
                }
                else if (typeQues == "Type of Question : Multiple Correct Choice") {
                    document.getElementById("divchkAnslist").style.display = "block";
                    document.getElementById("divrdoAnswerlist").style.display = "none";
                    document.getElementById("divpnlAnsMat").style.display = "none";
                    document.getElementById("divtxtAns").style.display = "none";

                    //clear/select Multiple
                    if (examAns[v] == "0")
                        uncheckMultiple();
                    else
                        checkMultiple(v);
                }
                else if (typeQues == "Type of Question : Integer Answer Type") {
                    document.getElementById("divtxtAns").style.display = "block";
                    document.getElementById("divchkAnslist").style.display = "none";
                    document.getElementById("divrdoAnswerlist").style.display = "none";
                    document.getElementById("divpnlAnsMat").style.display = "none";

                    //clear/select Multiple
                    if (examAns[v] == "0")
                        uncheckInteger();
                    else
                        checkInteger(v);
                }
                else if (typeQues == "Type of Question : Matrix Match Type") {
                    document.getElementById("divpnlAnsMat").style.display = "block";
                    document.getElementById("divrdoAnswerlist").style.display = "none";
                    document.getElementById("divchkAnslist").style.display = "none";
                    document.getElementById("divtxtAns").style.display = "none";

                    //clear/select matrix
                    if (examAns[v] == "0")
                        uncheckMatrix();
                    else
                        checkMatrix(v);
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
                //get current Ques No from Label value
                var Qno1 = (document.getElementById("<%=lblQues.ClientID%>").innerText.split("Ques:")[1]);
                var typeQues = document.getElementById("UC" + Qno1 + "_lbltypeQues").innerText;


                if (typeQues == "Type of Question : Basic Type" || typeQues == "Type of Question : Question On Passage" || typeQues == "Type of Question : Reasoning Type") {
                    

                    //Below New Changes added by jitu on 04/09/2014 
                    var abc = document.getElementById('<%=rdoAnswerlist.ClientID%>');
                    var mod = abc.children[0].children[0].cells;

                    for (var i = 0; i < 5; i++) {
                        var isChecked = mod[i].children[0].checked;
                        if (isChecked == true)
                            var ans = mod[i].children[0].value;
                    }
                    examAns[Qno1] = ans;


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
                    if (document.getElementById('<%=txtAns.ClientID%>').value != "")
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

                /******** make history of question and answers in cookies **********/
                testHistory();


                /******** Display next Question *********/
                nextQues();
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

        /******************* Create history of answers for this login in Cookies *****************/
        function testHistory() {
            var no = "";
            var ans = "";

            for (var i = 0; i < examAns.length; i++) {
                if (examAns[i] == "") { }
                else
                    ans = ans + document.getElementById("UC" + i + "_lblQuestion_id").innerText + ":" + examAns[i] + "@";
            }

            var CkId = "Qno" + document.getElementById("lblTestId").innerText;
            setCookie1History(CkId, ans, 2);
        }
    </script>

    <%--function to redirect to login page --%>

    <script type="text/javascript">
        function redirectToLoginPage() {
            window.location.assign("UserLogin.aspx");
        }
    </script>

    <%--function to finish exam --%>

    <script type="text/javascript" language="javascript">
        function confirmFinishExam() {

            var conf = confirm('Do you really want to Finish Exam!');
            if (conf == true) {
                finishExam();
                return true;
            }
            else return false;
        }

        //following function is important to display result of test at last
        function finishExam() {

            try {
                stopTimer();
                var QuesCurr = document.getElementById("<%=lblQues.ClientID%>").innerText;
                var QuesTo = document.getElementById("<%=lblQuesTo.ClientID%>").innerText;

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


                var totalQues = document.getElementById("<%=lblQuesTo.ClientID%>").innerText = examAns.length;
                var typeQues = document.getElementById("txtTotalQues").value = totalQues;

                var attemptQ = 0, correctQ = 0, incorrectQ = 0;

                for (i = 0; i < totalQues; i++) {
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

                var total = ('<%=Corrhidden3.ClientID%>');

                document.getElementById(total).value = correctQ;

                var total1 = ('<%=Atthidden2.ClientID%>');

                document.getElementById(total1).value = attemptQ;

                var total2 = ('<%=Incorrhidden4.ClientID%>');

                document.getElementById(total2).value = (attemptQ - correctQ);

                var total3 = ('<%=NotAnswered.ClientID%>');

                document.getElementById(total3).value = (totalQues - attemptQ);
            }
            catch (err) { alert(err); }
        }
    </script>

    <script type="text/javascript" language="javascript">
        function getCookieHistory(c_name) {
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

        function setCookie1History(c_name, value, exdays) {
            var exdate = new Date();
            exdate.setDate(exdate.getDate() + exdays);
            var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
            c_value = c_value + '; path=/';
            document.cookie = c_name + "=" + c_value;
        }

        function checkCookieHistory() {
            try {
                var CkId = "Qno" + document.getElementById("lblTestId").innerText;
                return getCookieHistory(CkId);
            }
            catch (err) {
            }
        }
    
    </script>

    <!--Below Lines Added by me on Dated 10.04.2015-->

    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function() { null };
    </script>

</head>
<body onkeydown="return disableCntrl(event)" onload = setInterval("window.clipboardData.setData('text','')",2) oncontextmenu = "return false" onselectstart = "return false">
    <form id="form1" name="timeForm" runat="server">
    <center>
        <div style="margin-bottom: 20px; margin-top: 1px; box-shadow: 1px 2px 7px #696969;
            width: 980px; height: 700px;">
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td class="header_bg" align="left" valign="bottom" colspan="2">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td class="tdHeader" rowspan="3">
                                    &nbsp;<img src="../Images/it.jpg" alt="Logo Image Abhinav IT Solutions" style="width: 139px;
                                        height: 78px" />&nbsp;
                                </td>
                                <td class="tdHeader">
                                    <asp:Label ID="lblTestId" runat="server" Width="50px" ForeColor="#FFFBD6" Text=""></asp:Label>
                                </td>
                                <td class="tdHeader" align="right" rowspan="3">
                                    <span class="loginName">Welcome :
                                        <asp:Label ID="lblLogin" runat="server" Text="Login"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdHeader" style="height: 70px; color: #FF8000; background-color: #FFFBD6;
                                    font-size: xx-large; font-family: 'Times New Roman', Times, serif; text-align: center;
                                    font-weight: 700;" align="left" valign="middle">
                                    <%=Convert.ToString(Session["TestName"])%>
                                    <asp:Label ID="lblQues" runat="server" ForeColor="#FFFBD6" Text="Ques:-1"></asp:Label>
                                    <asp:Label ID="lblQuesTo" runat="server" ForeColor="#FFFBD6" Text="0"></asp:Label>
                                    <asp:Label ID="lblTime0" runat="server" ForeColor="#FFFBD6" Text="0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdHeader">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <div>
                            <table style="width: 100%; font-family: Cambria; font-size: medium; color: #00CC00">
                                <tr>
                                    <td align="center">
                                        <span id="divTimer" class="displayBlock">
                                            <input type="text" name="timer1" disabled="disabled" class="timerControlClass" />
                                        </span>
                                    </td>
                                    <td align="center">
                                        <input id="btnFinish" type="button" value="Finish Exam" style="display: none; font-family: georgia;
                                            color: #287bae; font-weight: bold" onclick="confirmFinishExam()" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="middlediv">
                <table width="80%" align="center">
                    <tr>
                        <td class="tdMiddle" width="10%">
                            <input type="hidden" id="Corrhidden3" runat="server" />
                            <input type="hidden" id="Atthidden2" runat="server" />
                            <input type="hidden" id="Incorrhidden4" runat="server" />
                            <input type="hidden" id="NotAnswered" runat="server" />
                            <input type="button" id="btnBack" name="btnBack" value="<<" class="RoundedBtn" onclick="backQues()" />
                        </td>
                        <td align="left" style="border: thin solid #336699;" width="60%">
                            <asp:PlaceHolder ID="UCPlaceHolder" runat="server"></asp:PlaceHolder>
                        </td>
                        <td class="tdMiddle" width="10%">
                            <input type="button" id="btnNext" name="btnNext" value=">>" class="RoundedBtn" onclick="nextQues()" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="2">
                            <table id="tblAnswer" class="displayBlock" width="100%">
                                <tr>
                                    <td style="width: 50px">
                                        <asp:Label ID="lblAns" runat="server" Text="Answer" Style="display: none" Font-Size="Small"
                                            ForeColor="#CC3300" />
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
                                    </td>
                                    <td>
                                        <br />
                                        <input type="button" id="btnSubmit" value="Submit Answer" name="Submit" style="display: none;
                                            font-family: georgia; color: #287bae; font-weight: bold" onclick="GetListItem()" />
                                        <%-- <input type="button" id="btnClear" value="Clear" name="Clear" onclick="removeListItem()" />--%>
                                    </td>
                                    <td>
                                    </td>
                                    <td colspan="3">
                                        <br />
                                        <asp:Label ID="lblCountSolved" runat="server" Text="Solved" Font-Bold="true" ForeColor="Green"
                                            Visible="false"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td colspan="4">
                                        <br />
                                        <asp:Label ID="lblCountUnSolved" runat="server" Text="Unsolved" Font-Bold="true"
                                            ForeColor="Red" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </center>
    </form>
</body>
</html>
