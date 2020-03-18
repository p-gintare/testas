using OpenQA.Selenium;

namespace BasicSelenium.LoginTest.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
