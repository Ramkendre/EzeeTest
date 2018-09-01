<%@ Page Title="Fees Report" Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="FeesReport.aspx.cs" Inherits="Andorid_Class_App_FeesReport" %>

<%@ Register Assembly="AjaxcontrolToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function printDiv(divID) {
            //Get the HTML of div

            showDiv();
            var divElements = document.getElementById(divID).innerHTML;
            //Get the HTML of whole page
            var oldPage = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML =
              "<html><head><title></title></head><body>" +
              divElements + "</body>";

            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPage;
            document.getElementById('displaydata').style.display = "none";

        }

        // another div 
        function showDiv() {

            document.getElementById('displaydata').style.display = "block";
        }
    </script>

    <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="width: 100%;" align="center">
                <table cellpadding="0" cellspacing="0" width="90%" border="1" class="tables">
                    <tr>
                        <td style="text-align: center;">
                            <div style="width: 100%">
                                <center>
                                    <table cellpadding="2" cellspacing="2" width="65%" class="tables">
                                        <tr>
                                            <td colspan="4" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                <h3 style="color: Green">Student Fees Report
                                                </h3>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: left">
                                                <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: left; height: 20px">
                                                <asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Error"
                                                    Font-Size="Medium" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="background-color: #FFFFBB;">
                                            <td colspan="4" style="text-align: left;">
                                                <asp:Label ID="lblClass1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                    Text="Class : "></asp:Label>
                                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="ddlcsswidth" AutoPostBack="True" Width="90px"
                                                    OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                &nbsp;
                                    <asp:Label ID="lblBatch1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                        Text="Batch : "></asp:Label>
                                                <asp:DropDownList ID="ddlBatch" runat="server" CssClass="ddlcsswidth" AutoPostBack="True" Width="75px"
                                                    OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                &nbsp;
                                    <asp:Label ID="lblSession1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                        Text=" Session : "></asp:Label>
                                                <asp:DropDownList ID="ddlSession" runat="server" CssClass="ddlcsswidth" AutoPostBack="True" Width="90px"
                                                    OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <asp:Panel ID="pnl1" runat="server" Visible="false">
                                            <tr>

                                                <td style="text-align: left; width: 120px;">
                                                    <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Total Fess"></asp:Label>
                                                </td>
                                                <td colspan="3" style="text-align: left;">
                                                    <asp:TextBox ID="txtTotalfees" runat="server" CssClass="txthiwidth" MaxLength="7"
                                                        onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTotalfees"
                                                        Font-Size="Medium" ErrorMessage="*" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                </td>

                                            </tr>
                                            <tr>

                                                <td style="text-align: left; width: 50px;">
                                                    <asp:Label ID="lblsearchby" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Search By"></asp:Label>
                                                </td>
                                                <td colspan="3" style="text-align: left;">
                                                    <asp:DropDownList ID="ddlsearchby" runat="server" AutoPostBack="True" CssClass="ddlcsswidth"
                                                        OnSelectedIndexChanged="ddlsearchby_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">Date</asp:ListItem>
                                                        <asp:ListItem Value="1">Student</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>

                                            </tr>
                                            <tr id="Tr_stud" runat="server" visible="false">

                                                <td style="text-align: left; width: 50px;">
                                                    <asp:Label ID="lblstudent" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Student"></asp:Label>
                                                </td>
                                                <td colspan="3" style="text-align: left;">
                                                    <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" CssClass="ddlcsswidth">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlStudent"
                                                        Font-Size="Medium" ErrorMessage="*" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                </td>

                                            </tr>
                                            <tr id="Tr_date" runat="server">

                                                <td style="text-align: left; width: 50px;">
                                                    <asp:Label ID="lbldatebetween" runat="server" Font-Bold="False" Font-Names="Arial"
                                                        Font-Size="11pt" Text="Select Date"></asp:Label>
                                                </td>
                                                <td colspan="3" style="text-align: left;">
                                                    <span class="warning1">From</span>
                                                    <asp:TextBox ID="txtfromdate" runat="server" Width="70px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                                        PopupButtonID="img2" TargetControlID="txtfromdate">
                                                    </asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfromdate"
                                                        Font-Size="Medium" ErrorMessage="*" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                    <img id="img2" align="middle" alt="ezeesofts &amp; Co." border="0" height="20" src="../resources/images/calendarclick.gif" />
                                                    <span class="warning1">To</span>
                                                    <asp:TextBox ID="txtTodate" runat="server" Width="70px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTodate"
                                                        Font-Size="Medium" ErrorMessage="*" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                                        PopupButtonID="img3" TargetControlID="txtTodate">
                                                    </asp:CalendarExtender>
                                                    <img id="img3" align="middle" alt="ezeesofts &amp; Co." border="0" height="20" src="../resources/images/calendarclick.gif" />
                                                </td>

                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    <asp:Button ID="btnSave" runat="server" Text="Search" CssClass="btn" ValidationGroup="other"
                                                        Width="61px" OnClick="btnSave_Click" />
                                                    &nbsp;<asp:Button ID="btncancel" runat="server" CssClass="btn" Text="Cancel" />
                                                    &nbsp;
                                        <asp:Button ID="btnback" runat="server" CssClass="btn" PostBackUrl="~/Admin/Home.aspx"
                                            Text="Back" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: center">
                                                    <input type="button" value="Print" style="height: 30px; width: 50px; background-color: #FFFFFF; border-color: #361d23; border-width: 1px; color: #361d23; font-weight: bold; font-style: normal; border-radius: 4px 4px 4px 4px;"
                                                        onclick="javascript: printDiv('Printdiv')" />
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                    </table>
                                    <div id="Printdiv" class="grid" style="width: 75%">
                                        <%-- display name ,class--%>
                                        <div id="displaydata" style="width: 100%; display: none">
                                            <table cellpadding="2" cellspacing="2" width="100%" class="tables">
                                                <tr>
                                                    <td style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                            <asp:Label ID="lblDschoolname" runat="server" Font-Bold="False" Font-Names="Arial"
                                                Font-Size="11pt" Font-Underline="true" Text="School Name"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                        <asp:Label ID="lblDClass" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Class Name"></asp:Label>
                                                    </td>
                                                    <td style="text-align: right; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                        <asp:Label ID="lblDBatch" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Batch Name"></asp:Label>
                                                        &nbsp; &nbsp; &nbsp; &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                        <asp:Label ID="lblDSession" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Session Name"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="tr_DStudentname" runat="server" visible="false">
                                                    <td colspan="4" style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                        <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Student Name: "></asp:Label>
                                                        <asp:Label ID="lblDStudentName" runat="server" Font-Underline="true" Font-Bold="true"
                                                            Font-Names="Arial" Font-Size="12pt" Text="Student Name" Font-Italic="true"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="rounded">
                                            <div class="top-outer">
                                                <div class="top-inner">
                                                    <div class="top">
                                                        &nbsp;
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="mid-outer">
                                                <div class="mid-inner">
                                                    <div class="mid">
                                                        <div class="pager">
                                                            <asp:GridView ID="gvFessReport" runat="server" CssClass="datatable" CellPadding="5"
                                                                GridLines="Both" CellSpacing="2" AutoGenerateColumns="False" AllowPaging="True"
                                                                PageSize="200" Font-Bold="True" OnRowDataBound="gvFessReport_RowDataBound" ShowFooter="true">
                                                                <FooterStyle Font-Bold="true" ForeColor="black" BackColor="#61A6F8" BorderStyle="Groove" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="SNO" HeaderStyle-Font-Bold="true" HeaderStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblOrderQty" runat="server" Text='<%#Eval("SNO") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="30%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="35%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ReceiptNo" HeaderText="Receipt No">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Amount" HeaderText="Paid" Visible="false">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="feesdate" HeaderText="Fees Date" DataFormatString="{0:dd/MM/yyyy}">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Paid Fees" HeaderStyle-Width="20%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAmount" runat="server" />
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lbltxtTotal" runat="server" Text="Total Paid" />
                                                                            <asp:Label ID="lblTotal" runat="server" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fees Remaining" HeaderStyle-Width="40%" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblremaingPaid" runat="server" />
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lbltotalFeesRemaining" runat="server" Text="Total Fess Remaining" />
                                                                            <asp:Label ID="lnlTotalFessRemaining" runat="server" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                                <HeaderStyle BackColor="#61A6F8" Font-Bold="True" ForeColor="black"></HeaderStyle>
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
                                        &nbsp; &nbsp; &nbsp; &nbsp;
                            <div id="divHData" style="width: 100%;" runat="server" visible="false">
                                <table cellpadding="2" cellspacing="2" width="100%" class="tables" border="1">
                                    <tr>
                                        <td style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                            <asp:Label ID="lblHTotalfees" runat="server" Font-Bold="False" Font-Names="Arial"
                                                Font-Size="11pt" Text="Total Fees"></asp:Label>
                                        </td>
                                        <td style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                            <asp:Label ID="lblHpaid" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Paid Fess"></asp:Label>
                                        </td>
                                        <td style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                            <asp:Label ID="lblHRemainFess" runat="server" Font-Bold="False" Font-Names="Arial"
                                                Font-Size="11pt" Text="Remaining Fess"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                                    </div>
                                </center>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <%-- <asp:AsyncPostBackTrigger ControlID="ddlsearchby" EventName="SelectedIndexChanged" />--%>
            <asp:PostBackTrigger ControlID="ddlsearchby" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
