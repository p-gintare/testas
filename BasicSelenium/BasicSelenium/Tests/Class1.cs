using System;
using System.Collections.Generic;
using System.Text;
using BasicSelenium.Pabes;
using BasicSelenium.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace BasicSelenium.Tests
{
    public class InputTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestUserCanSendAndViewMessage()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("user-message")).SendKeys("irasom teksta");
            driver.FindElement(By.CssSelector("#get-input button")).Click();

            Assert.AreEqual("irasom teksta", driver.FindElement(By.Id("display")).Text);
        }

        [Test]
        public void CountSum()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("sum1")).SendKeys("5");
            driver.FindElement(By.Id("sum2")).SendKeys("2");
            driver.FindElement(By.CssSelector("#gettotal button")).Click();

            Assert.AreEqual("7", driver.FindElement(By.Id("displayvalue")).Text);

            //checkbox




           






        }
    }
}
