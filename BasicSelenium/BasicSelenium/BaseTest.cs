using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BasicSelenium.Tests
{
    [SetUpFixture]
    public class BaseTest
   {
       
       public IWebDriver driver;

       [SetUp]
       public void BeforeBase()
       {
           driver = new ChromeDriver();
           driver.Manage().Window.Maximize();
          // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
       }

       [TearDown]
       public void AfterBase()
       {
           driver.Quit();
       }
   }




   // kas yra interfeisas cia jau po paskaitos kiek snekejom
    public interface IAnimal
   {
       public void Voice();
       public void Food();
   }

   public class Cat : IAnimal
   {
       public void Voice()
       {
           Console.WriteLine("mew");
       }

       public void Food()
       {
           Console.WriteLine("royal");
        }
   }

   public class Dog : IAnimal
   {
       public void Voice()
       {
           Console.WriteLine("au");
        }

       public void Food()
       {
           Console.WriteLine("dog food");
        }
   }

   public class Tmp
   {
       private IAnimal animal;

       public void M()
       {
           animal = new Dog();
           animal = new Cat();
       }
   }
}
