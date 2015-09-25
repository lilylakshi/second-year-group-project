<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchCandidatesManager.aspx.cs" Inherits="SearchCandidatesManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Candidates</title>
<link href="css/extra_css.css" rel="stylesheet" />
    <link href="./css/style.css" rel="stylesheet" type="text/css" />
    <link href="./css/inner.css" rel="stylesheet" type="text/css" />
    <link href="Css/ViewCV_css.css" rel="stylesheet" />
    
    <script src="Calendar/jquery-1.10.2.js"></script>
    <script src="Calendar/jquery.easing.1.3.js"></script>
    <script src="Calendar/ZoomPhoto.js"></script>
    
       

    
<script type="text/javascript" src="./js/jquery-1.5.1.min.js"></script>
<script type="text/javascript" src="./js/cufon-yui.js"></script>
<script type="text/javascript" src="./js/Century_Gothic_400-Century_Gothic_700-Century_Gothic_italic_400.font.js"></script>
<script type="text/javascript">
    Cufon.replace('h1')('h2:not(h2.trigger)')('h3')('h4')('h5')('h6')('#middle-text')('#middle-text-small')('ul#topnav > li > a', { hover: true })('.button-contact')('.datebox');
</script>
<script type="text/javascript" src="./js/dropdown.js"></script>
<script type="text/javascript">
    var $ = jQuery.noConflict();

    $(document).ready(function () {

        $(".toggle_container").hide();
        $("h2.trigger").click(function () {
            $(this).toggleClass("active").next().slideToggle("slow");
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
							<h2>Community</h2>
							<ul>
								<li><a href="SearchApplicantsManager.aspx">Search Candidates</a></li>
								<li><a href="CreateForumAndAddMembers.aspx">Create Forum</a></li>
                                <li><a href="PostInForumManager.aspx">Post in Forum</a></li>
                                <li><a href="AddJobPosition.aspx">Create Job Positions</a></li>
								<li><a href="ViewEmployersJobPositions.aspx">Job Positions by You</a></li>
                                <li><a href="SearchJobPositionsManager.aspx">Job Positions by Employers</a></li>
                                
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
				
					
				<br /><br />
        
                                            <table border="0">
                                            <tr>
                                                <td rowspan="3" class="auto-style1"><asp:Image ID="picone" runat="server" Width="150px"  /></td>
                                                <td><asp:Button ID="ShowFacebookButton" runat="server" Text="Show Facebook Data" CssClass="newButton" OnClick="ShowFacebookButton_Click" /></td>
                                            </tr>
                                            <tr>
                                                <td class ="cvTableName">
                                                    <asp:Label ID="name" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="DownloadCvButton" runat="server" Text="Download CV" CssClass="newButton" OnClick="DownloadCvButton_Click" /></td>
                                            </tr>
                                        </table>
                                        
                    
				                                        
				                                        <div id="toggle">
					                                        <h2 class="trigger"><a>Personal Information</a></h2>
					                                        <div class="toggle_container">
						                                        <div class="block">
							                                        <table border="0">
                                                                        <tr>
                                                                            <td class="cvTableText">Age</td>
                                                                            <td class="cvTableInfo"><asp:Label ID="Calendar1" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="cvTableText">Gender</td>
                                                                            <td class="cvTableInfo"><asp:Label ID="Gender" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="cvTableText">Maritual Status</td>
                                                                            <td class="cvTableInfo"><asp:Label ID="mStatus" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="cvTableText">School</td>
                                                                            <td class="cvTableInfo"><asp:Label ID="school" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                    </table>
						                                        </div>
					                                        </div>
					
					                                        <h2 class="trigger"><a>Contact Information</a></h2>
				
					                                        <div class="toggle_container">
						                                        <div class="block">
							                                        <table>
                                                                        <tr>
                                                                            <td colspan="2" class="cvTableText">Address</td>
                                                                            
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="cvTableTextright">Number</td>
                                                                            <td class="cvTableInfo"><asp:Label ID="number" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="cvTableTextright">Street</td>
                                                                            <td class="cvTableInfo"><asp:Label ID="street" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="cvTableTextright">Town</td>
                                                                            <td class="cvTableInfo"><asp:Label ID="town" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        
                                                                        <tr>
                                                                            <td class="cvTableText">E-mail</td>
                                                                            <td class="cvTableInfo"><asp:Label ID="email" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="cvTableText"><asp:Label ID="PhoneLabel" runat="server" Text="Phone(s)"></asp:Label></td>
                                                                            <td class="cvTableInfo"><asp:GridView ID="PhoneGridView" runat="server" ShowHeader="false" CssClass="label"></asp:GridView></td>
                                                                        </tr>
							                                        </table>
                                                                </div>
				
					                                        </div>
					
					                                        <h2 class="trigger"><a>Education</a></h2>
					                                        <div class="toggle_container">
						                                        <div class="block">
                                                                    <table>
                                                                        <tr>
                                                                            <td class="cvTableText"><asp:Label ID="FirstDegreesLabel" runat="server" Text="First Degree(s)"></asp:Label></td>
                                                                            <td class="cvTableInfo"><asp:GridView ID="FirstDegreeGridView" runat="server" ShowHeader="false" CssClass="label"></asp:GridView></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="cvTableText"><asp:Label ID="MastersDegreeLabel" runat="server" Text="Master's Degree(s)"></asp:Label></td>
                                                                            <td class="cvTableInfo"><asp:GridView ID="MastersDegreeGridView" runat="server" ShowHeader="false" CssClass="label"></asp:GridView></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="cvTableText"><asp:Label ID="PhdLabel" runat="server" Text="PhD(s)"></asp:Label></td>
                                                                            <td class="cvTableInfo"><asp:GridView ID="PhdGridView" runat="server" ShowHeader="false" CssClass="label"></asp:GridView></td>
                                                                        </tr>
                                                                    </table>
							                                     </div>
					                                        </div>
					
					                                        <h2 class="trigger"><a>Other Skills</a></h2>
					                                        <div class="toggle_container">
						                                        <div class="block">
                                                                    <table>
                                                                        <tr>
                                                                            <td class="cvTableText"><asp:Label ID="SoftSkillLabel" runat="server" Text="Soft Skill(s)"></asp:Label></td>
                                                                            <td class="cvTableInfo"><asp:GridView ID="SoftSkillGridView" runat="server" ShowHeader="false" CssClass="label"></asp:GridView></td>
                                                                        </tr>
                                                                    </table>
							                                    </div>
					                                        </div>
					                                        <h2 class="trigger"><a>Other Information</a></h2>
					                                        <div class="toggle_container">
						                                        <div class="block">
                                                                    <table>
                                                                        <tr>
                                                                            <td class="cvTableText"><asp:Label ID="SeekingJobsLabel" runat="server" Text="Job(s) Seeking"></asp:Label></td>
                                                                            <td class="cvTableInfo"><asp:GridView ID="SeekingJobsGridView" runat="server" ShowHeader="false" CssClass="label"></asp:GridView></td>
                                                                        </tr>
                                                                    </table>
						                                        </div>
					                                        </div>
                    
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


