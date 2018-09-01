<%@ Page Language="C#" Title="TakePritnOutOfYourTest" AutoEventWireup="true" MasterPageFile="~/Layout/AdminMaster.master"
    CodeFile="TakePrintOut.aspx.cs" Inherits="SubAdmin_TakePrintOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            font-size: 12px;
        }
        .gridview td:hover
        {
            padding: 2px;
            border: solid 1px #c1c1c1;
            font-size: 13px;
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
        .lnkbtnerror
        {
            color: Blue;
            font-family: Courier New;
            font-size: small;
        }
        .lnkbtnerror:hover
        {
            color: Red;
        }
        .pointer
        {
            cursor: pointer;
        }
    </style>
    <div style="width: 100%" align="center">
        <table>
            <tr>
                <th>
                    <asp:Label ID="lblHeading" runat="server" Text="Take PrintOut of Your Test" Font-Size="Medium"
                        Font-Names="Tahoma" Font-Bold="true" ForeColor="Green"></asp:Label>
                </th>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblError" runat="server" Font-Bold="true" Font-Size="Small" Font-Names="Tahoma"
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <div style="width: 60%;" align="center">
            <asp:GridView ID="gvBindTestNamesForPrint" runat="server" CssClass="gridview" AutoGenerateColumns="false"
                DataKeyNames="Test_ID" OnRowCommand="gvBindTestNamesForPrint_RowCommand" OnRowDataBound="gvBindTestNamesForPrint_RowDataBound"
                AllowPaging="true" PageSize="10" EmptyDataText="No Question Papers Available For This Combination..."
                OnPageIndexChanging="gvBindTestNamesForPrint_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <center>
                                <%#Container.DataItemIndex + 1 %>
                            </center>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Test_ID" DataField="Test_ID" Visible="true">
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Test_Name" DataField="Exam_Name" Visible="true">
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="TakePrintOut">
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <center>
                                <asp:LinkButton ID="lnkbtnGiveTest" runat="server" CommandArgument='<%#Bind("Test_ID")%>'
                                    CommandName="TakePrintOut" Font-Bold="true" CssClass="lnkbtnerror" Text="TakePrint"></asp:LinkButton>
                            </center>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Button ID="btnBack" runat="server" Text="Back" Font-Bold="true" OnClick="btnBack_Click"
            BackColor="#800000" Width="100px" Height="25px" ForeColor="White" CssClass="pointer"
            PostBackUrl="~/CreateTest/createtest.aspx" />
    </div>
</asp:Content>
