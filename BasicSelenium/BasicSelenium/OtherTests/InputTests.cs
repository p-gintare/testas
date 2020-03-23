using System.Threading;
using BasicSelenium.Pages;
using NUnit.Framework;
using OpenQA.Selenium;


namespace BasicSelenium.Tests
{
    public class InputTests : BaseTest
    {
        private BasicFirstFormDemoPage basicFirstFormDemoPage;

        [SetUp]
        public void Setup()
        {
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
           
            basicFirstFormDemoPage = new BasicFirstFormDemoPage(driver);
            
        }

        [Test]
        public void TestUserCanSendAndViewMessage()
        {
            var myText = "beleka";
            basicFirstFormDemoPage
                .EnterMessage(myText)
                .ClickShowMessage();
            basicFirstFormDemoPage.AssertUserMessageIs(myText);
        }

        [Test]
        public void CountSum()
        {
           basicFirstFormDemoPage.EnterFirstNumber("1");
           basicFirstFormDemoPage.EnterSecondNumber("3");
           basicFirstFormDemoPage.ClickCalculateSum();
           basicFirstFormDemoPage.AssertSum("4");
        }

        [Test]
        public void CountSum2()
        {
            basicFirstFormDemoPage.EnterFirstAndSecondNumbers("1", "3");
            basicFirstFormDemoPage.ClickCalculateSum();
            basicFirstFormDemoPage.AssertSum("4");

            driver.FindElement(By.CssSelector(".b-login-form--login-button")).Click();
            Thread.Sleep(5000);
            Assert.AreEqual("https://www.barbora.lt/akcijos", driver.Url);
        }
    }
}
