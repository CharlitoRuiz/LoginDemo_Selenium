using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace LoginDemo.Test
{
    [TestFixture]
    public class BaseTest
    {
        public IWebDriver driver;
        public string baseURL = "https://the-internet.herokuapp.com/login";
        public static ExtentTest test;
        public static ExtentReports extent;


        [SetUp]
        public void ConfigBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);

        }

        [OneTimeSetUp]
        public void ReportStart()
        {
            extent = new ExtentReports();
            ExtentV3HtmlReporter htmlreporter = new ExtentV3HtmlReporter(@"..\..\..\Reports\" + this.GetType().ToString() + 
                DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);
            htmlreporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
        }

        [OneTimeTearDown]
        public void closeReporter()
        {
            extent.Flush();
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
