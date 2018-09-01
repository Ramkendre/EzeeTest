<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout/AdminMaster.master"
    CodeFile="RSBhutadaNewPractice.aspx.cs" Inherits="SubAdmin_RSBhutadaNewPractice"
    Title="eZeeTest:RSBPractice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div align="center">
                <div style="border: solid 3px Black; width: 60%; height: 450px;">
                    <div align="center" style="font-family: Tahoma; font-weight: bold; font-size: medium;">
                        Practice For 12th Science
                    </div>
                    <hr />
                    <div style="float: left; margin-left: 150px;">
                        <asp:Label ID="lblInstruction" runat="server" Text="All Fields are Mandatory!!!"
                            ForeColor="Red"></asp:Label>
                    </div>
                    <br />
                    <br />
                    <div style="float: left; margin-left: 150px;">
                        <asp:Label ID="lblGroupofExam" runat="server" Text="Select Type of Exam" Font-Size="Medium"></asp:Label></div>
                    <div style="float: right; margin-right: 300px;">
                        <asp:DropDownList ID="ddlGroupofExam" runat="server" Width="200px" OnSelectedIndexChanged="ddlGroupofExam_SelectedIndexChanged"
                            AutoPostBack="true">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="141">Engineering Entrance</asp:ListItem>
                            <asp:ListItem Value="142">Medical Entrance</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0"
                            ErrorMessage="*" ControlToValidate="ddlGroupofExam"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <br />
                    <div style="float: left; margin-left: 150px;">
                        <asp:Label ID="lblTypeofExam" runat="server" Text="Select ExamName" Font-Size="Medium"></asp:Label></div>
                    <div style="float: right; margin-right: 300px;">
                        <asp:DropDownList ID="ddlTypeofExam" runat="server" Width="200px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlTypeofExam_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            InitialValue="1" ControlToValidate="ddlTypeofExam"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <br />
                    <div style="float: left; margin-left: 150px;">
                        <asp:Label ID="lblClassName" runat="server" Text="Select ClassName" Font-Size="Medium"></asp:Label></div>
                    <div style="float: right; margin-right: 300px;">
                        <asp:DropDownList ID="ddlClassName" runat="server" Width="200px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlClassName_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                            InitialValue="1" ControlToValidate="ddlClassName"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <br />
                    <div style="float: left; margin-left: 150px;">
                        <asp:Label ID="lblSubject" runat="server" Text="Select Subject" Font-Size="Medium"></asp:Label></div>
                    <div style="float: right; margin-right: 300px;">
                        <asp:DropDownList ID="ddlSubject" runat="server" Width="200px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                            InitialValue="1" ControlToValidate="ddlSubject"></asp:RequiredFieldValidator>
                        <%--<asp:CheckBoxList ID="chkSubject" runat="server" Font-Size="Medium">
                </asp:CheckBoxList> class="container"--%>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div style="float: left; margin-left: 150px;">
                        <asp:Label ID="lblChapterName" runat="server" Text="Select Chapter" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="container" style="float: right; margin-right: 300px;">
                        <asp:CheckBox ID="ChkSelectALL" runat="server" OnClick="check(this)" Text="Select ALL Chapter"
                            Visible="false" />
                        <asp:CheckBoxList ID="ddlChapter" runat="server" RepeatColumns="1" BorderWidth="0px"
                            Datafield="description" DataValueField="value">
                        </asp:CheckBoxList>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <div align="center">
                        <asp:Button ID="btnFindQuestions" runat="server" CssClass="btn" Text="Find Questions"
                            OnClick="btnFindQuestions_Click" />
                        <asp:Button ID="btnBack" runat="server" CssClass="btn" Text="Back" PostBackUrl="~/Admin/Home.aspx"
                            CausesValidation="false" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
