<%@ Page Title="Test Report" Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="TestReport.aspx.cs" Inherits="Andorid_Class_App_TestReport" %>

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
                <table style="width: 90%" cellpadding="0" cellspacing="0" border="1" class="tables">
                    <tr>
                        <td>
                            <div style="width: 100%">
                                <center>
                                    <table cellpadding="2" cellspacing="2" style="width: 75%" class="tables">
                                        <tr>
                                            <td colspan="4" style="text-align: center">
                                                <h3 style="color: Green; font-family: Times New Roman; font-size: x-large">Test Report
                                                </h3>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: left">
                                                <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: left;">
                                                <asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Error"
                                                    Font-Size="Medium" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="background-color: #FFFFBB;">
                                            <td colspan="4" style="text-align: left;">
                                                <asp:Label ID="lblClass1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                    Text="Class : "></asp:Label>
                                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="ddlcsswidth" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                &nbsp;
                                            <asp:Label ID="lblBatch1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                Text="Batch : "></asp:Label>
                                                <asp:DropDownList ID="ddlBatch" runat="server" CssClass="ddlcsswidth" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                &nbsp;
                                            <asp:Label ID="lblSession1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                Text=" Session : "></asp:Label>
                                                <asp:DropDownList ID="ddlSession" runat="server" CssClass="ddlcsswidth" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>

                                            <td style="text-align: left; width: 120px;">
                                                <asp:Label ID="lblsearchby" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Select Search By  "></asp:Label>
                                            </td>

                                            <td colspan="3" style="text-align: left;">
                                                <asp:DropDownList ID="ddlsearchby" runat="server" AutoPostBack="True"
                                                    CssClass="ddlcsswidth" OnSelectedIndexChanged="ddlsearchby_SelectedIndexChanged1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Test</asp:ListItem>
                                                    <asp:ListItem Value="2">Student</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>


                                        </tr>
                                        <tr id="Tr_test" runat="server">

                                            <td style="text-align: left; width: 50px;">
                                                <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Select Test"></asp:Label>
                                            </td>
                                            <td colspan="3" style="text-align: left;">
                                                <asp:DropDownList ID="ddltest" runat="server" CssClass="ddlcsswidth">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddltest"
                                                    Font-Size="Medium" ErrorMessage="*" ValidationGroup="other"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                        <tr id="Tr_stud" runat="server" visible="false">

                                            <td style="text-align: left; width: 50px;">
                                                <asp:Label ID="lblstudent" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Select Student"></asp:Label>
                                            </td>
                                            <td colspan="3" style="text-align: left;">
                                                <asp:DropDownList ID="ddlStudent" runat="server"
                                                    CssClass="ddlcsswidth">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlStudent"
                                                    Font-Size="Medium" ErrorMessage="*" ValidationGroup="other"></asp:RequiredFieldValidator>
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
                                                <input type="button" value="Print" style="height: 30px; width: 50px; background-color: #FFFFFF; border-color: #361d23; border-width: 1px; color: #361d23; font-weight: bold; font-style: normal;"
                                                    onclick="javascript: printDiv('Printdiv')" />
                                            </td>
                                        </tr>


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
                                                <tr>
                                                    <td>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr id="tr_D_TestnameDate" runat="server" visible="false">
                                                    <td style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                        <asp:Label ID="lblDTestname" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt" Visible="false"
                                                            Text="Test Name"></asp:Label>
                                                    </td>
                                                    <td style="text-align: right; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                        <asp:Label ID="lblDtestDate" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt" Visible="false"
                                                            Text="Test Date"></asp:Label>
                                                        &nbsp; &nbsp; &nbsp; &nbsp;
                                                    </td>
                                                </tr>
                                                <%-- <tr id="tr_D_outAvg" runat="server" visible="false">
                                        <td style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                            <asp:Label ID="lblDOutofmark" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt" Visible="false"
                                                Text="Out of Marks"></asp:Label>
                                        </td>
                                      
                                    </tr>--%>
                                                <tr id="tr_DStudentname" runat="server" visible="false">
                                                    <td colspan="4" style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                        <asp:Label ID="Label2" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="11pt"
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
                                                            <asp:GridView ID="gvTestReport" runat="server" CssClass="datatable" CellPadding="5"
                                                                GridLines="Both" CellSpacing="2" AutoGenerateColumns="False" AllowPaging="True"
                                                                PageSize="200" Font-Bold="false">

                                                                <Columns>

                                                                    <asp:TemplateField HeaderText="SNo." ItemStyle-Font-Bold="true" HeaderStyle-Width="2%">
                                                                        <ItemTemplate>
                                                                            <%#Container.DataItemIndex + 1%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField DataField="TestName" HeaderText="Test Name" Visible="false">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                    </asp:BoundField>


                                                                    <asp:BoundField DataField="Testdate" HeaderText="Test Date" DataFormatString="{0:dd/MM/yyyy}" Visible="false">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="name" HeaderText="Student Name" Visible="false">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="30%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="35%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="OutofMark" HeaderText="Total Marks">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ObtainedMark" HeaderText="Obtained Marks">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="perc" HeaderText="Percentage">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                    </asp:BoundField>




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
