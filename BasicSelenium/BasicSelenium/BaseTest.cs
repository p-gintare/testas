using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace BasicSelenium.Tests
{
   public class BaseTest
   {
       public IWebDriver driver;

       [SetUp]
       public void BeforeBase()
       {
           driver = new ChromeDriver();
           driver.Manage().Window.Maximize();
       }

       [TearDown]
       public void AfterBase()
       {
           driver.Quit();
       }
   }
}
