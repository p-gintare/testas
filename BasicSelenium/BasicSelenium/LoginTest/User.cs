
namespace BasicSelenium.LoginTest
{
    public class User
    {
        public static User DefaultUser = new User("opensourcecms", password: "opensourcecms");

        public string Username;
        public string Password;
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
