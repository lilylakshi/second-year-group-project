<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PromptToLogin.aspx.cs" Inherits="PromptToLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employer Home Page</title>
    <link href="~/css/style.css" rel="stylesheet" type="text/css" />
    <link href="~/css/lectric.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="css/extra_css.css" rel="stylesheet" />
    <link href="./css/style.css" rel="stylesheet" type="text/css" />
    <link href="./css/inner.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="./js/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="./js/cufon-yui.js"></script>
    <script type="text/javascript" src="./js/Century_Gothic_400-Century_Gothic_700-Century_Gothic_italic_400.font.js"></script>
    <script type="text/javascript">
        Cufon.replace('h1')('h2')('h3')('h4')('h5')('h6')('#middle-text')('#middle-text-small')('ul#topnav > li > a', { hover: true })('.button-contact')('.datebox');
    </script>
    <script type="text/javascript" src="./js/dropdown.js"></script>
    <script type="text/javascript" src="./js/jquery.cycle.all.min.js"></script>
    <script type='text/javascript' src='./js/lectric.js'></script>
    <script type='text/javascript' src='./js/slider.js'></script>
    <script type="text/javascript">
        var $ = jQuery.noConflict();
        $(document).ready(function () {
            /* if javascript disabled */
            $("body").removeClass("nojs").addClass("js");
        });
</script>

    <style type="text/css">
        .rightAlign {
            text-align: right;
        }
        .RedLabel {
            font-size: 12px;
            text-align: left;
            color:red;
            font-family: Arial;
        }
        #prompt {
            font-weight: bolder;
            font-size: 16px;
        }
        .auto-style1 {
            width: 375px;
        }
    </style>
</head>



<body class="nojs">
    <form id="form1" runat="server">
    <div id="outer-container">
	<div id="container">
		<div id="top">
			<div id="top-left">
				<div id="logo"><a href="#"><img src="./images/logo.png" alt="Company logo" /></a></div><!-- end #logo -->
			</div><!-- end #top-left -->
			<div id="top-right">
				<div id="top-navigation">
					<ul id="topnav">
						
						
						
                        
						
						
					</ul>
					<div class="clear"></div><!-- clear float -->
				</div>
				<!-- end #top-navigation -->
			</div><!-- end #top-right -->
		</div><!-- end #top -->
		

		<div id="middle-content">
			
		<div id="separator"></div><!-- end #separator -->
		<div id="content">
			<div id="main">
				
				<div class="clear"></div>
                <div id="prompt" class="RedLabel">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You&#39;re not logged in. Please log-in and you will be redirected to where you were.<br />
                </div>
                <br /><br />

                <table>
                    <tr>
                        <td class="auto-style1">Username</td>
                        <td><asp:TextBox ID="UserNameLogin" Width="268" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Password</td>
                        <td><asp:TextBox ID="PasswordLogin" runat="server" Width="268" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2"><asp:Button runat="server" CssClass="newButton" Text="Login" OnClick="LoginButton_Click" /></td>
                    </tr>
                </table>

                <br /><br /><br /><br />
                <table>
                    <tr>
                        <td><asp:Button ID="Button1" CssClass="newButton" runat="server" Text="Create New Account" OnClick="Button1_Click" /></td>
                    </tr>
                </table>
                <br/>
                <br />
                
                <asp:Label ID="ConfirmationLabel" CssClass="RedLabel" runat="server"></asp:Label>
				<div class="clear">


				</div>
			</div><!-- end #main -->
		</div><!-- end #content -->
		<div id="footer">
				<div id="foot-col1">
				<ul>
					<li class="widget-container" id="latestnews">
						
					</li>
				</ul>
				</div><!-- end #foot-col1 -->
				<div id="foot-col2">
				<ul>
					<li class="widget-container">
						
					</li>
				</ul>
				</div><!-- end #foot-col2 -->
				<div id="foot-col3">
				<ul>
					<li class="widget-container">
						
					</li>
				</ul>
				</div><!-- end #foot-col3 -->
				<div id="foot-col4">
				<ul>
					<li class="widget-container">
						<div class="button-contact"><a href="#"><span class="styletext">Contact Form</span><br />stay together with us</a></div>
						<p class="lineheight-small">
						    Diligentia<br />
						    Faculty of IT, University of Moratuwa.<br />
						Phone: 0713906367<br />
						Fax: 0716284238</p>
						Copyright ©2011 <a href="ContactUS.aspx" class="colorlink">Diligentia Design</a>. <br />
						All Rights Reserved.
					</li>
				</ul>
				</div><!-- end #foot-col4 -->
				<div class="clear"></div>
		</div><!-- end #footer -->
	</div><!-- end #container -->
</div><!-- end #outer-container -->
		
 
    </form>
</body>
</html>

</html>