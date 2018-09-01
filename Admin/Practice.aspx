<%@ Page Language="C#" MasterPageFile="~/Layout/AdminMaster.master" AutoEventWireup="true" CodeFile="Practice.aspx.cs" Inherits="Practice" Title="Practice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table cellpadding="0" cellspacing="0" width="70%" border="1" ><tr><td align="center" >
            <div style="width: 100%">
                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                    <tr>
                        <td colspan="2"  style="height: 20px;">
                            <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 20px;">
       <table style="width: 80%; font-family: 'Times New Roman', Times, serif; font-size: medium;" 
                                class="tables" cellspacing="7px">
        <tr>
             <td style="text-align: center; width: 103px;"></td>
            <td style="text-align: center; colspan="4" align="center" 
                 
                 style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                    <b style="font-size: x-large">Practice
            </b>
            </td>
        </tr>
         <tr>
            <td align="center" colspan="3" style="text-align: left" >
                &nbsp;&nbsp;<span style="font-size: medium"><asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Label"></asp:Label><asp:Label ID="lblSuccess" runat="server"  Visible="False"  CssClass="error" ></asp:Label></span><br />
                <span style="font-size: medium">
                <asp:Label ID="Label1" runat="server" CssClass="error" ></asp:Label>
                
                
                </span>
                
                
                </td>
        </tr>
      <tr>
        <td style="width: 103px; text-align: center;">
                  
                  &nbsp;Language</td>
                          
            <td align="center" colspan="5" style="text-align: left" >
                <asp:DropDownList ID="cmbSelectlang" runat="server" ToolTip="Click to select language"
                    Width="140px" 
            OnSelectedIndexChanged="cmbSelectlang_SelectedIndexChanged" AutoPostBack="True">
                     <asp:ListItem>English</asp:ListItem>
                    <asp:ListItem>Hindi</asp:ListItem>
                    <asp:ListItem>Marathi</asp:ListItem>
                   
                     <asp:ListItem></asp:ListItem>
                   
                </asp:DropDownList>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  </td>
           </tr> 
                                   
           <tr>
           
               <td style="width: 103px; text-align: center;">
                   Subject
               </td>
               <td style="text-align: left" colspan="3">
        <asp:DropDownList ID="cmbSelectSub" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbSelectsub_SelectedIndexChanged"
           >
        </asp:DropDownList>
        
        
               </td>
               <td class="error">
                   &nbsp;&nbsp;</td>
           </tr>
           <tr>
               <td style="width: 103px; text-align: center;">
                   &nbsp;Chapter
               </td>
               <td style="text-align: left">
                <asp:ListBox ID="lstboxSeltopic" runat="server" BackColor="Transparent"  Height="62px" 
            OnSelectedIndexChanged="lstboxSeltopic_SelectedIndexChanged" 
            AutoPostBack="True" SelectionMode="Multiple" Width="172px"></asp:ListBox>
                </td>
               <td style="text-align: left">
                &nbsp;&nbsp;Select&nbsp; Level :<br />
                   <asp:RadioButtonList ID="rdoLevelList" runat="server" 
            ToolTip="Click to select level" 
            OnSelectedIndexChanged="rdoLevelList_SelectedIndexChanged" 
            AutoPostBack="True" 
            Font-Names="Arial" Font-Size="Small" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Level1" Selected="True">Level1</asp:ListItem>
                    <asp:ListItem Value="Level2">Level2</asp:ListItem>
                    <asp:ListItem Value="Level3">Level3</asp:ListItem>
                </asp:RadioButtonList>
                </td>
                
           </tr>
        
        <tr>
            <td style="width: 103px" >
                &nbsp;</td>
            <td style="text-align: left" colspan="3" >
                   &nbsp;<asp:Button ID="btnStart" runat="server"  CssClass="btn" 
            Text="Start Test" ToolTip="Click here to start the test" 
           OnClick="btnStart_Click1"  />
                                                                &nbsp;
                <asp:Button ID="btnCancel" runat="server"  CssClass="btn"  
                    OnClick="btnExit_Click" Text="Cancel" ToolTip="Click here to Cancel" 
                    ValidationGroup="other" PostBackUrl="~/html/Home.aspx"  />
                
                <asp:Label ID="lblCans" runat="server" ></asp:Label>
                                                                </td>
            <td class="error">
                &nbsp;
                                
                 
            </td>
       
       
            
            <td style="text-align: left" >
        
                                                                </td>
            <td class="error">
                &nbsp;
                                
                 
            </td>
        </tr>
        
        <tr>
            <td style="height: 28px; width: 103px; text-align: center;" >
                  <asp:Label ID="lblQuestion" runat="server" Text="Question  :" Width="95px" 
                      Font-Bold="True" ></asp:Label>
                   </td>
            <td style="text-align: left; height: 28px;" colspan="3" >
                   <asp:Label ID="lblQue" runat="server" Width="573px" 
                       style="font-size: medium; font-weight: 700; color: #800000" ></asp:Label>
             </td>
            <td class="error" style="height: 28px">
                &nbsp;
                                
                 
            </td>
        </tr>
        
        <tr>
        <td style="width: 103px"></td>
        <td>
               <asp:Image ID="ImgSfeed" runat="server" Height="77px" Width="135px"  />
        </td>
           
            
            
        </tr>
        
        
        <tr>
            <td style="width: 103px; text-align: center;" >
                   <asp:Label ID="lblAnswer" runat="server" Text="Answer " ></asp:Label></td>
            <td style="text-align: left" colspan="3" >
        <asp:RadioButtonList ID="rdoAnswerlist" runat="server" 
            ToolTip="Click to select answer" 
          
            CellSpacing="4" OnSelectedIndexChanged="rdoAnswerlist_SelectedIndexChanged" 
             EnableTheming="True" 
                    style="font-family: 'Times New Roman', Times, serif" Height="28px" 
                     Width="477px" RepeatDirection="Horizontal">
                    <asp:ListItem>Answer1</asp:ListItem>
                    <asp:ListItem>Answer2</asp:ListItem>
                    <asp:ListItem>Answer3</asp:ListItem>
                    <asp:ListItem>Answer4</asp:ListItem>
                </asp:RadioButtonList>
                   <br />
                   </td>
            <td class="error">
                &nbsp;
                                
                 
            </td>
        </tr>
             <tr>
            <td style="width: 103px" >
                   <asp:LinkButton ID="AnswerHint" runat="server" onclick="AnswerHint_Click">Hint</asp:LinkButton>
                 </td>
            <td style="text-align: left" colspan="3" >
                
                   <asp:Label ID="txtQhint" runat="server" Width="573px" 
                       style="font-size: medium; color: #800000" ></asp:Label>
        
                   <br />
                   </td>
            <td class="error">
                &nbsp;
                                
                 
            </td>
        </tr>
        <tr>
          <td style="width: 103px"></td>
          
            <td colspan="4" align="center" style="text-align: left">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" ValidationGroup="vgpStateSubmit"
                   OnClick="btnSubmit_Click"    ToolTip="Click here to submit" />
                &nbsp;<asp:Button ID="btnPrevious"  CssClass="btn"  runat="server" 
                       OnClick="btnPrevious_Click" Text="Prev" />
                     &nbsp;<asp:Label ID="txtGoto" runat="server" ForeColor="#006600" 
                       style="font-weight: 700" Width="30px" ></asp:Label>
                       <asp:Button                    
                       ID="btnNext"  CssClass="btn" 
            runat="server" Text="Next" 
            ToolTip="Click here to go to next question" OnClick="btnNext_Click"/>
                   &nbsp;&nbsp;<asp:Label ID="TxtCount" runat="server" ForeColor="#006600" 
                       style="font-weight: 700" Width="31px" ></asp:Label>&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnExit" runat="server"  CssClass="btn"  
                    OnClick="btnExit_Click" Text="Exit" ToolTip="Click here to exit" 
                    ValidationGroup="other" PostBackUrl="~/User/Home.aspx"  />
            &nbsp;&nbsp;
                <asp:Label ID="lblQues_id" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    </td></tr></table></div>
    
     </td></tr></table>
          
    <%--<asp:Panel ID="Panel1" runat="server" Height="520px" Width="1400px" style="left: 175px; position: absolute; top: 40px; border-right: gainsboro 1px ridge; border-top: gainsboro 1px ridge; border-left: gainsboro 1px ridge; border-bottom: gainsboro 1px ridge;" BackColor="Gainsboro">
        <asp:Panel ID="Panel2" runat="server" BackColor="Cornsilk" Height="50px" Width="1400px">
            <br />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Label ID="tblPractice" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Practice" style="left: 336px; top: 13px; position: absolute;" ForeColor="MidnightBlue"></asp:Label></asp:Panel>
        <br />
                <asp:Label ID="lblSelectlang" runat="server" Text='Select Language :<sup><Font Color="Red">*</Font Color></sup>' style="left: 380px; position: absolute; top: 59px" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"></asp:Label><asp:DropDownList ID="cmbSelectlang" runat="server" ToolTip="Click to select language"
                    Width="140px" style="left: 510px; position: absolute; top: 59px" OnSelectedIndexChanged="cmbSelectlang_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>English</asp:ListItem>
                    <asp:ListItem>Hindi</asp:ListItem>
                    <asp:ListItem>Marathi</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbSelectlang"
                    ErrorMessage="Language not selected" Width="142px" style="left: 675px; position: absolute; top: 60px" SetFocusOnError="True"></asp:RequiredFieldValidator><asp:Label ID="lblSelectlevel" runat="server" Text='Select Level :<sup><Font Color="Red">*</Font Color></sup>' style="left: 380px; position: absolute; top: 88px" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"></asp:Label><asp:RadioButtonList ID="rdoLevelList" runat="server" ToolTip="Click to select level" OnSelectedIndexChanged="rdoLevelList_SelectedIndexChanged" style="left: 510px; position: absolute; top: 88px" AutoPostBack="True" Font-Names="Arial" Font-Size="Small">
                    <asp:ListItem Value="Level1" Selected="True">Level1</asp:ListItem>
                    <asp:ListItem Value="Level2">Level2</asp:ListItem>
                    <asp:ListItem Value="Level3">Level3</asp:ListItem>
                </asp:RadioButtonList>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="lstboxSeltopic"
                    ErrorMessage="Topic not selected" Width="131px" style="left: 681px; position: absolute; top: 97px" SetFocusOnError="True"></asp:RequiredFieldValidator><asp:Label ID="lblQuestion" runat="server" Text="Question  :" Width="95px" style="left: 62px; position: absolute; top: 295px" Font-Bold="False" Font-Names="Arial" Font-Size="11pt"></asp:Label><asp:Label ID="lblAnswer" runat="server" Text="Answer  :" style="left: 58px; position: absolute; top: 381px" Font-Bold="False" Font-Size="11pt" Font-Names="Arial"></asp:Label><asp:RadioButtonList ID="rdoAnswerlist" runat="server" ToolTip="Click to select answer" style="left: 178px; position: absolute; top: 373px" Font-Names="Arial" Font-Size="Small" Width="514px" ForeColor="Black" CellPadding="4" CellSpacing="4" OnSelectedIndexChanged="rdoAnswerlist_SelectedIndexChanged" RepeatColumns="4" EnableTheming="True" RepeatDirection="Horizontal">
                    <asp:ListItem>Answer1</asp:ListItem>
                    <asp:ListItem>Answer2</asp:ListItem>
                    <asp:ListItem>Answer3</asp:ListItem>
                    <asp:ListItem>Answer4</asp:ListItem>
                </asp:RadioButtonList>
                <asp:ListBox ID="lstboxSeltopic" runat="server" BackColor="Transparent" 
            Height="170px" Style="left: 121px;
                    position: absolute; top: 87px" Width="222px" 
            OnSelectedIndexChanged="lstboxSeltopic_SelectedIndexChanged" 
            AutoPostBack="True" SelectionMode="Multiple"></asp:ListBox>
                <asp:Button ID="btnSubmit" runat="server" Height="26px" Text="Submit" ToolTip="Click here to submit"
                    Width="78px" OnClick="btnSubmit_Click" style="left: 270px; position: absolute; top: 472px" BackColor="LightSteelBlue" BorderStyle="Ridge" /><asp:Label ID="lblQue" runat="server" Width="573px" style="left: 181px; position: absolute; top: 294px" Font-Names="Arial" Font-Size="Small"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;
        <hr style="left: 3px; width: 818px; position: absolute; top: 261px; height: 1px; background-color: #000000;" />
        <asp:Label ID="lblSelecttopic" runat="server" Font-Bold="False" Style="left: 6px;
            position: absolute; top: 90px" Text='Select Topic :<sup><Font Color="Red">*</Font Color></sup>' Width="95px" Font-Names="Arial" Font-Size="11pt"></asp:Label>
        <asp:Label ID="lblCans" runat="server" Style="left: 363px; position: absolute; top: 270px"
            Width="333px"></asp:Label>
        <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Style="left: 382px;
            position: absolute; top: 474px" Text="Exit" ToolTip="Click here to exit"
            Width="72px" ValidationGroup="other" BackColor="LightSteelBlue" BorderStyle="Ridge" />
        &nbsp;&nbsp;
        <asp:Label ID="lblSelectsub" runat="server" Font-Bold="False" Style="left: 5px; position: absolute;
            top: 58px" Text='Select Subject :<sup><Font Color="Red">*</Font Color></sup>' Width="108px" Font-Names="Arial" Font-Size="11pt"></asp:Label>
        <asp:DropDownList ID="cmbSelectSub" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbSelectsub_SelectedIndexChanged"
            Style="left: 120px; position: absolute; top: 59px" Width="222px">
        </asp:DropDownList>
        &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="btnPrevious" runat="server" OnClick="btnPrevious_Click" Style="left: 378px; top: 224px" Text="Previous" BackColor="LightSteelBlue" BorderStyle="Ridge" />
        &nbsp; &nbsp;<asp:TextBox ID="txtGoto" runat="server" Width="31px" style="left: 461px; top: 225px" ToolTip="Enter the question number which you want to display" OnTextChanged="txtGoto_TextChanged" AutoPostBack="True" Height="15px"></asp:TextBox>&nbsp;<asp:Button ID="btnNext" runat="server" Text="Next" style="left: 512px; top: 225px" ToolTip="Click here to go to next question" OnClick="btnNext_Click" Height="25px" BackColor="LightSteelBlue" BorderStyle="Ridge" />
        &nbsp;<asp:TextBox ID="TxtCount" runat="server" Enabled="False" Width="25px" 
            style="left: 566px; top: 225px" Font-Size="Medium" ReadOnly="True" 
            ToolTip="total number of questions" Height="16px" 
            ontextchanged="TxtCount_TextChanged"></asp:TextBox>&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnStart" runat="server" Style="left: 675px;
            top: 226px" Text="Start Test" ToolTip="Click here to start the test" Width="74px" OnClick="btnStart_Click1" BackColor="LightSteelBlue" BorderStyle="Ridge" /></asp:Panel>
    &nbsp;--%>






</asp:Content>

