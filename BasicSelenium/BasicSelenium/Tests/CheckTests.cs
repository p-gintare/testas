using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BasicSelenium.Tests
{
    public class CheckboxTests
    {
        [Test]
        public void TestCheckbox()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("isAgeSelected")).Click();
            Assert.IsTrue(driver.FindElement(By.Id("isAgeSelected")).Selected);
            Assert.AreEqual("Success - Check box is checked", driver.FindElement((By.Id("txtAge"))).Text);
        }

        [Test]
        public void CheckAllTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("check1")).Click();
            var checkboxElementList = driver.FindElements(By.CssSelector(".text-left .panel ul~.checkbox input"));
            var checkboxElementList2 = driver.FindElements(By.CssSelector("ul~.checkbox input"));
            var checkboxElementList3 = driver.FindElements(By.CssSelector(".text-left .panel-body"))[1].FindElements(By.CssSelector(".checkbox input"));
            var checkboxElementList4 = driver.FindElements(By.XPath("//ul/..//input[@class='cb1-element']"));
            var checkboxElementList5 = driver.FindElements(By.CssSelector(".cb1-element"));
            var checkboxElementList6 = driver.FindElements(By.CssSelector("input.cb1-element"));
            var checkboxElementList7 = driver.FindElements(By.ClassName("cb1-element"));

            Assert.AreEqual(4, checkboxElementList7.Count);
            foreach (var checkboxElement in checkboxElementList7)
            {
                Assert.IsTrue(checkboxElement.Selected);
            }
        }
    }
}
