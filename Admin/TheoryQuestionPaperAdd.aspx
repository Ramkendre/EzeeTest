<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="TheoryQuestionPaperAdd.aspx.cs" Inherits="Admin_TheoryQuestionPaperAdd"
    Title="Set Theory Question Paper" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../resources/stylesheet/css11.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #loginform
        {
            min-width: 200px;
            height: 110px;
            background-color: #ffffff;
            border: 1px solid;
            border-color: #555555;
            padding: 16px 16px;
            border-radius: 4px;
            -webkit-box-shadow: 0px 1px 6px rgba(75, 31, 57, 0.8);
            -moz-box-shadow: 0px 1px 6px rgba(75, 31, 57, 0.8);
            box-shadow: 0px 1px 6px rgba(223, 88, 13, 0.8);
        }

        .txt
        {
            color: #505050;
        }

        .redstar
        {
            color: #FF0000;
        }

        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }

        .modalPopup
        {
            background-color: #FFFFFF;
            width: 400px;
            border: 3px solid #0DA9D0;
            border-radius: 12px;
            padding: 0;
            height: 200px;
        }

            .modalPopup .header
            {
                background-color: #2FBDF1;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
                border-top-left-radius: 6px;
                border-top-right-radius: 6px;
            }

            .modalPopup .body
            {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .footer
            {
                padding: 6px;
            }

            .modalPopup .yes, .modalPopup .no
            {
                height: 23px;
                color: White;
                line-height: 23px;
                text-align: center;
                font-weight: bold;
                cursor: pointer;
                border-radius: 4px;
            }

            .modalPopup .yes
            {
                background-color: #2FBDF1;
                border: 1px solid #0DA9D0;
            }

            .modalPopup .no
            {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }
    </style>

    <%--************************************* For instruction  **************************************--%>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div style="width: 100%;" align="center">
                        <table cellpadding="0" cellspacing="0" border="1" class="tables" width="85%">
                            <tr>
                                <td>
                                    <center>
                                        <table style="width: 75%" class="tables">
                                            <tr>
                                                <td colspan="3" style="text-align: center">
                                                    <h3 style="color: Green; font-size: x-large;">Create Theory Question Paper</h3>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                    <br />
                                                    <asp:Label ID="lblerror" runat="server" Font-Size="Small" ForeColor="Red" Text="Label"
                                                        Visible="False"></asp:Label>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblQueslanguage" runat="server" Font-Bold="False" Font-Names="Arial"
                                                        Font-Size="11pt" Text="Select Language of Paper" Width="170px"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:RadioButtonList ID="rdoQueslanguage" runat="server" AutoPostBack="True" CssClass="radio"
                                                        Font-Size="Medium" RepeatDirection="Horizontal" Width="203px" OnSelectedIndexChanged="rdoQueslanguage_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">English</asp:ListItem>
                                                        <asp:ListItem Value="1">Marathi</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblTest" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Test Name" Width="170px"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:DropDownList ID="ddltestName" runat="server" CssClass="ddlcsswidth " AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddltestName_SelectedIndexChanged1">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddltestName"
                                                        Enabled="True" ErrorMessage="Please select Test Name." Font-Size="Small" InitialValue="--Select--"
                                                        SetFocusOnError="True" ValidationGroup="other,instruc"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Main Question Number" Width="170px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblInitialQues" runat="server" Text="" Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlQNOE" runat="server">
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                        <asp:ListItem>6</asp:ListItem>
                                                        <asp:ListItem>7</asp:ListItem>
                                                        <asp:ListItem>8</asp:ListItem>
                                                        <asp:ListItem>9</asp:ListItem>
                                                        <asp:ListItem>10</asp:ListItem>
                                                        <asp:ListItem>11</asp:ListItem>
                                                        <asp:ListItem>12</asp:ListItem>
                                                        <asp:ListItem>13</asp:ListItem>
                                                        <asp:ListItem>14</asp:ListItem>
                                                        <asp:ListItem>15</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlQNOM" Visible="false" runat="server">
                                                        <asp:ListItem>१</asp:ListItem>
                                                        <asp:ListItem>२</asp:ListItem>
                                                        <asp:ListItem>३</asp:ListItem>
                                                        <asp:ListItem>४</asp:ListItem>
                                                        <asp:ListItem>५</asp:ListItem>
                                                        <asp:ListItem>६</asp:ListItem>
                                                        <asp:ListItem>७</asp:ListItem>
                                                        <asp:ListItem>८</asp:ListItem>
                                                        <asp:ListItem>९</asp:ListItem>
                                                        <asp:ListItem>१०</asp:ListItem>
                                                        <asp:ListItem>११</asp:ListItem>
                                                        <asp:ListItem>१२</asp:ListItem>
                                                        <asp:ListItem>१३</asp:ListItem>
                                                        <asp:ListItem>१४</asp:ListItem>
                                                        <asp:ListItem>१५</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="txtQNOHeading" runat="server" Visible="false" MaxLength="7"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtQNOHeading"
                                                        Enabled="True" ErrorMessage="Please Enter Question Number" Font-Size="Small"
                                                        SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblIsSubQues" runat="server" Text="Is It SubQuestion" Font-Names="Arial" Font-Size="11pt"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:RadioButtonList ID="rdolstIsSubQues" runat="server" OnSelectedIndexChanged="rdolstIsSubQues_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="0">Yes</asp:ListItem>
                                                        <asp:ListItem Value="1">No</asp:ListItem>
                                                    </asp:RadioButtonList>

                                                    <asp:DropDownList ID="ddlIsSubQuesE" Visible="false" runat="server">
                                                        <asp:ListItem>A</asp:ListItem>
                                                        <asp:ListItem>B</asp:ListItem>
                                                        <asp:ListItem>C</asp:ListItem>
                                                        <asp:ListItem>D</asp:ListItem>
                                                        <asp:ListItem>E</asp:ListItem>
                                                        <asp:ListItem>F</asp:ListItem>
                                                        <asp:ListItem>G</asp:ListItem>
                                                        <asp:ListItem>H</asp:ListItem>
                                                        <asp:ListItem>I</asp:ListItem>
                                                        <asp:ListItem>J</asp:ListItem>
                                                        <asp:ListItem>K</asp:ListItem>
                                                        <asp:ListItem>L</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlIsSubQuesM" Visible="false" runat="server">
                                                        <asp:ListItem>अ</asp:ListItem>
                                                        <asp:ListItem>आ</asp:ListItem>
                                                        <asp:ListItem>इ</asp:ListItem>
                                                        <asp:ListItem>ई</asp:ListItem>
                                                        <asp:ListItem>उ</asp:ListItem>
                                                        <asp:ListItem>ऊ</asp:ListItem>
                                                        <asp:ListItem>क</asp:ListItem>
                                                        <asp:ListItem>ख</asp:ListItem>
                                                        <asp:ListItem>ग</asp:ListItem>
                                                        <asp:ListItem>घ</asp:ListItem>
                                                        <asp:ListItem>च</asp:ListItem>
                                                        <asp:ListItem>छ</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td></td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Ques Heading" Width="170px"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMainHead" runat="server" CssClass="ddlcsswidth" Visible="true" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlMainHead_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    &nbsp;
                                                    <asp:TextBox ID="txtMainHead" runat="server"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="No of Question" Width="170px"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:TextBox ID="txtNoOfQues" runat="server" MaxLength="2" onkeypress="return numbersonly(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNoOfQues"
                                                        Enabled="True" ErrorMessage="Please Enter Number of Ques." Font-Size="Small"
                                                        SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Total marks for Question" Width="170px"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:TextBox ID="txtMarkforAllQues" runat="server" MaxLength="2" onkeypress="return numbersonly(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMarkforAllQues"
                                                        Enabled="True" ErrorMessage="Please Enter Marks for Question" Font-Size="Small"
                                                        SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select OR Question" Width="170px"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:CheckBox ID="chkOR" Text="OR" runat="server" />
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Subject" Width="170px"></asp:Label>
                                                    <span class="warning1" style="color: Red;">*</span>&nbsp;
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:DropDownList ID="cmbSelectsubject" runat="server" CssClass="ddlcsswidth " AutoPostBack="true"
                                                        OnSelectedIndexChanged="cmbSelectsubject_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <br />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cmbSelectsubject"
                                                        Enabled="True" ErrorMessage="You have not selected Subject" Font-Size="Small"
                                                        InitialValue="--Select--" SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Chapter" Width="150px"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td></td>
                                                <td>
                                                    <div class="container">
                                                        <asp:CheckBox ID="ChkSelectALL" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSelectALL_CheckedChanged"
                                                            Text="Select ALL Chapter" Visible="False" />
                                                        <asp:CheckBoxList ID="ddlChapter" runat="server" RepeatColumns="1" BorderWidth="0px"
                                                            Datafield="description" DataValueField="value">
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Level of Question " Width="170px"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:RadioButtonList ID="rdoLevelList1" runat="server" Font-Names="Arial" Font-Size="Small"
                                                        AutoPostBack="true" RepeatDirection="Horizontal" ToolTip="Click to select level"
                                                        OnSelectedIndexChanged="rdoLevelList1_SelectedIndexChanged">
                                                        <asp:ListItem Value="1">Level1</asp:ListItem>
                                                        <asp:ListItem Value="2">Level2</asp:ListItem>
                                                        <asp:ListItem Value="3">Level3</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                </td>
                                                <td colspan="2">&nbsp;<asp:Button ID="btnStart" runat="server" CssClass="btn" OnClick="btnStart_Click1"
                                                    Text="Find Question" ToolTip="Click here to start the test" ValidationGroup="other" />
                                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn" Text="Update" ToolTip="Click here to Update Changes"
                                                        ValidationGroup="other" Visible="False" OnClick="btnUpdate_Click" />
                                                    &nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="btn" OnClick="btnCancel_Click"
                                                        Text="cancel" ToolTip="Click here to Cancel Changes" />
                                                    &nbsp;
                                                    <asp:LinkButton ID="btnarchive" runat="server" Font-Size="Small" Text="Get BackUp Selected Test."
                                                        ToolTip="Click Here to Trasfer Archive." Visible="false" />
                                                    <asp:Button ID="btnPrint" runat="server" Height="31px" OnClick="btnPrint_Click" Text="Print Question"
                                                        Visible="False" Width="89px" />
                                                    &nbsp;
                                                    
                                                    <asp:Button ID="hplInstruction" runat="server" Text="Add Instructions"
                                                        ValidationGroup="instruc" Enabled="False" Height="31px" />
                                                </td>
                                            </tr>

                                        </table>
                                        <table>
                                            <tr>
                                                <td>&nbsp;
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
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </td>
                            </tr>
                        </table>
                        <br />

                        <%--************************************* For instruction  **************************************--%>

                        <asp:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="hplInstruction"
                            PopupControlID="popUpPanel" CancelControlID="btnclose" BackgroundCssClass="modalBackground"
                            DropShadow="true" runat="server">
                        </asp:ModalPopupExtender>

                        <asp:Panel ID="popUpPanel" runat="server" CssClass="modalPopup" Style="display: none">
                            <div class="header">
                                ADD INSTRUCTIONS FOR EXAM
                            </div>
                            <div class="body">
                                <table>
                                    <tr>
                                        <td>Instruction Language
                                        </td>
                                        <td><b>:</b>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rdoInstruLang" runat="server" Font-Size="Small" AutoPostBack="True"
                                                OnSelectedIndexChanged="rdoInstruLang_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="0">English</asp:ListItem>
                                                <asp:ListItem Value="1">Marathi</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Enter Instruction
                                        </td>
                                        <td><b>:</b></td>
                                        <td>
                                            <asp:TextBox ID="txtInstructionName" runat="server" placeholder=" Enter Instruction" Width="210px" Height="25px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Default Instruction
                                        </td>
                                        <td><b>:</b></td>
                                        <td>
                                            <asp:CheckBox ID="rdodefualt" runat="server" Font-Size="Small" Text="Add Default Instruction" />
                                        </td>
                                    </tr>
                                </table>
                            </div>

                            <div class="footer">
                                <asp:Button ID="btnInstru" runat="server" Text="Submit" CssClass="yes" OnClick="btnInstru_Click"
                                    ValidationGroup="btninstru" />
                                &nbsp;<asp:Button ID="btnclose0" runat="server" CausesValidation="false" Visible="false" OnClick="btnclose0_Click"
                                    Text="Cancel" />
                                &nbsp;<asp:Button ID="btnclose" runat="server" Text="Close" CssClass="no" CausesValidation="false" />
                            </div>
                            <br />
                            <div>
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </div>

                            <asp:Label ID="lblid2" runat="server" Visible="false"></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server" placeholder="Enter Instruction" Width="186px" Visible="False"></asp:TextBox>

                        </asp:Panel>

                        <%--************************************* End Instruction **************************************--%>
                        <br />
                        <%--************************************* grid **************************************--%>
                        <div class="grid" style="width: 85%">
                            <div class="rounded">
                                <div class="mid-outer">
                                    <div class="mid-inner">
                                        <div class="mid">
                                            <div class="pager">
                                                <asp:GridView ID="GridView2" runat="server" CssClass="datatable" OnRowCommand="GridView2_RowCommand"
                                                    CellPadding="5" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                    PageSize="25" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDeleting="GridView2_RowDeleting"
                                                    Visible="false">
                                                    <Columns>
                                                        <asp:BoundField DataField="ID" HeaderText="ID" HtmlEncode="true" ItemStyle-ForeColor="Red"
                                                            ItemStyle-Width="5%">
                                                            <ItemStyle Width="5%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Instruction" HeaderText="Instruction Name" HtmlEncode="true"
                                                            ItemStyle-Width="35%">
                                                            <ItemStyle Width="35%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Testname" HeaderText="Test Name" HtmlEncode="true" ItemStyle-Width="35%">
                                                            <ItemStyle Width="35%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Instrulanguage" HeaderText="Instruction language" HtmlEncode="true"
                                                            ItemStyle-Width="35%">
                                                            <ItemStyle Width="35%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="InstrucIDSet" HeaderText="Instruction ID" HtmlEncode="true"
                                                            ItemStyle-ForeColor="Red" ItemStyle-Width="35%">
                                                            <ItemStyle Width="35%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Default1" HeaderText="Default Instruction" HtmlEncode="true"></asp:BoundField>
                                                        <asp:TemplateField HeaderText="Modify">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("ID")%>' runat="server"
                                                                    ImageUrl="../resources/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("ID")%>' runat="server"
                                                                    OnClientClick="if(!confirm(' Are You Sure Want to Delete ?')) return false;" ImageUrl="../resources/images/close.gif"
                                                                    CommandName="Delete"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Add">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkAddInstruc" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <PagerStyle CssClass="pager-row" />
                                                </asp:GridView>
                                                <asp:GridView ID="gvTheory" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    CellPadding="5" CellSpacing="0" CssClass="datatable" EmptyDataText="Theory Questions List is not available."
                                                    GridLines="None" OnDataBound="gvTheory_DataBound" OnPageIndexChanging="gvTheory_PageIndexChanging"
                                                    OnRowCommand="gvTheory_RowCommand" OnRowDeleting="gvTheory_RowDeleting" PageSize="25">
                                                    <Columns>
                                                        <asp:BoundField DataField="ID" HeaderText="ID">
                                                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="10%" />
                                                            <ItemStyle Font-Bold="False" Font-Size="Medium" HorizontalAlign="Center" Width="10%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TestName" HeaderText="Test Name">
                                                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TestId" HeaderText="Test Id" Visible="False">
                                                            <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MainQuestion" HeaderText="Questions No.">
                                                            <HeaderStyle HorizontalAlign="left" Width="15%" />
                                                            <ItemStyle HorizontalAlign="left" Width="15%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="HeadingText" HeaderText="Heading of Question">
                                                            <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                            <ItemStyle HorizontalAlign="left" Width="30%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NoOfQuestion" HeaderText="No Of Question">
                                                            <HeaderStyle HorizontalAlign="left" Width="20%" />
                                                            <ItemStyle HorizontalAlign="left" Width="20%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MarkAllQuestion" HeaderText="Mark All Question">
                                                            <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                            <ItemStyle HorizontalAlign="left" Width="30%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ORMainQuestion" HeaderText="OR Questions">
                                                            <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                            <ItemStyle HorizontalAlign="left" Width="30%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="QuestionID" HeaderText="Question ID">
                                                            <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                            <ItemStyle HorizontalAlign="left" Width="30%" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Modify">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%#Bind("ID")%>'
                                                                    CommandName="Modify" Enabled="false" ImageUrl="../resources/images/ico_yes1.gif" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%#Bind("ID")%>'
                                                                    CommandName="Delete" Enabled="false" ImageUrl="../resources/images/close.gif" OnClientClick="return confirmationDelete();" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <PagerStyle CssClass="pager-row" />
                                                </asp:GridView>
                                                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="bottom-outer">
                                    <div class="bottom-inner">
                                        <div class="bottom">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnStart" />
                </Triggers>
            </asp:UpdatePanel>
            <%--************************************* End grid **************************************--%>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div style="width: 100%; font-family: Times New Roman;" align="center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table cellpadding="0" cellspacing="0" width="70%" bgcolor="White">
                            <div style="width: 80%">
                                <table style="width: 91%" cellspacing="7px" bgcolor="White">
                                    <tr bgcolor="#FFFFCC">
                                        <td colspan="2" align="left">
                                            <asp:Label ID="lblqn" runat="server" Font-Size="Large" Text="Q.No. :" ForeColor="#00CC00"
                                                Font-Bold="True"></asp:Label><asp:Label ID="lblQNo" runat="server" Font-Size="Large"
                                                    Text="Q" ForeColor="#00CC00" Font-Bold="True"></asp:Label>&#160; &#160;
                                            &#160; &#160; &#160; &#160; &#160; &#160; &#160;
                                            <asp:Label ID="lblQuestion_id" runat="server" Font-Bold="True" Font-Size="Medium"
                                                ForeColor="#009933" Text="Question_id" Visible="False"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblcount" runat="server" Font-Size="Medium" Text="count" ForeColor="#009933"
                                                Font-Bold="True"></asp:Label>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
                                            <asp:Label ID="lblSno" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#009933"
                                                Text="SNO" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px; text-align: left;">
                                            <asp:Label ID="lblQues" runat="server" Text="Question" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                        </td>
                                        <td colspan="3" align="left">
                                            <asp:Label ID="lblQuestion" runat="server" Font-Size="Medium" Text="Question"></asp:Label><asp:Image
                                                ID="imgQues" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px; text-align: left">
                                            <asp:Label ID="QuestionImage" runat="server" Text="QuestionImage" Font-Size="Large"
                                                ForeColor="#CC3300"></asp:Label>
                                        </td>
                                        <td colspan="3" align="left">
                                            <asp:Label ID="lblQuestionwithImage" runat="server" Font-Size="Medium" Text="QuestionwithImage"></asp:Label><asp:Image
                                                ID="imgQuesImage" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px; text-align: left;">
                                            <asp:Label ID="lblH" runat="server" Text="Hint" Font-Size="Large" ForeColor="#CC3300"></asp:Label><br />
                                            <asp:DropDownList ID="ddlhint" runat="server" AutoPostBack="True" Enabled="False">
                                                <asp:ListItem Value="0">English</asp:ListItem>
                                                <asp:ListItem Value="1">Marathi</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td colspan="4" align="left">
                                            <asp:TextBox ID="txtHint" runat="server" Height="32px" TextMode="MultiLine" Width="300px"
                                                Enabled="False"></asp:TextBox><asp:Image ID="imgHint" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 194px; text-align: left;" bgcolor="White">
                                            <asp:Label ID="lblAns" runat="server" Text="Mark for Question" Font-Size="Large"
                                                ForeColor="#CC3300"></asp:Label>
                                        </td>
                                        <td colspan="3" align="left">
                                            <asp:TextBox ID="txtAns" runat="server" MaxLength="15" Visible="False" Width="158px"
                                                Enabled="False"></asp:TextBox>&#160;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 84px; text-align: left;">
                                            <asp:Label ID="lbllevel" runat="server" Font-Size="Large" ForeColor="#CC3300" Text="Level"></asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:RadioButtonList ID="rdoLevelList" runat="server" Font-Names="Arial" Font-Size="Small"
                                                RepeatDirection="Horizontal" ToolTip="Click to select level" Enabled="False">
                                                <asp:ListItem Value="1">Level1</asp:ListItem>
                                                <asp:ListItem Value="2">Level2</asp:ListItem>
                                                <asp:ListItem Value="3">Level3</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <tr>
                                            <td colspan="2" style="text-align: left; height: 29px;">
                                                <asp:Label ID="lblt1" runat="server" Font-Bold="True" Font-Size="Medium" Font-Names="Constantia" ForeColor="#009933"
                                                    Text="lblt1 " Visible="False"></asp:Label>
                                            </td>
                                            <td colspan="2" style="text-align: center; height: 29px;">
                                                <asp:Label ID="lblt2" runat="server" Font-Bold="True" Font-Size="Medium" Font-Names="Constantia" ForeColor="#009933"
                                                    Text=" lblt2" Visible="False"></asp:Label>
                                            </td>
                                            <td colspan="2" style="text-align: left; height: 29px;">
                                                <asp:Label ID="lblt3" runat="server" Font-Bold="True" Font-Size="Medium" Font-Names="Constantia" ForeColor="#009933"
                                                    Text="lblt3 " Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="center">
                                                <asp:CheckBox ID="chkAddQuestion" runat="server" AutoPostBack="True" BackColor="White"
                                                    Font-Bold="True" Font-Italic="True" Font-Names="Times New Roman" Font-Overline="False"
                                                    Font-Underline="False" ForeColor="Red" OnCheckedChanged="chkAddQuestion_CheckedChanged"
                                                    Text="Add Question " />
                                            </td>
                                            <td align="center"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: center">
                                                <asp:Button ID="btnBack" runat="server" Height="39px" OnClick="btnBack_Click" Text="Back"
                                                    Width="71px" CssClass="btn" />&nbsp;<asp:Button ID="btnNext" runat="server" CssClass="btn"
                                                        Height="39px" OnClick="btnNext_Click" Text="Next" Width="71px" />
                                                &nbsp;
                                                <asp:Button ID="btnSubmit1" runat="server" CssClass="btn" Height="39px" Width="71px"
                                                    Text="Submit" OnClick="btnSubmit1_Click" CausesValidation="true" OnClientClick="return confirmationSubmit();" />
                                                <asp:Button ID="btnInsturc" runat="server" Height="31px" Text="Print Instruction"
                                                    Width="94px" OnClick="btnInsturc_Click" Visible="False" />
                                                <asp:Button ID="btnBack1" runat="server" Height="31px" Text="Back" Width="61px" CssClass="btn"
                                                    ToolTip="Back to Setting Page" Visible="False" />
                                                <asp:TextBox ID="txtGotoQues" runat="server" Width="50px" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                &nbsp;
                                                <asp:Button ID="btnGotoQues" runat="server" Height="30px" OnClick="btnGotoQues_Click"
                                                    Text="Go to Question No." Width="118px" />
                                            </td>
                                            <td></td>
                                        </tr>
                                    </tr>
                                </table>
                            </div>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
