using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BasicSelenium.Tests
{
    public class CheckboxTests : BaseTest
    {
        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        }


        [Test]
        public void TestCheckbox()
        {
            IWebElement checkboxAgeElement = driver.FindElement(By.Id("isAgeSelected"));
            checkboxAgeElement.Click();


            Assert.IsTrue(driver.FindElement(By.Id("isAgeSelected")).Selected);
            Assert.AreEqual("Success - Check box is checked", driver.FindElement((By.Id("txtAge"))).Text);
        }

        [Test]
        public void CheckAllTest()
        {
            

            driver.FindElement(By.Id("check1")).Click();
            Assert.IsNotNull(driver.FindElement(By.CssSelector("input[value='Uncheck All']")));
            Assert.AreEqual("Uncheck All", driver.FindElement(By.Id("check1")).GetProperty("value"), "Button value should change");

            var checkboxElementList = driver.FindElements(By.CssSelector(".text-left .panel ul~.checkbox input"));
            var checkboxElementList2 = driver.FindElements(By.CssSelector("ul~.checkbox input"));
            var checkboxElementList3 = driver.FindElements(By.CssSelector(".text-left .panel-body"))[1].FindElements(By.CssSelector(".checkbox input"));
            var checkboxElementList4 = driver.FindElements(By.XPath("//ul/..//input[@class='cb1-element']"));
            var checkboxElementList5 = driver.FindElements(By.CssSelector(".cb1-element"));
            var checkboxElementList6 = driver.FindElements(By.CssSelector("input.cb1-element"));
            var checkboxElementList7 = driver.FindElements(By.ClassName("cb1-element"));

            // if(4 == puslapio elementu skaiciui)
            Assert.AreEqual(4, checkboxElementList7.Count, "Turejo buti 4 checkboxai");
            foreach (var checkboxElement in checkboxElementList7)
            {
                Assert.IsTrue(checkboxElement.Selected, "Nepaselektino checkboxo.");
            }


        }

        [Test]
        public void TestUncheckAllButton()
        {
            // precondition
            driver.FindElement(By.Id("check1")).Click();

            // tikrasis testas
            driver.FindElement(By.Id("check1")).Click();
            //driver.FindElement(By.CssSelector("input[value='Uncheck All']")).Click();
            Assert.AreEqual("Check All", driver.FindElement(By.Id("check1")).GetProperty("value"));
            var checkboxElementList = driver.FindElements(By.CssSelector(".cb1-element"));
            Assert.AreEqual(4, checkboxElementList.Count);
            foreach (var checkboxElement in checkboxElementList)
            {
                Assert.AreEqual(false, checkboxElement.Selected);
                Assert.IsFalse(checkboxElement.Selected);
            }
        }
    }
}
