namespace Models;
public class ProfilePage
{

    public string? Image { get; set; }

    public string AboutMe { get; set; }
    public List<string> Hobbies { get; set; }

    public List<string> Interests { get; set; }

    public ProfilePage(string profileImage, string profileAboutMe, List<string> profileHobbies, List<string> profileInterests)
    {
        Image = profileImage;
        AboutMe = profileAboutMe;
        Hobbies = profileHobbies;
        Interests = profileInterests;
    }
}