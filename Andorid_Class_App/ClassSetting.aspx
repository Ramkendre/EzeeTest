<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ClassSetting.aspx.cs" Inherits="Andorid_Class_App_ClassSetting" Title="Class Setting" %>

<%@ Register Assembly="AjaxcontrolToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div style="width: 100%;" align="center">
                <table cellpadding="0" cellspacing="0" width="70%" border="1" class="tables">
                    <tr>
                        <td style="text-align: center;">
                            <div style="width: 100%">
                                <center>
                                    <table cellpadding="2" cellspacing="2" width="60%" class="tables">
                                        <tr>
                                            <td colspan="2" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                <h3 style="color: Green">Class Settings
                                                </h3>
                                            </td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="text-align: left">
                                                <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; height: 20px">
                                                <asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Error"
                                                    Font-Size="Medium" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="text-align: left; width: 150px">
                                                <asp:Label ID="lblSession" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Select Session"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">

                                                <asp:DropDownList ID="ddlSession" runat="server" CssClass="ddlcsswidth " Height="22px">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">2013-2014</asp:ListItem>
                                                    <asp:ListItem Value="2">2014-2015</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                    ControlToValidate="ddlSession" ErrorMessage="*" Font-Size="Small"
                                                    InitialValue="0" SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="text-align: left; width: 150px">
                                                <asp:Label ID="lblClass" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Select Class"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="ddlcsswidth " Height="22px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlClass"
                                                    Font-Size="Medium" ErrorMessage="*" ValidationGroup="other"
                                                    InitialValue="1"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="text-align: left; width: 150px">
                                                <asp:Label ID="lblBatch" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Select Batch"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="ddlBatch" runat="server" CssClass="ddlcsswidth " Height="22px">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">A</asp:ListItem>
                                                    <asp:ListItem Value="2">B</asp:ListItem>
                                                    <asp:ListItem Value="3">C</asp:ListItem>
                                                    <asp:ListItem Value="4">D</asp:ListItem>
                                                    <asp:ListItem Value="5">E</asp:ListItem>
                                                    <asp:ListItem Value="6">F</asp:ListItem>
                                                    <asp:ListItem Value="7">G</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlBatch"
                                                    Font-Size="Medium" ErrorMessage="*" ValidationGroup="other"
                                                    InitialValue="0"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; width: 150px">
                                                <asp:Label ID="lblSemester" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Select Semester"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="ddlSemester" runat="server" CssClass="ddlcsswidth " Height="22px">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Sem 1</asp:ListItem>
                                                    <asp:ListItem Value="2">Sem 2</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSemester"
                                                    Font-Size="Medium" ErrorMessage="*" ValidationGroup="other"
                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; width: 179px">
                                                <asp:Label ID="lblClassTeach" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Enter Class Teacher Name"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="txtClasTeach" runat="server" CssClass="txthiwidth"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; width: 150px">
                                                <asp:Label ID="lblMobNo" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Enter Mobile No."></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="txtMobNo" runat="server" CssClass="txthiwidth" MaxLength="10"
                                                    onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rq1" runat="server" ControlToValidate="txtMobNo" Font-Size="Medium" ErrorMessage="*" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="regularExp1" ControlToValidate="txtMobNo" runat="server" Font-Size="12px" Display="Dynamic"
                                                    ErrorMessage="Mobile Number must be 10 digit " ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>


                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; width: 150px">
                                                <asp:Label ID="lblEmailid" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Enter Email-Id"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="txtEmailId" runat="server" CssClass="txthiwidth"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                                    ControlToValidate="txtEmailId" Display="Dynamic"
                                                    ErrorMessage="Enter Valid Email Id" Font-Size="12px"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="other"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="2" style="text-align: center">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" ValidationGroup="other"
                                                    Width="61px" OnClick="btnSave_Click" Enabled="false" />
                                                &nbsp;<asp:Button ID="btncancel" runat="server" CssClass="btn" Text="Cancel" />
                                                &nbsp;
                                                <asp:Button ID="btnback" runat="server" CssClass="btn" PostBackUrl="~/Admin/Home.aspx"
                                                    Text="Back" />
                                            </td>
                                        </tr>
                                    </table>

                                    <div style="margin-left: 450px; text-shadow: 2px 2px Pink;">
                                        <div id="myDIV">
                                            <asp:Label ID="lblTotalClassCount" runat="server" Text="Total Student Count :"></asp:Label>
                                            &nbsp;&nbsp;&nbsp;&nbsp
                                    <asp:Label ID="lblClassCuntDisplay" runat="server" Text="" Font-Size="37px" Font-Bold="true" ForeColor="Green"></asp:Label>
                                            <br />
                                        </div>
                                    </div>

                                    <div class="grid" style="width: 75%">
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
                                                            <asp:GridView ID="gvclassSetting" runat="server" CssClass="datatable"
                                                                CellPadding="5" GridLines="None"
                                                                AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="Class Settings List is not available."
                                                                PageSize="20" OnPageIndexChanged="gvclassSetting_PageIndexChanged"
                                                                OnPageIndexChanging="gvclassSetting_PageIndexChanging"
                                                                OnRowCommand="gvclassSetting_RowCommand"
                                                                OnRowDataBound="gvclassSetting_RowDataBound"
                                                                OnRowDeleting="gvclassSetting_RowDeleting" OnRowUpdating="gvclassSetting_RowUpdating">
                                                                <Columns>
                                                                    <asp:BoundField DataField="ClassSetting_id" HeaderText="ID">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="Session" HeaderText="Session   ">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="25%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Batch" HeaderText="Batch   ">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Semester" HeaderText="Semester ">
                                                                        <HeaderStyle HorizontalAlign="left" Width="10%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Class_Teacher" HeaderText="Class Teacher   ">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Mob_No" HeaderText="Mob. No   ">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="30%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="StudentTotal" HeaderText="Student Count">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Modify">
                                                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("ClassSetting_id")%>' runat="server"
                                                                                ImageUrl="../resources/images/ico_yes1.gif" Enabled="false" CommandName="Modify"></asp:ImageButton>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Register Student" HeaderStyle-ForeColor="Red">
                                                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImageButton3" CommandArgument='<%#Bind("ClassSetting_id")%>' runat="server"
                                                                                ImageUrl="../resources/images/ico_yes1.gif" CommandName="RegisterStudent"></asp:ImageButton>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
