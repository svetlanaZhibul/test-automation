using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Chromedriver
{
    public static class Driver
    {
        private static IWebDriver driver;

        public static IWebDriver Get()
        {
            if (driver == null)
            {
                driver = new ChromeDriver(@"D:\programs\Selenium");
                driver.Manage().Window.Maximize();
            }

            return driver;
        }

        public static void SetWaitTime(int seconds)
        {
            if (driver != null)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
            }
        }

        public static void Close()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}
