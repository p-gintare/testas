using System;
using System.Collections.Generic;
using System.Text;
using BasicSelenium.LoginTest.Api;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BasicSelenium.LoginTest
{
    public class RestTest
    {
        [Test]
        public void test()
        {
            LoginApi.Login(User.DefaultUser);
        }

        [Test]
        public void t2()
        {
            var driver = MyDriver.InitDriver(Browser.Chrome);
            driver.Url = "https://claim.skycop.com/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
            var depaturElement = driver.FindElement(By.CssSelector("#airport-departure input"));
           // depaturElement.Click();
            depaturElement.SendKeys("Vilnius");
            driver.FindElement(By.CssSelector(".Select-option.is-focused")).Click();
        }
    }
}
