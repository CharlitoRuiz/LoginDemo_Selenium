﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Text;

namespace LoginDemo.PageObject.Login
{
    [TestFixture]
    public class LoginPage
    {
        public IWebDriver _webDriver;
        public string baseUrl;

        public LoginPage(string url, IWebDriver driver){
            this._webDriver = driver;
            this.baseUrl = url;
        }

        // Localizadores
        private By txtLogin = By.Id("username");
        private By txtPass = By.Id("password");
        private By btnLogin = By.CssSelector("#login > button");

        // Set
        public IWebElement set_txtUser() { return _webDriver.FindElement(this.txtLogin); }
        public IWebElement set_txtPass() { return _webDriver.FindElement(this.txtPass); }
        public IWebElement set_btnLogin() { return _webDriver.FindElement(this.btnLogin); }

        // Metodos
        public void enterCredentials()
        {
            set_txtUser().SendKeys("tomsmith");
            set_txtPass().SendKeys("SuperSecretPassword!");
        }

        public void clickButtom()
        {
            set_btnLogin().Click();
        }
    }

}