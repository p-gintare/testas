using BasicSelenium.LoginTest.Pages;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using System;
using Allure.Commons;
using NUnit.Framework;

namespace BasicSelenium.LoginTest
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement UsernameElement => Driver.FindElement(By.Id("txtUsername"));

        public void AssertLoginButtonIsVisisble()
        {
            Assert.IsNotNull(LoginButton);
        }

        public void AssertLoggedIn()
        {
            Assert.IsNull(LoginButton);
        }

        private IWebElement PasswordElement => Driver.FindElement(By.Id("txtPassword"));
        private IWebElement LoginButton => Driver.FindElement(By.Id("btnLogin"));

        public LoginPage EnterUsername(string username)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
                {
                    UsernameElement.SendKeys(username);
                },
                $"Enter user name {username}");
            
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                PasswordElement.SendKeys(password);

            }, "Enter password *******");
            
            return this;
        }

        public HomePage ClickLogin()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                LoginButton.Click();
            }, "click login");
            
            return new HomePage(Driver);
        }

        public HomePage Login(User user)
        {
            EnterUsername(user.Username);
            EnterPassword(user.Password);
            ClickLogin();
            
            return new HomePage(Driver);
        }

    }
}
