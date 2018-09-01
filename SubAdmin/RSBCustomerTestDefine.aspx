<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RSBCustomerTestDefine.aspx.cs"
    MasterPageFile="~/Layout/AdminMaster.master" Inherits="SubAdmin_RSBCustomerTestDefine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .checkbx {
            float: left;
        }

        .textbx {
            margin-top: 2px;
        }

        .divLabel {
            float: left;
            margin-left: 150px;
        }

        .divTextBox {
            float: right;
            margin-right: 390px;
        }

        .gridview {
            background-color: #f2f9f8;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
            font-family: Arial;
        }

            .gridview td {
                padding: 2px;
                border: solid 1px #c1c1c1;
                color: black;
                font-size: 12px;
            }

                .gridview td:hover {
                    padding: 2px;
                    border: solid 1px #c1c1c1;
                    font-size: 13px;
                    background: #dddddd;
                }

            .gridview th {
                padding: 4px 2px;
                color: #fff;
                background: #164854;
                border-left: solid 1px #525252;
                font-size: 12px;
            }

            .gridview .gridview_alter {
                background: #E7E7E7;
            }

            .gridview .gridview_pager {
                background: #424242;
            }

                .gridview .gridview_pager table {
                    margin: 5px 0;
                }

                .gridview .gridview_pager td {
                    border-width: 0;
                    padding: 0 6px;
                    border-left: solid 1px #666;
                    font-weight: bold;
                    color: #fff;
                    line-height: 12px;
                }

                .gridview .gridview_pager a {
                    color: #666;
                    text-decoration: none;
                }

                    .gridview .gridview_pager a:hover {
                        color: #000;
                        text-decoration: none;
                    }
    </style>

    <script language="javascript" type="text/javascript">
        function setTimeForSubmit() {
            window.setTimeout("submitForm()", 1500000); //Expire after 25 min
        }
        function submitForm() {
            document.forma.submit();
        }

        function check(checkbox) {
            var cbl = document.getElementById('<%=ddlChapter.ClientID %>').getElementsByTagName("input");
            for (i = 0; i < cbl.length; i++)
                cbl[i].checked = checkbox.checked;
        }


    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div align="center">
                <div style="border: solid 3px Black; width: 70%; height: 1100px;">
                    <div align="center" style="font-family: Tahoma; font-weight: bold; font-size: medium;">
                        Define Your Test
                    </div>
                    <hr />
                    <div class="divLabel">
                        <asp:Label ID="lblInstruction" runat="server" ForeColor="Red" Text="All Fields are Mandatory."></asp:Label>
                    </div>
                    &nbsp;&nbsp;
                    <div style="float: left;">
                        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                        &nbsp;&nbsp;
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblTestName" runat="server" Text="Enter TestName" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="divTextBox">
                        <asp:TextBox ID="txtTestName" runat="server" Width="190px" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ControlToValidate="txtTestName"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblTotalNoQues" runat="server" Text="Enter Total Ques" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="divTextBox">
                        <asp:TextBox ID="txtTotalNoQues" runat="server" Width="190px" onkeypress="return numbersonly(this,event)"
                            MaxLength="3"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ControlToValidate="txtTotalNoQues"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblNoofRepeat" runat="server" Text="Ques Set Repeat" Font-Size="Medium"></asp:Label>
                    </div>
                    <div style="float: right; margin-right: 400px;">
                        <asp:TextBox ID="txtNoofRepeat" runat="server" Width="190px" onkeypress="return numbersonly(this,event)"
                            MaxLength="2"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                    ControlToValidate="txtNoofRepeat"></asp:RequiredFieldValidator>--%>
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblTestDuration" runat="server" Text="Enter Test Duration" Font-Size="Medium"></asp:Label>
                    </div>
                    <div style="float: right; margin-right: 370px;">
                        <asp:TextBox ID="txtTestDuration" runat="server" Width="190px" onkeypress="return numbersonly(this,event)"
                            MaxLength="3"></asp:TextBox>Min
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                            ControlToValidate="txtTestDuration"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblMedium" runat="server" Font-Size="Medium" Text="Select Medium"></asp:Label>
                    </div>
                    <div style="float: right; margin-right: 490px;">
                        <asp:DropDownList ID="ddlMedium" runat="server">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">English</asp:ListItem>
                            <asp:ListItem Value="2">Semi-English</asp:ListItem>
                            <asp:ListItem Value="3">Marathi</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblGroupofExam" runat="server" Text="Select Type of Exam" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="divTextBox">
                        <asp:DropDownList ID="ddlGroupofExam" runat="server" Width="195px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlGroupofExam_SelectedIndexChanged">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="135">(0-10th)StateBoard</asp:ListItem>
                            <asp:ListItem Value="136">(0-12)th CBSE</asp:ListItem>
                            <asp:ListItem Value="137">(0-12)th ICSE</asp:ListItem>
                            <asp:ListItem Value="140">Scholarship</asp:ListItem>
                            <asp:ListItem Value="143">Competitive Exam</asp:ListItem>
                            <asp:ListItem Value="141">Engineering Entrance</asp:ListItem>
                            <asp:ListItem Value="142">Medical Entrance</asp:ListItem>
                            <asp:ListItem Value="144">Computer Courses</asp:ListItem>
                            <asp:ListItem Value="177">Skill Tests</asp:ListItem>
                            <asp:ListItem Value="231">BE/B.TECH (CSE)</asp:ListItem>
                            <asp:ListItem Value="257">NIITAPS Exam Group</asp:ListItem>
                            <asp:ListItem Value="273">One Year Courses</asp:ListItem>
                            <asp:ListItem Value="274">6 Months Courses</asp:ListItem>
                            <asp:ListItem Value="275">3 Months Courses</asp:ListItem>
                            <asp:ListItem Value="276">2 Months Courses</asp:ListItem>
                            <asp:ListItem Value="277">1 Months Courses</asp:ListItem>
                            <asp:ListItem Value="278">Other Program</asp:ListItem>
                            <asp:ListItem Value="445">STP-YASHADA</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                            InitialValue="0" ControlToValidate="ddlGroupofExam"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblTypeofExam" runat="server" Text="Select ExamName" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="divTextBox">
                        <asp:DropDownList ID="ddlTypeofExam" runat="server" Width="195px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlTypeofExam_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="1"
                            ErrorMessage="*" ControlToValidate="ddlTypeofExam"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblClassName" runat="server" Text="Select Class Name" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="divTextBox">
                        <asp:DropDownList ID="ddlClassName" runat="server" Width="195px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlClassName_SelectedIndexChanged">
                            <asp:ListItem Value="1">--Select--</asp:ListItem>
                        </asp:DropDownList>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" InitialValue="1"
                            ErrorMessage="*" ControlToValidate="ddlClassName"></asp:RequiredFieldValidator>--%>
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblSubjectName" runat="server" Text="Select Subject Name" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="divTextBox">
                        <asp:DropDownList ID="ddlSubjectName" runat="server" Width="195px">
                            <asp:ListItem Value="1">--Select--</asp:ListItem>
                        </asp:DropDownList>
                        <%--<asp:CheckBoxList ID="chkSubject" runat="server" Font-Size="Medium">
                </asp:CheckBoxList> class="container"--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                            InitialValue="1" ControlToValidate="ddlSubjectName"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblChapterName" runat="server" Text="Select Chapter" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="container" style="float: right; margin-right: 390px;">
                        <asp:CheckBox ID="ChkSelectALL" runat="server" OnClick="check(this)" Text="Select ALL Chapter"
                            Visible="false" CssClass="checkbx" />
                        <asp:CheckBoxList ID="ddlChapter" runat="server" RepeatColumns="1" BorderWidth="0px"
                            Datafield="description" CssClass="checkbx" DataValueField="value">
                        </asp:CheckBoxList>
                        <div style="float: right; margin-right: 20px; top: auto; vertical-align: top;">
                            <asp:TextBox ID="TextBox0" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp1"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox1" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp2"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox2" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp3"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox3" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp4"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox4" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp5"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox5" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp6"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox6" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp7"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox7" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp8"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox8" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp9"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox9" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp10"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox10" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp11"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox11" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp12"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox12" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp13"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox13" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp14"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox14" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp15"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox15" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp16"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox16" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp17"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox17" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp18"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox18" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp19"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox19" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp20"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox20" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp21"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox21" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp22"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox22" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp23"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox23" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp24"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox24" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp25"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox25" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp26"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox26" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp27"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox27" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp28"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox28" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp29"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox29" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp30"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox30" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp31"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox31" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp32"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox32" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp33"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox33" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp34"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox34" runat="server" Width="40px" Height="15px" CssClass="textbx"
                                MaxLength="3" placeholder="Chp35"></asp:TextBox><br />
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblMarkForCorrA" runat="server" Font-Size="Medium" Text="Marks For Correct Ans"></asp:Label>
                    </div>
                    <div style="float: right; margin-right: 490px;">
                        <asp:TextBox ID="txtMarkForCorrA" runat="server" onkeypress="return numbersonly(this,event)"
                            CssClass="txtcss" MaxLength="3"></asp:TextBox>
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblMarkForPass" runat="server" Font-Size="Medium" Text="Marks For Passing"></asp:Label>
                    </div>
                    <div style="float: right; margin-right: 490px;">
                        <asp:TextBox ID="txtMarkForPass" runat="server" onkeypress="return numbersonly(this,event)"
                            CssClass="txtcss" MaxLength="3"></asp:TextBox>
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblRetakeallow" runat="server" Font-Size="Medium" Text="Retake Allow"></asp:Label>
                    </div>
                    <div style="float: right; margin-right: 490px;">
                        <asp:RadioButtonList ID="rdolstretake" Font-Size="Medium" RepeatDirection="Horizontal"
                            runat="server">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblBreakAllow" runat="server" Font-Size="Medium" Text="Break Allow"></asp:Label>
                    </div>
                    <div style="float: right; margin-right: 490px;">
                        <asp:RadioButtonList ID="rdolstBreak" Font-Size="Medium" RepeatDirection="Horizontal"
                            runat="server">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblReverseNavigation" runat="server" Font-Size="Medium" Text="Reverse Navigation"></asp:Label>
                    </div>
                    <div style="float: right; margin-right: 490px;">
                        <asp:RadioButtonList ID="rdolstReverseNavi" Font-Size="Medium" RepeatDirection="Horizontal"
                            runat="server">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblNegativeMarks" runat="server" Font-Size="Medium" Text="Negative Marking"></asp:Label>
                    </div>
                    <div style="float: right; margin-right: 490px;">
                        <asp:RadioButtonList ID="rdolstNegativeMarks" Font-Size="Medium" AutoPostBack="true"
                            OnSelectedIndexChanged="rdolstNegativeMarks_SelectedIndexChanged" RepeatDirection="Horizontal"
                            runat="server">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblIfYes" runat="server" Font-Size="Medium" Text="If Yes"></asp:Label>
                    </div>
                    <div style="float: right; margin-right: 490px;">
                        <asp:TextBox ID="txtIfYes" onkeypress="return numbersonly(this,event)" CssClass="txtcss"
                            MaxLength="3" runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <br />
                    <div class="divLabel">
                        <asp:Label ID="lblTestType" runat="server" Font-Size="Medium" Text="Select TypeofTest"></asp:Label>
                    </div>
                    <div style="float: right; margin-right: 490px;">
                        <asp:DropDownList ID="ddlTypeofTest" runat="server">
                            <asp:ListItem Value="0">Free Test</asp:ListItem>
                            <asp:ListItem Value="1">Premium Test</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div style="float: left; margin-left: 350px;">
                        <asp:Button ID="btnCreateTest" runat="server" Text="Create Test !!!" CssClass="btn"
                            OnClick="btnCreateTest_Click" />
                        <asp:Label ID="lblSubjectID" runat="server" Visible="false"></asp:Label>
                    </div>
                    <div style="float: right; margin-right: 150px">
                        <asp:LinkButton ID="lnkbtnRSBTestHome" runat="server" Font-Size="Medium" Text="Go For Test !!!"
                            ForeColor="Green" Font-Underline="true" Font-Bold="true" Visible="false" CausesValidation="false"
                            OnClick="lnkbtnRSBTestHome_Click"></asp:LinkButton>
                    </div>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="lblResult" runat="server" Visible="false" Text="Label"></asp:Label><br />
                    <div style="float: left; margin-left: 5px; width: 96%">
                        <asp:GridView ID="gvRSBTestList" runat="server" OnPageIndexChanging="gvRSBTestList_PageIndexChanging"
                            AutoGenerateColumns="false" OnRowCommand="gvRSBTestList_RowCommand" DataKeyNames="Test_ID"
                            AllowPaging="true" CssClass="gridview" PageSize="5" OnRowDataBound="gvRSBTestList_RowDataBound"
                            EmptyDataText="No Question Papers Available For This Combination...">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr_No.">
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <center>
                                            <%#Container.DataItemIndex + 1%></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Test_ID" DataField="Test_ID" Visible="true">
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Test_Name" DataField="Exam_name" Visible="true">
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Test Date" DataFormatString="{0:dd-M-yyyy}" DataField="Exam_date" Visible="true">
                                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Test_Duration (Minute)" DataField="Exam_duration" Visible="true">
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Exam Name" DataField="ExamName" Visible="true">
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Class" DataField="ClassName" Visible="true">
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Subject" DataField="SubjectName" Visible="true">
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Chapters" DataField="ChapterName" Visible="true">
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="TotalQues" DataField="TotNoQues" Visible="true">
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Prepare_Test">
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <center>
                                            <asp:LinkButton ID="lnkbtnPrepareTest" CausesValidation="false" Font-Bold="true"
                                                CommandArgument='<%#Bind("Test_ID") %>' CommandName="Prepare_Test" runat="server"
                                                Text="Prepare_Test"></asp:LinkButton>
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemStyle Width="4%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <center>
                                            <asp:LinkButton ID="lnkbtnDelete" CausesValidation="false" Font-Bold="true" CommandArgument='<%#Bind("Test_ID")%>'
                                                OnClientClick="if(!confirm(' Are you sure you want delete All Question related to this Test Name ?')) return false;" CommandName="Delete" runat="server" Text="Delete"></asp:LinkButton>
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <asp:Label ID="lblChapterID" runat="server" Visible="false"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
