using LoginDemo.PageObject.Login;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LoginDemo
{
    public class Tests
    {
        IWebDriver driver = new ChromeDriver(@"C:\driver\chromedriver");
        string baseURL = "https://the-internet.herokuapp.com/login";

        [Test]
        public void EnterLoginTrue()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);
            LoginPage login = new LoginPage(baseURL, driver);
            login.enterCredentials();
            login.clickButtom();
            driver.Close();
            driver.Quit();
        }
        [Test]
        public void InvalidLogin()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("username")).SendKeys("user");
            driver.FindElement(By.Id("password")).SendKeys("Pass");
            driver.FindElement(By.CssSelector("#login > button")).Click();
            driver.Close();
            driver.Quit();

        }
    }
}