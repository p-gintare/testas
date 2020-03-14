using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BasicSelenium.Tests
{
    public class CheckboxTests : BaseTest
    {
        IWebElement checkboxAgeElement => driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement showCheckedTextElement => driver.FindElement(By.Id("txtAge"));

        IWebElement checkboxElement => driver.FindElement(By.Id("check1"));
        IList<IWebElement> checkboxElementList => driver.FindElements(By.CssSelector(".cb1-element"));


        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        }

        [Test]
        public void TestCheckbox()
        {
            checkboxAgeElement.Click();

            Assert.IsTrue(checkboxAgeElement.Selected);
            Assert.AreEqual("Success - Check box is checked", showCheckedTextElement.Text);
        }

        [Test]
        public void CheckAllTest()
        {
            
            checkboxElement.Click();
            Assert.AreEqual("Uncheck All", checkboxElement.GetAttribute("value"), "Button value should change");

            Assert.AreEqual(4, checkboxElementList.Count, "Turejo buti 4 checkboxai");
            foreach (var checkboxElement in checkboxElementList)
            {
                Assert.IsTrue(checkboxElement.Selected, "Nepaselektino checkboxo.");
            }
        }

        [Test]
        public void TestUncheckAllButton()
        {
            // precondition
            checkboxElement.Click();

            checkboxElement.Click();
            Assert.AreEqual("Check All", checkboxElement.GetAttribute("value"));
            Assert.AreEqual(4, checkboxElementList.Count);
            foreach (var checkboxElement in checkboxElementList)
            {
                Assert.IsFalse(checkboxElement.Selected);
            }
        }
    }
}
