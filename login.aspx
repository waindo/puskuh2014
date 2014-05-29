<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="css/content.css" rel="stylesheet" type="text/css" /> 
    <link href="css/content2.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/rounded/rounded.css" type="text/css" />
    <link rel="stylesheet" href="css/rounded/ie7.css" type="text/css" />
    <script type="text/javascript" src="js/jquery-menu.js"></script>
<script type="text/javascript" src="js/interface.js"></script>
<link href="css/style-menu.css" rel="stylesheet" type="text/css" />
<!--[if lt IE 7]>
 <style type="text/css">
 div, img { behavior: url(iepngfix.htc) }
 </style>
<![endif]-->
    <title>Silakan Login</title>
</head>
<body>
<script>
    function capLock(e) {
        kc = e.keyCode ? e.keyCode : e.which;
        sk = e.shiftKey ? e.shiftKey : ((kc == 16) ? true : false);
        if (((kc >= 65 && kc <= 90) && !sk) || ((kc >= 97 && kc <= 122) && sk))
            document.getElementById('divMayus').style.visibility = 'visible';
        else
            document.getElementById('divMayus').style.visibility = 'hidden';
    }
</script>
    <form id="form1" runat="server">
   
    <div id="content" class="fb_content">
<div class="UIOneOff_Container"><!-- 2365fa3194ecdc0cab15721ce967a9f8663937c7 -->
<div class="WelcomePage_Container">
<div class="WelcomePage_MainSellContainer">
<div class="WelcomePage_MainSell">
<div class="WelcomePage_MainSellCenter clearfix">
<div class="WelcomePage_MainSellLeft">
<%--<div class="WelcomePage_MainMessage" align="center"><b>Sistem Informasi Geografi<br />
    PUSKUH - Development</b></div>--%>
<%--<div class="WelcomePage_MainMap"></div>--%></div>

<div class="WelcomePage_MainSellRight">
	<div class="WelcomePage_SignUpSection">
	<div class="WelcomePage_SignUpMessage">
		<div class="WelcomePage_SignUpHeadline">User Access And Authorization</div>
		<div class="WelcomePage_SignUpSubheadline"></div>
	</div>

	<div class="WelcomePage_SimpleReg" id="registration_container">
	<div id="simple_registration_container" class="simple_registration_container">
	<div id="reg_box" style="padding-left:0px">
		<form method="post" action="" name="" id="">
		<div id="no_js_box" style="margin-left:30px">
		  <h2>Silahkan Masukkan User ID dan Password Anda.</h2><br /><br /><br />
		</div>
		<div id="reg_form_box">
		<div class="border" >
			<div class="padding">
				<div id="element-box">
					<jdoc:include type="message" />
					<div class="t">
						<div class="t">
							<div class="t"></div>
						</div>
					</div>
					<div class="m">
					<table width="100%">
					<tr valign="top">
					<td><img src="Images/j_login_lock.jpg" width="75" height="67" /></td>
					<td>
					<table class="editor" border="0" cellspacing="0" width="100%">
					<br /><br />
					<tr valign="top">
					<td>
						Nama User
					</td>
					<td>
						&nbsp;&nbsp;
					</td>
					  <td class="label"><input style="width: 120px;" type="text" id="txtUserName" runat="server" onkeypress="capLock(event)"/>
					  </td></tr><tr><td></td><td></td><td>
					    <div>
					        <asp:RequiredFieldValidator ID="validatorName" runat="server" ControlToValidate="txtUserName"
                            ErrorMessage="Masukkan nama user" Font-Size="12px" ForeColor="Firebrick"></asp:RequiredFieldValidator>
					    </div></td></tr>
                          
					<tr valign="top">
					<td>
					<div>
						Password
						</div>
					</td>
					<td>
						&nbsp;&nbsp;
					</td>
					  <td class="label"><input style="width: 120px;" type="password" id="txtPassword" runat="server" onkeypress="capLock(event)"/></td></tr><tr><td></td><td></td><td>
						<div>
						    <asp:RequiredFieldValidator ID="validatorPass" runat="server" ControlToValidate="txtPassword"
                            ErrorMessage="Password harus diisi" Font-Size="12px" ForeColor="Firebrick"></asp:RequiredFieldValidator>
						</div></td></tr>
					<tr>
					  <td style="height: 24px">
                          <input type="submit" id="btnLogin2" value="Login" runat="server"  onserverclick="btnLogin2_ServerClick"/></td>
					  <td style="height: 24px"><div class="UILinkButton UILinkButton_SU">
                          <div class="UILinkButton_RW"><div class="UILinkButton_R"></div></div></div></td><td><div id="divMayus" style="visibility:hidden;COLOR: Red">Caps Lock is on.</div></td></tr>
					  
					</table>
					</td></tr></table>
					
					<!--div id="reg_pages_msg" style="border-top:solid 1px #ddd;margin:0px auto;margin-top:20px;position:relative;width:100%; text-align:center; left: 0px; top: 0px;">Untuk login sebagai Guest, Klik disini.</div-->
					<div id="Div1" style="border-top:solid 1px #ddd;margin:0px auto;margin-top:20px;position:relative;width:100%; text-align:center; left: 0px; top: 0px;">
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red" Text="Username atau Password Salah"
                            Visible="False"></asp:Label></div>
                    <div><asp:Label ID="hidlbl" runat="server" Visible="false"><% Random rndm = new Random(); rndm.Next(); %></asp:Label></div>
				</div>
				<div class="b">
					<div class="b">
						<div class="b"></div>
					</div>
				</div>
			</div>
			<div class="clr"></div>
		</div>
	</div>
</div>
<div id="reg_captcha" style="display: none;">
<div id="captcha_buttons" class="clearfix" style="display: none;">
	
<div id="A_btn_sign_up" class="gridCol"><div>

<div class="UILinkButton UILinkButton_SU">
<div class="UILinkButton_RW"><div class="UILinkButton_R"></div></div></div>

<div id="captcha_async_status" class="async_status" style="display: none">
<!--img src="http://b.static.ak.fbcdn.net/images/loaders/indicator_blue_small.gif?8:111099" alt="" /--></div></div></div></div></div>

</form>
</div></div></div></div></div></div></div></div></div></div></div>

    
    </form>

<div id="pagefooter" class= "pagefooter_minimal" style="text-align:center">
<div class="dock" id="dock">
      <div class="dock-container"> 
      <a id="href" class="dock-item" href="#"><img id="img" src="#"  /><span></span></a>
      
     </div>
 	  </div>
   	<script type="text/javascript">

   	    $(document).ready(
		function () {
		    $('#dock').Fisheye(
				{
				    maxWidth: 150,
				    items: 'a',
				    itemsText: 'span',
				    container: '.dock-container',
				    itemWidth: 200,
				    proximity: 90,
				    halign: 'center'
				}
			)
		}
	);

   	    var href = document.getElementById("href");
   	    var img = document.getElementById("img");
   	    var ua = navigator.userAgent.toLowerCase();
   	    var isWindows = ua.indexOf("windows") > -1;
   	    var isAndroid = ua.indexOf("android") > -1;
   	    if (isWindows) {
   	        href.href = "http://www.mozilla.org/en-US/firefox/new/";
   	        img.src = "images/firefox.png";
   	    } else if (isAndroid) {
   	        href.href = "https://play.google.com/store/apps/details?id=com.android.chrome";
   	        img.src = "images/chrome.png";
   	    } 

</script>
<script language="javascript" type="text/javascript" src="js/scroll.js"></script>
<script language="javascript" type="text/javascript" src="js/graphic_scrollbar.js"></script>
<br> 
	<span style="text-align:center; color: #666666">Copyright © 2014 PUSKUH</span><br />
</div>
</body>
</html>