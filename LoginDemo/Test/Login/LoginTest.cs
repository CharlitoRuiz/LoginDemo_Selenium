using AventStack.ExtentReports;
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
            Screenshots screenshot = new Screenshots();
            test = extent.CreateTest("Enter login true");

            string user = logindata.login_data().trueLogin.username;
            string pass = logindata.login_data().trueLogin.password;
            string photo;


            try
            {
                login.enterCredentials(user, pass);
                test.Log(Status.Pass, "Enter valid credentials");
                photo = screenshot.takeScreenshot(driver);
                test.AddScreenCaptureFromBase64String(photo);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(login.set_btnLogin()));
                login.clickButtom();
                test.Log(Status.Pass, "Enter the site");
                Assert.IsTrue(login.set_msjAlert().Displayed);
                test.Log(Status.Pass, "Validate the message");
                photo = screenshot.takeScreenshot(driver);
                test.AddScreenCaptureFromBase64String(photo);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [Test]
        public void InvalidLogin()
        {
            LoginPage login = new LoginPage(baseURL, driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Screenshots screenshot = new Screenshots();
            test = extent.CreateTest("Enter incorrect login");

            string user = logindata.login_data().badlogin.username;
            string pass = logindata.login_data().badlogin.password;
            string photo;


            try
            {
                login.enterCredentials(user, pass);
                test.Log(Status.Pass, "Enter invalid credentials");
                login.clickButtom();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(login.set_msjAlert(), "username"));
                Assert.IsTrue(login.set_msjAlert().Text.Contains("username"));
                Assert.IsTrue(login.set_msjAlert().Text.StartsWith("Your"));
                test.Log(Status.Pass, "Validate the fail message");
                photo = screenshot.takeScreenshot(driver);
                test.AddScreenCaptureFromBase64String(photo);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}