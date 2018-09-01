<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Heading.ascx.cs" Inherits="userControl_Heading" %>
<div id="td12">
    <table style="width: 70%;" cellspacing="1px">
        <%--for Heading class="divremovespace"--%>
        <tr>
            <td style="text-align: center;">
                <%--<div id="divOR" runat="server" class="displayDiv">
                </div>--%>
                <asp:LinkButton ID="lbOR" runat="server" class="hidewhileprinting" Text="Insert Blank Line"
                    OnClientClick="return add(this)" />
                <asp:LinkButton ID="lbORDel" runat="server" class="hidewhileprinting" Text="Delete Blank Line"
                    OnClientClick="return del(this)" />
                <asp:Label ID="lblOR" runat="server" Font-Size="Small" Text="OR" Font-Bold="true"
                    Width="575px" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: left;">
                <div id="divHeading" runat="server" class="displayDiv">
                </div>
                <asp:LinkButton ID="lbHeading" runat="server" class="hidewhileprinting" Text="Insert Blank Line"
                    OnClientClick="return add(this)" />
                <asp:LinkButton ID="lbHeadingDel" runat="server" class="hidewhileprinting" Text="Delete Blank Line"
                    OnClientClick="return del(this)" />

                <asp:Label ID="lblQNoHead" runat="server" Font-Bold="false" Font-Size="Medium" Text=""></asp:Label><%-- Text="Q.No.:"--%>
                <asp:Label ID="lblSubQNO" runat="server" Font-Size="Medium" Text=""></asp:Label>
                <asp:Label ID="lblHeading" runat="server" Font-Size="Small" Font-Bold="false" ForeColor="Black"
                    Width="550px"></asp:Label>
            </td>
            <td style="text-align: right;">
                <asp:Label ID="lblMarks" runat="server" Font-Size="Small" Font-Bold="false" Width="25px"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <div id="div2" runat="server" class="displayDiv">
                </div>
                <asp:LinkButton ID="lbHeading1" runat="server" class="hidewhileprinting" Text="Insert Blank Line"
                    OnClientClick="return add(this)" />
                <asp:LinkButton ID="lbHeadingDel1" runat="server" class="hidewhileprinting" Text="Delete Blank Line"
                    OnClientClick="return del(this)" />
                <asp:Label ID="lblHeading1" runat="server" Font-Size="Small" Width="575px"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMarks1" runat="server" Font-Size="Small" Width="25px"></asp:Label>
            </td>
        </tr>
    </table>
</div>
