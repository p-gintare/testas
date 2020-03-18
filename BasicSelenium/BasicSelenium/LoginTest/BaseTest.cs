using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BasicSelenium.LoginTest
{
    public class BaseTest
    {
        protected IWebDriver Driver;

        [SetUp]
        public void InitDriver()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Url = "https://s2.demo.opensourcecms.com/orangehrm/symfony/web/index.php/auth/login";
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [TearDown]
        public void QuitDriver()
        {
            Driver.Quit();
        }

        //BaseTest set up
            // LoginTest set up
            //test
            // LoginTests tear down
        //BaseTest tear down
    }
}
