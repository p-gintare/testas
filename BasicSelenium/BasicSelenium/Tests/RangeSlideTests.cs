using System;
using System.Collections.Generic;
using System.Text;
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
            driver.Url = "https://www.seleniumeasy.com/test/drag-drop-range-sliders-demo.html";
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
