<%@ Page Title="Student mdb FileUpload" Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="StudentmdbFileUpload.aspx.cs" Inherits="Andorid_Class_App_StudentmdbFileUpload" %>

<%@ Register Assembly="AjaxcontrolToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="width: 100%;" align="center">

        <%--<asp:UpdatePanel ID="Updatepanel1" runat="server">
 
        <ContentTemplate>--%>
        <table cellpadding="0" cellspacing="0" width="75%" border="1" class="tables">
            <tr>
                <td style="text-align: center;">
                    <div style="width: 100%">
                        <center>
                            <table cellpadding="2" cellspacing="2" width="75%" class="tables">
                                <tr>
                                    <td colspan="4" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                        <h3 style="color: Green">Database(.Mdb) File Upload
                                        </h3>
                                    </td>
                                    <%--<td>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>--%>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left">
                                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: left; height: 20px">
                                        <asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Error"
                                            Font-Size="Medium" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="text-align: right">&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td></td>
                                </tr>
                                <tr style="background-color: #FFFFBB;">
                                    <span>
                                        <td colspan="4" style="text-align: left; width: 150px">
                                            <asp:Label ID="lblClass1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                Text="Class : "></asp:Label>
                                            <asp:Label ID="lblClass" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                Text="Class"></asp:Label>
                                            &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                                                <asp:Label ID="lblBatch1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                    Text="Batch : "></asp:Label>
                                            <asp:Label ID="lblBatch" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                Text="Batch"></asp:Label>
                                            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                                                <asp:Label ID="lblSession1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                    Text=" Session : "></asp:Label>
                                            <asp:Label ID="lblSession" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                Text="Session"></asp:Label>
                                        </td>
                                    </span>
                                </tr>
                                <tr>
                                    <td style="text-align: center">
                                        <asp:Label ID="Label1" runat="server" Font-Size="Medium"
                                            Text="Select Database File"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                            ControlToValidate="FileUpload1" ErrorMessage="*" Font-Size="Small"
                                            SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2" style="text-align: center">&nbsp; &nbsp; &nbsp; &nbsp;
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click" Text="Upload file"
                                            ValidationGroup="other" Width="71px" />
                                        &nbsp;<asp:Button ID="btncancel" runat="server" CssClass="btn" Text="Cancel" />
                                        &nbsp;
                                            <asp:Button ID="btnback" runat="server" CssClass="btn" PostBackUrl="~/Andorid_Class_App/ClassSetting.aspx"
                                                Text="Back" />


                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center;">
                                        <asp:Button ID="Button1" runat="server" CssClass="btn"
                                            Text="Submit selected Record" OnClick="Button1_Click" Height="25px" />
                                    </td>
                                </tr>
                            </table>
                            <div class="grid" style="width: 60%">
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

                                                    <asp:GridView ID="gvmdbupload" runat="server" CssClass="datatable" CellPadding="5" AlternatingRowStyle-BackColor="WhiteSmoke"
                                                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="Student List is not available."
                                                        Font-Bold="True" OnRowDataBound="gvmdbupload_RowDataBound"
                                                        OnPageIndexChanging="gvmdbupload_PageIndexChanging" PageSize="10000">

                                                        <Columns>
                                                            <asp:BoundField DataField="pklLearnerId" HeaderText="SNO">
                                                                <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="vsFname" HeaderText="First Name">
                                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="vsMname" HeaderText="Father Name">
                                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="vsLname" HeaderText="Last Name">
                                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="dtDob" HeaderText="DOB" DataFormatString="{0:dd/MM/yyyy}">
                                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>


                                                            <asp:BoundField DataField="vsGender" HeaderText="Gender">
                                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>

                                                            <asp:TemplateField HeaderText="Selected Student Add" ItemStyle-HorizontalAlign="Right">
                                                                <ItemStyle HorizontalAlign="left" Width="5%"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkSelect" Checked="true" runat="server" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                        </center>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
