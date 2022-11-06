using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDemo.Genericos
{
    public class Screenshots
    {
        public void takeScreenshot(IWebDriver driver, string photoName)
        {
            Screenshot photo = ((ITakesScreenshot)driver).GetScreenshot();
            photo.SaveAsFile("C://driver//screens//" + photoName + ".png", ScreenshotImageFormat.Png);
        }
    }
}
