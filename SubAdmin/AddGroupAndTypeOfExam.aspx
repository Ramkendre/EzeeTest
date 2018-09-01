<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true" CodeFile="AddGroupAndTypeOfExam.aspx.cs" Inherits="SubAdmin_AddGroupAndTypeOfExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:updatepanel id="Updatepanel1" runat="server">
        <ContentTemplate>
            <div class="middle">
                <table cellpadding="0" cellspacing="0" width="100%" border="1">
                    <tr>
                        <td align="center">
                            <tr>
                                <td align="center" style="text-align: center">

                                    <h3 style="color: Green; font-size: x-large;">Add Group Exam And Type Exam</h3>

                                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

                                        <asp:View ID="View1" runat="server">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td colspan="5">
                                                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5">
                                                        <asp:Label ID="lblError" runat="server" Text="Label" Style="color: red;"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 35px"></td>
                                                    <td style="width: 258px; height: 35px">Select Group Exam Name:*

                                                    </td>
                                                    <td style="width: 236px; height: 35px">
                                                        <asp:DropDownList ID="ddlGroupExamName" runat="server" DataKeyValue="Id" AutoPostBack="true" OnSelectedIndexChanged="ddlGroupExamName_SelectedIndexChanged" style="height: 20px" >
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 247px; height: 35px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="1" ControlToValidate="ddlGroupExamName"
                                                            ErrorMessage="Please select Group Exam Name" SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="height: 35px"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 35px"></td>
                                                    <td style="width: 245px; height: 35px">Group Name:

                                                    </td>
                                                    <td style="width: 236px; height: 35px">
                                                        <asp:TextBox ID="txtGroupname" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 247px; height: 35px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGroupname"
                                                            ErrorMessage="Please Enter Group Name" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="height: 35px"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 35px"></td>
                                                    <td style="width: 258px; height: 36px;">Mobile No:

                                                    </td>
                                                    <td style="width: 236px; height: 35px;">
                                                        <asp:TextBox ID="txtmobNo" runat="server" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                  
                                                    <td style="height: 35px"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 35px"></td>
                                                    <td style="width: 258px; height: 36px;"></td>
                                                    <td style="height: 35px;">
                                                        <asp:Button ID="btnSave" runat="server" Height="24px" Text="Save" Width="78px" OnClick="btnSave_Click" CssClass="btn" ValidationGroup="other" />
                                                    </td>
                                                    <td style="height: 35px;">
                                                        <asp:Button ID="btnNext" runat="server" Height="24px" Text="Next" Width="78px" OnClick="btnNext_Click" CssClass="btn" />
                                                    </td>
                                                    <td style="height: 35px" colspan="4"></td>
                                                </tr>
                                                 <tr>
                                                    <td colspan="5">

                                                    </td>
                                                </tr>
                                            </table>
                             <div class="grid" style="width: 70%">
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
                                                <asp:GridView ID="GDview1" runat="server" Width="100%" CssClass="datatable" CellPadding="5"
                                                    CellSpacing="0" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                    EmptyDataText="Item List is not available." PageSize="25" 
                                                    OnRowCommand="GDview1_RowCommand"> 
                                                    <Columns>
                                                         <asp:BoundField DataField="Id" HeaderText="ID">
                                                            <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="GroupOfExamId" HeaderText="Id">
                                                            <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="GroupOfExamName" HeaderText="Group Name">
                                                            <HeaderStyle HorizontalAlign="left" Width="40%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="40%"></ItemStyle>
                                                        </asp:BoundField>
                                                      
                                                        <asp:TemplateField HeaderText="Modify">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("Id") %>' runat="server"
                                                                    ImageUrl="../resources/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
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
                           
                                        </asp:View>
                                        <asp:View ID="View2" runat="server">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td colspan="5">
                                                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5">
                                                        <asp:Label ID="Label8" runat="server" Text="Label" Style="color: red;"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 35px"></td>
                                                    <td style="width: 258px; height: 35px">Select Group Exam Name:*
                                                    </td>
                                                    <td style="width: 246px; height: 35px">
                                                        <asp:DropDownList ID="ddlGroupExamName0" runat="server" DataKeyValue="Id" AutoPostBack="true" OnSelectedIndexChanged="ddlGroupExamName0_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 247px; height: 35px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlGroupExamName0" ErrorMessage="Please select Group Exam Name" SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="height: 35px"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 35px">&nbsp;</td>
                                                    <td style="width: 258px; height: 35px">Select Type Exam Name:*
                                                        &nbsp;</td>
                                                    <td style="width: 246px; height: 35px">
                                                        <asp:DropDownList ID="ddltypeExam" runat="server" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 247px; height: 35px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddltypeExam" ErrorMessage="Please select Type Exam Name" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="height: 35px">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 35px"></td>
                                                    <td style="width: 258px; height: 35px">Type Exam Name:

                                                    </td>
                                                    <td style="width: 246px; height: 35px">
                                                        <asp:TextBox ID="txtTypeExam" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 247px; height: 35px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTypeExam" ErrorMessage="Please Enter Type Name" SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="height: 35px"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 35px"></td>
                                                    <td style="width: 258px; height: 36px;">Mobile No:
                                                    </td>
                                                    <td style="width: 246px; height: 35px;">
                                                        <asp:TextBox ID="txtmobNo0" runat="server" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                
                                                    <td style="height: 35px"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 35px"></td>
                                                    <td style="width: 258px; height: 36px;"></td>
                                                    <td colspan="1" style="height: 35px;">
                                                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="btn" ValidationGroup="other" />
                                                    </td>
                                                    <td style="height: 35px"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5">

                                                    </td>
                                                </tr>
                                            </table>
                                             <div class="grid" style="width: 70%">
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
                                                <asp:GridView ID="GDview2" runat="server" Width="100%" CssClass="datatable" CellPadding="5"
                                                    CellSpacing="0" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                    EmptyDataText="Item List is not available." PageSize="25" 
                                                    OnRowCommand="GDview2_RowCommand"> 
                                                    <Columns>
                                                         <asp:BoundField DataField="Id" HeaderText="ID">
                                                            <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="GroupOfExamId" HeaderText="Group Id">
                                                            <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TypeOfExamName" HeaderText="Type Name">
                                                            <HeaderStyle HorizontalAlign="left" Width="40%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="40%"></ItemStyle>
                                                        </asp:BoundField>
                                                       <asp:BoundField DataField="TypeOfExamId" HeaderText="TypeExamid">
                                                            <HeaderStyle HorizontalAlign="left" Width="40%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="40%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Modify">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("Id") %>' runat="server"
                                                                    ImageUrl="../resources/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:TemplateField>
                                                    
                                                    </Columns>
                                                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <PagerStyle CssClass="pager-row" />
                                                </asp:GridView>
                                                <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
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
                                        </asp:View>
                                    </asp:MultiView>
                                </td>
                            </tr>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:updatepanel>
</asp:Content>

