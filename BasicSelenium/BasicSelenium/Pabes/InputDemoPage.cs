

using OpenQA.Selenium;

namespace BasicSelenium.Pabes
{
    class InputDemoPage
    {
        private IWebDriver driver;

        public InputDemoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement userInputElement => driver.FindElement(By.Id("user-message"));
        private IWebElement showMessageButton => driver.FindElement(By.CssSelector("#get-input .btn"));
        private IWebElement diplsayTextElement => driver.FindElement(By.CssSelector("#user-message #display"));

        public InputDemoPage EnterText(string text)
        {
            userInputElement.SendKeys(text);
            return this;
        }

        public InputDemoPage ClickShowMessage()
        {
            showMessageButton.Click();
            return this;
        }

        public string GetUserMessage()
        {
            return diplsayTextElement.GetProperty("value");
        }
    }
}
