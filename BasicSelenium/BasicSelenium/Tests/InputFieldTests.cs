using System;
using BasicSelenium.Pabes;
using BasicSelenium.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BasicSelenium
{
    public class InputFieldTests
    {
        private IWebDriver driver;
        private InputDemoPage inputDemoPage;

        [SetUp]
        public void Setup()
        {
            driver = new Driver().Init();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            driver.Manage().Window.FullScreen();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            inputDemoPage = new InputDemoPage(driver);
        }

        [Test]
        public void TestUserCanSendAndViewMessage()
        {
            var userMessage = "Test message";
            inputDemoPage
                .EnterText(userMessage)
                .ClickShowMessage();

            Assert.AreEqual(userMessage, inputDemoPage.GetUserMessage());
        }

        [Test]
        public void checkbox()
        {
            driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-checkbox-demo.html");
            driver.Manage().Window.Size = new System.Drawing.Size(1914, 1034);
            driver.FindElement(By.Id("isAgeSelected")).Click();
            driver.FindElement(By.CssSelector(".checkbox:nth-child(5) .cb1-element")).Click();
            Assert.That(driver.FindElement(By.Id("txtAge")).Text, Is.EqualTo("Success - Check box is checked"));
            Assert.That(driver.FindElement(By.Id("isAgeSelected")).Selected, Is.True);
            driver.FindElement(By.Id("check1")).Click();
            driver.FindElement(By.Id("check1")).Click();
            driver.FindElement(By.CssSelector(".panel:nth-child(5) > .panel-body")).Click();
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }
    }
}