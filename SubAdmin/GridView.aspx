<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout/AdminMaster.master"
    CodeFile="GridView.aspx.cs" Inherits="SubAdmin_GridView" Title="eZeeTest:Add Question to Test Method 2" %>

<asp:Content ID="content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script src="../resources/JScript/jquery-1.11.1.js" type="text/javascript"></script>

    <script src="../resources/JScript/jquery-ui.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function check(checkbox) {
            var cbl = document.getElementById('<%=ddlChapter.ClientID %>').getElementsByTagName("input");
            for (i = 0; i < cbl.length; i++) {
                cbl[i].checked = checkbox.checked;
            }
        }
        
    </script>

    <script type="text/javascript" language="javascript">

        $(document).ready(function() {

            $("[id*=chkAll]").click(function() {

                if ($("[id*=chkAll]").is(":checked")) {

                    $('input:checkbox[name$=chk1]').each(function() {
                        $(this).attr('checked', 'checked');

                    });
                }
                else {
                    $('input:checkbox[name$=chk1]').each(function() {

                        $(this).removeAttr('checked');
                    });

                }
            });


            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (prm != null) {
                prm.add_endRequest(function(sender, e) {
                    if (sender._postBackSettings.panelsToUpdate != null) {
                        $("[id*=chkAll]").click(function() {

                            if ($("[id*=chkAll]").is(":checked")) {

                                $('input:checkbox[name$=chk1]').each(function() {
                                    $(this).attr('checked', 'checked');

                                });
                            }
                            else {
                                $('input:checkbox[name$=chk1]').each(function() {

                                    $(this).removeAttr('checked');
                                });

                            }
                        });

                    }
                });
            };


        });
    
    
    </script>

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
        element.onmousedown = function() { return false; } // For Mozilla Browser
             
    </script>

    <style type="text/css">
        .gridview
        {
            background-color: #f2f9f8;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
            font-family: Arial;
        }
        .gridview td
        {
            padding: 2px;
            border: solid 1px #c1c1c1;
            color: black;
            font-size: 10px;
        }
        .gridview td:hover
        {
            padding: 2px;
            border: solid 1px #c1c1c1;
            font-size: 10px;
            background: #dddddd;
        }
        .gridview th
        {
            padding: 4px 2px;
            color: #fff;
            background: #164854;
            border-left: solid 1px #525252;
            font-size: 12px;
        }
        .gridview .gridview_alter
        {
            background: #E7E7E7;
        }
        .gridview .gridview_pager
        {
            background: #424242;
        }
        .gridview .gridview_pager table
        {
            margin: 5px 0;
        }
        .gridview .gridview_pager td
        {
            border-width: 0;
            padding: 0 6px;
            border-left: solid 1px #666;
            font-weight: bold;
            color: #fff;
            line-height: 12px;
        }
        .gridview .gridview_pager a
        {
            color: #666;
            text-decoration: none;
        }
        .gridview .gridview_pager a:hover
        {
            color: #000;
            text-decoration: none;
        }
    </style>
    <div style="width: 100%;" align="center">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkbtnBackToPanel" runat="server" Visible="false" Text="<<< Back To Panel"
                            Font-Bold="true" ForeColor="HighlightText" PostBackUrl="~/CreateTest/createtest.aspx"></asp:LinkButton>
                        <table cellpadding="0" cellspacing="0" width="65%" class="tables" border="1">
                            <tr>
                                <td>
                                    <center>
                                        <table style="width: 55%" class="tables" width="160">
                                            <tr>
                                                <td colspan="3" style="text-align: center">
                                                    <h3 style="color: Green; font-size: x-large;">
                                                        Add Question for Exam&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </h3>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                    <br />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbltext" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Test Name" Width="120px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddltextName" runat="server" CssClass="ddlcsswidth " AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddltextName_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddltextName"
                                                        Enabled="True" ErrorMessage="Please select Test Name." Font-Size="Small" InitialValue="--Select--"
                                                        SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Subject" Width="100px"></asp:Label>
                                                    <span class="warning1" style="color: Red;">*</span>&nbsp;
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="cmbSelectsubject" runat="server" CssClass="ddlcsswidth " AutoPostBack="true"
                                                        OnSelectedIndexChanged="cmbSelectsubject_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <br />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbSelectsubject"
                                                        Enabled="True" ErrorMessage="You have not selected Subject" Font-Size="Small"
                                                        InitialValue="--Select--" SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblchapter" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Chapter" Width="100px" ></asp:Label>
                                                    <span class="warning1" style="color: Red;">*</span>&nbsp;
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTopik" runat="server" CssClass="ddlcsswidth " AutoPostBack="True"
                                                          OnSelectedIndexChanged="ddlTopik_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <br />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTopik"
                                                        ErrorMessage="You have not selected Chapter" Font-Size="Small" InitialValue="--Select--"
                                                        SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblMedium" runat="server" Font-Bold="false" Font-Names="arial" Font-Size="11pt"
                                                        Text="Select Medium" Width="170px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="ddlcsswidth ">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1">English</asp:ListItem>
                                                        <asp:ListItem Value="2">Semi-English</asp:ListItem>
                                                        <asp:ListItem Value="3">Marathi</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    <asp:Label ID="lblpublication" runat="server" Font-Bold="false" Font-Names="arial" Font-Size="11pt"
                                                        Text="Select Publication" Width="170px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlpublication" runat="server" CssClass="ddlcsswidth ">

                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbltopic" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Topic" Width="150px"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <div class="container">
                                                        <asp:CheckBox ID="ChkSelectALL" runat="server" Text="Select ALL Toipc" OnClick="check(this)"
                                                            Visible="False" />
                                                        <asp:CheckBoxList ID="ddlChapter" runat="server" RepeatColumns="1" BorderWidth="0px"
                                                            Datafield="description" DataValueField="value">
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Level of Question " Width="160px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rdoLevelList1" runat="server" Font-Names="Arial" Font-Size="Small"
                                                        AutoPostBack="true" RepeatDirection="Horizontal" ToolTip="Click to select level">
                                                        <asp:ListItem Value="1">Level1</asp:ListItem>
                                                        <asp:ListItem Value="2">Level2</asp:ListItem>
                                                        <asp:ListItem Value="3">Level3</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td colspan="2">
                                                    &nbsp;<asp:Button ID="btnStart" runat="server" CssClass="btn" Text="Find Question"
                                                        ToolTip="Click here to start the test" ValidationGroup="other" OnClick="btnStart_Click" />
                                                    &nbsp;
                                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn" PostBackUrl="~/Admin/Home.aspx"
                                                        Text="Cancel" ToolTip="Click here to Cancel" CausesValidation="false" ValidationGroup="other" />
                                                    &nbsp;&nbsp;<asp:LinkButton ID="btnarchive" runat="server" Visible="false" Text="Get BackUp Selected Test."
                                                        ToolTip="Click Here to Trasfer Archive." Font-Size="Small" />
                                                    &nbsp;
                                                    <asp:Button ID="btnNoReapetQues" runat="server" Text="No Repeat Ques" CssClass="btn"
                                                        ValidationGroup="other" CausesValidation="false" PostBackUrl="~/SubAdmin/NoRepeatQues.aspx"
                                                        OnClick="btnNoReapetQues_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Panel ID="pnl1" runat="server">
                                                        <asp:Label ID="lblTotalQNo" runat="server" CssClass="error"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="lblAvailable" runat="server" CssClass="error"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="lblRemaininhg" runat="server" CssClass="error"></asp:Label>
                                                        <br />
                                                    </asp:Panel>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnStart" />
                        <asp:PostBackTrigger ControlID="btnNoReapetQues" />
                        
                    </Triggers>
                </asp:UpdatePanel>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:UpdatePanel ID="updatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" Visible="false" Text="<<< Back To Panel"
                            Font-Bold="true" ForeColor="HighlightText" PostBackUrl="~/CreateTest/createtest.aspx"></asp:LinkButton>
                        <div style="width: 90%; font-family: Times New Roman">
                            <table width="90%">
                                <tr>
                                    <td style="text-align: left; height: 29px; width: 25%">
                                        <asp:Label ID="lblt1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#009933"
                                            Text="lblt1 " Visible="false"></asp:Label>
                                    </td>
                                    <td style="text-align: left; height: 29px; width: 25%">
                                        <asp:Label ID="lblt2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#009933"
                                            Text="lblt2 " Visible="false"></asp:Label>
                                    </td>
                                    <td style="text-align: left; height: 29px; width: 25%">
                                        <asp:Label ID="lblt3" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#009933"
                                            Text="lblt3 " Visible="false"></asp:Label>
                                    </td>
                                    <td style="text-align: left; height: 29px; width: 25%">
                                        <asp:Label ID="lblcount" runat="server" Font-Size="Medium" Text="count" ForeColor="#009933"
                                            Visible="false" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <asp:Label ID="lblNoReQues" runat="server" Text="Label" ForeColor="Red" Font-Bold="true"
                                        Font-Size="Medium"></asp:Label>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="gvBindQuestions" AutoGenerateColumns="false" DataKeyNames="SNO"
                                            EmptyDataText="No Question found for this combination" Width="90%" runat="server"
                                            OnRowDataBound="gvBindQuestions_RowDataBound" CssClass="gridview">
                                            <Columns>
                                                <asp:BoundField HeaderText="Master ID" DataField="NewQID" Visible="true">
                                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="SNO" DataField="SNO" Visible="true">
                                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Question">
                                                    <ItemStyle Width="40%" />
                                                    <ItemTemplate>
                                                        <%--Text='<%#Eval("Question") %>'--%>
                                                        <asp:Label ID="lblTextQuestion" runat="server" Text='<%# Eval("Question") %>'></asp:Label>
                                                        <asp:Image ID="imgQuestion" runat="server" ImageUrl='<%# Eval("Question") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Type of Question" DataField="TypeofQues">
                                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Choose Question">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkAll" runat="server" Text="Select All" />
                                                        <%--OnCheckedChanged="chkAll_CheckedChanged"--%>
                                                    </HeaderTemplate>
                                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <center>
                                                            <asp:CheckBox ID="chk1" runat="server" ToolTip="Select Question to Add in Exam" /></center>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:Repeater ID="rptPageNumber" runat="server">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnPagenumber" Font-Size="Small" runat="server" Text='<%# Eval("Text") %>'
                                                    CommandArgument='<%#Eval("Value") %>' Enabled='<%#Eval("Enabled") %>' OnClick="PageChange_OnClick"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%">
                                        <asp:Button ID="btnBack1" runat="server" CssClass="btn" Text="Back" OnClick="btnBack1_Click" />
                                    </td>
                                    <td width="25%">
                                        <asp:Button ID="btnPrint" runat="server" Height="31px" Text="Print Question" Width="89px"
                                            OnClick="btnPrint_Click" />
                                        <asp:Button ID="btnInsturc" runat="server" Height="31px" Text="Print Instruction"
                                            Width="94px" OnClick="btnInsturc_Click" />
                                    </td>
                                    <td width="25%">
                                    </td>
                                    <td align="center" width="25%">
                                        <asp:Button ID="btnAddQuestion" Text="Add Question" CssClass="btn" runat="server"
                                            OnClick="btnAddQuestion_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnBack1" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:View>
        </asp:MultiView></div>
</asp:Content>
