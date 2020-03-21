using System;
using System.Collections.Generic;
using System.Text;
using BasicSelenium.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace BasicSelenium.LoginTest
{
    public static class MyDriver
    {
        public static IWebDriver InitDriver(Browser browser)
        {
            IWebDriver driver = null;
            switch (browser)
            {
                case Browser.Chrome:
                    driver = new ChromeDriver(GetChromeOptions());
                    break;
                case Browser.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    Assert.Fail("Nesuportinu browser");
                    break;
            }

           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return driver;
        }

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("incognito", "start-maximized");
            return options;
        }
    }

    public enum  Browser
    {
        Firefox,
        Chrome
    }
}
