using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LoginDemo
{
    public class Tests
    {
        IWebDriver driver = new ChromeDriver(@"C:\driver\chromedriver");

        [Test]
        public void EnterLoginTrue()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector("#login > button")).Click();
            driver.Close();
            driver.Quit();
        }
        [Test]
        public void InvalidLogin()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
            driver.FindElement(By.Id("username")).SendKeys("user");
            driver.FindElement(By.Id("password")).SendKeys("Pass");
            driver.FindElement(By.CssSelector("#login > button")).Click();
            driver.Close();
            driver.Quit();

        }
    }
}