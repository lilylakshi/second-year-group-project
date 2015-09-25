<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerInformation.aspx.cs" Inherits="ManagerInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manager Information</title>
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
    <script src="Calendar/jquery-1.10.2.js"></script>
    <script src="Calendar/jquery-ui.js"></script>
    <link href="Calendar/jquery-ui.css" rel="stylesheet" />
    <script>
        $(function () {
            $("#Datepicker").datepicker({
                changeMonth: true,
                changeYear: true
            });
        });
  </script>
    <style type="text/css">
        .auto-style1 {
            text-align: left;
            width: 196px;
        }
        .auto-style2 {
            text-align: left;
            width: 196px;
        }
    </style>
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
						<li><a class="current" href="ManagerHomePage.aspx">Home</a></li>
						<li><a>My Information</a>
							<ul>
								<li><a href="ManagerInformation.aspx">Personal Information</a></li>
								<li><a href="UpdateManagerInformation.aspx">Edit Personal Information</a></li>
							</ul>
						</li>
						<li><a>Community</a>
							<ul>
								<li><a href="SearchApplicantsManager.aspx">Search Candidates</a></li>
								<li><a href="CreateForumAndAddMembers.aspx">Create Forum</a></li>
                                <li><a href="PostInForumManager.aspx">Post in Forum</a></li>
                                <li><a href="AddJobPosition.aspx">Create Job Positions</a></li>
								<li><a href="ViewEmployersJobPositions.aspx">Job Positions by You</a></li>
                                <li><a href="SearchJobPositionsManager.aspx">Job Positions by Employers</a></li>
							</ul>
						</li>
                        
						<li><a>Settings</a>
							<ul>
								<li><a href="Settings_AccountSettingsManager.aspx">Account Settings</a></li>
								<li><a href="Settings_HelpManager.aspx">Help</a></li>
								<li><a href="Settings_ReportAProblemManager.aspx">Report a problem</a></li>
							</ul>
						</li>
						<li><a href="ContactUsManager.aspx">Contact Us</a></li>
                        <li><a>
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
		</div><!-- end #top-inner -->
		<div id="separator"></div><!-- end #separator -->
		<div id="content">
			<div id="main">
				<div id="side">
					<ul>
						<li class="widget-container">
							<h2>My Information</h2>
							<ul>
								<li><a href="ManagerInformation.aspx">Personal Information</a></li>
								<li><a href="UpdateManagerInformation.aspx">Edit Personal Information</a></li>
                                
							</ul>
						<li class="widget-container">
							<h2 class="widget-title">features we offer</h2>
							<ul class="no-arrow no-border">
								<li><span class="t3"><a href="#">Connect with the community</a></span>Connect with the profess<span>ional community to share knowledge and experience  </span></li>
								<li><span class="t3"><a href="#">Show your skills to the world</a></span>Share what you know with the world so that they can better recognise your <span>potential. </span></li>
							</ul>
						</li>
					</ul>
				</div><!-- end #side -->
				<div id="maincontent">
				
				<h1 class="pagetitle">Personal Information</h1>
				<div class="tabcontainer-arrow">
					<ul class="tabs-arrow">
						<li><a href="#tab_1">About You</a></li>
						<li><a href="#tab_2">Contact Information</a></li>
                        <li><a href="#tab_3">Company Information</a></li>
						
					</ul>
					<div id="tab-body-content">
						<div id="tab_1" class="tab-content-arrow">
							<table border="0">
            <tr><td class="auto-style1">First Name</td><td class="newTable"><asp:TextBox ID="fName" runat="server" Width="268px"></asp:TextBox>
                </td></tr> 
             <tr><td class="auto-style1">Middle Name</td><td class="newTable"><asp:TextBox ID="mName" runat="server" Width="268px"></asp:TextBox>
                </td></tr>
            <tr><td class="auto-style1">Last Name</td><td class="newTable"><asp:TextBox ID="lName" runat="server" Width="268px"></asp:TextBox>
                </td></tr>
            <tr><td class="auto-style1">Company Name</td><td class="newTable"><asp:TextBox ID="company" runat="server" Width="268px"></asp:TextBox>
                </td></tr> 
            
                                </table>
						</div><!-- end of #tab_1 -->

						<div id="tab_2" class="tab-content-arrow">
                            <table border="0">
                            <tr><td class="auto-style2">Personal Phone</td><td class="newTable"><asp:TextBox ID="personalPhone" runat="server" Width="268px"></asp:TextBox>
                </td></tr>
                            <tr><td class="auto-style2">Personal E-mail</td><td class="newTable"><asp:TextBox ID="personalEmail" runat="server" Width="268px"></asp:TextBox>
                </td></tr>
                           
                                
                                </table>
						</div><!-- end of #tab_2 -->
                        <div id="tab_3" class="tab-content-arrow">
                            <table>
                                <tr>
                                <td class="auto-style2">Company Number</td><td class="newTable">
                <asp:TextBox ID="companyPhone" runat="server" Width="268px"></asp:TextBox>
                </td>
                            </tr>
                                <tr>
                                <td class="auto-style2">Company E-mail</td><td class="newTable">
                <asp:TextBox ID="companyEmail" runat="server" Width="268px"></asp:TextBox>
                </td>
                            </tr>
                            <tr><td class="newTable"><strong>Company Address</strong></td></tr>
            <tr><td class="auto-style2">Number</td><td class="newTable">
                <asp:TextBox ID="number" runat="server" Width="268px"></asp:TextBox>
                </td></tr> 
            <tr><td class="auto-style2">Street</td><td class="newTable">
                <asp:TextBox ID="street" runat="server" Width="268px"></asp:TextBox>
                </td></tr> 
            <tr><td class ="auto-style2">Town</td><td class="newTable">
                <asp:TextBox ID="town" runat="server" Width="268px"></asp:TextBox>
                </td></tr> 
                            </table>
                            
						</div><!-- end of #tab_3 -->
						
					</div><!-- end #tab-body-content -->
				</div><!-- end #tabcontainer-arrow -->
				<br /><br />
        
                <asp:Button ID="AdditionalInfoButton" class="newButton" runat="server" Text="Submit Information" OnClick="AdditionalInfoButton_Click" />
                    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
			</div><!-- end #main -->
		</div><!-- end #content -->
            <div class="clear"></div><!-- clear float -->
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
						Copyright ©2011 <a href="ContactUsManager.aspx" class="colorlink">Diligentia Design</a>. <br />
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