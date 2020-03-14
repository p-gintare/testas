using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BasicSelenium.Tests
{
    public class DownloadProgressTests: BaseTest
    {
        private IWebElement downloadButton => driver.FindElement(By.Id("cricle-btn"));
        private IWebElement finishedTextElement => driver.FindElement(By.CssSelector(".percenttext"));
        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/bootstrap-download-progress-demo.html";
        }

        //su thread sleep tas pats kas selenium ide pause
        [Test]
        public void TestDownload()
        {
            downloadButton.Click();
            // sleep for 50 sec
            Thread.Sleep(50000);
            Assert.AreEqual("100%", finishedTextElement.Text);
        }
        //su explicity wait with expected conditions
        [Test]
        public void TestDownload2()
        {
            downloadButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(
                ExpectedConditions.TextToBePresentInElement(finishedTextElement, "100%"));
            Assert.AreEqual("100%", finishedTextElement.Text);
        }

        // aprasytas wait
        [Test]
        public void TestDownload3()
        {
            downloadButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(d => finishedTextElement.Text == "100%");
            Assert.AreEqual("100%", finishedTextElement.Text);
        }
    }
}
