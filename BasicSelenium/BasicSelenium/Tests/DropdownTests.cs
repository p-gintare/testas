using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace BasicSelenium.Tests
{
    public class DropdownTests : BaseTest
    {
        IWebElement dropdown => driver.FindElement(By.Id("select-demo"));

        SelectElement dropdownSelectElement => new SelectElement(dropdown);

        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        }

        [Test]
        public void TestsSingleDropDown()
        {
            dropdownSelectElement.SelectByValue("Wednesday");

            var displaySelectedDayElement = driver.FindElement(By.CssSelector(".selected-value"));
            Assert.AreEqual("Day selected :- Wednesday", displaySelectedDayElement.Text);
            
            dropdownSelectElement.SelectByText("Monday");
            Assert.AreEqual("Day selected :- Monday", displaySelectedDayElement.Text);

            dropdownSelectElement.SelectByIndex(6);
            Assert.AreEqual("Day selected :- Friday", displaySelectedDayElement.Text);
        }

        [Test]
        public void MultiChoiseTests()
        {
            var multiSelect = driver.FindElement(By.Id("multi-select"));
            var multiselectElement = new SelectElement(multiSelect);
            multiselectElement.SelectByValue("Ohio");
            var floridaElement = multiselectElement.Options[1];

            var builder = new Actions(driver);
            builder.KeyDown(Keys.Control);
            builder.Click(floridaElement);
            builder.KeyUp(Keys.Control);
            builder.Build().Perform();

            var printSingleButton = driver.FindElement(By.Id("printMe"));
            printSingleButton.Click();

            var showAllSelectedElement = driver.FindElement(By.CssSelector(".getall-selected"));
            Assert.AreEqual("First selected option is : Ohio", showAllSelectedElement.Text);

        }

        [Test]
        public void MultiChoiseTests2()
        {
            var multiSelect = driver.FindElement(By.Id("multi-select"));
            var multiselectElement = new SelectElement(multiSelect);
            multiselectElement.SelectByValue("Ohio");
            var floridaElement = multiselectElement.Options[1];

            var builder = new Actions(driver);
            builder.KeyDown(Keys.Control);
            builder.Click(floridaElement);
            builder.KeyUp(Keys.Control);
            builder.Build().Perform();

            var printAllButton = driver.FindElement(By.Id("printAll"));
            printAllButton.Click();

            var showAllSelectedElement = driver.FindElement(By.CssSelector(".getall-selected"));
            Assert.AreEqual("Options selected are : Ohio,Florida", showAllSelectedElement.Text);
        }
    }
}
