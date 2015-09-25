<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactUS.aspx.cs" Inherits="ContactUS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ContactUs</title>
    <link href="css/extra_css.css" rel="stylesheet" />
    <link href="./css/style.css" rel="stylesheet" type="text/css" />
    <link href="./css/inner.css" rel="stylesheet" type="text/css" />
    <script src="Calendar/jquery-1.10.2.js"></script>
    <script src="Calendar/jquery.easing.1.3.js"></script>
    <script type="text/javascript">
        function animateGridView() {
            //$("#GridView1").animate({ height: 600 }, "slow", "easeOutElastic");
            //$("#GridView1").slideUp();
            $("#gridViewDiv").slideUp(10, "swing", function () {
                showAnimation();
                console.log("animation completed");
            });
        }
        function showAnimation() {
            $("#gridViewDiv").fadeIn(1500, "swing");
        }
    </script>
    

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
<script type="text/javascript" src="./js/dropdown.js"></script>
<script type="text/javascript">
    var $ = jQuery.noConflict();

    $(document).ready(function () {

        /* Function for tab with arrow */
        $(".tab-content-arrow").hide(); //Hide all content
        $("ul.tabs-arrow li:first").addClass("active").show(); //Activate first tab
        $(".tab-content-arrow:first").show(); //Show first tab content
        //On Click Event
        $("ul.tabs-arrow li").click(function () {
            $("ul.tabs-arrow li").removeClass("active"); //Remove any "active" class
            $(this).addClass("active"); //Add "active" class to selected tab
            $(".tab-content-arrow").hide(); //Hide all tab content
            var activeTab = $(this).find("a").attr("href"); //Find the rel attribute value to identify the active tab + content
            $(activeTab).fadeIn(1000); //Fade in the active content
            return false;
        });

        /* Function for tab with frame */
        $(".tab-content").hide(); //Hide all content
        $("ul.tabs li:first").addClass("active").show(); //Activate first tab
        $(".tab-content:first").show(); //Show first tab content
        //On Click Event
        $("ul.tabs li").click(function () {
            $("ul.tabs li").removeClass("active"); //Remove any "active" class
            $(this).addClass("active"); //Add "active" class to selected tab
            $(".tab-content").hide(); //Hide all tab content
            var activeTab = $(this).find("a").attr("href"); //Find the rel attribute value to identify the active tab + content
            $(activeTab).fadeIn(1000); //Fade in the active content
            return false;
        });

    });

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="outer-container">
	<div id="container">
		<div id="top-inner">
			<div id="top-left">
				<div id="logo"><a href="./index.html"><img src="./images/logo.png" alt="" /></a></div><!-- end #logo -->
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
		</div><!-- end #top-inner -->
		<div id="separator"></div><!-- end #separator -->
		<div id="content">
			<div id="main">
				<div id="side">
					<ul>
						<li class="widget-container">
							
						</li>
					</ul>
				</div><!-- end #side -->
				<div id="maincontent">
				
				<h1 class="pagetitle_new">group Diligentia</h1>
                    
				    This is a group project done by Dliligentia group for their industry based project. The details of the group members are as follows.<br />
                    <br />
                    124005V&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp; P.G.L.L. Abeywickrama<br />
                    124229K&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp; J.G.U.P. Jayawardena<br />
                    124180B&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp; R.G.A.S. Udakara<br />
                    124063U&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp; A.R.M.S.K. Gunarathna<br />
                    124092G&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp; D.M.T.C. Karunarathna<br /><br />
                             
                                        
			</div><!-- end #main -->
		</div><!-- end #content -->
            <div class="clear"></div><!-- clear float -->
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
						Copyright ©2011 <a href="#" class="colorlink">Diligentia Design</a>. <br />
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

