using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.IO;
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
            //new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new EdgeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);

        }

        [OneTimeSetUp]
        public void ReportStart()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRootDirectory = Directory.GetParent(currentDirectory).Parent.Parent.Parent.FullName;

            string reportFolder = Path.Combine(projectRootDirectory, "Reportes");
            string reportPath = Path.Combine(reportFolder, "index.html");

            extent = new ExtentReports();
            ExtentSparkReporter htmlreporter = new ExtentSparkReporter(reportPath);
            extent.AttachReporter(htmlreporter);
            htmlreporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
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
