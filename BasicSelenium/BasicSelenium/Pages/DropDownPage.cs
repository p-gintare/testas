using System;
using System.Collections.Generic;
using System.Text;
using BasicSelenium.Pabes;
using BasicSelenium.Values;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace BasicSelenium.Pages
{
    class DropDownPage : BasePage
    {
        public DropDownPage(IWebDriver driver) : base(driver) { }

        IWebElement dropdown => throw new StaleElementReferenceException(); //driver.FindElement(By.Id("select-demo"));

        SelectElement dropdownSelectElement => new SelectElement(dropdown);
        IWebElement displaySelectedDayElement => driver.FindElement(By.CssSelector(".selected-value"));

        IWebElement multiSelect => driver.FindElement(By.Id("multi-select"));
        SelectElement multiselectElement => new SelectElement(multiSelect);
        IWebElement printSingleButton => driver.FindElement(By.Id("printMe"));
        IWebElement showAllSelectedElement => driver.FindElement(By.CssSelector(".getall-selected"));
        IList<IWebElement> stateOptionElementList => multiselectElement.Options;
        IWebElement printAllButton => driver.FindElement(By.Id("printAll"));

        public void SelectDay(WeekDay weekDay)
        {
            dropdownSelectElement.SelectByValue(weekDay.day);
        }

        public DropDownPage SelectState(State state)
        {
            multiselectElement.SelectByValue(state.state);
            return this;
        }

        public DropDownPage SelectSecondState(State state)
        {
            var builder = new Actions(driver);
            builder.KeyDown(Keys.Control);
            builder.Click(stateOptionElementList[state.index]);
            builder.KeyUp(Keys.Control);
            builder.Build().Perform();
            return this;
        }

        public DropDownPage SelectMultiStates(List<State> stateList)
        {
            foreach (var state in stateList)
            {
                SelectSecondState(state);
            }
            return this;
        }

        public DropDownPage SelectMultiStates2()
        {
            SelectSecondState(State.CALIFORNIA);
            SelectSecondState(State.OHIO);
            return this;
        }

        public void AssertAllSelectedStates()
        {
            Assert.AreEqual($"Options selected are : {State.CALIFORNIA.state},{State.OHIO.state}", showAllSelectedElement.Text);
        }

        public DropDownPage ClickPrintSingle()
        {
            printSingleButton.Click();
            return this;
        }
        public DropDownPage ClickPrintAll()
        {
            printAllButton.Click();
            return this;
        }

        public DropDownPage AssertFirstSelectedState(State state)
        {
            Assert.AreEqual($"First selected option is : {state.state}", showAllSelectedElement.Text);
            return this;
        }

        public void AssertAllSelectedStates(List<State> stateList)
        {
            string stateList2 = "";
            foreach (var state in stateList)
            {
                stateList2 += $"{state.state},";
            }

            stateList2 = stateList2.Substring(0, stateList2.Length - 1);

            Assert.AreEqual($"Options selected are : {stateList2}", showAllSelectedElement.Text);
        }


    }
}
