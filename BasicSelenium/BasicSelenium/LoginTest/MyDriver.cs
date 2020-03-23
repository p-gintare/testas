using System;
using BasicSelenium.LoginTest.Api;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

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

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            return driver;
        }

        public static void SetCookies(IWebDriver driver)
        {
            driver.Manage().Cookies.AddCookie(new Cookie("Loggedin", "True", "s2.demo.opensourcecms.com", "/", null));
        }

        public static void WriteAllCookies(IWebDriver driver)
        {
            var cookies = driver.Manage().Cookies.AllCookies;
            foreach (var cookie in cookies)
            {
               Console.WriteLine($" cookie: {cookie.Name} value: {cookie.Value} domain: {cookie.Domain} path: {cookie.Path}"); 
            }
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
