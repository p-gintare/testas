using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BasicSelenium.LoginTest
{
    public class LogoutTest : BaseTest
    {
        [SetUp]
        public void Login()
        {
            new LoginPage(Driver).Login(User.DefaultUser);
        }
    }
}
