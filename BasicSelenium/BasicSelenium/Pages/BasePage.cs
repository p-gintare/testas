using OpenQA.Selenium;

namespace BasicSelenium.Pabes
{
    public class BasePage
    {
        protected IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
