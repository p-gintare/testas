using BasicSelenium.LoginTest.Pages;
using NUnit.Framework;

namespace BasicSelenium.LoginTest
{
    public class LoginTest : BaseTest
    {
        private LoginPage loginPage;
        private HomePage homePage;

        [SetUp]
        public void InitPages()
        {
            loginPage = new LoginPage(Driver);
            homePage = new HomePage(Driver);
        }

        [Test]
        public void TestLogin()
        {
            loginPage
                .EnterUsername(User.DefaultUser.Username)
                .EnterPassword(User.DefaultUser.Password)
                .ClickLogin()
                .AssertLogoutIsVisible();
        }

        [TearDown]
        public void Logout()
        {
            homePage.ClickLogout();
        }
    }
}
