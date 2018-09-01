<%@ Page Title="Attendance Report" Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AttendanceReport.aspx.cs" Inherits="Andorid_Class_App_AttendanceReport" %>

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
                <table cellpadding="0" cellspacing="0" width="80%" border="1" class="tables">
                    <tr>
                        <td style="text-align: center;">
                            <div style="width: 100%">
                                <center>
                                    <table cellpadding="2" cellspacing="2" width="70%" class="tables" style="text-align: center">
                                        <tr>
                                            <td colspan="2" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                <h3 style="color: Green">Student Attendance Report
                                                </h3>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">
                                                <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; height: 20px">
                                                <asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Error"
                                                    Font-Size="Medium" ForeColor="Red"></asp:Label>
                                            </td>
                                            <td style="text-align: right">&nbsp;
                                            </td>
                                        </tr>
                                        <tr style="background-color: #FFFFBB;">
                                            <span>
                                                <td colspan="2" style="text-align: left; width: 150px">
                                                    <asp:Label ID="lblClass1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                        Text="Class : "></asp:Label>
                                                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="ddlcsswidth" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" Width="90px">
                                                    </asp:DropDownList>
                                                    &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                                                <asp:Label ID="lblBatch1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                    Text="Batch : "></asp:Label>
                                                    <asp:DropDownList ID="ddlBatch" runat="server" Width="75px" AutoPostBack="True" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    &nbsp; &nbsp;&nbsp;
                                                <asp:Label ID="lblSession1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                    Text=" Session : "></asp:Label>
                                                    <asp:DropDownList ID="ddlSession" runat="server" CssClass="ddlcsswidth" AutoPostBack="True" Width="90px"
                                                        OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </span>
                                        </tr>
                                        <asp:Panel ID="pnl1" runat="server" Visible="true">
                                            <tr>
                                                <td style="text-align: left; width: 60px;">
                                                    <asp:Label ID="lblsearchby" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="Select Search By"></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 250px">
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
                                                <td style="text-align: left; width: 100px;">
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
                                                <td style="text-align: left; width: 100px;">
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
                                    <div id="Printdiv" class="grid" style="width: 70%">
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
                                                <tr>
                                                    <td>
                                                        <br />
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td colspan="4" style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                        <asp:Label ID="lblDDate" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="11pt"
                                                            Text="Date From To"></asp:Label>
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
                                                            <asp:GridView ID="gvAttendanceReport" runat="server" Font-Bold="false" Font-Size="Small" CssClass="datatable" CellPadding="5" AlternatingRowStyle-BackColor="WhiteSmoke"
                                                                GridLines="Both" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="Student List is not available."
                                                                PageSize="200">
                                                                <Columns>
                                                                    <asp:BoundField DataField="SNO" HeaderText="SNO">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="name" HeaderText="Student Name" Visible="false">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="25%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="attenDate" HeaderText="Attendance Date" DataFormatString="{0:dd/MM/yyyy}" Visible="false">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Present" HeaderText="Present" Visible="false">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="Present1" HeaderText="Total Present Days" Visible="false">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Absent1" HeaderText="Total Absent Days" Visible="false">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>


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

                                        <%--  display after grid total p .Absent --%>
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    <div id="divHData" style="width: 85%;" runat="server" visible="false">
                                        <table cellpadding="2" cellspacing="2" width="100%" class="tables" border="1">
                                            <tr>
                                                <%--  <td style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                    <asp:Label ID="lblHTotalDay" runat="server" Font-Bold="False" Font-Names="Arial"
                                                        Font-Size="11pt" Text="Date From To "></asp:Label>
                                                </td>--%>

                                                <td style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                    <asp:Label ID="lblHPDay" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                        Text="P Days"></asp:Label>
                                                </td>
                                                <td style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                    <asp:Label ID="lblHADay" runat="server" Font-Bold="False" Font-Names="Arial"
                                                        Font-Size="11pt" Text="A Days"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                        <%-- End:  display after grid total p .Absent --%>
                                    </div>
                                </center>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ddlsearchby" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
