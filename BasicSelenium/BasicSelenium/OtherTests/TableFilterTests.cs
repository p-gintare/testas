using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BasicSelenium.Tests
{
    public class TableFilterTests : BaseTest
    {
        private IList<IWebElement> filterResultElementList => driver.FindElements(By.CssSelector(".table-filter tr:not([style*='display: none;'])"));

        private IList<IWebElement> filterResultCheckboxList =>
            driver.FindElements(By.CssSelector("tr:not([style='display: none']) input"));
        private IWebElement FilterSuccessButton => driver.FindElement(By.CssSelector(".btn-success"));
        private IWebElement secondCheckboxElement => driver.FindElements(By.CssSelector("tr:not([style='display: none']) .ckbox"))[1];

        private IWebElement firstStarElement =>
            driver.FindElement(By.CssSelector(".table-filter tr:not([style*='display: none;']) .star"));


        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/table-records-filter-demo.html";
        }

        [Test]
        public void FilterTest()
        {
            Assert.AreEqual(5, filterResultElementList.Count);
            FilterSuccessButton.Click();
            Assert.AreEqual(2, filterResultElementList.Count);
        }

        [Test]
        public void TestCheckboxInFilterResult()
        {
            secondCheckboxElement.Click();
            Assert.IsTrue(filterResultCheckboxList[1].Selected);
            //Taip pat
            Assert.IsTrue(filterResultElementList[1].GetAttribute("class").Contains("selected"), "checkbox should be selected");
        }

        [Test]
        public void TestItemCanBeStared()
        {
            firstStarElement.Click();
            Assert.IsTrue(firstStarElement.GetAttribute("class").Contains("star-checked"), "star should be selected");
        }
    }
}
