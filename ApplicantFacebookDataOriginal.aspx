<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplicantFacebookDataOriginal.aspx.cs" Inherits="ApplicantFacebookData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Applicant's Facebook Data</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td><asp:Image ID="Picture" runat="server" /></td><td></td>
            </tr>
            <tr>
                <td>Link</td><td><asp:HyperLink ID="HyperLink" runat="server"></asp:HyperLink></td>
            </tr>
            <tr>
                <td>Name</td><td><asp:Label ID="NameLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Birthday</td><td><asp:Label ID="BirthdayLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Gender</td><td><asp:Label ID="GenderLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>No of Facebook Friends</td><td><asp:Label ID="FriendsLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Hometown</td><td><asp:Label ID="HometownLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Bio</td><td><asp:Label ID="BioLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Email</td><td><asp:Label ID="EmailLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Religion</td><td><asp:Label ID="ReligionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Work</td><td><asp:Label ID="WorkLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Education</td><td><asp:Label ID="EducationLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Books Read</td><td><asp:Label ID="BooksLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Events Attending</td><td><asp:Label ID="EventsLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Last Three Statuses</td><td><asp:Label ID="StatusLabel" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
