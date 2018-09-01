<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="StudentRegister.aspx.cs" Inherits="Andorid_Class_App_StudentRegister"
    Title="Student Registration" %>

<%@ Register Assembly="AjaxcontrolToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
        <div style="width:100%;" align="center">
            <table cellpadding="0" cellspacing="0" width="70%" border="1" class="tables">
                <tr>
                    <td style="text-align: center;">
                        <div style="width: 100%">
                            <center>
                                <table cellpadding="2" cellspacing="2" width="70%" class="tables">
                                    <tr>
                                        <td colspan="4" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                            <h3 style="color: Green">
                                                Student Registration
                                            </h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="text-align: left">
                                            <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                            <asp:Label ID="lblClassid" runat="server" Font-Size="Smaller" Text="classId" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="text-align: left; height: 20px">
                                            <asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Error"
                                                Font-Size="Medium" ForeColor="Red"></asp:Label>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:Label ID="Label12" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                Text=" Record No : "></asp:Label>
                                            <asp:Label ID="lblRecordNo" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="12pt"
                                                Text="RecordNo"></asp:Label>
                                        </td>
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
                                    <tr style="height: 50px;">
                                        <span>
                                            <td style="text-align: right;">
                                                <asp:Label ID="lblAdm_No" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Admission No."></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="txtAdm_No" runat="server" CssClass="txtcssNo" Font-Bold="True" onkeypress="return numbersonly(this,event)"
                                                    AutoPostBack="True" OnTextChanged="txtAdm_No_TextChanged"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAdm_No"
                                                    Font-Size="Medium" ValidationGroup="other" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </td>
                                            <td style="text-align: right;">
                                                <asp:Label ID="lblAdm_Date" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                    Text="Admission Date"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="txtAdm_Date" runat="server" CssClass="txtcss" OnTextChanged="txtAdm_Date_TextChanged"></asp:TextBox>
                                                <img id="imgFromDate" align="middle" alt="ezeesofts &amp; Co." border="0" height="20"
                                                    src="../resources/images/calendarclick.gif" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAdm_Date"
                                                    Font-Size="Medium" ValidationGroup="other" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                    PopupButtonID="imgFromDate" TargetControlID="txtAdm_Date">
                                                </asp:CalendarExtender>
                                            </td>
                                        </span>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; width: 125px">
                                        </td>
                                        <td style="text-align: left; width: 125px">
                                            <asp:Label ID="lblFN" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="First Name "></asp:Label>
                                        </td>
                                        <td style="text-align: left;" colspan="2">
                                            <asp:TextBox ID="txtFN" runat="server" CssClass="txtcss"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFN"
                                                Font-Size="Medium" ValidationGroup="other" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; width: 125px">
                                        </td>
                                        <td style="text-align: left; width: 125px">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Last Name "></asp:Label>
                                        </td>
                                        <td style="text-align: left;" colspan="2">
                                            <asp:TextBox ID="txtLN" runat="server" CssClass="txtcss"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLN"
                                                Font-Size="Medium" ValidationGroup="other" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; width: 125px">
                                        </td>
                                        <td style="text-align: left; width: 125px">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Father Name "></asp:Label>
                                        </td>
                                        <td style="text-align: left;" colspan="2">
                                            <asp:TextBox ID="txtFatherName" runat="server" CssClass="txtcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; width: 125px">
                                        </td>
                                        <td style="text-align: left; width: 125px">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Parent Mobile No"></asp:Label>
                                        </td>
                                        <td style="text-align: left;" colspan="2">
                                            <asp:TextBox ID="txtParaentMob_No" runat="server" CssClass="txtcss" onkeypress="return numbersonly(this,event)"
                                                MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtParaentMob_No"
                                                Font-Size="Medium" ValidationGroup="other" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtParaentMob_No"
                                                Display="Dynamic" ErrorMessage="&lt;br&gt;Mobile Number must be 10 digit" Font-Size="12px"
                                                ValidationExpression="^[0-9]{10}$" ValidationGroup="other"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; width: 125px">
                                        </td>
                                        <td style="text-align: left; width: 125px">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Student Mobile No"></asp:Label>
                                        </td>
                                        <td style="text-align: left;" colspan="2">
                                            <asp:TextBox ID="txtStudMob_No" runat="server" CssClass="txtcss" onkeypress="return numbersonly(this,event)"
                                                MaxLength="10"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtStudMob_No"
                                                Display="Dynamic" ErrorMessage="&lt;br&gt;Mobile Number must be 10 digit" Font-Size="12px"
                                                ValidationExpression="^[0-9]{10}$" ValidationGroup="other"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; width: 125px">
                                        </td>
                                        <td style="text-align: left; width: 125px">
                                            <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="DOB"></asp:Label>
                                        </td>
                                        <td style="text-align: left;" colspan="2">
                                            <asp:TextBox ID="txtDOB" runat="server" CssClass="txtcss"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                PopupButtonID="img1" TargetControlID="txtDOB">
                                            </asp:CalendarExtender>
                                            <img id="img1" align="middle" alt="ezeesofts &amp; Co." border="0" height="20" src="../resources/images/calendarclick.gif" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; width: 125px">
                                        </td>
                                        <td style="text-align: left; width: 125px">
                                            <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Gender"></asp:Label>
                                        </td>
                                        <td style="text-align: left;" colspan="2">
                                            <asp:RadioButtonList ID="rdoGender" runat="server" Font-Size="Small" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="0">Boy</asp:ListItem>
                                                <asp:ListItem Value="1">Girl</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; width: 125px">
                                        </td>
                                        <td style="text-align: left; width: 125px">
                                            <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Address"></asp:Label>
                                        </td>
                                        <td style="text-align: left;" colspan="2">
                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="txthiwidth" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; width: 125px">
                                        </td>
                                        <td style="text-align: left; width: 125px">
                                            <asp:Label ID="Label13" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Ward No"></asp:Label>
                                        </td>
                                        <td style="text-align: left;" colspan="2">
                                            <asp:TextBox ID="txtwardNo" runat="server" CssClass="txtcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; width: 125px">
                                        </td>
                                        <td style="text-align: left; width: 125px">
                                            <asp:Label ID="Label14" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Area"></asp:Label>
                                        </td>
                                        <td style="text-align: left;" colspan="2">
                                            <asp:TextBox ID="txtArea" runat="server" CssClass="txtcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; width: 125px">
                                        </td>
                                        <td style="text-align: left; width: 125px">
                                            <asp:Label ID="Label11" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="">City</asp:Label>
                                        </td>
                                        <td style="text-align: left;" colspan="2">
                                            <asp:TextBox ID="txtCity" runat="server" CssClass="txtcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; width: 125px">
                                        </td>
                                        <td style="text-align: left; width: 125px">
                                            <asp:Label ID="Label15" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Pincode"></asp:Label>
                                        </td>
                                        <td style="text-align: left;" colspan="2">
                                            <asp:TextBox ID="txtPincode" runat="server" CssClass="txtcssNo" onkeypress="return numbersonly(this,event)"
                                                MaxLength="6"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPincode"
                                                Display="Dynamic" ErrorMessage="&lt;br&gt;Pincode Number must be 6 digit" Font-Size="12px"
                                                ValidationExpression="^[0-9]{6}$" ValidationGroup="other"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="text-align: center">
                                            <asp:Button ID="Button12" runat="server" onclick="Button12_Click" CssClass="btn"
                                                Text="Upload student MDB File " Enabled="false" />
                                            &nbsp; &nbsp; &nbsp; &nbsp;
                                            <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="Save" Width="58px" Enabled="false" OnClick="btnSave_Click"
                                                ValidationGroup="other" />
                                            &nbsp; &nbsp;<asp:Button ID="btncancel" runat="server" CssClass="btn" OnClick="btncancel_Click"
                                                Text="Cancel" />
                                            &nbsp;
                                            <asp:Button ID="btnback" runat="server" CssClass="btn" PostBackUrl="~/Admin/Home.aspx"
                                                Text="Back" />
                                            <%-- call popup from .cs coding on save btn click after code execute--%>
                                            <asp:Button ID="Button11" runat="server" Visible="false" Width="0px" Height="0px" />
                                            <asp:Label ID="lblSNo1" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="10pt"
                                                Visible="False" Width="0px" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>


                               


                                <asp:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="Button11" PopupControlID="popUpPanel"
                                    CancelControlID="btnclose" BackgroundCssClass="modalBackground" DropShadow="true"
                                    runat="server">
                                </asp:ModalPopupExtender>
                                <%--  panel pop up style="display:none"--%>
                                <asp:Panel ID="popUpPanel" runat="server" Width="90%" BackColor="White" style="display:none" >
                                    <div id="loginform">
                                        <table>
                                            <tr>
                                                <td colspan="4" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                    <h4 style="color: Green">
                                                        Family Details
                                                    </h4>
                                                </td>
                                            </tr>
                                            <tr>
                                             <td>
                                                    <span style="font-size: medium">  Student Name  :</span>
                                                                                               </td>
                                                <td>
                                                    <asp:Label ID="pnllblStudName" runat="server" Text="Label" Font-Size="Small"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span style="font-size: medium">Relation :</span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRelation"
                                                        Font-Size="Medium" ValidationGroup="btninstruc" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRelation" runat="server" placeholder=" Enter Relation" Width="176px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span style="font-size: medium">Name: </span>&nbsp;
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRelName"
                                                        Font-Size="Medium" ValidationGroup="btninstruc" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRelName" runat="server" placeholder=" Enter Name" Width="176px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span style="font-size: medium">Age: </span>&nbsp;
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtAge"
                                                        Font-Size="Medium" ValidationGroup="btninstruc" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAge" runat="server" placeholder=" Enter Age" onkeypress="return numbersonly(this,event)"
                                                        MaxLength="3" Width="90px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span style="font-size: medium">Education: </span>&nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEducation" runat="server" placeholder=" Enter Education" Width="176px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 120px">
                                                    <span style="font-size: medium">Occupation:</span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtOccupation"
                                                        Font-Size="Medium" ValidationGroup="btninstruc" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOccupation" runat="server" placeholder=" Enter Occupation" Width="176px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnInstru" runat="server" Text="Submit" OnClick="btnInstru_Click"
                                                        ValidationGroup="btninstruc" />
                                                    &nbsp;<asp:Button ID="btnclose0" runat="server" Text="Clear" OnClick="btnclose0_Click" />
                                                    &nbsp;<asp:Button ID="btnclose" runat="server" Text="Skip" Width="70px" CausesValidation="false"
                                                        CssClass="btn" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="grid" style="width: 65%;">
                                        <div class="rounded">
                                            <div class="top-outer">
                                                <div class="top-inner">
                                                    <div class="top">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="mid-outer">
                                                <div class="mid-inner">
                                                    <div class="mid">
                                                        <div class="pager">
                                                            <asp:GridView ID="gvFamilyDetails" runat="server" CssClass="datatable" CellPadding="5"
                                                                GridLines="None" AllowPaging="True" PageSize="10" AutoGenerateColumns="False"
                                                                OnRowCommand="gvFamilyDetails_RowCommand" OnRowDeleting="gvFamilyDetails_RowDeleting">
                                                                <Columns>
                                                                    <asp:BoundField DataField="SNO" HeaderText="SNO" HtmlEncode="true" ItemStyle-Width="5%">
                                                                        <ItemStyle Width="15%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Relation" HeaderText="Relation" HtmlEncode="true" ItemStyle-Width="35%">
                                                                        <ItemStyle Width="35%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Rel_Name" HeaderText="Name" HtmlEncode="true" ItemStyle-Width="35%">
                                                                        <ItemStyle Width="35%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Age" HeaderText="Age" HtmlEncode="true" ItemStyle-Width="35%">
                                                                        <ItemStyle Width="35%" />
                                                                    </asp:BoundField>
                                                         
                                                                    <asp:TemplateField HeaderText="Delete">
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("SNO")%>' runat="server"
                                                                                OnClientClick="return confirmationDelete();" ImageUrl="../resources/images/close.gif"
                                                                                CommandName="Delete"></asp:ImageButton>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <PagerStyle CssClass="pager-row" />
                                                            </asp:GridView>
                                                            <asp:Label ID="lblid2" runat="server" Visible="false"></asp:Label>
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
                                </asp:Panel>
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
                                                        <asp:GridView ID="gvStudentRegister" runat="server" CssClass="datatable" CellPadding="5"
                                                            GridLines="None" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="Student registration List is not available."
                                                            PageSize="20" OnPageIndexChanging="gvStudentRegister_PageIndexChanging" OnRowCommand="gvStudentRegister_RowCommand"
                                                            OnRowDataBound="gvStudentRegister_RowDataBound" OnRowDeleting="gvStudentRegister_RowDeleting"
                                                            OnRowUpdating="gvStudentRegister_RowUpdating">
                                                            <Columns>
                                                                <asp:BoundField DataField="SNO" HeaderText="ID">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Adm_No" HeaderText="Admission No">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="First_Name" HeaderText="First Name">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Last_Name" HeaderText="Last Name">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Father_Name" HeaderText="Father Name">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                </asp:BoundField>
                                                               
                                                                <asp:BoundField DataField="Parent_MobNo" HeaderText="Parent Mob.No ">
                                                                    <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Modify">
                                                                    <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("SNO")%>' runat="server"
                                                                            ImageUrl="../resources/images/ico_yes1.gif" Enabled="false" CommandName="Modify"></asp:ImageButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImageButton3" CommandArgument='<%#Bind("SNO")%>' runat="server"
                                                                            OnClientClick="if(!confirm(' Are you sure you want delete this student ?')) return false;"
                                                                            ImageUrl="../resources/images/close.gif" Enabled="false" CommandName="Delete"></asp:ImageButton>
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
            </table></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
