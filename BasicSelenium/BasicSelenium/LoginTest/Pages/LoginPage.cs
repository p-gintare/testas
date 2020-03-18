using System;
using System.Collections.Generic;
using System.Text;
using BasicSelenium.LoginTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BasicSelenium.LoginTest
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement UsernameElement => Driver.FindElement(By.Id("txtUsername"));
        private IWebElement PasswordElement => Driver.FindElement(By.Id("txtPassword"));
        private IWebElement LoginButton => Driver.FindElement(By.Id("btnLogin"));


        public LoginPage EnterUsername(string username)
        {
            //UsernameElement.SendKeys(username);
            new Actions(Driver).SendKeys(UsernameElement, username);
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            PasswordElement.SendKeys(password);
            return this;
        }

        public HomePage ClickLogin()
        {
            LoginButton.Click();
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
