<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AccessToSql.aspx.cs" Inherits="Admin_AccessToSql" Title="eZeeTest:Upload AccessDB File" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../resources/stylesheet/jquery-ui.theme.css" type="text/css" rel="Stylesheet" />
    <style type="text/css">
        #popupdiv
        {
            border: 1px solid black;
            border-radius: 5px;
            background-color: #FFFFBC;
            width: 550px;
            height: 400px;
            font-size: small;
        }
    </style>

    <script src="../resources/JScript/jquery-1.11.1.js" type="text/javascript"></script>

    <script src="../resources/JScript/jquery-ui.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            //Generate dialog on panel
            $(function() {
                $("#<%=popUpPanelChapterName.ClientID%>").dialog({
                    resizable: false,
                    modal: true,
                    autoOpen: false,

                    open: function(type, data) {
                        $(this).parent().appendTo("form");
                        $(this).parent().children().children('.ui-dialog-titlebar-close').hide();
                    }

                });


            });
            //Open the Dialog
            $("#<%=btnUpdateChapter1.ClientID%>").click(function() {
                $("#<%=popUpPanelChapterName.ClientID%>").dialog('open');
                return false;
            });

            //display date in textbox
            $("#<%=txtDOUpload1.ClientID%>").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'yy-mm-dd'
            });

            //Below code to reset Fields

            $("#<%=btnCancel1.ClientID%>").click(function() {
                $("#<%=txtChapterName.ClientID%>").val('');
                $("#<%=ddlTypeofExam1.ClientID%>").val(1);
                $("#<%=ddlTypeofQues1.ClientID%>").val(1);
                $("#<%=ddlClassId1.ClientID%>").val(1);
                $("#<%=ddlSubjectId1.ClientID%>").val(1);
                $("#<%=ddlMediumId1.ClientID%>").val(0);
                $("#<%=ddlTypeofDB1.ClientID%>").val(0);
                $("#<%=txtDOUpload1.ClientID%>").val('');

                $("#<%=ddlChapterId1.ClientID%>").val(1);
                $("#<%=ddlTopicId1.ClientID%>").val(1);

                return false;

            });

            //close the dialog
            $("#<%=btnClose.ClientID%>").click(function() {
                $("#<%=popUpPanelChapterName.ClientID%>").dialog('close');
                return false;
            });



        });


    </script>

    <div style="width: 100%;" align="center">
        <table cellpadding="0" cellspacing="0" width="70%" border="1">
            <tr>
                <td align="center">
                    <div style="width: 85%">
                        <table cellpadding="0" cellspacing="0" border="0" width="85%" class="tables">
                            <caption>
                                <br />
                                <tr>
                                    <td>
                                        <center>
                                            <h4 style="color: Green; text-align: center; font-size: x-large; font-family: Times New Roman;">
                                                Upload EzeeQuestion Database File</h4>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <center>
                                            <table cellspacing="7px" class="tables" style="width: 90%">
                                                <tr>
                                                    <td colspan="3" style="text-align: left">
                                                        <h3>
                                                            <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span></h3>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2" style="text-align: left">
                                                        <asp:Label ID="lblError" runat="server" CssClass="error" Font-Bold="False" Font-Size="Large"
                                                            ForeColor="#FF3300" Text="Label" Visible="False"></asp:Label>
                                                    </td>
                                                    <td align="right" style="text-align: left">
                                                        <asp:Label ID="lblcount" runat="server" Font-Size="Medium" ForeColor="#0066FF" Text="Count"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lblInserted" runat="server" Font-Size="Medium" ForeColor="Green" Text="Added"
                                                            Visible="False"></asp:Label>
                                                        &nbsp; &nbsp;
                                                        <asp:Label ID="lblUpdated" runat="server" Font-Size="Medium" ForeColor="Green" Text="Updated"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: Left;">
                                                        <asp:Label ID="lblQuesError" runat="server" Font-Size="Medium" ForeColor="red" Text="QuesError"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="lblErrorQuesID" runat="server" Text="" Font-Bold="true" ForeColor="DarkMagenta"
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTypeofMaterial" runat="server" Font-Size="Medium" Text="Select Type of Material"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                            <ContentTemplate>
                                                                <asp:RadioButtonList ID="rdoTypeofMaterial" runat="server" AutoPostBack="True" CssClass="radio"
                                                                    Font-Size="Medium" OnSelectedIndexChanged="rdoTypeofMaterial_SelectedIndexChanged"
                                                                    RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="0">Class</asp:ListItem>
                                                                    <asp:ListItem Value="1">Competitive Exam</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="rdoTypeofMaterial"
                                                                    ErrorMessage="*" Font-Size="Small" SetFocusOnError="True" ValidationGroup="other"
                                                                    Width="5px"></asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <%--New Row Added--%>
                                                <tr>
                                                    <td style="height: 30px">
                                                        <asp:Label ID="Label4" runat="server" Font-Size="Medium" Text="Select Type of Exam"></asp:Label>
                                                        <span class="warning1" style="color: Red">*</span>
                                                    </td>
                                                    <td colspan="2" style="height: 30px">
                                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlGroupofExam" runat="server" AutoPostBack="True" CssClass="ddlcsswidth"
                                                                    OnSelectedIndexChanged="ddlGroupofExam_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlGroupofExam"
                                                                    Enabled="False" ErrorMessage="*" Font-Size="Small" InitialValue="1" SetFocusOnError="True"
                                                                    ValidationGroup="other"></asp:RequiredFieldValidator>
                                                                <br />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <%--New Row Added--%>
                                                <tr>
                                                    <td style="height: 30px">
                                                        <asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Select ExamName"></asp:Label>
                                                    </td>
                                                    <td colspan="2" style="height: 30px">
                                                        <asp:UpdatePanel ID="panel4" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlTypeofExam" runat="server" AutoPostBack="True" CssClass="ddlcsswidth"
                                                                    OnSelectedIndexChanged="ddlTypeofExam_SelectedIndexChanged">
                                                                    <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlTypeofExam"
                                                                    Enabled="False" ErrorMessage="*" Font-Size="Small" InitialValue="1" SetFocusOnError="True"
                                                                    ValidationGroup="other"></asp:RequiredFieldValidator>
                                                                <br />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server" Font-Size="Medium" Text="Select Class Name"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlAddClass" runat="server" AutoPostBack="True" CssClass="ddlcsswidth "
                                                                    OnSelectedIndexChanged="ddlAddClass_SelectedIndexChanged">
                                                                    <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlAddClass"
                                                                    Enabled="False" ErrorMessage="*" Font-Size="Small" InitialValue="1" SetFocusOnError="True"
                                                                    ValidationGroup="other"></asp:RequiredFieldValidator>
                                                                <br />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" Font-Size="Medium" Text="Select Medium  Name"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:UpdatePanel ID="panel1" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlMedium" runat="server" CssClass="ddlcsswidth ">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">English</asp:ListItem>
                                                                    <asp:ListItem Value="2">Semi-English</asp:ListItem>
                                                                    <asp:ListItem Value="3">Marathi</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlMedium"
                                                                    ErrorMessage="*" Font-Size="Small" InitialValue="0" SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                                <br />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label7" runat="server" Font-Size="Medium" Text="Select Subject"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="cmbSelectsubject" runat="server" AutoPostBack="True" CssClass="ddlcsswidth "
                                                                    OnSelectedIndexChanged="cmbSelectsubject_SelectedIndexChanged">
                                                                    <asp:ListItem Value="1">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbSelectsubject"
                                                                    ErrorMessage="*" Font-Size="Small" InitialValue="1" SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                                <br />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label8" runat="server" Font-Size="Medium" Text="Select Chapter"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlChapter" runat="server" AutoPostBack="True" CssClass="ddlcsswidth ">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlChapter"
                                                                    ErrorMessage="*" Font-Size="Small" InitialValue="1" SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                                <br />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label9" runat="server" Font-Size="Medium" Text="Select Sub Topic"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlTopic" runat="server" CssClass="ddlcsswidth ">
                                                                </asp:DropDownList>
                                                                <br />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Select Excel File"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUpload1"
                                                            ErrorMessage="*" Font-Size="Small" SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server" Font-Size="Medium" Text="Enter Mobile No."></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtMobileNo1" runat="server" MaxLength="10" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobileNo1"
                                                            ErrorMessage="*" Font-Size="Small" SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPublication" runat="server" Font-Size="Medium" Text="Select Publication"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlpublication" runat="server" CssClass="ddlcsswidth ">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlpublication"
                                                            ErrorMessage="*" Font-Size="Small" SetFocusOnError="True" ValidationGroup="other"
                                                            InitialValue="1"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3" style="text-align: center">
                                                        <%-- OnClientClick="if(!confirm('Please Make sure to attach correct File and Select correct options !!')) return false;"--%>
                                                        <asp:Button ID="btnSubmitQues" runat="server" CssClass="btn" OnClick="btnSubmitQues_Click"
                                                            Text="Submit" ValidationGroup="other" />
                                                        &nbsp;<asp:Button ID="btnBackQues" runat="server" CssClass="btn" OnClick="btnBackQues_Click"
                                                            Text="Back" />&nbsp;
                                                        <asp:Button ID="btnUpdateChapter1" runat="server" CssClass="btn" Text="UpdateChapter" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                                    </td>
                                </tr>
                            </caption>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <asp:Panel ID="popUpPanelChapterName" runat="server" Width="550px" Style="display: none;">
            <div style="width: 100%;" id="popupdiv">
                <table width="100%">
                    <tr>
                        <td>
                            <center>
                                <b><u>Update UserChapterName</u></b></center>
                        </td>
                    </tr>
                </table>
                <span style="color: Red;">All Fields are Mandatory</span>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td>
                            <b>
                                <asp:Label ID="lblChapterName" runat="server" Text="ChapterName"></asp:Label></b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtChapterName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:Label ID="lblTypeofExam1" runat="server" Text="TypeofExam"></asp:Label></b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTypeofExam1" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:Label ID="lblTypeofQues1" runat="server" Text="TypeofQuestion"></asp:Label></b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTypeofQues1" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:Label ID="lblClassId1" runat="server" Text="ClassName"></asp:Label></b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlClassId1" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:Label ID="lblSubjectId1" runat="server" Text="Subject"></asp:Label></b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubjectId1" Width="165px" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:Label ID="lblChapterId1" runat="server" Text="ChapterId"></asp:Label></b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlChapterId1" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:Label ID="lblTopicId1" runat="server" Text="TopicId"></asp:Label></b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTopicId1" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:Label ID="lblMediumId1" runat="server" Text="Medium"></asp:Label></b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMediumId1" runat="server">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">English</asp:ListItem>
                                <asp:ListItem Value="2">Semi-English</asp:ListItem>
                                <asp:ListItem Value="3">Marathi</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:Label ID="lblTypeofDB1" runat="server" Text="TypeofDB"></asp:Label></b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTypeofDB1" runat="server">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">Access</asp:ListItem>
                                <asp:ListItem Value="2">Excel</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:Label ID="lblDOUpload1" runat="server" Text="DateOfUpload" Visible="false"></asp:Label></b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDOUpload1" runat="server" Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:Label ID="lblTypeofMaterial1" runat="server" Text="TypeofMaterial"></asp:Label></b>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rdblistTypeofMaterial" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="0">Class</asp:ListItem>
                                <asp:ListItem Value="1">Competitive Exam</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <%-- <tr>
                    <td>
                        <b>
                            <asp:Label ID="lblUploadedFileName1" runat="server" Text="UploadedFileName"></asp:Label></b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUploadedFileName1" runat="server"></asp:TextBox>
                    </td>
                </tr>--%>
                </table>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnUpdateChapter" runat="server" Text="Update" CssClass="btn" OnClick="btnUpdateChapter_Click" />
                            </td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <td>
                                <asp:Button ID="btnCancel1" runat="server" CssClass="btn" Text="Reset" />
                            </td>
                            <td>
                                <asp:Button ID="btnClose" runat="server" CssClass="btn" Text="Close" />
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
