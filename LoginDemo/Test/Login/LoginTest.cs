using LoginDemo.Genericos;
using LoginDemo.PageObject.Login;
using LoginDemo.Test;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
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
            // Instancias
            LoginPage login = new LoginPage(baseURL, driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            string user = logindata.login_data().trueLogin.username;
            string pass = logindata.login_data().trueLogin.password;

            login.enterCredentials(user, pass);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(login.set_btnLogin()));
            login.clickButtom();
            Assert.IsTrue(login.set_msjAlert().Displayed);
        }
        [Test]
        public void InvalidLogin()
        {
            LoginPage login = new LoginPage(baseURL, driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            string user = logindata.login_data().badlogin.username;
            string pass = logindata.login_data().badlogin.password;

            login.enterCredentials(user, pass);

            login.clickButtom();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(login.set_msjAlert(), "username"));
            Assert.IsTrue(login.set_msjAlert().Text.Contains("username"));
            Assert.IsTrue(login.set_msjAlert().Text.StartsWith("Your"));

        }
    }
}