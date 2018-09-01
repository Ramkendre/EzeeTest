<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout/AdminMaster.master"
    CodeFile="TakePracticeByTest.aspx.cs" Inherits="SubAdmin_Default" Title="eZeeTest:Practice Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
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

        .lnkbtnerror {
            color: HighlightText;
            font-family: Courier New;
            font-size: medium;
            font-weight: bold;
            text-shadow: 2px 2px 2px yellow;
        }

            .lnkbtnerror:hover {
                text-decoration: underline;
                color: Red;
            }

        .pointer {
            cursor: pointer;
        }

        .lnkbtnGiveTest {
            color: Blue;
            font-family: Courier New;
            font-size: small;
        }

            .lnkbtnGiveTest:hover {
                color: Red;
            }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <div style="width: 100%;" align="center">
                        <table>
                            <tr>
                                <th>
                                    <asp:Label ID="lblhead" runat="server" Font-Size="Medium" Font-Names="Tahoma" Text="Practice Question Paper Set"
                                        Font-Bold="true" ForeColor="Green"></asp:Label>
                                </th>
                            </tr>
                        </table>
                        <br />
                        <table style="width: 50%; height: 100px; border: 2px solid black; vertical-align: text-top;">
                            <tr>
                                <td width="22%">
                                    <b>Select GroupOfExam :</b>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlGroupofExam" runat="server" OnSelectedIndexChanged="ddlGroupofExam_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem Value="1">--Select--</asp:ListItem>
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
                                        <asp:ListItem Value="455">PreFoundation (GK JEE and NEET)</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="reqddlGroupofExam" runat="server" ControlToValidate="ddlGroupofExam"
                                        ErrorMessage=" * Required " InitialValue="1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Select Exam Name :</b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlExamName" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="reqddlExamName" runat="server" ControlToValidate="ddlExamName"
                                        ErrorMessage=" * Required " InitialValue="1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="btnProceed" runat="server" Font-Bold="true" BackColor="#800000" ForeColor="White"
                                        Text="Click To Proceed !!!" OnClick="btnProceed_Click" CssClass="pointer" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div style="width: 100%" align="center">
                        <div style="width: 60%;" align="center">
                            <asp:Label ID="lblalert" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label><br />
                            <br />
                            <asp:GridView ID="gvBindTestName" AutoGenerateColumns="false" DataKeyNames="Test_ID"
                                Width="100%" runat="server" CssClass="gridview" OnRowDataBound="gvBindTestName_RowDataBound"
                                OnRowCommand="gvBindTestName_RowCommand" AllowPaging="true" PageSize="5" EmptyDataText="No Question Papers Available For This Combination..."
                                OnPageIndexChanging="gvBindTestName_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <center>
                                                <%#Container.DataItemIndex + 1%></center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Test_ID" DataField="Test_ID" Visible="true">
                                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Test_Name" DataField="Exam_Name" Visible="true">
                                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Give Test">
                                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <center>
                                                <asp:LinkButton ID="lnkbtnGiveTest" runat="server" CommandArgument='<%#Bind("Test_ID")%>'
                                                    CommandName="Give Test" Font-Bold="true" Text="GiveTest" CssClass="lnkbtnGiveTest"></asp:LinkButton>
                                            </center>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Button ID="btnBack" runat="server" Text="Back" Font-Bold="true" OnClick="btnBack_Click"
                                BackColor="#800000" Width="100px" Height="25px" ForeColor="White" CssClass="pointer" />
                        </div>
                    </div>
                    <%--<asp:LinkButton ID="lnkbtnEnterCode" runat="server" CssClass="lnkbtnerror" Text="Click Here To Enter Your Code...!!!"></asp:LinkButton>--%><br />
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
