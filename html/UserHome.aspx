<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="html_UserHome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Home </title>
  
    <%-- <asp:ContentPlaceHolder ID="head" runat="server">
    </asp:ContentPlaceHolder>
--%>
    <link href="../resources/stylesheet/HomePage.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
// <!CDATA[

        

// ]]>
    </script>

</head>
<body>
    <div id="container">
        <!--container-->
        <div id="header">
            <!--header-->
            <img src="../resources/images/logo.png" class="logo" />
            <div class="links">
                <!--links-->
                <a href="#" class="active">English</a> | <a href="#">Marathi</a>
            </div>
        </div>
        <!--header-->
        <div id="nav">
            <!--navigation-->
            <ul>
                <li id="link1"><a href="#">Contact Us</a></li>
                <li id="link4"><a href="../Aboutus.aspx">About Us</a></li>
                <li id="link5"><a href="UserHome.aspx">Home</a></li>
            </ul>
        </div>
        <!--navigation-->
        <div id="banner_img">
            <!--banner-->
            <!-- HTML Codes by Quackit.com -->
            <marquee style="z-index: 2; position: absolute; left: 24; top: 39; font-family: Cursive;
                font-size: 14pt; color: ffcc00; height: 85;" scrollamount="6" direction="left"
                width="100%">M.P.S.C</marquee>
            <marquee style="z-index: 3; position: absolute; left: 363; top: 82; font-family: Cursive;
                font-size: 14pt; color: ffcc00; height: 116;" scrollamount="7" direction="right"
                width="100%">U.P.S.C</marquee>
            <marquee style="z-index: 2; position: absolute; left: 157; top: 34; font-family: Cursive;
                font-size: 14pt; color: ffcc00; height: 95;" scrollamount="5" direction="down">1Std to 10th Std</marquee>
            <marquee style="z-index: 2; position: absolute; left: 278; top: 49; font-family: Cursive;
                font-size: 14pt; color: ffcc00; height: 165;" scrollamount="2" direction="down">Free Text</marquee>
            <marquee style="z-index: 2; position: absolute; left: 307; top: 39; font-family: Cursive;
                font-size: 14pt; color: ffcc00; height: 335;" scrollamount="1" direction="down">Paid Text</marquee>
            <span style="position: absolute; top: 400px"></span>
            <img src="../resources/images/Colorful-books1_01.png" class="Ebanner" />
        </div>
        <!--banner-->
        <div id="article">
            <!--left_pannel-->
            <div id="section">
                <!--box-->
                <img src="../resources/images/buket_img.jpg" alt="Buy Now" title="Buy Now" class="buket_img" />
                <a style="cursor: pointer; text-decoration: none; color: #000000; font-weight: bold;
                    font-size: 18px; font-family: Arial" href="../User/Payment.aspx">Paid Test</a>
                <div class="artitop_02">
                    <img src="../resources/images/pin1.png" class="artitop_02" />
                </div>
            </div>
            <div id="section1">
                <!--box-->
                <img src="../resources/images/samplttest_pad.jpg" alt="Buy Now" title="Sample Test" class="samplttest_pad" />
                <a style="cursor: pointer; text-decoration: none; color: #000000; font-weight: bold;
                    font-size: 18px; font-family: Arial" href="../User/Practice.aspx">Sample Test</a>
                <div class="artitop_02">
                    <img src="../resources/images/pin1.png" class="artitop_02" />
                </div>
            </div>
        </div>
        <div id="more">
            <div class="box">
                <!--box1-->
                <h3>
                    MPSC</h3>
                <p>
                    This document is dedicated to the countless lost hours of both people having to
                    search for simple answers, This document is dedicated to the countless lost This
                    document is dedicated.
                </p>
                <input type="button" id="readMe" value="Read Me" />
            </div>
            <div class="box">
                <!--box2-->
                <h3>
                    UPSC</h3>
                <p>
                    This document is dedicated to the countless lost hours of both people having to
                    search for simple answers, This document is dedicated to the countless lost This
                    document is dedicated.</p>
                <input type="button" id="readMe" value="Read Me" />
            </div>
            <!--box2-->
            <div class="box">
                <!--box3-->
                <h3>
                    NTS,MTS,NMMS</h3>
                <p>
                    This document is dedicated to the countless lost hours of both people having to
                    search for simple answers, This document is dedicated to the countless lost This
                    document is dedicated.</p>
                <input type="button" id="readMe" value="Read Me" href="#" />
            </div>
            <!--box3-->
            <div class="box">
                <!--box4-->
                <h3>
                    1std to 10th English & Marathi</h3>
                <p>
                    This document is dedicated to the countless lost hours of both people having to
                    search for simple answers, This document is dedicated to the countless lost.</p>
                <input type="button" id="readMe" value="Read Me" />
            </div>
            <!--box4-->
            <div class="box">
                <!--box4-->
                <h3>
                    Schoolcholarship</h3>
                <p>
                    This document is dedicated to the countless lost hours of both people having to
                    search for simple answers, This document is dedicated to the countless lost This
                    document is dedicated.</p>
                <input type="button" id="readMe" value="Read Me" />
            </div>
            <!--box4-->
            <div class="box">
                <!--box4-->
                <h3>
                    Suggest Affairs</h3>
                <p>
                    This document is dedicated to the countless lost hours of both people having to
                    search for simple answers, This document is dedicated to the countless lost This
                    document is dedicated.</p>
                <input type="button" id="readMe" value="Read Me" />
            </div>
            <!--box4-->
        </div>
        <!--more-->
        <div id="bottomnew_link">
            <!--bottomnew_link-->
            <div id="new_link">
                <!--new_link-->
                <div class="links_count">
                    <!--firstbox1-->
                    <h4>
                        Live Projects</h4>
                    <img src="../resources/images/Newlinks_article.jpg" alt="Newlinks_article" style="padding-top: 30px;" />
                    <a href="#">Know More...</a>
                </div>
                <div class="line">
                </div>
                <div class="links_count1">
                    <!--secondbox2-->
                    <h4>
                        Our Team</h4>
                    <img src="../resources/images/testimonials.jpg" alt="Newlinks_article" style="padding-top: 30px;" />
                    <a href="#">Know More...</a>
                </div>
                <div class="line1">
                </div>
                <div class="links_count2">
                    <!--secondbox3-->
                    <h4>
                        Publication</h4>
                    <img src="../resources/images/publication.jpg" alt="Newlinks_article" style="padding-top: 30px;" />
                    <a href="#">Know More...</a>
                </div>
                <div class="line2">
                </div>
                <div class="links_count3">
                    <!--secondbox3-->
                    <h4>
                        MCQ's On</h4>
                    <img src="../resources/images/updates.jpg" alt="Newlinks_article" style="padding-top: 30px;" />
                    <a href="#">Know More...</a>
                </div>
            </div>
            <!--head-->
        </div>
        <!--bottomnew_link-->
        <div id="bootom_right">
            <div class="r_logo">
                <img src="../resources/images/login_lock.png" width="85" height="110" class="lock" />
            </div>
            <div class="login">
                <h4>
                    Member Login</h4>
                <h5>
                    User Name:</h5>
                <input type="text" class="loginname" name="loginname" placeholder="Enter Login Id" />
                <h5>
                    Password</h5>
                <input type="text" id="pwd" class="loginname" placeholder="Enter Pass Word" />
                <img src="../resources/images/login.jpg" alt="login" class="login_img" />
                <a href="#" class="fpwd">Forgot PassWord </a>
            </div>
            <!--bootom_right-->
        </div>
        <div id="shortlnk">
            <!--footer_link-->
            <div class="footer_lnk">
                <a href="about.html">About</a> | <a href="sampletest.html">Sampletest</a> | <a href="payment.html">
                    Paid Test</a> | <a href="#">Contact Us</a> | <a href="index.html">Home</a>
            </div>
            <!--footer_lnk-->
        </div>
        <!--footer_lnik-->
        <div class="footernewmid">
            <div class="footernew_lnk">
                <!--footernew_lnk-->
                <a href="#">1 Std to IX Std </a>| <a href="#">X Std</a> | <a href="#">JE Mains</a>
                | <a href="#">IBPS</a> | <a href="#">MPSC</a> | <a href="#">UPSC</a>
            </div>
            <!--footernew_lnk-->
        </div>
        <div id="footer">
            <!--footer-->
            <div class="footerline">
                @ copyright 2013 all rights reserved
            </div>
        </div>
        <!--footer-->
    </div>
    <!--container-->
</body>
</html>
