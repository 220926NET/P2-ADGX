using System.Windows.Media.ImageSource;

namespace Models;
public class User
{

    //Users information variables
    public int? User_ID
    { get; set; } = null;

    public string LogInName
    { get; set; }
    public string Password
    { get; set; }

    public byte[] Portrait 
    { get; set; }

    public User(string askLoginName, string askPassword, bool askIsManager)
    {

        this.LogInName = askLoginName;
        this.Password = askPassword;
    }


    public User(string askLoginName, string askPassword, bool askIsManager, blob bioImage)
    {

        this.LogInName = askLoginName;
        this.Password = askPassword;
    }

    public User(string askLoginName, string askPassword, int getUser_ID)
    {

        this.LogInName = askLoginName;
        this.Password = askPassword;
        this.User_ID = getUser_ID;
    }



}
