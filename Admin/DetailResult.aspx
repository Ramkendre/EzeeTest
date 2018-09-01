<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master"  AutoEventWireup="true" CodeFile="DetailResult.aspx.cs" Inherits="DetailResult" Title="Detail Result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0" width="85%" border="1" ><tr><td align="center" >
            <div style="width: 95%">
                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                    <tr>
                        <td colspan="2"  style="height: 20px;">
                            <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 20px;">
       <table style="width: 100%; font-weight: bold;" class="tables" cellspacing="7px">
        <tr>
             <td style="text-align: center; color: #800000;">Your Exam Finished Get Result Details</td>
           
        </tr>
        
    </table>
        <asp:Button ID="btnback" runat="server" Text="Back" 
                  CssClass="btn" 
                    PostBackUrl="~/Admin/Timeover.aspx" onclick="btnback_Click" />
    <br />
    </td></tr></table></div>
    <div class="grid" style="width: 95%">
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
                                <div class="pager" style="text-align: left">
                        
                        <asp:GridView ID="GridView1" runat="server" CssClass="datatable"
                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                        AllowPaging="True"
                        OnPageIndexChanging="GridView1_PageIndexChanging1">
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
     </td></tr></table>

    <%--<asp:Panel ID="Panel1" runat="server" Style="left: 172px; position: absolute;
        top: 45px; background-color: gainsboro; height: 416px; width: 1400px;">
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <hr id="HR1" style="left: 0px; width: 705px; position: absolute; top: 1px; width: 1200px; height: 66px;
            background-color: cornsilk" onclick="return HR1_onclick()" />
        <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Detail Result" style="left: 271px; position: absolute; top: 18px"> Your Exam Finished Get Result Details : <%=Convert.ToString(Session["user"])%> </asp:Label>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" ConflictDetection="CompareAllValues"
            DataFile="~/App_Data/eZeeMHCET1.mdb" DeleteCommand="DELETE FROM [tblExamQuestion] WHERE [EQ_id] = ? AND [Question] = ? AND [Correct_ans] = ? AND [Submitted] = ? AND [Status] = ?"
            InsertCommand="INSERT INTO [tblExamQuestion] ([EQ_id], [Question], [Correct_ans], [Submitted], [Status]) VALUES (?, ?, ?, ?, ?)"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [EQ_id], [Question], [Correct_ans], [Submitted], [Status] FROM [tblExamQuestion]"
            UpdateCommand="UPDATE [tblExamQuestion] SET [Question] = ?, [Correct_ans] = ?, [Submitted] = ?, [Status] = ? WHERE [EQ_id] = ? AND [Question] = ? AND [Correct_ans] = ? AND [Submitted] = ? AND [Status] = ?">
            <DeleteParameters>
                <asp:Parameter Name="original_EQ_id" Type="Int32" />
                <asp:Parameter Name="original_Question" Type="String" />
                <asp:Parameter Name="original_Correct_ans" Type="String" />
                <asp:Parameter Name="original_Submitted" Type="String" />
                <asp:Parameter Name="original_Status" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Question" Type="String" />
                <asp:Parameter Name="Correct_ans" Type="String" />
                <asp:Parameter Name="Submitted" Type="String" />
                <asp:Parameter Name="Status" Type="Int32" />
                <asp:Parameter Name="original_EQ_id" Type="Int32" />
                <asp:Parameter Name="original_Question" Type="String" />
                <asp:Parameter Name="original_Correct_ans" Type="String" />
                <asp:Parameter Name="original_Submitted" Type="String" />
                <asp:Parameter Name="original_Status" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="EQ_id" Type="Int32" />
                <asp:Parameter Name="Question" Type="String" />
                <asp:Parameter Name="Correct_ans" Type="String" />
                <asp:Parameter Name="Submitted" Type="String" />
                <asp:Parameter Name="Status" Type="Int32" />
            </InsertParameters>
        </asp:AccessDataSource>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
            BorderStyle="Ridge" BorderWidth="1px" CellPadding="3" CellSpacing="1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
            Style="left: 2px; position: absolute; top: 70px" Width="1200px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging1">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        &nbsp; &nbsp;&nbsp; &nbsp;
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label></asp:Panel>--%>
</asp:Content>

