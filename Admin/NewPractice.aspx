<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true"
    CodeFile="NewPractice.aspx.cs" Inherits="Admin_NewPractice" Title="eZeeTest:Practice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .submit
        {
            border: 1px solid #563d7c;
            border-radius: 5px;
            color: white;
            padding: 5px 10px 5px 25px;
            background-image: url(https://cdn.sstatic.net/stackoverflow/img/sprites.png?v=6);
            background-position-y: 465px;
            background-position-x: 5px;
            background-color: #563d7c;
        }
    </style>
    <%--****************************************--%>

    <script language="javascript" type="text/javascript">
        function setTimeForSubmit() {
            window.setTimeout("submitForm()", 1500000); //Expire after 25 min
        }
        function submitForm() {
            document.forma.submit();
        }

        function check(checkbox) {
            var cbl = document.getElementById('<%=ddlChapter.ClientID %>').getElementsByTagName("input");
            for (i = 0; i < cbl.length; i++)
                cbl[i].checked = checkbox.checked;
        }
        
        
    </script>

    <script language="javascript" type="text/javascript">

        var mins = 25; // write mins to javascript  
        var secs = 1; // write secs to javascript  
        function timer() {
            // tic tac  
            if (--secs == -1) {
                secs = 59;
                --mins;
            }

            // leading zero? formatting  
            if (secs < 10)
                secs = "0" + secs;
            if (mins < 10)
                mins = "0" + parseInt(mins, 10);

            // display  
            document.forma.mins.value = mins;
            document.forma.secs.value = secs;

            // continue?  
            if (secs == 0 && mins == 0) // time over  
            {
                document.forma.ok.disabled = true;
                document.formb.results.style.display = "block";
            }
            else // call timer() recursively every 1000 ms == 1 sec  
            {
                window.setTimeout("timer()", 1000);
            }
        }
            
    </script>

    <script language="javascript" type="text/javascript">
        window.history.forward();
        function noBack() {
            window.history.forward();
        }
    </script>

    <%--***********************************--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 100%;" align="center">
                <table cellpadding="0" cellspacing="0" width="65%" class="tables" border="1">
                    <tr>
                        <td>
                            <center>
                                <table style="width: 55%" class="tables" width="160">
                                    <tr>
                                        <td colspan="3" style="text-align: center">
                                            <h3 style="color: Green; font-size: x-large">
                                                Practice&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: text-top;">
                                            <asp:Label ID="lblTypeofMaterial" runat="server" Font-Bold="False" Font-Names="Arial"
                                                Font-Size="11pt" Text="Select Type of Material"></asp:Label>
                                            <span class="warning1" style="color: Red;">*</span>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rdoTypeofMaterial" runat="server" CssClass="radio" Font-Size="Medium"
                                                RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rdoTypeofMaterial_SelectedIndexChanged">
                                                <asp:ListItem Value="0">Class</asp:ListItem>
                                                <asp:ListItem Value="1">Competitive Exam</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="rdoTypeofMaterial"
                                                ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                Font-Size="Small"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <%--new row added--%>
                                    <tr>
                                        <td style="vertical-align: text-top;">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Type of Exam"></asp:Label>
                                            <span class="warning1" style="color: Red;">*</span>&nbsp;
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlGroupofExam" runat="server" CssClass="ddlcsswidth " AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlGroupofExam_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlGroupofExam"
                                                InitialValue="1" ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                Enabled="False" Font-Size="Small"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <%--new row added--%>
                                    <tr>
                                        <td style="vertical-align: text-top;">
                                            <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select ExamName"></asp:Label>
                                            <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="14pt"
                                                Text="*" ForeColor="Red" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTypeofExam" runat="server" CssClass="ddlcsswidth " AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlTypeofExam_SelectedIndexChanged">
                                                <asp:ListItem Value="1">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlTypeofExam"
                                                InitialValue="1" ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                Enabled="False" Font-Size="Small"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: text-top;">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Class Name"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="14pt"
                                                Text="*" ForeColor="Red" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlAddClass" runat="server" CssClass="ddlcsswidth " AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlAddClass_SelectedIndexChanged">
                                                <asp:ListItem Value="1">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlAddClass"
                                                InitialValue="1" ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                Enabled="False" Font-Size="Small"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: middle;">
                                            <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Subject" Width="100px"></asp:Label>
                                            <span class="warning1" style="color: Red;">*</span>&nbsp;
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="cmbSelectsubject" runat="server" CssClass="ddlcsswidth " OnSelectedIndexChanged="cmbSelectsubject_SelectedIndexChanged">
                                                <asp:ListItem Value="1">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <br />
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbSelectsubject"
                                                Enabled="True" ErrorMessage="You have not selected Subject" Font-Size="Small"
                                                InitialValue="--Select--" SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMedium" runat="server" Font-Bold="false" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Medium" Width="170px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="true" CssClass="ddlcsswidth "
                                                OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">English</asp:ListItem>
                                                <asp:ListItem Value="2">Semi-English</asp:ListItem>
                                                <asp:ListItem Value="3">Marathi</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblChaptername" runat="server" Font-Bold="false" Font-Names="Arial" Font-Size="11pt" 
                                                Text="Select Chapter" Width="170px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTopik" runat="server" AutoPostBack="true" CssClass="ddlcsswidth" OnSelectedIndexChanged="ddlTopik_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTopik"
                                                InitialValue="1" ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                Enabled="False" Font-Size="Small"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td height="10px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Topic" Width="150px" Height="17px"></asp:Label>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <div class="container">
                                                <asp:CheckBox ID="ChkSelectALL" runat="server" OnClick="check(this)" Text="Select ALL Topic"
                                                    Visible="false" />
                                                <asp:CheckBoxList ID="ddlChapter" runat="server" RepeatColumns="1" BorderWidth="0px"
                                                    Datafield="description" DataValueField="value" OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged">
                                                </asp:CheckBoxList>
                                            </div>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Level of Question " Width="162px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rdoLevelList1" runat="server" Font-Names="Arial" Font-Size="Small"
                                                RepeatDirection="Horizontal" ToolTip="Click to select level" OnSelectedIndexChanged="rdoLevelList1_SelectedIndexChanged">
                                                <asp:ListItem Value="1">Level1</asp:ListItem>
                                                <asp:ListItem Value="2">Level2</asp:ListItem>
                                                <asp:ListItem Value="3">Level3</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td colspan="2">
                                            &nbsp;<asp:Button ID="btnStart" runat="server" CssClass="btn" OnClick="btnStart_Click1"
                                                Text="Find Question" ToolTip="Click here to start the test" ValidationGroup="other" />
                                            &nbsp;
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn" CausesValidation="false"
                                                Text="Cancel" ToolTip="Click here to Cancel" ValidationGroup="other" OnClick="btnCancel_Click1" />
                                            &nbsp;&nbsp;<asp:LinkButton ID="btnarchive" runat="server" Visible="false" Text="Get BackUp Selected Test."
                                                ToolTip="Click Here to Trasfer Archive." Font-Size="Small" />
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
</asp:Content>
