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

        [SetUp]
        public void ConfigBrowser()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);

        }

        [Test]
        public void EnterLoginTrue()
        {
            LoginPage login = new LoginPage(baseURL, driver);
            login.enterCredentials();
            login.clickButtom();
            driver.FindElement(By.CssSelector("#login > button")).Click();
        }
        [Test]
        public void InvalidLogin()
        {
            LoginPage login = new LoginPage(baseURL, driver);
            driver.FindElement(By.Id("username")).SendKeys("user");
            driver.FindElement(By.Id("password")).SendKeys("Pass");
            driver.FindElement(By.CssSelector("#login > button")).Click();

        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
            driver.Quit();
        }
    }
}