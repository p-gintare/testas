using System.Collections.Generic;
using BasicSelenium.Pages;
using BasicSelenium.Values;
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
        private DropDownPage dropDownPage = null;

        [SetUp]
        public void BeforeTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
           dropDownPage = new DropDownPage(driver);
        }

        [Test]
        public void TestsSingleDropDown()
        {
            dropDownPage.SelectDay(WeekDay.MONDAY);
          //  Assert.AreEqual($"Day selected :- {WeekDay.MONDAY.day}", displaySelectedDayElement.Text);
          
        }

        [Test]
        public void MultiChoiseTests()
        {
            dropDownPage
            .SelectState(State.FLORIDA)
            .SelectSecondState(State.CALIFORNIA)
            .ClickPrintSingle()
            .AssertFirstSelectedState(State.FLORIDA);
        }

        [Test]
        public void MultiChoiseTests2()
        {
            dropDownPage
                .SelectState(State.OHIO)
                .SelectSecondState(State.CALIFORNIA)
                .SelectSecondState(State.FLORIDA)
                .ClickPrintSingle()
                .AssertFirstSelectedState(State.OHIO)
                .ClickPrintAll()
                .AssertAllSelectedStates(new List<State>{State.OHIO, State.CALIFORNIA, State.FLORIDA});
        }

        [Test]
        public void MultiChoiseTests3()
        {
            dropDownPage
                .SelectMultiStates(new List<State> { State.OHIO, State.CALIFORNIA, State.FLORIDA })
                .ClickPrintSingle()
                .AssertFirstSelectedState(State.OHIO)
                .ClickPrintAll()
                .AssertAllSelectedStates(new List<State> { State.OHIO, State.CALIFORNIA, State.FLORIDA });


        }

        [Test]
        public void MultiChoiseTests4()
        {
            dropDownPage
                .SelectMultiStates2()
                .ClickPrintSingle()
                .AssertFirstSelectedState(State.CALIFORNIA)
                .ClickPrintAll()
                .AssertAllSelectedStates();


        }
    }
}
