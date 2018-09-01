<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createtest.aspx.cs" MasterPageFile="~/Layout/AdminMaster.master"
    Inherits="CreateTest_createtest" %>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .img1
        {
            padding: 10px;
            margin: 10px;
            border: 5px solid blue;
            border-radius: 10px;
            box-shadow: 10px 10px 10px gray;
            width: 40%;
            height: 200px;
            background-color: yellow;
            float: left;
        }

        .img2
        {
            padding: 10px;
            margin: 10px;
            border: 5px solid blue;
            border-radius: 10px;
            box-shadow: 10px 10px 10px gray;
            width: 40%;
            height: 200px;
            background-color: yellow;
            float: right;
        }

        .img3
        {
            padding: 10px;
            margin: 10px;
            border: 5px solid blue;
            border-radius: 10px;
            box-shadow: 10px 10px 10px gray;
            width: 40%;
            height: 200px;
            background-color: yellow;
            float: left;
        }

        .img4
        {
            padding: 10px;
            margin: 10px;
            border: 5px solid blue;
            border-radius: 10px;
            box-shadow: 10px 10px 10px gray;
            width: 40%;
            height: 200px;
            background-color: yellow;
            float: right;
        }

        .img5
        {
            padding: 10px;
            margin: 10px;
            border: 5px solid blue;
            border-radius: 10px;
            box-shadow: 10px 10px 10px gray;
            width: 40%;
            height: 200px;
            background-color: yellow;
            float: left;
        }

        .img6
        {
            padding: 10px;
            margin: 10px;
            border: 5px solid blue;
            border-radius: 10px;
            box-shadow: 10px 10px 10px gray;
            width: 40%;
            height: 200px;
            background-color: yellow;
            float: right;
        }
        .img7
        {
            padding: 10px;
            margin: 10px;
            border: 5px solid blue;
            border-radius: 10px;
            box-shadow: 10px 10px 10px gray;
            width: 40%;
            height: 200px;
            background-color: yellow;
            float: right;
        }
        .tooltip
        {
            display: none;
            position: absolute;
            border: 1px solid #FFFACD;
            background-color: #FFFACD;
            border-radius: 5px;
            padding: 10px;
            color: #191970;
            font-size: 12px;
            font-weight: bold;
        }
    </style>

    <script src="../resources/JScript/jquery-1.11.1.js" type="text/javascript"></script>

    <script src="../resources/JScript/jquery-ui.js" type="text/javascript"></script>

    <script src="../resources/stylesheet/jquery-ui.theme.css" type="text/javascript"></script>

    <script type="text/javascript">

        $(document).ready(function () {


            // Tooltip only Text
            $('.masterTooltip').hover(function () {
                // Hover over code
                var title = $(this).attr('title');
                $(this).data('tipText', title).removeAttr('title');
                $('<p class="tooltip"></p>')
               .text(title)
               .appendTo('body')
               .fadeIn('slow');
            },
             function () {
                 // Hover out code
                 $(this).attr('title', $(this).data('tipText'));
                 $('.tooltip').remove();
             }).mousemove(function (e) {
                 var mousex = e.pageX + 20; //Get X coordinates
                 var mousey = e.pageY + 10; //Get Y coordinates
                 $('.tooltip')
                    .css({ top: mousey, left: mousex })
             });



        });

    </script>

    <div style="width: 100%; height: 100%;">
        
        <div class="img1">
            <asp:ImageButton ID="imgTestDefinition" AlternateText="Create Test and Assign to Students"
                CssClass="masterTooltip" runat="server" Width="100%" Height="100%" ImageUrl="~/CreateTest/TestDefinition.png"
                title="Create Test and Assign to Students" PostBackUrl="~/Admin/TestDefinition.aspx" />
        </div>
        <div class="img2">
            <asp:ImageButton ID="imgAddchapter" AlternateText="Assign Chapter to Test" CssClass="masterTooltip"
                runat="server" Width="100%" Height="100%" ImageUrl="~/CreateTest/AddChapter.png"
                title="Assign Chapter to Test" PostBackUrl="~/Admin/AddExamChapter.aspx" />
        </div>
        <div class="img3">
            <asp:ImageButton ID="imgAddQuestionsMethod1" AlternateText="Add Questions to Test Method1"
                runat="server" Width="100%" Height="100%" ImageUrl="~/CreateTest/Method1.png"
                title="Add Questions to Test Method1" CssClass="masterTooltip" PostBackUrl="~/Admin/AssignQuestionInExam.aspx" />
        </div>
        <div class="img4">
            <asp:ImageButton ID="imgAddquestionsMethod2" AlternateText="Add Questions to Test Method2"
                runat="server" Width="100%" Height="100%" ImageUrl="~/CreateTest/Method2.png"
                title="Add Questions to Test Method2" CssClass="masterTooltip" PostBackUrl="~/SubAdmin/GridView.aspx" />
        </div>
        <div class="img5">
            <asp:ImageButton ID="imgCreateTheoryQuestionPaper" AlternateText="Add Questions to Theory Question Paper"
                runat="server" Width="100%" Height="100%" ImageUrl="~/CreateTest/TheoryQues.png"
                title="Add Question to Theory Question Paper" CssClass="masterTooltip" PostBackUrl="~/Admin/TheoryQuestionPaperAdd.aspx" />
        </div>
        <div class="img6">
            <asp:ImageButton ID="imgPrintTest" AlternateText="Print Your Test" runat="server"
                Width="100%" Height="100%" ImageUrl="~/CreateTest/print.png" title=" Take PrintOut of Your Test"
                CssClass="masterTooltip" PostBackUrl="~/SubAdmin/TakePrintOut.aspx" />
        </div>
        <div class="img5">
            <asp:ImageButton ID="imgDailyQuestions" AlternateText="Prepare Daily Questions" runat="server"
                Width="100%" Height="100%" ImageUrl="~/CreateTest/daily.png" title="Prepared Daily Quesrions...!!!"
                CssClass="masterTooltip" PostBackUrl="~/SubAdmin/RSBCustomerTestDefine.aspx" />
        </div>
        <div class="img6">
            <asp:ImageButton ID="imgAudioVideoList" AlternateText="Upload Audio/Video" runat="server"
                Width="100%" Height="100%" ImageUrl="~/CreateTest/AVUpload.png" title="Upload Audio and Video List...!!!"
                CssClass="masterTooltip" PostBackUrl="~/SubAdmin/AudiVideoUpload.aspx" />
        </div>
        <div class="img5">
            <asp:ImageButton ID="imgFeedback" AlternateText="Feedback Details" runat="server"
                Width="100%" Height="100%" ImageUrl="~/CreateTest/imgFeedback.jpg" title="Get Feedback Details.!!!"
                CssClass="masterTooltip" PostBackUrl="~/SubAdmin/eZeetestAppFeedback.aspx" />
        </div>
         <div class="img6">
            <asp:ImageButton ID="imgUsrMarksDetails" AlternateText="User Marks Details" runat="server"
                Width="100%" Height="100%" ImageUrl="~/CreateTest/imgMarksDetails.png" title="Get User Marks Details.!!!"
                CssClass="masterTooltip" PostBackUrl="~/SubAdmin/StudentScoreReport.aspx" />
        </div>

        <div class="img5">
            <asp:ImageButton ID="imgInsertChapters" AlternateText="Insert Chapters & Topics" runat="server"
                Width="100%" Height="100%" ImageUrl="~/CreateTest/InsertChapters.jpg" title="Insert Chapters & Topics Names.!!!"
                CssClass="masterTooltip" PostBackUrl="~/SubAdmin/GiveNamestoChapters.aspx" />
        </div>

        <div class="img6">
            <asp:ImageButton ID="imgAppItemMaster" AlternateText="App Item Masters" runat="server"
                Width="100%" Height="100%" ImageUrl="~/CreateTest/appitem.jpg" title="Insert App Item Masters.!!!"
                CssClass="masterTooltip" PostBackUrl="~/SubAdmin/AddAppItemMaster.aspx" />
        </div>
        <div class="img5">
            <asp:ImageButton ID="imgAdvertisement" AlternateText="Insert Advertisement" runat="server" 
                Width="100%" Height="100%" ImageUrl="~/CreateTest/Advimg.jpg" title="Insert Advertisement...!!!"
                CssClass="masterTooltip" PostBackUrl="~/SubAdmin/Advertisement.aspx" />
        </div>
        <div class="img7">
            <asp:ImageButton ID="ImgTrainingReport" AlternateText="Training Report Details" runat="server"
                Width="100%" Height="100%" ImageUrl="~/CreateTest/TrningReport.png" title="Training Report Record Display.!!!"
                CssClass="masterTooltip" PostBackUrl="~/SubAdmin/TrainingReport.aspx" />
        </div>
    </div>
    
</asp:Content>
