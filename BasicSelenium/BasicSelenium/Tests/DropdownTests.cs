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
        IWebElement displaySelectedDayElement => driver.FindElement(By.CssSelector(".selected-value"));

        IWebElement multiSelect => driver.FindElement(By.Id("multi-select"));
        SelectElement multiselectElement => new SelectElement(multiSelect);
        IWebElement printSingleButton => driver.FindElement(By.Id("printMe"));
        IWebElement showAllSelectedElement => driver.FindElement(By.CssSelector(".getall-selected"));
        IWebElement floridaElement => multiselectElement.Options[1];
        IWebElement printAllButton => driver.FindElement(By.Id("printAll"));

        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        }

        [Test]
        public void TestsSingleDropDown()
        {
            dropdownSelectElement.SelectByValue("Wednesday");
            Assert.AreEqual("Day selected :- Wednesday", displaySelectedDayElement.Text);
            
            dropdownSelectElement.SelectByText("Monday");
            Assert.AreEqual("Day selected :- Monday", displaySelectedDayElement.Text);

            dropdownSelectElement.SelectByIndex(6);
            Assert.AreEqual("Day selected :- Friday", displaySelectedDayElement.Text);
        }

        [Test]
        public void MultiChoiseTests()
        {
            multiselectElement.SelectByValue("Ohio");

            var builder = new Actions(driver);
            builder.KeyDown(Keys.Control);
            builder.Click(floridaElement);
            builder.KeyUp(Keys.Control);
            builder.Build().Perform();
            
            printSingleButton.Click();

            Assert.AreEqual("First selected option is : Ohio", showAllSelectedElement.Text);
        }

        [Test]
        public void MultiChoiseTests2()
        {
            multiselectElement.SelectByValue("Ohio");

            var builder = new Actions(driver);
            builder.KeyDown(Keys.Control);
            builder.Click(floridaElement);
            builder.KeyUp(Keys.Control);
            builder.Build().Perform();

            printAllButton.Click();

            Assert.AreEqual("Options selected are : Ohio,Florida", showAllSelectedElement.Text);
        }
    }
}
