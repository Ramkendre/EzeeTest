<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPrintTheoryQues.aspx.cs"
    Inherits="frmPrintTheoryQues" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Online Exam</title>
    <link href="../resources/stylesheet/styleExamControl.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        @media print
        {
            .hidewhileprinting
            {
                display: none;
            }
        }
    </style>
    <style type="text/css">
        .divremovespace
        {
            margin-top: -20px;
        }
    </style>



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
        window.print();
    </script>

    <script type="text/javascript" language="javascript">

        function add(obj) {
            var hgt = 10;
            var divHgt, setHg;
            var elementId = obj.id.split('_')[0];

            if (obj.id.split('_')[1] == "lbInstruction") {
                document.getElementById(elementId + "_divInstruction").style.display = "block";

                divHgt = document.getElementById(elementId + "_divInstruction").offsetHeight;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divInstruction").style.height = setHgt;
            }

            if (obj.id.split('_')[1] == "Question") {
                document.getElementById(elementId + "_divQuestion").style.display = "block";

                divHgt = document.getElementById(elementId + "_divQuestion").offsetHeight;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divQuestion").style.height = setHgt;
            }

            if (obj.id.split('_')[1] == "lbOR") {
                document.getElementById(elementId + "_divOR").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOR").offsetHeight;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divOR").style.height = setHgt;
            }

            if (obj.id.split('_')[1] == "lbHeading") {
                document.getElementById(elementId + "_divHeading").style.display = "block";

                divHgt = document.getElementById(elementId + "_divHeading").offsetHeight;
                setHgt = (divHgt + hgt) + "px";
                document.getElementById(elementId + "_divHeading").style.height = setHgt;
            }

            return false;
        }

        function del(obj) {
            var hgt = 10;
            var divHgt, setHg;
            var elementId = obj.id.split('_')[0];


            if (obj.id.split('_')[1] == "lbInstructionDel") {
                document.getElementById(elementId + "_divInstruction").style.display = "block";

                divHgt = document.getElementById(elementId + "_divInstruction").offsetHeight;
                setHgt = (divHgt - hgt) + "px";
                document.getElementById(elementId + "_divInstruction").style.height = setHgt;
            }

            if (obj.id.split('_')[1] == "QuestionDel") {
                document.getElementById(elementId + "_divQuestion").style.display = "block";

                divHgt = document.getElementById(elementId + "_divQuestion").offsetHeight;
                setHgt = (divHgt - hgt) + "px";
                document.getElementById(elementId + "_divQuestion").style.height = setHgt;
            }


            if (obj.id.split('_')[1] == "lbORDel") {
                document.getElementById(elementId + "_divOR").style.display = "block";

                divHgt = document.getElementById(elementId + "_divOR").offsetHeight;
                setHgt = (divHgt - hgt) + "px";
                document.getElementById(elementId + "_divOR").style.height = setHgt;
            }

            if (obj.id.split('_')[1] == "lbHeadingDel") {
                document.getElementById(elementId + "_divHeading").style.display = "block";

                divHgt = document.getElementById(elementId + "_divHeading").offsetHeight;
                setHgt = (divHgt - hgt) + "px";
                document.getElementById(elementId + "_divHeading").style.height = setHgt;
            }

            return false;
        }
    </script>

    <style type="text/Css">
        .div1
        {
            position: absolute;
            left: 2%;
            margin-top: 40px;
        }

        .div2
        {
            position: absolute;
            left: 45%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server"> 
        
        <center>
            <div id="tblPage" runat="server">
                <div>
                    <table width="90%"; bgcolor="#EFECC0">
                        <tr>
                            <td colspan="4" style="font-size: x-large; font-weight: bold; color: #000000; text-align: center; font-family: 'times New Roman', Times, serif;">
                                <asp:Label ID="lblCollegeName" runat="server" Text="CollegeName" ForeColor="#EA4515"
                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="" colspan="4">

                                <asp:Label ID="lblTestName" runat="server" Text="Test Name" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                <asp:Label ID="lblExamDurration1" runat="server" Text="Exam Duration : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblExamDurration" runat="server" Text="Exam Durration" Font-Bold="True"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblTotalQues1" runat="server" Text="Marks : " Font-Bold="True"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblTotalQue" runat="server" Text="Total Question" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="border: groove 1px black; width: 100%;">
                </div>
                <div id="td1" class="div1" runat="server" style="width: 100%; top: 55px; bottom:311px;">
                    <table width="90%">
                        <tr>
                            <td style="text-align: left">
                                <h5 style="color: darkorange;font-family:'Courier New'">INSTRUCTIONS :</h5>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </center>
    </form>
</body>
</html>
