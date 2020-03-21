using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BasicSelenium.LoginTest.Pages;
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

        [TearDown]
        public void QuitDriver()
        {
            Driver.Quit();
        }

        protected void MakeScreenshotOnTestFailure()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                DoScreenshot();
            }
        }

        protected void DoScreenshot()
        {
            Screenshot screenshot = Driver.TakeScreenshot();
            string screenshotPath = $"{TestContext.CurrentContext.WorkDirectory}/Screenshots";
            Directory.CreateDirectory(screenshotPath);
            string screenshotFile = Path.Combine(screenshotPath, $"{TestContext.CurrentContext.Test.Name}.png");

            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
            Console.WriteLine("screenshot: file://" + screenshotFile);

            // Add that file to NUnit results
            TestContext.AddTestAttachment(screenshotFile, "My Screenshot");
        }

        //BaseTest set up
            // LoginTest set up
            //test
            // LoginTests tear down
        //BaseTest tear down
    }
}
