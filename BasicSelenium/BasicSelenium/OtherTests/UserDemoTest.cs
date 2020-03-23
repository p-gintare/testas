using System;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BasicSelenium.Tests
{
    public class UserDemoTest : BaseTest
    {
        private IWebElement NewUserButton => driver.FindElement(By.Id("save"));
        private IWebElement ResultElement => driver.FindElement(By.Id("loading"));

        private IWebElement UserPhotoElement => driver.FindElement(By.CssSelector("#loading img"));

        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/dynamic-data-loading-demo.html";
        }

        [Test]
        public void TestRandomUSerThreadSleep()
        {
            NewUserButton.Click();
            Thread.Sleep(5000);
            Assert.IsTrue(UserPhotoElement.GetAttribute("src").Contains("https://randomuser.me/api/portraits/"), "Image should not be empty.");
            var actualText = ResultElement.Text;
            var fisrtNameRegex = new Regex("(First Name : [A-Za-z]+)");
            Assert.IsTrue(fisrtNameRegex.IsMatch(actualText), $"First name should not be empty. Was {actualText}");
            var lastNameRegex = new Regex("(Last Name : [A-Za-z]+)");
            Assert.IsTrue(lastNameRegex.IsMatch(actualText), $"Last name should not be empty. Was {actualText}");
        }

        [Test]
        public void TestRandomUSer()
        {
            NewUserButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => !ResultElement.Text.Contains("loading", StringComparison.CurrentCultureIgnoreCase));
            Assert.IsTrue(UserPhotoElement.GetAttribute("src").Contains("https://randomuser.me/api/portraits/"), "Image should not be empty.");
            var actualText = ResultElement.Text;
            var fisrtNameRegex = new Regex("(First Name : [A-Za-z]+)");
            Assert.IsTrue(fisrtNameRegex.IsMatch(actualText), $"First name should not be empty. Was {actualText}");
            var lastNameRegex = new Regex("(Last Name : [A-Za-z]+)");
            Assert.IsTrue(lastNameRegex.IsMatch(actualText), $"Last name should not be empty. Was {actualText}");
        }
    }
}
