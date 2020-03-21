using NUnit.Framework;

namespace BasicSelenium.LoginTest
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        [Test]
        public void TestLogin()
        {
            loginPage
                .EnterUsername(User.DefaultUser.Username)
                .EnterPassword(User.DefaultUser.Password)
                .ClickLogin()
                .AssertLogoutIsVisible();
            homePage.ClickLogout().AssertLoginButtonIsVisisble();
        }

        [TearDown]
        public void Logout()
        {
            MakeScreenshotOnTestFailure();
        }
    }
}
