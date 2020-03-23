using System;
using NUnit.Framework;

namespace BasicSelenium.LoginTest
{
    public class LogoutTest : BaseTest
    {
        [SetUp]
        public void Login()
        {
            Login2(User.DefaultUser);
        }

        [Test]
        public void TestLogout()
        {
            MyDriver.WriteAllCookies(Driver);
            homePage.ClickLogout().AssertLoginButtonIsVisisble();
        }
    }
}
