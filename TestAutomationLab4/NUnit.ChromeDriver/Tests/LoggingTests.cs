using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnitChromeDriver.Pages;

namespace NUnitChromeDriver.Tests
{
    [TestFixture]
    public class LoggingTests
    {
        private const string BASE_URL = "https://rail.cc/ru";
        private const string INVALID_LOGIN = "sdfgh";
        private const string INVALID_PASSWORD = "";

        public static IWebDriver driver;

        public static string RelativePathToBinary
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().Location;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path) + @"\..\..\Binary";
                //return Assembly.GetAssembly(typeof(NUnit.ChromeDriver)).Location;
            }
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver(RelativePathToBinary);
            driver.Navigate().GoToUrl(BASE_URL);           
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [TestCase(INVALID_LOGIN, INVALID_PASSWORD)]
        public void FailLogging(string login, string password)
        {
            HomePage page = new HomePage(driver);

            HomePage noSkipPage = page.LoginAsUser(login, password);

            Assert.AreEqual(page, noSkipPage);
            Assert.IsNotNull(driver.FindElement(By.ClassName("text-error")));
        }

        [Test]
        public void SucceededLogging()
        {
            // TODO: Add your test code here
            //Assert.Pass("Your first passing test");
        }
    }
}
