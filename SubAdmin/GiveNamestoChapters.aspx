<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GiveNamestoChapters.aspx.cs" MasterPageFile="~/Layout/AdminMaster.master" Inherits="SubAdmin_GiveNamestoChapters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../resources/JScript/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../resources/JScript/jquery-ui.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            $(function () {
                $("#<%=btnClear.ClientID%>").click(function () {

                    $("#<%=ddlGroupofExam.ClientID%>").val(1);
                    $("#<%=ddlTypeofExam.ClientID%>").val(1);
                    $("#<%=ddlState.ClientID%>").val(1);
                    $("#<%=ddlDistrict.ClientID%>").val(1);
                    $("#<%=txtBoard.ClientID%>").val('');
                    $("#<%=txtUniversity.ClientID%>").val('');
                    $("#<%=ddlMedium.ClientID%>").val(1);
                    $("#<%=ddlClass.ClientID%>").val(1);
                    $("#<%=ddlSubject.ClientID%>").val(1);
                    $("#<%=ddlPublication.ClientID%>").val(1);
                    $("#<%=ddlChapter.ClientID%>").val(0);
                    $("#<%=txtChapterName.ClientID%>").val('');
                    $("#<%=ddlTopic.ClientID%>").val(0);
                    $("#<%=txtTopicName.ClientID%>").val('');
                    return false;
                });

            });

            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (prm != null) {
                prm.add_endRequest(function (sender, e) {
                    if (sender._postBackSettings.panelsToUpdate != null) {

                        $(function () {
                            $("#<%=btnClear.ClientID%>").click(function () {

                                $("#<%=ddlGroupofExam.ClientID%>").val(1);
                                $("#<%=ddlTypeofExam.ClientID%>").val(1);
                                $("#<%=ddlState.ClientID%>").val(1);
                                $("#<%=ddlDistrict.ClientID%>").val(1);
                                $("#<%=txtBoard.ClientID%>").val('');
                                $("#<%=txtUniversity.ClientID%>").val('');
                                $("#<%=ddlMedium.ClientID%>").val(1);
                                $("#<%=ddlClass.ClientID%>").val(1);
                                $("#<%=ddlSubject.ClientID%>").val(1);
                                $("#<%=ddlPublication.ClientID%>").val(1);
                                $("#<%=ddlChapter.ClientID%>").val(1);
                                $("#<%=txtChapterName.ClientID%>").val('');
                                $("#<%=ddlTopic.ClientID%>").val(0);
                                $("#<%=txtTopicName.ClientID%>").val('');
                                return false;
                            });
                        });
                    }
                });
            };
        });

    </script>


    <style type="text/css">
        .dap_text_box { /*EBEAC8*/
            background: #EBEAC8;
            color: #804811;
            border: 2px solid #12F00E;
            border-radius: 4px;
            font-size: 15px;
            height: 18px;
            line-height: 22px;
            width: 196px;
            /*padding: 8px;*/
            box-shadow: 2px 1px 2px #E7DAED;
            -webkit-box-shadow: 2px 1px 2px #E7DAED;
            -moz-box-shadow: 2px 1px 2px #E7DAED;
            margin-top: 15px;
        }

        .dap_drop_box {
            width: 200px;
            /*padding: 8px;*/
            border: 2px solid #93f35c;
            border-radius: 6px;
            font-family: Consolas;
            font-size: 12px;
            background-color: #EBEAC8;
            margin-top: 15px;
        }

        .forbox {
            width: 49%;
            float: left;
            text-align: left;
            margin-top: 15px;
            margin-left: 15px;
        }

        .forbox1 {
            width: 49%;
            float: left;
            text-align: right;
            margin-top: 15px;
        }

        .labelFont {
            font-family: Garamond;
            font-size: 12px;
            color: blueviolet;
            font-weight: bold;
            /*padding-top: 20px;*/
        }

        .labelStatus {
            font-family: 'Courier New';
            font-size: 13px;
            font-weight: bold;
            /*background-color:crimson;*/
            margin-top: 8px;
        }

        .button {
            border-top: 1px solid #97e9f7;
            background: #e6e315;
            background: -webkit-gradient(linear, left top, left bottom, from(#10e887), to(#e6e315));
            background: -webkit-linear-gradient(top, #10e887, #e6e315);
            background: -moz-linear-gradient(top, #10e887, #e6e315);
            background: -ms-linear-gradient(top, #10e887, #e6e315);
            background: -o-linear-gradient(top, #10e887, #e6e315);
            padding: 7px 14px;
            -webkit-border-radius: 9px;
            -moz-border-radius: 9px;
            border-radius: 9px;
            -webkit-box-shadow: rgba(0,0,0,1) 0 1px 0;
            -moz-box-shadow: rgba(0,0,0,1) 0 1px 0;
            box-shadow: rgba(0,0,0,1) 0 1px 0;
            text-shadow: rgba(0,0,0,.4) 0 1px 0;
            color: #2c782f;
            font-size: 19px;
            font-family: Consolas;
            text-decoration: none;
            vertical-align: middle;
            margin-top: 15px;
        }

            .button:hover {
                border-top-color: #458f1b;
                background: #458f1b;
                color: #bacf1b;
                cursor: pointer;
            }

            .button:active {
                border-top-color: #f27516;
                background: #f27516;
            }

        .gridview {
            background-color: #f3f090;
            margin: 5px 0 10px 0;
            border: 2px solid #05c705;
            border-collapse: collapse;
            font-family: Calibri;
        }

            .gridview td {
                padding: 2px;
                border: 1px solid black;
                color: #905011;
                font-size: 10px;
            }

                .gridview td:hover {
                    padding: 2px;
                    border: solid 1px #c1c1c1;
                    font-size: 12px;
                    background: #b6ff00;
                }

            .gridview th {
                padding: 6px 3px;
                color: #905011;
                background: #6cf66c;
                border: 1px solid black;
                font-size: 13px;
            }

            .gridview .gridview_alter {
                background: #E7E7E7;
            }

            .gridview .gridview_pager {
                background: #05c705;
            }

                .gridview .gridview_pager table {
                    margin: 5px 0;
                }

                .gridview .gridview_pager td {
                    border-width: 0;
                    padding: 0 6px;
                    border-left: 1px solid #905011;
                    font-weight: bold;
                    color: #fff;
                    line-height: 13px;
                }

                .gridview .gridview_pager a {
                    color: #666;
                    text-decoration: none;
                }

                    .gridview .gridview_pager a:hover {
                        color: #b6ff00;
                        text-decoration: none;
                    }
    </style>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div align="Center">
                <div style="border: 3px solid #030303; width: 70%; height: 600px;">

                    <div style="border: 1px solid green; width: 100%; height: 30px; margin-top: 15px; background-color: green;" align="center">
                        <div style="margin-top: 5px;">
                            <asp:Label ID="lblHeading" runat="server" Text="INSERT CHAPTERS AND TOPICS NAMES" Style="margin-top: 5px; font-family: 'Courier New'; font-size: medium; font-style: normal; font-weight: bold; color: white;"></asp:Label>
                        </div>
                    </div>

                    <asp:Label ID="lblStatus" runat="server" Text="" CssClass="labelStatus"></asp:Label>

                    <div>
                        <div class="forbox1">
                            <div class="labelFont" style="padding-top: 20px;">
                                <asp:Label ID="lblGroupofExam" runat="server" Text="SELECT GROUP OF EXAMS"></asp:Label>
                                &nbsp :
                            </div>

                            <div class="labelFont" style="padding-top: 20px;">
                                <asp:Label ID="lblTypeofExam" runat="server" Text="SELECT TYPE OF EXAMS" CssClass="labelFont"></asp:Label>
                                &nbsp:
                            </div>
                            <div class="labelFont" style="padding-top: 22px;">
                                <asp:Label ID="lblState" runat="server" Text="SELECT STATE" CssClass="labelFont"></asp:Label>
                                &nbsp:
                            </div>
                            <div class="labelFont" style="padding-top: 22px;">
                                <asp:Label ID="lblDistrict" runat="server" Text="SELECT DISTRICT" CssClass="labelFont"></asp:Label>
                                &nbsp  :
                            </div>
                            <div class="labelFont" style="padding-top: 22px;">
                                <asp:Label ID="lblBoard" runat="server" Text="ENTER BOARD NAME" CssClass="labelFont"></asp:Label>
                                &nbsp:
                            </div>
                            <div class="labelFont" style="padding-top: 26px;">
                                <asp:Label ID="lblUniversity" runat="server" Text="ENTER UNIVERSITY NAME" CssClass="labelFont"></asp:Label>
                                &nbsp :
                            </div>
                            <div class="labelFont" style="padding-top: 26px;">
                                <asp:Label ID="lblMedium" runat="server" Text="SELECT MEDIUM" CssClass="labelFont"></asp:Label>
                                &nbsp :
                            </div>
                            <div class="labelFont" style="padding-top: 24px;">
                                <asp:Label ID="lblClass" runat="server" Text="SELECT CLASS" CssClass="labelFont"></asp:Label>
                                &nbsp:
                            </div>
                            <div class="labelFont" style="padding-top: 22px;">
                                <asp:Label ID="lblSubject" runat="server" Text="SELECT SUBJECT" CssClass="labelFont"></asp:Label>
                                &nbsp:
                            </div>
                            <div class="labelFont" style="padding-top: 22px;">
                                <asp:Label ID="lblPublication" runat="server" Text="SELECT PUBLICATION" CssClass="labelFont"></asp:Label>
                                &nbsp:
                            </div>
                            <div class="labelFont" style="padding-top: 22px;">
                                <asp:Label ID="lblChapter" runat="server" Text="SELECT CHAPTER" CssClass="labelFont"></asp:Label>
                                &nbsp :
                            </div>
                            <div class="labelFont" style="padding-top: 22px;">
                                <asp:Label ID="lblChapterName" runat="server" Text="ENTER CHAPTER NAME" CssClass="labelFont"></asp:Label>
                                &nbsp: 
                            </div>
                            <div class="labelFont" style="padding-top: 22px;">
                                <asp:Label ID="lblTopic" runat="server" Text="SELECT TOPIC" CssClass="labelFont"></asp:Label>
                                &nbsp :
                            </div>
                            <div class="labelFont" style="padding-top: 22px;">
                                <asp:Label ID="lblTopicName" runat="server" Text="ENTER TOPIC NAME" CssClass="labelFont"></asp:Label>
                                &nbsp: 
                            </div>
                            <div style="padding-top: 20px;">
                                <asp:Button ID="btnInsert" runat="server" Text="INSERT_RECORD" CssClass="button" OnClick="btnInsert_Click" />
                            </div>

                        </div>
                        <div class="forbox">
                            <asp:DropDownList ID="ddlGroupofExam" runat="server" CssClass="dap_drop_box" OnSelectedIndexChanged="ddlGroupofExam_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="1">--Select--</asp:ListItem>
                                <asp:ListItem Value="135">(0-10th)StateBoard</asp:ListItem>
                                <asp:ListItem Value="136">(0-12th)CBSE</asp:ListItem>
                                <asp:ListItem Value="137">(0-12th)ICSE</asp:ListItem>
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
                                <asp:ListItem Value="455">PreFoundation (GK JEE and NEET)</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <asp:DropDownList ID="ddlTypeofExam" runat="server" CssClass="dap_drop_box" OnSelectedIndexChanged="ddlTypeofExam_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <br />
                            <asp:DropDownList ID="ddlState" runat="server" CssClass="dap_drop_box" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <br />
                            <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="dap_drop_box">
                            </asp:DropDownList>
                            <br />
                            <asp:TextBox ID="txtBoard" runat="server" CssClass="dap_text_box"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="txtUniversity" runat="server" CssClass="dap_text_box"></asp:TextBox>
                            <br />
                            <asp:DropDownList ID="ddlMedium" runat="server" CssClass="dap_drop_box">
                                <asp:ListItem Value="1">--Select--</asp:ListItem>
                                <asp:ListItem Value="2">English</asp:ListItem>
                                <asp:ListItem Value="3">Semi-English</asp:ListItem>
                                <asp:ListItem Value="4">Marathi</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="dap_drop_box">
                            </asp:DropDownList>
                            <br />
                            <asp:DropDownList ID="ddlSubject" runat="server" CssClass="dap_drop_box">
                            </asp:DropDownList>
                            <br />
                            <asp:DropDownList ID="ddlPublication" runat="server" CssClass="dap_drop_box">
                            </asp:DropDownList>
                            <br />
                            <asp:DropDownList ID="ddlChapter" runat="server" CssClass="dap_drop_box">
                            </asp:DropDownList>
                            <br />
                            <asp:TextBox ID="txtChapterName" runat="server" CssClass="dap_text_box"></asp:TextBox><br />
                            <asp:DropDownList ID="ddlTopic" runat="server" CssClass="dap_drop_box">
                            </asp:DropDownList>
                            <br />
                            <asp:TextBox ID="txtTopicName" runat="server" CssClass="dap_text_box"></asp:TextBox>
                            <div style="padding-top: 18px;">
                                <asp:Button ID="btnClear" runat="server" Text="CLEAR_FIELDS" CssClass="button" OnClick="btnClear_Click" />&nbsp;&nbsp;
                                <asp:Button ID="btnBack" runat="server" Text="BACK" CssClass="button" PostBackUrl="~/CreateTest/createtest.aspx" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div>
                <div style="width: 100%; height: auto;">
                    <asp:HiddenField ID="hiddenSnoId" runat="server" />
                    <asp:GridView ID="gvInsertChapters" runat="server" AutoGenerateColumns="false" CssClass="gridview" AllowPaging="true" OnRowCommand="gvInsertChapters_RowCommand" OnPageIndexChanging="gvInsertChapters_PageIndexChanging" PageSize="10">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="SnoId" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="GROUPOFEXAM_ID" DataField="GroupofExamId" Visible="false">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="GROUPOFEXAM_NAME" DataField="GroupofExamName" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="TYPEOFEXAM_ID" DataField="TypeofExamId" Visible="false">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="TYPEOFEXAM_NAME" DataField="TypeofExamName" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="STATE_ID" DataField="StateID" Visible="false">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="STATE_NAME" DataField="StateName" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="DISTRICT_ID" DataField="DistrictID" Visible="false">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="DISTRICT_NAME" DataField="DistrictName" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="BOARD_ID" DataField="BoardID" Visible="false">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="BOARD_NAME" DataField="BoardName" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="UNIVERSITY_ID" DataField="UniversityID" Visible="false">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="UNIVERSITY_NAME" DataField="UniversityName" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="MEDIUM" DataField="Medium" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="CLASS_ID" DataField="ClassID" Visible="false">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="CLASS_NAME" DataField="ClassName" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="SUBJECT_ID" DataField="SubjectID" Visible="false">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="SUBJECT_NAME" DataField="SubjectName" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="PUBLICATION_ID" DataField="PublicationID" Visible="false">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="PUBLICATION_NAME" DataField="PublicationName" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="CHAPTER_ID" DataField="ChapterID" Visible="false">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="CHAPTER_NAME" DataField="ChapterName" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="TOPIC_ID" DataField="TopicID" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="TOPIC_NAME" DataField="TopicName" Visible="true">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="MODIFY">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgModify" CommandArgument='<%#Bind("SnoId") %>' runat="server"
                                        ImageUrl="../resources/images/ico_yes1.gif" CommandName="MODIFY"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DELETE">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" CommandArgument='<%#Bind("SnoId") %>' runat="server" OnClientClick="if(!confirm(' Are you sure you want delete All Question related to this Test Name ?')) return false;"
                                        ImageUrl="../resources/images/close.gif" CommandName="DELETE"></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnInsert" />
            <asp:AsyncPostBackTrigger ControlID="btnClear" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
