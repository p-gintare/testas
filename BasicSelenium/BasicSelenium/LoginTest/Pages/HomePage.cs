using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BasicSelenium.LoginTest.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement logoutElement => Driver.FindElement(By.CssSelector("[target='_parent']"));

        public void AssertLogoutIsVisible()
        {
            Assert.IsNotNull(logoutElement, "User was not logged in");
        }

        public void ClickLogout()
        {
            logoutElement.Click();
        }
    }
}
