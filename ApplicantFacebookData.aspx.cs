using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;

public partial class ApplicantFacebookData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginModule myLoginModule = new LoginModule();
        myLoginModule.checkLoginStatus();
        WelcomeLabel.Text = myLoginModule.getFirstName((String)Session["userID"]);

        loadFacebookData();
    }

    protected void loadFacebookData()
    {
        try
        {
            var client = new FacebookClient(new InfoModule().readFacebookAccessToken(Request["id"]));
            dynamic response = client.Get("me");
            dynamic response2 = client.Get("me?fields=picture");
            dynamic response3 = client.Get("me?fields=books");
            dynamic response4 = client.Get("me?fields=friends,events,sports,statuses.limit(3)");
            Picture.ImageUrl = response2.picture.data.url;
            HyperLink.NavigateUrl = response.link;
            HyperLink.Text = response.link;
            NameLabel.Text = response.name;
            BirthdayLabel.Text = response.birthday;
            GenderLabel.Text = response.gender;
            HometownLabel.Text = response.hometown.name;
            BioLabel.Text = response.bio;
            EmailLabel.Text = response.email;
            ReligionLabel.Text = response.religion;
            WorkLabel.Text = "";
            EducationLabel.Text = "";
            BooksLabel.Text = "";
            EventsLabel.Text = "";
            StatusLabel.Text = "";
            FriendsLabel.Text = response4.friends.summary.total_count.ToString();

            foreach (dynamic workplace in response.work)
            {
                WorkLabel.Text += workplace.employer.name + "<br />";
            }
            foreach (dynamic school in response.education)
            {
                EducationLabel.Text += school.school.name + "<br />";
            }
            foreach (dynamic book in response3.books.data)
            {
                BooksLabel.Text += book.name + "<br />";
            }
            foreach (dynamic events in response4.events.data)
            {
                EventsLabel.Text += events.name + "<br />";
            }
            foreach (dynamic status in response4.statuses.data)
            {
                StatusLabel.Text += status.message + "<br /><br />";
            }
        }
        catch (NullReferenceException e)
        {

        }
        
    }

    protected void Logout(object sender, EventArgs e)
    {
        Session["userID"] = null;
        Session["prevPage"] = null;
        Response.Redirect("~/WhereIsMyJob.aspx");
    }
}