<%@ Page Language="C#" MasterPageFile="~/Layout/Master.master" AutoEventWireup="true" CodeFile="UserDetails.aspx.cs" Inherits="User_UserDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:UpdatePanel ID="UpdatePanel1" runat="server"  >
   
<ContentTemplate >
    &nbsp;<table cellpadding="0" cellspacing="0" width="80%" border="1"   >
    <tr>
        <td align="center" >
            <div style="width: 100%; height: 904px;">
                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                    <div style="width: 90%">
                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                    <tr>
                        <td  style="height: 20px;">
                            <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;">
       <table style="width: 85%" class="tables" cellspacing="2" cellpadding="2">
        <tr>
             <td style="text-align: left; width: 9%;" ></td>
            <td align="center" 
                 
                 style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                    <b>User Exam Details
            </b>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="text-align: left" >
                &nbsp;&nbsp;<asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Label"></asp:Label><asp:Label ID="lblSuccess" runat="server"  CssClass="error" Visible="False" ></asp:Label></td>
        </tr>
        
        <tr>
            <td align="left" style="width:9%; text-align: left;"  >
                Select Test Name</td>
        </td>
            <td align="left" style="width:30%; text-align: left;"  >
                <asp:DropDownList ID="ddlEname" runat="server" AutoPostBack="True" 
                      CssClass="txthiwidth" 
                    onselectedindexchanged="ddlEname_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        
  <tr>
            <td align="left" style="width:9%; text-align: left;"  >
               </td>
        </td>
            <td align="left" style="width:30%; text-align: left;"  >
               
                &nbsp;</td>
        </tr>
      
    </table>
                <div class="grid" style="width: 96%">
                <div class="rounded">
                    <div class="top-outer">
                        <div class="top-inner">
                            <div class="top">
                                &nbsp;
                                <asp:GridView ID="gvState" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" CellPadding="5" CellSpacing="0" 
                                    CssClass="datatable" EmptyDataText="Test Defination List is not available." 
                                    GridLines="None" OnPageIndexChanging="gvState_PageIndexChanging" 
                                    OnRowCommand="gvState_RowCommand" onrowdeleted="gvState_RowDeleted" 
                                    onrowdeleting="gvState_RowDeleting" 
                                    onselectedindexchanged="gvState_SelectedIndexChanged" PageSize="25">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Login ID">
                                            <HeaderStyle HorizontalAlign="Center" Width="30%" />
                                            <ItemStyle HorizontalAlign="Center" Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="name" HeaderText="User Name">
                                            <HeaderStyle HorizontalAlign="Center" Width="30%" />
                                            <ItemStyle HorizontalAlign="Center" Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="testname" HeaderText="Test Name">
                                            <HeaderStyle HorizontalAlign="left" Width="30%" />
                                            <ItemStyle HorizontalAlign="left" Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Marks" HeaderText="Marks">
                                            <HeaderStyle HorizontalAlign="left" Width="30%" />
                                            <ItemStyle HorizontalAlign="left" Width="30%" />
                                        </asp:BoundField>
                                        <%-- <asp:BoundField DataField="Exam_Duration" HeaderText="Status">
                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                            </asp:BoundField>
                                           --%>
                                    </Columns>
                                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <PagerStyle CssClass="pager-row" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="mid-outer" >
                        <div class="mid-inner" >
                            <div class="mid" >
                                <div class="pager" >
                                   
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
    <br />
    </td></tr></table></div>
    
     </td></tr></table>
    </table>
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">You are Interested retesting Click here.....</asp:LinkButton>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

