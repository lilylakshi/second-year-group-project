<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login_Register.aspx.cs" Inherits="Login_Register" %>

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

                <table width="450" class="newTable">
                    <tr>
                        <td colspan ="2">Login or Create a Free Account</td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>Create Account:</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>Username</td>
                                    <td><asp:TextBox ID="TextBox2" TextMode="SingleLine" runat="server" CssClass="" Width="200"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td><asp:RadioButton ID="RadioButton2" runat="server" GroupName="group1" Text="Candidate" /></td>
                                    <td><asp:RadioButton ID="RadioButton1" Text="Employer" runat="server" GroupName="group1" /></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="ShowAvailabilityLabel" class ="label4"  runat="server"></asp:Label></td>
                                    <td><asp:Button ID="VerifyButton" CssClass="newButton" runat="server" Text="Check Availability" OnClick="VerifyButton_Click" /></td>
                                </tr>
                                <tr>
                                    <td>E-mail</td>
                                    <td><asp:TextBox ID="EmailTextBox" TextMode="SingleLine" runat="server" Width="200"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Password</td>
                                    <td><asp:TextBox ID="TextBox3" TextMode="Password" runat="server" width="200"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Re-enter Password</td>
                                    <td><asp:TextBox ID="ReEnterPassword" TextMode="Password" runat="server" Width="200"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:CheckBox ID="InformCheck" class ="label3" runat="server" Text="Please Inform Me of Job Opportunities" /></td>
                                    
                                </tr>
                                <tr>
                                    <td><asp:Label ID="WarningLabel" runat="server" CssClass="RedLabel"></asp:Label></td>
                                    <td><asp:Button ID="Button2" CssClass="newButton" runat="server" Text="Create Account" OnClick="Button2_Click" /></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>Login :</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>Username</td>
                                    <td><asp:TextBox ID="UserNameLogin" TextMode="SingleLine" runat="server" Width="200"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Password</td>
                                    <td><asp:TextBox ID="PasswordLogin" TextMode ="Password" runat="server" Width="200"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td><a href="SendAnEmail.aspx" title="Forgot Password">I Forgot my Password</a></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="ConfirmationLabel" CssClass="RedLabel" runat="server"></asp:Label></td>
                                    <td><asp:Button ID="LoginButton" CssClass="newButton" runat="server" Text="Login" OnClick="LoginButton_Click" /></td>
                                </tr>
                            </table>
                        </td>
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

