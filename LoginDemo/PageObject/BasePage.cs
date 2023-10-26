using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDemo.PageObject
{
    [TestFixture]
    public class BasePage
    {
        public IWebDriver _webDriver;
        public string baseUrl;

        public BasePage(string url, IWebDriver driver)
        {
            this._webDriver = driver;
            this.baseUrl = url;
        }
    }
}
