using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BasicSelenium.Tests
{
    public class UserDemoTest : BaseTest
    {
        private IWebElement NewUserButton => driver.FindElement(By.Id("save"));
        private IWebElement ResultElement => driver.FindElement(By.Id("loading"));

        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/dynamic-data-loading-demo.html";
        }
    }
}
