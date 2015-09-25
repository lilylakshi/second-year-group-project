<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendAnEmail.aspx.cs" Inherits="SendAnEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Applicant Home Page</title>

     <link href="css/extra_css.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="./css/style.css" rel="stylesheet" type="text/css" />
    <link href="./css/inner.css" rel="stylesheet" type="text/css" />

    <link href="~/css/style.css" rel="stylesheet" type="text/css" />
    <link href="~/css/lectric.css" rel="stylesheet" type="text/css" media="screen" />

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
        .auto-style1 {
            width: 406px;
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
		
		
		<div id="separator"></div><!-- end #separator -->
		<div id="content">
			<div id="main">
				
				<div class="clear">
				</div>
                
                <table class="newTable">
                    <tr>
                        <td>Enter your e-mail address :</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><asp:TextBox ID="TextBox1" runat="server" CssClass="newTableText" Width="272px"></asp:TextBox></td>
                        <td><asp:Button ID="CreatePostButton" class="button" runat="server" Text="Send" CssClass="newButton" OnClick="CreatePostButton_Click"  /></td>
                    </tr>
                </table>

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

