<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true" CodeFile="AddQuestionExam.aspx.cs" Inherits="Admin_AddQuestionExam" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <style type="text/css">
        .protected
        {
            -moz-user-select: none;
            -webkit-user-select: none;
            user-select: none;
        }
           .style2
           {
               width: 103px;
           }
    </style>

    <script language="javascript" type="text/javascript">
        function disableselect(e) {
            return false
        }
        function reEnable() {
            return true
        }
        document.onselectstart = new Function("return false")
        if (window.sidebar) {
            document.onmousedown = disableselect                    // for mozilla           
            document.onclick = reEnable
        }
        function clickIE() {
            if (document.all) {
                (message);
                return false;
            }
        }
        document.oncontextmenu = new Function("return false")
        var element = document.getElementById('tbl');
        element.onmousedown = function() { return false; }        // For Mozilla Browser
    </script>
    <asp:MultiView ID="MultiView1" runat="server">
       
         
        <asp:View ID="View1" runat="server">
         <div style="width: 95%; color: #000000;">
             <table cellpadding="0" cellspacing="0" width="90%" >
                    <tr>
                        <%--<td align="center">--%>
                            <div style="width: 100%">
                          <table cellpadding="0" cellspacing="0" width="95%" class="tables" border="1">
                                  <tr>
                                    <td class="error">
                                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                    </td>
                                </tr>
                                
                                
                                
                                      <tr>
                                    <td style="height: 20px;">
                                        <table style="width: 93%; font-family: 'Times New Roman', Times, serif; font-size: medium;"
                                            class="tables" cellspacing="7px">
                                            <tr>
                                               <%-- <td style="text-align: center; width: 103px;">
                                                </td>--%>
                                                <td style="text-align: center;" colspan="3" align="center" style="text-align: left;
                                                    font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                   <%-- <b style="font-size: x-large">Sample Test </b>
                                                    --%>
                                                    <%--<div class="graybox">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>--%>

                                                    <h2 style="color:Green; text-align: center;">Select Question for Exam</h2>
                                                    
                                                </td>
                                            </tr>
                                            
                                            
                                             
                                         
                                               <tr>
                                        
                                                   <td style="width: 628px; text-align: right;">
                                                       <asp:Label ID="lblTypeofMaterial" runat="server" Font-Bold="False" 
                                                           Font-Names="Arial" Font-Size="11pt" Text="Select Type of Material"></asp:Label>
                                                       <span class="warning1" style="color: Red;">*&nbsp;</span></td>
                                                   <td style="height: 31px; width: 200px;">
                                                       <asp:RadioButtonList ID="rdoTypeofMaterial" runat="server" AutoPostBack="True" 
                                                           CssClass="radio" Font-Size="Medium" 
                                                           onselectedindexchanged="rdoTypeofMaterial_SelectedIndexChanged" 
                                                           RepeatDirection="Horizontal" Width="203px">
                                                           <asp:ListItem Value="0">Class</asp:ListItem>
                                                           <asp:ListItem Value="1">Competitive Exam</asp:ListItem>
                                                       </asp:RadioButtonList>
                                                   </td>
                                                   <td class="error" style="height: 29px">
                                                       &nbsp;
                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                           ControlToValidate="rdoTypeofMaterial" 
                                                           ErrorMessage="You have not selected Type of Material" Font-Size="Small" 
                                                           SetFocusOnError="True" ValidationGroup="other" Width="225px"></asp:RequiredFieldValidator>
                                                   </td>
                                        
                                    </tr>
                                              
                                           <tr>
                            <td style="width: 628px; text-align: right;">
                                <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                    Text="Select Type of Exam"></asp:Label>
                                            &nbsp;<asp:Label ID="Label10" runat="server" Font-Bold="False" 
                                    Font-Names="Arial" Font-Size="14pt"
                                                Text="*" ForeColor="Red" Visible="False"></asp:Label></td>
                            <td style="width: 100px; height: 31px;" >
                                <asp:DropDownList ID="ddlTypeofExam" runat="server" CssClass="ddlcsswidth "
                                    Height="22px">
                                   
                                </asp:DropDownList>
                                <br />
                            </td>
                            <td class="error" style="height: 29px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                    ControlToValidate="ddlTypeofExam" InitialValue="1"
                                    ErrorMessage="You have not selected Type of Exam" SetFocusOnError="True" Width="225px"
                                    ValidationGroup="other" Enabled="False" Font-Size="Small"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                                        <tr>
                                        <td style="width: 628px; text-align: right;">
                                            <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Class Name"></asp:Label>
                                            <asp:Label ID="Label11" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="14pt"
                                                Text="*" ForeColor="Red" Visible="False"></asp:Label>
                                            &nbsp;</td>
                                        <td style="height: 31px; width: 200px;">
                                            <asp:DropDownList ID="ddlAddClass" runat="server" CssClass="ddlcsswidth "
                                               >
                                            </asp:DropDownList>
                                            <br />
                                        </td>
                                      <td class="error" style="height: 29px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                    ControlToValidate="ddlAddClass" InitialValue="1"
                                    ErrorMessage="You have not selected Class" SetFocusOnError="True" Width="225px"
                                    ValidationGroup="other" Enabled="False" Font-Size="Small"></asp:RequiredFieldValidator>
                            </td>
                                    </tr>

                                            <tr>
                                        <td style="width: 628px; text-align: right;">
                                            <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Subject" Width="100px"></asp:Label>
                                            <span class="warning1" style="color: Red;">*</span>&nbsp;
                                        </td>
                                        <td style="height: 31px; width: 200px;">
                                            <asp:DropDownList ID="cmbSelectsubject" runat="server" CssClass="ddlcsswidth "
                                               >
                                            </asp:DropDownList>
                                            <br />
                                        </td>
                                        <td class="error" style="height: 29px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbSelectsubject"
                                                ErrorMessage="You have not selected Subject" SetFocusOnError="True" Width="225px"
                                                ValidationGroup="other" InitialValue="1" Font-Size="Small" Enabled="True"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td style="width: 628px; text-align: right;" width="500px">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"
                                                Text="Select Chapter" Width="150px"></asp:Label>
                                            &nbsp;
                                        </td>
                                        <td style="height: 31px; width: 200px;">
                                            <asp:DropDownList ID="ddlChapter" runat="server" CssClass="ddlcsswidth "
                                                >
                                            </asp:DropDownList>
                                            <br />
                                        </td>
                                        <td class="error" style="height: 29px">
                                            &nbsp;</td>
                                       
                                    </tr>
                                             <tr>
                                        
                                                   <td style="width: 628px; text-align: right;">
                                                       <asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Names="Arial" 
                                                           Font-Size="11pt" Text="Select Level of Question " Width="100px"></asp:Label>
                                                   </td>
                                                   <td style="height: 31px; width: 200px;">
                                                       <asp:RadioButtonList ID="rdoLevelList1" runat="server" Font-Names="Arial" 
                                                           Font-Size="Small" RepeatDirection="Horizontal" ToolTip="Click to select level">
                                                           <asp:ListItem Value="1">Level1</asp:ListItem>
                                                           <asp:ListItem Value="2">Level2</asp:ListItem>
                                                           <asp:ListItem Value="3">Level3</asp:ListItem>
                                                       </asp:RadioButtonList>
                                                   </td>
                                                   <td class="error" style="height: 29px">
                                                       &nbsp;
                                                       </td>
                                        
                                    </tr>
                                            <tr>
                                                <td class="style2">
                                                    &nbsp; </td>
                                                <td style="text-align: left" colspan="2">
                                                    &nbsp;<asp:Button ID="btnStart" runat="server" CssClass="btn" 
                                                        OnClick="btnStart_Click1" Text="Find Question" 
                                                        ToolTip="Click here to start the test" ValidationGroup="other" />
                                                    &nbsp;
                                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn" 
                                                        PostBackUrl="~/html/UserHome.aspx" Text="Cancel" 
                                                        ToolTip="Click here to Cancel" ValidationGroup="other" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    </td>
                                                <td class="error">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: left">
                                                </td>
                                                <td class="error">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                     </td>
                                        </tr>
                                </table>
                </table>
                 </div>
        </asp:View>
     
        
        <asp:View ID="View2" runat="server">
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="70%" bgcolor="White" >
                <div style="width: 80%">
                    <table style="width: 91%"  cellspacing="7px" bgcolor="White">
                        <tr bgcolor="#FFFFCC">
                            <td colspan="2" align="left">
                                <asp:Label ID="lblqn" runat="server" Font-Size="Large" Text="Q.No. :" 
                                    ForeColor="#00CC00" Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblQNo" runat="server" Font-Size="Large" Text="Q" 
                                    ForeColor="#00CC00" Font-Bold="True"></asp:Label>
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:Label ID="lblQuestion_id" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    ForeColor="#009933" Text="Question_id" Visible="False"></asp:Label>
                            </td>
                            <td colspan="3" style="width: 84px; text-align: left;">
                                <asp:Label ID="lbltypeQues" runat="server" Font-Size="Medium" 
                                    Text="Type of Ques" ForeColor="#CC3300" Font-Bold="True"></asp:Label>
                                &nbsp;</td>
                            <td align="left">
                             <asp:Label ID="lblcount" runat="server" Font-Size="Medium" 
                                    Text="count" ForeColor="#009933" Font-Bold="True"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblSno" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    ForeColor="#009933" Text="SNO" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px">
                                <asp:Label ID="lblpassage1" runat="server" Text="Passage" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:Label ID="lblPassage" runat="server" Font-Size="Medium" Text="Passage"></asp:Label>
                                <asp:Image ID="imgPassage" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px">
                                <asp:Label ID="lblQues" runat="server" Text="Question" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:Label ID="lblQuestion" runat="server" Font-Size="Medium" Text="Question"></asp:Label>
                                <asp:Image ID="imgQues" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px">
                                <asp:Label ID="QuestionImage" runat="server" Text="QuestionImage" Font-Size="Large"
                                    ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:Label ID="lblQuestionwithImage" runat="server" Font-Size="Medium" Text="QuestionwithImage"></asp:Label>
                                <asp:Image ID="imgQuesImage" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblA" runat="server" Text="A" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptA" runat="server" Font-Size="Medium" Text="OptionA"></asp:Label>
                                <asp:Image ID="imgoptA" runat="server" />
                            </td>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblP" runat="server" Text="P" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptP" runat="server" Font-Size="Medium" Text="OptionP"></asp:Label>
                                <asp:Image ID="imgoptP" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblB" runat="server" Text="B" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptB" runat="server" Font-Size="Medium" Text="OptionB"></asp:Label>
                                <asp:Image ID="imgoptB" runat="server" />
                            </td>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblQ" runat="server" Text="Q" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptQ" runat="server" Font-Size="Medium" Text="OptionQ"></asp:Label>
                                <asp:Image ID="imgoptQ" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblC" runat="server" Text="C" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptC" runat="server" Font-Size="Medium" Text="OptionC"></asp:Label>
                                <asp:Image ID="imgoptC" runat="server" />
                            </td>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblR" runat="server" Text="R" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptR" runat="server" Font-Size="Medium" Text="OptionR"></asp:Label>
                                <asp:Image ID="imgoptR" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblD" runat="server" Text="D" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptD" runat="server" Font-Size="Medium" Text="OptionD"></asp:Label>
                                <asp:Image ID="imgoptD" runat="server" />
                            </td>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblS" runat="server" Text="S" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptS" runat="server" Font-Size="Medium" Text="OptionS"></asp:Label>
                                <asp:Image ID="imgoptS" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblE" runat="server" Text="E" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptE" runat="server" Font-Size="Medium" Text="OptionE"></asp:Label>
                                <asp:Image ID="imgoptE" runat="server" />
                            </td>
                             <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblT" runat="server" Text="T" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px">
                                <asp:Label ID="lblOptT" runat="server" Font-Size="Medium" Text="OptionT"></asp:Label>
                                <asp:Image ID="imgoptT" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lblH" runat="server" Text="Hint" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                                <br />
                                <asp:DropDownList ID="ddlhint" runat="server" 
                                    OnSelectedIndexChanged="ddlhint_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Value="0">English</asp:ListItem>
                                    <asp:ListItem Value="1">Marathi</asp:ListItem>
                                   <%-- <asp:ListItem Value="2">Image</asp:ListItem>--%>
                                </asp:DropDownList>
                            </td>
                            <td colspan="4" align="left">
                                <asp:TextBox ID="txtHint" runat="server" Height="32px" TextMode="MultiLine" 
                                    Width="300px"></asp:TextBox>
                                <asp:Image ID="imgHint" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center;" bgcolor="White">
                                <asp:Label ID="lblAns" runat="server" Text="Answer" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:RadioButtonList ID="rdoAnswerlist" runat="server" Font-Size="Medium" RepeatDirection="Horizontal"
                                    Visible="False">
                                    <asp:ListItem Value="0">A</asp:ListItem>
                                    <asp:ListItem Value="1">B</asp:ListItem>
                                    <asp:ListItem Value="2">C</asp:ListItem>
                                    <asp:ListItem Value="3">D</asp:ListItem>
                                    <asp:ListItem Value="4">E</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:TextBox ID="txtAns" runat="server" MaxLength="15" Visible="False" Width="158px"></asp:TextBox>
                                <asp:CheckBoxList ID="chkAnslist" runat="server" Font-Size="Medium" RepeatDirection="Horizontal"
                                    Visible="False" onselectedindexchanged="chkAnslist_SelectedIndexChanged">
                                    <asp:ListItem Value="0">A</asp:ListItem>
                                    <asp:ListItem Value="1">B</asp:ListItem>
                                    <asp:ListItem Value="2">C</asp:ListItem>
                                    <asp:ListItem Value="3">D</asp:ListItem>
                                    <asp:ListItem Value="4">E</asp:ListItem>
                                </asp:CheckBoxList>
                                <asp:Panel ID="pnlAnsMat" runat="server" Visible="False" Height="110px" 
                                    Width="305px">
                                    <table>
                                    <tr>
                                         <td style="font-size: medium" >A-</td>
                                        <td style="width: 300px; text-align: center;">
                                       <asp:CheckBoxList ID="ChkansMatA" runat="server" Font-Size="Medium" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0">P</asp:ListItem>
                                        <asp:ListItem Value="1">Q</asp:ListItem>
                                        <asp:ListItem Value="2">R</asp:ListItem>
                                        <asp:ListItem Value="3">S</asp:ListItem>
                                         <asp:ListItem Value="4">T</asp:ListItem>
                                    </asp:CheckBoxList>
                                        </td>
                                        </tr>
                                        
                                        <tr>
                                        <td style="font-size: medium" bgcolor="White">B-</td>
                                         <td style="width: 300px; text-align: center;">
                                         <asp:CheckBoxList ID="ChkansMatB" runat="server" Font-Size="Medium" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0">P</asp:ListItem>
                                        <asp:ListItem Value="1">Q</asp:ListItem>
                                        <asp:ListItem Value="2">R</asp:ListItem>
                                        <asp:ListItem Value="3">S</asp:ListItem>
                                        <asp:ListItem Value="4">T</asp:ListItem>
                                    </asp:CheckBoxList>
                                        
                                        </td>
                                        </tr>
                                        <tr>
                                         <td style="font-size: medium">C-</td>
                                         <td style="width: 300px; text-align: center;">
                                        <asp:CheckBoxList ID="ChkansMatC" runat="server" Font-Size="Medium" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0">P</asp:ListItem>
                                        <asp:ListItem Value="1">Q</asp:ListItem>
                                        <asp:ListItem Value="2">R</asp:ListItem>
                                        <asp:ListItem Value="3">S</asp:ListItem>
                                        <asp:ListItem Value="4">T</asp:ListItem>
                                    </asp:CheckBoxList>
                                        </td>
                                        </tr>
                                        <tr>
                                         <td style="font-size: medium">D-</td>
                                         <td style="width: 300px; text-align: center;">
                                         <asp:CheckBoxList ID="ChkansMatD" runat="server" Font-Size="Medium" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0">P</asp:ListItem>
                                        <asp:ListItem Value="1">Q</asp:ListItem>
                                        <asp:ListItem Value="2">R</asp:ListItem>
                                        <asp:ListItem Value="3">S</asp:ListItem>
                                        <asp:ListItem Value="4">T</asp:ListItem>
                                    </asp:CheckBoxList>
                                        </td>
                                        </tr>
                                    </table>
                               </asp:Panel>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px; text-align: center;">
                                <asp:Label ID="lbllevel" runat="server" Font-Size="Large" ForeColor="#CC3300" Text="Level"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:RadioButtonList ID="rdoLevelList" runat="server" Font-Names="Arial" Font-Size="Small"
                                    RepeatDirection="Horizontal" ToolTip="Click to select level">
                                    <asp:ListItem Value="1">Level1</asp:ListItem>
                                    <asp:ListItem Value="2">Level2</asp:ListItem>
                                    <asp:ListItem Value="3">Level3</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            
                             <tr>
                            <td style="width: 84px; text-align: center; height: 29px;">
                                <asp:Label ID="lblQuesVerify" runat="server" Font-Size="Large" 
                                    ForeColor="#CC3300" Text="Question Verify ?" Visible="False"></asp:Label>
                            </td>
                            <td colspan="2" align="left" style="width: 300px; height: 29px;">
                                <asp:RadioButtonList ID="rdoQuesVerify" runat="server" Font-Size="Medium" 
                                    RepeatDirection="Horizontal" Visible="False">
                                    <asp:ListItem Value="0">Correct</asp:ListItem>
                                    <asp:ListItem Value="1">InCorrect</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="width: 84px; text-align: center; height: 29px;">
                                &nbsp;</td>
                            <td colspan="2" align="left" style="width: 300px; height: 29px;">
                                <asp:CheckBox ID="chkAddQuestion" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="chkAddQuestion_CheckedChanged" Text="Add Question " 
                                    BackColor="White" Font-Bold="True" Font-Italic="True" 
                                    Font-Names="Times New Roman" Font-Overline="False" Font-Underline="False" 
                                    ForeColor="Red" />
                            </td>
                        </tr>
                            
                            
                            
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtAnsMatA" runat="server" Visible="False" Width="39px"></asp:TextBox>
                                    <asp:TextBox ID="txtAnsMatB" runat="server" Visible="False" Width="39px"></asp:TextBox>
                                    <asp:TextBox ID="txtAnsMatC" runat="server" Visible="False" Width="39px"></asp:TextBox>
                                    <asp:TextBox ID="txtAnsMatD" runat="server" Visible="False" Width="39px"></asp:TextBox>
                                </td>
                                <td colspan="4" style="text-align: center">
                                    <asp:Button ID="btnBack" runat="server" Height="39px" OnClick="btnBack_Click" 
                                        Text="Back" Width="71px" />
                                    &nbsp;<asp:Button ID="btnUpdate" runat="server" Height="39px" 
                                        Text="Update" onclick="btnUpdate_Click" Width="74px" Visible="False" />
                                    &nbsp;<asp:Button ID="btnNext" runat="server" Height="39px" OnClick="btnNext_Click"
                                        Text="Next" Width="71px" />
                                    &nbsp;<asp:Button ID="btnSubmit" runat="server" Height="39px" 
                                        Text="Submit" Width="71px" onclick="btnSubmit_Click" />
                                </td>
                                <td>
                                  
                                  
                                  
                                  
                                    <asp:TextBox ID="txtSuggest" runat="server" Height="32px" TextMode="MultiLine" 
                                        Visible="False" Width="233px"></asp:TextBox>
                                  
                                  
                                  
                                  
                                    <br />
                                </td>
                            </tr>
                        </tr>
                    </table>
                </div>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
        </asp:View>
        
        
         </asp:MultiView>
  



</asp:Content>

