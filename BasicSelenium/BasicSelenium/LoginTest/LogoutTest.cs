using NUnit.Framework;

namespace BasicSelenium.LoginTest
{
    public class LogoutTest : BaseTest
    {
        [SetUp]
        public void Login()
        {
            loginPage.Login(User.DefaultUser);
        }

        [Test]
        public void TestLogout()
        {
            
        }
    }
}
