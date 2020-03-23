using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Allure.Commons;
using BasicSelenium.LoginTest.Api;
using BasicSelenium.LoginTest.Pages;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace BasicSelenium.LoginTest
{
    public class BaseTest
    {
        protected IWebDriver Driver;

        protected LoginPage loginPage;
        protected HomePage homePage;

        [SetUp]
        public void InitDriver()
        {
            Driver = MyDriver.InitDriver(Browser.Chrome);
            Driver.Url = "https://s2.demo.opensourcecms.com/orangehrm/symfony/web/index.php/auth/login";
            InitPages();
        }

        private void InitPages()
        {
            loginPage = new LoginPage(Driver);
            homePage = new HomePage(Driver);
        }

        public void Login2(User user)
        {
            var token = LoginApi.Login(user);
            Driver.Manage().Cookies.AddCookie(new Cookie("PHPSESSID", token.PHPSESSID));
            Driver.Manage().Cookies.AddCookie(new Cookie("Loggedin", "True"));
            Driver.Url = "https://s2.demo.opensourcecms.com/orangehrm/index.php";
            MyDriver.WriteAllCookies(Driver);
        }

        public void LoginViaApi(User user)
        {
            var token = new Token(Driver.Manage().Cookies.GetCookieNamed("PHPSESSID").Value);
            LoginApi.Login(user, token);
            MyDriver.SetCookies(Driver);
            Driver.Url = "https://s2.demo.opensourcecms.com/orangehrm/index.php";
        }

        [TearDown]
        public void QuitDriver()
        {
            Driver.Quit();
        }

        protected void MakeScreenshotOnTestFailure()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                AllureLifecycle.Instance.WrapInStep(() =>
                {
                    var screenshot = DoScreenshot();
                    AllureLifecycle.Instance.AddAttachment("Look at me!!", "image/png", screenshot, "png");
                }, "Screenshot on test failure");

            }
        }

        protected byte[]  DoScreenshot()
        {
            Screenshot screenshot = Driver.TakeScreenshot();
            string screenshotPath = $"{TestContext.CurrentContext.WorkDirectory}/Screenshots";
            Directory.CreateDirectory(screenshotPath);
            string screenshotFile = Path.Combine(screenshotPath, $"{TestContext.CurrentContext.Test.Name}.png");

            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
            Console.WriteLine("screenshot: file://" + screenshotFile);

            // Add that file to NUnit results
            TestContext.AddTestAttachment(screenshotFile, "My Screenshot");
            return screenshot.AsByteArray;
        }

        //BaseTest set up
            // LoginTest set up
            //test
            // LoginTests tear down
        //BaseTest tear down
    }
}
