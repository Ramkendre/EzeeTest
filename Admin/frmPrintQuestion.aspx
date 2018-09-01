<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPrintQuestion.aspx.cs"
    Inherits="Admin_frmPrintQuestion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Exam</title>
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
        element.onmousedown = function () { return false; }        // For Mozilla Browser
    </script>

    <script type="text/javascript" language="javascript">

        function add(obj) {

            var hgt = 10;
            var divHgt, setHg;
            var elementId = obj.id.split('_')[0];

            if (obj.id.split('_')[1] == "Passage") {
                document.getElementById(elementId + "_divPassage").style.display = "block";

                divHgt = document.getElementById(elementId + "_divPassage").offsetHeight;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divPassage").style.height = setHgt;
            }
            if (obj.id.split('_')[1] == "Question") {
                document.getElementById(elementId + "_divQuestion").style.display = "block";

                divHgt = document.getElementById(elementId + "_divQuestion").offsetHeight;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divQuestion").style.height = setHgt;
            }
            if (obj.id.split('_')[1] == "OptionA") {
                document.getElementById(elementId + "_divOptionA").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOptionA").offsetHeight;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divOptionA").style.height = setHgt;
            }
            if (obj.id.split('_')[1] == "OptionB") {
                document.getElementById(elementId + "_divOptionB").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOptionB").offsetHeight;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divOptionB").style.height = setHgt;
            }
            if (obj.id.split('_')[1] == "OptionC") {
                document.getElementById(elementId + "_divOptionC").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOptionC").offsetHeight;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divOptionC").style.height = setHgt;
            }
            if (obj.id.split('_')[1] == "OptionD") {
                document.getElementById(elementId + "_divOptionD").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOptionD").offsetHeight;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divOptionD").style.height = setHgt;
            }
            if (obj.id.split('_')[1] == "OptionE") {
                document.getElementById(elementId + "_divOptionE").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOptionE").offsetHeight;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divOptionE").style.height = setHgt;
            }
            return false;
        }

        function del(obj) {
            var hgt = 10;
            var divHgt, setHg;
            var elementId = obj.id.split('_')[0];

            if (obj.id.split('_')[1] == "PassageDel") {
                document.getElementById(elementId + "_divPassage").style.display = "block";

                divHgt = document.getElementById(elementId + "_divPassage").offsetHeight;
                setHgt = (divHgt - hgt) + "px";
                document.getElementById(elementId + "_divPassage").style.height = setHgt;
            }
            if (obj.id.split('_')[1] == "QuestionDel") {
                document.getElementById(elementId + "_divQuestion").style.display = "block";

                divHgt = document.getElementById(elementId + "_divQuestion").offsetHeight;
                setHgt = (divHgt - hgt) + "px";
                document.getElementById(elementId + "_divQuestion").style.height = setHgt;
            }
            if (obj.id.split('_')[1] == "OptionADel") {
                document.getElementById(elementId + "_divOptionA").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOptionA").offsetHeight;
                setHgt = (divHgt - hgt) + "px";
                document.getElementById(elementId + "_divOptionA").style.height = setHgt;
            }
            if (obj.id.split('_')[1] == "OptionBDel") {
                document.getElementById(elementId + "_divOptionB").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOptionB").offsetHeight;
                setHgt = (divHgt - hgt) + "px";
                document.getElementById(elementId + "_divOptionB").style.height = setHgt;
            }
            if (obj.id.split('_')[1] == "OptionCDel") {
                document.getElementById(elementId + "_divOptionC").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOptionC").offsetHeight;
                setHgt = (divHgt - hgt) + "px";
                document.getElementById(elementId + "_divOptionC").style.height = setHgt;
            }
            if (obj.id.split('_')[1] == "OptionDDel") {
                document.getElementById(elementId + "_divOptionD").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOptionD").offsetHeight;
                setHgt = (divHgt - hgt) + "px";
                document.getElementById(elementId + "_divOptionD").style.height = setHgt;
            }
            if (obj.id.split('_')[1] == "OptionEDel") {
                document.getElementById(elementId + "_divOptionE").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOptionE").offsetHeight;
                setHgt = (divHgt - hgt) + "px";
                document.getElementById(elementId + "_divOptionE").style.height = setHgt;
            }
            return false;
        }

        function SetMargin(obj) {
           
            var hgt = 10;
            var divHgt, setHg;
            var elementId = obj.id.split('_')[0];

            if (obj.id.split('_')[1] == "Passage") {
                document.getElementById(elementId + "_divPassage").style.display = "block";

                divHgt = document.getElementById(elementId + "_divPassage").offsetWidth;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divPassage").style.width = setHgt;
            }
            if (obj.id.split('_')[1] == "Question") {
                document.getElementById(elementId + "_divQuestion").style.display = "block";

                divHgt = document.getElementById(elementId + "_divQuestion").offsetWidth;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divQuestion").style.width = setHgt;
            }
            if (obj.id.split('_')[1] == "OptionA") {
                document.getElementById(elementId + "_divOptionA").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOptionA").offsetWidth;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divOptionA").style.width = setHgt;
            }
            if (obj.id.split('_')[1] == "moveleft") {
                document.getElementById(elementId + "_divOptionB").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOptionB").offsetWidth;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divOptionB").style.width = setHgt;
            }
            if (obj.id.split('_')[1] == "OptionC") {
                document.getElementById(elementId + "_divOptionC").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOptionC").offsetWidth;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divOptionC").style.width = setHgt;
            }
            if (obj.id.split('_')[1] == "OptionD") {
                document.getElementById(elementId + "_divOptionD").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOptionD").offsetWidth;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divOptionD").style.width = setHgt;
            }
            if (obj.id.split('_')[1] == "OptionE") {
                document.getElementById(elementId + "_divOptionE").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOptionE").offsetWidth;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divOptionE").style.width = setHgt;
            }

            return false;
        }

    </script>

    <style type="text/Css">
        .div1
        {
            position: absolute;
            left: 2%;
            margin-top: 60px;
        }

        .div2
        {
            position: absolute;
            left: 45%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="width: 595; height: 842">
        <center>
            <div id="tblPage" runat="server" style="width: 580; height: 810;">
                <div>
                    <table width="90%" style="width: 580; height: 810;" bgcolor="#EFECC0">
                        <tr>
                            <td colspan="4" style="font-size: x-large; font-weight: bold; color: #000000; text-align: center; font-family: 'times New Roman', Times, serif;">
                                <asp:Label ID="lblCollegeName" runat="server" Text="CollegeName" ForeColor="#EA4515"
                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="" colspan="2">
                                <asp:Label ID="lblTestName1" runat="server" Text="TestName : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblTestName" runat="server" Text="Test Name" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                <asp:Label ID="lblExamDurration1" runat="server" Text="Exam Duration : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblExamDurration" runat="server" Text="Exam Durration" Font-Bold="True"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblTotalQues1" runat="server" Text="Total Question : " Font-Bold="True"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblTotalQue" runat="server" Text="Total Question" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="border: groove 1px black; width: 100%;">
                </div>
                <br />
                <div id="td1" class="div1" runat="server" style="width: 50%; height: 800; top: 80px;">
                </div>
            </div>
        </center>
    </form>
</body>
</html>
