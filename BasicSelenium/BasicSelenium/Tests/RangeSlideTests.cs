using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BasicSelenium.Tests
{
    class RangeSlideTests : BaseTest
    {
        private IWebElement dangerLineElement => driver.FindElement(By.CssSelector(".range-danger input"));
        private IWebElement dangerLineOutputElement => driver.FindElement(By.Id("rangeDanger"));

        private IWebElement darkBlueLineOutputElement => driver.FindElement(By.Id("rangePrimary"));

        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.kika.lt/";
        }

        [Test]
        public void LoginToKika()
        {
            //new Actions(driver).Click(driver.FindElement(By.CssSelector("#login-link > a "))).Build().Perform();
            driver.FindElement(By.CssSelector("#login-link a ")).Click();
           // Thread.Sleep(1000);
            new Actions(driver).SendKeys(driver.FindElement(By.Name("lgn_usr")), "test@test.test");
           // driver.FindElement(By.Name("lgn_usr")).SendKeys("test@test.test");
        }

        [Test]
        public void TestDangerLine()
        {
            for (int i = 1; i <= 16; i++)
            {
                dangerLineElement.SendKeys(Keys.ArrowLeft);
            }
            Assert.AreEqual("34", dangerLineOutputElement.Text);
        }

        [Test]
        public void TestDefaultValue()
        {
            Assert.AreEqual("50", darkBlueLineOutputElement.Text);
        }
    }
}
