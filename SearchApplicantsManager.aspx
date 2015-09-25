<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchApplicantsManager.aspx.cs" Inherits="SearchApplicantsManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Applicants</title>
    <link href="css/extra_css.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="./css/style.css" rel="stylesheet" type="text/css" />
    <link href="./css/inner.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function closeWindow() {
            window.open('', '_self', '');
            window.close();
        }
    </script>
    <script type="text/javascript" src="./js/jquery-1.5.1.min.js"></script>
<script type="text/javascript" src="./js/cufon-yui.js"></script>
<script type="text/javascript" src="./js/Century_Gothic_400-Century_Gothic_700-Century_Gothic_italic_400.font.js"></script>
<script type="text/javascript">
    Cufon.replace('h1')('h2')('h3')('h4')('h5')('h6')('#middle-text')('#middle-text-small')('ul#topnav > li > a', { hover: true })('.button-contact')('.datebox');
</script>
<script type="text/javascript" src="./js/dropdown.js"></script>
  
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
				
				<h1 class="pagetitle">search applicants</h1>
				
					
				<br /><br />
                    <table border="0" id="searchTable" class="center">
                                            <tr>
                                                <td class="newTableText">Search by</td>
                                                <td class="newTable">
                                                    <asp:DropDownList ID="SearchByDropDownList" CssClass="newdrop" runat="server" >
                                                        <asp:ListItem Value="Name">Name</asp:ListItem>
                                                        <asp:ListItem Value="ComputerLanguage">Computer Language</asp:ListItem>
                                                        <asp:ListItem Value="SoftSkill">Soft Skill</asp:ListItem>
                                                        <asp:ListItem Value="JobPosition">Job Position</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="newTableText">Keyword</td>
                                                <td class ="newTable"><asp:TextBox ID="KeywordBox" runat="server" Width="210px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td class="newTableText">
                                                    <asp:Label ID="JobTypeLabel" runat="server" Text="Job Type"></asp:Label>
                                                </td>
                                                <td class =" newTable">
                                                    <asp:DropDownList ID="JobTypeDropDownList" CssClass ="newdrop" runat="server">
                                                        <asp:ListItem Value="-1">All</asp:ListItem>
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
                                            <td colspan="2"><asp:Button ID="SearchButton" CssClass="newButton" runat="server" Text="Search" Width="181px" OnClick="SearchButton_Click" /></td>
                                            </tr>
                                            <tr>
                                            <td colspan="2">
                                                &nbsp;</td>
                                            </tr>
                                            <tr>
                                            <td colspan="2">
                                                <asp:Label ID="MessageLabel" CssClass="center" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            </table>
                                            <asp:GridView ID="ResultsGridView" runat="server" OnRowCreated="GridViewRowCreated" CssClass="center gridView"></asp:GridView>
                                        
                
                    
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

