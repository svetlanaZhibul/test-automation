using System;
using OpenQA.Selenium;
using Selenium.Chromedriver;
using NUnit.Framework;

namespace NUnit.Selenium.Chromedriver
{
    [TestFixture]
    public class AnyPageTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = Driver.Get();
        }

        [TearDown]
        public void Close()
        {
            Driver.Close();
        }
    }
}
