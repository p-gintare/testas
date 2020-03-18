using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BasicSelenium.Tests
{
    public class AlertMessageTests : BaseTest
    {
        private IWebElement ErrorMessageButton => driver.FindElement(By.Id("normal-btn-danger"));
        private IWebElement ErrorModal
        {
            get
            {
                try
                {
                    return driver.FindElement(By.CssSelector(".alert-normal-danger[style *='display: block;']"));
                } catch(NoSuchElementException)
                {
                    return null;
                }
            }
        }

        private IWebElement WarningButton => driver.FindElement(By.Id("autoclosable-btn-warning"));


        private IWebElement WarningModal
        {
            get
            {
                try
                {
                    return driver.FindElement(By.CssSelector(".alert-autocloseable-warning[style *='display: block;']"));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            }
        }

        private IWebElement errorModalCloseButton => driver.FindElement(By.CssSelector(".alert-normal-danger[style *='display: block;'] .close"));
        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/bootstrap-alert-messages-demo.html";
        }

        [Test]
        public void TestErrorMessageCloseButton()
        {
            ErrorMessageButton.Click();
            Assert.IsNotNull(ErrorModal);
            Assert.IsTrue(ErrorModal.Text.Contains("I'm a normal danger message"));
            errorModalCloseButton.Click();

            Assert.IsNull(ErrorModal);
        }

        [Test]
        public void TestWarningMessage()
        {
            WarningButton.Click();
            Assert.IsNotNull(WarningModal);
            Assert.IsTrue(WarningModal.Text.Contains("I'm an autocloseable warning message. I will hide in 3 seconds"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => WarningModal == null);
            Assert.IsNull(WarningModal);
        }
    }
}
