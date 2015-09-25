<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddJobPosition.aspx.cs" Inherits="AddJobPosition" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Job Position</title>
    <link href="css/extra_css.css" rel="stylesheet" />
    <link href="./css/style.css" rel="stylesheet" type="text/css" />
    <link href="./css/inner.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .auto-style1 {
                text-align: left;
                width: 196px;
            }
            .auto-style2 {
                width: 196px;
            }
        
    </style>
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
						<li><a class="current" href="HomePage.aspx">Home</a></li>
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
						</li>
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
				
				<h1 class="pagetitle">add job position</h1>
                    
				<br /><br />
                    <table >
                        <tr>
                            <td class="auto-style1">Title <span class="red">*</span></td>
                            <td colspan="2" class="newTable"><asp:TextBox Width="260" ID="TitleTextBox" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Job Type<span class="red">*</span></td>
                            <td colspan="2" class="newTable">
                                <asp:DropDownList CssClass="newdrop" ID="JobTypeDropDownList" runat="server">
                                <asp:ListItem Value="0">Test</asp:ListItem>
                                <asp:ListItem Value="1">3D Animation or Graphic Design</asp:ListItem>
                                <asp:ListItem Value="2">Customer Service</asp:ListItem>
                                <asp:ListItem Value="3">Data Entry</asp:ListItem>
                                <asp:ListItem Value="4">Database</asp:ListItem>
                                <asp:ListItem Value="5">Electronics Technician or Engineer</asp:ListItem>
                                <asp:ListItem Value="6">Engineer</asp:ListItem>
                                <asp:ListItem Value="7">Tester</asp:ListItem>
                                <asp:ListItem Value="8">Hardware</asp:ListItem>
                                <asp:ListItem Value="9">Networking or System Administrator</asp:ListItem>
                                <asp:ListItem Value="10">Programmer or Software Developer</asp:ListItem>
                                <asp:ListItem Value="11">Quality Assurance (QA)</asp:ListItem>
                                <asp:ListItem Value="12">System Analyst</asp:ListItem>
                                <asp:ListItem Value="13">Repair and Fix</asp:ListItem>
                                <asp:ListItem Value="14">Sales</asp:ListItem>
                                <asp:ListItem Value="15">Technical Support (Technician or Help Desk)</asp:ListItem>
                                <asp:ListItem Value="16">Technical Writing</asp:ListItem>
                                <asp:ListItem Value="17">Security Expert</asp:ListItem>
                                <asp:ListItem Value="18">Webmaster or Web Designer</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Employer <span class="red">*</span></td>
                            <td colspan="2" class="newTable"><asp:TextBox ID="EmployerTextBox" Width="260" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Salary (Optional)</td>
                            <td colspan="2" class="newTable"><asp:TextBox ID="SalaryTextBox" Width="260" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Minimum Age Requirement (Optional)</td>
                            <td colspan="2" class="newTable"><asp:TextBox ID="MinAgeTextBox" Width="260" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Maximum Age Requirement (Optional)</td>
                            <td colspan="2" class="newTable"><asp:TextBox ID="MaxAgeTextBox" Width="260" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Experience (Optional)</td>
                            <td colspan="2" class="newTable"><asp:TextBox ID="ExperienceTextBox" Width="260" runat="server">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style2"></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="3" class="newTable">What qualities do you look for in an applicant? (Technical skills, softskills. leadership skills, etc...)<br />(You can pick the same quality three times.)</td>
                        </tr>
                       <tr>
                            <td class="auto-style1">First Quality <span class="red">*</span></td>
                            <td class="newTable"><asp:TextBox ID="FirstQualityTextBox" runat="server"></asp:TextBox></td>
                            <td class="newTable"><asp:DropDownList CssClass="newdrop" ID="FirstQualityDropDownList" runat="server">
                                <asp:ListItem Value="0">Computer Language</asp:ListItem>
                                <asp:ListItem Value="1">Soft Skill</asp:ListItem>
                                <asp:ListItem Value="2">Degree</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                        
                        <tr>
                            <td class="auto-style1">Second Quality <span class="red">*</span></td>
                            <td class="newTable"><asp:TextBox ID="SecondQualityTextBox" runat="server"></asp:TextBox></td>
                            <td class="newTable"><asp:DropDownList CssClass="newdrop" ID="SecondQualityDropDownList" runat="server">
                                <asp:ListItem Value="0">Computer Language</asp:ListItem>
                                <asp:ListItem Value="1">Soft Skill</asp:ListItem>
                                <asp:ListItem Value="2">Degree</asp:ListItem></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"class="newTable">Third Quality <span class="red">*</span></td>
                            <td class="newTable"><asp:TextBox ID="ThirdQualityTextBox" runat="server"></asp:TextBox></td>
                            <td class="newTable"><asp:DropDownList CssClass="newdrop" ID="ThirdQualityDropDownList" runat="server">
                                <asp:ListItem Value="0">Computer Language</asp:ListItem>
                                <asp:ListItem Value="1">Soft Skill</asp:ListItem>
                                <asp:ListItem Value="2">Degree</asp:ListItem></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Description <span class="red">*</span></td>
                            <td class="newTable" colspan="2"><asp:TextBox ID="DescriptionTextBox" runat="server" TextMode="MultiLine" Height="265px" Width="309px"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td><asp:Button CssClass="newButton" ID="SubmitCloseButton" runat="server" Text="Submit and Close" OnClick="SubmitCloseButton_Click" /></td>
                            <td><asp:Button CssClass="newButton" ID="SubmitNewButton" runat="server" Text="Submit and New" OnClick="SubmitNewButton_Click" /></td>
                        </tr>
                    </table>
                    <asp:Label ID="FeedbackLabel" runat="server" CssClass="red"></asp:Label>
                    

                  
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