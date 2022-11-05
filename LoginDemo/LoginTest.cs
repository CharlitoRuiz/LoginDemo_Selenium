using LoginDemo.Genericos;
using LoginDemo.PageObject.Login;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace LoginDemo
{
    public class Tests
    {
        public IWebDriver driver;
        string baseURL = "https://the-internet.herokuapp.com/login";
        CargarJson logindata = new CargarJson();

        [SetUp]
        public void ConfigBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);

        }

        [Test]
        public void EnterLoginTrue()
        {
            LoginPage login = new LoginPage(baseURL, driver);
            string user = logindata.login_data().trueLogin.username;
            string pass = logindata.login_data().trueLogin.password;

            login.enterCredentials(user, pass);
            login.clickButtom();
        }
        [Test]
        public void InvalidLogin()
        {
            LoginPage login = new LoginPage(baseURL, driver);
            string user = logindata.login_data().badlogin.username;
            string pass = logindata.login_data().badlogin.password;

            login.enterCredentials(user, pass);
            login.clickButtom();

        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
            driver.Quit();
        }
    }
}