using System;
using BasicSelenium.Pabes;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BasicSelenium.Pages
{
    public class BasicFirstFormDemoPage : BasePage
    {
        private IWebElement messageElement => driver.FindElement(By.Id("user-message"));
        private IWebElement showMessageButton => driver.FindElement(By.CssSelector("#get-input button"));
        private IWebElement displayMessageElement => driver.FindElement(By.Id("display"));

        IWebElement firstNumberElement => driver.FindElement(By.Id("sum1"));
        IWebElement secondNumberElement => driver.FindElement(By.Id("sum2"));
        IWebElement sumButton => driver.FindElement(By.CssSelector("#gettotal button"));
        IWebElement displaySumElement => driver.FindElement(By.Id("displayvalue"));

        public BasicFirstFormDemoPage(IWebDriver driver) : base(driver) { }

        public BasicFirstFormDemoPage EnterMessage(string text)
        {
            messageElement.SendKeys(text);
            return this;
        }

        public BasicFirstFormDemoPage ClickShowMessage()
        {
            showMessageButton.Click();
            return this;
        }

        public void AssertUserMessageIs(string text)
        {
            Assert.AreEqual(text, displayMessageElement.Text);
        }

        public void EnterFirstNumber(string number)
        {
            firstNumberElement.SendKeys(number);
        }

        public void EnterSecondNumber(string number)
        {
            secondNumberElement.SendKeys(number);
        }

        public void EnterFirstAndSecondNumbers(string number1, string number2)
        {
            firstNumberElement.SendKeys(number1);
            secondNumberElement.SendKeys(number2);
        }

        public void ClickCalculateSum()
        {
            sumButton.Click();
        }

        public void AssertSum(string expectedSum)
        {
            Assert.AreEqual(expectedSum, displaySumElement.Text);
        }
    }
}
