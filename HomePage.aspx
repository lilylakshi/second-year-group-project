<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Applicant Home Page</title>

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
						<li><a class="current" href="HomePage.aspx">Home</a></li>
						<li><a href="#">My CV</a>
							<ul>
								<li><a href="CreateCV.aspx">Personal Information</a></li>
								<li><a href="UpdateCV.aspx">Edit Personal Information</a></li>
                                <li><a href="AddPhoneNumber.aspx">Add Phone Number</a></li>
                                <li><a href="AddComputerLanguage.aspx">Add a Computer Language</a></li>
                                <li><a href="AddFirstDegree.aspx">Add a First Degree</a></li>
                                <li><a href="AddMastersDegree.aspx">Add a Master's Degree</a></li>
                                <li><a href="addPhd.aspx">Add a PhD</a></li>
                                <li><a href="AddSoftSkill.aspx">Add a Soft Skill</a></li>
                                <li><a href="AddSeekingJob.aspx">Add a Seeking Job Position</a></li>
                                <li><a> Take Questionnaire</a>
                                    <ul>
                                        <li><a href="QuestionnaireJava.aspx">Java Questionnaire</a></li>
                                        <li><a href="QuestionnaireDatabase.aspx">Database Questionnaire</a></li>
                                    </ul>
                                </li>
                                <li><a href="ViewCV.aspx">View CV</a></li>
                                
							</ul>
						</li>
						<li><a href="#">Community</a>
							<ul>
								<li><a href="SearchApplicants.aspx">Search Peers</a></li>
								<li><a href="SearchJobPositions.aspx">Find Job Positions</a></li>
                                <li><a href="ApplicantsJobs.aspx">My Jobs</a></li>
                                <li><a href="PostInForum.aspx">Post in Forum</a></li>
							</ul>
						</li>
						<li><a href="#">Settings</a>
							<ul>
								<li><a href="Settings_AccountSettings.aspx">Account Settings</a></li>
								<li><a href="Settings_Help.aspx">Help</a></li>
								<li><a href="Settings_ReportAProblem.aspx">Report a problem</a></li>
							</ul>
						</li>
						<li><a href="ContactUsApplicant.aspx">Contact Us</a></li>
                        <li><a href="#">
                            <asp:Label ID="WelcomeLabel" runat="server" Text="Label"></asp:Label></a>
                            <ul>
								<li>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Logout">Logout</asp:LinkButton></li>
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
					<li><div class="title-icon"><img src="./images/content/icon1.png" alt="" class="alignleft" /><h2>Meet the Proffessionals</h2></div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum fermentum diam id purus dapibus pretium auctor nisl varius. Vestibulum arcu augue, porttitor in dictum vitae, vehicula et sapien. </li>
					<li><div class="title-icon"><img src="./images/content/icon4.png" alt="" class="alignleft" /><h2>Improve Your Knowledge</h2></div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum fermentum diam id purus dapibus pretium auctor nisl varius. Vestibulum arcu augue, porttitor in dictum vitae, vehicula et sapien. </li>
					<li class="last"><div class="title-icon"><img src="./images/content/icon5.png" alt="" class="alignleft" /><h2>Easy to Use</h2></div>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum fermentum diam id purus dapibus pretium auctor nisl varius. Vestibulum arcu augue, porttitor in dictum vitae, vehicula et sapien. </li>
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
								<h6 class="t1"><a href="#">The template design</a></h6>
								<span><a href="#">admin</a> // <a href="#">15 comments</a></span>
								<div class="clear"></div>
							</li>
							<li>
								<div class="datebox">may<br />05</div>
								<h6 class="t1"><a href="#">Web design</a></h6>
								<span><a href="#">admin</a> // <a href="#">10 comments</a></span>
								<div class="clear"></div>
							</li>
							<li>
								<div class="datebox">oct<br />10</div>
								<h6 class="t1"><a href="#">Photography</a></h6>
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
							<li><a href="#">Template design</a></li>
							<li><a href="#">Our new pages online </a></li>
							<li><a href="#">Adoble flash released</a></li>
							<li><a href="#">Photography of art</a></li>

							<li><a href="#">Media of advertising</a></li>
							<li><a href="#">Our technology</a></li>
							<li><a href="#">Website advertising</a></li>
						</ul>
					</li>
				</ul>
				</div><!-- end #foot-col2 -->
				<div id="foot-col3">
				<ul>
					<li class="widget-container">
						<h2 class="widget-title">Miscellaneous</h2>
						<ul>
							<li><a href="#">Organizing</a></li>
							<li><a href="#">Now to buy</a></li>
							<li><a href="#">Exterior design</a></li>
							<li><a href="#">Interior design</a></li>

							<li><a href="#">Shopping</a></li>
							<li><a href="#">Term of services</a></li>
							<li><a href="#">Site map</a></li>
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
						Copyright ©2011 <a href="ContactUsApplicant.aspx" class="colorlink">Diligentia Design</a>. <br />
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

