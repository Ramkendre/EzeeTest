<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Master.master" AutoEventWireup="true" CodeFile="addExamname.aspx.cs" Inherits="addExamname" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <table cellpadding="0" cellspacing="0" width="70%" border="1" ><tr><td align="center" >
            <div style="width: 90%; margin-left: 115px; margin-right: 05px;">
                <table cellpadding="0" cellspacing="0" border="0" class="tables" 
                    style="width: 82%; margin-left: 45px; margin-right: 50px">
                    <tr>
                        <td colspan="2"  style="height: 20px;">
                            <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 20px;">
       <table style="width: 127%; margin-left: 0px;" class="tables" cellspacing="7px">
        <tr>
            
            <td colspan="4" align="center" 
                 
                 style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                    <b>Add Exam Name
            </b>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" >
                &nbsp;&nbsp;<asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Label"></asp:Label><asp:Label ID="lblSuccess" runat="server"  Visible="False"  CssClass="error" ></asp:Label><br />
                <asp:Label ID="Label1" runat="server" CssClass="error" ></asp:Label>
                
                
                </td>
        </tr>
        <tr>
        <td style="height: 35px; font-family: Arial; width: 136px;">
 Select College Name
               *</td>
               <td style="height: 35px">
                  
                   <asp:DropDownList ID="ddlCollege" runat="server" AutoPostBack="True" 
                       Height="25px" Width="120px"
                       onselectedindexchanged="ddlCollege_SelectedIndexChanged" 
                       CssClass="ddlcsswidth">
                   </asp:DropDownList>
                <br />
                
        </td>
        
        </tr>
           <tr>
               <td style="height: 32px; font-family: Arial; width: 136px;">
 Add Exam Name
                   *
               </td>
               <td style="height: 32px">
                  
                <asp:TextBox ID="txtexamname" runat="server" Height="20px" Width="120px" CssClass ="txtcss"
                    ToolTip="Click here to enter subject" ></asp:TextBox>
                <br />
                
        </td>
               <td class="error" style="height: 32px">
 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                       ControlToValidate="txtexamname" ErrorMessage="You have not entered subject name"
                SetFocusOnError="True" Width="225px" ValidationGroup="other"></asp:RequiredFieldValidator>

                   </td>
           </tr>

        <tr>
         
            <td colspan="2" align="center" style="text-align: right" >
        &nbsp; &nbsp; &nbsp;        
        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" ValidationGroup="other" CssClass="btn" />
        &nbsp; &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                    CssClass="btn" onclick="btnCancel_Click"  
                     />
  &nbsp;&nbsp;
        <asp:Button ID="btnback" runat="server" Text="Back" 
                    CssClass="btn" 
                    PostBackUrl="~/html/Home.aspx" onclick="btnback_Click" /> 
  </td>
        </tr>
    </table>
    <br />
   
           <div class="mid">
                       <div class="grid" style="width: 70%; margin-right: 102px;">
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
                              <div class="pager">
                              
                               
                              
                              
                                     <asp:GridView ID="gdExam" runat="server" Width="100%" CssClass="datatable" OnRowCommand="gdExam_RowCommand"
                                        OnPageIndexChanging="gdExam_PageIndexChanging" CellPadding="5" CellSpacing="0"
                                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" 
                                        EmptyDataText="Exam  List is not available." PageSize="25" 
                                         onrowdeleted="gdExam_RowDeleted" onrowdeleting="gdExam_RowDeleting" 
                                        >   
                                        
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Id">
                                                <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Name" HeaderText="Exam Name">
                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Modify">
                                                <itemstyle horizontalalign="Center"></itemstyle>
                                                <itemtemplate>
                                                    <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("Id") %>' runat="server" ImageUrl="../resources/images/ico_yes1.gif"
                                                        CommandName="Modify" >
                                                    </asp:ImageButton>
                                                </itemtemplate>
                                                <headerstyle horizontalalign="Center"></headerstyle>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Delete">
                                                <itemstyle horizontalalign="Center"></itemstyle>
                                                <itemtemplate>
                                                    <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("Id") %>' runat="server" ImageUrl="../resources/images/close.gif"
                                                        CommandName="Delete" >
                                                    </asp:ImageButton>
                                                </itemtemplate>
                                                <headerstyle horizontalalign="Center"></headerstyle>
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
     </td></tr></table>
   
   
 </div>   </td></tr></table>
   
   
    <%--<table style="left: 182px; position: absolute; top: 40px; border-right: gainsboro thin ridge; border-top: gainsboro thin ridge; border-left: gainsboro thin ridge; width: 557px; border-bottom: gainsboro thin ridge; height: 350px;">
        <tr>
            <td style="height: 473px">
            <asp:Panel ID="Panel1" runat="server" Width="1400px" style="left: 100px; top: -11px; border-top-width: thin; border-left-width: thin; border-left-color: #999999; border-bottom-width: thin; border-bottom-color: #999999; border-top-color: #999999; border-right-width: thin; border-right-color: #999999; background-color: gainsboro;" BackColor="White" Height="498px" BorderColor="Gainsboro" >
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
        <asp:Panel ID="Panel2" runat="server" BackColor="Cornsilk" BorderColor="Gainsboro"
            Height="60px" Style="left: 1px; position: absolute; top: 1px" Width="1400px">
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="MidnightBlue"
                Style="left: 249px; position: absolute; top: 12px" Text="Add Exam Name"></asp:Label>
        </asp:Panel>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label 
                    ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="13pt" 
                    ForeColor="#804000" Style="left: 699px; position: absolute; top: 941px" 
                    Visible="False" Width="366px"></asp:Label><br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="lblError" runat="server"
            Font-Size="Medium" ForeColor="Red" Width="308px"></asp:Label><br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<br />
                &nbsp;<asp:Label ID="lblExamname" runat="server" 
            Text='Enter Exam Name : &lt;sup&gt;&lt;Font Color="Red"&gt;*&lt;/Font Color&gt;&lt;/sup&gt;' 
            Font-Bold="False" Font-Names="Arial" Font-Size="11pt"></asp:Label>&nbsp;
                <asp:TextBox ID="txtexamname" runat="server" Height="20px" 
                    ToolTip="Click here to enter subject" Width="285px"></asp:TextBox>
                <br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                runat="server" ControlToValidate="txtexamname" ErrorMessage="You have not entered subject name"
                SetFocusOnError="True" ToolTip="required field validator" Width="225px"></asp:RequiredFieldValidator>
        <br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        
        
       --%> 
                <%--&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; 
        <asp:Button ID="btnSubmit" runat="server"
            Text="Save" ToolTip="Click here to submit" OnClick="btnSubmit_Click" Width="58px" BackColor="LightSteelBlue" BorderStyle="Ridge" style="left: 227px; top: 369px" Height="26px" />
                &nbsp; &nbsp; 
        <asp:Button ID="btnEdit"
            runat="server" Text="Edit" ToolTip="Click here to modify" OnClick="btnEdit_Click1" ValidationGroup="other" Width="58px" BackColor="LightSteelBlue" BorderStyle="Ridge" style="left: 329px; top: 369px" Height="26px" />
                &nbsp; &nbsp; <asp:Button ID="btnDelete"
            runat="server" Text="Delete" ToolTip="Click here to Delete" OnClick="btnDelete_Click1" ValidationGroup="other" Width="58px" BackColor="LightSteelBlue" BorderStyle="Ridge" style="left: 329px; top: 369px" Height="26px" />
       
                &nbsp; &nbsp;
        <asp:Button ID="btnExit" runat="server" Text="Exit" ToolTip="Click here to exit" OnClick="btnExit_Click1" ValidationGroup="other" Width="58px" BackColor="LightSteelBlue" BorderStyle="Ridge" style="left: 421px; top: 369px" Height="26px" />
  --%>  
</asp:Content>

