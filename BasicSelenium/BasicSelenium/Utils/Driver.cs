using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace BasicSelenium.Utils
{
    class Driver
    {
        public IWebDriver Init()
        {
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
