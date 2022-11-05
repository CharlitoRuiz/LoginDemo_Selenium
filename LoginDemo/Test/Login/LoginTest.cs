using LoginDemo.Genericos;
using LoginDemo.PageObject.Login;
using LoginDemo.Test;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace LoginDemo
{
    [TestFixture]
    public class Tests : BaseTest
    {
        CargarJson logindata = new CargarJson();

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
    }
}