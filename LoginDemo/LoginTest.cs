using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LoginDemo
{
    public class Tests
    {

        [Test]
        public void EnterLoginTrue()
        {
            IWebDriver driver = new ChromeDriver(@"C:\driver\chromedriver");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector("#login > button")).Click();
        }
    }
}