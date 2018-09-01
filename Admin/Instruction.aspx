<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Instruction.aspx.cs" Inherits="Admin_Instruction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Exam</title>
    <style type="text/css">
        .style1
        {
            height: 23px;
            width: 181px;
        }
        .style3
        {
            width: 181px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div style="border: dotted 1px black; width: 100%; margin-top:100px;">
        
    <div id="tblInstruction" class="div1" runat="server" style="width: 580; height: 810;">
        <table width="95%" border="0" style="width: 580; height: 810;">
            <tr>
                <td>
                 
                    <center>
                    <br />
                    <br />
                        <table width="90%" style="width: 580; height: 810;">
                            <tr>
                            
                                <td colspan="4" style="font-size: x-large; font-weight: bold; color: #000000; text-align: center;
                                    font-family: 'times New Roman', Times, serif;">
                                    <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="#EA4515"></asp:Label>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                             <td width="30%">
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Exam Duration"></asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                </td>
                               
                               
                            </tr>
                            <tr>
                              <td>
                                </td>
                                <td width="10px">
                                    <asp:Label ID="Label4" runat="server" Text="Passing Mark"></asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                </td>
                              
                              
                            </tr>
                            <tr>
                            <td>
                                </td>
                                <td width="10px">
                                    <asp:Label ID="Label6" runat="server" Text="Total Number of Question" 
                                        Width="200px"></asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                                </td>
                               
                                
                            </tr>
                              <tr>
                              <td>
                                </td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Exam Date"></asp:Label>
                                </td>
                                <td class="style1">
                                    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                                </td>
                               
                            </tr>
                            
                             <tr>
                            <td>
                                </td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Marks for Correct Answer"></asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                                </td>
                               
                            </tr>
                            
                            <tr>
                            <td>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Negative Marking"></asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                                </td>
                               
                            </tr>
                          
                            <tr>
                            <td>
                                </td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="Mark for wrong Question" 
                                        Visible="False"></asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:Label ID="Label13" runat="server" Text="Label" Visible="False"></asp:Label>
                                </td>
                               
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                        <table width="90%" style="width: 580; height: 810;">
                            <tr>
                                <td style="text-align: center">
                                    <h2 style="color: Black">
                                        Instruction for Candidate</h2>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <center>
                                        <table border="1" width="90%">
                                            <tr>
                                            
                                                <td style="text-align: left">
                                                    <li>Do keep a pen and paper handy for rough work .</li>
                                                    <li>If you dont know answer then go for next Question please dont waste your valuable
                                                        time .</li>
                                                    <li>Try to give answer of every Question .</li>
                                                    <li>Try to use black boll pen only if you have.</li>
                                                    <li>Dont use Electronic Device like calculator</li>
                                                    <li>All the Best !!!!</li>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                </td>
            </tr>
        </table>
    </div>
    
        </div>
    </form>
</body>
</html>
