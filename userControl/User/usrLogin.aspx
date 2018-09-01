<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usrLogin.aspx.cs" Inherits="User_usrLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script type="text/javascript" language="javascript">
        function logout() {
            try {

                var ip = '<%= Request.UserHostAddress %>';

                if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                    xmlhttp = new XMLHttpRequest();
                }
                else {// code for IE6, IE5
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.open("GET", "../pExamSession.xml", false);
                xmlhttp.send();
                xmlDoc = xmlhttp.responseXML;

                var x = xmlDoc.getElementsByTagName("Users");
                for (i = 0; i < x.length; i++) {
                    var y = x[i].getElementsByTagName("session");
                    for (j = 0; j < y.length; j++) {
                        if (y[j].getElementsByTagName("ipAddress")[0].childNodes[0].nodeValue == ip && y[j].getElementsByTagName("LogOut")[0].childNodes[0].nodeValue == "1") {
                            //alert('sdf');
                            //xmlDoc.documentElement.removeChild(x);


                            //Find the node to kill
                            //var y = xmlDoc.getElementsByTagName("session")[0];
                            //Find that nodes parent
                            //var z = y.parentNode;
                            //delete the node from the parent.
                            //z.removeChild(y);

                            //var y1 = xmlDoc.getElementsByTagName("session")[0];
                            //var x1 = xmlDoc.documentElement.removeChild(y1);
                        }
                    }
                }
            } catch (err) {
                alert(err.message);
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%-- OnClientClick="logout()"--%>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="LogOut" OnClick="Button2_Click" />
    </div>
    </form>
</body>
</html>
