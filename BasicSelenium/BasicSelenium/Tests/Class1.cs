using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;


namespace BasicSelenium.Tests
{
    public class InputTests : BaseTest
    {

        [SetUp]
        public void Setup()
        {
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
        }

        [Test]
        public void TestUserCanSendAndViewMessage()
        {
            IWebElement messageElement = driver.FindElement(By.Id("user-message"));
            messageElement.SendKeys("irasom teksta");

            IWebElement showMessageButton = driver.FindElement(By.CssSelector("#get-input button"));
            showMessageButton.Click();

            IWebElement displayMessageElement = driver.FindElement(By.Id("display"));
            Assert.AreEqual("irasom teksta", displayMessageElement.Text);
        }

        [Test]
        public void CountSum()
        {
            var firstNumberElement = driver.FindElement(By.Id("sum1"));
            firstNumberElement.SendKeys("5");

            var secondNumberElement = driver.FindElement(By.Id("sum2"));
            secondNumberElement.SendKeys("2");
            var sumButton = driver.FindElement(By.CssSelector("#gettotal button"));
            sumButton.Click();

            var displaySumElement = driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("7", displaySumElement.Text);
        }
    }
}
