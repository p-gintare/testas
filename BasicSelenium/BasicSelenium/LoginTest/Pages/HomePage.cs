using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(4));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[target='_parent']")));

            wait.Until(d => logoutElement.Displayed);
            
            Assert.IsNotNull(logoutElement, "User was not logged in");
        }

        public LoginPage ClickLogout()
        {
            logoutElement.Click();
            return new LoginPage(Driver);
        }
    }
}
