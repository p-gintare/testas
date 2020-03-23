using System.Threading;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BasicSelenium.LoginTest
{
    
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
