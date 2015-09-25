<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WhereIsMyJob.aspx.cs" Inherits="WhereIsMyJob" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Where is my Job</title>
    <link href="css/extra_css.css" rel="stylesheet" />
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
						<li><a class="current" href="WhereIsMyJob.aspx">Home</a></li>
						<li><a href="ContactUS.aspx">Contact Us</a></li>
                        <li><a href="Login_Register.aspx"> Login/Register</a>
                            <ul>
                                <li>
                                    <asp:TextBox ID="UserNameLogin" runat="server"></asp:TextBox>

                              
                                    <asp:TextBox ID="PasswordLogin" runat="server"></asp:TextBox>

                                
                                    <asp:Button ID="LoginButton" CssClass="newButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
                                </li>
                            </ul>
                        </li>
					</ul>
					<div class="clear"></div><!-- clear float -->
				</div>
				<!-- end #top-navigation -->
			</div><!-- end #top-right -->
		</div><!-- end #top -->
		<div id="header">
			<div id="slider">
                    <div class="item"><img src="./images/content/slide1.jpg" alt="slide1" /></div>
                    <div class="item"><img src="./images/content/slide2.jpg" alt="slide2" /></div>
                    <div class="item"><img src="./images/content/slide3.jpg" alt="slide3" /></div>
                    <div class="item"><img src="./images/content/slide4.jpg" alt="slide4" /></div>
                    <div class="item"><img src="./images/content/slide5.jpg" alt="slide5" /></div>
                    <div class="item"><img src="./images/content/slide2.jpg" alt="slide2" /></div>
          	</div><!-- end #slider -->
            <div class="clear"></div>
            <div id="scrubber">
                <a href="#" title="0" class="item"></a>
                <a href="#" title="1" class="item"></a>
                <a href="#" title="2" class="item"></a>
                <a href="#" title="3" class="item"></a>
                <a href="#" title="4" class="item"></a>
                <a href="#" title="5" class="item lastscrubber"></a>
                <div id="scrubmover"></div>
            </div>
		</div><!-- end #header -->
		<div id="middle-content">
			<div id="middle-text">Find your Dream Job here</div>
			<div id="middle-text-small">we give you opportunities that will build your future</div>
		</div><!-- end #middle-content -->
		<div id="separator"></div><!-- end #separator -->
		<div id="content">
			<div id="main">
				<ul class="three_column">
					<li><div class="title-icon"><img src="./images/content/icon2.png" alt="" class="alignleft" /><h2>Create Your own CV</h2><span class="clear"></span></div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum fermentum diam id purus dapibus pretium auctor nisl varius. Vestibulum arcu augue, porttitor in dictum vitae, vehicula et sapien. </li>
					<li><div class="title-icon"><img src="./images/content/icon3.png" alt="" class="alignleft" /><h2>Jobs at Your Feet</h2></div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum fermentum diam id purus dapibus pretium auctor nisl varius. Vestibulum arcu augue, porttitor in dictum vitae, vehicula et sapien. </li>
					<li class="last"><div class="title-icon"><img src="./images/content/icon1.png" alt="" class="alignleft" /><h2>Interact with the community</h2></div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum fermentum diam id purus dapibus pretium auctor nisl varius. Vestibulum arcu augue, porttitor in dictum vitae, vehicula et sapien. </li>
				</ul>
				<div class="clear"></div><br /><br />
				<ul class="three_column">
					<li><div class="title-icon"><img src="./images/content/icon1.png" alt="" class="alignleft" /><h2>Create Job possitions</h2></div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum fermentum diam id purus dapibus pretium auctor nisl varius. Vestibulum arcu augue, porttitor in dictum vitae, vehicula et sapien. </li>
					<li><div class="title-icon"><img src="./images/content/icon4.png" alt="" class="alignleft" /><h2>Search Candidates</h2></div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum fermentum diam id purus dapibus pretium auctor nisl varius. Vestibulum arcu augue, porttitor in dictum vitae, vehicula et sapien. </li>
					<li class="last"><div class="title-icon"><img src="./images/content/icon5.png" alt="" class="alignleft" /><h2>Get Employer information</h2></div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum fermentum diam id purus dapibus pretium auctor nisl varius. Vestibulum arcu augue, porttitor in dictum vitae, vehicula et sapien. </li>
				</ul>
				<div class="clear"></div>
			</div><!-- end #main -->
		</div><!-- end #content -->
		<div id="footer">
				<div id="foot-col1">
				<ul>
					<li class="widget-container" id="latestnews">
						<h2 class="widget-title">Latest News</h2>
						<ul>
							<li>
								<div class="datebox">mar<br />12</div>
								<h6 class="t1"><a href="#">News 1</a></h6>
								<span><a href="#">admin</a> // <a href="#">15 comments</a></span>
								<div class="clear"></div>
							</li>
							<li>
								<div class="datebox">may<br />05</div>
								<h6 class="t1"><a href="#">News 2</a></h6>
								<span><a href="#">admin</a> // <a href="#">10 comments</a></span>
								<div class="clear"></div>
							</li>
							<li>
								<div class="datebox">oct<br />10</div>
								<h6 class="t1"><a href="#">News 3</a></h6>
								<span><a href="#">admin</a> // <a href="#">5 comments</a></span>
								<div class="clear"></div>
							</li>
						</ul>
					</li>
				</ul>
				</div><!-- end #foot-col1 -->
				<div id="foot-col2">
				<ul>
					<li class="widget-container">
						<h2 class="widget-title">Recent Posts</h2>
						<ul>
							<li><a href="#">Post 1</a></li>
							<li><a href="#">Post 2 </a></li>
							<li><a href="#">Post 3</a></li>
							<li><a href="#">Post 4</a></li>

							<li><a href="#">Post 5</a></li>
							<li><a href="#">Post 6</a></li>
							<li><a href="#">Post 7</a></li>
						</ul>
					</li>
				</ul>
				</div><!-- end #foot-col2 -->
				<div id="foot-col3">
				<ul>
					<li class="widget-container">
						<h2 class="widget-title">Miscellaneous</h2>
						<ul>
							<li><a href="#">Search Applicant</a></li>
							<li><a href="#">Search Job Position</a></li>
							<li><a href="#">Update Your Account</a></li>
							<li><a href="#">Change Password</a></li>

							<li><a href="#">Post in Forum</a></li>
							<li><a href="#">Help</a></li>
							<li><a href="#">View Applicant Information</a></li>
						</ul>
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
