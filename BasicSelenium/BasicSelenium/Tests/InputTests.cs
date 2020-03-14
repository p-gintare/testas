using NUnit.Framework;
using OpenQA.Selenium;


namespace BasicSelenium.Tests
{
    public class InputTests : BaseTest
    {
        IWebElement messageElement => driver.FindElement(By.Id("user-message"));
        IWebElement showMessageButton => driver.FindElement(By.CssSelector("#get-input button"));
        IWebElement displayMessageElement => driver.FindElement(By.Id("display"));

        IWebElement firstNumberElement => driver.FindElement(By.Id("sum1"));
        IWebElement secondNumberElement => driver.FindElement(By.Id("sum2"));
        IWebElement sumButton => driver.FindElement(By.CssSelector("#gettotal button"));

        IWebElement displaySumElement => driver.FindElement(By.Id("displayvalue"));

        [SetUp]
        public void Setup()
        {
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
        }

        [Test]
        public void TestUserCanSendAndViewMessage()
        {
            messageElement.SendKeys("irasom teksta");
            showMessageButton.Click();

            Assert.AreEqual("irasom teksta", displayMessageElement.Text);
        }

        [Test]
        public void CountSum()
        {
            firstNumberElement.SendKeys("5");
            secondNumberElement.SendKeys("2");
            sumButton.Click();
            
            Assert.AreEqual("7", displaySumElement.Text);
        }
    }
}
