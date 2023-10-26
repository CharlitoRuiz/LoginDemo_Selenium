using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDemo.Genericos
{
    public class Screenshots
    {
        public string takeScreenshot(IWebDriver driver)
        {
            string photo = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
            return photo;
        }
    }
}
