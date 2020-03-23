using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BasicSelenium.Tests
{
    public class ProgressBarDialogTests : BaseTest
    {
        private IWebElement SuccessButton => driver.FindElement(By.CssSelector(".btn-success"));

        private IWebElement ModalElement =>
            driver.FindElement(By.CssSelector(".modal.fade.in"));

        private IWebElement ModalHeaderElement =>
            driver.FindElement(By.CssSelector(".modal.fade.in .modal-header"));

        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/bootstrap-progress-bar-dialog-demo.html";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void TestProgressBarDialog()
        {
            SuccessButton.Click();
            Assert.IsNotNull(ModalElement);
            Assert.AreEqual("Custom message", ModalHeaderElement.Text);
        }
    }
}
