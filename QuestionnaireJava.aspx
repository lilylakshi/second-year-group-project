<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuestionnaireJava.aspx.cs" Inherits="QuestionnaireJava" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Take Questionnaire</title>
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
						<li><a>My CV</a>
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
						<li><a>Community</a>
							<ul>
								<li><a href="SearchApplicants.aspx">Search Peers</a></li>
								<li><a href="SearchJobPositions.aspx">Find Job Positions</a></li>
                                <li><a href="ApplicantsJobs.aspx">My Jobs</a></li>
                                <li><a href="PostInForum.aspx">Post in Forum</a></li>
							</ul>
						</li>
						<li><a>Settings</a>
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
							<h2>My CV</h2>
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
                                        <li><a href="QuestionnaireDB.aspx">Database Questionnaire</a></li>
                                    </ul>
                                </li>
                                <li><a href="ViewCV.aspx">View CV</a></li>
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
				
				<h1 class="pagetitle">java questionnaire</h1>
                    
				<br /><br />
                   
                    1) Which one of these lists contains only Java programming language keywords?<br /><!-- 2 -->
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton1" runat="server" GroupName="1" text="class, if, void, long, Int, continue"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" GroupName="1" text="goto, instanceof, native, finally, default, throws"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton3" runat="server" GroupName="1" text="try, virtual, throw, final, volatile, transient"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton4" runat="server" GroupName="1" text="strictfp, constant, super, implements, do"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton5" runat="server" GroupName="1" text="byte, break, assert, switch, include"/><br /><br />

                    2) Which will legally declare, construct, and initialize an array?<br /><!-- 4 -->
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton6" runat="server" GroupName="2" text="int [] myList = {&ldquo;1&rdquo;, &ldquo;2&rdquo;, &ldquo;3&rdquo;};"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton7" runat="server" GroupName="2" text="int [] myList = (5, 8, 2)};"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton8" runat="server" GroupName="2" text="int myList [] [] = {4,9,7,0};"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton9" runat="server" GroupName="2" text="int myList [] = {4, 3, 7};"/><br /><br />

                    3) You want subclasses in any package to have access to members of a superclass. Which is the most restrictive access that accomplishes this objective?<br /><!-- 3 -->
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton10" runat="server" GroupName="3" text="public"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton11" runat="server" GroupName="3" text="private"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton12" runat="server" GroupName="3" text="protected"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton13" runat="server" GroupName="3" text="transient"/><br /><br />


                    4) public class Outer <br />
                        &nbsp;&nbsp;&nbsp;
                        { <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            public void someOuterMethod() <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    {<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            //Line 5 <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    } <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    public class Inner { } 
                    <br />
                    <br />
    
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
                public static void main(String[] argv) <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                {<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Outer ot = new Outer(); <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    //Line 10<br />
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   } <br />
                &nbsp;&nbsp;&nbsp;
                } <br />
&nbsp;&nbsp;&nbsp;
Which of the following code fragments inserted, will allow to compile?<br /><!-- 1 -->
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton14" runat="server" GroupName="4" text="new Inner(); //At line 5"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton15" runat="server" GroupName="4" text="new Inner(); //At line 10"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton16" runat="server" GroupName="4" text="new ot.Inner(); //At line 10"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton17" runat="server" GroupName="4" text="new Outer.Inner(); //At line 10"/><br /><br />


                   
                    5) public class Test { }<br />
                        &nbsp;&nbsp;&nbsp;
                        What is the prototype of the default constructor?<br /><!-- 3 -->
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton18" runat="server" GroupName="5" text="Test( )"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton19" runat="server" GroupName="5" text="Test(void)"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton20" runat="server" GroupName="5" text="public Test( )"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton21" runat="server" GroupName="5" text="public Test(void)"/><br /><br />

                    6) Which two of the following are legal declarations for nonnested classes and interfaces?<br />

                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                            1.final abstract class Test {}<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            2.public static interface Test {}<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            3.final public class Test {}<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            4.protected abstract class Test {}<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            5.protected interface Test {}<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            6.abstract public class Test {}<br /><!-- 3 -->
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton22" runat="server" GroupName="6" text="1 and 4"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton23" runat="server" GroupName="6" text="2 and 5"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton24" runat="server" GroupName="6" text="3 and 6"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton25" runat="server" GroupName="6" text="4 and 6"/><br /><br />

                     7) Suppose that you would like to create an instance of a new Map that has an iteration order that is the same as the iteration order of an existing instance of a Map. Which concrete implementation of the Map interface should be used for the new instance?<br /><!-- 3 -->
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton26" runat="server" GroupName="7" text="TreeMap"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton27" runat="server" GroupName="7" text="HashMap"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton28" runat="server" GroupName="7" text="LinkedHashMap"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton29" runat="server" GroupName="7" text="The answer depends on the implementation of the existing instance."/><br /><br />


                    8) Which three are methods of the Object class?<br />

                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                        1.notify();<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        2.notifyAll();<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        3.isInterrupted();<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        4.synchronized();<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        5.interrupt();<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        6.wait(long msecs);<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        7.sleep(long msecs);<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        8.yield();<br /><!-- 3 -->
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton30" runat="server" GroupName="8" text="1, 2, 4"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton31" runat="server" GroupName="8" text="2, 4, 5"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton32" runat="server" GroupName="8" text="1, 2, 6"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton33" runat="server" GroupName="8" text="2, 3, 4"/><br /><br />

                    9) What allows the programmer to destroy an object x?<br /><!-- 4 -->
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton34" runat="server" GroupName="9" text="x.delete()"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton35" runat="server" GroupName="9" text="x.finalize()"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton36" runat="server" GroupName="9" text="Runtime.getRuntime().gc()"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton37" runat="server" GroupName="9" text="Only the garbage collection system can destroy an object."/><br /><br />

                    10) Which of the following are valid calls to Math.max?<br />
                        1.Math.max(1,4)<br />
                        2.Math.max(2.3, 5)<br />
                        3.Math.max(1, 3, 5, 7)<br />
                        4.Math.max(-1.5, -2.8f)<br /><!-- 1 -->
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton38" runat="server" GroupName="10" text="1, 2 and 4"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton39" runat="server" GroupName="10" text="2, 3 and 4"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton40" runat="server" GroupName="10" text="1, 2 and 3"/><br />
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton41" runat="server" GroupName="10" text="3 and 4"/><br /><br />

                    <asp:Button ID="Button1" runat="server" CssClass="newButton" Text="Submit Answers" OnClick="Button1_Click" />

                    
                  
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

